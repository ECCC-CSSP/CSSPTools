(window.webpackJsonp=window.webpackJsonp||[]).push([[57],{QRvi:function(t,n,i){"use strict";i.d(n,"a",(function(){return o}));var o=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},TnRq:function(t,n,i){"use strict";i.r(n),i.d(n,"MapInfoPointModule",(function(){return Y}));var o=i("ofXK"),e=i("tyNb");function a(t){let n={Title:"The title"};"fr-CA"===$localize.locale&&(n.Title="Le Titre"),t.next(n)}var r=i("QRvi"),p=i("fXoL"),c=i("2Vo4"),s=i("LRne"),b=i("tk/3"),f=i("lJxs"),l=i("JIr8"),u=i("gkM4");let m=(()=>{class t{constructor(t,n){this.httpClient=t,this.httpClientService=n,this.mapinfopointTextModel$=new c.a({}),this.mapinfopointListModel$=new c.a({}),this.mapinfopointGetModel$=new c.a({}),this.mapinfopointPutModel$=new c.a({}),this.mapinfopointPostModel$=new c.a({}),this.mapinfopointDeleteModel$=new c.a({}),a(this.mapinfopointTextModel$),this.mapinfopointTextModel$.next({Title:"Something2 for text"})}GetMapInfoPointList(){return this.httpClientService.BeforeHttpClient(this.mapinfopointGetModel$),this.httpClient.get("/api/MapInfoPoint").pipe(Object(f.a)(t=>{this.httpClientService.DoSuccess(this.mapinfopointListModel$,this.mapinfopointGetModel$,t,r.a.Get,null)}),Object(l.a)(t=>Object(s.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.mapinfopointListModel$,this.mapinfopointGetModel$,t)}))))}PutMapInfoPoint(t){return this.httpClientService.BeforeHttpClient(this.mapinfopointPutModel$),this.httpClient.put("/api/MapInfoPoint",t,{headers:new b.d}).pipe(Object(f.a)(n=>{this.httpClientService.DoSuccess(this.mapinfopointListModel$,this.mapinfopointPutModel$,n,r.a.Put,t)}),Object(l.a)(t=>Object(s.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.mapinfopointListModel$,this.mapinfopointPutModel$,t)}))))}PostMapInfoPoint(t){return this.httpClientService.BeforeHttpClient(this.mapinfopointPostModel$),this.httpClient.post("/api/MapInfoPoint",t,{headers:new b.d}).pipe(Object(f.a)(n=>{this.httpClientService.DoSuccess(this.mapinfopointListModel$,this.mapinfopointPostModel$,n,r.a.Post,t)}),Object(l.a)(t=>Object(s.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.mapinfopointListModel$,this.mapinfopointPostModel$,t)}))))}DeleteMapInfoPoint(t){return this.httpClientService.BeforeHttpClient(this.mapinfopointDeleteModel$),this.httpClient.delete("/api/MapInfoPoint/"+t.MapInfoPointID).pipe(Object(f.a)(n=>{this.httpClientService.DoSuccess(this.mapinfopointListModel$,this.mapinfopointDeleteModel$,n,r.a.Delete,t)}),Object(l.a)(t=>Object(s.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.mapinfopointListModel$,this.mapinfopointDeleteModel$,t)}))))}}return t.\u0275fac=function(n){return new(n||t)(p.Wb(b.b),p.Wb(u.a))},t.\u0275prov=p.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var d=i("Wp6s"),h=i("bTqV"),I=i("bv9b"),S=i("NFeN"),P=i("3Pt+"),M=i("kmnG"),R=i("qFsG");function g(t,n){1&t&&p.Nb(0,"mat-progress-bar",11)}function D(t,n){1&t&&p.Nb(0,"mat-progress-bar",11)}function C(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function B(t,n){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,C,3,0,"span",4),p.Rb()),2&t){const t=n.$implicit;p.Bb(2),p.Ac(p.fc(3,2,t)),p.Bb(3),p.ic("ngIf",t.required)}}function v(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function y(t,n){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,v,3,0,"span",4),p.Rb()),2&t){const t=n.$implicit;p.Bb(2),p.Ac(p.fc(3,2,t)),p.Bb(3),p.ic("ngIf",t.required)}}function L(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function $(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Min - 0"),p.Nb(2,"br"),p.Rb())}function T(t,n){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,L,3,0,"span",4),p.yc(6,$,3,0,"span",4),p.Rb()),2&t){const t=n.$implicit;p.Bb(2),p.Ac(p.fc(3,3,t)),p.Bb(3),p.ic("ngIf",t.required),p.Bb(1),p.ic("ngIf",t.min)}}function w(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function z(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Min - -90"),p.Nb(2,"br"),p.Rb())}function N(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Max - 90"),p.Nb(2,"br"),p.Rb())}function G(t,n){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,w,3,0,"span",4),p.yc(6,z,3,0,"span",4),p.yc(7,N,3,0,"span",4),p.Rb()),2&t){const t=n.$implicit;p.Bb(2),p.Ac(p.fc(3,4,t)),p.Bb(3),p.ic("ngIf",t.required),p.Bb(1),p.ic("ngIf",t.min),p.Bb(1),p.ic("ngIf",t.min)}}function k(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function E(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Min - -180"),p.Nb(2,"br"),p.Rb())}function O(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Max - 180"),p.Nb(2,"br"),p.Rb())}function q(t,n){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,k,3,0,"span",4),p.yc(6,E,3,0,"span",4),p.yc(7,O,3,0,"span",4),p.Rb()),2&t){const t=n.$implicit;p.Bb(2),p.Ac(p.fc(3,4,t)),p.Bb(3),p.ic("ngIf",t.required),p.Bb(1),p.ic("ngIf",t.min),p.Bb(1),p.ic("ngIf",t.min)}}function x(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function j(t,n){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,x,3,0,"span",4),p.Rb()),2&t){const t=n.$implicit;p.Bb(2),p.Ac(p.fc(3,2,t)),p.Bb(3),p.ic("ngIf",t.required)}}function U(t,n){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function V(t,n){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,U,3,0,"span",4),p.Rb()),2&t){const t=n.$implicit;p.Bb(2),p.Ac(p.fc(3,2,t)),p.Bb(3),p.ic("ngIf",t.required)}}let F=(()=>{class t{constructor(t,n){this.mapinfopointService=t,this.fb=n,this.mapinfopoint=null,this.httpClientCommand=r.a.Put}GetPut(){return this.httpClientCommand==r.a.Put}PutMapInfoPoint(t){this.sub=this.mapinfopointService.PutMapInfoPoint(t).subscribe()}PostMapInfoPoint(t){this.sub=this.mapinfopointService.PostMapInfoPoint(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.mapinfopoint){let n=this.fb.group({MapInfoPointID:[{value:t===r.a.Post?0:this.mapinfopoint.MapInfoPointID,disabled:!1},[P.p.required]],MapInfoID:[{value:this.mapinfopoint.MapInfoID,disabled:!1},[P.p.required]],Ordinal:[{value:this.mapinfopoint.Ordinal,disabled:!1},[P.p.required,P.p.min(0)]],Lat:[{value:this.mapinfopoint.Lat,disabled:!1},[P.p.required,P.p.min(-90),P.p.max(90)]],Lng:[{value:this.mapinfopoint.Lng,disabled:!1},[P.p.required,P.p.min(-180),P.p.max(180)]],LastUpdateDate_UTC:[{value:this.mapinfopoint.LastUpdateDate_UTC,disabled:!1},[P.p.required]],LastUpdateContactTVItemID:[{value:this.mapinfopoint.LastUpdateContactTVItemID,disabled:!1},[P.p.required]]});this.mapinfopointFormEdit=n}}}return t.\u0275fac=function(n){return new(n||t)(p.Mb(m),p.Mb(P.d))},t.\u0275cmp=p.Gb({type:t,selectors:[["app-mapinfopoint-edit"]],inputs:{mapinfopoint:"mapinfopoint",httpClientCommand:"httpClientCommand"},decls:45,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","MapInfoPointID"],[4,"ngIf"],["matInput","","type","number","formControlName","MapInfoID"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","number","formControlName","Lat"],["matInput","","type","number","formControlName","Lng"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,n){1&t&&(p.Sb(0,"form",0),p.Zb("ngSubmit",(function(){return n.GetPut()?n.PutMapInfoPoint(n.mapinfopointFormEdit.value):n.PostMapInfoPoint(n.mapinfopointFormEdit.value)})),p.Sb(1,"h3"),p.zc(2," MapInfoPoint "),p.Sb(3,"button",1),p.Sb(4,"span"),p.zc(5),p.Rb(),p.Rb(),p.yc(6,g,1,0,"mat-progress-bar",2),p.yc(7,D,1,0,"mat-progress-bar",2),p.Rb(),p.Sb(8,"p"),p.Sb(9,"mat-form-field"),p.Sb(10,"mat-label"),p.zc(11,"MapInfoPointID"),p.Rb(),p.Nb(12,"input",3),p.yc(13,B,6,4,"mat-error",4),p.Rb(),p.Sb(14,"mat-form-field"),p.Sb(15,"mat-label"),p.zc(16,"MapInfoID"),p.Rb(),p.Nb(17,"input",5),p.yc(18,y,6,4,"mat-error",4),p.Rb(),p.Sb(19,"mat-form-field"),p.Sb(20,"mat-label"),p.zc(21,"Ordinal"),p.Rb(),p.Nb(22,"input",6),p.yc(23,T,7,5,"mat-error",4),p.Rb(),p.Sb(24,"mat-form-field"),p.Sb(25,"mat-label"),p.zc(26,"Lat"),p.Rb(),p.Nb(27,"input",7),p.yc(28,G,8,6,"mat-error",4),p.Rb(),p.Rb(),p.Sb(29,"p"),p.Sb(30,"mat-form-field"),p.Sb(31,"mat-label"),p.zc(32,"Lng"),p.Rb(),p.Nb(33,"input",8),p.yc(34,q,8,6,"mat-error",4),p.Rb(),p.Sb(35,"mat-form-field"),p.Sb(36,"mat-label"),p.zc(37,"LastUpdateDate_UTC"),p.Rb(),p.Nb(38,"input",9),p.yc(39,j,6,4,"mat-error",4),p.Rb(),p.Sb(40,"mat-form-field"),p.Sb(41,"mat-label"),p.zc(42,"LastUpdateContactTVItemID"),p.Rb(),p.Nb(43,"input",10),p.yc(44,V,6,4,"mat-error",4),p.Rb(),p.Rb(),p.Rb()),2&t&&(p.ic("formGroup",n.mapinfopointFormEdit),p.Bb(5),p.Bc("",n.GetPut()?"Put":"Post"," MapInfoPoint"),p.Bb(1),p.ic("ngIf",n.mapinfopointService.mapinfopointPutModel$.getValue().Working),p.Bb(1),p.ic("ngIf",n.mapinfopointService.mapinfopointPostModel$.getValue().Working),p.Bb(6),p.ic("ngIf",n.mapinfopointFormEdit.controls.MapInfoPointID.errors),p.Bb(5),p.ic("ngIf",n.mapinfopointFormEdit.controls.MapInfoID.errors),p.Bb(5),p.ic("ngIf",n.mapinfopointFormEdit.controls.Ordinal.errors),p.Bb(5),p.ic("ngIf",n.mapinfopointFormEdit.controls.Lat.errors),p.Bb(6),p.ic("ngIf",n.mapinfopointFormEdit.controls.Lng.errors),p.Bb(5),p.ic("ngIf",n.mapinfopointFormEdit.controls.LastUpdateDate_UTC.errors),p.Bb(5),p.ic("ngIf",n.mapinfopointFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[P.q,P.l,P.f,h.b,o.l,M.c,M.f,R.b,P.n,P.c,P.k,P.e,I.a,M.b],pipes:[o.f],styles:[""],changeDetection:0}),t})();function W(t,n){1&t&&p.Nb(0,"mat-progress-bar",4)}function A(t,n){1&t&&p.Nb(0,"mat-progress-bar",4)}function _(t,n){if(1&t&&(p.Sb(0,"p"),p.Nb(1,"app-mapinfopoint-edit",8),p.Rb()),2&t){const t=p.dc().$implicit,n=p.dc(2);p.Bb(1),p.ic("mapinfopoint",t)("httpClientCommand",n.GetPutEnum())}}function J(t,n){if(1&t&&(p.Sb(0,"p"),p.Nb(1,"app-mapinfopoint-edit",8),p.Rb()),2&t){const t=p.dc().$implicit,n=p.dc(2);p.Bb(1),p.ic("mapinfopoint",t)("httpClientCommand",n.GetPostEnum())}}function H(t,n){if(1&t){const t=p.Tb();p.Sb(0,"div"),p.Sb(1,"p"),p.Sb(2,"button",6),p.Zb("click",(function(){p.qc(t);const i=n.$implicit;return p.dc(2).DeleteMapInfoPoint(i)})),p.Sb(3,"span"),p.zc(4),p.Rb(),p.Sb(5,"mat-icon"),p.zc(6,"delete"),p.Rb(),p.Rb(),p.zc(7,"\xa0\xa0\xa0 "),p.Sb(8,"button",7),p.Zb("click",(function(){p.qc(t);const i=n.$implicit;return p.dc(2).ShowPut(i)})),p.Sb(9,"span"),p.zc(10,"Show Put"),p.Rb(),p.Rb(),p.zc(11,"\xa0\xa0 "),p.Sb(12,"button",7),p.Zb("click",(function(){p.qc(t);const i=n.$implicit;return p.dc(2).ShowPost(i)})),p.Sb(13,"span"),p.zc(14,"Show Post"),p.Rb(),p.Rb(),p.zc(15,"\xa0\xa0 "),p.yc(16,A,1,0,"mat-progress-bar",0),p.Rb(),p.yc(17,_,2,2,"p",2),p.yc(18,J,2,2,"p",2),p.Sb(19,"blockquote"),p.Sb(20,"p"),p.Sb(21,"span"),p.zc(22),p.Rb(),p.Sb(23,"span"),p.zc(24),p.Rb(),p.Sb(25,"span"),p.zc(26),p.Rb(),p.Sb(27,"span"),p.zc(28),p.Rb(),p.Rb(),p.Sb(29,"p"),p.Sb(30,"span"),p.zc(31),p.Rb(),p.Sb(32,"span"),p.zc(33),p.Rb(),p.Sb(34,"span"),p.zc(35),p.Rb(),p.Rb(),p.Rb(),p.Rb()}if(2&t){const t=n.$implicit,i=p.dc(2);p.Bb(4),p.Bc("Delete MapInfoPointID [",t.MapInfoPointID,"]\xa0\xa0\xa0"),p.Bb(4),p.ic("color",i.GetPutButtonColor(t)),p.Bb(4),p.ic("color",i.GetPostButtonColor(t)),p.Bb(4),p.ic("ngIf",i.mapinfopointService.mapinfopointDeleteModel$.getValue().Working),p.Bb(1),p.ic("ngIf",i.IDToShow===t.MapInfoPointID&&i.showType===i.GetPutEnum()),p.Bb(1),p.ic("ngIf",i.IDToShow===t.MapInfoPointID&&i.showType===i.GetPostEnum()),p.Bb(4),p.Bc("MapInfoPointID: [",t.MapInfoPointID,"]"),p.Bb(2),p.Bc(" --- MapInfoID: [",t.MapInfoID,"]"),p.Bb(2),p.Bc(" --- Ordinal: [",t.Ordinal,"]"),p.Bb(2),p.Bc(" --- Lat: [",t.Lat,"]"),p.Bb(3),p.Bc("Lng: [",t.Lng,"]"),p.Bb(2),p.Bc(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),p.Bb(2),p.Bc(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function Z(t,n){if(1&t&&(p.Sb(0,"div"),p.yc(1,H,36,13,"div",5),p.Rb()),2&t){const t=p.dc();p.Bb(1),p.ic("ngForOf",t.mapinfopointService.mapinfopointListModel$.getValue())}}const X=[{path:"",component:(()=>{class t{constructor(t,n,i){this.mapinfopointService=t,this.router=n,this.httpClientService=i,this.showType=null,i.oldURL=n.url}GetPutButtonColor(t){return this.IDToShow===t.MapInfoPointID&&this.showType===r.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.MapInfoPointID&&this.showType===r.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.MapInfoPointID&&this.showType===r.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MapInfoPointID,this.showType=r.a.Put)}ShowPost(t){this.IDToShow===t.MapInfoPointID&&this.showType===r.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MapInfoPointID,this.showType=r.a.Post)}GetPutEnum(){return r.a.Put}GetPostEnum(){return r.a.Post}GetMapInfoPointList(){this.sub=this.mapinfopointService.GetMapInfoPointList().subscribe()}DeleteMapInfoPoint(t){this.sub=this.mapinfopointService.DeleteMapInfoPoint(t).subscribe()}ngOnInit(){a(this.mapinfopointService.mapinfopointTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(n){return new(n||t)(p.Mb(m),p.Mb(e.b),p.Mb(u.a))},t.\u0275cmp=p.Gb({type:t,selectors:[["app-mapinfopoint"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"mapinfopoint","httpClientCommand"]],template:function(t,n){if(1&t&&(p.yc(0,W,1,0,"mat-progress-bar",0),p.Sb(1,"mat-card"),p.Sb(2,"mat-card-header"),p.Sb(3,"mat-card-title"),p.zc(4," MapInfoPoint works! "),p.Sb(5,"button",1),p.Zb("click",(function(){return n.GetMapInfoPointList()})),p.Sb(6,"span"),p.zc(7,"Get MapInfoPoint"),p.Rb(),p.Rb(),p.Rb(),p.Sb(8,"mat-card-subtitle"),p.zc(9),p.Rb(),p.Rb(),p.Sb(10,"mat-card-content"),p.yc(11,Z,2,1,"div",2),p.Rb(),p.Sb(12,"mat-card-actions"),p.Sb(13,"button",3),p.zc(14,"Allo"),p.Rb(),p.Rb(),p.Rb()),2&t){var i;const t=null==(i=n.mapinfopointService.mapinfopointGetModel$.getValue())?null:i.Working;var o;const e=null==(o=n.mapinfopointService.mapinfopointListModel$.getValue())?null:o.length;p.ic("ngIf",t),p.Bb(9),p.Ac(n.mapinfopointService.mapinfopointTextModel$.getValue().Title),p.Bb(2),p.ic("ngIf",e)}},directives:[o.l,d.a,d.d,d.g,h.b,d.f,d.c,d.b,I.a,o.k,S.a,F],styles:[""],changeDetection:0}),t})(),canActivate:[i("auXs").a]}];let K=(()=>{class t{}return t.\u0275mod=p.Kb({type:t}),t.\u0275inj=p.Jb({factory:function(n){return new(n||t)},imports:[[e.e.forChild(X)],e.e]}),t})();var Q=i("B+Mi");let Y=(()=>{class t{}return t.\u0275mod=p.Kb({type:t}),t.\u0275inj=p.Jb({factory:function(n){return new(n||t)},imports:[[o.c,e.e,K,Q.a,P.g,P.o]]}),t})()},gkM4:function(t,n,i){"use strict";i.d(n,"a",(function(){return r}));var o=i("QRvi"),e=i("fXoL"),a=i("tyNb");let r=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,n,i){t.next(null),n.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,n,i){t.next(null),n.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,n,i,e,a){if(e===o.a.Get&&t.next(i),e===o.a.Put&&(t.getValue()[0]=i),e===o.a.Post&&t.getValue().push(i),e===o.a.Delete){const n=t.getValue().indexOf(a);t.getValue().splice(n,1)}t.next(t.getValue()),n.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,n,i,e,a){e===o.a.Get&&t.next(i),t.next(t.getValue()),n.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(n){return new(n||t)(e.Wb(a.b))},t.\u0275prov=e.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);