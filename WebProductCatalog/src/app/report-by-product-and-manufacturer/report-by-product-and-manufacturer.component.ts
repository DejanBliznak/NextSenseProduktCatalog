import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';
import { Subject, takeUntil } from 'rxjs';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-report-by-product-and-manufacturer',
  templateUrl: './report-by-product-and-manufacturer.component.html',
  styleUrls: ['./report-by-product-and-manufacturer.component.scss']
})
export class ReportByProductAndManufacturerComponent implements OnInit {

  public unsubscribe: Subject<void> = new Subject<void>();
  public data!: any[];
  rows: number = 5;
  constructor(
    private _orderService: OrderService,
    public _messageService: MessageService    
  ) { }

  ngOnInit(): void {
    this.reportForOrderByProductAndManufacturer()
  }
  reportForOrderByProductAndManufacturer(){
    this._orderService.reportForOrderByProductAndManufacturer()
    .pipe(takeUntil(this.unsubscribe))
    .subscribe({
      next: (response) => {        
        this.data = response        
      },
      error: errorResponse => {
        this._messageService.add({ key: 'error_msg', severity: 'error', summary: 'Error', detail: 'System Error!', sticky: false, life:3000, closable: false, icon: "none" });
      }
    });
  }
}
