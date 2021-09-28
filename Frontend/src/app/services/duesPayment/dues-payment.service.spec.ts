import { TestBed } from '@angular/core/testing';

import { DuesPaymentService } from './dues-payment.service';

describe('DuesPaymentService', () => {
  let service: DuesPaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DuesPaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
