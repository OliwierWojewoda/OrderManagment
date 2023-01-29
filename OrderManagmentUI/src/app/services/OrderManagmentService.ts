import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ViewOrder } from '../models/ViewOrder';
import { ViewProduct } from '../models/ViewProduct';
@Injectable({
  providedIn: 'root'
})

export class OrderManagmentService {

  constructor(private http: HttpClient) { }

  public getProducts(): Observable<ViewProduct[]> {
    return this.http.get<ViewProduct[]>(`${environment.apiUrl}/Products/GetAll`);
  }
  
}
