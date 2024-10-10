import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './orders/orders.component';
import { ReportByProductAndManufacturerComponent } from './report-by-product-and-manufacturer/report-by-product-and-manufacturer.component';
import { ReportByDateComponent } from './report-by-date/report-by-date.component';

const routes: Routes = [

  { path: '', redirectTo: 'orders', pathMatch: 'full' },
  { path: 'orders', component: OrdersComponent }, 
  { path: 'reportbyproductandmanufacturer', component: ReportByProductAndManufacturerComponent }, 
  { path: 'reportbydate', component: ReportByDateComponent }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
