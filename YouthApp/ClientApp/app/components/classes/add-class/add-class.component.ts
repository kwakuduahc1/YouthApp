import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { ClassesHttpService } from '../../../http/classes/classes-http-service';
import { IMainClasses } from '../../../models/IClasses';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { IPrograms } from '../../../models/IPrograms';

@Component({
    selector: 'app-add-class',
    templateUrl: './add-class.component.html',
    styleUrls: ['./add-class.component.css']
})
/** add-class component*/
export class AddClassComponent implements IHttpHelper<IMainClasses> {
    error: boolean = false;
    message: string = "";
    form: FormGroup;
    classes: IMainClasses[];
    processing: boolean = false;
    dismiss: boolean = false;
    programs: IPrograms[];
    constructor(fb: FormBuilder, route: ActivatedRoute, private http: ClassesHttpService) {
        this.classes = route.snapshot.data["classes"] as IMainClasses[];
        this.programs = route.snapshot.data['programs'] as IPrograms[];
        this.form = fb.group({
            className: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(20)])],
            programsID:["", Validators.compose([Validators.required])]
        });
    }

    add(cl: IMainClasses) {
        this.processing = true;
        this.error = false;
        cl.className = cl.className.toUpperCase();
        this.http.add(cl).subscribe(res => {
            this.onSuccess(res);
        }, (err: HttpErrorResponse) => {
            this.onError(err);
        });
        this.processing = false;
    }

    change(cl: IMainClasses) {
        if (confirm(`Are you sure you want to mark this class (${cl.className}) as inactive?\n${cl.className} will not be deleted but it will not show up in the list of classes.`)) {
            this.processing = true;
            this.error = false;
            this.http.change(cl).subscribe(res => {
                this.error = false;
                cl.isActive = false;
            }, (err: HttpErrorResponse) => this.onError(err));
            this.processing = false;
        }

    }

    delete(i: IMainClasses) {
        if (confirm(`Deleting ${i.className} is irreversible. Do you want to continue? You can optional deactivate the class instead`)) {
            this.processing = true;
            this.error = false;
            this.http.delete(i).subscribe(() => this.onDelete(i), (err: HttpErrorResponse) => this.onError(err));
            this.processing = false;
        }
    }

    onDelete(item: IMainClasses): void {
        let ix: number = this.classes.findIndex(x => x.classesID == item.classesID);
        this.classes.splice(ix, 1);
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
        this.classes.unshift(item);
        this.form.reset();
    }
}