function _classCallCheck(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function _defineProperties(e,t){for(var a=0;a<t.length;a++){var r=t[a];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}function _createClass(e,t,a){return t&&_defineProperties(e.prototype,t),a&&_defineProperties(e,a),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[78],{NoDl:function(e,t,a){"use strict";a.r(t),a.d(t,"RatingCurveValueModule",(function(){return te}));var r=a("ofXK"),n=a("tyNb");function i(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var u,c=a("QRvi"),o=a("fXoL"),l=a("2Vo4"),s=a("LRne"),b=a("tk/3"),v=a("lJxs"),g=a("JIr8"),p=a("gkM4"),f=((u=function(){function e(t,a){_classCallCheck(this,e),this.httpClient=t,this.httpClientService=a,this.ratingcurvevalueTextModel$=new l.a({}),this.ratingcurvevalueListModel$=new l.a({}),this.ratingcurvevalueGetModel$=new l.a({}),this.ratingcurvevaluePutModel$=new l.a({}),this.ratingcurvevaluePostModel$=new l.a({}),this.ratingcurvevalueDeleteModel$=new l.a({}),i(this.ratingcurvevalueTextModel$),this.ratingcurvevalueTextModel$.next({Title:"Something2 for text"})}return _createClass(e,[{key:"GetRatingCurveValueList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.ratingcurvevalueGetModel$),this.httpClient.get("/api/RatingCurveValue").pipe(Object(v.a)((function(t){e.httpClientService.DoSuccess(e.ratingcurvevalueListModel$,e.ratingcurvevalueGetModel$,t,c.a.Get,null)})),Object(g.a)((function(t){return Object(s.a)(t).pipe(Object(v.a)((function(t){e.httpClientService.DoCatchError(e.ratingcurvevalueListModel$,e.ratingcurvevalueGetModel$,t)})))})))}},{key:"PutRatingCurveValue",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.ratingcurvevaluePutModel$),this.httpClient.put("/api/RatingCurveValue",e,{headers:new b.d}).pipe(Object(v.a)((function(a){t.httpClientService.DoSuccess(t.ratingcurvevalueListModel$,t.ratingcurvevaluePutModel$,a,c.a.Put,e)})),Object(g.a)((function(e){return Object(s.a)(e).pipe(Object(v.a)((function(e){t.httpClientService.DoCatchError(t.ratingcurvevalueListModel$,t.ratingcurvevaluePutModel$,e)})))})))}},{key:"PostRatingCurveValue",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.ratingcurvevaluePostModel$),this.httpClient.post("/api/RatingCurveValue",e,{headers:new b.d}).pipe(Object(v.a)((function(a){t.httpClientService.DoSuccess(t.ratingcurvevalueListModel$,t.ratingcurvevaluePostModel$,a,c.a.Post,e)})),Object(g.a)((function(e){return Object(s.a)(e).pipe(Object(v.a)((function(e){t.httpClientService.DoCatchError(t.ratingcurvevalueListModel$,t.ratingcurvevaluePostModel$,e)})))})))}},{key:"DeleteRatingCurveValue",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.ratingcurvevalueDeleteModel$),this.httpClient.delete("/api/RatingCurveValue/"+e.RatingCurveValueID).pipe(Object(v.a)((function(a){t.httpClientService.DoSuccess(t.ratingcurvevalueListModel$,t.ratingcurvevalueDeleteModel$,a,c.a.Delete,e)})),Object(g.a)((function(e){return Object(s.a)(e).pipe(Object(v.a)((function(e){t.httpClientService.DoCatchError(t.ratingcurvevalueListModel$,t.ratingcurvevalueDeleteModel$,e)})))})))}}]),e}()).\u0275fac=function(e){return new(e||u)(o.Xb(b.b),o.Xb(p.a))},u.\u0275prov=o.Jb({token:u,factory:u.\u0275fac,providedIn:"root"}),u),m=a("Wp6s"),h=a("bTqV"),d=a("bv9b"),C=a("NFeN"),S=a("3Pt+"),T=a("kmnG"),y=a("qFsG");function I(e,t){1&e&&o.Ob(0,"mat-progress-bar",10)}function D(e,t){1&e&&o.Ob(0,"mat-progress-bar",10)}function V(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function R(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,V,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}function P(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function k(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,P,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}function B(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function j(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 0"),o.Ob(2,"br"),o.Sb())}function O(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 1000"),o.Ob(2,"br"),o.Sb())}function w(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,B,3,0,"span",4),o.xc(6,j,3,0,"span",4),o.xc(7,O,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,4,a)),o.Bb(3),o.jc("ngIf",a.required),o.Bb(1),o.jc("ngIf",a.min),o.Bb(1),o.jc("ngIf",a.min)}}function $(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function x(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 0"),o.Ob(2,"br"),o.Sb())}function M(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 1000000"),o.Ob(2,"br"),o.Sb())}function _(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,$,3,0,"span",4),o.xc(6,x,3,0,"span",4),o.xc(7,M,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,4,a)),o.Bb(3),o.jc("ngIf",a.required),o.Bb(1),o.jc("ngIf",a.min),o.Bb(1),o.jc("ngIf",a.min)}}function L(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function G(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,L,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}function E(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function U(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,E,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}var q,F=((q=function(){function e(t,a){_classCallCheck(this,e),this.ratingcurvevalueService=t,this.fb=a,this.ratingcurvevalue=null,this.httpClientCommand=c.a.Put}return _createClass(e,[{key:"GetPut",value:function(){return this.httpClientCommand==c.a.Put}},{key:"PutRatingCurveValue",value:function(e){this.sub=this.ratingcurvevalueService.PutRatingCurveValue(e).subscribe()}},{key:"PostRatingCurveValue",value:function(e){this.sub=this.ratingcurvevalueService.PostRatingCurveValue(e).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.ratingcurvevalue){var t=this.fb.group({RatingCurveValueID:[{value:e===c.a.Post?0:this.ratingcurvevalue.RatingCurveValueID,disabled:!1},[S.p.required]],RatingCurveID:[{value:this.ratingcurvevalue.RatingCurveID,disabled:!1},[S.p.required]],StageValue_m:[{value:this.ratingcurvevalue.StageValue_m,disabled:!1},[S.p.required,S.p.min(0),S.p.max(1e3)]],DischargeValue_m3_s:[{value:this.ratingcurvevalue.DischargeValue_m3_s,disabled:!1},[S.p.required,S.p.min(0),S.p.max(1e6)]],LastUpdateDate_UTC:[{value:this.ratingcurvevalue.LastUpdateDate_UTC,disabled:!1},[S.p.required]],LastUpdateContactTVItemID:[{value:this.ratingcurvevalue.LastUpdateContactTVItemID,disabled:!1},[S.p.required]]});this.ratingcurvevalueFormEdit=t}}}]),e}()).\u0275fac=function(e){return new(e||q)(o.Nb(f),o.Nb(S.d))},q.\u0275cmp=o.Hb({type:q,selectors:[["app-ratingcurvevalue-edit"]],inputs:{ratingcurvevalue:"ratingcurvevalue",httpClientCommand:"httpClientCommand"},decls:40,vars:10,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","RatingCurveValueID"],[4,"ngIf"],["matInput","","type","number","formControlName","RatingCurveID"],["matInput","","type","number","formControlName","StageValue_m"],["matInput","","type","number","formControlName","DischargeValue_m3_s"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(e,t){1&e&&(o.Tb(0,"form",0),o.ac("ngSubmit",(function(){return t.GetPut()?t.PutRatingCurveValue(t.ratingcurvevalueFormEdit.value):t.PostRatingCurveValue(t.ratingcurvevalueFormEdit.value)})),o.Tb(1,"h3"),o.yc(2," RatingCurveValue "),o.Tb(3,"button",1),o.Tb(4,"span"),o.yc(5),o.Sb(),o.Sb(),o.xc(6,I,1,0,"mat-progress-bar",2),o.xc(7,D,1,0,"mat-progress-bar",2),o.Sb(),o.Tb(8,"p"),o.Tb(9,"mat-form-field"),o.Tb(10,"mat-label"),o.yc(11,"RatingCurveValueID"),o.Sb(),o.Ob(12,"input",3),o.xc(13,R,6,4,"mat-error",4),o.Sb(),o.Tb(14,"mat-form-field"),o.Tb(15,"mat-label"),o.yc(16,"RatingCurveID"),o.Sb(),o.Ob(17,"input",5),o.xc(18,k,6,4,"mat-error",4),o.Sb(),o.Tb(19,"mat-form-field"),o.Tb(20,"mat-label"),o.yc(21,"StageValue_m"),o.Sb(),o.Ob(22,"input",6),o.xc(23,w,8,6,"mat-error",4),o.Sb(),o.Tb(24,"mat-form-field"),o.Tb(25,"mat-label"),o.yc(26,"DischargeValue_m3_s"),o.Sb(),o.Ob(27,"input",7),o.xc(28,_,8,6,"mat-error",4),o.Sb(),o.Sb(),o.Tb(29,"p"),o.Tb(30,"mat-form-field"),o.Tb(31,"mat-label"),o.yc(32,"LastUpdateDate_UTC"),o.Sb(),o.Ob(33,"input",8),o.xc(34,G,6,4,"mat-error",4),o.Sb(),o.Tb(35,"mat-form-field"),o.Tb(36,"mat-label"),o.yc(37,"LastUpdateContactTVItemID"),o.Sb(),o.Ob(38,"input",9),o.xc(39,U,6,4,"mat-error",4),o.Sb(),o.Sb(),o.Sb()),2&e&&(o.jc("formGroup",t.ratingcurvevalueFormEdit),o.Bb(5),o.Ac("",t.GetPut()?"Put":"Post"," RatingCurveValue"),o.Bb(1),o.jc("ngIf",t.ratingcurvevalueService.ratingcurvevaluePutModel$.getValue().Working),o.Bb(1),o.jc("ngIf",t.ratingcurvevalueService.ratingcurvevaluePostModel$.getValue().Working),o.Bb(6),o.jc("ngIf",t.ratingcurvevalueFormEdit.controls.RatingCurveValueID.errors),o.Bb(5),o.jc("ngIf",t.ratingcurvevalueFormEdit.controls.RatingCurveID.errors),o.Bb(5),o.jc("ngIf",t.ratingcurvevalueFormEdit.controls.StageValue_m.errors),o.Bb(5),o.jc("ngIf",t.ratingcurvevalueFormEdit.controls.DischargeValue_m3_s.errors),o.Bb(6),o.jc("ngIf",t.ratingcurvevalueFormEdit.controls.LastUpdateDate_UTC.errors),o.Bb(5),o.jc("ngIf",t.ratingcurvevalueFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[S.q,S.l,S.f,h.b,r.l,T.c,T.f,y.b,S.n,S.c,S.k,S.e,d.a,T.b],pipes:[r.f],styles:[""],changeDetection:0}),q);function N(e,t){1&e&&o.Ob(0,"mat-progress-bar",4)}function A(e,t){1&e&&o.Ob(0,"mat-progress-bar",4)}function z(e,t){if(1&e&&(o.Tb(0,"p"),o.Ob(1,"app-ratingcurvevalue-edit",8),o.Sb()),2&e){var a=o.ec().$implicit,r=o.ec(2);o.Bb(1),o.jc("ratingcurvevalue",a)("httpClientCommand",r.GetPutEnum())}}function W(e,t){if(1&e&&(o.Tb(0,"p"),o.Ob(1,"app-ratingcurvevalue-edit",8),o.Sb()),2&e){var a=o.ec().$implicit,r=o.ec(2);o.Bb(1),o.jc("ratingcurvevalue",a)("httpClientCommand",r.GetPostEnum())}}function H(e,t){if(1&e){var a=o.Ub();o.Tb(0,"div"),o.Tb(1,"p"),o.Tb(2,"button",6),o.ac("click",(function(){o.rc(a);var e=t.$implicit;return o.ec(2).DeleteRatingCurveValue(e)})),o.Tb(3,"span"),o.yc(4),o.Sb(),o.Tb(5,"mat-icon"),o.yc(6,"delete"),o.Sb(),o.Sb(),o.yc(7,"\xa0\xa0\xa0 "),o.Tb(8,"button",7),o.ac("click",(function(){o.rc(a);var e=t.$implicit;return o.ec(2).ShowPut(e)})),o.Tb(9,"span"),o.yc(10,"Show Put"),o.Sb(),o.Sb(),o.yc(11,"\xa0\xa0 "),o.Tb(12,"button",7),o.ac("click",(function(){o.rc(a);var e=t.$implicit;return o.ec(2).ShowPost(e)})),o.Tb(13,"span"),o.yc(14,"Show Post"),o.Sb(),o.Sb(),o.yc(15,"\xa0\xa0 "),o.xc(16,A,1,0,"mat-progress-bar",0),o.Sb(),o.xc(17,z,2,2,"p",2),o.xc(18,W,2,2,"p",2),o.Tb(19,"blockquote"),o.Tb(20,"p"),o.Tb(21,"span"),o.yc(22),o.Sb(),o.Tb(23,"span"),o.yc(24),o.Sb(),o.Tb(25,"span"),o.yc(26),o.Sb(),o.Tb(27,"span"),o.yc(28),o.Sb(),o.Sb(),o.Tb(29,"p"),o.Tb(30,"span"),o.yc(31),o.Sb(),o.Tb(32,"span"),o.yc(33),o.Sb(),o.Sb(),o.Sb(),o.Sb()}if(2&e){var r=t.$implicit,n=o.ec(2);o.Bb(4),o.Ac("Delete RatingCurveValueID [",r.RatingCurveValueID,"]\xa0\xa0\xa0"),o.Bb(4),o.jc("color",n.GetPutButtonColor(r)),o.Bb(4),o.jc("color",n.GetPostButtonColor(r)),o.Bb(4),o.jc("ngIf",n.ratingcurvevalueService.ratingcurvevalueDeleteModel$.getValue().Working),o.Bb(1),o.jc("ngIf",n.IDToShow===r.RatingCurveValueID&&n.showType===n.GetPutEnum()),o.Bb(1),o.jc("ngIf",n.IDToShow===r.RatingCurveValueID&&n.showType===n.GetPostEnum()),o.Bb(4),o.Ac("RatingCurveValueID: [",r.RatingCurveValueID,"]"),o.Bb(2),o.Ac(" --- RatingCurveID: [",r.RatingCurveID,"]"),o.Bb(2),o.Ac(" --- StageValue_m: [",r.StageValue_m,"]"),o.Bb(2),o.Ac(" --- DischargeValue_m3_s: [",r.DischargeValue_m3_s,"]"),o.Bb(3),o.Ac("LastUpdateDate_UTC: [",r.LastUpdateDate_UTC,"]"),o.Bb(2),o.Ac(" --- LastUpdateContactTVItemID: [",r.LastUpdateContactTVItemID,"]")}}function X(e,t){if(1&e&&(o.Tb(0,"div"),o.xc(1,H,34,12,"div",5),o.Sb()),2&e){var a=o.ec();o.Bb(1),o.jc("ngForOf",a.ratingcurvevalueService.ratingcurvevalueListModel$.getValue())}}var J,K,Q,Y=[{path:"",component:(J=function(){function e(t,a,r){_classCallCheck(this,e),this.ratingcurvevalueService=t,this.router=a,this.httpClientService=r,this.showType=null,r.oldURL=a.url}return _createClass(e,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.RatingCurveValueID&&this.showType===c.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.RatingCurveValueID&&this.showType===c.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.RatingCurveValueID&&this.showType===c.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RatingCurveValueID,this.showType=c.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.RatingCurveValueID&&this.showType===c.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RatingCurveValueID,this.showType=c.a.Post)}},{key:"GetPutEnum",value:function(){return c.a.Put}},{key:"GetPostEnum",value:function(){return c.a.Post}},{key:"GetRatingCurveValueList",value:function(){this.sub=this.ratingcurvevalueService.GetRatingCurveValueList().subscribe()}},{key:"DeleteRatingCurveValue",value:function(e){this.sub=this.ratingcurvevalueService.DeleteRatingCurveValue(e).subscribe()}},{key:"ngOnInit",value:function(){i(this.ratingcurvevalueService.ratingcurvevalueTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),e}(),J.\u0275fac=function(e){return new(e||J)(o.Nb(f),o.Nb(n.b),o.Nb(p.a))},J.\u0275cmp=o.Hb({type:J,selectors:[["app-ratingcurvevalue"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"ratingcurvevalue","httpClientCommand"]],template:function(e,t){if(1&e&&(o.xc(0,N,1,0,"mat-progress-bar",0),o.Tb(1,"mat-card"),o.Tb(2,"mat-card-header"),o.Tb(3,"mat-card-title"),o.yc(4," RatingCurveValue works! "),o.Tb(5,"button",1),o.ac("click",(function(){return t.GetRatingCurveValueList()})),o.Tb(6,"span"),o.yc(7,"Get RatingCurveValue"),o.Sb(),o.Sb(),o.Sb(),o.Tb(8,"mat-card-subtitle"),o.yc(9),o.Sb(),o.Sb(),o.Tb(10,"mat-card-content"),o.xc(11,X,2,1,"div",2),o.Sb(),o.Tb(12,"mat-card-actions"),o.Tb(13,"button",3),o.yc(14,"Allo"),o.Sb(),o.Sb(),o.Sb()),2&e){var a,r,n=null==(a=t.ratingcurvevalueService.ratingcurvevalueGetModel$.getValue())?null:a.Working,i=null==(r=t.ratingcurvevalueService.ratingcurvevalueListModel$.getValue())?null:r.length;o.jc("ngIf",n),o.Bb(9),o.zc(t.ratingcurvevalueService.ratingcurvevalueTextModel$.getValue().Title),o.Bb(2),o.jc("ngIf",i)}},directives:[r.l,m.a,m.d,m.g,h.b,m.f,m.c,m.b,d.a,r.k,C.a,F],styles:[""],changeDetection:0}),J),canActivate:[a("auXs").a]}],Z=((K=function e(){_classCallCheck(this,e)}).\u0275mod=o.Lb({type:K}),K.\u0275inj=o.Kb({factory:function(e){return new(e||K)},imports:[[n.e.forChild(Y)],n.e]}),K),ee=a("B+Mi"),te=((Q=function e(){_classCallCheck(this,e)}).\u0275mod=o.Lb({type:Q}),Q.\u0275inj=o.Kb({factory:function(e){return new(e||Q)},imports:[[r.c,n.e,Z,ee.a,S.g,S.o]]}),Q)},QRvi:function(e,t,a){"use strict";a.d(t,"a",(function(){return r}));var r=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,a){"use strict";a.d(t,"a",(function(){return u}));var r=a("QRvi"),n=a("fXoL"),i=a("tyNb"),u=function(){var e=function(){function e(t){_classCallCheck(this,e),this.router=t,this.oldURL=t.url}return _createClass(e,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,t,a){e.next(null),t.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,t,a,n,i){if(n===r.a.Get&&e.next(a),n===r.a.Put&&(e.getValue()[0]=a),n===r.a.Post&&e.getValue().push(a),n===r.a.Delete){var u=e.getValue().indexOf(i);e.getValue().splice(u,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(n.Xb(i.b))},e.\u0275prov=n.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()}}]);