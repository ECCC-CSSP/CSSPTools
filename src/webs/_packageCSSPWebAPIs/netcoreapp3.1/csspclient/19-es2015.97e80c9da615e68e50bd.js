(window.webpackJsonp=window.webpackJsonp||[]).push([[19],{PSTt:function(t,e,n){"use strict";function a(){let t=[];return $localize,t.push({EnumID:1,EnumText:"en"}),t.push({EnumID:2,EnumText:"fr"}),t.push({EnumID:3,EnumText:"enAndfr"}),t.push({EnumID:4,EnumText:"es"}),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}function u(t){let e;return a().forEach(n=>{if(n.EnumID==t)return e=n.EnumText,!1}),e}n.d(e,"b",(function(){return a})),n.d(e,"a",(function(){return u}))},QRvi:function(t,e,n){"use strict";n.d(e,"a",(function(){return a}));var a=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gHfH:function(t,e,n){"use strict";n.r(e),n.d(e,"MWQMRunLanguageModule",(function(){return rt}));var a=n("ofXK"),u=n("tyNb");function r(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var o=n("PSTt"),i=n("BBgV"),s=n("QRvi"),c=n("fXoL"),m=n("2Vo4"),b=n("LRne"),l=n("tk/3"),g=n("lJxs"),p=n("JIr8"),h=n("gkM4");let d=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.mwqmrunlanguageTextModel$=new m.a({}),this.mwqmrunlanguageListModel$=new m.a({}),this.mwqmrunlanguageGetModel$=new m.a({}),this.mwqmrunlanguagePutModel$=new m.a({}),this.mwqmrunlanguagePostModel$=new m.a({}),this.mwqmrunlanguageDeleteModel$=new m.a({}),r(this.mwqmrunlanguageTextModel$),this.mwqmrunlanguageTextModel$.next({Title:"Something2 for text"})}GetMWQMRunLanguageList(){return this.httpClientService.BeforeHttpClient(this.mwqmrunlanguageGetModel$),this.httpClient.get("/api/MWQMRunLanguage").pipe(Object(g.a)(t=>{this.httpClientService.DoSuccess(this.mwqmrunlanguageListModel$,this.mwqmrunlanguageGetModel$,t,s.a.Get,null)}),Object(p.a)(t=>Object(b.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.mwqmrunlanguageListModel$,this.mwqmrunlanguageGetModel$,t)}))))}PutMWQMRunLanguage(t){return this.httpClientService.BeforeHttpClient(this.mwqmrunlanguagePutModel$),this.httpClient.put("/api/MWQMRunLanguage",t,{headers:new l.d}).pipe(Object(g.a)(e=>{this.httpClientService.DoSuccess(this.mwqmrunlanguageListModel$,this.mwqmrunlanguagePutModel$,e,s.a.Put,t)}),Object(p.a)(t=>Object(b.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.mwqmrunlanguageListModel$,this.mwqmrunlanguagePutModel$,t)}))))}PostMWQMRunLanguage(t){return this.httpClientService.BeforeHttpClient(this.mwqmrunlanguagePostModel$),this.httpClient.post("/api/MWQMRunLanguage",t,{headers:new l.d}).pipe(Object(g.a)(e=>{this.httpClientService.DoSuccess(this.mwqmrunlanguageListModel$,this.mwqmrunlanguagePostModel$,e,s.a.Post,t)}),Object(p.a)(t=>Object(b.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.mwqmrunlanguageListModel$,this.mwqmrunlanguagePostModel$,t)}))))}DeleteMWQMRunLanguage(t){return this.httpClientService.BeforeHttpClient(this.mwqmrunlanguageDeleteModel$),this.httpClient.delete("/api/MWQMRunLanguage/"+t.MWQMRunLanguageID).pipe(Object(g.a)(e=>{this.httpClientService.DoSuccess(this.mwqmrunlanguageListModel$,this.mwqmrunlanguageDeleteModel$,e,s.a.Delete,t)}),Object(p.a)(t=>Object(b.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.mwqmrunlanguageListModel$,this.mwqmrunlanguageDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(c.Xb(l.b),c.Xb(h.a))},t.\u0275prov=c.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var f=n("Wp6s"),S=n("bTqV"),T=n("bv9b"),M=n("NFeN"),w=n("3Pt+"),q=n("kmnG"),C=n("qFsG"),I=n("d3UM"),R=n("FKr1");function L(t,e){1&t&&c.Ob(0,"mat-progress-bar",14)}function D(t,e){1&t&&c.Ob(0,"mat-progress-bar",14)}function y(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function W(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,y,3,0,"span",4),c.Sb()),2&t){const t=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,t)),c.Bb(3),c.jc("ngIf",t.required)}}function v(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function B(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,v,3,0,"span",4),c.Sb()),2&t){const t=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,t)),c.Bb(3),c.jc("ngIf",t.required)}}function j(t,e){if(1&t&&(c.Tb(0,"mat-option",15),c.yc(1),c.Sb()),2&t){const t=e.$implicit;c.jc("value",t.EnumID),c.Bb(1),c.Ac(" ",t.EnumText," ")}}function x(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function O(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,x,3,0,"span",4),c.Sb()),2&t){const t=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,t)),c.Bb(3),c.jc("ngIf",t.required)}}function P(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function E(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,P,3,0,"span",4),c.Sb()),2&t){const t=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,t)),c.Bb(3),c.jc("ngIf",t.required)}}function $(t,e){if(1&t&&(c.Tb(0,"mat-option",15),c.yc(1),c.Sb()),2&t){const t=e.$implicit;c.jc("value",t.EnumID),c.Bb(1),c.Ac(" ",t.EnumText," ")}}function Q(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function G(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,Q,3,0,"span",4),c.Sb()),2&t){const t=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,t)),c.Bb(3),c.jc("ngIf",t.required)}}function k(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function F(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,k,3,0,"span",4),c.Sb()),2&t){const t=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,t)),c.Bb(3),c.jc("ngIf",t.required)}}function U(t,e){if(1&t&&(c.Tb(0,"mat-option",15),c.yc(1),c.Sb()),2&t){const t=e.$implicit;c.jc("value",t.EnumID),c.Bb(1),c.Ac(" ",t.EnumText," ")}}function V(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function A(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,V,3,0,"span",4),c.Sb()),2&t){const t=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,t)),c.Bb(3),c.jc("ngIf",t.required)}}function N(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function z(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,N,3,0,"span",4),c.Sb()),2&t){const t=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,t)),c.Bb(3),c.jc("ngIf",t.required)}}function H(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function X(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,H,3,0,"span",4),c.Sb()),2&t){const t=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,t)),c.Bb(3),c.jc("ngIf",t.required)}}let _=(()=>{class t{constructor(t,e){this.mwqmrunlanguageService=t,this.fb=e,this.mwqmrunlanguage=null,this.httpClientCommand=s.a.Put}GetPut(){return this.httpClientCommand==s.a.Put}PutMWQMRunLanguage(t){this.sub=this.mwqmrunlanguageService.PutMWQMRunLanguage(t).subscribe()}PostMWQMRunLanguage(t){this.sub=this.mwqmrunlanguageService.PostMWQMRunLanguage(t).subscribe()}ngOnInit(){this.languageList=Object(o.b)(),this.translationStatusRunCommentList=Object(i.b)(),this.translationStatusRunWeatherCommentList=Object(i.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.mwqmrunlanguage){let e=this.fb.group({MWQMRunLanguageID:[{value:t===s.a.Post?0:this.mwqmrunlanguage.MWQMRunLanguageID,disabled:!1},[w.p.required]],MWQMRunID:[{value:this.mwqmrunlanguage.MWQMRunID,disabled:!1},[w.p.required]],Language:[{value:this.mwqmrunlanguage.Language,disabled:!1},[w.p.required]],RunComment:[{value:this.mwqmrunlanguage.RunComment,disabled:!1},[w.p.required]],TranslationStatusRunComment:[{value:this.mwqmrunlanguage.TranslationStatusRunComment,disabled:!1},[w.p.required]],RunWeatherComment:[{value:this.mwqmrunlanguage.RunWeatherComment,disabled:!1},[w.p.required]],TranslationStatusRunWeatherComment:[{value:this.mwqmrunlanguage.TranslationStatusRunWeatherComment,disabled:!1},[w.p.required]],LastUpdateDate_UTC:[{value:this.mwqmrunlanguage.LastUpdateDate_UTC,disabled:!1},[w.p.required]],LastUpdateContactTVItemID:[{value:this.mwqmrunlanguage.LastUpdateContactTVItemID,disabled:!1},[w.p.required]]});this.mwqmrunlanguageFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(c.Nb(d),c.Nb(w.d))},t.\u0275cmp=c.Hb({type:t,selectors:[["app-mwqmrunlanguage-edit"]],inputs:{mwqmrunlanguage:"mwqmrunlanguage",httpClientCommand:"httpClientCommand"},decls:59,vars:16,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","MWQMRunLanguageID"],[4,"ngIf"],["matInput","","type","number","formControlName","MWQMRunID"],["formControlName","Language"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","RunComment"],["formControlName","TranslationStatusRunComment"],["matInput","","type","text","formControlName","RunWeatherComment"],["formControlName","TranslationStatusRunWeatherComment"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(c.Tb(0,"form",0),c.ac("ngSubmit",(function(){return e.GetPut()?e.PutMWQMRunLanguage(e.mwqmrunlanguageFormEdit.value):e.PostMWQMRunLanguage(e.mwqmrunlanguageFormEdit.value)})),c.Tb(1,"h3"),c.yc(2," MWQMRunLanguage "),c.Tb(3,"button",1),c.Tb(4,"span"),c.yc(5),c.Sb(),c.Sb(),c.xc(6,L,1,0,"mat-progress-bar",2),c.xc(7,D,1,0,"mat-progress-bar",2),c.Sb(),c.Tb(8,"p"),c.Tb(9,"mat-form-field"),c.Tb(10,"mat-label"),c.yc(11,"MWQMRunLanguageID"),c.Sb(),c.Ob(12,"input",3),c.xc(13,W,6,4,"mat-error",4),c.Sb(),c.Tb(14,"mat-form-field"),c.Tb(15,"mat-label"),c.yc(16,"MWQMRunID"),c.Sb(),c.Ob(17,"input",5),c.xc(18,B,6,4,"mat-error",4),c.Sb(),c.Tb(19,"mat-form-field"),c.Tb(20,"mat-label"),c.yc(21,"Language"),c.Sb(),c.Tb(22,"mat-select",6),c.xc(23,j,2,2,"mat-option",7),c.Sb(),c.xc(24,O,6,4,"mat-error",4),c.Sb(),c.Tb(25,"mat-form-field"),c.Tb(26,"mat-label"),c.yc(27,"RunComment"),c.Sb(),c.Ob(28,"input",8),c.xc(29,E,6,4,"mat-error",4),c.Sb(),c.Sb(),c.Tb(30,"p"),c.Tb(31,"mat-form-field"),c.Tb(32,"mat-label"),c.yc(33,"TranslationStatusRunComment"),c.Sb(),c.Tb(34,"mat-select",9),c.xc(35,$,2,2,"mat-option",7),c.Sb(),c.xc(36,G,6,4,"mat-error",4),c.Sb(),c.Tb(37,"mat-form-field"),c.Tb(38,"mat-label"),c.yc(39,"RunWeatherComment"),c.Sb(),c.Ob(40,"input",10),c.xc(41,F,6,4,"mat-error",4),c.Sb(),c.Tb(42,"mat-form-field"),c.Tb(43,"mat-label"),c.yc(44,"TranslationStatusRunWeatherComment"),c.Sb(),c.Tb(45,"mat-select",11),c.xc(46,U,2,2,"mat-option",7),c.Sb(),c.xc(47,A,6,4,"mat-error",4),c.Sb(),c.Tb(48,"mat-form-field"),c.Tb(49,"mat-label"),c.yc(50,"LastUpdateDate_UTC"),c.Sb(),c.Ob(51,"input",12),c.xc(52,z,6,4,"mat-error",4),c.Sb(),c.Sb(),c.Tb(53,"p"),c.Tb(54,"mat-form-field"),c.Tb(55,"mat-label"),c.yc(56,"LastUpdateContactTVItemID"),c.Sb(),c.Ob(57,"input",13),c.xc(58,X,6,4,"mat-error",4),c.Sb(),c.Sb(),c.Sb()),2&t&&(c.jc("formGroup",e.mwqmrunlanguageFormEdit),c.Bb(5),c.Ac("",e.GetPut()?"Put":"Post"," MWQMRunLanguage"),c.Bb(1),c.jc("ngIf",e.mwqmrunlanguageService.mwqmrunlanguagePutModel$.getValue().Working),c.Bb(1),c.jc("ngIf",e.mwqmrunlanguageService.mwqmrunlanguagePostModel$.getValue().Working),c.Bb(6),c.jc("ngIf",e.mwqmrunlanguageFormEdit.controls.MWQMRunLanguageID.errors),c.Bb(5),c.jc("ngIf",e.mwqmrunlanguageFormEdit.controls.MWQMRunID.errors),c.Bb(5),c.jc("ngForOf",e.languageList),c.Bb(1),c.jc("ngIf",e.mwqmrunlanguageFormEdit.controls.Language.errors),c.Bb(5),c.jc("ngIf",e.mwqmrunlanguageFormEdit.controls.RunComment.errors),c.Bb(6),c.jc("ngForOf",e.translationStatusRunCommentList),c.Bb(1),c.jc("ngIf",e.mwqmrunlanguageFormEdit.controls.TranslationStatusRunComment.errors),c.Bb(5),c.jc("ngIf",e.mwqmrunlanguageFormEdit.controls.RunWeatherComment.errors),c.Bb(5),c.jc("ngForOf",e.translationStatusRunWeatherCommentList),c.Bb(1),c.jc("ngIf",e.mwqmrunlanguageFormEdit.controls.TranslationStatusRunWeatherComment.errors),c.Bb(5),c.jc("ngIf",e.mwqmrunlanguageFormEdit.controls.LastUpdateDate_UTC.errors),c.Bb(6),c.jc("ngIf",e.mwqmrunlanguageFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[w.q,w.l,w.f,S.b,a.l,q.c,q.f,C.b,w.n,w.c,w.k,w.e,I.a,a.k,T.a,q.b,R.n],pipes:[a.f],styles:[""],changeDetection:0}),t})();function J(t,e){1&t&&c.Ob(0,"mat-progress-bar",4)}function K(t,e){1&t&&c.Ob(0,"mat-progress-bar",4)}function Y(t,e){if(1&t&&(c.Tb(0,"p"),c.Ob(1,"app-mwqmrunlanguage-edit",8),c.Sb()),2&t){const t=c.ec().$implicit,e=c.ec(2);c.Bb(1),c.jc("mwqmrunlanguage",t)("httpClientCommand",e.GetPutEnum())}}function Z(t,e){if(1&t&&(c.Tb(0,"p"),c.Ob(1,"app-mwqmrunlanguage-edit",8),c.Sb()),2&t){const t=c.ec().$implicit,e=c.ec(2);c.Bb(1),c.jc("mwqmrunlanguage",t)("httpClientCommand",e.GetPostEnum())}}function tt(t,e){if(1&t){const t=c.Ub();c.Tb(0,"div"),c.Tb(1,"p"),c.Tb(2,"button",6),c.ac("click",(function(){c.rc(t);const n=e.$implicit;return c.ec(2).DeleteMWQMRunLanguage(n)})),c.Tb(3,"span"),c.yc(4),c.Sb(),c.Tb(5,"mat-icon"),c.yc(6,"delete"),c.Sb(),c.Sb(),c.yc(7,"\xa0\xa0\xa0 "),c.Tb(8,"button",7),c.ac("click",(function(){c.rc(t);const n=e.$implicit;return c.ec(2).ShowPut(n)})),c.Tb(9,"span"),c.yc(10,"Show Put"),c.Sb(),c.Sb(),c.yc(11,"\xa0\xa0 "),c.Tb(12,"button",7),c.ac("click",(function(){c.rc(t);const n=e.$implicit;return c.ec(2).ShowPost(n)})),c.Tb(13,"span"),c.yc(14,"Show Post"),c.Sb(),c.Sb(),c.yc(15,"\xa0\xa0 "),c.xc(16,K,1,0,"mat-progress-bar",0),c.Sb(),c.xc(17,Y,2,2,"p",2),c.xc(18,Z,2,2,"p",2),c.Tb(19,"blockquote"),c.Tb(20,"p"),c.Tb(21,"span"),c.yc(22),c.Sb(),c.Tb(23,"span"),c.yc(24),c.Sb(),c.Tb(25,"span"),c.yc(26),c.Sb(),c.Tb(27,"span"),c.yc(28),c.Sb(),c.Sb(),c.Tb(29,"p"),c.Tb(30,"span"),c.yc(31),c.Sb(),c.Tb(32,"span"),c.yc(33),c.Sb(),c.Tb(34,"span"),c.yc(35),c.Sb(),c.Tb(36,"span"),c.yc(37),c.Sb(),c.Sb(),c.Tb(38,"p"),c.Tb(39,"span"),c.yc(40),c.Sb(),c.Sb(),c.Sb(),c.Sb()}if(2&t){const t=e.$implicit,n=c.ec(2);c.Bb(4),c.Ac("Delete MWQMRunLanguageID [",t.MWQMRunLanguageID,"]\xa0\xa0\xa0"),c.Bb(4),c.jc("color",n.GetPutButtonColor(t)),c.Bb(4),c.jc("color",n.GetPostButtonColor(t)),c.Bb(4),c.jc("ngIf",n.mwqmrunlanguageService.mwqmrunlanguageDeleteModel$.getValue().Working),c.Bb(1),c.jc("ngIf",n.IDToShow===t.MWQMRunLanguageID&&n.showType===n.GetPutEnum()),c.Bb(1),c.jc("ngIf",n.IDToShow===t.MWQMRunLanguageID&&n.showType===n.GetPostEnum()),c.Bb(4),c.Ac("MWQMRunLanguageID: [",t.MWQMRunLanguageID,"]"),c.Bb(2),c.Ac(" --- MWQMRunID: [",t.MWQMRunID,"]"),c.Bb(2),c.Ac(" --- Language: [",n.GetLanguageEnumText(t.Language),"]"),c.Bb(2),c.Ac(" --- RunComment: [",t.RunComment,"]"),c.Bb(3),c.Ac("TranslationStatusRunComment: [",n.GetTranslationStatusEnumText(t.TranslationStatusRunComment),"]"),c.Bb(2),c.Ac(" --- RunWeatherComment: [",t.RunWeatherComment,"]"),c.Bb(2),c.Ac(" --- TranslationStatusRunWeatherComment: [",n.GetTranslationStatusEnumText(t.TranslationStatusRunWeatherComment),"]"),c.Bb(2),c.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),c.Bb(3),c.Ac("LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function et(t,e){if(1&t&&(c.Tb(0,"div"),c.xc(1,tt,41,15,"div",5),c.Sb()),2&t){const t=c.ec();c.Bb(1),c.jc("ngForOf",t.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue())}}const nt=[{path:"",component:(()=>{class t{constructor(t,e,n){this.mwqmrunlanguageService=t,this.router=e,this.httpClientService=n,this.showType=null,n.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.MWQMRunLanguageID&&this.showType===s.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.MWQMRunLanguageID&&this.showType===s.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.MWQMRunLanguageID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MWQMRunLanguageID,this.showType=s.a.Put)}ShowPost(t){this.IDToShow===t.MWQMRunLanguageID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MWQMRunLanguageID,this.showType=s.a.Post)}GetPutEnum(){return s.a.Put}GetPostEnum(){return s.a.Post}GetMWQMRunLanguageList(){this.sub=this.mwqmrunlanguageService.GetMWQMRunLanguageList().subscribe()}DeleteMWQMRunLanguage(t){this.sub=this.mwqmrunlanguageService.DeleteMWQMRunLanguage(t).subscribe()}GetLanguageEnumText(t){return Object(o.a)(t)}GetTranslationStatusEnumText(t){return Object(i.a)(t)}ngOnInit(){r(this.mwqmrunlanguageService.mwqmrunlanguageTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(c.Nb(d),c.Nb(u.b),c.Nb(h.a))},t.\u0275cmp=c.Hb({type:t,selectors:[["app-mwqmrunlanguage"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"mwqmrunlanguage","httpClientCommand"]],template:function(t,e){if(1&t&&(c.xc(0,J,1,0,"mat-progress-bar",0),c.Tb(1,"mat-card"),c.Tb(2,"mat-card-header"),c.Tb(3,"mat-card-title"),c.yc(4," MWQMRunLanguage works! "),c.Tb(5,"button",1),c.ac("click",(function(){return e.GetMWQMRunLanguageList()})),c.Tb(6,"span"),c.yc(7,"Get MWQMRunLanguage"),c.Sb(),c.Sb(),c.Sb(),c.Tb(8,"mat-card-subtitle"),c.yc(9),c.Sb(),c.Sb(),c.Tb(10,"mat-card-content"),c.xc(11,et,2,1,"div",2),c.Sb(),c.Tb(12,"mat-card-actions"),c.Tb(13,"button",3),c.yc(14,"Allo"),c.Sb(),c.Sb(),c.Sb()),2&t){var n;const t=null==(n=e.mwqmrunlanguageService.mwqmrunlanguageGetModel$.getValue())?null:n.Working;var a;const u=null==(a=e.mwqmrunlanguageService.mwqmrunlanguageListModel$.getValue())?null:a.length;c.jc("ngIf",t),c.Bb(9),c.zc(e.mwqmrunlanguageService.mwqmrunlanguageTextModel$.getValue().Title),c.Bb(2),c.jc("ngIf",u)}},directives:[a.l,f.a,f.d,f.g,S.b,f.f,f.c,f.b,T.a,a.k,M.a,_],styles:[""],changeDetection:0}),t})(),canActivate:[n("auXs").a]}];let at=(()=>{class t{}return t.\u0275mod=c.Lb({type:t}),t.\u0275inj=c.Kb({factory:function(e){return new(e||t)},imports:[[u.e.forChild(nt)],u.e]}),t})();var ut=n("B+Mi");let rt=(()=>{class t{}return t.\u0275mod=c.Lb({type:t}),t.\u0275inj=c.Kb({factory:function(e){return new(e||t)},imports:[[a.c,u.e,at,ut.a,w.g,w.o]]}),t})()},gkM4:function(t,e,n){"use strict";n.d(e,"a",(function(){return o}));var a=n("QRvi"),u=n("fXoL"),r=n("tyNb");let o=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,n,u,r){if(u===a.a.Get&&t.next(n),u===a.a.Put&&(t.getValue()[0]=n),u===a.a.Post&&t.getValue().push(n),u===a.a.Delete){const e=t.getValue().indexOf(r);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,n,u,r){u===a.a.Get&&t.next(n),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(u.Xb(r.b))},t.\u0275prov=u.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);