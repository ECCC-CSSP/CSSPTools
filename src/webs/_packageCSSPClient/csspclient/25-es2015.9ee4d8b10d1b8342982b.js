(window.webpackJsonp=window.webpackJsonp||[]).push([[25],{PSTt:function(t,e,i){"use strict";function a(){let t=[];return $localize,t.push({EnumID:1,EnumText:"en"}),t.push({EnumID:2,EnumText:"fr"}),t.push({EnumID:3,EnumText:"enAndfr"}),t.push({EnumID:4,EnumText:"es"}),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}function n(t){let e;return a().forEach(i=>{if(i.EnumID==t)return e=i.EnumText,!1}),e}i.d(e,"b",(function(){return a})),i.d(e,"a",(function(){return n}))},QRvi:function(t,e,i){"use strict";i.d(e,"a",(function(){return a}));var a=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},XzWX:function(t,e,i){"use strict";i.r(e),i.d(e,"TVFileLanguageModule",(function(){return Y}));var a=i("ofXK"),n=i("tyNb");function l(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var o=i("PSTt"),r=i("BBgV"),u=i("QRvi"),s=i("fXoL"),c=i("2Vo4"),b=i("LRne"),g=i("tk/3"),f=i("lJxs"),p=i("JIr8"),m=i("gkM4");let h=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.tvfilelanguageTextModel$=new c.a({}),this.tvfilelanguageListModel$=new c.a({}),this.tvfilelanguageGetModel$=new c.a({}),this.tvfilelanguagePutModel$=new c.a({}),this.tvfilelanguagePostModel$=new c.a({}),this.tvfilelanguageDeleteModel$=new c.a({}),l(this.tvfilelanguageTextModel$),this.tvfilelanguageTextModel$.next({Title:"Something2 for text"})}GetTVFileLanguageList(){return this.httpClientService.BeforeHttpClient(this.tvfilelanguageGetModel$),this.httpClient.get("/api/TVFileLanguage").pipe(Object(f.a)(t=>{this.httpClientService.DoSuccess(this.tvfilelanguageListModel$,this.tvfilelanguageGetModel$,t,u.a.Get,null)}),Object(p.a)(t=>Object(b.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.tvfilelanguageListModel$,this.tvfilelanguageGetModel$,t)}))))}PutTVFileLanguage(t){return this.httpClientService.BeforeHttpClient(this.tvfilelanguagePutModel$),this.httpClient.put("/api/TVFileLanguage",t,{headers:new g.d}).pipe(Object(f.a)(e=>{this.httpClientService.DoSuccess(this.tvfilelanguageListModel$,this.tvfilelanguagePutModel$,e,u.a.Put,t)}),Object(p.a)(t=>Object(b.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.tvfilelanguageListModel$,this.tvfilelanguagePutModel$,t)}))))}PostTVFileLanguage(t){return this.httpClientService.BeforeHttpClient(this.tvfilelanguagePostModel$),this.httpClient.post("/api/TVFileLanguage",t,{headers:new g.d}).pipe(Object(f.a)(e=>{this.httpClientService.DoSuccess(this.tvfilelanguageListModel$,this.tvfilelanguagePostModel$,e,u.a.Post,t)}),Object(p.a)(t=>Object(b.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.tvfilelanguageListModel$,this.tvfilelanguagePostModel$,t)}))))}DeleteTVFileLanguage(t){return this.httpClientService.BeforeHttpClient(this.tvfilelanguageDeleteModel$),this.httpClient.delete("/api/TVFileLanguage/"+t.TVFileLanguageID).pipe(Object(f.a)(e=>{this.httpClientService.DoSuccess(this.tvfilelanguageListModel$,this.tvfilelanguageDeleteModel$,e,u.a.Delete,t)}),Object(p.a)(t=>Object(b.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.tvfilelanguageListModel$,this.tvfilelanguageDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(s.Wb(g.b),s.Wb(m.a))},t.\u0275prov=s.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var d=i("Wp6s"),v=i("bTqV"),S=i("bv9b"),T=i("NFeN"),D=i("3Pt+"),I=i("kmnG"),L=i("qFsG"),R=i("d3UM"),F=i("FKr1");function C(t,e){1&t&&s.Nb(0,"mat-progress-bar",12)}function V(t,e){1&t&&s.Nb(0,"mat-progress-bar",12)}function B(t,e){1&t&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function P(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,B,3,0,"span",4),s.Rb()),2&t){const t=e.$implicit;s.Bb(2),s.Ac(s.fc(3,2,t)),s.Bb(3),s.ic("ngIf",t.required)}}function y(t,e){1&t&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function $(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,y,3,0,"span",4),s.Rb()),2&t){const t=e.$implicit;s.Bb(2),s.Ac(s.fc(3,2,t)),s.Bb(3),s.ic("ngIf",t.required)}}function E(t,e){if(1&t&&(s.Sb(0,"mat-option",13),s.zc(1),s.Rb()),2&t){const t=e.$implicit;s.ic("value",t.EnumID),s.Bb(1),s.Bc(" ",t.EnumText," ")}}function w(t,e){1&t&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function M(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,w,3,0,"span",4),s.Rb()),2&t){const t=e.$implicit;s.Bb(2),s.Ac(s.fc(3,2,t)),s.Bb(3),s.ic("ngIf",t.required)}}function z(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.Rb()),2&t){const t=e.$implicit;s.Bb(2),s.Ac(s.fc(3,1,t))}}function G(t,e){if(1&t&&(s.Sb(0,"mat-option",13),s.zc(1),s.Rb()),2&t){const t=e.$implicit;s.ic("value",t.EnumID),s.Bb(1),s.Bc(" ",t.EnumText," ")}}function x(t,e){1&t&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function N(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,x,3,0,"span",4),s.Rb()),2&t){const t=e.$implicit;s.Bb(2),s.Ac(s.fc(3,2,t)),s.Bb(3),s.ic("ngIf",t.required)}}function k(t,e){1&t&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function O(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,k,3,0,"span",4),s.Rb()),2&t){const t=e.$implicit;s.Bb(2),s.Ac(s.fc(3,2,t)),s.Bb(3),s.ic("ngIf",t.required)}}function j(t,e){1&t&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function U(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,j,3,0,"span",4),s.Rb()),2&t){const t=e.$implicit;s.Bb(2),s.Ac(s.fc(3,2,t)),s.Bb(3),s.ic("ngIf",t.required)}}let q=(()=>{class t{constructor(t,e){this.tvfilelanguageService=t,this.fb=e,this.tvfilelanguage=null,this.httpClientCommand=u.a.Put}GetPut(){return this.httpClientCommand==u.a.Put}PutTVFileLanguage(t){this.sub=this.tvfilelanguageService.PutTVFileLanguage(t).subscribe()}PostTVFileLanguage(t){this.sub=this.tvfilelanguageService.PostTVFileLanguage(t).subscribe()}ngOnInit(){this.languageList=Object(o.b)(),this.translationStatusList=Object(r.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.tvfilelanguage){let e=this.fb.group({TVFileLanguageID:[{value:t===u.a.Post?0:this.tvfilelanguage.TVFileLanguageID,disabled:!1},[D.p.required]],TVFileID:[{value:this.tvfilelanguage.TVFileID,disabled:!1},[D.p.required]],Language:[{value:this.tvfilelanguage.Language,disabled:!1},[D.p.required]],FileDescription:[{value:this.tvfilelanguage.FileDescription,disabled:!1}],TranslationStatus:[{value:this.tvfilelanguage.TranslationStatus,disabled:!1},[D.p.required]],LastUpdateDate_UTC:[{value:this.tvfilelanguage.LastUpdateDate_UTC,disabled:!1},[D.p.required]],LastUpdateContactTVItemID:[{value:this.tvfilelanguage.LastUpdateContactTVItemID,disabled:!1},[D.p.required]]});this.tvfilelanguageFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(s.Mb(h),s.Mb(D.d))},t.\u0275cmp=s.Gb({type:t,selectors:[["app-tvfilelanguage-edit"]],inputs:{tvfilelanguage:"tvfilelanguage",httpClientCommand:"httpClientCommand"},decls:47,vars:13,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TVFileLanguageID"],[4,"ngIf"],["matInput","","type","number","formControlName","TVFileID"],["formControlName","Language"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","FileDescription"],["formControlName","TranslationStatus"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(s.Sb(0,"form",0),s.Zb("ngSubmit",(function(){return e.GetPut()?e.PutTVFileLanguage(e.tvfilelanguageFormEdit.value):e.PostTVFileLanguage(e.tvfilelanguageFormEdit.value)})),s.Sb(1,"h3"),s.zc(2," TVFileLanguage "),s.Sb(3,"button",1),s.Sb(4,"span"),s.zc(5),s.Rb(),s.Rb(),s.yc(6,C,1,0,"mat-progress-bar",2),s.yc(7,V,1,0,"mat-progress-bar",2),s.Rb(),s.Sb(8,"p"),s.Sb(9,"mat-form-field"),s.Sb(10,"mat-label"),s.zc(11,"TVFileLanguageID"),s.Rb(),s.Nb(12,"input",3),s.yc(13,P,6,4,"mat-error",4),s.Rb(),s.Sb(14,"mat-form-field"),s.Sb(15,"mat-label"),s.zc(16,"TVFileID"),s.Rb(),s.Nb(17,"input",5),s.yc(18,$,6,4,"mat-error",4),s.Rb(),s.Sb(19,"mat-form-field"),s.Sb(20,"mat-label"),s.zc(21,"Language"),s.Rb(),s.Sb(22,"mat-select",6),s.yc(23,E,2,2,"mat-option",7),s.Rb(),s.yc(24,M,6,4,"mat-error",4),s.Rb(),s.Sb(25,"mat-form-field"),s.Sb(26,"mat-label"),s.zc(27,"FileDescription"),s.Rb(),s.Nb(28,"input",8),s.yc(29,z,5,3,"mat-error",4),s.Rb(),s.Rb(),s.Sb(30,"p"),s.Sb(31,"mat-form-field"),s.Sb(32,"mat-label"),s.zc(33,"TranslationStatus"),s.Rb(),s.Sb(34,"mat-select",9),s.yc(35,G,2,2,"mat-option",7),s.Rb(),s.yc(36,N,6,4,"mat-error",4),s.Rb(),s.Sb(37,"mat-form-field"),s.Sb(38,"mat-label"),s.zc(39,"LastUpdateDate_UTC"),s.Rb(),s.Nb(40,"input",10),s.yc(41,O,6,4,"mat-error",4),s.Rb(),s.Sb(42,"mat-form-field"),s.Sb(43,"mat-label"),s.zc(44,"LastUpdateContactTVItemID"),s.Rb(),s.Nb(45,"input",11),s.yc(46,U,6,4,"mat-error",4),s.Rb(),s.Rb(),s.Rb()),2&t&&(s.ic("formGroup",e.tvfilelanguageFormEdit),s.Bb(5),s.Bc("",e.GetPut()?"Put":"Post"," TVFileLanguage"),s.Bb(1),s.ic("ngIf",e.tvfilelanguageService.tvfilelanguagePutModel$.getValue().Working),s.Bb(1),s.ic("ngIf",e.tvfilelanguageService.tvfilelanguagePostModel$.getValue().Working),s.Bb(6),s.ic("ngIf",e.tvfilelanguageFormEdit.controls.TVFileLanguageID.errors),s.Bb(5),s.ic("ngIf",e.tvfilelanguageFormEdit.controls.TVFileID.errors),s.Bb(5),s.ic("ngForOf",e.languageList),s.Bb(1),s.ic("ngIf",e.tvfilelanguageFormEdit.controls.Language.errors),s.Bb(5),s.ic("ngIf",e.tvfilelanguageFormEdit.controls.FileDescription.errors),s.Bb(6),s.ic("ngForOf",e.translationStatusList),s.Bb(1),s.ic("ngIf",e.tvfilelanguageFormEdit.controls.TranslationStatus.errors),s.Bb(5),s.ic("ngIf",e.tvfilelanguageFormEdit.controls.LastUpdateDate_UTC.errors),s.Bb(5),s.ic("ngIf",e.tvfilelanguageFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[D.q,D.l,D.f,v.b,a.l,I.c,I.f,L.b,D.n,D.c,D.k,D.e,R.a,a.k,S.a,I.b,F.n],pipes:[a.f],styles:[""],changeDetection:0}),t})();function W(t,e){1&t&&s.Nb(0,"mat-progress-bar",4)}function A(t,e){1&t&&s.Nb(0,"mat-progress-bar",4)}function _(t,e){if(1&t&&(s.Sb(0,"p"),s.Nb(1,"app-tvfilelanguage-edit",8),s.Rb()),2&t){const t=s.dc().$implicit,e=s.dc(2);s.Bb(1),s.ic("tvfilelanguage",t)("httpClientCommand",e.GetPutEnum())}}function J(t,e){if(1&t&&(s.Sb(0,"p"),s.Nb(1,"app-tvfilelanguage-edit",8),s.Rb()),2&t){const t=s.dc().$implicit,e=s.dc(2);s.Bb(1),s.ic("tvfilelanguage",t)("httpClientCommand",e.GetPostEnum())}}function X(t,e){if(1&t){const t=s.Tb();s.Sb(0,"div"),s.Sb(1,"p"),s.Sb(2,"button",6),s.Zb("click",(function(){s.qc(t);const i=e.$implicit;return s.dc(2).DeleteTVFileLanguage(i)})),s.Sb(3,"span"),s.zc(4),s.Rb(),s.Sb(5,"mat-icon"),s.zc(6,"delete"),s.Rb(),s.Rb(),s.zc(7,"\xa0\xa0\xa0 "),s.Sb(8,"button",7),s.Zb("click",(function(){s.qc(t);const i=e.$implicit;return s.dc(2).ShowPut(i)})),s.Sb(9,"span"),s.zc(10,"Show Put"),s.Rb(),s.Rb(),s.zc(11,"\xa0\xa0 "),s.Sb(12,"button",7),s.Zb("click",(function(){s.qc(t);const i=e.$implicit;return s.dc(2).ShowPost(i)})),s.Sb(13,"span"),s.zc(14,"Show Post"),s.Rb(),s.Rb(),s.zc(15,"\xa0\xa0 "),s.yc(16,A,1,0,"mat-progress-bar",0),s.Rb(),s.yc(17,_,2,2,"p",2),s.yc(18,J,2,2,"p",2),s.Sb(19,"blockquote"),s.Sb(20,"p"),s.Sb(21,"span"),s.zc(22),s.Rb(),s.Sb(23,"span"),s.zc(24),s.Rb(),s.Sb(25,"span"),s.zc(26),s.Rb(),s.Sb(27,"span"),s.zc(28),s.Rb(),s.Rb(),s.Sb(29,"p"),s.Sb(30,"span"),s.zc(31),s.Rb(),s.Sb(32,"span"),s.zc(33),s.Rb(),s.Sb(34,"span"),s.zc(35),s.Rb(),s.Rb(),s.Rb(),s.Rb()}if(2&t){const t=e.$implicit,i=s.dc(2);s.Bb(4),s.Bc("Delete TVFileLanguageID [",t.TVFileLanguageID,"]\xa0\xa0\xa0"),s.Bb(4),s.ic("color",i.GetPutButtonColor(t)),s.Bb(4),s.ic("color",i.GetPostButtonColor(t)),s.Bb(4),s.ic("ngIf",i.tvfilelanguageService.tvfilelanguageDeleteModel$.getValue().Working),s.Bb(1),s.ic("ngIf",i.IDToShow===t.TVFileLanguageID&&i.showType===i.GetPutEnum()),s.Bb(1),s.ic("ngIf",i.IDToShow===t.TVFileLanguageID&&i.showType===i.GetPostEnum()),s.Bb(4),s.Bc("TVFileLanguageID: [",t.TVFileLanguageID,"]"),s.Bb(2),s.Bc(" --- TVFileID: [",t.TVFileID,"]"),s.Bb(2),s.Bc(" --- Language: [",i.GetLanguageEnumText(t.Language),"]"),s.Bb(2),s.Bc(" --- FileDescription: [",t.FileDescription,"]"),s.Bb(3),s.Bc("TranslationStatus: [",i.GetTranslationStatusEnumText(t.TranslationStatus),"]"),s.Bb(2),s.Bc(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),s.Bb(2),s.Bc(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function H(t,e){if(1&t&&(s.Sb(0,"div"),s.yc(1,X,36,13,"div",5),s.Rb()),2&t){const t=s.dc();s.Bb(1),s.ic("ngForOf",t.tvfilelanguageService.tvfilelanguageListModel$.getValue())}}const Z=[{path:"",component:(()=>{class t{constructor(t,e,i){this.tvfilelanguageService=t,this.router=e,this.httpClientService=i,this.showType=null,i.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.TVFileLanguageID&&this.showType===u.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.TVFileLanguageID&&this.showType===u.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.TVFileLanguageID&&this.showType===u.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TVFileLanguageID,this.showType=u.a.Put)}ShowPost(t){this.IDToShow===t.TVFileLanguageID&&this.showType===u.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TVFileLanguageID,this.showType=u.a.Post)}GetPutEnum(){return u.a.Put}GetPostEnum(){return u.a.Post}GetTVFileLanguageList(){this.sub=this.tvfilelanguageService.GetTVFileLanguageList().subscribe()}DeleteTVFileLanguage(t){this.sub=this.tvfilelanguageService.DeleteTVFileLanguage(t).subscribe()}GetLanguageEnumText(t){return Object(o.a)(t)}GetTranslationStatusEnumText(t){return Object(r.a)(t)}ngOnInit(){l(this.tvfilelanguageService.tvfilelanguageTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(s.Mb(h),s.Mb(n.b),s.Mb(m.a))},t.\u0275cmp=s.Gb({type:t,selectors:[["app-tvfilelanguage"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tvfilelanguage","httpClientCommand"]],template:function(t,e){var i,a;1&t&&(s.yc(0,W,1,0,"mat-progress-bar",0),s.Sb(1,"mat-card"),s.Sb(2,"mat-card-header"),s.Sb(3,"mat-card-title"),s.zc(4," TVFileLanguage works! "),s.Sb(5,"button",1),s.Zb("click",(function(){return e.GetTVFileLanguageList()})),s.Sb(6,"span"),s.zc(7,"Get TVFileLanguage"),s.Rb(),s.Rb(),s.Rb(),s.Sb(8,"mat-card-subtitle"),s.zc(9),s.Rb(),s.Rb(),s.Sb(10,"mat-card-content"),s.yc(11,H,2,1,"div",2),s.Rb(),s.Sb(12,"mat-card-actions"),s.Sb(13,"button",3),s.zc(14,"Allo"),s.Rb(),s.Rb(),s.Rb()),2&t&&(s.ic("ngIf",null==(i=e.tvfilelanguageService.tvfilelanguageGetModel$.getValue())?null:i.Working),s.Bb(9),s.Ac(e.tvfilelanguageService.tvfilelanguageTextModel$.getValue().Title),s.Bb(2),s.ic("ngIf",null==(a=e.tvfilelanguageService.tvfilelanguageListModel$.getValue())?null:a.length))},directives:[a.l,d.a,d.d,d.g,v.b,d.f,d.c,d.b,S.a,a.k,T.a,q],styles:[""],changeDetection:0}),t})(),canActivate:[i("auXs").a]}];let K=(()=>{class t{}return t.\u0275mod=s.Kb({type:t}),t.\u0275inj=s.Jb({factory:function(e){return new(e||t)},imports:[[n.e.forChild(Z)],n.e]}),t})();var Q=i("B+Mi");let Y=(()=>{class t{}return t.\u0275mod=s.Kb({type:t}),t.\u0275inj=s.Jb({factory:function(e){return new(e||t)},imports:[[a.c,n.e,K,Q.a,D.g,D.o]]}),t})()},gkM4:function(t,e,i){"use strict";i.d(e,"a",(function(){return o}));var a=i("QRvi"),n=i("fXoL"),l=i("tyNb");let o=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,i,n,l){if(n===a.a.Get&&t.next(i),n===a.a.Put&&(t.getValue()[0]=i),n===a.a.Post&&t.getValue().push(i),n===a.a.Delete){const e=t.getValue().indexOf(l);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,i,n,l){n===a.a.Get&&t.next(i),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(n.Wb(l.b))},t.\u0275prov=n.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);