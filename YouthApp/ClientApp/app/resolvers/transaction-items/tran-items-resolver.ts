import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { TransactionItemsHttpService } from "../../http/tran-items/tran-items-http-service";
import { ITransactionItems } from "../../models/ItranItems";

@Injectable()
export class TransactionItemsResolver implements Resolve<Observable<ITransactionItems[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<ITransactionItems[]> {
        return this.http.list();
    }

    constructor(private http: TransactionItemsHttpService) {

    }
}