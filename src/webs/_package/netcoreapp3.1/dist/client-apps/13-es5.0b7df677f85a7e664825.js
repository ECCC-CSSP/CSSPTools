function _classCallCheck(t,a){if(!(t instanceof a))throw new TypeError("Cannot call a class as a function")}function _defineProperties(t,a){for(var e=0;e<a.length;e++){var n=a[e];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}function _createClass(t,a,e){return a&&_defineProperties(t.prototype,a),e&&_defineProperties(t,e),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[13],{PSTt:function(t,a,e){"use strict";function n(){var t=[];return $localize,t.push({EnumID:1,EnumText:"en"}),t.push({EnumID:2,EnumText:"fr"}),t.push({EnumID:3,EnumText:"enAndfr"}),t.push({EnumID:4,EnumText:"es"}),t.sort((function(t,a){return t.EnumText.localeCompare(a.EnumText)}))}function r(t){var a;return n().forEach((function(e){if(e.EnumID==t)return a=e.EnumText,!1})),a}e.d(a,"b",(function(){return n})),e.d(a,"a",(function(){return r}))},QRvi:function(t,a,e){"use strict";e.d(a,"a",(function(){return n}));var n=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,a,e){"use strict";e.d(a,"a",(function(){return i}));var n=e("QRvi"),r=e("fXoL"),s=e("tyNb"),i=function(){var t=function(){function t(a){_classCallCheck(this,t),this.router=a,this.oldURL=a.url}return _createClass(t,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,a,e){t.next(null),a.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,a,e,r,s){if(r===n.a.Get&&t.next(e),r===n.a.Put&&(t.getValue()[0]=e),r===n.a.Post&&t.getValue().push(e),r===n.a.Delete){var i=t.getValue().indexOf(s);t.getValue().splice(i,1)}t.next(t.getValue()),a.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),t}();return t.\u0275fac=function(a){return new(a||t)(r.Xb(s.b))},t.\u0275prov=r.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t}()},jcPN:function(t,a,e){"use strict";e.r(a),e.d(a,"AppTaskLanguageModule",(function(){return ut}));var n=e("ofXK"),r=e("tyNb");function s(t){var a={Title:"The title"};"fr-CA"===$localize.locale&&(a.Title="Le Titre"),t.next(a)}var i,u=e("PSTt"),o=e("BBgV"),p=e("QRvi"),c=e("fXoL"),l=e("2Vo4"),b=e("LRne"),g=e("tk/3"),f=e("lJxs"),T=e("JIr8"),m=e("gkM4"),k=((i=function(){function t(a,e){_classCallCheck(this,t),this.httpClient=a,this.httpClientService=e,this.apptasklanguageTextModel$=new l.a({}),this.apptasklanguageListModel$=new l.a({}),this.apptasklanguageGetModel$=new l.a({}),this.apptasklanguagePutModel$=new l.a({}),this.apptasklanguagePostModel$=new l.a({}),this.apptasklanguageDeleteModel$=new l.a({}),s(this.apptasklanguageTextModel$),this.apptasklanguageTextModel$.next({Title:"Something2 for text"})}return _createClass(t,[{key:"GetAppTaskLanguageList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.apptasklanguageGetModel$),this.httpClient.get("/api/AppTaskLanguage").pipe(Object(f.a)((function(a){t.httpClientService.DoSuccess(t.apptasklanguageListModel$,t.apptasklanguageGetModel$,a,p.a.Get,null)})),Object(T.a)((function(a){return Object(b.a)(a).pipe(Object(f.a)((function(a){t.httpClientService.DoCatchError(t.apptasklanguageListModel$,t.apptasklanguageGetModel$,a)})))})))}},{key:"PutAppTaskLanguage",value:function(t){var a=this;return this.httpClientService.BeforeHttpClient(this.apptasklanguagePutModel$),this.httpClient.put("/api/AppTaskLanguage",t,{headers:new g.d}).pipe(Object(f.a)((function(e){a.httpClientService.DoSuccess(a.apptasklanguageListModel$,a.apptasklanguagePutModel$,e,p.a.Put,t)})),Object(T.a)((function(t){return Object(b.a)(t).pipe(Object(f.a)((function(t){a.httpClientService.DoCatchError(a.apptasklanguageListModel$,a.apptasklanguagePutModel$,t)})))})))}},{key:"PostAppTaskLanguage",value:function(t){var a=this;return this.httpClientService.BeforeHttpClient(this.apptasklanguagePostModel$),this.httpClient.post("/api/AppTaskLanguage",t,{headers:new g.d}).pipe(Object(f.a)((function(e){a.httpClientService.DoSuccess(a.apptasklanguageListModel$,a.apptasklanguagePostModel$,e,p.a.Post,t)})),Object(T.a)((function(t){return Object(b.a)(t).pipe(Object(f.a)((function(t){a.httpClientService.DoCatchError(a.apptasklanguageListModel$,a.apptasklanguagePostModel$,t)})))})))}},{key:"DeleteAppTaskLanguage",value:function(t){var a=this;return this.httpClientService.BeforeHttpClient(this.apptasklanguageDeleteModel$),this.httpClient.delete("/api/AppTaskLanguage/"+t.AppTaskLanguageID).pipe(Object(f.a)((function(e){a.httpClientService.DoSuccess(a.apptasklanguageListModel$,a.apptasklanguageDeleteModel$,e,p.a.Delete,t)})),Object(T.a)((function(t){return Object(b.a)(t).pipe(Object(f.a)((function(t){a.httpClientService.DoCatchError(a.apptasklanguageListModel$,a.apptasklanguageDeleteModel$,t)})))})))}}]),t}()).\u0275fac=function(t){return new(t||i)(c.Xb(g.b),c.Xb(m.a))},i.\u0275prov=c.Jb({token:i,factory:i.\u0275fac,providedIn:"root"}),i),h=e("Wp6s"),d=e("bTqV"),S=e("bv9b"),v=e("NFeN"),y=e("3Pt+"),I=e("kmnG"),L=e("qFsG"),C=e("d3UM"),D=e("FKr1");function x(t,a){1&t&&c.Ob(0,"mat-progress-bar",13)}function A(t,a){1&t&&c.Ob(0,"mat-progress-bar",13)}function P(t,a){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function j(t,a){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,P,3,0,"span",4),c.Sb()),2&t){var e=a.$implicit;c.Bb(2),c.zc(c.gc(3,2,e)),c.Bb(3),c.jc("ngIf",e.required)}}function B(t,a){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function O(t,a){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,B,3,0,"span",4),c.Sb()),2&t){var e=a.$implicit;c.Bb(2),c.zc(c.gc(3,2,e)),c.Bb(3),c.jc("ngIf",e.required)}}function E(t,a){if(1&t&&(c.Tb(0,"mat-option",14),c.yc(1),c.Sb()),2&t){var e=a.$implicit;c.jc("value",e.EnumID),c.Bb(1),c.Ac(" ",e.EnumText," ")}}function $(t,a){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function w(t,a){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,$,3,0,"span",4),c.Sb()),2&t){var e=a.$implicit;c.Bb(2),c.zc(c.gc(3,2,e)),c.Bb(3),c.jc("ngIf",e.required)}}function M(t,a){1&t&&(c.Tb(0,"span"),c.yc(1,"MaxLength - 250"),c.Ob(2,"br"),c.Sb())}function G(t,a){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,M,3,0,"span",4),c.Sb()),2&t){var e=a.$implicit;c.Bb(2),c.zc(c.gc(3,2,e)),c.Bb(3),c.jc("ngIf",e.maxlength)}}function U(t,a){1&t&&(c.Tb(0,"span"),c.yc(1,"MaxLength - 250"),c.Ob(2,"br"),c.Sb())}function F(t,a){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,U,3,0,"span",4),c.Sb()),2&t){var e=a.$implicit;c.Bb(2),c.zc(c.gc(3,2,e)),c.Bb(3),c.jc("ngIf",e.maxlength)}}function q(t,a){if(1&t&&(c.Tb(0,"mat-option",14),c.yc(1),c.Sb()),2&t){var e=a.$implicit;c.jc("value",e.EnumID),c.Bb(1),c.Ac(" ",e.EnumText," ")}}function V(t,a){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function _(t,a){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,V,3,0,"span",4),c.Sb()),2&t){var e=a.$implicit;c.Bb(2),c.zc(c.gc(3,2,e)),c.Bb(3),c.jc("ngIf",e.required)}}function N(t,a){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function R(t,a){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,N,3,0,"span",4),c.Sb()),2&t){var e=a.$implicit;c.Bb(2),c.zc(c.gc(3,2,e)),c.Bb(3),c.jc("ngIf",e.required)}}function z(t,a){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function W(t,a){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,z,3,0,"span",4),c.Sb()),2&t){var e=a.$implicit;c.Bb(2),c.zc(c.gc(3,2,e)),c.Bb(3),c.jc("ngIf",e.required)}}var H,X=((H=function(){function t(a,e){_classCallCheck(this,t),this.apptasklanguageService=a,this.fb=e,this.apptasklanguage=null,this.httpClientCommand=p.a.Put}return _createClass(t,[{key:"GetPut",value:function(){return this.httpClientCommand==p.a.Put}},{key:"PutAppTaskLanguage",value:function(t){this.sub=this.apptasklanguageService.PutAppTaskLanguage(t).subscribe()}},{key:"PostAppTaskLanguage",value:function(t){this.sub=this.apptasklanguageService.PostAppTaskLanguage(t).subscribe()}},{key:"ngOnInit",value:function(){this.languageList=Object(u.b)(),this.translationStatusList=Object(o.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.apptasklanguage){var a=this.fb.group({AppTaskLanguageID:[{value:t===p.a.Post?0:this.apptasklanguage.AppTaskLanguageID,disabled:!1},[y.p.required]],AppTaskID:[{value:this.apptasklanguage.AppTaskID,disabled:!1},[y.p.required]],Language:[{value:this.apptasklanguage.Language,disabled:!1},[y.p.required]],StatusText:[{value:this.apptasklanguage.StatusText,disabled:!1},[y.p.maxLength(250)]],ErrorText:[{value:this.apptasklanguage.ErrorText,disabled:!1},[y.p.maxLength(250)]],TranslationStatus:[{value:this.apptasklanguage.TranslationStatus,disabled:!1},[y.p.required]],LastUpdateDate_UTC:[{value:this.apptasklanguage.LastUpdateDate_UTC,disabled:!1},[y.p.required]],LastUpdateContactTVItemID:[{value:this.apptasklanguage.LastUpdateContactTVItemID,disabled:!1},[y.p.required]]});this.apptasklanguageFormEdit=a}}}]),t}()).\u0275fac=function(t){return new(t||H)(c.Nb(k),c.Nb(y.d))},H.\u0275cmp=c.Hb({type:H,selectors:[["app-apptasklanguage-edit"]],inputs:{apptasklanguage:"apptasklanguage",httpClientCommand:"httpClientCommand"},decls:52,vars:14,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","AppTaskLanguageID"],[4,"ngIf"],["matInput","","type","number","formControlName","AppTaskID"],["formControlName","Language"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","StatusText"],["matInput","","type","text","formControlName","ErrorText"],["formControlName","TranslationStatus"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,a){1&t&&(c.Tb(0,"form",0),c.ac("ngSubmit",(function(){return a.GetPut()?a.PutAppTaskLanguage(a.apptasklanguageFormEdit.value):a.PostAppTaskLanguage(a.apptasklanguageFormEdit.value)})),c.Tb(1,"h3"),c.yc(2," AppTaskLanguage "),c.Tb(3,"button",1),c.Tb(4,"span"),c.yc(5),c.Sb(),c.Sb(),c.xc(6,x,1,0,"mat-progress-bar",2),c.xc(7,A,1,0,"mat-progress-bar",2),c.Sb(),c.Tb(8,"p"),c.Tb(9,"mat-form-field"),c.Tb(10,"mat-label"),c.yc(11,"AppTaskLanguageID"),c.Sb(),c.Ob(12,"input",3),c.xc(13,j,6,4,"mat-error",4),c.Sb(),c.Tb(14,"mat-form-field"),c.Tb(15,"mat-label"),c.yc(16,"AppTaskID"),c.Sb(),c.Ob(17,"input",5),c.xc(18,O,6,4,"mat-error",4),c.Sb(),c.Tb(19,"mat-form-field"),c.Tb(20,"mat-label"),c.yc(21,"Language"),c.Sb(),c.Tb(22,"mat-select",6),c.xc(23,E,2,2,"mat-option",7),c.Sb(),c.xc(24,w,6,4,"mat-error",4),c.Sb(),c.Tb(25,"mat-form-field"),c.Tb(26,"mat-label"),c.yc(27,"StatusText"),c.Sb(),c.Ob(28,"input",8),c.xc(29,G,6,4,"mat-error",4),c.Sb(),c.Sb(),c.Tb(30,"p"),c.Tb(31,"mat-form-field"),c.Tb(32,"mat-label"),c.yc(33,"ErrorText"),c.Sb(),c.Ob(34,"input",9),c.xc(35,F,6,4,"mat-error",4),c.Sb(),c.Tb(36,"mat-form-field"),c.Tb(37,"mat-label"),c.yc(38,"TranslationStatus"),c.Sb(),c.Tb(39,"mat-select",10),c.xc(40,q,2,2,"mat-option",7),c.Sb(),c.xc(41,_,6,4,"mat-error",4),c.Sb(),c.Tb(42,"mat-form-field"),c.Tb(43,"mat-label"),c.yc(44,"LastUpdateDate_UTC"),c.Sb(),c.Ob(45,"input",11),c.xc(46,R,6,4,"mat-error",4),c.Sb(),c.Tb(47,"mat-form-field"),c.Tb(48,"mat-label"),c.yc(49,"LastUpdateContactTVItemID"),c.Sb(),c.Ob(50,"input",12),c.xc(51,W,6,4,"mat-error",4),c.Sb(),c.Sb(),c.Sb()),2&t&&(c.jc("formGroup",a.apptasklanguageFormEdit),c.Bb(5),c.Ac("",a.GetPut()?"Put":"Post"," AppTaskLanguage"),c.Bb(1),c.jc("ngIf",a.apptasklanguageService.apptasklanguagePutModel$.getValue().Working),c.Bb(1),c.jc("ngIf",a.apptasklanguageService.apptasklanguagePostModel$.getValue().Working),c.Bb(6),c.jc("ngIf",a.apptasklanguageFormEdit.controls.AppTaskLanguageID.errors),c.Bb(5),c.jc("ngIf",a.apptasklanguageFormEdit.controls.AppTaskID.errors),c.Bb(5),c.jc("ngForOf",a.languageList),c.Bb(1),c.jc("ngIf",a.apptasklanguageFormEdit.controls.Language.errors),c.Bb(5),c.jc("ngIf",a.apptasklanguageFormEdit.controls.StatusText.errors),c.Bb(6),c.jc("ngIf",a.apptasklanguageFormEdit.controls.ErrorText.errors),c.Bb(5),c.jc("ngForOf",a.translationStatusList),c.Bb(1),c.jc("ngIf",a.apptasklanguageFormEdit.controls.TranslationStatus.errors),c.Bb(5),c.jc("ngIf",a.apptasklanguageFormEdit.controls.LastUpdateDate_UTC.errors),c.Bb(5),c.jc("ngIf",a.apptasklanguageFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[y.q,y.l,y.f,d.b,n.l,I.c,I.f,L.b,y.n,y.c,y.k,y.e,C.a,n.k,S.a,I.b,D.n],pipes:[n.f],styles:[""],changeDetection:0}),H);function J(t,a){1&t&&c.Ob(0,"mat-progress-bar",4)}function K(t,a){1&t&&c.Ob(0,"mat-progress-bar",4)}function Q(t,a){if(1&t&&(c.Tb(0,"p"),c.Ob(1,"app-apptasklanguage-edit",8),c.Sb()),2&t){var e=c.ec().$implicit,n=c.ec(2);c.Bb(1),c.jc("apptasklanguage",e)("httpClientCommand",n.GetPutEnum())}}function Y(t,a){if(1&t&&(c.Tb(0,"p"),c.Ob(1,"app-apptasklanguage-edit",8),c.Sb()),2&t){var e=c.ec().$implicit,n=c.ec(2);c.Bb(1),c.jc("apptasklanguage",e)("httpClientCommand",n.GetPostEnum())}}function Z(t,a){if(1&t){var e=c.Ub();c.Tb(0,"div"),c.Tb(1,"p"),c.Tb(2,"button",6),c.ac("click",(function(){c.rc(e);var t=a.$implicit;return c.ec(2).DeleteAppTaskLanguage(t)})),c.Tb(3,"span"),c.yc(4),c.Sb(),c.Tb(5,"mat-icon"),c.yc(6,"delete"),c.Sb(),c.Sb(),c.yc(7,"\xa0\xa0\xa0 "),c.Tb(8,"button",7),c.ac("click",(function(){c.rc(e);var t=a.$implicit;return c.ec(2).ShowPut(t)})),c.Tb(9,"span"),c.yc(10,"Show Put"),c.Sb(),c.Sb(),c.yc(11,"\xa0\xa0 "),c.Tb(12,"button",7),c.ac("click",(function(){c.rc(e);var t=a.$implicit;return c.ec(2).ShowPost(t)})),c.Tb(13,"span"),c.yc(14,"Show Post"),c.Sb(),c.Sb(),c.yc(15,"\xa0\xa0 "),c.xc(16,K,1,0,"mat-progress-bar",0),c.Sb(),c.xc(17,Q,2,2,"p",2),c.xc(18,Y,2,2,"p",2),c.Tb(19,"blockquote"),c.Tb(20,"p"),c.Tb(21,"span"),c.yc(22),c.Sb(),c.Tb(23,"span"),c.yc(24),c.Sb(),c.Tb(25,"span"),c.yc(26),c.Sb(),c.Tb(27,"span"),c.yc(28),c.Sb(),c.Sb(),c.Tb(29,"p"),c.Tb(30,"span"),c.yc(31),c.Sb(),c.Tb(32,"span"),c.yc(33),c.Sb(),c.Tb(34,"span"),c.yc(35),c.Sb(),c.Tb(36,"span"),c.yc(37),c.Sb(),c.Sb(),c.Sb(),c.Sb()}if(2&t){var n=a.$implicit,r=c.ec(2);c.Bb(4),c.Ac("Delete AppTaskLanguageID [",n.AppTaskLanguageID,"]\xa0\xa0\xa0"),c.Bb(4),c.jc("color",r.GetPutButtonColor(n)),c.Bb(4),c.jc("color",r.GetPostButtonColor(n)),c.Bb(4),c.jc("ngIf",r.apptasklanguageService.apptasklanguageDeleteModel$.getValue().Working),c.Bb(1),c.jc("ngIf",r.IDToShow===n.AppTaskLanguageID&&r.showType===r.GetPutEnum()),c.Bb(1),c.jc("ngIf",r.IDToShow===n.AppTaskLanguageID&&r.showType===r.GetPostEnum()),c.Bb(4),c.Ac("AppTaskLanguageID: [",n.AppTaskLanguageID,"]"),c.Bb(2),c.Ac(" --- AppTaskID: [",n.AppTaskID,"]"),c.Bb(2),c.Ac(" --- Language: [",r.GetLanguageEnumText(n.Language),"]"),c.Bb(2),c.Ac(" --- StatusText: [",n.StatusText,"]"),c.Bb(3),c.Ac("ErrorText: [",n.ErrorText,"]"),c.Bb(2),c.Ac(" --- TranslationStatus: [",r.GetTranslationStatusEnumText(n.TranslationStatus),"]"),c.Bb(2),c.Ac(" --- LastUpdateDate_UTC: [",n.LastUpdateDate_UTC,"]"),c.Bb(2),c.Ac(" --- LastUpdateContactTVItemID: [",n.LastUpdateContactTVItemID,"]")}}function tt(t,a){if(1&t&&(c.Tb(0,"div"),c.xc(1,Z,38,14,"div",5),c.Sb()),2&t){var e=c.ec();c.Bb(1),c.jc("ngForOf",e.apptasklanguageService.apptasklanguageListModel$.getValue())}}var at,et,nt,rt=[{path:"",component:(at=function(){function t(a,e,n){_classCallCheck(this,t),this.apptasklanguageService=a,this.router=e,this.httpClientService=n,this.showType=null,n.oldURL=e.url}return _createClass(t,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.AppTaskLanguageID&&this.showType===p.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.AppTaskLanguageID&&this.showType===p.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.AppTaskLanguageID&&this.showType===p.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.AppTaskLanguageID,this.showType=p.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.AppTaskLanguageID&&this.showType===p.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.AppTaskLanguageID,this.showType=p.a.Post)}},{key:"GetPutEnum",value:function(){return p.a.Put}},{key:"GetPostEnum",value:function(){return p.a.Post}},{key:"GetAppTaskLanguageList",value:function(){this.sub=this.apptasklanguageService.GetAppTaskLanguageList().subscribe()}},{key:"DeleteAppTaskLanguage",value:function(t){this.sub=this.apptasklanguageService.DeleteAppTaskLanguage(t).subscribe()}},{key:"GetLanguageEnumText",value:function(t){return Object(u.a)(t)}},{key:"GetTranslationStatusEnumText",value:function(t){return Object(o.a)(t)}},{key:"ngOnInit",value:function(){s(this.apptasklanguageService.apptasklanguageTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),t}(),at.\u0275fac=function(t){return new(t||at)(c.Nb(k),c.Nb(r.b),c.Nb(m.a))},at.\u0275cmp=c.Hb({type:at,selectors:[["app-apptasklanguage"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"apptasklanguage","httpClientCommand"]],template:function(t,a){if(1&t&&(c.xc(0,J,1,0,"mat-progress-bar",0),c.Tb(1,"mat-card"),c.Tb(2,"mat-card-header"),c.Tb(3,"mat-card-title"),c.yc(4," AppTaskLanguage works! "),c.Tb(5,"button",1),c.ac("click",(function(){return a.GetAppTaskLanguageList()})),c.Tb(6,"span"),c.yc(7,"Get AppTaskLanguage"),c.Sb(),c.Sb(),c.Sb(),c.Tb(8,"mat-card-subtitle"),c.yc(9),c.Sb(),c.Sb(),c.Tb(10,"mat-card-content"),c.xc(11,tt,2,1,"div",2),c.Sb(),c.Tb(12,"mat-card-actions"),c.Tb(13,"button",3),c.yc(14,"Allo"),c.Sb(),c.Sb(),c.Sb()),2&t){var e,n,r=null==(e=a.apptasklanguageService.apptasklanguageGetModel$.getValue())?null:e.Working,s=null==(n=a.apptasklanguageService.apptasklanguageListModel$.getValue())?null:n.length;c.jc("ngIf",r),c.Bb(9),c.zc(a.apptasklanguageService.apptasklanguageTextModel$.getValue().Title),c.Bb(2),c.jc("ngIf",s)}},directives:[n.l,h.a,h.d,h.g,d.b,h.f,h.c,h.b,S.a,n.k,v.a,X],styles:[""],changeDetection:0}),at),canActivate:[e("auXs").a]}],st=((et=function t(){_classCallCheck(this,t)}).\u0275mod=c.Lb({type:et}),et.\u0275inj=c.Kb({factory:function(t){return new(t||et)},imports:[[r.e.forChild(rt)],r.e]}),et),it=e("B+Mi"),ut=((nt=function t(){_classCallCheck(this,t)}).\u0275mod=c.Lb({type:nt}),nt.\u0275inj=c.Kb({factory:function(t){return new(t||nt)},imports:[[n.c,r.e,st,it.a,y.g,y.o]]}),nt)}}]);