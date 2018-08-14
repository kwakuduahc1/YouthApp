import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { StudentsHttpService } from "../../http/students/students-http-service";
import { IStudents } from "../../models/IStudents";

@Injectable()
export class StudentResolver implements Resolve<Observable<IStudents>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IStudents> {
        return this.http.find(route.paramMap.get("id") as string) as Observable<IStudents>;
    }

    constructor(private http: StudentsHttpService) {

    }
}