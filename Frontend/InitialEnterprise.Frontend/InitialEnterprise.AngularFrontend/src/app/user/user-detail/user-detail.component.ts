import { Component, OnInit, Input, Injectable } from '@angular/core';
import { UserDto } from 'src/app/models/user.types';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from './../shared/user.service';
import {NgbDateAdapter, NgbDateStruct, NgbDateNativeAdapter} from '@ng-bootstrap/ng-bootstrap';
import { ValidationResult } from 'src/app/models/CommandHandlerAnswer';
import { CamelCasePipe } from 'src/app/core/pipes/camel-case.pipe';

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
  errors: { [key: string]: string } = {};
  validationResult: ValidationResult;

  constructor(public activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private camelCasePipe: CamelCasePipe) {}

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
      const user: UserDto = Object.assign({}, this.userForm.value);
      this.userService.put(user)
      .subscribe(
                (response: any) => {
                  this.user = response.aggregateRoot;
                  this.activeModal.close(this.user);
                  },
                  error => {
                      this.validationResult = error.error.validationResult;
                      this.updateErrorMessages();
                  });
   }

   updateErrorMessages() {
    this.errors = {};
    for (const message of this.validationResult.errors) {
      this.errors[this.camelCasePipe.transform(message.propertyName)] = message.errorMessage;
    }
  }

   onCancel() {
    this.activeModal.close(this.user);
   }

   get f() {
    return this.userForm.controls;
  }
}
