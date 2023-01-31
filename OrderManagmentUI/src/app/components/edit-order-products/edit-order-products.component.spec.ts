import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditOrderProductsComponent } from './edit-order-products.component';

describe('EditOrderProductsComponent', () => {
  let component: EditOrderProductsComponent;
  let fixture: ComponentFixture<EditOrderProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditOrderProductsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditOrderProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
