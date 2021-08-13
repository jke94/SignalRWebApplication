import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BubbleArea } from 'src/app/interfaces/bubbleArea.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BubbleareaService{

  public valores!:BubbleArea[];
  public errorHTTPGet!:string;

  constructor(private http: HttpClient) { }

  public getData():Observable<any> {
    return this.http.get('https://localhost:5001/api/BubbleAreaChart');
  }
}
