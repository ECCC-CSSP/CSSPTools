import { HttpRequestModel } from 'src/app/models/http.model';

export interface ShellModel extends HttpRequestModel {
    Language?: string;
    AppTitle?: string;
    ShowIcons?: string;
    HideIcons?: string;   
    Login?: string;
    Register?: string;
    Logout?: string;
}
