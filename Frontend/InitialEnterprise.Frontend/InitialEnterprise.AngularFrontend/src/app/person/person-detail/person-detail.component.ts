import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Component, OnInit} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {   NgbModal} from '@ng-bootstrap/ng-bootstrap';
import { Person } from 'src/app/shared/models/person.types';
import { MailAddress } from 'src/app/shared/models/mailaddress';
import { ValidationResult } from 'src/app/shared/models/commandHandlerAnswer';
import { MailaddressService } from 'src/app/shared/services/mailaddress.service';
import { PersonService } from 'src/app/shared/services/person.service';
import { CamelCasePipe } from 'src/app/shared/pipes/camel-case.pipe';
import { Guid } from 'src/app/shared/utils/guid';
import { ConfirmDialogBuilder } from 'src/app/shared/components/confirm-dialog/confirm-dialog-builder';
import { ToastService } from 'src/app/shared/components/toasts/toast.service';

@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html',
  styleUrls: ['./person-detail.component.css'],
})
export class PersonDetailComponent implements OnInit {
  public person: Person;
  form: FormGroup;
  emailAddresses: FormArray;
  errors: { [key: string]: string } = {};
  validationResult: ValidationResult;
  currencyService: any;
  infoContent: string;
  infoTitle: string;

  constructor(
    private personService: PersonService,
    private mailAddressService: MailaddressService,
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private camelCasePipe: CamelCasePipe,
    private modalService: NgbModal,
    public toastService: ToastService,
  ) {
      this.mailAddressService.RootEntityEndpointFragment = 'person';
  }

  ngOnInit() {
    const params = this.route.snapshot.params;
    this.personService.get(params.id)
      .subscribe(person => {
        this.person = person;
        this.initForm();
      });
  }

  initForm() {
    this.buildEmailAddressArray();

    this.form = this.formBuilder.group({
      id: [this.person.id, Validators.required],
      personType: [this.person.personType],
      nameStyle: [this.person.nameStyle, Validators.required],
      title: [this.person.title, Validators.required],
      firstName: [this.person.firstName, Validators.required],
      middleName: [this.person.middleName, Validators.required],
      lastName: [this.person.lastName, Validators.required],
      suffix: [this.person.suffix],
      emailPromotion: [this.person.emailPromotion, Validators.required],
      emailAddresses: this.emailAddresses
    });
  }

  onSubmit() {
    const person: Person =  Object.assign({}, this.form.value);
    this.personService.put(person)
      .subscribe(
        (response: any) => {
          this.person = response.aggregateRoot;
          this.toastService.showSuccess('Person saved');
          },
          error => {
              this.validationResult = error.error.validationResult;
              this.updateErrorMessages();
          });
  }

  delete() {
    if (confirm('Person wirklich löschen?')) {
      this.personService.delete(this.person)
        .subscribe(res => this.router.navigate(['../'], { relativeTo: this.route }));
    }
  }

  buildEmailAddressArray() {
    this.emailAddresses = this.formBuilder.array(
      this.person.emailAddresses.map(
        t => this.formBuilder.group({
          id: this.formBuilder.control(t.id),
          personId: this.formBuilder.control(t.personId),
          isPrimary: this.formBuilder.control(t.isPrimary),
          mailAddress: this.formBuilder.control(t.mailAddress),
          mailAddressType: this.formBuilder.control(t.mailAddressType)
        })
      )
    );
  }

  createEmailAddressControl() {
    this.emailAddresses.push(this.formBuilder.group({
      isPrimary: false, mailAddress: null, mailAddressType: null, id: Guid.emptyGuid(), personId: this.person.id }));
  }

  updateEmailAddress(index: number) {
    const emailAddress = this.emailAddresses.value[index] as MailAddress;
    this.infoContent = emailAddress.mailAddress;
    if (emailAddress.id === Guid.emptyGuid()) {
      this.mailAddressService.post(emailAddress)
      .subscribe(
        (response: any) => {
          this.person = response.aggregateRoot;
          const element: HTMLElement = document.getElementById('popoverInfo') as HTMLElement;
          this.infoTitle = 'Create';
          element.click();
          },
          error => {
              this.validationResult = error.error.validationResult;
          });
    } else {
      this.mailAddressService.put(emailAddress)
      .subscribe(
        (response: any) => {
          this.person = response.aggregateRoot;
          const element: HTMLElement = document.getElementById('popoverInfo') as HTMLElement;
          this.infoTitle = 'Update';
          element.click();
          },
          error => {
              this.validationResult = error.error.validationResult;
              this.updateErrorMessages();
          });
        }
  }

  deleteEmailAddress(index: number) {
    const emailAddress = this.emailAddresses.value[index] as MailAddress;
    const modal = ConfirmDialogBuilder.deleteConfirmBox(
    this.modalService, 'Delete MailAddress', `email: ${emailAddress.mailAddress}`);
    modal.result.then((result) => {
        if (result === 'confirm') {
          this.mailAddressService.delete(emailAddress.personId, emailAddress)
          .subscribe(() => {
          }, err => {
            console.log(err);
          });
          this.emailAddresses.removeAt(index);
        }
    });
  }

  updateErrorMessages() {
    this.errors = {};
    for (const message of this.validationResult.errors) {
      this.errors[this.camelCasePipe.transform(message.propertyName)] = message.errorMessage;
    }
  }
}
