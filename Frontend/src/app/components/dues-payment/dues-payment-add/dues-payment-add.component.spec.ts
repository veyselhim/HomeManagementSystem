import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DuesPaymentAddComponent } from './dues-payment-add.component';

describe('DuesPaymentAddComponent', () => {
  let component: DuesPaymentAddComponent;
  let fixture: ComponentFixture<DuesPaymentAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DuesPaymentAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DuesPaymentAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
