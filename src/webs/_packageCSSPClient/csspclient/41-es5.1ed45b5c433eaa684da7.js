!function(){function t(t,a){if(!(t instanceof a))throw new TypeError("Cannot call a class as a function")}function a(t,a){for(var e=0;e<a.length;e++){var i=a[e];i.enumerable=i.enumerable||!1,i.configurable=!0,"value"in i&&(i.writable=!0),Object.defineProperty(t,i.key,i)}}function e(t,e,i){return e&&a(t.prototype,e),i&&a(t,i),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[41],{"+WJj":function(a,i,n){"use strict";n.r(i),n.d(i,"ClimateDataValueModule",(function(){return Ft}));var c=n("ofXK"),r=n("tyNb");function l(t){var a={Title:"The title"};"fr-CA"===$localize.locale&&(a.Title="Le Titre"),t.next(a)}var o,b=n("qfes"),u=n("QRvi"),m=n("fXoL"),s=n("2Vo4"),p=n("LRne"),d=n("tk/3"),f=n("lJxs"),S=n("JIr8"),v=n("gkM4"),R=((o=function(){function a(e,i){t(this,a),this.httpClient=e,this.httpClientService=i,this.climatedatavalueTextModel$=new s.a({}),this.climatedatavalueListModel$=new s.a({}),this.climatedatavalueGetModel$=new s.a({}),this.climatedatavaluePutModel$=new s.a({}),this.climatedatavaluePostModel$=new s.a({}),this.climatedatavalueDeleteModel$=new s.a({}),l(this.climatedatavalueTextModel$),this.climatedatavalueTextModel$.next({Title:"Something2 for text"})}return e(a,[{key:"GetClimateDataValueList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.climatedatavalueGetModel$),this.httpClient.get("/api/ClimateDataValue").pipe(Object(f.a)((function(a){t.httpClientService.DoSuccess(t.climatedatavalueListModel$,t.climatedatavalueGetModel$,a,u.a.Get,null)})),Object(S.a)((function(a){return Object(p.a)(a).pipe(Object(f.a)((function(a){t.httpClientService.DoCatchError(t.climatedatavalueListModel$,t.climatedatavalueGetModel$,a)})))})))}},{key:"PutClimateDataValue",value:function(t){var a=this;return this.httpClientService.BeforeHttpClient(this.climatedatavaluePutModel$),this.httpClient.put("/api/ClimateDataValue",t,{headers:new d.d}).pipe(Object(f.a)((function(e){a.httpClientService.DoSuccess(a.climatedatavalueListModel$,a.climatedatavaluePutModel$,e,u.a.Put,t)})),Object(S.a)((function(t){return Object(p.a)(t).pipe(Object(f.a)((function(t){a.httpClientService.DoCatchError(a.climatedatavalueListModel$,a.climatedatavaluePutModel$,t)})))})))}},{key:"PostClimateDataValue",value:function(t){var a=this;return this.httpClientService.BeforeHttpClient(this.climatedatavaluePostModel$),this.httpClient.post("/api/ClimateDataValue",t,{headers:new d.d}).pipe(Object(f.a)((function(e){a.httpClientService.DoSuccess(a.climatedatavalueListModel$,a.climatedatavaluePostModel$,e,u.a.Post,t)})),Object(S.a)((function(t){return Object(p.a)(t).pipe(Object(f.a)((function(t){a.httpClientService.DoCatchError(a.climatedatavalueListModel$,a.climatedatavaluePostModel$,t)})))})))}},{key:"DeleteClimateDataValue",value:function(t){var a=this;return this.httpClientService.BeforeHttpClient(this.climatedatavalueDeleteModel$),this.httpClient.delete("/api/ClimateDataValue/"+t.ClimateDataValueID).pipe(Object(f.a)((function(e){a.httpClientService.DoSuccess(a.climatedatavalueListModel$,a.climatedatavalueDeleteModel$,e,u.a.Delete,t)})),Object(S.a)((function(t){return Object(p.a)(t).pipe(Object(f.a)((function(t){a.httpClientService.DoCatchError(a.climatedatavalueListModel$,a.climatedatavalueDeleteModel$,t)})))})))}}]),a}()).\u0275fac=function(t){return new(t||o)(m.Wb(d.b),m.Wb(v.a))},o.\u0275prov=m.Ib({token:o,factory:o.\u0275fac,providedIn:"root"}),o),h=n("Wp6s"),D=n("bTqV"),C=n("bv9b"),y=n("NFeN"),B=n("3Pt+"),g=n("kmnG"),I=n("qFsG"),N=n("d3UM"),z=n("FKr1");function _(t,a){1&t&&m.Nb(0,"mat-progress-bar",25)}function M(t,a){1&t&&m.Nb(0,"mat-progress-bar",25)}function T(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function x(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,T,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function V(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function k(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,V,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function P(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function w(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,P,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function $(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function G(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,$,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function E(t,a){if(1&t&&(m.Sb(0,"mat-option",26),m.zc(1),m.Rb()),2&t){var e=a.$implicit;m.ic("value",e.EnumID),m.Bb(1),m.Bc(" ",e.EnumText," ")}}function L(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function j(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,L,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function F(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function O(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,F,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function q(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - 0"),m.Nb(2,"br"),m.Rb())}function H(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 10000"),m.Nb(2,"br"),m.Rb())}function U(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,q,3,0,"span",4),m.yc(6,H,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function A(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - 0"),m.Nb(2,"br"),m.Rb())}function W(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 10000"),m.Nb(2,"br"),m.Rb())}function K(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,A,3,0,"span",4),m.yc(6,W,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function J(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - 0"),m.Nb(2,"br"),m.Rb())}function Z(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 10000"),m.Nb(2,"br"),m.Rb())}function X(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,J,3,0,"span",4),m.yc(6,Z,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function Q(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - 0"),m.Nb(2,"br"),m.Rb())}function Y(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 10000"),m.Nb(2,"br"),m.Rb())}function tt(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,Q,3,0,"span",4),m.yc(6,Y,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function at(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - -50"),m.Nb(2,"br"),m.Rb())}function et(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 50"),m.Nb(2,"br"),m.Rb())}function it(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,at,3,0,"span",4),m.yc(6,et,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function nt(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - -50"),m.Nb(2,"br"),m.Rb())}function ct(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 50"),m.Nb(2,"br"),m.Rb())}function rt(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,nt,3,0,"span",4),m.yc(6,ct,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function lt(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - -1000"),m.Nb(2,"br"),m.Rb())}function ot(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 100"),m.Nb(2,"br"),m.Rb())}function bt(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,lt,3,0,"span",4),m.yc(6,ot,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function ut(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - -1000"),m.Nb(2,"br"),m.Rb())}function mt(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 100"),m.Nb(2,"br"),m.Rb())}function st(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,ut,3,0,"span",4),m.yc(6,mt,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function pt(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - 0"),m.Nb(2,"br"),m.Rb())}function dt(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 10000"),m.Nb(2,"br"),m.Rb())}function ft(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,pt,3,0,"span",4),m.yc(6,dt,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function St(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - 0"),m.Nb(2,"br"),m.Rb())}function vt(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 360"),m.Nb(2,"br"),m.Rb())}function Rt(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,St,3,0,"span",4),m.yc(6,vt,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function ht(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - 0"),m.Nb(2,"br"),m.Rb())}function Dt(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 300"),m.Nb(2,"br"),m.Rb())}function Ct(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,ht,3,0,"span",4),m.yc(6,Dt,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function yt(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,1,e))}}function Bt(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function gt(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,Bt,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function It(t,a){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function Nt(t,a){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,It,3,0,"span",4),m.Rb()),2&t){var e=a.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}var zt,_t=((zt=function(){function a(e,i){t(this,a),this.climatedatavalueService=e,this.fb=i,this.climatedatavalue=null,this.httpClientCommand=u.a.Put}return e(a,[{key:"GetPut",value:function(){return this.httpClientCommand==u.a.Put}},{key:"PutClimateDataValue",value:function(t){this.sub=this.climatedatavalueService.PutClimateDataValue(t).subscribe()}},{key:"PostClimateDataValue",value:function(t){this.sub=this.climatedatavalueService.PostClimateDataValue(t).subscribe()}},{key:"ngOnInit",value:function(){this.storageDataTypeList=Object(b.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.climatedatavalue){var a=this.fb.group({ClimateDataValueID:[{value:t===u.a.Post?0:this.climatedatavalue.ClimateDataValueID,disabled:!1},[B.p.required]],ClimateSiteID:[{value:this.climatedatavalue.ClimateSiteID,disabled:!1},[B.p.required]],DateTime_Local:[{value:this.climatedatavalue.DateTime_Local,disabled:!1},[B.p.required]],Keep:[{value:this.climatedatavalue.Keep,disabled:!1},[B.p.required]],StorageDataType:[{value:this.climatedatavalue.StorageDataType,disabled:!1},[B.p.required]],HasBeenRead:[{value:this.climatedatavalue.HasBeenRead,disabled:!1},[B.p.required]],Snow_cm:[{value:this.climatedatavalue.Snow_cm,disabled:!1},[B.p.min(0),B.p.max(1e4)]],Rainfall_mm:[{value:this.climatedatavalue.Rainfall_mm,disabled:!1},[B.p.min(0),B.p.max(1e4)]],RainfallEntered_mm:[{value:this.climatedatavalue.RainfallEntered_mm,disabled:!1},[B.p.min(0),B.p.max(1e4)]],TotalPrecip_mm_cm:[{value:this.climatedatavalue.TotalPrecip_mm_cm,disabled:!1},[B.p.min(0),B.p.max(1e4)]],MaxTemp_C:[{value:this.climatedatavalue.MaxTemp_C,disabled:!1},[B.p.min(-50),B.p.max(50)]],MinTemp_C:[{value:this.climatedatavalue.MinTemp_C,disabled:!1},[B.p.min(-50),B.p.max(50)]],HeatDegDays_C:[{value:this.climatedatavalue.HeatDegDays_C,disabled:!1},[B.p.min(-1e3),B.p.max(100)]],CoolDegDays_C:[{value:this.climatedatavalue.CoolDegDays_C,disabled:!1},[B.p.min(-1e3),B.p.max(100)]],SnowOnGround_cm:[{value:this.climatedatavalue.SnowOnGround_cm,disabled:!1},[B.p.min(0),B.p.max(1e4)]],DirMaxGust_0North:[{value:this.climatedatavalue.DirMaxGust_0North,disabled:!1},[B.p.min(0),B.p.max(360)]],SpdMaxGust_kmh:[{value:this.climatedatavalue.SpdMaxGust_kmh,disabled:!1},[B.p.min(0),B.p.max(300)]],HourlyValues:[{value:this.climatedatavalue.HourlyValues,disabled:!1}],LastUpdateDate_UTC:[{value:this.climatedatavalue.LastUpdateDate_UTC,disabled:!1},[B.p.required]],LastUpdateContactTVItemID:[{value:this.climatedatavalue.LastUpdateContactTVItemID,disabled:!1},[B.p.required]]});this.climatedatavalueFormEdit=a}}}]),a}()).\u0275fac=function(t){return new(t||zt)(m.Mb(R),m.Mb(B.d))},zt.\u0275cmp=m.Gb({type:zt,selectors:[["app-climatedatavalue-edit"]],inputs:{climatedatavalue:"climatedatavalue",httpClientCommand:"httpClientCommand"},decls:114,vars:25,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","ClimateDataValueID"],[4,"ngIf"],["matInput","","type","number","formControlName","ClimateSiteID"],["matInput","","type","text","formControlName","DateTime_Local"],["matInput","","type","text","formControlName","Keep"],["formControlName","StorageDataType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","HasBeenRead"],["matInput","","type","number","formControlName","Snow_cm"],["matInput","","type","number","formControlName","Rainfall_mm"],["matInput","","type","number","formControlName","RainfallEntered_mm"],["matInput","","type","number","formControlName","TotalPrecip_mm_cm"],["matInput","","type","number","formControlName","MaxTemp_C"],["matInput","","type","number","formControlName","MinTemp_C"],["matInput","","type","number","formControlName","HeatDegDays_C"],["matInput","","type","number","formControlName","CoolDegDays_C"],["matInput","","type","number","formControlName","SnowOnGround_cm"],["matInput","","type","number","formControlName","DirMaxGust_0North"],["matInput","","type","number","formControlName","SpdMaxGust_kmh"],["matInput","","type","text","formControlName","HourlyValues"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,a){1&t&&(m.Sb(0,"form",0),m.Zb("ngSubmit",(function(){return a.GetPut()?a.PutClimateDataValue(a.climatedatavalueFormEdit.value):a.PostClimateDataValue(a.climatedatavalueFormEdit.value)})),m.Sb(1,"h3"),m.zc(2," ClimateDataValue "),m.Sb(3,"button",1),m.Sb(4,"span"),m.zc(5),m.Rb(),m.Rb(),m.yc(6,_,1,0,"mat-progress-bar",2),m.yc(7,M,1,0,"mat-progress-bar",2),m.Rb(),m.Sb(8,"p"),m.Sb(9,"mat-form-field"),m.Sb(10,"mat-label"),m.zc(11,"ClimateDataValueID"),m.Rb(),m.Nb(12,"input",3),m.yc(13,x,6,4,"mat-error",4),m.Rb(),m.Sb(14,"mat-form-field"),m.Sb(15,"mat-label"),m.zc(16,"ClimateSiteID"),m.Rb(),m.Nb(17,"input",5),m.yc(18,k,6,4,"mat-error",4),m.Rb(),m.Sb(19,"mat-form-field"),m.Sb(20,"mat-label"),m.zc(21,"DateTime_Local"),m.Rb(),m.Nb(22,"input",6),m.yc(23,w,6,4,"mat-error",4),m.Rb(),m.Sb(24,"mat-form-field"),m.Sb(25,"mat-label"),m.zc(26,"Keep"),m.Rb(),m.Nb(27,"input",7),m.yc(28,G,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Sb(29,"p"),m.Sb(30,"mat-form-field"),m.Sb(31,"mat-label"),m.zc(32,"StorageDataType"),m.Rb(),m.Sb(33,"mat-select",8),m.yc(34,E,2,2,"mat-option",9),m.Rb(),m.yc(35,j,6,4,"mat-error",4),m.Rb(),m.Sb(36,"mat-form-field"),m.Sb(37,"mat-label"),m.zc(38,"HasBeenRead"),m.Rb(),m.Nb(39,"input",10),m.yc(40,O,6,4,"mat-error",4),m.Rb(),m.Sb(41,"mat-form-field"),m.Sb(42,"mat-label"),m.zc(43,"Snow_cm"),m.Rb(),m.Nb(44,"input",11),m.yc(45,U,7,5,"mat-error",4),m.Rb(),m.Sb(46,"mat-form-field"),m.Sb(47,"mat-label"),m.zc(48,"Rainfall_mm"),m.Rb(),m.Nb(49,"input",12),m.yc(50,K,7,5,"mat-error",4),m.Rb(),m.Rb(),m.Sb(51,"p"),m.Sb(52,"mat-form-field"),m.Sb(53,"mat-label"),m.zc(54,"RainfallEntered_mm"),m.Rb(),m.Nb(55,"input",13),m.yc(56,X,7,5,"mat-error",4),m.Rb(),m.Sb(57,"mat-form-field"),m.Sb(58,"mat-label"),m.zc(59,"TotalPrecip_mm_cm"),m.Rb(),m.Nb(60,"input",14),m.yc(61,tt,7,5,"mat-error",4),m.Rb(),m.Sb(62,"mat-form-field"),m.Sb(63,"mat-label"),m.zc(64,"MaxTemp_C"),m.Rb(),m.Nb(65,"input",15),m.yc(66,it,7,5,"mat-error",4),m.Rb(),m.Sb(67,"mat-form-field"),m.Sb(68,"mat-label"),m.zc(69,"MinTemp_C"),m.Rb(),m.Nb(70,"input",16),m.yc(71,rt,7,5,"mat-error",4),m.Rb(),m.Rb(),m.Sb(72,"p"),m.Sb(73,"mat-form-field"),m.Sb(74,"mat-label"),m.zc(75,"HeatDegDays_C"),m.Rb(),m.Nb(76,"input",17),m.yc(77,bt,7,5,"mat-error",4),m.Rb(),m.Sb(78,"mat-form-field"),m.Sb(79,"mat-label"),m.zc(80,"CoolDegDays_C"),m.Rb(),m.Nb(81,"input",18),m.yc(82,st,7,5,"mat-error",4),m.Rb(),m.Sb(83,"mat-form-field"),m.Sb(84,"mat-label"),m.zc(85,"SnowOnGround_cm"),m.Rb(),m.Nb(86,"input",19),m.yc(87,ft,7,5,"mat-error",4),m.Rb(),m.Sb(88,"mat-form-field"),m.Sb(89,"mat-label"),m.zc(90,"DirMaxGust_0North"),m.Rb(),m.Nb(91,"input",20),m.yc(92,Rt,7,5,"mat-error",4),m.Rb(),m.Rb(),m.Sb(93,"p"),m.Sb(94,"mat-form-field"),m.Sb(95,"mat-label"),m.zc(96,"SpdMaxGust_kmh"),m.Rb(),m.Nb(97,"input",21),m.yc(98,Ct,7,5,"mat-error",4),m.Rb(),m.Sb(99,"mat-form-field"),m.Sb(100,"mat-label"),m.zc(101,"HourlyValues"),m.Rb(),m.Nb(102,"input",22),m.yc(103,yt,5,3,"mat-error",4),m.Rb(),m.Sb(104,"mat-form-field"),m.Sb(105,"mat-label"),m.zc(106,"LastUpdateDate_UTC"),m.Rb(),m.Nb(107,"input",23),m.yc(108,gt,6,4,"mat-error",4),m.Rb(),m.Sb(109,"mat-form-field"),m.Sb(110,"mat-label"),m.zc(111,"LastUpdateContactTVItemID"),m.Rb(),m.Nb(112,"input",24),m.yc(113,Nt,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Rb()),2&t&&(m.ic("formGroup",a.climatedatavalueFormEdit),m.Bb(5),m.Bc("",a.GetPut()?"Put":"Post"," ClimateDataValue"),m.Bb(1),m.ic("ngIf",a.climatedatavalueService.climatedatavaluePutModel$.getValue().Working),m.Bb(1),m.ic("ngIf",a.climatedatavalueService.climatedatavaluePostModel$.getValue().Working),m.Bb(6),m.ic("ngIf",a.climatedatavalueFormEdit.controls.ClimateDataValueID.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.ClimateSiteID.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.DateTime_Local.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.Keep.errors),m.Bb(6),m.ic("ngForOf",a.storageDataTypeList),m.Bb(1),m.ic("ngIf",a.climatedatavalueFormEdit.controls.StorageDataType.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.HasBeenRead.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.Snow_cm.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.Rainfall_mm.errors),m.Bb(6),m.ic("ngIf",a.climatedatavalueFormEdit.controls.RainfallEntered_mm.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.TotalPrecip_mm_cm.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.MaxTemp_C.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.MinTemp_C.errors),m.Bb(6),m.ic("ngIf",a.climatedatavalueFormEdit.controls.HeatDegDays_C.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.CoolDegDays_C.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.SnowOnGround_cm.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.DirMaxGust_0North.errors),m.Bb(6),m.ic("ngIf",a.climatedatavalueFormEdit.controls.SpdMaxGust_kmh.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.HourlyValues.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.LastUpdateDate_UTC.errors),m.Bb(5),m.ic("ngIf",a.climatedatavalueFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[B.q,B.l,B.f,D.b,c.l,g.c,g.f,I.b,B.n,B.c,B.k,B.e,N.a,c.k,C.a,g.b,z.n],pipes:[c.f],styles:[""],changeDetection:0}),zt);function Mt(t,a){1&t&&m.Nb(0,"mat-progress-bar",4)}function Tt(t,a){1&t&&m.Nb(0,"mat-progress-bar",4)}function xt(t,a){if(1&t&&(m.Sb(0,"p"),m.Nb(1,"app-climatedatavalue-edit",8),m.Rb()),2&t){var e=m.dc().$implicit,i=m.dc(2);m.Bb(1),m.ic("climatedatavalue",e)("httpClientCommand",i.GetPutEnum())}}function Vt(t,a){if(1&t&&(m.Sb(0,"p"),m.Nb(1,"app-climatedatavalue-edit",8),m.Rb()),2&t){var e=m.dc().$implicit,i=m.dc(2);m.Bb(1),m.ic("climatedatavalue",e)("httpClientCommand",i.GetPostEnum())}}function kt(t,a){if(1&t){var e=m.Tb();m.Sb(0,"div"),m.Sb(1,"p"),m.Sb(2,"button",6),m.Zb("click",(function(){m.qc(e);var t=a.$implicit;return m.dc(2).DeleteClimateDataValue(t)})),m.Sb(3,"span"),m.zc(4),m.Rb(),m.Sb(5,"mat-icon"),m.zc(6,"delete"),m.Rb(),m.Rb(),m.zc(7,"\xa0\xa0\xa0 "),m.Sb(8,"button",7),m.Zb("click",(function(){m.qc(e);var t=a.$implicit;return m.dc(2).ShowPut(t)})),m.Sb(9,"span"),m.zc(10,"Show Put"),m.Rb(),m.Rb(),m.zc(11,"\xa0\xa0 "),m.Sb(12,"button",7),m.Zb("click",(function(){m.qc(e);var t=a.$implicit;return m.dc(2).ShowPost(t)})),m.Sb(13,"span"),m.zc(14,"Show Post"),m.Rb(),m.Rb(),m.zc(15,"\xa0\xa0 "),m.yc(16,Tt,1,0,"mat-progress-bar",0),m.Rb(),m.yc(17,xt,2,2,"p",2),m.yc(18,Vt,2,2,"p",2),m.Sb(19,"blockquote"),m.Sb(20,"p"),m.Sb(21,"span"),m.zc(22),m.Rb(),m.Sb(23,"span"),m.zc(24),m.Rb(),m.Sb(25,"span"),m.zc(26),m.Rb(),m.Sb(27,"span"),m.zc(28),m.Rb(),m.Rb(),m.Sb(29,"p"),m.Sb(30,"span"),m.zc(31),m.Rb(),m.Sb(32,"span"),m.zc(33),m.Rb(),m.Sb(34,"span"),m.zc(35),m.Rb(),m.Sb(36,"span"),m.zc(37),m.Rb(),m.Rb(),m.Sb(38,"p"),m.Sb(39,"span"),m.zc(40),m.Rb(),m.Sb(41,"span"),m.zc(42),m.Rb(),m.Sb(43,"span"),m.zc(44),m.Rb(),m.Sb(45,"span"),m.zc(46),m.Rb(),m.Rb(),m.Sb(47,"p"),m.Sb(48,"span"),m.zc(49),m.Rb(),m.Sb(50,"span"),m.zc(51),m.Rb(),m.Sb(52,"span"),m.zc(53),m.Rb(),m.Sb(54,"span"),m.zc(55),m.Rb(),m.Rb(),m.Sb(56,"p"),m.Sb(57,"span"),m.zc(58),m.Rb(),m.Sb(59,"span"),m.zc(60),m.Rb(),m.Sb(61,"span"),m.zc(62),m.Rb(),m.Sb(63,"span"),m.zc(64),m.Rb(),m.Rb(),m.Rb(),m.Rb()}if(2&t){var i=a.$implicit,n=m.dc(2);m.Bb(4),m.Bc("Delete ClimateDataValueID [",i.ClimateDataValueID,"]\xa0\xa0\xa0"),m.Bb(4),m.ic("color",n.GetPutButtonColor(i)),m.Bb(4),m.ic("color",n.GetPostButtonColor(i)),m.Bb(4),m.ic("ngIf",n.climatedatavalueService.climatedatavalueDeleteModel$.getValue().Working),m.Bb(1),m.ic("ngIf",n.IDToShow===i.ClimateDataValueID&&n.showType===n.GetPutEnum()),m.Bb(1),m.ic("ngIf",n.IDToShow===i.ClimateDataValueID&&n.showType===n.GetPostEnum()),m.Bb(4),m.Bc("ClimateDataValueID: [",i.ClimateDataValueID,"]"),m.Bb(2),m.Bc(" --- ClimateSiteID: [",i.ClimateSiteID,"]"),m.Bb(2),m.Bc(" --- DateTime_Local: [",i.DateTime_Local,"]"),m.Bb(2),m.Bc(" --- Keep: [",i.Keep,"]"),m.Bb(3),m.Bc("StorageDataType: [",n.GetStorageDataTypeEnumText(i.StorageDataType),"]"),m.Bb(2),m.Bc(" --- HasBeenRead: [",i.HasBeenRead,"]"),m.Bb(2),m.Bc(" --- Snow_cm: [",i.Snow_cm,"]"),m.Bb(2),m.Bc(" --- Rainfall_mm: [",i.Rainfall_mm,"]"),m.Bb(3),m.Bc("RainfallEntered_mm: [",i.RainfallEntered_mm,"]"),m.Bb(2),m.Bc(" --- TotalPrecip_mm_cm: [",i.TotalPrecip_mm_cm,"]"),m.Bb(2),m.Bc(" --- MaxTemp_C: [",i.MaxTemp_C,"]"),m.Bb(2),m.Bc(" --- MinTemp_C: [",i.MinTemp_C,"]"),m.Bb(3),m.Bc("HeatDegDays_C: [",i.HeatDegDays_C,"]"),m.Bb(2),m.Bc(" --- CoolDegDays_C: [",i.CoolDegDays_C,"]"),m.Bb(2),m.Bc(" --- SnowOnGround_cm: [",i.SnowOnGround_cm,"]"),m.Bb(2),m.Bc(" --- DirMaxGust_0North: [",i.DirMaxGust_0North,"]"),m.Bb(3),m.Bc("SpdMaxGust_kmh: [",i.SpdMaxGust_kmh,"]"),m.Bb(2),m.Bc(" --- HourlyValues: [",i.HourlyValues,"]"),m.Bb(2),m.Bc(" --- LastUpdateDate_UTC: [",i.LastUpdateDate_UTC,"]"),m.Bb(2),m.Bc(" --- LastUpdateContactTVItemID: [",i.LastUpdateContactTVItemID,"]")}}function Pt(t,a){if(1&t&&(m.Sb(0,"div"),m.yc(1,kt,65,26,"div",5),m.Rb()),2&t){var e=m.dc();m.Bb(1),m.ic("ngForOf",e.climatedatavalueService.climatedatavalueListModel$.getValue())}}var wt,$t,Gt,Et=[{path:"",component:(wt=function(){function a(e,i,n){t(this,a),this.climatedatavalueService=e,this.router=i,this.httpClientService=n,this.showType=null,n.oldURL=i.url}return e(a,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.ClimateDataValueID&&this.showType===u.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.ClimateDataValueID&&this.showType===u.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.ClimateDataValueID&&this.showType===u.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ClimateDataValueID,this.showType=u.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.ClimateDataValueID&&this.showType===u.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ClimateDataValueID,this.showType=u.a.Post)}},{key:"GetPutEnum",value:function(){return u.a.Put}},{key:"GetPostEnum",value:function(){return u.a.Post}},{key:"GetClimateDataValueList",value:function(){this.sub=this.climatedatavalueService.GetClimateDataValueList().subscribe()}},{key:"DeleteClimateDataValue",value:function(t){this.sub=this.climatedatavalueService.DeleteClimateDataValue(t).subscribe()}},{key:"GetStorageDataTypeEnumText",value:function(t){return Object(b.a)(t)}},{key:"ngOnInit",value:function(){l(this.climatedatavalueService.climatedatavalueTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),a}(),wt.\u0275fac=function(t){return new(t||wt)(m.Mb(R),m.Mb(r.b),m.Mb(v.a))},wt.\u0275cmp=m.Gb({type:wt,selectors:[["app-climatedatavalue"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"climatedatavalue","httpClientCommand"]],template:function(t,a){if(1&t&&(m.yc(0,Mt,1,0,"mat-progress-bar",0),m.Sb(1,"mat-card"),m.Sb(2,"mat-card-header"),m.Sb(3,"mat-card-title"),m.zc(4," ClimateDataValue works! "),m.Sb(5,"button",1),m.Zb("click",(function(){return a.GetClimateDataValueList()})),m.Sb(6,"span"),m.zc(7,"Get ClimateDataValue"),m.Rb(),m.Rb(),m.Rb(),m.Sb(8,"mat-card-subtitle"),m.zc(9),m.Rb(),m.Rb(),m.Sb(10,"mat-card-content"),m.yc(11,Pt,2,1,"div",2),m.Rb(),m.Sb(12,"mat-card-actions"),m.Sb(13,"button",3),m.zc(14,"Allo"),m.Rb(),m.Rb(),m.Rb()),2&t){var e,i,n=null==(e=a.climatedatavalueService.climatedatavalueGetModel$.getValue())?null:e.Working,c=null==(i=a.climatedatavalueService.climatedatavalueListModel$.getValue())?null:i.length;m.ic("ngIf",n),m.Bb(9),m.Ac(a.climatedatavalueService.climatedatavalueTextModel$.getValue().Title),m.Bb(2),m.ic("ngIf",c)}},directives:[c.l,h.a,h.d,h.g,D.b,h.f,h.c,h.b,C.a,c.k,y.a,_t],styles:[""],changeDetection:0}),wt),canActivate:[n("auXs").a]}],Lt=(($t=function a(){t(this,a)}).\u0275mod=m.Kb({type:$t}),$t.\u0275inj=m.Jb({factory:function(t){return new(t||$t)},imports:[[r.e.forChild(Et)],r.e]}),$t),jt=n("B+Mi"),Ft=((Gt=function a(){t(this,a)}).\u0275mod=m.Kb({type:Gt}),Gt.\u0275inj=m.Jb({factory:function(t){return new(t||Gt)},imports:[[c.c,r.e,Lt,jt.a,B.g,B.o]]}),Gt)},QRvi:function(t,a,e){"use strict";e.d(a,"a",(function(){return i}));var i=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(a,i,n){"use strict";n.d(i,"a",(function(){return o}));var c=n("QRvi"),r=n("fXoL"),l=n("tyNb"),o=function(){var a=function(){function a(e){t(this,a),this.router=e,this.oldURL=e.url}return e(a,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,a,e){t.next(null),a.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,a,e){t.next(null),a.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,a,e,i,n){if(i===c.a.Get&&t.next(e),i===c.a.Put&&(t.getValue()[0]=e),i===c.a.Post&&t.getValue().push(e),i===c.a.Delete){var r=t.getValue().indexOf(n);t.getValue().splice(r,1)}t.next(t.getValue()),a.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,a,e,i,n){i===c.a.Get&&t.next(e),t.next(t.getValue()),a.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),a}();return a.\u0275fac=function(t){return new(t||a)(r.Wb(l.b))},a.\u0275prov=r.Ib({token:a,factory:a.\u0275fac,providedIn:"root"}),a}()}}])}();