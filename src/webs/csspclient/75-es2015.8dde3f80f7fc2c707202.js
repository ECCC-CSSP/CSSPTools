(window.webpackJsonp=window.webpackJsonp||[]).push([[75],{QRvi:function(e,t,n){"use strict";n.d(t,"a",(function(){return c}));var c=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},R7CB:function(e,t,n){"use strict";n.r(t),n.d(t,"RainExceedanceModule",(function(){return ue}));var c=n("ofXK"),a=n("tyNb");function i(e){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var r=n("QRvi"),o=n("fXoL"),b=n("2Vo4"),s=n("LRne"),d=n("tk/3"),l=n("lJxs"),u=n("JIr8"),m=n("gkM4");let p=(()=>{class e{constructor(e,t){this.httpClient=e,this.httpClientService=t,this.rainexceedanceTextModel$=new b.a({}),this.rainexceedanceListModel$=new b.a({}),this.rainexceedanceGetModel$=new b.a({}),this.rainexceedancePutModel$=new b.a({}),this.rainexceedancePostModel$=new b.a({}),this.rainexceedanceDeleteModel$=new b.a({}),i(this.rainexceedanceTextModel$),this.rainexceedanceTextModel$.next({Title:"Something2 for text"})}GetRainExceedanceList(){return this.httpClientService.BeforeHttpClient(this.rainexceedanceGetModel$),this.httpClient.get("/api/RainExceedance").pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.rainexceedanceListModel$,this.rainexceedanceGetModel$,e,r.a.Get,null)}),Object(u.a)(e=>Object(s.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.rainexceedanceListModel$,this.rainexceedanceGetModel$,e)}))))}PutRainExceedance(e){return this.httpClientService.BeforeHttpClient(this.rainexceedancePutModel$),this.httpClient.put("/api/RainExceedance",e,{headers:new d.d}).pipe(Object(l.a)(t=>{this.httpClientService.DoSuccess(this.rainexceedanceListModel$,this.rainexceedancePutModel$,t,r.a.Put,e)}),Object(u.a)(e=>Object(s.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.rainexceedanceListModel$,this.rainexceedancePutModel$,e)}))))}PostRainExceedance(e){return this.httpClientService.BeforeHttpClient(this.rainexceedancePostModel$),this.httpClient.post("/api/RainExceedance",e,{headers:new d.d}).pipe(Object(l.a)(t=>{this.httpClientService.DoSuccess(this.rainexceedanceListModel$,this.rainexceedancePostModel$,t,r.a.Post,e)}),Object(u.a)(e=>Object(s.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.rainexceedanceListModel$,this.rainexceedancePostModel$,e)}))))}DeleteRainExceedance(e){return this.httpClientService.BeforeHttpClient(this.rainexceedanceDeleteModel$),this.httpClient.delete("/api/RainExceedance/"+e.RainExceedanceID).pipe(Object(l.a)(t=>{this.httpClientService.DoSuccess(this.rainexceedanceListModel$,this.rainexceedanceDeleteModel$,t,r.a.Delete,e)}),Object(u.a)(e=>Object(s.a)(e).pipe(Object(l.a)(e=>{this.httpClientService.DoCatchError(this.rainexceedanceListModel$,this.rainexceedanceDeleteModel$,e)}))))}}return e.\u0275fac=function(t){return new(t||e)(o.Xb(d.b),o.Xb(m.a))},e.\u0275prov=o.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var f=n("Wp6s"),x=n("bTqV"),h=n("bv9b"),S=n("NFeN"),T=n("3Pt+"),I=n("kmnG"),y=n("qFsG");function D(e,t){1&e&&o.Ob(0,"mat-progress-bar",16)}function E(e,t){1&e&&o.Ob(0,"mat-progress-bar",16)}function g(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function B(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,g,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,e)),o.Bb(3),o.jc("ngIf",e.required)}}function v(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function C(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,v,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,e)),o.Bb(3),o.jc("ngIf",e.required)}}function O(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function R(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 1"),o.Ob(2,"br"),o.Sb())}function j(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 12"),o.Ob(2,"br"),o.Sb())}function M(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,O,3,0,"span",4),o.xc(6,R,3,0,"span",4),o.xc(7,j,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,4,e)),o.Bb(3),o.jc("ngIf",e.required),o.Bb(1),o.jc("ngIf",e.min),o.Bb(1),o.jc("ngIf",e.min)}}function P(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function $(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 1"),o.Ob(2,"br"),o.Sb())}function L(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 31"),o.Ob(2,"br"),o.Sb())}function w(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,P,3,0,"span",4),o.xc(6,$,3,0,"span",4),o.xc(7,L,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,4,e)),o.Bb(3),o.jc("ngIf",e.required),o.Bb(1),o.jc("ngIf",e.min),o.Bb(1),o.jc("ngIf",e.min)}}function k(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function q(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 1"),o.Ob(2,"br"),o.Sb())}function G(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 12"),o.Ob(2,"br"),o.Sb())}function V(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,k,3,0,"span",4),o.xc(6,q,3,0,"span",4),o.xc(7,G,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,4,e)),o.Bb(3),o.jc("ngIf",e.required),o.Bb(1),o.jc("ngIf",e.min),o.Bb(1),o.jc("ngIf",e.min)}}function U(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function F(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 1"),o.Ob(2,"br"),o.Sb())}function A(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 31"),o.Ob(2,"br"),o.Sb())}function N(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,U,3,0,"span",4),o.xc(6,F,3,0,"span",4),o.xc(7,A,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,4,e)),o.Bb(3),o.jc("ngIf",e.required),o.Bb(1),o.jc("ngIf",e.min),o.Bb(1),o.jc("ngIf",e.min)}}function z(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function _(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 0"),o.Ob(2,"br"),o.Sb())}function W(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 300"),o.Ob(2,"br"),o.Sb())}function H(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,z,3,0,"span",4),o.xc(6,_,3,0,"span",4),o.xc(7,W,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,4,e)),o.Bb(3),o.jc("ngIf",e.required),o.Bb(1),o.jc("ngIf",e.min),o.Bb(1),o.jc("ngIf",e.min)}}function X(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,1,e))}}function J(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,1,e))}}function K(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function Q(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,K,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,e)),o.Bb(3),o.jc("ngIf",e.required)}}function Y(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function Z(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,Y,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,e)),o.Bb(3),o.jc("ngIf",e.required)}}function ee(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function te(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,ee,3,0,"span",4),o.Sb()),2&e){const e=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,e)),o.Bb(3),o.jc("ngIf",e.required)}}let ne=(()=>{class e{constructor(e,t){this.rainexceedanceService=e,this.fb=t,this.rainexceedance=null,this.httpClientCommand=r.a.Put}GetPut(){return this.httpClientCommand==r.a.Put}PutRainExceedance(e){this.sub=this.rainexceedanceService.PutRainExceedance(e).subscribe()}PostRainExceedance(e){this.sub=this.rainexceedanceService.PostRainExceedance(e).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.rainexceedance){let t=this.fb.group({RainExceedanceID:[{value:e===r.a.Post?0:this.rainexceedance.RainExceedanceID,disabled:!1},[T.p.required]],RainExceedanceTVItemID:[{value:this.rainexceedance.RainExceedanceTVItemID,disabled:!1},[T.p.required]],StartMonth:[{value:this.rainexceedance.StartMonth,disabled:!1},[T.p.required,T.p.min(1),T.p.max(12)]],StartDay:[{value:this.rainexceedance.StartDay,disabled:!1},[T.p.required,T.p.min(1),T.p.max(31)]],EndMonth:[{value:this.rainexceedance.EndMonth,disabled:!1},[T.p.required,T.p.min(1),T.p.max(12)]],EndDay:[{value:this.rainexceedance.EndDay,disabled:!1},[T.p.required,T.p.min(1),T.p.max(31)]],RainMaximum_mm:[{value:this.rainexceedance.RainMaximum_mm,disabled:!1},[T.p.required,T.p.min(0),T.p.max(300)]],StakeholdersEmailDistributionListID:[{value:this.rainexceedance.StakeholdersEmailDistributionListID,disabled:!1}],OnlyStaffEmailDistributionListID:[{value:this.rainexceedance.OnlyStaffEmailDistributionListID,disabled:!1}],IsActive:[{value:this.rainexceedance.IsActive,disabled:!1},[T.p.required]],LastUpdateDate_UTC:[{value:this.rainexceedance.LastUpdateDate_UTC,disabled:!1},[T.p.required]],LastUpdateContactTVItemID:[{value:this.rainexceedance.LastUpdateContactTVItemID,disabled:!1},[T.p.required]]});this.rainexceedanceFormEdit=t}}}return e.\u0275fac=function(t){return new(t||e)(o.Nb(p),o.Nb(T.d))},e.\u0275cmp=o.Hb({type:e,selectors:[["app-rainexceedance-edit"]],inputs:{rainexceedance:"rainexceedance",httpClientCommand:"httpClientCommand"},decls:71,vars:16,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","RainExceedanceID"],[4,"ngIf"],["matInput","","type","number","formControlName","RainExceedanceTVItemID"],["matInput","","type","number","formControlName","StartMonth"],["matInput","","type","number","formControlName","StartDay"],["matInput","","type","number","formControlName","EndMonth"],["matInput","","type","number","formControlName","EndDay"],["matInput","","type","number","formControlName","RainMaximum_mm"],["matInput","","type","number","formControlName","StakeholdersEmailDistributionListID"],["matInput","","type","number","formControlName","OnlyStaffEmailDistributionListID"],["matInput","","type","text","formControlName","IsActive"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(e,t){1&e&&(o.Tb(0,"form",0),o.ac("ngSubmit",(function(){return t.GetPut()?t.PutRainExceedance(t.rainexceedanceFormEdit.value):t.PostRainExceedance(t.rainexceedanceFormEdit.value)})),o.Tb(1,"h3"),o.yc(2," RainExceedance "),o.Tb(3,"button",1),o.Tb(4,"span"),o.yc(5),o.Sb(),o.Sb(),o.xc(6,D,1,0,"mat-progress-bar",2),o.xc(7,E,1,0,"mat-progress-bar",2),o.Sb(),o.Tb(8,"p"),o.Tb(9,"mat-form-field"),o.Tb(10,"mat-label"),o.yc(11,"RainExceedanceID"),o.Sb(),o.Ob(12,"input",3),o.xc(13,B,6,4,"mat-error",4),o.Sb(),o.Tb(14,"mat-form-field"),o.Tb(15,"mat-label"),o.yc(16,"RainExceedanceTVItemID"),o.Sb(),o.Ob(17,"input",5),o.xc(18,C,6,4,"mat-error",4),o.Sb(),o.Tb(19,"mat-form-field"),o.Tb(20,"mat-label"),o.yc(21,"StartMonth"),o.Sb(),o.Ob(22,"input",6),o.xc(23,M,8,6,"mat-error",4),o.Sb(),o.Tb(24,"mat-form-field"),o.Tb(25,"mat-label"),o.yc(26,"StartDay"),o.Sb(),o.Ob(27,"input",7),o.xc(28,w,8,6,"mat-error",4),o.Sb(),o.Sb(),o.Tb(29,"p"),o.Tb(30,"mat-form-field"),o.Tb(31,"mat-label"),o.yc(32,"EndMonth"),o.Sb(),o.Ob(33,"input",8),o.xc(34,V,8,6,"mat-error",4),o.Sb(),o.Tb(35,"mat-form-field"),o.Tb(36,"mat-label"),o.yc(37,"EndDay"),o.Sb(),o.Ob(38,"input",9),o.xc(39,N,8,6,"mat-error",4),o.Sb(),o.Tb(40,"mat-form-field"),o.Tb(41,"mat-label"),o.yc(42,"RainMaximum_mm"),o.Sb(),o.Ob(43,"input",10),o.xc(44,H,8,6,"mat-error",4),o.Sb(),o.Tb(45,"mat-form-field"),o.Tb(46,"mat-label"),o.yc(47,"StakeholdersEmailDistributionListID"),o.Sb(),o.Ob(48,"input",11),o.xc(49,X,5,3,"mat-error",4),o.Sb(),o.Sb(),o.Tb(50,"p"),o.Tb(51,"mat-form-field"),o.Tb(52,"mat-label"),o.yc(53,"OnlyStaffEmailDistributionListID"),o.Sb(),o.Ob(54,"input",12),o.xc(55,J,5,3,"mat-error",4),o.Sb(),o.Tb(56,"mat-form-field"),o.Tb(57,"mat-label"),o.yc(58,"IsActive"),o.Sb(),o.Ob(59,"input",13),o.xc(60,Q,6,4,"mat-error",4),o.Sb(),o.Tb(61,"mat-form-field"),o.Tb(62,"mat-label"),o.yc(63,"LastUpdateDate_UTC"),o.Sb(),o.Ob(64,"input",14),o.xc(65,Z,6,4,"mat-error",4),o.Sb(),o.Tb(66,"mat-form-field"),o.Tb(67,"mat-label"),o.yc(68,"LastUpdateContactTVItemID"),o.Sb(),o.Ob(69,"input",15),o.xc(70,te,6,4,"mat-error",4),o.Sb(),o.Sb(),o.Sb()),2&e&&(o.jc("formGroup",t.rainexceedanceFormEdit),o.Bb(5),o.Ac("",t.GetPut()?"Put":"Post"," RainExceedance"),o.Bb(1),o.jc("ngIf",t.rainexceedanceService.rainexceedancePutModel$.getValue().Working),o.Bb(1),o.jc("ngIf",t.rainexceedanceService.rainexceedancePostModel$.getValue().Working),o.Bb(6),o.jc("ngIf",t.rainexceedanceFormEdit.controls.RainExceedanceID.errors),o.Bb(5),o.jc("ngIf",t.rainexceedanceFormEdit.controls.RainExceedanceTVItemID.errors),o.Bb(5),o.jc("ngIf",t.rainexceedanceFormEdit.controls.StartMonth.errors),o.Bb(5),o.jc("ngIf",t.rainexceedanceFormEdit.controls.StartDay.errors),o.Bb(6),o.jc("ngIf",t.rainexceedanceFormEdit.controls.EndMonth.errors),o.Bb(5),o.jc("ngIf",t.rainexceedanceFormEdit.controls.EndDay.errors),o.Bb(5),o.jc("ngIf",t.rainexceedanceFormEdit.controls.RainMaximum_mm.errors),o.Bb(5),o.jc("ngIf",t.rainexceedanceFormEdit.controls.StakeholdersEmailDistributionListID.errors),o.Bb(6),o.jc("ngIf",t.rainexceedanceFormEdit.controls.OnlyStaffEmailDistributionListID.errors),o.Bb(5),o.jc("ngIf",t.rainexceedanceFormEdit.controls.IsActive.errors),o.Bb(5),o.jc("ngIf",t.rainexceedanceFormEdit.controls.LastUpdateDate_UTC.errors),o.Bb(5),o.jc("ngIf",t.rainexceedanceFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[T.q,T.l,T.f,x.b,c.l,I.c,I.f,y.b,T.n,T.c,T.k,T.e,h.a,I.b],pipes:[c.f],styles:[""],changeDetection:0}),e})();function ce(e,t){1&e&&o.Ob(0,"mat-progress-bar",4)}function ae(e,t){1&e&&o.Ob(0,"mat-progress-bar",4)}function ie(e,t){if(1&e&&(o.Tb(0,"p"),o.Ob(1,"app-rainexceedance-edit",8),o.Sb()),2&e){const e=o.ec().$implicit,t=o.ec(2);o.Bb(1),o.jc("rainexceedance",e)("httpClientCommand",t.GetPutEnum())}}function re(e,t){if(1&e&&(o.Tb(0,"p"),o.Ob(1,"app-rainexceedance-edit",8),o.Sb()),2&e){const e=o.ec().$implicit,t=o.ec(2);o.Bb(1),o.jc("rainexceedance",e)("httpClientCommand",t.GetPostEnum())}}function oe(e,t){if(1&e){const e=o.Ub();o.Tb(0,"div"),o.Tb(1,"p"),o.Tb(2,"button",6),o.ac("click",(function(){o.rc(e);const n=t.$implicit;return o.ec(2).DeleteRainExceedance(n)})),o.Tb(3,"span"),o.yc(4),o.Sb(),o.Tb(5,"mat-icon"),o.yc(6,"delete"),o.Sb(),o.Sb(),o.yc(7,"\xa0\xa0\xa0 "),o.Tb(8,"button",7),o.ac("click",(function(){o.rc(e);const n=t.$implicit;return o.ec(2).ShowPut(n)})),o.Tb(9,"span"),o.yc(10,"Show Put"),o.Sb(),o.Sb(),o.yc(11,"\xa0\xa0 "),o.Tb(12,"button",7),o.ac("click",(function(){o.rc(e);const n=t.$implicit;return o.ec(2).ShowPost(n)})),o.Tb(13,"span"),o.yc(14,"Show Post"),o.Sb(),o.Sb(),o.yc(15,"\xa0\xa0 "),o.xc(16,ae,1,0,"mat-progress-bar",0),o.Sb(),o.xc(17,ie,2,2,"p",2),o.xc(18,re,2,2,"p",2),o.Tb(19,"blockquote"),o.Tb(20,"p"),o.Tb(21,"span"),o.yc(22),o.Sb(),o.Tb(23,"span"),o.yc(24),o.Sb(),o.Tb(25,"span"),o.yc(26),o.Sb(),o.Tb(27,"span"),o.yc(28),o.Sb(),o.Sb(),o.Tb(29,"p"),o.Tb(30,"span"),o.yc(31),o.Sb(),o.Tb(32,"span"),o.yc(33),o.Sb(),o.Tb(34,"span"),o.yc(35),o.Sb(),o.Tb(36,"span"),o.yc(37),o.Sb(),o.Sb(),o.Tb(38,"p"),o.Tb(39,"span"),o.yc(40),o.Sb(),o.Tb(41,"span"),o.yc(42),o.Sb(),o.Tb(43,"span"),o.yc(44),o.Sb(),o.Tb(45,"span"),o.yc(46),o.Sb(),o.Sb(),o.Sb(),o.Sb()}if(2&e){const e=t.$implicit,n=o.ec(2);o.Bb(4),o.Ac("Delete RainExceedanceID [",e.RainExceedanceID,"]\xa0\xa0\xa0"),o.Bb(4),o.jc("color",n.GetPutButtonColor(e)),o.Bb(4),o.jc("color",n.GetPostButtonColor(e)),o.Bb(4),o.jc("ngIf",n.rainexceedanceService.rainexceedanceDeleteModel$.getValue().Working),o.Bb(1),o.jc("ngIf",n.IDToShow===e.RainExceedanceID&&n.showType===n.GetPutEnum()),o.Bb(1),o.jc("ngIf",n.IDToShow===e.RainExceedanceID&&n.showType===n.GetPostEnum()),o.Bb(4),o.Ac("RainExceedanceID: [",e.RainExceedanceID,"]"),o.Bb(2),o.Ac(" --- RainExceedanceTVItemID: [",e.RainExceedanceTVItemID,"]"),o.Bb(2),o.Ac(" --- StartMonth: [",e.StartMonth,"]"),o.Bb(2),o.Ac(" --- StartDay: [",e.StartDay,"]"),o.Bb(3),o.Ac("EndMonth: [",e.EndMonth,"]"),o.Bb(2),o.Ac(" --- EndDay: [",e.EndDay,"]"),o.Bb(2),o.Ac(" --- RainMaximum_mm: [",e.RainMaximum_mm,"]"),o.Bb(2),o.Ac(" --- StakeholdersEmailDistributionListID: [",e.StakeholdersEmailDistributionListID,"]"),o.Bb(3),o.Ac("OnlyStaffEmailDistributionListID: [",e.OnlyStaffEmailDistributionListID,"]"),o.Bb(2),o.Ac(" --- IsActive: [",e.IsActive,"]"),o.Bb(2),o.Ac(" --- LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),o.Bb(2),o.Ac(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function be(e,t){if(1&e&&(o.Tb(0,"div"),o.xc(1,oe,47,18,"div",5),o.Sb()),2&e){const e=o.ec();o.Bb(1),o.jc("ngForOf",e.rainexceedanceService.rainexceedanceListModel$.getValue())}}const se=[{path:"",component:(()=>{class e{constructor(e,t,n){this.rainexceedanceService=e,this.router=t,this.httpClientService=n,this.showType=null,n.oldURL=t.url}GetPutButtonColor(e){return this.IDToShow===e.RainExceedanceID&&this.showType===r.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.RainExceedanceID&&this.showType===r.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.RainExceedanceID&&this.showType===r.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RainExceedanceID,this.showType=r.a.Put)}ShowPost(e){this.IDToShow===e.RainExceedanceID&&this.showType===r.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RainExceedanceID,this.showType=r.a.Post)}GetPutEnum(){return r.a.Put}GetPostEnum(){return r.a.Post}GetRainExceedanceList(){this.sub=this.rainexceedanceService.GetRainExceedanceList().subscribe()}DeleteRainExceedance(e){this.sub=this.rainexceedanceService.DeleteRainExceedance(e).subscribe()}ngOnInit(){i(this.rainexceedanceService.rainexceedanceTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(t){return new(t||e)(o.Nb(p),o.Nb(a.b),o.Nb(m.a))},e.\u0275cmp=o.Hb({type:e,selectors:[["app-rainexceedance"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"rainexceedance","httpClientCommand"]],template:function(e,t){if(1&e&&(o.xc(0,ce,1,0,"mat-progress-bar",0),o.Tb(1,"mat-card"),o.Tb(2,"mat-card-header"),o.Tb(3,"mat-card-title"),o.yc(4," RainExceedance works! "),o.Tb(5,"button",1),o.ac("click",(function(){return t.GetRainExceedanceList()})),o.Tb(6,"span"),o.yc(7,"Get RainExceedance"),o.Sb(),o.Sb(),o.Sb(),o.Tb(8,"mat-card-subtitle"),o.yc(9),o.Sb(),o.Sb(),o.Tb(10,"mat-card-content"),o.xc(11,be,2,1,"div",2),o.Sb(),o.Tb(12,"mat-card-actions"),o.Tb(13,"button",3),o.yc(14,"Allo"),o.Sb(),o.Sb(),o.Sb()),2&e){var n;const e=null==(n=t.rainexceedanceService.rainexceedanceGetModel$.getValue())?null:n.Working;var c;const a=null==(c=t.rainexceedanceService.rainexceedanceListModel$.getValue())?null:c.length;o.jc("ngIf",e),o.Bb(9),o.zc(t.rainexceedanceService.rainexceedanceTextModel$.getValue().Title),o.Bb(2),o.jc("ngIf",a)}},directives:[c.l,f.a,f.d,f.g,x.b,f.f,f.c,f.b,h.a,c.k,S.a,ne],styles:[""],changeDetection:0}),e})(),canActivate:[n("auXs").a]}];let de=(()=>{class e{}return e.\u0275mod=o.Lb({type:e}),e.\u0275inj=o.Kb({factory:function(t){return new(t||e)},imports:[[a.e.forChild(se)],a.e]}),e})();var le=n("B+Mi");let ue=(()=>{class e{}return e.\u0275mod=o.Lb({type:e}),e.\u0275inj=o.Kb({factory:function(t){return new(t||e)},imports:[[c.c,a.e,de,le.a,T.g,T.o]]}),e})()},gkM4:function(e,t,n){"use strict";n.d(t,"a",(function(){return r}));var c=n("QRvi"),a=n("fXoL"),i=n("tyNb");let r=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,t,n){e.next(null),t.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(e,t,n){e.next(null),t.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,t,n,a,i){if(a===c.a.Get&&e.next(n),a===c.a.Put&&(e.getValue()[0]=n),a===c.a.Post&&e.getValue().push(n),a===c.a.Delete){const t=e.getValue().indexOf(i);e.getValue().splice(t,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(e,t,n,a,i){a===c.a.Get&&e.next(n),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(t){return new(t||e)(a.Xb(i.b))},e.\u0275prov=a.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()}}]);