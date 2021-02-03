import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IRealProperty } from '../models/realProperty';

@Injectable()
export class RoofstockService {
    baseUrl = environment.apiUrl;
    realProperties: IRealProperty[];
    
    constructor(private http: HttpClient) { }

    // Method to return an observable with the properties from the endpoint given.
    getExternalProperties(): Observable<any[]> {
        return this.http.get<any[]>('https://samplerspubcontent.blob.core.windows.net/public/properties.json');
    }

    // Method to return an observable with the properties from the database.
    getInternalProperties(): Observable<IRealProperty[]> {
        return this.http.get<IRealProperty[]>(this.baseUrl +'properties');
    }

    // Method to return an observable with the property created on the database.
    addInternalProperty(realProperty: IRealProperty): Observable<IRealProperty> {
        if (realProperty) {
            return this.http.post<IRealProperty>(this.baseUrl +'properties', realProperty);
        } else {
            return of();
        }
    }
}
