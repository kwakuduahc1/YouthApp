import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { ClassesHttpService } from "../../http/classes/classes-http-service";
import { IDebtors } from "../../models/IDebtors";

@Injectable()
export class ClassesDebtorsResolver implements Resolve<Observable<IDebtors[]>> {
    resolve(route:ActivatedRouteSnapshot): Observable<IDebtors[]> {
        return this.http.debtors(parseInt(route.paramMap.get('id') as string));
    }
    constructor(private http: ClassesHttpService) {

    }
}