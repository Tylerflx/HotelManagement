import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoombyTypeComponent } from './roomby-type.component';

describe('RoombyTypeComponent', () => {
  let component: RoombyTypeComponent;
  let fixture: ComponentFixture<RoombyTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoombyTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoombyTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
