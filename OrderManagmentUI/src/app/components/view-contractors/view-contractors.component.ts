import { Component, OnInit } from '@angular/core';
import { ViewContractor } from 'src/app/models/ViewContractor';
import { ContractorManagmentService } from 'src/app/services/ContractorManagmentService';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-view-contractors',
  templateUrl: './view-contractors.component.html',
  styleUrls: ['./view-contractors.component.css']
})
export class ViewContractorsComponent implements OnInit {
contractors: ViewContractor[] = [];
enteredSearchValue=''
    constructor(private ordermanagmentservice: ContractorManagmentService){}
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
onSearchTextChanged(){
  if(this.enteredSearchValue.length!=0)
  {
    this.ordermanagmentservice.searchContractors(this.enteredSearchValue)
        .subscribe({
         next: (contractors) => {
           this.contractors = contractors
         }
        });       
  }
  else{
    this.ngOnInit();
  }
}
}