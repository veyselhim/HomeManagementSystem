import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApartmentUpdateComponent } from './apartment-update.component';

describe('ApartmentUpdateComponent', () => {
  let component: ApartmentUpdateComponent;
  let fixture: ComponentFixture<ApartmentUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApartmentUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApartmentUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
