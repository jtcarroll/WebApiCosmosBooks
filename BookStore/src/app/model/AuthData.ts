import {AccountInfo, PublicClientApplication} from "@azure/msal-browser"

export interface AuthData {
    account: AccountInfo | null,
    msalInstance: PublicClientApplication,
    token: string
}