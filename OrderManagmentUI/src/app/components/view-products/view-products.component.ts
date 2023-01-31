import { Component, OnInit } from '@angular/core';
import { ViewProduct } from 'src/app/models/ViewProduct';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {
   products: ViewProduct[] = [];
   constructor(private ordermanagmentservice: OrderManagmentService){}
      ngOnInit() : void{
        this.ordermanagmentservice.getProducts()
        .subscribe({
         next: (products) => {
           this.products = products
         }
        });       
}
deleteProduct(id: number){
  this.ordermanagmentservice.deleteProduct(id.toString())
  .subscribe({
    next: (response) => 
    {
      window.location.reload();
    }
  })
}
}
