import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetbillComponent } from './getbill.component';

describe('GetbillComponent', () => {
  let component: GetbillComponent;
  let fixture: ComponentFixture<GetbillComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetbillComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetbillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
