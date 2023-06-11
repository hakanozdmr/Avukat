import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvukatLayoutComponent } from './avukat-layout.component';

describe('AvukatLayoutComponent', () => {
  let component: AvukatLayoutComponent;
  let fixture: ComponentFixture<AvukatLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvukatLayoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AvukatLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
