export interface Register {
  userName: string;
  email: string ;
  password: string;
  confirmPassword: string;
}

export interface RegisterInterface {
  register: Register;
}

export interface LoginInterface {
  login: Login;
}

export interface Login {
  email: string | undefined;
  password: string;
  rememberMe: boolean;
}

export interface ApplicationUserClaim {
  id: number;
  claimType: string ;
  claimValue: string;
}

export interface UserDto {
  id: any;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  userName: string;
  email: string;
  emailConfirmed: string;
  phoneNumber: string;
  phoneNumberConfirmed: string;
  password: string;
  confirmPassword: string;
  role: string;
  claims: ApplicationUserClaim[];
  image: string;
}

export interface UserSignInResultDto {
  signInResult: any;
  user: UserDto;
  token: string;
}

// export interface TokenDto {
//   Id: string;
//   Sub: string;
//   Exp: number;
//   Iat: number;
// }

export enum Role {
  User = 'User',
  Admin = 'Admin'
}
