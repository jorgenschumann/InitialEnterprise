import { CurrencyDetailComponent } from '../currency-detail/currency-detail.component';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { Currency } from '../types';
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
    const modal = this.modalService.open(CurrencyDetailComponent, { size: 'lg' });
    modal.componentInstance.currency = this.selectedCurrency;
    modal.result.then((result) => {
      ArrayUtils.pushToArray(this.currencies, Object.assign(this.selectedCurrency, result));
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    }

  getDismissReason(reason: any): any {
    throw new Error('Method not implemented.');
  }

  public delete(currency: Currency) {
      const modal = this.modalService.open(ConfirmDialogComponent, { size: 'sm' });
      modal.result.then((result) => {
        alert(result);
        if (result === 'confirm') {
          this.currencyService.delete(currency.id);
          ArrayUtils.removeFromArray(this.currencies, currency);
        }
      });
  }
}

