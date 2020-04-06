import { UserModel } from '../auth/login';

export interface ShellModel {
    Language?: string;
    AppTitle?: string;
    ShowIcons?: string;
    HideIcons?: string;   
    Login?: string;
    Register?: string;
    Error?: string;
    UserModel?: UserModel;
}
