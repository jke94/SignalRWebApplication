
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Doughnut } from 'src/app/interfaces/doughnut.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DoughnutService{
  public valores!:Doughnut[];
  public errorHTTPGet!:string;

  constructor(private http: HttpClient) { }

  public getData():Observable<any> {
    return this.http.get('https://localhost:5001/api/doughnut');
  }
}
