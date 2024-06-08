import { Component } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { ProductionMonthly } from '../../contracts/reports/productionsMonthly';
import { ProductionYearly } from '../../contracts/reports/productionsYearly';
import { TransportationMonthly } from '../../contracts/reports/transportationMonthly';
import { TransportationYearly } from '../../contracts/reports/transportationYearly';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent {

  constructor(private httpClientService: HttpClientService) { }

  monthlyProductionReport: ProductionMonthly[];
  yearlyProductionReport: ProductionYearly[];

  monthlyTransportationReport: TransportationMonthly[];
  yearlyTransportationReport: TransportationYearly[];


  monthlyProductionChartData: any;
  yearlyProductionChartData: any;

  monthlyTransportationChartData: any;
  yearlyTransportationChartData: any;

  basicOptions: any = {
    
    
    
  };

  ngOnInit() {
    this.getMonthlyProductionReport();
    this.getYearlyProductionReport();
    this.getMonthlyTransportationReport();
    this.getYearlyTransportationReport();
  }

  ngOnViewInit() {
    this.getMonthlyProductionReport();
    this.getYearlyProductionReport();
    this.getMonthlyTransportationReport();
    this.getYearlyTransportationReport();
  }

  getMonthlyProductionReport() {
    this.httpClientService.get<ProductionMonthly[]>({
      controller: "Reports",
      action: "GetProductionsWithCarbonFootprintByMonth"
    }).subscribe(data => {
      this.monthlyProductionReport = data;
      this.formatMonthlyProductionChartData();
    });
  }

  getYearlyProductionReport() {
    this.httpClientService.get<ProductionYearly[]>({
      controller: "Reports",
      action: "GetProductionsWithCarbonFootprintByYear"
    }).subscribe(data => {
      this.yearlyProductionReport = data;
      this.formatYearlyProductionChartData();
    });
  }

  getMonthlyTransportationReport() {
    this.httpClientService.get<TransportationMonthly[]>({
      controller: "Reports",
      action: "GetTransportationsWithCarbonFootprintByMonth"
    }).subscribe(data => {
      this.monthlyTransportationReport = data;
      console.log(this.monthlyTransportationReport);

      this.formatMonthlyTransportationChartData();
    });
  }

  getYearlyTransportationReport() {
    this.httpClientService.get<TransportationYearly[]>({
      controller: "Reports",
      action: "GetTransportationsWithCarbonFootprintByYear"
    }).subscribe(data => {
      this.yearlyTransportationReport = data;
      this.formatYearlyTransportationChartData();
    });
  }


  formatMonthlyProductionChartData() {
    // Format your monthlyChartData here based on monthlyReport
    // Example:
    this.monthlyProductionChartData = {
      labels: this.monthlyProductionReport.map(item => item.monthName),
      datasets: [
        {
          label: 'Monthly Production Envioronment Carbon Footprint',
          data: this.monthlyProductionReport.map(item => item.totalCarbonFootprintCount),
          backgroundColor: 'rgba(255, 99, 132, 0.2)',
          borderColor: 'rgba(255, 99, 132, 1)',
          borderWidth: 1
        }
      ]
    };
  }

  formatYearlyProductionChartData() {
    // Format your yearlyChartData here based on yearlyReport
    // Example:
    this.yearlyProductionChartData = {
      labels: this.yearlyProductionReport.map(item => item.year),
      datasets: [
        {
          label: 'Yearly Production Envioronment Carbon Footprint',
          data: this.yearlyProductionReport.map(item => item.totalCarbonFootprintCount),
          backgroundColor: 'rgba(54, 162, 235, 0.2)',
          borderColor: 'rgba(54, 162, 235, 1)',
          borderWidth: 1
        }
      ]
    };
  }

  formatMonthlyTransportationChartData() {
    // Format your monthlyChartData here based on monthlyReport
    // Example:
    this.monthlyTransportationChartData = {
      labels: this.monthlyTransportationReport.map(item => item.monthName),
      datasets: [
        {
          label: 'Monthly Transportation Envioronment Carbon Footprint',
          data: this.monthlyTransportationReport.map(item => item.totalCarbonFootprintCount),
          backgroundColor: 'rgba(255, 99, 132, 0.2)',
          borderColor: 'rgba(255, 99, 132, 1)',
          borderWidth: 1
        }
      ]
    };
  }

  formatYearlyTransportationChartData() {
    // Format your yearlyChartData here based on yearlyReport
    // Example:
    this.yearlyTransportationChartData = {
      labels: this.yearlyTransportationReport.map(item => item.year),
      datasets: [
        {
          label: 'Yearly Transportation Envioronment Carbon Footprint',
          data: this.yearlyTransportationReport.map(item => item.totalCarbonFootprintCount),
          backgroundColor: 'rgba(54, 162, 235, 0.2)',
          borderColor: 'rgba(54, 162, 235, 1)',
          borderWidth: 1
        }
      ]
    };
  }

}