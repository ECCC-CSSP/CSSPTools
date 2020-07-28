function _classCallCheck(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function _defineProperties(e,t){for(var o=0;o<t.length;o++){var n=t[o];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(e,n.key,n)}}function _createClass(e,t,o){return t&&_defineProperties(e.prototype,t),o&&_defineProperties(e,o),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[39],{"3dNl":function(e,t,o){"use strict";o.r(t),o.d(t,"BoxModelResultModule",(function(){return qe}));var n=o("ofXK"),r=o("tyNb");function i(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}function b(){var e=[];return"fr-CA"===$localize.locale?(e.push({EnumID:1,EnumText:"Dilution"}),e.push({EnumID:2,EnumText:"NoDecayUntreated (fr)"}),e.push({EnumID:3,EnumText:"NoDecayPreDisinfection (fr)"}),e.push({EnumID:4,EnumText:"DecayUntreated (fr)"}),e.push({EnumID:5,EnumText:"DecayPreDisinfection (fr)"})):(e.push({EnumID:1,EnumText:"Dilution"}),e.push({EnumID:2,EnumText:"NoDecayUntreated"}),e.push({EnumID:3,EnumText:"NoDecayPreDisinfection"}),e.push({EnumID:4,EnumText:"DecayUntreated"}),e.push({EnumID:5,EnumText:"DecayPreDisinfection"})),e.sort((function(e,t){return e.EnumText.localeCompare(t.EnumText)}))}var l,c=o("QRvi"),a=o("fXoL"),u=o("2Vo4"),s=o("LRne"),m=o("tk/3"),d=o("lJxs"),p=o("JIr8"),f=o("gkM4"),x=((l=function(){function e(t,o){_classCallCheck(this,e),this.httpClient=t,this.httpClientService=o,this.boxmodelresultTextModel$=new u.a({}),this.boxmodelresultListModel$=new u.a({}),this.boxmodelresultGetModel$=new u.a({}),this.boxmodelresultPutModel$=new u.a({}),this.boxmodelresultPostModel$=new u.a({}),this.boxmodelresultDeleteModel$=new u.a({}),i(this.boxmodelresultTextModel$),this.boxmodelresultTextModel$.next({Title:"Something2 for text"})}return _createClass(e,[{key:"GetBoxModelResultList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.boxmodelresultGetModel$),this.httpClient.get("/api/BoxModelResult").pipe(Object(d.a)((function(t){e.httpClientService.DoSuccess(e.boxmodelresultListModel$,e.boxmodelresultGetModel$,t,c.a.Get,null)})),Object(p.a)((function(t){return Object(s.a)(t).pipe(Object(d.a)((function(t){e.httpClientService.DoCatchError(e.boxmodelresultListModel$,e.boxmodelresultGetModel$,t)})))})))}},{key:"PutBoxModelResult",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.boxmodelresultPutModel$),this.httpClient.put("/api/BoxModelResult",e,{headers:new m.d}).pipe(Object(d.a)((function(o){t.httpClientService.DoSuccess(t.boxmodelresultListModel$,t.boxmodelresultPutModel$,o,c.a.Put,e)})),Object(p.a)((function(e){return Object(s.a)(e).pipe(Object(d.a)((function(e){t.httpClientService.DoCatchError(t.boxmodelresultListModel$,t.boxmodelresultPutModel$,e)})))})))}},{key:"PostBoxModelResult",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.boxmodelresultPostModel$),this.httpClient.post("/api/BoxModelResult",e,{headers:new m.d}).pipe(Object(d.a)((function(o){t.httpClientService.DoSuccess(t.boxmodelresultListModel$,t.boxmodelresultPostModel$,o,c.a.Post,e)})),Object(p.a)((function(e){return Object(s.a)(e).pipe(Object(d.a)((function(e){t.httpClientService.DoCatchError(t.boxmodelresultListModel$,t.boxmodelresultPostModel$,e)})))})))}},{key:"DeleteBoxModelResult",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.boxmodelresultDeleteModel$),this.httpClient.delete("/api/BoxModelResult/"+e.BoxModelResultID).pipe(Object(d.a)((function(o){t.httpClientService.DoSuccess(t.boxmodelresultListModel$,t.boxmodelresultDeleteModel$,o,c.a.Delete,e)})),Object(p.a)((function(e){return Object(s.a)(e).pipe(Object(d.a)((function(e){t.httpClientService.DoCatchError(t.boxmodelresultListModel$,t.boxmodelresultDeleteModel$,e)})))})))}}]),e}()).\u0275fac=function(e){return new(e||l)(a.Xb(m.b),a.Xb(f.a))},l.\u0275prov=a.Jb({token:l,factory:l.\u0275fac,providedIn:"root"}),l),S=o("Wp6s"),T=o("bTqV"),h=o("bv9b"),y=o("NFeN"),g=o("3Pt+"),B=o("kmnG"),I=o("qFsG"),v=o("d3UM"),L=o("FKr1");function C(e,t){1&e&&a.Ob(0,"mat-progress-bar",23)}function M(e,t){1&e&&a.Ob(0,"mat-progress-bar",23)}function D(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function j(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,D,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,2,o)),a.Bb(3),a.jc("ngIf",o.required)}}function O(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function R(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,O,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,2,o)),a.Bb(3),a.jc("ngIf",o.required)}}function E(e,t){if(1&e&&(a.Tb(0,"mat-option",24),a.yc(1),a.Sb()),2&e){var o=t.$implicit;a.jc("value",o.EnumID),a.Bb(1),a.Ac(" ",o.EnumText," ")}}function _(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function k(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,_,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,2,o)),a.Bb(3),a.jc("ngIf",o.required)}}function P(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function $(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - 0"),a.Ob(2,"br"),a.Sb())}function w(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,P,3,0,"span",4),a.xc(6,$,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,3,o)),a.Bb(3),a.jc("ngIf",o.required),a.Bb(1),a.jc("ngIf",o.min)}}function F(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function q(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - 0"),a.Ob(2,"br"),a.Sb())}function A(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,F,3,0,"span",4),a.xc(6,q,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,3,o)),a.Bb(3),a.jc("ngIf",o.required),a.Bb(1),a.jc("ngIf",o.min)}}function G(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function N(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - 0"),a.Ob(2,"br"),a.Sb())}function U(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Max - 100000"),a.Ob(2,"br"),a.Sb())}function V(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,G,3,0,"span",4),a.xc(6,N,3,0,"span",4),a.xc(7,U,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,4,o)),a.Bb(3),a.jc("ngIf",o.required),a.Bb(1),a.jc("ngIf",o.min),a.Bb(1),a.jc("ngIf",o.min)}}function W(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - 0"),a.Ob(2,"br"),a.Sb())}function z(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Max - 360"),a.Ob(2,"br"),a.Sb())}function H(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,W,3,0,"span",4),a.xc(6,z,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,3,o)),a.Bb(3),a.jc("ngIf",o.min),a.Bb(1),a.jc("ngIf",o.min)}}function X(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - -90"),a.Ob(2,"br"),a.Sb())}function J(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Max - 90"),a.Ob(2,"br"),a.Sb())}function K(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,X,3,0,"span",4),a.xc(6,J,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,3,o)),a.Bb(3),a.jc("ngIf",o.min),a.Bb(1),a.jc("ngIf",o.min)}}function Q(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - -180"),a.Ob(2,"br"),a.Sb())}function Y(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Max - 180"),a.Ob(2,"br"),a.Sb())}function Z(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,Q,3,0,"span",4),a.xc(6,Y,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,3,o)),a.Bb(3),a.jc("ngIf",o.min),a.Bb(1),a.jc("ngIf",o.min)}}function ee(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function te(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,ee,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,2,o)),a.Bb(3),a.jc("ngIf",o.required)}}function oe(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function ne(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,oe,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,2,o)),a.Bb(3),a.jc("ngIf",o.required)}}function re(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function ie(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - 0"),a.Ob(2,"br"),a.Sb())}function be(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Max - 100000"),a.Ob(2,"br"),a.Sb())}function le(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,re,3,0,"span",4),a.xc(6,ie,3,0,"span",4),a.xc(7,be,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,4,o)),a.Bb(3),a.jc("ngIf",o.required),a.Bb(1),a.jc("ngIf",o.min),a.Bb(1),a.jc("ngIf",o.min)}}function ce(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function ae(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - 0"),a.Ob(2,"br"),a.Sb())}function ue(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Max - 100000"),a.Ob(2,"br"),a.Sb())}function se(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,ce,3,0,"span",4),a.xc(6,ae,3,0,"span",4),a.xc(7,ue,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,4,o)),a.Bb(3),a.jc("ngIf",o.required),a.Bb(1),a.jc("ngIf",o.min),a.Bb(1),a.jc("ngIf",o.min)}}function me(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - 0"),a.Ob(2,"br"),a.Sb())}function de(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Max - 360"),a.Ob(2,"br"),a.Sb())}function pe(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,me,3,0,"span",4),a.xc(6,de,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,3,o)),a.Bb(3),a.jc("ngIf",o.min),a.Bb(1),a.jc("ngIf",o.min)}}function fe(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - -90"),a.Ob(2,"br"),a.Sb())}function xe(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Max - 90"),a.Ob(2,"br"),a.Sb())}function Se(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,fe,3,0,"span",4),a.xc(6,xe,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,3,o)),a.Bb(3),a.jc("ngIf",o.min),a.Bb(1),a.jc("ngIf",o.min)}}function Te(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Min - -180"),a.Ob(2,"br"),a.Sb())}function he(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Max - 180"),a.Ob(2,"br"),a.Sb())}function ye(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,Te,3,0,"span",4),a.xc(6,he,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,3,o)),a.Bb(3),a.jc("ngIf",o.min),a.Bb(1),a.jc("ngIf",o.min)}}function ge(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function Be(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,ge,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,2,o)),a.Bb(3),a.jc("ngIf",o.required)}}function Ie(e,t){1&e&&(a.Tb(0,"span"),a.yc(1,"Is Required"),a.Ob(2,"br"),a.Sb())}function ve(e,t){if(1&e&&(a.Tb(0,"mat-error"),a.Tb(1,"span"),a.yc(2),a.fc(3,"json"),a.Ob(4,"br"),a.Sb(),a.xc(5,Ie,3,0,"span",4),a.Sb()),2&e){var o=t.$implicit;a.Bb(2),a.zc(a.gc(3,2,o)),a.Bb(3),a.jc("ngIf",o.required)}}var Le,Ce=((Le=function(){function e(t,o){_classCallCheck(this,e),this.boxmodelresultService=t,this.fb=o,this.boxmodelresult=null,this.httpClientCommand=c.a.Put}return _createClass(e,[{key:"GetPut",value:function(){return this.httpClientCommand==c.a.Put}},{key:"PutBoxModelResult",value:function(e){this.sub=this.boxmodelresultService.PutBoxModelResult(e).subscribe()}},{key:"PostBoxModelResult",value:function(e){this.sub=this.boxmodelresultService.PostBoxModelResult(e).subscribe()}},{key:"ngOnInit",value:function(){this.boxModelResultTypeList=b(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.boxmodelresult){var t=this.fb.group({BoxModelResultID:[{value:e===c.a.Post?0:this.boxmodelresult.BoxModelResultID,disabled:!1},[g.p.required]],BoxModelID:[{value:this.boxmodelresult.BoxModelID,disabled:!1},[g.p.required]],BoxModelResultType:[{value:this.boxmodelresult.BoxModelResultType,disabled:!1},[g.p.required]],Volume_m3:[{value:this.boxmodelresult.Volume_m3,disabled:!1},[g.p.required,g.p.min(0)]],Surface_m2:[{value:this.boxmodelresult.Surface_m2,disabled:!1},[g.p.required,g.p.min(0)]],Radius_m:[{value:this.boxmodelresult.Radius_m,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e5)]],LeftSideDiameterLineAngle_deg:[{value:this.boxmodelresult.LeftSideDiameterLineAngle_deg,disabled:!1},[g.p.min(0),g.p.max(360)]],CircleCenterLatitude:[{value:this.boxmodelresult.CircleCenterLatitude,disabled:!1},[g.p.min(-90),g.p.max(90)]],CircleCenterLongitude:[{value:this.boxmodelresult.CircleCenterLongitude,disabled:!1},[g.p.min(-180),g.p.max(180)]],FixLength:[{value:this.boxmodelresult.FixLength,disabled:!1},[g.p.required]],FixWidth:[{value:this.boxmodelresult.FixWidth,disabled:!1},[g.p.required]],RectLength_m:[{value:this.boxmodelresult.RectLength_m,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e5)]],RectWidth_m:[{value:this.boxmodelresult.RectWidth_m,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e5)]],LeftSideLineAngle_deg:[{value:this.boxmodelresult.LeftSideLineAngle_deg,disabled:!1},[g.p.min(0),g.p.max(360)]],LeftSideLineStartLatitude:[{value:this.boxmodelresult.LeftSideLineStartLatitude,disabled:!1},[g.p.min(-90),g.p.max(90)]],LeftSideLineStartLongitude:[{value:this.boxmodelresult.LeftSideLineStartLongitude,disabled:!1},[g.p.min(-180),g.p.max(180)]],LastUpdateDate_UTC:[{value:this.boxmodelresult.LastUpdateDate_UTC,disabled:!1},[g.p.required]],LastUpdateContactTVItemID:[{value:this.boxmodelresult.LastUpdateContactTVItemID,disabled:!1},[g.p.required]]});this.boxmodelresultFormEdit=t}}}]),e}()).\u0275fac=function(e){return new(e||Le)(a.Nb(x),a.Nb(g.d))},Le.\u0275cmp=a.Hb({type:Le,selectors:[["app-boxmodelresult-edit"]],inputs:{boxmodelresult:"boxmodelresult",httpClientCommand:"httpClientCommand"},decls:104,vars:23,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","BoxModelResultID"],[4,"ngIf"],["matInput","","type","number","formControlName","BoxModelID"],["formControlName","BoxModelResultType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","number","formControlName","Volume_m3"],["matInput","","type","number","formControlName","Surface_m2"],["matInput","","type","number","formControlName","Radius_m"],["matInput","","type","number","formControlName","LeftSideDiameterLineAngle_deg"],["matInput","","type","number","formControlName","CircleCenterLatitude"],["matInput","","type","number","formControlName","CircleCenterLongitude"],["matInput","","type","text","formControlName","FixLength"],["matInput","","type","text","formControlName","FixWidth"],["matInput","","type","number","formControlName","RectLength_m"],["matInput","","type","number","formControlName","RectWidth_m"],["matInput","","type","number","formControlName","LeftSideLineAngle_deg"],["matInput","","type","number","formControlName","LeftSideLineStartLatitude"],["matInput","","type","number","formControlName","LeftSideLineStartLongitude"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(a.Tb(0,"form",0),a.ac("ngSubmit",(function(){return t.GetPut()?t.PutBoxModelResult(t.boxmodelresultFormEdit.value):t.PostBoxModelResult(t.boxmodelresultFormEdit.value)})),a.Tb(1,"h3"),a.yc(2," BoxModelResult "),a.Tb(3,"button",1),a.Tb(4,"span"),a.yc(5),a.Sb(),a.Sb(),a.xc(6,C,1,0,"mat-progress-bar",2),a.xc(7,M,1,0,"mat-progress-bar",2),a.Sb(),a.Tb(8,"p"),a.Tb(9,"mat-form-field"),a.Tb(10,"mat-label"),a.yc(11,"BoxModelResultID"),a.Sb(),a.Ob(12,"input",3),a.xc(13,j,6,4,"mat-error",4),a.Sb(),a.Tb(14,"mat-form-field"),a.Tb(15,"mat-label"),a.yc(16,"BoxModelID"),a.Sb(),a.Ob(17,"input",5),a.xc(18,R,6,4,"mat-error",4),a.Sb(),a.Tb(19,"mat-form-field"),a.Tb(20,"mat-label"),a.yc(21,"BoxModelResultType"),a.Sb(),a.Tb(22,"mat-select",6),a.xc(23,E,2,2,"mat-option",7),a.Sb(),a.xc(24,k,6,4,"mat-error",4),a.Sb(),a.Tb(25,"mat-form-field"),a.Tb(26,"mat-label"),a.yc(27,"Volume_m3"),a.Sb(),a.Ob(28,"input",8),a.xc(29,w,7,5,"mat-error",4),a.Sb(),a.Sb(),a.Tb(30,"p"),a.Tb(31,"mat-form-field"),a.Tb(32,"mat-label"),a.yc(33,"Surface_m2"),a.Sb(),a.Ob(34,"input",9),a.xc(35,A,7,5,"mat-error",4),a.Sb(),a.Tb(36,"mat-form-field"),a.Tb(37,"mat-label"),a.yc(38,"Radius_m"),a.Sb(),a.Ob(39,"input",10),a.xc(40,V,8,6,"mat-error",4),a.Sb(),a.Tb(41,"mat-form-field"),a.Tb(42,"mat-label"),a.yc(43,"LeftSideDiameterLineAngle_deg"),a.Sb(),a.Ob(44,"input",11),a.xc(45,H,7,5,"mat-error",4),a.Sb(),a.Tb(46,"mat-form-field"),a.Tb(47,"mat-label"),a.yc(48,"CircleCenterLatitude"),a.Sb(),a.Ob(49,"input",12),a.xc(50,K,7,5,"mat-error",4),a.Sb(),a.Sb(),a.Tb(51,"p"),a.Tb(52,"mat-form-field"),a.Tb(53,"mat-label"),a.yc(54,"CircleCenterLongitude"),a.Sb(),a.Ob(55,"input",13),a.xc(56,Z,7,5,"mat-error",4),a.Sb(),a.Tb(57,"mat-form-field"),a.Tb(58,"mat-label"),a.yc(59,"FixLength"),a.Sb(),a.Ob(60,"input",14),a.xc(61,te,6,4,"mat-error",4),a.Sb(),a.Tb(62,"mat-form-field"),a.Tb(63,"mat-label"),a.yc(64,"FixWidth"),a.Sb(),a.Ob(65,"input",15),a.xc(66,ne,6,4,"mat-error",4),a.Sb(),a.Tb(67,"mat-form-field"),a.Tb(68,"mat-label"),a.yc(69,"RectLength_m"),a.Sb(),a.Ob(70,"input",16),a.xc(71,le,8,6,"mat-error",4),a.Sb(),a.Sb(),a.Tb(72,"p"),a.Tb(73,"mat-form-field"),a.Tb(74,"mat-label"),a.yc(75,"RectWidth_m"),a.Sb(),a.Ob(76,"input",17),a.xc(77,se,8,6,"mat-error",4),a.Sb(),a.Tb(78,"mat-form-field"),a.Tb(79,"mat-label"),a.yc(80,"LeftSideLineAngle_deg"),a.Sb(),a.Ob(81,"input",18),a.xc(82,pe,7,5,"mat-error",4),a.Sb(),a.Tb(83,"mat-form-field"),a.Tb(84,"mat-label"),a.yc(85,"LeftSideLineStartLatitude"),a.Sb(),a.Ob(86,"input",19),a.xc(87,Se,7,5,"mat-error",4),a.Sb(),a.Tb(88,"mat-form-field"),a.Tb(89,"mat-label"),a.yc(90,"LeftSideLineStartLongitude"),a.Sb(),a.Ob(91,"input",20),a.xc(92,ye,7,5,"mat-error",4),a.Sb(),a.Sb(),a.Tb(93,"p"),a.Tb(94,"mat-form-field"),a.Tb(95,"mat-label"),a.yc(96,"LastUpdateDate_UTC"),a.Sb(),a.Ob(97,"input",21),a.xc(98,Be,6,4,"mat-error",4),a.Sb(),a.Tb(99,"mat-form-field"),a.Tb(100,"mat-label"),a.yc(101,"LastUpdateContactTVItemID"),a.Sb(),a.Ob(102,"input",22),a.xc(103,ve,6,4,"mat-error",4),a.Sb(),a.Sb(),a.Sb()),2&e&&(a.jc("formGroup",t.boxmodelresultFormEdit),a.Bb(5),a.Ac("",t.GetPut()?"Put":"Post"," BoxModelResult"),a.Bb(1),a.jc("ngIf",t.boxmodelresultService.boxmodelresultPutModel$.getValue().Working),a.Bb(1),a.jc("ngIf",t.boxmodelresultService.boxmodelresultPostModel$.getValue().Working),a.Bb(6),a.jc("ngIf",t.boxmodelresultFormEdit.controls.BoxModelResultID.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.BoxModelID.errors),a.Bb(5),a.jc("ngForOf",t.boxModelResultTypeList),a.Bb(1),a.jc("ngIf",t.boxmodelresultFormEdit.controls.BoxModelResultType.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.Volume_m3.errors),a.Bb(6),a.jc("ngIf",t.boxmodelresultFormEdit.controls.Surface_m2.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.Radius_m.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.LeftSideDiameterLineAngle_deg.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.CircleCenterLatitude.errors),a.Bb(6),a.jc("ngIf",t.boxmodelresultFormEdit.controls.CircleCenterLongitude.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.FixLength.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.FixWidth.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.RectLength_m.errors),a.Bb(6),a.jc("ngIf",t.boxmodelresultFormEdit.controls.RectWidth_m.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.LeftSideLineAngle_deg.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.LeftSideLineStartLatitude.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.LeftSideLineStartLongitude.errors),a.Bb(6),a.jc("ngIf",t.boxmodelresultFormEdit.controls.LastUpdateDate_UTC.errors),a.Bb(5),a.jc("ngIf",t.boxmodelresultFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[g.q,g.l,g.f,T.b,n.l,B.c,B.f,I.b,g.n,g.c,g.k,g.e,v.a,n.k,h.a,B.b,L.n],pipes:[n.f],styles:[""],changeDetection:0}),Le);function Me(e,t){1&e&&a.Ob(0,"mat-progress-bar",4)}function De(e,t){1&e&&a.Ob(0,"mat-progress-bar",4)}function je(e,t){if(1&e&&(a.Tb(0,"p"),a.Ob(1,"app-boxmodelresult-edit",8),a.Sb()),2&e){var o=a.ec().$implicit,n=a.ec(2);a.Bb(1),a.jc("boxmodelresult",o)("httpClientCommand",n.GetPutEnum())}}function Oe(e,t){if(1&e&&(a.Tb(0,"p"),a.Ob(1,"app-boxmodelresult-edit",8),a.Sb()),2&e){var o=a.ec().$implicit,n=a.ec(2);a.Bb(1),a.jc("boxmodelresult",o)("httpClientCommand",n.GetPostEnum())}}function Re(e,t){if(1&e){var o=a.Ub();a.Tb(0,"div"),a.Tb(1,"p"),a.Tb(2,"button",6),a.ac("click",(function(){a.rc(o);var e=t.$implicit;return a.ec(2).DeleteBoxModelResult(e)})),a.Tb(3,"span"),a.yc(4),a.Sb(),a.Tb(5,"mat-icon"),a.yc(6,"delete"),a.Sb(),a.Sb(),a.yc(7,"\xa0\xa0\xa0 "),a.Tb(8,"button",7),a.ac("click",(function(){a.rc(o);var e=t.$implicit;return a.ec(2).ShowPut(e)})),a.Tb(9,"span"),a.yc(10,"Show Put"),a.Sb(),a.Sb(),a.yc(11,"\xa0\xa0 "),a.Tb(12,"button",7),a.ac("click",(function(){a.rc(o);var e=t.$implicit;return a.ec(2).ShowPost(e)})),a.Tb(13,"span"),a.yc(14,"Show Post"),a.Sb(),a.Sb(),a.yc(15,"\xa0\xa0 "),a.xc(16,De,1,0,"mat-progress-bar",0),a.Sb(),a.xc(17,je,2,2,"p",2),a.xc(18,Oe,2,2,"p",2),a.Tb(19,"blockquote"),a.Tb(20,"p"),a.Tb(21,"span"),a.yc(22),a.Sb(),a.Tb(23,"span"),a.yc(24),a.Sb(),a.Tb(25,"span"),a.yc(26),a.Sb(),a.Tb(27,"span"),a.yc(28),a.Sb(),a.Sb(),a.Tb(29,"p"),a.Tb(30,"span"),a.yc(31),a.Sb(),a.Tb(32,"span"),a.yc(33),a.Sb(),a.Tb(34,"span"),a.yc(35),a.Sb(),a.Tb(36,"span"),a.yc(37),a.Sb(),a.Sb(),a.Tb(38,"p"),a.Tb(39,"span"),a.yc(40),a.Sb(),a.Tb(41,"span"),a.yc(42),a.Sb(),a.Tb(43,"span"),a.yc(44),a.Sb(),a.Tb(45,"span"),a.yc(46),a.Sb(),a.Sb(),a.Tb(47,"p"),a.Tb(48,"span"),a.yc(49),a.Sb(),a.Tb(50,"span"),a.yc(51),a.Sb(),a.Tb(52,"span"),a.yc(53),a.Sb(),a.Tb(54,"span"),a.yc(55),a.Sb(),a.Sb(),a.Tb(56,"p"),a.Tb(57,"span"),a.yc(58),a.Sb(),a.Tb(59,"span"),a.yc(60),a.Sb(),a.Sb(),a.Sb(),a.Sb()}if(2&e){var n=t.$implicit,r=a.ec(2);a.Bb(4),a.Ac("Delete BoxModelResultID [",n.BoxModelResultID,"]\xa0\xa0\xa0"),a.Bb(4),a.jc("color",r.GetPutButtonColor(n)),a.Bb(4),a.jc("color",r.GetPostButtonColor(n)),a.Bb(4),a.jc("ngIf",r.boxmodelresultService.boxmodelresultDeleteModel$.getValue().Working),a.Bb(1),a.jc("ngIf",r.IDToShow===n.BoxModelResultID&&r.showType===r.GetPutEnum()),a.Bb(1),a.jc("ngIf",r.IDToShow===n.BoxModelResultID&&r.showType===r.GetPostEnum()),a.Bb(4),a.Ac("BoxModelResultID: [",n.BoxModelResultID,"]"),a.Bb(2),a.Ac(" --- BoxModelID: [",n.BoxModelID,"]"),a.Bb(2),a.Ac(" --- BoxModelResultType: [",r.GetBoxModelResultTypeEnumText(n.BoxModelResultType),"]"),a.Bb(2),a.Ac(" --- Volume_m3: [",n.Volume_m3,"]"),a.Bb(3),a.Ac("Surface_m2: [",n.Surface_m2,"]"),a.Bb(2),a.Ac(" --- Radius_m: [",n.Radius_m,"]"),a.Bb(2),a.Ac(" --- LeftSideDiameterLineAngle_deg: [",n.LeftSideDiameterLineAngle_deg,"]"),a.Bb(2),a.Ac(" --- CircleCenterLatitude: [",n.CircleCenterLatitude,"]"),a.Bb(3),a.Ac("CircleCenterLongitude: [",n.CircleCenterLongitude,"]"),a.Bb(2),a.Ac(" --- FixLength: [",n.FixLength,"]"),a.Bb(2),a.Ac(" --- FixWidth: [",n.FixWidth,"]"),a.Bb(2),a.Ac(" --- RectLength_m: [",n.RectLength_m,"]"),a.Bb(3),a.Ac("RectWidth_m: [",n.RectWidth_m,"]"),a.Bb(2),a.Ac(" --- LeftSideLineAngle_deg: [",n.LeftSideLineAngle_deg,"]"),a.Bb(2),a.Ac(" --- LeftSideLineStartLatitude: [",n.LeftSideLineStartLatitude,"]"),a.Bb(2),a.Ac(" --- LeftSideLineStartLongitude: [",n.LeftSideLineStartLongitude,"]"),a.Bb(3),a.Ac("LastUpdateDate_UTC: [",n.LastUpdateDate_UTC,"]"),a.Bb(2),a.Ac(" --- LastUpdateContactTVItemID: [",n.LastUpdateContactTVItemID,"]")}}function Ee(e,t){if(1&e&&(a.Tb(0,"div"),a.xc(1,Re,61,24,"div",5),a.Sb()),2&e){var o=a.ec();a.Bb(1),a.jc("ngForOf",o.boxmodelresultService.boxmodelresultListModel$.getValue())}}var _e,ke,Pe,$e=[{path:"",component:(_e=function(){function e(t,o,n){_classCallCheck(this,e),this.boxmodelresultService=t,this.router=o,this.httpClientService=n,this.showType=null,n.oldURL=o.url}return _createClass(e,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.BoxModelResultID&&this.showType===c.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.BoxModelResultID&&this.showType===c.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.BoxModelResultID&&this.showType===c.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.BoxModelResultID,this.showType=c.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.BoxModelResultID&&this.showType===c.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.BoxModelResultID,this.showType=c.a.Post)}},{key:"GetPutEnum",value:function(){return c.a.Put}},{key:"GetPostEnum",value:function(){return c.a.Post}},{key:"GetBoxModelResultList",value:function(){this.sub=this.boxmodelresultService.GetBoxModelResultList().subscribe()}},{key:"DeleteBoxModelResult",value:function(e){this.sub=this.boxmodelresultService.DeleteBoxModelResult(e).subscribe()}},{key:"GetBoxModelResultTypeEnumText",value:function(e){return function(e){var t;return b().forEach((function(o){if(o.EnumID==e)return t=o.EnumText,!1})),t}(e)}},{key:"ngOnInit",value:function(){i(this.boxmodelresultService.boxmodelresultTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),e}(),_e.\u0275fac=function(e){return new(e||_e)(a.Nb(x),a.Nb(r.b),a.Nb(f.a))},_e.\u0275cmp=a.Hb({type:_e,selectors:[["app-boxmodelresult"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"boxmodelresult","httpClientCommand"]],template:function(e,t){if(1&e&&(a.xc(0,Me,1,0,"mat-progress-bar",0),a.Tb(1,"mat-card"),a.Tb(2,"mat-card-header"),a.Tb(3,"mat-card-title"),a.yc(4," BoxModelResult works! "),a.Tb(5,"button",1),a.ac("click",(function(){return t.GetBoxModelResultList()})),a.Tb(6,"span"),a.yc(7,"Get BoxModelResult"),a.Sb(),a.Sb(),a.Sb(),a.Tb(8,"mat-card-subtitle"),a.yc(9),a.Sb(),a.Sb(),a.Tb(10,"mat-card-content"),a.xc(11,Ee,2,1,"div",2),a.Sb(),a.Tb(12,"mat-card-actions"),a.Tb(13,"button",3),a.yc(14,"Allo"),a.Sb(),a.Sb(),a.Sb()),2&e){var o,n,r=null==(o=t.boxmodelresultService.boxmodelresultGetModel$.getValue())?null:o.Working,i=null==(n=t.boxmodelresultService.boxmodelresultListModel$.getValue())?null:n.length;a.jc("ngIf",r),a.Bb(9),a.zc(t.boxmodelresultService.boxmodelresultTextModel$.getValue().Title),a.Bb(2),a.jc("ngIf",i)}},directives:[n.l,S.a,S.d,S.g,T.b,S.f,S.c,S.b,h.a,n.k,y.a,Ce],styles:[""],changeDetection:0}),_e),canActivate:[o("auXs").a]}],we=((ke=function e(){_classCallCheck(this,e)}).\u0275mod=a.Lb({type:ke}),ke.\u0275inj=a.Kb({factory:function(e){return new(e||ke)},imports:[[r.e.forChild($e)],r.e]}),ke),Fe=o("B+Mi"),qe=((Pe=function e(){_classCallCheck(this,e)}).\u0275mod=a.Lb({type:Pe}),Pe.\u0275inj=a.Kb({factory:function(e){return new(e||Pe)},imports:[[n.c,r.e,we,Fe.a,g.g,g.o]]}),Pe)},QRvi:function(e,t,o){"use strict";o.d(t,"a",(function(){return n}));var n=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,o){"use strict";o.d(t,"a",(function(){return b}));var n=o("QRvi"),r=o("fXoL"),i=o("tyNb"),b=function(){var e=function(){function e(t){_classCallCheck(this,e),this.router=t,this.oldURL=t.url}return _createClass(e,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,t,o){e.next(null),t.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(e,t,o){e.next(null),t.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,t,o,r,i){if(r===n.a.Get&&e.next(o),r===n.a.Put&&(e.getValue()[0]=o),r===n.a.Post&&e.getValue().push(o),r===n.a.Delete){var b=e.getValue().indexOf(i);e.getValue().splice(b,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(e,t,o,r,i){r===n.a.Get&&e.next(o),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(r.Xb(i.b))},e.\u0275prov=r.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()}}]);