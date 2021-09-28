import { TestBed } from '@angular/core/testing';

import { BillPaymentService } from './bill-payment.service';

describe('BillPaymentService', () => {
  let service: BillPaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BillPaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
