import { UserService } from './../shared/user.service';
import { UserDto } from './../../models/user.types';
import { Component, OnInit } from '@angular/core';
import { UserDetailComponent } from '../user-detail/user-detail.component';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

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
    private modalService: NgbModal) { }

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

    const modalRef = this.modalService.open(UserDetailComponent, { size: 'lg' });
    modalRef.componentInstance.user = this.selectedUser;
    modalRef.result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
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

}




