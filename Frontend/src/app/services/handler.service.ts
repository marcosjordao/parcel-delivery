import { Injectable, Inject } from '@angular/core';
import { Parcel } from '../model/parcel';
import { Observable } from 'rxjs';
import { Department } from '../model/department';
import { catchError } from 'rxjs/operators';
import { defaultErrorHandle } from '../helpers/default-error-handle';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
    providedIn: 'root'
})
export class HandlerService {
    constructor(
        private http: HttpClient,
        @Inject('BASE_API_URL') private baseUrl: string
    ) {}

    private apiUrl = `${this.baseUrl}/handler`;

    public handleParcel(parcel: Parcel): Observable<Department> {
        return this.http
            .post<Department>(this.apiUrl, parcel, httpOptions)
            .pipe(catchError(defaultErrorHandle('handle parcel')));
    }
}
