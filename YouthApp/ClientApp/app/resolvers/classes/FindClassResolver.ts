import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { ClassesHttpService } from "../../http/classes/classes-http-service";
import { IMainClasses } from "../../models/IClasses";

@Injectable()
export class FindClassResolver implements Resolve<Observable<IMainClasses>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IMainClasses> {
        return this.http.find(route.paramMap.get('id') as string) as Observable<IMainClasses>;
    }

    constructor(private http: ClassesHttpService) {

    }
}