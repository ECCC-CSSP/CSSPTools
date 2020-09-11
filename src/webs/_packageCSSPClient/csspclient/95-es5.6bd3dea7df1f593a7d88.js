!function(){function e(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function t(e,t){for(var i=0;i<t.length;i++){var n=t[i];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(e,n.key,n)}}function i(e,i,n){return i&&t(e.prototype,i),n&&t(e,n),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[95],{CEwS:function(t,n,r){"use strict";r.r(n),r.d(n,"TVFileModule",(function(){return Me}));var a=r("ofXK"),b=r("tyNb");function o(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var l=r("BJD1"),c=r("PSTt");function u(){var e=[];return"fr-CA"===$localize.locale?(e.push({EnumID:1,EnumText:"MIKE Input (fr)"}),e.push({EnumID:2,EnumText:"MIKE Input MDF (fr)"}),e.push({EnumID:3,EnumText:"MIKE Result DFSU (fr)"}),e.push({EnumID:4,EnumText:"MIKE Result KMZ (fr)"}),e.push({EnumID:5,EnumText:"Information (fr)"}),e.push({EnumID:6,EnumText:"Image (fr)"}),e.push({EnumID:7,EnumText:"Picture (fr)"}),e.push({EnumID:8,EnumText:"Report Generated (fr)"}),e.push({EnumID:9,EnumText:"Template Generated (fr)"}),e.push({EnumID:10,EnumText:"Generated FC Form(fr)"}),e.push({EnumID:11,EnumText:"Template (fr)"}),e.push({EnumID:12,EnumText:"Map (fr)"}),e.push({EnumID:13,EnumText:"Analyses"}),e.push({EnumID:14,EnumText:"Open Data (fr)"})):(e.push({EnumID:1,EnumText:"MIKE Input"}),e.push({EnumID:2,EnumText:"MIKE Input MDF"}),e.push({EnumID:3,EnumText:"MIKE Result DFSU"}),e.push({EnumID:4,EnumText:"MIKE Result KMZ"}),e.push({EnumID:5,EnumText:"Information"}),e.push({EnumID:6,EnumText:"Image"}),e.push({EnumID:7,EnumText:"Picture"}),e.push({EnumID:8,EnumText:"Report Generated"}),e.push({EnumID:9,EnumText:"Template Generated"}),e.push({EnumID:10,EnumText:"Generated FC Form"}),e.push({EnumID:11,EnumText:"Template"}),e.push({EnumID:12,EnumText:"Map"}),e.push({EnumID:13,EnumText:"Analysis"}),e.push({EnumID:14,EnumText:"Open Data"})),e.sort((function(e,t){return e.EnumText.localeCompare(t.EnumText)}))}var s,m=r("PDru"),p=r("QRvi"),f=r("fXoL"),h=r("2Vo4"),v=r("LRne"),d=r("tk/3"),S=r("lJxs"),T=r("JIr8"),I=r("gkM4"),y=((s=function(){function t(i,n){e(this,t),this.httpClient=i,this.httpClientService=n,this.tvfileTextModel$=new h.a({}),this.tvfileListModel$=new h.a({}),this.tvfileGetModel$=new h.a({}),this.tvfilePutModel$=new h.a({}),this.tvfilePostModel$=new h.a({}),this.tvfileDeleteModel$=new h.a({}),o(this.tvfileTextModel$),this.tvfileTextModel$.next({Title:"Something2 for text"})}return i(t,[{key:"GetTVFileList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.tvfileGetModel$),this.httpClient.get("/api/TVFile").pipe(Object(S.a)((function(t){e.httpClientService.DoSuccess(e.tvfileListModel$,e.tvfileGetModel$,t,p.a.Get,null)})),Object(T.a)((function(t){return Object(v.a)(t).pipe(Object(S.a)((function(t){e.httpClientService.DoCatchError(e.tvfileListModel$,e.tvfileGetModel$,t)})))})))}},{key:"PutTVFile",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.tvfilePutModel$),this.httpClient.put("/api/TVFile",e,{headers:new d.d}).pipe(Object(S.a)((function(i){t.httpClientService.DoSuccess(t.tvfileListModel$,t.tvfilePutModel$,i,p.a.Put,e)})),Object(T.a)((function(e){return Object(v.a)(e).pipe(Object(S.a)((function(e){t.httpClientService.DoCatchError(t.tvfileListModel$,t.tvfilePutModel$,e)})))})))}},{key:"PostTVFile",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.tvfilePostModel$),this.httpClient.post("/api/TVFile",e,{headers:new d.d}).pipe(Object(S.a)((function(i){t.httpClientService.DoSuccess(t.tvfileListModel$,t.tvfilePostModel$,i,p.a.Post,e)})),Object(T.a)((function(e){return Object(v.a)(e).pipe(Object(S.a)((function(e){t.httpClientService.DoCatchError(t.tvfileListModel$,t.tvfilePostModel$,e)})))})))}},{key:"DeleteTVFile",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.tvfileDeleteModel$),this.httpClient.delete("/api/TVFile/"+e.TVFileID).pipe(Object(S.a)((function(i){t.httpClientService.DoSuccess(t.tvfileListModel$,t.tvfileDeleteModel$,i,p.a.Delete,e)})),Object(T.a)((function(e){return Object(v.a)(e).pipe(Object(S.a)((function(e){t.httpClientService.DoCatchError(t.tvfileListModel$,t.tvfileDeleteModel$,e)})))})))}}]),t}()).\u0275fac=function(e){return new(e||s)(f.Wb(d.b),f.Wb(I.a))},s.\u0275prov=f.Ib({token:s,factory:s.\u0275fac,providedIn:"root"}),s),R=r("Wp6s"),F=r("bTqV"),D=r("bv9b"),g=r("NFeN"),x=r("3Pt+"),E=r("kmnG"),C=r("qFsG"),B=r("d3UM"),P=r("FKr1");function N(e,t){1&e&&f.Nb(0,"mat-progress-bar",23)}function V(e,t){1&e&&f.Nb(0,"mat-progress-bar",23)}function M(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function $(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,M,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,2,i)),f.Bb(3),f.hc("ngIf",i.required)}}function L(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function k(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,L,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,2,i)),f.Bb(3),f.hc("ngIf",i.required)}}function w(e,t){if(1&e&&(f.Sb(0,"mat-option",24),f.yc(1),f.Rb()),2&e){var i=t.$implicit;f.hc("value",i.EnumID),f.Bb(1),f.Ac(" ",i.EnumText," ")}}function G(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,1,i))}}function j(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,1,i))}}function q(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,1,i))}}function O(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Min - 1980"),f.Nb(2,"br"),f.Rb())}function U(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Max - 2050"),f.Nb(2,"br"),f.Rb())}function A(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,O,3,0,"span",4),f.xc(6,U,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,3,i)),f.Bb(3),f.hc("ngIf",i.min),f.Bb(1),f.hc("ngIf",i.min)}}function z(e,t){if(1&e&&(f.Sb(0,"mat-option",24),f.yc(1),f.Rb()),2&e){var i=t.$implicit;f.hc("value",i.EnumID),f.Bb(1),f.Ac(" ",i.EnumText," ")}}function _(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function K(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,_,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,2,i)),f.Bb(3),f.hc("ngIf",i.required)}}function W(e,t){if(1&e&&(f.Sb(0,"mat-option",24),f.yc(1),f.Rb()),2&e){var i=t.$implicit;f.hc("value",i.EnumID),f.Bb(1),f.Ac(" ",i.EnumText," ")}}function Y(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function J(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,Y,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,2,i)),f.Bb(3),f.hc("ngIf",i.required)}}function H(e,t){if(1&e&&(f.Sb(0,"mat-option",24),f.yc(1),f.Rb()),2&e){var i=t.$implicit;f.hc("value",i.EnumID),f.Bb(1),f.Ac(" ",i.EnumText," ")}}function X(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function Z(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,X,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,2,i)),f.Bb(3),f.hc("ngIf",i.required)}}function Q(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function ee(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Min - 0"),f.Nb(2,"br"),f.Rb())}function te(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Max - 100000000"),f.Nb(2,"br"),f.Rb())}function ie(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,Q,3,0,"span",4),f.xc(6,ee,3,0,"span",4),f.xc(7,te,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,4,i)),f.Bb(3),f.hc("ngIf",i.required),f.Bb(1),f.hc("ngIf",i.min),f.Bb(1),f.hc("ngIf",i.min)}}function ne(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,1,i))}}function re(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function ae(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,re,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,2,i)),f.Bb(3),f.hc("ngIf",i.required)}}function be(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,1,i))}}function oe(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"MaxLength - 250"),f.Nb(2,"br"),f.Rb())}function le(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,oe,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,2,i)),f.Bb(3),f.hc("ngIf",i.maxlength)}}function ce(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function ue(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"MaxLength - 250"),f.Nb(2,"br"),f.Rb())}function se(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,ce,3,0,"span",4),f.xc(6,ue,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,3,i)),f.Bb(3),f.hc("ngIf",i.required),f.Bb(1),f.hc("ngIf",i.maxlength)}}function me(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function pe(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"MaxLength - 250"),f.Nb(2,"br"),f.Rb())}function fe(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,me,3,0,"span",4),f.xc(6,pe,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,3,i)),f.Bb(3),f.hc("ngIf",i.required),f.Bb(1),f.hc("ngIf",i.maxlength)}}function he(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function ve(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,he,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,2,i)),f.Bb(3),f.hc("ngIf",i.required)}}function de(e,t){1&e&&(f.Sb(0,"span"),f.yc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function Se(e,t){if(1&e&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.yc(2),f.dc(3,"json"),f.Nb(4,"br"),f.Rb(),f.xc(5,de,3,0,"span",4),f.Rb()),2&e){var i=t.$implicit;f.Bb(2),f.zc(f.ec(3,2,i)),f.Bb(3),f.hc("ngIf",i.required)}}var Te,Ie=((Te=function(){function t(i,n){e(this,t),this.tvfileService=i,this.fb=n,this.tvfile=null,this.httpClientCommand=p.a.Put}return i(t,[{key:"GetPut",value:function(){return this.httpClientCommand==p.a.Put}},{key:"PutTVFile",value:function(e){this.sub=this.tvfileService.PutTVFile(e).subscribe()}},{key:"PostTVFile",value:function(e){this.sub=this.tvfileService.PostTVFile(e).subscribe()}},{key:"ngOnInit",value:function(){this.templateTVTypeList=Object(l.b)(),this.languageList=Object(c.b)(),this.filePurposeList=u(),this.fileTypeList=Object(m.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.tvfile){var t=this.fb.group({TVFileID:[{value:e===p.a.Post?0:this.tvfile.TVFileID,disabled:!1},[x.p.required]],TVFileTVItemID:[{value:this.tvfile.TVFileTVItemID,disabled:!1},[x.p.required]],TemplateTVType:[{value:this.tvfile.TemplateTVType,disabled:!1}],ReportTypeID:[{value:this.tvfile.ReportTypeID,disabled:!1}],Parameters:[{value:this.tvfile.Parameters,disabled:!1}],Year:[{value:this.tvfile.Year,disabled:!1},[x.p.min(1980),x.p.max(2050)]],Language:[{value:this.tvfile.Language,disabled:!1},[x.p.required]],FilePurpose:[{value:this.tvfile.FilePurpose,disabled:!1},[x.p.required]],FileType:[{value:this.tvfile.FileType,disabled:!1},[x.p.required]],FileSize_kb:[{value:this.tvfile.FileSize_kb,disabled:!1},[x.p.required,x.p.min(0),x.p.max(1e8)]],FileInfo:[{value:this.tvfile.FileInfo,disabled:!1}],FileCreatedDate_UTC:[{value:this.tvfile.FileCreatedDate_UTC,disabled:!1},[x.p.required]],FromWater:[{value:this.tvfile.FromWater,disabled:!1}],ClientFilePath:[{value:this.tvfile.ClientFilePath,disabled:!1},[x.p.maxLength(250)]],ServerFileName:[{value:this.tvfile.ServerFileName,disabled:!1},[x.p.required,x.p.maxLength(250)]],ServerFilePath:[{value:this.tvfile.ServerFilePath,disabled:!1},[x.p.required,x.p.maxLength(250)]],LastUpdateDate_UTC:[{value:this.tvfile.LastUpdateDate_UTC,disabled:!1},[x.p.required]],LastUpdateContactTVItemID:[{value:this.tvfile.LastUpdateContactTVItemID,disabled:!1},[x.p.required]]});this.tvfileFormEdit=t}}}]),t}()).\u0275fac=function(e){return new(e||Te)(f.Mb(y),f.Mb(x.d))},Te.\u0275cmp=f.Gb({type:Te,selectors:[["app-tvfile-edit"]],inputs:{tvfile:"tvfile",httpClientCommand:"httpClientCommand"},decls:107,vars:26,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TVFileID"],[4,"ngIf"],["matInput","","type","number","formControlName","TVFileTVItemID"],["formControlName","TemplateTVType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","number","formControlName","ReportTypeID"],["matInput","","type","text","formControlName","Parameters"],["matInput","","type","number","formControlName","Year"],["formControlName","Language"],["formControlName","FilePurpose"],["formControlName","FileType"],["matInput","","type","number","formControlName","FileSize_kb"],["matInput","","type","text","formControlName","FileInfo"],["matInput","","type","text","formControlName","FileCreatedDate_UTC"],["matInput","","type","text","formControlName","FromWater"],["matInput","","type","text","formControlName","ClientFilePath"],["matInput","","type","text","formControlName","ServerFileName"],["matInput","","type","text","formControlName","ServerFilePath"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(f.Sb(0,"form",0),f.Yb("ngSubmit",(function(){return t.GetPut()?t.PutTVFile(t.tvfileFormEdit.value):t.PostTVFile(t.tvfileFormEdit.value)})),f.Sb(1,"h3"),f.yc(2," TVFile "),f.Sb(3,"button",1),f.Sb(4,"span"),f.yc(5),f.Rb(),f.Rb(),f.xc(6,N,1,0,"mat-progress-bar",2),f.xc(7,V,1,0,"mat-progress-bar",2),f.Rb(),f.Sb(8,"p"),f.Sb(9,"mat-form-field"),f.Sb(10,"mat-label"),f.yc(11,"TVFileID"),f.Rb(),f.Nb(12,"input",3),f.xc(13,$,6,4,"mat-error",4),f.Rb(),f.Sb(14,"mat-form-field"),f.Sb(15,"mat-label"),f.yc(16,"TVFileTVItemID"),f.Rb(),f.Nb(17,"input",5),f.xc(18,k,6,4,"mat-error",4),f.Rb(),f.Sb(19,"mat-form-field"),f.Sb(20,"mat-label"),f.yc(21,"TemplateTVType"),f.Rb(),f.Sb(22,"mat-select",6),f.xc(23,w,2,2,"mat-option",7),f.Rb(),f.xc(24,G,5,3,"mat-error",4),f.Rb(),f.Sb(25,"mat-form-field"),f.Sb(26,"mat-label"),f.yc(27,"ReportTypeID"),f.Rb(),f.Nb(28,"input",8),f.xc(29,j,5,3,"mat-error",4),f.Rb(),f.Rb(),f.Sb(30,"p"),f.Sb(31,"mat-form-field"),f.Sb(32,"mat-label"),f.yc(33,"Parameters"),f.Rb(),f.Nb(34,"input",9),f.xc(35,q,5,3,"mat-error",4),f.Rb(),f.Sb(36,"mat-form-field"),f.Sb(37,"mat-label"),f.yc(38,"Year"),f.Rb(),f.Nb(39,"input",10),f.xc(40,A,7,5,"mat-error",4),f.Rb(),f.Sb(41,"mat-form-field"),f.Sb(42,"mat-label"),f.yc(43,"Language"),f.Rb(),f.Sb(44,"mat-select",11),f.xc(45,z,2,2,"mat-option",7),f.Rb(),f.xc(46,K,6,4,"mat-error",4),f.Rb(),f.Sb(47,"mat-form-field"),f.Sb(48,"mat-label"),f.yc(49,"FilePurpose"),f.Rb(),f.Sb(50,"mat-select",12),f.xc(51,W,2,2,"mat-option",7),f.Rb(),f.xc(52,J,6,4,"mat-error",4),f.Rb(),f.Rb(),f.Sb(53,"p"),f.Sb(54,"mat-form-field"),f.Sb(55,"mat-label"),f.yc(56,"FileType"),f.Rb(),f.Sb(57,"mat-select",13),f.xc(58,H,2,2,"mat-option",7),f.Rb(),f.xc(59,Z,6,4,"mat-error",4),f.Rb(),f.Sb(60,"mat-form-field"),f.Sb(61,"mat-label"),f.yc(62,"FileSize_kb"),f.Rb(),f.Nb(63,"input",14),f.xc(64,ie,8,6,"mat-error",4),f.Rb(),f.Sb(65,"mat-form-field"),f.Sb(66,"mat-label"),f.yc(67,"FileInfo"),f.Rb(),f.Nb(68,"input",15),f.xc(69,ne,5,3,"mat-error",4),f.Rb(),f.Sb(70,"mat-form-field"),f.Sb(71,"mat-label"),f.yc(72,"FileCreatedDate_UTC"),f.Rb(),f.Nb(73,"input",16),f.xc(74,ae,6,4,"mat-error",4),f.Rb(),f.Rb(),f.Sb(75,"p"),f.Sb(76,"mat-form-field"),f.Sb(77,"mat-label"),f.yc(78,"FromWater"),f.Rb(),f.Nb(79,"input",17),f.xc(80,be,5,3,"mat-error",4),f.Rb(),f.Sb(81,"mat-form-field"),f.Sb(82,"mat-label"),f.yc(83,"ClientFilePath"),f.Rb(),f.Nb(84,"input",18),f.xc(85,le,6,4,"mat-error",4),f.Rb(),f.Sb(86,"mat-form-field"),f.Sb(87,"mat-label"),f.yc(88,"ServerFileName"),f.Rb(),f.Nb(89,"input",19),f.xc(90,se,7,5,"mat-error",4),f.Rb(),f.Sb(91,"mat-form-field"),f.Sb(92,"mat-label"),f.yc(93,"ServerFilePath"),f.Rb(),f.Nb(94,"input",20),f.xc(95,fe,7,5,"mat-error",4),f.Rb(),f.Rb(),f.Sb(96,"p"),f.Sb(97,"mat-form-field"),f.Sb(98,"mat-label"),f.yc(99,"LastUpdateDate_UTC"),f.Rb(),f.Nb(100,"input",21),f.xc(101,ve,6,4,"mat-error",4),f.Rb(),f.Sb(102,"mat-form-field"),f.Sb(103,"mat-label"),f.yc(104,"LastUpdateContactTVItemID"),f.Rb(),f.Nb(105,"input",22),f.xc(106,Se,6,4,"mat-error",4),f.Rb(),f.Rb(),f.Rb()),2&e&&(f.hc("formGroup",t.tvfileFormEdit),f.Bb(5),f.Ac("",t.GetPut()?"Put":"Post"," TVFile"),f.Bb(1),f.hc("ngIf",t.tvfileService.tvfilePutModel$.getValue().Working),f.Bb(1),f.hc("ngIf",t.tvfileService.tvfilePostModel$.getValue().Working),f.Bb(6),f.hc("ngIf",t.tvfileFormEdit.controls.TVFileID.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.TVFileTVItemID.errors),f.Bb(5),f.hc("ngForOf",t.templateTVTypeList),f.Bb(1),f.hc("ngIf",t.tvfileFormEdit.controls.TemplateTVType.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.ReportTypeID.errors),f.Bb(6),f.hc("ngIf",t.tvfileFormEdit.controls.Parameters.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.Year.errors),f.Bb(5),f.hc("ngForOf",t.languageList),f.Bb(1),f.hc("ngIf",t.tvfileFormEdit.controls.Language.errors),f.Bb(5),f.hc("ngForOf",t.filePurposeList),f.Bb(1),f.hc("ngIf",t.tvfileFormEdit.controls.FilePurpose.errors),f.Bb(6),f.hc("ngForOf",t.fileTypeList),f.Bb(1),f.hc("ngIf",t.tvfileFormEdit.controls.FileType.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.FileSize_kb.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.FileInfo.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.FileCreatedDate_UTC.errors),f.Bb(6),f.hc("ngIf",t.tvfileFormEdit.controls.FromWater.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.ClientFilePath.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.ServerFileName.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.ServerFilePath.errors),f.Bb(6),f.hc("ngIf",t.tvfileFormEdit.controls.LastUpdateDate_UTC.errors),f.Bb(5),f.hc("ngIf",t.tvfileFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[x.q,x.l,x.f,F.b,a.l,E.c,E.f,C.b,x.n,x.c,x.k,x.e,B.a,a.k,D.a,E.b,P.n],pipes:[a.f],styles:[""],changeDetection:0}),Te);function ye(e,t){1&e&&f.Nb(0,"mat-progress-bar",4)}function Re(e,t){1&e&&f.Nb(0,"mat-progress-bar",4)}function Fe(e,t){if(1&e&&(f.Sb(0,"p"),f.Nb(1,"app-tvfile-edit",8),f.Rb()),2&e){var i=f.cc().$implicit,n=f.cc(2);f.Bb(1),f.hc("tvfile",i)("httpClientCommand",n.GetPutEnum())}}function De(e,t){if(1&e&&(f.Sb(0,"p"),f.Nb(1,"app-tvfile-edit",8),f.Rb()),2&e){var i=f.cc().$implicit,n=f.cc(2);f.Bb(1),f.hc("tvfile",i)("httpClientCommand",n.GetPostEnum())}}function ge(e,t){if(1&e){var i=f.Tb();f.Sb(0,"div"),f.Sb(1,"p"),f.Sb(2,"button",6),f.Yb("click",(function(){f.pc(i);var e=t.$implicit;return f.cc(2).DeleteTVFile(e)})),f.Sb(3,"span"),f.yc(4),f.Rb(),f.Sb(5,"mat-icon"),f.yc(6,"delete"),f.Rb(),f.Rb(),f.yc(7,"\xa0\xa0\xa0 "),f.Sb(8,"button",7),f.Yb("click",(function(){f.pc(i);var e=t.$implicit;return f.cc(2).ShowPut(e)})),f.Sb(9,"span"),f.yc(10,"Show Put"),f.Rb(),f.Rb(),f.yc(11,"\xa0\xa0 "),f.Sb(12,"button",7),f.Yb("click",(function(){f.pc(i);var e=t.$implicit;return f.cc(2).ShowPost(e)})),f.Sb(13,"span"),f.yc(14,"Show Post"),f.Rb(),f.Rb(),f.yc(15,"\xa0\xa0 "),f.xc(16,Re,1,0,"mat-progress-bar",0),f.Rb(),f.xc(17,Fe,2,2,"p",2),f.xc(18,De,2,2,"p",2),f.Sb(19,"blockquote"),f.Sb(20,"p"),f.Sb(21,"span"),f.yc(22),f.Rb(),f.Sb(23,"span"),f.yc(24),f.Rb(),f.Sb(25,"span"),f.yc(26),f.Rb(),f.Sb(27,"span"),f.yc(28),f.Rb(),f.Rb(),f.Sb(29,"p"),f.Sb(30,"span"),f.yc(31),f.Rb(),f.Sb(32,"span"),f.yc(33),f.Rb(),f.Sb(34,"span"),f.yc(35),f.Rb(),f.Sb(36,"span"),f.yc(37),f.Rb(),f.Rb(),f.Sb(38,"p"),f.Sb(39,"span"),f.yc(40),f.Rb(),f.Sb(41,"span"),f.yc(42),f.Rb(),f.Sb(43,"span"),f.yc(44),f.Rb(),f.Sb(45,"span"),f.yc(46),f.Rb(),f.Rb(),f.Sb(47,"p"),f.Sb(48,"span"),f.yc(49),f.Rb(),f.Sb(50,"span"),f.yc(51),f.Rb(),f.Sb(52,"span"),f.yc(53),f.Rb(),f.Sb(54,"span"),f.yc(55),f.Rb(),f.Rb(),f.Sb(56,"p"),f.Sb(57,"span"),f.yc(58),f.Rb(),f.Sb(59,"span"),f.yc(60),f.Rb(),f.Rb(),f.Rb(),f.Rb()}if(2&e){var n=t.$implicit,r=f.cc(2);f.Bb(4),f.Ac("Delete TVFileID [",n.TVFileID,"]\xa0\xa0\xa0"),f.Bb(4),f.hc("color",r.GetPutButtonColor(n)),f.Bb(4),f.hc("color",r.GetPostButtonColor(n)),f.Bb(4),f.hc("ngIf",r.tvfileService.tvfileDeleteModel$.getValue().Working),f.Bb(1),f.hc("ngIf",r.IDToShow===n.TVFileID&&r.showType===r.GetPutEnum()),f.Bb(1),f.hc("ngIf",r.IDToShow===n.TVFileID&&r.showType===r.GetPostEnum()),f.Bb(4),f.Ac("TVFileID: [",n.TVFileID,"]"),f.Bb(2),f.Ac(" --- TVFileTVItemID: [",n.TVFileTVItemID,"]"),f.Bb(2),f.Ac(" --- TemplateTVType: [",r.GetTVTypeEnumText(n.TemplateTVType),"]"),f.Bb(2),f.Ac(" --- ReportTypeID: [",n.ReportTypeID,"]"),f.Bb(3),f.Ac("Parameters: [",n.Parameters,"]"),f.Bb(2),f.Ac(" --- Year: [",n.Year,"]"),f.Bb(2),f.Ac(" --- Language: [",r.GetLanguageEnumText(n.Language),"]"),f.Bb(2),f.Ac(" --- FilePurpose: [",r.GetFilePurposeEnumText(n.FilePurpose),"]"),f.Bb(3),f.Ac("FileType: [",r.GetFileTypeEnumText(n.FileType),"]"),f.Bb(2),f.Ac(" --- FileSize_kb: [",n.FileSize_kb,"]"),f.Bb(2),f.Ac(" --- FileInfo: [",n.FileInfo,"]"),f.Bb(2),f.Ac(" --- FileCreatedDate_UTC: [",n.FileCreatedDate_UTC,"]"),f.Bb(3),f.Ac("FromWater: [",n.FromWater,"]"),f.Bb(2),f.Ac(" --- ClientFilePath: [",n.ClientFilePath,"]"),f.Bb(2),f.Ac(" --- ServerFileName: [",n.ServerFileName,"]"),f.Bb(2),f.Ac(" --- ServerFilePath: [",n.ServerFilePath,"]"),f.Bb(3),f.Ac("LastUpdateDate_UTC: [",n.LastUpdateDate_UTC,"]"),f.Bb(2),f.Ac(" --- LastUpdateContactTVItemID: [",n.LastUpdateContactTVItemID,"]")}}function xe(e,t){if(1&e&&(f.Sb(0,"div"),f.xc(1,ge,61,24,"div",5),f.Rb()),2&e){var i=f.cc();f.Bb(1),f.hc("ngForOf",i.tvfileService.tvfileListModel$.getValue())}}var Ee,Ce,Be,Pe=[{path:"",component:(Ee=function(){function t(i,n,r){e(this,t),this.tvfileService=i,this.router=n,this.httpClientService=r,this.showType=null,r.oldURL=n.url}return i(t,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.TVFileID&&this.showType===p.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.TVFileID&&this.showType===p.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.TVFileID&&this.showType===p.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.TVFileID,this.showType=p.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.TVFileID&&this.showType===p.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.TVFileID,this.showType=p.a.Post)}},{key:"GetPutEnum",value:function(){return p.a.Put}},{key:"GetPostEnum",value:function(){return p.a.Post}},{key:"GetTVFileList",value:function(){this.sub=this.tvfileService.GetTVFileList().subscribe()}},{key:"DeleteTVFile",value:function(e){this.sub=this.tvfileService.DeleteTVFile(e).subscribe()}},{key:"GetTVTypeEnumText",value:function(e){return Object(l.a)(e)}},{key:"GetLanguageEnumText",value:function(e){return Object(c.a)(e)}},{key:"GetFilePurposeEnumText",value:function(e){return function(e){var t;return u().forEach((function(i){if(i.EnumID==e)return t=i.EnumText,!1})),t}(e)}},{key:"GetFileTypeEnumText",value:function(e){return Object(m.a)(e)}},{key:"ngOnInit",value:function(){o(this.tvfileService.tvfileTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),t}(),Ee.\u0275fac=function(e){return new(e||Ee)(f.Mb(y),f.Mb(b.b),f.Mb(I.a))},Ee.\u0275cmp=f.Gb({type:Ee,selectors:[["app-tvfile"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tvfile","httpClientCommand"]],template:function(e,t){var i,n;1&e&&(f.xc(0,ye,1,0,"mat-progress-bar",0),f.Sb(1,"mat-card"),f.Sb(2,"mat-card-header"),f.Sb(3,"mat-card-title"),f.yc(4," TVFile works! "),f.Sb(5,"button",1),f.Yb("click",(function(){return t.GetTVFileList()})),f.Sb(6,"span"),f.yc(7,"Get TVFile"),f.Rb(),f.Rb(),f.Rb(),f.Sb(8,"mat-card-subtitle"),f.yc(9),f.Rb(),f.Rb(),f.Sb(10,"mat-card-content"),f.xc(11,xe,2,1,"div",2),f.Rb(),f.Sb(12,"mat-card-actions"),f.Sb(13,"button",3),f.yc(14,"Allo"),f.Rb(),f.Rb(),f.Rb()),2&e&&(f.hc("ngIf",null==(i=t.tvfileService.tvfileGetModel$.getValue())?null:i.Working),f.Bb(9),f.zc(t.tvfileService.tvfileTextModel$.getValue().Title),f.Bb(2),f.hc("ngIf",null==(n=t.tvfileService.tvfileListModel$.getValue())?null:n.length))},directives:[a.l,R.a,R.d,R.g,F.b,R.f,R.c,R.b,D.a,a.k,g.a,Ie],styles:[""],changeDetection:0}),Ee),canActivate:[r("auXs").a]}],Ne=((Ce=function t(){e(this,t)}).\u0275mod=f.Kb({type:Ce}),Ce.\u0275inj=f.Jb({factory:function(e){return new(e||Ce)},imports:[[b.e.forChild(Pe)],b.e]}),Ce),Ve=r("B+Mi"),Me=((Be=function t(){e(this,t)}).\u0275mod=f.Kb({type:Be}),Be.\u0275inj=f.Jb({factory:function(e){return new(e||Be)},imports:[[a.c,b.e,Ne,Ve.a,x.g,x.o]]}),Be)}}])}();