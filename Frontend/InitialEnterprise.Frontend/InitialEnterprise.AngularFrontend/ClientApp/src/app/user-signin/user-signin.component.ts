import { Component, Inject, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-user-signin',
  templateUrl: './user-signin.component.html',
  styleUrls: ['./user-signin.component.css']
})
export class UserSigninComponent implements OnInit {
  public userSignInResult: UserSignInResult;
  closeResult: string;
  modalService: any;

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string, modalService: NgbModal) {
    // http.post<UserSignInResult>(apiUrl + '/UserAccount/SignIn').subscribe(result => {
    //   this.userSignInResult = result;
    // }, error => console.error(error));
  }

  ngOnInit() {
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
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

export interface UserSignInResult {
  signInResult: any;
  user: string;
  token: string;
}



