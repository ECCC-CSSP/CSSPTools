(window.webpackJsonp=window.webpackJsonp||[]).push([[60],{QRvi:function(t,e,r){"use strict";r.d(e,"a",(function(){return n}));var n=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},a4Mp:function(t,e,r){"use strict";r.r(e),r.d(e,"MikeSourceStartEndModule",(function(){return gt}));var n=r("ofXK"),o=r("tyNb");function i(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var c=r("QRvi"),a=r("fXoL"),s=r("2Vo4"),b=r("LRne"),u=r("tk/3"),d=r("lJxs"),m=r("JIr8"),l=r("gkM4");let S=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.mikesourcestartendTextModel$=new s.a({}),this.mikesourcestartendListModel$=new s.a({}),this.mikesourcestartendGetModel$=new s.a({}),this.mikesourcestartendPutModel$=new s.a({}),this.mikesourcestartendPostModel$=new s.a({}),this.mikesourcestartendDeleteModel$=new s.a({}),i(this.mikesourcestartendTextModel$),this.mikesourcestartendTextModel$.next({Title:"Something2 for text"})}GetMikeSourceStartEndList(){return this.httpClientService.BeforeHttpClient(this.mikesourcestartendGetModel$),this.httpClient.get("/api/MikeSourceStartEnd").pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.mikesourcestartendListModel$,this.mikesourcestartendGetModel$,t,c.a.Get,null)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.mikesourcestartendListModel$,this.mikesourcestartendGetModel$,t)}))))}PutMikeSourceStartEnd(t){return this.httpClientService.BeforeHttpClient(this.mikesourcestartendPutModel$),this.httpClient.put("/api/MikeSourceStartEnd",t,{headers:new u.d}).pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.mikesourcestartendListModel$,this.mikesourcestartendPutModel$,e,c.a.Put,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.mikesourcestartendListModel$,this.mikesourcestartendPutModel$,t)}))))}PostMikeSourceStartEnd(t){return this.httpClientService.BeforeHttpClient(this.mikesourcestartendPostModel$),this.httpClient.post("/api/MikeSourceStartEnd",t,{headers:new u.d}).pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.mikesourcestartendListModel$,this.mikesourcestartendPostModel$,e,c.a.Post,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.mikesourcestartendListModel$,this.mikesourcestartendPostModel$,t)}))))}DeleteMikeSourceStartEnd(t){return this.httpClientService.BeforeHttpClient(this.mikesourcestartendDeleteModel$),this.httpClient.delete("/api/MikeSourceStartEnd/"+t.MikeSourceStartEndID).pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.mikesourcestartendListModel$,this.mikesourcestartendDeleteModel$,e,c.a.Delete,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.mikesourcestartendListModel$,this.mikesourcestartendDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(a.Wb(u.b),a.Wb(l.a))},t.\u0275prov=a.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var p=r("Wp6s"),h=r("bTqV"),f=r("bv9b"),k=r("NFeN"),R=r("3Pt+"),y=r("kmnG"),I=r("qFsG");function M(t,e){1&t&&a.Nb(0,"mat-progress-bar",18)}function E(t,e){1&t&&a.Nb(0,"mat-progress-bar",18)}function g(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function _(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,g,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,2,t)),a.Bb(3),a.hc("ngIf",t.required)}}function P(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function B(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,P,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,2,t)),a.Bb(3),a.hc("ngIf",t.required)}}function D(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function N(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,D,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,2,t)),a.Bb(3),a.hc("ngIf",t.required)}}function C(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function x(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,C,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,2,t)),a.Bb(3),a.hc("ngIf",t.required)}}function T(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function v(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Min - 0"),a.Nb(2,"br"),a.Rb())}function w(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Max - 1000000"),a.Nb(2,"br"),a.Rb())}function $(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,T,3,0,"span",4),a.xc(6,v,3,0,"span",4),a.xc(7,w,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,4,t)),a.Bb(3),a.hc("ngIf",t.required),a.Bb(1),a.hc("ngIf",t.min),a.Bb(1),a.hc("ngIf",t.min)}}function L(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function q(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Min - 0"),a.Nb(2,"br"),a.Rb())}function F(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Max - 1000000"),a.Nb(2,"br"),a.Rb())}function U(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,L,3,0,"span",4),a.xc(6,q,3,0,"span",4),a.xc(7,F,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,4,t)),a.Bb(3),a.hc("ngIf",t.required),a.Bb(1),a.hc("ngIf",t.min),a.Bb(1),a.hc("ngIf",t.min)}}function G(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function A(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Min - 0"),a.Nb(2,"br"),a.Rb())}function j(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Max - 10000000"),a.Nb(2,"br"),a.Rb())}function O(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,G,3,0,"span",4),a.xc(6,A,3,0,"span",4),a.xc(7,j,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,4,t)),a.Bb(3),a.hc("ngIf",t.required),a.Bb(1),a.hc("ngIf",t.min),a.Bb(1),a.hc("ngIf",t.min)}}function V(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function z(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Min - 0"),a.Nb(2,"br"),a.Rb())}function W(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Max - 10000000"),a.Nb(2,"br"),a.Rb())}function J(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,V,3,0,"span",4),a.xc(6,z,3,0,"span",4),a.xc(7,W,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,4,t)),a.Bb(3),a.hc("ngIf",t.required),a.Bb(1),a.hc("ngIf",t.min),a.Bb(1),a.hc("ngIf",t.min)}}function H(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function Y(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Min - -10"),a.Nb(2,"br"),a.Rb())}function X(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Max - 40"),a.Nb(2,"br"),a.Rb())}function K(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,H,3,0,"span",4),a.xc(6,Y,3,0,"span",4),a.xc(7,X,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,4,t)),a.Bb(3),a.hc("ngIf",t.required),a.Bb(1),a.hc("ngIf",t.min),a.Bb(1),a.hc("ngIf",t.min)}}function Q(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function Z(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Min - -10"),a.Nb(2,"br"),a.Rb())}function tt(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Max - 40"),a.Nb(2,"br"),a.Rb())}function et(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,Q,3,0,"span",4),a.xc(6,Z,3,0,"span",4),a.xc(7,tt,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,4,t)),a.Bb(3),a.hc("ngIf",t.required),a.Bb(1),a.hc("ngIf",t.min),a.Bb(1),a.hc("ngIf",t.min)}}function rt(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function nt(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Min - 0"),a.Nb(2,"br"),a.Rb())}function ot(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Max - 40"),a.Nb(2,"br"),a.Rb())}function it(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,rt,3,0,"span",4),a.xc(6,nt,3,0,"span",4),a.xc(7,ot,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,4,t)),a.Bb(3),a.hc("ngIf",t.required),a.Bb(1),a.hc("ngIf",t.min),a.Bb(1),a.hc("ngIf",t.min)}}function ct(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function at(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Min - 0"),a.Nb(2,"br"),a.Rb())}function st(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Max - 40"),a.Nb(2,"br"),a.Rb())}function bt(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,ct,3,0,"span",4),a.xc(6,at,3,0,"span",4),a.xc(7,st,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,4,t)),a.Bb(3),a.hc("ngIf",t.required),a.Bb(1),a.hc("ngIf",t.min),a.Bb(1),a.hc("ngIf",t.min)}}function ut(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function dt(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,ut,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,2,t)),a.Bb(3),a.hc("ngIf",t.required)}}function mt(t,e){1&t&&(a.Sb(0,"span"),a.yc(1,"Is Required"),a.Nb(2,"br"),a.Rb())}function lt(t,e){if(1&t&&(a.Sb(0,"mat-error"),a.Sb(1,"span"),a.yc(2),a.dc(3,"json"),a.Nb(4,"br"),a.Rb(),a.xc(5,mt,3,0,"span",4),a.Rb()),2&t){const t=e.$implicit;a.Bb(2),a.zc(a.ec(3,2,t)),a.Bb(3),a.hc("ngIf",t.required)}}let St=(()=>{class t{constructor(t,e){this.mikesourcestartendService=t,this.fb=e,this.mikesourcestartend=null,this.httpClientCommand=c.a.Put}GetPut(){return this.httpClientCommand==c.a.Put}PutMikeSourceStartEnd(t){this.sub=this.mikesourcestartendService.PutMikeSourceStartEnd(t).subscribe()}PostMikeSourceStartEnd(t){this.sub=this.mikesourcestartendService.PostMikeSourceStartEnd(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.mikesourcestartend){let e=this.fb.group({MikeSourceStartEndID:[{value:t===c.a.Post?0:this.mikesourcestartend.MikeSourceStartEndID,disabled:!1},[R.p.required]],MikeSourceID:[{value:this.mikesourcestartend.MikeSourceID,disabled:!1},[R.p.required]],StartDateAndTime_Local:[{value:this.mikesourcestartend.StartDateAndTime_Local,disabled:!1},[R.p.required]],EndDateAndTime_Local:[{value:this.mikesourcestartend.EndDateAndTime_Local,disabled:!1},[R.p.required]],SourceFlowStart_m3_day:[{value:this.mikesourcestartend.SourceFlowStart_m3_day,disabled:!1},[R.p.required,R.p.min(0),R.p.max(1e6)]],SourceFlowEnd_m3_day:[{value:this.mikesourcestartend.SourceFlowEnd_m3_day,disabled:!1},[R.p.required,R.p.min(0),R.p.max(1e6)]],SourcePollutionStart_MPN_100ml:[{value:this.mikesourcestartend.SourcePollutionStart_MPN_100ml,disabled:!1},[R.p.required,R.p.min(0),R.p.max(1e7)]],SourcePollutionEnd_MPN_100ml:[{value:this.mikesourcestartend.SourcePollutionEnd_MPN_100ml,disabled:!1},[R.p.required,R.p.min(0),R.p.max(1e7)]],SourceTemperatureStart_C:[{value:this.mikesourcestartend.SourceTemperatureStart_C,disabled:!1},[R.p.required,R.p.min(-10),R.p.max(40)]],SourceTemperatureEnd_C:[{value:this.mikesourcestartend.SourceTemperatureEnd_C,disabled:!1},[R.p.required,R.p.min(-10),R.p.max(40)]],SourceSalinityStart_PSU:[{value:this.mikesourcestartend.SourceSalinityStart_PSU,disabled:!1},[R.p.required,R.p.min(0),R.p.max(40)]],SourceSalinityEnd_PSU:[{value:this.mikesourcestartend.SourceSalinityEnd_PSU,disabled:!1},[R.p.required,R.p.min(0),R.p.max(40)]],LastUpdateDate_UTC:[{value:this.mikesourcestartend.LastUpdateDate_UTC,disabled:!1},[R.p.required]],LastUpdateContactTVItemID:[{value:this.mikesourcestartend.LastUpdateContactTVItemID,disabled:!1},[R.p.required]]});this.mikesourcestartendFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(a.Mb(S),a.Mb(R.d))},t.\u0275cmp=a.Gb({type:t,selectors:[["app-mikesourcestartend-edit"]],inputs:{mikesourcestartend:"mikesourcestartend",httpClientCommand:"httpClientCommand"},decls:82,vars:18,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","MikeSourceStartEndID"],[4,"ngIf"],["matInput","","type","number","formControlName","MikeSourceID"],["matInput","","type","text","formControlName","StartDateAndTime_Local"],["matInput","","type","text","formControlName","EndDateAndTime_Local"],["matInput","","type","number","formControlName","SourceFlowStart_m3_day"],["matInput","","type","number","formControlName","SourceFlowEnd_m3_day"],["matInput","","type","number","formControlName","SourcePollutionStart_MPN_100ml"],["matInput","","type","number","formControlName","SourcePollutionEnd_MPN_100ml"],["matInput","","type","number","formControlName","SourceTemperatureStart_C"],["matInput","","type","number","formControlName","SourceTemperatureEnd_C"],["matInput","","type","number","formControlName","SourceSalinityStart_PSU"],["matInput","","type","number","formControlName","SourceSalinityEnd_PSU"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,e){1&t&&(a.Sb(0,"form",0),a.Yb("ngSubmit",(function(){return e.GetPut()?e.PutMikeSourceStartEnd(e.mikesourcestartendFormEdit.value):e.PostMikeSourceStartEnd(e.mikesourcestartendFormEdit.value)})),a.Sb(1,"h3"),a.yc(2," MikeSourceStartEnd "),a.Sb(3,"button",1),a.Sb(4,"span"),a.yc(5),a.Rb(),a.Rb(),a.xc(6,M,1,0,"mat-progress-bar",2),a.xc(7,E,1,0,"mat-progress-bar",2),a.Rb(),a.Sb(8,"p"),a.Sb(9,"mat-form-field"),a.Sb(10,"mat-label"),a.yc(11,"MikeSourceStartEndID"),a.Rb(),a.Nb(12,"input",3),a.xc(13,_,6,4,"mat-error",4),a.Rb(),a.Sb(14,"mat-form-field"),a.Sb(15,"mat-label"),a.yc(16,"MikeSourceID"),a.Rb(),a.Nb(17,"input",5),a.xc(18,B,6,4,"mat-error",4),a.Rb(),a.Sb(19,"mat-form-field"),a.Sb(20,"mat-label"),a.yc(21,"StartDateAndTime_Local"),a.Rb(),a.Nb(22,"input",6),a.xc(23,N,6,4,"mat-error",4),a.Rb(),a.Sb(24,"mat-form-field"),a.Sb(25,"mat-label"),a.yc(26,"EndDateAndTime_Local"),a.Rb(),a.Nb(27,"input",7),a.xc(28,x,6,4,"mat-error",4),a.Rb(),a.Rb(),a.Sb(29,"p"),a.Sb(30,"mat-form-field"),a.Sb(31,"mat-label"),a.yc(32,"SourceFlowStart_m3_day"),a.Rb(),a.Nb(33,"input",8),a.xc(34,$,8,6,"mat-error",4),a.Rb(),a.Sb(35,"mat-form-field"),a.Sb(36,"mat-label"),a.yc(37,"SourceFlowEnd_m3_day"),a.Rb(),a.Nb(38,"input",9),a.xc(39,U,8,6,"mat-error",4),a.Rb(),a.Sb(40,"mat-form-field"),a.Sb(41,"mat-label"),a.yc(42,"SourcePollutionStart_MPN_100ml"),a.Rb(),a.Nb(43,"input",10),a.xc(44,O,8,6,"mat-error",4),a.Rb(),a.Sb(45,"mat-form-field"),a.Sb(46,"mat-label"),a.yc(47,"SourcePollutionEnd_MPN_100ml"),a.Rb(),a.Nb(48,"input",11),a.xc(49,J,8,6,"mat-error",4),a.Rb(),a.Rb(),a.Sb(50,"p"),a.Sb(51,"mat-form-field"),a.Sb(52,"mat-label"),a.yc(53,"SourceTemperatureStart_C"),a.Rb(),a.Nb(54,"input",12),a.xc(55,K,8,6,"mat-error",4),a.Rb(),a.Sb(56,"mat-form-field"),a.Sb(57,"mat-label"),a.yc(58,"SourceTemperatureEnd_C"),a.Rb(),a.Nb(59,"input",13),a.xc(60,et,8,6,"mat-error",4),a.Rb(),a.Sb(61,"mat-form-field"),a.Sb(62,"mat-label"),a.yc(63,"SourceSalinityStart_PSU"),a.Rb(),a.Nb(64,"input",14),a.xc(65,it,8,6,"mat-error",4),a.Rb(),a.Sb(66,"mat-form-field"),a.Sb(67,"mat-label"),a.yc(68,"SourceSalinityEnd_PSU"),a.Rb(),a.Nb(69,"input",15),a.xc(70,bt,8,6,"mat-error",4),a.Rb(),a.Rb(),a.Sb(71,"p"),a.Sb(72,"mat-form-field"),a.Sb(73,"mat-label"),a.yc(74,"LastUpdateDate_UTC"),a.Rb(),a.Nb(75,"input",16),a.xc(76,dt,6,4,"mat-error",4),a.Rb(),a.Sb(77,"mat-form-field"),a.Sb(78,"mat-label"),a.yc(79,"LastUpdateContactTVItemID"),a.Rb(),a.Nb(80,"input",17),a.xc(81,lt,6,4,"mat-error",4),a.Rb(),a.Rb(),a.Rb()),2&t&&(a.hc("formGroup",e.mikesourcestartendFormEdit),a.Bb(5),a.Ac("",e.GetPut()?"Put":"Post"," MikeSourceStartEnd"),a.Bb(1),a.hc("ngIf",e.mikesourcestartendService.mikesourcestartendPutModel$.getValue().Working),a.Bb(1),a.hc("ngIf",e.mikesourcestartendService.mikesourcestartendPostModel$.getValue().Working),a.Bb(6),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.MikeSourceStartEndID.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.MikeSourceID.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.StartDateAndTime_Local.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.EndDateAndTime_Local.errors),a.Bb(6),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.SourceFlowStart_m3_day.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.SourceFlowEnd_m3_day.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.SourcePollutionStart_MPN_100ml.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.SourcePollutionEnd_MPN_100ml.errors),a.Bb(6),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.SourceTemperatureStart_C.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.SourceTemperatureEnd_C.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.SourceSalinityStart_PSU.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.SourceSalinityEnd_PSU.errors),a.Bb(6),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.LastUpdateDate_UTC.errors),a.Bb(5),a.hc("ngIf",e.mikesourcestartendFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[R.q,R.l,R.f,h.b,n.l,y.c,y.f,I.b,R.n,R.c,R.k,R.e,f.a,y.b],pipes:[n.f],styles:[""],changeDetection:0}),t})();function pt(t,e){1&t&&a.Nb(0,"mat-progress-bar",4)}function ht(t,e){1&t&&a.Nb(0,"mat-progress-bar",4)}function ft(t,e){if(1&t&&(a.Sb(0,"p"),a.Nb(1,"app-mikesourcestartend-edit",8),a.Rb()),2&t){const t=a.cc().$implicit,e=a.cc(2);a.Bb(1),a.hc("mikesourcestartend",t)("httpClientCommand",e.GetPutEnum())}}function kt(t,e){if(1&t&&(a.Sb(0,"p"),a.Nb(1,"app-mikesourcestartend-edit",8),a.Rb()),2&t){const t=a.cc().$implicit,e=a.cc(2);a.Bb(1),a.hc("mikesourcestartend",t)("httpClientCommand",e.GetPostEnum())}}function Rt(t,e){if(1&t){const t=a.Tb();a.Sb(0,"div"),a.Sb(1,"p"),a.Sb(2,"button",6),a.Yb("click",(function(){a.pc(t);const r=e.$implicit;return a.cc(2).DeleteMikeSourceStartEnd(r)})),a.Sb(3,"span"),a.yc(4),a.Rb(),a.Sb(5,"mat-icon"),a.yc(6,"delete"),a.Rb(),a.Rb(),a.yc(7,"\xa0\xa0\xa0 "),a.Sb(8,"button",7),a.Yb("click",(function(){a.pc(t);const r=e.$implicit;return a.cc(2).ShowPut(r)})),a.Sb(9,"span"),a.yc(10,"Show Put"),a.Rb(),a.Rb(),a.yc(11,"\xa0\xa0 "),a.Sb(12,"button",7),a.Yb("click",(function(){a.pc(t);const r=e.$implicit;return a.cc(2).ShowPost(r)})),a.Sb(13,"span"),a.yc(14,"Show Post"),a.Rb(),a.Rb(),a.yc(15,"\xa0\xa0 "),a.xc(16,ht,1,0,"mat-progress-bar",0),a.Rb(),a.xc(17,ft,2,2,"p",2),a.xc(18,kt,2,2,"p",2),a.Sb(19,"blockquote"),a.Sb(20,"p"),a.Sb(21,"span"),a.yc(22),a.Rb(),a.Sb(23,"span"),a.yc(24),a.Rb(),a.Sb(25,"span"),a.yc(26),a.Rb(),a.Sb(27,"span"),a.yc(28),a.Rb(),a.Rb(),a.Sb(29,"p"),a.Sb(30,"span"),a.yc(31),a.Rb(),a.Sb(32,"span"),a.yc(33),a.Rb(),a.Sb(34,"span"),a.yc(35),a.Rb(),a.Sb(36,"span"),a.yc(37),a.Rb(),a.Rb(),a.Sb(38,"p"),a.Sb(39,"span"),a.yc(40),a.Rb(),a.Sb(41,"span"),a.yc(42),a.Rb(),a.Sb(43,"span"),a.yc(44),a.Rb(),a.Sb(45,"span"),a.yc(46),a.Rb(),a.Rb(),a.Sb(47,"p"),a.Sb(48,"span"),a.yc(49),a.Rb(),a.Sb(50,"span"),a.yc(51),a.Rb(),a.Rb(),a.Rb(),a.Rb()}if(2&t){const t=e.$implicit,r=a.cc(2);a.Bb(4),a.Ac("Delete MikeSourceStartEndID [",t.MikeSourceStartEndID,"]\xa0\xa0\xa0"),a.Bb(4),a.hc("color",r.GetPutButtonColor(t)),a.Bb(4),a.hc("color",r.GetPostButtonColor(t)),a.Bb(4),a.hc("ngIf",r.mikesourcestartendService.mikesourcestartendDeleteModel$.getValue().Working),a.Bb(1),a.hc("ngIf",r.IDToShow===t.MikeSourceStartEndID&&r.showType===r.GetPutEnum()),a.Bb(1),a.hc("ngIf",r.IDToShow===t.MikeSourceStartEndID&&r.showType===r.GetPostEnum()),a.Bb(4),a.Ac("MikeSourceStartEndID: [",t.MikeSourceStartEndID,"]"),a.Bb(2),a.Ac(" --- MikeSourceID: [",t.MikeSourceID,"]"),a.Bb(2),a.Ac(" --- StartDateAndTime_Local: [",t.StartDateAndTime_Local,"]"),a.Bb(2),a.Ac(" --- EndDateAndTime_Local: [",t.EndDateAndTime_Local,"]"),a.Bb(3),a.Ac("SourceFlowStart_m3_day: [",t.SourceFlowStart_m3_day,"]"),a.Bb(2),a.Ac(" --- SourceFlowEnd_m3_day: [",t.SourceFlowEnd_m3_day,"]"),a.Bb(2),a.Ac(" --- SourcePollutionStart_MPN_100ml: [",t.SourcePollutionStart_MPN_100ml,"]"),a.Bb(2),a.Ac(" --- SourcePollutionEnd_MPN_100ml: [",t.SourcePollutionEnd_MPN_100ml,"]"),a.Bb(3),a.Ac("SourceTemperatureStart_C: [",t.SourceTemperatureStart_C,"]"),a.Bb(2),a.Ac(" --- SourceTemperatureEnd_C: [",t.SourceTemperatureEnd_C,"]"),a.Bb(2),a.Ac(" --- SourceSalinityStart_PSU: [",t.SourceSalinityStart_PSU,"]"),a.Bb(2),a.Ac(" --- SourceSalinityEnd_PSU: [",t.SourceSalinityEnd_PSU,"]"),a.Bb(3),a.Ac("LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),a.Bb(2),a.Ac(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function yt(t,e){if(1&t&&(a.Sb(0,"div"),a.xc(1,Rt,52,20,"div",5),a.Rb()),2&t){const t=a.cc();a.Bb(1),a.hc("ngForOf",t.mikesourcestartendService.mikesourcestartendListModel$.getValue())}}const It=[{path:"",component:(()=>{class t{constructor(t,e,r){this.mikesourcestartendService=t,this.router=e,this.httpClientService=r,this.showType=null,r.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.MikeSourceStartEndID&&this.showType===c.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.MikeSourceStartEndID&&this.showType===c.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.MikeSourceStartEndID&&this.showType===c.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MikeSourceStartEndID,this.showType=c.a.Put)}ShowPost(t){this.IDToShow===t.MikeSourceStartEndID&&this.showType===c.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MikeSourceStartEndID,this.showType=c.a.Post)}GetPutEnum(){return c.a.Put}GetPostEnum(){return c.a.Post}GetMikeSourceStartEndList(){this.sub=this.mikesourcestartendService.GetMikeSourceStartEndList().subscribe()}DeleteMikeSourceStartEnd(t){this.sub=this.mikesourcestartendService.DeleteMikeSourceStartEnd(t).subscribe()}ngOnInit(){i(this.mikesourcestartendService.mikesourcestartendTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(a.Mb(S),a.Mb(o.b),a.Mb(l.a))},t.\u0275cmp=a.Gb({type:t,selectors:[["app-mikesourcestartend"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"mikesourcestartend","httpClientCommand"]],template:function(t,e){var r,n;1&t&&(a.xc(0,pt,1,0,"mat-progress-bar",0),a.Sb(1,"mat-card"),a.Sb(2,"mat-card-header"),a.Sb(3,"mat-card-title"),a.yc(4," MikeSourceStartEnd works! "),a.Sb(5,"button",1),a.Yb("click",(function(){return e.GetMikeSourceStartEndList()})),a.Sb(6,"span"),a.yc(7,"Get MikeSourceStartEnd"),a.Rb(),a.Rb(),a.Rb(),a.Sb(8,"mat-card-subtitle"),a.yc(9),a.Rb(),a.Rb(),a.Sb(10,"mat-card-content"),a.xc(11,yt,2,1,"div",2),a.Rb(),a.Sb(12,"mat-card-actions"),a.Sb(13,"button",3),a.yc(14,"Allo"),a.Rb(),a.Rb(),a.Rb()),2&t&&(a.hc("ngIf",null==(r=e.mikesourcestartendService.mikesourcestartendGetModel$.getValue())?null:r.Working),a.Bb(9),a.zc(e.mikesourcestartendService.mikesourcestartendTextModel$.getValue().Title),a.Bb(2),a.hc("ngIf",null==(n=e.mikesourcestartendService.mikesourcestartendListModel$.getValue())?null:n.length))},directives:[n.l,p.a,p.d,p.g,h.b,p.f,p.c,p.b,f.a,n.k,k.a,St],styles:[""],changeDetection:0}),t})(),canActivate:[r("auXs").a]}];let Mt=(()=>{class t{}return t.\u0275mod=a.Kb({type:t}),t.\u0275inj=a.Jb({factory:function(e){return new(e||t)},imports:[[o.e.forChild(It)],o.e]}),t})();var Et=r("B+Mi");let gt=(()=>{class t{}return t.\u0275mod=a.Kb({type:t}),t.\u0275inj=a.Jb({factory:function(e){return new(e||t)},imports:[[n.c,o.e,Mt,Et.a,R.g,R.o]]}),t})()},gkM4:function(t,e,r){"use strict";r.d(e,"a",(function(){return c}));var n=r("QRvi"),o=r("fXoL"),i=r("tyNb");let c=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,r){t.next(null),e.next({Working:!1,Error:r,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,r){t.next(null),e.next({Working:!1,Error:r,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,r,o,i){if(o===n.a.Get&&t.next(r),o===n.a.Put&&(t.getValue()[0]=r),o===n.a.Post&&t.getValue().push(r),o===n.a.Delete){const e=t.getValue().indexOf(i);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,r,o,i){o===n.a.Get&&t.next(r),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(o.Wb(i.b))},t.\u0275prov=o.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);