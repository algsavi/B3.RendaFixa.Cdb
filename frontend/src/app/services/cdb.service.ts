import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CdbRequest, CdbResponse } from '../models/cdb.model';

@Injectable({ providedIn: 'root' })
export class CdbService {
    private readonly baseUrl = 'https://localhost:7167';

    constructor(private http: HttpClient) { }

    calcular(req: CdbRequest): Observable<CdbResponse> {
        return this.http.post<CdbResponse>(`${this.baseUrl}/api/v1/cdb`, req);
    }
}