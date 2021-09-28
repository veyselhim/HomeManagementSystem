import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DuesDetailComponent } from './dues-detail.component';

describe('DuesDetailComponent', () => {
  let component: DuesDetailComponent;
  let fixture: ComponentFixture<DuesDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DuesDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DuesDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
