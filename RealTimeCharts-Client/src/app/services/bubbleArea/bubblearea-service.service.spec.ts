import { TestBed } from '@angular/core/testing';

import { BubbleareaService } from './bubblearea-service.service';

describe('BubbleareaServiceService', () => {
  let service: BubbleareaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BubbleareaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
