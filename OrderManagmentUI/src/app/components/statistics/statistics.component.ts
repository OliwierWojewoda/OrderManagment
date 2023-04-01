import { Component, OnInit } from '@angular/core';
import { ContractorWithStats } from 'src/app/models/StatsModels/ContractorWithStats';
import { OrderWithStats } from 'src/app/models/StatsModels/OrderWithStats';
import { ProductWithStats } from 'src/app/models/StatsModels/ProductWithStats';
import { TopCitiesByContractors } from 'src/app/models/StatsModels/TopCitiesByContractors';
import { TopCitiesByIncome } from 'src/app/models/StatsModels/TopCitiesByIncome';
import { OrderManagmentService } from 'src/app/services/OrderManagmentService';

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
  constructor(private ordermanagmentservice: OrderManagmentService){}
     ngOnInit() : void{
       this.ordermanagmentservice.getTopProductsSaled()
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
       this.ordermanagmentservice.getTopContractorsByMoneySpent()
       .subscribe({
        next: (ContractorStats) => {
          this.ContractorStats = ContractorStats
        }
       })
       this.ordermanagmentservice.getTopCitiesByContractors()
       .subscribe({
        next: (TopCitiesContractors) => {
          this.TopCitiesContractors = TopCitiesContractors
        }
       })
       this.ordermanagmentservice.getTopCitiesByIncome()
       .subscribe({
        next: (TopCitiesIncome) => {
          this.TopCitiesIncome = TopCitiesIncome
        }
       })
       this.ordermanagmentservice.getMostProductsSaled()
       .subscribe({
        next: (MostProductsSold) => {
          this.MostProductsSold = MostProductsSold
        }
       })
}}
