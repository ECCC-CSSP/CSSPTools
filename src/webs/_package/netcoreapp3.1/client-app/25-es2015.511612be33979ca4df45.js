(window.webpackJsonp=window.webpackJsonp||[]).push([[25],{PSTt:function(t,e,a){"use strict";function n(){let t=[];return $localize,t.push({EnumID:1,EnumText:"en"}),t.push({EnumID:2,EnumText:"fr"}),t.push({EnumID:3,EnumText:"enAndfr"}),t.push({EnumID:4,EnumText:"es"}),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}function i(t){let e;return n().forEach(a=>{if(a.EnumID==t)return e=a.EnumText,!1}),e}a.d(e,"b",(function(){return n})),a.d(e,"a",(function(){return i}))},QRvi:function(t,e,a){"use strict";a.d(e,"a",(function(){return n}));var n=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},XzWX:function(t,e,a){"use strict";a.r(e),a.d(e,"TVFileLanguageModule",(function(){return Z}));var n=a("ofXK"),i=a("tyNb");function l(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var o=a("PSTt"),r=a("BBgV"),u=a("QRvi"),s=a("fXoL"),c=a("2Vo4"),g=a("LRne"),b=a("tk/3"),f=a("lJxs"),p=a("JIr8"),T=a("gkM4");let m=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.tvfilelanguageTextModel$=new c.a({}),this.tvfilelanguageListModel$=new c.a({}),this.tvfilelanguageGetModel$=new c.a({}),this.tvfilelanguagePutModel$=new c.a({}),this.tvfilelanguagePostModel$=new c.a({}),this.tvfilelanguageDeleteModel$=new c.a({}),l(this.tvfilelanguageTextModel$),this.tvfilelanguageTextModel$.next({Title:"Something2 for text"})}GetTVFileLanguageList(){return this.httpClientService.BeforeHttpClient(this.tvfilelanguageGetModel$),this.httpClient.get("/api/TVFileLanguage").pipe(Object(f.a)(t=>{this.httpClientService.DoSuccess(this.tvfilelanguageListModel$,this.tvfilelanguageGetModel$,t,u.a.Get,null)}),Object(p.a)(t=>Object(g.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.tvfilelanguageListModel$,this.tvfilelanguageGetModel$,t)}))))}PutTVFileLanguage(t){return this.httpClientService.BeforeHttpClient(this.tvfilelanguagePutModel$),this.httpClient.put("/api/TVFileLanguage",t,{headers:new b.d}).pipe(Object(f.a)(e=>{this.httpClientService.DoSuccess(this.tvfilelanguageListModel$,this.tvfilelanguagePutModel$,e,u.a.Put,t)}),Object(p.a)(t=>Object(g.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.tvfilelanguageListModel$,this.tvfilelanguagePutModel$,t)}))))}PostTVFileLanguage(t){return this.httpClientService.BeforeHttpClient(this.tvfilelanguagePostModel$),this.httpClient.post("/api/TVFileLanguage",t,{headers:new b.d}).pipe(Object(f.a)(e=>{this.httpClientService.DoSuccess(this.tvfilelanguageListModel$,this.tvfilelanguagePostModel$,e,u.a.Post,t)}),Object(p.a)(t=>Object(g.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.tvfilelanguageListModel$,this.tvfilelanguagePostModel$,t)}))))}DeleteTVFileLanguage(t){return this.httpClientService.BeforeHttpClient(this.tvfilelanguageDeleteModel$),this.httpClient.delete("/api/TVFileLanguage/"+t.TVFileLanguageID).pipe(Object(f.a)(e=>{this.httpClientService.DoSuccess(this.tvfilelanguageListModel$,this.tvfilelanguageDeleteModel$,e,u.a.Delete,t)}),Object(p.a)(t=>Object(g.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.tvfilelanguageListModel$,this.tvfilelanguageDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(s.Xb(b.b),s.Xb(T.a))},t.\u0275prov=s.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var h=a("Wp6s"),d=a("bTqV"),v=a("bv9b"),S=a("NFeN"),D=a("3Pt+"),I=a("kmnG"),L=a("qFsG"),F=a("d3UM"),y=a("FKr1");function C(t,e){1&t&&s.Ob(0,"mat-progress-bar",12)}function V(t,e){1&t&&s.Ob(0,"mat-progress-bar",12)}function P(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function B(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,P,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function j(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function x(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,j,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function O(t,e){if(1&t&&(s.Tb(0,"mat-option",13),s.yc(1),s.Sb()),2&t){const t=e.$implicit;s.jc("value",t.EnumID),s.Bb(1),s.Ac(" ",t.EnumText," ")}}function $(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function E(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,$,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function w(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,1,t))}}function M(t,e){if(1&t&&(s.Tb(0,"mat-option",13),s.yc(1),s.Sb()),2&t){const t=e.$implicit;s.jc("value",t.EnumID),s.Bb(1),s.Ac(" ",t.EnumText," ")}}function G(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function k(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,G,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function U(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function q(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,U,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function R(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function N(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,R,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}let A=(()=>{class t{constructor(t,e){this.tvfilelanguageService=t,this.fb=e,this.tvfilelanguage=null,this.httpClientCommand=u.a.Put}GetPut(){return this.httpClientCommand==u.a.Put}PutTVFileLanguage(t){this.sub=this.tvfilelanguageService.PutTVFileLanguage(t).subscribe()}PostTVFileLanguage(t){this.sub=this.tvfilelanguageService.PostTVFileLanguage(t).subscribe()}ngOnInit(){this.languageList=Object(o.b)(),this.translationStatusList=Object(r.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.tvfilelanguage){let e=this.fb.group({TVFileLanguageID:[{value:t===u.a.Post?0:this.tvfilelanguage.TVFileLanguageID,disabled:!1},[D.p.required]],TVFileID:[{value:this.tvfilelanguage.TVFileID,disabled:!1},[D.p.required]],Language:[{value:this.tvfilelanguage.Language,disabled:!1},[D.p.required]],FileDescription:[{value:this.tvfilelanguage.FileDescription,disabled:!1}],TranslationStatus:[{value:this.tvfilelanguage.TranslationStatus,disabled:!1},[D.p.required]],LastUpdateDate_UTC:[{value:this.tvfilelanguage.LastUpdateDate_UTC,disabled:!1},[D.p.required]],LastUpdateContactTVItemID:[{value:this.tvfilelanguage.LastUpdateContactTVItemID,disabled:!1},[D.p.required]]});this.tvfilelanguageFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(s.Nb(m),s.Nb(D.d))},t.\u0275cmp=s.Hb({type:t,selectors:[["app-tvfilelanguage-edit"]],inputs:{tvfilelanguage:"tvfilelanguage",httpClientCommand:"httpClientCommand"},decls:47,vars:13,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TVFileLanguageID"],[4,"ngIf"],["matInput","","type","number","formControlName","TVFileID"],["formControlName","Language"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","FileDescription"],["formControlName","TranslationStatus"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(s.Tb(0,"form",0),s.ac("ngSubmit",(function(){return e.GetPut()?e.PutTVFileLanguage(e.tvfilelanguageFormEdit.value):e.PostTVFileLanguage(e.tvfilelanguageFormEdit.value)})),s.Tb(1,"h3"),s.yc(2," TVFileLanguage "),s.Tb(3,"button",1),s.Tb(4,"span"),s.yc(5),s.Sb(),s.Sb(),s.xc(6,C,1,0,"mat-progress-bar",2),s.xc(7,V,1,0,"mat-progress-bar",2),s.Sb(),s.Tb(8,"p"),s.Tb(9,"mat-form-field"),s.Tb(10,"mat-label"),s.yc(11,"TVFileLanguageID"),s.Sb(),s.Ob(12,"input",3),s.xc(13,B,6,4,"mat-error",4),s.Sb(),s.Tb(14,"mat-form-field"),s.Tb(15,"mat-label"),s.yc(16,"TVFileID"),s.Sb(),s.Ob(17,"input",5),s.xc(18,x,6,4,"mat-error",4),s.Sb(),s.Tb(19,"mat-form-field"),s.Tb(20,"mat-label"),s.yc(21,"Language"),s.Sb(),s.Tb(22,"mat-select",6),s.xc(23,O,2,2,"mat-option",7),s.Sb(),s.xc(24,E,6,4,"mat-error",4),s.Sb(),s.Tb(25,"mat-form-field"),s.Tb(26,"mat-label"),s.yc(27,"FileDescription"),s.Sb(),s.Ob(28,"input",8),s.xc(29,w,5,3,"mat-error",4),s.Sb(),s.Sb(),s.Tb(30,"p"),s.Tb(31,"mat-form-field"),s.Tb(32,"mat-label"),s.yc(33,"TranslationStatus"),s.Sb(),s.Tb(34,"mat-select",9),s.xc(35,M,2,2,"mat-option",7),s.Sb(),s.xc(36,k,6,4,"mat-error",4),s.Sb(),s.Tb(37,"mat-form-field"),s.Tb(38,"mat-label"),s.yc(39,"LastUpdateDate_UTC"),s.Sb(),s.Ob(40,"input",10),s.xc(41,q,6,4,"mat-error",4),s.Sb(),s.Tb(42,"mat-form-field"),s.Tb(43,"mat-label"),s.yc(44,"LastUpdateContactTVItemID"),s.Sb(),s.Ob(45,"input",11),s.xc(46,N,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Sb()),2&t&&(s.jc("formGroup",e.tvfilelanguageFormEdit),s.Bb(5),s.Ac("",e.GetPut()?"Put":"Post"," TVFileLanguage"),s.Bb(1),s.jc("ngIf",e.tvfilelanguageService.tvfilelanguagePutModel$.getValue().Working),s.Bb(1),s.jc("ngIf",e.tvfilelanguageService.tvfilelanguagePostModel$.getValue().Working),s.Bb(6),s.jc("ngIf",e.tvfilelanguageFormEdit.controls.TVFileLanguageID.errors),s.Bb(5),s.jc("ngIf",e.tvfilelanguageFormEdit.controls.TVFileID.errors),s.Bb(5),s.jc("ngForOf",e.languageList),s.Bb(1),s.jc("ngIf",e.tvfilelanguageFormEdit.controls.Language.errors),s.Bb(5),s.jc("ngIf",e.tvfilelanguageFormEdit.controls.FileDescription.errors),s.Bb(6),s.jc("ngForOf",e.translationStatusList),s.Bb(1),s.jc("ngIf",e.tvfilelanguageFormEdit.controls.TranslationStatus.errors),s.Bb(5),s.jc("ngIf",e.tvfilelanguageFormEdit.controls.LastUpdateDate_UTC.errors),s.Bb(5),s.jc("ngIf",e.tvfilelanguageFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[D.q,D.l,D.f,d.b,n.l,I.c,I.f,L.b,D.n,D.c,D.k,D.e,F.a,n.k,v.a,I.b,y.n],pipes:[n.f],styles:[""],changeDetection:0}),t})();function z(t,e){1&t&&s.Ob(0,"mat-progress-bar",4)}function W(t,e){1&t&&s.Ob(0,"mat-progress-bar",4)}function X(t,e){if(1&t&&(s.Tb(0,"p"),s.Ob(1,"app-tvfilelanguage-edit",8),s.Sb()),2&t){const t=s.ec().$implicit,e=s.ec(2);s.Bb(1),s.jc("tvfilelanguage",t)("httpClientCommand",e.GetPutEnum())}}function H(t,e){if(1&t&&(s.Tb(0,"p"),s.Ob(1,"app-tvfilelanguage-edit",8),s.Sb()),2&t){const t=s.ec().$implicit,e=s.ec(2);s.Bb(1),s.jc("tvfilelanguage",t)("httpClientCommand",e.GetPostEnum())}}function _(t,e){if(1&t){const t=s.Ub();s.Tb(0,"div"),s.Tb(1,"p"),s.Tb(2,"button",6),s.ac("click",(function(){s.rc(t);const a=e.$implicit;return s.ec(2).DeleteTVFileLanguage(a)})),s.Tb(3,"span"),s.yc(4),s.Sb(),s.Tb(5,"mat-icon"),s.yc(6,"delete"),s.Sb(),s.Sb(),s.yc(7,"\xa0\xa0\xa0 "),s.Tb(8,"button",7),s.ac("click",(function(){s.rc(t);const a=e.$implicit;return s.ec(2).ShowPut(a)})),s.Tb(9,"span"),s.yc(10,"Show Put"),s.Sb(),s.Sb(),s.yc(11,"\xa0\xa0 "),s.Tb(12,"button",7),s.ac("click",(function(){s.rc(t);const a=e.$implicit;return s.ec(2).ShowPost(a)})),s.Tb(13,"span"),s.yc(14,"Show Post"),s.Sb(),s.Sb(),s.yc(15,"\xa0\xa0 "),s.xc(16,W,1,0,"mat-progress-bar",0),s.Sb(),s.xc(17,X,2,2,"p",2),s.xc(18,H,2,2,"p",2),s.Tb(19,"blockquote"),s.Tb(20,"p"),s.Tb(21,"span"),s.yc(22),s.Sb(),s.Tb(23,"span"),s.yc(24),s.Sb(),s.Tb(25,"span"),s.yc(26),s.Sb(),s.Tb(27,"span"),s.yc(28),s.Sb(),s.Sb(),s.Tb(29,"p"),s.Tb(30,"span"),s.yc(31),s.Sb(),s.Tb(32,"span"),s.yc(33),s.Sb(),s.Tb(34,"span"),s.yc(35),s.Sb(),s.Sb(),s.Sb(),s.Sb()}if(2&t){const t=e.$implicit,a=s.ec(2);s.Bb(4),s.Ac("Delete TVFileLanguageID [",t.TVFileLanguageID,"]\xa0\xa0\xa0"),s.Bb(4),s.jc("color",a.GetPutButtonColor(t)),s.Bb(4),s.jc("color",a.GetPostButtonColor(t)),s.Bb(4),s.jc("ngIf",a.tvfilelanguageService.tvfilelanguageDeleteModel$.getValue().Working),s.Bb(1),s.jc("ngIf",a.IDToShow===t.TVFileLanguageID&&a.showType===a.GetPutEnum()),s.Bb(1),s.jc("ngIf",a.IDToShow===t.TVFileLanguageID&&a.showType===a.GetPostEnum()),s.Bb(4),s.Ac("TVFileLanguageID: [",t.TVFileLanguageID,"]"),s.Bb(2),s.Ac(" --- TVFileID: [",t.TVFileID,"]"),s.Bb(2),s.Ac(" --- Language: [",a.GetLanguageEnumText(t.Language),"]"),s.Bb(2),s.Ac(" --- FileDescription: [",t.FileDescription,"]"),s.Bb(3),s.Ac("TranslationStatus: [",a.GetTranslationStatusEnumText(t.TranslationStatus),"]"),s.Bb(2),s.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),s.Bb(2),s.Ac(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function J(t,e){if(1&t&&(s.Tb(0,"div"),s.xc(1,_,36,13,"div",5),s.Sb()),2&t){const t=s.ec();s.Bb(1),s.jc("ngForOf",t.tvfilelanguageService.tvfilelanguageListModel$.getValue())}}const K=[{path:"",component:(()=>{class t{constructor(t,e,a){this.tvfilelanguageService=t,this.router=e,this.httpClientService=a,this.showType=null,a.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.TVFileLanguageID&&this.showType===u.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.TVFileLanguageID&&this.showType===u.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.TVFileLanguageID&&this.showType===u.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TVFileLanguageID,this.showType=u.a.Put)}ShowPost(t){this.IDToShow===t.TVFileLanguageID&&this.showType===u.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TVFileLanguageID,this.showType=u.a.Post)}GetPutEnum(){return u.a.Put}GetPostEnum(){return u.a.Post}GetTVFileLanguageList(){this.sub=this.tvfilelanguageService.GetTVFileLanguageList().subscribe()}DeleteTVFileLanguage(t){this.sub=this.tvfilelanguageService.DeleteTVFileLanguage(t).subscribe()}GetLanguageEnumText(t){return Object(o.a)(t)}GetTranslationStatusEnumText(t){return Object(r.a)(t)}ngOnInit(){l(this.tvfilelanguageService.tvfilelanguageTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(s.Nb(m),s.Nb(i.b),s.Nb(T.a))},t.\u0275cmp=s.Hb({type:t,selectors:[["app-tvfilelanguage"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tvfilelanguage","httpClientCommand"]],template:function(t,e){if(1&t&&(s.xc(0,z,1,0,"mat-progress-bar",0),s.Tb(1,"mat-card"),s.Tb(2,"mat-card-header"),s.Tb(3,"mat-card-title"),s.yc(4," TVFileLanguage works! "),s.Tb(5,"button",1),s.ac("click",(function(){return e.GetTVFileLanguageList()})),s.Tb(6,"span"),s.yc(7,"Get TVFileLanguage"),s.Sb(),s.Sb(),s.Sb(),s.Tb(8,"mat-card-subtitle"),s.yc(9),s.Sb(),s.Sb(),s.Tb(10,"mat-card-content"),s.xc(11,J,2,1,"div",2),s.Sb(),s.Tb(12,"mat-card-actions"),s.Tb(13,"button",3),s.yc(14,"Allo"),s.Sb(),s.Sb(),s.Sb()),2&t){var a;const t=null==(a=e.tvfilelanguageService.tvfilelanguageGetModel$.getValue())?null:a.Working;var n;const i=null==(n=e.tvfilelanguageService.tvfilelanguageListModel$.getValue())?null:n.length;s.jc("ngIf",t),s.Bb(9),s.zc(e.tvfilelanguageService.tvfilelanguageTextModel$.getValue().Title),s.Bb(2),s.jc("ngIf",i)}},directives:[n.l,h.a,h.d,h.g,d.b,h.f,h.c,h.b,v.a,n.k,S.a,A],styles:[""],changeDetection:0}),t})(),canActivate:[a("auXs").a]}];let Q=(()=>{class t{}return t.\u0275mod=s.Lb({type:t}),t.\u0275inj=s.Kb({factory:function(e){return new(e||t)},imports:[[i.e.forChild(K)],i.e]}),t})();var Y=a("B+Mi");let Z=(()=>{class t{}return t.\u0275mod=s.Lb({type:t}),t.\u0275inj=s.Kb({factory:function(e){return new(e||t)},imports:[[n.c,i.e,Q,Y.a,D.g,D.o]]}),t})()},gkM4:function(t,e,a){"use strict";a.d(e,"a",(function(){return o}));var n=a("QRvi"),i=a("fXoL"),l=a("tyNb");let o=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,a){t.next(null),e.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,a){t.next(null),e.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,a,i,l){if(i===n.a.Get&&t.next(a),i===n.a.Put&&(t.getValue()[0]=a),i===n.a.Post&&t.getValue().push(a),i===n.a.Delete){const e=t.getValue().indexOf(l);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,a,i,l){i===n.a.Get&&t.next(a),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(i.Xb(l.b))},t.\u0275prov=i.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);