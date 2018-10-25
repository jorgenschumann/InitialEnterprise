export type LoginFormButtonType = 'login' | undefined;


// tslint:disable-next-line:interface-name
export interface LoginInterface {
    login: Login ;
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
