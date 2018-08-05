import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { TransactionsHttpService } from "../../http/transactions/payments-http-service";
import { IBalances } from "../../models/IBalances";

@Injectable()
export class ItemBalancesResolver implements Resolve<Observable<IBalances[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IBalances[]> {
        return this.http.itemBalances();
    }

    constructor(private http: TransactionsHttpService) {

    }
}