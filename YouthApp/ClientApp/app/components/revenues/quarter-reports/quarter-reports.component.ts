import { Component } from '@angular/core';
import { IBalances } from '../../../models/IBalances';
import { HelperHttpService } from '../../../http/helper/helper-http-service';
import { IQuarters, Quarters } from '../../../models/IQuarters';
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PrintProviderService } from '../../../providers/print-provider.service';

@Component({
    selector: 'app-quarter-reports',
    templateUrl: './quarter-reports.component.html',
    styleUrls: ['./quarter-reports.component.css']
})
/** quarter-reports component*/
export class QuarterReportsComponent {
    processing: boolean = false;
    error: boolean = false;
    message: string = "";
    dismiss: boolean = false;
    balances: IBalances[] = [];
    quarters: IQuarters[];
    form: FormGroup;
    constructor(private http: HelperHttpService, fb: FormBuilder, private printer: PrintProviderService) {
        this.quarters = new Quarters().getQuarters();
        this.form = fb.group({
            period: ["", Validators.required]
        });
    }

    getReport(iq: IQuarters) {
        this.http.quarterly(iq.value.start, iq.value.end).subscribe(res => this.balances = res, (err: HttpErrorResponse) => alert("An error occurred. Try again"));
    }

    title(): string {
        let qrt: IQuarters = this.form.controls['period'].value;
        if (qrt) {
            var ix = this.quarters.findIndex(x => x.value.end === qrt.value.end);
            return new Date().getFullYear() + ' ' + this.quarters[ix].name;
        }
        return 'Quarterly Report';
    }
    print() {

        this.printer.print('print')
    }

    totals() {
        let totals = { exp: 0, rev: 0 };
        totals.exp = this.balances.reduce((pv, cv) => pv + cv.expenditure, 0);
        totals.rev = this.balances.reduce((pv, cv) => pv + cv.revenue, 0);
        return totals
    }
}