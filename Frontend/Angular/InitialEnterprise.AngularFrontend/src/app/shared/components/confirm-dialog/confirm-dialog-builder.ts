import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Injectable } from '@angular/core';
import { ConfirmDialogModel } from './confirm-dialog-model';
import { ConfirmDialogComponent } from './confirm-dialog.component';

@Injectable({
    providedIn: 'root'
})
export class ConfirmDialogBuilder {
  static deleteConfirmBox(modalService: NgbModal, header: string, body: string): NgbModalRef {
    const model = new ConfirmDialogModel(header , body);
    const modal = modalService.open(ConfirmDialogComponent, { size: 'sm', centered: true  });
    const confirmDialogComponent = modal.componentInstance as ConfirmDialogComponent;
    confirmDialogComponent.setModel(model);
    return modal;
  }
}
