import { Component } from '@angular/core';
import { ITerms } from '../../../models/Iterms';
import { IClassBills } from '../../../models/IClassBill';
import { ActivatedRoute } from '@angular/router';
import { ClassBillHttpService } from '../../../http/class-bill/class-bill-http-service';
import { IMainClasses } from '../../../models/IClasses';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'app-view-bill',
    templateUrl: './view-bill.component.html',
    styleUrls: ['./view-bill.component.css']
})
/** view-bill component*/
export class ViewBillComponent {
    years: number[];
    bill: IClassBills[] = [];
    _class: IMainClasses;
    form: FormGroup;
    constructor(route: ActivatedRoute, private http: ClassBillHttpService) {
        this.years = route.snapshot.data['years'];
        this._class = route.snapshot.data['class'];
        this.form = new FormBuilder().group({
            year: ["", Validators.required]
        });
    }

    change(t: number) {
        let i = { year: t, classid: this._class.classesID };
        this.http.termly(i).subscribe(res => this.bill = res);
    }

    total() {
        return this.bill.reduce((pv, cv) => pv + cv.amount, 0);
    }
}