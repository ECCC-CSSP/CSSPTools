(window.webpackJsonp=window.webpackJsonp||[]).push([[14],{PSTt:function(e,t,o){"use strict";function a(){let e=[];return $localize,e.push({EnumID:1,EnumText:"en"}),e.push({EnumID:2,EnumText:"fr"}),e.push({EnumID:3,EnumText:"enAndfr"}),e.push({EnumID:4,EnumText:"es"}),e.sort((e,t)=>e.EnumText.localeCompare(t.EnumText))}function n(e){let t;return a().forEach(o=>{if(o.EnumID==e)return t=o.EnumText,!1}),t}o.d(t,"b",(function(){return a})),o.d(t,"a",(function(){return n}))},QRvi:function(e,t,o){"use strict";o.d(t,"a",(function(){return a}));var a=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,o){"use strict";o.d(t,"a",(function(){return i}));var a=o("QRvi"),n=o("fXoL"),l=o("tyNb");let i=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,t,o){e.next(null),t.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(e,t,o){e.next(null),t.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,t,o,n,l){if(n===a.a.Get&&e.next(o),n===a.a.Put&&(e.getValue()[0]=o),n===a.a.Post&&e.getValue().push(o),n===a.a.Delete){const t=e.getValue().indexOf(l);e.getValue().splice(t,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(e,t,o,n,l){n===a.a.Get&&e.next(o),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(t){return new(t||e)(n.Xb(l.b))},e.\u0275prov=n.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()},mAw6:function(e,t,o){"use strict";o.r(t),o.d(t,"BoxModelLanguageModule",(function(){return te}));var a=o("ofXK"),n=o("tyNb");function l(e){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var i=o("PSTt"),r=o("BBgV"),u=o("QRvi"),b=o("fXoL"),c=o("2Vo4"),s=o("LRne"),g=o("tk/3"),d=o("lJxs"),m=o("JIr8"),p=o("gkM4");let x=(()=>{class e{constructor(e,t){this.httpClient=e,this.httpClientService=t,this.boxmodellanguageTextModel$=new c.a({}),this.boxmodellanguageListModel$=new c.a({}),this.boxmodellanguageGetModel$=new c.a({}),this.boxmodellanguagePutModel$=new c.a({}),this.boxmodellanguagePostModel$=new c.a({}),this.boxmodellanguageDeleteModel$=new c.a({}),l(this.boxmodellanguageTextModel$),this.boxmodellanguageTextModel$.next({Title:"Something2 for text"})}GetBoxModelLanguageList(){return this.httpClientService.BeforeHttpClient(this.boxmodellanguageGetModel$),this.httpClient.get("/api/BoxModelLanguage").pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.boxmodellanguageListModel$,this.boxmodellanguageGetModel$,e,u.a.Get,null)}),Object(m.a)(e=>Object(s.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.boxmodellanguageListModel$,this.boxmodellanguageGetModel$,e)}))))}PutBoxModelLanguage(e){return this.httpClientService.BeforeHttpClient(this.boxmodellanguagePutModel$),this.httpClient.put("/api/BoxModelLanguage",e,{headers:new g.d}).pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.boxmodellanguageListModel$,this.boxmodellanguagePutModel$,t,u.a.Put,e)}),Object(m.a)(e=>Object(s.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.boxmodellanguageListModel$,this.boxmodellanguagePutModel$,e)}))))}PostBoxModelLanguage(e){return this.httpClientService.BeforeHttpClient(this.boxmodellanguagePostModel$),this.httpClient.post("/api/BoxModelLanguage",e,{headers:new g.d}).pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.boxmodellanguageListModel$,this.boxmodellanguagePostModel$,t,u.a.Post,e)}),Object(m.a)(e=>Object(s.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.boxmodellanguageListModel$,this.boxmodellanguagePostModel$,e)}))))}DeleteBoxModelLanguage(e){return this.httpClientService.BeforeHttpClient(this.boxmodellanguageDeleteModel$),this.httpClient.delete("/api/BoxModelLanguage/"+e.BoxModelLanguageID).pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.boxmodellanguageListModel$,this.boxmodellanguageDeleteModel$,t,u.a.Delete,e)}),Object(m.a)(e=>Object(s.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.boxmodellanguageListModel$,this.boxmodellanguageDeleteModel$,e)}))))}}return e.\u0275fac=function(t){return new(t||e)(b.Xb(g.b),b.Xb(p.a))},e.\u0275prov=b.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var h=o("Wp6s"),f=o("bTqV"),S=o("bv9b"),T=o("NFeN"),B=o("3Pt+"),I=o("kmnG"),L=o("qFsG"),M=o("d3UM"),D=o("FKr1");function y(e,t){1&e&&b.Ob(0,"mat-progress-bar",12)}function C(e,t){1&e&&b.Ob(0,"mat-progress-bar",12)}function v(e,t){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function j(e,t){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,v,3,0,"span",4),b.Sb()),2&e){const e=t.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function P(e,t){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function O(e,t){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,P,3,0,"span",4),b.Sb()),2&e){const e=t.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function $(e,t){if(1&e&&(b.Tb(0,"mat-option",13),b.yc(1),b.Sb()),2&e){const e=t.$implicit;b.jc("value",e.EnumID),b.Bb(1),b.Ac(" ",e.EnumText," ")}}function E(e,t){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function w(e,t){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,E,3,0,"span",4),b.Sb()),2&e){const e=t.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function G(e,t){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function k(e,t){1&e&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 250"),b.Ob(2,"br"),b.Sb())}function U(e,t){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,G,3,0,"span",4),b.xc(6,k,3,0,"span",4),b.Sb()),2&e){const e=t.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.required),b.Bb(1),b.jc("ngIf",e.maxlength)}}function q(e,t){if(1&e&&(b.Tb(0,"mat-option",13),b.yc(1),b.Sb()),2&e){const e=t.$implicit;b.jc("value",e.EnumID),b.Bb(1),b.Ac(" ",e.EnumText," ")}}function F(e,t){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function N(e,t){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,F,3,0,"span",4),b.Sb()),2&e){const e=t.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function V(e,t){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function R(e,t){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,V,3,0,"span",4),b.Sb()),2&e){const e=t.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function A(e,t){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function z(e,t){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,A,3,0,"span",4),b.Sb()),2&e){const e=t.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}let W=(()=>{class e{constructor(e,t){this.boxmodellanguageService=e,this.fb=t,this.boxmodellanguage=null,this.httpClientCommand=u.a.Put}GetPut(){return this.httpClientCommand==u.a.Put}PutBoxModelLanguage(e){this.sub=this.boxmodellanguageService.PutBoxModelLanguage(e).subscribe()}PostBoxModelLanguage(e){this.sub=this.boxmodellanguageService.PostBoxModelLanguage(e).subscribe()}ngOnInit(){this.languageList=Object(i.b)(),this.translationStatusList=Object(r.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.boxmodellanguage){let t=this.fb.group({BoxModelLanguageID:[{value:e===u.a.Post?0:this.boxmodellanguage.BoxModelLanguageID,disabled:!1},[B.p.required]],BoxModelID:[{value:this.boxmodellanguage.BoxModelID,disabled:!1},[B.p.required]],Language:[{value:this.boxmodellanguage.Language,disabled:!1},[B.p.required]],ScenarioName:[{value:this.boxmodellanguage.ScenarioName,disabled:!1},[B.p.required,B.p.maxLength(250)]],TranslationStatus:[{value:this.boxmodellanguage.TranslationStatus,disabled:!1},[B.p.required]],LastUpdateDate_UTC:[{value:this.boxmodellanguage.LastUpdateDate_UTC,disabled:!1},[B.p.required]],LastUpdateContactTVItemID:[{value:this.boxmodellanguage.LastUpdateContactTVItemID,disabled:!1},[B.p.required]]});this.boxmodellanguageFormEdit=t}}}return e.\u0275fac=function(t){return new(t||e)(b.Nb(x),b.Nb(B.d))},e.\u0275cmp=b.Hb({type:e,selectors:[["app-boxmodellanguage-edit"]],inputs:{boxmodellanguage:"boxmodellanguage",httpClientCommand:"httpClientCommand"},decls:47,vars:13,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","BoxModelLanguageID"],[4,"ngIf"],["matInput","","type","number","formControlName","BoxModelID"],["formControlName","Language"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","ScenarioName"],["formControlName","TranslationStatus"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(b.Tb(0,"form",0),b.ac("ngSubmit",(function(){return t.GetPut()?t.PutBoxModelLanguage(t.boxmodellanguageFormEdit.value):t.PostBoxModelLanguage(t.boxmodellanguageFormEdit.value)})),b.Tb(1,"h3"),b.yc(2," BoxModelLanguage "),b.Tb(3,"button",1),b.Tb(4,"span"),b.yc(5),b.Sb(),b.Sb(),b.xc(6,y,1,0,"mat-progress-bar",2),b.xc(7,C,1,0,"mat-progress-bar",2),b.Sb(),b.Tb(8,"p"),b.Tb(9,"mat-form-field"),b.Tb(10,"mat-label"),b.yc(11,"BoxModelLanguageID"),b.Sb(),b.Ob(12,"input",3),b.xc(13,j,6,4,"mat-error",4),b.Sb(),b.Tb(14,"mat-form-field"),b.Tb(15,"mat-label"),b.yc(16,"BoxModelID"),b.Sb(),b.Ob(17,"input",5),b.xc(18,O,6,4,"mat-error",4),b.Sb(),b.Tb(19,"mat-form-field"),b.Tb(20,"mat-label"),b.yc(21,"Language"),b.Sb(),b.Tb(22,"mat-select",6),b.xc(23,$,2,2,"mat-option",7),b.Sb(),b.xc(24,w,6,4,"mat-error",4),b.Sb(),b.Tb(25,"mat-form-field"),b.Tb(26,"mat-label"),b.yc(27,"ScenarioName"),b.Sb(),b.Ob(28,"input",8),b.xc(29,U,7,5,"mat-error",4),b.Sb(),b.Sb(),b.Tb(30,"p"),b.Tb(31,"mat-form-field"),b.Tb(32,"mat-label"),b.yc(33,"TranslationStatus"),b.Sb(),b.Tb(34,"mat-select",9),b.xc(35,q,2,2,"mat-option",7),b.Sb(),b.xc(36,N,6,4,"mat-error",4),b.Sb(),b.Tb(37,"mat-form-field"),b.Tb(38,"mat-label"),b.yc(39,"LastUpdateDate_UTC"),b.Sb(),b.Ob(40,"input",10),b.xc(41,R,6,4,"mat-error",4),b.Sb(),b.Tb(42,"mat-form-field"),b.Tb(43,"mat-label"),b.yc(44,"LastUpdateContactTVItemID"),b.Sb(),b.Ob(45,"input",11),b.xc(46,z,6,4,"mat-error",4),b.Sb(),b.Sb(),b.Sb()),2&e&&(b.jc("formGroup",t.boxmodellanguageFormEdit),b.Bb(5),b.Ac("",t.GetPut()?"Put":"Post"," BoxModelLanguage"),b.Bb(1),b.jc("ngIf",t.boxmodellanguageService.boxmodellanguagePutModel$.getValue().Working),b.Bb(1),b.jc("ngIf",t.boxmodellanguageService.boxmodellanguagePostModel$.getValue().Working),b.Bb(6),b.jc("ngIf",t.boxmodellanguageFormEdit.controls.BoxModelLanguageID.errors),b.Bb(5),b.jc("ngIf",t.boxmodellanguageFormEdit.controls.BoxModelID.errors),b.Bb(5),b.jc("ngForOf",t.languageList),b.Bb(1),b.jc("ngIf",t.boxmodellanguageFormEdit.controls.Language.errors),b.Bb(5),b.jc("ngIf",t.boxmodellanguageFormEdit.controls.ScenarioName.errors),b.Bb(6),b.jc("ngForOf",t.translationStatusList),b.Bb(1),b.jc("ngIf",t.boxmodellanguageFormEdit.controls.TranslationStatus.errors),b.Bb(5),b.jc("ngIf",t.boxmodellanguageFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(5),b.jc("ngIf",t.boxmodellanguageFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[B.q,B.l,B.f,f.b,a.l,I.c,I.f,L.b,B.n,B.c,B.k,B.e,M.a,a.k,S.a,I.b,D.n],pipes:[a.f],styles:[""],changeDetection:0}),e})();function H(e,t){1&e&&b.Ob(0,"mat-progress-bar",4)}function X(e,t){1&e&&b.Ob(0,"mat-progress-bar",4)}function _(e,t){if(1&e&&(b.Tb(0,"p"),b.Ob(1,"app-boxmodellanguage-edit",8),b.Sb()),2&e){const e=b.ec().$implicit,t=b.ec(2);b.Bb(1),b.jc("boxmodellanguage",e)("httpClientCommand",t.GetPutEnum())}}function J(e,t){if(1&e&&(b.Tb(0,"p"),b.Ob(1,"app-boxmodellanguage-edit",8),b.Sb()),2&e){const e=b.ec().$implicit,t=b.ec(2);b.Bb(1),b.jc("boxmodellanguage",e)("httpClientCommand",t.GetPostEnum())}}function K(e,t){if(1&e){const e=b.Ub();b.Tb(0,"div"),b.Tb(1,"p"),b.Tb(2,"button",6),b.ac("click",(function(){b.rc(e);const o=t.$implicit;return b.ec(2).DeleteBoxModelLanguage(o)})),b.Tb(3,"span"),b.yc(4),b.Sb(),b.Tb(5,"mat-icon"),b.yc(6,"delete"),b.Sb(),b.Sb(),b.yc(7,"\xa0\xa0\xa0 "),b.Tb(8,"button",7),b.ac("click",(function(){b.rc(e);const o=t.$implicit;return b.ec(2).ShowPut(o)})),b.Tb(9,"span"),b.yc(10,"Show Put"),b.Sb(),b.Sb(),b.yc(11,"\xa0\xa0 "),b.Tb(12,"button",7),b.ac("click",(function(){b.rc(e);const o=t.$implicit;return b.ec(2).ShowPost(o)})),b.Tb(13,"span"),b.yc(14,"Show Post"),b.Sb(),b.Sb(),b.yc(15,"\xa0\xa0 "),b.xc(16,X,1,0,"mat-progress-bar",0),b.Sb(),b.xc(17,_,2,2,"p",2),b.xc(18,J,2,2,"p",2),b.Tb(19,"blockquote"),b.Tb(20,"p"),b.Tb(21,"span"),b.yc(22),b.Sb(),b.Tb(23,"span"),b.yc(24),b.Sb(),b.Tb(25,"span"),b.yc(26),b.Sb(),b.Tb(27,"span"),b.yc(28),b.Sb(),b.Sb(),b.Tb(29,"p"),b.Tb(30,"span"),b.yc(31),b.Sb(),b.Tb(32,"span"),b.yc(33),b.Sb(),b.Tb(34,"span"),b.yc(35),b.Sb(),b.Sb(),b.Sb(),b.Sb()}if(2&e){const e=t.$implicit,o=b.ec(2);b.Bb(4),b.Ac("Delete BoxModelLanguageID [",e.BoxModelLanguageID,"]\xa0\xa0\xa0"),b.Bb(4),b.jc("color",o.GetPutButtonColor(e)),b.Bb(4),b.jc("color",o.GetPostButtonColor(e)),b.Bb(4),b.jc("ngIf",o.boxmodellanguageService.boxmodellanguageDeleteModel$.getValue().Working),b.Bb(1),b.jc("ngIf",o.IDToShow===e.BoxModelLanguageID&&o.showType===o.GetPutEnum()),b.Bb(1),b.jc("ngIf",o.IDToShow===e.BoxModelLanguageID&&o.showType===o.GetPostEnum()),b.Bb(4),b.Ac("BoxModelLanguageID: [",e.BoxModelLanguageID,"]"),b.Bb(2),b.Ac(" --- BoxModelID: [",e.BoxModelID,"]"),b.Bb(2),b.Ac(" --- Language: [",o.GetLanguageEnumText(e.Language),"]"),b.Bb(2),b.Ac(" --- ScenarioName: [",e.ScenarioName,"]"),b.Bb(3),b.Ac("TranslationStatus: [",o.GetTranslationStatusEnumText(e.TranslationStatus),"]"),b.Bb(2),b.Ac(" --- LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),b.Bb(2),b.Ac(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function Q(e,t){if(1&e&&(b.Tb(0,"div"),b.xc(1,K,36,13,"div",5),b.Sb()),2&e){const e=b.ec();b.Bb(1),b.jc("ngForOf",e.boxmodellanguageService.boxmodellanguageListModel$.getValue())}}const Y=[{path:"",component:(()=>{class e{constructor(e,t,o){this.boxmodellanguageService=e,this.router=t,this.httpClientService=o,this.showType=null,o.oldURL=t.url}GetPutButtonColor(e){return this.IDToShow===e.BoxModelLanguageID&&this.showType===u.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.BoxModelLanguageID&&this.showType===u.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.BoxModelLanguageID&&this.showType===u.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.BoxModelLanguageID,this.showType=u.a.Put)}ShowPost(e){this.IDToShow===e.BoxModelLanguageID&&this.showType===u.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.BoxModelLanguageID,this.showType=u.a.Post)}GetPutEnum(){return u.a.Put}GetPostEnum(){return u.a.Post}GetBoxModelLanguageList(){this.sub=this.boxmodellanguageService.GetBoxModelLanguageList().subscribe()}DeleteBoxModelLanguage(e){this.sub=this.boxmodellanguageService.DeleteBoxModelLanguage(e).subscribe()}GetLanguageEnumText(e){return Object(i.a)(e)}GetTranslationStatusEnumText(e){return Object(r.a)(e)}ngOnInit(){l(this.boxmodellanguageService.boxmodellanguageTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(t){return new(t||e)(b.Nb(x),b.Nb(n.b),b.Nb(p.a))},e.\u0275cmp=b.Hb({type:e,selectors:[["app-boxmodellanguage"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"boxmodellanguage","httpClientCommand"]],template:function(e,t){if(1&e&&(b.xc(0,H,1,0,"mat-progress-bar",0),b.Tb(1,"mat-card"),b.Tb(2,"mat-card-header"),b.Tb(3,"mat-card-title"),b.yc(4," BoxModelLanguage works! "),b.Tb(5,"button",1),b.ac("click",(function(){return t.GetBoxModelLanguageList()})),b.Tb(6,"span"),b.yc(7,"Get BoxModelLanguage"),b.Sb(),b.Sb(),b.Sb(),b.Tb(8,"mat-card-subtitle"),b.yc(9),b.Sb(),b.Sb(),b.Tb(10,"mat-card-content"),b.xc(11,Q,2,1,"div",2),b.Sb(),b.Tb(12,"mat-card-actions"),b.Tb(13,"button",3),b.yc(14,"Allo"),b.Sb(),b.Sb(),b.Sb()),2&e){var o;const e=null==(o=t.boxmodellanguageService.boxmodellanguageGetModel$.getValue())?null:o.Working;var a;const n=null==(a=t.boxmodellanguageService.boxmodellanguageListModel$.getValue())?null:a.length;b.jc("ngIf",e),b.Bb(9),b.zc(t.boxmodellanguageService.boxmodellanguageTextModel$.getValue().Title),b.Bb(2),b.jc("ngIf",n)}},directives:[a.l,h.a,h.d,h.g,f.b,h.f,h.c,h.b,S.a,a.k,T.a,W],styles:[""],changeDetection:0}),e})(),canActivate:[o("auXs").a]}];let Z=(()=>{class e{}return e.\u0275mod=b.Lb({type:e}),e.\u0275inj=b.Kb({factory:function(t){return new(t||e)},imports:[[n.e.forChild(Y)],n.e]}),e})();var ee=o("B+Mi");let te=(()=>{class e{}return e.\u0275mod=b.Lb({type:e}),e.\u0275inj=b.Kb({factory:function(t){return new(t||e)},imports:[[a.c,n.e,Z,ee.a,B.g,B.o]]}),e})()}}]);