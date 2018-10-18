
export interface Register {
    UserName: string;
    Email: string ;
    Password: string;
    ConfirmPassword: string;  
}

export interface RegisterInterface {
    register: Register ;
}
