import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DatastoreService {

  constructor() { }

  private _accessToken: string | null = null;
  private _account: any = null;

  // Token Getter & Setter
  get accessToken(): string | null {
    return this._accessToken;
  }

  set accessToken(token: string | null) {
    this._accessToken = token;
  }

  // Account Getter & Setter
  get account(): any {
    return this._account;
  }

  set account(account: any) {
    this._account = account;
  }

  // Optionally, add more shared data methods
  clear() {
    this._accessToken = null;
    this._account = null;
  }
}
