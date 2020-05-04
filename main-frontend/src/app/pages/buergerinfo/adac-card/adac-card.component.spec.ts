import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdacCardComponent } from './adac-card.component';

describe('AdacCardComponent', () => {
  let component: AdacCardComponent;
  let fixture: ComponentFixture<AdacCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdacCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdacCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
