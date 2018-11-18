export type LoginFormButtonType = 'login' | undefined;

// tslint:disable-next-line:interface-name
export interface Register {
    UserName: string;
    Email: string ;
    Password: string;
    ConfirmPassword: string;
}

// tslint:disable-next-line:interface-name
export interface RegisterInterface {
    register: Register ;
}

// tslint:disable-next-line:interface-name
export interface LoginInterface {
    login: Login;
}

// tslint:disable-next-line:interface-name
export interface LoginButtonClicks {
    loginClick: (login: Login) => void;
}

// tslint:disable-next-line:interface-name
export interface Login {
    Email: string | undefined;
    Password: string;
}

export interface ApplicationUserClaim {
    Id: number;
    ClaimType: string ;
    ClaimValue: string;
}

export interface User {
    Id: string;
    UserName: string;
    Email: string;
    EmailConfirmed: string;
    PhoneNumber: string;
    PhoneNumberConfirmed: string;
    Password: string;
    ConfirmPassword: string;
    Claims: ApplicationUserClaim[];
}


export interface TokenDto {
    Id: string;
    Sub: string;
    Exp: number;
    Iat: number;
}