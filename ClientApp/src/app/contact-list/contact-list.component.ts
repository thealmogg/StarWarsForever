import { ContactsService } from './../services/contacts.service';
import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: Contact[];
  constructor(private contactsService: ContactsService) { }

  ngOnInit() {
    this.contactsService.getContacts().subscribe(contacts => this.contacts = contacts);
  }

  onCheckedDisplay(event, contact: Contact) {
    contact.isDisplayed = event.target.checked;
    this.contactsService.updateContact(contact)
    .subscribe(
    res => console.log(res));
  }

}
