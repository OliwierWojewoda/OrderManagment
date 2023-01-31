import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NewOrderProducts } from 'src/app/models/NewOrderProducts';
import { ViewOrder } from 'src/app/models/ViewOrder';
import { ViewOrderProducts } from 'src/app/models/ViewOrderProducts';
import { ViewProduct } from 'src/app/models/ViewProduct';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-view-order-products',
  templateUrl: './view-order-products.component.html',
  styleUrls: ['./view-order-products.component.css']
})
export class ViewOrderProductsComponent implements OnInit {

  constructor(private route: ActivatedRoute,private service:OrderManagmentService,private router: Router) { }
  @Input() order?: ViewOrder;
  @Input() orderedProducts?: NewOrderProducts;
  orderDetails:ViewOrder=new ViewOrder()
  newOrderProduct: NewOrderProducts= new NewOrderProducts()
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id');
        if(id) {
          this.service.getOrderById(id)
          .subscribe({
            next: (orderDetails) => {
              this.orderDetails = orderDetails;
            }
          })
        }
      }
    })
  } 
    updateOrder(){
     this.service.updateOrder(this.orderDetails)
     .subscribe({
       next: (response) => {
         this.router.navigate(['/']);
       }
     });
    }

     addOrderProducts(orderProduct:NewOrderProducts){
      this.newOrderProduct.orderId=this.orderDetails.id
      this.service.addOrderProducts(this.newOrderProduct)
       .subscribe({ 
         next: (orderProduct) => {
           this.router.navigate(['/editOrder',this.newOrderProduct.orderId]);
           window.location.reload();
         }
       });
     }
  }

