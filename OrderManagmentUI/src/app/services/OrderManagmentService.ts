import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ViewOrder } from '../models/ViewOrder';
import { ViewProduct } from '../models/ViewProduct';
import { ViewContractor } from '../models/ViewContractor';
import { ViewOrderProducts } from '../models/ViewOrderProducts';
import { NewOrderProducts } from '../models/NewOrderProducts';
import { NewOrder } from '../models/NewOrder';
@Injectable({
  providedIn: 'root'
})

export class OrderManagmentService {

  constructor(private http: HttpClient) { }

  public getProducts(): Observable<ViewProduct[]> {
    return this.http.get<ViewProduct[]>(`${environment.apiUrl}/Products/GetAll`);
  }
  public getContractors(): Observable<ViewContractor[]> {
    return this.http.get<ViewContractor[]>(`${environment.apiUrl}/Contractors/GetAll`);
  }
  public getOrders(): Observable<ViewOrder[]> {
    return this.http.get<ViewOrder[]>(`${environment.apiUrl}/Orders/GetAll`);
  } 
  public getContractorById(id: string): Observable<ViewContractor> {
    return this.http.get<ViewContractor>(`${environment.apiUrl}/Contractors/GetBy${id}`);
  } 
  public updateContractor(contractor: ViewContractor): Observable<ViewContractor[]> {
    return this.http.put<ViewContractor[]>(`${environment.apiUrl}/Contractors/Update${contractor.id}`,
    contractor);
  }
  public getProductById(id: string): Observable<ViewProduct> {
    return this.http.get<ViewProduct>(`${environment.apiUrl}/Products/GetBy${id}`);
  } 
  public updateProduct(product: ViewProduct): Observable<ViewProduct[]> {
    return this.http.put<ViewProduct[]>(`${environment.apiUrl}/Products/Update${product.id}`,
    product);
  }
  public getOrderById(id: string): Observable<ViewOrder> {
    return this.http.get<ViewOrder>(`${environment.apiUrl}/Orders/GetBy${id}`);
  }
  public updateOrder(order: ViewOrder): Observable<ViewOrder[]> {
    return this.http.put<ViewOrder[]>(`${environment.apiUrl}/Orders/Update${order.id}`,
    order);
  } 
  public addProduct(product: ViewProduct): Observable<ViewProduct[]> {
    return this.http.post<ViewProduct[]>(`${environment.apiUrl}/Products/Add`,product);
  }
  public addContractor(contractor: ViewContractor): Observable<ViewContractor[]> {
    return this.http.post<ViewContractor[]>(`${environment.apiUrl}/Contractors/Add`,contractor);
  }
  public addOrderProducts(orderProducts:NewOrderProducts): Observable<NewOrderProducts[]> {
    return this.http.post<NewOrderProducts[]>(`${environment.apiUrl}/OrderedProducts/Add`,orderProducts);
  }
  public addOrder(order:NewOrder): Observable<NewOrder[]> {
    return this.http.post<NewOrder[]>(`${environment.apiUrl}/Orders/Add`,order);
  }
}
