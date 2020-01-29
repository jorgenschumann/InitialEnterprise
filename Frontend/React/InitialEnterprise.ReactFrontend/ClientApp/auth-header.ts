export function authHeader() {  
    var token = localStorage['token'] || '';
    if (token) {
        return { 'Authorization': token };
    } else {
        return {};
    }
}