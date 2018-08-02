import { Resolve } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { IRevenues } from "../../models/IRevenues";
import { RevenueHttpService } from "../../http/revenues/revenues-http-service";

@Injectable()
export class RevenueListResolver implements Resolve<Observable<IRevenues[]>> {
    resolve(): Observable<IRevenues[]> {
        return this.http.list();
    }
    constructor(private http: RevenueHttpService) {

    }
}