import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NewOrderProducts } from 'src/app/models/NewOrderProducts';
import { ViewOrderProducts } from 'src/app/models/ViewOrderProducts';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';
import { OrderProductsManagmentService } from 'src/app/services/OrderProductsManagmentService';

@Component({
  selector: 'app-edit-order-products',
  templateUrl: './edit-order-products.component.html',
  styleUrls: ['./edit-order-products.component.css']
})
export class EditOrderProductsComponent implements OnInit {

  constructor(private route: ActivatedRoute,private service:OrderProductsManagmentService,private router: Router) { }
  @Input() orderProducts?: NewOrderProducts;
  orderedProducts:NewOrderProducts=new NewOrderProducts()
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id');
        const orderid = params.get('orderid');
        if(id) {
          this.service.getOrderProductsById(id)
          .subscribe({
            next: (orderedProducts) => {
              this.orderedProducts.id= orderedProducts.id;
              this.orderedProducts.orderId = Number(orderid);
              this.orderedProducts.quantity = orderedProducts.quantity;
              this.orderedProducts.productId = orderedProducts.product.id;
            }
          })
        }
      }
    })
  } 
  updateOrderProducts(){
    this.service.updateOrderProducts(this.orderedProducts)
    .subscribe({
      next: (response) => {
        this.router.navigate(['/editOrder',this.orderedProducts.orderId]);
      }
    });
  }
}
