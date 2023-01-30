import { ViewOrderProductsComponent } from "../components/view-order-products/view-order-products.component";
import { ViewContractor } from "./ViewContractor";

export class ViewOrder{
    id?: number;
    date ="";
    contractor: ViewContractor=new ViewContractor();
    overallNetto?: number;
    overallBrutto?: number;
    orderedProducts:ViewOrderProductsComponent[]=[];  
}