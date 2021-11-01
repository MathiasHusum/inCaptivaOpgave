import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpgaveCreateComponent } from './opgave-create.component';

describe('OpgaveCreateComponent', () => {
  let component: OpgaveCreateComponent;
  let fixture: ComponentFixture<OpgaveCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpgaveCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpgaveCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
