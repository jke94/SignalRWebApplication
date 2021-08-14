import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChartsModule } from 'ng2-charts';
import { HttpClientModule } from '@angular/common/http';
import { BarChartComponent } from './components/bar-chart/bar-chart.component';
import { BubbleAreaChartComponent } from './components/bubble-area-chart/bubble-area-chart.component';

@NgModule({
  declarations: [
    AppComponent,
    BarChartComponent,
    BubbleAreaChartComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ChartsModule    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
