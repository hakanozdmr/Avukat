import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AvukatSidebarComponent } from './avukat-sidebar.component';

describe('AvukatSidebarComponent', () => {
  let component: AvukatSidebarComponent;
  let fixture: ComponentFixture<AvukatSidebarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AvukatSidebarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AvukatSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
