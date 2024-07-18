import { Component, NgModule, OnInit, AfterViewInit } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { NgxMaskModule } from 'ngx-mask';
import * as $ from 'jquery';
import 'bootstrap';
import { FormBaseComponent } from '../form-base.component';
import { Person } from '../shared/models/person';
import { User } from '../shared/models/user';
import { Role } from '../shared/models/role';
import { File } from '../shared/models/file';
import { FileType, FileTypes } from '../shared/models/file-type';
import { AccountService } from '../shared/services/account.services';
import { PersonRole } from '../shared/models/personRole';
import { DateValidator } from '../shared/services/form-validators.services';
import { UploadService } from '../shared/services/upload.services';

@Component({
  selector: 'app-career',
  templateUrl: './career.component.html',
  styleUrls: ['./career.component.css']
})
export class CareerComponent extends FormBaseComponent implements OnInit, AfterViewInit {

  public formCareer: FormGroup;
  public name: FormControl;
  public email: FormControl;
  public document: FormControl;
  public birthDate: FormControl;
  public password: FormControl;
  public passwordCompare: FormControl;
  public roleIds: FormControl;
  public resumeFileName: FormControl;
  public birthDatePicker: FormControl;
  public hide: boolean = true;

  public filename = '';

  public formSubmitted = false;

  public roles: Role[];

  public resume: File;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private service: AccountService,
    private uploadService: UploadService
  ) {
    super();
  }

  ngOnInit() {
    this.createForm();
    this.getRoles();
  }

  ngAfterViewInit() {
    $('.carousel').carousel();
  }

  public createFormControls(): void {

    this.name = new FormControl('', [
      Validators.required,
      Validators.minLength(8)
    ]);
    this.email = new FormControl('', [
      Validators.required,
      Validators.email
    ]);
    this.document = new FormControl('', [
      Validators.required,
      Validators.minLength(11)
    ]);
    this.birthDate = new FormControl('', [
      Validators.required,
      Validators.minLength(10)
    ]);
    this.birthDatePicker = new FormControl();
    this.password = new FormControl('', [
      Validators.required,
      Validators.minLength(3)
    ]);
    this.passwordCompare = new FormControl('', [
      Validators.required,
      Validators.minLength(3)
    ]);
    this.roleIds = new FormControl('', [
      Validators.required
    ]);
    this.resumeFileName = new FormControl('', [
      Validators.required
    ])

  }

  public fillbirthdate(value): void {
    this.birthDate.setValue(value);
    const birtYear = parseInt(this.birthDate.value.substr(6, 4));
    const birtMonth = parseInt(this.birthDate.value.substr(3, 2)) - 1;
    const birtDate = parseInt(this.birthDate.value.substr(0, 2));
    this.birthDatePicker.setValue(new Date(birtYear, birtMonth, birtDate));
  }

  public createForm(): void {

    this.createFormControls();

    this.formCareer = this.formBuilder.group({
      name: this.name,
      email: this.email,
      document: this.document,
      birthDate: this.birthDate,
      birthDatePicker: this.birthDatePicker,
      password: this.password,
      passwordCompare: this.passwordCompare,
      roleIds: this.roleIds,
      resumeFileName: this.resumeFileName
    });
  }

  public getRoles(): void {

    this.service.GetListRoles()
      .subscribe(
        data => {
          this.roles = data;
          console.log(this.roles);
        },
        error => {
          console.log(error);
        })
  }

  public clearForm(): void {
    this.createForm();
  }

  public save(files): void {
    const formData = new FormData();

    formData.append(files[0].name, files[0]);
    this.filename = files[0].name;

    console.log(files[0]);

    this.uploadService
      .upload(formData)
      .subscribe(fileUploaded => {

        this.resume = new File();
        this.resume.fileExtension = fileUploaded.extension;
        this.resume.fileName = fileUploaded.fileName;
        this.resume.fileNameOriginal = fileUploaded.fileNameOriginal;
        this.resume.path = fileUploaded.absoluteUri;
        this.resume.fileTypeId = FileTypes.Curriculo;
        this.resume.insertDate = new Date();
        this.resume.insertUser = 1;
        this.resume.updateDate = new Date();
        this.resume.updateUser = 1;

        this.uploadService
          .uploadResume(this.resume)
          .subscribe(id => {
            this.resume.id = id;

            this.resumeFileName.setValue(this.resume.fileNameOriginal);

            console.log(this.resume);

          }, (error) => { console.log(error); });


      })

  }

  public enrollment(event): void {

    try {
      const files = this.formCareer.get('resumeFileName').value.files;
      if (files.length > 0) { this.save(files); }

      event.preventDefault();
      this.formSubmitted = true;

      console.log(this.formCareer.value);

      const birtYear = parseInt(this.birthDate.value.substr(6, 4));
      const birtMonth = parseInt(this.birthDate.value.substr(3, 2)) - 1;
      const birtDate = parseInt(this.birthDate.value.substr(0, 2));

      let person = new Person();
      person.name = this.name.value;
      person.document = this.document.value;
      person.birthDate = new Date(birtYear, birtMonth, birtDate);


      console.log("this.roleIds ::");
      console.log(this.roleIds);

      this.roleIds
        .value
        .forEach(e => {
          if (person.roles == null) { person.roles = new Array<PersonRole>() }
          this.roles.forEach(r => {
            if (r.id == parseInt(e)) {
              let pr = new PersonRole();
              pr.roleId = r.id;
              person.roles.push(pr);
            }
          })
        });

      let user = new User();
      user.userName = this.document.value;
      user.email = this.email.value;
      user.password = this.password.value;

      console.log("user ::");
      console.log(user);

      if (person.users == null) { person.users = new Array<User>(); }
      person.users.push(user);

      console.log("person :: ");
      console.log(person);

      this.service
        .SaveCareer(person)
        .subscribe(personId => {

          if (this.resume != null) {
            this.resume.personId = personId;

            this.uploadService
              .uploadResume(this.resume)
              .subscribe(id => {

                console.log(this.resume);

              }, (error) => { console.log(error); });
          }

          alert("Cadastro realizado com sucesso.");
          this.clearForm();

        }, (err) => {
          console.log(err);
          alert("Ocorreu um erro no cadastro. Tente mais tarde.");
        });

    }
    catch (e) {
      console.log(e);
    }

  }

}
