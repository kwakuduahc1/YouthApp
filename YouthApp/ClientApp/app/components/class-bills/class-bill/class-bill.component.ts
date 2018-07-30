import { Component } from '@angular/core';
import { IMainClasses } from '../../../models/IClasses';
import { IBillItems } from '../../../models/IBillItems';
import { IClassBills } from '../../../models/IClassBill';
import { ITerms } from '../../../models/Iterms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassBillHttpService } from '../../../http/class-bill/class-bill-http-service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'app-class-bill',
    templateUrl: './class-bill.component.html',
    styleUrls: ['./class-bill.component.css']
})
/** class-bill component*/
export class ClassBillComponent {
    class: IMainClasses;
    items: IBillItems[];
    terms: ITerms[];
    termForm: FormGroup;
    constructor(private fb:FormBuilder, route: ActivatedRoute, private http: ClassBillHttpService, private router: Router) {
        this.class = route.snapshot.data["class"] as IMainClasses;
        this.items = route.snapshot.data["items"] as IBillItems[];
        this.terms = route.snapshot.data['terms'] as ITerms[];
        this.termForm = fb.group({
            term:["",Validators.compose([Validators.required,Validators.min(1)])]
        })
    }
    add(item: IBillItems) {
        let cb: IClassBills = { billItemsID: item.billItemsID, billItem: item.billItem } as IClassBills;
        //if (this.classBill.find(x => x.billItemsID == item.billItemsID)) {
        //    alert(`${item.billItem} has been already added`);
        //    return;
        //}
        //else {
        //    this.classBill.unshift(cb);
        //}
    }

    //save() {
    //   if (this.classBill.length < 1) {
    //        alert("A class bill must contain at least one bill item");
    //        return;
    //    }
    //    else if (this.classBill.some(x => x.amount < 1)) {
    //        alert("The minimum billable amount is GH¢ 1.00\nEnsure all amount exceed as such");
    //        return;
    //    }
    //    else {
    //        this.classBill.forEach(x => {
    //            x.classesID = this.class.classesID
    //        });
    //        this.http.add(this.classBill).subscribe(res => {
    //            alert("Bill preparation was successful");
    //            this.processing = false;
    //            this.router.navigate(['/classes']);
    //        }, (err: HttpErrorResponse) => {
    //            this.processing = false;
    //            if (err!.error!.message) {
    //                alert(err.error.message);
    //            }
    //            else {
    //                alert("Unrecognized error occurred. Contact support");
    //            }
    //        });
    //    }
    //}
}