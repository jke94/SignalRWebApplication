import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";  // or from "@microsoft/signalr" if you are using a new library
import { BubbleArea } from '../interfaces/bubbleArea.model';
import { ChartModel } from '../interfaces/chartmodel.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  public data!: ChartModel[];
  public dataBubbleAreaChart!: BubbleArea[];

  private hubConnection!: signalR.HubConnection
  private hubConnectionBubbleArea!: signalR.HubConnection

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/chart')
      .build();

    this.hubConnectionBubbleArea = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/bubbleArea')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started: chart'))
      .catch(err => console.log('Error while starting connection (chart): ' + err))

    this.hubConnectionBubbleArea
      .start()
      .then(() => console.log('Connection started: bubbleArea'))
      .catch(err => console.log('Error while starting connection (bubbleArea): ' + err))
  }

  public addTransferChartDataListener = () => {
    this.hubConnection.on('transferchartdataChart', (data) => {
      this.data = data;
      console.log(data);
    });
  }

  public addTransferBubbleAreaDataListener = () => {
    this.hubConnection.on('transferchartdataBubbleAreaChart', (data) => {
      this.dataBubbleAreaChart = data;
      console.log(data);
    });
  }
}