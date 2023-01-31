import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddContractorComponent } from './components/add-contractor/add-contractor.component';
import { AddOrderProductsComponent } from './components/add-order-products/add-order-products.component';
import { AddOrderComponent } from './components/add-order/add-order.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { EditContractorComponent } from './components/edit-contractor/edit-contractor.component';
import { EditOrderProductsComponent } from './components/edit-order-products/edit-order-products.component';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { ViewContractorsComponent } from './components/view-contractors/view-contractors.component';
import { ViewOrderProductsComponent } from './components/view-order-products/view-order-products.component';
import { ViewOrdersComponent } from './components/view-orders/view-orders.component';
import { ViewProductsComponent } from './components/view-products/view-products.component';
import { ViewContractor } from './models/ViewContractor';

const routes: Routes = [
  {
    path: 'productsList',
    component:ViewProductsComponent
  },
  {
    path: 'contractorsList',
    component:ViewContractorsComponent
  },
  {
    path: '',
    component:ViewOrdersComponent
  },
  {
    path: 'orderDetails',
    component:ViewOrderProductsComponent
  },
  {
    path: 'editContractor/:id',
    component:EditContractorComponent
  },
  {
    path: 'editProduct/:id',
    component:EditProductComponent
  },
  {
    path: 'editOrder/:id',
    component:ViewOrderProductsComponent
  },
  {
    path: 'addContractor',
    component:AddContractorComponent
  },
  {
    path: 'addProduct',
    component:AddProductComponent
  },
  {
    path: 'addOrder',
    component:AddOrderComponent
  },
  {
    path: 'addOrderProducts/:id',
    component:AddOrderProductsComponent
  },
  {
    path: 'editOrderProducts/:orderid/:id',
    component:EditOrderProductsComponent
  },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
