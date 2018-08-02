import { Component } from '@angular/core';
//import { IStatuses } from '../../model/IStatuses';
import { ActivatedRoute } from '@angular/router';
import { IPaymentsSum } from '../../models/IPaymentsSum';
import { IDebtors } from '../../models/IDebtors';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styles:[]
})
export class HomeComponent {
    //statuses: IStatuses[];
    payments: IPaymentsSum[];
    debtors: IDebtors[];
    constructor(route: ActivatedRoute) {
        this.payments = route.snapshot.data['payments'];
        this.debtors = route.snapshot.data['debtors'];
    }
}
