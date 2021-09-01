import { CustomerDetailService } from './../../core/services/customer-detail.service';
import { CustomerDetailCard } from './../../shared/models/customerDetailCard';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  customerdetail!: CustomerDetailCard[];
  constructor(private customerdetailService : CustomerDetailService) { }

  ngOnInit(): void {
    this.customerdetailService.getCustomerDetail().subscribe(
      m => {
        this.customerdetail = m;
        console.log(this.customerdetail);
      }
    )
  }

}
