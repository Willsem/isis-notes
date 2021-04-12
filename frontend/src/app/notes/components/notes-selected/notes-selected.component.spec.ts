import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotesSelectedComponent } from './notes-selected.component';

describe('NotesSelectedComponent', () => {
  let component: NotesSelectedComponent;
  let fixture: ComponentFixture<NotesSelectedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotesSelectedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotesSelectedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
