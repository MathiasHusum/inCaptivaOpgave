import { TestBed } from '@angular/core/testing';

import { MedarbejderServiceService } from './medarbejder-service.service';

describe('MedarbejderServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MedarbejderServiceService = TestBed.get(MedarbejderServiceService);
    expect(service).toBeTruthy();
  });
});
