function _classCallCheck(t,c){if(!(t instanceof c))throw new TypeError("Cannot call a class as a function")}function _defineProperties(t,c){for(var e=0;e<c.length;e++){var o=c[e];o.enumerable=o.enumerable||!1,o.configurable=!0,"value"in o&&(o.writable=!0),Object.defineProperty(t,o.key,o)}}function _createClass(t,c,e){return c&&_defineProperties(t.prototype,c),e&&_defineProperties(t,e),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[44],{Ho8B:function(t,c,e){"use strict";e.r(c),e.d(c,"ContactShortcutModule",(function(){return Z}));var o=e("ofXK"),n=e("tyNb");function r(t){var c={Title:"The title"};"fr-CA"===$localize.locale&&(c.Title="Le Titre"),t.next(c)}var a,i=e("QRvi"),u=e("fXoL"),s=e("2Vo4"),b=e("LRne"),l=e("tk/3"),h=e("lJxs"),p=e("JIr8"),f=e("gkM4"),d=((a=function(){function t(c,e){_classCallCheck(this,t),this.httpClient=c,this.httpClientService=e,this.contactshortcutTextModel$=new s.a({}),this.contactshortcutListModel$=new s.a({}),this.contactshortcutGetModel$=new s.a({}),this.contactshortcutPutModel$=new s.a({}),this.contactshortcutPostModel$=new s.a({}),this.contactshortcutDeleteModel$=new s.a({}),r(this.contactshortcutTextModel$),this.contactshortcutTextModel$.next({Title:"Something2 for text"})}return _createClass(t,[{key:"GetContactShortcutList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.contactshortcutGetModel$),this.httpClient.get("/api/ContactShortcut").pipe(Object(h.a)((function(c){t.httpClientService.DoSuccess(t.contactshortcutListModel$,t.contactshortcutGetModel$,c,i.a.Get,null)})),Object(p.a)((function(c){return Object(b.a)(c).pipe(Object(h.a)((function(c){t.httpClientService.DoCatchError(t.contactshortcutListModel$,t.contactshortcutGetModel$,c)})))})))}},{key:"PutContactShortcut",value:function(t){var c=this;return this.httpClientService.BeforeHttpClient(this.contactshortcutPutModel$),this.httpClient.put("/api/ContactShortcut",t,{headers:new l.d}).pipe(Object(h.a)((function(e){c.httpClientService.DoSuccess(c.contactshortcutListModel$,c.contactshortcutPutModel$,e,i.a.Put,t)})),Object(p.a)((function(t){return Object(b.a)(t).pipe(Object(h.a)((function(t){c.httpClientService.DoCatchError(c.contactshortcutListModel$,c.contactshortcutPutModel$,t)})))})))}},{key:"PostContactShortcut",value:function(t){var c=this;return this.httpClientService.BeforeHttpClient(this.contactshortcutPostModel$),this.httpClient.post("/api/ContactShortcut",t,{headers:new l.d}).pipe(Object(h.a)((function(e){c.httpClientService.DoSuccess(c.contactshortcutListModel$,c.contactshortcutPostModel$,e,i.a.Post,t)})),Object(p.a)((function(t){return Object(b.a)(t).pipe(Object(h.a)((function(t){c.httpClientService.DoCatchError(c.contactshortcutListModel$,c.contactshortcutPostModel$,t)})))})))}},{key:"DeleteContactShortcut",value:function(t){var c=this;return this.httpClientService.BeforeHttpClient(this.contactshortcutDeleteModel$),this.httpClient.delete("/api/ContactShortcut/"+t.ContactShortcutID).pipe(Object(h.a)((function(e){c.httpClientService.DoSuccess(c.contactshortcutListModel$,c.contactshortcutDeleteModel$,e,i.a.Delete,t)})),Object(p.a)((function(t){return Object(b.a)(t).pipe(Object(h.a)((function(t){c.httpClientService.DoCatchError(c.contactshortcutListModel$,c.contactshortcutDeleteModel$,t)})))})))}}]),t}()).\u0275fac=function(t){return new(t||a)(u.Xb(l.b),u.Xb(f.a))},a.\u0275prov=u.Jb({token:a,factory:a.\u0275fac,providedIn:"root"}),a),S=e("Wp6s"),m=e("bTqV"),C=e("bv9b"),T=e("NFeN"),v=e("3Pt+"),y=e("kmnG"),g=e("qFsG");function I(t,c){1&t&&u.Ob(0,"mat-progress-bar",10)}function D(t,c){1&t&&u.Ob(0,"mat-progress-bar",10)}function k(t,c){1&t&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function P(t,c){if(1&t&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,k,3,0,"span",4),u.Sb()),2&t){var e=c.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}function x(t,c){1&t&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function B(t,c){if(1&t&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,x,3,0,"span",4),u.Sb()),2&t){var e=c.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}function j(t,c){1&t&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function w(t,c){1&t&&(u.Tb(0,"span"),u.yc(1,"MaxLength - 100"),u.Ob(2,"br"),u.Sb())}function O(t,c){if(1&t&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,j,3,0,"span",4),u.xc(6,w,3,0,"span",4),u.Sb()),2&t){var e=c.$implicit;u.Bb(2),u.zc(u.gc(3,3,e)),u.Bb(3),u.jc("ngIf",e.required),u.Bb(1),u.jc("ngIf",e.maxlength)}}function $(t,c){1&t&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function L(t,c){1&t&&(u.Tb(0,"span"),u.yc(1,"MaxLength - 200"),u.Ob(2,"br"),u.Sb())}function M(t,c){if(1&t&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,$,3,0,"span",4),u.xc(6,L,3,0,"span",4),u.Sb()),2&t){var e=c.$implicit;u.Bb(2),u.zc(u.gc(3,3,e)),u.Bb(3),u.jc("ngIf",e.required),u.Bb(1),u.jc("ngIf",e.maxlength)}}function G(t,c){1&t&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function E(t,c){if(1&t&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,G,3,0,"span",4),u.Sb()),2&t){var e=c.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}function U(t,c){1&t&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function q(t,c){if(1&t&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,U,3,0,"span",4),u.Sb()),2&t){var e=c.$implicit;u.Bb(2),u.zc(u.gc(3,2,e)),u.Bb(3),u.jc("ngIf",e.required)}}var V,_=((V=function(){function t(c,e){_classCallCheck(this,t),this.contactshortcutService=c,this.fb=e,this.contactshortcut=null,this.httpClientCommand=i.a.Put}return _createClass(t,[{key:"GetPut",value:function(){return this.httpClientCommand==i.a.Put}},{key:"PutContactShortcut",value:function(t){this.sub=this.contactshortcutService.PutContactShortcut(t).subscribe()}},{key:"PostContactShortcut",value:function(t){this.sub=this.contactshortcutService.PostContactShortcut(t).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.contactshortcut){var c=this.fb.group({ContactShortcutID:[{value:t===i.a.Post?0:this.contactshortcut.ContactShortcutID,disabled:!1},[v.p.required]],ContactID:[{value:this.contactshortcut.ContactID,disabled:!1},[v.p.required]],ShortCutText:[{value:this.contactshortcut.ShortCutText,disabled:!1},[v.p.required,v.p.maxLength(100)]],ShortCutAddress:[{value:this.contactshortcut.ShortCutAddress,disabled:!1},[v.p.required,v.p.maxLength(200)]],LastUpdateDate_UTC:[{value:this.contactshortcut.LastUpdateDate_UTC,disabled:!1},[v.p.required]],LastUpdateContactTVItemID:[{value:this.contactshortcut.LastUpdateContactTVItemID,disabled:!1},[v.p.required]]});this.contactshortcutFormEdit=c}}}]),t}()).\u0275fac=function(t){return new(t||V)(u.Nb(d),u.Nb(v.d))},V.\u0275cmp=u.Hb({type:V,selectors:[["app-contactshortcut-edit"]],inputs:{contactshortcut:"contactshortcut",httpClientCommand:"httpClientCommand"},decls:40,vars:10,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","ContactShortcutID"],[4,"ngIf"],["matInput","","type","number","formControlName","ContactID"],["matInput","","type","text","formControlName","ShortCutText"],["matInput","","type","text","formControlName","ShortCutAddress"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,c){1&t&&(u.Tb(0,"form",0),u.ac("ngSubmit",(function(){return c.GetPut()?c.PutContactShortcut(c.contactshortcutFormEdit.value):c.PostContactShortcut(c.contactshortcutFormEdit.value)})),u.Tb(1,"h3"),u.yc(2," ContactShortcut "),u.Tb(3,"button",1),u.Tb(4,"span"),u.yc(5),u.Sb(),u.Sb(),u.xc(6,I,1,0,"mat-progress-bar",2),u.xc(7,D,1,0,"mat-progress-bar",2),u.Sb(),u.Tb(8,"p"),u.Tb(9,"mat-form-field"),u.Tb(10,"mat-label"),u.yc(11,"ContactShortcutID"),u.Sb(),u.Ob(12,"input",3),u.xc(13,P,6,4,"mat-error",4),u.Sb(),u.Tb(14,"mat-form-field"),u.Tb(15,"mat-label"),u.yc(16,"ContactID"),u.Sb(),u.Ob(17,"input",5),u.xc(18,B,6,4,"mat-error",4),u.Sb(),u.Tb(19,"mat-form-field"),u.Tb(20,"mat-label"),u.yc(21,"ShortCutText"),u.Sb(),u.Ob(22,"input",6),u.xc(23,O,7,5,"mat-error",4),u.Sb(),u.Tb(24,"mat-form-field"),u.Tb(25,"mat-label"),u.yc(26,"ShortCutAddress"),u.Sb(),u.Ob(27,"input",7),u.xc(28,M,7,5,"mat-error",4),u.Sb(),u.Sb(),u.Tb(29,"p"),u.Tb(30,"mat-form-field"),u.Tb(31,"mat-label"),u.yc(32,"LastUpdateDate_UTC"),u.Sb(),u.Ob(33,"input",8),u.xc(34,E,6,4,"mat-error",4),u.Sb(),u.Tb(35,"mat-form-field"),u.Tb(36,"mat-label"),u.yc(37,"LastUpdateContactTVItemID"),u.Sb(),u.Ob(38,"input",9),u.xc(39,q,6,4,"mat-error",4),u.Sb(),u.Sb(),u.Sb()),2&t&&(u.jc("formGroup",c.contactshortcutFormEdit),u.Bb(5),u.Ac("",c.GetPut()?"Put":"Post"," ContactShortcut"),u.Bb(1),u.jc("ngIf",c.contactshortcutService.contactshortcutPutModel$.getValue().Working),u.Bb(1),u.jc("ngIf",c.contactshortcutService.contactshortcutPostModel$.getValue().Working),u.Bb(6),u.jc("ngIf",c.contactshortcutFormEdit.controls.ContactShortcutID.errors),u.Bb(5),u.jc("ngIf",c.contactshortcutFormEdit.controls.ContactID.errors),u.Bb(5),u.jc("ngIf",c.contactshortcutFormEdit.controls.ShortCutText.errors),u.Bb(5),u.jc("ngIf",c.contactshortcutFormEdit.controls.ShortCutAddress.errors),u.Bb(6),u.jc("ngIf",c.contactshortcutFormEdit.controls.LastUpdateDate_UTC.errors),u.Bb(5),u.jc("ngIf",c.contactshortcutFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[v.q,v.l,v.f,m.b,o.l,y.c,y.f,g.b,v.n,v.c,v.k,v.e,C.a,y.b],pipes:[o.f],styles:[""],changeDetection:0}),V);function F(t,c){1&t&&u.Ob(0,"mat-progress-bar",4)}function A(t,c){1&t&&u.Ob(0,"mat-progress-bar",4)}function R(t,c){if(1&t&&(u.Tb(0,"p"),u.Ob(1,"app-contactshortcut-edit",8),u.Sb()),2&t){var e=u.ec().$implicit,o=u.ec(2);u.Bb(1),u.jc("contactshortcut",e)("httpClientCommand",o.GetPutEnum())}}function N(t,c){if(1&t&&(u.Tb(0,"p"),u.Ob(1,"app-contactshortcut-edit",8),u.Sb()),2&t){var e=u.ec().$implicit,o=u.ec(2);u.Bb(1),u.jc("contactshortcut",e)("httpClientCommand",o.GetPostEnum())}}function W(t,c){if(1&t){var e=u.Ub();u.Tb(0,"div"),u.Tb(1,"p"),u.Tb(2,"button",6),u.ac("click",(function(){u.rc(e);var t=c.$implicit;return u.ec(2).DeleteContactShortcut(t)})),u.Tb(3,"span"),u.yc(4),u.Sb(),u.Tb(5,"mat-icon"),u.yc(6,"delete"),u.Sb(),u.Sb(),u.yc(7,"\xa0\xa0\xa0 "),u.Tb(8,"button",7),u.ac("click",(function(){u.rc(e);var t=c.$implicit;return u.ec(2).ShowPut(t)})),u.Tb(9,"span"),u.yc(10,"Show Put"),u.Sb(),u.Sb(),u.yc(11,"\xa0\xa0 "),u.Tb(12,"button",7),u.ac("click",(function(){u.rc(e);var t=c.$implicit;return u.ec(2).ShowPost(t)})),u.Tb(13,"span"),u.yc(14,"Show Post"),u.Sb(),u.Sb(),u.yc(15,"\xa0\xa0 "),u.xc(16,A,1,0,"mat-progress-bar",0),u.Sb(),u.xc(17,R,2,2,"p",2),u.xc(18,N,2,2,"p",2),u.Tb(19,"blockquote"),u.Tb(20,"p"),u.Tb(21,"span"),u.yc(22),u.Sb(),u.Tb(23,"span"),u.yc(24),u.Sb(),u.Tb(25,"span"),u.yc(26),u.Sb(),u.Tb(27,"span"),u.yc(28),u.Sb(),u.Sb(),u.Tb(29,"p"),u.Tb(30,"span"),u.yc(31),u.Sb(),u.Tb(32,"span"),u.yc(33),u.Sb(),u.Sb(),u.Sb(),u.Sb()}if(2&t){var o=c.$implicit,n=u.ec(2);u.Bb(4),u.Ac("Delete ContactShortcutID [",o.ContactShortcutID,"]\xa0\xa0\xa0"),u.Bb(4),u.jc("color",n.GetPutButtonColor(o)),u.Bb(4),u.jc("color",n.GetPostButtonColor(o)),u.Bb(4),u.jc("ngIf",n.contactshortcutService.contactshortcutDeleteModel$.getValue().Working),u.Bb(1),u.jc("ngIf",n.IDToShow===o.ContactShortcutID&&n.showType===n.GetPutEnum()),u.Bb(1),u.jc("ngIf",n.IDToShow===o.ContactShortcutID&&n.showType===n.GetPostEnum()),u.Bb(4),u.Ac("ContactShortcutID: [",o.ContactShortcutID,"]"),u.Bb(2),u.Ac(" --- ContactID: [",o.ContactID,"]"),u.Bb(2),u.Ac(" --- ShortCutText: [",o.ShortCutText,"]"),u.Bb(2),u.Ac(" --- ShortCutAddress: [",o.ShortCutAddress,"]"),u.Bb(3),u.Ac("LastUpdateDate_UTC: [",o.LastUpdateDate_UTC,"]"),u.Bb(2),u.Ac(" --- LastUpdateContactTVItemID: [",o.LastUpdateContactTVItemID,"]")}}function z(t,c){if(1&t&&(u.Tb(0,"div"),u.xc(1,W,34,12,"div",5),u.Sb()),2&t){var e=u.ec();u.Bb(1),u.jc("ngForOf",e.contactshortcutService.contactshortcutListModel$.getValue())}}var H,X,J,K=[{path:"",component:(H=function(){function t(c,e,o){_classCallCheck(this,t),this.contactshortcutService=c,this.router=e,this.httpClientService=o,this.showType=null,o.oldURL=e.url}return _createClass(t,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.ContactShortcutID&&this.showType===i.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.ContactShortcutID&&this.showType===i.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.ContactShortcutID&&this.showType===i.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactShortcutID,this.showType=i.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.ContactShortcutID&&this.showType===i.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactShortcutID,this.showType=i.a.Post)}},{key:"GetPutEnum",value:function(){return i.a.Put}},{key:"GetPostEnum",value:function(){return i.a.Post}},{key:"GetContactShortcutList",value:function(){this.sub=this.contactshortcutService.GetContactShortcutList().subscribe()}},{key:"DeleteContactShortcut",value:function(t){this.sub=this.contactshortcutService.DeleteContactShortcut(t).subscribe()}},{key:"ngOnInit",value:function(){r(this.contactshortcutService.contactshortcutTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),t}(),H.\u0275fac=function(t){return new(t||H)(u.Nb(d),u.Nb(n.b),u.Nb(f.a))},H.\u0275cmp=u.Hb({type:H,selectors:[["app-contactshortcut"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"contactshortcut","httpClientCommand"]],template:function(t,c){if(1&t&&(u.xc(0,F,1,0,"mat-progress-bar",0),u.Tb(1,"mat-card"),u.Tb(2,"mat-card-header"),u.Tb(3,"mat-card-title"),u.yc(4," ContactShortcut works! "),u.Tb(5,"button",1),u.ac("click",(function(){return c.GetContactShortcutList()})),u.Tb(6,"span"),u.yc(7,"Get ContactShortcut"),u.Sb(),u.Sb(),u.Sb(),u.Tb(8,"mat-card-subtitle"),u.yc(9),u.Sb(),u.Sb(),u.Tb(10,"mat-card-content"),u.xc(11,z,2,1,"div",2),u.Sb(),u.Tb(12,"mat-card-actions"),u.Tb(13,"button",3),u.yc(14,"Allo"),u.Sb(),u.Sb(),u.Sb()),2&t){var e,o,n=null==(e=c.contactshortcutService.contactshortcutGetModel$.getValue())?null:e.Working,r=null==(o=c.contactshortcutService.contactshortcutListModel$.getValue())?null:o.length;u.jc("ngIf",n),u.Bb(9),u.zc(c.contactshortcutService.contactshortcutTextModel$.getValue().Title),u.Bb(2),u.jc("ngIf",r)}},directives:[o.l,S.a,S.d,S.g,m.b,S.f,S.c,S.b,C.a,o.k,T.a,_],styles:[""],changeDetection:0}),H),canActivate:[e("auXs").a]}],Q=((X=function t(){_classCallCheck(this,t)}).\u0275mod=u.Lb({type:X}),X.\u0275inj=u.Kb({factory:function(t){return new(t||X)},imports:[[n.e.forChild(K)],n.e]}),X),Y=e("B+Mi"),Z=((J=function t(){_classCallCheck(this,t)}).\u0275mod=u.Lb({type:J}),J.\u0275inj=u.Kb({factory:function(t){return new(t||J)},imports:[[o.c,n.e,Q,Y.a,v.g,v.o]]}),J)},QRvi:function(t,c,e){"use strict";e.d(c,"a",(function(){return o}));var o=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,c,e){"use strict";e.d(c,"a",(function(){return a}));var o=e("QRvi"),n=e("fXoL"),r=e("tyNb"),a=function(){var t=function(){function t(c){_classCallCheck(this,t),this.router=c,this.oldURL=c.url}return _createClass(t,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,c,e){t.next(null),c.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,c,e){t.next(null),c.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,c,e,n,r){if(n===o.a.Get&&t.next(e),n===o.a.Put&&(t.getValue()[0]=e),n===o.a.Post&&t.getValue().push(e),n===o.a.Delete){var a=t.getValue().indexOf(r);t.getValue().splice(a,1)}t.next(t.getValue()),c.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,c,e,n,r){n===o.a.Get&&t.next(e),t.next(t.getValue()),c.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),t}();return t.\u0275fac=function(c){return new(c||t)(n.Xb(r.b))},t.\u0275prov=n.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t}()}}]);