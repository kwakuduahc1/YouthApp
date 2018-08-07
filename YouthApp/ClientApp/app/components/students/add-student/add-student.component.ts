import { Component } from '@angular/core';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { IStudents } from '../../../models/IStudents';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { StudentsHttpService } from '../../../http/students/students-http-service';
import { IMainClasses } from '../../../models/IClasses';
import { HttpErrorResponse } from '@angular/common/http';
import { transition } from '@angular/animations';
import { PrintProviderService } from '../../../providers/print-provider.service';

@Component({
    selector: 'app-add-student',
    templateUrl: './add-student.component.html',
    styleUrls: ['./add-student.component.css']
})
/** add-student component*/
export class AddStudentComponent implements IHttpHelper<IStudents> {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    form: FormGroup;
    dismiss: boolean = false;
    students: IStudents[];
    _class: IMainClasses;
    constructor(route: ActivatedRoute, private http: StudentsHttpService, fb: FormBuilder, private printer: PrintProviderService) {
        this.students = route.snapshot.data['students'];
        this._class = route.snapshot.data['class'];
        this.form = fb.group({
            surname: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
            otherNames: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
            gender: ['', Validators.compose([Validators.required, Validators.minLength(4), Validators.maxLength(6)])],
            level: ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(20)])],
            dateOfBirth: ['', Validators.compose([Validators.required])]
        })
    }
    onDelete(item: IStudents): void {
        throw new Error("Method not implemented.");
    }
    onError(err: HttpErrorResponse): void {
        this.dismiss = true;
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
        alert(this.message);
    }

    onSuccess(item: IStudents): void {
        this.students.unshift(item);
        this.form.reset();
    }

    register(std: IStudents) {
        this.processing = true;
        this.error = false;
        std.classesID = this._class.classesID;
        this.http.add(std).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        this.processing = false;
    }

    change(std: IStudents) {
        this.processing = true;
        this.error = false;
        if (confirm(`Do you want to change the status of ${std.surname} ${std.otherNames ? std.otherNames : ''}?`)) {
            this.http.change(std).subscribe(res => {
                std.isActive = !std.isActive;
            }, (err: HttpErrorResponse) => this.onError(err));
            this.processing = false;
        }
    }

    print() {
        this.printer.print('print', `List of student in ${this._class.className}`)
    }
}