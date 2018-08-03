import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { ITransactionItems } from "../../models/ItranItems";
import { TransactionItemsHttpService } from "../../http/tran-items/tran-items-http-service";

@Injectable()
export class FindTransactionItemResolver implements Resolve<Observable<ITransactionItems>> {
    resolve(route: ActivatedRouteSnapshot): Observable<ITransactionItems> {
        return this.http.find(route.paramMap.get('id') as string) as Observable<ITransactionItems>;
    }

    constructor(private http: TransactionItemsHttpService) {

    }
}