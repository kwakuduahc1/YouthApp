import { Component } from '@angular/core';
import { IMainClasses } from '../../../models/IClasses';
import { IBillItems } from '../../../models/IBillItems';
import { IClassBills } from '../../../models/IClassBill';
import { ITerms } from '../../../models/Iterms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassBillHttpService } from '../../../http/class-bill/class-bill-http-service';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-class-bill',
    templateUrl: './class-bill.component.html',
    styleUrls: ['./class-bill.component.css']
})
/** class-bill component*/
export class ClassBillComponent {
    processing: boolean = false;
    class: IMainClasses;
    items: IBillItems[];
    terms: ITerms[];
    termForm: FormGroup;
    classBills: FormGroup[] = [];
    bill: IClassBills[] = [];
    constructor(private fb: FormBuilder, route: ActivatedRoute, private http: ClassBillHttpService, private router: Router) {
        this.class = route.snapshot.data["class"] as IMainClasses;
        this.items = route.snapshot.data["items"] as IBillItems[];
        this.terms = route.snapshot.data['terms'] as ITerms[];
        this.termForm = fb.group({
            term: ["", Validators.compose([Validators.required, Validators.min(1)])]
        });
    }
    add(item: IBillItems) {
        if (this.termForm.invalid) {
            alert('Kindly select a term to begin with');
            let ctrl = document.getElementById('term') as HTMLSelectElement;
            ctrl.focus();
            return;
        }
        let cb: IClassBills = { billItemsID: item.billItemsID, billItem: item.billItem } as IClassBills;
        if (this.bill.find(x => x.billItemsID == item.billItemsID)) {
            alert(`${item.billItem} has been already added`);
            return;
        }
        else {
            this.bill.unshift(cb);
        };
        this.classBills.unshift(this.fb.group({
            billItemsID: new FormControl({ value: item.billItemsID, disabled: true }, Validators.compose([Validators.required])),
            billItem: new FormControl({ value: item.billItem, disabled: true }, Validators.compose([Validators.required])),
            amount: [0, Validators.compose([Validators.required, Validators.min(0.1)])],
        }))
    }

    remove(ix: number) {
        if (confirm(`Do you want to remove this item from the list?`)) {
            this.bill.splice(ix, 1);
            this.classBills.splice(ix, 1);
        }
    }

    hasError() {
        return this.termForm.valid && this.classBills.length > 0 && this.classBills.every(t => t.valid);
    }
    save() {
        if (this.bill.length < 1) {
            alert("A class bill must contain at least one bill item");
            return;
        }
        else if (this.bill.some(x => x.amount < 0.1)) {
            alert("The minimum billable amount is GH¢ 0.1\nEnsure all amount exceed as such");
            return;
        }
        else {
            for (var i = 0; i < this.bill.length; i++) {
                this.bill[i].classesID = this.class.classesID;
                this.bill[i].termsID = this.termForm.controls['term'].value['termsID'];
                this.bill[i].amount = this.classBills[i].controls['amount'].value
            }
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
}