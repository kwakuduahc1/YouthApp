import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { HelperHttpService } from "../../http/helper/helper-http-service";

@Injectable()
export class YearGroupsResolver implements Resolve<Observable<number[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<number[]> {
        return this.http.yearGroups();
    }

    constructor(private http: HelperHttpService) {

    }
}