(window.webpackJsonp=window.webpackJsonp||[]).push([[71],{QRvi:function(e,t,o){"use strict";o.d(t,"a",(function(){return s}));var s=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},XBzJ:function(e,t,o){"use strict";o.r(t),o.d(t,"PolSourceObservationIssueModule",(function(){return Z}));var s=o("ofXK"),r=o("tyNb");function i(e){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var n=o("QRvi"),c=o("fXoL"),u=o("2Vo4"),a=o("LRne"),b=o("tk/3"),l=o("lJxs"),p=o("JIr8"),v=o("gkM4");let d=(()=>{class e{constructor(e,t){this.httpClient=e,this.httpClientService=t,this.polsourceobservationissueTextModel$=new u.a({}),this.polsourceobservationissueListModel$=new u.a({}),this.polsourceobservationissueGetModel$=new u.a({}),this.polsourceobservationissuePutModel$=new u.a({}),this.polsourceobservationissuePostModel$=new u.a({}),this.polsourceobservationissueDeleteModel$=new u.a({}),i(this.polsourceobservationissueTextModel$),this.polsourceobservationissueTextModel$.next({Title:"Something2 for text"})}GetPolSourceObservationIssueList(){return this.httpClientService.BeforeHttpClient(this.polsourceobservationissueGetModel$),this.httpClient.get("/api/PolSourceObservationIssue").pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.polsourceobservationissueListModel$,this.polsourceobservationissueGetModel$,e,n.a.Get,null)}),Object(p.a)(e=>Object(a.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.polsourceobservationissueListModel$,this.polsourceobservationissueGetModel$,e)}))))}PutPolSourceObservationIssue(e){return this.httpClientService.BeforeHttpClient(this.polsourceobservationissuePutModel$),this.httpClient.put("/api/PolSourceObservationIssue",e,{headers:new b.d}).pipe(Object(l.a)(t=>{this.httpClientService.DoSuccess(this.polsourceobservationissueListModel$,this.polsourceobservationissuePutModel$,t,n.a.Put,e)}),Object(p.a)(e=>Object(a.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.polsourceobservationissueListModel$,this.polsourceobservationissuePutModel$,e)}))))}PostPolSourceObservationIssue(e){return this.httpClientService.BeforeHttpClient(this.polsourceobservationissuePostModel$),this.httpClient.post("/api/PolSourceObservationIssue",e,{headers:new b.d}).pipe(Object(l.a)(t=>{this.httpClientService.DoSuccess(this.polsourceobservationissueListModel$,this.polsourceobservationissuePostModel$,t,n.a.Post,e)}),Object(p.a)(e=>Object(a.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.polsourceobservationissueListModel$,this.polsourceobservationissuePostModel$,e)}))))}DeletePolSourceObservationIssue(e){return this.httpClientService.BeforeHttpClient(this.polsourceobservationissueDeleteModel$),this.httpClient.delete("/api/PolSourceObservationIssue/"+e.PolSourceObservationIssueID).pipe(Object(l.a)(t=>{this.httpClientService.DoSuccess(this.polsourceobservationissueListModel$,this.polsourceobservationissueDeleteModel$,t,n.a.Delete,e)}),Object(p.a)(e=>Object(a.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.polsourceobservationissueListModel$,this.polsourceobservationissueDeleteModel$,e)}))))}}return e.\u0275fac=function(t){return new(t||e)(c.Wb(b.b),c.Wb(v.a))},e.\u0275prov=c.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var S=o("Wp6s"),m=o("bTqV"),h=o("bv9b"),f=o("NFeN"),I=o("3Pt+"),P=o("kmnG"),R=o("qFsG");function O(e,t){1&e&&c.Nb(0,"mat-progress-bar",11)}function g(e,t){1&e&&c.Nb(0,"mat-progress-bar",11)}function D(e,t){1&e&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function C(e,t){if(1&e&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,D,3,0,"span",4),c.Rb()),2&e){const e=t.$implicit;c.Bb(2),c.Ac(c.fc(3,2,e)),c.Bb(3),c.ic("ngIf",e.required)}}function B(e,t){1&e&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function y(e,t){if(1&e&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,B,3,0,"span",4),c.Rb()),2&e){const e=t.$implicit;c.Bb(2),c.Ac(c.fc(3,2,e)),c.Bb(3),c.ic("ngIf",e.required)}}function $(e,t){1&e&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function w(e,t){1&e&&(c.Sb(0,"span"),c.zc(1,"MaxLength - 250"),c.Nb(2,"br"),c.Rb())}function M(e,t){if(1&e&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,$,3,0,"span",4),c.yc(6,w,3,0,"span",4),c.Rb()),2&e){const e=t.$implicit;c.Bb(2),c.Ac(c.fc(3,3,e)),c.Bb(3),c.ic("ngIf",e.required),c.Bb(1),c.ic("ngIf",e.maxlength)}}function T(e,t){1&e&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function z(e,t){1&e&&(c.Sb(0,"span"),c.zc(1,"Min - 0"),c.Nb(2,"br"),c.Rb())}function N(e,t){1&e&&(c.Sb(0,"span"),c.zc(1,"Max - 1000"),c.Nb(2,"br"),c.Rb())}function L(e,t){if(1&e&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,T,3,0,"span",4),c.yc(6,z,3,0,"span",4),c.yc(7,N,3,0,"span",4),c.Rb()),2&e){const e=t.$implicit;c.Bb(2),c.Ac(c.fc(3,4,e)),c.Bb(3),c.ic("ngIf",e.required),c.Bb(1),c.ic("ngIf",e.min),c.Bb(1),c.ic("ngIf",e.min)}}function E(e,t){if(1&e&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.Rb()),2&e){const e=t.$implicit;c.Bb(2),c.Ac(c.fc(3,1,e))}}function x(e,t){1&e&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function G(e,t){if(1&e&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,x,3,0,"span",4),c.Rb()),2&e){const e=t.$implicit;c.Bb(2),c.Ac(c.fc(3,2,e)),c.Bb(3),c.ic("ngIf",e.required)}}function k(e,t){1&e&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function j(e,t){if(1&e&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,k,3,0,"span",4),c.Rb()),2&e){const e=t.$implicit;c.Bb(2),c.Ac(c.fc(3,2,e)),c.Bb(3),c.ic("ngIf",e.required)}}let q=(()=>{class e{constructor(e,t){this.polsourceobservationissueService=e,this.fb=t,this.polsourceobservationissue=null,this.httpClientCommand=n.a.Put}GetPut(){return this.httpClientCommand==n.a.Put}PutPolSourceObservationIssue(e){this.sub=this.polsourceobservationissueService.PutPolSourceObservationIssue(e).subscribe()}PostPolSourceObservationIssue(e){this.sub=this.polsourceobservationissueService.PostPolSourceObservationIssue(e).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.polsourceobservationissue){let t=this.fb.group({PolSourceObservationIssueID:[{value:e===n.a.Post?0:this.polsourceobservationissue.PolSourceObservationIssueID,disabled:!1},[I.p.required]],PolSourceObservationID:[{value:this.polsourceobservationissue.PolSourceObservationID,disabled:!1},[I.p.required]],ObservationInfo:[{value:this.polsourceobservationissue.ObservationInfo,disabled:!1},[I.p.required,I.p.maxLength(250)]],Ordinal:[{value:this.polsourceobservationissue.Ordinal,disabled:!1},[I.p.required,I.p.min(0),I.p.max(1e3)]],ExtraComment:[{value:this.polsourceobservationissue.ExtraComment,disabled:!1}],LastUpdateDate_UTC:[{value:this.polsourceobservationissue.LastUpdateDate_UTC,disabled:!1},[I.p.required]],LastUpdateContactTVItemID:[{value:this.polsourceobservationissue.LastUpdateContactTVItemID,disabled:!1},[I.p.required]]});this.polsourceobservationissueFormEdit=t}}}return e.\u0275fac=function(t){return new(t||e)(c.Mb(d),c.Mb(I.d))},e.\u0275cmp=c.Gb({type:e,selectors:[["app-polsourceobservationissue-edit"]],inputs:{polsourceobservationissue:"polsourceobservationissue",httpClientCommand:"httpClientCommand"},decls:45,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","PolSourceObservationIssueID"],[4,"ngIf"],["matInput","","type","number","formControlName","PolSourceObservationID"],["matInput","","type","text","formControlName","ObservationInfo"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","text","formControlName","ExtraComment"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(e,t){1&e&&(c.Sb(0,"form",0),c.Zb("ngSubmit",(function(){return t.GetPut()?t.PutPolSourceObservationIssue(t.polsourceobservationissueFormEdit.value):t.PostPolSourceObservationIssue(t.polsourceobservationissueFormEdit.value)})),c.Sb(1,"h3"),c.zc(2," PolSourceObservationIssue "),c.Sb(3,"button",1),c.Sb(4,"span"),c.zc(5),c.Rb(),c.Rb(),c.yc(6,O,1,0,"mat-progress-bar",2),c.yc(7,g,1,0,"mat-progress-bar",2),c.Rb(),c.Sb(8,"p"),c.Sb(9,"mat-form-field"),c.Sb(10,"mat-label"),c.zc(11,"PolSourceObservationIssueID"),c.Rb(),c.Nb(12,"input",3),c.yc(13,C,6,4,"mat-error",4),c.Rb(),c.Sb(14,"mat-form-field"),c.Sb(15,"mat-label"),c.zc(16,"PolSourceObservationID"),c.Rb(),c.Nb(17,"input",5),c.yc(18,y,6,4,"mat-error",4),c.Rb(),c.Sb(19,"mat-form-field"),c.Sb(20,"mat-label"),c.zc(21,"ObservationInfo"),c.Rb(),c.Nb(22,"input",6),c.yc(23,M,7,5,"mat-error",4),c.Rb(),c.Sb(24,"mat-form-field"),c.Sb(25,"mat-label"),c.zc(26,"Ordinal"),c.Rb(),c.Nb(27,"input",7),c.yc(28,L,8,6,"mat-error",4),c.Rb(),c.Rb(),c.Sb(29,"p"),c.Sb(30,"mat-form-field"),c.Sb(31,"mat-label"),c.zc(32,"ExtraComment"),c.Rb(),c.Nb(33,"input",8),c.yc(34,E,5,3,"mat-error",4),c.Rb(),c.Sb(35,"mat-form-field"),c.Sb(36,"mat-label"),c.zc(37,"LastUpdateDate_UTC"),c.Rb(),c.Nb(38,"input",9),c.yc(39,G,6,4,"mat-error",4),c.Rb(),c.Sb(40,"mat-form-field"),c.Sb(41,"mat-label"),c.zc(42,"LastUpdateContactTVItemID"),c.Rb(),c.Nb(43,"input",10),c.yc(44,j,6,4,"mat-error",4),c.Rb(),c.Rb(),c.Rb()),2&e&&(c.ic("formGroup",t.polsourceobservationissueFormEdit),c.Bb(5),c.Bc("",t.GetPut()?"Put":"Post"," PolSourceObservationIssue"),c.Bb(1),c.ic("ngIf",t.polsourceobservationissueService.polsourceobservationissuePutModel$.getValue().Working),c.Bb(1),c.ic("ngIf",t.polsourceobservationissueService.polsourceobservationissuePostModel$.getValue().Working),c.Bb(6),c.ic("ngIf",t.polsourceobservationissueFormEdit.controls.PolSourceObservationIssueID.errors),c.Bb(5),c.ic("ngIf",t.polsourceobservationissueFormEdit.controls.PolSourceObservationID.errors),c.Bb(5),c.ic("ngIf",t.polsourceobservationissueFormEdit.controls.ObservationInfo.errors),c.Bb(5),c.ic("ngIf",t.polsourceobservationissueFormEdit.controls.Ordinal.errors),c.Bb(6),c.ic("ngIf",t.polsourceobservationissueFormEdit.controls.ExtraComment.errors),c.Bb(5),c.ic("ngIf",t.polsourceobservationissueFormEdit.controls.LastUpdateDate_UTC.errors),c.Bb(5),c.ic("ngIf",t.polsourceobservationissueFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[I.q,I.l,I.f,m.b,s.l,P.c,P.f,R.b,I.n,I.c,I.k,I.e,h.a,P.b],pipes:[s.f],styles:[""],changeDetection:0}),e})();function U(e,t){1&e&&c.Nb(0,"mat-progress-bar",4)}function V(e,t){1&e&&c.Nb(0,"mat-progress-bar",4)}function F(e,t){if(1&e&&(c.Sb(0,"p"),c.Nb(1,"app-polsourceobservationissue-edit",8),c.Rb()),2&e){const e=c.dc().$implicit,t=c.dc(2);c.Bb(1),c.ic("polsourceobservationissue",e)("httpClientCommand",t.GetPutEnum())}}function W(e,t){if(1&e&&(c.Sb(0,"p"),c.Nb(1,"app-polsourceobservationissue-edit",8),c.Rb()),2&e){const e=c.dc().$implicit,t=c.dc(2);c.Bb(1),c.ic("polsourceobservationissue",e)("httpClientCommand",t.GetPostEnum())}}function A(e,t){if(1&e){const e=c.Tb();c.Sb(0,"div"),c.Sb(1,"p"),c.Sb(2,"button",6),c.Zb("click",(function(){c.qc(e);const o=t.$implicit;return c.dc(2).DeletePolSourceObservationIssue(o)})),c.Sb(3,"span"),c.zc(4),c.Rb(),c.Sb(5,"mat-icon"),c.zc(6,"delete"),c.Rb(),c.Rb(),c.zc(7,"\xa0\xa0\xa0 "),c.Sb(8,"button",7),c.Zb("click",(function(){c.qc(e);const o=t.$implicit;return c.dc(2).ShowPut(o)})),c.Sb(9,"span"),c.zc(10,"Show Put"),c.Rb(),c.Rb(),c.zc(11,"\xa0\xa0 "),c.Sb(12,"button",7),c.Zb("click",(function(){c.qc(e);const o=t.$implicit;return c.dc(2).ShowPost(o)})),c.Sb(13,"span"),c.zc(14,"Show Post"),c.Rb(),c.Rb(),c.zc(15,"\xa0\xa0 "),c.yc(16,V,1,0,"mat-progress-bar",0),c.Rb(),c.yc(17,F,2,2,"p",2),c.yc(18,W,2,2,"p",2),c.Sb(19,"blockquote"),c.Sb(20,"p"),c.Sb(21,"span"),c.zc(22),c.Rb(),c.Sb(23,"span"),c.zc(24),c.Rb(),c.Sb(25,"span"),c.zc(26),c.Rb(),c.Sb(27,"span"),c.zc(28),c.Rb(),c.Rb(),c.Sb(29,"p"),c.Sb(30,"span"),c.zc(31),c.Rb(),c.Sb(32,"span"),c.zc(33),c.Rb(),c.Sb(34,"span"),c.zc(35),c.Rb(),c.Rb(),c.Rb(),c.Rb()}if(2&e){const e=t.$implicit,o=c.dc(2);c.Bb(4),c.Bc("Delete PolSourceObservationIssueID [",e.PolSourceObservationIssueID,"]\xa0\xa0\xa0"),c.Bb(4),c.ic("color",o.GetPutButtonColor(e)),c.Bb(4),c.ic("color",o.GetPostButtonColor(e)),c.Bb(4),c.ic("ngIf",o.polsourceobservationissueService.polsourceobservationissueDeleteModel$.getValue().Working),c.Bb(1),c.ic("ngIf",o.IDToShow===e.PolSourceObservationIssueID&&o.showType===o.GetPutEnum()),c.Bb(1),c.ic("ngIf",o.IDToShow===e.PolSourceObservationIssueID&&o.showType===o.GetPostEnum()),c.Bb(4),c.Bc("PolSourceObservationIssueID: [",e.PolSourceObservationIssueID,"]"),c.Bb(2),c.Bc(" --- PolSourceObservationID: [",e.PolSourceObservationID,"]"),c.Bb(2),c.Bc(" --- ObservationInfo: [",e.ObservationInfo,"]"),c.Bb(2),c.Bc(" --- Ordinal: [",e.Ordinal,"]"),c.Bb(3),c.Bc("ExtraComment: [",e.ExtraComment,"]"),c.Bb(2),c.Bc(" --- LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),c.Bb(2),c.Bc(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function J(e,t){if(1&e&&(c.Sb(0,"div"),c.yc(1,A,36,13,"div",5),c.Rb()),2&e){const e=c.dc();c.Bb(1),c.ic("ngForOf",e.polsourceobservationissueService.polsourceobservationissueListModel$.getValue())}}const _=[{path:"",component:(()=>{class e{constructor(e,t,o){this.polsourceobservationissueService=e,this.router=t,this.httpClientService=o,this.showType=null,o.oldURL=t.url}GetPutButtonColor(e){return this.IDToShow===e.PolSourceObservationIssueID&&this.showType===n.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.PolSourceObservationIssueID&&this.showType===n.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.PolSourceObservationIssueID&&this.showType===n.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.PolSourceObservationIssueID,this.showType=n.a.Put)}ShowPost(e){this.IDToShow===e.PolSourceObservationIssueID&&this.showType===n.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.PolSourceObservationIssueID,this.showType=n.a.Post)}GetPutEnum(){return n.a.Put}GetPostEnum(){return n.a.Post}GetPolSourceObservationIssueList(){this.sub=this.polsourceobservationissueService.GetPolSourceObservationIssueList().subscribe()}DeletePolSourceObservationIssue(e){this.sub=this.polsourceobservationissueService.DeletePolSourceObservationIssue(e).subscribe()}ngOnInit(){i(this.polsourceobservationissueService.polsourceobservationissueTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(t){return new(t||e)(c.Mb(d),c.Mb(r.b),c.Mb(v.a))},e.\u0275cmp=c.Gb({type:e,selectors:[["app-polsourceobservationissue"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"polsourceobservationissue","httpClientCommand"]],template:function(e,t){if(1&e&&(c.yc(0,U,1,0,"mat-progress-bar",0),c.Sb(1,"mat-card"),c.Sb(2,"mat-card-header"),c.Sb(3,"mat-card-title"),c.zc(4," PolSourceObservationIssue works! "),c.Sb(5,"button",1),c.Zb("click",(function(){return t.GetPolSourceObservationIssueList()})),c.Sb(6,"span"),c.zc(7,"Get PolSourceObservationIssue"),c.Rb(),c.Rb(),c.Rb(),c.Sb(8,"mat-card-subtitle"),c.zc(9),c.Rb(),c.Rb(),c.Sb(10,"mat-card-content"),c.yc(11,J,2,1,"div",2),c.Rb(),c.Sb(12,"mat-card-actions"),c.Sb(13,"button",3),c.zc(14,"Allo"),c.Rb(),c.Rb(),c.Rb()),2&e){var o;const e=null==(o=t.polsourceobservationissueService.polsourceobservationissueGetModel$.getValue())?null:o.Working;var s;const r=null==(s=t.polsourceobservationissueService.polsourceobservationissueListModel$.getValue())?null:s.length;c.ic("ngIf",e),c.Bb(9),c.Ac(t.polsourceobservationissueService.polsourceobservationissueTextModel$.getValue().Title),c.Bb(2),c.ic("ngIf",r)}},directives:[s.l,S.a,S.d,S.g,m.b,S.f,S.c,S.b,h.a,s.k,f.a,q],styles:[""],changeDetection:0}),e})(),canActivate:[o("auXs").a]}];let H=(()=>{class e{}return e.\u0275mod=c.Kb({type:e}),e.\u0275inj=c.Jb({factory:function(t){return new(t||e)},imports:[[r.e.forChild(_)],r.e]}),e})();var X=o("B+Mi");let Z=(()=>{class e{}return e.\u0275mod=c.Kb({type:e}),e.\u0275inj=c.Jb({factory:function(t){return new(t||e)},imports:[[s.c,r.e,H,X.a,I.g,I.o]]}),e})()},gkM4:function(e,t,o){"use strict";o.d(t,"a",(function(){return n}));var s=o("QRvi"),r=o("fXoL"),i=o("tyNb");let n=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,t,o){e.next(null),t.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(e,t,o){e.next(null),t.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,t,o,r,i){if(r===s.a.Get&&e.next(o),r===s.a.Put&&(e.getValue()[0]=o),r===s.a.Post&&e.getValue().push(o),r===s.a.Delete){const t=e.getValue().indexOf(i);e.getValue().splice(t,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(e,t,o,r,i){r===s.a.Get&&e.next(o),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(t){return new(t||e)(r.Wb(i.b))},e.\u0275prov=r.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()}}]);