import { Injectable } from '@angular/core';
import { HttpClient } from '../../../node_modules/@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';
import { Weapon } from '../models/weapon.model';

@Injectable()
export class WeaponsService {
  private readonly weaponsEndpoint: string = '/api/weapons/';

  constructor(private http: HttpClient) { }

  getWeapons(): Observable<Weapon[]> {
    return this.http.get<Weapon[]>(this.weaponsEndpoint, {
      responseType: 'json'
    });
  }

  getWeapon(weapondId: number): Observable<Weapon> {
    return this.http.get<Weapon>(this.weaponsEndpoint + weapondId, {
      responseType: 'json'
    });
  }

  deleteWeapon(weaponId: number) {
    return this.http.delete<Weapon>(this.weaponsEndpoint + weaponId, {
      responseType: 'json'
    });
  }

  updateWeapon(weapon: Weapon) {
    return this.http.put<Weapon>(this.weaponsEndpoint + weapon.id, weapon, {
      responseType: 'json'
    });
  }
  createWeapon(weapon: Weapon) {
    return this.http.post<Weapon>(this.weaponsEndpoint + weapon.contactId, weapon, {
      responseType: 'json'
    });
  }


}
