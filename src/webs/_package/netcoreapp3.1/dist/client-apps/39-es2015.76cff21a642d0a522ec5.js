(window.webpackJsonp=window.webpackJsonp||[]).push([[39],{"3dNl":function(e,t,o){"use strict";o.r(t),o.d(t,"BoxModelResultModule",(function(){return $e}));var n=o("ofXK"),r=o("tyNb");function i(e){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}function b(){let e=[];return"fr-CA"===$localize.locale?(e.push({EnumID:1,EnumText:"Dilution"}),e.push({EnumID:2,EnumText:"NoDecayUntreated (fr)"}),e.push({EnumID:3,EnumText:"NoDecayPreDisinfection (fr)"}),e.push({EnumID:4,EnumText:"DecayUntreated (fr)"}),e.push({EnumID:5,EnumText:"DecayPreDisinfection (fr)"})):(e.push({EnumID:1,EnumText:"Dilution"}),e.push({EnumID:2,EnumText:"NoDecayUntreated"}),e.push({EnumID:3,EnumText:"NoDecayPreDisinfection"}),e.push({EnumID:4,EnumText:"DecayUntreated"}),e.push({EnumID:5,EnumText:"DecayPreDisinfection"})),e.sort((e,t)=>e.EnumText.localeCompare(t.EnumText))}var l=o("QRvi"),s=o("fXoL"),c=o("2Vo4"),u=o("LRne"),a=o("tk/3"),m=o("lJxs"),d=o("JIr8"),p=o("gkM4");let f=(()=>{class e{constructor(e,t){this.httpClient=e,this.httpClientService=t,this.boxmodelresultTextModel$=new c.a({}),this.boxmodelresultListModel$=new c.a({}),this.boxmodelresultGetModel$=new c.a({}),this.boxmodelresultPutModel$=new c.a({}),this.boxmodelresultPostModel$=new c.a({}),this.boxmodelresultDeleteModel$=new c.a({}),i(this.boxmodelresultTextModel$),this.boxmodelresultTextModel$.next({Title:"Something2 for text"})}GetBoxModelResultList(){return this.httpClientService.BeforeHttpClient(this.boxmodelresultGetModel$),this.httpClient.get("/api/BoxModelResult").pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.boxmodelresultListModel$,this.boxmodelresultGetModel$,e,l.a.Get,null)}),Object(d.a)(e=>Object(u.a)(e).pipe(Object(m.a)(e=>{this.httpClientService.DoCatchError(this.boxmodelresultListModel$,this.boxmodelresultGetModel$,e)}))))}PutBoxModelResult(e){return this.httpClientService.BeforeHttpClient(this.boxmodelresultPutModel$),this.httpClient.put("/api/BoxModelResult",e,{headers:new a.d}).pipe(Object(m.a)(t=>{this.httpClientService.DoSuccess(this.boxmodelresultListModel$,this.boxmodelresultPutModel$,t,l.a.Put,e)}),Object(d.a)(e=>Object(u.a)(e).pipe(Object(m.a)(e=>{this.httpClientService.DoCatchError(this.boxmodelresultListModel$,this.boxmodelresultPutModel$,e)}))))}PostBoxModelResult(e){return this.httpClientService.BeforeHttpClient(this.boxmodelresultPostModel$),this.httpClient.post("/api/BoxModelResult",e,{headers:new a.d}).pipe(Object(m.a)(t=>{this.httpClientService.DoSuccess(this.boxmodelresultListModel$,this.boxmodelresultPostModel$,t,l.a.Post,e)}),Object(d.a)(e=>Object(u.a)(e).pipe(Object(m.a)(e=>{this.httpClientService.DoCatchError(this.boxmodelresultListModel$,this.boxmodelresultPostModel$,e)}))))}DeleteBoxModelResult(e){return this.httpClientService.BeforeHttpClient(this.boxmodelresultDeleteModel$),this.httpClient.delete("/api/BoxModelResult/"+e.BoxModelResultID).pipe(Object(m.a)(t=>{this.httpClientService.DoSuccess(this.boxmodelresultListModel$,this.boxmodelresultDeleteModel$,t,l.a.Delete,e)}),Object(d.a)(e=>Object(u.a)(e).pipe(Object(m.a)(e=>{this.httpClientService.DoCatchError(this.boxmodelresultListModel$,this.boxmodelresultDeleteModel$,e)}))))}}return e.\u0275fac=function(t){return new(t||e)(s.Xb(a.b),s.Xb(p.a))},e.\u0275prov=s.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var x=o("Wp6s"),S=o("bTqV"),T=o("bv9b"),h=o("NFeN"),g=o("3Pt+"),B=o("kmnG"),y=o("qFsG"),I=o("d3UM"),L=o("FKr1");function M(e,t){1&e&&s.Ob(0,"mat-progress-bar",23)}function C(e,t){1&e&&s.Ob(0,"mat-progress-bar",23)}function D(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function j(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,D,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function O(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function R(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,O,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function v(e,t){if(1&e&&(s.Tb(0,"mat-option",24),s.yc(1),s.Sb()),2&e){const e=t.$implicit;s.jc("value",e.EnumID),s.Bb(1),s.Ac(" ",e.EnumText," ")}}function E(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function P(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,E,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function $(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function _(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function F(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,$,3,0,"span",4),s.xc(6,_,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,3,e)),s.Bb(3),s.jc("ngIf",e.required),s.Bb(1),s.jc("ngIf",e.min)}}function w(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function q(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function A(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,w,3,0,"span",4),s.xc(6,q,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,3,e)),s.Bb(3),s.jc("ngIf",e.required),s.Bb(1),s.jc("ngIf",e.min)}}function G(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function N(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function U(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Max - 100000"),s.Ob(2,"br"),s.Sb())}function k(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,G,3,0,"span",4),s.xc(6,N,3,0,"span",4),s.xc(7,U,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,4,e)),s.Bb(3),s.jc("ngIf",e.required),s.Bb(1),s.jc("ngIf",e.min),s.Bb(1),s.jc("ngIf",e.min)}}function V(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function W(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Max - 360"),s.Ob(2,"br"),s.Sb())}function z(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,V,3,0,"span",4),s.xc(6,W,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,3,e)),s.Bb(3),s.jc("ngIf",e.min),s.Bb(1),s.jc("ngIf",e.min)}}function H(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - -90"),s.Ob(2,"br"),s.Sb())}function X(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Max - 90"),s.Ob(2,"br"),s.Sb())}function J(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,H,3,0,"span",4),s.xc(6,X,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,3,e)),s.Bb(3),s.jc("ngIf",e.min),s.Bb(1),s.jc("ngIf",e.min)}}function K(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - -180"),s.Ob(2,"br"),s.Sb())}function Q(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Max - 180"),s.Ob(2,"br"),s.Sb())}function Y(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,K,3,0,"span",4),s.xc(6,Q,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,3,e)),s.Bb(3),s.jc("ngIf",e.min),s.Bb(1),s.jc("ngIf",e.min)}}function Z(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function ee(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,Z,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function te(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function oe(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,te,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function ne(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function re(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function ie(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Max - 100000"),s.Ob(2,"br"),s.Sb())}function be(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,ne,3,0,"span",4),s.xc(6,re,3,0,"span",4),s.xc(7,ie,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,4,e)),s.Bb(3),s.jc("ngIf",e.required),s.Bb(1),s.jc("ngIf",e.min),s.Bb(1),s.jc("ngIf",e.min)}}function le(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function se(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function ce(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Max - 100000"),s.Ob(2,"br"),s.Sb())}function ue(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,le,3,0,"span",4),s.xc(6,se,3,0,"span",4),s.xc(7,ce,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,4,e)),s.Bb(3),s.jc("ngIf",e.required),s.Bb(1),s.jc("ngIf",e.min),s.Bb(1),s.jc("ngIf",e.min)}}function ae(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function me(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Max - 360"),s.Ob(2,"br"),s.Sb())}function de(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,ae,3,0,"span",4),s.xc(6,me,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,3,e)),s.Bb(3),s.jc("ngIf",e.min),s.Bb(1),s.jc("ngIf",e.min)}}function pe(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - -90"),s.Ob(2,"br"),s.Sb())}function fe(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Max - 90"),s.Ob(2,"br"),s.Sb())}function xe(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,pe,3,0,"span",4),s.xc(6,fe,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,3,e)),s.Bb(3),s.jc("ngIf",e.min),s.Bb(1),s.jc("ngIf",e.min)}}function Se(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Min - -180"),s.Ob(2,"br"),s.Sb())}function Te(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Max - 180"),s.Ob(2,"br"),s.Sb())}function he(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,Se,3,0,"span",4),s.xc(6,Te,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,3,e)),s.Bb(3),s.jc("ngIf",e.min),s.Bb(1),s.jc("ngIf",e.min)}}function ge(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function Be(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,ge,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function ye(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function Ie(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,ye,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}let Le=(()=>{class e{constructor(e,t){this.boxmodelresultService=e,this.fb=t,this.boxmodelresult=null,this.httpClientCommand=l.a.Put}GetPut(){return this.httpClientCommand==l.a.Put}PutBoxModelResult(e){this.sub=this.boxmodelresultService.PutBoxModelResult(e).subscribe()}PostBoxModelResult(e){this.sub=this.boxmodelresultService.PostBoxModelResult(e).subscribe()}ngOnInit(){this.boxModelResultTypeList=b(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.boxmodelresult){let t=this.fb.group({BoxModelResultID:[{value:e===l.a.Post?0:this.boxmodelresult.BoxModelResultID,disabled:!1},[g.p.required]],BoxModelID:[{value:this.boxmodelresult.BoxModelID,disabled:!1},[g.p.required]],BoxModelResultType:[{value:this.boxmodelresult.BoxModelResultType,disabled:!1},[g.p.required]],Volume_m3:[{value:this.boxmodelresult.Volume_m3,disabled:!1},[g.p.required,g.p.min(0)]],Surface_m2:[{value:this.boxmodelresult.Surface_m2,disabled:!1},[g.p.required,g.p.min(0)]],Radius_m:[{value:this.boxmodelresult.Radius_m,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e5)]],LeftSideDiameterLineAngle_deg:[{value:this.boxmodelresult.LeftSideDiameterLineAngle_deg,disabled:!1},[g.p.min(0),g.p.max(360)]],CircleCenterLatitude:[{value:this.boxmodelresult.CircleCenterLatitude,disabled:!1},[g.p.min(-90),g.p.max(90)]],CircleCenterLongitude:[{value:this.boxmodelresult.CircleCenterLongitude,disabled:!1},[g.p.min(-180),g.p.max(180)]],FixLength:[{value:this.boxmodelresult.FixLength,disabled:!1},[g.p.required]],FixWidth:[{value:this.boxmodelresult.FixWidth,disabled:!1},[g.p.required]],RectLength_m:[{value:this.boxmodelresult.RectLength_m,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e5)]],RectWidth_m:[{value:this.boxmodelresult.RectWidth_m,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e5)]],LeftSideLineAngle_deg:[{value:this.boxmodelresult.LeftSideLineAngle_deg,disabled:!1},[g.p.min(0),g.p.max(360)]],LeftSideLineStartLatitude:[{value:this.boxmodelresult.LeftSideLineStartLatitude,disabled:!1},[g.p.min(-90),g.p.max(90)]],LeftSideLineStartLongitude:[{value:this.boxmodelresult.LeftSideLineStartLongitude,disabled:!1},[g.p.min(-180),g.p.max(180)]],LastUpdateDate_UTC:[{value:this.boxmodelresult.LastUpdateDate_UTC,disabled:!1},[g.p.required]],LastUpdateContactTVItemID:[{value:this.boxmodelresult.LastUpdateContactTVItemID,disabled:!1},[g.p.required]]});this.boxmodelresultFormEdit=t}}}return e.\u0275fac=function(t){return new(t||e)(s.Nb(f),s.Nb(g.d))},e.\u0275cmp=s.Hb({type:e,selectors:[["app-boxmodelresult-edit"]],inputs:{boxmodelresult:"boxmodelresult",httpClientCommand:"httpClientCommand"},decls:104,vars:23,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","BoxModelResultID"],[4,"ngIf"],["matInput","","type","number","formControlName","BoxModelID"],["formControlName","BoxModelResultType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","number","formControlName","Volume_m3"],["matInput","","type","number","formControlName","Surface_m2"],["matInput","","type","number","formControlName","Radius_m"],["matInput","","type","number","formControlName","LeftSideDiameterLineAngle_deg"],["matInput","","type","number","formControlName","CircleCenterLatitude"],["matInput","","type","number","formControlName","CircleCenterLongitude"],["matInput","","type","text","formControlName","FixLength"],["matInput","","type","text","formControlName","FixWidth"],["matInput","","type","number","formControlName","RectLength_m"],["matInput","","type","number","formControlName","RectWidth_m"],["matInput","","type","number","formControlName","LeftSideLineAngle_deg"],["matInput","","type","number","formControlName","LeftSideLineStartLatitude"],["matInput","","type","number","formControlName","LeftSideLineStartLongitude"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(s.Tb(0,"form",0),s.ac("ngSubmit",(function(){return t.GetPut()?t.PutBoxModelResult(t.boxmodelresultFormEdit.value):t.PostBoxModelResult(t.boxmodelresultFormEdit.value)})),s.Tb(1,"h3"),s.yc(2," BoxModelResult "),s.Tb(3,"button",1),s.Tb(4,"span"),s.yc(5),s.Sb(),s.Sb(),s.xc(6,M,1,0,"mat-progress-bar",2),s.xc(7,C,1,0,"mat-progress-bar",2),s.Sb(),s.Tb(8,"p"),s.Tb(9,"mat-form-field"),s.Tb(10,"mat-label"),s.yc(11,"BoxModelResultID"),s.Sb(),s.Ob(12,"input",3),s.xc(13,j,6,4,"mat-error",4),s.Sb(),s.Tb(14,"mat-form-field"),s.Tb(15,"mat-label"),s.yc(16,"BoxModelID"),s.Sb(),s.Ob(17,"input",5),s.xc(18,R,6,4,"mat-error",4),s.Sb(),s.Tb(19,"mat-form-field"),s.Tb(20,"mat-label"),s.yc(21,"BoxModelResultType"),s.Sb(),s.Tb(22,"mat-select",6),s.xc(23,v,2,2,"mat-option",7),s.Sb(),s.xc(24,P,6,4,"mat-error",4),s.Sb(),s.Tb(25,"mat-form-field"),s.Tb(26,"mat-label"),s.yc(27,"Volume_m3"),s.Sb(),s.Ob(28,"input",8),s.xc(29,F,7,5,"mat-error",4),s.Sb(),s.Sb(),s.Tb(30,"p"),s.Tb(31,"mat-form-field"),s.Tb(32,"mat-label"),s.yc(33,"Surface_m2"),s.Sb(),s.Ob(34,"input",9),s.xc(35,A,7,5,"mat-error",4),s.Sb(),s.Tb(36,"mat-form-field"),s.Tb(37,"mat-label"),s.yc(38,"Radius_m"),s.Sb(),s.Ob(39,"input",10),s.xc(40,k,8,6,"mat-error",4),s.Sb(),s.Tb(41,"mat-form-field"),s.Tb(42,"mat-label"),s.yc(43,"LeftSideDiameterLineAngle_deg"),s.Sb(),s.Ob(44,"input",11),s.xc(45,z,7,5,"mat-error",4),s.Sb(),s.Tb(46,"mat-form-field"),s.Tb(47,"mat-label"),s.yc(48,"CircleCenterLatitude"),s.Sb(),s.Ob(49,"input",12),s.xc(50,J,7,5,"mat-error",4),s.Sb(),s.Sb(),s.Tb(51,"p"),s.Tb(52,"mat-form-field"),s.Tb(53,"mat-label"),s.yc(54,"CircleCenterLongitude"),s.Sb(),s.Ob(55,"input",13),s.xc(56,Y,7,5,"mat-error",4),s.Sb(),s.Tb(57,"mat-form-field"),s.Tb(58,"mat-label"),s.yc(59,"FixLength"),s.Sb(),s.Ob(60,"input",14),s.xc(61,ee,6,4,"mat-error",4),s.Sb(),s.Tb(62,"mat-form-field"),s.Tb(63,"mat-label"),s.yc(64,"FixWidth"),s.Sb(),s.Ob(65,"input",15),s.xc(66,oe,6,4,"mat-error",4),s.Sb(),s.Tb(67,"mat-form-field"),s.Tb(68,"mat-label"),s.yc(69,"RectLength_m"),s.Sb(),s.Ob(70,"input",16),s.xc(71,be,8,6,"mat-error",4),s.Sb(),s.Sb(),s.Tb(72,"p"),s.Tb(73,"mat-form-field"),s.Tb(74,"mat-label"),s.yc(75,"RectWidth_m"),s.Sb(),s.Ob(76,"input",17),s.xc(77,ue,8,6,"mat-error",4),s.Sb(),s.Tb(78,"mat-form-field"),s.Tb(79,"mat-label"),s.yc(80,"LeftSideLineAngle_deg"),s.Sb(),s.Ob(81,"input",18),s.xc(82,de,7,5,"mat-error",4),s.Sb(),s.Tb(83,"mat-form-field"),s.Tb(84,"mat-label"),s.yc(85,"LeftSideLineStartLatitude"),s.Sb(),s.Ob(86,"input",19),s.xc(87,xe,7,5,"mat-error",4),s.Sb(),s.Tb(88,"mat-form-field"),s.Tb(89,"mat-label"),s.yc(90,"LeftSideLineStartLongitude"),s.Sb(),s.Ob(91,"input",20),s.xc(92,he,7,5,"mat-error",4),s.Sb(),s.Sb(),s.Tb(93,"p"),s.Tb(94,"mat-form-field"),s.Tb(95,"mat-label"),s.yc(96,"LastUpdateDate_UTC"),s.Sb(),s.Ob(97,"input",21),s.xc(98,Be,6,4,"mat-error",4),s.Sb(),s.Tb(99,"mat-form-field"),s.Tb(100,"mat-label"),s.yc(101,"LastUpdateContactTVItemID"),s.Sb(),s.Ob(102,"input",22),s.xc(103,Ie,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Sb()),2&e&&(s.jc("formGroup",t.boxmodelresultFormEdit),s.Bb(5),s.Ac("",t.GetPut()?"Put":"Post"," BoxModelResult"),s.Bb(1),s.jc("ngIf",t.boxmodelresultService.boxmodelresultPutModel$.getValue().Working),s.Bb(1),s.jc("ngIf",t.boxmodelresultService.boxmodelresultPostModel$.getValue().Working),s.Bb(6),s.jc("ngIf",t.boxmodelresultFormEdit.controls.BoxModelResultID.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.BoxModelID.errors),s.Bb(5),s.jc("ngForOf",t.boxModelResultTypeList),s.Bb(1),s.jc("ngIf",t.boxmodelresultFormEdit.controls.BoxModelResultType.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.Volume_m3.errors),s.Bb(6),s.jc("ngIf",t.boxmodelresultFormEdit.controls.Surface_m2.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.Radius_m.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.LeftSideDiameterLineAngle_deg.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.CircleCenterLatitude.errors),s.Bb(6),s.jc("ngIf",t.boxmodelresultFormEdit.controls.CircleCenterLongitude.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.FixLength.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.FixWidth.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.RectLength_m.errors),s.Bb(6),s.jc("ngIf",t.boxmodelresultFormEdit.controls.RectWidth_m.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.LeftSideLineAngle_deg.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.LeftSideLineStartLatitude.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.LeftSideLineStartLongitude.errors),s.Bb(6),s.jc("ngIf",t.boxmodelresultFormEdit.controls.LastUpdateDate_UTC.errors),s.Bb(5),s.jc("ngIf",t.boxmodelresultFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[g.q,g.l,g.f,S.b,n.l,B.c,B.f,y.b,g.n,g.c,g.k,g.e,I.a,n.k,T.a,B.b,L.n],pipes:[n.f],styles:[""],changeDetection:0}),e})();function Me(e,t){1&e&&s.Ob(0,"mat-progress-bar",4)}function Ce(e,t){1&e&&s.Ob(0,"mat-progress-bar",4)}function De(e,t){if(1&e&&(s.Tb(0,"p"),s.Ob(1,"app-boxmodelresult-edit",8),s.Sb()),2&e){const e=s.ec().$implicit,t=s.ec(2);s.Bb(1),s.jc("boxmodelresult",e)("httpClientCommand",t.GetPutEnum())}}function je(e,t){if(1&e&&(s.Tb(0,"p"),s.Ob(1,"app-boxmodelresult-edit",8),s.Sb()),2&e){const e=s.ec().$implicit,t=s.ec(2);s.Bb(1),s.jc("boxmodelresult",e)("httpClientCommand",t.GetPostEnum())}}function Oe(e,t){if(1&e){const e=s.Ub();s.Tb(0,"div"),s.Tb(1,"p"),s.Tb(2,"button",6),s.ac("click",(function(){s.rc(e);const o=t.$implicit;return s.ec(2).DeleteBoxModelResult(o)})),s.Tb(3,"span"),s.yc(4),s.Sb(),s.Tb(5,"mat-icon"),s.yc(6,"delete"),s.Sb(),s.Sb(),s.yc(7,"\xa0\xa0\xa0 "),s.Tb(8,"button",7),s.ac("click",(function(){s.rc(e);const o=t.$implicit;return s.ec(2).ShowPut(o)})),s.Tb(9,"span"),s.yc(10,"Show Put"),s.Sb(),s.Sb(),s.yc(11,"\xa0\xa0 "),s.Tb(12,"button",7),s.ac("click",(function(){s.rc(e);const o=t.$implicit;return s.ec(2).ShowPost(o)})),s.Tb(13,"span"),s.yc(14,"Show Post"),s.Sb(),s.Sb(),s.yc(15,"\xa0\xa0 "),s.xc(16,Ce,1,0,"mat-progress-bar",0),s.Sb(),s.xc(17,De,2,2,"p",2),s.xc(18,je,2,2,"p",2),s.Tb(19,"blockquote"),s.Tb(20,"p"),s.Tb(21,"span"),s.yc(22),s.Sb(),s.Tb(23,"span"),s.yc(24),s.Sb(),s.Tb(25,"span"),s.yc(26),s.Sb(),s.Tb(27,"span"),s.yc(28),s.Sb(),s.Sb(),s.Tb(29,"p"),s.Tb(30,"span"),s.yc(31),s.Sb(),s.Tb(32,"span"),s.yc(33),s.Sb(),s.Tb(34,"span"),s.yc(35),s.Sb(),s.Tb(36,"span"),s.yc(37),s.Sb(),s.Sb(),s.Tb(38,"p"),s.Tb(39,"span"),s.yc(40),s.Sb(),s.Tb(41,"span"),s.yc(42),s.Sb(),s.Tb(43,"span"),s.yc(44),s.Sb(),s.Tb(45,"span"),s.yc(46),s.Sb(),s.Sb(),s.Tb(47,"p"),s.Tb(48,"span"),s.yc(49),s.Sb(),s.Tb(50,"span"),s.yc(51),s.Sb(),s.Tb(52,"span"),s.yc(53),s.Sb(),s.Tb(54,"span"),s.yc(55),s.Sb(),s.Sb(),s.Tb(56,"p"),s.Tb(57,"span"),s.yc(58),s.Sb(),s.Tb(59,"span"),s.yc(60),s.Sb(),s.Sb(),s.Sb(),s.Sb()}if(2&e){const e=t.$implicit,o=s.ec(2);s.Bb(4),s.Ac("Delete BoxModelResultID [",e.BoxModelResultID,"]\xa0\xa0\xa0"),s.Bb(4),s.jc("color",o.GetPutButtonColor(e)),s.Bb(4),s.jc("color",o.GetPostButtonColor(e)),s.Bb(4),s.jc("ngIf",o.boxmodelresultService.boxmodelresultDeleteModel$.getValue().Working),s.Bb(1),s.jc("ngIf",o.IDToShow===e.BoxModelResultID&&o.showType===o.GetPutEnum()),s.Bb(1),s.jc("ngIf",o.IDToShow===e.BoxModelResultID&&o.showType===o.GetPostEnum()),s.Bb(4),s.Ac("BoxModelResultID: [",e.BoxModelResultID,"]"),s.Bb(2),s.Ac(" --- BoxModelID: [",e.BoxModelID,"]"),s.Bb(2),s.Ac(" --- BoxModelResultType: [",o.GetBoxModelResultTypeEnumText(e.BoxModelResultType),"]"),s.Bb(2),s.Ac(" --- Volume_m3: [",e.Volume_m3,"]"),s.Bb(3),s.Ac("Surface_m2: [",e.Surface_m2,"]"),s.Bb(2),s.Ac(" --- Radius_m: [",e.Radius_m,"]"),s.Bb(2),s.Ac(" --- LeftSideDiameterLineAngle_deg: [",e.LeftSideDiameterLineAngle_deg,"]"),s.Bb(2),s.Ac(" --- CircleCenterLatitude: [",e.CircleCenterLatitude,"]"),s.Bb(3),s.Ac("CircleCenterLongitude: [",e.CircleCenterLongitude,"]"),s.Bb(2),s.Ac(" --- FixLength: [",e.FixLength,"]"),s.Bb(2),s.Ac(" --- FixWidth: [",e.FixWidth,"]"),s.Bb(2),s.Ac(" --- RectLength_m: [",e.RectLength_m,"]"),s.Bb(3),s.Ac("RectWidth_m: [",e.RectWidth_m,"]"),s.Bb(2),s.Ac(" --- LeftSideLineAngle_deg: [",e.LeftSideLineAngle_deg,"]"),s.Bb(2),s.Ac(" --- LeftSideLineStartLatitude: [",e.LeftSideLineStartLatitude,"]"),s.Bb(2),s.Ac(" --- LeftSideLineStartLongitude: [",e.LeftSideLineStartLongitude,"]"),s.Bb(3),s.Ac("LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),s.Bb(2),s.Ac(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function Re(e,t){if(1&e&&(s.Tb(0,"div"),s.xc(1,Oe,61,24,"div",5),s.Sb()),2&e){const e=s.ec();s.Bb(1),s.jc("ngForOf",e.boxmodelresultService.boxmodelresultListModel$.getValue())}}const ve=[{path:"",component:(()=>{class e{constructor(e,t,o){this.boxmodelresultService=e,this.router=t,this.httpClientService=o,this.showType=null,o.oldURL=t.url}GetPutButtonColor(e){return this.IDToShow===e.BoxModelResultID&&this.showType===l.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.BoxModelResultID&&this.showType===l.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.BoxModelResultID&&this.showType===l.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.BoxModelResultID,this.showType=l.a.Put)}ShowPost(e){this.IDToShow===e.BoxModelResultID&&this.showType===l.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.BoxModelResultID,this.showType=l.a.Post)}GetPutEnum(){return l.a.Put}GetPostEnum(){return l.a.Post}GetBoxModelResultList(){this.sub=this.boxmodelresultService.GetBoxModelResultList().subscribe()}DeleteBoxModelResult(e){this.sub=this.boxmodelresultService.DeleteBoxModelResult(e).subscribe()}GetBoxModelResultTypeEnumText(e){return function(e){let t;return b().forEach(o=>{if(o.EnumID==e)return t=o.EnumText,!1}),t}(e)}ngOnInit(){i(this.boxmodelresultService.boxmodelresultTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(t){return new(t||e)(s.Nb(f),s.Nb(r.b),s.Nb(p.a))},e.\u0275cmp=s.Hb({type:e,selectors:[["app-boxmodelresult"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"boxmodelresult","httpClientCommand"]],template:function(e,t){if(1&e&&(s.xc(0,Me,1,0,"mat-progress-bar",0),s.Tb(1,"mat-card"),s.Tb(2,"mat-card-header"),s.Tb(3,"mat-card-title"),s.yc(4," BoxModelResult works! "),s.Tb(5,"button",1),s.ac("click",(function(){return t.GetBoxModelResultList()})),s.Tb(6,"span"),s.yc(7,"Get BoxModelResult"),s.Sb(),s.Sb(),s.Sb(),s.Tb(8,"mat-card-subtitle"),s.yc(9),s.Sb(),s.Sb(),s.Tb(10,"mat-card-content"),s.xc(11,Re,2,1,"div",2),s.Sb(),s.Tb(12,"mat-card-actions"),s.Tb(13,"button",3),s.yc(14,"Allo"),s.Sb(),s.Sb(),s.Sb()),2&e){var o;const e=null==(o=t.boxmodelresultService.boxmodelresultGetModel$.getValue())?null:o.Working;var n;const r=null==(n=t.boxmodelresultService.boxmodelresultListModel$.getValue())?null:n.length;s.jc("ngIf",e),s.Bb(9),s.zc(t.boxmodelresultService.boxmodelresultTextModel$.getValue().Title),s.Bb(2),s.jc("ngIf",r)}},directives:[n.l,x.a,x.d,x.g,S.b,x.f,x.c,x.b,T.a,n.k,h.a,Le],styles:[""],changeDetection:0}),e})(),canActivate:[o("auXs").a]}];let Ee=(()=>{class e{}return e.\u0275mod=s.Lb({type:e}),e.\u0275inj=s.Kb({factory:function(t){return new(t||e)},imports:[[r.e.forChild(ve)],r.e]}),e})();var Pe=o("B+Mi");let $e=(()=>{class e{}return e.\u0275mod=s.Lb({type:e}),e.\u0275inj=s.Kb({factory:function(t){return new(t||e)},imports:[[n.c,r.e,Ee,Pe.a,g.g,g.o]]}),e})()},QRvi:function(e,t,o){"use strict";o.d(t,"a",(function(){return n}));var n=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,o){"use strict";o.d(t,"a",(function(){return b}));var n=o("QRvi"),r=o("fXoL"),i=o("tyNb");let b=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,t,o){e.next(null),t.next({Working:!1,Error:o,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,t,o,r,i){if(r===n.a.Get&&e.next(o),r===n.a.Put&&(e.getValue()[0]=o),r===n.a.Post&&e.getValue().push(o),r===n.a.Delete){const t=e.getValue().indexOf(i);e.getValue().splice(t,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(t){return new(t||e)(r.Xb(i.b))},e.\u0275prov=r.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()}}]);