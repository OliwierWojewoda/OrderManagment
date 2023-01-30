import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ViewProduct } from 'src/app/models/ViewProduct';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  constructor(private route: ActivatedRoute,private service:OrderManagmentService,private router: Router) { }
  @Input() contractor?: ViewProduct;
  productDetails:ViewProduct=new ViewProduct()
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id');
        if(id) {
          this.service.getProductById(id)
          .subscribe({
            next: (productDetails) => {
              this.productDetails = productDetails;
            }
          })
        }
      }
    })
  } 
  updateProduct(){
    this.service.updateProduct(this.productDetails)
    .subscribe({
      next: (response) => {
        this.router.navigate(['productsList']);
      }
    });
  }
}

