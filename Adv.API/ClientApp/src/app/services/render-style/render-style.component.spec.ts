import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RenderStyleComponent } from './render-style.component';

describe('RenderStyleComponent', () => {
  let component: RenderStyleComponent;
  let fixture: ComponentFixture<RenderStyleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RenderStyleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RenderStyleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
