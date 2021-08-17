import { Component } from '@angular/core';
import { ChartType, ChartDataSets } from 'chart.js';
import { SignalRService } from '../../services/signal-r.service'
import { BubbleArea } from '../../interfaces/bubbleArea.model';
import { BubbleareaService } from '../../services/bubbleArea/bubblearea-service.service';

@Component({
  selector: 'app-bubble-area-chart',
  templateUrl: './bubble-area-chart.component.html',
  styleUrls: ['./bubble-area-chart.component.css']
})
export class BubbleAreaChartComponent {

  public chartLabels: string[];
  public bubbleChartOptions: any = [];
  public bubbleChartType!: ChartType;
  public bubbleChartLegend!: boolean;

  public bubbleChartData!: BubbleArea [];

  public valores!: BubbleArea[];
  public errorHTTPGet!: string;

  constructor(public signalRService: SignalRService,
              public bubbleAreaService: BubbleareaService){

    this.chartLabels = ['Metrics from the Web Api.'];
    this.bubbleChartOptions = {
      responsive: true,
      scales: {
        xAxes: [
          {
            ticks: {
              min: 0,
              max: 80,
            }
          }
        ],
        yAxes: [
          {
            ticks: {
              min: 0,
              max: 250,
            }
          }
        ]
      }
    };
    this.bubbleChartType = 'bubble';
    this.bubbleChartLegend = true;
    
    // this.bubbleChartData = [
    //     {label: 'Label 1', data:[{ x: 45, y: 150000, r: 22.22 }], backgroundColor: '#5491DA', borderColor: '#000000', borderWidth: 5,pointStyle: 'star'},
    //     {label: 'Label 2', data:[{ x: 42, y: 110000, r: 33.00 }], backgroundColor: '#E74C3C', pointStyle: 'triangle'},
    //     {label: 'Label 3', data:[{ x: 60, y: 80637,  r: 25.22 }], backgroundColor: '#82E0AA', pointStyle: 'triangle'},
    //     {label: 'Label 4', data:[{ x: 75, y: 195055, r: 21.50 }], backgroundColor: '#A5C7E9'},
    //     {label: 'Label 5', data:[{ x: 30, y: 160446, r: 35.67 }], backgroundColor: '#C5E7E9'},
    //     {label: 'Label 6', data:[{ x: 70, y: 100446, r: 15.67 }], backgroundColor: '#E1E719'},
    //     {label: 'Label 7', data:[{ x: 10, y: 110446, r: 45.67 }], backgroundColor: '#15E7E9'},
    //   ]
  }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferBubbleAreaDataListener();
    this.bubbleAreatHttpRequest();
  }

  private bubbleAreatHttpRequest(): void {

    this.bubbleAreaService.getData().subscribe(
      (res) => {
        this.valores = res as BubbleArea[];
        this.bubbleChartData = res as BubbleArea[];
        console.log("BubbleArea Data: ",this.valores);
      },
      (res) => {
        this.errorHTTPGet = "Imposible obtener los datos para el componente bubble-area!"
        console.log("Error HTTP Get!", res)
      })
  }
}
