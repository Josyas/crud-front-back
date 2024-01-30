import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductTypeRequest } from '../models/ProductTypeRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequestUpdateProducttypeService {

  private apiUrl = "https://localhost:44349/"; 
  
  constructor(private http: HttpClient) { }

  public updateProductType(productType: ProductTypeRequest): Observable<ProductTypeRequest> {
    const url = `${this.apiUrl}/UpdateProductType`; 
    return this.http.put<ProductTypeRequest>(url, productType);
  }
}
