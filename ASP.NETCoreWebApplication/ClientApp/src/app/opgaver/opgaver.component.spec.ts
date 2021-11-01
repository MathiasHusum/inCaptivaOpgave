import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpgaverComponent } from './opgaver.component';

describe('OpgaverComponent', () => {
  let component: OpgaverComponent;
  let fixture: ComponentFixture<OpgaverComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpgaverComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpgaverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
