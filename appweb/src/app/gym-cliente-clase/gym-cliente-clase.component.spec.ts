import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymClienteClaseComponent } from './gym-cliente-clase.component';

describe('GymClienteClaseComponent', () => {
  let component: GymClienteClaseComponent;
  let fixture: ComponentFixture<GymClienteClaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymClienteClaseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymClienteClaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
