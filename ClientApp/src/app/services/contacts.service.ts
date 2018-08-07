import { ProfileImage } from './../models/profileimage.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent } from '../../../node_modules/@angular/common/http';
import { Contact } from '../models/contact.model';
import { Observable } from '../../../node_modules/rxjs';

@Injectable()
export class ContactsService {
  private readonly contactsEndpoint: string = '/api/contacts/';

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.contactsEndpoint, {
      responseType: 'json'
    });
  }

  getContact(contactId: number): Observable<Contact> {
    return this.http.get<Contact>(this.contactsEndpoint + contactId, {
      responseType: 'json'
    });
  }
  createContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(this.contactsEndpoint, contact);
  }
  uploadProfile(contactId: number, photo: File): Observable<HttpEvent<ProfileImage>> {
    const formData = new FormData();
    formData.append('file', photo, photo.name);
    return this.http.post<ProfileImage>(this.contactsEndpoint + contactId + '/image', formData, {
      responseType: 'json',
      reportProgress: true,
      observe: 'events'
    });
  }
  updateContact(contact: Contact) {
    return this.http.put<Contact>(this.contactsEndpoint + contact.id, contact, {
      responseType: 'json'
    });
  }
  deleteContact(contactId: number) {
    return this.http.delete<Contact>(this.contactsEndpoint + contactId, {
      responseType: 'json'
    });
  }
}
