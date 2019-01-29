import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MailingSingleComponent } from './mailing-single.component';

describe('MailingSingleComponent', () => {
  let component: MailingSingleComponent;
  let fixture: ComponentFixture<MailingSingleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MailingSingleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MailingSingleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
