import { ToastyService } from 'ng2-toasty';
import { ContactsService } from './../services/contacts.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';

@Component({
  selector: 'app-contact-form-new',
  templateUrl: './contact-form-new.component.html',
  styleUrls: ['./contact-form-new.component.css']
})
export class ContactFormNewComponent implements OnInit {
  contactForm: FormGroup;
  contact: Contact;
  constructor(private contactsService: ContactsService,
            private toasty: ToastyService) { }

  ngOnInit() {
    this.contactForm = new FormGroup({
      'name': new FormControl(null, [Validators.required]),
      'last': new FormControl(null, [Validators.required]),
      'birthdate': new FormControl(null),
      'isdisplayed': new FormControl(false, [Validators.required])
    });
  }

  onSubmit() {
    this.contactsService.createContact(this.contactForm.value)
    .subscribe(
      contact => {
        this.toasty.success({
          title: 'Welcome, ' + this.contactForm.value.name,
          msg: 'Contact Created Successfuly',
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
      });      }
    );
  }
}
