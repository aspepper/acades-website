import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerEnrollComponent } from './customer-enroll.component';

describe('CustomerEnrollComponent', () => {
  let component: CustomerEnrollComponent;
  let fixture: ComponentFixture<CustomerEnrollComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomerEnrollComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerEnrollComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
