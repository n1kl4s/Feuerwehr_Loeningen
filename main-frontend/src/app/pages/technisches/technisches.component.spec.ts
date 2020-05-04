import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TechnischesComponent } from './technisches.component';

describe('TechnischesComponent', () => {
  let component: TechnischesComponent;
  let fixture: ComponentFixture<TechnischesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TechnischesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TechnischesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
