import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateHouseSaleComponent } from './create-house-sale.component';

describe('CreateHouseSaleComponent', () => {
  let component: CreateHouseSaleComponent;
  let fixture: ComponentFixture<CreateHouseSaleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateHouseSaleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateHouseSaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
