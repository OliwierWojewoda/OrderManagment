import { ViewProduct } from "./ViewProduct";

export class ViewOrderProducts{
    id?: number;
    date ="";
    product:ViewProduct= new ViewProduct()
    quantity?: number;
    nettoPrice?: number;
    bruttoPrice?: number;  
}