import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';
import { Configuration } from 'src/app/configuration';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private configuration: Configuration,
                private authenticationService: AuthenticationService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const currentUser = this.authenticationService.currentUserValue;
    const token = localStorage.getItem(this.configuration.localStorageTokenKey);
    if (currentUser && token) {
            request = request.clone({
                setHeaders: {
                  Authorization: token
                }
            });
        }
    return next.handle(request);
    }
}
