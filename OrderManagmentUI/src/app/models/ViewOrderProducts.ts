import { ViewProduct } from "./ViewProduct";

export class ViewOrder{
    id?: number;
    date ="";
    product:ViewProduct= new ViewProduct()
    quantity?: number;
    nettoPrice?: number;
    bruttoPrice?: number;  
}