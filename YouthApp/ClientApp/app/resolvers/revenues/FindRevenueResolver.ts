import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { IRevenues } from "../../models/IRevenues";
import { RevenueHttpService } from "../../http/revenues/revenues-http-service";

@Injectable()
export class FindRevenueResolver implements Resolve<Observable<IRevenues>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IRevenues> {
        return this.http.find(route.paramMap.get('id') as string) as Observable<IRevenues>;
    }

    constructor(private http: RevenueHttpService) {

    }
}