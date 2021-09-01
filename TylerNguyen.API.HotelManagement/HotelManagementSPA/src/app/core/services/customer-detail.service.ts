import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';
import { CustomerDetailCard } from 'src/app/shared/models/customerDetailCard';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerDetailService {

  constructor(private http: HttpClient) { }
  getCustomerDetail(): Observable<CustomerDetailCard[]>{
    return this.http.get(`${environment.apiUrl}`+ 'Customer/{id}').pipe(
      map(resp => resp as CustomerDetailCard[])
    )
  }
}
