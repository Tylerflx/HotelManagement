import { CustomerCard } from './../../shared/models/customerCard';

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  //should have all the methods that deal with Customers, getbyId, Details
  //HTTPClient to make AJAX request
  //XML HTTPRequest => use behind the scence

  constructor(private http: HttpClient) { }
  getAllCustomers(): Observable<CustomerCard[]>{

    //http://localhost:12555/api/Customer
    //create model based on json data
    //observable are lazy only when subscribe observable will get the data
    return this.http.get(`${environment.apiUrl}`+ 'Customer').pipe(
      map(resp => resp as CustomerCard[])
    )
  }
}
