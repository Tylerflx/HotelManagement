import { CustomerDetail } from './../../shared/models/customerDetailCard';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerDetailService {

  constructor(private http: HttpClient) { }
  getCustomerDetail(id : number): Observable<CustomerDetail>{
    return this.http.get(`${environment.apiUrl}`+ 'Customer/' + id.toString()).pipe(
      map(resp => resp as CustomerDetail)
    )
  }
}
