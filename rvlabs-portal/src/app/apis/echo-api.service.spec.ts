import { TestBed } from '@angular/core/testing';

import { EchoApiService } from './echo-api.service';

describe('EchoApiService', () => {
  let service: EchoApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EchoApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
