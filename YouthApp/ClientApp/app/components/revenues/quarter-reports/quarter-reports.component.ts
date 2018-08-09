import { Component } from '@angular/core';
import { IBalances } from '../../../models/IBalances';
import { HelperHttpService } from '../../../http/helper/helper-http-service';
import { IQuarters, Quarters } from '../../../models/IQuarters';
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

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
    constructor(private http: HelperHttpService, fb: FormBuilder) {
        this.quarters = new Quarters().getQuarters();
        this.form = fb.group({
            period: ["", Validators.required]
        });
    }

    getReport(iq: IQuarters) {
        console.log(iq);
        this.http.quarterly(iq.value.start, iq.value.end).subscribe(res => this.balances = res, (err: HttpErrorResponse) => alert("An error occurred. Try again"));
    }
}