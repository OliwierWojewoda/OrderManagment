import { ViewOrderProducts } from "./ViewOrderProducts";

export class NewOrder{
    id?: number;
    createdAt ="";
    contractorId?: number;
    overallNetto?: number;
    overallBrutto?: number;
    orderedProducts:ViewOrderProducts[]=[];  
}