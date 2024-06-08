import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { ProductComponent } from './admin/product/product.component';
import { VehicleComponent } from './admin/vehicle/vehicle.component';
import { ProductionComponent } from './admin/production/production.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { TransportationComponent } from './admin/transportation/transportation.component';
import { ReportComponent } from './admin/report/report.component';


const routes: Routes = [
  {path: "", redirectTo: "admin", pathMatch: "full"},
  { path: "admin", component: LayoutComponent, children: [
    {path: "product", component: ProductComponent},
    {path: "vehicle", component: VehicleComponent},
    {path: "production", component: ProductionComponent},
    {path: "transportation", component: TransportationComponent},
    {path: "report", component: ReportComponent},
    {path: "", component: DashboardComponent, pathMatch: "full"}
  ]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
