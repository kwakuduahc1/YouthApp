import { Component } from '@angular/core';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { ITransactionItems } from '../../../models/ItranItems';
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionItemsHttpService } from '../../../http/tran-items/tran-items-http-service';

@Component({
    selector: 'app-edit-tran-item',
    templateUrl: './edit-tran-item.component.html',
    styleUrls: ['./edit-tran-item.component.css']
})
/** edit-tran-item component*/
export class EditTranItemComponent implements IHttpHelper<ITransactionItems> {
    onDelete(item: ITransactionItems): void {
        throw new Error("Method not implemented.");
    }
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    item: ITransactionItems;
    form: FormGroup;
    dismiss: boolean = true;
    constructor(route: ActivatedRoute, private http: TransactionItemsHttpService, fb: FormBuilder, private router:Router) {
        this.item = route.snapshot.data['item'];
        this.form = fb.group({
            transactionItem: [this.item.transactionItem, Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])]
        });
    }

    add(item: ITransactionItems) {
        this.processing = true;
        this.error = false;
        this.dismiss = true;
        this.item.transactionItem = item.transactionItem
        this.http.edit(this.item).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        this.processing = false;
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
        this.message = "Edit was successful";
        this.form.reset();
        alert(this.message);
        this.dismiss = false;
        this.router.navigate(['/tran-items']);
    }
}