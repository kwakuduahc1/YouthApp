import { Component } from '@angular/core';
import { IMainClasses } from '../../../../models/IClasses';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IStudents } from '../../../../models/IStudents';
import { ActivatedRoute } from '@angular/router';
import { StudentsHttpService } from '../../../../http/students/students-http-service';
import { IPayments } from '../../../../models/IPayments';
import { StudentPaymentsHttpService } from '../../../../http/students/payments-http-service';
import { HttpErrorResponse } from '@angular/common/http';
import { PrintProviderService } from '../../../../providers/print-provider.service';

@Component({
    selector: 'app-student-payments',
    templateUrl: './student-payments.component.html',
    styleUrls: ['./student-payments.component.css']
})
/** student-payments component*/
export class StudentPaymentsComponent {
    classes: IMainClasses[];
    form: FormGroup;
    payments: IPayments[] = [];
    bForm: FormGroup | undefined;
    stds: IStudents[] = [];
    std: IStudents | undefined;
    message = "";
    error = false;
    constructor(route: ActivatedRoute, private http: StudentsHttpService, private fb: FormBuilder, private pay_http:StudentPaymentsHttpService, private printer:PrintProviderService) {
        this.classes = route.snapshot.data['classes'];
        this.form = fb.group({
            _class: ["", Validators.compose([Validators.required])],
            std: ["", Validators.required]
        });

    };

    classChange(cl: IMainClasses) {
        this.http.classList(cl.classesID).subscribe(res => this.stds = res);
    }

    stdChange(std: IStudents) {
        this.std = std;
        this.bForm = this.fb.group({
            gCr: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(0.1)])]
        });
        this.pay_http.list(std.studentsID).subscribe(res => this.payments = res, (err: HttpErrorResponse) => this.onError(err));
    }

    receive(pay: IPayments) {
        if (confirm(`Have you received ${pay.amount} from ${this.std!.surname} ${this.std!.otherNames}`)) {
            pay.receiver = "accountant received";
            pay.studentsID = this.std!.studentsID as number;
            this.error = false;
            this.message = "";
            this.pay_http.add(pay).subscribe(res => {
                this.payments.unshift(res);
                this.bForm!.reset();
                this.form.controls['std'].reset();
            }, (err: HttpErrorResponse) => {
                this.onError(err);
            })
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
        alert(this.message);
        this.error = true;
    }

    print() {
        this.printer.print(`List of payments by ${this.std!.surname} ${this.std!.otherNames}`)
    }
}