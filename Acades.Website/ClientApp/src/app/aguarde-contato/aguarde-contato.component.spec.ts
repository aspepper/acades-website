import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AguardeContatoComponent } from './aguarde-contato.component';

describe('AguardeContatoComponent', () => {
  let component: AguardeContatoComponent;
  let fixture: ComponentFixture<AguardeContatoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AguardeContatoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AguardeContatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
