import { ViewProduct } from "./ViewProduct";

export class ViewOrderProducts{
    id?: number;
    product:ViewProduct= new ViewProduct()
    quantity?: number;
    nettoPrice?: number;
    bruttoPrice?: number;  
    orderId?: number;
}