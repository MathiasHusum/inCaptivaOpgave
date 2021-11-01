import { TestBed } from '@angular/core/testing';

import { VagtServiceService } from './vagt-service.service';

describe('VagtServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VagtServiceService = TestBed.get(VagtServiceService);
    expect(service).toBeTruthy();
  });
});
