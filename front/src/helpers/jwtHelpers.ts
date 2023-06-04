import IJwtDTO from "../dto/user-auth/IJwtDTO";

export function hasJwt(): boolean {
    return getJwt() !== undefined;
}

export function getJwt(): IJwtDTO | undefined {
    const jwt = localStorage.getItem("jwt");
    return jwt === null ? undefined : JSON.parse(jwt);
}

export function setJwt(jwt: IJwtDTO): void {
    localStorage.setItem("jwt", JSON.stringify(jwt));
}

export function removeJwt(): void {
    localStorage.removeItem("jwt");
}
