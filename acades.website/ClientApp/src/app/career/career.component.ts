import { Component, NgModule, OnInit, AfterViewInit } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Person } from '../shared/models/person';
import { User } from '../shared/models/user';
import { Role } from '../shared/models/role';
import { AccountService } from '../shared/services/account.services'
import * as $ from 'jquery';
import 'bootstrap';
import { PersonRole } from '../shared/models/personRole';

function emailDomainValidator(control: FormControl) {
  let email = control.value;
  if (email && email.indexOf("@") != -1) {
    let [_, domain] = email.split("@");
    if (domain !== "codecraft.tv") {
      return {
        emailDomain: {
          parsedDomain: domain
        }
      }
    }
  }
  return null;
}

@Component({
  selector: 'app-career',
  templateUrl: './career.component.html',
  styleUrls: ['./career.component.css']
})
export class CareerComponent implements OnInit, AfterViewInit {

  public form: FormGroup;
  public nome: FormControl;
  public email: FormControl;
  public document: FormControl;
  public birthDate: FormControl;
  public password: FormControl;
  public passwordCompare: FormControl;
  public cargoIds: FormControl;

  public roles: Role[];

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private service: AccountService
  ) {
    this.createFormControls();
    this.createForm();
  }

  ngOnInit() {
    this.getRoles();
  }

  ngAfterViewInit() {
    $('.carousel').carousel();
  }

  public createFormControls(): void {
    this.nome = new FormControl('', [
      Validators.required,
      Validators.minLength(8)
    ]);
    this.email = new FormControl('', [
      Validators.required,
      Validators.pattern("[^ @]*@[^ @]*"),
      emailDomainValidator
    ]);
    this.document = new FormControl('', [
      Validators.required,
      Validators.minLength(11)
    ]);
    this.birthDate = new FormControl('', [
      Validators.required,
      Validators.minLength(10)
    ]);
    this.password = new FormControl('', [
      Validators.required,
      Validators.minLength(3)
    ]);
    this.passwordCompare = new FormControl('', [
      Validators.required,
      Validators.minLength(3)
    ]);
    this.cargoIds = new FormControl('', [
      Validators.required
    ]);
  }

  public createForm(): void {
    this.form = new FormGroup({
      nome: this.nome,
      email: this.email,
      document: this.document,
      birthDate: this.birthDate,
      password: this.password,
      passwordCompare: this.passwordCompare,
      cargoIds: this.cargoIds
    });
  }

  public enrollment(): void {
    if (this.form.invalid) {
      alert('Preencha o formulário corretamente');
      console.log(this.form.errors);
      return;
    }

    let person = new Person();
    person.name = this.nome.value;
    person.document = this.document.value;
    person.birthDate = this.birthDate.value;

    this.cargoIds.value
      .split(',')
      .foreach(e => {
        if (person.roles == null) { person.roles = new Array<PersonRole>() }
        this.roles.forEach(r => {
          if (r.id == parseInt(e)) {
            let pr = new PersonRole();
            pr.roleId = r.id;
            person.roles.push(pr);
          }
        })
      });

    console.log("person :: ");
    console.log(person);


    let user = new User();
    user.email = this.email.value;
    user.password = this.password.value;

    person.user.push(user);

    //this.http.post("/api/carrer/save", person);

  }

  public getRoles(): void {

    this.service.GetListRoles()
      .subscribe(
        data => {
          this.roles = data;
          console.log(this.roles);
        })
  }

}
