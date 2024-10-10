import { NgModule } from "@angular/core";
import { DropdownModule } from 'primeng/dropdown'; 
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { TableModule } from 'primeng/table';
import { TabViewModule } from 'primeng/tabview';
import { PaginatorModule } from 'primeng/paginator';
@NgModule({
    declarations: [],
    imports: [
        DropdownModule,
        ButtonModule ,
        ToastModule,
        TableModule,
        TabViewModule,
        PaginatorModule
    ],
    exports: [
        DropdownModule,
        ButtonModule,
        ToastModule,
        TableModule,
        TabViewModule,
        PaginatorModule
    ]
  })
  export class NgPrimeModule { }