import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MostexpensiveComponent } from './mostexpensive.component';

describe('MostexpensiveComponent', () => {
  let component: MostexpensiveComponent;
  let fixture: ComponentFixture<MostexpensiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MostexpensiveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MostexpensiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
