import { CustomerCard } from './../../models/customerCard';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-card',
  templateUrl: './customer-card.component.html',
  styleUrls: ['./customer-card.component.css']
})
export class CustomerCardComponent implements OnInit {

  @Input() customer!: CustomerCard; //passing single data
  constructor() { }

  ngOnInit(): void {
  }

}
