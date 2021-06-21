import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymClienteLoginComponent } from './gym-cliente-login.component';

describe('GymClienteLoginComponent', () => {
  let component: GymClienteLoginComponent;
  let fixture: ComponentFixture<GymClienteLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymClienteLoginComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymClienteLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
