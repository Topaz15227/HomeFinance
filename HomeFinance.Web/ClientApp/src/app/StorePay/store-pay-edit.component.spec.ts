import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StorePayEditComponent } from './store-pay-edit.component';

describe('StorePayEditComponent', () => {
  let component: StorePayEditComponent;
  let fixture: ComponentFixture<StorePayEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StorePayEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StorePayEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
