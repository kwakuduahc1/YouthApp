import { Component } from '@angular/core';
import { ITransactionsTypes } from '../../../models/ITransactionTypes';
import { ITransactionItems } from '../../../models/ItranItems';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { ITransactions } from '../../../models/ITransactions';
import { ActivatedRoute } from '@angular/router';
import { TransactionsHttpService } from '../../../http/transactions/payments-http-service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { IRevenues } from '../../../models/IRevenues';
import { tick } from '@angular/core/testing';

@Component({
    selector: 'app-receive-transaction',
    templateUrl: './receive-transaction.component.html',
    styleUrls: ['./receive-transaction.component.css']
})
/** receive-transaction component*/
export class ReceiveTransactionComponent implements IHttpHelper<ITransactions> {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    dismiss: boolean = false;
    types: ITransactionsTypes;
    items: ITransactionItems[];
    form: FormGroup;
    trans: ITransactions[];
    revs: IRevenues[];
    findForm: FormGroup;
    constructor(private route: ActivatedRoute, private http: TransactionsHttpService, fb: FormBuilder) {
        this.types = route.snapshot.data['types'];
        this.items = route.snapshot.data['items'];
        this.trans = route.snapshot.data['trans'];
        this.revs = route.snapshot.data['revs'];
        this.form = fb.group({
            amount: ["", Validators.compose([Validators.required, Validators.min(0)])],
            revenuesID: ["", Validators.compose([Validators.required, Validators.min(1)])],
            purpose: ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(100)])],
            transactionItemsID: ['', Validators.compose([Validators.required, Validators.min(1)])]
        });
        this.findForm = fb.group({
            qry: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(10)])]
        })
    }

    add(tran: ITransactions) {
        if (confirm("Confirm the details of this transaction")) {
            tran.transactionsTypesID = 1;
            this.processing = true;
            this.error = false;
            this.http.receive(tran).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
            this.processing = false;
        }
    }

    delete(tran: ITransactions) {
        if (confirm('Deleting this is irreversible. Click okay to confirm')) {
            this.processing = true;
            this.error = false;
            this.http.delete(tran).subscribe(res => this.onDelete(tran), (err: HttpErrorResponse) => this.onError(err));
        }
    }

    onDelete(item: ITransactions): void {
        let ix: number = this.trans.findIndex(x => x.transactionsID === item.transactionsID);
        this.trans.splice(ix, 1);
        alert("Delete was successful");
    }

    onError(err: HttpErrorResponse): void {
        this.dismiss = !this.dismiss;
        if (err.error!.message) {
            this.message = err.error.message;
        }
        else {
            switch (err.status) {
                case 500:
                    this.message = "A server error occurred. Contact support";
                    break;
                case 400:
                    this.message = err.error!.message;
                    break;
                default:
                    this.message = "An unexpected error occurred. Contact support";
                    break;

            }
        }
        this.error = true;
    }

    onSuccess(item: ITransactions): void {
        item.accountName = this.revs.find(t => t.revenuesID === item.revenuesID)!.accountName;
        item.accountNumber = this.revs.find(t => t.revenuesID === item.revenuesID)!.accountNumber;
        item.source = this.revs.find(t => t.revenuesID === item.revenuesID)!.source;
        item.transactionType = 'Revenue';
        item.transactionItem = this.items.find(x => x.transactionItemsID === item.transactionItemsID)!.transactionItem;
        this.trans.unshift(item);
        this.form.reset();
    }

    search(qry: string) {
        this.processing = true;
        this.http.search(qry).subscribe(res => this.trans = res, (err: HttpErrorResponse) => this.onError(err));
        this.processing = false;
    }

    reset() {
        this.trans = this.route.snapshot.data['trans'];
    }
}