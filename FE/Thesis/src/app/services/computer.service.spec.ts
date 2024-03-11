import { TestBed } from '@angular/core/testing';

import { ComputerService } from './computer.service';

describe('ComputerServic', () => {
  let service: ComputerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ComputerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
