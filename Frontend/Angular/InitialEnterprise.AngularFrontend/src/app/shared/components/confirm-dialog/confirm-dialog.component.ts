import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmDialogModel } from './confirm-dialog-model';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.css']
})
export class ConfirmDialogComponent implements OnInit {
  model: ConfirmDialogModel;

  constructor(public activeModal: NgbActiveModal) { }

  setModel(confirmDialogModel: ConfirmDialogModel) {
    this.model = confirmDialogModel;
  }

  ngOnInit() {
  }


  onCancel() {
    this.activeModal.close('cancel');
   }

  onConfirm() {
    this.activeModal.close('confirm');
  }

}
