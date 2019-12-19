import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StorePaysByClosingComponent } from './store-pays-by-closing.component';

describe('StorePaysByClosingComponent', () => {
  let component: StorePaysByClosingComponent;
  let fixture: ComponentFixture<StorePaysByClosingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StorePaysByClosingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StorePaysByClosingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
