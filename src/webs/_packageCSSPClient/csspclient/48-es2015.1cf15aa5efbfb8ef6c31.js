(window.webpackJsonp=window.webpackJsonp||[]).push([[48],{FaSq:function(t,i,e){"use strict";e.r(i),e.d(i,"EmailDistributionListModule",(function(){return _}));var s=e("ofXK"),n=e("tyNb");function o(t){let i={Title:"The title"};"fr-CA"===$localize.locale&&(i.Title="Le Titre"),t.next(i)}var r=e("QRvi"),l=e("fXoL"),a=e("2Vo4"),b=e("LRne"),u=e("tk/3"),c=e("lJxs"),m=e("JIr8"),d=e("gkM4");let p=(()=>{class t{constructor(t,i){this.httpClient=t,this.httpClientService=i,this.emaildistributionlistTextModel$=new a.a({}),this.emaildistributionlistListModel$=new a.a({}),this.emaildistributionlistGetModel$=new a.a({}),this.emaildistributionlistPutModel$=new a.a({}),this.emaildistributionlistPostModel$=new a.a({}),this.emaildistributionlistDeleteModel$=new a.a({}),o(this.emaildistributionlistTextModel$),this.emaildistributionlistTextModel$.next({Title:"Something2 for text"})}GetEmailDistributionListList(){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistGetModel$),this.httpClient.get("/api/EmailDistributionList").pipe(Object(c.a)(t=>{this.httpClientService.DoSuccess(this.emaildistributionlistListModel$,this.emaildistributionlistGetModel$,t,r.a.Get,null)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(c.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistListModel$,this.emaildistributionlistGetModel$,t)}))))}PutEmailDistributionList(t){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistPutModel$),this.httpClient.put("/api/EmailDistributionList",t,{headers:new u.d}).pipe(Object(c.a)(i=>{this.httpClientService.DoSuccess(this.emaildistributionlistListModel$,this.emaildistributionlistPutModel$,i,r.a.Put,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(c.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistListModel$,this.emaildistributionlistPutModel$,t)}))))}PostEmailDistributionList(t){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistPostModel$),this.httpClient.post("/api/EmailDistributionList",t,{headers:new u.d}).pipe(Object(c.a)(i=>{this.httpClientService.DoSuccess(this.emaildistributionlistListModel$,this.emaildistributionlistPostModel$,i,r.a.Post,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(c.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistListModel$,this.emaildistributionlistPostModel$,t)}))))}DeleteEmailDistributionList(t){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistDeleteModel$),this.httpClient.delete("/api/EmailDistributionList/"+t.EmailDistributionListID).pipe(Object(c.a)(i=>{this.httpClientService.DoSuccess(this.emaildistributionlistListModel$,this.emaildistributionlistDeleteModel$,i,r.a.Delete,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(c.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistListModel$,this.emaildistributionlistDeleteModel$,t)}))))}}return t.\u0275fac=function(i){return new(i||t)(l.Wb(u.b),l.Wb(d.a))},t.\u0275prov=l.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var h=e("Wp6s"),f=e("bTqV"),D=e("bv9b"),S=e("NFeN"),I=e("3Pt+"),L=e("kmnG"),R=e("qFsG");function g(t,i){1&t&&l.Nb(0,"mat-progress-bar",9)}function C(t,i){1&t&&l.Nb(0,"mat-progress-bar",9)}function E(t,i){1&t&&(l.Sb(0,"span"),l.zc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function v(t,i){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.zc(2),l.ec(3,"json"),l.Nb(4,"br"),l.Rb(),l.yc(5,E,3,0,"span",4),l.Rb()),2&t){const t=i.$implicit;l.Bb(2),l.Ac(l.fc(3,2,t)),l.Bb(3),l.ic("ngIf",t.required)}}function P(t,i){1&t&&(l.Sb(0,"span"),l.zc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function B(t,i){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.zc(2),l.ec(3,"json"),l.Nb(4,"br"),l.Rb(),l.yc(5,P,3,0,"span",4),l.Rb()),2&t){const t=i.$implicit;l.Bb(2),l.Ac(l.fc(3,2,t)),l.Bb(3),l.ic("ngIf",t.required)}}function y(t,i){1&t&&(l.Sb(0,"span"),l.zc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function T(t,i){1&t&&(l.Sb(0,"span"),l.zc(1,"Min - 0"),l.Nb(2,"br"),l.Rb())}function w(t,i){1&t&&(l.Sb(0,"span"),l.zc(1,"Max - 1000"),l.Nb(2,"br"),l.Rb())}function $(t,i){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.zc(2),l.ec(3,"json"),l.Nb(4,"br"),l.Rb(),l.yc(5,y,3,0,"span",4),l.yc(6,T,3,0,"span",4),l.yc(7,w,3,0,"span",4),l.Rb()),2&t){const t=i.$implicit;l.Bb(2),l.Ac(l.fc(3,4,t)),l.Bb(3),l.ic("ngIf",t.required),l.Bb(1),l.ic("ngIf",t.min),l.Bb(1),l.ic("ngIf",t.min)}}function M(t,i){1&t&&(l.Sb(0,"span"),l.zc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function z(t,i){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.zc(2),l.ec(3,"json"),l.Nb(4,"br"),l.Rb(),l.yc(5,M,3,0,"span",4),l.Rb()),2&t){const t=i.$implicit;l.Bb(2),l.Ac(l.fc(3,2,t)),l.Bb(3),l.ic("ngIf",t.required)}}function G(t,i){1&t&&(l.Sb(0,"span"),l.zc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function N(t,i){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.zc(2),l.ec(3,"json"),l.Nb(4,"br"),l.Rb(),l.yc(5,G,3,0,"span",4),l.Rb()),2&t){const t=i.$implicit;l.Bb(2),l.Ac(l.fc(3,2,t)),l.Bb(3),l.ic("ngIf",t.required)}}let k=(()=>{class t{constructor(t,i){this.emaildistributionlistService=t,this.fb=i,this.emaildistributionlist=null,this.httpClientCommand=r.a.Put}GetPut(){return this.httpClientCommand==r.a.Put}PutEmailDistributionList(t){this.sub=this.emaildistributionlistService.PutEmailDistributionList(t).subscribe()}PostEmailDistributionList(t){this.sub=this.emaildistributionlistService.PostEmailDistributionList(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.emaildistributionlist){let i=this.fb.group({EmailDistributionListID:[{value:t===r.a.Post?0:this.emaildistributionlist.EmailDistributionListID,disabled:!1},[I.p.required]],ParentTVItemID:[{value:this.emaildistributionlist.ParentTVItemID,disabled:!1},[I.p.required]],Ordinal:[{value:this.emaildistributionlist.Ordinal,disabled:!1},[I.p.required,I.p.min(0),I.p.max(1e3)]],LastUpdateDate_UTC:[{value:this.emaildistributionlist.LastUpdateDate_UTC,disabled:!1},[I.p.required]],LastUpdateContactTVItemID:[{value:this.emaildistributionlist.LastUpdateContactTVItemID,disabled:!1},[I.p.required]]});this.emaildistributionlistFormEdit=i}}}return t.\u0275fac=function(i){return new(i||t)(l.Mb(p),l.Mb(I.d))},t.\u0275cmp=l.Gb({type:t,selectors:[["app-emaildistributionlist-edit"]],inputs:{emaildistributionlist:"emaildistributionlist",httpClientCommand:"httpClientCommand"},decls:35,vars:9,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","EmailDistributionListID"],[4,"ngIf"],["matInput","","type","number","formControlName","ParentTVItemID"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,i){1&t&&(l.Sb(0,"form",0),l.Zb("ngSubmit",(function(){return i.GetPut()?i.PutEmailDistributionList(i.emaildistributionlistFormEdit.value):i.PostEmailDistributionList(i.emaildistributionlistFormEdit.value)})),l.Sb(1,"h3"),l.zc(2," EmailDistributionList "),l.Sb(3,"button",1),l.Sb(4,"span"),l.zc(5),l.Rb(),l.Rb(),l.yc(6,g,1,0,"mat-progress-bar",2),l.yc(7,C,1,0,"mat-progress-bar",2),l.Rb(),l.Sb(8,"p"),l.Sb(9,"mat-form-field"),l.Sb(10,"mat-label"),l.zc(11,"EmailDistributionListID"),l.Rb(),l.Nb(12,"input",3),l.yc(13,v,6,4,"mat-error",4),l.Rb(),l.Sb(14,"mat-form-field"),l.Sb(15,"mat-label"),l.zc(16,"ParentTVItemID"),l.Rb(),l.Nb(17,"input",5),l.yc(18,B,6,4,"mat-error",4),l.Rb(),l.Sb(19,"mat-form-field"),l.Sb(20,"mat-label"),l.zc(21,"Ordinal"),l.Rb(),l.Nb(22,"input",6),l.yc(23,$,8,6,"mat-error",4),l.Rb(),l.Sb(24,"mat-form-field"),l.Sb(25,"mat-label"),l.zc(26,"LastUpdateDate_UTC"),l.Rb(),l.Nb(27,"input",7),l.yc(28,z,6,4,"mat-error",4),l.Rb(),l.Rb(),l.Sb(29,"p"),l.Sb(30,"mat-form-field"),l.Sb(31,"mat-label"),l.zc(32,"LastUpdateContactTVItemID"),l.Rb(),l.Nb(33,"input",8),l.yc(34,N,6,4,"mat-error",4),l.Rb(),l.Rb(),l.Rb()),2&t&&(l.ic("formGroup",i.emaildistributionlistFormEdit),l.Bb(5),l.Bc("",i.GetPut()?"Put":"Post"," EmailDistributionList"),l.Bb(1),l.ic("ngIf",i.emaildistributionlistService.emaildistributionlistPutModel$.getValue().Working),l.Bb(1),l.ic("ngIf",i.emaildistributionlistService.emaildistributionlistPostModel$.getValue().Working),l.Bb(6),l.ic("ngIf",i.emaildistributionlistFormEdit.controls.EmailDistributionListID.errors),l.Bb(5),l.ic("ngIf",i.emaildistributionlistFormEdit.controls.ParentTVItemID.errors),l.Bb(5),l.ic("ngIf",i.emaildistributionlistFormEdit.controls.Ordinal.errors),l.Bb(5),l.ic("ngIf",i.emaildistributionlistFormEdit.controls.LastUpdateDate_UTC.errors),l.Bb(6),l.ic("ngIf",i.emaildistributionlistFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[I.q,I.l,I.f,f.b,s.l,L.c,L.f,R.b,I.n,I.c,I.k,I.e,D.a,L.b],pipes:[s.f],styles:[""],changeDetection:0}),t})();function O(t,i){1&t&&l.Nb(0,"mat-progress-bar",4)}function V(t,i){1&t&&l.Nb(0,"mat-progress-bar",4)}function U(t,i){if(1&t&&(l.Sb(0,"p"),l.Nb(1,"app-emaildistributionlist-edit",8),l.Rb()),2&t){const t=l.dc().$implicit,i=l.dc(2);l.Bb(1),l.ic("emaildistributionlist",t)("httpClientCommand",i.GetPutEnum())}}function x(t,i){if(1&t&&(l.Sb(0,"p"),l.Nb(1,"app-emaildistributionlist-edit",8),l.Rb()),2&t){const t=l.dc().$implicit,i=l.dc(2);l.Bb(1),l.ic("emaildistributionlist",t)("httpClientCommand",i.GetPostEnum())}}function j(t,i){if(1&t){const t=l.Tb();l.Sb(0,"div"),l.Sb(1,"p"),l.Sb(2,"button",6),l.Zb("click",(function(){l.qc(t);const e=i.$implicit;return l.dc(2).DeleteEmailDistributionList(e)})),l.Sb(3,"span"),l.zc(4),l.Rb(),l.Sb(5,"mat-icon"),l.zc(6,"delete"),l.Rb(),l.Rb(),l.zc(7,"\xa0\xa0\xa0 "),l.Sb(8,"button",7),l.Zb("click",(function(){l.qc(t);const e=i.$implicit;return l.dc(2).ShowPut(e)})),l.Sb(9,"span"),l.zc(10,"Show Put"),l.Rb(),l.Rb(),l.zc(11,"\xa0\xa0 "),l.Sb(12,"button",7),l.Zb("click",(function(){l.qc(t);const e=i.$implicit;return l.dc(2).ShowPost(e)})),l.Sb(13,"span"),l.zc(14,"Show Post"),l.Rb(),l.Rb(),l.zc(15,"\xa0\xa0 "),l.yc(16,V,1,0,"mat-progress-bar",0),l.Rb(),l.yc(17,U,2,2,"p",2),l.yc(18,x,2,2,"p",2),l.Sb(19,"blockquote"),l.Sb(20,"p"),l.Sb(21,"span"),l.zc(22),l.Rb(),l.Sb(23,"span"),l.zc(24),l.Rb(),l.Sb(25,"span"),l.zc(26),l.Rb(),l.Sb(27,"span"),l.zc(28),l.Rb(),l.Rb(),l.Sb(29,"p"),l.Sb(30,"span"),l.zc(31),l.Rb(),l.Rb(),l.Rb(),l.Rb()}if(2&t){const t=i.$implicit,e=l.dc(2);l.Bb(4),l.Bc("Delete EmailDistributionListID [",t.EmailDistributionListID,"]\xa0\xa0\xa0"),l.Bb(4),l.ic("color",e.GetPutButtonColor(t)),l.Bb(4),l.ic("color",e.GetPostButtonColor(t)),l.Bb(4),l.ic("ngIf",e.emaildistributionlistService.emaildistributionlistDeleteModel$.getValue().Working),l.Bb(1),l.ic("ngIf",e.IDToShow===t.EmailDistributionListID&&e.showType===e.GetPutEnum()),l.Bb(1),l.ic("ngIf",e.IDToShow===t.EmailDistributionListID&&e.showType===e.GetPostEnum()),l.Bb(4),l.Bc("EmailDistributionListID: [",t.EmailDistributionListID,"]"),l.Bb(2),l.Bc(" --- ParentTVItemID: [",t.ParentTVItemID,"]"),l.Bb(2),l.Bc(" --- Ordinal: [",t.Ordinal,"]"),l.Bb(2),l.Bc(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),l.Bb(3),l.Bc("LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function q(t,i){if(1&t&&(l.Sb(0,"div"),l.yc(1,j,32,11,"div",5),l.Rb()),2&t){const t=l.dc();l.Bb(1),l.ic("ngForOf",t.emaildistributionlistService.emaildistributionlistListModel$.getValue())}}const F=[{path:"",component:(()=>{class t{constructor(t,i,e){this.emaildistributionlistService=t,this.router=i,this.httpClientService=e,this.showType=null,e.oldURL=i.url}GetPutButtonColor(t){return this.IDToShow===t.EmailDistributionListID&&this.showType===r.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.EmailDistributionListID&&this.showType===r.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.EmailDistributionListID&&this.showType===r.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.EmailDistributionListID,this.showType=r.a.Put)}ShowPost(t){this.IDToShow===t.EmailDistributionListID&&this.showType===r.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.EmailDistributionListID,this.showType=r.a.Post)}GetPutEnum(){return r.a.Put}GetPostEnum(){return r.a.Post}GetEmailDistributionListList(){this.sub=this.emaildistributionlistService.GetEmailDistributionListList().subscribe()}DeleteEmailDistributionList(t){this.sub=this.emaildistributionlistService.DeleteEmailDistributionList(t).subscribe()}ngOnInit(){o(this.emaildistributionlistService.emaildistributionlistTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(i){return new(i||t)(l.Mb(p),l.Mb(n.b),l.Mb(d.a))},t.\u0275cmp=l.Gb({type:t,selectors:[["app-emaildistributionlist"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"emaildistributionlist","httpClientCommand"]],template:function(t,i){if(1&t&&(l.yc(0,O,1,0,"mat-progress-bar",0),l.Sb(1,"mat-card"),l.Sb(2,"mat-card-header"),l.Sb(3,"mat-card-title"),l.zc(4," EmailDistributionList works! "),l.Sb(5,"button",1),l.Zb("click",(function(){return i.GetEmailDistributionListList()})),l.Sb(6,"span"),l.zc(7,"Get EmailDistributionList"),l.Rb(),l.Rb(),l.Rb(),l.Sb(8,"mat-card-subtitle"),l.zc(9),l.Rb(),l.Rb(),l.Sb(10,"mat-card-content"),l.yc(11,q,2,1,"div",2),l.Rb(),l.Sb(12,"mat-card-actions"),l.Sb(13,"button",3),l.zc(14,"Allo"),l.Rb(),l.Rb(),l.Rb()),2&t){var e;const t=null==(e=i.emaildistributionlistService.emaildistributionlistGetModel$.getValue())?null:e.Working;var s;const n=null==(s=i.emaildistributionlistService.emaildistributionlistListModel$.getValue())?null:s.length;l.ic("ngIf",t),l.Bb(9),l.Ac(i.emaildistributionlistService.emaildistributionlistTextModel$.getValue().Title),l.Bb(2),l.ic("ngIf",n)}},directives:[s.l,h.a,h.d,h.g,f.b,h.f,h.c,h.b,D.a,s.k,S.a,k],styles:[""],changeDetection:0}),t})(),canActivate:[e("auXs").a]}];let W=(()=>{class t{}return t.\u0275mod=l.Kb({type:t}),t.\u0275inj=l.Jb({factory:function(i){return new(i||t)},imports:[[n.e.forChild(F)],n.e]}),t})();var A=e("B+Mi");let _=(()=>{class t{}return t.\u0275mod=l.Kb({type:t}),t.\u0275inj=l.Jb({factory:function(i){return new(i||t)},imports:[[s.c,n.e,W,A.a,I.g,I.o]]}),t})()},QRvi:function(t,i,e){"use strict";e.d(i,"a",(function(){return s}));var s=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,i,e){"use strict";e.d(i,"a",(function(){return r}));var s=e("QRvi"),n=e("fXoL"),o=e("tyNb");let r=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,i,e){t.next(null),i.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,i,e){t.next(null),i.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,i,e,n,o){if(n===s.a.Get&&t.next(e),n===s.a.Put&&(t.getValue()[0]=e),n===s.a.Post&&t.getValue().push(e),n===s.a.Delete){const i=t.getValue().indexOf(o);t.getValue().splice(i,1)}t.next(t.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,i,e,n,o){n===s.a.Get&&t.next(e),t.next(t.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(i){return new(i||t)(n.Wb(o.b))},t.\u0275prov=n.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);