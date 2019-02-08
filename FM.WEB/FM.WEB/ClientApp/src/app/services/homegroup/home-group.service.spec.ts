import { TestBed } from '@angular/core/testing';

import { HomeGroupService } from './home-group.service';

describe('HomeGroupService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HomeGroupService = TestBed.get(HomeGroupService);
    expect(service).toBeTruthy();
  });
});
