import { Component, OnInit } from '@angular/core';
import { ContractorWithStats } from 'src/app/models/StatsModels/ContractorWithStats';
import { OrderWithStats } from 'src/app/models/StatsModels/OrderWithStats';
import { ProductWithStats } from 'src/app/models/StatsModels/ProductWithStats';
import { TopCitiesByContractors } from 'src/app/models/StatsModels/TopCitiesByContractors';
import { TopCitiesByIncome } from 'src/app/models/StatsModels/TopCitiesByIncome';
import { ContractorManagmentService } from 'src/app/services/ContractorManagmentService';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';
import { ProductManagmentService } from 'src/app/services/ProductManagmentService';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  ProductStats: ProductWithStats[] = []
  OrderStats: OrderWithStats[] = []
  ContractorStats: ContractorWithStats[] = []
  TopCitiesIncome: TopCitiesByIncome[] = []
  TopCitiesContractors: TopCitiesByContractors[] = []
  MostProductsSold:ProductWithStats[] = []
  constructor(private ordermanagmentservice: OrderManagmentService
    ,private contractormanagmentService: ContractorManagmentService,
    private productmanagmentService: ProductManagmentService){}
     ngOnInit() : void{
       this.productmanagmentService.getTopProductsSaled()
       .subscribe({
        next: (ProductStats) => {
          this.ProductStats = ProductStats
        }
       });
       this.ordermanagmentservice.getGetTopOrdersByIncome()
       .subscribe({
        next: (OrderStats) => {
          this.OrderStats = OrderStats
        }
       })
       this.contractormanagmentService.getTopContractorsByMoneySpent()
       .subscribe({
        next: (ContractorStats) => {
          this.ContractorStats = ContractorStats
        }
       })
       this.contractormanagmentService.getTopCitiesByContractors()
       .subscribe({
        next: (TopCitiesContractors) => {
          this.TopCitiesContractors = TopCitiesContractors
        }
       })
       this.contractormanagmentService.getTopCitiesByIncome()
       .subscribe({
        next: (TopCitiesIncome) => {
          this.TopCitiesIncome = TopCitiesIncome
        }
       })
       this.productmanagmentService.getMostProductsSaled()
       .subscribe({
        next: (MostProductsSold) => {
          this.MostProductsSold = MostProductsSold
        }
       })
}}
