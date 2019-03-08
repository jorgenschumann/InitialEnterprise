import { CurrencyDetailComponent } from '../currency-detail/currency-detail.component';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Currency } from '../types';
import { provideForRootGuard } from '@angular/router/src/router_module';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ArrayUtils } from '../../core/arrayUtils';
import { CurrencyService } from '../shared/currency.service';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-list-currency',
  templateUrl: './currency-list.component.html'
})

export class CurrencyListComponent implements OnInit {
  public currencies: Currency[];
  selectedCurrency: Currency;
  closeResult: string;
  constructor(
    private currencyService: CurrencyService,
    private modalService: NgbModal) {
  }

  ngOnInit() {
    this.currencyService.list()
      .subscribe(res => {
        this.currencies = res;
      }, err => {
        console.log(err);
      });
  }

  public edit(currency: Currency) {
    this.selectedCurrency = currency;
    const modalRef = this.modalService.open(CurrencyDetailComponent, { size: 'lg' });
    modalRef.componentInstance.currency = this.selectedCurrency;
    modalRef.result.then((result) => {
      ArrayUtils.pushToArray(this.currencies, Object.assign(this.selectedCurrency, result));
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    }

  getDismissReason(reason: any): any {
    throw new Error('Method not implemented.');
  }

  public delete(currency: Currency) {
      const modalRef = this.modalService.open(ConfirmDialogComponent, { size: 'lg' });
  }
}

