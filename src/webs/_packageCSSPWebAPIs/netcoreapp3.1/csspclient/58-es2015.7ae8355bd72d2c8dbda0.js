(window.webpackJsonp=window.webpackJsonp||[]).push([[58],{QRvi:function(e,i,t){"use strict";t.d(i,"a",(function(){return n}));var n=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,i,t){"use strict";t.d(i,"a",(function(){return c}));var n=t("QRvi"),r=t("fXoL"),a=t("tyNb");let c=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,i,t){e.next(null),i.next({Working:!1,Error:t,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(e,i,t){e.next(null),i.next({Working:!1,Error:t,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,i,t,r,a){if(r===n.a.Get&&e.next(t),r===n.a.Put&&(e.getValue()[0]=t),r===n.a.Post&&e.getValue().push(t),r===n.a.Delete){const i=e.getValue().indexOf(a);e.getValue().splice(i,1)}e.next(e.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(e,i,t,r,a){r===n.a.Get&&e.next(t),e.next(e.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(i){return new(i||e)(r.Xb(a.b))},e.\u0275prov=r.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()},kmbE:function(e,i,t){"use strict";t.r(i),t.d(i,"MikeScenarioModule",(function(){return li}));var n=t("ofXK"),r=t("tyNb");function a(e){let i={Title:"The title"};"fr-CA"===$localize.locale&&(i.Title="Le Titre"),e.next(i)}var c=t("s4a4"),o=t("QRvi"),b=t("fXoL"),s=t("2Vo4"),m=t("LRne"),u=t("tk/3"),l=t("lJxs"),p=t("JIr8"),S=t("gkM4");let f=(()=>{class e{constructor(e,i){this.httpClient=e,this.httpClientService=i,this.mikescenarioTextModel$=new s.a({}),this.mikescenarioListModel$=new s.a({}),this.mikescenarioGetModel$=new s.a({}),this.mikescenarioPutModel$=new s.a({}),this.mikescenarioPostModel$=new s.a({}),this.mikescenarioDeleteModel$=new s.a({}),a(this.mikescenarioTextModel$),this.mikescenarioTextModel$.next({Title:"Something2 for text"})}GetMikeScenarioList(){return this.httpClientService.BeforeHttpClient(this.mikescenarioGetModel$),this.httpClient.get("/api/MikeScenario").pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.mikescenarioListModel$,this.mikescenarioGetModel$,e,o.a.Get,null)}),Object(p.a)(e=>Object(m.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.mikescenarioListModel$,this.mikescenarioGetModel$,e)}))))}PutMikeScenario(e){return this.httpClientService.BeforeHttpClient(this.mikescenarioPutModel$),this.httpClient.put("/api/MikeScenario",e,{headers:new u.d}).pipe(Object(l.a)(i=>{this.httpClientService.DoSuccess(this.mikescenarioListModel$,this.mikescenarioPutModel$,i,o.a.Put,e)}),Object(p.a)(e=>Object(m.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.mikescenarioListModel$,this.mikescenarioPutModel$,e)}))))}PostMikeScenario(e){return this.httpClientService.BeforeHttpClient(this.mikescenarioPostModel$),this.httpClient.post("/api/MikeScenario",e,{headers:new u.d}).pipe(Object(l.a)(i=>{this.httpClientService.DoSuccess(this.mikescenarioListModel$,this.mikescenarioPostModel$,i,o.a.Post,e)}),Object(p.a)(e=>Object(m.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.mikescenarioListModel$,this.mikescenarioPostModel$,e)}))))}DeleteMikeScenario(e){return this.httpClientService.BeforeHttpClient(this.mikescenarioDeleteModel$),this.httpClient.delete("/api/MikeScenario/"+e.MikeScenarioID).pipe(Object(l.a)(i=>{this.httpClientService.DoSuccess(this.mikescenarioListModel$,this.mikescenarioDeleteModel$,i,o.a.Delete,e)}),Object(p.a)(e=>Object(m.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.mikescenarioListModel$,this.mikescenarioDeleteModel$,e)}))))}}return e.\u0275fac=function(i){return new(i||e)(b.Xb(u.b),b.Xb(S.a))},e.\u0275prov=b.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var T=t("Wp6s"),d=t("bTqV"),y=t("bv9b"),I=t("NFeN"),k=t("3Pt+"),g=t("kmnG"),h=t("qFsG"),O=t("d3UM"),M=t("FKr1");function B(e,i){1&e&&b.Ob(0,"mat-progress-bar",37)}function x(e,i){1&e&&b.Ob(0,"mat-progress-bar",37)}function D(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function j(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,D,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function C(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function F(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,C,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function E(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,1,e))}}function v(e,i){if(1&e&&(b.Tb(0,"mat-option",38),b.yc(1),b.Sb()),2&e){const e=i.$implicit;b.jc("value",e.EnumID),b.Bb(1),b.Ac(" ",e.EnumText," ")}}function _(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function N(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,_,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function P(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,1,e))}}function L(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function $(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,L,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function A(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function q(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,A,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function V(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,1,e))}}function w(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 1"),b.Ob(2,"br"),b.Sb())}function z(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100000"),b.Ob(2,"br"),b.Sb())}function U(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,w,3,0,"span",4),b.xc(6,z,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function G(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function R(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function W(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100"),b.Ob(2,"br"),b.Sb())}function H(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,G,3,0,"span",4),b.xc(6,R,3,0,"span",4),b.xc(7,W,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,4,e)),b.Bb(3),b.jc("ngIf",e.required),b.Bb(1),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function Q(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function X(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function Z(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 360"),b.Ob(2,"br"),b.Sb())}function J(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Q,3,0,"span",4),b.xc(6,X,3,0,"span",4),b.xc(7,Z,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,4,e)),b.Bb(3),b.jc("ngIf",e.required),b.Bb(1),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function K(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function Y(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function ee(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100"),b.Ob(2,"br"),b.Sb())}function ie(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,K,3,0,"span",4),b.xc(6,Y,3,0,"span",4),b.xc(7,ee,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,4,e)),b.Bb(3),b.jc("ngIf",e.required),b.Bb(1),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function te(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function ne(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,te,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function re(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function ae(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function ce(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100"),b.Ob(2,"br"),b.Sb())}function oe(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,re,3,0,"span",4),b.xc(6,ae,3,0,"span",4),b.xc(7,ce,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,4,e)),b.Bb(3),b.jc("ngIf",e.required),b.Bb(1),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function be(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function se(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function me(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100"),b.Ob(2,"br"),b.Sb())}function ue(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,be,3,0,"span",4),b.xc(6,se,3,0,"span",4),b.xc(7,me,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,4,e)),b.Bb(3),b.jc("ngIf",e.required),b.Bb(1),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function le(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function pe(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - -10"),b.Ob(2,"br"),b.Sb())}function Se(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 40"),b.Ob(2,"br"),b.Sb())}function fe(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,le,3,0,"span",4),b.xc(6,pe,3,0,"span",4),b.xc(7,Se,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,4,e)),b.Bb(3),b.jc("ngIf",e.required),b.Bb(1),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function Te(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function de(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function ye(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 40"),b.Ob(2,"br"),b.Sb())}function Ie(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Te,3,0,"span",4),b.xc(6,de,3,0,"span",4),b.xc(7,ye,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,4,e)),b.Bb(3),b.jc("ngIf",e.required),b.Bb(1),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function ke(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,1,e))}}function ge(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,1,e))}}function he(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,1,e))}}function Oe(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,1,e))}}function Me(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function Be(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function xe(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100"),b.Ob(2,"br"),b.Sb())}function De(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Me,3,0,"span",4),b.xc(6,Be,3,0,"span",4),b.xc(7,xe,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,4,e)),b.Bb(3),b.jc("ngIf",e.required),b.Bb(1),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function je(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 1"),b.Ob(2,"br"),b.Sb())}function Ce(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 1000000"),b.Ob(2,"br"),b.Sb())}function Fe(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,je,3,0,"span",4),b.xc(6,Ce,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function Ee(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 1"),b.Ob(2,"br"),b.Sb())}function ve(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 1000000"),b.Ob(2,"br"),b.Sb())}function _e(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Ee,3,0,"span",4),b.xc(6,ve,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function Ne(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function Pe(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100"),b.Ob(2,"br"),b.Sb())}function Le(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Ne,3,0,"span",4),b.xc(6,Pe,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function $e(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function Ae(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100"),b.Ob(2,"br"),b.Sb())}function qe(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,$e,3,0,"span",4),b.xc(6,Ae,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function Ve(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function we(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100"),b.Ob(2,"br"),b.Sb())}function ze(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Ve,3,0,"span",4),b.xc(6,we,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function Ue(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function Ge(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100"),b.Ob(2,"br"),b.Sb())}function Re(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Ue,3,0,"span",4),b.xc(6,Ge,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function We(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function He(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100000000"),b.Ob(2,"br"),b.Sb())}function Qe(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,We,3,0,"span",4),b.xc(6,He,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function Xe(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Min - 0"),b.Ob(2,"br"),b.Sb())}function Ze(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Max - 100000000"),b.Ob(2,"br"),b.Sb())}function Je(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Xe,3,0,"span",4),b.xc(6,Ze,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,3,e)),b.Bb(3),b.jc("ngIf",e.min),b.Bb(1),b.jc("ngIf",e.min)}}function Ke(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function Ye(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Ke,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}function ei(e,i){1&e&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function ii(e,i){if(1&e&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,ei,3,0,"span",4),b.Sb()),2&e){const e=i.$implicit;b.Bb(2),b.zc(b.gc(3,2,e)),b.Bb(3),b.jc("ngIf",e.required)}}let ti=(()=>{class e{constructor(e,i){this.mikescenarioService=e,this.fb=i,this.mikescenario=null,this.httpClientCommand=o.a.Put}GetPut(){return this.httpClientCommand==o.a.Put}PutMikeScenario(e){this.sub=this.mikescenarioService.PutMikeScenario(e).subscribe()}PostMikeScenario(e){this.sub=this.mikescenarioService.PostMikeScenario(e).subscribe()}ngOnInit(){this.scenarioStatusList=Object(c.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.mikescenario){let i=this.fb.group({MikeScenarioID:[{value:e===o.a.Post?0:this.mikescenario.MikeScenarioID,disabled:!1},[k.p.required]],MikeScenarioTVItemID:[{value:this.mikescenario.MikeScenarioTVItemID,disabled:!1},[k.p.required]],ParentMikeScenarioID:[{value:this.mikescenario.ParentMikeScenarioID,disabled:!1}],ScenarioStatus:[{value:this.mikescenario.ScenarioStatus,disabled:!1},[k.p.required]],ErrorInfo:[{value:this.mikescenario.ErrorInfo,disabled:!1}],MikeScenarioStartDateTime_Local:[{value:this.mikescenario.MikeScenarioStartDateTime_Local,disabled:!1},[k.p.required]],MikeScenarioEndDateTime_Local:[{value:this.mikescenario.MikeScenarioEndDateTime_Local,disabled:!1},[k.p.required]],MikeScenarioStartExecutionDateTime_Local:[{value:this.mikescenario.MikeScenarioStartExecutionDateTime_Local,disabled:!1}],MikeScenarioExecutionTime_min:[{value:this.mikescenario.MikeScenarioExecutionTime_min,disabled:!1},[k.p.min(1),k.p.max(1e5)]],WindSpeed_km_h:[{value:this.mikescenario.WindSpeed_km_h,disabled:!1},[k.p.required,k.p.min(0),k.p.max(100)]],WindDirection_deg:[{value:this.mikescenario.WindDirection_deg,disabled:!1},[k.p.required,k.p.min(0),k.p.max(360)]],DecayFactor_per_day:[{value:this.mikescenario.DecayFactor_per_day,disabled:!1},[k.p.required,k.p.min(0),k.p.max(100)]],DecayIsConstant:[{value:this.mikescenario.DecayIsConstant,disabled:!1},[k.p.required]],DecayFactorAmplitude:[{value:this.mikescenario.DecayFactorAmplitude,disabled:!1},[k.p.required,k.p.min(0),k.p.max(100)]],ResultFrequency_min:[{value:this.mikescenario.ResultFrequency_min,disabled:!1},[k.p.required,k.p.min(0),k.p.max(100)]],AmbientTemperature_C:[{value:this.mikescenario.AmbientTemperature_C,disabled:!1},[k.p.required,k.p.min(-10),k.p.max(40)]],AmbientSalinity_PSU:[{value:this.mikescenario.AmbientSalinity_PSU,disabled:!1},[k.p.required,k.p.min(0),k.p.max(40)]],GenerateDecouplingFiles:[{value:this.mikescenario.GenerateDecouplingFiles,disabled:!1}],UseDecouplingFiles:[{value:this.mikescenario.UseDecouplingFiles,disabled:!1}],UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID:[{value:this.mikescenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID,disabled:!1}],ForSimulatingMWQMRunTVItemID:[{value:this.mikescenario.ForSimulatingMWQMRunTVItemID,disabled:!1}],ManningNumber:[{value:this.mikescenario.ManningNumber,disabled:!1},[k.p.required,k.p.min(0),k.p.max(100)]],NumberOfElements:[{value:this.mikescenario.NumberOfElements,disabled:!1},[k.p.min(1),k.p.max(1e6)]],NumberOfTimeSteps:[{value:this.mikescenario.NumberOfTimeSteps,disabled:!1},[k.p.min(1),k.p.max(1e6)]],NumberOfSigmaLayers:[{value:this.mikescenario.NumberOfSigmaLayers,disabled:!1},[k.p.min(0),k.p.max(100)]],NumberOfZLayers:[{value:this.mikescenario.NumberOfZLayers,disabled:!1},[k.p.min(0),k.p.max(100)]],NumberOfHydroOutputParameters:[{value:this.mikescenario.NumberOfHydroOutputParameters,disabled:!1},[k.p.min(0),k.p.max(100)]],NumberOfTransOutputParameters:[{value:this.mikescenario.NumberOfTransOutputParameters,disabled:!1},[k.p.min(0),k.p.max(100)]],EstimatedHydroFileSize:[{value:this.mikescenario.EstimatedHydroFileSize,disabled:!1},[k.p.min(0),k.p.max(1e8)]],EstimatedTransFileSize:[{value:this.mikescenario.EstimatedTransFileSize,disabled:!1},[k.p.min(0),k.p.max(1e8)]],LastUpdateDate_UTC:[{value:this.mikescenario.LastUpdateDate_UTC,disabled:!1},[k.p.required]],LastUpdateContactTVItemID:[{value:this.mikescenario.LastUpdateContactTVItemID,disabled:!1},[k.p.required]]});this.mikescenarioFormEdit=i}}}return e.\u0275fac=function(i){return new(i||e)(b.Nb(f),b.Nb(k.d))},e.\u0275cmp=b.Hb({type:e,selectors:[["app-mikescenario-edit"]],inputs:{mikescenario:"mikescenario",httpClientCommand:"httpClientCommand"},decls:177,vars:37,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","MikeScenarioID"],[4,"ngIf"],["matInput","","type","number","formControlName","MikeScenarioTVItemID"],["matInput","","type","number","formControlName","ParentMikeScenarioID"],["formControlName","ScenarioStatus"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","ErrorInfo"],["matInput","","type","text","formControlName","MikeScenarioStartDateTime_Local"],["matInput","","type","text","formControlName","MikeScenarioEndDateTime_Local"],["matInput","","type","text","formControlName","MikeScenarioStartExecutionDateTime_Local"],["matInput","","type","number","formControlName","MikeScenarioExecutionTime_min"],["matInput","","type","number","formControlName","WindSpeed_km_h"],["matInput","","type","number","formControlName","WindDirection_deg"],["matInput","","type","number","formControlName","DecayFactor_per_day"],["matInput","","type","text","formControlName","DecayIsConstant"],["matInput","","type","number","formControlName","DecayFactorAmplitude"],["matInput","","type","number","formControlName","ResultFrequency_min"],["matInput","","type","number","formControlName","AmbientTemperature_C"],["matInput","","type","number","formControlName","AmbientSalinity_PSU"],["matInput","","type","text","formControlName","GenerateDecouplingFiles"],["matInput","","type","text","formControlName","UseDecouplingFiles"],["matInput","","type","number","formControlName","UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID"],["matInput","","type","number","formControlName","ForSimulatingMWQMRunTVItemID"],["matInput","","type","number","formControlName","ManningNumber"],["matInput","","type","number","formControlName","NumberOfElements"],["matInput","","type","number","formControlName","NumberOfTimeSteps"],["matInput","","type","number","formControlName","NumberOfSigmaLayers"],["matInput","","type","number","formControlName","NumberOfZLayers"],["matInput","","type","number","formControlName","NumberOfHydroOutputParameters"],["matInput","","type","number","formControlName","NumberOfTransOutputParameters"],["matInput","","type","number","formControlName","EstimatedHydroFileSize"],["matInput","","type","number","formControlName","EstimatedTransFileSize"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,i){1&e&&(b.Tb(0,"form",0),b.ac("ngSubmit",(function(){return i.GetPut()?i.PutMikeScenario(i.mikescenarioFormEdit.value):i.PostMikeScenario(i.mikescenarioFormEdit.value)})),b.Tb(1,"h3"),b.yc(2," MikeScenario "),b.Tb(3,"button",1),b.Tb(4,"span"),b.yc(5),b.Sb(),b.Sb(),b.xc(6,B,1,0,"mat-progress-bar",2),b.xc(7,x,1,0,"mat-progress-bar",2),b.Sb(),b.Tb(8,"p"),b.Tb(9,"mat-form-field"),b.Tb(10,"mat-label"),b.yc(11,"MikeScenarioID"),b.Sb(),b.Ob(12,"input",3),b.xc(13,j,6,4,"mat-error",4),b.Sb(),b.Tb(14,"mat-form-field"),b.Tb(15,"mat-label"),b.yc(16,"MikeScenarioTVItemID"),b.Sb(),b.Ob(17,"input",5),b.xc(18,F,6,4,"mat-error",4),b.Sb(),b.Tb(19,"mat-form-field"),b.Tb(20,"mat-label"),b.yc(21,"ParentMikeScenarioID"),b.Sb(),b.Ob(22,"input",6),b.xc(23,E,5,3,"mat-error",4),b.Sb(),b.Tb(24,"mat-form-field"),b.Tb(25,"mat-label"),b.yc(26,"ScenarioStatus"),b.Sb(),b.Tb(27,"mat-select",7),b.xc(28,v,2,2,"mat-option",8),b.Sb(),b.xc(29,N,6,4,"mat-error",4),b.Sb(),b.Sb(),b.Tb(30,"p"),b.Tb(31,"mat-form-field"),b.Tb(32,"mat-label"),b.yc(33,"ErrorInfo"),b.Sb(),b.Ob(34,"input",9),b.xc(35,P,5,3,"mat-error",4),b.Sb(),b.Tb(36,"mat-form-field"),b.Tb(37,"mat-label"),b.yc(38,"MikeScenarioStartDateTime_Local"),b.Sb(),b.Ob(39,"input",10),b.xc(40,$,6,4,"mat-error",4),b.Sb(),b.Tb(41,"mat-form-field"),b.Tb(42,"mat-label"),b.yc(43,"MikeScenarioEndDateTime_Local"),b.Sb(),b.Ob(44,"input",11),b.xc(45,q,6,4,"mat-error",4),b.Sb(),b.Tb(46,"mat-form-field"),b.Tb(47,"mat-label"),b.yc(48,"MikeScenarioStartExecutionDateTime_Local"),b.Sb(),b.Ob(49,"input",12),b.xc(50,V,5,3,"mat-error",4),b.Sb(),b.Sb(),b.Tb(51,"p"),b.Tb(52,"mat-form-field"),b.Tb(53,"mat-label"),b.yc(54,"MikeScenarioExecutionTime_min"),b.Sb(),b.Ob(55,"input",13),b.xc(56,U,7,5,"mat-error",4),b.Sb(),b.Tb(57,"mat-form-field"),b.Tb(58,"mat-label"),b.yc(59,"WindSpeed_km_h"),b.Sb(),b.Ob(60,"input",14),b.xc(61,H,8,6,"mat-error",4),b.Sb(),b.Tb(62,"mat-form-field"),b.Tb(63,"mat-label"),b.yc(64,"WindDirection_deg"),b.Sb(),b.Ob(65,"input",15),b.xc(66,J,8,6,"mat-error",4),b.Sb(),b.Tb(67,"mat-form-field"),b.Tb(68,"mat-label"),b.yc(69,"DecayFactor_per_day"),b.Sb(),b.Ob(70,"input",16),b.xc(71,ie,8,6,"mat-error",4),b.Sb(),b.Sb(),b.Tb(72,"p"),b.Tb(73,"mat-form-field"),b.Tb(74,"mat-label"),b.yc(75,"DecayIsConstant"),b.Sb(),b.Ob(76,"input",17),b.xc(77,ne,6,4,"mat-error",4),b.Sb(),b.Tb(78,"mat-form-field"),b.Tb(79,"mat-label"),b.yc(80,"DecayFactorAmplitude"),b.Sb(),b.Ob(81,"input",18),b.xc(82,oe,8,6,"mat-error",4),b.Sb(),b.Tb(83,"mat-form-field"),b.Tb(84,"mat-label"),b.yc(85,"ResultFrequency_min"),b.Sb(),b.Ob(86,"input",19),b.xc(87,ue,8,6,"mat-error",4),b.Sb(),b.Tb(88,"mat-form-field"),b.Tb(89,"mat-label"),b.yc(90,"AmbientTemperature_C"),b.Sb(),b.Ob(91,"input",20),b.xc(92,fe,8,6,"mat-error",4),b.Sb(),b.Sb(),b.Tb(93,"p"),b.Tb(94,"mat-form-field"),b.Tb(95,"mat-label"),b.yc(96,"AmbientSalinity_PSU"),b.Sb(),b.Ob(97,"input",21),b.xc(98,Ie,8,6,"mat-error",4),b.Sb(),b.Tb(99,"mat-form-field"),b.Tb(100,"mat-label"),b.yc(101,"GenerateDecouplingFiles"),b.Sb(),b.Ob(102,"input",22),b.xc(103,ke,5,3,"mat-error",4),b.Sb(),b.Tb(104,"mat-form-field"),b.Tb(105,"mat-label"),b.yc(106,"UseDecouplingFiles"),b.Sb(),b.Ob(107,"input",23),b.xc(108,ge,5,3,"mat-error",4),b.Sb(),b.Tb(109,"mat-form-field"),b.Tb(110,"mat-label"),b.yc(111,"UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID"),b.Sb(),b.Ob(112,"input",24),b.xc(113,he,5,3,"mat-error",4),b.Sb(),b.Sb(),b.Tb(114,"p"),b.Tb(115,"mat-form-field"),b.Tb(116,"mat-label"),b.yc(117,"ForSimulatingMWQMRunTVItemID"),b.Sb(),b.Ob(118,"input",25),b.xc(119,Oe,5,3,"mat-error",4),b.Sb(),b.Tb(120,"mat-form-field"),b.Tb(121,"mat-label"),b.yc(122,"ManningNumber"),b.Sb(),b.Ob(123,"input",26),b.xc(124,De,8,6,"mat-error",4),b.Sb(),b.Tb(125,"mat-form-field"),b.Tb(126,"mat-label"),b.yc(127,"NumberOfElements"),b.Sb(),b.Ob(128,"input",27),b.xc(129,Fe,7,5,"mat-error",4),b.Sb(),b.Tb(130,"mat-form-field"),b.Tb(131,"mat-label"),b.yc(132,"NumberOfTimeSteps"),b.Sb(),b.Ob(133,"input",28),b.xc(134,_e,7,5,"mat-error",4),b.Sb(),b.Sb(),b.Tb(135,"p"),b.Tb(136,"mat-form-field"),b.Tb(137,"mat-label"),b.yc(138,"NumberOfSigmaLayers"),b.Sb(),b.Ob(139,"input",29),b.xc(140,Le,7,5,"mat-error",4),b.Sb(),b.Tb(141,"mat-form-field"),b.Tb(142,"mat-label"),b.yc(143,"NumberOfZLayers"),b.Sb(),b.Ob(144,"input",30),b.xc(145,qe,7,5,"mat-error",4),b.Sb(),b.Tb(146,"mat-form-field"),b.Tb(147,"mat-label"),b.yc(148,"NumberOfHydroOutputParameters"),b.Sb(),b.Ob(149,"input",31),b.xc(150,ze,7,5,"mat-error",4),b.Sb(),b.Tb(151,"mat-form-field"),b.Tb(152,"mat-label"),b.yc(153,"NumberOfTransOutputParameters"),b.Sb(),b.Ob(154,"input",32),b.xc(155,Re,7,5,"mat-error",4),b.Sb(),b.Sb(),b.Tb(156,"p"),b.Tb(157,"mat-form-field"),b.Tb(158,"mat-label"),b.yc(159,"EstimatedHydroFileSize"),b.Sb(),b.Ob(160,"input",33),b.xc(161,Qe,7,5,"mat-error",4),b.Sb(),b.Tb(162,"mat-form-field"),b.Tb(163,"mat-label"),b.yc(164,"EstimatedTransFileSize"),b.Sb(),b.Ob(165,"input",34),b.xc(166,Je,7,5,"mat-error",4),b.Sb(),b.Tb(167,"mat-form-field"),b.Tb(168,"mat-label"),b.yc(169,"LastUpdateDate_UTC"),b.Sb(),b.Ob(170,"input",35),b.xc(171,Ye,6,4,"mat-error",4),b.Sb(),b.Tb(172,"mat-form-field"),b.Tb(173,"mat-label"),b.yc(174,"LastUpdateContactTVItemID"),b.Sb(),b.Ob(175,"input",36),b.xc(176,ii,6,4,"mat-error",4),b.Sb(),b.Sb(),b.Sb()),2&e&&(b.jc("formGroup",i.mikescenarioFormEdit),b.Bb(5),b.Ac("",i.GetPut()?"Put":"Post"," MikeScenario"),b.Bb(1),b.jc("ngIf",i.mikescenarioService.mikescenarioPutModel$.getValue().Working),b.Bb(1),b.jc("ngIf",i.mikescenarioService.mikescenarioPostModel$.getValue().Working),b.Bb(6),b.jc("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioID.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioTVItemID.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.ParentMikeScenarioID.errors),b.Bb(5),b.jc("ngForOf",i.scenarioStatusList),b.Bb(1),b.jc("ngIf",i.mikescenarioFormEdit.controls.ScenarioStatus.errors),b.Bb(6),b.jc("ngIf",i.mikescenarioFormEdit.controls.ErrorInfo.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioStartDateTime_Local.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioEndDateTime_Local.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioStartExecutionDateTime_Local.errors),b.Bb(6),b.jc("ngIf",i.mikescenarioFormEdit.controls.MikeScenarioExecutionTime_min.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.WindSpeed_km_h.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.WindDirection_deg.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.DecayFactor_per_day.errors),b.Bb(6),b.jc("ngIf",i.mikescenarioFormEdit.controls.DecayIsConstant.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.DecayFactorAmplitude.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.ResultFrequency_min.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.AmbientTemperature_C.errors),b.Bb(6),b.jc("ngIf",i.mikescenarioFormEdit.controls.AmbientSalinity_PSU.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.GenerateDecouplingFiles.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.UseDecouplingFiles.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID.errors),b.Bb(6),b.jc("ngIf",i.mikescenarioFormEdit.controls.ForSimulatingMWQMRunTVItemID.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.ManningNumber.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.NumberOfElements.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.NumberOfTimeSteps.errors),b.Bb(6),b.jc("ngIf",i.mikescenarioFormEdit.controls.NumberOfSigmaLayers.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.NumberOfZLayers.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.NumberOfHydroOutputParameters.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.NumberOfTransOutputParameters.errors),b.Bb(6),b.jc("ngIf",i.mikescenarioFormEdit.controls.EstimatedHydroFileSize.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.EstimatedTransFileSize.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(5),b.jc("ngIf",i.mikescenarioFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[k.q,k.l,k.f,d.b,n.l,g.c,g.f,h.b,k.n,k.c,k.k,k.e,O.a,n.k,y.a,g.b,M.n],pipes:[n.f],styles:[""],changeDetection:0}),e})();function ni(e,i){1&e&&b.Ob(0,"mat-progress-bar",4)}function ri(e,i){1&e&&b.Ob(0,"mat-progress-bar",4)}function ai(e,i){if(1&e&&(b.Tb(0,"p"),b.Ob(1,"app-mikescenario-edit",8),b.Sb()),2&e){const e=b.ec().$implicit,i=b.ec(2);b.Bb(1),b.jc("mikescenario",e)("httpClientCommand",i.GetPutEnum())}}function ci(e,i){if(1&e&&(b.Tb(0,"p"),b.Ob(1,"app-mikescenario-edit",8),b.Sb()),2&e){const e=b.ec().$implicit,i=b.ec(2);b.Bb(1),b.jc("mikescenario",e)("httpClientCommand",i.GetPostEnum())}}function oi(e,i){if(1&e){const e=b.Ub();b.Tb(0,"div"),b.Tb(1,"p"),b.Tb(2,"button",6),b.ac("click",(function(){b.rc(e);const t=i.$implicit;return b.ec(2).DeleteMikeScenario(t)})),b.Tb(3,"span"),b.yc(4),b.Sb(),b.Tb(5,"mat-icon"),b.yc(6,"delete"),b.Sb(),b.Sb(),b.yc(7,"\xa0\xa0\xa0 "),b.Tb(8,"button",7),b.ac("click",(function(){b.rc(e);const t=i.$implicit;return b.ec(2).ShowPut(t)})),b.Tb(9,"span"),b.yc(10,"Show Put"),b.Sb(),b.Sb(),b.yc(11,"\xa0\xa0 "),b.Tb(12,"button",7),b.ac("click",(function(){b.rc(e);const t=i.$implicit;return b.ec(2).ShowPost(t)})),b.Tb(13,"span"),b.yc(14,"Show Post"),b.Sb(),b.Sb(),b.yc(15,"\xa0\xa0 "),b.xc(16,ri,1,0,"mat-progress-bar",0),b.Sb(),b.xc(17,ai,2,2,"p",2),b.xc(18,ci,2,2,"p",2),b.Tb(19,"blockquote"),b.Tb(20,"p"),b.Tb(21,"span"),b.yc(22),b.Sb(),b.Tb(23,"span"),b.yc(24),b.Sb(),b.Tb(25,"span"),b.yc(26),b.Sb(),b.Tb(27,"span"),b.yc(28),b.Sb(),b.Sb(),b.Tb(29,"p"),b.Tb(30,"span"),b.yc(31),b.Sb(),b.Tb(32,"span"),b.yc(33),b.Sb(),b.Tb(34,"span"),b.yc(35),b.Sb(),b.Tb(36,"span"),b.yc(37),b.Sb(),b.Sb(),b.Tb(38,"p"),b.Tb(39,"span"),b.yc(40),b.Sb(),b.Tb(41,"span"),b.yc(42),b.Sb(),b.Tb(43,"span"),b.yc(44),b.Sb(),b.Tb(45,"span"),b.yc(46),b.Sb(),b.Sb(),b.Tb(47,"p"),b.Tb(48,"span"),b.yc(49),b.Sb(),b.Tb(50,"span"),b.yc(51),b.Sb(),b.Tb(52,"span"),b.yc(53),b.Sb(),b.Tb(54,"span"),b.yc(55),b.Sb(),b.Sb(),b.Tb(56,"p"),b.Tb(57,"span"),b.yc(58),b.Sb(),b.Tb(59,"span"),b.yc(60),b.Sb(),b.Tb(61,"span"),b.yc(62),b.Sb(),b.Tb(63,"span"),b.yc(64),b.Sb(),b.Sb(),b.Tb(65,"p"),b.Tb(66,"span"),b.yc(67),b.Sb(),b.Tb(68,"span"),b.yc(69),b.Sb(),b.Tb(70,"span"),b.yc(71),b.Sb(),b.Tb(72,"span"),b.yc(73),b.Sb(),b.Sb(),b.Tb(74,"p"),b.Tb(75,"span"),b.yc(76),b.Sb(),b.Tb(77,"span"),b.yc(78),b.Sb(),b.Tb(79,"span"),b.yc(80),b.Sb(),b.Tb(81,"span"),b.yc(82),b.Sb(),b.Sb(),b.Tb(83,"p"),b.Tb(84,"span"),b.yc(85),b.Sb(),b.Tb(86,"span"),b.yc(87),b.Sb(),b.Tb(88,"span"),b.yc(89),b.Sb(),b.Tb(90,"span"),b.yc(91),b.Sb(),b.Sb(),b.Sb(),b.Sb()}if(2&e){const e=i.$implicit,t=b.ec(2);b.Bb(4),b.Ac("Delete MikeScenarioID [",e.MikeScenarioID,"]\xa0\xa0\xa0"),b.Bb(4),b.jc("color",t.GetPutButtonColor(e)),b.Bb(4),b.jc("color",t.GetPostButtonColor(e)),b.Bb(4),b.jc("ngIf",t.mikescenarioService.mikescenarioDeleteModel$.getValue().Working),b.Bb(1),b.jc("ngIf",t.IDToShow===e.MikeScenarioID&&t.showType===t.GetPutEnum()),b.Bb(1),b.jc("ngIf",t.IDToShow===e.MikeScenarioID&&t.showType===t.GetPostEnum()),b.Bb(4),b.Ac("MikeScenarioID: [",e.MikeScenarioID,"]"),b.Bb(2),b.Ac(" --- MikeScenarioTVItemID: [",e.MikeScenarioTVItemID,"]"),b.Bb(2),b.Ac(" --- ParentMikeScenarioID: [",e.ParentMikeScenarioID,"]"),b.Bb(2),b.Ac(" --- ScenarioStatus: [",t.GetScenarioStatusEnumText(e.ScenarioStatus),"]"),b.Bb(3),b.Ac("ErrorInfo: [",e.ErrorInfo,"]"),b.Bb(2),b.Ac(" --- MikeScenarioStartDateTime_Local: [",e.MikeScenarioStartDateTime_Local,"]"),b.Bb(2),b.Ac(" --- MikeScenarioEndDateTime_Local: [",e.MikeScenarioEndDateTime_Local,"]"),b.Bb(2),b.Ac(" --- MikeScenarioStartExecutionDateTime_Local: [",e.MikeScenarioStartExecutionDateTime_Local,"]"),b.Bb(3),b.Ac("MikeScenarioExecutionTime_min: [",e.MikeScenarioExecutionTime_min,"]"),b.Bb(2),b.Ac(" --- WindSpeed_km_h: [",e.WindSpeed_km_h,"]"),b.Bb(2),b.Ac(" --- WindDirection_deg: [",e.WindDirection_deg,"]"),b.Bb(2),b.Ac(" --- DecayFactor_per_day: [",e.DecayFactor_per_day,"]"),b.Bb(3),b.Ac("DecayIsConstant: [",e.DecayIsConstant,"]"),b.Bb(2),b.Ac(" --- DecayFactorAmplitude: [",e.DecayFactorAmplitude,"]"),b.Bb(2),b.Ac(" --- ResultFrequency_min: [",e.ResultFrequency_min,"]"),b.Bb(2),b.Ac(" --- AmbientTemperature_C: [",e.AmbientTemperature_C,"]"),b.Bb(3),b.Ac("AmbientSalinity_PSU: [",e.AmbientSalinity_PSU,"]"),b.Bb(2),b.Ac(" --- GenerateDecouplingFiles: [",e.GenerateDecouplingFiles,"]"),b.Bb(2),b.Ac(" --- UseDecouplingFiles: [",e.UseDecouplingFiles,"]"),b.Bb(2),b.Ac(" --- UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID: [",e.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID,"]"),b.Bb(3),b.Ac("ForSimulatingMWQMRunTVItemID: [",e.ForSimulatingMWQMRunTVItemID,"]"),b.Bb(2),b.Ac(" --- ManningNumber: [",e.ManningNumber,"]"),b.Bb(2),b.Ac(" --- NumberOfElements: [",e.NumberOfElements,"]"),b.Bb(2),b.Ac(" --- NumberOfTimeSteps: [",e.NumberOfTimeSteps,"]"),b.Bb(3),b.Ac("NumberOfSigmaLayers: [",e.NumberOfSigmaLayers,"]"),b.Bb(2),b.Ac(" --- NumberOfZLayers: [",e.NumberOfZLayers,"]"),b.Bb(2),b.Ac(" --- NumberOfHydroOutputParameters: [",e.NumberOfHydroOutputParameters,"]"),b.Bb(2),b.Ac(" --- NumberOfTransOutputParameters: [",e.NumberOfTransOutputParameters,"]"),b.Bb(3),b.Ac("EstimatedHydroFileSize: [",e.EstimatedHydroFileSize,"]"),b.Bb(2),b.Ac(" --- EstimatedTransFileSize: [",e.EstimatedTransFileSize,"]"),b.Bb(2),b.Ac(" --- LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),b.Bb(2),b.Ac(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function bi(e,i){if(1&e&&(b.Tb(0,"div"),b.xc(1,oi,92,38,"div",5),b.Sb()),2&e){const e=b.ec();b.Bb(1),b.jc("ngForOf",e.mikescenarioService.mikescenarioListModel$.getValue())}}const si=[{path:"",component:(()=>{class e{constructor(e,i,t){this.mikescenarioService=e,this.router=i,this.httpClientService=t,this.showType=null,t.oldURL=i.url}GetPutButtonColor(e){return this.IDToShow===e.MikeScenarioID&&this.showType===o.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.MikeScenarioID&&this.showType===o.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.MikeScenarioID&&this.showType===o.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.MikeScenarioID,this.showType=o.a.Put)}ShowPost(e){this.IDToShow===e.MikeScenarioID&&this.showType===o.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.MikeScenarioID,this.showType=o.a.Post)}GetPutEnum(){return o.a.Put}GetPostEnum(){return o.a.Post}GetMikeScenarioList(){this.sub=this.mikescenarioService.GetMikeScenarioList().subscribe()}DeleteMikeScenario(e){this.sub=this.mikescenarioService.DeleteMikeScenario(e).subscribe()}GetScenarioStatusEnumText(e){return Object(c.a)(e)}ngOnInit(){a(this.mikescenarioService.mikescenarioTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(i){return new(i||e)(b.Nb(f),b.Nb(r.b),b.Nb(S.a))},e.\u0275cmp=b.Hb({type:e,selectors:[["app-mikescenario"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"mikescenario","httpClientCommand"]],template:function(e,i){if(1&e&&(b.xc(0,ni,1,0,"mat-progress-bar",0),b.Tb(1,"mat-card"),b.Tb(2,"mat-card-header"),b.Tb(3,"mat-card-title"),b.yc(4," MikeScenario works! "),b.Tb(5,"button",1),b.ac("click",(function(){return i.GetMikeScenarioList()})),b.Tb(6,"span"),b.yc(7,"Get MikeScenario"),b.Sb(),b.Sb(),b.Sb(),b.Tb(8,"mat-card-subtitle"),b.yc(9),b.Sb(),b.Sb(),b.Tb(10,"mat-card-content"),b.xc(11,bi,2,1,"div",2),b.Sb(),b.Tb(12,"mat-card-actions"),b.Tb(13,"button",3),b.yc(14,"Allo"),b.Sb(),b.Sb(),b.Sb()),2&e){var t;const e=null==(t=i.mikescenarioService.mikescenarioGetModel$.getValue())?null:t.Working;var n;const r=null==(n=i.mikescenarioService.mikescenarioListModel$.getValue())?null:n.length;b.jc("ngIf",e),b.Bb(9),b.zc(i.mikescenarioService.mikescenarioTextModel$.getValue().Title),b.Bb(2),b.jc("ngIf",r)}},directives:[n.l,T.a,T.d,T.g,d.b,T.f,T.c,T.b,y.a,n.k,I.a,ti],styles:[""],changeDetection:0}),e})(),canActivate:[t("auXs").a]}];let mi=(()=>{class e{}return e.\u0275mod=b.Lb({type:e}),e.\u0275inj=b.Kb({factory:function(i){return new(i||e)},imports:[[r.e.forChild(si)],r.e]}),e})();var ui=t("B+Mi");let li=(()=>{class e{}return e.\u0275mod=b.Lb({type:e}),e.\u0275inj=b.Kb({factory:function(i){return new(i||e)},imports:[[n.c,r.e,mi,ui.a,k.g,k.o]]}),e})()}}]);