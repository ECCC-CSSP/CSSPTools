!function(){function e(e,o){if(!(e instanceof o))throw new TypeError("Cannot call a class as a function")}function o(e,o){for(var t=0;t<o.length;t++){var s=o[t];s.enumerable=s.enumerable||!1,s.configurable=!0,"value"in s&&(s.writable=!0),Object.defineProperty(e,s.key,s)}}function t(e,t,s){return t&&o(e.prototype,t),s&&o(e,s),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[71],{QRvi:function(e,o,t){"use strict";t.d(o,"a",(function(){return s}));var s=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},XBzJ:function(o,s,r){"use strict";r.r(s),r.d(s,"PolSourceObservationIssueModule",(function(){return se}));var i=r("ofXK"),n=r("tyNb");function u(e){var o={Title:"The title"};"fr-CA"===$localize.locale&&(o.Title="Le Titre"),e.next(o)}var a,c=r("QRvi"),b=r("fXoL"),l=r("2Vo4"),p=r("LRne"),v=r("tk/3"),f=r("lJxs"),d=r("JIr8"),m=r("gkM4"),S=((a=function(){function o(t,s){e(this,o),this.httpClient=t,this.httpClientService=s,this.polsourceobservationissueTextModel$=new l.a({}),this.polsourceobservationissueListModel$=new l.a({}),this.polsourceobservationissueGetModel$=new l.a({}),this.polsourceobservationissuePutModel$=new l.a({}),this.polsourceobservationissuePostModel$=new l.a({}),this.polsourceobservationissueDeleteModel$=new l.a({}),u(this.polsourceobservationissueTextModel$),this.polsourceobservationissueTextModel$.next({Title:"Something2 for text"})}return t(o,[{key:"GetPolSourceObservationIssueList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.polsourceobservationissueGetModel$),this.httpClient.get("/api/PolSourceObservationIssue").pipe(Object(f.a)((function(o){e.httpClientService.DoSuccess(e.polsourceobservationissueListModel$,e.polsourceobservationissueGetModel$,o,c.a.Get,null)})),Object(d.a)((function(o){return Object(p.a)(o).pipe(Object(f.a)((function(o){e.httpClientService.DoCatchError(e.polsourceobservationissueListModel$,e.polsourceobservationissueGetModel$,o)})))})))}},{key:"PutPolSourceObservationIssue",value:function(e){var o=this;return this.httpClientService.BeforeHttpClient(this.polsourceobservationissuePutModel$),this.httpClient.put("/api/PolSourceObservationIssue",e,{headers:new v.d}).pipe(Object(f.a)((function(t){o.httpClientService.DoSuccess(o.polsourceobservationissueListModel$,o.polsourceobservationissuePutModel$,t,c.a.Put,e)})),Object(d.a)((function(e){return Object(p.a)(e).pipe(Object(f.a)((function(e){o.httpClientService.DoCatchError(o.polsourceobservationissueListModel$,o.polsourceobservationissuePutModel$,e)})))})))}},{key:"PostPolSourceObservationIssue",value:function(e){var o=this;return this.httpClientService.BeforeHttpClient(this.polsourceobservationissuePostModel$),this.httpClient.post("/api/PolSourceObservationIssue",e,{headers:new v.d}).pipe(Object(f.a)((function(t){o.httpClientService.DoSuccess(o.polsourceobservationissueListModel$,o.polsourceobservationissuePostModel$,t,c.a.Post,e)})),Object(d.a)((function(e){return Object(p.a)(e).pipe(Object(f.a)((function(e){o.httpClientService.DoCatchError(o.polsourceobservationissueListModel$,o.polsourceobservationissuePostModel$,e)})))})))}},{key:"DeletePolSourceObservationIssue",value:function(e){var o=this;return this.httpClientService.BeforeHttpClient(this.polsourceobservationissueDeleteModel$),this.httpClient.delete("/api/PolSourceObservationIssue/"+e.PolSourceObservationIssueID).pipe(Object(f.a)((function(t){o.httpClientService.DoSuccess(o.polsourceobservationissueListModel$,o.polsourceobservationissueDeleteModel$,t,c.a.Delete,e)})),Object(d.a)((function(e){return Object(p.a)(e).pipe(Object(f.a)((function(e){o.httpClientService.DoCatchError(o.polsourceobservationissueListModel$,o.polsourceobservationissueDeleteModel$,e)})))})))}}]),o}()).\u0275fac=function(e){return new(e||a)(b.Wb(v.b),b.Wb(m.a))},a.\u0275prov=b.Ib({token:a,factory:a.\u0275fac,providedIn:"root"}),a),h=r("Wp6s"),I=r("bTqV"),P=r("bv9b"),R=r("NFeN"),y=r("3Pt+"),O=r("kmnG"),g=r("qFsG");function D(e,o){1&e&&b.Nb(0,"mat-progress-bar",11)}function C(e,o){1&e&&b.Nb(0,"mat-progress-bar",11)}function B(e,o){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function k(e,o){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,B,3,0,"span",4),b.Rb()),2&e){var t=o.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function w(e,o){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function $(e,o){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,w,3,0,"span",4),b.Rb()),2&e){var t=o.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function T(e,o){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function M(e,o){1&e&&(b.Sb(0,"span"),b.zc(1,"MaxLength - 250"),b.Nb(2,"br"),b.Rb())}function z(e,o){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,T,3,0,"span",4),b.yc(6,M,3,0,"span",4),b.Rb()),2&e){var t=o.$implicit;b.Bb(2),b.Ac(b.fc(3,3,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.maxlength)}}function N(e,o){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function L(e,o){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function E(e,o){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 1000"),b.Nb(2,"br"),b.Rb())}function x(e,o){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,N,3,0,"span",4),b.yc(6,L,3,0,"span",4),b.yc(7,E,3,0,"span",4),b.Rb()),2&e){var t=o.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function G(e,o){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.Rb()),2&e){var t=o.$implicit;b.Bb(2),b.Ac(b.fc(3,1,t))}}function j(e,o){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function q(e,o){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,j,3,0,"span",4),b.Rb()),2&e){var t=o.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function U(e,o){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function V(e,o){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,U,3,0,"span",4),b.Rb()),2&e){var t=o.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}var F,W=((F=function(){function o(t,s){e(this,o),this.polsourceobservationissueService=t,this.fb=s,this.polsourceobservationissue=null,this.httpClientCommand=c.a.Put}return t(o,[{key:"GetPut",value:function(){return this.httpClientCommand==c.a.Put}},{key:"PutPolSourceObservationIssue",value:function(e){this.sub=this.polsourceobservationissueService.PutPolSourceObservationIssue(e).subscribe()}},{key:"PostPolSourceObservationIssue",value:function(e){this.sub=this.polsourceobservationissueService.PostPolSourceObservationIssue(e).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.polsourceobservationissue){var o=this.fb.group({PolSourceObservationIssueID:[{value:e===c.a.Post?0:this.polsourceobservationissue.PolSourceObservationIssueID,disabled:!1},[y.p.required]],PolSourceObservationID:[{value:this.polsourceobservationissue.PolSourceObservationID,disabled:!1},[y.p.required]],ObservationInfo:[{value:this.polsourceobservationissue.ObservationInfo,disabled:!1},[y.p.required,y.p.maxLength(250)]],Ordinal:[{value:this.polsourceobservationissue.Ordinal,disabled:!1},[y.p.required,y.p.min(0),y.p.max(1e3)]],ExtraComment:[{value:this.polsourceobservationissue.ExtraComment,disabled:!1}],LastUpdateDate_UTC:[{value:this.polsourceobservationissue.LastUpdateDate_UTC,disabled:!1},[y.p.required]],LastUpdateContactTVItemID:[{value:this.polsourceobservationissue.LastUpdateContactTVItemID,disabled:!1},[y.p.required]]});this.polsourceobservationissueFormEdit=o}}}]),o}()).\u0275fac=function(e){return new(e||F)(b.Mb(S),b.Mb(y.d))},F.\u0275cmp=b.Gb({type:F,selectors:[["app-polsourceobservationissue-edit"]],inputs:{polsourceobservationissue:"polsourceobservationissue",httpClientCommand:"httpClientCommand"},decls:45,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","PolSourceObservationIssueID"],[4,"ngIf"],["matInput","","type","number","formControlName","PolSourceObservationID"],["matInput","","type","text","formControlName","ObservationInfo"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","text","formControlName","ExtraComment"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(e,o){1&e&&(b.Sb(0,"form",0),b.Zb("ngSubmit",(function(){return o.GetPut()?o.PutPolSourceObservationIssue(o.polsourceobservationissueFormEdit.value):o.PostPolSourceObservationIssue(o.polsourceobservationissueFormEdit.value)})),b.Sb(1,"h3"),b.zc(2," PolSourceObservationIssue "),b.Sb(3,"button",1),b.Sb(4,"span"),b.zc(5),b.Rb(),b.Rb(),b.yc(6,D,1,0,"mat-progress-bar",2),b.yc(7,C,1,0,"mat-progress-bar",2),b.Rb(),b.Sb(8,"p"),b.Sb(9,"mat-form-field"),b.Sb(10,"mat-label"),b.zc(11,"PolSourceObservationIssueID"),b.Rb(),b.Nb(12,"input",3),b.yc(13,k,6,4,"mat-error",4),b.Rb(),b.Sb(14,"mat-form-field"),b.Sb(15,"mat-label"),b.zc(16,"PolSourceObservationID"),b.Rb(),b.Nb(17,"input",5),b.yc(18,$,6,4,"mat-error",4),b.Rb(),b.Sb(19,"mat-form-field"),b.Sb(20,"mat-label"),b.zc(21,"ObservationInfo"),b.Rb(),b.Nb(22,"input",6),b.yc(23,z,7,5,"mat-error",4),b.Rb(),b.Sb(24,"mat-form-field"),b.Sb(25,"mat-label"),b.zc(26,"Ordinal"),b.Rb(),b.Nb(27,"input",7),b.yc(28,x,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"mat-form-field"),b.Sb(31,"mat-label"),b.zc(32,"ExtraComment"),b.Rb(),b.Nb(33,"input",8),b.yc(34,G,5,3,"mat-error",4),b.Rb(),b.Sb(35,"mat-form-field"),b.Sb(36,"mat-label"),b.zc(37,"LastUpdateDate_UTC"),b.Rb(),b.Nb(38,"input",9),b.yc(39,q,6,4,"mat-error",4),b.Rb(),b.Sb(40,"mat-form-field"),b.Sb(41,"mat-label"),b.zc(42,"LastUpdateContactTVItemID"),b.Rb(),b.Nb(43,"input",10),b.yc(44,V,6,4,"mat-error",4),b.Rb(),b.Rb(),b.Rb()),2&e&&(b.ic("formGroup",o.polsourceobservationissueFormEdit),b.Bb(5),b.Bc("",o.GetPut()?"Put":"Post"," PolSourceObservationIssue"),b.Bb(1),b.ic("ngIf",o.polsourceobservationissueService.polsourceobservationissuePutModel$.getValue().Working),b.Bb(1),b.ic("ngIf",o.polsourceobservationissueService.polsourceobservationissuePostModel$.getValue().Working),b.Bb(6),b.ic("ngIf",o.polsourceobservationissueFormEdit.controls.PolSourceObservationIssueID.errors),b.Bb(5),b.ic("ngIf",o.polsourceobservationissueFormEdit.controls.PolSourceObservationID.errors),b.Bb(5),b.ic("ngIf",o.polsourceobservationissueFormEdit.controls.ObservationInfo.errors),b.Bb(5),b.ic("ngIf",o.polsourceobservationissueFormEdit.controls.Ordinal.errors),b.Bb(6),b.ic("ngIf",o.polsourceobservationissueFormEdit.controls.ExtraComment.errors),b.Bb(5),b.ic("ngIf",o.polsourceobservationissueFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(5),b.ic("ngIf",o.polsourceobservationissueFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[y.q,y.l,y.f,I.b,i.l,O.c,O.f,g.b,y.n,y.c,y.k,y.e,P.a,O.b],pipes:[i.f],styles:[""],changeDetection:0}),F);function A(e,o){1&e&&b.Nb(0,"mat-progress-bar",4)}function J(e,o){1&e&&b.Nb(0,"mat-progress-bar",4)}function _(e,o){if(1&e&&(b.Sb(0,"p"),b.Nb(1,"app-polsourceobservationissue-edit",8),b.Rb()),2&e){var t=b.dc().$implicit,s=b.dc(2);b.Bb(1),b.ic("polsourceobservationissue",t)("httpClientCommand",s.GetPutEnum())}}function H(e,o){if(1&e&&(b.Sb(0,"p"),b.Nb(1,"app-polsourceobservationissue-edit",8),b.Rb()),2&e){var t=b.dc().$implicit,s=b.dc(2);b.Bb(1),b.ic("polsourceobservationissue",t)("httpClientCommand",s.GetPostEnum())}}function X(e,o){if(1&e){var t=b.Tb();b.Sb(0,"div"),b.Sb(1,"p"),b.Sb(2,"button",6),b.Zb("click",(function(){b.qc(t);var e=o.$implicit;return b.dc(2).DeletePolSourceObservationIssue(e)})),b.Sb(3,"span"),b.zc(4),b.Rb(),b.Sb(5,"mat-icon"),b.zc(6,"delete"),b.Rb(),b.Rb(),b.zc(7,"\xa0\xa0\xa0 "),b.Sb(8,"button",7),b.Zb("click",(function(){b.qc(t);var e=o.$implicit;return b.dc(2).ShowPut(e)})),b.Sb(9,"span"),b.zc(10,"Show Put"),b.Rb(),b.Rb(),b.zc(11,"\xa0\xa0 "),b.Sb(12,"button",7),b.Zb("click",(function(){b.qc(t);var e=o.$implicit;return b.dc(2).ShowPost(e)})),b.Sb(13,"span"),b.zc(14,"Show Post"),b.Rb(),b.Rb(),b.zc(15,"\xa0\xa0 "),b.yc(16,J,1,0,"mat-progress-bar",0),b.Rb(),b.yc(17,_,2,2,"p",2),b.yc(18,H,2,2,"p",2),b.Sb(19,"blockquote"),b.Sb(20,"p"),b.Sb(21,"span"),b.zc(22),b.Rb(),b.Sb(23,"span"),b.zc(24),b.Rb(),b.Sb(25,"span"),b.zc(26),b.Rb(),b.Sb(27,"span"),b.zc(28),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"span"),b.zc(31),b.Rb(),b.Sb(32,"span"),b.zc(33),b.Rb(),b.Sb(34,"span"),b.zc(35),b.Rb(),b.Rb(),b.Rb(),b.Rb()}if(2&e){var s=o.$implicit,r=b.dc(2);b.Bb(4),b.Bc("Delete PolSourceObservationIssueID [",s.PolSourceObservationIssueID,"]\xa0\xa0\xa0"),b.Bb(4),b.ic("color",r.GetPutButtonColor(s)),b.Bb(4),b.ic("color",r.GetPostButtonColor(s)),b.Bb(4),b.ic("ngIf",r.polsourceobservationissueService.polsourceobservationissueDeleteModel$.getValue().Working),b.Bb(1),b.ic("ngIf",r.IDToShow===s.PolSourceObservationIssueID&&r.showType===r.GetPutEnum()),b.Bb(1),b.ic("ngIf",r.IDToShow===s.PolSourceObservationIssueID&&r.showType===r.GetPostEnum()),b.Bb(4),b.Bc("PolSourceObservationIssueID: [",s.PolSourceObservationIssueID,"]"),b.Bb(2),b.Bc(" --- PolSourceObservationID: [",s.PolSourceObservationID,"]"),b.Bb(2),b.Bc(" --- ObservationInfo: [",s.ObservationInfo,"]"),b.Bb(2),b.Bc(" --- Ordinal: [",s.Ordinal,"]"),b.Bb(3),b.Bc("ExtraComment: [",s.ExtraComment,"]"),b.Bb(2),b.Bc(" --- LastUpdateDate_UTC: [",s.LastUpdateDate_UTC,"]"),b.Bb(2),b.Bc(" --- LastUpdateContactTVItemID: [",s.LastUpdateContactTVItemID,"]")}}function Z(e,o){if(1&e&&(b.Sb(0,"div"),b.yc(1,X,36,13,"div",5),b.Rb()),2&e){var t=b.dc();b.Bb(1),b.ic("ngForOf",t.polsourceobservationissueService.polsourceobservationissueListModel$.getValue())}}var K,Q,Y,ee=[{path:"",component:(K=function(){function o(t,s,r){e(this,o),this.polsourceobservationissueService=t,this.router=s,this.httpClientService=r,this.showType=null,r.oldURL=s.url}return t(o,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.PolSourceObservationIssueID&&this.showType===c.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.PolSourceObservationIssueID&&this.showType===c.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.PolSourceObservationIssueID&&this.showType===c.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.PolSourceObservationIssueID,this.showType=c.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.PolSourceObservationIssueID&&this.showType===c.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.PolSourceObservationIssueID,this.showType=c.a.Post)}},{key:"GetPutEnum",value:function(){return c.a.Put}},{key:"GetPostEnum",value:function(){return c.a.Post}},{key:"GetPolSourceObservationIssueList",value:function(){this.sub=this.polsourceobservationissueService.GetPolSourceObservationIssueList().subscribe()}},{key:"DeletePolSourceObservationIssue",value:function(e){this.sub=this.polsourceobservationissueService.DeletePolSourceObservationIssue(e).subscribe()}},{key:"ngOnInit",value:function(){u(this.polsourceobservationissueService.polsourceobservationissueTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),o}(),K.\u0275fac=function(e){return new(e||K)(b.Mb(S),b.Mb(n.b),b.Mb(m.a))},K.\u0275cmp=b.Gb({type:K,selectors:[["app-polsourceobservationissue"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"polsourceobservationissue","httpClientCommand"]],template:function(e,o){if(1&e&&(b.yc(0,A,1,0,"mat-progress-bar",0),b.Sb(1,"mat-card"),b.Sb(2,"mat-card-header"),b.Sb(3,"mat-card-title"),b.zc(4," PolSourceObservationIssue works! "),b.Sb(5,"button",1),b.Zb("click",(function(){return o.GetPolSourceObservationIssueList()})),b.Sb(6,"span"),b.zc(7,"Get PolSourceObservationIssue"),b.Rb(),b.Rb(),b.Rb(),b.Sb(8,"mat-card-subtitle"),b.zc(9),b.Rb(),b.Rb(),b.Sb(10,"mat-card-content"),b.yc(11,Z,2,1,"div",2),b.Rb(),b.Sb(12,"mat-card-actions"),b.Sb(13,"button",3),b.zc(14,"Allo"),b.Rb(),b.Rb(),b.Rb()),2&e){var t,s,r=null==(t=o.polsourceobservationissueService.polsourceobservationissueGetModel$.getValue())?null:t.Working,i=null==(s=o.polsourceobservationissueService.polsourceobservationissueListModel$.getValue())?null:s.length;b.ic("ngIf",r),b.Bb(9),b.Ac(o.polsourceobservationissueService.polsourceobservationissueTextModel$.getValue().Title),b.Bb(2),b.ic("ngIf",i)}},directives:[i.l,h.a,h.d,h.g,I.b,h.f,h.c,h.b,P.a,i.k,R.a,W],styles:[""],changeDetection:0}),K),canActivate:[r("auXs").a]}],oe=((Q=function o(){e(this,o)}).\u0275mod=b.Kb({type:Q}),Q.\u0275inj=b.Jb({factory:function(e){return new(e||Q)},imports:[[n.e.forChild(ee)],n.e]}),Q),te=r("B+Mi"),se=((Y=function o(){e(this,o)}).\u0275mod=b.Kb({type:Y}),Y.\u0275inj=b.Jb({factory:function(e){return new(e||Y)},imports:[[i.c,n.e,oe,te.a,y.g,y.o]]}),Y)},gkM4:function(o,s,r){"use strict";r.d(s,"a",(function(){return a}));var i=r("QRvi"),n=r("fXoL"),u=r("tyNb"),a=function(){var o=function(){function o(t){e(this,o),this.router=t,this.oldURL=t.url}return t(o,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,o,t){e.next(null),o.next({Working:!1,Error:t,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(e,o,t){e.next(null),o.next({Working:!1,Error:t,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,o,t,s,r){if(s===i.a.Get&&e.next(t),s===i.a.Put&&(e.getValue()[0]=t),s===i.a.Post&&e.getValue().push(t),s===i.a.Delete){var n=e.getValue().indexOf(r);e.getValue().splice(n,1)}e.next(e.getValue()),o.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(e,o,t,s,r){s===i.a.Get&&e.next(t),e.next(e.getValue()),o.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),o}();return o.\u0275fac=function(e){return new(e||o)(n.Wb(u.b))},o.\u0275prov=n.Ib({token:o,factory:o.\u0275fac,providedIn:"root"}),o}()}}])}();