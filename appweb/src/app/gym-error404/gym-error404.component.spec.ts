import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymError404Component } from './gym-error404.component';

describe('GymError404Component', () => {
  let component: GymError404Component;
  let fixture: ComponentFixture<GymError404Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymError404Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymError404Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
