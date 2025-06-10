import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { keys } from '../model/keys';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class KeysService {

  constructor() { }
  private url = environment.apiUrl;
  private http = inject(HttpClient);

  getKeys(){
    return this.http.get<keys>(this.url + 'key/');
  }
}
