(window.webpackJsonp=window.webpackJsonp||[]).push([[62],{QRvi:function(t,e,r){"use strict";r.d(e,"a",(function(){return a}));var a=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},ZGES:function(t,e,r){"use strict";r.r(e),r.d(e,"MWQMAnalysisReportParameterModule",(function(){return pe}));var a=r("ofXK"),i=r("tyNb");function n(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}function s(){let t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"All - All - All"}),t.push({EnumID:2,EnumText:"Wet - All - All (fr)"}),t.push({EnumID:3,EnumText:"Dry - All - All (fr)"}),t.push({EnumID:4,EnumText:"Wet - Wet - All (fr)"}),t.push({EnumID:5,EnumText:"Dry - Dry - All (fr)"}),t.push({EnumID:6,EnumText:"Wet - Dry - All (fr)"}),t.push({EnumID:7,EnumText:"Dry - Wet - All (fr)"})):(t.push({EnumID:1,EnumText:"All - All - All"}),t.push({EnumID:2,EnumText:"Wet - All - All"}),t.push({EnumID:3,EnumText:"Dry - All - All"}),t.push({EnumID:4,EnumText:"Wet - Wet - All"}),t.push({EnumID:5,EnumText:"Dry - Dry - All"}),t.push({EnumID:6,EnumText:"Wet - Dry - All"}),t.push({EnumID:7,EnumText:"Dry - Wet - All"})),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}function m(){let t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"Rapport"}),t.push({EnumID:2,EnumText:"Excel"})):(t.push({EnumID:1,EnumText:"Report"}),t.push({EnumID:2,EnumText:"Excel"})),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}var o=r("QRvi"),b=r("fXoL"),c=r("2Vo4"),p=r("LRne"),l=r("tk/3"),u=r("lJxs"),f=r("JIr8"),y=r("gkM4");let R=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.mwqmanalysisreportparameterTextModel$=new c.a({}),this.mwqmanalysisreportparameterListModel$=new c.a({}),this.mwqmanalysisreportparameterGetModel$=new c.a({}),this.mwqmanalysisreportparameterPutModel$=new c.a({}),this.mwqmanalysisreportparameterPostModel$=new c.a({}),this.mwqmanalysisreportparameterDeleteModel$=new c.a({}),n(this.mwqmanalysisreportparameterTextModel$),this.mwqmanalysisreportparameterTextModel$.next({Title:"Something2 for text"})}GetMWQMAnalysisReportParameterList(){return this.httpClientService.BeforeHttpClient(this.mwqmanalysisreportparameterGetModel$),this.httpClient.get("/api/MWQMAnalysisReportParameter").pipe(Object(u.a)(t=>{this.httpClientService.DoSuccess(this.mwqmanalysisreportparameterListModel$,this.mwqmanalysisreportparameterGetModel$,t,o.a.Get,null)}),Object(f.a)(t=>Object(p.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.mwqmanalysisreportparameterListModel$,this.mwqmanalysisreportparameterGetModel$,t)}))))}PutMWQMAnalysisReportParameter(t){return this.httpClientService.BeforeHttpClient(this.mwqmanalysisreportparameterPutModel$),this.httpClient.put("/api/MWQMAnalysisReportParameter",t,{headers:new l.d}).pipe(Object(u.a)(e=>{this.httpClientService.DoSuccess(this.mwqmanalysisreportparameterListModel$,this.mwqmanalysisreportparameterPutModel$,e,o.a.Put,t)}),Object(f.a)(t=>Object(p.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.mwqmanalysisreportparameterListModel$,this.mwqmanalysisreportparameterPutModel$,t)}))))}PostMWQMAnalysisReportParameter(t){return this.httpClientService.BeforeHttpClient(this.mwqmanalysisreportparameterPostModel$),this.httpClient.post("/api/MWQMAnalysisReportParameter",t,{headers:new l.d}).pipe(Object(u.a)(e=>{this.httpClientService.DoSuccess(this.mwqmanalysisreportparameterListModel$,this.mwqmanalysisreportparameterPostModel$,e,o.a.Post,t)}),Object(f.a)(t=>Object(p.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.mwqmanalysisreportparameterListModel$,this.mwqmanalysisreportparameterPostModel$,t)}))))}DeleteMWQMAnalysisReportParameter(t){return this.httpClientService.BeforeHttpClient(this.mwqmanalysisreportparameterDeleteModel$),this.httpClient.delete("/api/MWQMAnalysisReportParameter/"+t.MWQMAnalysisReportParameterID).pipe(Object(u.a)(e=>{this.httpClientService.DoSuccess(this.mwqmanalysisreportparameterListModel$,this.mwqmanalysisreportparameterDeleteModel$,e,o.a.Delete,t)}),Object(f.a)(t=>Object(p.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.mwqmanalysisreportparameterListModel$,this.mwqmanalysisreportparameterDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(b.Wb(l.b),b.Wb(y.a))},t.\u0275prov=b.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var d=r("Wp6s"),S=r("bTqV"),h=r("bv9b"),I=r("NFeN"),g=r("3Pt+"),q=r("kmnG"),D=r("qFsG"),B=r("d3UM"),w=r("FKr1");function M(t,e){1&t&&b.Nb(0,"mat-progress-bar",31)}function N(t,e){1&t&&b.Nb(0,"mat-progress-bar",31)}function z(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function A(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,z,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function T(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function E(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,T,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function C(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function v(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"MinLength - 5"),b.Nb(2,"br"),b.Rb())}function L(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"MaxLength - 250"),b.Nb(2,"br"),b.Rb())}function x(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,C,3,0,"span",4),b.yc(6,v,3,0,"span",4),b.yc(7,L,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.minlength),b.Bb(1),b.ic("ngIf",t.maxlength)}}function P(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1980"),b.Nb(2,"br"),b.Rb())}function W(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 2050"),b.Nb(2,"br"),b.Rb())}function $(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,P,3,0,"span",4),b.yc(6,W,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,3,t)),b.Bb(3),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function F(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function O(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,F,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function Q(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function j(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Q,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function V(t,e){if(1&t&&(b.Sb(0,"mat-option",32),b.zc(1),b.Rb()),2&t){const t=e.$implicit;b.ic("value",t.EnumID),b.Bb(1),b.Bc(" ",t.EnumText," ")}}function G(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function k(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,G,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function U(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Y(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function H(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 1000"),b.Nb(2,"br"),b.Rb())}function _(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,U,3,0,"span",4),b.yc(6,Y,3,0,"span",4),b.yc(7,H,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function J(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Z(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,J,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function K(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function X(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function tt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 20"),b.Nb(2,"br"),b.Rb())}function et(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,K,3,0,"span",4),b.yc(6,X,3,0,"span",4),b.yc(7,tt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function rt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function at(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function it(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 5"),b.Nb(2,"br"),b.Rb())}function nt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,rt,3,0,"span",4),b.yc(6,at,3,0,"span",4),b.yc(7,it,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function st(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function mt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 2"),b.Nb(2,"br"),b.Rb())}function ot(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 7"),b.Nb(2,"br"),b.Rb())}function bt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,st,3,0,"span",4),b.yc(6,mt,3,0,"span",4),b.yc(7,ot,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function ct(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function pt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function lt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function ut(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,ct,3,0,"span",4),b.yc(6,pt,3,0,"span",4),b.yc(7,lt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function ft(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function yt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function Rt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function dt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,ft,3,0,"span",4),b.yc(6,yt,3,0,"span",4),b.yc(7,Rt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function St(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function ht(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function It(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function gt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,St,3,0,"span",4),b.yc(6,ht,3,0,"span",4),b.yc(7,It,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function qt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Dt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function Bt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function wt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,qt,3,0,"span",4),b.yc(6,Dt,3,0,"span",4),b.yc(7,Bt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function Mt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Nt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function zt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function At(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Mt,3,0,"span",4),b.yc(6,Nt,3,0,"span",4),b.yc(7,zt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function Tt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Et(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function Ct(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function vt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Tt,3,0,"span",4),b.yc(6,Et,3,0,"span",4),b.yc(7,Ct,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function Lt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function xt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function Pt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function Wt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Lt,3,0,"span",4),b.yc(6,xt,3,0,"span",4),b.yc(7,Pt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function $t(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Ft(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function Ot(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function Qt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,$t,3,0,"span",4),b.yc(6,Ft,3,0,"span",4),b.yc(7,Ot,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.min),b.Bb(1),b.ic("ngIf",t.min)}}function jt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Vt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"MaxLength - 250"),b.Nb(2,"br"),b.Rb())}function Gt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,jt,3,0,"span",4),b.yc(6,Vt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,3,t)),b.Bb(3),b.ic("ngIf",t.required),b.Bb(1),b.ic("ngIf",t.maxlength)}}function kt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"MaxLength - 20"),b.Nb(2,"br"),b.Rb())}function Ut(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,kt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.maxlength)}}function Yt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,1,t))}}function Ht(t,e){if(1&t&&(b.Sb(0,"mat-option",32),b.zc(1),b.Rb()),2&t){const t=e.$implicit;b.ic("value",t.EnumID),b.Bb(1),b.Bc(" ",t.EnumText," ")}}function _t(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Jt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,_t,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function Zt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Kt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Zt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}function Xt(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function te(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Xt,3,0,"span",4),b.Rb()),2&t){const t=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,t)),b.Bb(3),b.ic("ngIf",t.required)}}let ee=(()=>{class t{constructor(t,e){this.mwqmanalysisreportparameterService=t,this.fb=e,this.mwqmanalysisreportparameter=null,this.httpClientCommand=o.a.Put}GetPut(){return this.httpClientCommand==o.a.Put}PutMWQMAnalysisReportParameter(t){this.sub=this.mwqmanalysisreportparameterService.PutMWQMAnalysisReportParameter(t).subscribe()}PostMWQMAnalysisReportParameter(t){this.sub=this.mwqmanalysisreportparameterService.PostMWQMAnalysisReportParameter(t).subscribe()}ngOnInit(){this.analysisCalculationTypeList=s(),this.commandList=m(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.mwqmanalysisreportparameter){let e=this.fb.group({MWQMAnalysisReportParameterID:[{value:t===o.a.Post?0:this.mwqmanalysisreportparameter.MWQMAnalysisReportParameterID,disabled:!1},[g.p.required]],SubsectorTVItemID:[{value:this.mwqmanalysisreportparameter.SubsectorTVItemID,disabled:!1},[g.p.required]],AnalysisName:[{value:this.mwqmanalysisreportparameter.AnalysisName,disabled:!1},[g.p.required,g.p.minLength(5),g.p.maxLength(250)]],AnalysisReportYear:[{value:this.mwqmanalysisreportparameter.AnalysisReportYear,disabled:!1},[g.p.min(1980),g.p.max(2050)]],StartDate:[{value:this.mwqmanalysisreportparameter.StartDate,disabled:!1},[g.p.required]],EndDate:[{value:this.mwqmanalysisreportparameter.EndDate,disabled:!1},[g.p.required]],AnalysisCalculationType:[{value:this.mwqmanalysisreportparameter.AnalysisCalculationType,disabled:!1},[g.p.required]],NumberOfRuns:[{value:this.mwqmanalysisreportparameter.NumberOfRuns,disabled:!1},[g.p.required,g.p.min(1),g.p.max(1e3)]],FullYear:[{value:this.mwqmanalysisreportparameter.FullYear,disabled:!1},[g.p.required]],SalinityHighlightDeviationFromAverage:[{value:this.mwqmanalysisreportparameter.SalinityHighlightDeviationFromAverage,disabled:!1},[g.p.required,g.p.min(1),g.p.max(20)]],ShortRangeNumberOfDays:[{value:this.mwqmanalysisreportparameter.ShortRangeNumberOfDays,disabled:!1},[g.p.required,g.p.min(0),g.p.max(5)]],MidRangeNumberOfDays:[{value:this.mwqmanalysisreportparameter.MidRangeNumberOfDays,disabled:!1},[g.p.required,g.p.min(2),g.p.max(7)]],DryLimit24h:[{value:this.mwqmanalysisreportparameter.DryLimit24h,disabled:!1},[g.p.required,g.p.min(1),g.p.max(100)]],DryLimit48h:[{value:this.mwqmanalysisreportparameter.DryLimit48h,disabled:!1},[g.p.required,g.p.min(1),g.p.max(100)]],DryLimit72h:[{value:this.mwqmanalysisreportparameter.DryLimit72h,disabled:!1},[g.p.required,g.p.min(1),g.p.max(100)]],DryLimit96h:[{value:this.mwqmanalysisreportparameter.DryLimit96h,disabled:!1},[g.p.required,g.p.min(1),g.p.max(100)]],WetLimit24h:[{value:this.mwqmanalysisreportparameter.WetLimit24h,disabled:!1},[g.p.required,g.p.min(1),g.p.max(100)]],WetLimit48h:[{value:this.mwqmanalysisreportparameter.WetLimit48h,disabled:!1},[g.p.required,g.p.min(1),g.p.max(100)]],WetLimit72h:[{value:this.mwqmanalysisreportparameter.WetLimit72h,disabled:!1},[g.p.required,g.p.min(1),g.p.max(100)]],WetLimit96h:[{value:this.mwqmanalysisreportparameter.WetLimit96h,disabled:!1},[g.p.required,g.p.min(1),g.p.max(100)]],RunsToOmit:[{value:this.mwqmanalysisreportparameter.RunsToOmit,disabled:!1},[g.p.required,g.p.maxLength(250)]],ShowDataTypes:[{value:this.mwqmanalysisreportparameter.ShowDataTypes,disabled:!1},[g.p.maxLength(20)]],ExcelTVFileTVItemID:[{value:this.mwqmanalysisreportparameter.ExcelTVFileTVItemID,disabled:!1}],Command:[{value:this.mwqmanalysisreportparameter.Command,disabled:!1},[g.p.required]],LastUpdateDate_UTC:[{value:this.mwqmanalysisreportparameter.LastUpdateDate_UTC,disabled:!1},[g.p.required]],LastUpdateContactTVItemID:[{value:this.mwqmanalysisreportparameter.LastUpdateContactTVItemID,disabled:!1},[g.p.required]]});this.mwqmanalysisreportparameterFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(b.Mb(R),b.Mb(g.d))},t.\u0275cmp=b.Gb({type:t,selectors:[["app-mwqmanalysisreportparameter-edit"]],inputs:{mwqmanalysisreportparameter:"mwqmanalysisreportparameter",httpClientCommand:"httpClientCommand"},decls:147,vars:32,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","MWQMAnalysisReportParameterID"],[4,"ngIf"],["matInput","","type","number","formControlName","SubsectorTVItemID"],["matInput","","type","text","formControlName","AnalysisName"],["matInput","","type","number","formControlName","AnalysisReportYear"],["matInput","","type","text","formControlName","StartDate"],["matInput","","type","text","formControlName","EndDate"],["formControlName","AnalysisCalculationType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","number","formControlName","NumberOfRuns"],["matInput","","type","text","formControlName","FullYear"],["matInput","","type","number","formControlName","SalinityHighlightDeviationFromAverage"],["matInput","","type","number","formControlName","ShortRangeNumberOfDays"],["matInput","","type","number","formControlName","MidRangeNumberOfDays"],["matInput","","type","number","formControlName","DryLimit24h"],["matInput","","type","number","formControlName","DryLimit48h"],["matInput","","type","number","formControlName","DryLimit72h"],["matInput","","type","number","formControlName","DryLimit96h"],["matInput","","type","number","formControlName","WetLimit24h"],["matInput","","type","number","formControlName","WetLimit48h"],["matInput","","type","number","formControlName","WetLimit72h"],["matInput","","type","number","formControlName","WetLimit96h"],["matInput","","type","text","formControlName","RunsToOmit"],["matInput","","type","text","formControlName","ShowDataTypes"],["matInput","","type","number","formControlName","ExcelTVFileTVItemID"],["formControlName","Command"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(b.Sb(0,"form",0),b.Zb("ngSubmit",(function(){return e.GetPut()?e.PutMWQMAnalysisReportParameter(e.mwqmanalysisreportparameterFormEdit.value):e.PostMWQMAnalysisReportParameter(e.mwqmanalysisreportparameterFormEdit.value)})),b.Sb(1,"h3"),b.zc(2," MWQMAnalysisReportParameter "),b.Sb(3,"button",1),b.Sb(4,"span"),b.zc(5),b.Rb(),b.Rb(),b.yc(6,M,1,0,"mat-progress-bar",2),b.yc(7,N,1,0,"mat-progress-bar",2),b.Rb(),b.Sb(8,"p"),b.Sb(9,"mat-form-field"),b.Sb(10,"mat-label"),b.zc(11,"MWQMAnalysisReportParameterID"),b.Rb(),b.Nb(12,"input",3),b.yc(13,A,6,4,"mat-error",4),b.Rb(),b.Sb(14,"mat-form-field"),b.Sb(15,"mat-label"),b.zc(16,"SubsectorTVItemID"),b.Rb(),b.Nb(17,"input",5),b.yc(18,E,6,4,"mat-error",4),b.Rb(),b.Sb(19,"mat-form-field"),b.Sb(20,"mat-label"),b.zc(21,"AnalysisName"),b.Rb(),b.Nb(22,"input",6),b.yc(23,x,8,6,"mat-error",4),b.Rb(),b.Sb(24,"mat-form-field"),b.Sb(25,"mat-label"),b.zc(26,"AnalysisReportYear"),b.Rb(),b.Nb(27,"input",7),b.yc(28,$,7,5,"mat-error",4),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"mat-form-field"),b.Sb(31,"mat-label"),b.zc(32,"StartDate"),b.Rb(),b.Nb(33,"input",8),b.yc(34,O,6,4,"mat-error",4),b.Rb(),b.Sb(35,"mat-form-field"),b.Sb(36,"mat-label"),b.zc(37,"EndDate"),b.Rb(),b.Nb(38,"input",9),b.yc(39,j,6,4,"mat-error",4),b.Rb(),b.Sb(40,"mat-form-field"),b.Sb(41,"mat-label"),b.zc(42,"AnalysisCalculationType"),b.Rb(),b.Sb(43,"mat-select",10),b.yc(44,V,2,2,"mat-option",11),b.Rb(),b.yc(45,k,6,4,"mat-error",4),b.Rb(),b.Sb(46,"mat-form-field"),b.Sb(47,"mat-label"),b.zc(48,"NumberOfRuns"),b.Rb(),b.Nb(49,"input",12),b.yc(50,_,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(51,"p"),b.Sb(52,"mat-form-field"),b.Sb(53,"mat-label"),b.zc(54,"FullYear"),b.Rb(),b.Nb(55,"input",13),b.yc(56,Z,6,4,"mat-error",4),b.Rb(),b.Sb(57,"mat-form-field"),b.Sb(58,"mat-label"),b.zc(59,"SalinityHighlightDeviationFromAverage"),b.Rb(),b.Nb(60,"input",14),b.yc(61,et,8,6,"mat-error",4),b.Rb(),b.Sb(62,"mat-form-field"),b.Sb(63,"mat-label"),b.zc(64,"ShortRangeNumberOfDays"),b.Rb(),b.Nb(65,"input",15),b.yc(66,nt,8,6,"mat-error",4),b.Rb(),b.Sb(67,"mat-form-field"),b.Sb(68,"mat-label"),b.zc(69,"MidRangeNumberOfDays"),b.Rb(),b.Nb(70,"input",16),b.yc(71,bt,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(72,"p"),b.Sb(73,"mat-form-field"),b.Sb(74,"mat-label"),b.zc(75,"DryLimit24h"),b.Rb(),b.Nb(76,"input",17),b.yc(77,ut,8,6,"mat-error",4),b.Rb(),b.Sb(78,"mat-form-field"),b.Sb(79,"mat-label"),b.zc(80,"DryLimit48h"),b.Rb(),b.Nb(81,"input",18),b.yc(82,dt,8,6,"mat-error",4),b.Rb(),b.Sb(83,"mat-form-field"),b.Sb(84,"mat-label"),b.zc(85,"DryLimit72h"),b.Rb(),b.Nb(86,"input",19),b.yc(87,gt,8,6,"mat-error",4),b.Rb(),b.Sb(88,"mat-form-field"),b.Sb(89,"mat-label"),b.zc(90,"DryLimit96h"),b.Rb(),b.Nb(91,"input",20),b.yc(92,wt,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(93,"p"),b.Sb(94,"mat-form-field"),b.Sb(95,"mat-label"),b.zc(96,"WetLimit24h"),b.Rb(),b.Nb(97,"input",21),b.yc(98,At,8,6,"mat-error",4),b.Rb(),b.Sb(99,"mat-form-field"),b.Sb(100,"mat-label"),b.zc(101,"WetLimit48h"),b.Rb(),b.Nb(102,"input",22),b.yc(103,vt,8,6,"mat-error",4),b.Rb(),b.Sb(104,"mat-form-field"),b.Sb(105,"mat-label"),b.zc(106,"WetLimit72h"),b.Rb(),b.Nb(107,"input",23),b.yc(108,Wt,8,6,"mat-error",4),b.Rb(),b.Sb(109,"mat-form-field"),b.Sb(110,"mat-label"),b.zc(111,"WetLimit96h"),b.Rb(),b.Nb(112,"input",24),b.yc(113,Qt,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(114,"p"),b.Sb(115,"mat-form-field"),b.Sb(116,"mat-label"),b.zc(117,"RunsToOmit"),b.Rb(),b.Nb(118,"input",25),b.yc(119,Gt,7,5,"mat-error",4),b.Rb(),b.Sb(120,"mat-form-field"),b.Sb(121,"mat-label"),b.zc(122,"ShowDataTypes"),b.Rb(),b.Nb(123,"input",26),b.yc(124,Ut,6,4,"mat-error",4),b.Rb(),b.Sb(125,"mat-form-field"),b.Sb(126,"mat-label"),b.zc(127,"ExcelTVFileTVItemID"),b.Rb(),b.Nb(128,"input",27),b.yc(129,Yt,5,3,"mat-error",4),b.Rb(),b.Sb(130,"mat-form-field"),b.Sb(131,"mat-label"),b.zc(132,"Command"),b.Rb(),b.Sb(133,"mat-select",28),b.yc(134,Ht,2,2,"mat-option",11),b.Rb(),b.yc(135,Jt,6,4,"mat-error",4),b.Rb(),b.Rb(),b.Sb(136,"p"),b.Sb(137,"mat-form-field"),b.Sb(138,"mat-label"),b.zc(139,"LastUpdateDate_UTC"),b.Rb(),b.Nb(140,"input",29),b.yc(141,Kt,6,4,"mat-error",4),b.Rb(),b.Sb(142,"mat-form-field"),b.Sb(143,"mat-label"),b.zc(144,"LastUpdateContactTVItemID"),b.Rb(),b.Nb(145,"input",30),b.yc(146,te,6,4,"mat-error",4),b.Rb(),b.Rb(),b.Rb()),2&t&&(b.ic("formGroup",e.mwqmanalysisreportparameterFormEdit),b.Bb(5),b.Bc("",e.GetPut()?"Put":"Post"," MWQMAnalysisReportParameter"),b.Bb(1),b.ic("ngIf",e.mwqmanalysisreportparameterService.mwqmanalysisreportparameterPutModel$.getValue().Working),b.Bb(1),b.ic("ngIf",e.mwqmanalysisreportparameterService.mwqmanalysisreportparameterPostModel$.getValue().Working),b.Bb(6),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.MWQMAnalysisReportParameterID.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.SubsectorTVItemID.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.AnalysisName.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.AnalysisReportYear.errors),b.Bb(6),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.StartDate.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.EndDate.errors),b.Bb(5),b.ic("ngForOf",e.analysisCalculationTypeList),b.Bb(1),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.AnalysisCalculationType.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.NumberOfRuns.errors),b.Bb(6),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.FullYear.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.SalinityHighlightDeviationFromAverage.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.ShortRangeNumberOfDays.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.MidRangeNumberOfDays.errors),b.Bb(6),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.DryLimit24h.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.DryLimit48h.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.DryLimit72h.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.DryLimit96h.errors),b.Bb(6),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.WetLimit24h.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.WetLimit48h.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.WetLimit72h.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.WetLimit96h.errors),b.Bb(6),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.RunsToOmit.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.ShowDataTypes.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.ExcelTVFileTVItemID.errors),b.Bb(5),b.ic("ngForOf",e.commandList),b.Bb(1),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.Command.errors),b.Bb(6),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(5),b.ic("ngIf",e.mwqmanalysisreportparameterFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[g.q,g.l,g.f,S.b,a.l,q.c,q.f,D.b,g.n,g.c,g.k,g.e,B.a,a.k,h.a,q.b,w.n],pipes:[a.f],styles:[""],changeDetection:0}),t})();function re(t,e){1&t&&b.Nb(0,"mat-progress-bar",4)}function ae(t,e){1&t&&b.Nb(0,"mat-progress-bar",4)}function ie(t,e){if(1&t&&(b.Sb(0,"p"),b.Nb(1,"app-mwqmanalysisreportparameter-edit",8),b.Rb()),2&t){const t=b.dc().$implicit,e=b.dc(2);b.Bb(1),b.ic("mwqmanalysisreportparameter",t)("httpClientCommand",e.GetPutEnum())}}function ne(t,e){if(1&t&&(b.Sb(0,"p"),b.Nb(1,"app-mwqmanalysisreportparameter-edit",8),b.Rb()),2&t){const t=b.dc().$implicit,e=b.dc(2);b.Bb(1),b.ic("mwqmanalysisreportparameter",t)("httpClientCommand",e.GetPostEnum())}}function se(t,e){if(1&t){const t=b.Tb();b.Sb(0,"div"),b.Sb(1,"p"),b.Sb(2,"button",6),b.Zb("click",(function(){b.qc(t);const r=e.$implicit;return b.dc(2).DeleteMWQMAnalysisReportParameter(r)})),b.Sb(3,"span"),b.zc(4),b.Rb(),b.Sb(5,"mat-icon"),b.zc(6,"delete"),b.Rb(),b.Rb(),b.zc(7,"\xa0\xa0\xa0 "),b.Sb(8,"button",7),b.Zb("click",(function(){b.qc(t);const r=e.$implicit;return b.dc(2).ShowPut(r)})),b.Sb(9,"span"),b.zc(10,"Show Put"),b.Rb(),b.Rb(),b.zc(11,"\xa0\xa0 "),b.Sb(12,"button",7),b.Zb("click",(function(){b.qc(t);const r=e.$implicit;return b.dc(2).ShowPost(r)})),b.Sb(13,"span"),b.zc(14,"Show Post"),b.Rb(),b.Rb(),b.zc(15,"\xa0\xa0 "),b.yc(16,ae,1,0,"mat-progress-bar",0),b.Rb(),b.yc(17,ie,2,2,"p",2),b.yc(18,ne,2,2,"p",2),b.Sb(19,"blockquote"),b.Sb(20,"p"),b.Sb(21,"span"),b.zc(22),b.Rb(),b.Sb(23,"span"),b.zc(24),b.Rb(),b.Sb(25,"span"),b.zc(26),b.Rb(),b.Sb(27,"span"),b.zc(28),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"span"),b.zc(31),b.Rb(),b.Sb(32,"span"),b.zc(33),b.Rb(),b.Sb(34,"span"),b.zc(35),b.Rb(),b.Sb(36,"span"),b.zc(37),b.Rb(),b.Rb(),b.Sb(38,"p"),b.Sb(39,"span"),b.zc(40),b.Rb(),b.Sb(41,"span"),b.zc(42),b.Rb(),b.Sb(43,"span"),b.zc(44),b.Rb(),b.Sb(45,"span"),b.zc(46),b.Rb(),b.Rb(),b.Sb(47,"p"),b.Sb(48,"span"),b.zc(49),b.Rb(),b.Sb(50,"span"),b.zc(51),b.Rb(),b.Sb(52,"span"),b.zc(53),b.Rb(),b.Sb(54,"span"),b.zc(55),b.Rb(),b.Rb(),b.Sb(56,"p"),b.Sb(57,"span"),b.zc(58),b.Rb(),b.Sb(59,"span"),b.zc(60),b.Rb(),b.Sb(61,"span"),b.zc(62),b.Rb(),b.Sb(63,"span"),b.zc(64),b.Rb(),b.Rb(),b.Sb(65,"p"),b.Sb(66,"span"),b.zc(67),b.Rb(),b.Sb(68,"span"),b.zc(69),b.Rb(),b.Sb(70,"span"),b.zc(71),b.Rb(),b.Sb(72,"span"),b.zc(73),b.Rb(),b.Rb(),b.Sb(74,"p"),b.Sb(75,"span"),b.zc(76),b.Rb(),b.Sb(77,"span"),b.zc(78),b.Rb(),b.Rb(),b.Rb(),b.Rb()}if(2&t){const t=e.$implicit,r=b.dc(2);b.Bb(4),b.Bc("Delete MWQMAnalysisReportParameterID [",t.MWQMAnalysisReportParameterID,"]\xa0\xa0\xa0"),b.Bb(4),b.ic("color",r.GetPutButtonColor(t)),b.Bb(4),b.ic("color",r.GetPostButtonColor(t)),b.Bb(4),b.ic("ngIf",r.mwqmanalysisreportparameterService.mwqmanalysisreportparameterDeleteModel$.getValue().Working),b.Bb(1),b.ic("ngIf",r.IDToShow===t.MWQMAnalysisReportParameterID&&r.showType===r.GetPutEnum()),b.Bb(1),b.ic("ngIf",r.IDToShow===t.MWQMAnalysisReportParameterID&&r.showType===r.GetPostEnum()),b.Bb(4),b.Bc("MWQMAnalysisReportParameterID: [",t.MWQMAnalysisReportParameterID,"]"),b.Bb(2),b.Bc(" --- SubsectorTVItemID: [",t.SubsectorTVItemID,"]"),b.Bb(2),b.Bc(" --- AnalysisName: [",t.AnalysisName,"]"),b.Bb(2),b.Bc(" --- AnalysisReportYear: [",t.AnalysisReportYear,"]"),b.Bb(3),b.Bc("StartDate: [",t.StartDate,"]"),b.Bb(2),b.Bc(" --- EndDate: [",t.EndDate,"]"),b.Bb(2),b.Bc(" --- AnalysisCalculationType: [",r.GetAnalysisCalculationTypeEnumText(t.AnalysisCalculationType),"]"),b.Bb(2),b.Bc(" --- NumberOfRuns: [",t.NumberOfRuns,"]"),b.Bb(3),b.Bc("FullYear: [",t.FullYear,"]"),b.Bb(2),b.Bc(" --- SalinityHighlightDeviationFromAverage: [",t.SalinityHighlightDeviationFromAverage,"]"),b.Bb(2),b.Bc(" --- ShortRangeNumberOfDays: [",t.ShortRangeNumberOfDays,"]"),b.Bb(2),b.Bc(" --- MidRangeNumberOfDays: [",t.MidRangeNumberOfDays,"]"),b.Bb(3),b.Bc("DryLimit24h: [",t.DryLimit24h,"]"),b.Bb(2),b.Bc(" --- DryLimit48h: [",t.DryLimit48h,"]"),b.Bb(2),b.Bc(" --- DryLimit72h: [",t.DryLimit72h,"]"),b.Bb(2),b.Bc(" --- DryLimit96h: [",t.DryLimit96h,"]"),b.Bb(3),b.Bc("WetLimit24h: [",t.WetLimit24h,"]"),b.Bb(2),b.Bc(" --- WetLimit48h: [",t.WetLimit48h,"]"),b.Bb(2),b.Bc(" --- WetLimit72h: [",t.WetLimit72h,"]"),b.Bb(2),b.Bc(" --- WetLimit96h: [",t.WetLimit96h,"]"),b.Bb(3),b.Bc("RunsToOmit: [",t.RunsToOmit,"]"),b.Bb(2),b.Bc(" --- ShowDataTypes: [",t.ShowDataTypes,"]"),b.Bb(2),b.Bc(" --- ExcelTVFileTVItemID: [",t.ExcelTVFileTVItemID,"]"),b.Bb(2),b.Bc(" --- Command: [",r.GetAnalysisReportExportCommandEnumText(t.Command),"]"),b.Bb(3),b.Bc("LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),b.Bb(2),b.Bc(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function me(t,e){if(1&t&&(b.Sb(0,"div"),b.yc(1,se,79,32,"div",5),b.Rb()),2&t){const t=b.dc();b.Bb(1),b.ic("ngForOf",t.mwqmanalysisreportparameterService.mwqmanalysisreportparameterListModel$.getValue())}}const oe=[{path:"",component:(()=>{class t{constructor(t,e,r){this.mwqmanalysisreportparameterService=t,this.router=e,this.httpClientService=r,this.showType=null,r.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.MWQMAnalysisReportParameterID&&this.showType===o.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.MWQMAnalysisReportParameterID&&this.showType===o.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.MWQMAnalysisReportParameterID&&this.showType===o.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MWQMAnalysisReportParameterID,this.showType=o.a.Put)}ShowPost(t){this.IDToShow===t.MWQMAnalysisReportParameterID&&this.showType===o.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.MWQMAnalysisReportParameterID,this.showType=o.a.Post)}GetPutEnum(){return o.a.Put}GetPostEnum(){return o.a.Post}GetMWQMAnalysisReportParameterList(){this.sub=this.mwqmanalysisreportparameterService.GetMWQMAnalysisReportParameterList().subscribe()}DeleteMWQMAnalysisReportParameter(t){this.sub=this.mwqmanalysisreportparameterService.DeleteMWQMAnalysisReportParameter(t).subscribe()}GetAnalysisCalculationTypeEnumText(t){return function(t){let e;return s().forEach(r=>{if(r.EnumID==t)return e=r.EnumText,!1}),e}(t)}GetAnalysisReportExportCommandEnumText(t){return function(t){let e;return m().forEach(r=>{if(r.EnumID==t)return e=r.EnumText,!1}),e}(t)}ngOnInit(){n(this.mwqmanalysisreportparameterService.mwqmanalysisreportparameterTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(b.Mb(R),b.Mb(i.b),b.Mb(y.a))},t.\u0275cmp=b.Gb({type:t,selectors:[["app-mwqmanalysisreportparameter"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"mwqmanalysisreportparameter","httpClientCommand"]],template:function(t,e){if(1&t&&(b.yc(0,re,1,0,"mat-progress-bar",0),b.Sb(1,"mat-card"),b.Sb(2,"mat-card-header"),b.Sb(3,"mat-card-title"),b.zc(4," MWQMAnalysisReportParameter works! "),b.Sb(5,"button",1),b.Zb("click",(function(){return e.GetMWQMAnalysisReportParameterList()})),b.Sb(6,"span"),b.zc(7,"Get MWQMAnalysisReportParameter"),b.Rb(),b.Rb(),b.Rb(),b.Sb(8,"mat-card-subtitle"),b.zc(9),b.Rb(),b.Rb(),b.Sb(10,"mat-card-content"),b.yc(11,me,2,1,"div",2),b.Rb(),b.Sb(12,"mat-card-actions"),b.Sb(13,"button",3),b.zc(14,"Allo"),b.Rb(),b.Rb(),b.Rb()),2&t){var r;const t=null==(r=e.mwqmanalysisreportparameterService.mwqmanalysisreportparameterGetModel$.getValue())?null:r.Working;var a;const i=null==(a=e.mwqmanalysisreportparameterService.mwqmanalysisreportparameterListModel$.getValue())?null:a.length;b.ic("ngIf",t),b.Bb(9),b.Ac(e.mwqmanalysisreportparameterService.mwqmanalysisreportparameterTextModel$.getValue().Title),b.Bb(2),b.ic("ngIf",i)}},directives:[a.l,d.a,d.d,d.g,S.b,d.f,d.c,d.b,h.a,a.k,I.a,ee],styles:[""],changeDetection:0}),t})(),canActivate:[r("auXs").a]}];let be=(()=>{class t{}return t.\u0275mod=b.Kb({type:t}),t.\u0275inj=b.Jb({factory:function(e){return new(e||t)},imports:[[i.e.forChild(oe)],i.e]}),t})();var ce=r("B+Mi");let pe=(()=>{class t{}return t.\u0275mod=b.Kb({type:t}),t.\u0275inj=b.Jb({factory:function(e){return new(e||t)},imports:[[a.c,i.e,be,ce.a,g.g,g.o]]}),t})()},gkM4:function(t,e,r){"use strict";r.d(e,"a",(function(){return s}));var a=r("QRvi"),i=r("fXoL"),n=r("tyNb");let s=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,r){t.next(null),e.next({Working:!1,Error:r,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,r){t.next(null),e.next({Working:!1,Error:r,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,r,i,n){if(i===a.a.Get&&t.next(r),i===a.a.Put&&(t.getValue()[0]=r),i===a.a.Post&&t.getValue().push(r),i===a.a.Delete){const e=t.getValue().indexOf(n);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,r,i,n){i===a.a.Get&&t.next(r),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(i.Wb(n.b))},t.\u0275prov=i.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);