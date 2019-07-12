import { Component, OnInit, Input, Injectable } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/shared/services/user.service';
import { CamelCasePipe } from 'src/app/shared/pipes/camel-case.pipe';
import { UserDto } from 'src/app/shared/models/user.types';
import { ValidationResult } from 'src/app/shared/models/commandHandlerAnswer';
@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})

@Injectable({ providedIn: 'root' })
export class UserDetailComponent implements OnInit {

  constructor(public activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private camelCasePipe: CamelCasePipe) {}

   get f() {
    return this.userForm.controls;
  }
  @Input() user: UserDto;
  userForm: FormGroup;
  loading = false;
  submitted = false;
  errors: { [key: string]: string } = {};
  validationResult: ValidationResult;

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
}
