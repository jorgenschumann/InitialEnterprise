import { Country } from './../../models/country';
import { Address } from './../../models/address';
import { AddressFactory } from './../../factories/address-factory';
import { AddressService } from './../../services/address.service';
import { OnInit, Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { ValidationResult } from '../../models/commandHandlerAnswer';
import { CountryService } from '../../services/country.service';
import { CamelCasePipe } from '../../pipes/camel-case.pipe';
import { Guid } from '../../utils/guid';
import { ToastService } from '../../components/toasts/toast.service';

@Component({
  selector: 'app-address-detail',
  templateUrl: './address-detail.component.html',
  styleUrls: ['./address-detail.component.css']
})

export class AddressDetailComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private addressService: AddressService,
    private countryService: CountryService,
    private formBuilder: FormBuilder,
    private camelCasePipe: CamelCasePipe,
    public location: Location,
    public toastService: ToastService,
  ) {
    this.addressService.RootEntityEndpointFragment = 'person';
  }

  @Input() address: Address;
  form: FormGroup;
  validationResult: ValidationResult;
  errors: { [key: string]: string } = {};
  countries: Country[];
  provinces: string[];

  ngOnInit() {
    const params = this.route.snapshot.params;
    if (params.id === Guid.emptyGuid()) {
      this.address = AddressFactory.empty(params.personId);
      this.initForm();
    } else {
      this.addressService.get(params.personId, params.id)
        .subscribe(address => {
          this.address = address;
          this.onCountryChange(this.address.country);
          this.initForm();
        });
    }
    this.countryService.list().subscribe(
      (response: any) => {
        this.countries = response;
      });
  }

  private initForm() {
    this.form = this.formBuilder.group({
      id: [this.address.id, Validators.required],
      city: [this.address.city, Validators.required],
      country: [this.address.country, Validators.required],
      isPrimary: [this.address.isPrimary, Validators.required],
      personId: [this.address.personId, Validators.required],
      province: [this.address.province, Validators.required],
      street: [this.address.street, Validators.required],
      number: [this.address.number, Validators.required],
      zip: [this.address.zip, Validators.required]
    });
  }

  public submit() {
    const address: Address = Object.assign({}, this.form.value);
    if (address.id === Guid.emptyGuid()) {
      this.post(address);
    } else {
      this.put(address);
    }
  }

  private post(address: Address) {
    this.addressService.post(address).subscribe(
      (response: any) => {
        this.address = response.aggregateRoot.addresses.find((e) => e.id === address.id);
        this.toastService.showSuccess('Address created');
      },
      error => {
        this.validationResult = error.error.validationResult;
        this.updateErrorMessages();
      });
  }

  private put(address: Address) {
    this.addressService.put(address).subscribe(
      (response: any) => {
        this.address = response.aggregateRoot.addresses.find((e) => e.id === address.id);
        this.toastService.showSuccess('Address updated');
      },
      error => {
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

  public onCountryChange(selectedCountry: string) {
    const country = this.countries.find((x) => x.name === selectedCountry) as Country;
    this.provinces = country.provinces;
    this.address.country = country.name;
  }

}


