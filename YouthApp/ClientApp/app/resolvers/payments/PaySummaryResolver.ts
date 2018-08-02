import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { HelperHttpService } from "../../http/helper/helper-http-service";
import { IPaymentsSum } from "../../models/IPaymentsSum";

@Injectable()
export class PaymentSummaryResolver implements Resolve<Observable<IPaymentsSum[]>> {
    resolve(route:ActivatedRouteSnapshot): Observable<IPaymentsSum[]>{
        return this.http.payments();
    }

    constructor(private http: HelperHttpService) {

    }
}