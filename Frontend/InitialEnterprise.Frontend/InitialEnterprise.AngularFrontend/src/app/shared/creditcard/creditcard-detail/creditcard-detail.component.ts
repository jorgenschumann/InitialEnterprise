import { CreditCardType } from './../../models/creditcard';
import { OnInit, Component, Input} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { ValidationResult } from '../../models/commandHandlerAnswer';
import { CamelCasePipe } from '../../pipes/camel-case.pipe';
import { Guid } from '../../utils/guid';
import { ToastService } from '../../components/toasts/toast.service';
import { CreditCard } from '../../models/creditcard';
import { CreditCardService } from '../../services/creditcard.service';

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
    this.credidCardService.getCreditCardTypes().subscribe (
      (response: CreditCardType[]) => {
        this.creditCardTypes = response;
      });
    const params = this.route.snapshot.params;
    if (params.id === Guid.emptyGuid()) {
      //this.creditCard = CredidCardFactory.empty(params.personId);
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
    // const address: Address =  Object.assign({}, this.form.value);
    // if (address.id === Guid.emptyGuid()) {
    //     this.post(address);
    //     } else {
    //       this.put(address);
    //   }
  }

}
