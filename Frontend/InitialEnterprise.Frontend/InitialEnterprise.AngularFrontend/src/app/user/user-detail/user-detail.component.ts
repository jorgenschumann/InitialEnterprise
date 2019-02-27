import { Component, OnInit, Input, Injectable } from '@angular/core';
import { UserDto } from 'src/app/models/user.types';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from './../shared/user.service';
import {NgbDateAdapter, NgbDateStruct, NgbDateNativeAdapter} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})

@Injectable({ providedIn: 'root' })
export class UserDetailComponent implements OnInit {
  @Input() user: UserDto;
  userForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  constructor(public activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private userService: UserService) {}

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      firstName: [this.user.firstName, Validators.required],
      lastName: [this.user.lastName, Validators.required],
      userName: [this.user.userName, Validators.required],
      email: [this.user.email, Validators.required],
      phoneNumber: [this.user.phoneNumber, Validators.required],
      dateOfBirth: [this.user.dateOfBirth, Validators.required]
      });
  }

  onSubmit() {
    if (this.userForm.valid) {
      this.userService.put(this.userForm.value)
      .subscribe(
          data => {
              this.activeModal.close('SaveClick');
          },
          error => {
              this.error = error;
              this.loading = false;
          });
      }
   }

   onCancel() {
    this.activeModal.close('CancelClick');
   }

   get f() {
    return this.userForm.controls;
  }
}
