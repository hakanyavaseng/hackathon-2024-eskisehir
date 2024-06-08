import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
import { ProductComponent } from './product/product.component';
import { ProductionComponent } from './production/production.component';
import { VehicleComponent } from './vehicle/vehicle.component';
import { AppRoutingModule } from '../app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TransportationComponent } from './transportation/transportation.component';



@NgModule({
  declarations: [
    LayoutComponent,
    ProductComponent,
    ProductionComponent,
    VehicleComponent,
    DashboardComponent,
    TransportationComponent
  ],
  imports: [
    AppRoutingModule, ReactiveFormsModule, FormsModule,
    CommonModule
  ]
})
export class AdminModule { }
