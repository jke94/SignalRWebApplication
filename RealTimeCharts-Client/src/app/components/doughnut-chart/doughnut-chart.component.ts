import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartType,ChartPoint } from 'chart.js';
import { SignalRService } from '../../services/signal-r.service'
import { DoughnutService } from '../../services/doughnut/doughnut.service';
import { Doughnut, DoughnutBetha } from 'src/app/interfaces/doughnut.model';
import { BaseChartDirective } from 'ng2-charts';
import { MultiDataSet,SingleDataSet, Label, Color } from 'ng2-charts';

@Component({
  selector: 'app-doughnut-chart',
  templateUrl: './doughnut-chart.component.html',
  styleUrls: ['./doughnut-chart.component.css']
})
export class DoughnutChartComponent implements OnInit {

  public doughnutChartLabels!: string[];
  public doughnutBaseChartDirective!: BaseChartDirective;
  public doughnutChartType!: ChartType;

  public ChartDataSetsValues!: ChartDataSets[];
  public valores!: SingleDataSet[] ;  
  public errorHTTPGet!: string;

  constructor(public signalRService: SignalRService, public doughnutService: DoughnutService) {
    this.doughnutChartType = 'doughnut'
  }

  ngOnInit(): void {
    this.doughnutHttpRequest();
  }

  private doughnutHttpRequest(): void {

    this.doughnutService.getData().subscribe(
      (res) => {
        this.valores = res.data;
        this.doughnutChartLabels = res.label;
      },
      (res) => {
        this.errorHTTPGet = "Imposible obtener los datos para el componente doughnut-char!"
        console.log("Error HTTP Get!", res)
      })
  }
}
