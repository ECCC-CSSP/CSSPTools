(window.webpackJsonp=window.webpackJsonp||[]).push([[69],{Hqkm:function(o,t,e){"use strict";e.r(t),e.d(t,"PolSourceGroupingModule",(function(){return Z}));var r=e("ofXK"),i=e("tyNb");function n(o){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),o.next(t)}var c=e("QRvi"),u=e("fXoL"),s=e("2Vo4"),p=e("LRne"),l=e("tk/3"),a=e("lJxs"),b=e("JIr8"),g=e("gkM4");let h=(()=>{class o{constructor(o,t){this.httpClient=o,this.httpClientService=t,this.polsourcegroupingTextModel$=new s.a({}),this.polsourcegroupingListModel$=new s.a({}),this.polsourcegroupingGetModel$=new s.a({}),this.polsourcegroupingPutModel$=new s.a({}),this.polsourcegroupingPostModel$=new s.a({}),this.polsourcegroupingDeleteModel$=new s.a({}),n(this.polsourcegroupingTextModel$),this.polsourcegroupingTextModel$.next({Title:"Something2 for text"})}GetPolSourceGroupingList(){return this.httpClientService.BeforeHttpClient(this.polsourcegroupingGetModel$),this.httpClient.get("/api/PolSourceGrouping").pipe(Object(a.a)(o=>{this.httpClientService.DoSuccess(this.polsourcegroupingListModel$,this.polsourcegroupingGetModel$,o,c.a.Get,null)}),Object(b.a)(o=>Object(p.a)(o).pipe(Object(a.a)(o=>{this.httpClientService.DoCatchError(this.polsourcegroupingListModel$,this.polsourcegroupingGetModel$,o)}))))}PutPolSourceGrouping(o){return this.httpClientService.BeforeHttpClient(this.polsourcegroupingPutModel$),this.httpClient.put("/api/PolSourceGrouping",o,{headers:new l.d}).pipe(Object(a.a)(t=>{this.httpClientService.DoSuccess(this.polsourcegroupingListModel$,this.polsourcegroupingPutModel$,t,c.a.Put,o)}),Object(b.a)(o=>Object(p.a)(o).pipe(Object(a.a)(o=>{this.httpClientService.DoCatchError(this.polsourcegroupingListModel$,this.polsourcegroupingPutModel$,o)}))))}PostPolSourceGrouping(o){return this.httpClientService.BeforeHttpClient(this.polsourcegroupingPostModel$),this.httpClient.post("/api/PolSourceGrouping",o,{headers:new l.d}).pipe(Object(a.a)(t=>{this.httpClientService.DoSuccess(this.polsourcegroupingListModel$,this.polsourcegroupingPostModel$,t,c.a.Post,o)}),Object(b.a)(o=>Object(p.a)(o).pipe(Object(a.a)(o=>{this.httpClientService.DoCatchError(this.polsourcegroupingListModel$,this.polsourcegroupingPostModel$,o)}))))}DeletePolSourceGrouping(o){return this.httpClientService.BeforeHttpClient(this.polsourcegroupingDeleteModel$),this.httpClient.delete("/api/PolSourceGrouping/"+o.PolSourceGroupingID).pipe(Object(a.a)(t=>{this.httpClientService.DoSuccess(this.polsourcegroupingListModel$,this.polsourcegroupingDeleteModel$,t,c.a.Delete,o)}),Object(b.a)(o=>Object(p.a)(o).pipe(Object(a.a)(o=>{this.httpClientService.DoCatchError(this.polsourcegroupingListModel$,this.polsourcegroupingDeleteModel$,o)}))))}}return o.\u0275fac=function(t){return new(t||o)(u.Xb(l.b),u.Xb(g.a))},o.\u0275prov=u.Jb({token:o,factory:o.\u0275fac,providedIn:"root"}),o})();var S=e("Wp6s"),d=e("bTqV"),m=e("bv9b"),f=e("NFeN"),T=e("3Pt+"),P=e("kmnG"),I=e("qFsG");function C(o,t){1&o&&u.Ob(0,"mat-progress-bar",11)}function D(o,t){1&o&&u.Ob(0,"mat-progress-bar",11)}function G(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function y(o,t){if(1&o&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,G,3,0,"span",4),u.Sb()),2&o){const o=t.$implicit;u.Bb(2),u.zc(u.gc(3,2,o)),u.Bb(3),u.jc("ngIf",o.required)}}function v(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function x(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"Min - 10000"),u.Ob(2,"br"),u.Sb())}function B(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"Max - 100000"),u.Ob(2,"br"),u.Sb())}function j(o,t){if(1&o&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,v,3,0,"span",4),u.xc(6,x,3,0,"span",4),u.xc(7,B,3,0,"span",4),u.Sb()),2&o){const o=t.$implicit;u.Bb(2),u.zc(u.gc(3,4,o)),u.Bb(3),u.jc("ngIf",o.required),u.Bb(1),u.jc("ngIf",o.min),u.Bb(1),u.jc("ngIf",o.min)}}function O(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function $(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"MaxLength - 500"),u.Ob(2,"br"),u.Sb())}function w(o,t){if(1&o&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,O,3,0,"span",4),u.xc(6,$,3,0,"span",4),u.Sb()),2&o){const o=t.$implicit;u.Bb(2),u.zc(u.gc(3,3,o)),u.Bb(3),u.jc("ngIf",o.required),u.Bb(1),u.jc("ngIf",o.maxlength)}}function L(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function M(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"MaxLength - 500"),u.Ob(2,"br"),u.Sb())}function k(o,t){if(1&o&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,L,3,0,"span",4),u.xc(6,M,3,0,"span",4),u.Sb()),2&o){const o=t.$implicit;u.Bb(2),u.zc(u.gc(3,3,o)),u.Bb(3),u.jc("ngIf",o.required),u.Bb(1),u.jc("ngIf",o.maxlength)}}function E(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function q(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"MaxLength - 500"),u.Ob(2,"br"),u.Sb())}function U(o,t){if(1&o&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,E,3,0,"span",4),u.xc(6,q,3,0,"span",4),u.Sb()),2&o){const o=t.$implicit;u.Bb(2),u.zc(u.gc(3,3,o)),u.Bb(3),u.jc("ngIf",o.required),u.Bb(1),u.jc("ngIf",o.maxlength)}}function N(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function V(o,t){if(1&o&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,N,3,0,"span",4),u.Sb()),2&o){const o=t.$implicit;u.Bb(2),u.zc(u.gc(3,2,o)),u.Bb(3),u.jc("ngIf",o.required)}}function F(o,t){1&o&&(u.Tb(0,"span"),u.yc(1,"Is Required"),u.Ob(2,"br"),u.Sb())}function R(o,t){if(1&o&&(u.Tb(0,"mat-error"),u.Tb(1,"span"),u.yc(2),u.fc(3,"json"),u.Ob(4,"br"),u.Sb(),u.xc(5,F,3,0,"span",4),u.Sb()),2&o){const o=t.$implicit;u.Bb(2),u.zc(u.gc(3,2,o)),u.Bb(3),u.jc("ngIf",o.required)}}let H=(()=>{class o{constructor(o,t){this.polsourcegroupingService=o,this.fb=t,this.polsourcegrouping=null,this.httpClientCommand=c.a.Put}GetPut(){return this.httpClientCommand==c.a.Put}PutPolSourceGrouping(o){this.sub=this.polsourcegroupingService.PutPolSourceGrouping(o).subscribe()}PostPolSourceGrouping(o){this.sub=this.polsourcegroupingService.PostPolSourceGrouping(o).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var o;null===(o=this.sub)||void 0===o||o.unsubscribe()}FillFormBuilderGroup(o){if(this.polsourcegrouping){let t=this.fb.group({PolSourceGroupingID:[{value:o===c.a.Post?0:this.polsourcegrouping.PolSourceGroupingID,disabled:!1},[T.p.required]],CSSPID:[{value:this.polsourcegrouping.CSSPID,disabled:!1},[T.p.required,T.p.min(1e4),T.p.max(1e5)]],GroupName:[{value:this.polsourcegrouping.GroupName,disabled:!1},[T.p.required,T.p.maxLength(500)]],Child:[{value:this.polsourcegrouping.Child,disabled:!1},[T.p.required,T.p.maxLength(500)]],Hide:[{value:this.polsourcegrouping.Hide,disabled:!1},[T.p.required,T.p.maxLength(500)]],LastUpdateDate_UTC:[{value:this.polsourcegrouping.LastUpdateDate_UTC,disabled:!1},[T.p.required]],LastUpdateContactTVItemID:[{value:this.polsourcegrouping.LastUpdateContactTVItemID,disabled:!1},[T.p.required]]});this.polsourcegroupingFormEdit=t}}}return o.\u0275fac=function(t){return new(t||o)(u.Nb(h),u.Nb(T.d))},o.\u0275cmp=u.Hb({type:o,selectors:[["app-polsourcegrouping-edit"]],inputs:{polsourcegrouping:"polsourcegrouping",httpClientCommand:"httpClientCommand"},decls:45,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","PolSourceGroupingID"],[4,"ngIf"],["matInput","","type","number","formControlName","CSSPID"],["matInput","","type","text","formControlName","GroupName"],["matInput","","type","text","formControlName","Child"],["matInput","","type","text","formControlName","Hide"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(o,t){1&o&&(u.Tb(0,"form",0),u.ac("ngSubmit",(function(){return t.GetPut()?t.PutPolSourceGrouping(t.polsourcegroupingFormEdit.value):t.PostPolSourceGrouping(t.polsourcegroupingFormEdit.value)})),u.Tb(1,"h3"),u.yc(2," PolSourceGrouping "),u.Tb(3,"button",1),u.Tb(4,"span"),u.yc(5),u.Sb(),u.Sb(),u.xc(6,C,1,0,"mat-progress-bar",2),u.xc(7,D,1,0,"mat-progress-bar",2),u.Sb(),u.Tb(8,"p"),u.Tb(9,"mat-form-field"),u.Tb(10,"mat-label"),u.yc(11,"PolSourceGroupingID"),u.Sb(),u.Ob(12,"input",3),u.xc(13,y,6,4,"mat-error",4),u.Sb(),u.Tb(14,"mat-form-field"),u.Tb(15,"mat-label"),u.yc(16,"CSSPID"),u.Sb(),u.Ob(17,"input",5),u.xc(18,j,8,6,"mat-error",4),u.Sb(),u.Tb(19,"mat-form-field"),u.Tb(20,"mat-label"),u.yc(21,"GroupName"),u.Sb(),u.Ob(22,"input",6),u.xc(23,w,7,5,"mat-error",4),u.Sb(),u.Tb(24,"mat-form-field"),u.Tb(25,"mat-label"),u.yc(26,"Child"),u.Sb(),u.Ob(27,"input",7),u.xc(28,k,7,5,"mat-error",4),u.Sb(),u.Sb(),u.Tb(29,"p"),u.Tb(30,"mat-form-field"),u.Tb(31,"mat-label"),u.yc(32,"Hide"),u.Sb(),u.Ob(33,"input",8),u.xc(34,U,7,5,"mat-error",4),u.Sb(),u.Tb(35,"mat-form-field"),u.Tb(36,"mat-label"),u.yc(37,"LastUpdateDate_UTC"),u.Sb(),u.Ob(38,"input",9),u.xc(39,V,6,4,"mat-error",4),u.Sb(),u.Tb(40,"mat-form-field"),u.Tb(41,"mat-label"),u.yc(42,"LastUpdateContactTVItemID"),u.Sb(),u.Ob(43,"input",10),u.xc(44,R,6,4,"mat-error",4),u.Sb(),u.Sb(),u.Sb()),2&o&&(u.jc("formGroup",t.polsourcegroupingFormEdit),u.Bb(5),u.Ac("",t.GetPut()?"Put":"Post"," PolSourceGrouping"),u.Bb(1),u.jc("ngIf",t.polsourcegroupingService.polsourcegroupingPutModel$.getValue().Working),u.Bb(1),u.jc("ngIf",t.polsourcegroupingService.polsourcegroupingPostModel$.getValue().Working),u.Bb(6),u.jc("ngIf",t.polsourcegroupingFormEdit.controls.PolSourceGroupingID.errors),u.Bb(5),u.jc("ngIf",t.polsourcegroupingFormEdit.controls.CSSPID.errors),u.Bb(5),u.jc("ngIf",t.polsourcegroupingFormEdit.controls.GroupName.errors),u.Bb(5),u.jc("ngIf",t.polsourcegroupingFormEdit.controls.Child.errors),u.Bb(6),u.jc("ngIf",t.polsourcegroupingFormEdit.controls.Hide.errors),u.Bb(5),u.jc("ngIf",t.polsourcegroupingFormEdit.controls.LastUpdateDate_UTC.errors),u.Bb(5),u.jc("ngIf",t.polsourcegroupingFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[T.q,T.l,T.f,d.b,r.l,P.c,P.f,I.b,T.n,T.c,T.k,T.e,m.a,P.b],pipes:[r.f],styles:[""],changeDetection:0}),o})();function A(o,t){1&o&&u.Ob(0,"mat-progress-bar",4)}function W(o,t){1&o&&u.Ob(0,"mat-progress-bar",4)}function z(o,t){if(1&o&&(u.Tb(0,"p"),u.Ob(1,"app-polsourcegrouping-edit",8),u.Sb()),2&o){const o=u.ec().$implicit,t=u.ec(2);u.Bb(1),u.jc("polsourcegrouping",o)("httpClientCommand",t.GetPutEnum())}}function X(o,t){if(1&o&&(u.Tb(0,"p"),u.Ob(1,"app-polsourcegrouping-edit",8),u.Sb()),2&o){const o=u.ec().$implicit,t=u.ec(2);u.Bb(1),u.jc("polsourcegrouping",o)("httpClientCommand",t.GetPostEnum())}}function _(o,t){if(1&o){const o=u.Ub();u.Tb(0,"div"),u.Tb(1,"p"),u.Tb(2,"button",6),u.ac("click",(function(){u.rc(o);const e=t.$implicit;return u.ec(2).DeletePolSourceGrouping(e)})),u.Tb(3,"span"),u.yc(4),u.Sb(),u.Tb(5,"mat-icon"),u.yc(6,"delete"),u.Sb(),u.Sb(),u.yc(7,"\xa0\xa0\xa0 "),u.Tb(8,"button",7),u.ac("click",(function(){u.rc(o);const e=t.$implicit;return u.ec(2).ShowPut(e)})),u.Tb(9,"span"),u.yc(10,"Show Put"),u.Sb(),u.Sb(),u.yc(11,"\xa0\xa0 "),u.Tb(12,"button",7),u.ac("click",(function(){u.rc(o);const e=t.$implicit;return u.ec(2).ShowPost(e)})),u.Tb(13,"span"),u.yc(14,"Show Post"),u.Sb(),u.Sb(),u.yc(15,"\xa0\xa0 "),u.xc(16,W,1,0,"mat-progress-bar",0),u.Sb(),u.xc(17,z,2,2,"p",2),u.xc(18,X,2,2,"p",2),u.Tb(19,"blockquote"),u.Tb(20,"p"),u.Tb(21,"span"),u.yc(22),u.Sb(),u.Tb(23,"span"),u.yc(24),u.Sb(),u.Tb(25,"span"),u.yc(26),u.Sb(),u.Tb(27,"span"),u.yc(28),u.Sb(),u.Sb(),u.Tb(29,"p"),u.Tb(30,"span"),u.yc(31),u.Sb(),u.Tb(32,"span"),u.yc(33),u.Sb(),u.Tb(34,"span"),u.yc(35),u.Sb(),u.Sb(),u.Sb(),u.Sb()}if(2&o){const o=t.$implicit,e=u.ec(2);u.Bb(4),u.Ac("Delete PolSourceGroupingID [",o.PolSourceGroupingID,"]\xa0\xa0\xa0"),u.Bb(4),u.jc("color",e.GetPutButtonColor(o)),u.Bb(4),u.jc("color",e.GetPostButtonColor(o)),u.Bb(4),u.jc("ngIf",e.polsourcegroupingService.polsourcegroupingDeleteModel$.getValue().Working),u.Bb(1),u.jc("ngIf",e.IDToShow===o.PolSourceGroupingID&&e.showType===e.GetPutEnum()),u.Bb(1),u.jc("ngIf",e.IDToShow===o.PolSourceGroupingID&&e.showType===e.GetPostEnum()),u.Bb(4),u.Ac("PolSourceGroupingID: [",o.PolSourceGroupingID,"]"),u.Bb(2),u.Ac(" --- CSSPID: [",o.CSSPID,"]"),u.Bb(2),u.Ac(" --- GroupName: [",o.GroupName,"]"),u.Bb(2),u.Ac(" --- Child: [",o.Child,"]"),u.Bb(3),u.Ac("Hide: [",o.Hide,"]"),u.Bb(2),u.Ac(" --- LastUpdateDate_UTC: [",o.LastUpdateDate_UTC,"]"),u.Bb(2),u.Ac(" --- LastUpdateContactTVItemID: [",o.LastUpdateContactTVItemID,"]")}}function J(o,t){if(1&o&&(u.Tb(0,"div"),u.xc(1,_,36,13,"div",5),u.Sb()),2&o){const o=u.ec();u.Bb(1),u.jc("ngForOf",o.polsourcegroupingService.polsourcegroupingListModel$.getValue())}}const K=[{path:"",component:(()=>{class o{constructor(o,t,e){this.polsourcegroupingService=o,this.router=t,this.httpClientService=e,this.showType=null,e.oldURL=t.url}GetPutButtonColor(o){return this.IDToShow===o.PolSourceGroupingID&&this.showType===c.a.Put?"primary":"basic"}GetPostButtonColor(o){return this.IDToShow===o.PolSourceGroupingID&&this.showType===c.a.Post?"primary":"basic"}ShowPut(o){this.IDToShow===o.PolSourceGroupingID&&this.showType===c.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=o.PolSourceGroupingID,this.showType=c.a.Put)}ShowPost(o){this.IDToShow===o.PolSourceGroupingID&&this.showType===c.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=o.PolSourceGroupingID,this.showType=c.a.Post)}GetPutEnum(){return c.a.Put}GetPostEnum(){return c.a.Post}GetPolSourceGroupingList(){this.sub=this.polsourcegroupingService.GetPolSourceGroupingList().subscribe()}DeletePolSourceGrouping(o){this.sub=this.polsourcegroupingService.DeletePolSourceGrouping(o).subscribe()}ngOnInit(){n(this.polsourcegroupingService.polsourcegroupingTextModel$)}ngOnDestroy(){var o;null===(o=this.sub)||void 0===o||o.unsubscribe()}}return o.\u0275fac=function(t){return new(t||o)(u.Nb(h),u.Nb(i.b),u.Nb(g.a))},o.\u0275cmp=u.Hb({type:o,selectors:[["app-polsourcegrouping"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"polsourcegrouping","httpClientCommand"]],template:function(o,t){if(1&o&&(u.xc(0,A,1,0,"mat-progress-bar",0),u.Tb(1,"mat-card"),u.Tb(2,"mat-card-header"),u.Tb(3,"mat-card-title"),u.yc(4," PolSourceGrouping works! "),u.Tb(5,"button",1),u.ac("click",(function(){return t.GetPolSourceGroupingList()})),u.Tb(6,"span"),u.yc(7,"Get PolSourceGrouping"),u.Sb(),u.Sb(),u.Sb(),u.Tb(8,"mat-card-subtitle"),u.yc(9),u.Sb(),u.Sb(),u.Tb(10,"mat-card-content"),u.xc(11,J,2,1,"div",2),u.Sb(),u.Tb(12,"mat-card-actions"),u.Tb(13,"button",3),u.yc(14,"Allo"),u.Sb(),u.Sb(),u.Sb()),2&o){var e;const o=null==(e=t.polsourcegroupingService.polsourcegroupingGetModel$.getValue())?null:e.Working;var r;const i=null==(r=t.polsourcegroupingService.polsourcegroupingListModel$.getValue())?null:r.length;u.jc("ngIf",o),u.Bb(9),u.zc(t.polsourcegroupingService.polsourcegroupingTextModel$.getValue().Title),u.Bb(2),u.jc("ngIf",i)}},directives:[r.l,S.a,S.d,S.g,d.b,S.f,S.c,S.b,m.a,r.k,f.a,H],styles:[""],changeDetection:0}),o})(),canActivate:[e("auXs").a]}];let Q=(()=>{class o{}return o.\u0275mod=u.Lb({type:o}),o.\u0275inj=u.Kb({factory:function(t){return new(t||o)},imports:[[i.e.forChild(K)],i.e]}),o})();var Y=e("B+Mi");let Z=(()=>{class o{}return o.\u0275mod=u.Lb({type:o}),o.\u0275inj=u.Kb({factory:function(t){return new(t||o)},imports:[[r.c,i.e,Q,Y.a,T.g,T.o]]}),o})()},QRvi:function(o,t,e){"use strict";e.d(t,"a",(function(){return r}));var r=function(o){return o[o.Get=1]="Get",o[o.Put=2]="Put",o[o.Post=3]="Post",o[o.Delete=4]="Delete",o}({})},gkM4:function(o,t,e){"use strict";e.d(t,"a",(function(){return c}));var r=e("QRvi"),i=e("fXoL"),n=e("tyNb");let c=(()=>{class o{constructor(o){this.router=o,this.oldURL=o.url}BeforeHttpClient(o){o.next({Working:!0,Error:null,Status:null})}DoCatchError(o,t,e){o.next(null),t.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(o,t,e){o.next(null),t.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(o,t,e,i,n){if(i===r.a.Get&&o.next(e),i===r.a.Put&&(o.getValue()[0]=e),i===r.a.Post&&o.getValue().push(e),i===r.a.Delete){const t=o.getValue().indexOf(n);o.getValue().splice(t,1)}o.next(o.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(o,t,e,i,n){i===r.a.Get&&o.next(e),o.next(o.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return o.\u0275fac=function(t){return new(t||o)(i.Xb(n.b))},o.\u0275prov=i.Jb({token:o,factory:o.\u0275fac,providedIn:"root"}),o})()}}]);