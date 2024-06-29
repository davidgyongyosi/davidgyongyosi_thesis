export class User {
    userId = "";
    userName = "";
    firstName = "";
    lastName = "";
    email = "";
    picture: string | undefined;
}

export interface UserDetailDTO {
    userId: string;
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    picture: string | undefined;
    roles: string[];
}

export class UpdateUserDTO {
    userId?: string;
    firstName?: string;
    lastName?: string;
    email?: string;
    picture?: string | undefined;
}