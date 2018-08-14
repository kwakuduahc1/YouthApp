import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { IPayments } from "../../models/IPayments";
import { StudentPaymentsHttpService } from "../../http/students/payments-http-service";

@Injectable()
export class FindPaymentResolver implements Resolve<Observable<IPayments>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IPayments> {
        return this.http.find(route.paramMap.get('pid') as string);
    }

    constructor(private http: StudentPaymentsHttpService) {

    }
}