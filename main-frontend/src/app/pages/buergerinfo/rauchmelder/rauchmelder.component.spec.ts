import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RauchmelderComponent } from './rauchmelder.component';

describe('RauchmelderComponent', () => {
  let component: RauchmelderComponent;
  let fixture: ComponentFixture<RauchmelderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RauchmelderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RauchmelderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
