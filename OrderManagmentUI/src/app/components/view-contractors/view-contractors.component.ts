import { Component, OnInit } from '@angular/core';
import { ViewContractor } from 'src/app/models/ViewContractor';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-view-contractors',
  templateUrl: './view-contractors.component.html',
  styleUrls: ['./view-contractors.component.css']
})
export class ViewContractorsComponent implements OnInit {
contractors: ViewContractor[] = [];
    constructor(private ordermanagmentservice: OrderManagmentService){}
       ngOnInit() : void{
         this.ordermanagmentservice.getContractors()
         .subscribe({
          next: (contractors) => {
            this.contractors = contractors
          }
         });
}
deleteContractor(id: number){
  this.ordermanagmentservice.deleteContractor(id.toString())
  .subscribe({
    next: (response) => 
    {
      window.location.reload();
    }
  })
}
}