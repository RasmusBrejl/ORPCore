export class User {

    name: string;
    password: string;

    constructor(user?: any) {
        if (user != null) {
          Object.entries(user).forEach((prop) => {
            this[prop[0]] = prop[1];
          });
        }
      }
}