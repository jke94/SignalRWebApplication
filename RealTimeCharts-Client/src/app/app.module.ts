import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChartsModule } from 'ng2-charts';
import { HttpClientModule } from '@angular/common/http';
import { BarChartComponent } from './components/bar-chart/bar-chart.component';
import { BubbleAreaChartComponent } from './components/bubble-area-chart/bubble-area-chart.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { DoughnutChartComponent } from './components/doughnut-chart/doughnut-chart/doughnut-chart.component';
import { LineChartComponent } from './components/line-chart/line-chart.component';
import { PieChartComponent } from './components/pie-chart/pie-chart.component';
import { ScatterAreaChartComponent } from './components/scatter-area-chart/scatter-area-chart.component';

@NgModule({
  declarations: [
    AppComponent,
    BarChartComponent,
    BubbleAreaChartComponent,
    DoughnutChartComponent,
    LineChartComponent,
    PieChartComponent,
    ScatterAreaChartComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ChartsModule,
    NgbModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
