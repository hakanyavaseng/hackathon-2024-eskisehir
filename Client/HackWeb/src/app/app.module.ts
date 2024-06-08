import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AdminModule,
    BrowserModule, 
    AppRoutingModule, HttpClientModule, NgbModule, ReactiveFormsModule, FormsModule
  ],
  providers: [
    { provide: "baseUrl", useValue: "https://localhost:5000/api" }
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
