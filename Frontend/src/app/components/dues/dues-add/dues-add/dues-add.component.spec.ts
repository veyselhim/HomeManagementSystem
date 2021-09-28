import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DuesAddComponent } from './dues-add.component';

describe('DuesAddComponent', () => {
  let component: DuesAddComponent;
  let fixture: ComponentFixture<DuesAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DuesAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DuesAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
