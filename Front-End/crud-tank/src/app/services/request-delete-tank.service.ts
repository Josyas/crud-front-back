import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TankRequest } from '../models/TankRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequestDeleteTankService {

  private apiUrl = "https://localhost:44349/";

  constructor(private http: HttpClient) { }

  public deleteTank(productType: TankRequest): Observable<TankRequest> {
    const url = `${this.apiUrl}/DeleteTank`;

    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: productType, 
    };

    return this.http.delete<TankRequest>(url, options);
  }
}
