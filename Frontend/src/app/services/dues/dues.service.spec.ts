import { TestBed } from '@angular/core/testing';

import { DuesService } from './dues.service';

describe('DuesService', () => {
  let service: DuesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DuesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
