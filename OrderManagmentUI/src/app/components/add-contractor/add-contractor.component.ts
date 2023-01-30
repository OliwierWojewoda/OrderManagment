import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ViewContractor } from 'src/app/models/ViewContractor';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-add-contractor',
  templateUrl: './add-contractor.component.html',
  styleUrls: ['./add-contractor.component.css']
})
export class AddContractorComponent implements OnInit {

   newContractor: ViewContractor={
    name :'',
    city: '',
    address: '',
    postalCode: ''
  }
  constructor(private service: OrderManagmentService, private router: Router){}
    ngOnInit() : void{}
     addContractor(contractor: ViewContractor){
      this.service.addContractor(this.newContractor)
      .subscribe({
        next: (contractor) => {
          this.router.navigate(['contractorsList']);
        }
      })
     }
}
