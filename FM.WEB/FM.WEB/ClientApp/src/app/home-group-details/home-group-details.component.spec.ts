import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeGroupDetailsComponent } from './home-group-details.component';

describe('HomeGroupDetailsComponent', () => {
  let component: HomeGroupDetailsComponent;
  let fixture: ComponentFixture<HomeGroupDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeGroupDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeGroupDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
