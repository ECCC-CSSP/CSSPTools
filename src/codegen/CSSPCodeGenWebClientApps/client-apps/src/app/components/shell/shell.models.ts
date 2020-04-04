export interface ShellModel {
    isEnglish?: boolean;
    appTitle?: string;
    menuTitle?: string;
    currentButtonSelect?: ButtonTypeOptions;
    leftIconsVisible?: boolean;
    showIcons?: string;
    hideIcons?: string;    
}

export type ButtonTypeOptions = 'First' | 'Second' | 'Third';