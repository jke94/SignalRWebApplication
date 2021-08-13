import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../services/signal-r.service'
import { HttpClient } from '@angular/common/http';
import { ChartType} from 'chart.js';
import { ChartModel } from '../interfaces/chartmodel.model';

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

  public valores!:ChartModel[];
  public errorHTTPGet!:string;

  constructor(public signalRService: SignalRService, private http: HttpClient) {
    
    this.chartLabels  = ['Metrics from the Web Api.'];
    this.barChartType  = 'bar'
    this.chartLegend = true;
    this.colors  = 
    [
      { backgroundColor: '#5491DA' }, 
      { backgroundColor: '#E74C3C' }, 
      { backgroundColor: '#82E0AA' }, 
      { backgroundColor: '#A5C7E9' },
      { backgroundColor: '#C5E7E9' },
      { backgroundColor: '#E1E719' },
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
      .subscribe(
        (res) => 
        {
        this.valores = res as ChartModel[];
          console.log(res);
        },
        (res) => 
        {
          this.errorHTTPGet = "Imposible obtener los datos!"
          console.log("Error HTTP Get!", res)
        })
  }
}