import { ValidationResult } from "../types";

export type MailFormButtonType = 'edit' | 'add' | undefined;

export interface EmailAddresses {
    EmailAddresses: EmailAddress[] | undefined;
}

export interface EmailAddressFormState {
    EmailAddress: EmailAddress;   
    ValidationResult: ValidationResult;
}

export interface EmailButtonClicks {
    DeleteClick: (mail: EmailAddress) => void;
    EditClick: (mail: EmailAddress) => void;
}

export interface EmailAddress {
    Id: string;
    PersonId: string;
    MailAddress: string;
}

