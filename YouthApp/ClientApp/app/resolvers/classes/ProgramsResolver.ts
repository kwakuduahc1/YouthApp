import { Resolve } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { IPrograms } from "../../models/IPrograms";
import { HelperHttpService } from "../../http/helper/helper-http-service";

@Injectable()
export class ProgramsResolver implements Resolve<Observable<IPrograms[]>> {
    resolve(): Observable<IPrograms[]> {
        return this.http.getPrograms();
    }
    constructor(private http: HelperHttpService) {

    }
}