(window.webpackJsonp=window.webpackJsonp||[]).push([[55],{Go4k:function(e,t,b){"use strict";b.r(t),b.d(t,"LabSheetTubeMPNDetailModule",(function(){return Be}));var a=b("ofXK"),i=b("tyNb");function n(e){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var l=b("KyBE"),r=b("QRvi"),s=b("fXoL"),o=b("2Vo4"),c=b("LRne"),u=b("tk/3"),p=b("lJxs"),m=b("JIr8"),h=b("gkM4");let d=(()=>{class e{constructor(e,t){this.httpClient=e,this.httpClientService=t,this.labsheettubempndetailTextModel$=new o.a({}),this.labsheettubempndetailListModel$=new o.a({}),this.labsheettubempndetailGetModel$=new o.a({}),this.labsheettubempndetailPutModel$=new o.a({}),this.labsheettubempndetailPostModel$=new o.a({}),this.labsheettubempndetailDeleteModel$=new o.a({}),n(this.labsheettubempndetailTextModel$),this.labsheettubempndetailTextModel$.next({Title:"Something2 for text"})}GetLabSheetTubeMPNDetailList(){return this.httpClientService.BeforeHttpClient(this.labsheettubempndetailGetModel$),this.httpClient.get("/api/LabSheetTubeMPNDetail").pipe(Object(p.a)(e=>{this.httpClientService.DoSuccess(this.labsheettubempndetailListModel$,this.labsheettubempndetailGetModel$,e,r.a.Get,null)}),Object(m.a)(e=>Object(c.a)(e).pipe(Object(p.a)(e=>{this.httpClientService.DoCatchError(this.labsheettubempndetailListModel$,this.labsheettubempndetailGetModel$,e)}))))}PutLabSheetTubeMPNDetail(e){return this.httpClientService.BeforeHttpClient(this.labsheettubempndetailPutModel$),this.httpClient.put("/api/LabSheetTubeMPNDetail",e,{headers:new u.d}).pipe(Object(p.a)(t=>{this.httpClientService.DoSuccess(this.labsheettubempndetailListModel$,this.labsheettubempndetailPutModel$,t,r.a.Put,e)}),Object(m.a)(e=>Object(c.a)(e).pipe(Object(p.a)(e=>{this.httpClientService.DoCatchError(this.labsheettubempndetailListModel$,this.labsheettubempndetailPutModel$,e)}))))}PostLabSheetTubeMPNDetail(e){return this.httpClientService.BeforeHttpClient(this.labsheettubempndetailPostModel$),this.httpClient.post("/api/LabSheetTubeMPNDetail",e,{headers:new u.d}).pipe(Object(p.a)(t=>{this.httpClientService.DoSuccess(this.labsheettubempndetailListModel$,this.labsheettubempndetailPostModel$,t,r.a.Post,e)}),Object(m.a)(e=>Object(c.a)(e).pipe(Object(p.a)(e=>{this.httpClientService.DoCatchError(this.labsheettubempndetailListModel$,this.labsheettubempndetailPostModel$,e)}))))}DeleteLabSheetTubeMPNDetail(e){return this.httpClientService.BeforeHttpClient(this.labsheettubempndetailDeleteModel$),this.httpClient.delete("/api/LabSheetTubeMPNDetail/"+e.LabSheetTubeMPNDetailID).pipe(Object(p.a)(t=>{this.httpClientService.DoSuccess(this.labsheettubempndetailListModel$,this.labsheettubempndetailDeleteModel$,t,r.a.Delete,e)}),Object(m.a)(e=>Object(c.a)(e).pipe(Object(p.a)(e=>{this.httpClientService.DoCatchError(this.labsheettubempndetailListModel$,this.labsheettubempndetailDeleteModel$,e)}))))}}return e.\u0275fac=function(t){return new(t||e)(s.Wb(u.b),s.Wb(h.a))},e.\u0275prov=s.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var S=b("Wp6s"),f=b("bTqV"),R=b("bv9b"),D=b("NFeN"),T=b("3Pt+"),I=b("kmnG"),N=b("qFsG"),B=b("d3UM"),M=b("FKr1");function y(e,t){1&e&&s.Nb(0,"mat-progress-bar",21)}function P(e,t){1&e&&s.Nb(0,"mat-progress-bar",21)}function g(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function L(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,g,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,2,e)),s.Bb(3),s.ic("ngIf",e.required)}}function C(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function z(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,C,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,2,e)),s.Bb(3),s.ic("ngIf",e.required)}}function v(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function $(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Min - 0"),s.Nb(2,"br"),s.Rb())}function w(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Max - 1000"),s.Nb(2,"br"),s.Rb())}function x(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,v,3,0,"span",4),s.yc(6,$,3,0,"span",4),s.yc(7,w,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,4,e)),s.Bb(3),s.ic("ngIf",e.required),s.Bb(1),s.ic("ngIf",e.min),s.Bb(1),s.ic("ngIf",e.min)}}function E(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function G(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,E,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,2,e)),s.Bb(3),s.ic("ngIf",e.required)}}function j(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,1,e))}}function O(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Min - 1"),s.Nb(2,"br"),s.Rb())}function k(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Max - 10000000"),s.Nb(2,"br"),s.Rb())}function F(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,O,3,0,"span",4),s.yc(6,k,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,3,e)),s.Bb(3),s.ic("ngIf",e.min),s.Bb(1),s.ic("ngIf",e.min)}}function V(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Min - 0"),s.Nb(2,"br"),s.Rb())}function q(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Max - 5"),s.Nb(2,"br"),s.Rb())}function U(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,V,3,0,"span",4),s.yc(6,q,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,3,e)),s.Bb(3),s.ic("ngIf",e.min),s.Bb(1),s.ic("ngIf",e.min)}}function _(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Min - 0"),s.Nb(2,"br"),s.Rb())}function A(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Max - 5"),s.Nb(2,"br"),s.Rb())}function W(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,_,3,0,"span",4),s.yc(6,A,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,3,e)),s.Bb(3),s.ic("ngIf",e.min),s.Bb(1),s.ic("ngIf",e.min)}}function Q(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Min - 0"),s.Nb(2,"br"),s.Rb())}function J(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Max - 5"),s.Nb(2,"br"),s.Rb())}function H(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,Q,3,0,"span",4),s.yc(6,J,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,3,e)),s.Bb(3),s.ic("ngIf",e.min),s.Bb(1),s.ic("ngIf",e.min)}}function K(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Min - 0"),s.Nb(2,"br"),s.Rb())}function Z(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Max - 40"),s.Nb(2,"br"),s.Rb())}function X(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,K,3,0,"span",4),s.yc(6,Z,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,3,e)),s.Bb(3),s.ic("ngIf",e.min),s.Bb(1),s.ic("ngIf",e.min)}}function Y(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Min - -10"),s.Nb(2,"br"),s.Rb())}function ee(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Max - 40"),s.Nb(2,"br"),s.Rb())}function te(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,Y,3,0,"span",4),s.yc(6,ee,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,3,e)),s.Bb(3),s.ic("ngIf",e.min),s.Bb(1),s.ic("ngIf",e.min)}}function be(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"MaxLength - 10"),s.Nb(2,"br"),s.Rb())}function ae(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,be,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,2,e)),s.Bb(3),s.ic("ngIf",e.maxlength)}}function ie(e,t){if(1&e&&(s.Sb(0,"mat-option",22),s.zc(1),s.Rb()),2&e){const e=t.$implicit;s.ic("value",e.EnumID),s.Bb(1),s.Bc(" ",e.EnumText," ")}}function ne(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function le(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,ne,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,2,e)),s.Bb(3),s.ic("ngIf",e.required)}}function re(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"MaxLength - 250"),s.Nb(2,"br"),s.Rb())}function se(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,re,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,2,e)),s.Bb(3),s.ic("ngIf",e.maxlength)}}function oe(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function ce(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,oe,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,2,e)),s.Bb(3),s.ic("ngIf",e.required)}}function ue(e,t){1&e&&(s.Sb(0,"span"),s.zc(1,"Is Required"),s.Nb(2,"br"),s.Rb())}function pe(e,t){if(1&e&&(s.Sb(0,"mat-error"),s.Sb(1,"span"),s.zc(2),s.ec(3,"json"),s.Nb(4,"br"),s.Rb(),s.yc(5,ue,3,0,"span",4),s.Rb()),2&e){const e=t.$implicit;s.Bb(2),s.Ac(s.fc(3,2,e)),s.Bb(3),s.ic("ngIf",e.required)}}let me=(()=>{class e{constructor(e,t){this.labsheettubempndetailService=e,this.fb=t,this.labsheettubempndetail=null,this.httpClientCommand=r.a.Put}GetPut(){return this.httpClientCommand==r.a.Put}PutLabSheetTubeMPNDetail(e){this.sub=this.labsheettubempndetailService.PutLabSheetTubeMPNDetail(e).subscribe()}PostLabSheetTubeMPNDetail(e){this.sub=this.labsheettubempndetailService.PostLabSheetTubeMPNDetail(e).subscribe()}ngOnInit(){this.sampleTypeList=Object(l.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.labsheettubempndetail){let t=this.fb.group({LabSheetTubeMPNDetailID:[{value:e===r.a.Post?0:this.labsheettubempndetail.LabSheetTubeMPNDetailID,disabled:!1},[T.p.required]],LabSheetDetailID:[{value:this.labsheettubempndetail.LabSheetDetailID,disabled:!1},[T.p.required]],Ordinal:[{value:this.labsheettubempndetail.Ordinal,disabled:!1},[T.p.required,T.p.min(0),T.p.max(1e3)]],MWQMSiteTVItemID:[{value:this.labsheettubempndetail.MWQMSiteTVItemID,disabled:!1},[T.p.required]],SampleDateTime:[{value:this.labsheettubempndetail.SampleDateTime,disabled:!1}],MPN:[{value:this.labsheettubempndetail.MPN,disabled:!1},[T.p.min(1),T.p.max(1e7)]],Tube10:[{value:this.labsheettubempndetail.Tube10,disabled:!1},[T.p.min(0),T.p.max(5)]],Tube1_0:[{value:this.labsheettubempndetail.Tube1_0,disabled:!1},[T.p.min(0),T.p.max(5)]],Tube0_1:[{value:this.labsheettubempndetail.Tube0_1,disabled:!1},[T.p.min(0),T.p.max(5)]],Salinity:[{value:this.labsheettubempndetail.Salinity,disabled:!1},[T.p.min(0),T.p.max(40)]],Temperature:[{value:this.labsheettubempndetail.Temperature,disabled:!1},[T.p.min(-10),T.p.max(40)]],ProcessedBy:[{value:this.labsheettubempndetail.ProcessedBy,disabled:!1},[T.p.maxLength(10)]],SampleType:[{value:this.labsheettubempndetail.SampleType,disabled:!1},[T.p.required]],SiteComment:[{value:this.labsheettubempndetail.SiteComment,disabled:!1},[T.p.maxLength(250)]],LastUpdateDate_UTC:[{value:this.labsheettubempndetail.LastUpdateDate_UTC,disabled:!1},[T.p.required]],LastUpdateContactTVItemID:[{value:this.labsheettubempndetail.LastUpdateContactTVItemID,disabled:!1},[T.p.required]]});this.labsheettubempndetailFormEdit=t}}}return e.\u0275fac=function(t){return new(t||e)(s.Mb(d),s.Mb(T.d))},e.\u0275cmp=s.Gb({type:e,selectors:[["app-labsheettubempndetail-edit"]],inputs:{labsheettubempndetail:"labsheettubempndetail",httpClientCommand:"httpClientCommand"},decls:93,vars:21,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","LabSheetTubeMPNDetailID"],[4,"ngIf"],["matInput","","type","number","formControlName","LabSheetDetailID"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","number","formControlName","MWQMSiteTVItemID"],["matInput","","type","text","formControlName","SampleDateTime"],["matInput","","type","number","formControlName","MPN"],["matInput","","type","number","formControlName","Tube10"],["matInput","","type","number","formControlName","Tube1_0"],["matInput","","type","number","formControlName","Tube0_1"],["matInput","","type","number","formControlName","Salinity"],["matInput","","type","number","formControlName","Temperature"],["matInput","","type","text","formControlName","ProcessedBy"],["formControlName","SampleType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","SiteComment"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(s.Sb(0,"form",0),s.Zb("ngSubmit",(function(){return t.GetPut()?t.PutLabSheetTubeMPNDetail(t.labsheettubempndetailFormEdit.value):t.PostLabSheetTubeMPNDetail(t.labsheettubempndetailFormEdit.value)})),s.Sb(1,"h3"),s.zc(2," LabSheetTubeMPNDetail "),s.Sb(3,"button",1),s.Sb(4,"span"),s.zc(5),s.Rb(),s.Rb(),s.yc(6,y,1,0,"mat-progress-bar",2),s.yc(7,P,1,0,"mat-progress-bar",2),s.Rb(),s.Sb(8,"p"),s.Sb(9,"mat-form-field"),s.Sb(10,"mat-label"),s.zc(11,"LabSheetTubeMPNDetailID"),s.Rb(),s.Nb(12,"input",3),s.yc(13,L,6,4,"mat-error",4),s.Rb(),s.Sb(14,"mat-form-field"),s.Sb(15,"mat-label"),s.zc(16,"LabSheetDetailID"),s.Rb(),s.Nb(17,"input",5),s.yc(18,z,6,4,"mat-error",4),s.Rb(),s.Sb(19,"mat-form-field"),s.Sb(20,"mat-label"),s.zc(21,"Ordinal"),s.Rb(),s.Nb(22,"input",6),s.yc(23,x,8,6,"mat-error",4),s.Rb(),s.Sb(24,"mat-form-field"),s.Sb(25,"mat-label"),s.zc(26,"MWQMSiteTVItemID"),s.Rb(),s.Nb(27,"input",7),s.yc(28,G,6,4,"mat-error",4),s.Rb(),s.Rb(),s.Sb(29,"p"),s.Sb(30,"mat-form-field"),s.Sb(31,"mat-label"),s.zc(32,"SampleDateTime"),s.Rb(),s.Nb(33,"input",8),s.yc(34,j,5,3,"mat-error",4),s.Rb(),s.Sb(35,"mat-form-field"),s.Sb(36,"mat-label"),s.zc(37,"MPN"),s.Rb(),s.Nb(38,"input",9),s.yc(39,F,7,5,"mat-error",4),s.Rb(),s.Sb(40,"mat-form-field"),s.Sb(41,"mat-label"),s.zc(42,"Tube10"),s.Rb(),s.Nb(43,"input",10),s.yc(44,U,7,5,"mat-error",4),s.Rb(),s.Sb(45,"mat-form-field"),s.Sb(46,"mat-label"),s.zc(47,"Tube1_0"),s.Rb(),s.Nb(48,"input",11),s.yc(49,W,7,5,"mat-error",4),s.Rb(),s.Rb(),s.Sb(50,"p"),s.Sb(51,"mat-form-field"),s.Sb(52,"mat-label"),s.zc(53,"Tube0_1"),s.Rb(),s.Nb(54,"input",12),s.yc(55,H,7,5,"mat-error",4),s.Rb(),s.Sb(56,"mat-form-field"),s.Sb(57,"mat-label"),s.zc(58,"Salinity"),s.Rb(),s.Nb(59,"input",13),s.yc(60,X,7,5,"mat-error",4),s.Rb(),s.Sb(61,"mat-form-field"),s.Sb(62,"mat-label"),s.zc(63,"Temperature"),s.Rb(),s.Nb(64,"input",14),s.yc(65,te,7,5,"mat-error",4),s.Rb(),s.Sb(66,"mat-form-field"),s.Sb(67,"mat-label"),s.zc(68,"ProcessedBy"),s.Rb(),s.Nb(69,"input",15),s.yc(70,ae,6,4,"mat-error",4),s.Rb(),s.Rb(),s.Sb(71,"p"),s.Sb(72,"mat-form-field"),s.Sb(73,"mat-label"),s.zc(74,"SampleType"),s.Rb(),s.Sb(75,"mat-select",16),s.yc(76,ie,2,2,"mat-option",17),s.Rb(),s.yc(77,le,6,4,"mat-error",4),s.Rb(),s.Sb(78,"mat-form-field"),s.Sb(79,"mat-label"),s.zc(80,"SiteComment"),s.Rb(),s.Nb(81,"input",18),s.yc(82,se,6,4,"mat-error",4),s.Rb(),s.Sb(83,"mat-form-field"),s.Sb(84,"mat-label"),s.zc(85,"LastUpdateDate_UTC"),s.Rb(),s.Nb(86,"input",19),s.yc(87,ce,6,4,"mat-error",4),s.Rb(),s.Sb(88,"mat-form-field"),s.Sb(89,"mat-label"),s.zc(90,"LastUpdateContactTVItemID"),s.Rb(),s.Nb(91,"input",20),s.yc(92,pe,6,4,"mat-error",4),s.Rb(),s.Rb(),s.Rb()),2&e&&(s.ic("formGroup",t.labsheettubempndetailFormEdit),s.Bb(5),s.Bc("",t.GetPut()?"Put":"Post"," LabSheetTubeMPNDetail"),s.Bb(1),s.ic("ngIf",t.labsheettubempndetailService.labsheettubempndetailPutModel$.getValue().Working),s.Bb(1),s.ic("ngIf",t.labsheettubempndetailService.labsheettubempndetailPostModel$.getValue().Working),s.Bb(6),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.LabSheetTubeMPNDetailID.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.LabSheetDetailID.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.Ordinal.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.MWQMSiteTVItemID.errors),s.Bb(6),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.SampleDateTime.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.MPN.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.Tube10.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.Tube1_0.errors),s.Bb(6),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.Tube0_1.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.Salinity.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.Temperature.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.ProcessedBy.errors),s.Bb(6),s.ic("ngForOf",t.sampleTypeList),s.Bb(1),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.SampleType.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.SiteComment.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.LastUpdateDate_UTC.errors),s.Bb(5),s.ic("ngIf",t.labsheettubempndetailFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[T.q,T.l,T.f,f.b,a.l,I.c,I.f,N.b,T.n,T.c,T.k,T.e,B.a,a.k,R.a,I.b,M.n],pipes:[a.f],styles:[""],changeDetection:0}),e})();function he(e,t){1&e&&s.Nb(0,"mat-progress-bar",4)}function de(e,t){1&e&&s.Nb(0,"mat-progress-bar",4)}function Se(e,t){if(1&e&&(s.Sb(0,"p"),s.Nb(1,"app-labsheettubempndetail-edit",8),s.Rb()),2&e){const e=s.dc().$implicit,t=s.dc(2);s.Bb(1),s.ic("labsheettubempndetail",e)("httpClientCommand",t.GetPutEnum())}}function fe(e,t){if(1&e&&(s.Sb(0,"p"),s.Nb(1,"app-labsheettubempndetail-edit",8),s.Rb()),2&e){const e=s.dc().$implicit,t=s.dc(2);s.Bb(1),s.ic("labsheettubempndetail",e)("httpClientCommand",t.GetPostEnum())}}function Re(e,t){if(1&e){const e=s.Tb();s.Sb(0,"div"),s.Sb(1,"p"),s.Sb(2,"button",6),s.Zb("click",(function(){s.qc(e);const b=t.$implicit;return s.dc(2).DeleteLabSheetTubeMPNDetail(b)})),s.Sb(3,"span"),s.zc(4),s.Rb(),s.Sb(5,"mat-icon"),s.zc(6,"delete"),s.Rb(),s.Rb(),s.zc(7,"\xa0\xa0\xa0 "),s.Sb(8,"button",7),s.Zb("click",(function(){s.qc(e);const b=t.$implicit;return s.dc(2).ShowPut(b)})),s.Sb(9,"span"),s.zc(10,"Show Put"),s.Rb(),s.Rb(),s.zc(11,"\xa0\xa0 "),s.Sb(12,"button",7),s.Zb("click",(function(){s.qc(e);const b=t.$implicit;return s.dc(2).ShowPost(b)})),s.Sb(13,"span"),s.zc(14,"Show Post"),s.Rb(),s.Rb(),s.zc(15,"\xa0\xa0 "),s.yc(16,de,1,0,"mat-progress-bar",0),s.Rb(),s.yc(17,Se,2,2,"p",2),s.yc(18,fe,2,2,"p",2),s.Sb(19,"blockquote"),s.Sb(20,"p"),s.Sb(21,"span"),s.zc(22),s.Rb(),s.Sb(23,"span"),s.zc(24),s.Rb(),s.Sb(25,"span"),s.zc(26),s.Rb(),s.Sb(27,"span"),s.zc(28),s.Rb(),s.Rb(),s.Sb(29,"p"),s.Sb(30,"span"),s.zc(31),s.Rb(),s.Sb(32,"span"),s.zc(33),s.Rb(),s.Sb(34,"span"),s.zc(35),s.Rb(),s.Sb(36,"span"),s.zc(37),s.Rb(),s.Rb(),s.Sb(38,"p"),s.Sb(39,"span"),s.zc(40),s.Rb(),s.Sb(41,"span"),s.zc(42),s.Rb(),s.Sb(43,"span"),s.zc(44),s.Rb(),s.Sb(45,"span"),s.zc(46),s.Rb(),s.Rb(),s.Sb(47,"p"),s.Sb(48,"span"),s.zc(49),s.Rb(),s.Sb(50,"span"),s.zc(51),s.Rb(),s.Sb(52,"span"),s.zc(53),s.Rb(),s.Sb(54,"span"),s.zc(55),s.Rb(),s.Rb(),s.Rb(),s.Rb()}if(2&e){const e=t.$implicit,b=s.dc(2);s.Bb(4),s.Bc("Delete LabSheetTubeMPNDetailID [",e.LabSheetTubeMPNDetailID,"]\xa0\xa0\xa0"),s.Bb(4),s.ic("color",b.GetPutButtonColor(e)),s.Bb(4),s.ic("color",b.GetPostButtonColor(e)),s.Bb(4),s.ic("ngIf",b.labsheettubempndetailService.labsheettubempndetailDeleteModel$.getValue().Working),s.Bb(1),s.ic("ngIf",b.IDToShow===e.LabSheetTubeMPNDetailID&&b.showType===b.GetPutEnum()),s.Bb(1),s.ic("ngIf",b.IDToShow===e.LabSheetTubeMPNDetailID&&b.showType===b.GetPostEnum()),s.Bb(4),s.Bc("LabSheetTubeMPNDetailID: [",e.LabSheetTubeMPNDetailID,"]"),s.Bb(2),s.Bc(" --- LabSheetDetailID: [",e.LabSheetDetailID,"]"),s.Bb(2),s.Bc(" --- Ordinal: [",e.Ordinal,"]"),s.Bb(2),s.Bc(" --- MWQMSiteTVItemID: [",e.MWQMSiteTVItemID,"]"),s.Bb(3),s.Bc("SampleDateTime: [",e.SampleDateTime,"]"),s.Bb(2),s.Bc(" --- MPN: [",e.MPN,"]"),s.Bb(2),s.Bc(" --- Tube10: [",e.Tube10,"]"),s.Bb(2),s.Bc(" --- Tube1_0: [",e.Tube1_0,"]"),s.Bb(3),s.Bc("Tube0_1: [",e.Tube0_1,"]"),s.Bb(2),s.Bc(" --- Salinity: [",e.Salinity,"]"),s.Bb(2),s.Bc(" --- Temperature: [",e.Temperature,"]"),s.Bb(2),s.Bc(" --- ProcessedBy: [",e.ProcessedBy,"]"),s.Bb(3),s.Bc("SampleType: [",b.GetSampleTypeEnumText(e.SampleType),"]"),s.Bb(2),s.Bc(" --- SiteComment: [",e.SiteComment,"]"),s.Bb(2),s.Bc(" --- LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),s.Bb(2),s.Bc(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function De(e,t){if(1&e&&(s.Sb(0,"div"),s.yc(1,Re,56,22,"div",5),s.Rb()),2&e){const e=s.dc();s.Bb(1),s.ic("ngForOf",e.labsheettubempndetailService.labsheettubempndetailListModel$.getValue())}}const Te=[{path:"",component:(()=>{class e{constructor(e,t,b){this.labsheettubempndetailService=e,this.router=t,this.httpClientService=b,this.showType=null,b.oldURL=t.url}GetPutButtonColor(e){return this.IDToShow===e.LabSheetTubeMPNDetailID&&this.showType===r.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.LabSheetTubeMPNDetailID&&this.showType===r.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.LabSheetTubeMPNDetailID&&this.showType===r.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.LabSheetTubeMPNDetailID,this.showType=r.a.Put)}ShowPost(e){this.IDToShow===e.LabSheetTubeMPNDetailID&&this.showType===r.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.LabSheetTubeMPNDetailID,this.showType=r.a.Post)}GetPutEnum(){return r.a.Put}GetPostEnum(){return r.a.Post}GetLabSheetTubeMPNDetailList(){this.sub=this.labsheettubempndetailService.GetLabSheetTubeMPNDetailList().subscribe()}DeleteLabSheetTubeMPNDetail(e){this.sub=this.labsheettubempndetailService.DeleteLabSheetTubeMPNDetail(e).subscribe()}GetSampleTypeEnumText(e){return Object(l.a)(e)}ngOnInit(){n(this.labsheettubempndetailService.labsheettubempndetailTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(t){return new(t||e)(s.Mb(d),s.Mb(i.b),s.Mb(h.a))},e.\u0275cmp=s.Gb({type:e,selectors:[["app-labsheettubempndetail"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"labsheettubempndetail","httpClientCommand"]],template:function(e,t){var b,a;1&e&&(s.yc(0,he,1,0,"mat-progress-bar",0),s.Sb(1,"mat-card"),s.Sb(2,"mat-card-header"),s.Sb(3,"mat-card-title"),s.zc(4," LabSheetTubeMPNDetail works! "),s.Sb(5,"button",1),s.Zb("click",(function(){return t.GetLabSheetTubeMPNDetailList()})),s.Sb(6,"span"),s.zc(7,"Get LabSheetTubeMPNDetail"),s.Rb(),s.Rb(),s.Rb(),s.Sb(8,"mat-card-subtitle"),s.zc(9),s.Rb(),s.Rb(),s.Sb(10,"mat-card-content"),s.yc(11,De,2,1,"div",2),s.Rb(),s.Sb(12,"mat-card-actions"),s.Sb(13,"button",3),s.zc(14,"Allo"),s.Rb(),s.Rb(),s.Rb()),2&e&&(s.ic("ngIf",null==(b=t.labsheettubempndetailService.labsheettubempndetailGetModel$.getValue())?null:b.Working),s.Bb(9),s.Ac(t.labsheettubempndetailService.labsheettubempndetailTextModel$.getValue().Title),s.Bb(2),s.ic("ngIf",null==(a=t.labsheettubempndetailService.labsheettubempndetailListModel$.getValue())?null:a.length))},directives:[a.l,S.a,S.d,S.g,f.b,S.f,S.c,S.b,R.a,a.k,D.a,me],styles:[""],changeDetection:0}),e})(),canActivate:[b("auXs").a]}];let Ie=(()=>{class e{}return e.\u0275mod=s.Kb({type:e}),e.\u0275inj=s.Jb({factory:function(t){return new(t||e)},imports:[[i.e.forChild(Te)],i.e]}),e})();var Ne=b("B+Mi");let Be=(()=>{class e{}return e.\u0275mod=s.Kb({type:e}),e.\u0275inj=s.Jb({factory:function(t){return new(t||e)},imports:[[a.c,i.e,Ie,Ne.a,T.g,T.o]]}),e})()},QRvi:function(e,t,b){"use strict";b.d(t,"a",(function(){return a}));var a=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,b){"use strict";b.d(t,"a",(function(){return l}));var a=b("QRvi"),i=b("fXoL"),n=b("tyNb");let l=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,t,b){e.next(null),t.next({Working:!1,Error:b,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(e,t,b){e.next(null),t.next({Working:!1,Error:b,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,t,b,i,n){if(i===a.a.Get&&e.next(b),i===a.a.Put&&(e.getValue()[0]=b),i===a.a.Post&&e.getValue().push(b),i===a.a.Delete){const t=e.getValue().indexOf(n);e.getValue().splice(t,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(e,t,b,i,n){i===a.a.Get&&e.next(b),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(t){return new(t||e)(i.Wb(n.b))},e.\u0275prov=i.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()}}]);