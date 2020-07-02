function _classCallCheck(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function _defineProperties(e,t){for(var i=0;i<t.length;i++){var n=t[i];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(e,n.key,n)}}function _createClass(e,t,i){return t&&_defineProperties(e.prototype,t),i&&_defineProperties(e,i),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[95],{CEwS:function(e,t,i){"use strict";i.r(t),i.d(t,"TVFileModule",(function(){return Oe}));var n=i("ofXK"),r=i("tyNb");function a(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var b=i("BJD1"),l=i("PSTt");function o(){var e=[];return"fr-CA"===$localize.locale?(e.push({EnumID:1,EnumText:"MIKE Input (fr)"}),e.push({EnumID:2,EnumText:"MIKE Input MDF (fr)"}),e.push({EnumID:3,EnumText:"MIKE Result DFSU (fr)"}),e.push({EnumID:4,EnumText:"MIKE Result KMZ (fr)"}),e.push({EnumID:5,EnumText:"Information (fr)"}),e.push({EnumID:6,EnumText:"Image (fr)"}),e.push({EnumID:7,EnumText:"Picture (fr)"}),e.push({EnumID:8,EnumText:"Report Generated (fr)"}),e.push({EnumID:9,EnumText:"Template Generated (fr)"}),e.push({EnumID:10,EnumText:"Generated FC Form(fr)"}),e.push({EnumID:11,EnumText:"Template (fr)"}),e.push({EnumID:12,EnumText:"Map (fr)"}),e.push({EnumID:13,EnumText:"Analyses"}),e.push({EnumID:14,EnumText:"Open Data (fr)"})):(e.push({EnumID:1,EnumText:"MIKE Input"}),e.push({EnumID:2,EnumText:"MIKE Input MDF"}),e.push({EnumID:3,EnumText:"MIKE Result DFSU"}),e.push({EnumID:4,EnumText:"MIKE Result KMZ"}),e.push({EnumID:5,EnumText:"Information"}),e.push({EnumID:6,EnumText:"Image"}),e.push({EnumID:7,EnumText:"Picture"}),e.push({EnumID:8,EnumText:"Report Generated"}),e.push({EnumID:9,EnumText:"Template Generated"}),e.push({EnumID:10,EnumText:"Generated FC Form"}),e.push({EnumID:11,EnumText:"Template"}),e.push({EnumID:12,EnumText:"Map"}),e.push({EnumID:13,EnumText:"Analysis"}),e.push({EnumID:14,EnumText:"Open Data"})),e.sort((function(e,t){return e.EnumText.localeCompare(t.EnumText)}))}var c,u=i("PDru"),s=i("QRvi"),f=i("fXoL"),m=i("2Vo4"),p=i("LRne"),T=i("tk/3"),v=i("lJxs"),d=i("JIr8"),S=i("gkM4"),h=((c=function(){function e(t,i){_classCallCheck(this,e),this.httpClient=t,this.httpClientService=i,this.tvfileTextModel$=new m.a({}),this.tvfileListModel$=new m.a({}),this.tvfileGetModel$=new m.a({}),this.tvfilePutModel$=new m.a({}),this.tvfilePostModel$=new m.a({}),this.tvfileDeleteModel$=new m.a({}),a(this.tvfileTextModel$),this.tvfileTextModel$.next({Title:"Something2 for text"})}return _createClass(e,[{key:"GetTVFileList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.tvfileGetModel$),this.httpClient.get("/api/TVFile").pipe(Object(v.a)((function(t){e.httpClientService.DoSuccess(e.tvfileListModel$,e.tvfileGetModel$,t,s.a.Get,null)})),Object(d.a)((function(t){return Object(p.a)(t).pipe(Object(v.a)((function(t){e.httpClientService.DoCatchError(e.tvfileListModel$,e.tvfileGetModel$,t)})))})))}},{key:"PutTVFile",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.tvfilePutModel$),this.httpClient.put("/api/TVFile",e,{headers:new T.d}).pipe(Object(v.a)((function(i){t.httpClientService.DoSuccess(t.tvfileListModel$,t.tvfilePutModel$,i,s.a.Put,e)})),Object(d.a)((function(e){return Object(p.a)(e).pipe(Object(v.a)((function(e){t.httpClientService.DoCatchError(t.tvfileListModel$,t.tvfilePutModel$,e)})))})))}},{key:"PostTVFile",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.tvfilePostModel$),this.httpClient.post("/api/TVFile",e,{headers:new T.d}).pipe(Object(v.a)((function(i){t.httpClientService.DoSuccess(t.tvfileListModel$,t.tvfilePostModel$,i,s.a.Post,e)})),Object(d.a)((function(e){return Object(p.a)(e).pipe(Object(v.a)((function(e){t.httpClientService.DoCatchError(t.tvfileListModel$,t.tvfilePostModel$,e)})))})))}},{key:"DeleteTVFile",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.tvfileDeleteModel$),this.httpClient.delete("/api/TVFile/"+e.TVFileID).pipe(Object(v.a)((function(i){t.httpClientService.DoSuccess(t.tvfileListModel$,t.tvfileDeleteModel$,i,s.a.Delete,e)})),Object(d.a)((function(e){return Object(p.a)(e).pipe(Object(v.a)((function(e){t.httpClientService.DoCatchError(t.tvfileListModel$,t.tvfileDeleteModel$,e)})))})))}}]),e}()).\u0275fac=function(e){return new(e||c)(f.Xb(T.b),f.Xb(S.a))},c.\u0275prov=f.Jb({token:c,factory:c.\u0275fac,providedIn:"root"}),c),I=i("Wp6s"),y=i("bTqV"),F=i("bv9b"),g=i("NFeN"),D=i("3Pt+"),C=i("kmnG"),x=i("qFsG"),E=i("d3UM"),B=i("FKr1");function j(e,t){1&e&&f.Ob(0,"mat-progress-bar",23)}function P(e,t){1&e&&f.Ob(0,"mat-progress-bar",23)}function O(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function V(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,O,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,2,i)),f.Bb(3),f.jc("ngIf",i.required)}}function $(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function M(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,$,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,2,i)),f.Bb(3),f.jc("ngIf",i.required)}}function k(e,t){if(1&e&&(f.Tb(0,"mat-option",24),f.yc(1),f.Sb()),2&e){var i=t.$implicit;f.jc("value",i.EnumID),f.Bb(1),f.Ac(" ",i.EnumText," ")}}function L(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,1,i))}}function w(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,1,i))}}function G(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,1,i))}}function q(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Min - 1980"),f.Ob(2,"br"),f.Sb())}function _(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Max - 2050"),f.Ob(2,"br"),f.Sb())}function N(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,q,3,0,"span",4),f.xc(6,_,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,3,i)),f.Bb(3),f.jc("ngIf",i.min),f.Bb(1),f.jc("ngIf",i.min)}}function U(e,t){if(1&e&&(f.Tb(0,"mat-option",24),f.yc(1),f.Sb()),2&e){var i=t.$implicit;f.jc("value",i.EnumID),f.Bb(1),f.Ac(" ",i.EnumText," ")}}function A(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function z(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,A,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,2,i)),f.Bb(3),f.jc("ngIf",i.required)}}function R(e,t){if(1&e&&(f.Tb(0,"mat-option",24),f.yc(1),f.Sb()),2&e){var i=t.$implicit;f.jc("value",i.EnumID),f.Bb(1),f.Ac(" ",i.EnumText," ")}}function K(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function W(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,K,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,2,i)),f.Bb(3),f.jc("ngIf",i.required)}}function Y(e,t){if(1&e&&(f.Tb(0,"mat-option",24),f.yc(1),f.Sb()),2&e){var i=t.$implicit;f.jc("value",i.EnumID),f.Bb(1),f.Ac(" ",i.EnumText," ")}}function H(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function J(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,H,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,2,i)),f.Bb(3),f.jc("ngIf",i.required)}}function X(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function Z(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Min - 0"),f.Ob(2,"br"),f.Sb())}function Q(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Max - 100000000"),f.Ob(2,"br"),f.Sb())}function ee(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,X,3,0,"span",4),f.xc(6,Z,3,0,"span",4),f.xc(7,Q,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,4,i)),f.Bb(3),f.jc("ngIf",i.required),f.Bb(1),f.jc("ngIf",i.min),f.Bb(1),f.jc("ngIf",i.min)}}function te(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,1,i))}}function ie(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function ne(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,ie,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,2,i)),f.Bb(3),f.jc("ngIf",i.required)}}function re(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,1,i))}}function ae(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"MaxLength - 250"),f.Ob(2,"br"),f.Sb())}function be(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,ae,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,2,i)),f.Bb(3),f.jc("ngIf",i.maxlength)}}function le(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function oe(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"MaxLength - 250"),f.Ob(2,"br"),f.Sb())}function ce(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,le,3,0,"span",4),f.xc(6,oe,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,3,i)),f.Bb(3),f.jc("ngIf",i.required),f.Bb(1),f.jc("ngIf",i.maxlength)}}function ue(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function se(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"MaxLength - 250"),f.Ob(2,"br"),f.Sb())}function fe(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,ue,3,0,"span",4),f.xc(6,se,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,3,i)),f.Bb(3),f.jc("ngIf",i.required),f.Bb(1),f.jc("ngIf",i.maxlength)}}function me(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function pe(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,me,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,2,i)),f.Bb(3),f.jc("ngIf",i.required)}}function Te(e,t){1&e&&(f.Tb(0,"span"),f.yc(1,"Is Required"),f.Ob(2,"br"),f.Sb())}function ve(e,t){if(1&e&&(f.Tb(0,"mat-error"),f.Tb(1,"span"),f.yc(2),f.fc(3,"json"),f.Ob(4,"br"),f.Sb(),f.xc(5,Te,3,0,"span",4),f.Sb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.gc(3,2,i)),f.Bb(3),f.jc("ngIf",i.required)}}var de,Se=((de=function(){function e(t,i){_classCallCheck(this,e),this.tvfileService=t,this.fb=i,this.tvfile=null,this.httpClientCommand=s.a.Put}return _createClass(e,[{key:"GetPut",value:function(){return this.httpClientCommand==s.a.Put}},{key:"PutTVFile",value:function(e){this.sub=this.tvfileService.PutTVFile(e).subscribe()}},{key:"PostTVFile",value:function(e){this.sub=this.tvfileService.PostTVFile(e).subscribe()}},{key:"ngOnInit",value:function(){this.templateTVTypeList=Object(b.b)(),this.languageList=Object(l.b)(),this.filePurposeList=o(),this.fileTypeList=Object(u.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.tvfile){var t=this.fb.group({TVFileID:[{value:e===s.a.Post?0:this.tvfile.TVFileID,disabled:!1},[D.p.required]],TVFileTVItemID:[{value:this.tvfile.TVFileTVItemID,disabled:!1},[D.p.required]],TemplateTVType:[{value:this.tvfile.TemplateTVType,disabled:!1}],ReportTypeID:[{value:this.tvfile.ReportTypeID,disabled:!1}],Parameters:[{value:this.tvfile.Parameters,disabled:!1}],Year:[{value:this.tvfile.Year,disabled:!1},[D.p.min(1980),D.p.max(2050)]],Language:[{value:this.tvfile.Language,disabled:!1},[D.p.required]],FilePurpose:[{value:this.tvfile.FilePurpose,disabled:!1},[D.p.required]],FileType:[{value:this.tvfile.FileType,disabled:!1},[D.p.required]],FileSize_kb:[{value:this.tvfile.FileSize_kb,disabled:!1},[D.p.required,D.p.min(0),D.p.max(1e8)]],FileInfo:[{value:this.tvfile.FileInfo,disabled:!1}],FileCreatedDate_UTC:[{value:this.tvfile.FileCreatedDate_UTC,disabled:!1},[D.p.required]],FromWater:[{value:this.tvfile.FromWater,disabled:!1}],ClientFilePath:[{value:this.tvfile.ClientFilePath,disabled:!1},[D.p.maxLength(250)]],ServerFileName:[{value:this.tvfile.ServerFileName,disabled:!1},[D.p.required,D.p.maxLength(250)]],ServerFilePath:[{value:this.tvfile.ServerFilePath,disabled:!1},[D.p.required,D.p.maxLength(250)]],LastUpdateDate_UTC:[{value:this.tvfile.LastUpdateDate_UTC,disabled:!1},[D.p.required]],LastUpdateContactTVItemID:[{value:this.tvfile.LastUpdateContactTVItemID,disabled:!1},[D.p.required]]});this.tvfileFormEdit=t}}}]),e}()).\u0275fac=function(e){return new(e||de)(f.Nb(h),f.Nb(D.d))},de.\u0275cmp=f.Hb({type:de,selectors:[["app-tvfile-edit"]],inputs:{tvfile:"tvfile",httpClientCommand:"httpClientCommand"},decls:107,vars:26,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TVFileID"],[4,"ngIf"],["matInput","","type","number","formControlName","TVFileTVItemID"],["formControlName","TemplateTVType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","number","formControlName","ReportTypeID"],["matInput","","type","text","formControlName","Parameters"],["matInput","","type","number","formControlName","Year"],["formControlName","Language"],["formControlName","FilePurpose"],["formControlName","FileType"],["matInput","","type","number","formControlName","FileSize_kb"],["matInput","","type","text","formControlName","FileInfo"],["matInput","","type","text","formControlName","FileCreatedDate_UTC"],["matInput","","type","text","formControlName","FromWater"],["matInput","","type","text","formControlName","ClientFilePath"],["matInput","","type","text","formControlName","ServerFileName"],["matInput","","type","text","formControlName","ServerFilePath"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(f.Tb(0,"form",0),f.ac("ngSubmit",(function(){return t.GetPut()?t.PutTVFile(t.tvfileFormEdit.value):t.PostTVFile(t.tvfileFormEdit.value)})),f.Tb(1,"h3"),f.yc(2," TVFile "),f.Tb(3,"button",1),f.Tb(4,"span"),f.yc(5),f.Sb(),f.Sb(),f.xc(6,j,1,0,"mat-progress-bar",2),f.xc(7,P,1,0,"mat-progress-bar",2),f.Sb(),f.Tb(8,"p"),f.Tb(9,"mat-form-field"),f.Tb(10,"mat-label"),f.yc(11,"TVFileID"),f.Sb(),f.Ob(12,"input",3),f.xc(13,V,6,4,"mat-error",4),f.Sb(),f.Tb(14,"mat-form-field"),f.Tb(15,"mat-label"),f.yc(16,"TVFileTVItemID"),f.Sb(),f.Ob(17,"input",5),f.xc(18,M,6,4,"mat-error",4),f.Sb(),f.Tb(19,"mat-form-field"),f.Tb(20,"mat-label"),f.yc(21,"TemplateTVType"),f.Sb(),f.Tb(22,"mat-select",6),f.xc(23,k,2,2,"mat-option",7),f.Sb(),f.xc(24,L,5,3,"mat-error",4),f.Sb(),f.Tb(25,"mat-form-field"),f.Tb(26,"mat-label"),f.yc(27,"ReportTypeID"),f.Sb(),f.Ob(28,"input",8),f.xc(29,w,5,3,"mat-error",4),f.Sb(),f.Sb(),f.Tb(30,"p"),f.Tb(31,"mat-form-field"),f.Tb(32,"mat-label"),f.yc(33,"Parameters"),f.Sb(),f.Ob(34,"input",9),f.xc(35,G,5,3,"mat-error",4),f.Sb(),f.Tb(36,"mat-form-field"),f.Tb(37,"mat-label"),f.yc(38,"Year"),f.Sb(),f.Ob(39,"input",10),f.xc(40,N,7,5,"mat-error",4),f.Sb(),f.Tb(41,"mat-form-field"),f.Tb(42,"mat-label"),f.yc(43,"Language"),f.Sb(),f.Tb(44,"mat-select",11),f.xc(45,U,2,2,"mat-option",7),f.Sb(),f.xc(46,z,6,4,"mat-error",4),f.Sb(),f.Tb(47,"mat-form-field"),f.Tb(48,"mat-label"),f.yc(49,"FilePurpose"),f.Sb(),f.Tb(50,"mat-select",12),f.xc(51,R,2,2,"mat-option",7),f.Sb(),f.xc(52,W,6,4,"mat-error",4),f.Sb(),f.Sb(),f.Tb(53,"p"),f.Tb(54,"mat-form-field"),f.Tb(55,"mat-label"),f.yc(56,"FileType"),f.Sb(),f.Tb(57,"mat-select",13),f.xc(58,Y,2,2,"mat-option",7),f.Sb(),f.xc(59,J,6,4,"mat-error",4),f.Sb(),f.Tb(60,"mat-form-field"),f.Tb(61,"mat-label"),f.yc(62,"FileSize_kb"),f.Sb(),f.Ob(63,"input",14),f.xc(64,ee,8,6,"mat-error",4),f.Sb(),f.Tb(65,"mat-form-field"),f.Tb(66,"mat-label"),f.yc(67,"FileInfo"),f.Sb(),f.Ob(68,"input",15),f.xc(69,te,5,3,"mat-error",4),f.Sb(),f.Tb(70,"mat-form-field"),f.Tb(71,"mat-label"),f.yc(72,"FileCreatedDate_UTC"),f.Sb(),f.Ob(73,"input",16),f.xc(74,ne,6,4,"mat-error",4),f.Sb(),f.Sb(),f.Tb(75,"p"),f.Tb(76,"mat-form-field"),f.Tb(77,"mat-label"),f.yc(78,"FromWater"),f.Sb(),f.Ob(79,"input",17),f.xc(80,re,5,3,"mat-error",4),f.Sb(),f.Tb(81,"mat-form-field"),f.Tb(82,"mat-label"),f.yc(83,"ClientFilePath"),f.Sb(),f.Ob(84,"input",18),f.xc(85,be,6,4,"mat-error",4),f.Sb(),f.Tb(86,"mat-form-field"),f.Tb(87,"mat-label"),f.yc(88,"ServerFileName"),f.Sb(),f.Ob(89,"input",19),f.xc(90,ce,7,5,"mat-error",4),f.Sb(),f.Tb(91,"mat-form-field"),f.Tb(92,"mat-label"),f.yc(93,"ServerFilePath"),f.Sb(),f.Ob(94,"input",20),f.xc(95,fe,7,5,"mat-error",4),f.Sb(),f.Sb(),f.Tb(96,"p"),f.Tb(97,"mat-form-field"),f.Tb(98,"mat-label"),f.yc(99,"LastUpdateDate_UTC"),f.Sb(),f.Ob(100,"input",21),f.xc(101,pe,6,4,"mat-error",4),f.Sb(),f.Tb(102,"mat-form-field"),f.Tb(103,"mat-label"),f.yc(104,"LastUpdateContactTVItemID"),f.Sb(),f.Ob(105,"input",22),f.xc(106,ve,6,4,"mat-error",4),f.Sb(),f.Sb(),f.Sb()),2&e&&(f.jc("formGroup",t.tvfileFormEdit),f.Bb(5),f.Ac("",t.GetPut()?"Put":"Post"," TVFile"),f.Bb(1),f.jc("ngIf",t.tvfileService.tvfilePutModel$.getValue().Working),f.Bb(1),f.jc("ngIf",t.tvfileService.tvfilePostModel$.getValue().Working),f.Bb(6),f.jc("ngIf",t.tvfileFormEdit.controls.TVFileID.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.TVFileTVItemID.errors),f.Bb(5),f.jc("ngForOf",t.templateTVTypeList),f.Bb(1),f.jc("ngIf",t.tvfileFormEdit.controls.TemplateTVType.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.ReportTypeID.errors),f.Bb(6),f.jc("ngIf",t.tvfileFormEdit.controls.Parameters.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.Year.errors),f.Bb(5),f.jc("ngForOf",t.languageList),f.Bb(1),f.jc("ngIf",t.tvfileFormEdit.controls.Language.errors),f.Bb(5),f.jc("ngForOf",t.filePurposeList),f.Bb(1),f.jc("ngIf",t.tvfileFormEdit.controls.FilePurpose.errors),f.Bb(6),f.jc("ngForOf",t.fileTypeList),f.Bb(1),f.jc("ngIf",t.tvfileFormEdit.controls.FileType.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.FileSize_kb.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.FileInfo.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.FileCreatedDate_UTC.errors),f.Bb(6),f.jc("ngIf",t.tvfileFormEdit.controls.FromWater.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.ClientFilePath.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.ServerFileName.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.ServerFilePath.errors),f.Bb(6),f.jc("ngIf",t.tvfileFormEdit.controls.LastUpdateDate_UTC.errors),f.Bb(5),f.jc("ngIf",t.tvfileFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[D.q,D.l,D.f,y.b,n.l,C.c,C.f,x.b,D.n,D.c,D.k,D.e,E.a,n.k,F.a,C.b,B.n],pipes:[n.f],styles:[""],changeDetection:0}),de);function he(e,t){1&e&&f.Ob(0,"mat-progress-bar",4)}function Ie(e,t){1&e&&f.Ob(0,"mat-progress-bar",4)}function ye(e,t){if(1&e&&(f.Tb(0,"p"),f.Ob(1,"app-tvfile-edit",8),f.Sb()),2&e){var i=f.ec().$implicit,n=f.ec(2);f.Bb(1),f.jc("tvfile",i)("httpClientCommand",n.GetPutEnum())}}function Fe(e,t){if(1&e&&(f.Tb(0,"p"),f.Ob(1,"app-tvfile-edit",8),f.Sb()),2&e){var i=f.ec().$implicit,n=f.ec(2);f.Bb(1),f.jc("tvfile",i)("httpClientCommand",n.GetPostEnum())}}function ge(e,t){if(1&e){var i=f.Ub();f.Tb(0,"div"),f.Tb(1,"p"),f.Tb(2,"button",6),f.ac("click",(function(){f.rc(i);var e=t.$implicit;return f.ec(2).DeleteTVFile(e)})),f.Tb(3,"span"),f.yc(4),f.Sb(),f.Tb(5,"mat-icon"),f.yc(6,"delete"),f.Sb(),f.Sb(),f.yc(7,"\xa0\xa0\xa0 "),f.Tb(8,"button",7),f.ac("click",(function(){f.rc(i);var e=t.$implicit;return f.ec(2).ShowPut(e)})),f.Tb(9,"span"),f.yc(10,"Show Put"),f.Sb(),f.Sb(),f.yc(11,"\xa0\xa0 "),f.Tb(12,"button",7),f.ac("click",(function(){f.rc(i);var e=t.$implicit;return f.ec(2).ShowPost(e)})),f.Tb(13,"span"),f.yc(14,"Show Post"),f.Sb(),f.Sb(),f.yc(15,"\xa0\xa0 "),f.xc(16,Ie,1,0,"mat-progress-bar",0),f.Sb(),f.xc(17,ye,2,2,"p",2),f.xc(18,Fe,2,2,"p",2),f.Tb(19,"blockquote"),f.Tb(20,"p"),f.Tb(21,"span"),f.yc(22),f.Sb(),f.Tb(23,"span"),f.yc(24),f.Sb(),f.Tb(25,"span"),f.yc(26),f.Sb(),f.Tb(27,"span"),f.yc(28),f.Sb(),f.Sb(),f.Tb(29,"p"),f.Tb(30,"span"),f.yc(31),f.Sb(),f.Tb(32,"span"),f.yc(33),f.Sb(),f.Tb(34,"span"),f.yc(35),f.Sb(),f.Tb(36,"span"),f.yc(37),f.Sb(),f.Sb(),f.Tb(38,"p"),f.Tb(39,"span"),f.yc(40),f.Sb(),f.Tb(41,"span"),f.yc(42),f.Sb(),f.Tb(43,"span"),f.yc(44),f.Sb(),f.Tb(45,"span"),f.yc(46),f.Sb(),f.Sb(),f.Tb(47,"p"),f.Tb(48,"span"),f.yc(49),f.Sb(),f.Tb(50,"span"),f.yc(51),f.Sb(),f.Tb(52,"span"),f.yc(53),f.Sb(),f.Tb(54,"span"),f.yc(55),f.Sb(),f.Sb(),f.Tb(56,"p"),f.Tb(57,"span"),f.yc(58),f.Sb(),f.Tb(59,"span"),f.yc(60),f.Sb(),f.Sb(),f.Sb(),f.Sb()}if(2&e){var n=t.$implicit,r=f.ec(2);f.Bb(4),f.Ac("Delete TVFileID [",n.TVFileID,"]\xa0\xa0\xa0"),f.Bb(4),f.jc("color",r.GetPutButtonColor(n)),f.Bb(4),f.jc("color",r.GetPostButtonColor(n)),f.Bb(4),f.jc("ngIf",r.tvfileService.tvfileDeleteModel$.getValue().Working),f.Bb(1),f.jc("ngIf",r.IDToShow===n.TVFileID&&r.showType===r.GetPutEnum()),f.Bb(1),f.jc("ngIf",r.IDToShow===n.TVFileID&&r.showType===r.GetPostEnum()),f.Bb(4),f.Ac("TVFileID: [",n.TVFileID,"]"),f.Bb(2),f.Ac(" --- TVFileTVItemID: [",n.TVFileTVItemID,"]"),f.Bb(2),f.Ac(" --- TemplateTVType: [",r.GetTVTypeEnumText(n.TemplateTVType),"]"),f.Bb(2),f.Ac(" --- ReportTypeID: [",n.ReportTypeID,"]"),f.Bb(3),f.Ac("Parameters: [",n.Parameters,"]"),f.Bb(2),f.Ac(" --- Year: [",n.Year,"]"),f.Bb(2),f.Ac(" --- Language: [",r.GetLanguageEnumText(n.Language),"]"),f.Bb(2),f.Ac(" --- FilePurpose: [",r.GetFilePurposeEnumText(n.FilePurpose),"]"),f.Bb(3),f.Ac("FileType: [",r.GetFileTypeEnumText(n.FileType),"]"),f.Bb(2),f.Ac(" --- FileSize_kb: [",n.FileSize_kb,"]"),f.Bb(2),f.Ac(" --- FileInfo: [",n.FileInfo,"]"),f.Bb(2),f.Ac(" --- FileCreatedDate_UTC: [",n.FileCreatedDate_UTC,"]"),f.Bb(3),f.Ac("FromWater: [",n.FromWater,"]"),f.Bb(2),f.Ac(" --- ClientFilePath: [",n.ClientFilePath,"]"),f.Bb(2),f.Ac(" --- ServerFileName: [",n.ServerFileName,"]"),f.Bb(2),f.Ac(" --- ServerFilePath: [",n.ServerFilePath,"]"),f.Bb(3),f.Ac("LastUpdateDate_UTC: [",n.LastUpdateDate_UTC,"]"),f.Bb(2),f.Ac(" --- LastUpdateContactTVItemID: [",n.LastUpdateContactTVItemID,"]")}}function De(e,t){if(1&e&&(f.Tb(0,"div"),f.xc(1,ge,61,24,"div",5),f.Sb()),2&e){var i=f.ec();f.Bb(1),f.jc("ngForOf",i.tvfileService.tvfileListModel$.getValue())}}var Ce,xe,Ee,Be=[{path:"",component:(Ce=function(){function e(t,i,n){_classCallCheck(this,e),this.tvfileService=t,this.router=i,this.httpClientService=n,this.showType=null,n.oldURL=i.url}return _createClass(e,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.TVFileID&&this.showType===s.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.TVFileID&&this.showType===s.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.TVFileID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.TVFileID,this.showType=s.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.TVFileID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.TVFileID,this.showType=s.a.Post)}},{key:"GetPutEnum",value:function(){return s.a.Put}},{key:"GetPostEnum",value:function(){return s.a.Post}},{key:"GetTVFileList",value:function(){this.sub=this.tvfileService.GetTVFileList().subscribe()}},{key:"DeleteTVFile",value:function(e){this.sub=this.tvfileService.DeleteTVFile(e).subscribe()}},{key:"GetTVTypeEnumText",value:function(e){return Object(b.a)(e)}},{key:"GetLanguageEnumText",value:function(e){return Object(l.a)(e)}},{key:"GetFilePurposeEnumText",value:function(e){return function(e){var t;return o().forEach((function(i){if(i.EnumID==e)return t=i.EnumText,!1})),t}(e)}},{key:"GetFileTypeEnumText",value:function(e){return Object(u.a)(e)}},{key:"ngOnInit",value:function(){a(this.tvfileService.tvfileTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),e}(),Ce.\u0275fac=function(e){return new(e||Ce)(f.Nb(h),f.Nb(r.b),f.Nb(S.a))},Ce.\u0275cmp=f.Hb({type:Ce,selectors:[["app-tvfile"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tvfile","httpClientCommand"]],template:function(e,t){if(1&e&&(f.xc(0,he,1,0,"mat-progress-bar",0),f.Tb(1,"mat-card"),f.Tb(2,"mat-card-header"),f.Tb(3,"mat-card-title"),f.yc(4," TVFile works! "),f.Tb(5,"button",1),f.ac("click",(function(){return t.GetTVFileList()})),f.Tb(6,"span"),f.yc(7,"Get TVFile"),f.Sb(),f.Sb(),f.Sb(),f.Tb(8,"mat-card-subtitle"),f.yc(9),f.Sb(),f.Sb(),f.Tb(10,"mat-card-content"),f.xc(11,De,2,1,"div",2),f.Sb(),f.Tb(12,"mat-card-actions"),f.Tb(13,"button",3),f.yc(14,"Allo"),f.Sb(),f.Sb(),f.Sb()),2&e){var i,n,r=null==(i=t.tvfileService.tvfileGetModel$.getValue())?null:i.Working,a=null==(n=t.tvfileService.tvfileListModel$.getValue())?null:n.length;f.jc("ngIf",r),f.Bb(9),f.zc(t.tvfileService.tvfileTextModel$.getValue().Title),f.Bb(2),f.jc("ngIf",a)}},directives:[n.l,I.a,I.d,I.g,y.b,I.f,I.c,I.b,F.a,n.k,g.a,Se],styles:[""],changeDetection:0}),Ce),canActivate:[i("auXs").a]}],je=((xe=function e(){_classCallCheck(this,e)}).\u0275mod=f.Lb({type:xe}),xe.\u0275inj=f.Kb({factory:function(e){return new(e||xe)},imports:[[r.e.forChild(Be)],r.e]}),xe),Pe=i("B+Mi"),Oe=((Ee=function e(){_classCallCheck(this,e)}).\u0275mod=f.Lb({type:Ee}),Ee.\u0275inj=f.Kb({factory:function(e){return new(e||Ee)},imports:[[n.c,r.e,je,Pe.a,D.g,D.o]]}),Ee)}}]);