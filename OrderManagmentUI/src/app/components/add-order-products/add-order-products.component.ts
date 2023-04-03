import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NewOrderProducts } from 'src/app/models/NewOrderProducts';
import { OrderProductsManagmentService } from 'src/app/services/OrderProductsManagmentService';

@Component({
  selector: 'app-add-order-products',
  templateUrl: './add-order-products.component.html',
  styleUrls: ['./add-order-products.component.css']
})
export class AddOrderProductsComponent implements OnInit {

  constructor(private route: ActivatedRoute,private service:OrderProductsManagmentService,private router: Router) { }
  @Input() orderedProducts?: NewOrderProducts;
  newOrderProduct: NewOrderProducts= new NewOrderProducts()
  ngOnInit(): void { 
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id'); 
        this.newOrderProduct.orderId = Number(id)    
          }
        })   
      }
     addOrderProducts(orderProduct:NewOrderProducts){  
      this.service.addOrderProducts(this.newOrderProduct)     
       .subscribe({ 
         next: (orderProduct) => {
           this.router.navigate(['/editOrder',this.newOrderProduct.orderId]);
         }
       });
     }
  }

