import { Observable } from 'rxjs';
import { ProductTypeRequest } from '../models/ProductTypeRequest';
import { HttpClient } from '@angular/common/http';
import { Injectable, NgModule } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class RequestProductTypeService {
  private apiUrl = "https://localhost:44349/"; 
  
  constructor(private http: HttpClient) { }

  public createProductType(productType: ProductTypeRequest): Observable<ProductTypeRequest> {
    const url = `${this.apiUrl}/CreateProductType`; 
    return this.http.post<ProductTypeRequest>(url, productType);
  }
}
