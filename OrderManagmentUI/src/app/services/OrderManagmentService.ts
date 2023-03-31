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
import { TopCitiesByIncome } from '../models/StatsModels/TopCitiesByIncome';
import { TopCitiesByContractors } from '../models/StatsModels/TopCitiesByContractors';
import { ContractorWithStats } from '../models/StatsModels/ContractorWithStats';
import { OrderWithStats } from '../models/StatsModels/OrderWithStats';
import { ProductWithStats } from '../models/StatsModels/ProductWithStats';
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
  public updateOrderProducts(orderProducts: NewOrderProducts): Observable<NewOrderProducts[]> {
    return this.http.put<NewOrderProducts[]>(`${environment.apiUrl}/OrderedProducts/Update${orderProducts.id}`,
    orderProducts);
  }
  public getOrderProductsById(id: string): Observable<ViewOrderProducts> {
    return this.http.get<ViewOrderProducts>(`${environment.apiUrl}/OrderedProducts/GetBy${id}`);
  }
  public deleteOrder(id: string): Observable<ViewOrder> {
    return this.http.delete<ViewOrder>(`${environment.apiUrl}/Orders/Delete${id}`);
  }
  public deleteOrderProducts(id: string): Observable<ViewOrderProducts> {
    return this.http.delete<ViewOrderProducts>(`${environment.apiUrl}/OrderedProducts/Delete${id}`);
  }
  public deleteContractor(id: string): Observable<ViewContractor> {
    return this.http.delete<ViewContractor>(`${environment.apiUrl}/Contractors/Delete${id}`);
  }
  public deleteProduct(id: string): Observable<ViewProduct> {
    return this.http.delete<ViewProduct>(`${environment.apiUrl}/Products/Delete${id}`);
  }
  public searchProducts(word: string): Observable<ViewProduct[]> {
    return this.http.get<ViewProduct[]>(`${environment.apiUrl}/Products/Search${word}`);
  }
  public searchContractors(word: string): Observable<ViewContractor[]> {
    return this.http.get<ViewContractor[]>(`${environment.apiUrl}/Contractors/Search${word}`);
  }
  public getTopCitiesByIncome(): Observable<TopCitiesByIncome[]> {
    return this.http.get<TopCitiesByIncome[]>(`${environment.apiUrl}/Contractors/TopCitiesByIncome`);
  } 
  public getTopCitiesByContractors(): Observable<TopCitiesByContractors[]> {
    return this.http.get<TopCitiesByContractors[]>(`${environment.apiUrl}/Contractors/TopCitiesByContractors`);
  } 
  public getTopContractorsByMoneySpent(): Observable<ContractorWithStats[]> {
    return this.http.get<ContractorWithStats[]>(`${environment.apiUrl}/Contractors/TopContractorsByMoneySpent`);
  } 
  public getGetTopOrdersByIncome(): Observable<OrderWithStats[]> {
    return this.http.get<OrderWithStats[]>(`${environment.apiUrl}/Orders/GetTopOrdersByIncome`);
  } 
  public getTopProductsSaled(): Observable<ProductWithStats[]> {
    return this.http.get<ProductWithStats[]>(`${environment.apiUrl}/Products/TopSaledProducts`);
  } 
}
