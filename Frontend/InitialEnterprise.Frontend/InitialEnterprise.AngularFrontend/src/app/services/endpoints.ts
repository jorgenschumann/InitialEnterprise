import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root'})
export class Configuration {
  public Endpoint = 'http://localhost:63928/api';
}
