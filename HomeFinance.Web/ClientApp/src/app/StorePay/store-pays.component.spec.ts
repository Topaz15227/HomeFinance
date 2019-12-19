import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StorePaysComponent } from './store-pays.component';

describe('StorePaysComponent', () => {
  let component: StorePaysComponent;
  let fixture: ComponentFixture<StorePaysComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StorePaysComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StorePaysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
