import { Component } from '@angular/core';
import { IDebtors } from '../../../models/IDebtors';
import { ActivatedRoute } from '@angular/router';
import { PrintProviderService } from '../../../providers/print-provider.service';
import { IMainClasses } from '../../../models/IClasses';

@Component({
    selector: 'app-debtors',
    templateUrl: './debtors.component.html',
    styleUrls: ['./debtors.component.css']
})
/** debtors component*/
export class DebtorsComponent {
    list: IDebtors[];
    _class: IMainClasses;
    constructor(private route:ActivatedRoute, private printer:PrintProviderService) {
        this.list = route.snapshot.data['debtors'];
        this._class = route.snapshot.data['class'];
    }

    print() {
        this.printer.print('print', `List of debtors in ${this._class.programName} ${this._class.addYear}`)
    }
}