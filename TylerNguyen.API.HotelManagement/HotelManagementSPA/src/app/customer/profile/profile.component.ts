import { CustomerDetailService } from './../../core/services/customer-detail.service';
import { CustomerDetail } from './../../shared/models/customerDetailCard';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  customerdetail!: CustomerDetail;
  id!: number;
  constructor(private customerdetailService : CustomerDetailService,  private currentRouter: ActivatedRoute) { }

  ngOnInit(): void {
    this.currentRouter.params.subscribe(
      i =>{
        this.id = i['id'];
      });
      console.log(this.id);
    this.customerdetailService.getCustomerDetail(this.id).subscribe(
      m => {
        this.customerdetail = m;
        console.log(this.customerdetail);
      }
    )
  }

}
