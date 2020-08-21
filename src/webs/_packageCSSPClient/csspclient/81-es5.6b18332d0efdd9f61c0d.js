!function(){function e(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function t(e,t){for(var a=0;a<t.length;a++){var n=t[a];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(e,n.key,n)}}function a(e,a,n){return a&&t(e.prototype,a),n&&t(e,n),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[81],{QRvi:function(e,t,a){"use strict";a.d(t,"a",(function(){return n}));var n=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},Y3pN:function(t,n,i){"use strict";i.r(n),i.d(n,"SamplingPlanEmailModule",(function(){return pe}));var l=i("ofXK"),r=i("tyNb");function o(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var c,p=i("QRvi"),m=i("fXoL"),s=i("2Vo4"),b=i("LRne"),u=i("tk/3"),f=i("lJxs"),S=i("JIr8"),d=i("gkM4"),g=((c=function(){function t(a,n){e(this,t),this.httpClient=a,this.httpClientService=n,this.samplingplanemailTextModel$=new s.a({}),this.samplingplanemailListModel$=new s.a({}),this.samplingplanemailGetModel$=new s.a({}),this.samplingplanemailPutModel$=new s.a({}),this.samplingplanemailPostModel$=new s.a({}),this.samplingplanemailDeleteModel$=new s.a({}),o(this.samplingplanemailTextModel$),this.samplingplanemailTextModel$.next({Title:"Something2 for text"})}return a(t,[{key:"GetSamplingPlanEmailList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.samplingplanemailGetModel$),this.httpClient.get("/api/SamplingPlanEmail").pipe(Object(f.a)((function(t){e.httpClientService.DoSuccess(e.samplingplanemailListModel$,e.samplingplanemailGetModel$,t,p.a.Get,null)})),Object(S.a)((function(t){return Object(b.a)(t).pipe(Object(f.a)((function(t){e.httpClientService.DoCatchError(e.samplingplanemailListModel$,e.samplingplanemailGetModel$,t)})))})))}},{key:"PutSamplingPlanEmail",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.samplingplanemailPutModel$),this.httpClient.put("/api/SamplingPlanEmail",e,{headers:new u.d}).pipe(Object(f.a)((function(a){t.httpClientService.DoSuccess(t.samplingplanemailListModel$,t.samplingplanemailPutModel$,a,p.a.Put,e)})),Object(S.a)((function(e){return Object(b.a)(e).pipe(Object(f.a)((function(e){t.httpClientService.DoCatchError(t.samplingplanemailListModel$,t.samplingplanemailPutModel$,e)})))})))}},{key:"PostSamplingPlanEmail",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.samplingplanemailPostModel$),this.httpClient.post("/api/SamplingPlanEmail",e,{headers:new u.d}).pipe(Object(f.a)((function(a){t.httpClientService.DoSuccess(t.samplingplanemailListModel$,t.samplingplanemailPostModel$,a,p.a.Post,e)})),Object(S.a)((function(e){return Object(b.a)(e).pipe(Object(f.a)((function(e){t.httpClientService.DoCatchError(t.samplingplanemailListModel$,t.samplingplanemailPostModel$,e)})))})))}},{key:"DeleteSamplingPlanEmail",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.samplingplanemailDeleteModel$),this.httpClient.delete("/api/SamplingPlanEmail/"+e.SamplingPlanEmailID).pipe(Object(f.a)((function(a){t.httpClientService.DoSuccess(t.samplingplanemailListModel$,t.samplingplanemailDeleteModel$,a,p.a.Delete,e)})),Object(S.a)((function(e){return Object(b.a)(e).pipe(Object(f.a)((function(e){t.httpClientService.DoCatchError(t.samplingplanemailListModel$,t.samplingplanemailDeleteModel$,e)})))})))}}]),t}()).\u0275fac=function(e){return new(e||c)(m.Wb(u.b),m.Wb(d.a))},c.\u0275prov=m.Ib({token:c,factory:c.\u0275fac,providedIn:"root"}),c),h=i("Wp6s"),v=i("bTqV"),R=i("bv9b"),I=i("NFeN"),P=i("3Pt+"),y=i("kmnG"),C=i("qFsG");function E(e,t){1&e&&m.Nb(0,"mat-progress-bar",14)}function D(e,t){1&e&&m.Nb(0,"mat-progress-bar",14)}function B(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function L(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,B,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,a)),m.Bb(3),m.ic("ngIf",a.required)}}function k(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function z(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,k,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,a)),m.Bb(3),m.ic("ngIf",a.required)}}function N(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function $(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Need valid Email"),m.Nb(2,"br"),m.Rb())}function w(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"MaxLength - 150"),m.Nb(2,"br"),m.Rb())}function T(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,N,3,0,"span",4),m.yc(6,$,3,0,"span",4),m.yc(7,w,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,4,a)),m.Bb(3),m.ic("ngIf",a.required),m.Bb(1),m.ic("ngIf",a.email),m.Bb(1),m.ic("ngIf",a.maxlength)}}function M(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function q(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,M,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,a)),m.Bb(3),m.ic("ngIf",a.required)}}function j(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function G(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,j,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,a)),m.Bb(3),m.ic("ngIf",a.required)}}function x(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function O(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,x,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,a)),m.Bb(3),m.ic("ngIf",a.required)}}function V(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function U(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,V,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,a)),m.Bb(3),m.ic("ngIf",a.required)}}function F(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function A(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,F,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,a)),m.Bb(3),m.ic("ngIf",a.required)}}function W(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function H(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,W,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,a)),m.Bb(3),m.ic("ngIf",a.required)}}function _(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function J(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,_,3,0,"span",4),m.Rb()),2&e){var a=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,a)),m.Bb(3),m.ic("ngIf",a.required)}}var Z,X=((Z=function(){function t(a,n){e(this,t),this.samplingplanemailService=a,this.fb=n,this.samplingplanemail=null,this.httpClientCommand=p.a.Put}return a(t,[{key:"GetPut",value:function(){return this.httpClientCommand==p.a.Put}},{key:"PutSamplingPlanEmail",value:function(e){this.sub=this.samplingplanemailService.PutSamplingPlanEmail(e).subscribe()}},{key:"PostSamplingPlanEmail",value:function(e){this.sub=this.samplingplanemailService.PostSamplingPlanEmail(e).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.samplingplanemail){var t=this.fb.group({SamplingPlanEmailID:[{value:e===p.a.Post?0:this.samplingplanemail.SamplingPlanEmailID,disabled:!1},[P.p.required]],SamplingPlanID:[{value:this.samplingplanemail.SamplingPlanID,disabled:!1},[P.p.required]],Email:[{value:this.samplingplanemail.Email,disabled:!1},[P.p.required,P.p.email,P.p.maxLength(150)]],IsContractor:[{value:this.samplingplanemail.IsContractor,disabled:!1},[P.p.required]],LabSheetHasValueOver500:[{value:this.samplingplanemail.LabSheetHasValueOver500,disabled:!1},[P.p.required]],LabSheetReceived:[{value:this.samplingplanemail.LabSheetReceived,disabled:!1},[P.p.required]],LabSheetAccepted:[{value:this.samplingplanemail.LabSheetAccepted,disabled:!1},[P.p.required]],LabSheetRejected:[{value:this.samplingplanemail.LabSheetRejected,disabled:!1},[P.p.required]],LastUpdateDate_UTC:[{value:this.samplingplanemail.LastUpdateDate_UTC,disabled:!1},[P.p.required]],LastUpdateContactTVItemID:[{value:this.samplingplanemail.LastUpdateContactTVItemID,disabled:!1},[P.p.required]]});this.samplingplanemailFormEdit=t}}}]),t}()).\u0275fac=function(e){return new(e||Z)(m.Mb(g),m.Mb(P.d))},Z.\u0275cmp=m.Gb({type:Z,selectors:[["app-samplingplanemail-edit"]],inputs:{samplingplanemail:"samplingplanemail",httpClientCommand:"httpClientCommand"},decls:61,vars:14,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","SamplingPlanEmailID"],[4,"ngIf"],["matInput","","type","number","formControlName","SamplingPlanID"],["matInput","","type","text","formControlName","Email"],["matInput","","type","text","formControlName","IsContractor"],["matInput","","type","text","formControlName","LabSheetHasValueOver500"],["matInput","","type","text","formControlName","LabSheetReceived"],["matInput","","type","text","formControlName","LabSheetAccepted"],["matInput","","type","text","formControlName","LabSheetRejected"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(e,t){1&e&&(m.Sb(0,"form",0),m.Zb("ngSubmit",(function(){return t.GetPut()?t.PutSamplingPlanEmail(t.samplingplanemailFormEdit.value):t.PostSamplingPlanEmail(t.samplingplanemailFormEdit.value)})),m.Sb(1,"h3"),m.zc(2," SamplingPlanEmail "),m.Sb(3,"button",1),m.Sb(4,"span"),m.zc(5),m.Rb(),m.Rb(),m.yc(6,E,1,0,"mat-progress-bar",2),m.yc(7,D,1,0,"mat-progress-bar",2),m.Rb(),m.Sb(8,"p"),m.Sb(9,"mat-form-field"),m.Sb(10,"mat-label"),m.zc(11,"SamplingPlanEmailID"),m.Rb(),m.Nb(12,"input",3),m.yc(13,L,6,4,"mat-error",4),m.Rb(),m.Sb(14,"mat-form-field"),m.Sb(15,"mat-label"),m.zc(16,"SamplingPlanID"),m.Rb(),m.Nb(17,"input",5),m.yc(18,z,6,4,"mat-error",4),m.Rb(),m.Sb(19,"mat-form-field"),m.Sb(20,"mat-label"),m.zc(21,"Email"),m.Rb(),m.Nb(22,"input",6),m.yc(23,T,8,6,"mat-error",4),m.Rb(),m.Sb(24,"mat-form-field"),m.Sb(25,"mat-label"),m.zc(26,"IsContractor"),m.Rb(),m.Nb(27,"input",7),m.yc(28,q,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Sb(29,"p"),m.Sb(30,"mat-form-field"),m.Sb(31,"mat-label"),m.zc(32,"LabSheetHasValueOver500"),m.Rb(),m.Nb(33,"input",8),m.yc(34,G,6,4,"mat-error",4),m.Rb(),m.Sb(35,"mat-form-field"),m.Sb(36,"mat-label"),m.zc(37,"LabSheetReceived"),m.Rb(),m.Nb(38,"input",9),m.yc(39,O,6,4,"mat-error",4),m.Rb(),m.Sb(40,"mat-form-field"),m.Sb(41,"mat-label"),m.zc(42,"LabSheetAccepted"),m.Rb(),m.Nb(43,"input",10),m.yc(44,U,6,4,"mat-error",4),m.Rb(),m.Sb(45,"mat-form-field"),m.Sb(46,"mat-label"),m.zc(47,"LabSheetRejected"),m.Rb(),m.Nb(48,"input",11),m.yc(49,A,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Sb(50,"p"),m.Sb(51,"mat-form-field"),m.Sb(52,"mat-label"),m.zc(53,"LastUpdateDate_UTC"),m.Rb(),m.Nb(54,"input",12),m.yc(55,H,6,4,"mat-error",4),m.Rb(),m.Sb(56,"mat-form-field"),m.Sb(57,"mat-label"),m.zc(58,"LastUpdateContactTVItemID"),m.Rb(),m.Nb(59,"input",13),m.yc(60,J,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Rb()),2&e&&(m.ic("formGroup",t.samplingplanemailFormEdit),m.Bb(5),m.Bc("",t.GetPut()?"Put":"Post"," SamplingPlanEmail"),m.Bb(1),m.ic("ngIf",t.samplingplanemailService.samplingplanemailPutModel$.getValue().Working),m.Bb(1),m.ic("ngIf",t.samplingplanemailService.samplingplanemailPostModel$.getValue().Working),m.Bb(6),m.ic("ngIf",t.samplingplanemailFormEdit.controls.SamplingPlanEmailID.errors),m.Bb(5),m.ic("ngIf",t.samplingplanemailFormEdit.controls.SamplingPlanID.errors),m.Bb(5),m.ic("ngIf",t.samplingplanemailFormEdit.controls.Email.errors),m.Bb(5),m.ic("ngIf",t.samplingplanemailFormEdit.controls.IsContractor.errors),m.Bb(6),m.ic("ngIf",t.samplingplanemailFormEdit.controls.LabSheetHasValueOver500.errors),m.Bb(5),m.ic("ngIf",t.samplingplanemailFormEdit.controls.LabSheetReceived.errors),m.Bb(5),m.ic("ngIf",t.samplingplanemailFormEdit.controls.LabSheetAccepted.errors),m.Bb(5),m.ic("ngIf",t.samplingplanemailFormEdit.controls.LabSheetRejected.errors),m.Bb(6),m.ic("ngIf",t.samplingplanemailFormEdit.controls.LastUpdateDate_UTC.errors),m.Bb(5),m.ic("ngIf",t.samplingplanemailFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[P.q,P.l,P.f,v.b,l.l,y.c,y.f,C.b,P.n,P.c,P.k,P.e,R.a,y.b],pipes:[l.f],styles:[""],changeDetection:0}),Z);function K(e,t){1&e&&m.Nb(0,"mat-progress-bar",4)}function Q(e,t){1&e&&m.Nb(0,"mat-progress-bar",4)}function Y(e,t){if(1&e&&(m.Sb(0,"p"),m.Nb(1,"app-samplingplanemail-edit",8),m.Rb()),2&e){var a=m.dc().$implicit,n=m.dc(2);m.Bb(1),m.ic("samplingplanemail",a)("httpClientCommand",n.GetPutEnum())}}function ee(e,t){if(1&e&&(m.Sb(0,"p"),m.Nb(1,"app-samplingplanemail-edit",8),m.Rb()),2&e){var a=m.dc().$implicit,n=m.dc(2);m.Bb(1),m.ic("samplingplanemail",a)("httpClientCommand",n.GetPostEnum())}}function te(e,t){if(1&e){var a=m.Tb();m.Sb(0,"div"),m.Sb(1,"p"),m.Sb(2,"button",6),m.Zb("click",(function(){m.qc(a);var e=t.$implicit;return m.dc(2).DeleteSamplingPlanEmail(e)})),m.Sb(3,"span"),m.zc(4),m.Rb(),m.Sb(5,"mat-icon"),m.zc(6,"delete"),m.Rb(),m.Rb(),m.zc(7,"\xa0\xa0\xa0 "),m.Sb(8,"button",7),m.Zb("click",(function(){m.qc(a);var e=t.$implicit;return m.dc(2).ShowPut(e)})),m.Sb(9,"span"),m.zc(10,"Show Put"),m.Rb(),m.Rb(),m.zc(11,"\xa0\xa0 "),m.Sb(12,"button",7),m.Zb("click",(function(){m.qc(a);var e=t.$implicit;return m.dc(2).ShowPost(e)})),m.Sb(13,"span"),m.zc(14,"Show Post"),m.Rb(),m.Rb(),m.zc(15,"\xa0\xa0 "),m.yc(16,Q,1,0,"mat-progress-bar",0),m.Rb(),m.yc(17,Y,2,2,"p",2),m.yc(18,ee,2,2,"p",2),m.Sb(19,"blockquote"),m.Sb(20,"p"),m.Sb(21,"span"),m.zc(22),m.Rb(),m.Sb(23,"span"),m.zc(24),m.Rb(),m.Sb(25,"span"),m.zc(26),m.Rb(),m.Sb(27,"span"),m.zc(28),m.Rb(),m.Rb(),m.Sb(29,"p"),m.Sb(30,"span"),m.zc(31),m.Rb(),m.Sb(32,"span"),m.zc(33),m.Rb(),m.Sb(34,"span"),m.zc(35),m.Rb(),m.Sb(36,"span"),m.zc(37),m.Rb(),m.Rb(),m.Sb(38,"p"),m.Sb(39,"span"),m.zc(40),m.Rb(),m.Sb(41,"span"),m.zc(42),m.Rb(),m.Rb(),m.Rb(),m.Rb()}if(2&e){var n=t.$implicit,i=m.dc(2);m.Bb(4),m.Bc("Delete SamplingPlanEmailID [",n.SamplingPlanEmailID,"]\xa0\xa0\xa0"),m.Bb(4),m.ic("color",i.GetPutButtonColor(n)),m.Bb(4),m.ic("color",i.GetPostButtonColor(n)),m.Bb(4),m.ic("ngIf",i.samplingplanemailService.samplingplanemailDeleteModel$.getValue().Working),m.Bb(1),m.ic("ngIf",i.IDToShow===n.SamplingPlanEmailID&&i.showType===i.GetPutEnum()),m.Bb(1),m.ic("ngIf",i.IDToShow===n.SamplingPlanEmailID&&i.showType===i.GetPostEnum()),m.Bb(4),m.Bc("SamplingPlanEmailID: [",n.SamplingPlanEmailID,"]"),m.Bb(2),m.Bc(" --- SamplingPlanID: [",n.SamplingPlanID,"]"),m.Bb(2),m.Bc(" --- Email: [",n.Email,"]"),m.Bb(2),m.Bc(" --- IsContractor: [",n.IsContractor,"]"),m.Bb(3),m.Bc("LabSheetHasValueOver500: [",n.LabSheetHasValueOver500,"]"),m.Bb(2),m.Bc(" --- LabSheetReceived: [",n.LabSheetReceived,"]"),m.Bb(2),m.Bc(" --- LabSheetAccepted: [",n.LabSheetAccepted,"]"),m.Bb(2),m.Bc(" --- LabSheetRejected: [",n.LabSheetRejected,"]"),m.Bb(3),m.Bc("LastUpdateDate_UTC: [",n.LastUpdateDate_UTC,"]"),m.Bb(2),m.Bc(" --- LastUpdateContactTVItemID: [",n.LastUpdateContactTVItemID,"]")}}function ae(e,t){if(1&e&&(m.Sb(0,"div"),m.yc(1,te,43,16,"div",5),m.Rb()),2&e){var a=m.dc();m.Bb(1),m.ic("ngForOf",a.samplingplanemailService.samplingplanemailListModel$.getValue())}}var ne,ie,le,re=[{path:"",component:(ne=function(){function t(a,n,i){e(this,t),this.samplingplanemailService=a,this.router=n,this.httpClientService=i,this.showType=null,i.oldURL=n.url}return a(t,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.SamplingPlanEmailID&&this.showType===p.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.SamplingPlanEmailID&&this.showType===p.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.SamplingPlanEmailID&&this.showType===p.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.SamplingPlanEmailID,this.showType=p.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.SamplingPlanEmailID&&this.showType===p.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.SamplingPlanEmailID,this.showType=p.a.Post)}},{key:"GetPutEnum",value:function(){return p.a.Put}},{key:"GetPostEnum",value:function(){return p.a.Post}},{key:"GetSamplingPlanEmailList",value:function(){this.sub=this.samplingplanemailService.GetSamplingPlanEmailList().subscribe()}},{key:"DeleteSamplingPlanEmail",value:function(e){this.sub=this.samplingplanemailService.DeleteSamplingPlanEmail(e).subscribe()}},{key:"ngOnInit",value:function(){o(this.samplingplanemailService.samplingplanemailTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),t}(),ne.\u0275fac=function(e){return new(e||ne)(m.Mb(g),m.Mb(r.b),m.Mb(d.a))},ne.\u0275cmp=m.Gb({type:ne,selectors:[["app-samplingplanemail"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"samplingplanemail","httpClientCommand"]],template:function(e,t){var a,n;1&e&&(m.yc(0,K,1,0,"mat-progress-bar",0),m.Sb(1,"mat-card"),m.Sb(2,"mat-card-header"),m.Sb(3,"mat-card-title"),m.zc(4," SamplingPlanEmail works! "),m.Sb(5,"button",1),m.Zb("click",(function(){return t.GetSamplingPlanEmailList()})),m.Sb(6,"span"),m.zc(7,"Get SamplingPlanEmail"),m.Rb(),m.Rb(),m.Rb(),m.Sb(8,"mat-card-subtitle"),m.zc(9),m.Rb(),m.Rb(),m.Sb(10,"mat-card-content"),m.yc(11,ae,2,1,"div",2),m.Rb(),m.Sb(12,"mat-card-actions"),m.Sb(13,"button",3),m.zc(14,"Allo"),m.Rb(),m.Rb(),m.Rb()),2&e&&(m.ic("ngIf",null==(a=t.samplingplanemailService.samplingplanemailGetModel$.getValue())?null:a.Working),m.Bb(9),m.Ac(t.samplingplanemailService.samplingplanemailTextModel$.getValue().Title),m.Bb(2),m.ic("ngIf",null==(n=t.samplingplanemailService.samplingplanemailListModel$.getValue())?null:n.length))},directives:[l.l,h.a,h.d,h.g,v.b,h.f,h.c,h.b,R.a,l.k,I.a,X],styles:[""],changeDetection:0}),ne),canActivate:[i("auXs").a]}],oe=((ie=function t(){e(this,t)}).\u0275mod=m.Kb({type:ie}),ie.\u0275inj=m.Jb({factory:function(e){return new(e||ie)},imports:[[r.e.forChild(re)],r.e]}),ie),ce=i("B+Mi"),pe=((le=function t(){e(this,t)}).\u0275mod=m.Kb({type:le}),le.\u0275inj=m.Jb({factory:function(e){return new(e||le)},imports:[[l.c,r.e,oe,ce.a,P.g,P.o]]}),le)},gkM4:function(t,n,i){"use strict";i.d(n,"a",(function(){return c}));var l=i("QRvi"),r=i("fXoL"),o=i("tyNb"),c=function(){var t=function(){function t(a){e(this,t),this.router=a,this.oldURL=a.url}return a(t,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,t,a){e.next(null),t.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(e,t,a){e.next(null),t.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,t,a,n,i){if(n===l.a.Get&&e.next(a),n===l.a.Put&&(e.getValue()[0]=a),n===l.a.Post&&e.getValue().push(a),n===l.a.Delete){var r=e.getValue().indexOf(i);e.getValue().splice(r,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(e,t,a,n,i){n===l.a.Get&&e.next(a),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),t}();return t.\u0275fac=function(e){return new(e||t)(r.Wb(o.b))},t.\u0275prov=r.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t}()}}])}();