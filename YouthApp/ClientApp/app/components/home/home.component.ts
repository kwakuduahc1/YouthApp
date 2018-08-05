import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPaymentsSum } from '../../models/IPaymentsSum';
import { IDebtors } from '../../models/IDebtors';
import { IBalances } from '../../models/IBalances';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styles:[]
})
export class HomeComponent {
    payments: IPaymentsSum[];
    debtors: IDebtors[];
    balances: IBalances[];
    constructor(route: ActivatedRoute) {
        this.payments = route.snapshot.data['payments'];
        this.debtors = route.snapshot.data['debtors'];
        this.balances = route.snapshot.data['balances'];
    }
}
