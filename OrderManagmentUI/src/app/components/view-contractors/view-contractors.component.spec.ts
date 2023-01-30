import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewContractorsComponent } from './view-contractors.component';

describe('ViewContractorsComponent', () => {
  let component: ViewContractorsComponent;
  let fixture: ComponentFixture<ViewContractorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewContractorsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewContractorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
