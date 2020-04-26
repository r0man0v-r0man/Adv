import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleHouseComponent } from './sale-house.component';

describe('SaleHouseComponent', () => {
  let component: SaleHouseComponent;
  let fixture: ComponentFixture<SaleHouseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SaleHouseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SaleHouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
