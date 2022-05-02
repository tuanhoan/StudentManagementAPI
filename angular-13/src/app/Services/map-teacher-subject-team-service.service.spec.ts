import { TestBed } from '@angular/core/testing';

import { MapTeacherSubjectTeamServiceService } from './map-teacher-subject-team-service.service';

describe('MapTeacherSubjectTeamServiceService', () => {
  let service: MapTeacherSubjectTeamServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MapTeacherSubjectTeamServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
