(window.webpackJsonp=window.webpackJsonp||[]).push([[44],{Ho8B:function(t,c,o){"use strict";o.r(c),o.d(c,"ContactShortcutModule",(function(){return J}));var e=o("ofXK"),r=o("tyNb");function n(t){let c={Title:"The title"};"fr-CA"===$localize.locale&&(c.Title="Le Titre"),t.next(c)}var s=o("QRvi"),a=o("fXoL"),i=o("2Vo4"),u=o("LRne"),b=o("tk/3"),h=o("lJxs"),l=o("JIr8"),p=o("gkM4");let d=(()=>{class t{constructor(t,c){this.httpClient=t,this.httpClientService=c,this.contactshortcutTextModel$=new i.a({}),this.contactshortcutListModel$=new i.a({}),this.contactshortcutGetModel$=new i.a({}),this.contactshortcutPutModel$=new i.a({}),this.contactshortcutPostModel$=new i.a({}),this.contactshortcutDeleteModel$=new i.a({}),n(this.contactshortcutTextModel$),this.contactshortcutTextModel$.next({Title:"Something2 for text"})}GetContactShortcutList(){return this.httpClientService.BeforeHttpClient(this.contactshortcutGetModel$),this.httpClient.get("/api/ContactShortcut").pipe(Object(h.a)(t=>{this.httpClientService.DoSuccess(this.contactshortcutListModel$,this.contactshortcutGetModel$,t,s.a.Get,null)}),Object(l.a)(t=>Object(u.a)(t).pipe(Object(h.a)(t=>{this.httpClientService.DoCatchError(this.contactshortcutListModel$,this.contactshortcutGetModel$,t)}))))}PutContactShortcut(t){return this.httpClientService.BeforeHttpClient(this.contactshortcutPutModel$),this.httpClient.put("/api/ContactShortcut",t,{headers:new b.d}).pipe(Object(h.a)(c=>{this.httpClientService.DoSuccess(this.contactshortcutListModel$,this.contactshortcutPutModel$,c,s.a.Put,t)}),Object(l.a)(t=>Object(u.a)(t).pipe(Object(h.a)(t=>{this.httpClientService.DoCatchError(this.contactshortcutListModel$,this.contactshortcutPutModel$,t)}))))}PostContactShortcut(t){return this.httpClientService.BeforeHttpClient(this.contactshortcutPostModel$),this.httpClient.post("/api/ContactShortcut",t,{headers:new b.d}).pipe(Object(h.a)(c=>{this.httpClientService.DoSuccess(this.contactshortcutListModel$,this.contactshortcutPostModel$,c,s.a.Post,t)}),Object(l.a)(t=>Object(u.a)(t).pipe(Object(h.a)(t=>{this.httpClientService.DoCatchError(this.contactshortcutListModel$,this.contactshortcutPostModel$,t)}))))}DeleteContactShortcut(t){return this.httpClientService.BeforeHttpClient(this.contactshortcutDeleteModel$),this.httpClient.delete("/api/ContactShortcut/"+t.ContactShortcutID).pipe(Object(h.a)(c=>{this.httpClientService.DoSuccess(this.contactshortcutListModel$,this.contactshortcutDeleteModel$,c,s.a.Delete,t)}),Object(l.a)(t=>Object(u.a)(t).pipe(Object(h.a)(t=>{this.httpClientService.DoCatchError(this.contactshortcutListModel$,this.contactshortcutDeleteModel$,t)}))))}}return t.\u0275fac=function(c){return new(c||t)(a.Wb(b.b),a.Wb(p.a))},t.\u0275prov=a.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var S=o("Wp6s"),m=o("bTqV"),f=o("bv9b"),C=o("NFeN"),I=o("3Pt+"),R=o("kmnG"),g=o("qFsG");function D(t,c){1&t&&a.Nb(0,"mat-progress-bar",10)}function v(t,c){1&t&&a.Nb(0,"mat-progress-bar",10)}function B(t,c){1&t&&(a.Sb(0,"span"),a.zc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function P(t,c){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.zc(2),a.ec(3,"json"),a.Nb(4,"br"),a.Rb(),a.yc(5,B,3,0,"span",4),a.Rb()),2&t){const t=c.$implicit;a.Bb(2),a.Ac(a.fc(3,2,t)),a.Bb(3),a.ic("ngIf",t.required)}}function y(t,c){1&t&&(a.Sb(0,"span"),a.zc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function T(t,c){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.zc(2),a.ec(3,"json"),a.Nb(4,"br"),a.Rb(),a.yc(5,y,3,0,"span",4),a.Rb()),2&t){const t=c.$implicit;a.Bb(2),a.Ac(a.fc(3,2,t)),a.Bb(3),a.ic("ngIf",t.required)}}function $(t,c){1&t&&(a.Sb(0,"span"),a.zc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function w(t,c){1&t&&(a.Sb(0,"span"),a.zc(1,"MaxLength - 100"),a.Nb(2,"br"),a.Rb())}function M(t,c){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.zc(2),a.ec(3,"json"),a.Nb(4,"br"),a.Rb(),a.yc(5,$,3,0,"span",4),a.yc(6,w,3,0,"span",4),a.Rb()),2&t){const t=c.$implicit;a.Bb(2),a.Ac(a.fc(3,3,t)),a.Bb(3),a.ic("ngIf",t.required),a.Bb(1),a.ic("ngIf",t.maxlength)}}function L(t,c){1&t&&(a.Sb(0,"span"),a.zc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function z(t,c){1&t&&(a.Sb(0,"span"),a.zc(1,"MaxLength - 200"),a.Nb(2,"br"),a.Rb())}function x(t,c){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.zc(2),a.ec(3,"json"),a.Nb(4,"br"),a.Rb(),a.yc(5,L,3,0,"span",4),a.yc(6,z,3,0,"span",4),a.Rb()),2&t){const t=c.$implicit;a.Bb(2),a.Ac(a.fc(3,3,t)),a.Bb(3),a.ic("ngIf",t.required),a.Bb(1),a.ic("ngIf",t.maxlength)}}function G(t,c){1&t&&(a.Sb(0,"span"),a.zc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function N(t,c){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.zc(2),a.ec(3,"json"),a.Nb(4,"br"),a.Rb(),a.yc(5,G,3,0,"span",4),a.Rb()),2&t){const t=c.$implicit;a.Bb(2),a.Ac(a.fc(3,2,t)),a.Bb(3),a.ic("ngIf",t.required)}}function k(t,c){1&t&&(a.Sb(0,"span"),a.zc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function E(t,c){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.zc(2),a.ec(3,"json"),a.Nb(4,"br"),a.Rb(),a.yc(5,k,3,0,"span",4),a.Rb()),2&t){const t=c.$implicit;a.Bb(2),a.Ac(a.fc(3,2,t)),a.Bb(3),a.ic("ngIf",t.required)}}let q=(()=>{class t{constructor(t,c){this.contactshortcutService=t,this.fb=c,this.contactshortcut=null,this.httpClientCommand=s.a.Put}GetPut(){return this.httpClientCommand==s.a.Put}PutContactShortcut(t){this.sub=this.contactshortcutService.PutContactShortcut(t).subscribe()}PostContactShortcut(t){this.sub=this.contactshortcutService.PostContactShortcut(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.contactshortcut){let c=this.fb.group({ContactShortcutID:[{value:t===s.a.Post?0:this.contactshortcut.ContactShortcutID,disabled:!1},[I.p.required]],ContactID:[{value:this.contactshortcut.ContactID,disabled:!1},[I.p.required]],ShortCutText:[{value:this.contactshortcut.ShortCutText,disabled:!1},[I.p.required,I.p.maxLength(100)]],ShortCutAddress:[{value:this.contactshortcut.ShortCutAddress,disabled:!1},[I.p.required,I.p.maxLength(200)]],LastUpdateDate_UTC:[{value:this.contactshortcut.LastUpdateDate_UTC,disabled:!1},[I.p.required]],LastUpdateContactTVItemID:[{value:this.contactshortcut.LastUpdateContactTVItemID,disabled:!1},[I.p.required]]});this.contactshortcutFormEdit=c}}}return t.\u0275fac=function(c){return new(c||t)(a.Mb(d),a.Mb(I.d))},t.\u0275cmp=a.Gb({type:t,selectors:[["app-contactshortcut-edit"]],inputs:{contactshortcut:"contactshortcut",httpClientCommand:"httpClientCommand"},decls:40,vars:10,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","ContactShortcutID"],[4,"ngIf"],["matInput","","type","number","formControlName","ContactID"],["matInput","","type","text","formControlName","ShortCutText"],["matInput","","type","text","formControlName","ShortCutAddress"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,c){1&t&&(a.Sb(0,"form",0),a.Zb("ngSubmit",(function(){return c.GetPut()?c.PutContactShortcut(c.contactshortcutFormEdit.value):c.PostContactShortcut(c.contactshortcutFormEdit.value)})),a.Sb(1,"h3"),a.zc(2," ContactShortcut "),a.Sb(3,"button",1),a.Sb(4,"span"),a.zc(5),a.Rb(),a.Rb(),a.yc(6,D,1,0,"mat-progress-bar",2),a.yc(7,v,1,0,"mat-progress-bar",2),a.Rb(),a.Sb(8,"p"),a.Sb(9,"mat-form-field"),a.Sb(10,"mat-label"),a.zc(11,"ContactShortcutID"),a.Rb(),a.Nb(12,"input",3),a.yc(13,P,6,4,"mat-error",4),a.Rb(),a.Sb(14,"mat-form-field"),a.Sb(15,"mat-label"),a.zc(16,"ContactID"),a.Rb(),a.Nb(17,"input",5),a.yc(18,T,6,4,"mat-error",4),a.Rb(),a.Sb(19,"mat-form-field"),a.Sb(20,"mat-label"),a.zc(21,"ShortCutText"),a.Rb(),a.Nb(22,"input",6),a.yc(23,M,7,5,"mat-error",4),a.Rb(),a.Sb(24,"mat-form-field"),a.Sb(25,"mat-label"),a.zc(26,"ShortCutAddress"),a.Rb(),a.Nb(27,"input",7),a.yc(28,x,7,5,"mat-error",4),a.Rb(),a.Rb(),a.Sb(29,"p"),a.Sb(30,"mat-form-field"),a.Sb(31,"mat-label"),a.zc(32,"LastUpdateDate_UTC"),a.Rb(),a.Nb(33,"input",8),a.yc(34,N,6,4,"mat-error",4),a.Rb(),a.Sb(35,"mat-form-field"),a.Sb(36,"mat-label"),a.zc(37,"LastUpdateContactTVItemID"),a.Rb(),a.Nb(38,"input",9),a.yc(39,E,6,4,"mat-error",4),a.Rb(),a.Rb(),a.Rb()),2&t&&(a.ic("formGroup",c.contactshortcutFormEdit),a.Bb(5),a.Bc("",c.GetPut()?"Put":"Post"," ContactShortcut"),a.Bb(1),a.ic("ngIf",c.contactshortcutService.contactshortcutPutModel$.getValue().Working),a.Bb(1),a.ic("ngIf",c.contactshortcutService.contactshortcutPostModel$.getValue().Working),a.Bb(6),a.ic("ngIf",c.contactshortcutFormEdit.controls.ContactShortcutID.errors),a.Bb(5),a.ic("ngIf",c.contactshortcutFormEdit.controls.ContactID.errors),a.Bb(5),a.ic("ngIf",c.contactshortcutFormEdit.controls.ShortCutText.errors),a.Bb(5),a.ic("ngIf",c.contactshortcutFormEdit.controls.ShortCutAddress.errors),a.Bb(6),a.ic("ngIf",c.contactshortcutFormEdit.controls.LastUpdateDate_UTC.errors),a.Bb(5),a.ic("ngIf",c.contactshortcutFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[I.q,I.l,I.f,m.b,e.l,R.c,R.f,g.b,I.n,I.c,I.k,I.e,f.a,R.b],pipes:[e.f],styles:[""],changeDetection:0}),t})();function U(t,c){1&t&&a.Nb(0,"mat-progress-bar",4)}function j(t,c){1&t&&a.Nb(0,"mat-progress-bar",4)}function O(t,c){if(1&t&&(a.Sb(0,"p"),a.Nb(1,"app-contactshortcut-edit",8),a.Rb()),2&t){const t=a.dc().$implicit,c=a.dc(2);a.Bb(1),a.ic("contactshortcut",t)("httpClientCommand",c.GetPutEnum())}}function V(t,c){if(1&t&&(a.Sb(0,"p"),a.Nb(1,"app-contactshortcut-edit",8),a.Rb()),2&t){const t=a.dc().$implicit,c=a.dc(2);a.Bb(1),a.ic("contactshortcut",t)("httpClientCommand",c.GetPostEnum())}}function F(t,c){if(1&t){const t=a.Tb();a.Sb(0,"div"),a.Sb(1,"p"),a.Sb(2,"button",6),a.Zb("click",(function(){a.qc(t);const o=c.$implicit;return a.dc(2).DeleteContactShortcut(o)})),a.Sb(3,"span"),a.zc(4),a.Rb(),a.Sb(5,"mat-icon"),a.zc(6,"delete"),a.Rb(),a.Rb(),a.zc(7,"\xa0\xa0\xa0 "),a.Sb(8,"button",7),a.Zb("click",(function(){a.qc(t);const o=c.$implicit;return a.dc(2).ShowPut(o)})),a.Sb(9,"span"),a.zc(10,"Show Put"),a.Rb(),a.Rb(),a.zc(11,"\xa0\xa0 "),a.Sb(12,"button",7),a.Zb("click",(function(){a.qc(t);const o=c.$implicit;return a.dc(2).ShowPost(o)})),a.Sb(13,"span"),a.zc(14,"Show Post"),a.Rb(),a.Rb(),a.zc(15,"\xa0\xa0 "),a.yc(16,j,1,0,"mat-progress-bar",0),a.Rb(),a.yc(17,O,2,2,"p",2),a.yc(18,V,2,2,"p",2),a.Sb(19,"blockquote"),a.Sb(20,"p"),a.Sb(21,"span"),a.zc(22),a.Rb(),a.Sb(23,"span"),a.zc(24),a.Rb(),a.Sb(25,"span"),a.zc(26),a.Rb(),a.Sb(27,"span"),a.zc(28),a.Rb(),a.Rb(),a.Sb(29,"p"),a.Sb(30,"span"),a.zc(31),a.Rb(),a.Sb(32,"span"),a.zc(33),a.Rb(),a.Rb(),a.Rb(),a.Rb()}if(2&t){const t=c.$implicit,o=a.dc(2);a.Bb(4),a.Bc("Delete ContactShortcutID [",t.ContactShortcutID,"]\xa0\xa0\xa0"),a.Bb(4),a.ic("color",o.GetPutButtonColor(t)),a.Bb(4),a.ic("color",o.GetPostButtonColor(t)),a.Bb(4),a.ic("ngIf",o.contactshortcutService.contactshortcutDeleteModel$.getValue().Working),a.Bb(1),a.ic("ngIf",o.IDToShow===t.ContactShortcutID&&o.showType===o.GetPutEnum()),a.Bb(1),a.ic("ngIf",o.IDToShow===t.ContactShortcutID&&o.showType===o.GetPostEnum()),a.Bb(4),a.Bc("ContactShortcutID: [",t.ContactShortcutID,"]"),a.Bb(2),a.Bc(" --- ContactID: [",t.ContactID,"]"),a.Bb(2),a.Bc(" --- ShortCutText: [",t.ShortCutText,"]"),a.Bb(2),a.Bc(" --- ShortCutAddress: [",t.ShortCutAddress,"]"),a.Bb(3),a.Bc("LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),a.Bb(2),a.Bc(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function A(t,c){if(1&t&&(a.Sb(0,"div"),a.yc(1,F,34,12,"div",5),a.Rb()),2&t){const t=a.dc();a.Bb(1),a.ic("ngForOf",t.contactshortcutService.contactshortcutListModel$.getValue())}}const W=[{path:"",component:(()=>{class t{constructor(t,c,o){this.contactshortcutService=t,this.router=c,this.httpClientService=o,this.showType=null,o.oldURL=c.url}GetPutButtonColor(t){return this.IDToShow===t.ContactShortcutID&&this.showType===s.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.ContactShortcutID&&this.showType===s.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.ContactShortcutID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactShortcutID,this.showType=s.a.Put)}ShowPost(t){this.IDToShow===t.ContactShortcutID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactShortcutID,this.showType=s.a.Post)}GetPutEnum(){return s.a.Put}GetPostEnum(){return s.a.Post}GetContactShortcutList(){this.sub=this.contactshortcutService.GetContactShortcutList().subscribe()}DeleteContactShortcut(t){this.sub=this.contactshortcutService.DeleteContactShortcut(t).subscribe()}ngOnInit(){n(this.contactshortcutService.contactshortcutTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(c){return new(c||t)(a.Mb(d),a.Mb(r.b),a.Mb(p.a))},t.\u0275cmp=a.Gb({type:t,selectors:[["app-contactshortcut"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"contactshortcut","httpClientCommand"]],template:function(t,c){var o,e;1&t&&(a.yc(0,U,1,0,"mat-progress-bar",0),a.Sb(1,"mat-card"),a.Sb(2,"mat-card-header"),a.Sb(3,"mat-card-title"),a.zc(4," ContactShortcut works! "),a.Sb(5,"button",1),a.Zb("click",(function(){return c.GetContactShortcutList()})),a.Sb(6,"span"),a.zc(7,"Get ContactShortcut"),a.Rb(),a.Rb(),a.Rb(),a.Sb(8,"mat-card-subtitle"),a.zc(9),a.Rb(),a.Rb(),a.Sb(10,"mat-card-content"),a.yc(11,A,2,1,"div",2),a.Rb(),a.Sb(12,"mat-card-actions"),a.Sb(13,"button",3),a.zc(14,"Allo"),a.Rb(),a.Rb(),a.Rb()),2&t&&(a.ic("ngIf",null==(o=c.contactshortcutService.contactshortcutGetModel$.getValue())?null:o.Working),a.Bb(9),a.Ac(c.contactshortcutService.contactshortcutTextModel$.getValue().Title),a.Bb(2),a.ic("ngIf",null==(e=c.contactshortcutService.contactshortcutListModel$.getValue())?null:e.length))},directives:[e.l,S.a,S.d,S.g,m.b,S.f,S.c,S.b,f.a,e.k,C.a,q],styles:[""],changeDetection:0}),t})(),canActivate:[o("auXs").a]}];let _=(()=>{class t{}return t.\u0275mod=a.Kb({type:t}),t.\u0275inj=a.Jb({factory:function(c){return new(c||t)},imports:[[r.e.forChild(W)],r.e]}),t})();var H=o("B+Mi");let J=(()=>{class t{}return t.\u0275mod=a.Kb({type:t}),t.\u0275inj=a.Jb({factory:function(c){return new(c||t)},imports:[[e.c,r.e,_,H.a,I.g,I.o]]}),t})()},QRvi:function(t,c,o){"use strict";o.d(c,"a",(function(){return e}));var e=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,c,o){"use strict";o.d(c,"a",(function(){return s}));var e=o("QRvi"),r=o("fXoL"),n=o("tyNb");let s=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,c,o){t.next(null),c.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,c,o){t.next(null),c.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,c,o,r,n){if(r===e.a.Get&&t.next(o),r===e.a.Put&&(t.getValue()[0]=o),r===e.a.Post&&t.getValue().push(o),r===e.a.Delete){const c=t.getValue().indexOf(n);t.getValue().splice(c,1)}t.next(t.getValue()),c.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,c,o,r,n){r===e.a.Get&&t.next(o),t.next(t.getValue()),c.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(c){return new(c||t)(r.Wb(n.b))},t.\u0275prov=r.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);