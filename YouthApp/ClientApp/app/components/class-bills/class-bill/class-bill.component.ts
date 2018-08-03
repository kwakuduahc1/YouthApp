import { Component } from '@angular/core';
import { IMainClasses } from '../../../models/IClasses';
import { IBillItems } from '../../../models/IBillItems';
import { IClassBills } from '../../../models/IClassBill';
import { ITerms } from '../../../models/Iterms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassBillHttpService } from '../../../http/class-bill/class-bill-http-service';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { IBillsVm } from '../../../models/IBill';

@Component({
    selector: 'app-class-bill',
    templateUrl: './class-bill.component.html',
    styleUrls: ['./class-bill.component.css']
})
/** class-bill component*/
export class ClassBillComponent {
    processing: boolean = false;
    years: number[];
    items: IBillItems[];
    termForm: FormGroup;
    classBills: FormGroup[] = [];
    bill: IBillsVm[] = [];
    constructor(private fb: FormBuilder, route: ActivatedRoute, private http: ClassBillHttpService, private router: Router) {
        this.years = route.snapshot.data["years"];
        this.items = route.snapshot.data["items"] as IBillItems[];
        this.termForm = fb.group({
            year: ["", Validators.compose([Validators.required, Validators.min(new Date().getFullYear() - 2)])]
        });
        this.add();
    }
    add() {
        this.items.forEach(x => {
            this.classBills.push(
                this.fb.group({
                    billItemsID: new FormControl(x.billItemsID, Validators.compose([Validators.required])),
                    billItem: new FormControl({ value: x.billItem, disabled: true }, Validators.compose([Validators.required])),
                    amount: [0, Validators.compose([Validators.required])]
                }))
        })
    }

    hasError() {
        return this.termForm.valid && this.classBills.length > 0 && this.classBills.every(t => t.valid);
    }
    save() {
        this.classBills.forEach(x => {
            console.log(x);
            this.bill.push(x.value);
        });
        if (this.bill.some(x => x.amount === 0)) {
            if (confirm("Zero bill items will be removed. Press okay to confirm")) {
                this.bill = this.bill.filter(x => x.amount > 0);
            }
        }
        if (this.bill.length===0) {
            alert("Nothing to save");
            return;
        }
            this.bill.forEach(x => x.yearGroup = this.termForm.value['year']);
            this.http.addBill(this.bill).subscribe(res => {
                alert("Bill preparation was successful");
                this.processing = false;
                this.router.navigate(['/classes']);
            }, (err: HttpErrorResponse) => {
                this.processing = false;
                if (err!.error!.message) {
                    alert(err.error.message);
                }
                else {
                    alert("Unrecognized error occurred. Contact support");
                }
            });
    }
}