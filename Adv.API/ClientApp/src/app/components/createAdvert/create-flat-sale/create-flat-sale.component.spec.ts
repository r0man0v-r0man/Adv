import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFlatSaleComponent } from './create-flat-sale.component';

describe('CreateFlatSaleComponent', () => {
  let component: CreateFlatSaleComponent;
  let fixture: ComponentFixture<CreateFlatSaleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateFlatSaleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateFlatSaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
