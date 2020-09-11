!function(){function t(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function e(t,e){for(var o=0;o<e.length;o++){var n=e[o];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}function o(t,o,n){return o&&e(t.prototype,o),n&&e(t,n),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[55],{QRvi:function(t,e,o){"use strict";o.d(e,"a",(function(){return n}));var n=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},SJzs:function(e,n,i){"use strict";i.r(n),i.d(n,"LogModule",(function(){return ct}));var r=i("ofXK"),a=i("tyNb");function c(t){var e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}function l(){var t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"Add (fr)"}),t.push({EnumID:2,EnumText:"Change (fr)"}),t.push({EnumID:3,EnumText:"Delete (fr)"})):(t.push({EnumID:1,EnumText:"Add"}),t.push({EnumID:2,EnumText:"Change"}),t.push({EnumID:3,EnumText:"Delete"})),t.sort((function(t,e){return t.EnumText.localeCompare(e.EnumText)}))}var u,b=i("QRvi"),s=i("fXoL"),p=i("2Vo4"),m=i("LRne"),g=i("tk/3"),f=i("lJxs"),h=i("JIr8"),d=i("gkM4"),S=((u=function(){function e(o,n){t(this,e),this.httpClient=o,this.httpClientService=n,this.logTextModel$=new p.a({}),this.logListModel$=new p.a({}),this.logGetModel$=new p.a({}),this.logPutModel$=new p.a({}),this.logPostModel$=new p.a({}),this.logDeleteModel$=new p.a({}),c(this.logTextModel$),this.logTextModel$.next({Title:"Something2 for text"})}return o(e,[{key:"GetLogList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.logGetModel$),this.httpClient.get("/api/Log").pipe(Object(f.a)((function(e){t.httpClientService.DoSuccess(t.logListModel$,t.logGetModel$,e,b.a.Get,null)})),Object(h.a)((function(e){return Object(m.a)(e).pipe(Object(f.a)((function(e){t.httpClientService.DoCatchError(t.logListModel$,t.logGetModel$,e)})))})))}},{key:"PutLog",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.logPutModel$),this.httpClient.put("/api/Log",t,{headers:new g.d}).pipe(Object(f.a)((function(o){e.httpClientService.DoSuccess(e.logListModel$,e.logPutModel$,o,b.a.Put,t)})),Object(h.a)((function(t){return Object(m.a)(t).pipe(Object(f.a)((function(t){e.httpClientService.DoCatchError(e.logListModel$,e.logPutModel$,t)})))})))}},{key:"PostLog",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.logPostModel$),this.httpClient.post("/api/Log",t,{headers:new g.d}).pipe(Object(f.a)((function(o){e.httpClientService.DoSuccess(e.logListModel$,e.logPostModel$,o,b.a.Post,t)})),Object(h.a)((function(t){return Object(m.a)(t).pipe(Object(f.a)((function(t){e.httpClientService.DoCatchError(e.logListModel$,e.logPostModel$,t)})))})))}},{key:"DeleteLog",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.logDeleteModel$),this.httpClient.delete("/api/Log/"+t.LogID).pipe(Object(f.a)((function(o){e.httpClientService.DoSuccess(e.logListModel$,e.logDeleteModel$,o,b.a.Delete,t)})),Object(h.a)((function(t){return Object(m.a)(t).pipe(Object(f.a)((function(t){e.httpClientService.DoCatchError(e.logListModel$,e.logDeleteModel$,t)})))})))}}]),e}()).\u0275fac=function(t){return new(t||u)(s.Wb(g.b),s.Wb(d.a))},u.\u0275prov=s.Ib({token:u,factory:u.\u0275fac,providedIn:"root"}),u),v=i("Wp6s"),y=i("bTqV"),I=i("bv9b"),R=i("NFeN"),D=i("3Pt+"),L=i("kmnG"),C=i("qFsG"),T=i("d3UM"),x=i("FKr1");function k(t,e){1&t&&s.Nb(0,"mat-progress-bar",12)}function P(t,e){1&t&&s.Nb(0,"mat-progress-bar",12)}function B(t,e){1&t&&(s.Sb(0,"span"),s.yc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function E(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.yc(2),s.dc(3,"json"),s.Nb(4,"br"),s.Rb(),s.xc(5,B,3,0,"span",4),s.Rb()),2&t){var o=e.$implicit;s.Bb(2),s.zc(s.ec(3,2,o)),s.Bb(3),s.hc("ngIf",o.required)}}function $(t,e){1&t&&(s.Sb(0,"span"),s.yc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function w(t,e){1&t&&(s.Sb(0,"span"),s.yc(1,"MaxLength - 50"),s.Nb(2,"br"),s.Rb())}function M(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.yc(2),s.dc(3,"json"),s.Nb(4,"br"),s.Rb(),s.xc(5,$,3,0,"span",4),s.xc(6,w,3,0,"span",4),s.Rb()),2&t){var o=e.$implicit;s.Bb(2),s.zc(s.ec(3,3,o)),s.Bb(3),s.hc("ngIf",o.required),s.Bb(1),s.hc("ngIf",o.maxlength)}}function N(t,e){1&t&&(s.Sb(0,"span"),s.yc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function G(t,e){1&t&&(s.Sb(0,"span"),s.yc(1,"Min - 1"),s.Nb(2,"br"),s.Rb())}function j(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.yc(2),s.dc(3,"json"),s.Nb(4,"br"),s.Rb(),s.xc(5,N,3,0,"span",4),s.xc(6,G,3,0,"span",4),s.Rb()),2&t){var o=e.$implicit;s.Bb(2),s.zc(s.ec(3,3,o)),s.Bb(3),s.hc("ngIf",o.required),s.Bb(1),s.hc("ngIf",o.min)}}function O(t,e){if(1&t&&(s.Sb(0,"mat-option",13),s.yc(1),s.Rb()),2&t){var o=e.$implicit;s.hc("value",o.EnumID),s.Bb(1),s.Ac(" ",o.EnumText," ")}}function U(t,e){1&t&&(s.Sb(0,"span"),s.yc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function q(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.yc(2),s.dc(3,"json"),s.Nb(4,"br"),s.Rb(),s.xc(5,U,3,0,"span",4),s.Rb()),2&t){var o=e.$implicit;s.Bb(2),s.zc(s.ec(3,2,o)),s.Bb(3),s.hc("ngIf",o.required)}}function F(t,e){1&t&&(s.Sb(0,"span"),s.yc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function V(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.yc(2),s.dc(3,"json"),s.Nb(4,"br"),s.Rb(),s.xc(5,F,3,0,"span",4),s.Rb()),2&t){var o=e.$implicit;s.Bb(2),s.zc(s.ec(3,2,o)),s.Bb(3),s.hc("ngIf",o.required)}}function A(t,e){1&t&&(s.Sb(0,"span"),s.yc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function W(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.yc(2),s.dc(3,"json"),s.Nb(4,"br"),s.Rb(),s.xc(5,A,3,0,"span",4),s.Rb()),2&t){var o=e.$implicit;s.Bb(2),s.zc(s.ec(3,2,o)),s.Bb(3),s.hc("ngIf",o.required)}}function z(t,e){1&t&&(s.Sb(0,"span"),s.yc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function J(t,e){if(1&t&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.yc(2),s.dc(3,"json"),s.Nb(4,"br"),s.Rb(),s.xc(5,z,3,0,"span",4),s.Rb()),2&t){var o=e.$implicit;s.Bb(2),s.zc(s.ec(3,2,o)),s.Bb(3),s.hc("ngIf",o.required)}}var _,H=((_=function(){function e(o,n){t(this,e),this.logService=o,this.fb=n,this.log=null,this.httpClientCommand=b.a.Put}return o(e,[{key:"GetPut",value:function(){return this.httpClientCommand==b.a.Put}},{key:"PutLog",value:function(t){this.sub=this.logService.PutLog(t).subscribe()}},{key:"PostLog",value:function(t){this.sub=this.logService.PostLog(t).subscribe()}},{key:"ngOnInit",value:function(){this.logCommandList=l(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.log){var e=this.fb.group({LogID:[{value:t===b.a.Post?0:this.log.LogID,disabled:!1},[D.p.required]],TableName:[{value:this.log.TableName,disabled:!1},[D.p.required,D.p.maxLength(50)]],ID:[{value:this.log.ID,disabled:!1},[D.p.required,D.p.min(1)]],LogCommand:[{value:this.log.LogCommand,disabled:!1},[D.p.required]],Information:[{value:this.log.Information,disabled:!1},[D.p.required]],LastUpdateDate_UTC:[{value:this.log.LastUpdateDate_UTC,disabled:!1},[D.p.required]],LastUpdateContactTVItemID:[{value:this.log.LastUpdateContactTVItemID,disabled:!1},[D.p.required]]});this.logFormEdit=e}}}]),e}()).\u0275fac=function(t){return new(t||_)(s.Mb(S),s.Mb(D.d))},_.\u0275cmp=s.Gb({type:_,selectors:[["app-log-edit"]],inputs:{log:"log",httpClientCommand:"httpClientCommand"},decls:46,vars:12,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","LogID"],[4,"ngIf"],["matInput","","type","text","formControlName","TableName"],["matInput","","type","number","formControlName","ID"],["formControlName","LogCommand"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","Information"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(s.Sb(0,"form",0),s.Yb("ngSubmit",(function(){return e.GetPut()?e.PutLog(e.logFormEdit.value):e.PostLog(e.logFormEdit.value)})),s.Sb(1,"h3"),s.yc(2," Log "),s.Sb(3,"button",1),s.Sb(4,"span"),s.yc(5),s.Rb(),s.Rb(),s.xc(6,k,1,0,"mat-progress-bar",2),s.xc(7,P,1,0,"mat-progress-bar",2),s.Rb(),s.Sb(8,"p"),s.Sb(9,"mat-form-field"),s.Sb(10,"mat-label"),s.yc(11,"LogID"),s.Rb(),s.Nb(12,"input",3),s.xc(13,E,6,4,"mat-error",4),s.Rb(),s.Sb(14,"mat-form-field"),s.Sb(15,"mat-label"),s.yc(16,"TableName"),s.Rb(),s.Nb(17,"input",5),s.xc(18,M,7,5,"mat-error",4),s.Rb(),s.Sb(19,"mat-form-field"),s.Sb(20,"mat-label"),s.yc(21,"ID"),s.Rb(),s.Nb(22,"input",6),s.xc(23,j,7,5,"mat-error",4),s.Rb(),s.Sb(24,"mat-form-field"),s.Sb(25,"mat-label"),s.yc(26,"LogCommand"),s.Rb(),s.Sb(27,"mat-select",7),s.xc(28,O,2,2,"mat-option",8),s.Rb(),s.xc(29,q,6,4,"mat-error",4),s.Rb(),s.Rb(),s.Sb(30,"p"),s.Sb(31,"mat-form-field"),s.Sb(32,"mat-label"),s.yc(33,"Information"),s.Rb(),s.Nb(34,"input",9),s.xc(35,V,6,4,"mat-error",4),s.Rb(),s.Sb(36,"mat-form-field"),s.Sb(37,"mat-label"),s.yc(38,"LastUpdateDate_UTC"),s.Rb(),s.Nb(39,"input",10),s.xc(40,W,6,4,"mat-error",4),s.Rb(),s.Sb(41,"mat-form-field"),s.Sb(42,"mat-label"),s.yc(43,"LastUpdateContactTVItemID"),s.Rb(),s.Nb(44,"input",11),s.xc(45,J,6,4,"mat-error",4),s.Rb(),s.Rb(),s.Rb()),2&t&&(s.hc("formGroup",e.logFormEdit),s.Bb(5),s.Ac("",e.GetPut()?"Put":"Post"," Log"),s.Bb(1),s.hc("ngIf",e.logService.logPutModel$.getValue().Working),s.Bb(1),s.hc("ngIf",e.logService.logPostModel$.getValue().Working),s.Bb(6),s.hc("ngIf",e.logFormEdit.controls.LogID.errors),s.Bb(5),s.hc("ngIf",e.logFormEdit.controls.TableName.errors),s.Bb(5),s.hc("ngIf",e.logFormEdit.controls.ID.errors),s.Bb(5),s.hc("ngForOf",e.logCommandList),s.Bb(1),s.hc("ngIf",e.logFormEdit.controls.LogCommand.errors),s.Bb(6),s.hc("ngIf",e.logFormEdit.controls.Information.errors),s.Bb(5),s.hc("ngIf",e.logFormEdit.controls.LastUpdateDate_UTC.errors),s.Bb(5),s.hc("ngIf",e.logFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[D.q,D.l,D.f,y.b,r.l,L.c,L.f,C.b,D.n,D.c,D.k,D.e,T.a,r.k,I.a,L.b,x.n],pipes:[r.f],styles:[""],changeDetection:0}),_);function Y(t,e){1&t&&s.Nb(0,"mat-progress-bar",4)}function K(t,e){1&t&&s.Nb(0,"mat-progress-bar",4)}function X(t,e){if(1&t&&(s.Sb(0,"p"),s.Nb(1,"app-log-edit",8),s.Rb()),2&t){var o=s.cc().$implicit,n=s.cc(2);s.Bb(1),s.hc("log",o)("httpClientCommand",n.GetPutEnum())}}function Q(t,e){if(1&t&&(s.Sb(0,"p"),s.Nb(1,"app-log-edit",8),s.Rb()),2&t){var o=s.cc().$implicit,n=s.cc(2);s.Bb(1),s.hc("log",o)("httpClientCommand",n.GetPostEnum())}}function Z(t,e){if(1&t){var o=s.Tb();s.Sb(0,"div"),s.Sb(1,"p"),s.Sb(2,"button",6),s.Yb("click",(function(){s.pc(o);var t=e.$implicit;return s.cc(2).DeleteLog(t)})),s.Sb(3,"span"),s.yc(4),s.Rb(),s.Sb(5,"mat-icon"),s.yc(6,"delete"),s.Rb(),s.Rb(),s.yc(7,"\xa0\xa0\xa0 "),s.Sb(8,"button",7),s.Yb("click",(function(){s.pc(o);var t=e.$implicit;return s.cc(2).ShowPut(t)})),s.Sb(9,"span"),s.yc(10,"Show Put"),s.Rb(),s.Rb(),s.yc(11,"\xa0\xa0 "),s.Sb(12,"button",7),s.Yb("click",(function(){s.pc(o);var t=e.$implicit;return s.cc(2).ShowPost(t)})),s.Sb(13,"span"),s.yc(14,"Show Post"),s.Rb(),s.Rb(),s.yc(15,"\xa0\xa0 "),s.xc(16,K,1,0,"mat-progress-bar",0),s.Rb(),s.xc(17,X,2,2,"p",2),s.xc(18,Q,2,2,"p",2),s.Sb(19,"blockquote"),s.Sb(20,"p"),s.Sb(21,"span"),s.yc(22),s.Rb(),s.Sb(23,"span"),s.yc(24),s.Rb(),s.Sb(25,"span"),s.yc(26),s.Rb(),s.Sb(27,"span"),s.yc(28),s.Rb(),s.Rb(),s.Sb(29,"p"),s.Sb(30,"span"),s.yc(31),s.Rb(),s.Sb(32,"span"),s.yc(33),s.Rb(),s.Sb(34,"span"),s.yc(35),s.Rb(),s.Rb(),s.Rb(),s.Rb()}if(2&t){var n=e.$implicit,i=s.cc(2);s.Bb(4),s.Ac("Delete LogID [",n.LogID,"]\xa0\xa0\xa0"),s.Bb(4),s.hc("color",i.GetPutButtonColor(n)),s.Bb(4),s.hc("color",i.GetPostButtonColor(n)),s.Bb(4),s.hc("ngIf",i.logService.logDeleteModel$.getValue().Working),s.Bb(1),s.hc("ngIf",i.IDToShow===n.LogID&&i.showType===i.GetPutEnum()),s.Bb(1),s.hc("ngIf",i.IDToShow===n.LogID&&i.showType===i.GetPostEnum()),s.Bb(4),s.Ac("LogID: [",n.LogID,"]"),s.Bb(2),s.Ac(" --- TableName: [",n.TableName,"]"),s.Bb(2),s.Ac(" --- ID: [",n.ID,"]"),s.Bb(2),s.Ac(" --- LogCommand: [",i.GetLogCommandEnumText(n.LogCommand),"]"),s.Bb(3),s.Ac("Information: [",n.Information,"]"),s.Bb(2),s.Ac(" --- LastUpdateDate_UTC: [",n.LastUpdateDate_UTC,"]"),s.Bb(2),s.Ac(" --- LastUpdateContactTVItemID: [",n.LastUpdateContactTVItemID,"]")}}function tt(t,e){if(1&t&&(s.Sb(0,"div"),s.xc(1,Z,36,13,"div",5),s.Rb()),2&t){var o=s.cc();s.Bb(1),s.hc("ngForOf",o.logService.logListModel$.getValue())}}var et,ot,nt,it=[{path:"",component:(et=function(){function e(o,n,i){t(this,e),this.logService=o,this.router=n,this.httpClientService=i,this.showType=null,i.oldURL=n.url}return o(e,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.LogID&&this.showType===b.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.LogID&&this.showType===b.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.LogID&&this.showType===b.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.LogID,this.showType=b.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.LogID&&this.showType===b.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.LogID,this.showType=b.a.Post)}},{key:"GetPutEnum",value:function(){return b.a.Put}},{key:"GetPostEnum",value:function(){return b.a.Post}},{key:"GetLogList",value:function(){this.sub=this.logService.GetLogList().subscribe()}},{key:"DeleteLog",value:function(t){this.sub=this.logService.DeleteLog(t).subscribe()}},{key:"GetLogCommandEnumText",value:function(t){return function(t){var e;return l().forEach((function(o){if(o.EnumID==t)return e=o.EnumText,!1})),e}(t)}},{key:"ngOnInit",value:function(){c(this.logService.logTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),e}(),et.\u0275fac=function(t){return new(t||et)(s.Mb(S),s.Mb(a.b),s.Mb(d.a))},et.\u0275cmp=s.Gb({type:et,selectors:[["app-log"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"log","httpClientCommand"]],template:function(t,e){var o,n;1&t&&(s.xc(0,Y,1,0,"mat-progress-bar",0),s.Sb(1,"mat-card"),s.Sb(2,"mat-card-header"),s.Sb(3,"mat-card-title"),s.yc(4," Log works! "),s.Sb(5,"button",1),s.Yb("click",(function(){return e.GetLogList()})),s.Sb(6,"span"),s.yc(7,"Get Log"),s.Rb(),s.Rb(),s.Rb(),s.Sb(8,"mat-card-subtitle"),s.yc(9),s.Rb(),s.Rb(),s.Sb(10,"mat-card-content"),s.xc(11,tt,2,1,"div",2),s.Rb(),s.Sb(12,"mat-card-actions"),s.Sb(13,"button",3),s.yc(14,"Allo"),s.Rb(),s.Rb(),s.Rb()),2&t&&(s.hc("ngIf",null==(o=e.logService.logGetModel$.getValue())?null:o.Working),s.Bb(9),s.zc(e.logService.logTextModel$.getValue().Title),s.Bb(2),s.hc("ngIf",null==(n=e.logService.logListModel$.getValue())?null:n.length))},directives:[r.l,v.a,v.d,v.g,y.b,v.f,v.c,v.b,I.a,r.k,R.a,H],styles:[""],changeDetection:0}),et),canActivate:[i("auXs").a]}],rt=((ot=function e(){t(this,e)}).\u0275mod=s.Kb({type:ot}),ot.\u0275inj=s.Jb({factory:function(t){return new(t||ot)},imports:[[a.e.forChild(it)],a.e]}),ot),at=i("B+Mi"),ct=((nt=function e(){t(this,e)}).\u0275mod=s.Kb({type:nt}),nt.\u0275inj=s.Jb({factory:function(t){return new(t||nt)},imports:[[r.c,a.e,rt,at.a,D.g,D.o]]}),nt)},gkM4:function(e,n,i){"use strict";i.d(n,"a",(function(){return l}));var r=i("QRvi"),a=i("fXoL"),c=i("tyNb"),l=function(){var e=function(){function e(o){t(this,e),this.router=o,this.oldURL=o.url}return o(e,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,e,o){t.next(null),e.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,e,o){t.next(null),e.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,e,o,n,i){if(n===r.a.Get&&t.next(o),n===r.a.Put&&(t.getValue()[0]=o),n===r.a.Post&&t.getValue().push(o),n===r.a.Delete){var a=t.getValue().indexOf(i);t.getValue().splice(a,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,e,o,n,i){n===r.a.Get&&t.next(o),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(a.Wb(c.b))},e.\u0275prov=a.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()}}])}();