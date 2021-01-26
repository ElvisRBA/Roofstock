import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IRealProperty } from '../models/realProperty';

@Injectable()
export class RoofstockService {
    baseUrl = environment.apiUrl;
    realProperties: IRealProperty[];
    
    constructor(private http: HttpClient) { }

    getExternalProperties(): Observable<any[]> {
        return this.http.get<any[]>('https://samplerspubcontent.blob.core.windows.net/public/properties.json');
    }

    getInternalProperties(): Observable<IRealProperty[]> {
        return this.http.get<IRealProperty[]>(this.baseUrl +'properties');
    }

    addInternalProperty(realProperty: IRealProperty): Observable<IRealProperty> {
        return this.http.post<IRealProperty>(this.baseUrl +'properties', realProperty);
    }
}
