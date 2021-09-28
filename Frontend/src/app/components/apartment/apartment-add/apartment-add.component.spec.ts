import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApartmentAddComponent } from './apartment-add.component';

describe('ApartmentAddComponent', () => {
  let component: ApartmentAddComponent;
  let fixture: ComponentFixture<ApartmentAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApartmentAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApartmentAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
