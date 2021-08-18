import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScatterAreaChartComponent } from './scatter-area-chart.component';

describe('ScatterAreaChartComponent', () => {
  let component: ScatterAreaChartComponent;
  let fixture: ComponentFixture<ScatterAreaChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScatterAreaChartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ScatterAreaChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
