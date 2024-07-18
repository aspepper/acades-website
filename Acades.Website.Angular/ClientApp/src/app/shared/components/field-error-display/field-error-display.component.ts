import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-field-error-display',
  templateUrl: './field-error-display.component.html',
  styleUrls: ['./field-error-display.component.css']
})
export class FieldErrorDisplayComponent implements OnInit, OnChanges {
  @Input() errorMsg: string;
  @Input() displayError: boolean;

  ngOnInit() {

  }

  ngOnChanges(changes: SimpleChanges) {
  }

}

