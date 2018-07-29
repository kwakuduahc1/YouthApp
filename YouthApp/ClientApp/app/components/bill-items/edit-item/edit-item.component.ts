import { Component } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRouteSnapshot, ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { IBillItems } from '../../../models/IBillItems';
import { BillItemHttpService } from '../../../http/bill-items/bill-item.service';
import { IHttpHelper } from '../../../http/IHttpHelper';

@Component({
    selector: 'app-edit-item',
    templateUrl: './edit-item.component.html',
    styleUrls: ['./edit-item.component.css']
})
/** edit-item component*/
export class EditItemComponent implements IHttpHelper<IBillItems> {
    error: boolean = false;
    message: string = "";
    form: FormGroup;
    item: IBillItems;
    processing: boolean = false;
    constructor(fb: FormBuilder, route: ActivatedRoute, private http: BillItemHttpService, private router: Router) {
        this.item = route.snapshot.data["item"];
        this.form = fb.group({
            billItem: [this.item.billItem, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(20)])]
        });
    }


    edit(cl: IBillItems) {
        this.processing = true;
        this.error = false;
        this.item.billItem = cl.billItem.toUpperCase();
        this.http.edit(this.item).subscribe(res => {
            this.onSuccess(res);
        }, (err: HttpErrorResponse) => {
            this.processing = false;
            if (err!.error!.message) {
                alert(err.error.message);
            }
            else {
                alert("Unrecognized error occurred. Contact support");
            }
        });
    }

    onDelete(): void {
        this.router.navigate(['/bill-items'])
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

    delete(item: IBillItems) {
        if (confirm(`Do you want to delete ${item.billItem} from the list?\nIt is irreversible.`)) {
            this.processing = true;
            this.error = false;
            this.http.delete(this.item).subscribe(res => this.onSuccess(this.item), (err: HttpErrorResponse) => this.onError(err));
        }
    }

    onSuccess(item: IBillItems): void {
        this.onDelete();
    }
}