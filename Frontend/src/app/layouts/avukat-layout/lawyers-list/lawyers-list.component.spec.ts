import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LawyersListComponent } from './lawyers-list.component';

describe('LawyersListComponent', () => {
  let component: LawyersListComponent;
  let fixture: ComponentFixture<LawyersListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LawyersListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LawyersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
