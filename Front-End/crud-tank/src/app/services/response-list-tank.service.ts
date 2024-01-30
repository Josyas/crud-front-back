import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TankRequest } from '../models/TankRequest';

@Injectable({
  providedIn: 'root'
})
export class ResponseListTankService {

  private apiUrl = "https://localhost:44349/"; 
  
  constructor(private http: HttpClient) { }

  public getAllTanks(): Observable<TankRequest[]> {
    const url = `${this.apiUrl}/GetAllTank`; 
    return this.http.get<TankRequest[]>(url);
  }
}
