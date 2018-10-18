export function authHeader() {
    const token = localStorage.token || '';
    if (token) {
        return { Authorization: token };
    } else {
        return {};
    }
}
