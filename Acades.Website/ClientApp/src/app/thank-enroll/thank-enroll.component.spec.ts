import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThankEnrollComponent } from './thank-enroll.component';

describe('ThankEnrollComponent', () => {
  let component: ThankEnrollComponent;
  let fixture: ComponentFixture<ThankEnrollComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThankEnrollComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThankEnrollComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
