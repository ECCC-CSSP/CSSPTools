(window.webpackJsonp=window.webpackJsonp||[]).push([[21],{AfOW:function(t,e,a){"use strict";a.r(e),a.d(e,"MWQMSubsectorLanguageModule",(function(){return ot}));var s=a("ofXK"),o=a("tyNb");function n(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var r=a("PSTt"),c=a("BBgV"),u=a("QRvi"),b=a("fXoL"),i=a("2Vo4"),l=a("LRne"),g=a("tk/3"),m=a("lJxs"),p=a("JIr8"),S=a("gkM4");let h=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.mwqmsubsectorlanguageTextModel$=new i.a({}),this.mwqmsubsectorlanguageListModel$=new i.a({}),this.mwqmsubsectorlanguageGetModel$=new i.a({}),this.mwqmsubsectorlanguagePutModel$=new i.a({}),this.mwqmsubsectorlanguagePostModel$=new i.a({}),this.mwqmsubsectorlanguageDeleteModel$=new i.a({}),n(this.mwqmsubsectorlanguageTextModel$),this.mwqmsubsectorlanguageTextModel$.next({Title:"Something2 for text"})}GetMWQMSubsectorLanguageList(){return this.httpClientService.BeforeHttpClient(this.mwqmsubsectorlanguageGetModel$),this.httpClient.get("/api/MWQMSubsectorLanguage").pipe(Object(m.a)(t=>{this.httpClientService.DoSuccess(this.mwqmsubsectorlanguageListModel$,this.mwqmsubsectorlanguageGetModel$,t,u.a.Get,null)}),Object(p.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.mwqmsubsectorlanguageListModel$,this.mwqmsubsectorlanguageGetModel$,t)}))))}PutMWQMSubsectorLanguage(t){return this.httpClientService.BeforeHttpClient(this.mwqmsubsectorlanguagePutModel$),this.httpClient.put("/api/MWQMSubsectorLanguage",t,{headers:new g.d}).pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.mwqmsubsectorlanguageListModel$,this.mwqmsubsectorlanguagePutModel$,e,u.a.Put,t)}),Object(p.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.mwqmsubsectorlanguageListModel$,this.mwqmsubsectorlanguagePutModel$,t)}))))}PostMWQMSubsectorLanguage(t){return this.httpClientService.BeforeHttpClient(this.mwqmsubsectorlanguagePostModel$),this.httpClient.post("/api/MWQMSubsectorLanguage",t,{headers:new g.d}).pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.mwqmsubsectorlanguageListModel$,this.mwqmsubsectorlanguagePostModel$,e,u.a.Post,t)}),Object(p.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.mwqmsubsectorlanguageListModel$,this.mwqmsubsectorlanguagePostModel$,t)}))))}DeleteMWQMSubsectorLanguage(t){return this.httpClientService.BeforeHttpClient(this.mwqmsubsectorlanguageDeleteModel$),this.httpClient.delete("/api/MWQMSubsectorLanguage/"+t.MWQMSubsectorLanguageID).pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.mwqmsubsectorlanguageListModel$,this.mwqmsubsectorlanguageDeleteModel$,e,u.a.Delete,t)}),Object(p.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.mwqmsubsectorlanguageListModel$,this.mwqmsubsectorlanguageDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(b.Xb(g.b),b.Xb(S.a))},t.\u0275prov=b.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var d=a("Wp6s"),f=a("bTqV"),T=a("bv9b"),M=a("NFeN"),w=a("3Pt+"),L=a("kmnG"),q=a("qFsG"),D=a("d3UM"),I=a("FKr1");function y(t,e){1&t&&b.Ob(0,"mat-progress-bar",14)}function B(t,e){1&t&&b.Ob(0,"mat-progress-bar",14)}function C(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function v(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,C,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function j(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function x(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,j,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function O(t,e){if(1&t&&(b.Tb(0,"mat-option",15),b.yc(1),b.Sb()),2&t){const t=e.$implicit;b.jc("value",t.EnumID),b.Bb(1),b.Ac(" ",t.EnumText," ")}}function P(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function W(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,P,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function $(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function Q(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 250"),b.Ob(2,"br"),b.Sb())}function E(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,$,3,0,"span",4),b.xc(6,Q,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,3,t)),b.Bb(3),b.jc("ngIf",t.required),b.Bb(1),b.jc("ngIf",t.maxlength)}}function k(t,e){if(1&t&&(b.Tb(0,"mat-option",15),b.yc(1),b.Sb()),2&t){const t=e.$implicit;b.jc("value",t.EnumID),b.Bb(1),b.Ac(" ",t.EnumText," ")}}function G(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function F(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,G,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function U(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,1,t))}}function V(t,e){if(1&t&&(b.Tb(0,"mat-option",15),b.yc(1),b.Sb()),2&t){const t=e.$implicit;b.jc("value",t.EnumID),b.Bb(1),b.Ac(" ",t.EnumText," ")}}function A(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,1,t))}}function N(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function R(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,N,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function z(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function H(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,z,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}let X=(()=>{class t{constructor(t,e){this.mwqmsubsectorlanguageService=t,this.fb=e,this.mwqmsubsectorlanguage=null,this.httpClientCommand=u.a.Put}GetPut(){return this.httpClientCommand==u.a.Put}PutMWQMSubsectorLanguage(t){this.sub=this.mwqmsubsectorlanguageService.PutMWQMSubsectorLanguage(t).subscribe()}PostMWQMSubsectorLanguage(t){this.sub=this.mwqmsubsectorlanguageService.PostMWQMSubsectorLanguage(t).subscribe()}ngOnInit(){this.languageList=Object(r.b)(),this.translationStatusSubsectorDescList=Object(c.b)(),this.translationStatusLogBookList=Object(c.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.mwqmsubsectorlanguage){let e=this.fb.group({MWQMSubsectorLanguageID:[{value:t===u.a.Post?0:this.mwqmsubsectorlanguage.MWQMSubsectorLanguageID,disabled:!1},[w.p.required]],MWQMSubsectorID:[{value:this.mwqmsubsectorlanguage.MWQMSubsectorID,disabled:!1},[w.p.required]],Language:[{value:this.mwqmsubsectorlanguage.Language,disabled:!1},[w.p.required]],SubsectorDesc:[{value:this.mwqmsubsectorlanguage.SubsectorDesc,disabled:!1},[w.p.required,w.p.maxLength(250)]],TranslationStatusSubsectorDesc:[{value:this.mwqmsubsectorlanguage.TranslationStatusSubsectorDesc,disabled:!1},[w.p.required]],LogBook:[{value:this.mwqmsubsectorlanguage.LogBook,disabled:!1}],TranslationStatusLogBook:[{value:this.mwqmsubsectorlanguage.TranslationStatusLogBook,disabled:!1}],LastUpdateDate_UTC:[{value:this.mwqmsubsectorlanguage.LastUpdateDate_UTC,disabled:!1},[w.p.required]],LastUpdateContactTVItemID:[{value:this.mwqmsubsectorlanguage.LastUpdateContactTVItemID,disabled:!1},[w.p.required]]});this.mwqmsubsectorlanguageFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(b.Nb(h),b.Nb(w.d))},t.\u0275cmp=b.Hb({type:t,selectors:[["app-mwqmsubsectorlanguage-edit"]],inputs:{mwqmsubsectorlanguage:"mwqmsubsectorlanguage",httpClientCommand:"httpClientCommand"},decls:59,vars:16,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","MWQMSubsectorLanguageID"],[4,"ngIf"],["matInput","","type","number","formControlName","MWQMSubsectorID"],["formControlName","Language"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","SubsectorDesc"],["formControlName","TranslationStatusSubsectorDesc"],["matInput","","type","text","formControlName","LogBook"],["formControlName","TranslationStatusLogBook"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(b.Tb(0,"form",0),b.ac("ngSubmit",(function(){return e.GetPut()?e.PutMWQMSubsectorLanguage(e.mwqmsubsectorlanguageFormEdit.value):e.PostMWQMSubsectorLanguage(e.mwqmsubsectorlanguageFormEdit.value)})),b.Tb(1,"h3"),b.yc(2," MWQMSubsectorLanguage "),b.Tb(3,"button",1),b.Tb(4,"span"),b.yc(5),b.Sb(),b.Sb(),b.xc(6,y,1,0,"mat-progress-bar",2),b.xc(7,B,1,0,"mat-progress-bar",2),b.Sb(),b.Tb(8,"p"),b.Tb(9,"mat-form-field"),b.Tb(10,"mat-label"),b.yc(11,"MWQMSubsectorLanguageID"),b.Sb(),b.Ob(12,"input",3),b.xc(13,v,6,4,"mat-error",4),b.Sb(),b.Tb(14,"mat-form-field"),b.Tb(15,"mat-label"),b.yc(16,"MWQMSubsectorID"),b.Sb(),b.Ob(17,"input",5),b.xc(18,x,6,4,"mat-error",4),b.Sb(),b.Tb(19,"mat-form-field"),b.Tb(20,"mat-label"),b.yc(21,"Language"),b.Sb(),b.Tb(22,"mat-select",6),b.xc(23,O,2,2,"mat-option",7),b.Sb(),b.xc(24,W,6,4,"mat-error",4),b.Sb(),b.Tb(25,"mat-form-field"),b.Tb(26,"mat-label"),b.yc(27,"SubsectorDesc"),b.Sb(),b.Ob(28,"input",8),b.xc(29,E,7,5,"mat-error",4),b.Sb(),b.Sb(),b.Tb(30,"p"),b.Tb(31,"mat-form-field"),b.Tb(32,"mat-label"),b.yc(33,"TranslationStatusSubsectorDesc"),b.Sb(),b.Tb(34,"mat-select",9),b.xc(35,k,2,2,"mat-option",7),b.Sb(),b.xc(36,F,6,4,"mat-error",4),b.Sb(),b.Tb(37,"mat-form-field"),b.Tb(38,"mat-label"),b.yc(39,"LogBook"),b.Sb(),b.Ob(40,"input",10),b.xc(41,U,5,3,"mat-error",4),b.Sb(),b.Tb(42,"mat-form-field"),b.Tb(43,"mat-label"),b.yc(44,"TranslationStatusLogBook"),b.Sb(),b.Tb(45,"mat-select",11),b.xc(46,V,2,2,"mat-option",7),b.Sb(),b.xc(47,A,5,3,"mat-error",4),b.Sb(),b.Tb(48,"mat-form-field"),b.Tb(49,"mat-label"),b.yc(50,"LastUpdateDate_UTC"),b.Sb(),b.Ob(51,"input",12),b.xc(52,R,6,4,"mat-error",4),b.Sb(),b.Sb(),b.Tb(53,"p"),b.Tb(54,"mat-form-field"),b.Tb(55,"mat-label"),b.yc(56,"LastUpdateContactTVItemID"),b.Sb(),b.Ob(57,"input",13),b.xc(58,H,6,4,"mat-error",4),b.Sb(),b.Sb(),b.Sb()),2&t&&(b.jc("formGroup",e.mwqmsubsectorlanguageFormEdit),b.Bb(5),b.Ac("",e.GetPut()?"Put":"Post"," MWQMSubsectorLanguage"),b.Bb(1),b.jc("ngIf",e.mwqmsubsectorlanguageService.mwqmsubsectorlanguagePutModel$.getValue().Working),b.Bb(1),b.jc("ngIf",e.mwqmsubsectorlanguageService.mwqmsubsectorlanguagePostModel$.getValue().Working),b.Bb(6),b.jc("ngIf",e.mwqmsubsectorlanguageFormEdit.controls.MWQMSubsectorLanguageID.errors),b.Bb(5),b.jc("ngIf",e.mwqmsubsectorlanguageFormEdit.controls.MWQMSubsectorID.errors),b.Bb(5),b.jc("ngForOf",e.languageList),b.Bb(1),b.jc("ngIf",e.mwqmsubsectorlanguageFormEdit.controls.Language.errors),b.Bb(5),b.jc("ngIf",e.mwqmsubsectorlanguageFormEdit.controls.SubsectorDesc.errors),b.Bb(6),b.jc("ngForOf",e.translationStatusSubsectorDescList),b.Bb(1),b.jc("ngIf",e.mwqmsubsectorlanguageFormEdit.controls.TranslationStatusSubsectorDesc.errors),b.Bb(5),b.jc("ngIf",e.mwqmsubsectorlanguageFormEdit.controls.LogBook.errors),b.Bb(5),b.jc("ngForOf",e.translationStatusLogBookList),b.Bb(1),b.jc("ngIf",e.mwqmsubsectorlanguageFormEdit.controls.TranslationStatusLogBook.errors),b.Bb(5),b.jc("ngIf",e.mwqmsubsectorlanguageFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(6),b.jc("ngIf",e.mwqmsubsectorlanguageFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[w.q,w.l,w.f,f.b,s.l,L.c,L.f,q.b,w.n,w.c,w.k,w.e,D.a,s.k,T.a,L.b,I.n],pipes:[s.f],styles:[""],changeDetection:0}),t})();function _(t,e){1&t&&b.Ob(0,"mat-progress-bar",4)}function J(t,e){1&t&&b.Ob(0,"mat-progress-bar",4)}function K(t,e){if(1&t&&(b.Tb(0,"p"),b.Ob(1,"app-mwqmsubsectorlanguage-edit",8),b.Sb()),2&t){const t=b.ec().$implicit,e=b.ec(2);b.Bb(1),b.jc("mwqmsubsectorlanguage",t)("httpClientCommand",e.GetPutEnum())}}function Y(t,e){if(1&t&&(b.Tb(0,"p"),b.Ob(1,"app-mwqmsubsectorlanguage-edit",8),b.Sb()),2&t){const t=b.ec().$implicit,e=b.ec(2);b.Bb(1),b.jc("mwqmsubsectorlanguage",t)("httpClientCommand",e.GetPostEnum())}}function Z(t,e){if(1&t){const t=b.Ub();b.Tb(0,"div"),b.Tb(1,"p"),b.Tb(2,"button",6),b.ac("click",(function(){b.rc(t);const a=e.$implicit;return b.ec(2).DeleteMWQMSubsectorLanguage(a)})),b.Tb(3,"span"),b.yc(4),b.Sb(),b.Tb(5,"mat-icon"),b.yc(6,"delete"),b.Sb(),b.Sb(),b.yc(7,"\xa0\xa0\xa0 "),b.Tb(8,"button",7),b.ac("click",(function(){b.rc(t);const a=e.$implicit;return b.ec(2).ShowPut(a)})),b.Tb(9,"span"),b.yc(10,"Show Put"),b.Sb(),b.Sb(),b.yc(11,"\xa0\xa0 "),b.Tb(12,"button",7),b.ac("click",(function(){b.rc(t);const a=e.$implicit;return b.ec(2).ShowPost(a)})),b.Tb(13,"span"),b.yc(14,"Show Post"),b.Sb(),b.Sb(),b.yc(15,"\xa0\xa0 "),b.xc(16,J,1,0,"mat-progress-bar",0),b.Sb(),b.xc(17,K,2,2,"p",2),b.xc(18,Y,2,2,"p",2),b.Tb(19,"blockquote"),b.Tb(20,"p"),b.Tb(21,"span"),b.yc(22),b.Sb(),b.Tb(23,"span"),b.yc(24),b.Sb(),b.Tb(25,"span"),b.yc(26),b.Sb(),b.Tb(27,"span"),b.yc(28),b.Sb(),b.Sb(),b.Tb(29,"p"),b.Tb(30,"span"),b.yc(31),b.Sb(),b.Tb(32,"span"),b.yc(33),b.Sb(),b.Tb(34,"span"),b.yc(35),b.Sb(),b.Tb(36,"span"),b.yc(37),b.Sb(),b.Sb(),b.Tb(38,"p"),b.Tb(39,"span"),b.yc(40),b.Sb(),b.Sb(),b.Sb(),b.Sb()}if(2&t){const t=e.$implicit,a=b.ec(2);b.Bb(4),b.Ac("Delete MWQMSubsectorLanguageID [",t.MWQMSubsectorLanguageID,"]\xa0\xa0\xa0"),b.Bb(4),b.jc("color",a.GetPutButtonColor(t)),b.Bb(4),b.jc("color",a.GetPostButtonColor(t)),b.Bb(4),b.jc("ngIf",a.mwqmsubsectorlanguageService.mwqmsubsectorlanguageDeleteModel$.getValue().Working),b.Bb(1),b.jc("ngIf",a.IDToShow===t.MWQMSubsectorLanguageID&&a.showType===a.GetPutEnum()),b.Bb(1),b.jc("ngIf",a.IDToShow===t.MWQMSubsectorLanguageID&&a.showType===a.GetPostEnum()),b.Bb(4),b.Ac("MWQMSubsectorLanguageID: [",t.MWQMSubsectorLanguageID,"]"),b.Bb(2),b.Ac(" --- MWQMSubsectorID: [",t.MWQMSubsectorID,"]"),b.Bb(2),b.Ac(" --- Language: [",a.GetLanguageEnumText(t.Language),"]"),b.Bb(2),b.Ac(" --- SubsectorDesc: [",t.SubsectorDesc,"]"),b.Bb(3),b.Ac("TranslationStatusSubsectorDesc: [",a.GetTranslationStatusEnumText(t.TranslationStatusSubsectorDesc),"]"),b.Bb(2),b.Ac(" --- LogBook: [",t.LogBook,"]"),b.Bb(2),b.Ac(" --- TranslationStatusLogBook: [",a.GetTranslationStatusEnumText(t.TranslationStatusLogBook),"]"),b.Bb(2),b.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),b.Bb(3),b.Ac("LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function tt(t,e){if(1&t&&(b.Tb(0,"div"),b.xc(1,Z,41,15,"div",5),b.Sb()),2&t){const t=b.ec();b.Bb(1),b.jc("ngForOf",t.mwqmsubsectorlanguageService.mwqmsubsectorlanguageListModel$.getValue())}}const et=[{path:"",component:(()=>{class t{constructor(t,e,a){this.mwqmsubsectorlanguageService=t,this.router=e,this.httpClientService=a,this.showType=null,a.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.MWQMSubsectorLanguageID&&this.showType===u.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.MWQMSubsectorLanguageID&&this.showType===u.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.MWQMSubsectorLanguageID&&this.showType===u.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MWQMSubsectorLanguageID,this.showType=u.a.Put)}ShowPost(t){this.IDToShow===t.MWQMSubsectorLanguageID&&this.showType===u.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MWQMSubsectorLanguageID,this.showType=u.a.Post)}GetPutEnum(){return u.a.Put}GetPostEnum(){return u.a.Post}GetMWQMSubsectorLanguageList(){this.sub=this.mwqmsubsectorlanguageService.GetMWQMSubsectorLanguageList().subscribe()}DeleteMWQMSubsectorLanguage(t){this.sub=this.mwqmsubsectorlanguageService.DeleteMWQMSubsectorLanguage(t).subscribe()}GetLanguageEnumText(t){return Object(r.a)(t)}GetTranslationStatusEnumText(t){return Object(c.a)(t)}ngOnInit(){n(this.mwqmsubsectorlanguageService.mwqmsubsectorlanguageTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(b.Nb(h),b.Nb(o.b),b.Nb(S.a))},t.\u0275cmp=b.Hb({type:t,selectors:[["app-mwqmsubsectorlanguage"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"mwqmsubsectorlanguage","httpClientCommand"]],template:function(t,e){if(1&t&&(b.xc(0,_,1,0,"mat-progress-bar",0),b.Tb(1,"mat-card"),b.Tb(2,"mat-card-header"),b.Tb(3,"mat-card-title"),b.yc(4," MWQMSubsectorLanguage works! "),b.Tb(5,"button",1),b.ac("click",(function(){return e.GetMWQMSubsectorLanguageList()})),b.Tb(6,"span"),b.yc(7,"Get MWQMSubsectorLanguage"),b.Sb(),b.Sb(),b.Sb(),b.Tb(8,"mat-card-subtitle"),b.yc(9),b.Sb(),b.Sb(),b.Tb(10,"mat-card-content"),b.xc(11,tt,2,1,"div",2),b.Sb(),b.Tb(12,"mat-card-actions"),b.Tb(13,"button",3),b.yc(14,"Allo"),b.Sb(),b.Sb(),b.Sb()),2&t){var a;const t=null==(a=e.mwqmsubsectorlanguageService.mwqmsubsectorlanguageGetModel$.getValue())?null:a.Working;var s;const o=null==(s=e.mwqmsubsectorlanguageService.mwqmsubsectorlanguageListModel$.getValue())?null:s.length;b.jc("ngIf",t),b.Bb(9),b.zc(e.mwqmsubsectorlanguageService.mwqmsubsectorlanguageTextModel$.getValue().Title),b.Bb(2),b.jc("ngIf",o)}},directives:[s.l,d.a,d.d,d.g,f.b,d.f,d.c,d.b,T.a,s.k,M.a,X],styles:[""],changeDetection:0}),t})(),canActivate:[a("auXs").a]}];let at=(()=>{class t{}return t.\u0275mod=b.Lb({type:t}),t.\u0275inj=b.Kb({factory:function(e){return new(e||t)},imports:[[o.e.forChild(et)],o.e]}),t})();var st=a("B+Mi");let ot=(()=>{class t{}return t.\u0275mod=b.Lb({type:t}),t.\u0275inj=b.Kb({factory:function(e){return new(e||t)},imports:[[s.c,o.e,at,st.a,w.g,w.o]]}),t})()},PSTt:function(t,e,a){"use strict";function s(){let t=[];return $localize,t.push({EnumID:1,EnumText:"en"}),t.push({EnumID:2,EnumText:"fr"}),t.push({EnumID:3,EnumText:"enAndfr"}),t.push({EnumID:4,EnumText:"es"}),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}function o(t){let e;return s().forEach(a=>{if(a.EnumID==t)return e=a.EnumText,!1}),e}a.d(e,"b",(function(){return s})),a.d(e,"a",(function(){return o}))},QRvi:function(t,e,a){"use strict";a.d(e,"a",(function(){return s}));var s=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,a){"use strict";a.d(e,"a",(function(){return r}));var s=a("QRvi"),o=a("fXoL"),n=a("tyNb");let r=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,a){t.next(null),e.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,a,o,n){if(o===s.a.Get&&t.next(a),o===s.a.Put&&(t.getValue()[0]=a),o===s.a.Post&&t.getValue().push(a),o===s.a.Delete){const e=t.getValue().indexOf(n);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(o.Xb(n.b))},t.\u0275prov=o.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);