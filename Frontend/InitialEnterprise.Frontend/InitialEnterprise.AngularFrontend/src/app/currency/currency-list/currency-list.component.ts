import { Currency } from './../types';
import { CurrencyDetailComponent } from '../currency-detail/currency-detail.component';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ArrayUtils } from '../../core/arrayUtils';
import { CurrencyService } from '../shared/currency.service';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { Guid } from 'src/app/core/guid';
import { CurrencyFactory } from '../shared/currency-factory';
import { ConfirmDialogModus } from 'src/app/shared/components/confirm-dialog/confirm-dialog-modus.enum';

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
    modal.componentInstance.modus = ConfirmDialogModus.Edit;
    modal.componentInstance.currency = this.selectedCurrency;
    modal.result.then((result) => {
      ArrayUtils.pushToArray(this.currencies, Object.assign(this.selectedCurrency, result));
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    }

  public add() {
    const modal = this.modalService.open(CurrencyDetailComponent, { size: 'lg' });
    modal.componentInstance.modus = ConfirmDialogModus.Create;
    modal.componentInstance.currency = CurrencyFactory.empty();
    modal.result.then((result) => {
      ArrayUtils.pushToArray(this.currencies, Object.assign(this.selectedCurrency, result));
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
  }


  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  public delete(currency: Currency) {
      const modal = this.modalService.open(ConfirmDialogComponent, { size: 'sm' });
      modal.result.then((result) => {
        if (result === 'confirm') {
          this.currencyService.delete(currency.id);
          ArrayUtils.removeFromArray(this.currencies, currency);
        }
      });
  }
}

