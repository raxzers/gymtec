import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GymClienteRegitroComponent } from './gym-cliente-regitro.component';

describe('GymClienteRegitroComponent', () => {
  let component: GymClienteRegitroComponent;
  let fixture: ComponentFixture<GymClienteRegitroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GymClienteRegitroComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GymClienteRegitroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
