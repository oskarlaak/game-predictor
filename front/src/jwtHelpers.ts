import IJwtDTO from "./dto/identity/IJwtDTO";

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
