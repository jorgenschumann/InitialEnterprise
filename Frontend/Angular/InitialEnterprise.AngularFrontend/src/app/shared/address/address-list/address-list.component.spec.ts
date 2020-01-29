/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddressListComponent } from './address-list.component';

describe('AddressListComponent', () => {
  let component: AddressListComponent;
  let fixture: ComponentFixture<AddressListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddressListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
