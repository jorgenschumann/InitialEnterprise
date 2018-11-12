import * as JWT from 'jwt-decode';
import axios, { AxiosRequestConfig, AxiosPromise } from 'axios';
import { Endpoints } from './Endpoints';

export class Http {        

    private static axiosWrapper = () => {
        const token = localStorage.getItem('token');
        const defaultOptions = {
            baseURL: Endpoints.Api,
            headers: {
                'Authorization': token ? `Bearer ${token}` : '',
                'Content-Type': 'application/json'
            }
        };
        return {
            get: (url, options = {}) => axios.get(url, { ...defaultOptions, ...options }),
            post: (url, data, options = {}) => axios.post(url, data, { ...defaultOptions, ...options }),
            put: (url, data, options = {}) => axios.put(url, data, { ...defaultOptions, ...options }),
            delete: (url, options = {}) => axios.delete(url, { ...defaultOptions, ...options }),
            patch: (url, options = {}) => axios.patch(url, { ...defaultOptions, ...options }),
        };
    };
     
    public static get(url, config?: AxiosRequestConfig): AxiosPromise {
        return Http.axiosWrapper().get(url, config);
    }

    public static put(url, data,config?: AxiosRequestConfig): AxiosPromise{
        return Http.axiosWrapper().put(url, data,config);
    }

    public static post(url,data, config?: AxiosRequestConfig): AxiosPromise {
        return Http.axiosWrapper().post(url,data, config);
    }

    public static delete(url, config?: AxiosRequestConfig): AxiosPromise {
        return Http.axiosWrapper().delete(url, config);
    }

    public static patch(url, config?: AxiosRequestConfig): AxiosPromise {
        return Http.axiosWrapper().patch(url, config);
    }

    //https://codesandbox.io/s/vy3o1nk21l
    // https://medium.freecodecamp.org/how-to-protect-your-routes-with-react-context-717670c4713a

    public static isAuthenticated () {       
        const token = this.getToken()
        return !!token && !this.tokenExpired()
    }

    static tokenExpired() {
        try {
            const decoded = JWT(this.getToken());
            if (decoded.exp < Date.now() / 1000) {
                return true;
            }
            else
                return false;
        }
        catch (err) {
            return false;
        }
    }
    
    static getToken() {
        return localStorage.getItem('token')
    }

    public static getTokenDecoded(): string {
        var tokenDecoded = JWT(this.getToken());       
        return tokenDecoded;
    }
}
