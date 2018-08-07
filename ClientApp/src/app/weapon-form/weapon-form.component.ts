import { ToastyService } from 'ng2-toasty';
import { Weapon } from './../models/weapon.model';
import { WeaponsService } from './../services/weapons.service';
import { Contact } from './../models/contact.model';
import { ContactsService } from './../services/contacts.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '../../../node_modules/@angular/router';

@Component({
  selector: 'app-weapon-form',
  templateUrl: './weapon-form.component.html',
  styleUrls: ['./weapon-form.component.css']
})
export class WeaponFormComponent implements OnInit {
  weaponForm: FormGroup;
  contacts: Contact[];
  updateMode: boolean;
  currentWeapon: Weapon;
  constructor(private contactsService: ContactsService,
              private weaponsService: WeaponsService,
              private route: ActivatedRoute,
              private toasty: ToastyService,
              private router: Router) { }

  ngOnInit() {
    this.weaponForm = new FormGroup({
      'name': new FormControl(null, [Validators.required]),
      'contactId': new FormControl(null, [Validators.required]),
    });
    this.contactsService.getContacts().subscribe(contacts => this.contacts = contacts);
    const snapshotId = this.route.snapshot.params['id'];
    if (!isNaN(snapshotId)) {
      console.log(snapshotId);
      this.weaponsService.getWeapon(+snapshotId).subscribe(
        weapon => {
          this.weaponForm.controls['name'].setValue(weapon.name);
          this.weaponForm.controls['contactId'].setValue(weapon.contactId);
          this.updateMode = true;
          this.currentWeapon = weapon;
        });

    }
  }

  onSubmit() {
    if (this.updateMode) {
      this.currentWeapon.name = this.weaponForm.value.name;
      this.currentWeapon.contactId = this.weaponForm.value.contactId;

      this.weaponsService.updateWeapon(this.currentWeapon)
      .subscribe(
        weapon => {
          this.toasty.success({
            title: 'Success',
            msg: 'Weapon Created Successfully',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
          this.router.navigate(['/weapons']);
        }
      );
    } else {
      this.weaponsService.createWeapon(this.weaponForm.value)
      .subscribe(
        weapon => {
          this.toasty.success({
            title: 'Success',
            msg: 'Weapon Created Successfully',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
          this.weaponForm.reset();
        });
    }

  }

}
