import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillPaymentAddComponent } from './bill-payment-add.component';

describe('BillPaymentAddComponent', () => {
  let component: BillPaymentAddComponent;
  let fixture: ComponentFixture<BillPaymentAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BillPaymentAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BillPaymentAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
