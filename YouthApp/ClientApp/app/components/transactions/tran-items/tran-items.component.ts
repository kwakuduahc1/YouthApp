import { Component } from '@angular/core';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { ITransactionItems } from '../../../models/ItranItems';
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TransactionItemsHttpService } from '../../../http/tran-items/tran-items-http-service';

@Component({
    selector: 'app-tran-items',
    templateUrl: './tran-items.component.html',
    styleUrls: ['./tran-items.component.css']
})
/** tran-items component*/
export class TranItemsComponent implements IHttpHelper<ITransactionItems> {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    items: ITransactionItems[];
    form: FormGroup;
    dismiss: boolean = true;
    constructor(route: ActivatedRoute, private http: TransactionItemsHttpService, fb: FormBuilder) {
        this.items = route.snapshot.data['items'];
        this.form = fb.group({
            transactionItem: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])]
        });
    }

    add(item: ITransactionItems) {
        if (this.items.some(t => t.transactionItem === item.transactionItem)) {
            alert(`${item.transactionItem} already exists`);
        }
        else {
            this.processing = true;
            this.error = false;
            this.dismiss = true;
            this.http.add(item).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        }
    }
    onDelete(item: ITransactionItems): void {
        throw new Error("Method not implemented.");
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
    onSuccess(item: ITransactionItems): void {
        this.message = "Item was added successfully";
        this.items.unshift(item);
        this.form.reset();
        alert(this.message);
        this.dismiss = false;
        setTimeout(() => this.showDelay(), 250);
    }

    showDelay(): any {
        this.dismiss = true;
    }

}