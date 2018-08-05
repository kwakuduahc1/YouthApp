import { Component, Input } from '@angular/core';
import { IBalances } from '../../../models/IBalances';

@Component({
    selector: 'app-item-balances',
    templateUrl: './item-balances.component.html',
    styleUrls: ['./item-balances.component.css']
})
/** item-balances component*/
export class ItemBalancesComponent {
    @Input() balances: IBalances[] = [];
    constructor() {

    }
}