import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { TransactionsHttpService } from "../../http/transactions/payments-http-service";
import { ITransactions } from "../../models/ITransactions";

@Injectable()
export class TransactionsResolver implements Resolve<Observable<ITransactions[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<ITransactions[]> {
        return this.http.list();
    }

    constructor(private http: TransactionsHttpService) {

    }
}