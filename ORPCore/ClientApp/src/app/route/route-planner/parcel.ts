export class Parcel {

    weight: string;
    height: string;
    depth: string;
    width: string;
    type: number[];

    constructor(user?: any) {
        if (user != null) {
          Object.entries(user).forEach((prop) => {
            this[prop[0]] = prop[1];
          });
        }
      }
}