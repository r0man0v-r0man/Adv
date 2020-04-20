import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateHouseRentComponent } from './create-house-rent.component';

describe('CreateHouseRentComponent', () => {
  let component: CreateHouseRentComponent;
  let fixture: ComponentFixture<CreateHouseRentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateHouseRentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateHouseRentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
