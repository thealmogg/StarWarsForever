import { ProfileImage } from './profileimage.model';
import { Weapon } from './weapon.model';

export class Contact {

  constructor(public name: string,
    public last: string,
    public isDisplayed: boolean, public weapons?: Weapon[],
    public id?: number, public birthDate?: string, public profileImage?: ProfileImage) {}
}
