!function(){function e(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function t(e,t){for(var r=0;r<t.length;r++){var a=t[r];a.enumerable=a.enumerable||!1,a.configurable=!0,"value"in a&&(a.writable=!0),Object.defineProperty(e,a.key,a)}}function r(e,r,a){return r&&t(e.prototype,r),a&&t(e,a),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[61],{QRvi:function(e,t,r){"use strict";r.d(t,"a",(function(){return a}));var a=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},ZGES:function(t,a,n){"use strict";n.r(a),n.d(a,"MWQMAnalysisReportParameterModule",(function(){return Rt}));var i=n("ofXK"),o=n("tyNb");function m(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}function s(){var e=[];return"fr-CA"===$localize.locale?(e.push({EnumID:1,EnumText:"All - All - All"}),e.push({EnumID:2,EnumText:"Wet - All - All (fr)"}),e.push({EnumID:3,EnumText:"Dry - All - All (fr)"}),e.push({EnumID:4,EnumText:"Wet - Wet - All (fr)"}),e.push({EnumID:5,EnumText:"Dry - Dry - All (fr)"}),e.push({EnumID:6,EnumText:"Wet - Dry - All (fr)"}),e.push({EnumID:7,EnumText:"Dry - Wet - All (fr)"})):(e.push({EnumID:1,EnumText:"All - All - All"}),e.push({EnumID:2,EnumText:"Wet - All - All"}),e.push({EnumID:3,EnumText:"Dry - All - All"}),e.push({EnumID:4,EnumText:"Wet - Wet - All"}),e.push({EnumID:5,EnumText:"Dry - Dry - All"}),e.push({EnumID:6,EnumText:"Wet - Dry - All"}),e.push({EnumID:7,EnumText:"Dry - Wet - All"})),e.sort((function(e,t){return e.EnumText.localeCompare(t.EnumText)}))}function b(){var e=[];return"fr-CA"===$localize.locale?(e.push({EnumID:1,EnumText:"Rapport"}),e.push({EnumID:2,EnumText:"Excel"})):(e.push({EnumID:1,EnumText:"Report"}),e.push({EnumID:2,EnumText:"Excel"})),e.sort((function(e,t){return e.EnumText.localeCompare(t.EnumText)}))}var c,p=n("QRvi"),l=n("fXoL"),u=n("2Vo4"),y=n("LRne"),f=n("tk/3"),h=n("lJxs"),d=n("JIr8"),R=n("gkM4"),S=((c=function(){function t(r,a){e(this,t),this.httpClient=r,this.httpClientService=a,this.mwqmanalysisreportparameterTextModel$=new u.a({}),this.mwqmanalysisreportparameterListModel$=new u.a({}),this.mwqmanalysisreportparameterGetModel$=new u.a({}),this.mwqmanalysisreportparameterPutModel$=new u.a({}),this.mwqmanalysisreportparameterPostModel$=new u.a({}),this.mwqmanalysisreportparameterDeleteModel$=new u.a({}),m(this.mwqmanalysisreportparameterTextModel$),this.mwqmanalysisreportparameterTextModel$.next({Title:"Something2 for text"})}return r(t,[{key:"GetMWQMAnalysisReportParameterList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.mwqmanalysisreportparameterGetModel$),this.httpClient.get("/api/MWQMAnalysisReportParameter").pipe(Object(h.a)((function(t){e.httpClientService.DoSuccess(e.mwqmanalysisreportparameterListModel$,e.mwqmanalysisreportparameterGetModel$,t,p.a.Get,null)})),Object(d.a)((function(t){return Object(y.a)(t).pipe(Object(h.a)((function(t){e.httpClientService.DoCatchError(e.mwqmanalysisreportparameterListModel$,e.mwqmanalysisreportparameterGetModel$,t)})))})))}},{key:"PutMWQMAnalysisReportParameter",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.mwqmanalysisreportparameterPutModel$),this.httpClient.put("/api/MWQMAnalysisReportParameter",e,{headers:new f.d}).pipe(Object(h.a)((function(r){t.httpClientService.DoSuccess(t.mwqmanalysisreportparameterListModel$,t.mwqmanalysisreportparameterPutModel$,r,p.a.Put,e)})),Object(d.a)((function(e){return Object(y.a)(e).pipe(Object(h.a)((function(e){t.httpClientService.DoCatchError(t.mwqmanalysisreportparameterListModel$,t.mwqmanalysisreportparameterPutModel$,e)})))})))}},{key:"PostMWQMAnalysisReportParameter",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.mwqmanalysisreportparameterPostModel$),this.httpClient.post("/api/MWQMAnalysisReportParameter",e,{headers:new f.d}).pipe(Object(h.a)((function(r){t.httpClientService.DoSuccess(t.mwqmanalysisreportparameterListModel$,t.mwqmanalysisreportparameterPostModel$,r,p.a.Post,e)})),Object(d.a)((function(e){return Object(y.a)(e).pipe(Object(h.a)((function(e){t.httpClientService.DoCatchError(t.mwqmanalysisreportparameterListModel$,t.mwqmanalysisreportparameterPostModel$,e)})))})))}},{key:"DeleteMWQMAnalysisReportParameter",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.mwqmanalysisreportparameterDeleteModel$),this.httpClient.delete("/api/MWQMAnalysisReportParameter/"+e.MWQMAnalysisReportParameterID).pipe(Object(h.a)((function(r){t.httpClientService.DoSuccess(t.mwqmanalysisreportparameterListModel$,t.mwqmanalysisreportparameterDeleteModel$,r,p.a.Delete,e)})),Object(d.a)((function(e){return Object(y.a)(e).pipe(Object(h.a)((function(e){t.httpClientService.DoCatchError(t.mwqmanalysisreportparameterListModel$,t.mwqmanalysisreportparameterDeleteModel$,e)})))})))}}]),t}()).\u0275fac=function(e){return new(e||c)(l.Wb(f.b),l.Wb(R.a))},c.\u0275prov=l.Ib({token:c,factory:c.\u0275fac,providedIn:"root"}),c),I=n("Wp6s"),g=n("bTqV"),x=n("bv9b"),D=n("NFeN"),q=n("3Pt+"),v=n("kmnG"),w=n("qFsG"),M=n("d3UM"),N=n("FKr1");function B(e,t){1&e&&l.Nb(0,"mat-progress-bar",31)}function A(e,t){1&e&&l.Nb(0,"mat-progress-bar",31)}function T(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function E(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,T,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.required)}}function C(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function L(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,C,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.required)}}function P(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function W(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"MinLength - 5"),l.Nb(2,"br"),l.Rb())}function $(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 250"),l.Nb(2,"br"),l.Rb())}function F(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,P,3,0,"span",4),l.xc(6,W,3,0,"span",4),l.xc(7,$,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.minlength),l.Bb(1),l.hc("ngIf",r.maxlength)}}function k(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1980"),l.Nb(2,"br"),l.Rb())}function O(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 2050"),l.Nb(2,"br"),l.Rb())}function Q(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,k,3,0,"span",4),l.xc(6,O,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,3,r)),l.Bb(3),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function j(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function V(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,j,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.required)}}function G(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function z(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,G,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.required)}}function U(e,t){if(1&e&&(l.Sb(0,"mat-option",32),l.yc(1),l.Rb()),2&e){var r=t.$implicit;l.hc("value",r.EnumID),l.Bb(1),l.Ac(" ",r.EnumText," ")}}function Y(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function H(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,Y,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.required)}}function _(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function J(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function K(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 1000"),l.Nb(2,"br"),l.Rb())}function X(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,_,3,0,"span",4),l.xc(6,J,3,0,"span",4),l.xc(7,K,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function Z(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function ee(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,Z,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.required)}}function te(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function re(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function ae(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 20"),l.Nb(2,"br"),l.Rb())}function ne(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,te,3,0,"span",4),l.xc(6,re,3,0,"span",4),l.xc(7,ae,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function ie(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function oe(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 0"),l.Nb(2,"br"),l.Rb())}function me(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 5"),l.Nb(2,"br"),l.Rb())}function se(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,ie,3,0,"span",4),l.xc(6,oe,3,0,"span",4),l.xc(7,me,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function be(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function ce(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 2"),l.Nb(2,"br"),l.Rb())}function pe(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 7"),l.Nb(2,"br"),l.Rb())}function le(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,be,3,0,"span",4),l.xc(6,ce,3,0,"span",4),l.xc(7,pe,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function ue(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function ye(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function fe(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 100"),l.Nb(2,"br"),l.Rb())}function he(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,ue,3,0,"span",4),l.xc(6,ye,3,0,"span",4),l.xc(7,fe,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function de(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function Re(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function Se(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 100"),l.Nb(2,"br"),l.Rb())}function Ie(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,de,3,0,"span",4),l.xc(6,Re,3,0,"span",4),l.xc(7,Se,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function ge(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function xe(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function De(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 100"),l.Nb(2,"br"),l.Rb())}function qe(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,ge,3,0,"span",4),l.xc(6,xe,3,0,"span",4),l.xc(7,De,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function ve(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function we(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function Me(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 100"),l.Nb(2,"br"),l.Rb())}function Ne(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,ve,3,0,"span",4),l.xc(6,we,3,0,"span",4),l.xc(7,Me,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function Be(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function Ae(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function Te(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 100"),l.Nb(2,"br"),l.Rb())}function Ee(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,Be,3,0,"span",4),l.xc(6,Ae,3,0,"span",4),l.xc(7,Te,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function Ce(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function Le(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function Pe(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 100"),l.Nb(2,"br"),l.Rb())}function We(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,Ce,3,0,"span",4),l.xc(6,Le,3,0,"span",4),l.xc(7,Pe,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function $e(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function Fe(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function ke(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 100"),l.Nb(2,"br"),l.Rb())}function Oe(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,$e,3,0,"span",4),l.xc(6,Fe,3,0,"span",4),l.xc(7,ke,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function Qe(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function je(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Min - 1"),l.Nb(2,"br"),l.Rb())}function Ve(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Max - 100"),l.Nb(2,"br"),l.Rb())}function Ge(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,Qe,3,0,"span",4),l.xc(6,je,3,0,"span",4),l.xc(7,Ve,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,4,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.min),l.Bb(1),l.hc("ngIf",r.min)}}function ze(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function Ue(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 250"),l.Nb(2,"br"),l.Rb())}function Ye(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,ze,3,0,"span",4),l.xc(6,Ue,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,3,r)),l.Bb(3),l.hc("ngIf",r.required),l.Bb(1),l.hc("ngIf",r.maxlength)}}function He(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 20"),l.Nb(2,"br"),l.Rb())}function _e(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,He,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.maxlength)}}function Je(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,1,r))}}function Ke(e,t){if(1&e&&(l.Sb(0,"mat-option",32),l.yc(1),l.Rb()),2&e){var r=t.$implicit;l.hc("value",r.EnumID),l.Bb(1),l.Ac(" ",r.EnumText," ")}}function Xe(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function Ze(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,Xe,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.required)}}function et(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function tt(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,et,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.required)}}function rt(e,t){1&e&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function at(e,t){if(1&e&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,rt,3,0,"span",4),l.Rb()),2&e){var r=t.$implicit;l.Bb(2),l.zc(l.ec(3,2,r)),l.Bb(3),l.hc("ngIf",r.required)}}var nt,it=((nt=function(){function t(r,a){e(this,t),this.mwqmanalysisreportparameterService=r,this.fb=a,this.mwqmanalysisreportparameter=null,this.httpClientCommand=p.a.Put}return r(t,[{key:"GetPut",value:function(){return this.httpClientCommand==p.a.Put}},{key:"PutMWQMAnalysisReportParameter",value:function(e){this.sub=this.mwqmanalysisreportparameterService.PutMWQMAnalysisReportParameter(e).subscribe()}},{key:"PostMWQMAnalysisReportParameter",value:function(e){this.sub=this.mwqmanalysisreportparameterService.PostMWQMAnalysisReportParameter(e).subscribe()}},{key:"ngOnInit",value:function(){this.analysisCalculationTypeList=s(),this.commandList=b(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.mwqmanalysisreportparameter){var t=this.fb.group({MWQMAnalysisReportParameterID:[{value:e===p.a.Post?0:this.mwqmanalysisreportparameter.MWQMAnalysisReportParameterID,disabled:!1},[q.p.required]],SubsectorTVItemID:[{value:this.mwqmanalysisreportparameter.SubsectorTVItemID,disabled:!1},[q.p.required]],AnalysisName:[{value:this.mwqmanalysisreportparameter.AnalysisName,disabled:!1},[q.p.required,q.p.minLength(5),q.p.maxLength(250)]],AnalysisReportYear:[{value:this.mwqmanalysisreportparameter.AnalysisReportYear,disabled:!1},[q.p.min(1980),q.p.max(2050)]],StartDate:[{value:this.mwqmanalysisreportparameter.StartDate,disabled:!1},[q.p.required]],EndDate:[{value:this.mwqmanalysisreportparameter.EndDate,disabled:!1},[q.p.required]],AnalysisCalculationType:[{value:this.mwqmanalysisreportparameter.AnalysisCalculationType,disabled:!1},[q.p.required]],NumberOfRuns:[{value:this.mwqmanalysisreportparameter.NumberOfRuns,disabled:!1},[q.p.required,q.p.min(1),q.p.max(1e3)]],FullYear:[{value:this.mwqmanalysisreportparameter.FullYear,disabled:!1},[q.p.required]],SalinityHighlightDeviationFromAverage:[{value:this.mwqmanalysisreportparameter.SalinityHighlightDeviationFromAverage,disabled:!1},[q.p.required,q.p.min(1),q.p.max(20)]],ShortRangeNumberOfDays:[{value:this.mwqmanalysisreportparameter.ShortRangeNumberOfDays,disabled:!1},[q.p.required,q.p.min(0),q.p.max(5)]],MidRangeNumberOfDays:[{value:this.mwqmanalysisreportparameter.MidRangeNumberOfDays,disabled:!1},[q.p.required,q.p.min(2),q.p.max(7)]],DryLimit24h:[{value:this.mwqmanalysisreportparameter.DryLimit24h,disabled:!1},[q.p.required,q.p.min(1),q.p.max(100)]],DryLimit48h:[{value:this.mwqmanalysisreportparameter.DryLimit48h,disabled:!1},[q.p.required,q.p.min(1),q.p.max(100)]],DryLimit72h:[{value:this.mwqmanalysisreportparameter.DryLimit72h,disabled:!1},[q.p.required,q.p.min(1),q.p.max(100)]],DryLimit96h:[{value:this.mwqmanalysisreportparameter.DryLimit96h,disabled:!1},[q.p.required,q.p.min(1),q.p.max(100)]],WetLimit24h:[{value:this.mwqmanalysisreportparameter.WetLimit24h,disabled:!1},[q.p.required,q.p.min(1),q.p.max(100)]],WetLimit48h:[{value:this.mwqmanalysisreportparameter.WetLimit48h,disabled:!1},[q.p.required,q.p.min(1),q.p.max(100)]],WetLimit72h:[{value:this.mwqmanalysisreportparameter.WetLimit72h,disabled:!1},[q.p.required,q.p.min(1),q.p.max(100)]],WetLimit96h:[{value:this.mwqmanalysisreportparameter.WetLimit96h,disabled:!1},[q.p.required,q.p.min(1),q.p.max(100)]],RunsToOmit:[{value:this.mwqmanalysisreportparameter.RunsToOmit,disabled:!1},[q.p.required,q.p.maxLength(250)]],ShowDataTypes:[{value:this.mwqmanalysisreportparameter.ShowDataTypes,disabled:!1},[q.p.maxLength(20)]],ExcelTVFileTVItemID:[{value:this.mwqmanalysisreportparameter.ExcelTVFileTVItemID,disabled:!1}],Command:[{value:this.mwqmanalysisreportparameter.Command,disabled:!1},[q.p.required]],LastUpdateDate_UTC:[{value:this.mwqmanalysisreportparameter.LastUpdateDate_UTC,disabled:!1},[q.p.required]],LastUpdateContactTVItemID:[{value:this.mwqmanalysisreportparameter.LastUpdateContactTVItemID,disabled:!1},[q.p.required]]});this.mwqmanalysisreportparameterFormEdit=t}}}]),t}()).\u0275fac=function(e){return new(e||nt)(l.Mb(S),l.Mb(q.d))},nt.\u0275cmp=l.Gb({type:nt,selectors:[["app-mwqmanalysisreportparameter-edit"]],inputs:{mwqmanalysisreportparameter:"mwqmanalysisreportparameter",httpClientCommand:"httpClientCommand"},decls:147,vars:32,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","MWQMAnalysisReportParameterID"],[4,"ngIf"],["matInput","","type","number","formControlName","SubsectorTVItemID"],["matInput","","type","text","formControlName","AnalysisName"],["matInput","","type","number","formControlName","AnalysisReportYear"],["matInput","","type","text","formControlName","StartDate"],["matInput","","type","text","formControlName","EndDate"],["formControlName","AnalysisCalculationType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","number","formControlName","NumberOfRuns"],["matInput","","type","text","formControlName","FullYear"],["matInput","","type","number","formControlName","SalinityHighlightDeviationFromAverage"],["matInput","","type","number","formControlName","ShortRangeNumberOfDays"],["matInput","","type","number","formControlName","MidRangeNumberOfDays"],["matInput","","type","number","formControlName","DryLimit24h"],["matInput","","type","number","formControlName","DryLimit48h"],["matInput","","type","number","formControlName","DryLimit72h"],["matInput","","type","number","formControlName","DryLimit96h"],["matInput","","type","number","formControlName","WetLimit24h"],["matInput","","type","number","formControlName","WetLimit48h"],["matInput","","type","number","formControlName","WetLimit72h"],["matInput","","type","number","formControlName","WetLimit96h"],["matInput","","type","text","formControlName","RunsToOmit"],["matInput","","type","text","formControlName","ShowDataTypes"],["matInput","","type","number","formControlName","ExcelTVFileTVItemID"],["formControlName","Command"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(l.Sb(0,"form",0),l.Yb("ngSubmit",(function(){return t.GetPut()?t.PutMWQMAnalysisReportParameter(t.mwqmanalysisreportparameterFormEdit.value):t.PostMWQMAnalysisReportParameter(t.mwqmanalysisreportparameterFormEdit.value)})),l.Sb(1,"h3"),l.yc(2," MWQMAnalysisReportParameter "),l.Sb(3,"button",1),l.Sb(4,"span"),l.yc(5),l.Rb(),l.Rb(),l.xc(6,B,1,0,"mat-progress-bar",2),l.xc(7,A,1,0,"mat-progress-bar",2),l.Rb(),l.Sb(8,"p"),l.Sb(9,"mat-form-field"),l.Sb(10,"mat-label"),l.yc(11,"MWQMAnalysisReportParameterID"),l.Rb(),l.Nb(12,"input",3),l.xc(13,E,6,4,"mat-error",4),l.Rb(),l.Sb(14,"mat-form-field"),l.Sb(15,"mat-label"),l.yc(16,"SubsectorTVItemID"),l.Rb(),l.Nb(17,"input",5),l.xc(18,L,6,4,"mat-error",4),l.Rb(),l.Sb(19,"mat-form-field"),l.Sb(20,"mat-label"),l.yc(21,"AnalysisName"),l.Rb(),l.Nb(22,"input",6),l.xc(23,F,8,6,"mat-error",4),l.Rb(),l.Sb(24,"mat-form-field"),l.Sb(25,"mat-label"),l.yc(26,"AnalysisReportYear"),l.Rb(),l.Nb(27,"input",7),l.xc(28,Q,7,5,"mat-error",4),l.Rb(),l.Rb(),l.Sb(29,"p"),l.Sb(30,"mat-form-field"),l.Sb(31,"mat-label"),l.yc(32,"StartDate"),l.Rb(),l.Nb(33,"input",8),l.xc(34,V,6,4,"mat-error",4),l.Rb(),l.Sb(35,"mat-form-field"),l.Sb(36,"mat-label"),l.yc(37,"EndDate"),l.Rb(),l.Nb(38,"input",9),l.xc(39,z,6,4,"mat-error",4),l.Rb(),l.Sb(40,"mat-form-field"),l.Sb(41,"mat-label"),l.yc(42,"AnalysisCalculationType"),l.Rb(),l.Sb(43,"mat-select",10),l.xc(44,U,2,2,"mat-option",11),l.Rb(),l.xc(45,H,6,4,"mat-error",4),l.Rb(),l.Sb(46,"mat-form-field"),l.Sb(47,"mat-label"),l.yc(48,"NumberOfRuns"),l.Rb(),l.Nb(49,"input",12),l.xc(50,X,8,6,"mat-error",4),l.Rb(),l.Rb(),l.Sb(51,"p"),l.Sb(52,"mat-form-field"),l.Sb(53,"mat-label"),l.yc(54,"FullYear"),l.Rb(),l.Nb(55,"input",13),l.xc(56,ee,6,4,"mat-error",4),l.Rb(),l.Sb(57,"mat-form-field"),l.Sb(58,"mat-label"),l.yc(59,"SalinityHighlightDeviationFromAverage"),l.Rb(),l.Nb(60,"input",14),l.xc(61,ne,8,6,"mat-error",4),l.Rb(),l.Sb(62,"mat-form-field"),l.Sb(63,"mat-label"),l.yc(64,"ShortRangeNumberOfDays"),l.Rb(),l.Nb(65,"input",15),l.xc(66,se,8,6,"mat-error",4),l.Rb(),l.Sb(67,"mat-form-field"),l.Sb(68,"mat-label"),l.yc(69,"MidRangeNumberOfDays"),l.Rb(),l.Nb(70,"input",16),l.xc(71,le,8,6,"mat-error",4),l.Rb(),l.Rb(),l.Sb(72,"p"),l.Sb(73,"mat-form-field"),l.Sb(74,"mat-label"),l.yc(75,"DryLimit24h"),l.Rb(),l.Nb(76,"input",17),l.xc(77,he,8,6,"mat-error",4),l.Rb(),l.Sb(78,"mat-form-field"),l.Sb(79,"mat-label"),l.yc(80,"DryLimit48h"),l.Rb(),l.Nb(81,"input",18),l.xc(82,Ie,8,6,"mat-error",4),l.Rb(),l.Sb(83,"mat-form-field"),l.Sb(84,"mat-label"),l.yc(85,"DryLimit72h"),l.Rb(),l.Nb(86,"input",19),l.xc(87,qe,8,6,"mat-error",4),l.Rb(),l.Sb(88,"mat-form-field"),l.Sb(89,"mat-label"),l.yc(90,"DryLimit96h"),l.Rb(),l.Nb(91,"input",20),l.xc(92,Ne,8,6,"mat-error",4),l.Rb(),l.Rb(),l.Sb(93,"p"),l.Sb(94,"mat-form-field"),l.Sb(95,"mat-label"),l.yc(96,"WetLimit24h"),l.Rb(),l.Nb(97,"input",21),l.xc(98,Ee,8,6,"mat-error",4),l.Rb(),l.Sb(99,"mat-form-field"),l.Sb(100,"mat-label"),l.yc(101,"WetLimit48h"),l.Rb(),l.Nb(102,"input",22),l.xc(103,We,8,6,"mat-error",4),l.Rb(),l.Sb(104,"mat-form-field"),l.Sb(105,"mat-label"),l.yc(106,"WetLimit72h"),l.Rb(),l.Nb(107,"input",23),l.xc(108,Oe,8,6,"mat-error",4),l.Rb(),l.Sb(109,"mat-form-field"),l.Sb(110,"mat-label"),l.yc(111,"WetLimit96h"),l.Rb(),l.Nb(112,"input",24),l.xc(113,Ge,8,6,"mat-error",4),l.Rb(),l.Rb(),l.Sb(114,"p"),l.Sb(115,"mat-form-field"),l.Sb(116,"mat-label"),l.yc(117,"RunsToOmit"),l.Rb(),l.Nb(118,"input",25),l.xc(119,Ye,7,5,"mat-error",4),l.Rb(),l.Sb(120,"mat-form-field"),l.Sb(121,"mat-label"),l.yc(122,"ShowDataTypes"),l.Rb(),l.Nb(123,"input",26),l.xc(124,_e,6,4,"mat-error",4),l.Rb(),l.Sb(125,"mat-form-field"),l.Sb(126,"mat-label"),l.yc(127,"ExcelTVFileTVItemID"),l.Rb(),l.Nb(128,"input",27),l.xc(129,Je,5,3,"mat-error",4),l.Rb(),l.Sb(130,"mat-form-field"),l.Sb(131,"mat-label"),l.yc(132,"Command"),l.Rb(),l.Sb(133,"mat-select",28),l.xc(134,Ke,2,2,"mat-option",11),l.Rb(),l.xc(135,Ze,6,4,"mat-error",4),l.Rb(),l.Rb(),l.Sb(136,"p"),l.Sb(137,"mat-form-field"),l.Sb(138,"mat-label"),l.yc(139,"LastUpdateDate_UTC"),l.Rb(),l.Nb(140,"input",29),l.xc(141,tt,6,4,"mat-error",4),l.Rb(),l.Sb(142,"mat-form-field"),l.Sb(143,"mat-label"),l.yc(144,"LastUpdateContactTVItemID"),l.Rb(),l.Nb(145,"input",30),l.xc(146,at,6,4,"mat-error",4),l.Rb(),l.Rb(),l.Rb()),2&e&&(l.hc("formGroup",t.mwqmanalysisreportparameterFormEdit),l.Bb(5),l.Ac("",t.GetPut()?"Put":"Post"," MWQMAnalysisReportParameter"),l.Bb(1),l.hc("ngIf",t.mwqmanalysisreportparameterService.mwqmanalysisreportparameterPutModel$.getValue().Working),l.Bb(1),l.hc("ngIf",t.mwqmanalysisreportparameterService.mwqmanalysisreportparameterPostModel$.getValue().Working),l.Bb(6),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.MWQMAnalysisReportParameterID.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.SubsectorTVItemID.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.AnalysisName.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.AnalysisReportYear.errors),l.Bb(6),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.StartDate.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.EndDate.errors),l.Bb(5),l.hc("ngForOf",t.analysisCalculationTypeList),l.Bb(1),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.AnalysisCalculationType.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.NumberOfRuns.errors),l.Bb(6),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.FullYear.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.SalinityHighlightDeviationFromAverage.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.ShortRangeNumberOfDays.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.MidRangeNumberOfDays.errors),l.Bb(6),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.DryLimit24h.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.DryLimit48h.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.DryLimit72h.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.DryLimit96h.errors),l.Bb(6),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.WetLimit24h.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.WetLimit48h.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.WetLimit72h.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.WetLimit96h.errors),l.Bb(6),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.RunsToOmit.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.ShowDataTypes.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.ExcelTVFileTVItemID.errors),l.Bb(5),l.hc("ngForOf",t.commandList),l.Bb(1),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.Command.errors),l.Bb(6),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.LastUpdateDate_UTC.errors),l.Bb(5),l.hc("ngIf",t.mwqmanalysisreportparameterFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[q.q,q.l,q.f,g.b,i.l,v.c,v.f,w.b,q.n,q.c,q.k,q.e,M.a,i.k,x.a,v.b,N.n],pipes:[i.f],styles:[""],changeDetection:0}),nt);function ot(e,t){1&e&&l.Nb(0,"mat-progress-bar",4)}function mt(e,t){1&e&&l.Nb(0,"mat-progress-bar",4)}function st(e,t){if(1&e&&(l.Sb(0,"p"),l.Nb(1,"app-mwqmanalysisreportparameter-edit",8),l.Rb()),2&e){var r=l.cc().$implicit,a=l.cc(2);l.Bb(1),l.hc("mwqmanalysisreportparameter",r)("httpClientCommand",a.GetPutEnum())}}function bt(e,t){if(1&e&&(l.Sb(0,"p"),l.Nb(1,"app-mwqmanalysisreportparameter-edit",8),l.Rb()),2&e){var r=l.cc().$implicit,a=l.cc(2);l.Bb(1),l.hc("mwqmanalysisreportparameter",r)("httpClientCommand",a.GetPostEnum())}}function ct(e,t){if(1&e){var r=l.Tb();l.Sb(0,"div"),l.Sb(1,"p"),l.Sb(2,"button",6),l.Yb("click",(function(){l.pc(r);var e=t.$implicit;return l.cc(2).DeleteMWQMAnalysisReportParameter(e)})),l.Sb(3,"span"),l.yc(4),l.Rb(),l.Sb(5,"mat-icon"),l.yc(6,"delete"),l.Rb(),l.Rb(),l.yc(7,"\xa0\xa0\xa0 "),l.Sb(8,"button",7),l.Yb("click",(function(){l.pc(r);var e=t.$implicit;return l.cc(2).ShowPut(e)})),l.Sb(9,"span"),l.yc(10,"Show Put"),l.Rb(),l.Rb(),l.yc(11,"\xa0\xa0 "),l.Sb(12,"button",7),l.Yb("click",(function(){l.pc(r);var e=t.$implicit;return l.cc(2).ShowPost(e)})),l.Sb(13,"span"),l.yc(14,"Show Post"),l.Rb(),l.Rb(),l.yc(15,"\xa0\xa0 "),l.xc(16,mt,1,0,"mat-progress-bar",0),l.Rb(),l.xc(17,st,2,2,"p",2),l.xc(18,bt,2,2,"p",2),l.Sb(19,"blockquote"),l.Sb(20,"p"),l.Sb(21,"span"),l.yc(22),l.Rb(),l.Sb(23,"span"),l.yc(24),l.Rb(),l.Sb(25,"span"),l.yc(26),l.Rb(),l.Sb(27,"span"),l.yc(28),l.Rb(),l.Rb(),l.Sb(29,"p"),l.Sb(30,"span"),l.yc(31),l.Rb(),l.Sb(32,"span"),l.yc(33),l.Rb(),l.Sb(34,"span"),l.yc(35),l.Rb(),l.Sb(36,"span"),l.yc(37),l.Rb(),l.Rb(),l.Sb(38,"p"),l.Sb(39,"span"),l.yc(40),l.Rb(),l.Sb(41,"span"),l.yc(42),l.Rb(),l.Sb(43,"span"),l.yc(44),l.Rb(),l.Sb(45,"span"),l.yc(46),l.Rb(),l.Rb(),l.Sb(47,"p"),l.Sb(48,"span"),l.yc(49),l.Rb(),l.Sb(50,"span"),l.yc(51),l.Rb(),l.Sb(52,"span"),l.yc(53),l.Rb(),l.Sb(54,"span"),l.yc(55),l.Rb(),l.Rb(),l.Sb(56,"p"),l.Sb(57,"span"),l.yc(58),l.Rb(),l.Sb(59,"span"),l.yc(60),l.Rb(),l.Sb(61,"span"),l.yc(62),l.Rb(),l.Sb(63,"span"),l.yc(64),l.Rb(),l.Rb(),l.Sb(65,"p"),l.Sb(66,"span"),l.yc(67),l.Rb(),l.Sb(68,"span"),l.yc(69),l.Rb(),l.Sb(70,"span"),l.yc(71),l.Rb(),l.Sb(72,"span"),l.yc(73),l.Rb(),l.Rb(),l.Sb(74,"p"),l.Sb(75,"span"),l.yc(76),l.Rb(),l.Sb(77,"span"),l.yc(78),l.Rb(),l.Rb(),l.Rb(),l.Rb()}if(2&e){var a=t.$implicit,n=l.cc(2);l.Bb(4),l.Ac("Delete MWQMAnalysisReportParameterID [",a.MWQMAnalysisReportParameterID,"]\xa0\xa0\xa0"),l.Bb(4),l.hc("color",n.GetPutButtonColor(a)),l.Bb(4),l.hc("color",n.GetPostButtonColor(a)),l.Bb(4),l.hc("ngIf",n.mwqmanalysisreportparameterService.mwqmanalysisreportparameterDeleteModel$.getValue().Working),l.Bb(1),l.hc("ngIf",n.IDToShow===a.MWQMAnalysisReportParameterID&&n.showType===n.GetPutEnum()),l.Bb(1),l.hc("ngIf",n.IDToShow===a.MWQMAnalysisReportParameterID&&n.showType===n.GetPostEnum()),l.Bb(4),l.Ac("MWQMAnalysisReportParameterID: [",a.MWQMAnalysisReportParameterID,"]"),l.Bb(2),l.Ac(" --- SubsectorTVItemID: [",a.SubsectorTVItemID,"]"),l.Bb(2),l.Ac(" --- AnalysisName: [",a.AnalysisName,"]"),l.Bb(2),l.Ac(" --- AnalysisReportYear: [",a.AnalysisReportYear,"]"),l.Bb(3),l.Ac("StartDate: [",a.StartDate,"]"),l.Bb(2),l.Ac(" --- EndDate: [",a.EndDate,"]"),l.Bb(2),l.Ac(" --- AnalysisCalculationType: [",n.GetAnalysisCalculationTypeEnumText(a.AnalysisCalculationType),"]"),l.Bb(2),l.Ac(" --- NumberOfRuns: [",a.NumberOfRuns,"]"),l.Bb(3),l.Ac("FullYear: [",a.FullYear,"]"),l.Bb(2),l.Ac(" --- SalinityHighlightDeviationFromAverage: [",a.SalinityHighlightDeviationFromAverage,"]"),l.Bb(2),l.Ac(" --- ShortRangeNumberOfDays: [",a.ShortRangeNumberOfDays,"]"),l.Bb(2),l.Ac(" --- MidRangeNumberOfDays: [",a.MidRangeNumberOfDays,"]"),l.Bb(3),l.Ac("DryLimit24h: [",a.DryLimit24h,"]"),l.Bb(2),l.Ac(" --- DryLimit48h: [",a.DryLimit48h,"]"),l.Bb(2),l.Ac(" --- DryLimit72h: [",a.DryLimit72h,"]"),l.Bb(2),l.Ac(" --- DryLimit96h: [",a.DryLimit96h,"]"),l.Bb(3),l.Ac("WetLimit24h: [",a.WetLimit24h,"]"),l.Bb(2),l.Ac(" --- WetLimit48h: [",a.WetLimit48h,"]"),l.Bb(2),l.Ac(" --- WetLimit72h: [",a.WetLimit72h,"]"),l.Bb(2),l.Ac(" --- WetLimit96h: [",a.WetLimit96h,"]"),l.Bb(3),l.Ac("RunsToOmit: [",a.RunsToOmit,"]"),l.Bb(2),l.Ac(" --- ShowDataTypes: [",a.ShowDataTypes,"]"),l.Bb(2),l.Ac(" --- ExcelTVFileTVItemID: [",a.ExcelTVFileTVItemID,"]"),l.Bb(2),l.Ac(" --- Command: [",n.GetAnalysisReportExportCommandEnumText(a.Command),"]"),l.Bb(3),l.Ac("LastUpdateDate_UTC: [",a.LastUpdateDate_UTC,"]"),l.Bb(2),l.Ac(" --- LastUpdateContactTVItemID: [",a.LastUpdateContactTVItemID,"]")}}function pt(e,t){if(1&e&&(l.Sb(0,"div"),l.xc(1,ct,79,32,"div",5),l.Rb()),2&e){var r=l.cc();l.Bb(1),l.hc("ngForOf",r.mwqmanalysisreportparameterService.mwqmanalysisreportparameterListModel$.getValue())}}var lt,ut,yt,ft=[{path:"",component:(lt=function(){function t(r,a,n){e(this,t),this.mwqmanalysisreportparameterService=r,this.router=a,this.httpClientService=n,this.showType=null,n.oldURL=a.url}return r(t,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.MWQMAnalysisReportParameterID&&this.showType===p.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.MWQMAnalysisReportParameterID&&this.showType===p.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.MWQMAnalysisReportParameterID&&this.showType===p.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.MWQMAnalysisReportParameterID,this.showType=p.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.MWQMAnalysisReportParameterID&&this.showType===p.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.MWQMAnalysisReportParameterID,this.showType=p.a.Post)}},{key:"GetPutEnum",value:function(){return p.a.Put}},{key:"GetPostEnum",value:function(){return p.a.Post}},{key:"GetMWQMAnalysisReportParameterList",value:function(){this.sub=this.mwqmanalysisreportparameterService.GetMWQMAnalysisReportParameterList().subscribe()}},{key:"DeleteMWQMAnalysisReportParameter",value:function(e){this.sub=this.mwqmanalysisreportparameterService.DeleteMWQMAnalysisReportParameter(e).subscribe()}},{key:"GetAnalysisCalculationTypeEnumText",value:function(e){return function(e){var t;return s().forEach((function(r){if(r.EnumID==e)return t=r.EnumText,!1})),t}(e)}},{key:"GetAnalysisReportExportCommandEnumText",value:function(e){return function(e){var t;return b().forEach((function(r){if(r.EnumID==e)return t=r.EnumText,!1})),t}(e)}},{key:"ngOnInit",value:function(){m(this.mwqmanalysisreportparameterService.mwqmanalysisreportparameterTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),t}(),lt.\u0275fac=function(e){return new(e||lt)(l.Mb(S),l.Mb(o.b),l.Mb(R.a))},lt.\u0275cmp=l.Gb({type:lt,selectors:[["app-mwqmanalysisreportparameter"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"mwqmanalysisreportparameter","httpClientCommand"]],template:function(e,t){var r,a;1&e&&(l.xc(0,ot,1,0,"mat-progress-bar",0),l.Sb(1,"mat-card"),l.Sb(2,"mat-card-header"),l.Sb(3,"mat-card-title"),l.yc(4," MWQMAnalysisReportParameter works! "),l.Sb(5,"button",1),l.Yb("click",(function(){return t.GetMWQMAnalysisReportParameterList()})),l.Sb(6,"span"),l.yc(7,"Get MWQMAnalysisReportParameter"),l.Rb(),l.Rb(),l.Rb(),l.Sb(8,"mat-card-subtitle"),l.yc(9),l.Rb(),l.Rb(),l.Sb(10,"mat-card-content"),l.xc(11,pt,2,1,"div",2),l.Rb(),l.Sb(12,"mat-card-actions"),l.Sb(13,"button",3),l.yc(14,"Allo"),l.Rb(),l.Rb(),l.Rb()),2&e&&(l.hc("ngIf",null==(r=t.mwqmanalysisreportparameterService.mwqmanalysisreportparameterGetModel$.getValue())?null:r.Working),l.Bb(9),l.zc(t.mwqmanalysisreportparameterService.mwqmanalysisreportparameterTextModel$.getValue().Title),l.Bb(2),l.hc("ngIf",null==(a=t.mwqmanalysisreportparameterService.mwqmanalysisreportparameterListModel$.getValue())?null:a.length))},directives:[i.l,I.a,I.d,I.g,g.b,I.f,I.c,I.b,x.a,i.k,D.a,it],styles:[""],changeDetection:0}),lt),canActivate:[n("auXs").a]}],ht=((ut=function t(){e(this,t)}).\u0275mod=l.Kb({type:ut}),ut.\u0275inj=l.Jb({factory:function(e){return new(e||ut)},imports:[[o.e.forChild(ft)],o.e]}),ut),dt=n("B+Mi"),Rt=((yt=function t(){e(this,t)}).\u0275mod=l.Kb({type:yt}),yt.\u0275inj=l.Jb({factory:function(e){return new(e||yt)},imports:[[i.c,o.e,ht,dt.a,q.g,q.o]]}),yt)},gkM4:function(t,a,n){"use strict";n.d(a,"a",(function(){return s}));var i=n("QRvi"),o=n("fXoL"),m=n("tyNb"),s=function(){var t=function(){function t(r){e(this,t),this.router=r,this.oldURL=r.url}return r(t,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,t,r){e.next(null),t.next({Working:!1,Error:r,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(e,t,r){e.next(null),t.next({Working:!1,Error:r,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,t,r,a,n){if(a===i.a.Get&&e.next(r),a===i.a.Put&&(e.getValue()[0]=r),a===i.a.Post&&e.getValue().push(r),a===i.a.Delete){var o=e.getValue().indexOf(n);e.getValue().splice(o,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(e,t,r,a,n){a===i.a.Get&&e.next(r),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),t}();return t.\u0275fac=function(e){return new(e||t)(o.Wb(m.b))},t.\u0275prov=o.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t}()}}])}();