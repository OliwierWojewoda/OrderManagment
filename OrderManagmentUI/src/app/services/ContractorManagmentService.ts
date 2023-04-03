import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { ViewContractor } from '../models/ViewContractor';
import { TopCitiesByIncome } from '../models/StatsModels/TopCitiesByIncome';
import { TopCitiesByContractors } from '../models/StatsModels/TopCitiesByContractors';
import { ContractorWithStats } from '../models/StatsModels/ContractorWithStats';

@Injectable({
  providedIn: 'root'
})

export class ContractorManagmentService {

  constructor(private http: HttpClient) { }
  public getContractors(): Observable<ViewContractor[]> {
    return this.http.get<ViewContractor[]>(`${environment.apiUrl}/Contractors/GetAll`);
  }
  public getContractorById(id: string): Observable<ViewContractor> {
    return this.http.get<ViewContractor>(`${environment.apiUrl}/Contractors/GetBy${id}`);
  } 
  public updateContractor(contractor: ViewContractor): Observable<ViewContractor[]> {
    return this.http.put<ViewContractor[]>(`${environment.apiUrl}/Contractors/Update${contractor.id}`,
    contractor);
  }
  public addContractor(contractor: ViewContractor): Observable<ViewContractor[]> {
    return this.http.post<ViewContractor[]>(`${environment.apiUrl}/Contractors/Add`,contractor);
  }
  public deleteContractor(id: string): Observable<ViewContractor> {
    return this.http.delete<ViewContractor>(`${environment.apiUrl}/Contractors/Delete${id}`);
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
}
