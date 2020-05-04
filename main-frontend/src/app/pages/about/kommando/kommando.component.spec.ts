import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KommandoComponent } from './kommando.component';

describe('KommandoComponent', () => {
  let component: KommandoComponent;
  let fixture: ComponentFixture<KommandoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KommandoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KommandoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
