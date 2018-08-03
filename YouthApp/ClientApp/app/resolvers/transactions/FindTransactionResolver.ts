import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { TransactionsHttpService } from "../../http/transactions/payments-http-service";
import { ITransactions } from "../../models/ITransactions";

@Injectable()
export class FindTransactionResolver implements Resolve<Observable<ITransactions>> {
    resolve(route: ActivatedRouteSnapshot): Observable<ITransactions> {
        return this.http.find(route.paramMap.get('id') as string) as Observable<ITransactions>;
    }

    constructor(private http: TransactionsHttpService) {

    }
}