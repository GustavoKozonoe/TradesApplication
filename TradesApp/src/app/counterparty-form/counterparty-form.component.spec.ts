import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CounterpartyFormComponent } from './counterparty-form.component';

describe('CounterpartyFormComponent', () => {
  let component: CounterpartyFormComponent;
  let fixture: ComponentFixture<CounterpartyFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CounterpartyFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CounterpartyFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
