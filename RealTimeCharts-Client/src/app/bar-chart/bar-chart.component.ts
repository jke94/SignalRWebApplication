import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../services/signal-r.service'
import { HttpClient } from '@angular/common/http';
import { ChartType} from 'chart.js';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent implements OnInit {

  public chartLabels: string[];
  public barChartType: ChartType;
  public chartLegend: boolean;
  public colors: any[];
  public chartOptions: any;

  constructor(public signalRService: SignalRService, private http: HttpClient) {
    
    this.chartLabels  = ['Real time data for the chart'];
    this.barChartType  = 'bar'
    this.chartLegend = true;
    this.colors  = 
    [
      { backgroundColor: '#5491DA' }, 
      { backgroundColor: '#E74C3C' }, 
      { backgroundColor: '#82E0AA' }, 
      { backgroundColor: '#E5E7E9' },
      { backgroundColor: '#15E7E9' }

    ];
    this.chartOptions = {
      scaleShowVerticalLines: true,
      responsive: true,
      scales: {
        yAxes: [{
          ticks: {
            beginAtZero: true
          }
        }]
      }
    }
   }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener();    
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get('https://localhost:5001/api/chart')
      .subscribe(res => {
        console.log(res);
      })
  }
}