import { Component, inject, OnInit } from '@angular/core';
import { BookService } from '../services/book.service';
import { useAuth } from '../authConfig';
import { AuthenticationResult } from '@azure/msal-browser';
import { KeysService } from '../services/keys.service';
import { keys } from '../model/keys';
import { AuthData } from '../model/AuthData';
import { DatastoreService } from '../services/datastore.service';
import { Book } from '../model/book';



@Component({
  selector: 'app-login-page',
  standalone: true,
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent implements OnInit {

  private bookService = inject(BookService);
  private keyService = inject(KeysService);
  private dataStore = inject(DatastoreService);
  keysAuth: keys | undefined;
  authConfig!: AuthData;
  books: Book[] | null | undefined;

  async ngOnInit() {

    this.keyService.getKeys().subscribe({
      next: (keys) => {
        this.keysAuth = keys;
        this.authConfig = useAuth(this.keysAuth);

        this.initializeAuth();
      }
    })


  }

  async initializeAuth() {
    await this.authConfig.msalInstance.initialize();

    this.authConfig.msalInstance.handleRedirectPromise().then(async (authResult: AuthenticationResult | null) => {
      const accounts = this.authConfig.msalInstance.getAllAccounts();

      if (accounts.length > 0) {
        this.authConfig.account = accounts[0];
        this.dataStore.account = this.authConfig.account;

        const response = this.authConfig.msalInstance.acquireTokenSilent({
          account: this.authConfig.account,
          scopes: ["api://899a5c65-69c8-49be-bba8-8221f576b9eb/api.read"]//this.keysAuth?.scopes!
        })
        this.authConfig.token = (await response).accessToken
        this.dataStore.accessToken = this.authConfig.token;
      }
    })
  }

  async login() {
    await this.authConfig.msalInstance.loginRedirect();
  }

  logout() {
    this.authConfig.msalInstance.logoutRedirect({
      postLogoutRedirectUri: window.location.origin
    });
  }

  getAllBooks() {
    this.bookService.getAllBooks().subscribe({
      next: (res: Book[]) => {
        this.books = res;
      },
      error: (error: any) => console.log(error)
    })
  }
}
