import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoreapiComponent } from './coreapi.component';

describe('CoreapiComponent', () => {
  let component: CoreapiComponent;
  let fixture: ComponentFixture<CoreapiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoreapiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoreapiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
