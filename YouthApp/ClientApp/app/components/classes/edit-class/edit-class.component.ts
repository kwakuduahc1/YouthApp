import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { ClassesHttpService } from '../../../http/classes/classes-http-service';
import { IMainClasses } from '../../../models/IClasses';
import { IHttpHelper } from '../../../http/IHttpHelper';
@Component({
    selector: 'app-edit-class',
    templateUrl: './edit-class.component.html',
    styleUrls: ['./edit-class.component.css']
})
/** edit-class component*/
export class EditClassComponent implements IHttpHelper<IMainClasses> {
    error: boolean = false;
    message: string = "";
    form: FormGroup;
    _class: IMainClasses;
    processing: boolean = false;
    dismiss: boolean = false;
    constructor(fb: FormBuilder, route: ActivatedRoute, private http: ClassesHttpService, private router:Router) {
        this._class = route.snapshot.data["class"] as IMainClasses;
        this.form = fb.group({
            className: [this._class.className, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(20)])]
        });
    }

    edit(cl: IMainClasses) {
        this.processing = true;
        this.error = false;
        this._class.className = cl.className.toUpperCase();
        this.http.edit(this._class).subscribe(res => {
            this.onSuccess(res);
        }, (err: HttpErrorResponse) => {
            this.onError(err);
        });
        this.processing = false;
    }

    onDelete(item: IMainClasses): void {
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
    onSuccess(item: IMainClasses): void {
        this.router.navigate(['/classes']);
    }
}