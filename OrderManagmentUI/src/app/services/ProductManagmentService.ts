import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ViewProduct } from '../models/ViewProduct';
import { ProductWithStats } from '../models/StatsModels/ProductWithStats';
@Injectable({
  providedIn: 'root'
})

export class ProductManagmentService {

  constructor(private http: HttpClient) { }

  public getProducts(): Observable<ViewProduct[]> {
    return this.http.get<ViewProduct[]>(`${environment.apiUrl}/Products/GetAll`);
  }
  public getProductById(id: string): Observable<ViewProduct> {
    return this.http.get<ViewProduct>(`${environment.apiUrl}/Products/GetBy${id}`);
  } 
  public updateProduct(product: ViewProduct): Observable<ViewProduct[]> {
    return this.http.put<ViewProduct[]>(`${environment.apiUrl}/Products/Update${product.id}`,
    product);
  }
  public addProduct(product: ViewProduct): Observable<ViewProduct[]> {
    return this.http.post<ViewProduct[]>(`${environment.apiUrl}/Products/Add`,product);
  }
  public deleteProduct(id: string): Observable<ViewProduct> {
    return this.http.delete<ViewProduct>(`${environment.apiUrl}/Products/Delete${id}`);
  }
  public searchProducts(word: string): Observable<ViewProduct[]> {
    return this.http.get<ViewProduct[]>(`${environment.apiUrl}/Products/Search${word}`);
  }
  public getTopProductsSaled(): Observable<ProductWithStats[]> {
    return this.http.get<ProductWithStats[]>(`${environment.apiUrl}/Products/TopSaledProducts`);
  } 
  public getMostProductsSaled(): Observable<ProductWithStats[]> {
    return this.http.get<ProductWithStats[]>(`${environment.apiUrl}/Products/MostSaledProducts`);
  } 
}
