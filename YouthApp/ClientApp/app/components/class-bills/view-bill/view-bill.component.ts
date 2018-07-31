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
    terms: ITerms[];
    bill: IClassBills[] = [];
    _class: IMainClasses;
    form: FormGroup;
    constructor(route: ActivatedRoute, private http: ClassBillHttpService) {
        this.terms = route.snapshot.data['terms'];
        this._class = route.snapshot.data['class'];
        this.form = new FormBuilder().group({
            term: ["", Validators.required]
        });
    }

    change(t: ITerms) {
        let i = { term: t.termsID, classid: this._class.classesID };
        this.http.termly(i).subscribe(res => this.bill = res);
    }

    total() {
        return this.bill.reduce((pv, cv) => pv + cv.amount, 0);
    }
}