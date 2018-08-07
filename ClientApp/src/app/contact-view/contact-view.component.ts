import { ContactsService } from './../services/contacts.service';
import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { formatDate } from '@angular/common';
import { HttpEventType } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { forkJoin } from 'rxjs';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-contact-view',
  templateUrl: './contact-view.component.html',
  styleUrls: ['./contact-view.component.css']
})
export class ContactViewComponent implements OnInit {
  contact: Contact;
  uploadProgress = '0%';
  contacts: Contact[] = [];
  contactForm: FormGroup;
  contactIndex: number;
  constructor(private route: ActivatedRoute,
    private contactsService: ContactsService,
    private toasty: ToastyService,
    private router: Router) { }

  ngOnInit() {
    this.contactForm = new FormGroup({
      'isdisplayed': new FormControl(null),
      'birthdate': new FormControl(null, [])
    });

    this.contact = new Contact(null, null, false, []);
    const contactId: number = +this.route.snapshot.params['id'];
    forkJoin([
      this.contactsService.getContact(contactId),
      this.contactsService.getContacts()
    ]).subscribe(
      data => {
          this.contact = data[0];
          if (this.contact.birthDate) {
            this.contact.birthDate = formatDate(this.contact.birthDate, 'yyyy-MM-dd', 'en-US');
          }
        this.contacts = data[1];
      }, null, () => {
        this.contactForm.controls['isdisplayed'].setValue(this.contact.isDisplayed);
        this.contactForm.controls['birthdate'].setValue(this.contact.birthDate);
        this.contactIndex = this.getContactIndex();
        console.log(this.contactIndex);
      });
  }
  userImage() {
    if (this.contact && this.contact.profileImage) {
      return '/profile-images/' + this.contact.profileImage.fileName;
    }
    return '../../assets/img/defaultProfile.png';
  }
  onPhotoSelected(event) {
    this.contactsService.uploadProfile(this.contact.id, event.target.files[0])
    .subscribe(
      events  =>  {
        if (events.type === HttpEventType.UploadProgress) {
          this.uploadProgress = (Math.round(events.loaded / events.total * 100) + '%');
        } else if (events.type === HttpEventType.Response) {
          this.contact.profileImage = events.body;
        }
      },
    null,
    () => {
      this.uploadProgress = '0%';
      this.toasty.success({
        title: 'Success',
        msg: 'Profile Image Updated Successfuly',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
    });
  }
  onSubmit() {
    this.contact.isDisplayed = this.contactForm.controls['isdisplayed'].value;
    this.contact.birthDate = this.contactForm.controls['birthdate'].value;
    this.contactsService.updateContact(this.contact).subscribe(
      res => {
        console.log(res);
        this.toasty.success({
          title: 'Success',
          msg: 'Contact Updated Successfuly',
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
      });
  });
  }
  getContactIndex() {
    return this.contacts.findIndex(c => c.id === this.contact.id);
  }

  onChangeContact(move: string) {
    this.contactIndex = this.getContactIndex();
    console.log(this.contactIndex);
    switch (move) {
      case 'forward':
      this.contact = this.contacts[this.contactIndex + 1];
      break;
      case 'back':
      this.contact = this.contacts[this.contactIndex - 1];
      break;
    }
    this.contactIndex = this.getContactIndex();
  }
  onDeleteContact() {
    this.contactsService.deleteContact(this.contact.id).subscribe(
      contact => {
        this.toasty.info({
          title: 'Success',
          msg: `${contact.name} Deleted Successfuly`,
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
      });
      this.router.navigate(['/contacts']);
    });
  }
}
