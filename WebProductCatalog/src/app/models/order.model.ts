import { OrderDetails } from "./order-details.model";

export class OrderModel {
    public id : number = 0;
    public orderDate : Date | undefined;
    public orderTotal : number = 0;
    public orderDetails : Array<OrderDetails> = new Array<OrderDetails>();

}