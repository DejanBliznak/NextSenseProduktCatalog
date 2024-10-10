import { Component, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { OrderService } from '../services/order.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-report-by-date',
  templateUrl: './report-by-date.component.html',
  styleUrls: ['./report-by-date.component.scss']
})
export class ReportByDateComponent implements OnInit {

  public unsubscribe: Subject<void> = new Subject<void>();
  public data!: any[];
  rows: number = 5;
  constructor(
    private _orderService: OrderService,
    public _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this.reportForOrderByDate()
  }
  reportForOrderByDate(){
    this._orderService.reportForOrderByDate()
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
