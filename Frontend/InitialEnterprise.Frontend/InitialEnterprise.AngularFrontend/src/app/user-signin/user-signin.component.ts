import { UserAuthenticationService } from './user-authentication.service';
import { Login } from './sigin-types';
import {Component, OnInit, ElementRef, ViewChild} from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { Content } from '@angular/compiler/src/render3/r3_ast';
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import { ValidationService } from 'src/infrastructure/validation.service';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';


@Component({
  selector: 'app-user-signin',
  templateUrl: './user-signin.component.html',
  styleUrls: ['./user-signin.component.css']
})

export class UserSigninComponent implements OnInit {
  closeResult: string;
  signinForm: any;
  returnUrl: string;
  loading = false;
  submitted = false;
  error = '';
  login: Login = {} as Login;

  constructor(
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userAuthenticationService: UserAuthenticationService) {
    }

  ngOnInit(): void {
    this.signinForm = this.formBuilder.group({
      email: ['', [Validators.required, ValidationService.emailValidator]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      rememberMe: ['']
    });

    this.userAuthenticationService.logout();

    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  signin() {
    this.submitted = true;
    if (this.signinForm.dirty && this.signinForm.valid) {
      this.loading = true;
      this.login = Object.assign({}, this.signinForm.value);
      this.userAuthenticationService.login(this.login)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    this.error = error;
                    alert(JSON.stringify(error));
                    this.loading = false;
                  });
                }
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
