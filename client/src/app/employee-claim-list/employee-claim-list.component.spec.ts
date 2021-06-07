import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeClaimListComponent } from './employee-claim-list.component';

describe('EmployeeClaimListComponent', () => {
  let component: EmployeeClaimListComponent;
  let fixture: ComponentFixture<EmployeeClaimListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeClaimListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeClaimListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
