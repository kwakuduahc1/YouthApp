import { Component, Input } from '@angular/core';
import { IDebtors } from '../../../models/IDebtors';

@Component({
    selector: 'app-top-debtors',
    templateUrl: './top-debtors.component.html',
    styleUrls: ['./top-debtors.component.css']
})
/** top-debtors component*/
export class TopDebtorsComponent {
    @Input() debtors: IDebtors[] = [];
    constructor() {

    }
}