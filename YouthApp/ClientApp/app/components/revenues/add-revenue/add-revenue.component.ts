import { Component } from '@angular/core';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { IRevenues } from '../../../models/IRevenues';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RevenueHttpService } from '../../../http/revenues/revenues-http-service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-add-revenue',
    templateUrl: './add-revenue.component.html',
    styleUrls: ['./add-revenue.component.css']
})
/** add-revenue component*/
export class AddRevenueComponent implements IHttpHelper<IRevenues> {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    list: IRevenues[];
    form: FormGroup;
    dismiss: boolean = false;
    constructor(route: ActivatedRoute, private http: RevenueHttpService, fb: FormBuilder) {
        this.list = route.snapshot.data['revenues'];
        this.form = fb.group({
            accountName: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(100)])],
            accountNumber: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
            source: ["", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(10)])],
            bank: ["", Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])]
        });
    }

    onDelete(item: IRevenues): void {
        let ix: number = this.list.findIndex(x => x.revenuesID == item.revenuesID);
        this.list.splice(ix, 1);
        alert("Account details were deleted");
    }

    delete(item: IRevenues) {
        if (confirm("Do you want to delete this account information.\nIt is irreversible and related data may be deleted")) {
            let pr = prompt("Enter the account number for confirmation");
            if (pr === item.accountNumber) {
                if (confirm("Confirm the last time you know what you are doing")) {
                    this.http.delete(item).subscribe(res => this.onDelete(item), (err: HttpErrorResponse) => this.onError(err));
                }
            }
            else { alert("Confirmation failed.\nPlease begin the process again"); }
        }
    }

    onError(err: HttpErrorResponse): void {
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
    }
    onSuccess(item: IRevenues): void {
        this.error = false;
        this.list.unshift(item);
        this.form.reset();
    }

    add(rev: IRevenues) {
        this.processing = true;
        this.error = false;
        this.http.add(rev).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
    }


}