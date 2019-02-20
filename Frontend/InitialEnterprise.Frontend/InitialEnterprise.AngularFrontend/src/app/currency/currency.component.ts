import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Currency } from './types';
import { provideForRootGuard } from '@angular/router/src/router_module';
import { CurrencyService } from './shared/currency.service';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html'
})

export class CurrencyComponent implements OnInit {
  public currencies: Currency[];

  constructor(private api: CurrencyService) {
  }

  ngOnInit() {
    this.api.list()
      .subscribe(res => {
        this.currencies = res;
      }, err => {
        console.log(err);
      });
  }

  public edit(currency: Currency) {
    alert('edit');
  }

  public open() {
    alert('open');
  }
}

