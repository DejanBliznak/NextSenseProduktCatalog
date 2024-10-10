import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportByProductAndManufacturerComponent } from './report-by-product-and-manufacturer.component';

describe('ReportByProductAndManufacturerComponent', () => {
  let component: ReportByProductAndManufacturerComponent;
  let fixture: ComponentFixture<ReportByProductAndManufacturerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportByProductAndManufacturerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportByProductAndManufacturerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
