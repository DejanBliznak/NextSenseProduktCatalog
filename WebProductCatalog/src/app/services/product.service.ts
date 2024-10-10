import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs";

import { HttpService } from "./http.service";

const UrlSite="http://localhost:5200"
@Injectable({
    providedIn: 'root'
})
export class ProductService {

    
    constructor(private http: HttpClient, private _httpService: HttpService) {
    }
   

    
    getProducts() {
        var url = UrlSite+"/api/Product/getproducts";
        return this._httpService.httpGet(url)
            .pipe(map(resposne => {
                return resposne;
            }));
    }
    getProductDetails(productId : number) {
        var url = UrlSite+`/api/Product/getproductdetails?productId=${productId}`;
        return this._httpService.httpGet(url)
            .pipe(map(resposne => {
                return resposne;
            }));
    }
   
}