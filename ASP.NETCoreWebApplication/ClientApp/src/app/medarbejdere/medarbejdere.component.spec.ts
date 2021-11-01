import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedarbejdereComponent } from './medarbejdere.component';

describe('MedarbejdereComponent', () => {
  let component: MedarbejdereComponent;
  let fixture: ComponentFixture<MedarbejdereComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MedarbejdereComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedarbejdereComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
