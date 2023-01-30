import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ViewProduct } from 'src/app/models/ViewProduct';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  newProduct: ViewProduct={
    name: '',
    nettoPrice:0,
    vat:0,
    bruttoPrice:0,
 }
 constructor(private service: OrderManagmentService, private router: Router){}
   ngOnInit() : void{}
   addProduct(product: ViewProduct){
     this.service.addProduct(this.newProduct)
     .subscribe({
       next: (product) => {
         this.router.navigate(['productsList']);
       }
     })
    }
}

