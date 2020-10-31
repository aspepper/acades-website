import { Component, NgModule, OnInit, AfterViewInit } from '@angular/core';
import * as $ from 'jquery';
import 'bootstrap';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit, AfterViewInit {


  ngOnInit() { }

  ngAfterViewInit() {
    $('.carousel').carousel();
  }

}
