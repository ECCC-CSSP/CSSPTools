(window.webpackJsonp=window.webpackJsonp||[]).push([[24],{"BA+U":function(t,e,l){"use strict";l.r(e),l.d(e,"SpillLanguageModule",(function(){return tt}));var a=l("ofXK"),i=l("tyNb");function n(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var s=l("PSTt"),o=l("BBgV"),r=l("QRvi"),u=l("fXoL"),c=l("2Vo4"),b=l("LRne"),p=l("tk/3"),g=l("lJxs"),S=l("JIr8"),m=l("gkM4");let d=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.spilllanguageTextModel$=new c.a({}),this.spilllanguageListModel$=new c.a({}),this.spilllanguageGetModel$=new c.a({}),this.spilllanguagePutModel$=new c.a({}),this.spilllanguagePostModel$=new c.a({}),this.spilllanguageDeleteModel$=new c.a({}),n(this.spilllanguageTextModel$),this.spilllanguageTextModel$.next({Title:"Something2 for text"})}GetSpillLanguageList(){return this.httpClientService.BeforeHttpClient(this.spilllanguageGetModel$),this.httpClient.get("/api/SpillLanguage").pipe(Object(g.a)(t=>{this.httpClientService.DoSuccess(this.spilllanguageListModel$,this.spilllanguageGetModel$,t,r.a.Get,null)}),Object(S.a)(t=>Object(b.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.spilllanguageListModel$,this.spilllanguageGetModel$,t)}))))}PutSpillLanguage(t){return this.httpClientService.BeforeHttpClient(this.spilllanguagePutModel$),this.httpClient.put("/api/SpillLanguage",t,{headers:new p.d}).pipe(Object(g.a)(e=>{this.httpClientService.DoSuccess(this.spilllanguageListModel$,this.spilllanguagePutModel$,e,r.a.Put,t)}),Object(S.a)(t=>Object(b.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.spilllanguageListModel$,this.spilllanguagePutModel$,t)}))))}PostSpillLanguage(t){return this.httpClientService.BeforeHttpClient(this.spilllanguagePostModel$),this.httpClient.post("/api/SpillLanguage",t,{headers:new p.d}).pipe(Object(g.a)(e=>{this.httpClientService.DoSuccess(this.spilllanguageListModel$,this.spilllanguagePostModel$,e,r.a.Post,t)}),Object(S.a)(t=>Object(b.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.spilllanguageListModel$,this.spilllanguagePostModel$,t)}))))}DeleteSpillLanguage(t){return this.httpClientService.BeforeHttpClient(this.spilllanguageDeleteModel$),this.httpClient.delete("/api/SpillLanguage/"+t.SpillLanguageID).pipe(Object(g.a)(e=>{this.httpClientService.DoSuccess(this.spilllanguageListModel$,this.spilllanguageDeleteModel$,e,r.a.Delete,t)}),Object(S.a)(t=>Object(b.a)(t).pipe(Object(g.a)(t=>{this.httpClientService.DoCatchError(this.spilllanguageListModel$,this.spilllanguageDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(u.Wb(p.b),u.Wb(m.a))},t.\u0275prov=u.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var h=l("Wp6s"),f=l("bTqV"),I=l("bv9b"),R=l("NFeN"),L=l("3Pt+"),D=l("kmnG"),C=l("qFsG"),B=l("d3UM"),T=l("FKr1");function v(t,e){1&t&&u.Nb(0,"mat-progress-bar",12)}function P(t,e){1&t&&u.Nb(0,"mat-progress-bar",12)}function y(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function $(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,y,3,0,"span",4),u.Rb()),2&t){const t=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,t)),u.Bb(3),u.ic("ngIf",t.required)}}function E(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function w(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,E,3,0,"span",4),u.Rb()),2&t){const t=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,t)),u.Bb(3),u.ic("ngIf",t.required)}}function M(t,e){if(1&t&&(u.Sb(0,"mat-option",13),u.zc(1),u.Rb()),2&t){const t=e.$implicit;u.ic("value",t.EnumID),u.Bb(1),u.Bc(" ",t.EnumText," ")}}function z(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function G(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,z,3,0,"span",4),u.Rb()),2&t){const t=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,t)),u.Bb(3),u.ic("ngIf",t.required)}}function x(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function N(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,x,3,0,"span",4),u.Rb()),2&t){const t=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,t)),u.Bb(3),u.ic("ngIf",t.required)}}function k(t,e){if(1&t&&(u.Sb(0,"mat-option",13),u.zc(1),u.Rb()),2&t){const t=e.$implicit;u.ic("value",t.EnumID),u.Bb(1),u.Bc(" ",t.EnumText," ")}}function O(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function j(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,O,3,0,"span",4),u.Rb()),2&t){const t=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,t)),u.Bb(3),u.ic("ngIf",t.required)}}function q(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function U(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,q,3,0,"span",4),u.Rb()),2&t){const t=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,t)),u.Bb(3),u.ic("ngIf",t.required)}}function F(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function V(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,F,3,0,"span",4),u.Rb()),2&t){const t=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,t)),u.Bb(3),u.ic("ngIf",t.required)}}let A=(()=>{class t{constructor(t,e){this.spilllanguageService=t,this.fb=e,this.spilllanguage=null,this.httpClientCommand=r.a.Put}GetPut(){return this.httpClientCommand==r.a.Put}PutSpillLanguage(t){this.sub=this.spilllanguageService.PutSpillLanguage(t).subscribe()}PostSpillLanguage(t){this.sub=this.spilllanguageService.PostSpillLanguage(t).subscribe()}ngOnInit(){this.languageList=Object(s.b)(),this.translationStatusList=Object(o.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.spilllanguage){let e=this.fb.group({SpillLanguageID:[{value:t===r.a.Post?0:this.spilllanguage.SpillLanguageID,disabled:!1},[L.p.required]],SpillID:[{value:this.spilllanguage.SpillID,disabled:!1},[L.p.required]],Language:[{value:this.spilllanguage.Language,disabled:!1},[L.p.required]],SpillComment:[{value:this.spilllanguage.SpillComment,disabled:!1},[L.p.required]],TranslationStatus:[{value:this.spilllanguage.TranslationStatus,disabled:!1},[L.p.required]],LastUpdateDate_UTC:[{value:this.spilllanguage.LastUpdateDate_UTC,disabled:!1},[L.p.required]],LastUpdateContactTVItemID:[{value:this.spilllanguage.LastUpdateContactTVItemID,disabled:!1},[L.p.required]]});this.spilllanguageFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(u.Mb(d),u.Mb(L.d))},t.\u0275cmp=u.Gb({type:t,selectors:[["app-spilllanguage-edit"]],inputs:{spilllanguage:"spilllanguage",httpClientCommand:"httpClientCommand"},decls:47,vars:13,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","SpillLanguageID"],[4,"ngIf"],["matInput","","type","number","formControlName","SpillID"],["formControlName","Language"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","SpillComment"],["formControlName","TranslationStatus"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(u.Sb(0,"form",0),u.Zb("ngSubmit",(function(){return e.GetPut()?e.PutSpillLanguage(e.spilllanguageFormEdit.value):e.PostSpillLanguage(e.spilllanguageFormEdit.value)})),u.Sb(1,"h3"),u.zc(2," SpillLanguage "),u.Sb(3,"button",1),u.Sb(4,"span"),u.zc(5),u.Rb(),u.Rb(),u.yc(6,v,1,0,"mat-progress-bar",2),u.yc(7,P,1,0,"mat-progress-bar",2),u.Rb(),u.Sb(8,"p"),u.Sb(9,"mat-form-field"),u.Sb(10,"mat-label"),u.zc(11,"SpillLanguageID"),u.Rb(),u.Nb(12,"input",3),u.yc(13,$,6,4,"mat-error",4),u.Rb(),u.Sb(14,"mat-form-field"),u.Sb(15,"mat-label"),u.zc(16,"SpillID"),u.Rb(),u.Nb(17,"input",5),u.yc(18,w,6,4,"mat-error",4),u.Rb(),u.Sb(19,"mat-form-field"),u.Sb(20,"mat-label"),u.zc(21,"Language"),u.Rb(),u.Sb(22,"mat-select",6),u.yc(23,M,2,2,"mat-option",7),u.Rb(),u.yc(24,G,6,4,"mat-error",4),u.Rb(),u.Sb(25,"mat-form-field"),u.Sb(26,"mat-label"),u.zc(27,"SpillComment"),u.Rb(),u.Nb(28,"input",8),u.yc(29,N,6,4,"mat-error",4),u.Rb(),u.Rb(),u.Sb(30,"p"),u.Sb(31,"mat-form-field"),u.Sb(32,"mat-label"),u.zc(33,"TranslationStatus"),u.Rb(),u.Sb(34,"mat-select",9),u.yc(35,k,2,2,"mat-option",7),u.Rb(),u.yc(36,j,6,4,"mat-error",4),u.Rb(),u.Sb(37,"mat-form-field"),u.Sb(38,"mat-label"),u.zc(39,"LastUpdateDate_UTC"),u.Rb(),u.Nb(40,"input",10),u.yc(41,U,6,4,"mat-error",4),u.Rb(),u.Sb(42,"mat-form-field"),u.Sb(43,"mat-label"),u.zc(44,"LastUpdateContactTVItemID"),u.Rb(),u.Nb(45,"input",11),u.yc(46,V,6,4,"mat-error",4),u.Rb(),u.Rb(),u.Rb()),2&t&&(u.ic("formGroup",e.spilllanguageFormEdit),u.Bb(5),u.Bc("",e.GetPut()?"Put":"Post"," SpillLanguage"),u.Bb(1),u.ic("ngIf",e.spilllanguageService.spilllanguagePutModel$.getValue().Working),u.Bb(1),u.ic("ngIf",e.spilllanguageService.spilllanguagePostModel$.getValue().Working),u.Bb(6),u.ic("ngIf",e.spilllanguageFormEdit.controls.SpillLanguageID.errors),u.Bb(5),u.ic("ngIf",e.spilllanguageFormEdit.controls.SpillID.errors),u.Bb(5),u.ic("ngForOf",e.languageList),u.Bb(1),u.ic("ngIf",e.spilllanguageFormEdit.controls.Language.errors),u.Bb(5),u.ic("ngIf",e.spilllanguageFormEdit.controls.SpillComment.errors),u.Bb(6),u.ic("ngForOf",e.translationStatusList),u.Bb(1),u.ic("ngIf",e.spilllanguageFormEdit.controls.TranslationStatus.errors),u.Bb(5),u.ic("ngIf",e.spilllanguageFormEdit.controls.LastUpdateDate_UTC.errors),u.Bb(5),u.ic("ngIf",e.spilllanguageFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[L.q,L.l,L.f,f.b,a.l,D.c,D.f,C.b,L.n,L.c,L.k,L.e,B.a,a.k,I.a,D.b,T.n],pipes:[a.f],styles:[""],changeDetection:0}),t})();function W(t,e){1&t&&u.Nb(0,"mat-progress-bar",4)}function _(t,e){1&t&&u.Nb(0,"mat-progress-bar",4)}function J(t,e){if(1&t&&(u.Sb(0,"p"),u.Nb(1,"app-spilllanguage-edit",8),u.Rb()),2&t){const t=u.dc().$implicit,e=u.dc(2);u.Bb(1),u.ic("spilllanguage",t)("httpClientCommand",e.GetPutEnum())}}function H(t,e){if(1&t&&(u.Sb(0,"p"),u.Nb(1,"app-spilllanguage-edit",8),u.Rb()),2&t){const t=u.dc().$implicit,e=u.dc(2);u.Bb(1),u.ic("spilllanguage",t)("httpClientCommand",e.GetPostEnum())}}function Z(t,e){if(1&t){const t=u.Tb();u.Sb(0,"div"),u.Sb(1,"p"),u.Sb(2,"button",6),u.Zb("click",(function(){u.qc(t);const l=e.$implicit;return u.dc(2).DeleteSpillLanguage(l)})),u.Sb(3,"span"),u.zc(4),u.Rb(),u.Sb(5,"mat-icon"),u.zc(6,"delete"),u.Rb(),u.Rb(),u.zc(7,"\xa0\xa0\xa0 "),u.Sb(8,"button",7),u.Zb("click",(function(){u.qc(t);const l=e.$implicit;return u.dc(2).ShowPut(l)})),u.Sb(9,"span"),u.zc(10,"Show Put"),u.Rb(),u.Rb(),u.zc(11,"\xa0\xa0 "),u.Sb(12,"button",7),u.Zb("click",(function(){u.qc(t);const l=e.$implicit;return u.dc(2).ShowPost(l)})),u.Sb(13,"span"),u.zc(14,"Show Post"),u.Rb(),u.Rb(),u.zc(15,"\xa0\xa0 "),u.yc(16,_,1,0,"mat-progress-bar",0),u.Rb(),u.yc(17,J,2,2,"p",2),u.yc(18,H,2,2,"p",2),u.Sb(19,"blockquote"),u.Sb(20,"p"),u.Sb(21,"span"),u.zc(22),u.Rb(),u.Sb(23,"span"),u.zc(24),u.Rb(),u.Sb(25,"span"),u.zc(26),u.Rb(),u.Sb(27,"span"),u.zc(28),u.Rb(),u.Rb(),u.Sb(29,"p"),u.Sb(30,"span"),u.zc(31),u.Rb(),u.Sb(32,"span"),u.zc(33),u.Rb(),u.Sb(34,"span"),u.zc(35),u.Rb(),u.Rb(),u.Rb(),u.Rb()}if(2&t){const t=e.$implicit,l=u.dc(2);u.Bb(4),u.Bc("Delete SpillLanguageID [",t.SpillLanguageID,"]\xa0\xa0\xa0"),u.Bb(4),u.ic("color",l.GetPutButtonColor(t)),u.Bb(4),u.ic("color",l.GetPostButtonColor(t)),u.Bb(4),u.ic("ngIf",l.spilllanguageService.spilllanguageDeleteModel$.getValue().Working),u.Bb(1),u.ic("ngIf",l.IDToShow===t.SpillLanguageID&&l.showType===l.GetPutEnum()),u.Bb(1),u.ic("ngIf",l.IDToShow===t.SpillLanguageID&&l.showType===l.GetPostEnum()),u.Bb(4),u.Bc("SpillLanguageID: [",t.SpillLanguageID,"]"),u.Bb(2),u.Bc(" --- SpillID: [",t.SpillID,"]"),u.Bb(2),u.Bc(" --- Language: [",l.GetLanguageEnumText(t.Language),"]"),u.Bb(2),u.Bc(" --- SpillComment: [",t.SpillComment,"]"),u.Bb(3),u.Bc("TranslationStatus: [",l.GetTranslationStatusEnumText(t.TranslationStatus),"]"),u.Bb(2),u.Bc(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),u.Bb(2),u.Bc(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function K(t,e){if(1&t&&(u.Sb(0,"div"),u.yc(1,Z,36,13,"div",5),u.Rb()),2&t){const t=u.dc();u.Bb(1),u.ic("ngForOf",t.spilllanguageService.spilllanguageListModel$.getValue())}}const X=[{path:"",component:(()=>{class t{constructor(t,e,l){this.spilllanguageService=t,this.router=e,this.httpClientService=l,this.showType=null,l.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.SpillLanguageID&&this.showType===r.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.SpillLanguageID&&this.showType===r.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.SpillLanguageID&&this.showType===r.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.SpillLanguageID,this.showType=r.a.Put)}ShowPost(t){this.IDToShow===t.SpillLanguageID&&this.showType===r.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.SpillLanguageID,this.showType=r.a.Post)}GetPutEnum(){return r.a.Put}GetPostEnum(){return r.a.Post}GetSpillLanguageList(){this.sub=this.spilllanguageService.GetSpillLanguageList().subscribe()}DeleteSpillLanguage(t){this.sub=this.spilllanguageService.DeleteSpillLanguage(t).subscribe()}GetLanguageEnumText(t){return Object(s.a)(t)}GetTranslationStatusEnumText(t){return Object(o.a)(t)}ngOnInit(){n(this.spilllanguageService.spilllanguageTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(u.Mb(d),u.Mb(i.b),u.Mb(m.a))},t.\u0275cmp=u.Gb({type:t,selectors:[["app-spilllanguage"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"spilllanguage","httpClientCommand"]],template:function(t,e){var l,a;1&t&&(u.yc(0,W,1,0,"mat-progress-bar",0),u.Sb(1,"mat-card"),u.Sb(2,"mat-card-header"),u.Sb(3,"mat-card-title"),u.zc(4," SpillLanguage works! "),u.Sb(5,"button",1),u.Zb("click",(function(){return e.GetSpillLanguageList()})),u.Sb(6,"span"),u.zc(7,"Get SpillLanguage"),u.Rb(),u.Rb(),u.Rb(),u.Sb(8,"mat-card-subtitle"),u.zc(9),u.Rb(),u.Rb(),u.Sb(10,"mat-card-content"),u.yc(11,K,2,1,"div",2),u.Rb(),u.Sb(12,"mat-card-actions"),u.Sb(13,"button",3),u.zc(14,"Allo"),u.Rb(),u.Rb(),u.Rb()),2&t&&(u.ic("ngIf",null==(l=e.spilllanguageService.spilllanguageGetModel$.getValue())?null:l.Working),u.Bb(9),u.Ac(e.spilllanguageService.spilllanguageTextModel$.getValue().Title),u.Bb(2),u.ic("ngIf",null==(a=e.spilllanguageService.spilllanguageListModel$.getValue())?null:a.length))},directives:[a.l,h.a,h.d,h.g,f.b,h.f,h.c,h.b,I.a,a.k,R.a,A],styles:[""],changeDetection:0}),t})(),canActivate:[l("auXs").a]}];let Q=(()=>{class t{}return t.\u0275mod=u.Kb({type:t}),t.\u0275inj=u.Jb({factory:function(e){return new(e||t)},imports:[[i.e.forChild(X)],i.e]}),t})();var Y=l("B+Mi");let tt=(()=>{class t{}return t.\u0275mod=u.Kb({type:t}),t.\u0275inj=u.Jb({factory:function(e){return new(e||t)},imports:[[a.c,i.e,Q,Y.a,L.g,L.o]]}),t})()},PSTt:function(t,e,l){"use strict";function a(){let t=[];return $localize,t.push({EnumID:1,EnumText:"en"}),t.push({EnumID:2,EnumText:"fr"}),t.push({EnumID:3,EnumText:"enAndfr"}),t.push({EnumID:4,EnumText:"es"}),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}function i(t){let e;return a().forEach(l=>{if(l.EnumID==t)return e=l.EnumText,!1}),e}l.d(e,"b",(function(){return a})),l.d(e,"a",(function(){return i}))},QRvi:function(t,e,l){"use strict";l.d(e,"a",(function(){return a}));var a=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,l){"use strict";l.d(e,"a",(function(){return s}));var a=l("QRvi"),i=l("fXoL"),n=l("tyNb");let s=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,l){t.next(null),e.next({Working:!1,Error:l,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,l){t.next(null),e.next({Working:!1,Error:l,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,l,i,n){if(i===a.a.Get&&t.next(l),i===a.a.Put&&(t.getValue()[0]=l),i===a.a.Post&&t.getValue().push(l),i===a.a.Delete){const e=t.getValue().indexOf(n);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,l,i,n){i===a.a.Get&&t.next(l),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(i.Wb(n.b))},t.\u0275prov=i.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);