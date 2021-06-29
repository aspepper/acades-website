import { Component, NgModule, OnInit, AfterViewInit } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { NgxMaskModule } from 'ngx-mask';
import * as $ from 'jquery';
import 'bootstrap';

import { WatermarkService } from '../shared/services/watermark.service';
import { UploadService } from '../shared/services/upload.services';

@Component({
  selector: 'app-watermark',
  templateUrl: './watermark.component.html',
  styleUrls: ['./watermark.component.css']
})
export class WatermarkComponent implements OnInit {

  public formWatermark: FormGroup;
  public name: FormControl;
  public email: FormControl;
  public text1: FormControl;
  public text2: FormControl;
  public text3: FormControl;
  public password: FormControl;
  public file: FormControl;
  public formSubmitted: Boolean = false;
  public processing: Boolean = false;

  public fileName: string = "";

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
    this.email = new FormControl('', [
      Validators.required,
      Validators.email
    ])
    this.text1 = new FormControl('', [
      Validators.required,
      Validators.minLength(3)
    ]);
    this.text2 = new FormControl('');
    this.text3 = new FormControl('');
    this.password = new FormControl('');
    this.file = new FormControl('', [
      Validators.required
    ])
  }

  public createForm(): void {

    this.createFormControls();

    this.formWatermark = this.formBuilder.group({
      name: this.name,
      email: this.email,
      text1: this.text1,
      text2: this.text2,
      text3: this.text3,
      password: this.password,
      file: this.file
    });
  }

  public uploadDocument(files: any): void {
    if (files && files[0]) {
      console.log(files[0].name);
      this.fileName = files[0].name;
      const reader = new FileReader();
      reader.onload = () => {
        this.formWatermark.get('file').setValue(files[0]);
      };
      reader.readAsDataURL(files[0]);
    }
  }

  public proceed(event): void {
    this.processing = true;

    const formData = new FormData();

    formData.append('Name', this.name.value);
    formData.append('Email', this.email.value);
    formData.append('Text1', this.text1.value);
    formData.append('Text2', this.text2.value);
    formData.append('Text3', this.text3.value);
    formData.append('Password', this.password.value);
    formData.append('FileName', this.file.value.name);
    formData.append("File", this.file.value);

    this.watermarkService.toStamp(formData)
      .subscribe(file => {
        console.log(file);
        const source = `data:application/pdf;base64,${file}`;
        const link = document.createElement("a");
        link.href = source;
        link.download = this.fileName;
        link.click();

        this.processing = false;
      }, error => {
        console.log(error);
        this.processing = false;
      });


  }

}
