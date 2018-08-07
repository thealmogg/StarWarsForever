import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '../../node_modules/@angular/core';

import { WeaponListComponent } from './weapon-list/weapon-list.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { WeaponFormComponent } from './weapon-form/weapon-form.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { ContactViewComponent } from './contact-view/contact-view.component';
import { ContactFormNewComponent } from './contact-form-new/contact-form-new.component';

const appRoutes: Routes = [
  { path: '', redirectTo: 'contacts', pathMatch: 'full' },
  { path: 'contacts', component: ContactListComponent },
  { path: 'contacts/new', component: ContactFormNewComponent },
  { path: 'contacts/:id', component: ContactViewComponent },
  { path: 'weapons', component: WeaponListComponent },
  { path: 'weapons/new', component: WeaponFormComponent },
  { path: 'weapons/:id', component: WeaponFormComponent },
  { path: 'not-found', component: ErrorPageComponent, data: {message: 'Page not found!'}},
  { path: '**', redirectTo: '/not-found' }
];
@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class AppRouting { }
