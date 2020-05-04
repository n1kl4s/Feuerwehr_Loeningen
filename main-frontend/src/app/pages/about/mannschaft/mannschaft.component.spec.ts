import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MannschaftComponent } from './mannschaft.component';

describe('MannschaftComponent', () => {
  let component: MannschaftComponent;
  let fixture: ComponentFixture<MannschaftComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MannschaftComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MannschaftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
