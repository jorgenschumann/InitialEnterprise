
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
