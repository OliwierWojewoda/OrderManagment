import { ViewOrderProductsComponent } from "../components/view-order-products/view-order-products.component";
import { ViewContractor } from "./ViewContractor";
import { ViewOrderProducts } from "./ViewOrderProducts";


export class ViewOrder{
    id?: number;
    createdAt ="";
    contractor: ViewContractor=new ViewContractor();
    overallNetto?: number;
    overallBrutto?: number;
    orderedProducts:ViewOrderProducts[]=[];  
}