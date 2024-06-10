import { Component, OnInit, AfterViewInit } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { ProductionMonthly } from '../../contracts/reports/productionsMonthly';
import { ProductionYearly } from '../../contracts/reports/productionsYearly';
import { CouldBeSavedCarbonFootprint } from '../../contracts/reports/couldBeSavedCarbonFootprint';
import { TransportationMonthly } from '../../contracts/reports/transportationMonthly';
import { TransportationYearly } from '../../contracts/reports/transportationYearly';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit, AfterViewInit {

  constructor(private httpClientService: HttpClientService) { }

  couldBeSavedCarbonFootprint: CouldBeSavedCarbonFootprint;

  monthlyProductionReport: ProductionMonthly[];
  yearlyProductionReport: ProductionYearly[];

  monthlyTransportationReport: TransportationMonthly;
  yearlyTransportationReport: TransportationYearly;

  monthlyProductionChartData: any;
  yearlyProductionChartData: any;

  monthlyTransportationChartData: any;
  yearlyTransportationChartData: any;

  basicOptions: any = {
    // Define your basic chart options here
  };

  getCouldBeSavedCarbonFootprint() {
    this.httpClientService.get<CouldBeSavedCarbonFootprint>({
      controller: "Reports",
      action: "GetSavedCarbonEmission"
    }).subscribe(data => {
      this.couldBeSavedCarbonFootprint = data;
      console.log(this.couldBeSavedCarbonFootprint);
    });
  }

  ngOnInit() {
    this.getMonthlyProductionReport();
    this.getYearlyProductionReport();
    this.getMonthlyTransportationReport();
    this.getYearlyTransportationReport();
    this.getCouldBeSavedCarbonFootprint();
  }

  ngAfterViewInit() {
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
    this.httpClientService.get<TransportationMonthly>({
      controller: "Reports",
      action: "GetTransportationsWithCarbonFootprintByMonth"
    }).subscribe(data => {
      this.monthlyTransportationReport = data;
      console.log(this.monthlyTransportationReport);
      this.formatMonthlyTransportationChartData();
    });
  }

  getYearlyTransportationReport() {
    this.httpClientService.get<TransportationYearly>({
      controller: "Reports",
      action: "GetTransportationsWithCarbonFootprintByYear"
    }).subscribe(data => {
      this.yearlyTransportationReport = data;
      console.log(this.yearlyTransportationReport);
      this.formatYearlyTransportationChartData();
    });
  }

  formatMonthlyProductionChartData() {
    if (this.monthlyProductionReport) {
      this.monthlyProductionChartData = {
        labels: this.monthlyProductionReport.map(item => item.monthName),
        datasets: [
          {
            label: 'Monthly Production Environment Carbon Footprint',
            data: this.monthlyProductionReport.map(item => item.totalCarbonFootprintCount),
            backgroundColor: 'rgba(255, 99, 132, 0.2)',
            borderColor: 'rgba(255, 99, 132, 1)',
            borderWidth: 1
          }
        ]
      };
    }
  }

  formatYearlyProductionChartData() {
    if (this.yearlyProductionReport) {
      this.yearlyProductionChartData = {
        labels: this.yearlyProductionReport.map(item => item.year),
        datasets: [
          {
            label: 'Yearly Production Environment Carbon Footprint',
            data: this.yearlyProductionReport.map(item => item.totalCarbonFootprintCount),
            backgroundColor: 'rgba(54, 162, 235, 0.2)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1
          }
        ]
      };
    }
  }

  formatMonthlyTransportationChartData() {
    if (this.monthlyTransportationReport && this.monthlyTransportationReport.transportation && this.monthlyTransportationReport.totalCarbonFootprintIfElectrical) {
      this.monthlyTransportationChartData = {
        labels: this.monthlyTransportationReport.transportation.map(item => item.monthName),
        datasets: [
          {
            label: 'Monthly Transportation Environment Carbon Footprint',
            data: this.monthlyTransportationReport.transportation.map(item => item.totalCarbonFootprintCount),
            backgroundColor: 'rgba(255, 99, 132, 0.2)',
            borderColor: 'rgba(255, 99, 132, 1)',
            borderWidth: 1
          },
          {
            label: 'Monthly Transportation Carbon Footprint If Electric',
            data: this.monthlyTransportationReport.totalCarbonFootprintIfElectrical.map(item => item.totalCarbonFootprintCount),
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1
          }
        ]
      };
    }
  }

  formatYearlyTransportationChartData() {
    if (this.yearlyTransportationReport && this.yearlyTransportationReport.transportation && this.yearlyTransportationReport.totalCarbonFootprintIfElectrical) {
      this.yearlyTransportationChartData = {
        labels: this.yearlyTransportationReport.transportation.map(item => item.year),
        datasets: [
          {
            label: 'Yearly Transportation Environment Carbon Footprint',
            data: this.yearlyTransportationReport.transportation.map(item => item.totalCarbonFootprintCount),
            backgroundColor: 'rgba(255, 99, 132, 0.2)',
            borderColor: 'rgba(255, 99, 132, 1)',
            borderWidth: 1
          },
          {
            label: 'Yearly Transportation Carbon Footprint If Electric',
            data: this.yearlyTransportationReport.totalCarbonFootprintIfElectrical.map(item => item.totalCarbonFootprintCount),
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1
          }
        ]
      };
    }
  }
}