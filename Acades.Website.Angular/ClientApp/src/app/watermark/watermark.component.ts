import { Component, NgModule, OnInit, AfterViewInit } from '@angular/core';
import { FormControl, FormGroup, Validators, PatternValidator, FormArray, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { NgxMaskModule } from 'ngx-mask';
import * as $ from 'jquery';
import 'bootstrap';
import { FormBaseComponent } from '../form-base.component';
import { WatermarkService } from '../shared/services/watermark.service';
import { UploadService } from '../shared/services/upload.services';
import { CustomValidators } from '../shared/components/validators/custom-validators';

@Component({
  selector: 'app-watermark',
  templateUrl: './watermark.component.html',
  styleUrls: ['./watermark.component.css']
})
export class WatermarkComponent extends FormBaseComponent implements OnInit {

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
  public hide: boolean = true;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private watermarkService: WatermarkService
  ) {
    super();
  }

  ngOnInit() {
    this.createForm();
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
    
  public proceed(event): void {
    this.processing = true;

    const formData = new FormData();

    console.log(this.file);

    const FileInput = this.formWatermark.get('file').value;

    console.log(FileInput.files[0]);

    this.fileName = FileInput.files[0].name;

    formData.append('Name', this.name.value);
    formData.append('Email', this.email.value);
    formData.append('Text1', this.text1.value);
    formData.append('Text2', this.text2.value);
    formData.append('Text3', this.text3.value);
    formData.append('Password', this.password.value);
    formData.append('FileName', this.file.value.name);
    formData.append("File", FileInput.files[0]);

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
