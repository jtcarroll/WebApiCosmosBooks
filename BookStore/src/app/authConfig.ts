import {AccountInfo, PublicClientApplication} from "@azure/msal-browser"
import { keys } from "./model/keys";
import { AuthData } from './model/AuthData';

export function useAuth(keys: keys) {
    const authConfig = {
        auth: {
            clientId: keys.clientId,
            authority: 'https://login.microsoftonline.com/' + keys.tenantId
        }
    };

    const data: AuthData = {
        account: null as AccountInfo | null,
        msalInstance: new PublicClientApplication(authConfig),
        token: ""
        };

    return data;
}