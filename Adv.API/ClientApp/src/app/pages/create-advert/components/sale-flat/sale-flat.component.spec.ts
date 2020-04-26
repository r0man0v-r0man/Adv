import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleFlatComponent } from './sale-flat.component';

describe('SaleFlatComponent', () => {
  let component: SaleFlatComponent;
  let fixture: ComponentFixture<SaleFlatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SaleFlatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SaleFlatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
