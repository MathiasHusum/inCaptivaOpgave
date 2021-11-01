import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedarbejderCreateComponent } from './medarbejder-create.component';

describe('MedarbejderCreateComponent', () => {
  let component: MedarbejderCreateComponent;
  let fixture: ComponentFixture<MedarbejderCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MedarbejderCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedarbejderCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
