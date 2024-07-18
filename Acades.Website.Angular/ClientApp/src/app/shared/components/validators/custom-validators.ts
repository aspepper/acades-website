import { ValidatorFn, ValidationErrors, FormGroup, AbstractControl } from "@angular/forms";
import * as moment from 'moment';


export class CustomValidators {

  static DateMinimum(date: string): ValidatorFn {

    return (control: AbstractControl): ValidationErrors | null => {

      const FORMAT_DATE: string = "DD/MM/YYYY";
      if (!control.value) {
        return null;
      }

      const controlDate = moment(control.value, FORMAT_DATE);

      if (!controlDate.isValid()) {
        return {
          'date-minimum':
          {
            'date-minimum': 'invalid date',
            'actuel': control.value
          }
        };
      }

      const validationDate = moment(date, FORMAT_DATE);

      return controlDate.isAfter(validationDate) ? null : {
        'date-minimum':
        {
          'date-minimum': validationDate.format(FORMAT_DATE),
          'actuel': controlDate.format(FORMAT_DATE)
        }
      };

    };
  }

  static PatternValidator(regex: RegExp, error: ValidationErrors): ValidatorFn {

    return (control: AbstractControl): { [key: string]: any } => {

      if (!control.value) {
        return null;
      }

      const valid = regex.test(control.value);

      return valid ? null : error;

    };

  }

  static PasswordConfirming(): ValidatorFn {

    return (formGroup: FormGroup): ValidationErrors => {

      const password: AbstractControl = formGroup.controls['password'];
      const confirmPassword: AbstractControl = formGroup.controls['confpass'];

      if (!password.touched || !confirmPassword.touched) {
        password.setErrors(null);
        confirmPassword.setErrors(null);
        return;
      }

      if (password.value !== confirmPassword.value) {
        password.setErrors({ 'passwordNotMatch': true });
        confirmPassword.setErrors({ 'passwordNotMatch': true });
      }
      else {
        password.setErrors(null);
        confirmPassword.setErrors(null);
      }

      return;

    };

  }

}
