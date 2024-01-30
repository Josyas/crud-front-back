import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductTypeRequest } from '../models/ProductTypeRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequestDeleteProducttypeService {

  private apiUrl = "https://localhost:44349/";

  constructor(private http: HttpClient) { }

  public deleteProductType(productType: ProductTypeRequest): Observable<ProductTypeRequest> {
    const url = `${this.apiUrl}/DeleteProductType`;

    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: productType, 
    };

    return this.http.delete<ProductTypeRequest>(url, options);
  }
}
