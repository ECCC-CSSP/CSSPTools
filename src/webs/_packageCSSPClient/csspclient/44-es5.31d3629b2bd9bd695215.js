!function(){function t(t,o){if(!(t instanceof o))throw new TypeError("Cannot call a class as a function")}function o(t,o){for(var c=0;c<o.length;c++){var e=o[c];e.enumerable=e.enumerable||!1,e.configurable=!0,"value"in e&&(e.writable=!0),Object.defineProperty(t,e.key,e)}}function c(t,c,e){return c&&o(t.prototype,c),e&&o(t,e),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[44],{Ho8B:function(o,e,n){"use strict";n.r(e),n.d(e,"ContactShortcutModule",(function(){return ot}));var r=n("ofXK"),a=n("tyNb");function i(t){var o={Title:"The title"};"fr-CA"===$localize.locale&&(o.Title="Le Titre"),t.next(o)}var u,s=n("QRvi"),b=n("fXoL"),h=n("2Vo4"),l=n("LRne"),p=n("tk/3"),f=n("lJxs"),d=n("JIr8"),S=n("gkM4"),m=((u=function(){function o(c,e){t(this,o),this.httpClient=c,this.httpClientService=e,this.contactshortcutTextModel$=new h.a({}),this.contactshortcutListModel$=new h.a({}),this.contactshortcutGetModel$=new h.a({}),this.contactshortcutPutModel$=new h.a({}),this.contactshortcutPostModel$=new h.a({}),this.contactshortcutDeleteModel$=new h.a({}),i(this.contactshortcutTextModel$),this.contactshortcutTextModel$.next({Title:"Something2 for text"})}return c(o,[{key:"GetContactShortcutList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.contactshortcutGetModel$),this.httpClient.get("/api/ContactShortcut").pipe(Object(f.a)((function(o){t.httpClientService.DoSuccess(t.contactshortcutListModel$,t.contactshortcutGetModel$,o,s.a.Get,null)})),Object(d.a)((function(o){return Object(l.a)(o).pipe(Object(f.a)((function(o){t.httpClientService.DoCatchError(t.contactshortcutListModel$,t.contactshortcutGetModel$,o)})))})))}},{key:"PutContactShortcut",value:function(t){var o=this;return this.httpClientService.BeforeHttpClient(this.contactshortcutPutModel$),this.httpClient.put("/api/ContactShortcut",t,{headers:new p.d}).pipe(Object(f.a)((function(c){o.httpClientService.DoSuccess(o.contactshortcutListModel$,o.contactshortcutPutModel$,c,s.a.Put,t)})),Object(d.a)((function(t){return Object(l.a)(t).pipe(Object(f.a)((function(t){o.httpClientService.DoCatchError(o.contactshortcutListModel$,o.contactshortcutPutModel$,t)})))})))}},{key:"PostContactShortcut",value:function(t){var o=this;return this.httpClientService.BeforeHttpClient(this.contactshortcutPostModel$),this.httpClient.post("/api/ContactShortcut",t,{headers:new p.d}).pipe(Object(f.a)((function(c){o.httpClientService.DoSuccess(o.contactshortcutListModel$,o.contactshortcutPostModel$,c,s.a.Post,t)})),Object(d.a)((function(t){return Object(l.a)(t).pipe(Object(f.a)((function(t){o.httpClientService.DoCatchError(o.contactshortcutListModel$,o.contactshortcutPostModel$,t)})))})))}},{key:"DeleteContactShortcut",value:function(t){var o=this;return this.httpClientService.BeforeHttpClient(this.contactshortcutDeleteModel$),this.httpClient.delete("/api/ContactShortcut/"+t.ContactShortcutID).pipe(Object(f.a)((function(c){o.httpClientService.DoSuccess(o.contactshortcutListModel$,o.contactshortcutDeleteModel$,c,s.a.Delete,t)})),Object(d.a)((function(t){return Object(l.a)(t).pipe(Object(f.a)((function(t){o.httpClientService.DoCatchError(o.contactshortcutListModel$,o.contactshortcutDeleteModel$,t)})))})))}}]),o}()).\u0275fac=function(t){return new(t||u)(b.Wb(p.b),b.Wb(S.a))},u.\u0275prov=b.Ib({token:u,factory:u.\u0275fac,providedIn:"root"}),u),C=n("Wp6s"),v=n("bTqV"),I=n("bv9b"),y=n("NFeN"),g=n("3Pt+"),R=n("kmnG"),D=n("qFsG");function B(t,o){1&t&&b.Nb(0,"mat-progress-bar",10)}function P(t,o){1&t&&b.Nb(0,"mat-progress-bar",10)}function k(t,o){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function T(t,o){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,k,3,0,"span",4),b.Rb()),2&t){var c=o.$implicit;b.Bb(2),b.Ac(b.fc(3,2,c)),b.Bb(3),b.ic("ngIf",c.required)}}function w(t,o){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function $(t,o){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,w,3,0,"span",4),b.Rb()),2&t){var c=o.$implicit;b.Bb(2),b.Ac(b.fc(3,2,c)),b.Bb(3),b.ic("ngIf",c.required)}}function M(t,o){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function L(t,o){1&t&&(b.Sb(0,"span"),b.zc(1,"MaxLength - 100"),b.Nb(2,"br"),b.Rb())}function z(t,o){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,M,3,0,"span",4),b.yc(6,L,3,0,"span",4),b.Rb()),2&t){var c=o.$implicit;b.Bb(2),b.Ac(b.fc(3,3,c)),b.Bb(3),b.ic("ngIf",c.required),b.Bb(1),b.ic("ngIf",c.maxlength)}}function x(t,o){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function G(t,o){1&t&&(b.Sb(0,"span"),b.zc(1,"MaxLength - 200"),b.Nb(2,"br"),b.Rb())}function N(t,o){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,x,3,0,"span",4),b.yc(6,G,3,0,"span",4),b.Rb()),2&t){var c=o.$implicit;b.Bb(2),b.Ac(b.fc(3,3,c)),b.Bb(3),b.ic("ngIf",c.required),b.Bb(1),b.ic("ngIf",c.maxlength)}}function E(t,o){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function j(t,o){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,E,3,0,"span",4),b.Rb()),2&t){var c=o.$implicit;b.Bb(2),b.Ac(b.fc(3,2,c)),b.Bb(3),b.ic("ngIf",c.required)}}function q(t,o){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function U(t,o){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,q,3,0,"span",4),b.Rb()),2&t){var c=o.$implicit;b.Bb(2),b.Ac(b.fc(3,2,c)),b.Bb(3),b.ic("ngIf",c.required)}}var O,V=((O=function(){function o(c,e){t(this,o),this.contactshortcutService=c,this.fb=e,this.contactshortcut=null,this.httpClientCommand=s.a.Put}return c(o,[{key:"GetPut",value:function(){return this.httpClientCommand==s.a.Put}},{key:"PutContactShortcut",value:function(t){this.sub=this.contactshortcutService.PutContactShortcut(t).subscribe()}},{key:"PostContactShortcut",value:function(t){this.sub=this.contactshortcutService.PostContactShortcut(t).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.contactshortcut){var o=this.fb.group({ContactShortcutID:[{value:t===s.a.Post?0:this.contactshortcut.ContactShortcutID,disabled:!1},[g.p.required]],ContactID:[{value:this.contactshortcut.ContactID,disabled:!1},[g.p.required]],ShortCutText:[{value:this.contactshortcut.ShortCutText,disabled:!1},[g.p.required,g.p.maxLength(100)]],ShortCutAddress:[{value:this.contactshortcut.ShortCutAddress,disabled:!1},[g.p.required,g.p.maxLength(200)]],LastUpdateDate_UTC:[{value:this.contactshortcut.LastUpdateDate_UTC,disabled:!1},[g.p.required]],LastUpdateContactTVItemID:[{value:this.contactshortcut.LastUpdateContactTVItemID,disabled:!1},[g.p.required]]});this.contactshortcutFormEdit=o}}}]),o}()).\u0275fac=function(t){return new(t||O)(b.Mb(m),b.Mb(g.d))},O.\u0275cmp=b.Gb({type:O,selectors:[["app-contactshortcut-edit"]],inputs:{contactshortcut:"contactshortcut",httpClientCommand:"httpClientCommand"},decls:40,vars:10,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","ContactShortcutID"],[4,"ngIf"],["matInput","","type","number","formControlName","ContactID"],["matInput","","type","text","formControlName","ShortCutText"],["matInput","","type","text","formControlName","ShortCutAddress"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,o){1&t&&(b.Sb(0,"form",0),b.Zb("ngSubmit",(function(){return o.GetPut()?o.PutContactShortcut(o.contactshortcutFormEdit.value):o.PostContactShortcut(o.contactshortcutFormEdit.value)})),b.Sb(1,"h3"),b.zc(2," ContactShortcut "),b.Sb(3,"button",1),b.Sb(4,"span"),b.zc(5),b.Rb(),b.Rb(),b.yc(6,B,1,0,"mat-progress-bar",2),b.yc(7,P,1,0,"mat-progress-bar",2),b.Rb(),b.Sb(8,"p"),b.Sb(9,"mat-form-field"),b.Sb(10,"mat-label"),b.zc(11,"ContactShortcutID"),b.Rb(),b.Nb(12,"input",3),b.yc(13,T,6,4,"mat-error",4),b.Rb(),b.Sb(14,"mat-form-field"),b.Sb(15,"mat-label"),b.zc(16,"ContactID"),b.Rb(),b.Nb(17,"input",5),b.yc(18,$,6,4,"mat-error",4),b.Rb(),b.Sb(19,"mat-form-field"),b.Sb(20,"mat-label"),b.zc(21,"ShortCutText"),b.Rb(),b.Nb(22,"input",6),b.yc(23,z,7,5,"mat-error",4),b.Rb(),b.Sb(24,"mat-form-field"),b.Sb(25,"mat-label"),b.zc(26,"ShortCutAddress"),b.Rb(),b.Nb(27,"input",7),b.yc(28,N,7,5,"mat-error",4),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"mat-form-field"),b.Sb(31,"mat-label"),b.zc(32,"LastUpdateDate_UTC"),b.Rb(),b.Nb(33,"input",8),b.yc(34,j,6,4,"mat-error",4),b.Rb(),b.Sb(35,"mat-form-field"),b.Sb(36,"mat-label"),b.zc(37,"LastUpdateContactTVItemID"),b.Rb(),b.Nb(38,"input",9),b.yc(39,U,6,4,"mat-error",4),b.Rb(),b.Rb(),b.Rb()),2&t&&(b.ic("formGroup",o.contactshortcutFormEdit),b.Bb(5),b.Bc("",o.GetPut()?"Put":"Post"," ContactShortcut"),b.Bb(1),b.ic("ngIf",o.contactshortcutService.contactshortcutPutModel$.getValue().Working),b.Bb(1),b.ic("ngIf",o.contactshortcutService.contactshortcutPostModel$.getValue().Working),b.Bb(6),b.ic("ngIf",o.contactshortcutFormEdit.controls.ContactShortcutID.errors),b.Bb(5),b.ic("ngIf",o.contactshortcutFormEdit.controls.ContactID.errors),b.Bb(5),b.ic("ngIf",o.contactshortcutFormEdit.controls.ShortCutText.errors),b.Bb(5),b.ic("ngIf",o.contactshortcutFormEdit.controls.ShortCutAddress.errors),b.Bb(6),b.ic("ngIf",o.contactshortcutFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(5),b.ic("ngIf",o.contactshortcutFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[g.q,g.l,g.f,v.b,r.l,R.c,R.f,D.b,g.n,g.c,g.k,g.e,I.a,R.b],pipes:[r.f],styles:[""],changeDetection:0}),O);function F(t,o){1&t&&b.Nb(0,"mat-progress-bar",4)}function A(t,o){1&t&&b.Nb(0,"mat-progress-bar",4)}function W(t,o){if(1&t&&(b.Sb(0,"p"),b.Nb(1,"app-contactshortcut-edit",8),b.Rb()),2&t){var c=b.dc().$implicit,e=b.dc(2);b.Bb(1),b.ic("contactshortcut",c)("httpClientCommand",e.GetPutEnum())}}function _(t,o){if(1&t&&(b.Sb(0,"p"),b.Nb(1,"app-contactshortcut-edit",8),b.Rb()),2&t){var c=b.dc().$implicit,e=b.dc(2);b.Bb(1),b.ic("contactshortcut",c)("httpClientCommand",e.GetPostEnum())}}function H(t,o){if(1&t){var c=b.Tb();b.Sb(0,"div"),b.Sb(1,"p"),b.Sb(2,"button",6),b.Zb("click",(function(){b.qc(c);var t=o.$implicit;return b.dc(2).DeleteContactShortcut(t)})),b.Sb(3,"span"),b.zc(4),b.Rb(),b.Sb(5,"mat-icon"),b.zc(6,"delete"),b.Rb(),b.Rb(),b.zc(7,"\xa0\xa0\xa0 "),b.Sb(8,"button",7),b.Zb("click",(function(){b.qc(c);var t=o.$implicit;return b.dc(2).ShowPut(t)})),b.Sb(9,"span"),b.zc(10,"Show Put"),b.Rb(),b.Rb(),b.zc(11,"\xa0\xa0 "),b.Sb(12,"button",7),b.Zb("click",(function(){b.qc(c);var t=o.$implicit;return b.dc(2).ShowPost(t)})),b.Sb(13,"span"),b.zc(14,"Show Post"),b.Rb(),b.Rb(),b.zc(15,"\xa0\xa0 "),b.yc(16,A,1,0,"mat-progress-bar",0),b.Rb(),b.yc(17,W,2,2,"p",2),b.yc(18,_,2,2,"p",2),b.Sb(19,"blockquote"),b.Sb(20,"p"),b.Sb(21,"span"),b.zc(22),b.Rb(),b.Sb(23,"span"),b.zc(24),b.Rb(),b.Sb(25,"span"),b.zc(26),b.Rb(),b.Sb(27,"span"),b.zc(28),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"span"),b.zc(31),b.Rb(),b.Sb(32,"span"),b.zc(33),b.Rb(),b.Rb(),b.Rb(),b.Rb()}if(2&t){var e=o.$implicit,n=b.dc(2);b.Bb(4),b.Bc("Delete ContactShortcutID [",e.ContactShortcutID,"]\xa0\xa0\xa0"),b.Bb(4),b.ic("color",n.GetPutButtonColor(e)),b.Bb(4),b.ic("color",n.GetPostButtonColor(e)),b.Bb(4),b.ic("ngIf",n.contactshortcutService.contactshortcutDeleteModel$.getValue().Working),b.Bb(1),b.ic("ngIf",n.IDToShow===e.ContactShortcutID&&n.showType===n.GetPutEnum()),b.Bb(1),b.ic("ngIf",n.IDToShow===e.ContactShortcutID&&n.showType===n.GetPostEnum()),b.Bb(4),b.Bc("ContactShortcutID: [",e.ContactShortcutID,"]"),b.Bb(2),b.Bc(" --- ContactID: [",e.ContactID,"]"),b.Bb(2),b.Bc(" --- ShortCutText: [",e.ShortCutText,"]"),b.Bb(2),b.Bc(" --- ShortCutAddress: [",e.ShortCutAddress,"]"),b.Bb(3),b.Bc("LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),b.Bb(2),b.Bc(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function J(t,o){if(1&t&&(b.Sb(0,"div"),b.yc(1,H,34,12,"div",5),b.Rb()),2&t){var c=b.dc();b.Bb(1),b.ic("ngForOf",c.contactshortcutService.contactshortcutListModel$.getValue())}}var Z,X,K,Q=[{path:"",component:(Z=function(){function o(c,e,n){t(this,o),this.contactshortcutService=c,this.router=e,this.httpClientService=n,this.showType=null,n.oldURL=e.url}return c(o,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.ContactShortcutID&&this.showType===s.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.ContactShortcutID&&this.showType===s.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.ContactShortcutID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactShortcutID,this.showType=s.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.ContactShortcutID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactShortcutID,this.showType=s.a.Post)}},{key:"GetPutEnum",value:function(){return s.a.Put}},{key:"GetPostEnum",value:function(){return s.a.Post}},{key:"GetContactShortcutList",value:function(){this.sub=this.contactshortcutService.GetContactShortcutList().subscribe()}},{key:"DeleteContactShortcut",value:function(t){this.sub=this.contactshortcutService.DeleteContactShortcut(t).subscribe()}},{key:"ngOnInit",value:function(){i(this.contactshortcutService.contactshortcutTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),o}(),Z.\u0275fac=function(t){return new(t||Z)(b.Mb(m),b.Mb(a.b),b.Mb(S.a))},Z.\u0275cmp=b.Gb({type:Z,selectors:[["app-contactshortcut"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"contactshortcut","httpClientCommand"]],template:function(t,o){if(1&t&&(b.yc(0,F,1,0,"mat-progress-bar",0),b.Sb(1,"mat-card"),b.Sb(2,"mat-card-header"),b.Sb(3,"mat-card-title"),b.zc(4," ContactShortcut works! "),b.Sb(5,"button",1),b.Zb("click",(function(){return o.GetContactShortcutList()})),b.Sb(6,"span"),b.zc(7,"Get ContactShortcut"),b.Rb(),b.Rb(),b.Rb(),b.Sb(8,"mat-card-subtitle"),b.zc(9),b.Rb(),b.Rb(),b.Sb(10,"mat-card-content"),b.yc(11,J,2,1,"div",2),b.Rb(),b.Sb(12,"mat-card-actions"),b.Sb(13,"button",3),b.zc(14,"Allo"),b.Rb(),b.Rb(),b.Rb()),2&t){var c,e,n=null==(c=o.contactshortcutService.contactshortcutGetModel$.getValue())?null:c.Working,r=null==(e=o.contactshortcutService.contactshortcutListModel$.getValue())?null:e.length;b.ic("ngIf",n),b.Bb(9),b.Ac(o.contactshortcutService.contactshortcutTextModel$.getValue().Title),b.Bb(2),b.ic("ngIf",r)}},directives:[r.l,C.a,C.d,C.g,v.b,C.f,C.c,C.b,I.a,r.k,y.a,V],styles:[""],changeDetection:0}),Z),canActivate:[n("auXs").a]}],Y=((X=function o(){t(this,o)}).\u0275mod=b.Kb({type:X}),X.\u0275inj=b.Jb({factory:function(t){return new(t||X)},imports:[[a.e.forChild(Q)],a.e]}),X),tt=n("B+Mi"),ot=((K=function o(){t(this,o)}).\u0275mod=b.Kb({type:K}),K.\u0275inj=b.Jb({factory:function(t){return new(t||K)},imports:[[r.c,a.e,Y,tt.a,g.g,g.o]]}),K)},QRvi:function(t,o,c){"use strict";c.d(o,"a",(function(){return e}));var e=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(o,e,n){"use strict";n.d(e,"a",(function(){return u}));var r=n("QRvi"),a=n("fXoL"),i=n("tyNb"),u=function(){var o=function(){function o(c){t(this,o),this.router=c,this.oldURL=c.url}return c(o,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,o,c){t.next(null),o.next({Working:!1,Error:c,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,o,c){t.next(null),o.next({Working:!1,Error:c,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,o,c,e,n){if(e===r.a.Get&&t.next(c),e===r.a.Put&&(t.getValue()[0]=c),e===r.a.Post&&t.getValue().push(c),e===r.a.Delete){var a=t.getValue().indexOf(n);t.getValue().splice(a,1)}t.next(t.getValue()),o.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,o,c,e,n){e===r.a.Get&&t.next(c),t.next(t.getValue()),o.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),o}();return o.\u0275fac=function(t){return new(t||o)(a.Wb(i.b))},o.\u0275prov=a.Ib({token:o,factory:o.\u0275fac,providedIn:"root"}),o}()}}])}();