(window.webpackJsonp=window.webpackJsonp||[]).push([[12],{PSTt:function(t,a,e){"use strict";function n(){let t=[];return $localize,t.push({EnumID:1,EnumText:"en"}),t.push({EnumID:2,EnumText:"fr"}),t.push({EnumID:3,EnumText:"enAndfr"}),t.push({EnumID:4,EnumText:"es"}),t.sort((t,a)=>t.EnumText.localeCompare(a.EnumText))}function s(t){let a;return n().forEach(e=>{if(e.EnumID==t)return a=e.EnumText,!1}),a}e.d(a,"b",(function(){return n})),e.d(a,"a",(function(){return s}))},QRvi:function(t,a,e){"use strict";e.d(a,"a",(function(){return n}));var n=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,a,e){"use strict";e.d(a,"a",(function(){return p}));var n=e("QRvi"),s=e("fXoL"),r=e("tyNb");let p=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,a,e){t.next(null),a.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,a,e){t.next(null),a.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,a,e,s,r){if(s===n.a.Get&&t.next(e),s===n.a.Put&&(t.getValue()[0]=e),s===n.a.Post&&t.getValue().push(e),s===n.a.Delete){const a=t.getValue().indexOf(r);t.getValue().splice(a,1)}t.next(t.getValue()),a.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,a,e,s,r){s===n.a.Get&&t.next(e),t.next(t.getValue()),a.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(a){return new(a||t)(s.Wb(r.b))},t.\u0275prov=s.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()},jcPN:function(t,a,e){"use strict";e.r(a),e.d(a,"AppTaskLanguageModule",(function(){return et}));var n=e("ofXK"),s=e("tyNb");function r(t){let a={Title:"The title"};"fr-CA"===$localize.locale&&(a.Title="Le Titre"),t.next(a)}var p=e("PSTt"),o=e("BBgV"),i=e("QRvi"),u=e("fXoL"),c=e("2Vo4"),l=e("LRne"),b=e("tk/3"),g=e("lJxs"),h=e("JIr8"),m=e("gkM4");let d=(()=>{class t{constructor(t,a){this.httpClient=t,this.httpClientService=a,this.apptasklanguageTextModel$=new c.a({}),this.apptasklanguageListModel$=new c.a({}),this.apptasklanguageGetModel$=new c.a({}),this.apptasklanguagePutModel$=new c.a({}),this.apptasklanguagePostModel$=new c.a({}),this.apptasklanguageDeleteModel$=new c.a({}),r(this.apptasklanguageTextModel$),this.apptasklanguageTextModel$.next({Title:"Something2 for text"})}GetAppTaskLanguageList(){return this.httpClientService.BeforeHttpClient(this.apptasklanguageGetModel$),this.httpClient.get("/api/AppTaskLanguage").pipe(Object(g.a)(t=>{this.httpClientService.DoSuccess(this.apptasklanguageListModel$,this.apptasklanguageGetModel$,t,i.a.Get,null)}),Object(h.a)(t=>Object(l.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.apptasklanguageListModel$,this.apptasklanguageGetModel$,t)}))))}PutAppTaskLanguage(t){return this.httpClientService.BeforeHttpClient(this.apptasklanguagePutModel$),this.httpClient.put("/api/AppTaskLanguage",t,{headers:new b.d}).pipe(Object(g.a)(a=>{this.httpClientService.DoSuccess(this.apptasklanguageListModel$,this.apptasklanguagePutModel$,a,i.a.Put,t)}),Object(h.a)(t=>Object(l.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.apptasklanguageListModel$,this.apptasklanguagePutModel$,t)}))))}PostAppTaskLanguage(t){return this.httpClientService.BeforeHttpClient(this.apptasklanguagePostModel$),this.httpClient.post("/api/AppTaskLanguage",t,{headers:new b.d}).pipe(Object(g.a)(a=>{this.httpClientService.DoSuccess(this.apptasklanguageListModel$,this.apptasklanguagePostModel$,a,i.a.Post,t)}),Object(h.a)(t=>Object(l.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.apptasklanguageListModel$,this.apptasklanguagePostModel$,t)}))))}DeleteAppTaskLanguage(t){return this.httpClientService.BeforeHttpClient(this.apptasklanguageDeleteModel$),this.httpClient.delete("/api/AppTaskLanguage/"+t.AppTaskLanguageID).pipe(Object(g.a)(a=>{this.httpClientService.DoSuccess(this.apptasklanguageListModel$,this.apptasklanguageDeleteModel$,a,i.a.Delete,t)}),Object(h.a)(t=>Object(l.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.apptasklanguageListModel$,this.apptasklanguageDeleteModel$,t)}))))}}return t.\u0275fac=function(a){return new(a||t)(u.Wb(b.b),u.Wb(m.a))},t.\u0275prov=u.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var k=e("Wp6s"),S=e("bTqV"),f=e("bv9b"),T=e("NFeN"),I=e("3Pt+"),R=e("kmnG"),L=e("qFsG"),D=e("d3UM"),x=e("FKr1");function y(t,a){1&t&&u.Nb(0,"mat-progress-bar",13)}function C(t,a){1&t&&u.Nb(0,"mat-progress-bar",13)}function v(t,a){1&t&&(u.Sb(0,"span"),u.yc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function A(t,a){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.yc(2),u.dc(3,"json"),u.Nb(4,"br"),u.Rb(),u.xc(5,v,3,0,"span",4),u.Rb()),2&t){const t=a.$implicit;u.Bb(2),u.zc(u.ec(3,2,t)),u.Bb(3),u.hc("ngIf",t.required)}}function B(t,a){1&t&&(u.Sb(0,"span"),u.yc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function P(t,a){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.yc(2),u.dc(3,"json"),u.Nb(4,"br"),u.Rb(),u.xc(5,B,3,0,"span",4),u.Rb()),2&t){const t=a.$implicit;u.Bb(2),u.zc(u.ec(3,2,t)),u.Bb(3),u.hc("ngIf",t.required)}}function E(t,a){if(1&t&&(u.Sb(0,"mat-option",14),u.yc(1),u.Rb()),2&t){const t=a.$implicit;u.hc("value",t.EnumID),u.Bb(1),u.Ac(" ",t.EnumText," ")}}function $(t,a){1&t&&(u.Sb(0,"span"),u.yc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function w(t,a){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.yc(2),u.dc(3,"json"),u.Nb(4,"br"),u.Rb(),u.xc(5,$,3,0,"span",4),u.Rb()),2&t){const t=a.$implicit;u.Bb(2),u.zc(u.ec(3,2,t)),u.Bb(3),u.hc("ngIf",t.required)}}function M(t,a){1&t&&(u.Sb(0,"span"),u.yc(1,"MaxLength - 250"),u.Nb(2,"br"),u.Rb())}function N(t,a){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.yc(2),u.dc(3,"json"),u.Nb(4,"br"),u.Rb(),u.xc(5,M,3,0,"span",4),u.Rb()),2&t){const t=a.$implicit;u.Bb(2),u.zc(u.ec(3,2,t)),u.Bb(3),u.hc("ngIf",t.maxlength)}}function G(t,a){1&t&&(u.Sb(0,"span"),u.yc(1,"MaxLength - 250"),u.Nb(2,"br"),u.Rb())}function j(t,a){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.yc(2),u.dc(3,"json"),u.Nb(4,"br"),u.Rb(),u.xc(5,G,3,0,"span",4),u.Rb()),2&t){const t=a.$implicit;u.Bb(2),u.zc(u.ec(3,2,t)),u.Bb(3),u.hc("ngIf",t.maxlength)}}function O(t,a){if(1&t&&(u.Sb(0,"mat-option",14),u.yc(1),u.Rb()),2&t){const t=a.$implicit;u.hc("value",t.EnumID),u.Bb(1),u.Ac(" ",t.EnumText," ")}}function F(t,a){1&t&&(u.Sb(0,"span"),u.yc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function U(t,a){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.yc(2),u.dc(3,"json"),u.Nb(4,"br"),u.Rb(),u.xc(5,F,3,0,"span",4),u.Rb()),2&t){const t=a.$implicit;u.Bb(2),u.zc(u.ec(3,2,t)),u.Bb(3),u.hc("ngIf",t.required)}}function V(t,a){1&t&&(u.Sb(0,"span"),u.yc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function q(t,a){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.yc(2),u.dc(3,"json"),u.Nb(4,"br"),u.Rb(),u.xc(5,V,3,0,"span",4),u.Rb()),2&t){const t=a.$implicit;u.Bb(2),u.zc(u.ec(3,2,t)),u.Bb(3),u.hc("ngIf",t.required)}}function W(t,a){1&t&&(u.Sb(0,"span"),u.yc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function z(t,a){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.yc(2),u.dc(3,"json"),u.Nb(4,"br"),u.Rb(),u.xc(5,W,3,0,"span",4),u.Rb()),2&t){const t=a.$implicit;u.Bb(2),u.zc(u.ec(3,2,t)),u.Bb(3),u.hc("ngIf",t.required)}}let _=(()=>{class t{constructor(t,a){this.apptasklanguageService=t,this.fb=a,this.apptasklanguage=null,this.httpClientCommand=i.a.Put}GetPut(){return this.httpClientCommand==i.a.Put}PutAppTaskLanguage(t){this.sub=this.apptasklanguageService.PutAppTaskLanguage(t).subscribe()}PostAppTaskLanguage(t){this.sub=this.apptasklanguageService.PostAppTaskLanguage(t).subscribe()}ngOnInit(){this.languageList=Object(p.b)(),this.translationStatusList=Object(o.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.apptasklanguage){let a=this.fb.group({AppTaskLanguageID:[{value:t===i.a.Post?0:this.apptasklanguage.AppTaskLanguageID,disabled:!1},[I.p.required]],AppTaskID:[{value:this.apptasklanguage.AppTaskID,disabled:!1},[I.p.required]],Language:[{value:this.apptasklanguage.Language,disabled:!1},[I.p.required]],StatusText:[{value:this.apptasklanguage.StatusText,disabled:!1},[I.p.maxLength(250)]],ErrorText:[{value:this.apptasklanguage.ErrorText,disabled:!1},[I.p.maxLength(250)]],TranslationStatus:[{value:this.apptasklanguage.TranslationStatus,disabled:!1},[I.p.required]],LastUpdateDate_UTC:[{value:this.apptasklanguage.LastUpdateDate_UTC,disabled:!1},[I.p.required]],LastUpdateContactTVItemID:[{value:this.apptasklanguage.LastUpdateContactTVItemID,disabled:!1},[I.p.required]]});this.apptasklanguageFormEdit=a}}}return t.\u0275fac=function(a){return new(a||t)(u.Mb(d),u.Mb(I.d))},t.\u0275cmp=u.Gb({type:t,selectors:[["app-apptasklanguage-edit"]],inputs:{apptasklanguage:"apptasklanguage",httpClientCommand:"httpClientCommand"},decls:52,vars:14,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","AppTaskLanguageID"],[4,"ngIf"],["matInput","","type","number","formControlName","AppTaskID"],["formControlName","Language"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","StatusText"],["matInput","","type","text","formControlName","ErrorText"],["formControlName","TranslationStatus"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,a){1&t&&(u.Sb(0,"form",0),u.Yb("ngSubmit",(function(){return a.GetPut()?a.PutAppTaskLanguage(a.apptasklanguageFormEdit.value):a.PostAppTaskLanguage(a.apptasklanguageFormEdit.value)})),u.Sb(1,"h3"),u.yc(2," AppTaskLanguage "),u.Sb(3,"button",1),u.Sb(4,"span"),u.yc(5),u.Rb(),u.Rb(),u.xc(6,y,1,0,"mat-progress-bar",2),u.xc(7,C,1,0,"mat-progress-bar",2),u.Rb(),u.Sb(8,"p"),u.Sb(9,"mat-form-field"),u.Sb(10,"mat-label"),u.yc(11,"AppTaskLanguageID"),u.Rb(),u.Nb(12,"input",3),u.xc(13,A,6,4,"mat-error",4),u.Rb(),u.Sb(14,"mat-form-field"),u.Sb(15,"mat-label"),u.yc(16,"AppTaskID"),u.Rb(),u.Nb(17,"input",5),u.xc(18,P,6,4,"mat-error",4),u.Rb(),u.Sb(19,"mat-form-field"),u.Sb(20,"mat-label"),u.yc(21,"Language"),u.Rb(),u.Sb(22,"mat-select",6),u.xc(23,E,2,2,"mat-option",7),u.Rb(),u.xc(24,w,6,4,"mat-error",4),u.Rb(),u.Sb(25,"mat-form-field"),u.Sb(26,"mat-label"),u.yc(27,"StatusText"),u.Rb(),u.Nb(28,"input",8),u.xc(29,N,6,4,"mat-error",4),u.Rb(),u.Rb(),u.Sb(30,"p"),u.Sb(31,"mat-form-field"),u.Sb(32,"mat-label"),u.yc(33,"ErrorText"),u.Rb(),u.Nb(34,"input",9),u.xc(35,j,6,4,"mat-error",4),u.Rb(),u.Sb(36,"mat-form-field"),u.Sb(37,"mat-label"),u.yc(38,"TranslationStatus"),u.Rb(),u.Sb(39,"mat-select",10),u.xc(40,O,2,2,"mat-option",7),u.Rb(),u.xc(41,U,6,4,"mat-error",4),u.Rb(),u.Sb(42,"mat-form-field"),u.Sb(43,"mat-label"),u.yc(44,"LastUpdateDate_UTC"),u.Rb(),u.Nb(45,"input",11),u.xc(46,q,6,4,"mat-error",4),u.Rb(),u.Sb(47,"mat-form-field"),u.Sb(48,"mat-label"),u.yc(49,"LastUpdateContactTVItemID"),u.Rb(),u.Nb(50,"input",12),u.xc(51,z,6,4,"mat-error",4),u.Rb(),u.Rb(),u.Rb()),2&t&&(u.hc("formGroup",a.apptasklanguageFormEdit),u.Bb(5),u.Ac("",a.GetPut()?"Put":"Post"," AppTaskLanguage"),u.Bb(1),u.hc("ngIf",a.apptasklanguageService.apptasklanguagePutModel$.getValue().Working),u.Bb(1),u.hc("ngIf",a.apptasklanguageService.apptasklanguagePostModel$.getValue().Working),u.Bb(6),u.hc("ngIf",a.apptasklanguageFormEdit.controls.AppTaskLanguageID.errors),u.Bb(5),u.hc("ngIf",a.apptasklanguageFormEdit.controls.AppTaskID.errors),u.Bb(5),u.hc("ngForOf",a.languageList),u.Bb(1),u.hc("ngIf",a.apptasklanguageFormEdit.controls.Language.errors),u.Bb(5),u.hc("ngIf",a.apptasklanguageFormEdit.controls.StatusText.errors),u.Bb(6),u.hc("ngIf",a.apptasklanguageFormEdit.controls.ErrorText.errors),u.Bb(5),u.hc("ngForOf",a.translationStatusList),u.Bb(1),u.hc("ngIf",a.apptasklanguageFormEdit.controls.TranslationStatus.errors),u.Bb(5),u.hc("ngIf",a.apptasklanguageFormEdit.controls.LastUpdateDate_UTC.errors),u.Bb(5),u.hc("ngIf",a.apptasklanguageFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[I.q,I.l,I.f,S.b,n.l,R.c,R.f,L.b,I.n,I.c,I.k,I.e,D.a,n.k,f.a,R.b,x.n],pipes:[n.f],styles:[""],changeDetection:0}),t})();function J(t,a){1&t&&u.Nb(0,"mat-progress-bar",4)}function H(t,a){1&t&&u.Nb(0,"mat-progress-bar",4)}function Y(t,a){if(1&t&&(u.Sb(0,"p"),u.Nb(1,"app-apptasklanguage-edit",8),u.Rb()),2&t){const t=u.cc().$implicit,a=u.cc(2);u.Bb(1),u.hc("apptasklanguage",t)("httpClientCommand",a.GetPutEnum())}}function K(t,a){if(1&t&&(u.Sb(0,"p"),u.Nb(1,"app-apptasklanguage-edit",8),u.Rb()),2&t){const t=u.cc().$implicit,a=u.cc(2);u.Bb(1),u.hc("apptasklanguage",t)("httpClientCommand",a.GetPostEnum())}}function X(t,a){if(1&t){const t=u.Tb();u.Sb(0,"div"),u.Sb(1,"p"),u.Sb(2,"button",6),u.Yb("click",(function(){u.pc(t);const e=a.$implicit;return u.cc(2).DeleteAppTaskLanguage(e)})),u.Sb(3,"span"),u.yc(4),u.Rb(),u.Sb(5,"mat-icon"),u.yc(6,"delete"),u.Rb(),u.Rb(),u.yc(7,"\xa0\xa0\xa0 "),u.Sb(8,"button",7),u.Yb("click",(function(){u.pc(t);const e=a.$implicit;return u.cc(2).ShowPut(e)})),u.Sb(9,"span"),u.yc(10,"Show Put"),u.Rb(),u.Rb(),u.yc(11,"\xa0\xa0 "),u.Sb(12,"button",7),u.Yb("click",(function(){u.pc(t);const e=a.$implicit;return u.cc(2).ShowPost(e)})),u.Sb(13,"span"),u.yc(14,"Show Post"),u.Rb(),u.Rb(),u.yc(15,"\xa0\xa0 "),u.xc(16,H,1,0,"mat-progress-bar",0),u.Rb(),u.xc(17,Y,2,2,"p",2),u.xc(18,K,2,2,"p",2),u.Sb(19,"blockquote"),u.Sb(20,"p"),u.Sb(21,"span"),u.yc(22),u.Rb(),u.Sb(23,"span"),u.yc(24),u.Rb(),u.Sb(25,"span"),u.yc(26),u.Rb(),u.Sb(27,"span"),u.yc(28),u.Rb(),u.Rb(),u.Sb(29,"p"),u.Sb(30,"span"),u.yc(31),u.Rb(),u.Sb(32,"span"),u.yc(33),u.Rb(),u.Sb(34,"span"),u.yc(35),u.Rb(),u.Sb(36,"span"),u.yc(37),u.Rb(),u.Rb(),u.Rb(),u.Rb()}if(2&t){const t=a.$implicit,e=u.cc(2);u.Bb(4),u.Ac("Delete AppTaskLanguageID [",t.AppTaskLanguageID,"]\xa0\xa0\xa0"),u.Bb(4),u.hc("color",e.GetPutButtonColor(t)),u.Bb(4),u.hc("color",e.GetPostButtonColor(t)),u.Bb(4),u.hc("ngIf",e.apptasklanguageService.apptasklanguageDeleteModel$.getValue().Working),u.Bb(1),u.hc("ngIf",e.IDToShow===t.AppTaskLanguageID&&e.showType===e.GetPutEnum()),u.Bb(1),u.hc("ngIf",e.IDToShow===t.AppTaskLanguageID&&e.showType===e.GetPostEnum()),u.Bb(4),u.Ac("AppTaskLanguageID: [",t.AppTaskLanguageID,"]"),u.Bb(2),u.Ac(" --- AppTaskID: [",t.AppTaskID,"]"),u.Bb(2),u.Ac(" --- Language: [",e.GetLanguageEnumText(t.Language),"]"),u.Bb(2),u.Ac(" --- StatusText: [",t.StatusText,"]"),u.Bb(3),u.Ac("ErrorText: [",t.ErrorText,"]"),u.Bb(2),u.Ac(" --- TranslationStatus: [",e.GetTranslationStatusEnumText(t.TranslationStatus),"]"),u.Bb(2),u.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),u.Bb(2),u.Ac(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function Q(t,a){if(1&t&&(u.Sb(0,"div"),u.xc(1,X,38,14,"div",5),u.Rb()),2&t){const t=u.cc();u.Bb(1),u.hc("ngForOf",t.apptasklanguageService.apptasklanguageListModel$.getValue())}}const Z=[{path:"",component:(()=>{class t{constructor(t,a,e){this.apptasklanguageService=t,this.router=a,this.httpClientService=e,this.showType=null,e.oldURL=a.url}GetPutButtonColor(t){return this.IDToShow===t.AppTaskLanguageID&&this.showType===i.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.AppTaskLanguageID&&this.showType===i.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.AppTaskLanguageID&&this.showType===i.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.AppTaskLanguageID,this.showType=i.a.Put)}ShowPost(t){this.IDToShow===t.AppTaskLanguageID&&this.showType===i.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.AppTaskLanguageID,this.showType=i.a.Post)}GetPutEnum(){return i.a.Put}GetPostEnum(){return i.a.Post}GetAppTaskLanguageList(){this.sub=this.apptasklanguageService.GetAppTaskLanguageList().subscribe()}DeleteAppTaskLanguage(t){this.sub=this.apptasklanguageService.DeleteAppTaskLanguage(t).subscribe()}GetLanguageEnumText(t){return Object(p.a)(t)}GetTranslationStatusEnumText(t){return Object(o.a)(t)}ngOnInit(){r(this.apptasklanguageService.apptasklanguageTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(a){return new(a||t)(u.Mb(d),u.Mb(s.b),u.Mb(m.a))},t.\u0275cmp=u.Gb({type:t,selectors:[["app-apptasklanguage"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"apptasklanguage","httpClientCommand"]],template:function(t,a){var e,n;1&t&&(u.xc(0,J,1,0,"mat-progress-bar",0),u.Sb(1,"mat-card"),u.Sb(2,"mat-card-header"),u.Sb(3,"mat-card-title"),u.yc(4," AppTaskLanguage works! "),u.Sb(5,"button",1),u.Yb("click",(function(){return a.GetAppTaskLanguageList()})),u.Sb(6,"span"),u.yc(7,"Get AppTaskLanguage"),u.Rb(),u.Rb(),u.Rb(),u.Sb(8,"mat-card-subtitle"),u.yc(9),u.Rb(),u.Rb(),u.Sb(10,"mat-card-content"),u.xc(11,Q,2,1,"div",2),u.Rb(),u.Sb(12,"mat-card-actions"),u.Sb(13,"button",3),u.yc(14,"Allo"),u.Rb(),u.Rb(),u.Rb()),2&t&&(u.hc("ngIf",null==(e=a.apptasklanguageService.apptasklanguageGetModel$.getValue())?null:e.Working),u.Bb(9),u.zc(a.apptasklanguageService.apptasklanguageTextModel$.getValue().Title),u.Bb(2),u.hc("ngIf",null==(n=a.apptasklanguageService.apptasklanguageListModel$.getValue())?null:n.length))},directives:[n.l,k.a,k.d,k.g,S.b,k.f,k.c,k.b,f.a,n.k,T.a,_],styles:[""],changeDetection:0}),t})(),canActivate:[e("auXs").a]}];let tt=(()=>{class t{}return t.\u0275mod=u.Kb({type:t}),t.\u0275inj=u.Jb({factory:function(a){return new(a||t)},imports:[[s.e.forChild(Z)],s.e]}),t})();var at=e("B+Mi");let et=(()=>{class t{}return t.\u0275mod=u.Kb({type:t}),t.\u0275inj=u.Jb({factory:function(a){return new(a||t)},imports:[[n.c,s.e,tt,at.a,I.g,I.o]]}),t})()}}]);