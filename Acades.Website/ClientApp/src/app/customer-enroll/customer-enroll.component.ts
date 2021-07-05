import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-enroll',
  templateUrl: './customer-enroll.component.html',
  styleUrls: ['./customer-enroll.component.css']
})
export class CustomerEnrollComponent implements OnInit {

  public processing: boolean = false; 

  constructor() { }

  ngOnInit() {
  }

}
