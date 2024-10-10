import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { OrderService } from '../services/order.service';
import { Subject, takeUntil } from 'rxjs';
import { OrderModel } from '../models/order.model';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {

  public unsubscribe: Subject<void> = new Subject<void>();
  public order: OrderModel = new OrderModel()
  constructor(
    public config: DynamicDialogConfig,
    public ref: DynamicDialogRef,
    public _messageService: MessageService,
    private _orderService: OrderService) {

    this.getOrderDetails(this.config.data.id)
  }

  ngOnInit(): void {
  }

  getOrderDetails(orderId: number) {
    this._orderService.getOrderDetails(orderId)
      .pipe(takeUntil(this.unsubscribe))
      .subscribe({
        next: (response) => {
          this.order = response
        },
        error: errorResponse => {
          this._messageService.add({ key: 'error_msg', severity: 'error', summary: 'Error', detail: 'System Error!', sticky: false, life:3000, closable: false, icon: "none" });
        }
      });
  }
}
