import { Component } from '@angular/core';
import { ITransactionsTypes } from '../../../models/ITransactionTypes';
import { ITransactionItems } from '../../../models/ItranItems';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { ITransactions } from '../../../models/ITransactions';
import { ActivatedRoute, Router, Route } from '@angular/router';
import { TransactionsHttpService } from '../../../http/transactions/payments-http-service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { IRevenues } from '../../../models/IRevenues';
import { tick } from '@angular/core/testing';

@Component({
    selector: 'app-edit-transaction',
    templateUrl: './edit-transaction.component.html',
    styleUrls: ['./edit-transaction.component.css']
})
/** edit-transaction component*/
export class EditTransactionComponent implements IHttpHelper<ITransactions> {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    dismiss: boolean = false;
    types: ITransactionsTypes;
    items: ITransactionItems[];
    form: FormGroup;
    tran: ITransactions;
    revs: IRevenues[];
   // prev_route: string;
    constructor(private route: ActivatedRoute, private http: TransactionsHttpService, fb: FormBuilder, private router: Router) {
      //  console.log(rut.path);
        this.types = route.snapshot.data['types'];
        this.items = route.snapshot.data['items'];
        this.revs = route.snapshot.data['revs'];
        this.tran = route.snapshot.data['tran'];
        this.form = fb.group({
            amount: [this.tran.amount, Validators.compose([Validators.required, Validators.min(0)])],
            revenuesID: [this.tran.revenuesID, Validators.compose([Validators.required, Validators.min(1)])],
            purpose: [this.tran.purpose, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(100)])],
            transactionItemsID: [this.tran.transactionItemsID, Validators.compose([Validators.required, Validators.min(1)])]
        });
    }

    add(tran: ITransactions) {
        this.onSuccess(tran);
        //if (confirm("Confirm the details of this transaction")) {
        //    tran.transactionsTypesID = 2;
        //    this.processing = true;
        //    this.error = false;
        //    this.http.issue(tran).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        //    this.processing = false;
        //}
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
        var url = this.route.snapshot.url;
        console.log(url[0].path);
        // this.router.navigateByUrl(url.)
    }

    onDelete(item: ITransactions): void {
        throw new Error("Method not implemented.");
    }
}