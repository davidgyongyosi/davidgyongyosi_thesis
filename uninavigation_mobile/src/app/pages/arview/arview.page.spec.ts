import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ARViewPage } from './arview.page';

describe('ARViewPage', () => {
  let component: ARViewPage;
  let fixture: ComponentFixture<ARViewPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(ARViewPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
