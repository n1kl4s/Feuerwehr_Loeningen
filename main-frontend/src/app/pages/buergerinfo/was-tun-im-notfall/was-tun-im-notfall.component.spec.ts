import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WasTunImNotfallComponent } from './was-tun-im-notfall.component';

describe('WasTunImNotfallComponent', () => {
  let component: WasTunImNotfallComponent;
  let fixture: ComponentFixture<WasTunImNotfallComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WasTunImNotfallComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WasTunImNotfallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
