import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymAdminEmpleadosGestComponent } from './gym-admin-empleados-gest.component';

describe('GymAdminEmpleadosGestComponent', () => {
  let component: GymAdminEmpleadosGestComponent;
  let fixture: ComponentFixture<GymAdminEmpleadosGestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymAdminEmpleadosGestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymAdminEmpleadosGestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
