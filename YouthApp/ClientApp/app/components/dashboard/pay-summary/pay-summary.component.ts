import { Component, Input, OnInit } from '@angular/core';
import { IPaymentsSum } from '../../../models/IPaymentsSum';

@Component({
    selector: 'app-pay-summary',
    templateUrl: './pay-summary.component.html',
    styleUrls: ['./pay-summary.component.css']
})
/** pay-summary component*/
export class PaySummaryComponent implements OnInit {
    ngOnInit(): void {
    }


    @Input() payments: IPaymentsSum[] = [];

    constructor() {

    }

    total() {
        return this.payments.reduce((pv, cv) => pv + cv.payments, 0);
    }

    getYear() {
        return new Date().getFullYear();
    }
}