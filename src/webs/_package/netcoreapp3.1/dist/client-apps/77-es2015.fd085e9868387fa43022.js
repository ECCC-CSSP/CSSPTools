(window.webpackJsonp=window.webpackJsonp||[]).push([[77],{QRvi:function(t,e,r){"use strict";r.d(e,"a",(function(){return i}));var i=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},bjkp:function(t,e,r){"use strict";r.r(e),r.d(e,"RatingCurveModule",(function(){return W}));var i=r("ofXK"),n=r("tyNb");function a(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var c=r("QRvi"),o=r("fXoL"),u=r("2Vo4"),s=r("LRne"),b=r("tk/3"),l=r("lJxs"),g=r("JIr8"),p=r("gkM4");let v=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.ratingcurveTextModel$=new u.a({}),this.ratingcurveListModel$=new u.a({}),this.ratingcurveGetModel$=new u.a({}),this.ratingcurvePutModel$=new u.a({}),this.ratingcurvePostModel$=new u.a({}),this.ratingcurveDeleteModel$=new u.a({}),a(this.ratingcurveTextModel$),this.ratingcurveTextModel$.next({Title:"Something2 for text"})}GetRatingCurveList(){return this.httpClientService.BeforeHttpClient(this.ratingcurveGetModel$),this.httpClient.get("/api/RatingCurve").pipe(Object(l.a)(t=>{this.httpClientService.DoSuccess(this.ratingcurveListModel$,this.ratingcurveGetModel$,t,c.a.Get,null)}),Object(g.a)(t=>Object(s.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.ratingcurveListModel$,this.ratingcurveGetModel$,t)}))))}PutRatingCurve(t){return this.httpClientService.BeforeHttpClient(this.ratingcurvePutModel$),this.httpClient.put("/api/RatingCurve",t,{headers:new b.d}).pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.ratingcurveListModel$,this.ratingcurvePutModel$,e,c.a.Put,t)}),Object(g.a)(t=>Object(s.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.ratingcurveListModel$,this.ratingcurvePutModel$,t)}))))}PostRatingCurve(t){return this.httpClientService.BeforeHttpClient(this.ratingcurvePostModel$),this.httpClient.post("/api/RatingCurve",t,{headers:new b.d}).pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.ratingcurveListModel$,this.ratingcurvePostModel$,e,c.a.Post,t)}),Object(g.a)(t=>Object(s.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.ratingcurveListModel$,this.ratingcurvePostModel$,t)}))))}DeleteRatingCurve(t){return this.httpClientService.BeforeHttpClient(this.ratingcurveDeleteModel$),this.httpClient.delete("/api/RatingCurve/"+t.RatingCurveID).pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.ratingcurveListModel$,this.ratingcurveDeleteModel$,e,c.a.Delete,t)}),Object(g.a)(t=>Object(s.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.ratingcurveListModel$,this.ratingcurveDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(o.Xb(b.b),o.Xb(p.a))},t.\u0275prov=o.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var h=r("Wp6s"),d=r("bTqV"),m=r("bv9b"),f=r("NFeN"),S=r("3Pt+"),C=r("kmnG"),T=r("qFsG");function I(t,e){1&t&&o.Ob(0,"mat-progress-bar",9)}function D(t,e){1&t&&o.Ob(0,"mat-progress-bar",9)}function y(t,e){1&t&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function R(t,e){if(1&t&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,y,3,0,"span",4),o.Sb()),2&t){const t=e.$implicit;o.Bb(2),o.zc(o.gc(3,2,t)),o.Bb(3),o.jc("ngIf",t.required)}}function P(t,e){1&t&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function j(t,e){if(1&t&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,P,3,0,"span",4),o.Sb()),2&t){const t=e.$implicit;o.Bb(2),o.zc(o.gc(3,2,t)),o.Bb(3),o.jc("ngIf",t.required)}}function w(t,e){1&t&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function B(t,e){1&t&&(o.Tb(0,"span"),o.yc(1,"MaxLength - 50"),o.Ob(2,"br"),o.Sb())}function $(t,e){if(1&t&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,w,3,0,"span",4),o.xc(6,B,3,0,"span",4),o.Sb()),2&t){const t=e.$implicit;o.Bb(2),o.zc(o.gc(3,3,t)),o.Bb(3),o.jc("ngIf",t.required),o.Bb(1),o.jc("ngIf",t.maxlength)}}function O(t,e){1&t&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function L(t,e){if(1&t&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,O,3,0,"span",4),o.Sb()),2&t){const t=e.$implicit;o.Bb(2),o.zc(o.gc(3,2,t)),o.Bb(3),o.jc("ngIf",t.required)}}function M(t,e){1&t&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function x(t,e){if(1&t&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,M,3,0,"span",4),o.Sb()),2&t){const t=e.$implicit;o.Bb(2),o.zc(o.gc(3,2,t)),o.Bb(3),o.jc("ngIf",t.required)}}let G=(()=>{class t{constructor(t,e){this.ratingcurveService=t,this.fb=e,this.ratingcurve=null,this.httpClientCommand=c.a.Put}GetPut(){return this.httpClientCommand==c.a.Put}PutRatingCurve(t){this.sub=this.ratingcurveService.PutRatingCurve(t).subscribe()}PostRatingCurve(t){this.sub=this.ratingcurveService.PostRatingCurve(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.ratingcurve){let e=this.fb.group({RatingCurveID:[{value:t===c.a.Post?0:this.ratingcurve.RatingCurveID,disabled:!1},[S.p.required]],HydrometricSiteID:[{value:this.ratingcurve.HydrometricSiteID,disabled:!1},[S.p.required]],RatingCurveNumber:[{value:this.ratingcurve.RatingCurveNumber,disabled:!1},[S.p.required,S.p.maxLength(50)]],LastUpdateDate_UTC:[{value:this.ratingcurve.LastUpdateDate_UTC,disabled:!1},[S.p.required]],LastUpdateContactTVItemID:[{value:this.ratingcurve.LastUpdateContactTVItemID,disabled:!1},[S.p.required]]});this.ratingcurveFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(o.Nb(v),o.Nb(S.d))},t.\u0275cmp=o.Hb({type:t,selectors:[["app-ratingcurve-edit"]],inputs:{ratingcurve:"ratingcurve",httpClientCommand:"httpClientCommand"},decls:35,vars:9,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","RatingCurveID"],[4,"ngIf"],["matInput","","type","number","formControlName","HydrometricSiteID"],["matInput","","type","text","formControlName","RatingCurveNumber"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,e){1&t&&(o.Tb(0,"form",0),o.ac("ngSubmit",(function(){return e.GetPut()?e.PutRatingCurve(e.ratingcurveFormEdit.value):e.PostRatingCurve(e.ratingcurveFormEdit.value)})),o.Tb(1,"h3"),o.yc(2," RatingCurve "),o.Tb(3,"button",1),o.Tb(4,"span"),o.yc(5),o.Sb(),o.Sb(),o.xc(6,I,1,0,"mat-progress-bar",2),o.xc(7,D,1,0,"mat-progress-bar",2),o.Sb(),o.Tb(8,"p"),o.Tb(9,"mat-form-field"),o.Tb(10,"mat-label"),o.yc(11,"RatingCurveID"),o.Sb(),o.Ob(12,"input",3),o.xc(13,R,6,4,"mat-error",4),o.Sb(),o.Tb(14,"mat-form-field"),o.Tb(15,"mat-label"),o.yc(16,"HydrometricSiteID"),o.Sb(),o.Ob(17,"input",5),o.xc(18,j,6,4,"mat-error",4),o.Sb(),o.Tb(19,"mat-form-field"),o.Tb(20,"mat-label"),o.yc(21,"RatingCurveNumber"),o.Sb(),o.Ob(22,"input",6),o.xc(23,$,7,5,"mat-error",4),o.Sb(),o.Tb(24,"mat-form-field"),o.Tb(25,"mat-label"),o.yc(26,"LastUpdateDate_UTC"),o.Sb(),o.Ob(27,"input",7),o.xc(28,L,6,4,"mat-error",4),o.Sb(),o.Sb(),o.Tb(29,"p"),o.Tb(30,"mat-form-field"),o.Tb(31,"mat-label"),o.yc(32,"LastUpdateContactTVItemID"),o.Sb(),o.Ob(33,"input",8),o.xc(34,x,6,4,"mat-error",4),o.Sb(),o.Sb(),o.Sb()),2&t&&(o.jc("formGroup",e.ratingcurveFormEdit),o.Bb(5),o.Ac("",e.GetPut()?"Put":"Post"," RatingCurve"),o.Bb(1),o.jc("ngIf",e.ratingcurveService.ratingcurvePutModel$.getValue().Working),o.Bb(1),o.jc("ngIf",e.ratingcurveService.ratingcurvePostModel$.getValue().Working),o.Bb(6),o.jc("ngIf",e.ratingcurveFormEdit.controls.RatingCurveID.errors),o.Bb(5),o.jc("ngIf",e.ratingcurveFormEdit.controls.HydrometricSiteID.errors),o.Bb(5),o.jc("ngIf",e.ratingcurveFormEdit.controls.RatingCurveNumber.errors),o.Bb(5),o.jc("ngIf",e.ratingcurveFormEdit.controls.LastUpdateDate_UTC.errors),o.Bb(6),o.jc("ngIf",e.ratingcurveFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[S.q,S.l,S.f,d.b,i.l,C.c,C.f,T.b,S.n,S.c,S.k,S.e,m.a,C.b],pipes:[i.f],styles:[""],changeDetection:0}),t})();function k(t,e){1&t&&o.Ob(0,"mat-progress-bar",4)}function U(t,e){1&t&&o.Ob(0,"mat-progress-bar",4)}function E(t,e){if(1&t&&(o.Tb(0,"p"),o.Ob(1,"app-ratingcurve-edit",8),o.Sb()),2&t){const t=o.ec().$implicit,e=o.ec(2);o.Bb(1),o.jc("ratingcurve",t)("httpClientCommand",e.GetPutEnum())}}function N(t,e){if(1&t&&(o.Tb(0,"p"),o.Ob(1,"app-ratingcurve-edit",8),o.Sb()),2&t){const t=o.ec().$implicit,e=o.ec(2);o.Bb(1),o.jc("ratingcurve",t)("httpClientCommand",e.GetPostEnum())}}function V(t,e){if(1&t){const t=o.Ub();o.Tb(0,"div"),o.Tb(1,"p"),o.Tb(2,"button",6),o.ac("click",(function(){o.rc(t);const r=e.$implicit;return o.ec(2).DeleteRatingCurve(r)})),o.Tb(3,"span"),o.yc(4),o.Sb(),o.Tb(5,"mat-icon"),o.yc(6,"delete"),o.Sb(),o.Sb(),o.yc(7,"\xa0\xa0\xa0 "),o.Tb(8,"button",7),o.ac("click",(function(){o.rc(t);const r=e.$implicit;return o.ec(2).ShowPut(r)})),o.Tb(9,"span"),o.yc(10,"Show Put"),o.Sb(),o.Sb(),o.yc(11,"\xa0\xa0 "),o.Tb(12,"button",7),o.ac("click",(function(){o.rc(t);const r=e.$implicit;return o.ec(2).ShowPost(r)})),o.Tb(13,"span"),o.yc(14,"Show Post"),o.Sb(),o.Sb(),o.yc(15,"\xa0\xa0 "),o.xc(16,U,1,0,"mat-progress-bar",0),o.Sb(),o.xc(17,E,2,2,"p",2),o.xc(18,N,2,2,"p",2),o.Tb(19,"blockquote"),o.Tb(20,"p"),o.Tb(21,"span"),o.yc(22),o.Sb(),o.Tb(23,"span"),o.yc(24),o.Sb(),o.Tb(25,"span"),o.yc(26),o.Sb(),o.Tb(27,"span"),o.yc(28),o.Sb(),o.Sb(),o.Tb(29,"p"),o.Tb(30,"span"),o.yc(31),o.Sb(),o.Sb(),o.Sb(),o.Sb()}if(2&t){const t=e.$implicit,r=o.ec(2);o.Bb(4),o.Ac("Delete RatingCurveID [",t.RatingCurveID,"]\xa0\xa0\xa0"),o.Bb(4),o.jc("color",r.GetPutButtonColor(t)),o.Bb(4),o.jc("color",r.GetPostButtonColor(t)),o.Bb(4),o.jc("ngIf",r.ratingcurveService.ratingcurveDeleteModel$.getValue().Working),o.Bb(1),o.jc("ngIf",r.IDToShow===t.RatingCurveID&&r.showType===r.GetPutEnum()),o.Bb(1),o.jc("ngIf",r.IDToShow===t.RatingCurveID&&r.showType===r.GetPostEnum()),o.Bb(4),o.Ac("RatingCurveID: [",t.RatingCurveID,"]"),o.Bb(2),o.Ac(" --- HydrometricSiteID: [",t.HydrometricSiteID,"]"),o.Bb(2),o.Ac(" --- RatingCurveNumber: [",t.RatingCurveNumber,"]"),o.Bb(2),o.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),o.Bb(3),o.Ac("LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function q(t,e){if(1&t&&(o.Tb(0,"div"),o.xc(1,V,32,11,"div",5),o.Sb()),2&t){const t=o.ec();o.Bb(1),o.jc("ngForOf",t.ratingcurveService.ratingcurveListModel$.getValue())}}const F=[{path:"",component:(()=>{class t{constructor(t,e,r){this.ratingcurveService=t,this.router=e,this.httpClientService=r,this.showType=null,r.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.RatingCurveID&&this.showType===c.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.RatingCurveID&&this.showType===c.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.RatingCurveID&&this.showType===c.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.RatingCurveID,this.showType=c.a.Put)}ShowPost(t){this.IDToShow===t.RatingCurveID&&this.showType===c.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.RatingCurveID,this.showType=c.a.Post)}GetPutEnum(){return c.a.Put}GetPostEnum(){return c.a.Post}GetRatingCurveList(){this.sub=this.ratingcurveService.GetRatingCurveList().subscribe()}DeleteRatingCurve(t){this.sub=this.ratingcurveService.DeleteRatingCurve(t).subscribe()}ngOnInit(){a(this.ratingcurveService.ratingcurveTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(o.Nb(v),o.Nb(n.b),o.Nb(p.a))},t.\u0275cmp=o.Hb({type:t,selectors:[["app-ratingcurve"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"ratingcurve","httpClientCommand"]],template:function(t,e){if(1&t&&(o.xc(0,k,1,0,"mat-progress-bar",0),o.Tb(1,"mat-card"),o.Tb(2,"mat-card-header"),o.Tb(3,"mat-card-title"),o.yc(4," RatingCurve works! "),o.Tb(5,"button",1),o.ac("click",(function(){return e.GetRatingCurveList()})),o.Tb(6,"span"),o.yc(7,"Get RatingCurve"),o.Sb(),o.Sb(),o.Sb(),o.Tb(8,"mat-card-subtitle"),o.yc(9),o.Sb(),o.Sb(),o.Tb(10,"mat-card-content"),o.xc(11,q,2,1,"div",2),o.Sb(),o.Tb(12,"mat-card-actions"),o.Tb(13,"button",3),o.yc(14,"Allo"),o.Sb(),o.Sb(),o.Sb()),2&t){var r;const t=null==(r=e.ratingcurveService.ratingcurveGetModel$.getValue())?null:r.Working;var i;const n=null==(i=e.ratingcurveService.ratingcurveListModel$.getValue())?null:i.length;o.jc("ngIf",t),o.Bb(9),o.zc(e.ratingcurveService.ratingcurveTextModel$.getValue().Title),o.Bb(2),o.jc("ngIf",n)}},directives:[i.l,h.a,h.d,h.g,d.b,h.f,h.c,h.b,m.a,i.k,f.a,G],styles:[""],changeDetection:0}),t})(),canActivate:[r("auXs").a]}];let H=(()=>{class t{}return t.\u0275mod=o.Lb({type:t}),t.\u0275inj=o.Kb({factory:function(e){return new(e||t)},imports:[[n.e.forChild(F)],n.e]}),t})();var A=r("B+Mi");let W=(()=>{class t{}return t.\u0275mod=o.Lb({type:t}),t.\u0275inj=o.Kb({factory:function(e){return new(e||t)},imports:[[i.c,n.e,H,A.a,S.g,S.o]]}),t})()},gkM4:function(t,e,r){"use strict";r.d(e,"a",(function(){return c}));var i=r("QRvi"),n=r("fXoL"),a=r("tyNb");let c=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,r){t.next(null),e.next({Working:!1,Error:r,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,r,n,a){if(n===i.a.Get&&t.next(r),n===i.a.Put&&(t.getValue()[0]=r),n===i.a.Post&&t.getValue().push(r),n===i.a.Delete){const e=t.getValue().indexOf(a);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(n.Xb(a.b))},t.\u0275prov=n.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);