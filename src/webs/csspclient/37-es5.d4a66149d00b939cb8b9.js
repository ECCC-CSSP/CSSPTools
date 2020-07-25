function _classCallCheck(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function _defineProperties(e,t){for(var r=0;r<t.length;r++){var o=t[r];o.enumerable=o.enumerable||!1,o.configurable=!0,"value"in o&&(o.writable=!0),Object.defineProperty(e,o.key,o)}}function _createClass(e,t,r){return t&&_defineProperties(e.prototype,t),r&&_defineProperties(e,r),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[37],{QRvi:function(e,t,r){"use strict";r.d(t,"a",(function(){return o}));var o=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,r){"use strict";r.d(t,"a",(function(){return i}));var o=r("QRvi"),n=r("fXoL"),a=r("tyNb"),i=function(){var e=function(){function e(t){_classCallCheck(this,e),this.router=t,this.oldURL=t.url}return _createClass(e,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,t,r){e.next(null),t.next({Working:!1,Error:r,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(e,t,r){e.next(null),t.next({Working:!1,Error:r,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,t,r,n,a){if(n===o.a.Get&&e.next(r),n===o.a.Put&&(e.getValue()[0]=r),n===o.a.Post&&e.getValue().push(r),n===o.a.Delete){var i=e.getValue().indexOf(a);e.getValue().splice(i,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(e,t,r,n,a){n===o.a.Get&&e.next(r),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(n.Xb(a.b))},e.\u0275prov=n.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()},t8mL:function(e,t,r){"use strict";r.r(t),r.d(t,"AppErrLogModule",(function(){return oe}));var o=r("ofXK"),n=r("tyNb");function a(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var i,p=r("QRvi"),c=r("fXoL"),l=r("2Vo4"),s=r("LRne"),b=r("tk/3"),u=r("lJxs"),g=r("JIr8"),f=r("gkM4"),m=((i=function(){function e(t,r){_classCallCheck(this,e),this.httpClient=t,this.httpClientService=r,this.apperrlogTextModel$=new l.a({}),this.apperrlogListModel$=new l.a({}),this.apperrlogGetModel$=new l.a({}),this.apperrlogPutModel$=new l.a({}),this.apperrlogPostModel$=new l.a({}),this.apperrlogDeleteModel$=new l.a({}),a(this.apperrlogTextModel$),this.apperrlogTextModel$.next({Title:"Something2 for text"})}return _createClass(e,[{key:"GetAppErrLogList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.apperrlogGetModel$),this.httpClient.get("/api/AppErrLog").pipe(Object(u.a)((function(t){e.httpClientService.DoSuccess(e.apperrlogListModel$,e.apperrlogGetModel$,t,p.a.Get,null)})),Object(g.a)((function(t){return Object(s.a)(t).pipe(Object(u.a)((function(t){e.httpClientService.DoCatchError(e.apperrlogListModel$,e.apperrlogGetModel$,t)})))})))}},{key:"PutAppErrLog",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.apperrlogPutModel$),this.httpClient.put("/api/AppErrLog",e,{headers:new b.d}).pipe(Object(u.a)((function(r){t.httpClientService.DoSuccess(t.apperrlogListModel$,t.apperrlogPutModel$,r,p.a.Put,e)})),Object(g.a)((function(e){return Object(s.a)(e).pipe(Object(u.a)((function(e){t.httpClientService.DoCatchError(t.apperrlogListModel$,t.apperrlogPutModel$,e)})))})))}},{key:"PostAppErrLog",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.apperrlogPostModel$),this.httpClient.post("/api/AppErrLog",e,{headers:new b.d}).pipe(Object(u.a)((function(r){t.httpClientService.DoSuccess(t.apperrlogListModel$,t.apperrlogPostModel$,r,p.a.Post,e)})),Object(g.a)((function(e){return Object(s.a)(e).pipe(Object(u.a)((function(e){t.httpClientService.DoCatchError(t.apperrlogListModel$,t.apperrlogPostModel$,e)})))})))}},{key:"DeleteAppErrLog",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.apperrlogDeleteModel$),this.httpClient.delete("/api/AppErrLog/"+e.AppErrLogID).pipe(Object(u.a)((function(r){t.httpClientService.DoSuccess(t.apperrlogListModel$,t.apperrlogDeleteModel$,r,p.a.Delete,e)})),Object(g.a)((function(e){return Object(s.a)(e).pipe(Object(u.a)((function(e){t.httpClientService.DoCatchError(t.apperrlogListModel$,t.apperrlogDeleteModel$,e)})))})))}}]),e}()).\u0275fac=function(e){return new(e||i)(c.Xb(b.b),c.Xb(f.a))},i.\u0275prov=c.Jb({token:i,factory:i.\u0275fac,providedIn:"root"}),i),d=r("Wp6s"),h=r("bTqV"),T=r("bv9b"),S=r("NFeN"),v=r("3Pt+"),y=r("kmnG"),C=r("qFsG");function I(e,t){1&e&&c.Ob(0,"mat-progress-bar",12)}function L(e,t){1&e&&c.Ob(0,"mat-progress-bar",12)}function D(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function E(e,t){if(1&e&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,D,3,0,"span",4),c.Sb()),2&e){var r=t.$implicit;c.Bb(2),c.zc(c.gc(3,2,r)),c.Bb(3),c.jc("ngIf",r.required)}}function k(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function P(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"MaxLength - 100"),c.Ob(2,"br"),c.Sb())}function B(e,t){if(1&e&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,k,3,0,"span",4),c.xc(6,P,3,0,"span",4),c.Sb()),2&e){var r=t.$implicit;c.Bb(2),c.zc(c.gc(3,3,r)),c.Bb(3),c.jc("ngIf",r.required),c.Bb(1),c.jc("ngIf",r.maxlength)}}function j(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function A(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"Min - 1"),c.Ob(2,"br"),c.Sb())}function O(e,t){if(1&e&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,j,3,0,"span",4),c.xc(6,A,3,0,"span",4),c.Sb()),2&e){var r=t.$implicit;c.Bb(2),c.zc(c.gc(3,3,r)),c.Bb(3),c.jc("ngIf",r.required),c.Bb(1),c.jc("ngIf",r.min)}}function x(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function w(e,t){if(1&e&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,x,3,0,"span",4),c.Sb()),2&e){var r=t.$implicit;c.Bb(2),c.zc(c.gc(3,2,r)),c.Bb(3),c.jc("ngIf",r.required)}}function $(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function M(e,t){if(1&e&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,$,3,0,"span",4),c.Sb()),2&e){var r=t.$implicit;c.Bb(2),c.zc(c.gc(3,2,r)),c.Bb(3),c.jc("ngIf",r.required)}}function G(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function U(e,t){if(1&e&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,G,3,0,"span",4),c.Sb()),2&e){var r=t.$implicit;c.Bb(2),c.zc(c.gc(3,2,r)),c.Bb(3),c.jc("ngIf",r.required)}}function _(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function q(e,t){if(1&e&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,_,3,0,"span",4),c.Sb()),2&e){var r=t.$implicit;c.Bb(2),c.zc(c.gc(3,2,r)),c.Bb(3),c.jc("ngIf",r.required)}}function N(e,t){1&e&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function V(e,t){if(1&e&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,N,3,0,"span",4),c.Sb()),2&e){var r=t.$implicit;c.Bb(2),c.zc(c.gc(3,2,r)),c.Bb(3),c.jc("ngIf",r.required)}}var F,R=((F=function(){function e(t,r){_classCallCheck(this,e),this.apperrlogService=t,this.fb=r,this.apperrlog=null,this.httpClientCommand=p.a.Put}return _createClass(e,[{key:"GetPut",value:function(){return this.httpClientCommand==p.a.Put}},{key:"PutAppErrLog",value:function(e){this.sub=this.apperrlogService.PutAppErrLog(e).subscribe()}},{key:"PostAppErrLog",value:function(e){this.sub=this.apperrlogService.PostAppErrLog(e).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.apperrlog){var t=this.fb.group({AppErrLogID:[{value:e===p.a.Post?0:this.apperrlog.AppErrLogID,disabled:!1},[v.p.required]],Tag:[{value:this.apperrlog.Tag,disabled:!1},[v.p.required,v.p.maxLength(100)]],LineNumber:[{value:this.apperrlog.LineNumber,disabled:!1},[v.p.required,v.p.min(1)]],Source:[{value:this.apperrlog.Source,disabled:!1},[v.p.required]],Message:[{value:this.apperrlog.Message,disabled:!1},[v.p.required]],DateTime_UTC:[{value:this.apperrlog.DateTime_UTC,disabled:!1},[v.p.required]],LastUpdateDate_UTC:[{value:this.apperrlog.LastUpdateDate_UTC,disabled:!1},[v.p.required]],LastUpdateContactTVItemID:[{value:this.apperrlog.LastUpdateContactTVItemID,disabled:!1},[v.p.required]]});this.apperrlogFormEdit=t}}}]),e}()).\u0275fac=function(e){return new(e||F)(c.Nb(m),c.Nb(v.d))},F.\u0275cmp=c.Hb({type:F,selectors:[["app-apperrlog-edit"]],inputs:{apperrlog:"apperrlog",httpClientCommand:"httpClientCommand"},decls:50,vars:12,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","AppErrLogID"],[4,"ngIf"],["matInput","","type","text","formControlName","Tag"],["matInput","","type","number","formControlName","LineNumber"],["matInput","","type","text","formControlName","Source"],["matInput","","type","text","formControlName","Message"],["matInput","","type","text","formControlName","DateTime_UTC"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(e,t){1&e&&(c.Tb(0,"form",0),c.ac("ngSubmit",(function(){return t.GetPut()?t.PutAppErrLog(t.apperrlogFormEdit.value):t.PostAppErrLog(t.apperrlogFormEdit.value)})),c.Tb(1,"h3"),c.yc(2," AppErrLog "),c.Tb(3,"button",1),c.Tb(4,"span"),c.yc(5),c.Sb(),c.Sb(),c.xc(6,I,1,0,"mat-progress-bar",2),c.xc(7,L,1,0,"mat-progress-bar",2),c.Sb(),c.Tb(8,"p"),c.Tb(9,"mat-form-field"),c.Tb(10,"mat-label"),c.yc(11,"AppErrLogID"),c.Sb(),c.Ob(12,"input",3),c.xc(13,E,6,4,"mat-error",4),c.Sb(),c.Tb(14,"mat-form-field"),c.Tb(15,"mat-label"),c.yc(16,"Tag"),c.Sb(),c.Ob(17,"input",5),c.xc(18,B,7,5,"mat-error",4),c.Sb(),c.Tb(19,"mat-form-field"),c.Tb(20,"mat-label"),c.yc(21,"LineNumber"),c.Sb(),c.Ob(22,"input",6),c.xc(23,O,7,5,"mat-error",4),c.Sb(),c.Tb(24,"mat-form-field"),c.Tb(25,"mat-label"),c.yc(26,"Source"),c.Sb(),c.Ob(27,"input",7),c.xc(28,w,6,4,"mat-error",4),c.Sb(),c.Sb(),c.Tb(29,"p"),c.Tb(30,"mat-form-field"),c.Tb(31,"mat-label"),c.yc(32,"Message"),c.Sb(),c.Ob(33,"input",8),c.xc(34,M,6,4,"mat-error",4),c.Sb(),c.Tb(35,"mat-form-field"),c.Tb(36,"mat-label"),c.yc(37,"DateTime_UTC"),c.Sb(),c.Ob(38,"input",9),c.xc(39,U,6,4,"mat-error",4),c.Sb(),c.Tb(40,"mat-form-field"),c.Tb(41,"mat-label"),c.yc(42,"LastUpdateDate_UTC"),c.Sb(),c.Ob(43,"input",10),c.xc(44,q,6,4,"mat-error",4),c.Sb(),c.Tb(45,"mat-form-field"),c.Tb(46,"mat-label"),c.yc(47,"LastUpdateContactTVItemID"),c.Sb(),c.Ob(48,"input",11),c.xc(49,V,6,4,"mat-error",4),c.Sb(),c.Sb(),c.Sb()),2&e&&(c.jc("formGroup",t.apperrlogFormEdit),c.Bb(5),c.Ac("",t.GetPut()?"Put":"Post"," AppErrLog"),c.Bb(1),c.jc("ngIf",t.apperrlogService.apperrlogPutModel$.getValue().Working),c.Bb(1),c.jc("ngIf",t.apperrlogService.apperrlogPostModel$.getValue().Working),c.Bb(6),c.jc("ngIf",t.apperrlogFormEdit.controls.AppErrLogID.errors),c.Bb(5),c.jc("ngIf",t.apperrlogFormEdit.controls.Tag.errors),c.Bb(5),c.jc("ngIf",t.apperrlogFormEdit.controls.LineNumber.errors),c.Bb(5),c.jc("ngIf",t.apperrlogFormEdit.controls.Source.errors),c.Bb(6),c.jc("ngIf",t.apperrlogFormEdit.controls.Message.errors),c.Bb(5),c.jc("ngIf",t.apperrlogFormEdit.controls.DateTime_UTC.errors),c.Bb(5),c.jc("ngIf",t.apperrlogFormEdit.controls.LastUpdateDate_UTC.errors),c.Bb(5),c.jc("ngIf",t.apperrlogFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[v.q,v.l,v.f,h.b,o.l,y.c,y.f,C.b,v.n,v.c,v.k,v.e,T.a,y.b],pipes:[o.f],styles:[""],changeDetection:0}),F);function z(e,t){1&e&&c.Ob(0,"mat-progress-bar",4)}function W(e,t){1&e&&c.Ob(0,"mat-progress-bar",4)}function H(e,t){if(1&e&&(c.Tb(0,"p"),c.Ob(1,"app-apperrlog-edit",8),c.Sb()),2&e){var r=c.ec().$implicit,o=c.ec(2);c.Bb(1),c.jc("apperrlog",r)("httpClientCommand",o.GetPutEnum())}}function X(e,t){if(1&e&&(c.Tb(0,"p"),c.Ob(1,"app-apperrlog-edit",8),c.Sb()),2&e){var r=c.ec().$implicit,o=c.ec(2);c.Bb(1),c.jc("apperrlog",r)("httpClientCommand",o.GetPostEnum())}}function J(e,t){if(1&e){var r=c.Ub();c.Tb(0,"div"),c.Tb(1,"p"),c.Tb(2,"button",6),c.ac("click",(function(){c.rc(r);var e=t.$implicit;return c.ec(2).DeleteAppErrLog(e)})),c.Tb(3,"span"),c.yc(4),c.Sb(),c.Tb(5,"mat-icon"),c.yc(6,"delete"),c.Sb(),c.Sb(),c.yc(7,"\xa0\xa0\xa0 "),c.Tb(8,"button",7),c.ac("click",(function(){c.rc(r);var e=t.$implicit;return c.ec(2).ShowPut(e)})),c.Tb(9,"span"),c.yc(10,"Show Put"),c.Sb(),c.Sb(),c.yc(11,"\xa0\xa0 "),c.Tb(12,"button",7),c.ac("click",(function(){c.rc(r);var e=t.$implicit;return c.ec(2).ShowPost(e)})),c.Tb(13,"span"),c.yc(14,"Show Post"),c.Sb(),c.Sb(),c.yc(15,"\xa0\xa0 "),c.xc(16,W,1,0,"mat-progress-bar",0),c.Sb(),c.xc(17,H,2,2,"p",2),c.xc(18,X,2,2,"p",2),c.Tb(19,"blockquote"),c.Tb(20,"p"),c.Tb(21,"span"),c.yc(22),c.Sb(),c.Tb(23,"span"),c.yc(24),c.Sb(),c.Tb(25,"span"),c.yc(26),c.Sb(),c.Tb(27,"span"),c.yc(28),c.Sb(),c.Sb(),c.Tb(29,"p"),c.Tb(30,"span"),c.yc(31),c.Sb(),c.Tb(32,"span"),c.yc(33),c.Sb(),c.Tb(34,"span"),c.yc(35),c.Sb(),c.Tb(36,"span"),c.yc(37),c.Sb(),c.Sb(),c.Sb(),c.Sb()}if(2&e){var o=t.$implicit,n=c.ec(2);c.Bb(4),c.Ac("Delete AppErrLogID [",o.AppErrLogID,"]\xa0\xa0\xa0"),c.Bb(4),c.jc("color",n.GetPutButtonColor(o)),c.Bb(4),c.jc("color",n.GetPostButtonColor(o)),c.Bb(4),c.jc("ngIf",n.apperrlogService.apperrlogDeleteModel$.getValue().Working),c.Bb(1),c.jc("ngIf",n.IDToShow===o.AppErrLogID&&n.showType===n.GetPutEnum()),c.Bb(1),c.jc("ngIf",n.IDToShow===o.AppErrLogID&&n.showType===n.GetPostEnum()),c.Bb(4),c.Ac("AppErrLogID: [",o.AppErrLogID,"]"),c.Bb(2),c.Ac(" --- Tag: [",o.Tag,"]"),c.Bb(2),c.Ac(" --- LineNumber: [",o.LineNumber,"]"),c.Bb(2),c.Ac(" --- Source: [",o.Source,"]"),c.Bb(3),c.Ac("Message: [",o.Message,"]"),c.Bb(2),c.Ac(" --- DateTime_UTC: [",o.DateTime_UTC,"]"),c.Bb(2),c.Ac(" --- LastUpdateDate_UTC: [",o.LastUpdateDate_UTC,"]"),c.Bb(2),c.Ac(" --- LastUpdateContactTVItemID: [",o.LastUpdateContactTVItemID,"]")}}function K(e,t){if(1&e&&(c.Tb(0,"div"),c.xc(1,J,38,14,"div",5),c.Sb()),2&e){var r=c.ec();c.Bb(1),c.jc("ngForOf",r.apperrlogService.apperrlogListModel$.getValue())}}var Q,Y,Z,ee=[{path:"",component:(Q=function(){function e(t,r,o){_classCallCheck(this,e),this.apperrlogService=t,this.router=r,this.httpClientService=o,this.showType=null,o.oldURL=r.url}return _createClass(e,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.AppErrLogID&&this.showType===p.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.AppErrLogID&&this.showType===p.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.AppErrLogID&&this.showType===p.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.AppErrLogID,this.showType=p.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.AppErrLogID&&this.showType===p.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.AppErrLogID,this.showType=p.a.Post)}},{key:"GetPutEnum",value:function(){return p.a.Put}},{key:"GetPostEnum",value:function(){return p.a.Post}},{key:"GetAppErrLogList",value:function(){this.sub=this.apperrlogService.GetAppErrLogList().subscribe()}},{key:"DeleteAppErrLog",value:function(e){this.sub=this.apperrlogService.DeleteAppErrLog(e).subscribe()}},{key:"ngOnInit",value:function(){a(this.apperrlogService.apperrlogTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),e}(),Q.\u0275fac=function(e){return new(e||Q)(c.Nb(m),c.Nb(n.b),c.Nb(f.a))},Q.\u0275cmp=c.Hb({type:Q,selectors:[["app-apperrlog"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"apperrlog","httpClientCommand"]],template:function(e,t){if(1&e&&(c.xc(0,z,1,0,"mat-progress-bar",0),c.Tb(1,"mat-card"),c.Tb(2,"mat-card-header"),c.Tb(3,"mat-card-title"),c.yc(4," AppErrLog works! "),c.Tb(5,"button",1),c.ac("click",(function(){return t.GetAppErrLogList()})),c.Tb(6,"span"),c.yc(7,"Get AppErrLog"),c.Sb(),c.Sb(),c.Sb(),c.Tb(8,"mat-card-subtitle"),c.yc(9),c.Sb(),c.Sb(),c.Tb(10,"mat-card-content"),c.xc(11,K,2,1,"div",2),c.Sb(),c.Tb(12,"mat-card-actions"),c.Tb(13,"button",3),c.yc(14,"Allo"),c.Sb(),c.Sb(),c.Sb()),2&e){var r,o,n=null==(r=t.apperrlogService.apperrlogGetModel$.getValue())?null:r.Working,a=null==(o=t.apperrlogService.apperrlogListModel$.getValue())?null:o.length;c.jc("ngIf",n),c.Bb(9),c.zc(t.apperrlogService.apperrlogTextModel$.getValue().Title),c.Bb(2),c.jc("ngIf",a)}},directives:[o.l,d.a,d.d,d.g,h.b,d.f,d.c,d.b,T.a,o.k,S.a,R],styles:[""],changeDetection:0}),Q),canActivate:[r("auXs").a]}],te=((Y=function e(){_classCallCheck(this,e)}).\u0275mod=c.Lb({type:Y}),Y.\u0275inj=c.Kb({factory:function(e){return new(e||Y)},imports:[[n.e.forChild(ee)],n.e]}),Y),re=r("B+Mi"),oe=((Z=function e(){_classCallCheck(this,e)}).\u0275mod=c.Lb({type:Z}),Z.\u0275inj=c.Kb({factory:function(e){return new(e||Z)},imports:[[o.c,n.e,te,re.a,v.g,v.o]]}),Z)}}]);