import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root'})
export class Configuration {
  public Endpoint = 'http://localhost:55555/api';

  public localStorageUserKey = 'currentUser';
  public localStorageTokenKey = 'jwtToken';
}
