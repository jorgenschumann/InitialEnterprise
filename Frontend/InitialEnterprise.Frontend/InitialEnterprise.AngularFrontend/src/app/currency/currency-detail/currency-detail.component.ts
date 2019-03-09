import { Currency } from './../types';
import { Component, OnInit, Input, Injectable } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CurrencyService } from '../shared/currency.service';

@Component({
  selector: 'app-currency-detail',
  templateUrl: './currency-detail.component.html',
  styleUrls: ['./currency-detail.component.css']
})

@Injectable({ providedIn: 'root' })
export class CurrencyDetailComponent implements OnInit {
  @Input() currency: Currency;
  form: FormGroup;
  loading = false;
  submitted = false;
  error = '';

  constructor(public activeModal: NgbActiveModal,
              private currencyService: CurrencyService,
              private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      id: [this.currency.id, Validators.required],
      name: [this.currency.name, Validators.required],
      isoCode: [this.currency.isoCode, Validators.required]
      });
  }

  onSubmit() {
    if (this.form.valid) {
      this.currencyService.put(this.form.value)
      .subscribe(
          data => {
            this.currency = Object.assign({}, this.form.value);
            this.activeModal.close(this.currency);
          },
          error => {
              this.error = error;
              this.loading = false;
          });
      }
   }

   onCancel() {
    this.activeModal.close(this.currency);
   }

   get f() {
    return this.form.controls;
  }
}
