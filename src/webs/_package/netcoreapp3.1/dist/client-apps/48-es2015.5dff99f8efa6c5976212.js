(window.webpackJsonp=window.webpackJsonp||[]).push([[48],{FaSq:function(t,i,e){"use strict";e.r(i),e.d(i,"EmailDistributionListModule",(function(){return H}));var s=e("ofXK"),n=e("tyNb");function o(t){let i={Title:"The title"};"fr-CA"===$localize.locale&&(i.Title="Le Titre"),t.next(i)}var r=e("QRvi"),l=e("fXoL"),a=e("2Vo4"),b=e("LRne"),u=e("tk/3"),c=e("lJxs"),m=e("JIr8"),d=e("gkM4");let p=(()=>{class t{constructor(t,i){this.httpClient=t,this.httpClientService=i,this.emaildistributionlistTextModel$=new a.a({}),this.emaildistributionlistListModel$=new a.a({}),this.emaildistributionlistGetModel$=new a.a({}),this.emaildistributionlistPutModel$=new a.a({}),this.emaildistributionlistPostModel$=new a.a({}),this.emaildistributionlistDeleteModel$=new a.a({}),o(this.emaildistributionlistTextModel$),this.emaildistributionlistTextModel$.next({Title:"Something2 for text"})}GetEmailDistributionListList(){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistGetModel$),this.httpClient.get("/api/EmailDistributionList").pipe(Object(c.a)(t=>{this.httpClientService.DoSuccess(this.emaildistributionlistListModel$,this.emaildistributionlistGetModel$,t,r.a.Get,null)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(c.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistListModel$,this.emaildistributionlistGetModel$,t)}))))}PutEmailDistributionList(t){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistPutModel$),this.httpClient.put("/api/EmailDistributionList",t,{headers:new u.d}).pipe(Object(c.a)(i=>{this.httpClientService.DoSuccess(this.emaildistributionlistListModel$,this.emaildistributionlistPutModel$,i,r.a.Put,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(c.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistListModel$,this.emaildistributionlistPutModel$,t)}))))}PostEmailDistributionList(t){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistPostModel$),this.httpClient.post("/api/EmailDistributionList",t,{headers:new u.d}).pipe(Object(c.a)(i=>{this.httpClientService.DoSuccess(this.emaildistributionlistListModel$,this.emaildistributionlistPostModel$,i,r.a.Post,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(c.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistListModel$,this.emaildistributionlistPostModel$,t)}))))}DeleteEmailDistributionList(t){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistDeleteModel$),this.httpClient.delete("/api/EmailDistributionList/"+t.EmailDistributionListID).pipe(Object(c.a)(i=>{this.httpClientService.DoSuccess(this.emaildistributionlistListModel$,this.emaildistributionlistDeleteModel$,i,r.a.Delete,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(c.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistListModel$,this.emaildistributionlistDeleteModel$,t)}))))}}return t.\u0275fac=function(i){return new(i||t)(l.Xb(u.b),l.Xb(d.a))},t.\u0275prov=l.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var h=e("Wp6s"),f=e("bTqV"),D=e("bv9b"),S=e("NFeN"),T=e("3Pt+"),I=e("kmnG"),L=e("qFsG");function g(t,i){1&t&&l.Ob(0,"mat-progress-bar",9)}function C(t,i){1&t&&l.Ob(0,"mat-progress-bar",9)}function y(t,i){1&t&&(l.Tb(0,"span"),l.yc(1,"Is Required"),l.Ob(2,"br"),l.Sb())}function E(t,i){if(1&t&&(l.Tb(0,"mat-error"),l.Tb(1,"span"),l.yc(2),l.fc(3,"json"),l.Ob(4,"br"),l.Sb(),l.xc(5,y,3,0,"span",4),l.Sb()),2&t){const t=i.$implicit;l.Bb(2),l.zc(l.gc(3,2,t)),l.Bb(3),l.jc("ngIf",t.required)}}function v(t,i){1&t&&(l.Tb(0,"span"),l.yc(1,"Is Required"),l.Ob(2,"br"),l.Sb())}function P(t,i){if(1&t&&(l.Tb(0,"mat-error"),l.Tb(1,"span"),l.yc(2),l.fc(3,"json"),l.Ob(4,"br"),l.Sb(),l.xc(5,v,3,0,"span",4),l.Sb()),2&t){const t=i.$implicit;l.Bb(2),l.zc(l.gc(3,2,t)),l.Bb(3),l.jc("ngIf",t.required)}}function O(t,i){1&t&&(l.Tb(0,"span"),l.yc(1,"Is Required"),l.Ob(2,"br"),l.Sb())}function B(t,i){1&t&&(l.Tb(0,"span"),l.yc(1,"Min - 0"),l.Ob(2,"br"),l.Sb())}function j(t,i){1&t&&(l.Tb(0,"span"),l.yc(1,"Max - 1000"),l.Ob(2,"br"),l.Sb())}function w(t,i){if(1&t&&(l.Tb(0,"mat-error"),l.Tb(1,"span"),l.yc(2),l.fc(3,"json"),l.Ob(4,"br"),l.Sb(),l.xc(5,O,3,0,"span",4),l.xc(6,B,3,0,"span",4),l.xc(7,j,3,0,"span",4),l.Sb()),2&t){const t=i.$implicit;l.Bb(2),l.zc(l.gc(3,4,t)),l.Bb(3),l.jc("ngIf",t.required),l.Bb(1),l.jc("ngIf",t.min),l.Bb(1),l.jc("ngIf",t.min)}}function $(t,i){1&t&&(l.Tb(0,"span"),l.yc(1,"Is Required"),l.Ob(2,"br"),l.Sb())}function M(t,i){if(1&t&&(l.Tb(0,"mat-error"),l.Tb(1,"span"),l.yc(2),l.fc(3,"json"),l.Ob(4,"br"),l.Sb(),l.xc(5,$,3,0,"span",4),l.Sb()),2&t){const t=i.$implicit;l.Bb(2),l.zc(l.gc(3,2,t)),l.Bb(3),l.jc("ngIf",t.required)}}function x(t,i){1&t&&(l.Tb(0,"span"),l.yc(1,"Is Required"),l.Ob(2,"br"),l.Sb())}function G(t,i){if(1&t&&(l.Tb(0,"mat-error"),l.Tb(1,"span"),l.yc(2),l.fc(3,"json"),l.Ob(4,"br"),l.Sb(),l.xc(5,x,3,0,"span",4),l.Sb()),2&t){const t=i.$implicit;l.Bb(2),l.zc(l.gc(3,2,t)),l.Bb(3),l.jc("ngIf",t.required)}}let k=(()=>{class t{constructor(t,i){this.emaildistributionlistService=t,this.fb=i,this.emaildistributionlist=null,this.httpClientCommand=r.a.Put}GetPut(){return this.httpClientCommand==r.a.Put}PutEmailDistributionList(t){this.sub=this.emaildistributionlistService.PutEmailDistributionList(t).subscribe()}PostEmailDistributionList(t){this.sub=this.emaildistributionlistService.PostEmailDistributionList(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.emaildistributionlist){let i=this.fb.group({EmailDistributionListID:[{value:t===r.a.Post?0:this.emaildistributionlist.EmailDistributionListID,disabled:!1},[T.p.required]],ParentTVItemID:[{value:this.emaildistributionlist.ParentTVItemID,disabled:!1},[T.p.required]],Ordinal:[{value:this.emaildistributionlist.Ordinal,disabled:!1},[T.p.required,T.p.min(0),T.p.max(1e3)]],LastUpdateDate_UTC:[{value:this.emaildistributionlist.LastUpdateDate_UTC,disabled:!1},[T.p.required]],LastUpdateContactTVItemID:[{value:this.emaildistributionlist.LastUpdateContactTVItemID,disabled:!1},[T.p.required]]});this.emaildistributionlistFormEdit=i}}}return t.\u0275fac=function(i){return new(i||t)(l.Nb(p),l.Nb(T.d))},t.\u0275cmp=l.Hb({type:t,selectors:[["app-emaildistributionlist-edit"]],inputs:{emaildistributionlist:"emaildistributionlist",httpClientCommand:"httpClientCommand"},decls:35,vars:9,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","EmailDistributionListID"],[4,"ngIf"],["matInput","","type","number","formControlName","ParentTVItemID"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,i){1&t&&(l.Tb(0,"form",0),l.ac("ngSubmit",(function(){return i.GetPut()?i.PutEmailDistributionList(i.emaildistributionlistFormEdit.value):i.PostEmailDistributionList(i.emaildistributionlistFormEdit.value)})),l.Tb(1,"h3"),l.yc(2," EmailDistributionList "),l.Tb(3,"button",1),l.Tb(4,"span"),l.yc(5),l.Sb(),l.Sb(),l.xc(6,g,1,0,"mat-progress-bar",2),l.xc(7,C,1,0,"mat-progress-bar",2),l.Sb(),l.Tb(8,"p"),l.Tb(9,"mat-form-field"),l.Tb(10,"mat-label"),l.yc(11,"EmailDistributionListID"),l.Sb(),l.Ob(12,"input",3),l.xc(13,E,6,4,"mat-error",4),l.Sb(),l.Tb(14,"mat-form-field"),l.Tb(15,"mat-label"),l.yc(16,"ParentTVItemID"),l.Sb(),l.Ob(17,"input",5),l.xc(18,P,6,4,"mat-error",4),l.Sb(),l.Tb(19,"mat-form-field"),l.Tb(20,"mat-label"),l.yc(21,"Ordinal"),l.Sb(),l.Ob(22,"input",6),l.xc(23,w,8,6,"mat-error",4),l.Sb(),l.Tb(24,"mat-form-field"),l.Tb(25,"mat-label"),l.yc(26,"LastUpdateDate_UTC"),l.Sb(),l.Ob(27,"input",7),l.xc(28,M,6,4,"mat-error",4),l.Sb(),l.Sb(),l.Tb(29,"p"),l.Tb(30,"mat-form-field"),l.Tb(31,"mat-label"),l.yc(32,"LastUpdateContactTVItemID"),l.Sb(),l.Ob(33,"input",8),l.xc(34,G,6,4,"mat-error",4),l.Sb(),l.Sb(),l.Sb()),2&t&&(l.jc("formGroup",i.emaildistributionlistFormEdit),l.Bb(5),l.Ac("",i.GetPut()?"Put":"Post"," EmailDistributionList"),l.Bb(1),l.jc("ngIf",i.emaildistributionlistService.emaildistributionlistPutModel$.getValue().Working),l.Bb(1),l.jc("ngIf",i.emaildistributionlistService.emaildistributionlistPostModel$.getValue().Working),l.Bb(6),l.jc("ngIf",i.emaildistributionlistFormEdit.controls.EmailDistributionListID.errors),l.Bb(5),l.jc("ngIf",i.emaildistributionlistFormEdit.controls.ParentTVItemID.errors),l.Bb(5),l.jc("ngIf",i.emaildistributionlistFormEdit.controls.Ordinal.errors),l.Bb(5),l.jc("ngIf",i.emaildistributionlistFormEdit.controls.LastUpdateDate_UTC.errors),l.Bb(6),l.jc("ngIf",i.emaildistributionlistFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[T.q,T.l,T.f,f.b,s.l,I.c,I.f,L.b,T.n,T.c,T.k,T.e,D.a,I.b],pipes:[s.f],styles:[""],changeDetection:0}),t})();function V(t,i){1&t&&l.Ob(0,"mat-progress-bar",4)}function U(t,i){1&t&&l.Ob(0,"mat-progress-bar",4)}function q(t,i){if(1&t&&(l.Tb(0,"p"),l.Ob(1,"app-emaildistributionlist-edit",8),l.Sb()),2&t){const t=l.ec().$implicit,i=l.ec(2);l.Bb(1),l.jc("emaildistributionlist",t)("httpClientCommand",i.GetPutEnum())}}function F(t,i){if(1&t&&(l.Tb(0,"p"),l.Ob(1,"app-emaildistributionlist-edit",8),l.Sb()),2&t){const t=l.ec().$implicit,i=l.ec(2);l.Bb(1),l.jc("emaildistributionlist",t)("httpClientCommand",i.GetPostEnum())}}function R(t,i){if(1&t){const t=l.Ub();l.Tb(0,"div"),l.Tb(1,"p"),l.Tb(2,"button",6),l.ac("click",(function(){l.rc(t);const e=i.$implicit;return l.ec(2).DeleteEmailDistributionList(e)})),l.Tb(3,"span"),l.yc(4),l.Sb(),l.Tb(5,"mat-icon"),l.yc(6,"delete"),l.Sb(),l.Sb(),l.yc(7,"\xa0\xa0\xa0 "),l.Tb(8,"button",7),l.ac("click",(function(){l.rc(t);const e=i.$implicit;return l.ec(2).ShowPut(e)})),l.Tb(9,"span"),l.yc(10,"Show Put"),l.Sb(),l.Sb(),l.yc(11,"\xa0\xa0 "),l.Tb(12,"button",7),l.ac("click",(function(){l.rc(t);const e=i.$implicit;return l.ec(2).ShowPost(e)})),l.Tb(13,"span"),l.yc(14,"Show Post"),l.Sb(),l.Sb(),l.yc(15,"\xa0\xa0 "),l.xc(16,U,1,0,"mat-progress-bar",0),l.Sb(),l.xc(17,q,2,2,"p",2),l.xc(18,F,2,2,"p",2),l.Tb(19,"blockquote"),l.Tb(20,"p"),l.Tb(21,"span"),l.yc(22),l.Sb(),l.Tb(23,"span"),l.yc(24),l.Sb(),l.Tb(25,"span"),l.yc(26),l.Sb(),l.Tb(27,"span"),l.yc(28),l.Sb(),l.Sb(),l.Tb(29,"p"),l.Tb(30,"span"),l.yc(31),l.Sb(),l.Sb(),l.Sb(),l.Sb()}if(2&t){const t=i.$implicit,e=l.ec(2);l.Bb(4),l.Ac("Delete EmailDistributionListID [",t.EmailDistributionListID,"]\xa0\xa0\xa0"),l.Bb(4),l.jc("color",e.GetPutButtonColor(t)),l.Bb(4),l.jc("color",e.GetPostButtonColor(t)),l.Bb(4),l.jc("ngIf",e.emaildistributionlistService.emaildistributionlistDeleteModel$.getValue().Working),l.Bb(1),l.jc("ngIf",e.IDToShow===t.EmailDistributionListID&&e.showType===e.GetPutEnum()),l.Bb(1),l.jc("ngIf",e.IDToShow===t.EmailDistributionListID&&e.showType===e.GetPostEnum()),l.Bb(4),l.Ac("EmailDistributionListID: [",t.EmailDistributionListID,"]"),l.Bb(2),l.Ac(" --- ParentTVItemID: [",t.ParentTVItemID,"]"),l.Bb(2),l.Ac(" --- Ordinal: [",t.Ordinal,"]"),l.Bb(2),l.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),l.Bb(3),l.Ac("LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function N(t,i){if(1&t&&(l.Tb(0,"div"),l.xc(1,R,32,11,"div",5),l.Sb()),2&t){const t=l.ec();l.Bb(1),l.jc("ngForOf",t.emaildistributionlistService.emaildistributionlistListModel$.getValue())}}const A=[{path:"",component:(()=>{class t{constructor(t,i,e){this.emaildistributionlistService=t,this.router=i,this.httpClientService=e,this.showType=null,e.oldURL=i.url}GetPutButtonColor(t){return this.IDToShow===t.EmailDistributionListID&&this.showType===r.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.EmailDistributionListID&&this.showType===r.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.EmailDistributionListID&&this.showType===r.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.EmailDistributionListID,this.showType=r.a.Put)}ShowPost(t){this.IDToShow===t.EmailDistributionListID&&this.showType===r.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.EmailDistributionListID,this.showType=r.a.Post)}GetPutEnum(){return r.a.Put}GetPostEnum(){return r.a.Post}GetEmailDistributionListList(){this.sub=this.emaildistributionlistService.GetEmailDistributionListList().subscribe()}DeleteEmailDistributionList(t){this.sub=this.emaildistributionlistService.DeleteEmailDistributionList(t).subscribe()}ngOnInit(){o(this.emaildistributionlistService.emaildistributionlistTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(i){return new(i||t)(l.Nb(p),l.Nb(n.b),l.Nb(d.a))},t.\u0275cmp=l.Hb({type:t,selectors:[["app-emaildistributionlist"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"emaildistributionlist","httpClientCommand"]],template:function(t,i){if(1&t&&(l.xc(0,V,1,0,"mat-progress-bar",0),l.Tb(1,"mat-card"),l.Tb(2,"mat-card-header"),l.Tb(3,"mat-card-title"),l.yc(4," EmailDistributionList works! "),l.Tb(5,"button",1),l.ac("click",(function(){return i.GetEmailDistributionListList()})),l.Tb(6,"span"),l.yc(7,"Get EmailDistributionList"),l.Sb(),l.Sb(),l.Sb(),l.Tb(8,"mat-card-subtitle"),l.yc(9),l.Sb(),l.Sb(),l.Tb(10,"mat-card-content"),l.xc(11,N,2,1,"div",2),l.Sb(),l.Tb(12,"mat-card-actions"),l.Tb(13,"button",3),l.yc(14,"Allo"),l.Sb(),l.Sb(),l.Sb()),2&t){var e;const t=null==(e=i.emaildistributionlistService.emaildistributionlistGetModel$.getValue())?null:e.Working;var s;const n=null==(s=i.emaildistributionlistService.emaildistributionlistListModel$.getValue())?null:s.length;l.jc("ngIf",t),l.Bb(9),l.zc(i.emaildistributionlistService.emaildistributionlistTextModel$.getValue().Title),l.Bb(2),l.jc("ngIf",n)}},directives:[s.l,h.a,h.d,h.g,f.b,h.f,h.c,h.b,D.a,s.k,S.a,k],styles:[""],changeDetection:0}),t})(),canActivate:[e("auXs").a]}];let W=(()=>{class t{}return t.\u0275mod=l.Lb({type:t}),t.\u0275inj=l.Kb({factory:function(i){return new(i||t)},imports:[[n.e.forChild(A)],n.e]}),t})();var z=e("B+Mi");let H=(()=>{class t{}return t.\u0275mod=l.Lb({type:t}),t.\u0275inj=l.Kb({factory:function(i){return new(i||t)},imports:[[s.c,n.e,W,z.a,T.g,T.o]]}),t})()},QRvi:function(t,i,e){"use strict";e.d(i,"a",(function(){return s}));var s=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,i,e){"use strict";e.d(i,"a",(function(){return r}));var s=e("QRvi"),n=e("fXoL"),o=e("tyNb");let r=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,i,e){t.next(null),i.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,i,e,n,o){if(n===s.a.Get&&t.next(e),n===s.a.Put&&(t.getValue()[0]=e),n===s.a.Post&&t.getValue().push(e),n===s.a.Delete){const i=t.getValue().indexOf(o);t.getValue().splice(i,1)}t.next(t.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(i){return new(i||t)(n.Xb(o.b))},t.\u0275prov=n.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);