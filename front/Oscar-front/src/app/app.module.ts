import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductComponent } from './product/product.component';
import { SharedService } from './shared.service';
import { ShowProdComponent } from './show-prod/show-prod.component';
import { AddEditProdComponent } from './add-edit-prod/add-edit-prod.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    ShowProdComponent,
    AddEditProdComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
