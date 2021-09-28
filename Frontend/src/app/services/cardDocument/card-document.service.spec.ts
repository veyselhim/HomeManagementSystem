import { TestBed } from '@angular/core/testing';

import { CardDocumentService } from './card-document.service';

describe('CardDocumentService', () => {
  let service: CardDocumentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CardDocumentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
