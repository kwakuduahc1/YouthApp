import { Component } from '@angular/core';
import { IMainClasses } from '../../../models/IClasses';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IPayments } from '../../../models/IPayments';
import { IStudents } from '../../../models/IStudents';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentsHttpService } from '../../../http/students/students-http-service';
import { StudentPaymentsHttpService } from '../../../http/students/payments-http-service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-edit-student-payment',
    templateUrl: './edit-student-payment.component.html',
    styleUrls: ['./edit-student-payment.component.css']
})
/** edit-student-payment component*/
export class EditStudentPaymentComponent {
    payment: IPayments;
    bForm: FormGroup;
    std: IStudents;
    message = "";
    error = false;
    dismiss: boolean = true;
    processing: boolean = false;
    constructor(route: ActivatedRoute, private fb: FormBuilder, private pay_http: StudentPaymentsHttpService, private router: Router) {
        this.std = route.snapshot.data['student'];
        this.payment = route.snapshot.data['payment'];
        this.bForm = this.fb.group({
            gcr: [this.payment.gcr, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
            amount: [this.payment.amount, Validators.compose([Validators.required, Validators.min(0.1)])],
            datePaid: [this.payment.datePaid, Validators.compose([Validators.required])]
        });
    };


    edit(pay: IPayments) {
        if (confirm(`Have you received ${pay.amount} from ${this.std!.surname} ${this.std!.otherNames ? this.std!.otherNames : ""}`)) {
            console.log(this.payment);
            this.payment.amount = pay.amount;
            this.payment.gcr = pay.gcr;
            this.payment.datePaid = pay.datePaid;
            this.error = false;
            this.message = "";
            this.dismiss = true;
            this.pay_http.edit(this.payment).subscribe(res => {
                this.bForm!.reset();
                this.router.navigate(['/student-payments']);
            }, (err: HttpErrorResponse) => {
                this.onError(err);
                });
            this.processing = false;
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
}