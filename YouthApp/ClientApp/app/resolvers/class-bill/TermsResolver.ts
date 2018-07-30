import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { ITerms } from "../../models/Iterms";
import { HelperHttpService } from "../../http/helper/helper-http-service";

@Injectable()
export class TermsResolver implements Resolve<Observable<ITerms[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<ITerms[]> {
        return this.http.getTerms();
    }

    constructor(private http: HelperHttpService) {

    }
}