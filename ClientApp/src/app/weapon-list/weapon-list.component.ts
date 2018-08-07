import { WeaponsService } from './../services/weapons.service';
import { Component, OnInit, Input } from '@angular/core';
import { Weapon } from '../models/weapon.model';
import { ActivatedRoute, Router } from '../../../node_modules/@angular/router';
import { ToastyService } from '../../../node_modules/ng2-toasty';

@Component({
  selector: 'app-weapon-list',
  templateUrl: './weapon-list.component.html',
  styleUrls: ['./weapon-list.component.css']
})
export class WeaponListComponent implements OnInit {
  @Input() weapons: Weapon[] = [];
  inWeaponRoute: boolean;
  constructor(private weaponsService: WeaponsService,
    private route: ActivatedRoute,
    private toasty: ToastyService,
    private router: Router) { }

  ngOnInit() {
    this.inWeaponRoute = this.route.component === WeaponListComponent;
    if (this.inWeaponRoute) {
      this.weaponsService.getWeapons().subscribe(weapons => this.weapons = weapons);
      }
    }

  onWeaponChange(id: number) {
    this.weaponsService.deleteWeapon(id).subscribe(
      weapon => {
        this.toasty.info({
          title: 'Deleted',
          msg: 'Weapon Deleted Successfully',
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
        this.weapons.splice(this.weapons.indexOf(weapon), 1);
      });
  }
  onNewWeapon() {
    this.router.navigate(['/weapons/new']);
  }
}
