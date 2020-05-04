import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoerdervereinComponent } from './foerderverein.component';

describe('FoerdervereinComponent', () => {
  let component: FoerdervereinComponent;
  let fixture: ComponentFixture<FoerdervereinComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoerdervereinComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoerdervereinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
