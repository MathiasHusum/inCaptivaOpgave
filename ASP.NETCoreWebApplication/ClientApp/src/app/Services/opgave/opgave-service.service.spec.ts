import { TestBed } from '@angular/core/testing';

import { OpgaveServiceService } from './opgave-service.service';

describe('OpgaveServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OpgaveServiceService = TestBed.get(OpgaveServiceService);
    expect(service).toBeTruthy();
  });
});
