import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnergyReadingsComponent } from './energy-readings.component';

describe('EnergyReadingsComponent', () => {
  let component: EnergyReadingsComponent;
  let fixture: ComponentFixture<EnergyReadingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnergyReadingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnergyReadingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
