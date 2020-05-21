import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EzauthEchoApiComponent } from './ezauth-echo-api.component';

describe('EzauthEchoApiComponent', () => {
  let component: EzauthEchoApiComponent;
  let fixture: ComponentFixture<EzauthEchoApiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EzauthEchoApiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EzauthEchoApiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
