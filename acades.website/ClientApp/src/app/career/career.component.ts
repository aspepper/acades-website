import { Component, NgModule, OnInit, AfterViewInit } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { NgxMaskModule } from 'ngx-mask'
import * as $ from 'jquery';
import 'bootstrap';
import { Person } from '../shared/models/person';
import { User } from '../shared/models/user';
import { Role } from '../shared/models/role';
import { AccountService } from '../shared/services/account.services';
import { PersonRole } from '../shared/models/personRole';
import { DateValidator } from '../shared/services/form-validators.services';

@Component({
  selector: 'app-career',
  templateUrl: './career.component.html',
  styleUrls: ['./career.component.css']
})
export class CareerComponent implements OnInit, AfterViewInit {

  public formCareer: FormGroup;
  public name: FormControl;
  public email: FormControl;
  public document: FormControl;
  public birthDate: FormControl;
  public password: FormControl;
  public passwordCompare: FormControl;
  public roleIds: FormControl;

  public formSubmitted = false;

  public roles: Role[];

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private service: AccountService
  ) {

    this.createForm();
  }

  ngOnInit() {
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
      Validators.minLength(8)
    ]);
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
  }

  public createForm(): void {

    this.createFormControls();

    this.formCareer = this.formBuilder.group({
      name: this.name,
      email: this.email,
      document: this.document,
      birthDate: this.birthDate,
      password: this.password,
      passwordCompare: this.passwordCompare,
      roleIds: this.roleIds
    });
  }

  public getRoles(): void {

    this.service
      .GetListRoles()
      .subscribe(
        data => {
          this.roles = data;
          console.log(this.roles);
        })
  }

  public clearForm(): void {
    this.createForm();
  }

  public enrollment(event): void {
    event.preventDefault();
    this.formSubmitted = true;

    console.log(this.formCareer.value);

    const birtYear = parseInt(this.birthDate.value.substr(4, 4));
    const birtMonth = parseInt(this.birthDate.value.substr(2, 2)) - 1;
    const birtDate = parseInt(this.birthDate.value.substr(0, 2));

    let person = new Person();
    person.name = this.name.value;
    person.document = this.document.value;
    person.birthDate = new Date(birtYear, birtMonth, birtDate);

    console.log(this.roleIds.value);
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

    console.log("person :: ");
    console.log(person);

    let user = new User();
    user.email = this.email.value;
    user.password = this.password.value;

    console.log(user);

    if (person.users == null) { person.users = new Array<User>(); }
    person.users.push(user);

    this.service
      .SaveCareer(person)
      .subscribe(data => {
        alert("Cadastro realizado com sucesso.");
        this.clearForm();
      }, (err) => {
          console.log(err);
          alert("Ocorreu um erro no cadastro. Tente mais tarde.");
      });

  }

}
