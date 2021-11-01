import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VagterComponent } from './vagter.component';

describe('VagterComponent', () => {
  let component: VagterComponent;
  let fixture: ComponentFixture<VagterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VagterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VagterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
