import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NewOrder } from 'src/app/models/NewOrder';
import { ViewOrder } from 'src/app/models/ViewOrder';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {
newOrder: NewOrder = new NewOrder()
 constructor(private service: OrderManagmentService, private router: Router){}
   ngOnInit() : void{}
    addOrder(order: NewOrder){
     this.service.addOrder(this.newOrder)
     .subscribe({
       next: (order) => {
         this.router.navigate(['/editOrder',order[order.length-1].id]);
       }
     })
    }
}