import { catchError } from 'rxjs/operators';
import { CreditCardType } from './../../models/creditcard';
import { OnInit, Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { ValidationResult, CommandHandlerAnswer } from '../../models/commandHandlerAnswer';
import { CamelCasePipe } from '../../pipes/camel-case.pipe';
import { Guid } from '../../utils/guid';
import { ToastService } from '../../components/toasts/toast.service';
import { CreditCard } from '../../models/creditcard';
import { CreditCardService } from '../../services/creditcard.service';
import { CreditCardFactory } from '../../factories/creditcard-factory';
import { Person } from '../../models/person.types';


@Component({
  selector: 'app-creditcard-detail',
  templateUrl: './creditcard-detail.component.html',
  styleUrls: ['./creditcard-detail.component.css']
})
export class CreditCardDetailComponent implements OnInit {
  @Input() creditCard: CreditCard;
  form: FormGroup;
  validationResult: ValidationResult;
  errors: { [key: string]: string } = {};
  creditCardTypes: CreditCardType[];
  months = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
  years = [2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private credidCardService: CreditCardService,
    private formBuilder: FormBuilder,
    private camelCasePipe: CamelCasePipe,
    public location: Location,
    public toastService: ToastService
  ) {
    this.credidCardService.RootEntityEndpointFragment = 'person';
  }

  ngOnInit() {
    this.credidCardService.getCreditCardTypes().subscribe(
      (response: CreditCardType[]) => {
        this.creditCardTypes = response;
      });
    const params = this.route.snapshot.params;
    if (params.id === Guid.emptyGuid()) {
      this.creditCard = CreditCardFactory.empty(params.personId);
      this.initForm();
    } else {
      this.credidCardService.get(params.personId, params.id)
        .subscribe(creditCard => {
          this.creditCard = creditCard;
          this.initForm();
        });
    }
  }

  private initForm() {
    this.form = this.formBuilder.group({
      id: [this.creditCard.id, Validators.required],
      personId: [this.creditCard.personId, Validators.required],
      cardNumber: [this.creditCard.cardNumber, Validators.required],
      creditCardType: [this.creditCard.creditCardType, Validators.required],
      expireMonth: [this.creditCard.expireMonth, Validators.required],
      expireYear: [this.creditCard.expireYear, Validators.required],
    });
  }

  public submit() {
    const creditCard: CreditCard = Object.assign({}, this.form.value);
    if (creditCard.id === Guid.emptyGuid()) {
      this.post(creditCard);
    } else {
      this.put(creditCard);
    }
  }

  private post(creditCard: CreditCard) {
    this.credidCardService.post(creditCard).subscribe(
      (response: CommandHandlerAnswer<Person>) => {
        this.router.navigate(['/persons', creditCard.personId], { relativeTo: this.route });
        this.toastService.showSuccess('Credit Card created');
      }, error => {
        this.validationResult = error.error.validationResult;
        this.updateErrorMessages();
      });
  }


  private put(creditCard: CreditCard) {
    this.credidCardService.put(creditCard).subscribe(
      (response: CommandHandlerAnswer<Person>) => {
        alert(JSON.stringify(response));
        this.router.navigate(['/persons', creditCard.personId], { relativeTo: this.route });
        this.toastService.showSuccess('Credit Card updated');
      },
      error => {
        alert(JSON.stringify(error));
        this.validationResult = error.error.validationResult;
        this.updateErrorMessages();
      });
  }

  private updateErrorMessages() {
    this.errors = {};
    for (const message of this.validationResult.errors) {
      this.errors[this.camelCasePipe.transform(message.propertyName)] = message.errorMessage;
    }
  }

}
