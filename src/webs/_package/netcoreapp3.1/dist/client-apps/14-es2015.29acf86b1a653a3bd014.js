(window.webpackJsonp=window.webpackJsonp||[]).push([[14],{PSTt:function(e,t,o){"use strict";function a(){let e=[];return $localize,e.push({EnumID:1,EnumText:"en"}),e.push({EnumID:2,EnumText:"fr"}),e.push({EnumID:3,EnumText:"enAndfr"}),e.push({EnumID:4,EnumText:"es"}),e.sort((e,t)=>e.EnumText.localeCompare(t.EnumText))}function n(e){let t;return a().forEach(o=>{if(o.EnumID==e)return t=o.EnumText,!1}),t}o.d(t,"b",(function(){return a})),o.d(t,"a",(function(){return n}))},QRvi:function(e,t,o){"use strict";o.d(t,"a",(function(){return a}));var a=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,o){"use strict";o.d(t,"a",(function(){return i}));var a=o("QRvi"),n=o("fXoL"),l=o("tyNb");let i=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,t,o){e.next(null),t.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,t,o,n,l){if(n===a.a.Get&&e.next(o),n===a.a.Put&&(e.getValue()[0]=o),n===a.a.Post&&e.getValue().push(o),n===a.a.Delete){const t=e.getValue().indexOf(l);e.getValue().splice(t,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(t){return new(t||e)(n.Xb(l.b))},e.\u0275prov=n.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()},mAw6:function(e,t,o){"use strict";o.r(t),o.d(t,"BoxModelLanguageModule",(function(){return te}));var a=o("ofXK"),n=o("tyNb");function l(e){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var i=o("PSTt"),r=o("BBgV"),b=o("QRvi"),u=o("fXoL"),c=o("2Vo4"),s=o("LRne"),g=o("tk/3"),d=o("lJxs"),m=o("JIr8"),p=o("gkM4");let x=(()=>{class e{constructor(e,t){this.httpClient=e,this.httpClientService=t,this.boxmodellanguageTextModel$=new c.a({}),this.boxmodellanguageListModel$=new c.a({}),this.boxmodellanguageGetModel$=new c.a({}),this.boxmodellanguagePutModel$=new c.a({}),this.boxmodellanguagePostModel$=new c.a({}),this.boxmodellanguageDeleteModel$=new c.a({}),l(this.boxmodellanguageTextModel$),this.boxmodellanguageTextModel$.next({Title:"Something2 for text"})}GetBoxModelLanguageList(){return this.httpClientService.BeforeHttpClient(this.boxmodellanguageGetModel$),this.httpClient.get("/api/BoxModelLanguage").pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.boxmodellanguageListModel$,this.boxmodellanguageGetModel$,e,b.a.Get,null)}),Object(m.a)(e=>Object(s.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.boxmodellanguageListModel$,this.boxmodellanguageGetModel$,e)}))))}PutBoxModelLanguage(e){return this.httpClientService.BeforeHttpClient(this.boxmodellanguagePutModel$),this.httpClient.put("/api/BoxModelLanguage",e,{headers:new g.d}).pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.boxmodellanguageListModel$,this.boxmodellanguagePutModel$,t,b.a.Put,e)}),Object(m.a)(e=>Object(s.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.boxmodellanguageListModel$,this.boxmodellanguagePutModel$,e)}))))}PostBoxModelLanguage(e){return this.httpClientService.BeforeHttpClient(this.boxmodellanguagePostModel$),this.httpClient.post("/api/BoxModelLanguage",e,{headers:new g.d}).pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.boxmodellanguageListModel$,this.boxmodellanguagePostModel$,t,b.a.Post,e)}),Object(m.a)(e=>Object(s.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.boxmodellanguageListModel$,this.boxmodellanguagePostModel$,e)}))))}DeleteBoxModelLanguage(e){return this.httpClientService.BeforeHttpClient(this.boxmodellanguageDeleteModel$),this.httpClient.delete("/api/BoxModelLanguage/"+e.BoxModelLanguageID).pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.boxmodellanguageListModel$,this.boxmodellanguageDeleteModel$,t,b.a.Delete,e)}),Object(m.a)(e=>Object(s.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.boxmodellanguageListModel$,this.boxmodellanguageDeleteModel$,e)}))))}}return e.\u0275fac=function(t){return new(t||e)(u.Xb(g.b),u.Xb(p.a))},e.\u0275prov=u.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var h=o("Wp6s"),f=o("bTqV"),S=o("bv9b"),T=o("NFeN"),B=o("3Pt+"),I=o("kmnG"),L=o("qFsG"),M=o("d3UM"),D=o("FKr1");function y(e,t){1&e&&u.Ob(0,"mat-progress-bar",12)}function C(e,t){1&e&&u.Ob(0,"mat-progress-bar",12)}function v(e,t){1&e&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function j(e,t){if(1&e&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,v,3,0,"span",4),u.Sb()),2&e){const e=t.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}function P(e,t){1&e&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function O(e,t){if(1&e&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,P,3,0,"span",4),u.Sb()),2&e){const e=t.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}function $(e,t){if(1&e&&(u.Tb(0,"mat-option",13),u.yc(1),u.Sb()),2&e){const e=t.$implicit;u.jc("value",e.EnumID),u.Bb(1),u.Ac(" ",e.EnumText," ")}}function w(e,t){1&e&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function E(e,t){if(1&e&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,w,3,0,"span",4),u.Sb()),2&e){const e=t.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}function G(e,t){1&e&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function k(e,t){1&e&&(u.Tb(0,"span"),u.yc(1,"MaxLength - 250"),u.Ob(2,"br"),u.Sb())}function U(e,t){if(1&e&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,G,3,0,"span",4),u.xc(6,k,3,0,"span",4),u.Sb()),2&e){const e=t.$implicit;u.Bb(2),u.zc(u.gc(3,3,e)),u.Bb(3),u.jc("ngIf",e.required),u.Bb(1),u.jc("ngIf",e.maxlength)}}function q(e,t){if(1&e&&(u.Tb(0,"mat-option",13),u.yc(1),u.Sb()),2&e){const e=t.$implicit;u.jc("value",e.EnumID),u.Bb(1),u.Ac(" ",e.EnumText," ")}}function F(e,t){1&e&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function N(e,t){if(1&e&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,F,3,0,"span",4),u.Sb()),2&e){const e=t.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}function V(e,t){1&e&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function R(e,t){if(1&e&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,V,3,0,"span",4),u.Sb()),2&e){const e=t.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}function A(e,t){1&e&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function z(e,t){if(1&e&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,A,3,0,"span",4),u.Sb()),2&e){const e=t.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}let W=(()=>{class e{constructor(e,t){this.boxmodellanguageService=e,this.fb=t,this.boxmodellanguage=null,this.httpClientCommand=b.a.Put}GetPut(){return this.httpClientCommand==b.a.Put}PutBoxModelLanguage(e){this.sub=this.boxmodellanguageService.PutBoxModelLanguage(e).subscribe()}PostBoxModelLanguage(e){this.sub=this.boxmodellanguageService.PostBoxModelLanguage(e).subscribe()}ngOnInit(){this.languageList=Object(i.b)(),this.translationStatusList=Object(r.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.boxmodellanguage){let t=this.fb.group({BoxModelLanguageID:[{value:e===b.a.Post?0:this.boxmodellanguage.BoxModelLanguageID,disabled:!1},[B.p.required]],BoxModelID:[{value:this.boxmodellanguage.BoxModelID,disabled:!1},[B.p.required]],Language:[{value:this.boxmodellanguage.Language,disabled:!1},[B.p.required]],ScenarioName:[{value:this.boxmodellanguage.ScenarioName,disabled:!1},[B.p.required,B.p.maxLength(250)]],TranslationStatus:[{value:this.boxmodellanguage.TranslationStatus,disabled:!1},[B.p.required]],LastUpdateDate_UTC:[{value:this.boxmodellanguage.LastUpdateDate_UTC,disabled:!1},[B.p.required]],LastUpdateContactTVItemID:[{value:this.boxmodellanguage.LastUpdateContactTVItemID,disabled:!1},[B.p.required]]});this.boxmodellanguageFormEdit=t}}}return e.\u0275fac=function(t){return new(t||e)(u.Nb(x),u.Nb(B.d))},e.\u0275cmp=u.Hb({type:e,selectors:[["app-boxmodellanguage-edit"]],inputs:{boxmodellanguage:"boxmodellanguage",httpClientCommand:"httpClientCommand"},decls:47,vars:13,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","BoxModelLanguageID"],[4,"ngIf"],["matInput","","type","number","formControlName","BoxModelID"],["formControlName","Language"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","ScenarioName"],["formControlName","TranslationStatus"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(u.Tb(0,"form",0),u.ac("ngSubmit",(function(){return t.GetPut()?t.PutBoxModelLanguage(t.boxmodellanguageFormEdit.value):t.PostBoxModelLanguage(t.boxmodellanguageFormEdit.value)})),u.Tb(1,"h3"),u.yc(2," BoxModelLanguage "),u.Tb(3,"button",1),u.Tb(4,"span"),u.yc(5),u.Sb(),u.Sb(),u.xc(6,y,1,0,"mat-progress-bar",2),u.xc(7,C,1,0,"mat-progress-bar",2),u.Sb(),u.Tb(8,"p"),u.Tb(9,"mat-form-field"),u.Tb(10,"mat-label"),u.yc(11,"BoxModelLanguageID"),u.Sb(),u.Ob(12,"input",3),u.xc(13,j,6,4,"mat-error",4),u.Sb(),u.Tb(14,"mat-form-field"),u.Tb(15,"mat-label"),u.yc(16,"BoxModelID"),u.Sb(),u.Ob(17,"input",5),u.xc(18,O,6,4,"mat-error",4),u.Sb(),u.Tb(19,"mat-form-field"),u.Tb(20,"mat-label"),u.yc(21,"Language"),u.Sb(),u.Tb(22,"mat-select",6),u.xc(23,$,2,2,"mat-option",7),u.Sb(),u.xc(24,E,6,4,"mat-error",4),u.Sb(),u.Tb(25,"mat-form-field"),u.Tb(26,"mat-label"),u.yc(27,"ScenarioName"),u.Sb(),u.Ob(28,"input",8),u.xc(29,U,7,5,"mat-error",4),u.Sb(),u.Sb(),u.Tb(30,"p"),u.Tb(31,"mat-form-field"),u.Tb(32,"mat-label"),u.yc(33,"TranslationStatus"),u.Sb(),u.Tb(34,"mat-select",9),u.xc(35,q,2,2,"mat-option",7),u.Sb(),u.xc(36,N,6,4,"mat-error",4),u.Sb(),u.Tb(37,"mat-form-field"),u.Tb(38,"mat-label"),u.yc(39,"LastUpdateDate_UTC"),u.Sb(),u.Ob(40,"input",10),u.xc(41,R,6,4,"mat-error",4),u.Sb(),u.Tb(42,"mat-form-field"),u.Tb(43,"mat-label"),u.yc(44,"LastUpdateContactTVItemID"),u.Sb(),u.Ob(45,"input",11),u.xc(46,z,6,4,"mat-error",4),u.Sb(),u.Sb(),u.Sb()),2&e&&(u.jc("formGroup",t.boxmodellanguageFormEdit),u.Bb(5),u.Ac("",t.GetPut()?"Put":"Post"," BoxModelLanguage"),u.Bb(1),u.jc("ngIf",t.boxmodellanguageService.boxmodellanguagePutModel$.getValue().Working),u.Bb(1),u.jc("ngIf",t.boxmodellanguageService.boxmodellanguagePostModel$.getValue().Working),u.Bb(6),u.jc("ngIf",t.boxmodellanguageFormEdit.controls.BoxModelLanguageID.errors),u.Bb(5),u.jc("ngIf",t.boxmodellanguageFormEdit.controls.BoxModelID.errors),u.Bb(5),u.jc("ngForOf",t.languageList),u.Bb(1),u.jc("ngIf",t.boxmodellanguageFormEdit.controls.Language.errors),u.Bb(5),u.jc("ngIf",t.boxmodellanguageFormEdit.controls.ScenarioName.errors),u.Bb(6),u.jc("ngForOf",t.translationStatusList),u.Bb(1),u.jc("ngIf",t.boxmodellanguageFormEdit.controls.TranslationStatus.errors),u.Bb(5),u.jc("ngIf",t.boxmodellanguageFormEdit.controls.LastUpdateDate_UTC.errors),u.Bb(5),u.jc("ngIf",t.boxmodellanguageFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[B.q,B.l,B.f,f.b,a.l,I.c,I.f,L.b,B.n,B.c,B.k,B.e,M.a,a.k,S.a,I.b,D.n],pipes:[a.f],styles:[""],changeDetection:0}),e})();function H(e,t){1&e&&u.Ob(0,"mat-progress-bar",4)}function X(e,t){1&e&&u.Ob(0,"mat-progress-bar",4)}function _(e,t){if(1&e&&(u.Tb(0,"p"),u.Ob(1,"app-boxmodellanguage-edit",8),u.Sb()),2&e){const e=u.ec().$implicit,t=u.ec(2);u.Bb(1),u.jc("boxmodellanguage",e)("httpClientCommand",t.GetPutEnum())}}function J(e,t){if(1&e&&(u.Tb(0,"p"),u.Ob(1,"app-boxmodellanguage-edit",8),u.Sb()),2&e){const e=u.ec().$implicit,t=u.ec(2);u.Bb(1),u.jc("boxmodellanguage",e)("httpClientCommand",t.GetPostEnum())}}function K(e,t){if(1&e){const e=u.Ub();u.Tb(0,"div"),u.Tb(1,"p"),u.Tb(2,"button",6),u.ac("click",(function(){u.rc(e);const o=t.$implicit;return u.ec(2).DeleteBoxModelLanguage(o)})),u.Tb(3,"span"),u.yc(4),u.Sb(),u.Tb(5,"mat-icon"),u.yc(6,"delete"),u.Sb(),u.Sb(),u.yc(7,"\xa0\xa0\xa0 "),u.Tb(8,"button",7),u.ac("click",(function(){u.rc(e);const o=t.$implicit;return u.ec(2).ShowPut(o)})),u.Tb(9,"span"),u.yc(10,"Show Put"),u.Sb(),u.Sb(),u.yc(11,"\xa0\xa0 "),u.Tb(12,"button",7),u.ac("click",(function(){u.rc(e);const o=t.$implicit;return u.ec(2).ShowPost(o)})),u.Tb(13,"span"),u.yc(14,"Show Post"),u.Sb(),u.Sb(),u.yc(15,"\xa0\xa0 "),u.xc(16,X,1,0,"mat-progress-bar",0),u.Sb(),u.xc(17,_,2,2,"p",2),u.xc(18,J,2,2,"p",2),u.Tb(19,"blockquote"),u.Tb(20,"p"),u.Tb(21,"span"),u.yc(22),u.Sb(),u.Tb(23,"span"),u.yc(24),u.Sb(),u.Tb(25,"span"),u.yc(26),u.Sb(),u.Tb(27,"span"),u.yc(28),u.Sb(),u.Sb(),u.Tb(29,"p"),u.Tb(30,"span"),u.yc(31),u.Sb(),u.Tb(32,"span"),u.yc(33),u.Sb(),u.Tb(34,"span"),u.yc(35),u.Sb(),u.Sb(),u.Sb(),u.Sb()}if(2&e){const e=t.$implicit,o=u.ec(2);u.Bb(4),u.Ac("Delete BoxModelLanguageID [",e.BoxModelLanguageID,"]\xa0\xa0\xa0"),u.Bb(4),u.jc("color",o.GetPutButtonColor(e)),u.Bb(4),u.jc("color",o.GetPostButtonColor(e)),u.Bb(4),u.jc("ngIf",o.boxmodellanguageService.boxmodellanguageDeleteModel$.getValue().Working),u.Bb(1),u.jc("ngIf",o.IDToShow===e.BoxModelLanguageID&&o.showType===o.GetPutEnum()),u.Bb(1),u.jc("ngIf",o.IDToShow===e.BoxModelLanguageID&&o.showType===o.GetPostEnum()),u.Bb(4),u.Ac("BoxModelLanguageID: [",e.BoxModelLanguageID,"]"),u.Bb(2),u.Ac(" --- BoxModelID: [",e.BoxModelID,"]"),u.Bb(2),u.Ac(" --- Language: [",o.GetLanguageEnumText(e.Language),"]"),u.Bb(2),u.Ac(" --- ScenarioName: [",e.ScenarioName,"]"),u.Bb(3),u.Ac("TranslationStatus: [",o.GetTranslationStatusEnumText(e.TranslationStatus),"]"),u.Bb(2),u.Ac(" --- LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),u.Bb(2),u.Ac(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function Q(e,t){if(1&e&&(u.Tb(0,"div"),u.xc(1,K,36,13,"div",5),u.Sb()),2&e){const e=u.ec();u.Bb(1),u.jc("ngForOf",e.boxmodellanguageService.boxmodellanguageListModel$.getValue())}}const Y=[{path:"",component:(()=>{class e{constructor(e,t,o){this.boxmodellanguageService=e,this.router=t,this.httpClientService=o,this.showType=null,o.oldURL=t.url}GetPutButtonColor(e){return this.IDToShow===e.BoxModelLanguageID&&this.showType===b.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.BoxModelLanguageID&&this.showType===b.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.BoxModelLanguageID&&this.showType===b.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.BoxModelLanguageID,this.showType=b.a.Put)}ShowPost(e){this.IDToShow===e.BoxModelLanguageID&&this.showType===b.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.BoxModelLanguageID,this.showType=b.a.Post)}GetPutEnum(){return b.a.Put}GetPostEnum(){return b.a.Post}GetBoxModelLanguageList(){this.sub=this.boxmodellanguageService.GetBoxModelLanguageList().subscribe()}DeleteBoxModelLanguage(e){this.sub=this.boxmodellanguageService.DeleteBoxModelLanguage(e).subscribe()}GetLanguageEnumText(e){return Object(i.a)(e)}GetTranslationStatusEnumText(e){return Object(r.a)(e)}ngOnInit(){l(this.boxmodellanguageService.boxmodellanguageTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(t){return new(t||e)(u.Nb(x),u.Nb(n.b),u.Nb(p.a))},e.\u0275cmp=u.Hb({type:e,selectors:[["app-boxmodellanguage"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"boxmodellanguage","httpClientCommand"]],template:function(e,t){if(1&e&&(u.xc(0,H,1,0,"mat-progress-bar",0),u.Tb(1,"mat-card"),u.Tb(2,"mat-card-header"),u.Tb(3,"mat-card-title"),u.yc(4," BoxModelLanguage works! "),u.Tb(5,"button",1),u.ac("click",(function(){return t.GetBoxModelLanguageList()})),u.Tb(6,"span"),u.yc(7,"Get BoxModelLanguage"),u.Sb(),u.Sb(),u.Sb(),u.Tb(8,"mat-card-subtitle"),u.yc(9),u.Sb(),u.Sb(),u.Tb(10,"mat-card-content"),u.xc(11,Q,2,1,"div",2),u.Sb(),u.Tb(12,"mat-card-actions"),u.Tb(13,"button",3),u.yc(14,"Allo"),u.Sb(),u.Sb(),u.Sb()),2&e){var o;const e=null==(o=t.boxmodellanguageService.boxmodellanguageGetModel$.getValue())?null:o.Working;var a;const n=null==(a=t.boxmodellanguageService.boxmodellanguageListModel$.getValue())?null:a.length;u.jc("ngIf",e),u.Bb(9),u.zc(t.boxmodellanguageService.boxmodellanguageTextModel$.getValue().Title),u.Bb(2),u.jc("ngIf",n)}},directives:[a.l,h.a,h.d,h.g,f.b,h.f,h.c,h.b,S.a,a.k,T.a,W],styles:[""],changeDetection:0}),e})(),canActivate:[o("auXs").a]}];let Z=(()=>{class e{}return e.\u0275mod=u.Lb({type:e}),e.\u0275inj=u.Kb({factory:function(t){return new(t||e)},imports:[[n.e.forChild(Y)],n.e]}),e})();var ee=o("B+Mi");let te=(()=>{class e{}return e.\u0275mod=u.Lb({type:e}),e.\u0275inj=u.Kb({factory:function(t){return new(t||e)},imports:[[a.c,n.e,Z,ee.a,B.g,B.o]]}),e})()}}]);