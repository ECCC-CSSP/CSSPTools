(window.webpackJsonp=window.webpackJsonp||[]).push([[87],{QRvi:function(t,e,i){"use strict";i.d(e,"a",(function(){return o}));var o=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},Uvpw:function(t,e,i){"use strict";i.r(e),i.d(e,"TideLocationModule",(function(){return bt}));var o=i("ofXK"),n=i("tyNb");function c(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var a=i("QRvi"),r=i("fXoL"),b=i("2Vo4"),s=i("LRne"),l=i("tk/3"),d=i("lJxs"),u=i("JIr8"),p=i("gkM4");let m=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.tidelocationTextModel$=new b.a({}),this.tidelocationListModel$=new b.a({}),this.tidelocationGetModel$=new b.a({}),this.tidelocationPutModel$=new b.a({}),this.tidelocationPostModel$=new b.a({}),this.tidelocationDeleteModel$=new b.a({}),c(this.tidelocationTextModel$),this.tidelocationTextModel$.next({Title:"Something2 for text"})}GetTideLocationList(){return this.httpClientService.BeforeHttpClient(this.tidelocationGetModel$),this.httpClient.get("/api/TideLocation").pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.tidelocationListModel$,this.tidelocationGetModel$,t,a.a.Get,null)}),Object(u.a)(t=>Object(s.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.tidelocationListModel$,this.tidelocationGetModel$,t)}))))}PutTideLocation(t){return this.httpClientService.BeforeHttpClient(this.tidelocationPutModel$),this.httpClient.put("/api/TideLocation",t,{headers:new l.d}).pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.tidelocationListModel$,this.tidelocationPutModel$,e,a.a.Put,t)}),Object(u.a)(t=>Object(s.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.tidelocationListModel$,this.tidelocationPutModel$,t)}))))}PostTideLocation(t){return this.httpClientService.BeforeHttpClient(this.tidelocationPostModel$),this.httpClient.post("/api/TideLocation",t,{headers:new l.d}).pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.tidelocationListModel$,this.tidelocationPostModel$,e,a.a.Post,t)}),Object(u.a)(t=>Object(s.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.tidelocationListModel$,this.tidelocationPostModel$,t)}))))}DeleteTideLocation(t){return this.httpClientService.BeforeHttpClient(this.tidelocationDeleteModel$),this.httpClient.delete("/api/TideLocation/"+t.TideLocationID).pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.tidelocationListModel$,this.tidelocationDeleteModel$,e,a.a.Delete,t)}),Object(u.a)(t=>Object(s.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.tidelocationListModel$,this.tidelocationDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(r.Xb(l.b),r.Xb(p.a))},t.\u0275prov=r.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var h=i("Wp6s"),T=i("bTqV"),f=i("bv9b"),S=i("NFeN"),g=i("3Pt+"),I=i("kmnG"),L=i("qFsG");function y(t,e){1&t&&r.Ob(0,"mat-progress-bar",13)}function v(t,e){1&t&&r.Ob(0,"mat-progress-bar",13)}function D(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function C(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,D,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function x(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function B(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Min - 0"),r.Ob(2,"br"),r.Sb())}function j(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Max - 10000"),r.Ob(2,"br"),r.Sb())}function O(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,x,3,0,"span",4),r.xc(6,B,3,0,"span",4),r.xc(7,j,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,4,t)),r.Bb(3),r.jc("ngIf",t.required),r.Bb(1),r.jc("ngIf",t.min),r.Bb(1),r.jc("ngIf",t.min)}}function P(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function $(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"MaxLength - 100"),r.Ob(2,"br"),r.Sb())}function M(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,P,3,0,"span",4),r.xc(6,$,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,3,t)),r.Bb(3),r.jc("ngIf",t.required),r.Bb(1),r.jc("ngIf",t.maxlength)}}function w(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function G(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"MaxLength - 100"),r.Ob(2,"br"),r.Sb())}function E(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,w,3,0,"span",4),r.xc(6,G,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,3,t)),r.Bb(3),r.jc("ngIf",t.required),r.Bb(1),r.jc("ngIf",t.maxlength)}}function k(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function q(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Min - 0"),r.Ob(2,"br"),r.Sb())}function U(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Max - 100000"),r.Ob(2,"br"),r.Sb())}function N(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,k,3,0,"span",4),r.xc(6,q,3,0,"span",4),r.xc(7,U,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,4,t)),r.Bb(3),r.jc("ngIf",t.required),r.Bb(1),r.jc("ngIf",t.min),r.Bb(1),r.jc("ngIf",t.min)}}function F(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function V(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Min - -90"),r.Ob(2,"br"),r.Sb())}function R(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Max - 90"),r.Ob(2,"br"),r.Sb())}function A(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,F,3,0,"span",4),r.xc(6,V,3,0,"span",4),r.xc(7,R,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,4,t)),r.Bb(3),r.jc("ngIf",t.required),r.Bb(1),r.jc("ngIf",t.min),r.Bb(1),r.jc("ngIf",t.min)}}function z(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function W(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Min - -180"),r.Ob(2,"br"),r.Sb())}function H(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Max - 180"),r.Ob(2,"br"),r.Sb())}function X(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,z,3,0,"span",4),r.xc(6,W,3,0,"span",4),r.xc(7,H,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,4,t)),r.Bb(3),r.jc("ngIf",t.required),r.Bb(1),r.jc("ngIf",t.min),r.Bb(1),r.jc("ngIf",t.min)}}function Z(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function _(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,Z,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function J(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function K(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,J,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}let Q=(()=>{class t{constructor(t,e){this.tidelocationService=t,this.fb=e,this.tidelocation=null,this.httpClientCommand=a.a.Put}GetPut(){return this.httpClientCommand==a.a.Put}PutTideLocation(t){this.sub=this.tidelocationService.PutTideLocation(t).subscribe()}PostTideLocation(t){this.sub=this.tidelocationService.PostTideLocation(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.tidelocation){let e=this.fb.group({TideLocationID:[{value:t===a.a.Post?0:this.tidelocation.TideLocationID,disabled:!1},[g.p.required]],Zone:[{value:this.tidelocation.Zone,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e4)]],Name:[{value:this.tidelocation.Name,disabled:!1},[g.p.required,g.p.maxLength(100)]],Prov:[{value:this.tidelocation.Prov,disabled:!1},[g.p.required,g.p.maxLength(100)]],sid:[{value:this.tidelocation.sid,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e5)]],Lat:[{value:this.tidelocation.Lat,disabled:!1},[g.p.required,g.p.min(-90),g.p.max(90)]],Lng:[{value:this.tidelocation.Lng,disabled:!1},[g.p.required,g.p.min(-180),g.p.max(180)]],LastUpdateDate_UTC:[{value:this.tidelocation.LastUpdateDate_UTC,disabled:!1},[g.p.required]],LastUpdateContactTVItemID:[{value:this.tidelocation.LastUpdateContactTVItemID,disabled:!1},[g.p.required]]});this.tidelocationFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(r.Nb(m),r.Nb(g.d))},t.\u0275cmp=r.Hb({type:t,selectors:[["app-tidelocation-edit"]],inputs:{tidelocation:"tidelocation",httpClientCommand:"httpClientCommand"},decls:56,vars:13,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TideLocationID"],[4,"ngIf"],["matInput","","type","number","formControlName","Zone"],["matInput","","type","text","formControlName","Name"],["matInput","","type","text","formControlName","Prov"],["matInput","","type","number","formControlName","sid"],["matInput","","type","number","formControlName","Lat"],["matInput","","type","number","formControlName","Lng"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,e){1&t&&(r.Tb(0,"form",0),r.ac("ngSubmit",(function(){return e.GetPut()?e.PutTideLocation(e.tidelocationFormEdit.value):e.PostTideLocation(e.tidelocationFormEdit.value)})),r.Tb(1,"h3"),r.yc(2," TideLocation "),r.Tb(3,"button",1),r.Tb(4,"span"),r.yc(5),r.Sb(),r.Sb(),r.xc(6,y,1,0,"mat-progress-bar",2),r.xc(7,v,1,0,"mat-progress-bar",2),r.Sb(),r.Tb(8,"p"),r.Tb(9,"mat-form-field"),r.Tb(10,"mat-label"),r.yc(11,"TideLocationID"),r.Sb(),r.Ob(12,"input",3),r.xc(13,C,6,4,"mat-error",4),r.Sb(),r.Tb(14,"mat-form-field"),r.Tb(15,"mat-label"),r.yc(16,"Zone"),r.Sb(),r.Ob(17,"input",5),r.xc(18,O,8,6,"mat-error",4),r.Sb(),r.Tb(19,"mat-form-field"),r.Tb(20,"mat-label"),r.yc(21,"Name"),r.Sb(),r.Ob(22,"input",6),r.xc(23,M,7,5,"mat-error",4),r.Sb(),r.Tb(24,"mat-form-field"),r.Tb(25,"mat-label"),r.yc(26,"Prov"),r.Sb(),r.Ob(27,"input",7),r.xc(28,E,7,5,"mat-error",4),r.Sb(),r.Sb(),r.Tb(29,"p"),r.Tb(30,"mat-form-field"),r.Tb(31,"mat-label"),r.yc(32,"sid"),r.Sb(),r.Ob(33,"input",8),r.xc(34,N,8,6,"mat-error",4),r.Sb(),r.Tb(35,"mat-form-field"),r.Tb(36,"mat-label"),r.yc(37,"Lat"),r.Sb(),r.Ob(38,"input",9),r.xc(39,A,8,6,"mat-error",4),r.Sb(),r.Tb(40,"mat-form-field"),r.Tb(41,"mat-label"),r.yc(42,"Lng"),r.Sb(),r.Ob(43,"input",10),r.xc(44,X,8,6,"mat-error",4),r.Sb(),r.Tb(45,"mat-form-field"),r.Tb(46,"mat-label"),r.yc(47,"LastUpdateDate_UTC"),r.Sb(),r.Ob(48,"input",11),r.xc(49,_,6,4,"mat-error",4),r.Sb(),r.Sb(),r.Tb(50,"p"),r.Tb(51,"mat-form-field"),r.Tb(52,"mat-label"),r.yc(53,"LastUpdateContactTVItemID"),r.Sb(),r.Ob(54,"input",12),r.xc(55,K,6,4,"mat-error",4),r.Sb(),r.Sb(),r.Sb()),2&t&&(r.jc("formGroup",e.tidelocationFormEdit),r.Bb(5),r.Ac("",e.GetPut()?"Put":"Post"," TideLocation"),r.Bb(1),r.jc("ngIf",e.tidelocationService.tidelocationPutModel$.getValue().Working),r.Bb(1),r.jc("ngIf",e.tidelocationService.tidelocationPostModel$.getValue().Working),r.Bb(6),r.jc("ngIf",e.tidelocationFormEdit.controls.TideLocationID.errors),r.Bb(5),r.jc("ngIf",e.tidelocationFormEdit.controls.Zone.errors),r.Bb(5),r.jc("ngIf",e.tidelocationFormEdit.controls.Name.errors),r.Bb(5),r.jc("ngIf",e.tidelocationFormEdit.controls.Prov.errors),r.Bb(6),r.jc("ngIf",e.tidelocationFormEdit.controls.sid.errors),r.Bb(5),r.jc("ngIf",e.tidelocationFormEdit.controls.Lat.errors),r.Bb(5),r.jc("ngIf",e.tidelocationFormEdit.controls.Lng.errors),r.Bb(5),r.jc("ngIf",e.tidelocationFormEdit.controls.LastUpdateDate_UTC.errors),r.Bb(6),r.jc("ngIf",e.tidelocationFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[g.q,g.l,g.f,T.b,o.l,I.c,I.f,L.b,g.n,g.c,g.k,g.e,f.a,I.b],pipes:[o.f],styles:[""],changeDetection:0}),t})();function Y(t,e){1&t&&r.Ob(0,"mat-progress-bar",4)}function tt(t,e){1&t&&r.Ob(0,"mat-progress-bar",4)}function et(t,e){if(1&t&&(r.Tb(0,"p"),r.Ob(1,"app-tidelocation-edit",8),r.Sb()),2&t){const t=r.ec().$implicit,e=r.ec(2);r.Bb(1),r.jc("tidelocation",t)("httpClientCommand",e.GetPutEnum())}}function it(t,e){if(1&t&&(r.Tb(0,"p"),r.Ob(1,"app-tidelocation-edit",8),r.Sb()),2&t){const t=r.ec().$implicit,e=r.ec(2);r.Bb(1),r.jc("tidelocation",t)("httpClientCommand",e.GetPostEnum())}}function ot(t,e){if(1&t){const t=r.Ub();r.Tb(0,"div"),r.Tb(1,"p"),r.Tb(2,"button",6),r.ac("click",(function(){r.rc(t);const i=e.$implicit;return r.ec(2).DeleteTideLocation(i)})),r.Tb(3,"span"),r.yc(4),r.Sb(),r.Tb(5,"mat-icon"),r.yc(6,"delete"),r.Sb(),r.Sb(),r.yc(7,"\xa0\xa0\xa0 "),r.Tb(8,"button",7),r.ac("click",(function(){r.rc(t);const i=e.$implicit;return r.ec(2).ShowPut(i)})),r.Tb(9,"span"),r.yc(10,"Show Put"),r.Sb(),r.Sb(),r.yc(11,"\xa0\xa0 "),r.Tb(12,"button",7),r.ac("click",(function(){r.rc(t);const i=e.$implicit;return r.ec(2).ShowPost(i)})),r.Tb(13,"span"),r.yc(14,"Show Post"),r.Sb(),r.Sb(),r.yc(15,"\xa0\xa0 "),r.xc(16,tt,1,0,"mat-progress-bar",0),r.Sb(),r.xc(17,et,2,2,"p",2),r.xc(18,it,2,2,"p",2),r.Tb(19,"blockquote"),r.Tb(20,"p"),r.Tb(21,"span"),r.yc(22),r.Sb(),r.Tb(23,"span"),r.yc(24),r.Sb(),r.Tb(25,"span"),r.yc(26),r.Sb(),r.Tb(27,"span"),r.yc(28),r.Sb(),r.Sb(),r.Tb(29,"p"),r.Tb(30,"span"),r.yc(31),r.Sb(),r.Tb(32,"span"),r.yc(33),r.Sb(),r.Tb(34,"span"),r.yc(35),r.Sb(),r.Tb(36,"span"),r.yc(37),r.Sb(),r.Sb(),r.Tb(38,"p"),r.Tb(39,"span"),r.yc(40),r.Sb(),r.Sb(),r.Sb(),r.Sb()}if(2&t){const t=e.$implicit,i=r.ec(2);r.Bb(4),r.Ac("Delete TideLocationID [",t.TideLocationID,"]\xa0\xa0\xa0"),r.Bb(4),r.jc("color",i.GetPutButtonColor(t)),r.Bb(4),r.jc("color",i.GetPostButtonColor(t)),r.Bb(4),r.jc("ngIf",i.tidelocationService.tidelocationDeleteModel$.getValue().Working),r.Bb(1),r.jc("ngIf",i.IDToShow===t.TideLocationID&&i.showType===i.GetPutEnum()),r.Bb(1),r.jc("ngIf",i.IDToShow===t.TideLocationID&&i.showType===i.GetPostEnum()),r.Bb(4),r.Ac("TideLocationID: [",t.TideLocationID,"]"),r.Bb(2),r.Ac(" --- Zone: [",t.Zone,"]"),r.Bb(2),r.Ac(" --- Name: [",t.Name,"]"),r.Bb(2),r.Ac(" --- Prov: [",t.Prov,"]"),r.Bb(3),r.Ac("sid: [",t.sid,"]"),r.Bb(2),r.Ac(" --- Lat: [",t.Lat,"]"),r.Bb(2),r.Ac(" --- Lng: [",t.Lng,"]"),r.Bb(2),r.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),r.Bb(3),r.Ac("LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function nt(t,e){if(1&t&&(r.Tb(0,"div"),r.xc(1,ot,41,15,"div",5),r.Sb()),2&t){const t=r.ec();r.Bb(1),r.jc("ngForOf",t.tidelocationService.tidelocationListModel$.getValue())}}const ct=[{path:"",component:(()=>{class t{constructor(t,e,i){this.tidelocationService=t,this.router=e,this.httpClientService=i,this.showType=null,i.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.TideLocationID&&this.showType===a.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.TideLocationID&&this.showType===a.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.TideLocationID&&this.showType===a.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TideLocationID,this.showType=a.a.Put)}ShowPost(t){this.IDToShow===t.TideLocationID&&this.showType===a.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TideLocationID,this.showType=a.a.Post)}GetPutEnum(){return a.a.Put}GetPostEnum(){return a.a.Post}GetTideLocationList(){this.sub=this.tidelocationService.GetTideLocationList().subscribe()}DeleteTideLocation(t){this.sub=this.tidelocationService.DeleteTideLocation(t).subscribe()}ngOnInit(){c(this.tidelocationService.tidelocationTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(r.Nb(m),r.Nb(n.b),r.Nb(p.a))},t.\u0275cmp=r.Hb({type:t,selectors:[["app-tidelocation"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tidelocation","httpClientCommand"]],template:function(t,e){if(1&t&&(r.xc(0,Y,1,0,"mat-progress-bar",0),r.Tb(1,"mat-card"),r.Tb(2,"mat-card-header"),r.Tb(3,"mat-card-title"),r.yc(4," TideLocation works! "),r.Tb(5,"button",1),r.ac("click",(function(){return e.GetTideLocationList()})),r.Tb(6,"span"),r.yc(7,"Get TideLocation"),r.Sb(),r.Sb(),r.Sb(),r.Tb(8,"mat-card-subtitle"),r.yc(9),r.Sb(),r.Sb(),r.Tb(10,"mat-card-content"),r.xc(11,nt,2,1,"div",2),r.Sb(),r.Tb(12,"mat-card-actions"),r.Tb(13,"button",3),r.yc(14,"Allo"),r.Sb(),r.Sb(),r.Sb()),2&t){var i;const t=null==(i=e.tidelocationService.tidelocationGetModel$.getValue())?null:i.Working;var o;const n=null==(o=e.tidelocationService.tidelocationListModel$.getValue())?null:o.length;r.jc("ngIf",t),r.Bb(9),r.zc(e.tidelocationService.tidelocationTextModel$.getValue().Title),r.Bb(2),r.jc("ngIf",n)}},directives:[o.l,h.a,h.d,h.g,T.b,h.f,h.c,h.b,f.a,o.k,S.a,Q],styles:[""],changeDetection:0}),t})(),canActivate:[i("auXs").a]}];let at=(()=>{class t{}return t.\u0275mod=r.Lb({type:t}),t.\u0275inj=r.Kb({factory:function(e){return new(e||t)},imports:[[n.e.forChild(ct)],n.e]}),t})();var rt=i("B+Mi");let bt=(()=>{class t{}return t.\u0275mod=r.Lb({type:t}),t.\u0275inj=r.Kb({factory:function(e){return new(e||t)},imports:[[o.c,n.e,at,rt.a,g.g,g.o]]}),t})()},gkM4:function(t,e,i){"use strict";i.d(e,"a",(function(){return a}));var o=i("QRvi"),n=i("fXoL"),c=i("tyNb");let a=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,i,n,c){if(n===o.a.Get&&t.next(i),n===o.a.Put&&(t.getValue()[0]=i),n===o.a.Post&&t.getValue().push(i),n===o.a.Delete){const e=t.getValue().indexOf(c);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,i,n,c){n===o.a.Get&&t.next(i),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(n.Xb(c.b))},t.\u0275prov=n.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);