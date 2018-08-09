import { Component } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { IBillItems } from '../../../models/IBillItems';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { BillItemHttpService } from '../../../http/bill-items/bill-items-service';


@Component({
    selector: 'app-add-bill-item',
    templateUrl: './add-bill-item.component.html',
    styleUrls: ['./add-bill-item.component.css']
})
/** add-bill-item component*/
export class AddBillItemComponent implements IHttpHelper<IBillItems> {
    error: boolean = false;
    message: string = "";
    form: FormGroup;
    items: IBillItems[];
    processing: boolean = false;
    constructor(fb: FormBuilder, route: ActivatedRoute, private http: BillItemHttpService) {
        this.items = route.snapshot.data["items"] as IBillItems[];
        this.form = this.InitForm(fb);
    }

    InitForm(fb: FormBuilder): FormGroup {
        return fb.group({
            billItem: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(100)])]
        });
    }

    add(cl: IBillItems) {
        this.processing = true;
        this.error = false;
        this.http.add(cl).subscribe(res => {
            this.onSuccess(res);
        }, (err: HttpErrorResponse) => {
            if (err!.error!.message) {
                alert(err.error.message);
            }
            else {
                alert("Unrecognized error occurred. Contact support");
            }
        });
        this.processing = false;
    }

    onDelete(item: IBillItems): void {
        let ix: number = this.items.findIndex(x => x.billItemsID === item.billItemsID);
        this.items.splice(ix, 1);
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
            this.http.delete(item).subscribe(() => this.onDelete(item), (err: HttpErrorResponse) => this.onError(err));
        }
    }

    onSuccess(item: IBillItems): void {
        this.items.unshift(item);
        this.processing = false;
        this.form.reset();
    }
}