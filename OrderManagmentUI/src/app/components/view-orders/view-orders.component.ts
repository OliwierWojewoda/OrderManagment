import { Component, OnInit } from '@angular/core';
import { ViewOrder } from 'src/app/models/ViewOrder';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-view-orders',
  templateUrl: './view-orders.component.html',
  styleUrls: ['./view-orders.component.css']
})
export class ViewOrdersComponent implements OnInit {
  orders: ViewOrder[] = [];
  constructor(private ordermanagmentservice: OrderManagmentService){}
     ngOnInit() : void{
       this.ordermanagmentservice.getOrders()
       .subscribe({
        next: (orders) => {
          this.orders = orders
        }
       });
}
deleteOrder(id: number){
  this.ordermanagmentservice.deleteOrder(id.toString())
  .subscribe({
    next: (response) => 
    {
      window.location.reload();
    }
  })
}
}
