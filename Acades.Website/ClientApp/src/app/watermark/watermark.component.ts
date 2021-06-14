import { Component, OnInit } from '@angular/core';
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
    event.preventDefault();
    this.formSubmitted = true;

    let user = new User();
    user.email = this.email.value;
    user.password = this.password.value;

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

            });
        }

        alert("Cadastro realizado com sucesso.");
        this.clearForm();
      }, (err) => {
        console.log(err);
        alert("Ocorreu um erro no cadastro. Tente mais tarde.");
      });

  }

}
