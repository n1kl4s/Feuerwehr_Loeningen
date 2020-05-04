import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NeubauComponent } from './neubau.component';

describe('NeubauComponent', () => {
  let component: NeubauComponent;
  let fixture: ComponentFixture<NeubauComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NeubauComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NeubauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
