(window.webpackJsonp=window.webpackJsonp||[]).push([[42],{"2wOd":function(t,e,i){"use strict";i.r(e),i.d(e,"ClimateSiteModule",(function(){return Bt}));var a=i("ofXK"),c=i("tyNb");function o(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var n=i("QRvi"),r=i("fXoL"),b=i("2Vo4"),l=i("LRne"),s=i("tk/3"),m=i("lJxs"),u=i("JIr8"),p=i("gkM4");let S=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.climatesiteTextModel$=new b.a({}),this.climatesiteListModel$=new b.a({}),this.climatesiteGetModel$=new b.a({}),this.climatesitePutModel$=new b.a({}),this.climatesitePostModel$=new b.a({}),this.climatesiteDeleteModel$=new b.a({}),o(this.climatesiteTextModel$),this.climatesiteTextModel$.next({Title:"Something2 for text"})}GetClimateSiteList(){return this.httpClientService.BeforeHttpClient(this.climatesiteGetModel$),this.httpClient.get("/api/ClimateSite").pipe(Object(m.a)(t=>{this.httpClientService.DoSuccess(this.climatesiteListModel$,this.climatesiteGetModel$,t,n.a.Get,null)}),Object(u.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.climatesiteListModel$,this.climatesiteGetModel$,t)}))))}PutClimateSite(t){return this.httpClientService.BeforeHttpClient(this.climatesitePutModel$),this.httpClient.put("/api/ClimateSite",t,{headers:new s.d}).pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.climatesiteListModel$,this.climatesitePutModel$,e,n.a.Put,t)}),Object(u.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.climatesiteListModel$,this.climatesitePutModel$,t)}))))}PostClimateSite(t){return this.httpClientService.BeforeHttpClient(this.climatesitePostModel$),this.httpClient.post("/api/ClimateSite",t,{headers:new s.d}).pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.climatesiteListModel$,this.climatesitePostModel$,e,n.a.Post,t)}),Object(u.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.climatesiteListModel$,this.climatesitePostModel$,t)}))))}DeleteClimateSite(t){return this.httpClientService.BeforeHttpClient(this.climatesiteDeleteModel$),this.httpClient.delete("/api/ClimateSite/"+t.ClimateSiteID).pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.climatesiteListModel$,this.climatesiteDeleteModel$,e,n.a.Delete,t)}),Object(u.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.climatesiteListModel$,this.climatesiteDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(r.Wb(s.b),r.Wb(p.a))},t.\u0275prov=r.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var f=i("Wp6s"),d=i("bTqV"),h=i("bv9b"),R=i("NFeN"),I=i("3Pt+"),C=i("kmnG"),D=i("qFsG");function y(t,e){1&t&&r.Nb(0,"mat-progress-bar",28)}function B(t,e){1&t&&r.Nb(0,"mat-progress-bar",28)}function N(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function g(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,N,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.required)}}function z(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function v(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,z,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.required)}}function L(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Min - 1"),r.Nb(2,"br"),r.Rb())}function M(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Max - 100000"),r.Nb(2,"br"),r.Rb())}function E(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,L,3,0,"span",4),r.yc(6,M,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,3,t)),r.Bb(3),r.ic("ngIf",t.min),r.Bb(1),r.ic("ngIf",t.min)}}function w(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function _(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"MaxLength - 100"),r.Nb(2,"br"),r.Rb())}function T(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,w,3,0,"span",4),r.yc(6,_,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,3,t)),r.Bb(3),r.ic("ngIf",t.required),r.Bb(1),r.ic("ngIf",t.maxlength)}}function $(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function P(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"MaxLength - 4"),r.Nb(2,"br"),r.Rb())}function x(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,$,3,0,"span",4),r.yc(6,P,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,3,t)),r.Bb(3),r.ic("ngIf",t.required),r.Bb(1),r.ic("ngIf",t.maxlength)}}function F(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Min - 0"),r.Nb(2,"br"),r.Rb())}function j(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Max - 10000"),r.Nb(2,"br"),r.Rb())}function O(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,F,3,0,"span",4),r.yc(6,j,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,3,t)),r.Bb(3),r.ic("ngIf",t.min),r.Bb(1),r.ic("ngIf",t.min)}}function G(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"MaxLength - 10"),r.Nb(2,"br"),r.Rb())}function H(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,G,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.maxlength)}}function k(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Min - 1"),r.Nb(2,"br"),r.Rb())}function V(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Max - 100000"),r.Nb(2,"br"),r.Rb())}function A(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,k,3,0,"span",4),r.yc(6,V,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,3,t)),r.Bb(3),r.ic("ngIf",t.min),r.Bb(1),r.ic("ngIf",t.min)}}function q(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"MaxLength - 3"),r.Nb(2,"br"),r.Rb())}function U(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,q,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.maxlength)}}function W(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function Q(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function J(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Min - -10"),r.Nb(2,"br"),r.Rb())}function Z(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Max - 0"),r.Nb(2,"br"),r.Rb())}function X(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,J,3,0,"span",4),r.yc(6,Z,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,3,t)),r.Bb(3),r.ic("ngIf",t.min),r.Bb(1),r.ic("ngIf",t.min)}}function K(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"MaxLength - 50"),r.Nb(2,"br"),r.Rb())}function Y(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,K,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.maxlength)}}function tt(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function et(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function it(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function at(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function ct(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function ot(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function nt(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function rt(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function bt(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function lt(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function st(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,lt,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.required)}}function mt(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function ut(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,mt,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.required)}}let pt=(()=>{class t{constructor(t,e){this.climatesiteService=t,this.fb=e,this.climatesite=null,this.httpClientCommand=n.a.Put}GetPut(){return this.httpClientCommand==n.a.Put}PutClimateSite(t){this.sub=this.climatesiteService.PutClimateSite(t).subscribe()}PostClimateSite(t){this.sub=this.climatesiteService.PostClimateSite(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.climatesite){let e=this.fb.group({ClimateSiteID:[{value:t===n.a.Post?0:this.climatesite.ClimateSiteID,disabled:!1},[I.p.required]],ClimateSiteTVItemID:[{value:this.climatesite.ClimateSiteTVItemID,disabled:!1},[I.p.required]],ECDBID:[{value:this.climatesite.ECDBID,disabled:!1},[I.p.min(1),I.p.max(1e5)]],ClimateSiteName:[{value:this.climatesite.ClimateSiteName,disabled:!1},[I.p.required,I.p.maxLength(100)]],Province:[{value:this.climatesite.Province,disabled:!1},[I.p.required,I.p.maxLength(4)]],Elevation_m:[{value:this.climatesite.Elevation_m,disabled:!1},[I.p.min(0),I.p.max(1e4)]],ClimateID:[{value:this.climatesite.ClimateID,disabled:!1},[I.p.maxLength(10)]],WMOID:[{value:this.climatesite.WMOID,disabled:!1},[I.p.min(1),I.p.max(1e5)]],TCID:[{value:this.climatesite.TCID,disabled:!1},[I.p.maxLength(3)]],IsQuebecSite:[{value:this.climatesite.IsQuebecSite,disabled:!1}],IsCoCoRaHS:[{value:this.climatesite.IsCoCoRaHS,disabled:!1}],TimeOffset_hour:[{value:this.climatesite.TimeOffset_hour,disabled:!1},[I.p.min(-10),I.p.max(0)]],File_desc:[{value:this.climatesite.File_desc,disabled:!1},[I.p.maxLength(50)]],HourlyStartDate_Local:[{value:this.climatesite.HourlyStartDate_Local,disabled:!1}],HourlyEndDate_Local:[{value:this.climatesite.HourlyEndDate_Local,disabled:!1}],HourlyNow:[{value:this.climatesite.HourlyNow,disabled:!1}],DailyStartDate_Local:[{value:this.climatesite.DailyStartDate_Local,disabled:!1}],DailyEndDate_Local:[{value:this.climatesite.DailyEndDate_Local,disabled:!1}],DailyNow:[{value:this.climatesite.DailyNow,disabled:!1}],MonthlyStartDate_Local:[{value:this.climatesite.MonthlyStartDate_Local,disabled:!1}],MonthlyEndDate_Local:[{value:this.climatesite.MonthlyEndDate_Local,disabled:!1}],MonthlyNow:[{value:this.climatesite.MonthlyNow,disabled:!1}],LastUpdateDate_UTC:[{value:this.climatesite.LastUpdateDate_UTC,disabled:!1},[I.p.required]],LastUpdateContactTVItemID:[{value:this.climatesite.LastUpdateContactTVItemID,disabled:!1},[I.p.required]]});this.climatesiteFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(r.Mb(S),r.Mb(I.d))},t.\u0275cmp=r.Gb({type:t,selectors:[["app-climatesite-edit"]],inputs:{climatesite:"climatesite",httpClientCommand:"httpClientCommand"},decls:134,vars:28,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","ClimateSiteID"],[4,"ngIf"],["matInput","","type","number","formControlName","ClimateSiteTVItemID"],["matInput","","type","number","formControlName","ECDBID"],["matInput","","type","text","formControlName","ClimateSiteName"],["matInput","","type","text","formControlName","Province"],["matInput","","type","number","formControlName","Elevation_m"],["matInput","","type","text","formControlName","ClimateID"],["matInput","","type","number","formControlName","WMOID"],["matInput","","type","text","formControlName","TCID"],["matInput","","type","text","formControlName","IsQuebecSite"],["matInput","","type","text","formControlName","IsCoCoRaHS"],["matInput","","type","number","formControlName","TimeOffset_hour"],["matInput","","type","text","formControlName","File_desc"],["matInput","","type","text","formControlName","HourlyStartDate_Local"],["matInput","","type","text","formControlName","HourlyEndDate_Local"],["matInput","","type","text","formControlName","HourlyNow"],["matInput","","type","text","formControlName","DailyStartDate_Local"],["matInput","","type","text","formControlName","DailyEndDate_Local"],["matInput","","type","text","formControlName","DailyNow"],["matInput","","type","text","formControlName","MonthlyStartDate_Local"],["matInput","","type","text","formControlName","MonthlyEndDate_Local"],["matInput","","type","text","formControlName","MonthlyNow"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,e){1&t&&(r.Sb(0,"form",0),r.Zb("ngSubmit",(function(){return e.GetPut()?e.PutClimateSite(e.climatesiteFormEdit.value):e.PostClimateSite(e.climatesiteFormEdit.value)})),r.Sb(1,"h3"),r.zc(2," ClimateSite "),r.Sb(3,"button",1),r.Sb(4,"span"),r.zc(5),r.Rb(),r.Rb(),r.yc(6,y,1,0,"mat-progress-bar",2),r.yc(7,B,1,0,"mat-progress-bar",2),r.Rb(),r.Sb(8,"p"),r.Sb(9,"mat-form-field"),r.Sb(10,"mat-label"),r.zc(11,"ClimateSiteID"),r.Rb(),r.Nb(12,"input",3),r.yc(13,g,6,4,"mat-error",4),r.Rb(),r.Sb(14,"mat-form-field"),r.Sb(15,"mat-label"),r.zc(16,"ClimateSiteTVItemID"),r.Rb(),r.Nb(17,"input",5),r.yc(18,v,6,4,"mat-error",4),r.Rb(),r.Sb(19,"mat-form-field"),r.Sb(20,"mat-label"),r.zc(21,"ECDBID"),r.Rb(),r.Nb(22,"input",6),r.yc(23,E,7,5,"mat-error",4),r.Rb(),r.Sb(24,"mat-form-field"),r.Sb(25,"mat-label"),r.zc(26,"ClimateSiteName"),r.Rb(),r.Nb(27,"input",7),r.yc(28,T,7,5,"mat-error",4),r.Rb(),r.Rb(),r.Sb(29,"p"),r.Sb(30,"mat-form-field"),r.Sb(31,"mat-label"),r.zc(32,"Province"),r.Rb(),r.Nb(33,"input",8),r.yc(34,x,7,5,"mat-error",4),r.Rb(),r.Sb(35,"mat-form-field"),r.Sb(36,"mat-label"),r.zc(37,"Elevation_m"),r.Rb(),r.Nb(38,"input",9),r.yc(39,O,7,5,"mat-error",4),r.Rb(),r.Sb(40,"mat-form-field"),r.Sb(41,"mat-label"),r.zc(42,"ClimateID"),r.Rb(),r.Nb(43,"input",10),r.yc(44,H,6,4,"mat-error",4),r.Rb(),r.Sb(45,"mat-form-field"),r.Sb(46,"mat-label"),r.zc(47,"WMOID"),r.Rb(),r.Nb(48,"input",11),r.yc(49,A,7,5,"mat-error",4),r.Rb(),r.Rb(),r.Sb(50,"p"),r.Sb(51,"mat-form-field"),r.Sb(52,"mat-label"),r.zc(53,"TCID"),r.Rb(),r.Nb(54,"input",12),r.yc(55,U,6,4,"mat-error",4),r.Rb(),r.Sb(56,"mat-form-field"),r.Sb(57,"mat-label"),r.zc(58,"IsQuebecSite"),r.Rb(),r.Nb(59,"input",13),r.yc(60,W,5,3,"mat-error",4),r.Rb(),r.Sb(61,"mat-form-field"),r.Sb(62,"mat-label"),r.zc(63,"IsCoCoRaHS"),r.Rb(),r.Nb(64,"input",14),r.yc(65,Q,5,3,"mat-error",4),r.Rb(),r.Sb(66,"mat-form-field"),r.Sb(67,"mat-label"),r.zc(68,"TimeOffset_hour"),r.Rb(),r.Nb(69,"input",15),r.yc(70,X,7,5,"mat-error",4),r.Rb(),r.Rb(),r.Sb(71,"p"),r.Sb(72,"mat-form-field"),r.Sb(73,"mat-label"),r.zc(74,"File_desc"),r.Rb(),r.Nb(75,"input",16),r.yc(76,Y,6,4,"mat-error",4),r.Rb(),r.Sb(77,"mat-form-field"),r.Sb(78,"mat-label"),r.zc(79,"HourlyStartDate_Local"),r.Rb(),r.Nb(80,"input",17),r.yc(81,tt,5,3,"mat-error",4),r.Rb(),r.Sb(82,"mat-form-field"),r.Sb(83,"mat-label"),r.zc(84,"HourlyEndDate_Local"),r.Rb(),r.Nb(85,"input",18),r.yc(86,et,5,3,"mat-error",4),r.Rb(),r.Sb(87,"mat-form-field"),r.Sb(88,"mat-label"),r.zc(89,"HourlyNow"),r.Rb(),r.Nb(90,"input",19),r.yc(91,it,5,3,"mat-error",4),r.Rb(),r.Rb(),r.Sb(92,"p"),r.Sb(93,"mat-form-field"),r.Sb(94,"mat-label"),r.zc(95,"DailyStartDate_Local"),r.Rb(),r.Nb(96,"input",20),r.yc(97,at,5,3,"mat-error",4),r.Rb(),r.Sb(98,"mat-form-field"),r.Sb(99,"mat-label"),r.zc(100,"DailyEndDate_Local"),r.Rb(),r.Nb(101,"input",21),r.yc(102,ct,5,3,"mat-error",4),r.Rb(),r.Sb(103,"mat-form-field"),r.Sb(104,"mat-label"),r.zc(105,"DailyNow"),r.Rb(),r.Nb(106,"input",22),r.yc(107,ot,5,3,"mat-error",4),r.Rb(),r.Sb(108,"mat-form-field"),r.Sb(109,"mat-label"),r.zc(110,"MonthlyStartDate_Local"),r.Rb(),r.Nb(111,"input",23),r.yc(112,nt,5,3,"mat-error",4),r.Rb(),r.Rb(),r.Sb(113,"p"),r.Sb(114,"mat-form-field"),r.Sb(115,"mat-label"),r.zc(116,"MonthlyEndDate_Local"),r.Rb(),r.Nb(117,"input",24),r.yc(118,rt,5,3,"mat-error",4),r.Rb(),r.Sb(119,"mat-form-field"),r.Sb(120,"mat-label"),r.zc(121,"MonthlyNow"),r.Rb(),r.Nb(122,"input",25),r.yc(123,bt,5,3,"mat-error",4),r.Rb(),r.Sb(124,"mat-form-field"),r.Sb(125,"mat-label"),r.zc(126,"LastUpdateDate_UTC"),r.Rb(),r.Nb(127,"input",26),r.yc(128,st,6,4,"mat-error",4),r.Rb(),r.Sb(129,"mat-form-field"),r.Sb(130,"mat-label"),r.zc(131,"LastUpdateContactTVItemID"),r.Rb(),r.Nb(132,"input",27),r.yc(133,ut,6,4,"mat-error",4),r.Rb(),r.Rb(),r.Rb()),2&t&&(r.ic("formGroup",e.climatesiteFormEdit),r.Bb(5),r.Bc("",e.GetPut()?"Put":"Post"," ClimateSite"),r.Bb(1),r.ic("ngIf",e.climatesiteService.climatesitePutModel$.getValue().Working),r.Bb(1),r.ic("ngIf",e.climatesiteService.climatesitePostModel$.getValue().Working),r.Bb(6),r.ic("ngIf",e.climatesiteFormEdit.controls.ClimateSiteID.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.ClimateSiteTVItemID.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.ECDBID.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.ClimateSiteName.errors),r.Bb(6),r.ic("ngIf",e.climatesiteFormEdit.controls.Province.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.Elevation_m.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.ClimateID.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.WMOID.errors),r.Bb(6),r.ic("ngIf",e.climatesiteFormEdit.controls.TCID.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.IsQuebecSite.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.IsCoCoRaHS.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.TimeOffset_hour.errors),r.Bb(6),r.ic("ngIf",e.climatesiteFormEdit.controls.File_desc.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.HourlyStartDate_Local.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.HourlyEndDate_Local.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.HourlyNow.errors),r.Bb(6),r.ic("ngIf",e.climatesiteFormEdit.controls.DailyStartDate_Local.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.DailyEndDate_Local.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.DailyNow.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.MonthlyStartDate_Local.errors),r.Bb(6),r.ic("ngIf",e.climatesiteFormEdit.controls.MonthlyEndDate_Local.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.MonthlyNow.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.LastUpdateDate_UTC.errors),r.Bb(5),r.ic("ngIf",e.climatesiteFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[I.q,I.l,I.f,d.b,a.l,C.c,C.f,D.b,I.n,I.c,I.k,I.e,h.a,C.b],pipes:[a.f],styles:[""],changeDetection:0}),t})();function St(t,e){1&t&&r.Nb(0,"mat-progress-bar",4)}function ft(t,e){1&t&&r.Nb(0,"mat-progress-bar",4)}function dt(t,e){if(1&t&&(r.Sb(0,"p"),r.Nb(1,"app-climatesite-edit",8),r.Rb()),2&t){const t=r.dc().$implicit,e=r.dc(2);r.Bb(1),r.ic("climatesite",t)("httpClientCommand",e.GetPutEnum())}}function ht(t,e){if(1&t&&(r.Sb(0,"p"),r.Nb(1,"app-climatesite-edit",8),r.Rb()),2&t){const t=r.dc().$implicit,e=r.dc(2);r.Bb(1),r.ic("climatesite",t)("httpClientCommand",e.GetPostEnum())}}function Rt(t,e){if(1&t){const t=r.Tb();r.Sb(0,"div"),r.Sb(1,"p"),r.Sb(2,"button",6),r.Zb("click",(function(){r.qc(t);const i=e.$implicit;return r.dc(2).DeleteClimateSite(i)})),r.Sb(3,"span"),r.zc(4),r.Rb(),r.Sb(5,"mat-icon"),r.zc(6,"delete"),r.Rb(),r.Rb(),r.zc(7,"\xa0\xa0\xa0 "),r.Sb(8,"button",7),r.Zb("click",(function(){r.qc(t);const i=e.$implicit;return r.dc(2).ShowPut(i)})),r.Sb(9,"span"),r.zc(10,"Show Put"),r.Rb(),r.Rb(),r.zc(11,"\xa0\xa0 "),r.Sb(12,"button",7),r.Zb("click",(function(){r.qc(t);const i=e.$implicit;return r.dc(2).ShowPost(i)})),r.Sb(13,"span"),r.zc(14,"Show Post"),r.Rb(),r.Rb(),r.zc(15,"\xa0\xa0 "),r.yc(16,ft,1,0,"mat-progress-bar",0),r.Rb(),r.yc(17,dt,2,2,"p",2),r.yc(18,ht,2,2,"p",2),r.Sb(19,"blockquote"),r.Sb(20,"p"),r.Sb(21,"span"),r.zc(22),r.Rb(),r.Sb(23,"span"),r.zc(24),r.Rb(),r.Sb(25,"span"),r.zc(26),r.Rb(),r.Sb(27,"span"),r.zc(28),r.Rb(),r.Rb(),r.Sb(29,"p"),r.Sb(30,"span"),r.zc(31),r.Rb(),r.Sb(32,"span"),r.zc(33),r.Rb(),r.Sb(34,"span"),r.zc(35),r.Rb(),r.Sb(36,"span"),r.zc(37),r.Rb(),r.Rb(),r.Sb(38,"p"),r.Sb(39,"span"),r.zc(40),r.Rb(),r.Sb(41,"span"),r.zc(42),r.Rb(),r.Sb(43,"span"),r.zc(44),r.Rb(),r.Sb(45,"span"),r.zc(46),r.Rb(),r.Rb(),r.Sb(47,"p"),r.Sb(48,"span"),r.zc(49),r.Rb(),r.Sb(50,"span"),r.zc(51),r.Rb(),r.Sb(52,"span"),r.zc(53),r.Rb(),r.Sb(54,"span"),r.zc(55),r.Rb(),r.Rb(),r.Sb(56,"p"),r.Sb(57,"span"),r.zc(58),r.Rb(),r.Sb(59,"span"),r.zc(60),r.Rb(),r.Sb(61,"span"),r.zc(62),r.Rb(),r.Sb(63,"span"),r.zc(64),r.Rb(),r.Rb(),r.Sb(65,"p"),r.Sb(66,"span"),r.zc(67),r.Rb(),r.Sb(68,"span"),r.zc(69),r.Rb(),r.Sb(70,"span"),r.zc(71),r.Rb(),r.Sb(72,"span"),r.zc(73),r.Rb(),r.Rb(),r.Rb(),r.Rb()}if(2&t){const t=e.$implicit,i=r.dc(2);r.Bb(4),r.Bc("Delete ClimateSiteID [",t.ClimateSiteID,"]\xa0\xa0\xa0"),r.Bb(4),r.ic("color",i.GetPutButtonColor(t)),r.Bb(4),r.ic("color",i.GetPostButtonColor(t)),r.Bb(4),r.ic("ngIf",i.climatesiteService.climatesiteDeleteModel$.getValue().Working),r.Bb(1),r.ic("ngIf",i.IDToShow===t.ClimateSiteID&&i.showType===i.GetPutEnum()),r.Bb(1),r.ic("ngIf",i.IDToShow===t.ClimateSiteID&&i.showType===i.GetPostEnum()),r.Bb(4),r.Bc("ClimateSiteID: [",t.ClimateSiteID,"]"),r.Bb(2),r.Bc(" --- ClimateSiteTVItemID: [",t.ClimateSiteTVItemID,"]"),r.Bb(2),r.Bc(" --- ECDBID: [",t.ECDBID,"]"),r.Bb(2),r.Bc(" --- ClimateSiteName: [",t.ClimateSiteName,"]"),r.Bb(3),r.Bc("Province: [",t.Province,"]"),r.Bb(2),r.Bc(" --- Elevation_m: [",t.Elevation_m,"]"),r.Bb(2),r.Bc(" --- ClimateID: [",t.ClimateID,"]"),r.Bb(2),r.Bc(" --- WMOID: [",t.WMOID,"]"),r.Bb(3),r.Bc("TCID: [",t.TCID,"]"),r.Bb(2),r.Bc(" --- IsQuebecSite: [",t.IsQuebecSite,"]"),r.Bb(2),r.Bc(" --- IsCoCoRaHS: [",t.IsCoCoRaHS,"]"),r.Bb(2),r.Bc(" --- TimeOffset_hour: [",t.TimeOffset_hour,"]"),r.Bb(3),r.Bc("File_desc: [",t.File_desc,"]"),r.Bb(2),r.Bc(" --- HourlyStartDate_Local: [",t.HourlyStartDate_Local,"]"),r.Bb(2),r.Bc(" --- HourlyEndDate_Local: [",t.HourlyEndDate_Local,"]"),r.Bb(2),r.Bc(" --- HourlyNow: [",t.HourlyNow,"]"),r.Bb(3),r.Bc("DailyStartDate_Local: [",t.DailyStartDate_Local,"]"),r.Bb(2),r.Bc(" --- DailyEndDate_Local: [",t.DailyEndDate_Local,"]"),r.Bb(2),r.Bc(" --- DailyNow: [",t.DailyNow,"]"),r.Bb(2),r.Bc(" --- MonthlyStartDate_Local: [",t.MonthlyStartDate_Local,"]"),r.Bb(3),r.Bc("MonthlyEndDate_Local: [",t.MonthlyEndDate_Local,"]"),r.Bb(2),r.Bc(" --- MonthlyNow: [",t.MonthlyNow,"]"),r.Bb(2),r.Bc(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),r.Bb(2),r.Bc(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function It(t,e){if(1&t&&(r.Sb(0,"div"),r.yc(1,Rt,74,30,"div",5),r.Rb()),2&t){const t=r.dc();r.Bb(1),r.ic("ngForOf",t.climatesiteService.climatesiteListModel$.getValue())}}const Ct=[{path:"",component:(()=>{class t{constructor(t,e,i){this.climatesiteService=t,this.router=e,this.httpClientService=i,this.showType=null,i.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.ClimateSiteID&&this.showType===n.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.ClimateSiteID&&this.showType===n.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.ClimateSiteID&&this.showType===n.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ClimateSiteID,this.showType=n.a.Put)}ShowPost(t){this.IDToShow===t.ClimateSiteID&&this.showType===n.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ClimateSiteID,this.showType=n.a.Post)}GetPutEnum(){return n.a.Put}GetPostEnum(){return n.a.Post}GetClimateSiteList(){this.sub=this.climatesiteService.GetClimateSiteList().subscribe()}DeleteClimateSite(t){this.sub=this.climatesiteService.DeleteClimateSite(t).subscribe()}ngOnInit(){o(this.climatesiteService.climatesiteTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(r.Mb(S),r.Mb(c.b),r.Mb(p.a))},t.\u0275cmp=r.Gb({type:t,selectors:[["app-climatesite"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"climatesite","httpClientCommand"]],template:function(t,e){var i,a;1&t&&(r.yc(0,St,1,0,"mat-progress-bar",0),r.Sb(1,"mat-card"),r.Sb(2,"mat-card-header"),r.Sb(3,"mat-card-title"),r.zc(4," ClimateSite works! "),r.Sb(5,"button",1),r.Zb("click",(function(){return e.GetClimateSiteList()})),r.Sb(6,"span"),r.zc(7,"Get ClimateSite"),r.Rb(),r.Rb(),r.Rb(),r.Sb(8,"mat-card-subtitle"),r.zc(9),r.Rb(),r.Rb(),r.Sb(10,"mat-card-content"),r.yc(11,It,2,1,"div",2),r.Rb(),r.Sb(12,"mat-card-actions"),r.Sb(13,"button",3),r.zc(14,"Allo"),r.Rb(),r.Rb(),r.Rb()),2&t&&(r.ic("ngIf",null==(i=e.climatesiteService.climatesiteGetModel$.getValue())?null:i.Working),r.Bb(9),r.Ac(e.climatesiteService.climatesiteTextModel$.getValue().Title),r.Bb(2),r.ic("ngIf",null==(a=e.climatesiteService.climatesiteListModel$.getValue())?null:a.length))},directives:[a.l,f.a,f.d,f.g,d.b,f.f,f.c,f.b,h.a,a.k,R.a,pt],styles:[""],changeDetection:0}),t})(),canActivate:[i("auXs").a]}];let Dt=(()=>{class t{}return t.\u0275mod=r.Kb({type:t}),t.\u0275inj=r.Jb({factory:function(e){return new(e||t)},imports:[[c.e.forChild(Ct)],c.e]}),t})();var yt=i("B+Mi");let Bt=(()=>{class t{}return t.\u0275mod=r.Kb({type:t}),t.\u0275inj=r.Jb({factory:function(e){return new(e||t)},imports:[[a.c,c.e,Dt,yt.a,I.g,I.o]]}),t})()},QRvi:function(t,e,i){"use strict";i.d(e,"a",(function(){return a}));var a=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,i){"use strict";i.d(e,"a",(function(){return n}));var a=i("QRvi"),c=i("fXoL"),o=i("tyNb");let n=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,i,c,o){if(c===a.a.Get&&t.next(i),c===a.a.Put&&(t.getValue()[0]=i),c===a.a.Post&&t.getValue().push(i),c===a.a.Delete){const e=t.getValue().indexOf(o);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,i,c,o){c===a.a.Get&&t.next(i),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(c.Wb(o.b))},t.\u0275prov=c.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);