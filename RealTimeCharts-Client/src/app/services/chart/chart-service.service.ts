import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChartModel } from 'src/app/interfaces/chartmodel.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChartService{
  public valores!:ChartModel[];
  public errorHTTPGet!:string;

  constructor(private http: HttpClient) { }

  public getData():Observable<any> {
    return this.http.get('https://localhost:5001/api/chart');
  }
}
