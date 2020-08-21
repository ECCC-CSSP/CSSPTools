!function(){function t(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function e(t,e){for(var i=0;i<e.length;i++){var r=e[i];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(t,r.key,r)}}function i(t,i,r){return i&&e(t.prototype,i),r&&e(t,r),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[51],{QRvi:function(t,e,i){"use strict";i.d(e,"a",(function(){return r}));var r=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(e,r,o){"use strict";o.d(r,"a",(function(){return b}));var c=o("QRvi"),n=o("fXoL"),a=o("tyNb"),b=function(){var e=function(){function e(i){t(this,e),this.router=i,this.oldURL=i.url}return i(e,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,e,i,r,o){if(r===c.a.Get&&t.next(i),r===c.a.Put&&(t.getValue()[0]=i),r===c.a.Post&&t.getValue().push(i),r===c.a.Delete){var n=t.getValue().indexOf(o);t.getValue().splice(n,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,e,i,r,o){r===c.a.Get&&t.next(i),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(n.Wb(a.b))},e.\u0275prov=n.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()},sJCf:function(e,r,o){"use strict";o.r(r),o.d(r,"HydrometricSiteModule",(function(){return Ct}));var c=o("ofXK"),n=o("tyNb");function a(t){var e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var b,s=o("QRvi"),m=o("fXoL"),l=o("2Vo4"),u=o("LRne"),d=o("tk/3"),p=o("lJxs"),f=o("JIr8"),h=o("gkM4"),S=((b=function(){function e(i,r){t(this,e),this.httpClient=i,this.httpClientService=r,this.hydrometricsiteTextModel$=new l.a({}),this.hydrometricsiteListModel$=new l.a({}),this.hydrometricsiteGetModel$=new l.a({}),this.hydrometricsitePutModel$=new l.a({}),this.hydrometricsitePostModel$=new l.a({}),this.hydrometricsiteDeleteModel$=new l.a({}),a(this.hydrometricsiteTextModel$),this.hydrometricsiteTextModel$.next({Title:"Something2 for text"})}return i(e,[{key:"GetHydrometricSiteList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.hydrometricsiteGetModel$),this.httpClient.get("/api/HydrometricSite").pipe(Object(p.a)((function(e){t.httpClientService.DoSuccess(t.hydrometricsiteListModel$,t.hydrometricsiteGetModel$,e,s.a.Get,null)})),Object(f.a)((function(e){return Object(u.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.hydrometricsiteListModel$,t.hydrometricsiteGetModel$,e)})))})))}},{key:"PutHydrometricSite",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.hydrometricsitePutModel$),this.httpClient.put("/api/HydrometricSite",t,{headers:new d.d}).pipe(Object(p.a)((function(i){e.httpClientService.DoSuccess(e.hydrometricsiteListModel$,e.hydrometricsitePutModel$,i,s.a.Put,t)})),Object(f.a)((function(t){return Object(u.a)(t).pipe(Object(p.a)((function(t){e.httpClientService.DoCatchError(e.hydrometricsiteListModel$,e.hydrometricsitePutModel$,t)})))})))}},{key:"PostHydrometricSite",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.hydrometricsitePostModel$),this.httpClient.post("/api/HydrometricSite",t,{headers:new d.d}).pipe(Object(p.a)((function(i){e.httpClientService.DoSuccess(e.hydrometricsiteListModel$,e.hydrometricsitePostModel$,i,s.a.Post,t)})),Object(f.a)((function(t){return Object(u.a)(t).pipe(Object(p.a)((function(t){e.httpClientService.DoCatchError(e.hydrometricsiteListModel$,e.hydrometricsitePostModel$,t)})))})))}},{key:"DeleteHydrometricSite",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.hydrometricsiteDeleteModel$),this.httpClient.delete("/api/HydrometricSite/"+t.HydrometricSiteID).pipe(Object(p.a)((function(i){e.httpClientService.DoSuccess(e.hydrometricsiteListModel$,e.hydrometricsiteDeleteModel$,i,s.a.Delete,t)})),Object(f.a)((function(t){return Object(u.a)(t).pipe(Object(p.a)((function(t){e.httpClientService.DoCatchError(e.hydrometricsiteListModel$,e.hydrometricsiteDeleteModel$,t)})))})))}}]),e}()).\u0275fac=function(t){return new(t||b)(m.Wb(d.b),m.Wb(h.a))},b.\u0275prov=m.Ib({token:b,factory:b.\u0275fac,providedIn:"root"}),b),y=o("Wp6s"),R=o("bTqV"),v=o("bv9b"),I=o("NFeN"),g=o("3Pt+"),B=o("kmnG"),N=o("qFsG");function D(t,e){1&t&&m.Nb(0,"mat-progress-bar",26)}function C(t,e){1&t&&m.Nb(0,"mat-progress-bar",26)}function z(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function H(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,z,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,2,i)),m.Bb(3),m.ic("ngIf",i.required)}}function T(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function L(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,T,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,2,i)),m.Bb(3),m.ic("ngIf",i.required)}}function P(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"MaxLength - 7"),m.Nb(2,"br"),m.Rb())}function k(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,P,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,2,i)),m.Bb(3),m.ic("ngIf",i.maxlength)}}function $(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"MaxLength - 7"),m.Nb(2,"br"),m.Rb())}function E(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,$,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,2,i)),m.Bb(3),m.ic("ngIf",i.maxlength)}}function x(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function M(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"MaxLength - 200"),m.Nb(2,"br"),m.Rb())}function w(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,x,3,0,"span",4),m.yc(6,M,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,3,i)),m.Bb(3),m.ic("ngIf",i.required),m.Bb(1),m.ic("ngIf",i.maxlength)}}function F(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"MaxLength - 200"),m.Nb(2,"br"),m.Rb())}function _(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,F,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,2,i)),m.Bb(3),m.ic("ngIf",i.maxlength)}}function j(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function A(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"MaxLength - 4"),m.Nb(2,"br"),m.Rb())}function G(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,j,3,0,"span",4),m.yc(6,A,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,3,i)),m.Bb(3),m.ic("ngIf",i.required),m.Bb(1),m.ic("ngIf",i.maxlength)}}function O(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - 0"),m.Nb(2,"br"),m.Rb())}function V(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 10000"),m.Nb(2,"br"),m.Rb())}function q(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,O,3,0,"span",4),m.yc(6,V,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,3,i)),m.Bb(3),m.ic("ngIf",i.min),m.Bb(1),m.ic("ngIf",i.min)}}function U(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function W(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function Q(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - -10"),m.Nb(2,"br"),m.Rb())}function J(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 0"),m.Nb(2,"br"),m.Rb())}function Z(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,Q,3,0,"span",4),m.yc(6,J,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,3,i)),m.Bb(3),m.ic("ngIf",i.min),m.Bb(1),m.ic("ngIf",i.min)}}function X(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Min - 0"),m.Nb(2,"br"),m.Rb())}function K(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Max - 1000000"),m.Nb(2,"br"),m.Rb())}function Y(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,X,3,0,"span",4),m.yc(6,K,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,3,i)),m.Bb(3),m.ic("ngIf",i.min),m.Bb(1),m.ic("ngIf",i.min)}}function tt(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function et(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function it(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function rt(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function ot(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function ct(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function nt(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function at(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,1,i))}}function bt(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function st(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,bt,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,2,i)),m.Bb(3),m.ic("ngIf",i.required)}}function mt(t,e){1&t&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function lt(t,e){if(1&t&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,mt,3,0,"span",4),m.Rb()),2&t){var i=e.$implicit;m.Bb(2),m.Ac(m.fc(3,2,i)),m.Bb(3),m.ic("ngIf",i.required)}}var ut,dt=((ut=function(){function e(i,r){t(this,e),this.hydrometricsiteService=i,this.fb=r,this.hydrometricsite=null,this.httpClientCommand=s.a.Put}return i(e,[{key:"GetPut",value:function(){return this.httpClientCommand==s.a.Put}},{key:"PutHydrometricSite",value:function(t){this.sub=this.hydrometricsiteService.PutHydrometricSite(t).subscribe()}},{key:"PostHydrometricSite",value:function(t){this.sub=this.hydrometricsiteService.PostHydrometricSite(t).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.hydrometricsite){var e=this.fb.group({HydrometricSiteID:[{value:t===s.a.Post?0:this.hydrometricsite.HydrometricSiteID,disabled:!1},[g.p.required]],HydrometricSiteTVItemID:[{value:this.hydrometricsite.HydrometricSiteTVItemID,disabled:!1},[g.p.required]],FedSiteNumber:[{value:this.hydrometricsite.FedSiteNumber,disabled:!1},[g.p.maxLength(7)]],QuebecSiteNumber:[{value:this.hydrometricsite.QuebecSiteNumber,disabled:!1},[g.p.maxLength(7)]],HydrometricSiteName:[{value:this.hydrometricsite.HydrometricSiteName,disabled:!1},[g.p.required,g.p.maxLength(200)]],Description:[{value:this.hydrometricsite.Description,disabled:!1},[g.p.maxLength(200)]],Province:[{value:this.hydrometricsite.Province,disabled:!1},[g.p.required,g.p.maxLength(4)]],Elevation_m:[{value:this.hydrometricsite.Elevation_m,disabled:!1},[g.p.min(0),g.p.max(1e4)]],StartDate_Local:[{value:this.hydrometricsite.StartDate_Local,disabled:!1}],EndDate_Local:[{value:this.hydrometricsite.EndDate_Local,disabled:!1}],TimeOffset_hour:[{value:this.hydrometricsite.TimeOffset_hour,disabled:!1},[g.p.min(-10),g.p.max(0)]],DrainageArea_km2:[{value:this.hydrometricsite.DrainageArea_km2,disabled:!1},[g.p.min(0),g.p.max(1e6)]],IsNatural:[{value:this.hydrometricsite.IsNatural,disabled:!1}],IsActive:[{value:this.hydrometricsite.IsActive,disabled:!1}],Sediment:[{value:this.hydrometricsite.Sediment,disabled:!1}],RHBN:[{value:this.hydrometricsite.RHBN,disabled:!1}],RealTime:[{value:this.hydrometricsite.RealTime,disabled:!1}],HasDischarge:[{value:this.hydrometricsite.HasDischarge,disabled:!1}],HasLevel:[{value:this.hydrometricsite.HasLevel,disabled:!1}],HasRatingCurve:[{value:this.hydrometricsite.HasRatingCurve,disabled:!1}],LastUpdateDate_UTC:[{value:this.hydrometricsite.LastUpdateDate_UTC,disabled:!1},[g.p.required]],LastUpdateContactTVItemID:[{value:this.hydrometricsite.LastUpdateContactTVItemID,disabled:!1},[g.p.required]]});this.hydrometricsiteFormEdit=e}}}]),e}()).\u0275fac=function(t){return new(t||ut)(m.Mb(S),m.Mb(g.d))},ut.\u0275cmp=m.Gb({type:ut,selectors:[["app-hydrometricsite-edit"]],inputs:{hydrometricsite:"hydrometricsite",httpClientCommand:"httpClientCommand"},decls:124,vars:26,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","HydrometricSiteID"],[4,"ngIf"],["matInput","","type","number","formControlName","HydrometricSiteTVItemID"],["matInput","","type","text","formControlName","FedSiteNumber"],["matInput","","type","text","formControlName","QuebecSiteNumber"],["matInput","","type","text","formControlName","HydrometricSiteName"],["matInput","","type","text","formControlName","Description"],["matInput","","type","text","formControlName","Province"],["matInput","","type","number","formControlName","Elevation_m"],["matInput","","type","text","formControlName","StartDate_Local"],["matInput","","type","text","formControlName","EndDate_Local"],["matInput","","type","number","formControlName","TimeOffset_hour"],["matInput","","type","number","formControlName","DrainageArea_km2"],["matInput","","type","text","formControlName","IsNatural"],["matInput","","type","text","formControlName","IsActive"],["matInput","","type","text","formControlName","Sediment"],["matInput","","type","text","formControlName","RHBN"],["matInput","","type","text","formControlName","RealTime"],["matInput","","type","text","formControlName","HasDischarge"],["matInput","","type","text","formControlName","HasLevel"],["matInput","","type","text","formControlName","HasRatingCurve"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,e){1&t&&(m.Sb(0,"form",0),m.Zb("ngSubmit",(function(){return e.GetPut()?e.PutHydrometricSite(e.hydrometricsiteFormEdit.value):e.PostHydrometricSite(e.hydrometricsiteFormEdit.value)})),m.Sb(1,"h3"),m.zc(2," HydrometricSite "),m.Sb(3,"button",1),m.Sb(4,"span"),m.zc(5),m.Rb(),m.Rb(),m.yc(6,D,1,0,"mat-progress-bar",2),m.yc(7,C,1,0,"mat-progress-bar",2),m.Rb(),m.Sb(8,"p"),m.Sb(9,"mat-form-field"),m.Sb(10,"mat-label"),m.zc(11,"HydrometricSiteID"),m.Rb(),m.Nb(12,"input",3),m.yc(13,H,6,4,"mat-error",4),m.Rb(),m.Sb(14,"mat-form-field"),m.Sb(15,"mat-label"),m.zc(16,"HydrometricSiteTVItemID"),m.Rb(),m.Nb(17,"input",5),m.yc(18,L,6,4,"mat-error",4),m.Rb(),m.Sb(19,"mat-form-field"),m.Sb(20,"mat-label"),m.zc(21,"FedSiteNumber"),m.Rb(),m.Nb(22,"input",6),m.yc(23,k,6,4,"mat-error",4),m.Rb(),m.Sb(24,"mat-form-field"),m.Sb(25,"mat-label"),m.zc(26,"QuebecSiteNumber"),m.Rb(),m.Nb(27,"input",7),m.yc(28,E,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Sb(29,"p"),m.Sb(30,"mat-form-field"),m.Sb(31,"mat-label"),m.zc(32,"HydrometricSiteName"),m.Rb(),m.Nb(33,"input",8),m.yc(34,w,7,5,"mat-error",4),m.Rb(),m.Sb(35,"mat-form-field"),m.Sb(36,"mat-label"),m.zc(37,"Description"),m.Rb(),m.Nb(38,"input",9),m.yc(39,_,6,4,"mat-error",4),m.Rb(),m.Sb(40,"mat-form-field"),m.Sb(41,"mat-label"),m.zc(42,"Province"),m.Rb(),m.Nb(43,"input",10),m.yc(44,G,7,5,"mat-error",4),m.Rb(),m.Sb(45,"mat-form-field"),m.Sb(46,"mat-label"),m.zc(47,"Elevation_m"),m.Rb(),m.Nb(48,"input",11),m.yc(49,q,7,5,"mat-error",4),m.Rb(),m.Rb(),m.Sb(50,"p"),m.Sb(51,"mat-form-field"),m.Sb(52,"mat-label"),m.zc(53,"StartDate_Local"),m.Rb(),m.Nb(54,"input",12),m.yc(55,U,5,3,"mat-error",4),m.Rb(),m.Sb(56,"mat-form-field"),m.Sb(57,"mat-label"),m.zc(58,"EndDate_Local"),m.Rb(),m.Nb(59,"input",13),m.yc(60,W,5,3,"mat-error",4),m.Rb(),m.Sb(61,"mat-form-field"),m.Sb(62,"mat-label"),m.zc(63,"TimeOffset_hour"),m.Rb(),m.Nb(64,"input",14),m.yc(65,Z,7,5,"mat-error",4),m.Rb(),m.Sb(66,"mat-form-field"),m.Sb(67,"mat-label"),m.zc(68,"DrainageArea_km2"),m.Rb(),m.Nb(69,"input",15),m.yc(70,Y,7,5,"mat-error",4),m.Rb(),m.Rb(),m.Sb(71,"p"),m.Sb(72,"mat-form-field"),m.Sb(73,"mat-label"),m.zc(74,"IsNatural"),m.Rb(),m.Nb(75,"input",16),m.yc(76,tt,5,3,"mat-error",4),m.Rb(),m.Sb(77,"mat-form-field"),m.Sb(78,"mat-label"),m.zc(79,"IsActive"),m.Rb(),m.Nb(80,"input",17),m.yc(81,et,5,3,"mat-error",4),m.Rb(),m.Sb(82,"mat-form-field"),m.Sb(83,"mat-label"),m.zc(84,"Sediment"),m.Rb(),m.Nb(85,"input",18),m.yc(86,it,5,3,"mat-error",4),m.Rb(),m.Sb(87,"mat-form-field"),m.Sb(88,"mat-label"),m.zc(89,"RHBN"),m.Rb(),m.Nb(90,"input",19),m.yc(91,rt,5,3,"mat-error",4),m.Rb(),m.Rb(),m.Sb(92,"p"),m.Sb(93,"mat-form-field"),m.Sb(94,"mat-label"),m.zc(95,"RealTime"),m.Rb(),m.Nb(96,"input",20),m.yc(97,ot,5,3,"mat-error",4),m.Rb(),m.Sb(98,"mat-form-field"),m.Sb(99,"mat-label"),m.zc(100,"HasDischarge"),m.Rb(),m.Nb(101,"input",21),m.yc(102,ct,5,3,"mat-error",4),m.Rb(),m.Sb(103,"mat-form-field"),m.Sb(104,"mat-label"),m.zc(105,"HasLevel"),m.Rb(),m.Nb(106,"input",22),m.yc(107,nt,5,3,"mat-error",4),m.Rb(),m.Sb(108,"mat-form-field"),m.Sb(109,"mat-label"),m.zc(110,"HasRatingCurve"),m.Rb(),m.Nb(111,"input",23),m.yc(112,at,5,3,"mat-error",4),m.Rb(),m.Rb(),m.Sb(113,"p"),m.Sb(114,"mat-form-field"),m.Sb(115,"mat-label"),m.zc(116,"LastUpdateDate_UTC"),m.Rb(),m.Nb(117,"input",24),m.yc(118,st,6,4,"mat-error",4),m.Rb(),m.Sb(119,"mat-form-field"),m.Sb(120,"mat-label"),m.zc(121,"LastUpdateContactTVItemID"),m.Rb(),m.Nb(122,"input",25),m.yc(123,lt,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Rb()),2&t&&(m.ic("formGroup",e.hydrometricsiteFormEdit),m.Bb(5),m.Bc("",e.GetPut()?"Put":"Post"," HydrometricSite"),m.Bb(1),m.ic("ngIf",e.hydrometricsiteService.hydrometricsitePutModel$.getValue().Working),m.Bb(1),m.ic("ngIf",e.hydrometricsiteService.hydrometricsitePostModel$.getValue().Working),m.Bb(6),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.HydrometricSiteID.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.HydrometricSiteTVItemID.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.FedSiteNumber.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.QuebecSiteNumber.errors),m.Bb(6),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.HydrometricSiteName.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.Description.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.Province.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.Elevation_m.errors),m.Bb(6),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.StartDate_Local.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.EndDate_Local.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.TimeOffset_hour.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.DrainageArea_km2.errors),m.Bb(6),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.IsNatural.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.IsActive.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.Sediment.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.RHBN.errors),m.Bb(6),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.RealTime.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.HasDischarge.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.HasLevel.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.HasRatingCurve.errors),m.Bb(6),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.LastUpdateDate_UTC.errors),m.Bb(5),m.ic("ngIf",e.hydrometricsiteFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[g.q,g.l,g.f,R.b,c.l,B.c,B.f,N.b,g.n,g.c,g.k,g.e,v.a,B.b],pipes:[c.f],styles:[""],changeDetection:0}),ut);function pt(t,e){1&t&&m.Nb(0,"mat-progress-bar",4)}function ft(t,e){1&t&&m.Nb(0,"mat-progress-bar",4)}function ht(t,e){if(1&t&&(m.Sb(0,"p"),m.Nb(1,"app-hydrometricsite-edit",8),m.Rb()),2&t){var i=m.dc().$implicit,r=m.dc(2);m.Bb(1),m.ic("hydrometricsite",i)("httpClientCommand",r.GetPutEnum())}}function St(t,e){if(1&t&&(m.Sb(0,"p"),m.Nb(1,"app-hydrometricsite-edit",8),m.Rb()),2&t){var i=m.dc().$implicit,r=m.dc(2);m.Bb(1),m.ic("hydrometricsite",i)("httpClientCommand",r.GetPostEnum())}}function yt(t,e){if(1&t){var i=m.Tb();m.Sb(0,"div"),m.Sb(1,"p"),m.Sb(2,"button",6),m.Zb("click",(function(){m.qc(i);var t=e.$implicit;return m.dc(2).DeleteHydrometricSite(t)})),m.Sb(3,"span"),m.zc(4),m.Rb(),m.Sb(5,"mat-icon"),m.zc(6,"delete"),m.Rb(),m.Rb(),m.zc(7,"\xa0\xa0\xa0 "),m.Sb(8,"button",7),m.Zb("click",(function(){m.qc(i);var t=e.$implicit;return m.dc(2).ShowPut(t)})),m.Sb(9,"span"),m.zc(10,"Show Put"),m.Rb(),m.Rb(),m.zc(11,"\xa0\xa0 "),m.Sb(12,"button",7),m.Zb("click",(function(){m.qc(i);var t=e.$implicit;return m.dc(2).ShowPost(t)})),m.Sb(13,"span"),m.zc(14,"Show Post"),m.Rb(),m.Rb(),m.zc(15,"\xa0\xa0 "),m.yc(16,ft,1,0,"mat-progress-bar",0),m.Rb(),m.yc(17,ht,2,2,"p",2),m.yc(18,St,2,2,"p",2),m.Sb(19,"blockquote"),m.Sb(20,"p"),m.Sb(21,"span"),m.zc(22),m.Rb(),m.Sb(23,"span"),m.zc(24),m.Rb(),m.Sb(25,"span"),m.zc(26),m.Rb(),m.Sb(27,"span"),m.zc(28),m.Rb(),m.Rb(),m.Sb(29,"p"),m.Sb(30,"span"),m.zc(31),m.Rb(),m.Sb(32,"span"),m.zc(33),m.Rb(),m.Sb(34,"span"),m.zc(35),m.Rb(),m.Sb(36,"span"),m.zc(37),m.Rb(),m.Rb(),m.Sb(38,"p"),m.Sb(39,"span"),m.zc(40),m.Rb(),m.Sb(41,"span"),m.zc(42),m.Rb(),m.Sb(43,"span"),m.zc(44),m.Rb(),m.Sb(45,"span"),m.zc(46),m.Rb(),m.Rb(),m.Sb(47,"p"),m.Sb(48,"span"),m.zc(49),m.Rb(),m.Sb(50,"span"),m.zc(51),m.Rb(),m.Sb(52,"span"),m.zc(53),m.Rb(),m.Sb(54,"span"),m.zc(55),m.Rb(),m.Rb(),m.Sb(56,"p"),m.Sb(57,"span"),m.zc(58),m.Rb(),m.Sb(59,"span"),m.zc(60),m.Rb(),m.Sb(61,"span"),m.zc(62),m.Rb(),m.Sb(63,"span"),m.zc(64),m.Rb(),m.Rb(),m.Sb(65,"p"),m.Sb(66,"span"),m.zc(67),m.Rb(),m.Sb(68,"span"),m.zc(69),m.Rb(),m.Rb(),m.Rb(),m.Rb()}if(2&t){var r=e.$implicit,o=m.dc(2);m.Bb(4),m.Bc("Delete HydrometricSiteID [",r.HydrometricSiteID,"]\xa0\xa0\xa0"),m.Bb(4),m.ic("color",o.GetPutButtonColor(r)),m.Bb(4),m.ic("color",o.GetPostButtonColor(r)),m.Bb(4),m.ic("ngIf",o.hydrometricsiteService.hydrometricsiteDeleteModel$.getValue().Working),m.Bb(1),m.ic("ngIf",o.IDToShow===r.HydrometricSiteID&&o.showType===o.GetPutEnum()),m.Bb(1),m.ic("ngIf",o.IDToShow===r.HydrometricSiteID&&o.showType===o.GetPostEnum()),m.Bb(4),m.Bc("HydrometricSiteID: [",r.HydrometricSiteID,"]"),m.Bb(2),m.Bc(" --- HydrometricSiteTVItemID: [",r.HydrometricSiteTVItemID,"]"),m.Bb(2),m.Bc(" --- FedSiteNumber: [",r.FedSiteNumber,"]"),m.Bb(2),m.Bc(" --- QuebecSiteNumber: [",r.QuebecSiteNumber,"]"),m.Bb(3),m.Bc("HydrometricSiteName: [",r.HydrometricSiteName,"]"),m.Bb(2),m.Bc(" --- Description: [",r.Description,"]"),m.Bb(2),m.Bc(" --- Province: [",r.Province,"]"),m.Bb(2),m.Bc(" --- Elevation_m: [",r.Elevation_m,"]"),m.Bb(3),m.Bc("StartDate_Local: [",r.StartDate_Local,"]"),m.Bb(2),m.Bc(" --- EndDate_Local: [",r.EndDate_Local,"]"),m.Bb(2),m.Bc(" --- TimeOffset_hour: [",r.TimeOffset_hour,"]"),m.Bb(2),m.Bc(" --- DrainageArea_km2: [",r.DrainageArea_km2,"]"),m.Bb(3),m.Bc("IsNatural: [",r.IsNatural,"]"),m.Bb(2),m.Bc(" --- IsActive: [",r.IsActive,"]"),m.Bb(2),m.Bc(" --- Sediment: [",r.Sediment,"]"),m.Bb(2),m.Bc(" --- RHBN: [",r.RHBN,"]"),m.Bb(3),m.Bc("RealTime: [",r.RealTime,"]"),m.Bb(2),m.Bc(" --- HasDischarge: [",r.HasDischarge,"]"),m.Bb(2),m.Bc(" --- HasLevel: [",r.HasLevel,"]"),m.Bb(2),m.Bc(" --- HasRatingCurve: [",r.HasRatingCurve,"]"),m.Bb(3),m.Bc("LastUpdateDate_UTC: [",r.LastUpdateDate_UTC,"]"),m.Bb(2),m.Bc(" --- LastUpdateContactTVItemID: [",r.LastUpdateContactTVItemID,"]")}}function Rt(t,e){if(1&t&&(m.Sb(0,"div"),m.yc(1,yt,70,28,"div",5),m.Rb()),2&t){var i=m.dc();m.Bb(1),m.ic("ngForOf",i.hydrometricsiteService.hydrometricsiteListModel$.getValue())}}var vt,It,gt,Bt=[{path:"",component:(vt=function(){function e(i,r,o){t(this,e),this.hydrometricsiteService=i,this.router=r,this.httpClientService=o,this.showType=null,o.oldURL=r.url}return i(e,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.HydrometricSiteID&&this.showType===s.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.HydrometricSiteID&&this.showType===s.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.HydrometricSiteID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.HydrometricSiteID,this.showType=s.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.HydrometricSiteID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.HydrometricSiteID,this.showType=s.a.Post)}},{key:"GetPutEnum",value:function(){return s.a.Put}},{key:"GetPostEnum",value:function(){return s.a.Post}},{key:"GetHydrometricSiteList",value:function(){this.sub=this.hydrometricsiteService.GetHydrometricSiteList().subscribe()}},{key:"DeleteHydrometricSite",value:function(t){this.sub=this.hydrometricsiteService.DeleteHydrometricSite(t).subscribe()}},{key:"ngOnInit",value:function(){a(this.hydrometricsiteService.hydrometricsiteTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),e}(),vt.\u0275fac=function(t){return new(t||vt)(m.Mb(S),m.Mb(n.b),m.Mb(h.a))},vt.\u0275cmp=m.Gb({type:vt,selectors:[["app-hydrometricsite"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"hydrometricsite","httpClientCommand"]],template:function(t,e){var i,r;1&t&&(m.yc(0,pt,1,0,"mat-progress-bar",0),m.Sb(1,"mat-card"),m.Sb(2,"mat-card-header"),m.Sb(3,"mat-card-title"),m.zc(4," HydrometricSite works! "),m.Sb(5,"button",1),m.Zb("click",(function(){return e.GetHydrometricSiteList()})),m.Sb(6,"span"),m.zc(7,"Get HydrometricSite"),m.Rb(),m.Rb(),m.Rb(),m.Sb(8,"mat-card-subtitle"),m.zc(9),m.Rb(),m.Rb(),m.Sb(10,"mat-card-content"),m.yc(11,Rt,2,1,"div",2),m.Rb(),m.Sb(12,"mat-card-actions"),m.Sb(13,"button",3),m.zc(14,"Allo"),m.Rb(),m.Rb(),m.Rb()),2&t&&(m.ic("ngIf",null==(i=e.hydrometricsiteService.hydrometricsiteGetModel$.getValue())?null:i.Working),m.Bb(9),m.Ac(e.hydrometricsiteService.hydrometricsiteTextModel$.getValue().Title),m.Bb(2),m.ic("ngIf",null==(r=e.hydrometricsiteService.hydrometricsiteListModel$.getValue())?null:r.length))},directives:[c.l,y.a,y.d,y.g,R.b,y.f,y.c,y.b,v.a,c.k,I.a,dt],styles:[""],changeDetection:0}),vt),canActivate:[o("auXs").a]}],Nt=((It=function e(){t(this,e)}).\u0275mod=m.Kb({type:It}),It.\u0275inj=m.Jb({factory:function(t){return new(t||It)},imports:[[n.e.forChild(Bt)],n.e]}),It),Dt=o("B+Mi"),Ct=((gt=function e(){t(this,e)}).\u0275mod=m.Kb({type:gt}),gt.\u0275inj=m.Jb({factory:function(t){return new(t||gt)},imports:[[c.c,n.e,Nt,Dt.a,g.g,g.o]]}),gt)}}])}();