import { Resolve } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { ClassesHttpService } from "../../http/classes/classes-http-service";
import { IMainClasses } from "../../models/IClasses";

@Injectable()
export class ClassesListResolver implements Resolve<Observable<IMainClasses[]>> {
    resolve(): Observable<IMainClasses[]> {
        return this.http.list();
    }
    constructor(private http: ClassesHttpService) {

    }
}