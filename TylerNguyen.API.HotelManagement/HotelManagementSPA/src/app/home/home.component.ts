import { CustomerCard } from './../shared/models/customerCard';
import { CustomerService } from './../core/services/customer.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  customers!: CustomerCard[];

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    //call API
    this.customerService.getAllCustomers().subscribe(
      m =>{
        this.customers = m;
        console.log('inside home component');
        console.table(this.customers);
      }
    ); //need to subscribe to get data
  }

}
