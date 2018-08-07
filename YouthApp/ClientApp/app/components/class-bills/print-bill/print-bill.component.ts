import { Component } from '@angular/core';
import { IMainClasses } from '../../../models/IClasses';
import { ITerms } from '../../../models/Iterms';
import { ActivatedRoute } from '@angular/router';
import { ClassBillHttpService } from '../../../http/class-bill/class-bill-http-service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IStudentBill } from '../../../models/IStudentBill';
import { HttpErrorResponse } from '@angular/common/http';
import { PrintProviderService } from '../../../providers/print-provider.service';

@Component({
    selector: 'app-print-bill',
    templateUrl: './print-bill.component.html',
    styleUrls: ['./print-bill.component.css', './paper.min.css']
})
/** print-bill component*/
export class PrintBillComponent {
    _class: IMainClasses;
    terms: ITerms[];
    form: FormGroup;
    bills: IStudentBill[] | undefined;
    constructor(route: ActivatedRoute, private http: ClassBillHttpService, fb: FormBuilder, private printer: PrintProviderService) {
        this._class = route.snapshot.data['class'];
        this.terms = route.snapshot.data['terms'];
        this.form = fb.group({
            term: ["", Validators.required]
        })
    }

    getReport(term: number) {
        this.http.getClassbill(term, this._class.classesID).subscribe(res => this.bills = res, (err: HttpErrorResponse) => {

        })
    }

    total(ib: Array<{ item: string, amount: number }>): number {
        if (!ib)
            return 0;
        return ib.reduce((cv, pv) => cv + pv.amount, 0);
    }

    print() {
        this.printer.print('print', '', false);
    }
}