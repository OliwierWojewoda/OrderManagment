import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ViewOrderProducts } from '../models/ViewOrderProducts';
import { NewOrderProducts } from '../models/NewOrderProducts';

@Injectable({
  providedIn: 'root'
})

export class OrderProductsManagmentService {

  constructor(private http: HttpClient) { }


  public addOrderProducts(orderProducts:NewOrderProducts): Observable<NewOrderProducts[]> {
    return this.http.post<NewOrderProducts[]>(`${environment.apiUrl}/OrderedProducts/Add`,orderProducts);
  }

  public updateOrderProducts(orderProducts: NewOrderProducts): Observable<NewOrderProducts[]> {
    return this.http.put<NewOrderProducts[]>(`${environment.apiUrl}/OrderedProducts/Update${orderProducts.id}`,
    orderProducts);
  }
  public getOrderProductsById(id: string): Observable<ViewOrderProducts> {
    return this.http.get<ViewOrderProducts>(`${environment.apiUrl}/OrderedProducts/GetBy${id}`);
  }
  public deleteOrderProducts(id: string): Observable<ViewOrderProducts> {
    return this.http.delete<ViewOrderProducts>(`${environment.apiUrl}/OrderedProducts/Delete${id}`);
  }
}
