import { Component, OnInit } from '@angular/core';
import { ViewProduct } from 'src/app/models/ViewProduct';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';
import { ProductManagmentService } from 'src/app/services/ProductManagmentService';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {
   products: ViewProduct[] = [];
   enteredSearchValue=''
   constructor(private service: ProductManagmentService){}
      ngOnInit() : void{
        this.service.getProducts()
        .subscribe({
         next: (products) => {
           this.products = products
         }
        });       
}
deleteProduct(id: number){
  this.service.deleteProduct(id.toString())
  .subscribe({
    next: (response) => 
    {
      window.location.reload();
    }
  })
}
onSearchTextChanged(){
  if(this.enteredSearchValue.length!=0)
  {
    this.service.searchProducts(this.enteredSearchValue)
        .subscribe({
         next: (products) => {
           this.products = products
         }
        });       
  }
  else{
    this.ngOnInit();
  }
}
}

