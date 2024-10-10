import { Component, OnInit } from '@angular/core';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ProductModel } from '../models/product.model';
import { Subject, takeUntil } from 'rxjs';
import { ProductService } from '../services/product.service';
import { OrderService } from '../services/order.service';
import { AddOrdersComponent } from '../add-orders/add-orders.component';
import { OrderDetailsComponent } from '../order-details/order-details.component';
import { MessageService } from 'primeng/api';
@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  public unsubscribe: Subject<void> = new Subject<void>();
  public products: Array<ProductModel> = new Array<ProductModel>();
  public product: ProductModel = new ProductModel();
  public orders!: any[];
  totalRecords: number = 0;
  first: number = 1;
  page: number = 1;
  rows: number = 5;
  constructor(
    public dialogService: DialogService,
    private _productService: ProductService,
    private _orderService: OrderService,
    public _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this.getProducts()
    this.getOrders(this.rows, this.page, this.product.id);
  }
  onPageChange(event: any) {
    this.page = (event.first / event.rows) + 1;
    this.rows = event.rows;
    this.getOrders(this.rows, this.page, this.product?.id);
  }
  getProducts() {
    this._productService.getProducts()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe({
        next: (response) => {
          this.products = response
        },
        error: errorResponse => {
          // this.errorModel = this._utilsService.parseErrors(errorResponse);
        }
      });
  }

  getOrders(pageSize: number, pageNumber: number, productId: number | null) {

    this._orderService.getOrders(pageSize, pageNumber, productId)
      .pipe(takeUntil(this.unsubscribe))
      .subscribe({
        next: (response) => {

          this.orders = response.data
          this.totalRecords = response.total
        },
        error: errorResponse => {          
          this._messageService.add({ key: 'error_msg', severity: 'error', summary: 'Error', detail: 'System Error!', sticky: false, life:3000, closable: false, icon: "none" });
        }
      });
  }
  selectProduct() {
    this.getOrders(this.rows, this.page, this.product?.id);
  }
  getOrderDetails(orderId: number) {
    const ref = this.dialogService.open(OrderDetailsComponent, {
      header: "Order details",
      showHeader: true,
      width: '750px',
      closeOnEscape: false,
      data: {
        id: orderId
      },
    });
    ref.onClose.subscribe((item: any) => {
      if (item) {
        this.getOrders(this.rows, this.page, this.product?.id);
      }
    });
  }
  addOrder() {
    const ref = this.dialogService.open(AddOrdersComponent, {
      header: "Add Order ",
      showHeader: true,
      width: '750px',
      closeOnEscape: false
    });
    ref.onClose.subscribe((item: any) => {
      if (item) {       
        this._messageService.add({ key: 'error_msg', severity: 'success', summary: 'Success', detail: 'Order is successful add!', sticky: false, life:3000, closable: false, icon: "none" });
        this.getOrders(this.rows, this.page, this.product?.id);
      }
    });
  }




}


export class Customer {
  id?: number;
  name?: string;
  email?: string;
  phone?: string;
  date?: string | Date;
  status?: boolean;

}
