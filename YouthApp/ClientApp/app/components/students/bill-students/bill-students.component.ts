import { Component } from '@angular/core';
import { IStudents } from '../../../models/IStudents';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IHttpHelper } from '../../../http/IHttpHelper';
import { IIndividualBills } from '../../../models/IIndBill';
import { HttpErrorResponse } from '@angular/common/http';

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
    constructor(route: ActivatedRoute, private fb: FormBuilder) {
        this.stds = route.snapshot.data['students'];
        this.form = this.fb.group({
            student: ["", Validators.required]
        });
    }

    change(std: IStudents) {
        this.billForm = this.fb.group({
            description: ["", Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
            amount: ["", Validators.compose([Validators.required, Validators.min(1)])]
        })
    }

    bill(bill: IIndividualBills) {

    }

    onDelete(item: IIndividualBills): void {
        throw new Error("Method not implemented.");
    }
    onError(err: HttpErrorResponse): void {
        throw new Error("Method not implemented.");
    }
    onSuccess(item: IIndividualBills): void {
        throw new Error("Method not implemented.");
    }
}