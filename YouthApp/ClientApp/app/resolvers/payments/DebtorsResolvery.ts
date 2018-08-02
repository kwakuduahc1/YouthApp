import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { HelperHttpService } from "../../http/helper/helper-http-service";
import { IDebtors } from "../../models/IDebtors";

@Injectable()
export class DebtorsResolver implements Resolve<Observable<IDebtors[]>> {
    resolve(route:ActivatedRouteSnapshot): Observable<IDebtors[]>{
        return this.http.debtors();
    }

    constructor(private http: HelperHttpService) {

    }
}