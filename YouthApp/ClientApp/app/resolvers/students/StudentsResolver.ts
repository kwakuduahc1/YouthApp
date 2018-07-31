import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { IStudents } from "../../models/IStudents";
import { ClassesHttpService } from "../../http/classes/classes-http-service";

@Injectable()
export class StudentsResolver implements Resolve<Observable<IStudents[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IStudents[]> {
        return this.http.students(parseInt(route.paramMap.get("id") as string));
    }

    constructor(private http: ClassesHttpService) {

    }
}