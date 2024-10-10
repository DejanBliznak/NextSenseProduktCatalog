import { Component, OnInit } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { AddOrderModel } from '../models/add-order.model';
import { AddProductModel } from '../models/add-product.model';
import { ProductService } from '../services/product.service';
import { Subject, takeUntil } from 'rxjs';
import { ProductModel } from '../models/product.model';
import { OrderService } from '../services/order.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-add-orders',
  templateUrl: './add-orders.component.html',
  styleUrls: ['./add-orders.component.scss']
})
export class AddOrdersComponent implements OnInit {

  public unsubscribe: Subject<void> = new Subject<void>();
  public addOrderModel : AddOrderModel = new AddOrderModel();
  public products: Array<ProductModel> = new Array<ProductModel>();
  totalRecords: number = 0;
  rowsPerPage: number = 5;
  constructor(
    public ref :DynamicDialogRef,
    private _productService: ProductService,
    private _orderService: OrderService,
    public _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this.getProducts()
  }

  getProducts() {
    this._productService.getProducts()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe({
        next: (response) => {
          this.products = response
        },
        error: errorResponse => {
          this._messageService.add({ key: 'error_msg', severity: 'error', summary: 'Error', detail: 'System Error!', sticky: false, life:3000, closable: false, icon: "none" });
        }
      });
  }
  addProduct(){
    this.addOrderModel.products.push(new AddProductModel());
    this.totalRecords = this.addOrderModel.products.length;
  }
  removeProduct(index: any) {
   
    if (index > -1 && index < this.addOrderModel.products.length) {
      this.addOrderModel.products.splice(index, 1);
    }
    this.totalRecords = this.addOrderModel.products.length;
  }
  selectProduct(product : AddProductModel) {   
    this._productService.getProductDetails(product.productId)
    .pipe(takeUntil(this.unsubscribe))
    .subscribe({
      next: (response) => {     
       product.unitPrice = response.price
      },
      error: errorResponse => {
        this._messageService.add({ key: 'error_msg', severity: 'error', summary: 'Error', detail: 'System Error!', sticky: false, life:3000, closable: false, icon: "none" });
      }
    });
  }
  addOrder(addOrderModel : AddOrderModel){
    
    this._orderService.addOrder(addOrderModel)
    .pipe(takeUntil(this.unsubscribe))
    .subscribe({
      next: (response) => {     
        this.ref.close(true)
      },
      error: errorResponse => {
        this._messageService.add({ key: 'error_msg', severity: 'error', summary: 'Error', detail: 'System Error!', sticky: false, life:3000, closable: false, icon: "none" });
      }
    });
  }
  close(){
    this.ref.close(null)
  }
}
