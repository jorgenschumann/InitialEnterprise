import { Component, OnInit } from '@angular/core';
import { UserDetailComponent } from '../user-detail/user-detail.component';
import {NgbModal, ModalDismissReasons, NgbModalConfig} from '@ng-bootstrap/ng-bootstrap';
import { UserDto } from 'src/app/shared/models/user.types';
import { UserService } from 'src/app/shared/services/user.service';
import { ArrayUtils } from 'src/app/shared/utils/arrayUtils';
import { ConfirmDialogBuilder } from 'src/app/shared/components/confirm-dialog/confirm-dialog-builder';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})

export class UserListComponent implements OnInit {
  public users: UserDto[];
  selectedUser: UserDto;
  closeResult: string;

  constructor(
    private userService: UserService,
    private modalService: NgbModal,
    config: NgbModalConfig) {
    }

  ngOnInit() {
    this.userService.list()
      .subscribe(res => {
        this.users = res;
      }, err => {
        console.log(err);
      });
  }

  public edit(user: UserDto) {
    this.selectedUser = user;

    const modalRef = this.modalService.open(UserDetailComponent);
    modalRef.componentInstance.user = this.selectedUser;
    modalRef.result.then((result) => {
      ArrayUtils.pushToArray(this.users, Object.assign(this.selectedUser, result));
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    }

    public delete(user: UserDto) {
      const modal = ConfirmDialogBuilder.deleteConfirmBox(
        this.modalService, 'Delete User', `Name: ${user.firstName} ${user.lastName}`);
      modal.result.then((result) => {
        if (result === 'confirm') {
          this.userService.delete(user);
          ArrayUtils.removeFromArray(this.users, user);
        }
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
}




