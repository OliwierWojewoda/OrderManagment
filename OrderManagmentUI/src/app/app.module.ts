import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ViewOrdersComponent } from './components/view-orders/view-orders.component';
import { ViewProductsComponent } from './components/view-products/view-products.component';
import { ViewContractorsComponent } from './components/view-contractors/view-contractors.component';
import { ViewOrderProductsComponent } from './components/view-order-products/view-order-products.component';
import { EditContractorComponent } from './components/edit-contractor/edit-contractor.component';
import { FormsModule } from '@angular/forms';
import { EditProductComponent } from './components/edit-product/edit-product.component';

@NgModule({
  declarations: [
    AppComponent,
    ViewOrdersComponent,
    ViewProductsComponent,
    ViewContractorsComponent,
    ViewOrderProductsComponent,
    EditContractorComponent,
    EditProductComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
