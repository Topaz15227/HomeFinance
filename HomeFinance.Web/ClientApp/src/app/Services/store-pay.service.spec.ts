import { TestBed } from '@angular/core/testing';

import { StorePayService } from './store-pay.service';

describe('StorePayService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StorePayService = TestBed.get(StorePayService);
    expect(service).toBeTruthy();
  });
});
