import { TestBed, inject } from '@angular/core/testing';

import { DocumentValidatorService } from './document-validator.service';

describe('DocumentValidatorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DocumentValidatorService]
    });
  });

  it('should be created', inject([DocumentValidatorService], (service: DocumentValidatorService) => {
    expect(service).toBeTruthy();
  }));
});
