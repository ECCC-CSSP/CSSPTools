(window.webpackJsonp=window.webpackJsonp||[]).push([[57],{QRvi:function(t,n,o){"use strict";o.d(n,"a",(function(){return i}));var i=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},TnRq:function(t,n,o){"use strict";o.r(n),o.d(n,"MapInfoPointModule",(function(){return Z}));var i=o("ofXK"),e=o("tyNb");function a(t){let n={Title:"The title"};"fr-CA"===$localize.locale&&(n.Title="Le Titre"),t.next(n)}var r=o("QRvi"),p=o("fXoL"),c=o("2Vo4"),s=o("LRne"),b=o("tk/3"),f=o("lJxs"),l=o("JIr8"),u=o("gkM4");let m=(()=>{class t{constructor(t,n){this.httpClient=t,this.httpClientService=n,this.mapinfopointTextModel$=new c.a({}),this.mapinfopointListModel$=new c.a({}),this.mapinfopointGetModel$=new c.a({}),this.mapinfopointPutModel$=new c.a({}),this.mapinfopointPostModel$=new c.a({}),this.mapinfopointDeleteModel$=new c.a({}),a(this.mapinfopointTextModel$),this.mapinfopointTextModel$.next({Title:"Something2 for text"})}GetMapInfoPointList(){return this.httpClientService.BeforeHttpClient(this.mapinfopointGetModel$),this.httpClient.get("/api/MapInfoPoint").pipe(Object(f.a)(t=>{this.httpClientService.DoSuccess(this.mapinfopointListModel$,this.mapinfopointGetModel$,t,r.a.Get,null)}),Object(l.a)(t=>Object(s.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.mapinfopointListModel$,this.mapinfopointGetModel$,t)}))))}PutMapInfoPoint(t){return this.httpClientService.BeforeHttpClient(this.mapinfopointPutModel$),this.httpClient.put("/api/MapInfoPoint",t,{headers:new b.d}).pipe(Object(f.a)(n=>{this.httpClientService.DoSuccess(this.mapinfopointListModel$,this.mapinfopointPutModel$,n,r.a.Put,t)}),Object(l.a)(t=>Object(s.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.mapinfopointListModel$,this.mapinfopointPutModel$,t)}))))}PostMapInfoPoint(t){return this.httpClientService.BeforeHttpClient(this.mapinfopointPostModel$),this.httpClient.post("/api/MapInfoPoint",t,{headers:new b.d}).pipe(Object(f.a)(n=>{this.httpClientService.DoSuccess(this.mapinfopointListModel$,this.mapinfopointPostModel$,n,r.a.Post,t)}),Object(l.a)(t=>Object(s.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.mapinfopointListModel$,this.mapinfopointPostModel$,t)}))))}DeleteMapInfoPoint(t){return this.httpClientService.BeforeHttpClient(this.mapinfopointDeleteModel$),this.httpClient.delete("/api/MapInfoPoint/"+t.MapInfoPointID).pipe(Object(f.a)(n=>{this.httpClientService.DoSuccess(this.mapinfopointListModel$,this.mapinfopointDeleteModel$,n,r.a.Delete,t)}),Object(l.a)(t=>Object(s.a)(t).pipe(Object(f.a)(t=>{this.httpClientService.DoCatchError(this.mapinfopointListModel$,this.mapinfopointDeleteModel$,t)}))))}}return t.\u0275fac=function(n){return new(n||t)(p.Xb(b.b),p.Xb(u.a))},t.\u0275prov=p.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var d=o("Wp6s"),h=o("bTqV"),I=o("bv9b"),S=o("NFeN"),T=o("3Pt+"),P=o("kmnG"),g=o("qFsG");function M(t,n){1&t&&p.Ob(0,"mat-progress-bar",11)}function D(t,n){1&t&&p.Ob(0,"mat-progress-bar",11)}function y(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Is Required"),p.Ob(2,"br"),p.Sb())}function C(t,n){if(1&t&&(p.Tb(0,"mat-error"),p.Tb(1,"span"),p.yc(2),p.fc(3,"json"),p.Ob(4,"br"),p.Sb(),p.xc(5,y,3,0,"span",4),p.Sb()),2&t){const t=n.$implicit;p.Bb(2),p.zc(p.gc(3,2,t)),p.Bb(3),p.jc("ngIf",t.required)}}function v(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Is Required"),p.Ob(2,"br"),p.Sb())}function O(t,n){if(1&t&&(p.Tb(0,"mat-error"),p.Tb(1,"span"),p.yc(2),p.fc(3,"json"),p.Ob(4,"br"),p.Sb(),p.xc(5,v,3,0,"span",4),p.Sb()),2&t){const t=n.$implicit;p.Bb(2),p.zc(p.gc(3,2,t)),p.Bb(3),p.jc("ngIf",t.required)}}function B(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Is Required"),p.Ob(2,"br"),p.Sb())}function j(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Min - 0"),p.Ob(2,"br"),p.Sb())}function x(t,n){if(1&t&&(p.Tb(0,"mat-error"),p.Tb(1,"span"),p.yc(2),p.fc(3,"json"),p.Ob(4,"br"),p.Sb(),p.xc(5,B,3,0,"span",4),p.xc(6,j,3,0,"span",4),p.Sb()),2&t){const t=n.$implicit;p.Bb(2),p.zc(p.gc(3,3,t)),p.Bb(3),p.jc("ngIf",t.required),p.Bb(1),p.jc("ngIf",t.min)}}function L(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Is Required"),p.Ob(2,"br"),p.Sb())}function $(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Min - -90"),p.Ob(2,"br"),p.Sb())}function w(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Max - 90"),p.Ob(2,"br"),p.Sb())}function G(t,n){if(1&t&&(p.Tb(0,"mat-error"),p.Tb(1,"span"),p.yc(2),p.fc(3,"json"),p.Ob(4,"br"),p.Sb(),p.xc(5,L,3,0,"span",4),p.xc(6,$,3,0,"span",4),p.xc(7,w,3,0,"span",4),p.Sb()),2&t){const t=n.$implicit;p.Bb(2),p.zc(p.gc(3,4,t)),p.Bb(3),p.jc("ngIf",t.required),p.Bb(1),p.jc("ngIf",t.min),p.Bb(1),p.jc("ngIf",t.min)}}function k(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Is Required"),p.Ob(2,"br"),p.Sb())}function E(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Min - -180"),p.Ob(2,"br"),p.Sb())}function q(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Max - 180"),p.Ob(2,"br"),p.Sb())}function U(t,n){if(1&t&&(p.Tb(0,"mat-error"),p.Tb(1,"span"),p.yc(2),p.fc(3,"json"),p.Ob(4,"br"),p.Sb(),p.xc(5,k,3,0,"span",4),p.xc(6,E,3,0,"span",4),p.xc(7,q,3,0,"span",4),p.Sb()),2&t){const t=n.$implicit;p.Bb(2),p.zc(p.gc(3,4,t)),p.Bb(3),p.jc("ngIf",t.required),p.Bb(1),p.jc("ngIf",t.min),p.Bb(1),p.jc("ngIf",t.min)}}function V(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Is Required"),p.Ob(2,"br"),p.Sb())}function F(t,n){if(1&t&&(p.Tb(0,"mat-error"),p.Tb(1,"span"),p.yc(2),p.fc(3,"json"),p.Ob(4,"br"),p.Sb(),p.xc(5,V,3,0,"span",4),p.Sb()),2&t){const t=n.$implicit;p.Bb(2),p.zc(p.gc(3,2,t)),p.Bb(3),p.jc("ngIf",t.required)}}function R(t,n){1&t&&(p.Tb(0,"span"),p.yc(1,"Is Required"),p.Ob(2,"br"),p.Sb())}function N(t,n){if(1&t&&(p.Tb(0,"mat-error"),p.Tb(1,"span"),p.yc(2),p.fc(3,"json"),p.Ob(4,"br"),p.Sb(),p.xc(5,R,3,0,"span",4),p.Sb()),2&t){const t=n.$implicit;p.Bb(2),p.zc(p.gc(3,2,t)),p.Bb(3),p.jc("ngIf",t.required)}}let A=(()=>{class t{constructor(t,n){this.mapinfopointService=t,this.fb=n,this.mapinfopoint=null,this.httpClientCommand=r.a.Put}GetPut(){return this.httpClientCommand==r.a.Put}PutMapInfoPoint(t){this.sub=this.mapinfopointService.PutMapInfoPoint(t).subscribe()}PostMapInfoPoint(t){this.sub=this.mapinfopointService.PostMapInfoPoint(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.mapinfopoint){let n=this.fb.group({MapInfoPointID:[{value:t===r.a.Post?0:this.mapinfopoint.MapInfoPointID,disabled:!1},[T.p.required]],MapInfoID:[{value:this.mapinfopoint.MapInfoID,disabled:!1},[T.p.required]],Ordinal:[{value:this.mapinfopoint.Ordinal,disabled:!1},[T.p.required,T.p.min(0)]],Lat:[{value:this.mapinfopoint.Lat,disabled:!1},[T.p.required,T.p.min(-90),T.p.max(90)]],Lng:[{value:this.mapinfopoint.Lng,disabled:!1},[T.p.required,T.p.min(-180),T.p.max(180)]],LastUpdateDate_UTC:[{value:this.mapinfopoint.LastUpdateDate_UTC,disabled:!1},[T.p.required]],LastUpdateContactTVItemID:[{value:this.mapinfopoint.LastUpdateContactTVItemID,disabled:!1},[T.p.required]]});this.mapinfopointFormEdit=n}}}return t.\u0275fac=function(n){return new(n||t)(p.Nb(m),p.Nb(T.d))},t.\u0275cmp=p.Hb({type:t,selectors:[["app-mapinfopoint-edit"]],inputs:{mapinfopoint:"mapinfopoint",httpClientCommand:"httpClientCommand"},decls:45,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","MapInfoPointID"],[4,"ngIf"],["matInput","","type","number","formControlName","MapInfoID"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","number","formControlName","Lat"],["matInput","","type","number","formControlName","Lng"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,n){1&t&&(p.Tb(0,"form",0),p.ac("ngSubmit",(function(){return n.GetPut()?n.PutMapInfoPoint(n.mapinfopointFormEdit.value):n.PostMapInfoPoint(n.mapinfopointFormEdit.value)})),p.Tb(1,"h3"),p.yc(2," MapInfoPoint "),p.Tb(3,"button",1),p.Tb(4,"span"),p.yc(5),p.Sb(),p.Sb(),p.xc(6,M,1,0,"mat-progress-bar",2),p.xc(7,D,1,0,"mat-progress-bar",2),p.Sb(),p.Tb(8,"p"),p.Tb(9,"mat-form-field"),p.Tb(10,"mat-label"),p.yc(11,"MapInfoPointID"),p.Sb(),p.Ob(12,"input",3),p.xc(13,C,6,4,"mat-error",4),p.Sb(),p.Tb(14,"mat-form-field"),p.Tb(15,"mat-label"),p.yc(16,"MapInfoID"),p.Sb(),p.Ob(17,"input",5),p.xc(18,O,6,4,"mat-error",4),p.Sb(),p.Tb(19,"mat-form-field"),p.Tb(20,"mat-label"),p.yc(21,"Ordinal"),p.Sb(),p.Ob(22,"input",6),p.xc(23,x,7,5,"mat-error",4),p.Sb(),p.Tb(24,"mat-form-field"),p.Tb(25,"mat-label"),p.yc(26,"Lat"),p.Sb(),p.Ob(27,"input",7),p.xc(28,G,8,6,"mat-error",4),p.Sb(),p.Sb(),p.Tb(29,"p"),p.Tb(30,"mat-form-field"),p.Tb(31,"mat-label"),p.yc(32,"Lng"),p.Sb(),p.Ob(33,"input",8),p.xc(34,U,8,6,"mat-error",4),p.Sb(),p.Tb(35,"mat-form-field"),p.Tb(36,"mat-label"),p.yc(37,"LastUpdateDate_UTC"),p.Sb(),p.Ob(38,"input",9),p.xc(39,F,6,4,"mat-error",4),p.Sb(),p.Tb(40,"mat-form-field"),p.Tb(41,"mat-label"),p.yc(42,"LastUpdateContactTVItemID"),p.Sb(),p.Ob(43,"input",10),p.xc(44,N,6,4,"mat-error",4),p.Sb(),p.Sb(),p.Sb()),2&t&&(p.jc("formGroup",n.mapinfopointFormEdit),p.Bb(5),p.Ac("",n.GetPut()?"Put":"Post"," MapInfoPoint"),p.Bb(1),p.jc("ngIf",n.mapinfopointService.mapinfopointPutModel$.getValue().Working),p.Bb(1),p.jc("ngIf",n.mapinfopointService.mapinfopointPostModel$.getValue().Working),p.Bb(6),p.jc("ngIf",n.mapinfopointFormEdit.controls.MapInfoPointID.errors),p.Bb(5),p.jc("ngIf",n.mapinfopointFormEdit.controls.MapInfoID.errors),p.Bb(5),p.jc("ngIf",n.mapinfopointFormEdit.controls.Ordinal.errors),p.Bb(5),p.jc("ngIf",n.mapinfopointFormEdit.controls.Lat.errors),p.Bb(6),p.jc("ngIf",n.mapinfopointFormEdit.controls.Lng.errors),p.Bb(5),p.jc("ngIf",n.mapinfopointFormEdit.controls.LastUpdateDate_UTC.errors),p.Bb(5),p.jc("ngIf",n.mapinfopointFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[T.q,T.l,T.f,h.b,i.l,P.c,P.f,g.b,T.n,T.c,T.k,T.e,I.a,P.b],pipes:[i.f],styles:[""],changeDetection:0}),t})();function W(t,n){1&t&&p.Ob(0,"mat-progress-bar",4)}function z(t,n){1&t&&p.Ob(0,"mat-progress-bar",4)}function H(t,n){if(1&t&&(p.Tb(0,"p"),p.Ob(1,"app-mapinfopoint-edit",8),p.Sb()),2&t){const t=p.ec().$implicit,n=p.ec(2);p.Bb(1),p.jc("mapinfopoint",t)("httpClientCommand",n.GetPutEnum())}}function X(t,n){if(1&t&&(p.Tb(0,"p"),p.Ob(1,"app-mapinfopoint-edit",8),p.Sb()),2&t){const t=p.ec().$implicit,n=p.ec(2);p.Bb(1),p.jc("mapinfopoint",t)("httpClientCommand",n.GetPostEnum())}}function _(t,n){if(1&t){const t=p.Ub();p.Tb(0,"div"),p.Tb(1,"p"),p.Tb(2,"button",6),p.ac("click",(function(){p.rc(t);const o=n.$implicit;return p.ec(2).DeleteMapInfoPoint(o)})),p.Tb(3,"span"),p.yc(4),p.Sb(),p.Tb(5,"mat-icon"),p.yc(6,"delete"),p.Sb(),p.Sb(),p.yc(7,"\xa0\xa0\xa0 "),p.Tb(8,"button",7),p.ac("click",(function(){p.rc(t);const o=n.$implicit;return p.ec(2).ShowPut(o)})),p.Tb(9,"span"),p.yc(10,"Show Put"),p.Sb(),p.Sb(),p.yc(11,"\xa0\xa0 "),p.Tb(12,"button",7),p.ac("click",(function(){p.rc(t);const o=n.$implicit;return p.ec(2).ShowPost(o)})),p.Tb(13,"span"),p.yc(14,"Show Post"),p.Sb(),p.Sb(),p.yc(15,"\xa0\xa0 "),p.xc(16,z,1,0,"mat-progress-bar",0),p.Sb(),p.xc(17,H,2,2,"p",2),p.xc(18,X,2,2,"p",2),p.Tb(19,"blockquote"),p.Tb(20,"p"),p.Tb(21,"span"),p.yc(22),p.Sb(),p.Tb(23,"span"),p.yc(24),p.Sb(),p.Tb(25,"span"),p.yc(26),p.Sb(),p.Tb(27,"span"),p.yc(28),p.Sb(),p.Sb(),p.Tb(29,"p"),p.Tb(30,"span"),p.yc(31),p.Sb(),p.Tb(32,"span"),p.yc(33),p.Sb(),p.Tb(34,"span"),p.yc(35),p.Sb(),p.Sb(),p.Sb(),p.Sb()}if(2&t){const t=n.$implicit,o=p.ec(2);p.Bb(4),p.Ac("Delete MapInfoPointID [",t.MapInfoPointID,"]\xa0\xa0\xa0"),p.Bb(4),p.jc("color",o.GetPutButtonColor(t)),p.Bb(4),p.jc("color",o.GetPostButtonColor(t)),p.Bb(4),p.jc("ngIf",o.mapinfopointService.mapinfopointDeleteModel$.getValue().Working),p.Bb(1),p.jc("ngIf",o.IDToShow===t.MapInfoPointID&&o.showType===o.GetPutEnum()),p.Bb(1),p.jc("ngIf",o.IDToShow===t.MapInfoPointID&&o.showType===o.GetPostEnum()),p.Bb(4),p.Ac("MapInfoPointID: [",t.MapInfoPointID,"]"),p.Bb(2),p.Ac(" --- MapInfoID: [",t.MapInfoID,"]"),p.Bb(2),p.Ac(" --- Ordinal: [",t.Ordinal,"]"),p.Bb(2),p.Ac(" --- Lat: [",t.Lat,"]"),p.Bb(3),p.Ac("Lng: [",t.Lng,"]"),p.Bb(2),p.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),p.Bb(2),p.Ac(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function J(t,n){if(1&t&&(p.Tb(0,"div"),p.xc(1,_,36,13,"div",5),p.Sb()),2&t){const t=p.ec();p.Bb(1),p.jc("ngForOf",t.mapinfopointService.mapinfopointListModel$.getValue())}}const K=[{path:"",component:(()=>{class t{constructor(t,n,o){this.mapinfopointService=t,this.router=n,this.httpClientService=o,this.showType=null,o.oldURL=n.url}GetPutButtonColor(t){return this.IDToShow===t.MapInfoPointID&&this.showType===r.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.MapInfoPointID&&this.showType===r.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.MapInfoPointID&&this.showType===r.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MapInfoPointID,this.showType=r.a.Put)}ShowPost(t){this.IDToShow===t.MapInfoPointID&&this.showType===r.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MapInfoPointID,this.showType=r.a.Post)}GetPutEnum(){return r.a.Put}GetPostEnum(){return r.a.Post}GetMapInfoPointList(){this.sub=this.mapinfopointService.GetMapInfoPointList().subscribe()}DeleteMapInfoPoint(t){this.sub=this.mapinfopointService.DeleteMapInfoPoint(t).subscribe()}ngOnInit(){a(this.mapinfopointService.mapinfopointTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(n){return new(n||t)(p.Nb(m),p.Nb(e.b),p.Nb(u.a))},t.\u0275cmp=p.Hb({type:t,selectors:[["app-mapinfopoint"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"mapinfopoint","httpClientCommand"]],template:function(t,n){if(1&t&&(p.xc(0,W,1,0,"mat-progress-bar",0),p.Tb(1,"mat-card"),p.Tb(2,"mat-card-header"),p.Tb(3,"mat-card-title"),p.yc(4," MapInfoPoint works! "),p.Tb(5,"button",1),p.ac("click",(function(){return n.GetMapInfoPointList()})),p.Tb(6,"span"),p.yc(7,"Get MapInfoPoint"),p.Sb(),p.Sb(),p.Sb(),p.Tb(8,"mat-card-subtitle"),p.yc(9),p.Sb(),p.Sb(),p.Tb(10,"mat-card-content"),p.xc(11,J,2,1,"div",2),p.Sb(),p.Tb(12,"mat-card-actions"),p.Tb(13,"button",3),p.yc(14,"Allo"),p.Sb(),p.Sb(),p.Sb()),2&t){var o;const t=null==(o=n.mapinfopointService.mapinfopointGetModel$.getValue())?null:o.Working;var i;const e=null==(i=n.mapinfopointService.mapinfopointListModel$.getValue())?null:i.length;p.jc("ngIf",t),p.Bb(9),p.zc(n.mapinfopointService.mapinfopointTextModel$.getValue().Title),p.Bb(2),p.jc("ngIf",e)}},directives:[i.l,d.a,d.d,d.g,h.b,d.f,d.c,d.b,I.a,i.k,S.a,A],styles:[""],changeDetection:0}),t})(),canActivate:[o("auXs").a]}];let Q=(()=>{class t{}return t.\u0275mod=p.Lb({type:t}),t.\u0275inj=p.Kb({factory:function(n){return new(n||t)},imports:[[e.e.forChild(K)],e.e]}),t})();var Y=o("B+Mi");let Z=(()=>{class t{}return t.\u0275mod=p.Lb({type:t}),t.\u0275inj=p.Kb({factory:function(n){return new(n||t)},imports:[[i.c,e.e,Q,Y.a,T.g,T.o]]}),t})()},gkM4:function(t,n,o){"use strict";o.d(n,"a",(function(){return r}));var i=o("QRvi"),e=o("fXoL"),a=o("tyNb");let r=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,n,o){t.next(null),n.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,n,o){t.next(null),n.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,n,o,e,a){if(e===i.a.Get&&t.next(o),e===i.a.Put&&(t.getValue()[0]=o),e===i.a.Post&&t.getValue().push(o),e===i.a.Delete){const n=t.getValue().indexOf(a);t.getValue().splice(n,1)}t.next(t.getValue()),n.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,n,o,e,a){e===i.a.Get&&t.next(o),t.next(t.getValue()),n.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(n){return new(n||t)(e.Xb(a.b))},t.\u0275prov=e.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);