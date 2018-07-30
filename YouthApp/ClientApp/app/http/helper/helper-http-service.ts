import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { IMainClasses } from '../../models/IClasses';
import { ITerms } from '../../models/Iterms';

@Injectable()
export class HelperHttpService {

    getTerms(): Observable<ITerms[]> {
        return this.http.get<ITerms[]>(`/Helpers/Terms`)
    }

    constructor(private http: HttpClient) {

    }
}