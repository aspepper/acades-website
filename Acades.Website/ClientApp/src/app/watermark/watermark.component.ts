import { Component, NgModule, OnInit, AfterViewInit } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { NgxMaskModule } from 'ngx-mask';
import * as $ from 'jquery';
import 'bootstrap';
  import { WatermarkService } from '../shared/services/watermark.service';

@Component({
  selector: 'app-watermark',
  templateUrl: './watermark.component.html',
  styleUrls: ['./watermark.component.css']
})
export class WatermarkComponent implements OnInit {

  public formWatermark: FormGroup;
  public name: FormControl;
  public text1: FormControl;
  public text2: FormControl;
  public text3: FormControl;
  public fileName: FormControl;
  public formSubmitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private watermarkService: WatermarkService
  ) {

    this.createForm();
  }

  ngOnInit() {
  }

  public createFormControls(): void {

    this.name = new FormControl('', [
      Validators.required,
      Validators.minLength(8)
    ]);
    this.text1 = new FormControl('', [
      Validators.required,
      Validators.minLength(3)
    ]);
    this.text2 = new FormControl('');
    this.text3 = new FormControl('');
    this.fileName = new FormControl('', [
      Validators.required
    ])
  }

  public createForm(): void {
      
    this.createFormControls();

    this.formWatermark = this.formBuilder.group({
      name: this.name,
      text1: this.text1,
      text2: this.text2,
      text3: this.text3,
      fileName: this.fileName
    });
  }

  public download(event): void {
    this.watermarkService.upload(this.formWatermark)
      .subscribe(file => {
              
      }, error => {
          console.log(error);
      });
  }

}
