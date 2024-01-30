import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TankRequest } from '../models/TankRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequestUpdateTankService {

  private apiUrl = "https://localhost:44349/"; 
  
  constructor(private http: HttpClient) { }

  public updateTank(productType: TankRequest): Observable<TankRequest> {
    const url = `${this.apiUrl}/UpdateTank`; 
    return this.http.put<TankRequest>(url, productType);
  }
}
