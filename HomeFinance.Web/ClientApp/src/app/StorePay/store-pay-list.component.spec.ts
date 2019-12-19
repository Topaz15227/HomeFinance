import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StorePayListComponent } from './store-pay-list.component';

describe('StorePayListComponent', () => {
  let component: StorePayListComponent;
  let fixture: ComponentFixture<StorePayListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StorePayListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StorePayListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
