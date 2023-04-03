import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ViewOrder } from '../models/ViewOrder';
import { NewOrder } from '../models/NewOrder';
import { OrderWithStats } from '../models/StatsModels/OrderWithStats';
@Injectable({
  providedIn: 'root'
})

export class OrderManagmentService {

  constructor(private http: HttpClient) { }

  public getOrders(): Observable<ViewOrder[]> {
    return this.http.get<ViewOrder[]>(`${environment.apiUrl}/Orders/GetAll`);
  } 
  public getOrderById(id: string): Observable<ViewOrder> {
    return this.http.get<ViewOrder>(`${environment.apiUrl}/Orders/GetBy${id}`);
  }
  public updateOrder(order: ViewOrder): Observable<ViewOrder[]> {
    return this.http.put<ViewOrder[]>(`${environment.apiUrl}/Orders/Update${order.id}`,
    order);
  } 
  public addOrder(order:NewOrder): Observable<NewOrder[]> {
    return this.http.post<NewOrder[]>(`${environment.apiUrl}/Orders/Add`,order);
  }
  public deleteOrder(id: string): Observable<ViewOrder> {
    return this.http.delete<ViewOrder>(`${environment.apiUrl}/Orders/Delete${id}`);
  }
  public getGetTopOrdersByIncome(): Observable<OrderWithStats[]> {
    return this.http.get<OrderWithStats[]>(`${environment.apiUrl}/Orders/GetTopOrdersByIncome`);
  } 

}
