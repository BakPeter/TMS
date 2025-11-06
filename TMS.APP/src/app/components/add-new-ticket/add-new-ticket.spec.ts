import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewTicket } from './add-new-ticket';

describe('AddNewTicket', () => {
  let component: AddNewTicket;
  let fixture: ComponentFixture<AddNewTicket>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddNewTicket]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddNewTicket);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
