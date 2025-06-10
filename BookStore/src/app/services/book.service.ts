import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { useAuth } from '../authConfig';
import { KeysService } from './keys.service';
import { keys } from '../model/keys';
import { AuthData } from '../model/AuthData';
import { DatastoreService } from './datastore.service';
import { Book } from '../model/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private http = inject(HttpClient);
  private keyService = inject(KeysService);
  private dataStore = inject(DatastoreService);
  private url = environment.apiUrl;
  keysAuth: keys | undefined;
  authConfig: AuthData | undefined;

  constructor() {
    this.keyService.getKeys().subscribe({
      next: (keys) => {
        this.keysAuth = keys;
        this.authConfig = useAuth(this.keysAuth);
      }
    })
  }

  getAllBooks(){
    let header = new HttpHeaders().set('Content-type', 'application/json');

    header = header.append('Authorization', 'Bearer ' + this.dataStore.accessToken);
    return this.http.get<Book[]>(this.url + 'book', { headers: header })
  }
}
