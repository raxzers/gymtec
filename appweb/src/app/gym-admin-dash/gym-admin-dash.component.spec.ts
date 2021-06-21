import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymAdminDashComponent } from './gym-admin-dash.component';

describe('GymAdminDashComponent', () => {
  let component: GymAdminDashComponent;
  let fixture: ComponentFixture<GymAdminDashComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymAdminDashComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymAdminDashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
