import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, PatternValidator, FormArray, FormBuilder } from '@angular/forms';

@Component({
  template: ''
})
export class FormBaseComponent {

  public categoryCNHlist: string[] = ["Categoria A", "Categoria B", "Categoria C", "Categoria D", "Categoria E"];

  constructor() { }

  public isFieldValid(form: FormGroup, field: string) {
    const valid = !form.controls[field].valid && form.controls[field].touched;
    return valid;
  }

  protected displayFieldCss(form: FormGroup, field: string) {
    return {
      'has-error': this.isFieldValid(form, field),
      'has-feedback': this.isFieldValid(form, field)
    };
  }

  public validateAllFormFields(form: FormGroup): void {
    Object.keys(form.controls).forEach(field => {
      const control = form.controls[field];
      if (control instanceof FormControl) {
        control.markAsTouched({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      }

    });

  }

}