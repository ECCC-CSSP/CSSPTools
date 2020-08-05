!function(){function e(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function t(e,t){for(var n=0;n<t.length;n++){var i=t[n];i.enumerable=i.enumerable||!1,i.configurable=!0,"value"in i&&(i.writable=!0),Object.defineProperty(e,i.key,i)}}function n(e,n,i){return n&&t(e.prototype,n),i&&t(e,i),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[75],{QRvi:function(e,t,n){"use strict";n.d(t,"a",(function(){return i}));var i=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},R7CB:function(t,i,a){"use strict";a.r(i),a.d(i,"RainExceedanceModule",(function(){return xe}));var c=a("ofXK"),r=a("tyNb");function o(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var b,s=a("QRvi"),u=a("fXoL"),d=a("2Vo4"),l=a("LRne"),m=a("tk/3"),p=a("lJxs"),f=a("JIr8"),S=a("gkM4"),R=((b=function(){function t(n,i){e(this,t),this.httpClient=n,this.httpClientService=i,this.rainexceedanceTextModel$=new d.a({}),this.rainexceedanceListModel$=new d.a({}),this.rainexceedanceGetModel$=new d.a({}),this.rainexceedancePutModel$=new d.a({}),this.rainexceedancePostModel$=new d.a({}),this.rainexceedanceDeleteModel$=new d.a({}),o(this.rainexceedanceTextModel$),this.rainexceedanceTextModel$.next({Title:"Something2 for text"})}return n(t,[{key:"GetRainExceedanceList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.rainexceedanceGetModel$),this.httpClient.get("/api/RainExceedance").pipe(Object(p.a)((function(t){e.httpClientService.DoSuccess(e.rainexceedanceListModel$,e.rainexceedanceGetModel$,t,s.a.Get,null)})),Object(f.a)((function(t){return Object(l.a)(t).pipe(Object(p.a)((function(t){e.httpClientService.DoCatchError(e.rainexceedanceListModel$,e.rainexceedanceGetModel$,t)})))})))}},{key:"PutRainExceedance",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.rainexceedancePutModel$),this.httpClient.put("/api/RainExceedance",e,{headers:new m.d}).pipe(Object(p.a)((function(n){t.httpClientService.DoSuccess(t.rainexceedanceListModel$,t.rainexceedancePutModel$,n,s.a.Put,e)})),Object(f.a)((function(e){return Object(l.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.rainexceedanceListModel$,t.rainexceedancePutModel$,e)})))})))}},{key:"PostRainExceedance",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.rainexceedancePostModel$),this.httpClient.post("/api/RainExceedance",e,{headers:new m.d}).pipe(Object(p.a)((function(n){t.httpClientService.DoSuccess(t.rainexceedanceListModel$,t.rainexceedancePostModel$,n,s.a.Post,e)})),Object(f.a)((function(e){return Object(l.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.rainexceedanceListModel$,t.rainexceedancePostModel$,e)})))})))}},{key:"DeleteRainExceedance",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.rainexceedanceDeleteModel$),this.httpClient.delete("/api/RainExceedance/"+e.RainExceedanceID).pipe(Object(p.a)((function(n){t.httpClientService.DoSuccess(t.rainexceedanceListModel$,t.rainexceedanceDeleteModel$,n,s.a.Delete,e)})),Object(f.a)((function(e){return Object(l.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.rainexceedanceListModel$,t.rainexceedanceDeleteModel$,e)})))})))}}]),t}()).\u0275fac=function(e){return new(e||b)(u.Wb(m.b),u.Wb(S.a))},b.\u0275prov=u.Ib({token:b,factory:b.\u0275fac,providedIn:"root"}),b),h=a("Wp6s"),x=a("bTqV"),I=a("bv9b"),v=a("NFeN"),y=a("3Pt+"),D=a("kmnG"),E=a("qFsG");function g(e,t){1&e&&u.Nb(0,"mat-progress-bar",16)}function B(e,t){1&e&&u.Nb(0,"mat-progress-bar",16)}function C(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function M(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,C,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,2,n)),u.Bb(3),u.ic("ngIf",n.required)}}function z(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function N(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,z,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,2,n)),u.Bb(3),u.ic("ngIf",n.required)}}function k(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function P(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Min - 1"),u.Nb(2,"br"),u.Rb())}function T(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Max - 12"),u.Nb(2,"br"),u.Rb())}function $(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,k,3,0,"span",4),u.yc(6,P,3,0,"span",4),u.yc(7,T,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,4,n)),u.Bb(3),u.ic("ngIf",n.required),u.Bb(1),u.ic("ngIf",n.min),u.Bb(1),u.ic("ngIf",n.min)}}function w(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function L(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Min - 1"),u.Nb(2,"br"),u.Rb())}function q(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Max - 31"),u.Nb(2,"br"),u.Rb())}function G(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,w,3,0,"span",4),u.yc(6,L,3,0,"span",4),u.yc(7,q,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,4,n)),u.Bb(3),u.ic("ngIf",n.required),u.Bb(1),u.ic("ngIf",n.min),u.Bb(1),u.ic("ngIf",n.min)}}function j(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function O(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Min - 1"),u.Nb(2,"br"),u.Rb())}function V(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Max - 12"),u.Nb(2,"br"),u.Rb())}function F(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,j,3,0,"span",4),u.yc(6,O,3,0,"span",4),u.yc(7,V,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,4,n)),u.Bb(3),u.ic("ngIf",n.required),u.Bb(1),u.ic("ngIf",n.min),u.Bb(1),u.ic("ngIf",n.min)}}function U(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function A(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Min - 1"),u.Nb(2,"br"),u.Rb())}function _(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Max - 31"),u.Nb(2,"br"),u.Rb())}function W(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,U,3,0,"span",4),u.yc(6,A,3,0,"span",4),u.yc(7,_,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,4,n)),u.Bb(3),u.ic("ngIf",n.required),u.Bb(1),u.ic("ngIf",n.min),u.Bb(1),u.ic("ngIf",n.min)}}function J(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function H(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Min - 0"),u.Nb(2,"br"),u.Rb())}function Z(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Max - 300"),u.Nb(2,"br"),u.Rb())}function X(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,J,3,0,"span",4),u.yc(6,H,3,0,"span",4),u.yc(7,Z,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,4,n)),u.Bb(3),u.ic("ngIf",n.required),u.Bb(1),u.ic("ngIf",n.min),u.Bb(1),u.ic("ngIf",n.min)}}function K(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,1,n))}}function Q(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,1,n))}}function Y(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function ee(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,Y,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,2,n)),u.Bb(3),u.ic("ngIf",n.required)}}function te(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function ne(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,te,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,2,n)),u.Bb(3),u.ic("ngIf",n.required)}}function ie(e,t){1&e&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function ae(e,t){if(1&e&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,ie,3,0,"span",4),u.Rb()),2&e){var n=t.$implicit;u.Bb(2),u.Ac(u.fc(3,2,n)),u.Bb(3),u.ic("ngIf",n.required)}}var ce,re=((ce=function(){function t(n,i){e(this,t),this.rainexceedanceService=n,this.fb=i,this.rainexceedance=null,this.httpClientCommand=s.a.Put}return n(t,[{key:"GetPut",value:function(){return this.httpClientCommand==s.a.Put}},{key:"PutRainExceedance",value:function(e){this.sub=this.rainexceedanceService.PutRainExceedance(e).subscribe()}},{key:"PostRainExceedance",value:function(e){this.sub=this.rainexceedanceService.PostRainExceedance(e).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.rainexceedance){var t=this.fb.group({RainExceedanceID:[{value:e===s.a.Post?0:this.rainexceedance.RainExceedanceID,disabled:!1},[y.p.required]],RainExceedanceTVItemID:[{value:this.rainexceedance.RainExceedanceTVItemID,disabled:!1},[y.p.required]],StartMonth:[{value:this.rainexceedance.StartMonth,disabled:!1},[y.p.required,y.p.min(1),y.p.max(12)]],StartDay:[{value:this.rainexceedance.StartDay,disabled:!1},[y.p.required,y.p.min(1),y.p.max(31)]],EndMonth:[{value:this.rainexceedance.EndMonth,disabled:!1},[y.p.required,y.p.min(1),y.p.max(12)]],EndDay:[{value:this.rainexceedance.EndDay,disabled:!1},[y.p.required,y.p.min(1),y.p.max(31)]],RainMaximum_mm:[{value:this.rainexceedance.RainMaximum_mm,disabled:!1},[y.p.required,y.p.min(0),y.p.max(300)]],StakeholdersEmailDistributionListID:[{value:this.rainexceedance.StakeholdersEmailDistributionListID,disabled:!1}],OnlyStaffEmailDistributionListID:[{value:this.rainexceedance.OnlyStaffEmailDistributionListID,disabled:!1}],IsActive:[{value:this.rainexceedance.IsActive,disabled:!1},[y.p.required]],LastUpdateDate_UTC:[{value:this.rainexceedance.LastUpdateDate_UTC,disabled:!1},[y.p.required]],LastUpdateContactTVItemID:[{value:this.rainexceedance.LastUpdateContactTVItemID,disabled:!1},[y.p.required]]});this.rainexceedanceFormEdit=t}}}]),t}()).\u0275fac=function(e){return new(e||ce)(u.Mb(R),u.Mb(y.d))},ce.\u0275cmp=u.Gb({type:ce,selectors:[["app-rainexceedance-edit"]],inputs:{rainexceedance:"rainexceedance",httpClientCommand:"httpClientCommand"},decls:71,vars:16,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","RainExceedanceID"],[4,"ngIf"],["matInput","","type","number","formControlName","RainExceedanceTVItemID"],["matInput","","type","number","formControlName","StartMonth"],["matInput","","type","number","formControlName","StartDay"],["matInput","","type","number","formControlName","EndMonth"],["matInput","","type","number","formControlName","EndDay"],["matInput","","type","number","formControlName","RainMaximum_mm"],["matInput","","type","number","formControlName","StakeholdersEmailDistributionListID"],["matInput","","type","number","formControlName","OnlyStaffEmailDistributionListID"],["matInput","","type","text","formControlName","IsActive"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(e,t){1&e&&(u.Sb(0,"form",0),u.Zb("ngSubmit",(function(){return t.GetPut()?t.PutRainExceedance(t.rainexceedanceFormEdit.value):t.PostRainExceedance(t.rainexceedanceFormEdit.value)})),u.Sb(1,"h3"),u.zc(2," RainExceedance "),u.Sb(3,"button",1),u.Sb(4,"span"),u.zc(5),u.Rb(),u.Rb(),u.yc(6,g,1,0,"mat-progress-bar",2),u.yc(7,B,1,0,"mat-progress-bar",2),u.Rb(),u.Sb(8,"p"),u.Sb(9,"mat-form-field"),u.Sb(10,"mat-label"),u.zc(11,"RainExceedanceID"),u.Rb(),u.Nb(12,"input",3),u.yc(13,M,6,4,"mat-error",4),u.Rb(),u.Sb(14,"mat-form-field"),u.Sb(15,"mat-label"),u.zc(16,"RainExceedanceTVItemID"),u.Rb(),u.Nb(17,"input",5),u.yc(18,N,6,4,"mat-error",4),u.Rb(),u.Sb(19,"mat-form-field"),u.Sb(20,"mat-label"),u.zc(21,"StartMonth"),u.Rb(),u.Nb(22,"input",6),u.yc(23,$,8,6,"mat-error",4),u.Rb(),u.Sb(24,"mat-form-field"),u.Sb(25,"mat-label"),u.zc(26,"StartDay"),u.Rb(),u.Nb(27,"input",7),u.yc(28,G,8,6,"mat-error",4),u.Rb(),u.Rb(),u.Sb(29,"p"),u.Sb(30,"mat-form-field"),u.Sb(31,"mat-label"),u.zc(32,"EndMonth"),u.Rb(),u.Nb(33,"input",8),u.yc(34,F,8,6,"mat-error",4),u.Rb(),u.Sb(35,"mat-form-field"),u.Sb(36,"mat-label"),u.zc(37,"EndDay"),u.Rb(),u.Nb(38,"input",9),u.yc(39,W,8,6,"mat-error",4),u.Rb(),u.Sb(40,"mat-form-field"),u.Sb(41,"mat-label"),u.zc(42,"RainMaximum_mm"),u.Rb(),u.Nb(43,"input",10),u.yc(44,X,8,6,"mat-error",4),u.Rb(),u.Sb(45,"mat-form-field"),u.Sb(46,"mat-label"),u.zc(47,"StakeholdersEmailDistributionListID"),u.Rb(),u.Nb(48,"input",11),u.yc(49,K,5,3,"mat-error",4),u.Rb(),u.Rb(),u.Sb(50,"p"),u.Sb(51,"mat-form-field"),u.Sb(52,"mat-label"),u.zc(53,"OnlyStaffEmailDistributionListID"),u.Rb(),u.Nb(54,"input",12),u.yc(55,Q,5,3,"mat-error",4),u.Rb(),u.Sb(56,"mat-form-field"),u.Sb(57,"mat-label"),u.zc(58,"IsActive"),u.Rb(),u.Nb(59,"input",13),u.yc(60,ee,6,4,"mat-error",4),u.Rb(),u.Sb(61,"mat-form-field"),u.Sb(62,"mat-label"),u.zc(63,"LastUpdateDate_UTC"),u.Rb(),u.Nb(64,"input",14),u.yc(65,ne,6,4,"mat-error",4),u.Rb(),u.Sb(66,"mat-form-field"),u.Sb(67,"mat-label"),u.zc(68,"LastUpdateContactTVItemID"),u.Rb(),u.Nb(69,"input",15),u.yc(70,ae,6,4,"mat-error",4),u.Rb(),u.Rb(),u.Rb()),2&e&&(u.ic("formGroup",t.rainexceedanceFormEdit),u.Bb(5),u.Bc("",t.GetPut()?"Put":"Post"," RainExceedance"),u.Bb(1),u.ic("ngIf",t.rainexceedanceService.rainexceedancePutModel$.getValue().Working),u.Bb(1),u.ic("ngIf",t.rainexceedanceService.rainexceedancePostModel$.getValue().Working),u.Bb(6),u.ic("ngIf",t.rainexceedanceFormEdit.controls.RainExceedanceID.errors),u.Bb(5),u.ic("ngIf",t.rainexceedanceFormEdit.controls.RainExceedanceTVItemID.errors),u.Bb(5),u.ic("ngIf",t.rainexceedanceFormEdit.controls.StartMonth.errors),u.Bb(5),u.ic("ngIf",t.rainexceedanceFormEdit.controls.StartDay.errors),u.Bb(6),u.ic("ngIf",t.rainexceedanceFormEdit.controls.EndMonth.errors),u.Bb(5),u.ic("ngIf",t.rainexceedanceFormEdit.controls.EndDay.errors),u.Bb(5),u.ic("ngIf",t.rainexceedanceFormEdit.controls.RainMaximum_mm.errors),u.Bb(5),u.ic("ngIf",t.rainexceedanceFormEdit.controls.StakeholdersEmailDistributionListID.errors),u.Bb(6),u.ic("ngIf",t.rainexceedanceFormEdit.controls.OnlyStaffEmailDistributionListID.errors),u.Bb(5),u.ic("ngIf",t.rainexceedanceFormEdit.controls.IsActive.errors),u.Bb(5),u.ic("ngIf",t.rainexceedanceFormEdit.controls.LastUpdateDate_UTC.errors),u.Bb(5),u.ic("ngIf",t.rainexceedanceFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[y.q,y.l,y.f,x.b,c.l,D.c,D.f,E.b,y.n,y.c,y.k,y.e,I.a,D.b],pipes:[c.f],styles:[""],changeDetection:0}),ce);function oe(e,t){1&e&&u.Nb(0,"mat-progress-bar",4)}function be(e,t){1&e&&u.Nb(0,"mat-progress-bar",4)}function se(e,t){if(1&e&&(u.Sb(0,"p"),u.Nb(1,"app-rainexceedance-edit",8),u.Rb()),2&e){var n=u.dc().$implicit,i=u.dc(2);u.Bb(1),u.ic("rainexceedance",n)("httpClientCommand",i.GetPutEnum())}}function ue(e,t){if(1&e&&(u.Sb(0,"p"),u.Nb(1,"app-rainexceedance-edit",8),u.Rb()),2&e){var n=u.dc().$implicit,i=u.dc(2);u.Bb(1),u.ic("rainexceedance",n)("httpClientCommand",i.GetPostEnum())}}function de(e,t){if(1&e){var n=u.Tb();u.Sb(0,"div"),u.Sb(1,"p"),u.Sb(2,"button",6),u.Zb("click",(function(){u.qc(n);var e=t.$implicit;return u.dc(2).DeleteRainExceedance(e)})),u.Sb(3,"span"),u.zc(4),u.Rb(),u.Sb(5,"mat-icon"),u.zc(6,"delete"),u.Rb(),u.Rb(),u.zc(7,"\xa0\xa0\xa0 "),u.Sb(8,"button",7),u.Zb("click",(function(){u.qc(n);var e=t.$implicit;return u.dc(2).ShowPut(e)})),u.Sb(9,"span"),u.zc(10,"Show Put"),u.Rb(),u.Rb(),u.zc(11,"\xa0\xa0 "),u.Sb(12,"button",7),u.Zb("click",(function(){u.qc(n);var e=t.$implicit;return u.dc(2).ShowPost(e)})),u.Sb(13,"span"),u.zc(14,"Show Post"),u.Rb(),u.Rb(),u.zc(15,"\xa0\xa0 "),u.yc(16,be,1,0,"mat-progress-bar",0),u.Rb(),u.yc(17,se,2,2,"p",2),u.yc(18,ue,2,2,"p",2),u.Sb(19,"blockquote"),u.Sb(20,"p"),u.Sb(21,"span"),u.zc(22),u.Rb(),u.Sb(23,"span"),u.zc(24),u.Rb(),u.Sb(25,"span"),u.zc(26),u.Rb(),u.Sb(27,"span"),u.zc(28),u.Rb(),u.Rb(),u.Sb(29,"p"),u.Sb(30,"span"),u.zc(31),u.Rb(),u.Sb(32,"span"),u.zc(33),u.Rb(),u.Sb(34,"span"),u.zc(35),u.Rb(),u.Sb(36,"span"),u.zc(37),u.Rb(),u.Rb(),u.Sb(38,"p"),u.Sb(39,"span"),u.zc(40),u.Rb(),u.Sb(41,"span"),u.zc(42),u.Rb(),u.Sb(43,"span"),u.zc(44),u.Rb(),u.Sb(45,"span"),u.zc(46),u.Rb(),u.Rb(),u.Rb(),u.Rb()}if(2&e){var i=t.$implicit,a=u.dc(2);u.Bb(4),u.Bc("Delete RainExceedanceID [",i.RainExceedanceID,"]\xa0\xa0\xa0"),u.Bb(4),u.ic("color",a.GetPutButtonColor(i)),u.Bb(4),u.ic("color",a.GetPostButtonColor(i)),u.Bb(4),u.ic("ngIf",a.rainexceedanceService.rainexceedanceDeleteModel$.getValue().Working),u.Bb(1),u.ic("ngIf",a.IDToShow===i.RainExceedanceID&&a.showType===a.GetPutEnum()),u.Bb(1),u.ic("ngIf",a.IDToShow===i.RainExceedanceID&&a.showType===a.GetPostEnum()),u.Bb(4),u.Bc("RainExceedanceID: [",i.RainExceedanceID,"]"),u.Bb(2),u.Bc(" --- RainExceedanceTVItemID: [",i.RainExceedanceTVItemID,"]"),u.Bb(2),u.Bc(" --- StartMonth: [",i.StartMonth,"]"),u.Bb(2),u.Bc(" --- StartDay: [",i.StartDay,"]"),u.Bb(3),u.Bc("EndMonth: [",i.EndMonth,"]"),u.Bb(2),u.Bc(" --- EndDay: [",i.EndDay,"]"),u.Bb(2),u.Bc(" --- RainMaximum_mm: [",i.RainMaximum_mm,"]"),u.Bb(2),u.Bc(" --- StakeholdersEmailDistributionListID: [",i.StakeholdersEmailDistributionListID,"]"),u.Bb(3),u.Bc("OnlyStaffEmailDistributionListID: [",i.OnlyStaffEmailDistributionListID,"]"),u.Bb(2),u.Bc(" --- IsActive: [",i.IsActive,"]"),u.Bb(2),u.Bc(" --- LastUpdateDate_UTC: [",i.LastUpdateDate_UTC,"]"),u.Bb(2),u.Bc(" --- LastUpdateContactTVItemID: [",i.LastUpdateContactTVItemID,"]")}}function le(e,t){if(1&e&&(u.Sb(0,"div"),u.yc(1,de,47,18,"div",5),u.Rb()),2&e){var n=u.dc();u.Bb(1),u.ic("ngForOf",n.rainexceedanceService.rainexceedanceListModel$.getValue())}}var me,pe,fe,Se=[{path:"",component:(me=function(){function t(n,i,a){e(this,t),this.rainexceedanceService=n,this.router=i,this.httpClientService=a,this.showType=null,a.oldURL=i.url}return n(t,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.RainExceedanceID&&this.showType===s.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.RainExceedanceID&&this.showType===s.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.RainExceedanceID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RainExceedanceID,this.showType=s.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.RainExceedanceID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RainExceedanceID,this.showType=s.a.Post)}},{key:"GetPutEnum",value:function(){return s.a.Put}},{key:"GetPostEnum",value:function(){return s.a.Post}},{key:"GetRainExceedanceList",value:function(){this.sub=this.rainexceedanceService.GetRainExceedanceList().subscribe()}},{key:"DeleteRainExceedance",value:function(e){this.sub=this.rainexceedanceService.DeleteRainExceedance(e).subscribe()}},{key:"ngOnInit",value:function(){o(this.rainexceedanceService.rainexceedanceTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),t}(),me.\u0275fac=function(e){return new(e||me)(u.Mb(R),u.Mb(r.b),u.Mb(S.a))},me.\u0275cmp=u.Gb({type:me,selectors:[["app-rainexceedance"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"rainexceedance","httpClientCommand"]],template:function(e,t){if(1&e&&(u.yc(0,oe,1,0,"mat-progress-bar",0),u.Sb(1,"mat-card"),u.Sb(2,"mat-card-header"),u.Sb(3,"mat-card-title"),u.zc(4," RainExceedance works! "),u.Sb(5,"button",1),u.Zb("click",(function(){return t.GetRainExceedanceList()})),u.Sb(6,"span"),u.zc(7,"Get RainExceedance"),u.Rb(),u.Rb(),u.Rb(),u.Sb(8,"mat-card-subtitle"),u.zc(9),u.Rb(),u.Rb(),u.Sb(10,"mat-card-content"),u.yc(11,le,2,1,"div",2),u.Rb(),u.Sb(12,"mat-card-actions"),u.Sb(13,"button",3),u.zc(14,"Allo"),u.Rb(),u.Rb(),u.Rb()),2&e){var n,i,a=null==(n=t.rainexceedanceService.rainexceedanceGetModel$.getValue())?null:n.Working,c=null==(i=t.rainexceedanceService.rainexceedanceListModel$.getValue())?null:i.length;u.ic("ngIf",a),u.Bb(9),u.Ac(t.rainexceedanceService.rainexceedanceTextModel$.getValue().Title),u.Bb(2),u.ic("ngIf",c)}},directives:[c.l,h.a,h.d,h.g,x.b,h.f,h.c,h.b,I.a,c.k,v.a,re],styles:[""],changeDetection:0}),me),canActivate:[a("auXs").a]}],Re=((pe=function t(){e(this,t)}).\u0275mod=u.Kb({type:pe}),pe.\u0275inj=u.Jb({factory:function(e){return new(e||pe)},imports:[[r.e.forChild(Se)],r.e]}),pe),he=a("B+Mi"),xe=((fe=function t(){e(this,t)}).\u0275mod=u.Kb({type:fe}),fe.\u0275inj=u.Jb({factory:function(e){return new(e||fe)},imports:[[c.c,r.e,Re,he.a,y.g,y.o]]}),fe)},gkM4:function(t,i,a){"use strict";a.d(i,"a",(function(){return b}));var c=a("QRvi"),r=a("fXoL"),o=a("tyNb"),b=function(){var t=function(){function t(n){e(this,t),this.router=n,this.oldURL=n.url}return n(t,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,t,n){e.next(null),t.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(e,t,n){e.next(null),t.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,t,n,i,a){if(i===c.a.Get&&e.next(n),i===c.a.Put&&(e.getValue()[0]=n),i===c.a.Post&&e.getValue().push(n),i===c.a.Delete){var r=e.getValue().indexOf(a);e.getValue().splice(r,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(e,t,n,i,a){i===c.a.Get&&e.next(n),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),t}();return t.\u0275fac=function(e){return new(e||t)(r.Wb(o.b))},t.\u0275prov=r.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t}()}}])}();