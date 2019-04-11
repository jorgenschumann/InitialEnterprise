import { CamelCasePipe } from './../../core/pipes/camel-case.pipe';
import { Currency } from './../types';
import { Component, OnInit, Input, Injectable } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CurrencyService } from '../shared/currency.service';
import { CommandHandlerAnswer, ValidationResult } from 'src/app/models/CommandHandlerAnswer';
import { ConfirmDialogModus } from 'src/app/shared/components/confirm-dialog/confirm-dialog-modus.enum';

@Component({
  selector: 'app-currency-detail',
  templateUrl: './currency-detail.component.html',
  styleUrls: ['./currency-detail.component.css']
})

@Injectable({ providedIn: 'root' })
export class CurrencyDetailComponent implements OnInit {
  @Input() currency: Currency;
  @Input() modus = ConfirmDialogModus;
  form: FormGroup;
  loading = false;
  submitted = false;
  errors: { [key: string]: string } = {};


  validationResult: ValidationResult;

  constructor(public activeModal: NgbActiveModal,
              private currencyService: CurrencyService,
              private formBuilder: FormBuilder,
              private camelCasePipe: CamelCasePipe) { }

  ngOnInit() {
    this.initCurrency();
  }

  initCurrency() {
    this.form = this.formBuilder.group({
      id: [this.currency.id, Validators.required],
      name: [this.currency.name, Validators.required],
      isoCode: [this.currency.isoCode, Validators.required]
      });
    this.form.statusChanges.subscribe(() => this.updateErrorMessages());
  }

  onSubmit() {
      const currency: Currency =  Object.assign({}, this.form.value);
      this.currencyService.put(currency)
        .subscribe(
          (response: any) => {
            this.currency = response.aggregateRoot;
            this.activeModal.close(this.currency);
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
    this.activeModal.close(this.currency);
   }

   get f() {
    return this.form.controls;
  }
}
