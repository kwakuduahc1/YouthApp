import { Component } from '@angular/core';
import { IStudents } from '../../../models/IStudents';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { IIndividualBills } from '../../../models/IIndBill';
import { HttpErrorResponse } from '@angular/common/http';
import { StudentsHttpService } from '../../../http/students/students-http-service';

@Component({
    selector: 'app-bill-students',
    templateUrl: './bill-students.component.html',
    styleUrls: ['./bill-students.component.css']
})
/** bill-students component*/
export class BillStudentsComponent implements IHttpHelper<IIndividualBills> {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    dismiss: boolean = false;
    billForm: FormGroup | undefined;
    stds: IStudents[];
    _std: IStudents | undefined;
    form: FormGroup;
    stdBill: IIndividualBills[] = [];
    constructor(route: ActivatedRoute, private fb: FormBuilder, private http: StudentsHttpService, private router: Router) {
        this.stds = route.snapshot.data['students'];
        this.form = this.fb.group({
            student: ["", Validators.required]
        });
    }

    change(std: IStudents) {
        this._std = std;
        this.billForm = this.fb.group({
            description: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(1)])],
        });
        this.http.stdBill(std.studentsID).subscribe(res => this.stdBill = res, (err: HttpErrorResponse) => this.onError(err));
    }

    bill(bill: IIndividualBills) {
        this.processing = true;
        this.error = false;
        bill.studentsID = this._std!.studentsID;
        this.http.billStd(bill).subscribe(res => this.onSuccess(res), (err: HttpErrorResponse) => this.onError(err));
        this.processing = false;
    }

    onDelete(item: IIndividualBills): void {
        throw new Error("Method not implemented.");
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

    onSuccess(item: IIndividualBills): void {
        alert('Student was billed successfully');
        this.stdBill.unshift(item);
        this.billForm!.reset();
        this.form.reset();
        // this.router.navigate(['/classes']);
    }

    receive(sb: IIndividualBills) {
        if (confirm('Have you received payment for this item?\nIt may not be reversible.\nDo you wish to continue?')) {
            if (!sb.gCr) {
                let gcr = prompt("Enter the GCR number. 5 characters minimum");
                sb.gCr = gcr as string;
            }
            this.http.receive(sb).subscribe(res => {
                let ix = this.stdBill.findIndex(x => x.individualBillsID === res.individualBillsID);
                this.stdBill[ix].isPaid = true;
                alert("Bill was marked as received");
            }, (err: HttpErrorResponse) => this.onError(err));
        }
    }
}
