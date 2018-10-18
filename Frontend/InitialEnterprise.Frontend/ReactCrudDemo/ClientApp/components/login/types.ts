export type LoginFormButtonType = 'login' | undefined;


export interface LoginInterface {
    login: Login ;
}

export interface LoginButtonClicks {
    loginClick: (login: Login) => void;
}


export interface Login {
    Email: string | undefined;
    Password: string;
}
