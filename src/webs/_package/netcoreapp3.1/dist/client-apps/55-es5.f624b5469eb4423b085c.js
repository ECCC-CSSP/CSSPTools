function _classCallCheck(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function _defineProperties(e,t){for(var a=0;a<t.length;a++){var b=t[a];b.enumerable=b.enumerable||!1,b.configurable=!0,"value"in b&&(b.writable=!0),Object.defineProperty(e,b.key,b)}}function _createClass(e,t,a){return t&&_defineProperties(e.prototype,t),a&&_defineProperties(e,a),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[55],{Go4k:function(e,t,a){"use strict";a.r(t),a.d(t,"LabSheetTubeMPNDetailModule",(function(){return Le}));var b=a("ofXK"),n=a("tyNb");function i(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var r,l=a("KyBE"),c=a("QRvi"),o=a("fXoL"),u=a("2Vo4"),s=a("LRne"),p=a("tk/3"),m=a("lJxs"),h=a("JIr8"),d=a("gkM4"),f=((r=function(){function e(t,a){_classCallCheck(this,e),this.httpClient=t,this.httpClientService=a,this.labsheettubempndetailTextModel$=new u.a({}),this.labsheettubempndetailListModel$=new u.a({}),this.labsheettubempndetailGetModel$=new u.a({}),this.labsheettubempndetailPutModel$=new u.a({}),this.labsheettubempndetailPostModel$=new u.a({}),this.labsheettubempndetailDeleteModel$=new u.a({}),i(this.labsheettubempndetailTextModel$),this.labsheettubempndetailTextModel$.next({Title:"Something2 for text"})}return _createClass(e,[{key:"GetLabSheetTubeMPNDetailList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.labsheettubempndetailGetModel$),this.httpClient.get("/api/LabSheetTubeMPNDetail").pipe(Object(m.a)((function(t){e.httpClientService.DoSuccess(e.labsheettubempndetailListModel$,e.labsheettubempndetailGetModel$,t,c.a.Get,null)})),Object(h.a)((function(t){return Object(s.a)(t).pipe(Object(m.a)((function(t){e.httpClientService.DoCatchError(e.labsheettubempndetailListModel$,e.labsheettubempndetailGetModel$,t)})))})))}},{key:"PutLabSheetTubeMPNDetail",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.labsheettubempndetailPutModel$),this.httpClient.put("/api/LabSheetTubeMPNDetail",e,{headers:new p.d}).pipe(Object(m.a)((function(a){t.httpClientService.DoSuccess(t.labsheettubempndetailListModel$,t.labsheettubempndetailPutModel$,a,c.a.Put,e)})),Object(h.a)((function(e){return Object(s.a)(e).pipe(Object(m.a)((function(e){t.httpClientService.DoCatchError(t.labsheettubempndetailListModel$,t.labsheettubempndetailPutModel$,e)})))})))}},{key:"PostLabSheetTubeMPNDetail",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.labsheettubempndetailPostModel$),this.httpClient.post("/api/LabSheetTubeMPNDetail",e,{headers:new p.d}).pipe(Object(m.a)((function(a){t.httpClientService.DoSuccess(t.labsheettubempndetailListModel$,t.labsheettubempndetailPostModel$,a,c.a.Post,e)})),Object(h.a)((function(e){return Object(s.a)(e).pipe(Object(m.a)((function(e){t.httpClientService.DoCatchError(t.labsheettubempndetailListModel$,t.labsheettubempndetailPostModel$,e)})))})))}},{key:"DeleteLabSheetTubeMPNDetail",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.labsheettubempndetailDeleteModel$),this.httpClient.delete("/api/LabSheetTubeMPNDetail/"+e.LabSheetTubeMPNDetailID).pipe(Object(m.a)((function(a){t.httpClientService.DoSuccess(t.labsheettubempndetailListModel$,t.labsheettubempndetailDeleteModel$,a,c.a.Delete,e)})),Object(h.a)((function(e){return Object(s.a)(e).pipe(Object(m.a)((function(e){t.httpClientService.DoCatchError(t.labsheettubempndetailListModel$,t.labsheettubempndetailDeleteModel$,e)})))})))}}]),e}()).\u0275fac=function(e){return new(e||r)(o.Xb(p.b),o.Xb(d.a))},r.\u0275prov=o.Jb({token:r,factory:r.\u0275fac,providedIn:"root"}),r),T=a("Wp6s"),S=a("bTqV"),y=a("bv9b"),D=a("NFeN"),v=a("3Pt+"),I=a("kmnG"),g=a("qFsG"),M=a("d3UM"),P=a("FKr1");function C(e,t){1&e&&o.Ob(0,"mat-progress-bar",21)}function B(e,t){1&e&&o.Ob(0,"mat-progress-bar",21)}function L(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function O(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,L,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}function j(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function x(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,j,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}function N(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function k(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 0"),o.Ob(2,"br"),o.Sb())}function $(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 1000"),o.Ob(2,"br"),o.Sb())}function w(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,N,3,0,"span",4),o.xc(6,k,3,0,"span",4),o.xc(7,$,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,4,a)),o.Bb(3),o.jc("ngIf",a.required),o.Bb(1),o.jc("ngIf",a.min),o.Bb(1),o.jc("ngIf",a.min)}}function E(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function G(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,E,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}function _(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,1,a))}}function F(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 1"),o.Ob(2,"br"),o.Sb())}function V(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 10000000"),o.Ob(2,"br"),o.Sb())}function U(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,F,3,0,"span",4),o.xc(6,V,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,3,a)),o.Bb(3),o.jc("ngIf",a.min),o.Bb(1),o.jc("ngIf",a.min)}}function q(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 0"),o.Ob(2,"br"),o.Sb())}function A(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 5"),o.Ob(2,"br"),o.Sb())}function z(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,q,3,0,"span",4),o.xc(6,A,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,3,a)),o.Bb(3),o.jc("ngIf",a.min),o.Bb(1),o.jc("ngIf",a.min)}}function R(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 0"),o.Ob(2,"br"),o.Sb())}function W(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 5"),o.Ob(2,"br"),o.Sb())}function Q(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,R,3,0,"span",4),o.xc(6,W,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,3,a)),o.Bb(3),o.jc("ngIf",a.min),o.Bb(1),o.jc("ngIf",a.min)}}function H(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 0"),o.Ob(2,"br"),o.Sb())}function X(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 5"),o.Ob(2,"br"),o.Sb())}function J(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,H,3,0,"span",4),o.xc(6,X,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,3,a)),o.Bb(3),o.jc("ngIf",a.min),o.Bb(1),o.jc("ngIf",a.min)}}function K(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - 0"),o.Ob(2,"br"),o.Sb())}function Y(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 40"),o.Ob(2,"br"),o.Sb())}function Z(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,K,3,0,"span",4),o.xc(6,Y,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,3,a)),o.Bb(3),o.jc("ngIf",a.min),o.Bb(1),o.jc("ngIf",a.min)}}function ee(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Min - -10"),o.Ob(2,"br"),o.Sb())}function te(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Max - 40"),o.Ob(2,"br"),o.Sb())}function ae(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,ee,3,0,"span",4),o.xc(6,te,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,3,a)),o.Bb(3),o.jc("ngIf",a.min),o.Bb(1),o.jc("ngIf",a.min)}}function be(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"MaxLength - 10"),o.Ob(2,"br"),o.Sb())}function ne(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,be,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.maxlength)}}function ie(e,t){if(1&e&&(o.Tb(0,"mat-option",22),o.yc(1),o.Sb()),2&e){var a=t.$implicit;o.jc("value",a.EnumID),o.Bb(1),o.Ac(" ",a.EnumText," ")}}function re(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function le(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,re,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}function ce(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"MaxLength - 250"),o.Ob(2,"br"),o.Sb())}function oe(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,ce,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.maxlength)}}function ue(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function se(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,ue,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}function pe(e,t){1&e&&(o.Tb(0,"span"),o.yc(1,"Is Required"),o.Ob(2,"br"),o.Sb())}function me(e,t){if(1&e&&(o.Tb(0,"mat-error"),o.Tb(1,"span"),o.yc(2),o.fc(3,"json"),o.Ob(4,"br"),o.Sb(),o.xc(5,pe,3,0,"span",4),o.Sb()),2&e){var a=t.$implicit;o.Bb(2),o.zc(o.gc(3,2,a)),o.Bb(3),o.jc("ngIf",a.required)}}var he,de=((he=function(){function e(t,a){_classCallCheck(this,e),this.labsheettubempndetailService=t,this.fb=a,this.labsheettubempndetail=null,this.httpClientCommand=c.a.Put}return _createClass(e,[{key:"GetPut",value:function(){return this.httpClientCommand==c.a.Put}},{key:"PutLabSheetTubeMPNDetail",value:function(e){this.sub=this.labsheettubempndetailService.PutLabSheetTubeMPNDetail(e).subscribe()}},{key:"PostLabSheetTubeMPNDetail",value:function(e){this.sub=this.labsheettubempndetailService.PostLabSheetTubeMPNDetail(e).subscribe()}},{key:"ngOnInit",value:function(){this.sampleTypeList=Object(l.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.labsheettubempndetail){var t=this.fb.group({LabSheetTubeMPNDetailID:[{value:e===c.a.Post?0:this.labsheettubempndetail.LabSheetTubeMPNDetailID,disabled:!1},[v.p.required]],LabSheetDetailID:[{value:this.labsheettubempndetail.LabSheetDetailID,disabled:!1},[v.p.required]],Ordinal:[{value:this.labsheettubempndetail.Ordinal,disabled:!1},[v.p.required,v.p.min(0),v.p.max(1e3)]],MWQMSiteTVItemID:[{value:this.labsheettubempndetail.MWQMSiteTVItemID,disabled:!1},[v.p.required]],SampleDateTime:[{value:this.labsheettubempndetail.SampleDateTime,disabled:!1}],MPN:[{value:this.labsheettubempndetail.MPN,disabled:!1},[v.p.min(1),v.p.max(1e7)]],Tube10:[{value:this.labsheettubempndetail.Tube10,disabled:!1},[v.p.min(0),v.p.max(5)]],Tube1_0:[{value:this.labsheettubempndetail.Tube1_0,disabled:!1},[v.p.min(0),v.p.max(5)]],Tube0_1:[{value:this.labsheettubempndetail.Tube0_1,disabled:!1},[v.p.min(0),v.p.max(5)]],Salinity:[{value:this.labsheettubempndetail.Salinity,disabled:!1},[v.p.min(0),v.p.max(40)]],Temperature:[{value:this.labsheettubempndetail.Temperature,disabled:!1},[v.p.min(-10),v.p.max(40)]],ProcessedBy:[{value:this.labsheettubempndetail.ProcessedBy,disabled:!1},[v.p.maxLength(10)]],SampleType:[{value:this.labsheettubempndetail.SampleType,disabled:!1},[v.p.required]],SiteComment:[{value:this.labsheettubempndetail.SiteComment,disabled:!1},[v.p.maxLength(250)]],LastUpdateDate_UTC:[{value:this.labsheettubempndetail.LastUpdateDate_UTC,disabled:!1},[v.p.required]],LastUpdateContactTVItemID:[{value:this.labsheettubempndetail.LastUpdateContactTVItemID,disabled:!1},[v.p.required]]});this.labsheettubempndetailFormEdit=t}}}]),e}()).\u0275fac=function(e){return new(e||he)(o.Nb(f),o.Nb(v.d))},he.\u0275cmp=o.Hb({type:he,selectors:[["app-labsheettubempndetail-edit"]],inputs:{labsheettubempndetail:"labsheettubempndetail",httpClientCommand:"httpClientCommand"},decls:93,vars:21,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","LabSheetTubeMPNDetailID"],[4,"ngIf"],["matInput","","type","number","formControlName","LabSheetDetailID"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","number","formControlName","MWQMSiteTVItemID"],["matInput","","type","text","formControlName","SampleDateTime"],["matInput","","type","number","formControlName","MPN"],["matInput","","type","number","formControlName","Tube10"],["matInput","","type","number","formControlName","Tube1_0"],["matInput","","type","number","formControlName","Tube0_1"],["matInput","","type","number","formControlName","Salinity"],["matInput","","type","number","formControlName","Temperature"],["matInput","","type","text","formControlName","ProcessedBy"],["formControlName","SampleType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","SiteComment"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(o.Tb(0,"form",0),o.ac("ngSubmit",(function(){return t.GetPut()?t.PutLabSheetTubeMPNDetail(t.labsheettubempndetailFormEdit.value):t.PostLabSheetTubeMPNDetail(t.labsheettubempndetailFormEdit.value)})),o.Tb(1,"h3"),o.yc(2," LabSheetTubeMPNDetail "),o.Tb(3,"button",1),o.Tb(4,"span"),o.yc(5),o.Sb(),o.Sb(),o.xc(6,C,1,0,"mat-progress-bar",2),o.xc(7,B,1,0,"mat-progress-bar",2),o.Sb(),o.Tb(8,"p"),o.Tb(9,"mat-form-field"),o.Tb(10,"mat-label"),o.yc(11,"LabSheetTubeMPNDetailID"),o.Sb(),o.Ob(12,"input",3),o.xc(13,O,6,4,"mat-error",4),o.Sb(),o.Tb(14,"mat-form-field"),o.Tb(15,"mat-label"),o.yc(16,"LabSheetDetailID"),o.Sb(),o.Ob(17,"input",5),o.xc(18,x,6,4,"mat-error",4),o.Sb(),o.Tb(19,"mat-form-field"),o.Tb(20,"mat-label"),o.yc(21,"Ordinal"),o.Sb(),o.Ob(22,"input",6),o.xc(23,w,8,6,"mat-error",4),o.Sb(),o.Tb(24,"mat-form-field"),o.Tb(25,"mat-label"),o.yc(26,"MWQMSiteTVItemID"),o.Sb(),o.Ob(27,"input",7),o.xc(28,G,6,4,"mat-error",4),o.Sb(),o.Sb(),o.Tb(29,"p"),o.Tb(30,"mat-form-field"),o.Tb(31,"mat-label"),o.yc(32,"SampleDateTime"),o.Sb(),o.Ob(33,"input",8),o.xc(34,_,5,3,"mat-error",4),o.Sb(),o.Tb(35,"mat-form-field"),o.Tb(36,"mat-label"),o.yc(37,"MPN"),o.Sb(),o.Ob(38,"input",9),o.xc(39,U,7,5,"mat-error",4),o.Sb(),o.Tb(40,"mat-form-field"),o.Tb(41,"mat-label"),o.yc(42,"Tube10"),o.Sb(),o.Ob(43,"input",10),o.xc(44,z,7,5,"mat-error",4),o.Sb(),o.Tb(45,"mat-form-field"),o.Tb(46,"mat-label"),o.yc(47,"Tube1_0"),o.Sb(),o.Ob(48,"input",11),o.xc(49,Q,7,5,"mat-error",4),o.Sb(),o.Sb(),o.Tb(50,"p"),o.Tb(51,"mat-form-field"),o.Tb(52,"mat-label"),o.yc(53,"Tube0_1"),o.Sb(),o.Ob(54,"input",12),o.xc(55,J,7,5,"mat-error",4),o.Sb(),o.Tb(56,"mat-form-field"),o.Tb(57,"mat-label"),o.yc(58,"Salinity"),o.Sb(),o.Ob(59,"input",13),o.xc(60,Z,7,5,"mat-error",4),o.Sb(),o.Tb(61,"mat-form-field"),o.Tb(62,"mat-label"),o.yc(63,"Temperature"),o.Sb(),o.Ob(64,"input",14),o.xc(65,ae,7,5,"mat-error",4),o.Sb(),o.Tb(66,"mat-form-field"),o.Tb(67,"mat-label"),o.yc(68,"ProcessedBy"),o.Sb(),o.Ob(69,"input",15),o.xc(70,ne,6,4,"mat-error",4),o.Sb(),o.Sb(),o.Tb(71,"p"),o.Tb(72,"mat-form-field"),o.Tb(73,"mat-label"),o.yc(74,"SampleType"),o.Sb(),o.Tb(75,"mat-select",16),o.xc(76,ie,2,2,"mat-option",17),o.Sb(),o.xc(77,le,6,4,"mat-error",4),o.Sb(),o.Tb(78,"mat-form-field"),o.Tb(79,"mat-label"),o.yc(80,"SiteComment"),o.Sb(),o.Ob(81,"input",18),o.xc(82,oe,6,4,"mat-error",4),o.Sb(),o.Tb(83,"mat-form-field"),o.Tb(84,"mat-label"),o.yc(85,"LastUpdateDate_UTC"),o.Sb(),o.Ob(86,"input",19),o.xc(87,se,6,4,"mat-error",4),o.Sb(),o.Tb(88,"mat-form-field"),o.Tb(89,"mat-label"),o.yc(90,"LastUpdateContactTVItemID"),o.Sb(),o.Ob(91,"input",20),o.xc(92,me,6,4,"mat-error",4),o.Sb(),o.Sb(),o.Sb()),2&e&&(o.jc("formGroup",t.labsheettubempndetailFormEdit),o.Bb(5),o.Ac("",t.GetPut()?"Put":"Post"," LabSheetTubeMPNDetail"),o.Bb(1),o.jc("ngIf",t.labsheettubempndetailService.labsheettubempndetailPutModel$.getValue().Working),o.Bb(1),o.jc("ngIf",t.labsheettubempndetailService.labsheettubempndetailPostModel$.getValue().Working),o.Bb(6),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.LabSheetTubeMPNDetailID.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.LabSheetDetailID.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.Ordinal.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.MWQMSiteTVItemID.errors),o.Bb(6),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.SampleDateTime.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.MPN.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.Tube10.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.Tube1_0.errors),o.Bb(6),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.Tube0_1.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.Salinity.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.Temperature.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.ProcessedBy.errors),o.Bb(6),o.jc("ngForOf",t.sampleTypeList),o.Bb(1),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.SampleType.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.SiteComment.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.LastUpdateDate_UTC.errors),o.Bb(5),o.jc("ngIf",t.labsheettubempndetailFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[v.q,v.l,v.f,S.b,b.l,I.c,I.f,g.b,v.n,v.c,v.k,v.e,M.a,b.k,y.a,I.b,P.n],pipes:[b.f],styles:[""],changeDetection:0}),he);function fe(e,t){1&e&&o.Ob(0,"mat-progress-bar",4)}function Te(e,t){1&e&&o.Ob(0,"mat-progress-bar",4)}function Se(e,t){if(1&e&&(o.Tb(0,"p"),o.Ob(1,"app-labsheettubempndetail-edit",8),o.Sb()),2&e){var a=o.ec().$implicit,b=o.ec(2);o.Bb(1),o.jc("labsheettubempndetail",a)("httpClientCommand",b.GetPutEnum())}}function ye(e,t){if(1&e&&(o.Tb(0,"p"),o.Ob(1,"app-labsheettubempndetail-edit",8),o.Sb()),2&e){var a=o.ec().$implicit,b=o.ec(2);o.Bb(1),o.jc("labsheettubempndetail",a)("httpClientCommand",b.GetPostEnum())}}function De(e,t){if(1&e){var a=o.Ub();o.Tb(0,"div"),o.Tb(1,"p"),o.Tb(2,"button",6),o.ac("click",(function(){o.rc(a);var e=t.$implicit;return o.ec(2).DeleteLabSheetTubeMPNDetail(e)})),o.Tb(3,"span"),o.yc(4),o.Sb(),o.Tb(5,"mat-icon"),o.yc(6,"delete"),o.Sb(),o.Sb(),o.yc(7,"\xa0\xa0\xa0 "),o.Tb(8,"button",7),o.ac("click",(function(){o.rc(a);var e=t.$implicit;return o.ec(2).ShowPut(e)})),o.Tb(9,"span"),o.yc(10,"Show Put"),o.Sb(),o.Sb(),o.yc(11,"\xa0\xa0 "),o.Tb(12,"button",7),o.ac("click",(function(){o.rc(a);var e=t.$implicit;return o.ec(2).ShowPost(e)})),o.Tb(13,"span"),o.yc(14,"Show Post"),o.Sb(),o.Sb(),o.yc(15,"\xa0\xa0 "),o.xc(16,Te,1,0,"mat-progress-bar",0),o.Sb(),o.xc(17,Se,2,2,"p",2),o.xc(18,ye,2,2,"p",2),o.Tb(19,"blockquote"),o.Tb(20,"p"),o.Tb(21,"span"),o.yc(22),o.Sb(),o.Tb(23,"span"),o.yc(24),o.Sb(),o.Tb(25,"span"),o.yc(26),o.Sb(),o.Tb(27,"span"),o.yc(28),o.Sb(),o.Sb(),o.Tb(29,"p"),o.Tb(30,"span"),o.yc(31),o.Sb(),o.Tb(32,"span"),o.yc(33),o.Sb(),o.Tb(34,"span"),o.yc(35),o.Sb(),o.Tb(36,"span"),o.yc(37),o.Sb(),o.Sb(),o.Tb(38,"p"),o.Tb(39,"span"),o.yc(40),o.Sb(),o.Tb(41,"span"),o.yc(42),o.Sb(),o.Tb(43,"span"),o.yc(44),o.Sb(),o.Tb(45,"span"),o.yc(46),o.Sb(),o.Sb(),o.Tb(47,"p"),o.Tb(48,"span"),o.yc(49),o.Sb(),o.Tb(50,"span"),o.yc(51),o.Sb(),o.Tb(52,"span"),o.yc(53),o.Sb(),o.Tb(54,"span"),o.yc(55),o.Sb(),o.Sb(),o.Sb(),o.Sb()}if(2&e){var b=t.$implicit,n=o.ec(2);o.Bb(4),o.Ac("Delete LabSheetTubeMPNDetailID [",b.LabSheetTubeMPNDetailID,"]\xa0\xa0\xa0"),o.Bb(4),o.jc("color",n.GetPutButtonColor(b)),o.Bb(4),o.jc("color",n.GetPostButtonColor(b)),o.Bb(4),o.jc("ngIf",n.labsheettubempndetailService.labsheettubempndetailDeleteModel$.getValue().Working),o.Bb(1),o.jc("ngIf",n.IDToShow===b.LabSheetTubeMPNDetailID&&n.showType===n.GetPutEnum()),o.Bb(1),o.jc("ngIf",n.IDToShow===b.LabSheetTubeMPNDetailID&&n.showType===n.GetPostEnum()),o.Bb(4),o.Ac("LabSheetTubeMPNDetailID: [",b.LabSheetTubeMPNDetailID,"]"),o.Bb(2),o.Ac(" --- LabSheetDetailID: [",b.LabSheetDetailID,"]"),o.Bb(2),o.Ac(" --- Ordinal: [",b.Ordinal,"]"),o.Bb(2),o.Ac(" --- MWQMSiteTVItemID: [",b.MWQMSiteTVItemID,"]"),o.Bb(3),o.Ac("SampleDateTime: [",b.SampleDateTime,"]"),o.Bb(2),o.Ac(" --- MPN: [",b.MPN,"]"),o.Bb(2),o.Ac(" --- Tube10: [",b.Tube10,"]"),o.Bb(2),o.Ac(" --- Tube1_0: [",b.Tube1_0,"]"),o.Bb(3),o.Ac("Tube0_1: [",b.Tube0_1,"]"),o.Bb(2),o.Ac(" --- Salinity: [",b.Salinity,"]"),o.Bb(2),o.Ac(" --- Temperature: [",b.Temperature,"]"),o.Bb(2),o.Ac(" --- ProcessedBy: [",b.ProcessedBy,"]"),o.Bb(3),o.Ac("SampleType: [",n.GetSampleTypeEnumText(b.SampleType),"]"),o.Bb(2),o.Ac(" --- SiteComment: [",b.SiteComment,"]"),o.Bb(2),o.Ac(" --- LastUpdateDate_UTC: [",b.LastUpdateDate_UTC,"]"),o.Bb(2),o.Ac(" --- LastUpdateContactTVItemID: [",b.LastUpdateContactTVItemID,"]")}}function ve(e,t){if(1&e&&(o.Tb(0,"div"),o.xc(1,De,56,22,"div",5),o.Sb()),2&e){var a=o.ec();o.Bb(1),o.jc("ngForOf",a.labsheettubempndetailService.labsheettubempndetailListModel$.getValue())}}var Ie,ge,Me,Pe=[{path:"",component:(Ie=function(){function e(t,a,b){_classCallCheck(this,e),this.labsheettubempndetailService=t,this.router=a,this.httpClientService=b,this.showType=null,b.oldURL=a.url}return _createClass(e,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.LabSheetTubeMPNDetailID&&this.showType===c.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.LabSheetTubeMPNDetailID&&this.showType===c.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.LabSheetTubeMPNDetailID&&this.showType===c.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.LabSheetTubeMPNDetailID,this.showType=c.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.LabSheetTubeMPNDetailID&&this.showType===c.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.LabSheetTubeMPNDetailID,this.showType=c.a.Post)}},{key:"GetPutEnum",value:function(){return c.a.Put}},{key:"GetPostEnum",value:function(){return c.a.Post}},{key:"GetLabSheetTubeMPNDetailList",value:function(){this.sub=this.labsheettubempndetailService.GetLabSheetTubeMPNDetailList().subscribe()}},{key:"DeleteLabSheetTubeMPNDetail",value:function(e){this.sub=this.labsheettubempndetailService.DeleteLabSheetTubeMPNDetail(e).subscribe()}},{key:"GetSampleTypeEnumText",value:function(e){return Object(l.a)(e)}},{key:"ngOnInit",value:function(){i(this.labsheettubempndetailService.labsheettubempndetailTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),e}(),Ie.\u0275fac=function(e){return new(e||Ie)(o.Nb(f),o.Nb(n.b),o.Nb(d.a))},Ie.\u0275cmp=o.Hb({type:Ie,selectors:[["app-labsheettubempndetail"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"labsheettubempndetail","httpClientCommand"]],template:function(e,t){if(1&e&&(o.xc(0,fe,1,0,"mat-progress-bar",0),o.Tb(1,"mat-card"),o.Tb(2,"mat-card-header"),o.Tb(3,"mat-card-title"),o.yc(4," LabSheetTubeMPNDetail works! "),o.Tb(5,"button",1),o.ac("click",(function(){return t.GetLabSheetTubeMPNDetailList()})),o.Tb(6,"span"),o.yc(7,"Get LabSheetTubeMPNDetail"),o.Sb(),o.Sb(),o.Sb(),o.Tb(8,"mat-card-subtitle"),o.yc(9),o.Sb(),o.Sb(),o.Tb(10,"mat-card-content"),o.xc(11,ve,2,1,"div",2),o.Sb(),o.Tb(12,"mat-card-actions"),o.Tb(13,"button",3),o.yc(14,"Allo"),o.Sb(),o.Sb(),o.Sb()),2&e){var a,b,n=null==(a=t.labsheettubempndetailService.labsheettubempndetailGetModel$.getValue())?null:a.Working,i=null==(b=t.labsheettubempndetailService.labsheettubempndetailListModel$.getValue())?null:b.length;o.jc("ngIf",n),o.Bb(9),o.zc(t.labsheettubempndetailService.labsheettubempndetailTextModel$.getValue().Title),o.Bb(2),o.jc("ngIf",i)}},directives:[b.l,T.a,T.d,T.g,S.b,T.f,T.c,T.b,y.a,b.k,D.a,de],styles:[""],changeDetection:0}),Ie),canActivate:[a("auXs").a]}],Ce=((ge=function e(){_classCallCheck(this,e)}).\u0275mod=o.Lb({type:ge}),ge.\u0275inj=o.Kb({factory:function(e){return new(e||ge)},imports:[[n.e.forChild(Pe)],n.e]}),ge),Be=a("B+Mi"),Le=((Me=function e(){_classCallCheck(this,e)}).\u0275mod=o.Lb({type:Me}),Me.\u0275inj=o.Kb({factory:function(e){return new(e||Me)},imports:[[b.c,n.e,Ce,Be.a,v.g,v.o]]}),Me)},QRvi:function(e,t,a){"use strict";a.d(t,"a",(function(){return b}));var b=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,a){"use strict";a.d(t,"a",(function(){return r}));var b=a("QRvi"),n=a("fXoL"),i=a("tyNb"),r=function(){var e=function(){function e(t){_classCallCheck(this,e),this.router=t,this.oldURL=t.url}return _createClass(e,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,t,a){e.next(null),t.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,t,a,n,i){if(n===b.a.Get&&e.next(a),n===b.a.Put&&(e.getValue()[0]=a),n===b.a.Post&&e.getValue().push(a),n===b.a.Delete){var r=e.getValue().indexOf(i);e.getValue().splice(r,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(n.Xb(i.b))},e.\u0275prov=n.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()}}]);