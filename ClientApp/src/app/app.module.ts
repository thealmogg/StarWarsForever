import { AppErrorHandler } from './app.error-handler';
// Services
import { WeaponsService } from './services/weapons.service';
import { ContactsService } from './services/contacts.service';
// Modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRouting } from './app-routing.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { ToastyModule } from 'ng2-toasty';
// Directives
import { CollapseDirective } from './directives/collapse.directive';
import { DropdownDirective } from './directives/dropdown.directive';
// Components
import { AppComponent } from './app.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { WeaponListComponent } from './weapon-list/weapon-list.component';
import { WeaponFormComponent } from './weapon-form/weapon-form.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { ContactViewComponent } from './contact-view/contact-view.component';
import { ContactFormNewComponent } from './contact-form-new/contact-form-new.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    DropdownDirective,
    ContactListComponent,
    WeaponListComponent,
    WeaponFormComponent,
    ErrorPageComponent,
    ContactViewComponent,
    CollapseDirective,
    ContactFormNewComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastyModule.forRoot(),
    AppRouting,
    NgSelectModule,
  ],
  providers: [ContactsService, WeaponsService,
  {provide: ErrorHandler, useClass: AppErrorHandler}],
  bootstrap: [AppComponent]
})
export class AppModule { }
