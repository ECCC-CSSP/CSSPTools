(window.webpackJsonp=window.webpackJsonp||[]).push([[58],{QRvi:function(e,i,t){"use strict";t.d(i,"a",(function(){return n}));var n=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,i,t){"use strict";t.d(i,"a",(function(){return c}));var n=t("QRvi"),r=t("fXoL"),a=t("tyNb");let c=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,i,t){e.next(null),i.next({Working:!1,Error:t,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(e,i,t){e.next(null),i.next({Working:!1,Error:t,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,i,t,r,a){if(r===n.a.Get&&e.next(t),r===n.a.Put&&(e.getValue()[0]=t),r===n.a.Post&&e.getValue().push(t),r===n.a.Delete){const i=e.getValue().indexOf(a);e.getValue().splice(i,1)}e.next(e.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(e,i,t,r,a){r===n.a.Get&&e.next(t),e.next(e.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(i){return new(i||e)(r.Wb(a.b))},e.\u0275prov=r.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()},kmbE:function(e,i,t){"use strict";t.r(i),t.d(i,"MikeScenarioModule",(function(){return li}));var n=t("ofXK"),r=t("tyNb");function a(e){let i={Title:"The title"};"fr-CA"===$localize.locale&&(i.Title="Le Titre"),e.next(i)}var c=t("s4a4"),o=t("QRvi"),b=t("fXoL"),s=t("2Vo4"),m=t("LRne"),u=t("tk/3"),l=t("lJxs"),p=t("JIr8"),S=t("gkM4");let f=(()=>{class e{constructor(e,i){this.httpClient=e,this.httpClientService=i,this.mikescenarioTextModel$=new s.a({}),this.mikescenarioListModel$=new s.a({}),this.mikescenarioGetModel$=new s.a({}),this.mikescenarioPutModel$=new s.a({}),this.mikescenarioPostModel$=new s.a({}),this.mikescenarioDeleteModel$=new s.a({}),a(this.mikescenarioTextModel$),this.mikescenarioTextModel$.next({Title:"Something2 for text"})}GetMikeScenarioList(){return this.httpClientService.BeforeHttpClient(this.mikescenarioGetModel$),this.httpClient.get("/api/MikeScenario").pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.mikescenarioListModel$,this.mikescenarioGetModel$,e,o.a.Get,null)}),Object(p.a)(e=>Object(m.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.mikescenarioListModel$,this.mikescenarioGetModel$,e)}))))}PutMikeScenario(e){return this.httpClientService.BeforeHttpClient(this.mikescenarioPutModel$),this.httpClient.put("/api/MikeScenario",e,{headers:new u.d}).pipe(Object(l.a)(i=>{this.httpClientService.DoSuccess(this.mikescenarioListModel$,this.mikescenarioPutModel$,i,o.a.Put,e)}),Object(p.a)(e=>Object(m.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.mikescenarioListModel$,this.mikescenarioPutModel$,e)}))))}PostMikeScenario(e){return this.httpClientService.BeforeHttpClient(this.mikescenarioPostModel$),this.httpClient.post("/api/MikeScenario",e,{headers:new u.d}).pipe(Object(l.a)(i=>{this.httpClientService.DoSuccess(this.mikescenarioListModel$,this.mikescenarioPostModel$,i,o.a.Post,e)}),Object(p.a)(e=>Object(m.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.mikescenarioListModel$,this.mikescenarioPostModel$,e)}))))}DeleteMikeScenario(e){return this.httpClientService.BeforeHttpClient(this.mikescenarioDeleteModel$),this.httpClient.delete("/api/MikeScenario/"+e.MikeScenarioID).pipe(Object(l.a)(i=>{this.httpClientService.DoSuccess(this.mikescenarioListModel$,this.mikescenarioDeleteModel$,i,o.a.Delete,e)}),Object(p.a)(e=>Object(m.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.mikescenarioListModel$,this.mikescenarioDeleteModel$,e)}))))}}return e.\u0275fac=function(i){return new(i||e)(b.Wb(u.b),b.Wb(S.a))},e.\u0275prov=b.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var d=t("Wp6s"),R=t("bTqV"),I=t("bv9b"),k=t("NFeN"),y=t("3Pt+"),h=t("kmnG"),B=t("qFsG"),N=t("d3UM"),g=t("FKr1");function M(e,i){1&e&&b.Nb(0,"mat-progress-bar",37)}function z(e,i){1&e&&b.Nb(0,"mat-progress-bar",37)}function D(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function T(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,D,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,2,e)),b.Bb(3),b.ic("ngIf",e.required)}}function C(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function F(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,C,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,2,e)),b.Bb(3),b.ic("ngIf",e.required)}}function E(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,1,e))}}function v(e,i){if(1&e&&(b.Sb(0,"mat-option",38),b.zc(1),b.Rb()),2&e){const e=i.$implicit;b.ic("value",e.EnumID),b.Bb(1),b.Bc(" ",e.EnumText," ")}}function _(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function P(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,_,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,2,e)),b.Bb(3),b.ic("ngIf",e.required)}}function O(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,1,e))}}function x(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function $(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,x,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,2,e)),b.Bb(3),b.ic("ngIf",e.required)}}function L(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function A(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,L,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,2,e)),b.Bb(3),b.ic("ngIf",e.required)}}function q(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,1,e))}}function j(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function V(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100000"),b.Nb(2,"br"),b.Rb())}function w(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,j,3,0,"span",4),b.yc(6,V,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,3,e)),b.Bb(3),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function U(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function G(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function W(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function H(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,U,3,0,"span",4),b.yc(6,G,3,0,"span",4),b.yc(7,W,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,4,e)),b.Bb(3),b.ic("ngIf",e.required),b.Bb(1),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function Z(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Q(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function J(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 360"),b.Nb(2,"br"),b.Rb())}function K(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Z,3,0,"span",4),b.yc(6,Q,3,0,"span",4),b.yc(7,J,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,4,e)),b.Bb(3),b.ic("ngIf",e.required),b.Bb(1),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function X(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Y(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function ee(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function ie(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,X,3,0,"span",4),b.yc(6,Y,3,0,"span",4),b.yc(7,ee,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,4,e)),b.Bb(3),b.ic("ngIf",e.required),b.Bb(1),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function te(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function ne(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,te,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,2,e)),b.Bb(3),b.ic("ngIf",e.required)}}function re(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function ae(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function ce(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function oe(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,re,3,0,"span",4),b.yc(6,ae,3,0,"span",4),b.yc(7,ce,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,4,e)),b.Bb(3),b.ic("ngIf",e.required),b.Bb(1),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function be(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function se(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function me(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function ue(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,be,3,0,"span",4),b.yc(6,se,3,0,"span",4),b.yc(7,me,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,4,e)),b.Bb(3),b.ic("ngIf",e.required),b.Bb(1),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function le(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function pe(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - -10"),b.Nb(2,"br"),b.Rb())}function Se(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 40"),b.Nb(2,"br"),b.Rb())}function fe(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,le,3,0,"span",4),b.yc(6,pe,3,0,"span",4),b.yc(7,Se,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,4,e)),b.Bb(3),b.ic("ngIf",e.required),b.Bb(1),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function de(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Re(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function Ie(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 40"),b.Nb(2,"br"),b.Rb())}function ke(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,de,3,0,"span",4),b.yc(6,Re,3,0,"span",4),b.yc(7,Ie,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,4,e)),b.Bb(3),b.ic("ngIf",e.required),b.Bb(1),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function ye(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,1,e))}}function he(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,1,e))}}function Be(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,1,e))}}function Ne(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,1,e))}}function ge(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Me(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function ze(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function De(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,ge,3,0,"span",4),b.yc(6,Me,3,0,"span",4),b.yc(7,ze,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,4,e)),b.Bb(3),b.ic("ngIf",e.required),b.Bb(1),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function Te(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function Ce(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 1000000"),b.Nb(2,"br"),b.Rb())}function Fe(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Te,3,0,"span",4),b.yc(6,Ce,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,3,e)),b.Bb(3),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function Ee(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 1"),b.Nb(2,"br"),b.Rb())}function ve(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 1000000"),b.Nb(2,"br"),b.Rb())}function _e(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Ee,3,0,"span",4),b.yc(6,ve,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,3,e)),b.Bb(3),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function Pe(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function Oe(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function xe(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Pe,3,0,"span",4),b.yc(6,Oe,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,3,e)),b.Bb(3),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function $e(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function Le(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function Ae(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,$e,3,0,"span",4),b.yc(6,Le,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,3,e)),b.Bb(3),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function qe(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function je(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function Ve(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,qe,3,0,"span",4),b.yc(6,je,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,3,e)),b.Bb(3),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function we(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function Ue(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function Ge(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,we,3,0,"span",4),b.yc(6,Ue,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,3,e)),b.Bb(3),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function We(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function He(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100000000"),b.Nb(2,"br"),b.Rb())}function Ze(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,We,3,0,"span",4),b.yc(6,He,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,3,e)),b.Bb(3),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function Qe(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function Je(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Max - 100000000"),b.Nb(2,"br"),b.Rb())}function Ke(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Qe,3,0,"span",4),b.yc(6,Je,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,3,e)),b.Bb(3),b.ic("ngIf",e.min),b.Bb(1),b.ic("ngIf",e.min)}}function Xe(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Ye(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,Xe,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,2,e)),b.Bb(3),b.ic("ngIf",e.required)}}function ei(e,i){1&e&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function ii(e,i){if(1&e&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,ei,3,0,"span",4),b.Rb()),2&e){const e=i.$implicit;b.Bb(2),b.Ac(b.fc(3,2,e)),b.Bb(3),b.ic("ngIf",e.required)}}let ti=(()=>{class e{constructor(e,i){this.mikescenarioService=e,this.fb=i,this.mikescenario=null,this.httpClientCommand=o.a.Put}GetPut(){return this.httpClientCommand==o.a.Put}PutMikeScenario(e){this.sub=this.mikescenarioService.PutMikeScenario(e).subscribe()}PostMikeScenario(e){this.sub=this.mikescenarioService.PostMikeScenario(e).subscribe()}ngOnInit(){this.scenarioStatusList=Object(c.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.mikescenario){let i=this.fb.group({MikeScenarioID:[{value:e===o.a.Post?0:this.mikescenario.MikeScenarioID,disabled:!1},[y.p.required]],MikeScenarioTVItemID:[{value:this.mikescenario.MikeScenarioTVItemID,disabled:!1},[y.p.required]],ParentMikeScenarioID:[{value:this.mikescenario.ParentMikeScenarioID,disabled:!1}],ScenarioStatus:[{value:this.mikescenario.ScenarioStatus,disabled:!1},[y.p.required]],ErrorInfo:[{value:this.mikescenario.ErrorInfo,disabled:!1}],MikeScenarioStartDateTime_Local:[{value:this.mikescenario.MikeScenarioStartDateTime_Local,disabled:!1},[y.p.required]],MikeScenarioEndDateTime_Local:[{value:this.mikescenario.MikeScenarioEndDateTime_Local,disabled:!1},[y.p.required]],MikeScenarioStartExecutionDateTime_Local:[{value:this.mikescenario.MikeScenarioStartExecutionDateTime_Local,disabled:!1}],MikeScenarioExecutionTime_min:[{value:this.mikescenario.MikeScenarioExecutionTime_min,disabled:!1},[y.p.min(1),y.p.max(1e5)]],WindSpeed_km_h:[{value:this.mikescenario.WindSpeed_km_h,disabled:!1},[y.p.required,y.p.min(0),y.p.max(100)]],WindDirection_deg:[{value:this.mikescenario.WindDirection_deg,disabled:!1},[y.p.required,y.p.min(0),y.p.max(360)]],DecayFactor_per_day:[{value:this.mikescenario.DecayFactor_per_day,disabled:!1},[y.p.required,y.p.min(0),y.p.max(100)]],DecayIsConstant:[{value:this.mikescenario.DecayIsConstant,disabled:!1},[y.p.required]],DecayFactorAmplitude:[{value:this.mikescenario.DecayFactorAmplitude,disabled:!1},[y.p.required,y.p.min(0),y.p.max(100)]],ResultFrequency_min:[{value:this.mikescenario.ResultFrequency_min,disabled:!1},[y.p.required,y.p.min(0),y.p.max(100)]],AmbientTemperature_C:[{value:this.mikescenario.AmbientTemperature_C,disabled:!1},[y.p.required,y.p.min(-10),y.p.max(40)]],AmbientSalinity_PSU:[{value:this.mikescenario.AmbientSalinity_PSU,disabled:!1},[y.p.required,y.p.min(0),y.p.max(40)]],GenerateDecouplingFiles:[{value:this.mikescenario.GenerateDecouplingFiles,disabled:!1}],UseDecouplingFiles:[{value:this.mikescenario.UseDecouplingFiles,disabled:!1}],UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID:[{value:this.mikescenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID,disabled:!1}],ForSimulatingMWQMRunTVItemID:[{value:this.mikescenario.ForSimulatingMWQMRunTVItemID,disabled:!1}],ManningNumber:[{value:this.mikescenario.ManningNumber,disabled:!1},[y.p.required,y.p.min(0),y.p.max(100)]],NumberOfElements:[{value:this.mikescenario.NumberOfElements,disabled:!1},[y.p.min(1),y.p.max(1e6)]],NumberOfTimeSteps:[{value:this.mikescenario.NumberOfTimeSteps,disabled:!1},[y.p.min(1),y.p.max(1e6)]],NumberOfSigmaLayers:[{value:this.mikescenario.NumberOfSigmaLayers,disabled:!1},[y.p.min(0),y.p.max(100)]],NumberOfZLayers:[{value:this.mikescenario.NumberOfZLayers,disabled:!1},[y.p.min(0),y.p.max(100)]],NumberOfHydroOutputParameters:[{value:this.mikescenario.NumberOfHydroOutputParameters,disabled:!1},[y.p.min(0),y.p.max(100)]],NumberOfTransOutputParameters:[{value:this.mikescenario.NumberOfTransOutputParameters,disabled:!1},[y.p.min(0),y.p.max(100)]],EstimatedHydroFileSize:[{value:this.mikescenario.EstimatedHydroFileSize,disabled:!1},[y.p.min(0),y.p.max(1e8)]],EstimatedTransFileSize:[{value:this.mikescenario.EstimatedTransFileSize,disabled:!1},[y.p.min(0),y.p.max(1e8)]],LastUpdateDate_UTC:[{value:this.mikescenario.LastUpdateDate_UTC,disabled:!1},[y.p.required]],LastUpdateContactTVItemID:[{value:this.mikescenario.LastUpdateContactTVItemID,disabled:!1},[y.p.required]]});this.mikescenarioFormEdit=i}}}return e.\u0275fac=function(i){return new(i||e)(b.Mb(f),b.Mb(y.d))},e.\u0275cmp=b.Gb({type:e,selectors:[["app-mikescenario-edit"]],inputs:{mikescenario:"mikescenario",httpClientCommand:"httpClientCommand"},decls:177,vars:37,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","MikeScenarioID"],[4,"ngIf"],["matInput","","type","number","formControlName","MikeScenarioTVItemID"],["matInput","","type","number","formControlName","ParentMikeScenarioID"],["formControlName","ScenarioStatus"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","ErrorInfo"],["matInput","","type","text","formControlName","MikeScenarioStartDateTime_Local"],["matInput","","type","text","formControlName","MikeScenarioEndDateTime_Local"],["matInput","","type","text","formControlName","MikeScenarioStartExecutionDateTime_Local"],["matInput","","type","number","formControlName","MikeScenarioExecutionTime_min"],["matInput","","type","number","formControlName","WindSpeed_km_h"],["matInput","","type","number","formControlName","WindDirection_deg"],["matInput","","type","number","formControlName","DecayFactor_per_day"],["matInput","","type","text","formControlName","DecayIsConstant"],["matInput","","type","number","formControlName","DecayFactorAmplitude"],["matInput","","type","number","formControlName","ResultFrequency_min"],["matInput","","type","number","formControlName","AmbientTemperature_C"],["matInput","","type","number","formControlName","AmbientSalinity_PSU"],["matInput","","type","text","formControlName","GenerateDecouplingFiles"],["matInput","","type","text","formControlName","UseDecouplingFiles"],["matInput","","type","number","formControlName","UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID"],["matInput","","type","number","formControlName","ForSimulatingMWQMRunTVItemID"],["matInput","","type","number","formControlName","ManningNumber"],["matInput","","type","number","formControlName","NumberOfElements"],["matInput","","type","number","formControlName","NumberOfTimeSteps"],["matInput","","type","number","formControlName","NumberOfSigmaLayers"],["matInput","","type","number","formControlName","NumberOfZLayers"],["matInput","","type","number","formControlName","NumberOfHydroOutputParameters"],["matInput","","type","number","formControlName","NumberOfTransOutputParameters"],["matInput","","type","number","formControlName","EstimatedHydroFileSize"],["matInput","","type","number","formControlName","EstimatedTransFileSize"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,i){1&e&&(b.Sb(0,"form",0),b.Zb("ngSubmit",(function(){return i.GetPut()?i.PutMikeScenario(i.mikescenarioFormEdit.value):i.PostMikeScenario(i.mikescenarioFormEdit.value)})),b.Sb(1,"h3"),b.zc(2," MikeScenario "),b.Sb(3,"button",1),b.Sb(4,"span"),b.zc(5),b.Rb(),b.Rb(),b.yc(6,M,1,0,"mat-progress-bar",2),b.yc(7,z,1,0,"mat-progress-bar",2),b.Rb(),b.Sb(8,"p"),b.Sb(9,"mat-form-field"),b.Sb(10,"mat-label"),b.zc(11,"MikeScenarioID"),b.Rb(),b.Nb(12,"input",3),b.yc(13,T,6,4,"mat-error",4),b.Rb(),b.Sb(14,"mat-form-field"),b.Sb(15,"mat-label"),b.zc(16,"MikeScenarioTVItemID"),b.Rb(),b.Nb(17,"input",5),b.yc(18,F,6,4,"mat-error",4),b.Rb(),b.Sb(19,"mat-form-field"),b.Sb(20,"mat-label"),b.zc(21,"ParentMikeScenarioID"),b.Rb(),b.Nb(22,"input",6),b.yc(23,E,5,3,"mat-error",4),b.Rb(),b.Sb(24,"mat-form-field"),b.Sb(25,"mat-label"),b.zc(26,"ScenarioStatus"),b.Rb(),b.Sb(27,"mat-select",7),b.yc(28,v,2,2,"mat-option",8),b.Rb(),b.yc(29,P,6,4,"mat-error",4),b.Rb(),b.Rb(),b.Sb(30,"p"),b.Sb(31,"mat-form-field"),b.Sb(32,"mat-label"),b.zc(33,"ErrorInfo"),b.Rb(),b.Nb(34,"input",9),b.yc(35,O,5,3,"mat-error",4),b.Rb(),b.Sb(36,"mat-form-field"),b.Sb(37,"mat-label"),b.zc(38,"MikeScenarioStartDateTime_Local"),b.Rb(),b.Nb(39,"input",10),b.yc(40,$,6,4,"mat-error",4),b.Rb(),b.Sb(41,"mat-form-field"),b.Sb(42,"mat-label"),b.zc(43,"MikeScenarioEndDateTime_Local"),b.Rb(),b.Nb(44,"input",11),b.yc(45,A,6,4,"mat-error",4),b.Rb(),b.Sb(46,"mat-form-field"),b.Sb(47,"mat-label"),b.zc(48,"MikeScenarioStartExecutionDateTime_Local"),b.Rb(),b.Nb(49,"input",12),b.yc(50,q,5,3,"mat-error",4),b.Rb(),b.Rb(),b.Sb(51,"p"),b.Sb(52,"mat-form-field"),b.Sb(53,"mat-label"),b.zc(54,"MikeScenarioExecutionTime_min"),b.Rb(),b.Nb(55,"input",13),b.yc(56,w,7,5,"mat-error",4),b.Rb(),b.Sb(57,"mat-form-field"),b.Sb(58,"mat-label"),b.zc(59,"WindSpeed_km_h"),b.Rb(),b.Nb(60,"input",14),b.yc(61,H,8,6,"mat-error",4),b.Rb(),b.Sb(62,"mat-form-field"),b.Sb(63,"mat-label"),b.zc(64,"WindDirection_deg"),b.Rb(),b.Nb(65,"input",15),b.yc(66,K,8,6,"mat-error",4),b.Rb(),b.Sb(67,"mat-form-field"),b.Sb(68,"mat-label"),b.zc(69,"DecayFactor_per_day"),b.Rb(),b.Nb(70,"input",16),b.yc(71,ie,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(72,"p"),b.Sb(73,"mat-form-field"),b.Sb(74,"mat-label"),b.zc(75,"DecayIsConstant"),b.Rb(),b.Nb(76,"input",17),b.yc(77,ne,6,4,"mat-error",4),b.Rb(),b.Sb(78,"mat-form-field"),b.Sb(79,"mat-label"),b.zc(80,"DecayFactorAmplitude"),b.Rb(),b.Nb(81,"input",18),b.yc(82,oe,8,6,"mat-error",4),b.Rb(),b.Sb(83,"mat-form-field"),b.Sb(84,"mat-label"),b.zc(85,"ResultFrequency_min"),b.Rb(),b.Nb(86,"input",19),b.yc(87,ue,8,6,"mat-error",4),b.Rb(),b.Sb(88,"mat-form-field"),b.Sb(89,"mat-label"),b.zc(90,"AmbientTemperature_C"),b.Rb(),b.Nb(91,"input",20),b.yc(92,fe,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(93,"p"),b.Sb(94,"mat-form-field"),b.Sb(95,"mat-label"),b.zc(96,"AmbientSalinity_PSU"),b.Rb(),b.Nb(97,"input",21),b.yc(98,ke,8,6,"mat-error",4),b.Rb(),b.Sb(99,"mat-form-field"),b.Sb(100,"mat-label"),b.zc(101,"GenerateDecouplingFiles"),b.Rb(),b.Nb(102,"input",22),b.yc(103,ye,5,3,"mat-error",4),b.Rb(),b.Sb(104,"mat-form-field"),b.Sb(105,"mat-label"),b.zc(106,"UseDecouplingFiles"),b.Rb(),b.Nb(107,"input",23),b.yc(108,he,5,3,"mat-error",4),b.Rb(),b.Sb(109,"mat-form-field"),b.Sb(110,"mat-label"),b.zc(111,"UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID"),b.Rb(),b.Nb(112,"input",24),b.yc(113,Be,5,3,"mat-error",4),b.Rb(),b.Rb(),b.Sb(114,"p"),b.Sb(115,"mat-form-field"),b.Sb(116,"mat-label"),b.zc(117,"ForSimulatingMWQMRunTVItemID"),b.Rb(),b.Nb(118,"input",25),b.yc(119,Ne,5,3,"mat-error",4),b.Rb(),b.Sb(120,"mat-form-field"),b.Sb(121,"mat-label"),b.zc(122,"ManningNumber"),b.Rb(),b.Nb(123,"input",26),b.yc(124,De,8,6,"mat-error",4),b.Rb(),b.Sb(125,"mat-form-field"),b.Sb(126,"mat-label"),b.zc(127,"NumberOfElements"),b.Rb(),b.Nb(128,"input",27),b.yc(129,Fe,7,5,"mat-error",4),b.Rb(),b.Sb(130,"mat-form-field"),b.Sb(131,"mat-label"),b.zc(132,"NumberOfTimeSteps"),b.Rb(),b.Nb(133,"input",28),b.yc(134,_e,7,5,"mat-error",4),b.Rb(),b.Rb(),b.Sb(135,"p"),b.Sb(136,"mat-form-field"),b.Sb(137,"mat-label"),b.zc(138,"NumberOfSigmaLayers"),b.Rb(),b.Nb(139,"input",29),b.yc(140,xe,7,5,"mat-error",4),b.Rb(),b.Sb(141,"mat-form-field"),b.Sb(142,"mat-label"),b.zc(143,"NumberOfZLayers"),b.Rb(),b.Nb(144,"input",30),b.yc(145,Ae,7,5,"mat-error",4),b.Rb(),b.Sb(146,"mat-form-field"),b.Sb(147,"mat-label"),b.zc(148,"NumberOfHydroOutputParameters"),b.Rb(),b.Nb(149,"input",31),b.yc(150,Ve,7,5,"mat-error",4),b.Rb(),b.Sb(151,"mat-form-field"),b.Sb(152,"mat-label"),b.zc(153,"NumberOfTransOutputParameters"),b.Rb(),b.Nb(154,"input",32),b.yc(155,Ge,7,5,"mat-error",4),b.Rb(),b.Rb(),b.Sb(156,"p"),b.Sb(157,"mat-form-field"),b.Sb(158,"mat-label"),b.zc(159,"EstimatedHydroFileSize"),b.Rb(),b.Nb(160,"input",33),b.yc(161,Ze,7,5,"mat-error",4),b.Rb(),b.Sb(162,"mat-form-field"),b.Sb(163,"mat-label"),b.zc(164,"EstimatedTransFileSize"),b.Rb(),b.Nb(165,"input",34),b.yc(166,Ke,7,5,"mat-error",4),b.Rb(),b.Sb(167,"mat-form-field"),b.Sb(168,"mat-label"),b.zc(169,"LastUpdateDate_UTC"),b.Rb(),b.Nb(170,"input",35),b.yc(171,Ye,6,4,"mat-error",4),b.Rb(),b.Sb(172,"mat-form-field"),b.Sb(173,"mat-label"),b.zc(174,"LastUpdateContactTVItemID"),b.Rb(),b.Nb(175,"input",36),b.yc(176,ii,6,4,"mat-error",4),b.Rb(),b.Rb(),b.Rb()),2&e&&(b.ic("formGroup",i.mikescenarioFormEdit),b.Bb(5),b.Bc("",i.GetPut()?"Put":"Post"," MikeScenario"),b.Bb(1),b.ic("ngIf",i.mikescenarioService.mikescenarioPutModel$.getValue().Working),b.Bb(1),b.ic("ngIf",i.mikescenarioService.mikescenarioPostModel$.getValue().Working),b.Bb(6),b.ic("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioID.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioTVItemID.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.ParentMikeScenarioID.errors),b.Bb(5),b.ic("ngForOf",i.scenarioStatusList),b.Bb(1),b.ic("ngIf",i.mikescenarioFormEdit.controls.ScenarioStatus.errors),b.Bb(6),b.ic("ngIf",i.mikescenarioFormEdit.controls.ErrorInfo.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioStartDateTime_Local.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioEndDateTime_Local.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioStartExecutionDateTime_Local.errors),b.Bb(6),b.ic("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioExecutionTime_min.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.WindSpeed_km_h.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.WindDirection_deg.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.DecayFactor_per_day.errors),b.Bb(6),b.ic("ngIf",i.mikescenarioFormEdit.controls.DecayIsConstant.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.DecayFactorAmplitude.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.ResultFrequency_min.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.AmbientTemperature_C.errors),b.Bb(6),b.ic("ngIf",i.mikescenarioFormEdit.controls.AmbientSalinity_PSU.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.GenerateDecouplingFiles.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.UseDecouplingFiles.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID.errors),b.Bb(6),b.ic("ngIf",i.mikescenarioFormEdit.controls.ForSimulatingMWQMRunTVItemID.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.ManningNumber.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.NumberOfElements.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.NumberOfTimeSteps.errors),b.Bb(6),b.ic("ngIf",i.mikescenarioFormEdit.controls.NumberOfSigmaLayers.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.NumberOfZLayers.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.NumberOfHydroOutputParameters.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.NumberOfTransOutputParameters.errors),b.Bb(6),b.ic("ngIf",i.mikescenarioFormEdit.controls.EstimatedHydroFileSize.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.EstimatedTransFileSize.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(5),b.ic("ngIf",i.mikescenarioFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[y.q,y.l,y.f,R.b,n.l,h.c,h.f,B.b,y.n,y.c,y.k,y.e,N.a,n.k,I.a,h.b,g.n],pipes:[n.f],styles:[""],changeDetection:0}),e})();function ni(e,i){1&e&&b.Nb(0,"mat-progress-bar",4)}function ri(e,i){1&e&&b.Nb(0,"mat-progress-bar",4)}function ai(e,i){if(1&e&&(b.Sb(0,"p"),b.Nb(1,"app-mikescenario-edit",8),b.Rb()),2&e){const e=b.dc().$implicit,i=b.dc(2);b.Bb(1),b.ic("mikescenario",e)("httpClientCommand",i.GetPutEnum())}}function ci(e,i){if(1&e&&(b.Sb(0,"p"),b.Nb(1,"app-mikescenario-edit",8),b.Rb()),2&e){const e=b.dc().$implicit,i=b.dc(2);b.Bb(1),b.ic("mikescenario",e)("httpClientCommand",i.GetPostEnum())}}function oi(e,i){if(1&e){const e=b.Tb();b.Sb(0,"div"),b.Sb(1,"p"),b.Sb(2,"button",6),b.Zb("click",(function(){b.qc(e);const t=i.$implicit;return b.dc(2).DeleteMikeScenario(t)})),b.Sb(3,"span"),b.zc(4),b.Rb(),b.Sb(5,"mat-icon"),b.zc(6,"delete"),b.Rb(),b.Rb(),b.zc(7,"\xa0\xa0\xa0 "),b.Sb(8,"button",7),b.Zb("click",(function(){b.qc(e);const t=i.$implicit;return b.dc(2).ShowPut(t)})),b.Sb(9,"span"),b.zc(10,"Show Put"),b.Rb(),b.Rb(),b.zc(11,"\xa0\xa0 "),b.Sb(12,"button",7),b.Zb("click",(function(){b.qc(e);const t=i.$implicit;return b.dc(2).ShowPost(t)})),b.Sb(13,"span"),b.zc(14,"Show Post"),b.Rb(),b.Rb(),b.zc(15,"\xa0\xa0 "),b.yc(16,ri,1,0,"mat-progress-bar",0),b.Rb(),b.yc(17,ai,2,2,"p",2),b.yc(18,ci,2,2,"p",2),b.Sb(19,"blockquote"),b.Sb(20,"p"),b.Sb(21,"span"),b.zc(22),b.Rb(),b.Sb(23,"span"),b.zc(24),b.Rb(),b.Sb(25,"span"),b.zc(26),b.Rb(),b.Sb(27,"span"),b.zc(28),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"span"),b.zc(31),b.Rb(),b.Sb(32,"span"),b.zc(33),b.Rb(),b.Sb(34,"span"),b.zc(35),b.Rb(),b.Sb(36,"span"),b.zc(37),b.Rb(),b.Rb(),b.Sb(38,"p"),b.Sb(39,"span"),b.zc(40),b.Rb(),b.Sb(41,"span"),b.zc(42),b.Rb(),b.Sb(43,"span"),b.zc(44),b.Rb(),b.Sb(45,"span"),b.zc(46),b.Rb(),b.Rb(),b.Sb(47,"p"),b.Sb(48,"span"),b.zc(49),b.Rb(),b.Sb(50,"span"),b.zc(51),b.Rb(),b.Sb(52,"span"),b.zc(53),b.Rb(),b.Sb(54,"span"),b.zc(55),b.Rb(),b.Rb(),b.Sb(56,"p"),b.Sb(57,"span"),b.zc(58),b.Rb(),b.Sb(59,"span"),b.zc(60),b.Rb(),b.Sb(61,"span"),b.zc(62),b.Rb(),b.Sb(63,"span"),b.zc(64),b.Rb(),b.Rb(),b.Sb(65,"p"),b.Sb(66,"span"),b.zc(67),b.Rb(),b.Sb(68,"span"),b.zc(69),b.Rb(),b.Sb(70,"span"),b.zc(71),b.Rb(),b.Sb(72,"span"),b.zc(73),b.Rb(),b.Rb(),b.Sb(74,"p"),b.Sb(75,"span"),b.zc(76),b.Rb(),b.Sb(77,"span"),b.zc(78),b.Rb(),b.Sb(79,"span"),b.zc(80),b.Rb(),b.Sb(81,"span"),b.zc(82),b.Rb(),b.Rb(),b.Sb(83,"p"),b.Sb(84,"span"),b.zc(85),b.Rb(),b.Sb(86,"span"),b.zc(87),b.Rb(),b.Sb(88,"span"),b.zc(89),b.Rb(),b.Sb(90,"span"),b.zc(91),b.Rb(),b.Rb(),b.Rb(),b.Rb()}if(2&e){const e=i.$implicit,t=b.dc(2);b.Bb(4),b.Bc("Delete MikeScenarioID [",e.MikeScenarioID,"]\xa0\xa0\xa0"),b.Bb(4),b.ic("color",t.GetPutButtonColor(e)),b.Bb(4),b.ic("color",t.GetPostButtonColor(e)),b.Bb(4),b.ic("ngIf",t.mikescenarioService.mikescenarioDeleteModel$.getValue().Working),b.Bb(1),b.ic("ngIf",t.IDToShow===e.MikeScenarioID&&t.showType===t.GetPutEnum()),b.Bb(1),b.ic("ngIf",t.IDToShow===e.MikeScenarioID&&t.showType===t.GetPostEnum()),b.Bb(4),b.Bc("MikeScenarioID: [",e.MikeScenarioID,"]"),b.Bb(2),b.Bc(" --- MikeScenarioTVItemID: [",e.MikeScenarioTVItemID,"]"),b.Bb(2),b.Bc(" --- ParentMikeScenarioID: [",e.ParentMikeScenarioID,"]"),b.Bb(2),b.Bc(" --- ScenarioStatus: [",t.GetScenarioStatusEnumText(e.ScenarioStatus),"]"),b.Bb(3),b.Bc("ErrorInfo: [",e.ErrorInfo,"]"),b.Bb(2),b.Bc(" --- MikeScenarioStartDateTime_Local: [",e.MikeScenarioStartDateTime_Local,"]"),b.Bb(2),b.Bc(" --- MikeScenarioEndDateTime_Local: [",e.MikeScenarioEndDateTime_Local,"]"),b.Bb(2),b.Bc(" --- MikeScenarioStartExecutionDateTime_Local: [",e.MikeScenarioStartExecutionDateTime_Local,"]"),b.Bb(3),b.Bc("MikeScenarioExecutionTime_min: [",e.MikeScenarioExecutionTime_min,"]"),b.Bb(2),b.Bc(" --- WindSpeed_km_h: [",e.WindSpeed_km_h,"]"),b.Bb(2),b.Bc(" --- WindDirection_deg: [",e.WindDirection_deg,"]"),b.Bb(2),b.Bc(" --- DecayFactor_per_day: [",e.DecayFactor_per_day,"]"),b.Bb(3),b.Bc("DecayIsConstant: [",e.DecayIsConstant,"]"),b.Bb(2),b.Bc(" --- DecayFactorAmplitude: [",e.DecayFactorAmplitude,"]"),b.Bb(2),b.Bc(" --- ResultFrequency_min: [",e.ResultFrequency_min,"]"),b.Bb(2),b.Bc(" --- AmbientTemperature_C: [",e.AmbientTemperature_C,"]"),b.Bb(3),b.Bc("AmbientSalinity_PSU: [",e.AmbientSalinity_PSU,"]"),b.Bb(2),b.Bc(" --- GenerateDecouplingFiles: [",e.GenerateDecouplingFiles,"]"),b.Bb(2),b.Bc(" --- UseDecouplingFiles: [",e.UseDecouplingFiles,"]"),b.Bb(2),b.Bc(" --- UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID: [",e.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID,"]"),b.Bb(3),b.Bc("ForSimulatingMWQMRunTVItemID: [",e.ForSimulatingMWQMRunTVItemID,"]"),b.Bb(2),b.Bc(" --- ManningNumber: [",e.ManningNumber,"]"),b.Bb(2),b.Bc(" --- NumberOfElements: [",e.NumberOfElements,"]"),b.Bb(2),b.Bc(" --- NumberOfTimeSteps: [",e.NumberOfTimeSteps,"]"),b.Bb(3),b.Bc("NumberOfSigmaLayers: [",e.NumberOfSigmaLayers,"]"),b.Bb(2),b.Bc(" --- NumberOfZLayers: [",e.NumberOfZLayers,"]"),b.Bb(2),b.Bc(" --- NumberOfHydroOutputParameters: [",e.NumberOfHydroOutputParameters,"]"),b.Bb(2),b.Bc(" --- NumberOfTransOutputParameters: [",e.NumberOfTransOutputParameters,"]"),b.Bb(3),b.Bc("EstimatedHydroFileSize: [",e.EstimatedHydroFileSize,"]"),b.Bb(2),b.Bc(" --- EstimatedTransFileSize: [",e.EstimatedTransFileSize,"]"),b.Bb(2),b.Bc(" --- LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),b.Bb(2),b.Bc(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function bi(e,i){if(1&e&&(b.Sb(0,"div"),b.yc(1,oi,92,38,"div",5),b.Rb()),2&e){const e=b.dc();b.Bb(1),b.ic("ngForOf",e.mikescenarioService.mikescenarioListModel$.getValue())}}const si=[{path:"",component:(()=>{class e{constructor(e,i,t){this.mikescenarioService=e,this.router=i,this.httpClientService=t,this.showType=null,t.oldURL=i.url}GetPutButtonColor(e){return this.IDToShow===e.MikeScenarioID&&this.showType===o.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.MikeScenarioID&&this.showType===o.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.MikeScenarioID&&this.showType===o.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.MikeScenarioID,this.showType=o.a.Put)}ShowPost(e){this.IDToShow===e.MikeScenarioID&&this.showType===o.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.MikeScenarioID,this.showType=o.a.Post)}GetPutEnum(){return o.a.Put}GetPostEnum(){return o.a.Post}GetMikeScenarioList(){this.sub=this.mikescenarioService.GetMikeScenarioList().subscribe()}DeleteMikeScenario(e){this.sub=this.mikescenarioService.DeleteMikeScenario(e).subscribe()}GetScenarioStatusEnumText(e){return Object(c.a)(e)}ngOnInit(){a(this.mikescenarioService.mikescenarioTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(i){return new(i||e)(b.Mb(f),b.Mb(r.b),b.Mb(S.a))},e.\u0275cmp=b.Gb({type:e,selectors:[["app-mikescenario"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"mikescenario","httpClientCommand"]],template:function(e,i){var t,n;1&e&&(b.yc(0,ni,1,0,"mat-progress-bar",0),b.Sb(1,"mat-card"),b.Sb(2,"mat-card-header"),b.Sb(3,"mat-card-title"),b.zc(4," MikeScenario works! "),b.Sb(5,"button",1),b.Zb("click",(function(){return i.GetMikeScenarioList()})),b.Sb(6,"span"),b.zc(7,"Get MikeScenario"),b.Rb(),b.Rb(),b.Rb(),b.Sb(8,"mat-card-subtitle"),b.zc(9),b.Rb(),b.Rb(),b.Sb(10,"mat-card-content"),b.yc(11,bi,2,1,"div",2),b.Rb(),b.Sb(12,"mat-card-actions"),b.Sb(13,"button",3),b.zc(14,"Allo"),b.Rb(),b.Rb(),b.Rb()),2&e&&(b.ic("ngIf",null==(t=i.mikescenarioService.mikescenarioGetModel$.getValue())?null:t.Working),b.Bb(9),b.Ac(i.mikescenarioService.mikescenarioTextModel$.getValue().Title),b.Bb(2),b.ic("ngIf",null==(n=i.mikescenarioService.mikescenarioListModel$.getValue())?null:n.length))},directives:[n.l,d.a,d.d,d.g,R.b,d.f,d.c,d.b,I.a,n.k,k.a,ti],styles:[""],changeDetection:0}),e})(),canActivate:[t("auXs").a]}];let mi=(()=>{class e{}return e.\u0275mod=b.Kb({type:e}),e.\u0275inj=b.Jb({factory:function(i){return new(i||e)},imports:[[r.e.forChild(si)],r.e]}),e})();var ui=t("B+Mi");let li=(()=>{class e{}return e.\u0275mod=b.Kb({type:e}),e.\u0275inj=b.Jb({factory:function(i){return new(i||e)},imports:[[n.c,r.e,mi,ui.a,y.g,y.o]]}),e})()}}]);