import { Component } from '@angular/core';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { IRevenues } from '../../../models/IRevenues';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { RevenueHttpService } from '../../../http/revenues/revenues-http-service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-edit-revenue',
    templateUrl: './edit-revenue.component.html',
    styleUrls: ['./edit-revenue.component.css']
})
/** edit-revenue component*/
export class EditRevenueComponent implements IHttpHelper<IRevenues> {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    rev: IRevenues;
    form: FormGroup;

    constructor(route: ActivatedRoute, private http: RevenueHttpService, fb: FormBuilder, private router:Router) {
        this.rev = route.snapshot.data['revenue'];
        this.form = fb.group({
            accountName: [this.rev.accountName, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(100)])],
            accountNumber: [this.rev.accountNumber, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
            source: [this.rev.source, Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(10)])],
            bank: [this.rev.bank, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])]
        })
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
        alert(this.message);
    }

    onSuccess(item: IRevenues): void {
        this.router.navigate(['/add-revenue']);
    }

    edit(rev: IRevenues) {
        this.processing = true;
        this.error = false;
        rev.revenuesID = this.rev.revenuesID;
        this.http.edit(rev).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        this.processing = false;
    }

    onDelete(item: IRevenues): void {
        throw new Error("Method not implemented.");
    }
}