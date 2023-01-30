import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ViewContractor } from 'src/app/models/ViewContractor';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-edit-contractor',
  templateUrl: './edit-contractor.component.html',
  styleUrls: ['./edit-contractor.component.css']
})
export class EditContractorComponent implements OnInit {

  constructor(private route: ActivatedRoute,private service:OrderManagmentService,private router: Router) { }
  @Input() contractor?: ViewContractor;
  contractorDetails:ViewContractor=new ViewContractor()
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id');
        if(id) {
          this.service.getContractorById(id)
          .subscribe({
            next: (contractorDetails) => {
              this.contractorDetails = contractorDetails;
            }
          })
        }
      }
    })
  } 
  updateContractor(){
    this.service.updateContractor(this.contractorDetails)
    .subscribe({
      next: (response) => {
        this.router.navigate(['contractorsList']);
      }
    });
  }
}
