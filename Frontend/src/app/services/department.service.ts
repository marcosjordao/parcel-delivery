import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { defaultErrorHandle } from '../helpers/default-error-handle';
import { Department } from '../model/department';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
    providedIn: 'root'
})
export class DepartmentService {
    constructor(
        private http: HttpClient,
        @Inject('BASE_API_URL') private baseUrl: string
    ) {}

    private apiUrl = `${this.baseUrl}/department`;

    getDepartments(): Observable<Department[]> {
        return this.http
            .get<Department[]>(this.apiUrl)
            .pipe(catchError(defaultErrorHandle('load departments')));
    }

    getDepartment(id: string): Observable<Department> {
        const url = `${this.apiUrl}/${id}`;
        return this.http
            .get<Department>(url)
            .pipe(catchError(defaultErrorHandle(`load department [${id}]`)));
    }

    addDepartment(department: Department): Observable<Department> {
        return this.http
            .post<Department>(this.apiUrl, department, httpOptions)
            .pipe(catchError(defaultErrorHandle('add department')));
    }

    deleteDepartment(department: Department | string): Observable<Department> {
        const id = typeof department === 'string' ? department : department.id;
        const url = `${this.apiUrl}/${id}`;

        return this.http
            .delete<Department>(url, httpOptions)
            .pipe(catchError(defaultErrorHandle('delete department')));
    }

    updateDepartment(department: Department): Observable<any> {
        return this.http
            .put(this.apiUrl, department, httpOptions)
            .pipe(catchError(defaultErrorHandle('update department')));
    }
}
