import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TankRequest } from '../models/TankRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequestCreateTankService {

  private apiUrl = "https://localhost:44349/"; 
  
  constructor(private http: HttpClient) { }

  public createTank(productType: TankRequest): Observable<TankRequest> {
    const url = `${this.apiUrl}/CreateTank`; 
    return this.http.post<TankRequest>(url, productType);
  }
}
