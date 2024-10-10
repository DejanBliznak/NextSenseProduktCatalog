import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs";

import { HttpService } from "./http.service";
import { AddOrderModel } from "../models/add-order.model";

const UrlSite = "http://localhost:5200"
@Injectable({
    providedIn: 'root'
})
export class OrderService {


    constructor(private http: HttpClient, private _httpService: HttpService) {
    }

    getOrders(size: number, page: number, productId: number | null) {
        var url = UrlSite + `/api/Order/getorders?size=${size}&page=${page}`;
        if (productId !== null && productId !== undefined) {
            url += `&productId=${productId}`;
        }
        return this._httpService.httpGet(url)
            .pipe(map(resposne => {
                return resposne;
            }));
    }
    getOrderDetails(orderId: number) {
        var url = UrlSite + `/api/Order/getorderdetails?orderId=${orderId}`;
        return this._httpService.httpGet(url)
            .pipe(map(resposne => {
                return resposne;
            }));
    }

    addOrder(model: AddOrderModel) {
        var url = UrlSite + "/api/Order/addorder";
        return this._httpService.httpPost(url, model)
            .pipe(map(resposne => {
                return resposne;
            }));
    }
    reportForOrderByProductAndManufacturer() {
        var url = UrlSite + `/api/Order/reportfororderbyproductandmanufacturer`;
        return this._httpService.httpGet(url)
            .pipe(map(resposne => {
                return resposne;
            }));
    }
    reportForOrderByDate() {
        var url = UrlSite + `/api/Order/reportfororderbydate`;
        return this._httpService.httpGet(url)
            .pipe(map(resposne => {
                return resposne;
            }));
    }
}