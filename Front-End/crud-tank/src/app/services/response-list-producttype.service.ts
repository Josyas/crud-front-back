import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductTypeRequest } from '../models/ProductTypeRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ResponseListProducttypeService {

  private apiUrl = "https://localhost:44349/"; 
  
  constructor(private http: HttpClient) { }

  public getAllProductTypes(): Observable<ProductTypeRequest[]> {
    const url = `${this.apiUrl}/GetAllProductType`; 
    return this.http.get<ProductTypeRequest[]>(url);
  }
}
