!function(){function e(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function t(e,t){for(var a=0;a<t.length;a++){var n=t[a];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(e,n.key,n)}}function a(e,a,n){return a&&t(e.prototype,a),n&&t(e,n),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[78],{NoDl:function(t,n,r){"use strict";r.r(n),r.d(n,"RatingCurveValueModule",(function(){return ne}));var i=r("ofXK"),u=r("tyNb");function c(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var o,l=r("QRvi"),b=r("fXoL"),s=r("2Vo4"),v=r("LRne"),g=r("tk/3"),p=r("lJxs"),f=r("JIr8"),m=r("gkM4"),d=((o=function(){function t(a,n){e(this,t),this.httpClient=a,this.httpClientService=n,this.ratingcurvevalueTextModel$=new s.a({}),this.ratingcurvevalueListModel$=new s.a({}),this.ratingcurvevalueGetModel$=new s.a({}),this.ratingcurvevaluePutModel$=new s.a({}),this.ratingcurvevaluePostModel$=new s.a({}),this.ratingcurvevalueDeleteModel$=new s.a({}),c(this.ratingcurvevalueTextModel$),this.ratingcurvevalueTextModel$.next({Title:"Something2 for text"})}return a(t,[{key:"GetRatingCurveValueList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.ratingcurvevalueGetModel$),this.httpClient.get("/api/RatingCurveValue").pipe(Object(p.a)((function(t){e.httpClientService.DoSuccess(e.ratingcurvevalueListModel$,e.ratingcurvevalueGetModel$,t,l.a.Get,null)})),Object(f.a)((function(t){return Object(v.a)(t).pipe(Object(p.a)((function(t){e.httpClientService.DoCatchError(e.ratingcurvevalueListModel$,e.ratingcurvevalueGetModel$,t)})))})))}},{key:"PutRatingCurveValue",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.ratingcurvevaluePutModel$),this.httpClient.put("/api/RatingCurveValue",e,{headers:new g.d}).pipe(Object(p.a)((function(a){t.httpClientService.DoSuccess(t.ratingcurvevalueListModel$,t.ratingcurvevaluePutModel$,a,l.a.Put,e)})),Object(f.a)((function(e){return Object(v.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.ratingcurvevalueListModel$,t.ratingcurvevaluePutModel$,e)})))})))}},{key:"PostRatingCurveValue",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.ratingcurvevaluePostModel$),this.httpClient.post("/api/RatingCurveValue",e,{headers:new g.d}).pipe(Object(p.a)((function(a){t.httpClientService.DoSuccess(t.ratingcurvevalueListModel$,t.ratingcurvevaluePostModel$,a,l.a.Post,e)})),Object(f.a)((function(e){return Object(v.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.ratingcurvevalueListModel$,t.ratingcurvevaluePostModel$,e)})))})))}},{key:"DeleteRatingCurveValue",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.ratingcurvevalueDeleteModel$),this.httpClient.delete("/api/RatingCurveValue/"+e.RatingCurveValueID).pipe(Object(p.a)((function(a){t.httpClientService.DoSuccess(t.ratingcurvevalueListModel$,t.ratingcurvevalueDeleteModel$,a,l.a.Delete,e)})),Object(f.a)((function(e){return Object(v.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.ratingcurvevalueListModel$,t.ratingcurvevalueDeleteModel$,e)})))})))}}]),t}()).\u0275fac=function(e){return new(e||o)(b.Wb(g.b),b.Wb(m.a))},o.\u0275prov=b.Ib({token:o,factory:o.\u0275fac,providedIn:"root"}),o),h=r("Wp6s"),R=r("bTqV"),S=r("bv9b"),C=r("NFeN"),I=r("3Pt+"),D=r("kmnG"),y=r("qFsG");function V(e,t){1&e&&b.Nb(0,"mat-progress-bar",10)}function B(e,t){1&e&&b.Nb(0,"mat-progress-bar",10)}function P(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function k(e,t){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,P,3,0,"span",4),b.Rb()),2&e){var a=t.$implicit;b.Bb(2),b.Ac(b.fc(3,2,a)),b.Bb(3),b.ic("ngIf",a.required)}}function w(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function M(e,t){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,w,3,0,"span",4),b.Rb()),2&e){var a=t.$implicit;b.Bb(2),b.Ac(b.fc(3,2,a)),b.Bb(3),b.ic("ngIf",a.required)}}function T(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function $(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function z(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 1000"),b.Nb(2,"br"),b.Rb())}function N(e,t){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,T,3,0,"span",4),b.yc(6,$,3,0,"span",4),b.yc(7,z,3,0,"span",4),b.Rb()),2&e){var a=t.$implicit;b.Bb(2),b.Ac(b.fc(3,4,a)),b.Bb(3),b.ic("ngIf",a.required),b.Bb(1),b.ic("ngIf",a.min),b.Bb(1),b.ic("ngIf",a.min)}}function L(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function G(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function E(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 1000000"),b.Nb(2,"br"),b.Rb())}function _(e,t){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,L,3,0,"span",4),b.yc(6,G,3,0,"span",4),b.yc(7,E,3,0,"span",4),b.Rb()),2&e){var a=t.$implicit;b.Bb(2),b.Ac(b.fc(3,4,a)),b.Bb(3),b.ic("ngIf",a.required),b.Bb(1),b.ic("ngIf",a.min),b.Bb(1),b.ic("ngIf",a.min)}}function x(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function j(e,t){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,x,3,0,"span",4),b.Rb()),2&e){var a=t.$implicit;b.Bb(2),b.Ac(b.fc(3,2,a)),b.Bb(3),b.ic("ngIf",a.required)}}function q(e,t){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function U(e,t){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,q,3,0,"span",4),b.Rb()),2&e){var a=t.$implicit;b.Bb(2),b.Ac(b.fc(3,2,a)),b.Bb(3),b.ic("ngIf",a.required)}}var O,F=((O=function(){function t(a,n){e(this,t),this.ratingcurvevalueService=a,this.fb=n,this.ratingcurvevalue=null,this.httpClientCommand=l.a.Put}return a(t,[{key:"GetPut",value:function(){return this.httpClientCommand==l.a.Put}},{key:"PutRatingCurveValue",value:function(e){this.sub=this.ratingcurvevalueService.PutRatingCurveValue(e).subscribe()}},{key:"PostRatingCurveValue",value:function(e){this.sub=this.ratingcurvevalueService.PostRatingCurveValue(e).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.ratingcurvevalue){var t=this.fb.group({RatingCurveValueID:[{value:e===l.a.Post?0:this.ratingcurvevalue.RatingCurveValueID,disabled:!1},[I.p.required]],RatingCurveID:[{value:this.ratingcurvevalue.RatingCurveID,disabled:!1},[I.p.required]],StageValue_m:[{value:this.ratingcurvevalue.StageValue_m,disabled:!1},[I.p.required,I.p.min(0),I.p.max(1e3)]],DischargeValue_m3_s:[{value:this.ratingcurvevalue.DischargeValue_m3_s,disabled:!1},[I.p.required,I.p.min(0),I.p.max(1e6)]],LastUpdateDate_UTC:[{value:this.ratingcurvevalue.LastUpdateDate_UTC,disabled:!1},[I.p.required]],LastUpdateContactTVItemID:[{value:this.ratingcurvevalue.LastUpdateContactTVItemID,disabled:!1},[I.p.required]]});this.ratingcurvevalueFormEdit=t}}}]),t}()).\u0275fac=function(e){return new(e||O)(b.Mb(d),b.Mb(I.d))},O.\u0275cmp=b.Gb({type:O,selectors:[["app-ratingcurvevalue-edit"]],inputs:{ratingcurvevalue:"ratingcurvevalue",httpClientCommand:"httpClientCommand"},decls:40,vars:10,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","RatingCurveValueID"],[4,"ngIf"],["matInput","","type","number","formControlName","RatingCurveID"],["matInput","","type","number","formControlName","StageValue_m"],["matInput","","type","number","formControlName","DischargeValue_m3_s"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(e,t){1&e&&(b.Sb(0,"form",0),b.Zb("ngSubmit",(function(){return t.GetPut()?t.PutRatingCurveValue(t.ratingcurvevalueFormEdit.value):t.PostRatingCurveValue(t.ratingcurvevalueFormEdit.value)})),b.Sb(1,"h3"),b.zc(2," RatingCurveValue "),b.Sb(3,"button",1),b.Sb(4,"span"),b.zc(5),b.Rb(),b.Rb(),b.yc(6,V,1,0,"mat-progress-bar",2),b.yc(7,B,1,0,"mat-progress-bar",2),b.Rb(),b.Sb(8,"p"),b.Sb(9,"mat-form-field"),b.Sb(10,"mat-label"),b.zc(11,"RatingCurveValueID"),b.Rb(),b.Nb(12,"input",3),b.yc(13,k,6,4,"mat-error",4),b.Rb(),b.Sb(14,"mat-form-field"),b.Sb(15,"mat-label"),b.zc(16,"RatingCurveID"),b.Rb(),b.Nb(17,"input",5),b.yc(18,M,6,4,"mat-error",4),b.Rb(),b.Sb(19,"mat-form-field"),b.Sb(20,"mat-label"),b.zc(21,"StageValue_m"),b.Rb(),b.Nb(22,"input",6),b.yc(23,N,8,6,"mat-error",4),b.Rb(),b.Sb(24,"mat-form-field"),b.Sb(25,"mat-label"),b.zc(26,"DischargeValue_m3_s"),b.Rb(),b.Nb(27,"input",7),b.yc(28,_,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"mat-form-field"),b.Sb(31,"mat-label"),b.zc(32,"LastUpdateDate_UTC"),b.Rb(),b.Nb(33,"input",8),b.yc(34,j,6,4,"mat-error",4),b.Rb(),b.Sb(35,"mat-form-field"),b.Sb(36,"mat-label"),b.zc(37,"LastUpdateContactTVItemID"),b.Rb(),b.Nb(38,"input",9),b.yc(39,U,6,4,"mat-error",4),b.Rb(),b.Rb(),b.Rb()),2&e&&(b.ic("formGroup",t.ratingcurvevalueFormEdit),b.Bb(5),b.Bc("",t.GetPut()?"Put":"Post"," RatingCurveValue"),b.Bb(1),b.ic("ngIf",t.ratingcurvevalueService.ratingcurvevaluePutModel$.getValue().Working),b.Bb(1),b.ic("ngIf",t.ratingcurvevalueService.ratingcurvevaluePostModel$.getValue().Working),b.Bb(6),b.ic("ngIf",t.ratingcurvevalueFormEdit.controls.RatingCurveValueID.errors),b.Bb(5),b.ic("ngIf",t.ratingcurvevalueFormEdit.controls.RatingCurveID.errors),b.Bb(5),b.ic("ngIf",t.ratingcurvevalueFormEdit.controls.StageValue_m.errors),b.Bb(5),b.ic("ngIf",t.ratingcurvevalueFormEdit.controls.DischargeValue_m3_s.errors),b.Bb(6),b.ic("ngIf",t.ratingcurvevalueFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(5),b.ic("ngIf",t.ratingcurvevalueFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[I.q,I.l,I.f,R.b,i.l,D.c,D.f,y.b,I.n,I.c,I.k,I.e,S.a,D.b],pipes:[i.f],styles:[""],changeDetection:0}),O);function W(e,t){1&e&&b.Nb(0,"mat-progress-bar",4)}function A(e,t){1&e&&b.Nb(0,"mat-progress-bar",4)}function J(e,t){if(1&e&&(b.Sb(0,"p"),b.Nb(1,"app-ratingcurvevalue-edit",8),b.Rb()),2&e){var a=b.dc().$implicit,n=b.dc(2);b.Bb(1),b.ic("ratingcurvevalue",a)("httpClientCommand",n.GetPutEnum())}}function H(e,t){if(1&e&&(b.Sb(0,"p"),b.Nb(1,"app-ratingcurvevalue-edit",8),b.Rb()),2&e){var a=b.dc().$implicit,n=b.dc(2);b.Bb(1),b.ic("ratingcurvevalue",a)("httpClientCommand",n.GetPostEnum())}}function Z(e,t){if(1&e){var a=b.Tb();b.Sb(0,"div"),b.Sb(1,"p"),b.Sb(2,"button",6),b.Zb("click",(function(){b.qc(a);var e=t.$implicit;return b.dc(2).DeleteRatingCurveValue(e)})),b.Sb(3,"span"),b.zc(4),b.Rb(),b.Sb(5,"mat-icon"),b.zc(6,"delete"),b.Rb(),b.Rb(),b.zc(7,"\xa0\xa0\xa0 "),b.Sb(8,"button",7),b.Zb("click",(function(){b.qc(a);var e=t.$implicit;return b.dc(2).ShowPut(e)})),b.Sb(9,"span"),b.zc(10,"Show Put"),b.Rb(),b.Rb(),b.zc(11,"\xa0\xa0 "),b.Sb(12,"button",7),b.Zb("click",(function(){b.qc(a);var e=t.$implicit;return b.dc(2).ShowPost(e)})),b.Sb(13,"span"),b.zc(14,"Show Post"),b.Rb(),b.Rb(),b.zc(15,"\xa0\xa0 "),b.yc(16,A,1,0,"mat-progress-bar",0),b.Rb(),b.yc(17,J,2,2,"p",2),b.yc(18,H,2,2,"p",2),b.Sb(19,"blockquote"),b.Sb(20,"p"),b.Sb(21,"span"),b.zc(22),b.Rb(),b.Sb(23,"span"),b.zc(24),b.Rb(),b.Sb(25,"span"),b.zc(26),b.Rb(),b.Sb(27,"span"),b.zc(28),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"span"),b.zc(31),b.Rb(),b.Sb(32,"span"),b.zc(33),b.Rb(),b.Rb(),b.Rb(),b.Rb()}if(2&e){var n=t.$implicit,r=b.dc(2);b.Bb(4),b.Bc("Delete RatingCurveValueID [",n.RatingCurveValueID,"]\xa0\xa0\xa0"),b.Bb(4),b.ic("color",r.GetPutButtonColor(n)),b.Bb(4),b.ic("color",r.GetPostButtonColor(n)),b.Bb(4),b.ic("ngIf",r.ratingcurvevalueService.ratingcurvevalueDeleteModel$.getValue().Working),b.Bb(1),b.ic("ngIf",r.IDToShow===n.RatingCurveValueID&&r.showType===r.GetPutEnum()),b.Bb(1),b.ic("ngIf",r.IDToShow===n.RatingCurveValueID&&r.showType===r.GetPostEnum()),b.Bb(4),b.Bc("RatingCurveValueID: [",n.RatingCurveValueID,"]"),b.Bb(2),b.Bc(" --- RatingCurveID: [",n.RatingCurveID,"]"),b.Bb(2),b.Bc(" --- StageValue_m: [",n.StageValue_m,"]"),b.Bb(2),b.Bc(" --- DischargeValue_m3_s: [",n.DischargeValue_m3_s,"]"),b.Bb(3),b.Bc("LastUpdateDate_UTC: [",n.LastUpdateDate_UTC,"]"),b.Bb(2),b.Bc(" --- LastUpdateContactTVItemID: [",n.LastUpdateContactTVItemID,"]")}}function X(e,t){if(1&e&&(b.Sb(0,"div"),b.yc(1,Z,34,12,"div",5),b.Rb()),2&e){var a=b.dc();b.Bb(1),b.ic("ngForOf",a.ratingcurvevalueService.ratingcurvevalueListModel$.getValue())}}var K,Q,Y,ee=[{path:"",component:(K=function(){function t(a,n,r){e(this,t),this.ratingcurvevalueService=a,this.router=n,this.httpClientService=r,this.showType=null,r.oldURL=n.url}return a(t,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.RatingCurveValueID&&this.showType===l.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.RatingCurveValueID&&this.showType===l.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.RatingCurveValueID&&this.showType===l.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RatingCurveValueID,this.showType=l.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.RatingCurveValueID&&this.showType===l.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RatingCurveValueID,this.showType=l.a.Post)}},{key:"GetPutEnum",value:function(){return l.a.Put}},{key:"GetPostEnum",value:function(){return l.a.Post}},{key:"GetRatingCurveValueList",value:function(){this.sub=this.ratingcurvevalueService.GetRatingCurveValueList().subscribe()}},{key:"DeleteRatingCurveValue",value:function(e){this.sub=this.ratingcurvevalueService.DeleteRatingCurveValue(e).subscribe()}},{key:"ngOnInit",value:function(){c(this.ratingcurvevalueService.ratingcurvevalueTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),t}(),K.\u0275fac=function(e){return new(e||K)(b.Mb(d),b.Mb(u.b),b.Mb(m.a))},K.\u0275cmp=b.Gb({type:K,selectors:[["app-ratingcurvevalue"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"ratingcurvevalue","httpClientCommand"]],template:function(e,t){if(1&e&&(b.yc(0,W,1,0,"mat-progress-bar",0),b.Sb(1,"mat-card"),b.Sb(2,"mat-card-header"),b.Sb(3,"mat-card-title"),b.zc(4," RatingCurveValue works! "),b.Sb(5,"button",1),b.Zb("click",(function(){return t.GetRatingCurveValueList()})),b.Sb(6,"span"),b.zc(7,"Get RatingCurveValue"),b.Rb(),b.Rb(),b.Rb(),b.Sb(8,"mat-card-subtitle"),b.zc(9),b.Rb(),b.Rb(),b.Sb(10,"mat-card-content"),b.yc(11,X,2,1,"div",2),b.Rb(),b.Sb(12,"mat-card-actions"),b.Sb(13,"button",3),b.zc(14,"Allo"),b.Rb(),b.Rb(),b.Rb()),2&e){var a,n,r=null==(a=t.ratingcurvevalueService.ratingcurvevalueGetModel$.getValue())?null:a.Working,i=null==(n=t.ratingcurvevalueService.ratingcurvevalueListModel$.getValue())?null:n.length;b.ic("ngIf",r),b.Bb(9),b.Ac(t.ratingcurvevalueService.ratingcurvevalueTextModel$.getValue().Title),b.Bb(2),b.ic("ngIf",i)}},directives:[i.l,h.a,h.d,h.g,R.b,h.f,h.c,h.b,S.a,i.k,C.a,F],styles:[""],changeDetection:0}),K),canActivate:[r("auXs").a]}],te=((Q=function t(){e(this,t)}).\u0275mod=b.Kb({type:Q}),Q.\u0275inj=b.Jb({factory:function(e){return new(e||Q)},imports:[[u.e.forChild(ee)],u.e]}),Q),ae=r("B+Mi"),ne=((Y=function t(){e(this,t)}).\u0275mod=b.Kb({type:Y}),Y.\u0275inj=b.Jb({factory:function(e){return new(e||Y)},imports:[[i.c,u.e,te,ae.a,I.g,I.o]]}),Y)},QRvi:function(e,t,a){"use strict";a.d(t,"a",(function(){return n}));var n=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(t,n,r){"use strict";r.d(n,"a",(function(){return o}));var i=r("QRvi"),u=r("fXoL"),c=r("tyNb"),o=function(){var t=function(){function t(a){e(this,t),this.router=a,this.oldURL=a.url}return a(t,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,t,a){e.next(null),t.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(e,t,a){e.next(null),t.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,t,a,n,r){if(n===i.a.Get&&e.next(a),n===i.a.Put&&(e.getValue()[0]=a),n===i.a.Post&&e.getValue().push(a),n===i.a.Delete){var u=e.getValue().indexOf(r);e.getValue().splice(u,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(e,t,a,n,r){n===i.a.Get&&e.next(a),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),t}();return t.\u0275fac=function(e){return new(e||t)(u.Wb(c.b))},t.\u0275prov=u.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t}()}}])}();