import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class HttpService {
   
    constructor(private _httpClient: HttpClient) {
    }
    
    public httpPost(url: string, model: any) {
        return this._httpClient.post<any>(`${url}`, model, {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            }).set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
        })
            .pipe(map(resposne => {
                return resposne;
            }));
    }
    public httpGet(url: string) {
        return this._httpClient.get<any>(url, {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            }).set('Authorization', `Bearer ${localStorage.getItem('access_token')}`)
        })
            .pipe(map(resposne => {
                return resposne;
            }));
    }
    
}