!function(){function t(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function e(t,e){for(var n=0;n<e.length;n++){var i=e[n];i.enumerable=i.enumerable||!1,i.configurable=!0,"value"in i&&(i.writable=!0),Object.defineProperty(t,i.key,i)}}function n(t,n,i){return n&&e(t.prototype,n),i&&e(t,i),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[91],{"59if":function(e,i,r){"use strict";r.r(i),r.d(i,"VPResultModule",(function(){return Rt}));var o=r("ofXK"),s=r("tyNb");function u(t){var e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var c,a=r("QRvi"),b=r("fXoL"),l=r("2Vo4"),p=r("LRne"),f=r("tk/3"),m=r("lJxs"),d=r("JIr8"),v=r("gkM4"),h=((c=function(){function e(n,i){t(this,e),this.httpClient=n,this.httpClientService=i,this.vpresultTextModel$=new l.a({}),this.vpresultListModel$=new l.a({}),this.vpresultGetModel$=new l.a({}),this.vpresultPutModel$=new l.a({}),this.vpresultPostModel$=new l.a({}),this.vpresultDeleteModel$=new l.a({}),u(this.vpresultTextModel$),this.vpresultTextModel$.next({Title:"Something2 for text"})}return n(e,[{key:"GetVPResultList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.vpresultGetModel$),this.httpClient.get("/api/VPResult").pipe(Object(m.a)((function(e){t.httpClientService.DoSuccess(t.vpresultListModel$,t.vpresultGetModel$,e,a.a.Get,null)})),Object(d.a)((function(e){return Object(p.a)(e).pipe(Object(m.a)((function(e){t.httpClientService.DoCatchError(t.vpresultListModel$,t.vpresultGetModel$,e)})))})))}},{key:"PutVPResult",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.vpresultPutModel$),this.httpClient.put("/api/VPResult",t,{headers:new f.d}).pipe(Object(m.a)((function(n){e.httpClientService.DoSuccess(e.vpresultListModel$,e.vpresultPutModel$,n,a.a.Put,t)})),Object(d.a)((function(t){return Object(p.a)(t).pipe(Object(m.a)((function(t){e.httpClientService.DoCatchError(e.vpresultListModel$,e.vpresultPutModel$,t)})))})))}},{key:"PostVPResult",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.vpresultPostModel$),this.httpClient.post("/api/VPResult",t,{headers:new f.d}).pipe(Object(m.a)((function(n){e.httpClientService.DoSuccess(e.vpresultListModel$,e.vpresultPostModel$,n,a.a.Post,t)})),Object(d.a)((function(t){return Object(p.a)(t).pipe(Object(m.a)((function(t){e.httpClientService.DoCatchError(e.vpresultListModel$,e.vpresultPostModel$,t)})))})))}},{key:"DeleteVPResult",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.vpresultDeleteModel$),this.httpClient.delete("/api/VPResult/"+t.VPResultID).pipe(Object(m.a)((function(n){e.httpClientService.DoSuccess(e.vpresultListModel$,e.vpresultDeleteModel$,n,a.a.Delete,t)})),Object(d.a)((function(t){return Object(p.a)(t).pipe(Object(m.a)((function(t){e.httpClientService.DoCatchError(e.vpresultListModel$,e.vpresultDeleteModel$,t)})))})))}}]),e}()).\u0275fac=function(t){return new(t||c)(b.Wb(f.b),b.Wb(v.a))},c.\u0275prov=b.Ib({token:c,factory:c.\u0275fac,providedIn:"root"}),c),S=r("Wp6s"),R=r("bTqV"),I=r("bv9b"),P=r("NFeN"),y=r("3Pt+"),D=r("kmnG"),g=r("qFsG");function B(t,e){1&t&&b.Nb(0,"mat-progress-bar",14)}function C(t,e){1&t&&b.Nb(0,"mat-progress-bar",14)}function V(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function N(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,V,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,n)),b.Bb(3),b.ic("ngIf",n.required)}}function z(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function M(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,z,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,n)),b.Bb(3),b.ic("ngIf",n.required)}}function T(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function k(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function $(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 1000"),b.Nb(2,"br"),b.Rb())}function w(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,T,3,0,"span",4),b.yc(6,k,3,0,"span",4),b.yc(7,$,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,n)),b.Bb(3),b.ic("ngIf",n.required),b.Bb(1),b.ic("ngIf",n.min),b.Bb(1),b.ic("ngIf",n.min)}}function _(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function q(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function F(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 10000000"),b.Nb(2,"br"),b.Rb())}function L(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,_,3,0,"span",4),b.yc(6,q,3,0,"span",4),b.yc(7,F,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,n)),b.Bb(3),b.ic("ngIf",n.required),b.Bb(1),b.ic("ngIf",n.min),b.Bb(1),b.ic("ngIf",n.min)}}function G(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function x(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function E(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 1000000"),b.Nb(2,"br"),b.Rb())}function O(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,G,3,0,"span",4),b.yc(6,x,3,0,"span",4),b.yc(7,E,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,n)),b.Bb(3),b.ic("ngIf",n.required),b.Bb(1),b.ic("ngIf",n.min),b.Bb(1),b.ic("ngIf",n.min)}}function j(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function U(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function W(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 10000"),b.Nb(2,"br"),b.Rb())}function A(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,j,3,0,"span",4),b.yc(6,U,3,0,"span",4),b.yc(7,W,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,n)),b.Bb(3),b.ic("ngIf",n.required),b.Bb(1),b.ic("ngIf",n.min),b.Bb(1),b.ic("ngIf",n.min)}}function J(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function H(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function Z(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100000"),b.Nb(2,"br"),b.Rb())}function X(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,J,3,0,"span",4),b.yc(6,H,3,0,"span",4),b.yc(7,Z,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,n)),b.Bb(3),b.ic("ngIf",n.required),b.Bb(1),b.ic("ngIf",n.min),b.Bb(1),b.ic("ngIf",n.min)}}function K(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function Q(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Min - 0"),b.Nb(2,"br"),b.Rb())}function Y(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Max - 100"),b.Nb(2,"br"),b.Rb())}function tt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,K,3,0,"span",4),b.yc(6,Q,3,0,"span",4),b.yc(7,Y,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,4,n)),b.Bb(3),b.ic("ngIf",n.required),b.Bb(1),b.ic("ngIf",n.min),b.Bb(1),b.ic("ngIf",n.min)}}function et(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function nt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,et,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,n)),b.Bb(3),b.ic("ngIf",n.required)}}function it(t,e){1&t&&(b.Sb(0,"span"),b.zc(1,"Is Required"),b.Nb(2,"br"),b.Rb())}function rt(t,e){if(1&t&&(b.Sb(0,"mat-error"),b.Sb(1,"span"),b.zc(2),b.ec(3,"json"),b.Nb(4,"br"),b.Rb(),b.yc(5,it,3,0,"span",4),b.Rb()),2&t){var n=e.$implicit;b.Bb(2),b.Ac(b.fc(3,2,n)),b.Bb(3),b.ic("ngIf",n.required)}}var ot,st=((ot=function(){function e(n,i){t(this,e),this.vpresultService=n,this.fb=i,this.vpresult=null,this.httpClientCommand=a.a.Put}return n(e,[{key:"GetPut",value:function(){return this.httpClientCommand==a.a.Put}},{key:"PutVPResult",value:function(t){this.sub=this.vpresultService.PutVPResult(t).subscribe()}},{key:"PostVPResult",value:function(t){this.sub=this.vpresultService.PostVPResult(t).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.vpresult){var e=this.fb.group({VPResultID:[{value:t===a.a.Post?0:this.vpresult.VPResultID,disabled:!1},[y.p.required]],VPScenarioID:[{value:this.vpresult.VPScenarioID,disabled:!1},[y.p.required]],Ordinal:[{value:this.vpresult.Ordinal,disabled:!1},[y.p.required,y.p.min(0),y.p.max(1e3)]],Concentration_MPN_100ml:[{value:this.vpresult.Concentration_MPN_100ml,disabled:!1},[y.p.required,y.p.min(0),y.p.max(1e7)]],Dilution:[{value:this.vpresult.Dilution,disabled:!1},[y.p.required,y.p.min(0),y.p.max(1e6)]],FarFieldWidth_m:[{value:this.vpresult.FarFieldWidth_m,disabled:!1},[y.p.required,y.p.min(0),y.p.max(1e4)]],DispersionDistance_m:[{value:this.vpresult.DispersionDistance_m,disabled:!1},[y.p.required,y.p.min(0),y.p.max(1e5)]],TravelTime_hour:[{value:this.vpresult.TravelTime_hour,disabled:!1},[y.p.required,y.p.min(0),y.p.max(100)]],LastUpdateDate_UTC:[{value:this.vpresult.LastUpdateDate_UTC,disabled:!1},[y.p.required]],LastUpdateContactTVItemID:[{value:this.vpresult.LastUpdateContactTVItemID,disabled:!1},[y.p.required]]});this.vpresultFormEdit=e}}}]),e}()).\u0275fac=function(t){return new(t||ot)(b.Mb(h),b.Mb(y.d))},ot.\u0275cmp=b.Gb({type:ot,selectors:[["app-vpresult-edit"]],inputs:{vpresult:"vpresult",httpClientCommand:"httpClientCommand"},decls:61,vars:14,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","VPResultID"],[4,"ngIf"],["matInput","","type","number","formControlName","VPScenarioID"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","number","formControlName","Concentration_MPN_100ml"],["matInput","","type","number","formControlName","Dilution"],["matInput","","type","number","formControlName","FarFieldWidth_m"],["matInput","","type","number","formControlName","DispersionDistance_m"],["matInput","","type","number","formControlName","TravelTime_hour"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,e){1&t&&(b.Sb(0,"form",0),b.Zb("ngSubmit",(function(){return e.GetPut()?e.PutVPResult(e.vpresultFormEdit.value):e.PostVPResult(e.vpresultFormEdit.value)})),b.Sb(1,"h3"),b.zc(2," VPResult "),b.Sb(3,"button",1),b.Sb(4,"span"),b.zc(5),b.Rb(),b.Rb(),b.yc(6,B,1,0,"mat-progress-bar",2),b.yc(7,C,1,0,"mat-progress-bar",2),b.Rb(),b.Sb(8,"p"),b.Sb(9,"mat-form-field"),b.Sb(10,"mat-label"),b.zc(11,"VPResultID"),b.Rb(),b.Nb(12,"input",3),b.yc(13,N,6,4,"mat-error",4),b.Rb(),b.Sb(14,"mat-form-field"),b.Sb(15,"mat-label"),b.zc(16,"VPScenarioID"),b.Rb(),b.Nb(17,"input",5),b.yc(18,M,6,4,"mat-error",4),b.Rb(),b.Sb(19,"mat-form-field"),b.Sb(20,"mat-label"),b.zc(21,"Ordinal"),b.Rb(),b.Nb(22,"input",6),b.yc(23,w,8,6,"mat-error",4),b.Rb(),b.Sb(24,"mat-form-field"),b.Sb(25,"mat-label"),b.zc(26,"Concentration_MPN_100ml"),b.Rb(),b.Nb(27,"input",7),b.yc(28,L,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"mat-form-field"),b.Sb(31,"mat-label"),b.zc(32,"Dilution"),b.Rb(),b.Nb(33,"input",8),b.yc(34,O,8,6,"mat-error",4),b.Rb(),b.Sb(35,"mat-form-field"),b.Sb(36,"mat-label"),b.zc(37,"FarFieldWidth_m"),b.Rb(),b.Nb(38,"input",9),b.yc(39,A,8,6,"mat-error",4),b.Rb(),b.Sb(40,"mat-form-field"),b.Sb(41,"mat-label"),b.zc(42,"DispersionDistance_m"),b.Rb(),b.Nb(43,"input",10),b.yc(44,X,8,6,"mat-error",4),b.Rb(),b.Sb(45,"mat-form-field"),b.Sb(46,"mat-label"),b.zc(47,"TravelTime_hour"),b.Rb(),b.Nb(48,"input",11),b.yc(49,tt,8,6,"mat-error",4),b.Rb(),b.Rb(),b.Sb(50,"p"),b.Sb(51,"mat-form-field"),b.Sb(52,"mat-label"),b.zc(53,"LastUpdateDate_UTC"),b.Rb(),b.Nb(54,"input",12),b.yc(55,nt,6,4,"mat-error",4),b.Rb(),b.Sb(56,"mat-form-field"),b.Sb(57,"mat-label"),b.zc(58,"LastUpdateContactTVItemID"),b.Rb(),b.Nb(59,"input",13),b.yc(60,rt,6,4,"mat-error",4),b.Rb(),b.Rb(),b.Rb()),2&t&&(b.ic("formGroup",e.vpresultFormEdit),b.Bb(5),b.Bc("",e.GetPut()?"Put":"Post"," VPResult"),b.Bb(1),b.ic("ngIf",e.vpresultService.vpresultPutModel$.getValue().Working),b.Bb(1),b.ic("ngIf",e.vpresultService.vpresultPostModel$.getValue().Working),b.Bb(6),b.ic("ngIf",e.vpresultFormEdit.controls.VPResultID.errors),b.Bb(5),b.ic("ngIf",e.vpresultFormEdit.controls.VPScenarioID.errors),b.Bb(5),b.ic("ngIf",e.vpresultFormEdit.controls.Ordinal.errors),b.Bb(5),b.ic("ngIf",e.vpresultFormEdit.controls.Concentration_MPN_100ml.errors),b.Bb(6),b.ic("ngIf",e.vpresultFormEdit.controls.Dilution.errors),b.Bb(5),b.ic("ngIf",e.vpresultFormEdit.controls.FarFieldWidth_m.errors),b.Bb(5),b.ic("ngIf",e.vpresultFormEdit.controls.DispersionDistance_m.errors),b.Bb(5),b.ic("ngIf",e.vpresultFormEdit.controls.TravelTime_hour.errors),b.Bb(6),b.ic("ngIf",e.vpresultFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(5),b.ic("ngIf",e.vpresultFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[y.q,y.l,y.f,R.b,o.l,D.c,D.f,g.b,y.n,y.c,y.k,y.e,I.a,D.b],pipes:[o.f],styles:[""],changeDetection:0}),ot);function ut(t,e){1&t&&b.Nb(0,"mat-progress-bar",4)}function ct(t,e){1&t&&b.Nb(0,"mat-progress-bar",4)}function at(t,e){if(1&t&&(b.Sb(0,"p"),b.Nb(1,"app-vpresult-edit",8),b.Rb()),2&t){var n=b.dc().$implicit,i=b.dc(2);b.Bb(1),b.ic("vpresult",n)("httpClientCommand",i.GetPutEnum())}}function bt(t,e){if(1&t&&(b.Sb(0,"p"),b.Nb(1,"app-vpresult-edit",8),b.Rb()),2&t){var n=b.dc().$implicit,i=b.dc(2);b.Bb(1),b.ic("vpresult",n)("httpClientCommand",i.GetPostEnum())}}function lt(t,e){if(1&t){var n=b.Tb();b.Sb(0,"div"),b.Sb(1,"p"),b.Sb(2,"button",6),b.Zb("click",(function(){b.qc(n);var t=e.$implicit;return b.dc(2).DeleteVPResult(t)})),b.Sb(3,"span"),b.zc(4),b.Rb(),b.Sb(5,"mat-icon"),b.zc(6,"delete"),b.Rb(),b.Rb(),b.zc(7,"\xa0\xa0\xa0 "),b.Sb(8,"button",7),b.Zb("click",(function(){b.qc(n);var t=e.$implicit;return b.dc(2).ShowPut(t)})),b.Sb(9,"span"),b.zc(10,"Show Put"),b.Rb(),b.Rb(),b.zc(11,"\xa0\xa0 "),b.Sb(12,"button",7),b.Zb("click",(function(){b.qc(n);var t=e.$implicit;return b.dc(2).ShowPost(t)})),b.Sb(13,"span"),b.zc(14,"Show Post"),b.Rb(),b.Rb(),b.zc(15,"\xa0\xa0 "),b.yc(16,ct,1,0,"mat-progress-bar",0),b.Rb(),b.yc(17,at,2,2,"p",2),b.yc(18,bt,2,2,"p",2),b.Sb(19,"blockquote"),b.Sb(20,"p"),b.Sb(21,"span"),b.zc(22),b.Rb(),b.Sb(23,"span"),b.zc(24),b.Rb(),b.Sb(25,"span"),b.zc(26),b.Rb(),b.Sb(27,"span"),b.zc(28),b.Rb(),b.Rb(),b.Sb(29,"p"),b.Sb(30,"span"),b.zc(31),b.Rb(),b.Sb(32,"span"),b.zc(33),b.Rb(),b.Sb(34,"span"),b.zc(35),b.Rb(),b.Sb(36,"span"),b.zc(37),b.Rb(),b.Rb(),b.Sb(38,"p"),b.Sb(39,"span"),b.zc(40),b.Rb(),b.Sb(41,"span"),b.zc(42),b.Rb(),b.Rb(),b.Rb(),b.Rb()}if(2&t){var i=e.$implicit,r=b.dc(2);b.Bb(4),b.Bc("Delete VPResultID [",i.VPResultID,"]\xa0\xa0\xa0"),b.Bb(4),b.ic("color",r.GetPutButtonColor(i)),b.Bb(4),b.ic("color",r.GetPostButtonColor(i)),b.Bb(4),b.ic("ngIf",r.vpresultService.vpresultDeleteModel$.getValue().Working),b.Bb(1),b.ic("ngIf",r.IDToShow===i.VPResultID&&r.showType===r.GetPutEnum()),b.Bb(1),b.ic("ngIf",r.IDToShow===i.VPResultID&&r.showType===r.GetPostEnum()),b.Bb(4),b.Bc("VPResultID: [",i.VPResultID,"]"),b.Bb(2),b.Bc(" --- VPScenarioID: [",i.VPScenarioID,"]"),b.Bb(2),b.Bc(" --- Ordinal: [",i.Ordinal,"]"),b.Bb(2),b.Bc(" --- Concentration_MPN_100ml: [",i.Concentration_MPN_100ml,"]"),b.Bb(3),b.Bc("Dilution: [",i.Dilution,"]"),b.Bb(2),b.Bc(" --- FarFieldWidth_m: [",i.FarFieldWidth_m,"]"),b.Bb(2),b.Bc(" --- DispersionDistance_m: [",i.DispersionDistance_m,"]"),b.Bb(2),b.Bc(" --- TravelTime_hour: [",i.TravelTime_hour,"]"),b.Bb(3),b.Bc("LastUpdateDate_UTC: [",i.LastUpdateDate_UTC,"]"),b.Bb(2),b.Bc(" --- LastUpdateContactTVItemID: [",i.LastUpdateContactTVItemID,"]")}}function pt(t,e){if(1&t&&(b.Sb(0,"div"),b.yc(1,lt,43,16,"div",5),b.Rb()),2&t){var n=b.dc();b.Bb(1),b.ic("ngForOf",n.vpresultService.vpresultListModel$.getValue())}}var ft,mt,dt,vt=[{path:"",component:(ft=function(){function e(n,i,r){t(this,e),this.vpresultService=n,this.router=i,this.httpClientService=r,this.showType=null,r.oldURL=i.url}return n(e,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.VPResultID&&this.showType===a.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.VPResultID&&this.showType===a.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.VPResultID&&this.showType===a.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.VPResultID,this.showType=a.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.VPResultID&&this.showType===a.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.VPResultID,this.showType=a.a.Post)}},{key:"GetPutEnum",value:function(){return a.a.Put}},{key:"GetPostEnum",value:function(){return a.a.Post}},{key:"GetVPResultList",value:function(){this.sub=this.vpresultService.GetVPResultList().subscribe()}},{key:"DeleteVPResult",value:function(t){this.sub=this.vpresultService.DeleteVPResult(t).subscribe()}},{key:"ngOnInit",value:function(){u(this.vpresultService.vpresultTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),e}(),ft.\u0275fac=function(t){return new(t||ft)(b.Mb(h),b.Mb(s.b),b.Mb(v.a))},ft.\u0275cmp=b.Gb({type:ft,selectors:[["app-vpresult"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"vpresult","httpClientCommand"]],template:function(t,e){if(1&t&&(b.yc(0,ut,1,0,"mat-progress-bar",0),b.Sb(1,"mat-card"),b.Sb(2,"mat-card-header"),b.Sb(3,"mat-card-title"),b.zc(4," VPResult works! "),b.Sb(5,"button",1),b.Zb("click",(function(){return e.GetVPResultList()})),b.Sb(6,"span"),b.zc(7,"Get VPResult"),b.Rb(),b.Rb(),b.Rb(),b.Sb(8,"mat-card-subtitle"),b.zc(9),b.Rb(),b.Rb(),b.Sb(10,"mat-card-content"),b.yc(11,pt,2,1,"div",2),b.Rb(),b.Sb(12,"mat-card-actions"),b.Sb(13,"button",3),b.zc(14,"Allo"),b.Rb(),b.Rb(),b.Rb()),2&t){var n,i,r=null==(n=e.vpresultService.vpresultGetModel$.getValue())?null:n.Working,o=null==(i=e.vpresultService.vpresultListModel$.getValue())?null:i.length;b.ic("ngIf",r),b.Bb(9),b.Ac(e.vpresultService.vpresultTextModel$.getValue().Title),b.Bb(2),b.ic("ngIf",o)}},directives:[o.l,S.a,S.d,S.g,R.b,S.f,S.c,S.b,I.a,o.k,P.a,st],styles:[""],changeDetection:0}),ft),canActivate:[r("auXs").a]}],ht=((mt=function e(){t(this,e)}).\u0275mod=b.Kb({type:mt}),mt.\u0275inj=b.Jb({factory:function(t){return new(t||mt)},imports:[[s.e.forChild(vt)],s.e]}),mt),St=r("B+Mi"),Rt=((dt=function e(){t(this,e)}).\u0275mod=b.Kb({type:dt}),dt.\u0275inj=b.Jb({factory:function(t){return new(t||dt)},imports:[[o.c,s.e,ht,St.a,y.g,y.o]]}),dt)},QRvi:function(t,e,n){"use strict";n.d(e,"a",(function(){return i}));var i=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(e,i,r){"use strict";r.d(i,"a",(function(){return c}));var o=r("QRvi"),s=r("fXoL"),u=r("tyNb"),c=function(){var e=function(){function e(n){t(this,e),this.router=n,this.oldURL=n.url}return n(e,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,e,n,i,r){if(i===o.a.Get&&t.next(n),i===o.a.Put&&(t.getValue()[0]=n),i===o.a.Post&&t.getValue().push(n),i===o.a.Delete){var s=t.getValue().indexOf(r);t.getValue().splice(s,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,e,n,i,r){i===o.a.Get&&t.next(n),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(s.Wb(u.b))},e.\u0275prov=s.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()}}])}();