!function(){function t(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function e(t,e){for(var n=0;n<e.length;n++){var a=e[n];a.enumerable=a.enumerable||!1,a.configurable=!0,"value"in a&&(a.writable=!0),Object.defineProperty(t,a.key,a)}}function n(t,n,a){return n&&e(t.prototype,n),a&&e(t,a),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[80],{QRvi:function(t,e,n){"use strict";n.d(e,"a",(function(){return a}));var a=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},"d+8X":function(e,a,i){"use strict";i.r(a),i.d(a,"SamplingPlanModule",(function(){return Kt}));var r=i("ofXK"),l=i("tyNb");function o(t){var e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var b,c=i("KyBE"),p=i("V1px"),s=i("OG+2"),m=i("7HY/"),u=i("jE9Z"),f=i("tWIn"),S=i("QRvi"),g=i("fXoL"),d=i("2Vo4"),h=i("LRne"),y=i("tk/3"),R=i("lJxs"),I=i("JIr8"),v=i("gkM4"),B=((b=function(){function e(n,a){t(this,e),this.httpClient=n,this.httpClientService=a,this.samplingplanTextModel$=new d.a({}),this.samplingplanListModel$=new d.a({}),this.samplingplanGetModel$=new d.a({}),this.samplingplanPutModel$=new d.a({}),this.samplingplanPostModel$=new d.a({}),this.samplingplanDeleteModel$=new d.a({}),o(this.samplingplanTextModel$),this.samplingplanTextModel$.next({Title:"Something2 for text"})}return n(e,[{key:"GetSamplingPlanList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.samplingplanGetModel$),this.httpClient.get("/api/SamplingPlan").pipe(Object(R.a)((function(e){t.httpClientService.DoSuccess(t.samplingplanListModel$,t.samplingplanGetModel$,e,S.a.Get,null)})),Object(I.a)((function(e){return Object(h.a)(e).pipe(Object(R.a)((function(e){t.httpClientService.DoCatchError(t.samplingplanListModel$,t.samplingplanGetModel$,e)})))})))}},{key:"PutSamplingPlan",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.samplingplanPutModel$),this.httpClient.put("/api/SamplingPlan",t,{headers:new y.d}).pipe(Object(R.a)((function(n){e.httpClientService.DoSuccess(e.samplingplanListModel$,e.samplingplanPutModel$,n,S.a.Put,t)})),Object(I.a)((function(t){return Object(h.a)(t).pipe(Object(R.a)((function(t){e.httpClientService.DoCatchError(e.samplingplanListModel$,e.samplingplanPutModel$,t)})))})))}},{key:"PostSamplingPlan",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.samplingplanPostModel$),this.httpClient.post("/api/SamplingPlan",t,{headers:new y.d}).pipe(Object(R.a)((function(n){e.httpClientService.DoSuccess(e.samplingplanListModel$,e.samplingplanPostModel$,n,S.a.Post,t)})),Object(I.a)((function(t){return Object(h.a)(t).pipe(Object(R.a)((function(t){e.httpClientService.DoCatchError(e.samplingplanListModel$,e.samplingplanPostModel$,t)})))})))}},{key:"DeleteSamplingPlan",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.samplingplanDeleteModel$),this.httpClient.delete("/api/SamplingPlan/"+t.SamplingPlanID).pipe(Object(R.a)((function(n){e.httpClientService.DoSuccess(e.samplingplanListModel$,e.samplingplanDeleteModel$,n,S.a.Delete,t)})),Object(I.a)((function(t){return Object(h.a)(t).pipe(Object(R.a)((function(t){e.httpClientService.DoCatchError(e.samplingplanListModel$,e.samplingplanDeleteModel$,t)})))})))}}]),e}()).\u0275fac=function(t){return new(t||b)(g.Wb(y.b),g.Wb(v.a))},b.\u0275prov=g.Ib({token:b,factory:b.\u0275fac,providedIn:"root"}),b),D=i("Wp6s"),P=i("bTqV"),C=i("bv9b"),z=i("NFeN"),T=i("3Pt+"),N=i("kmnG"),L=i("qFsG"),x=i("d3UM"),M=i("FKr1");function k(t,e){1&t&&g.Nb(0,"mat-progress-bar",27)}function E(t,e){1&t&&g.Nb(0,"mat-progress-bar",27)}function $(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function A(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,$,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}function q(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function F(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,q,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}function G(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function j(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"MaxLength - 200"),g.Nb(2,"br"),g.Rb())}function w(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,G,3,0,"span",4),g.yc(6,j,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,3,n)),g.Bb(3),g.ic("ngIf",n.required),g.Bb(1),g.ic("ngIf",n.maxlength)}}function O(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function V(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"MaxLength - 100"),g.Nb(2,"br"),g.Rb())}function U(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,O,3,0,"span",4),g.yc(6,V,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,3,n)),g.Bb(3),g.ic("ngIf",n.required),g.Bb(1),g.ic("ngIf",n.maxlength)}}function Q(t,e){if(1&t&&(g.Sb(0,"mat-option",28),g.zc(1),g.Rb()),2&t){var n=e.$implicit;g.ic("value",n.EnumID),g.Bb(1),g.Bc(" ",n.EnumText," ")}}function W(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function Y(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,W,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}function _(t,e){if(1&t&&(g.Sb(0,"mat-option",28),g.zc(1),g.Rb()),2&t){var n=e.$implicit;g.ic("value",n.EnumID),g.Bb(1),g.Bc(" ",n.EnumText," ")}}function H(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function J(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,H,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}function Z(t,e){if(1&t&&(g.Sb(0,"mat-option",28),g.zc(1),g.Rb()),2&t){var n=e.$implicit;g.ic("value",n.EnumID),g.Bb(1),g.Bc(" ",n.EnumText," ")}}function K(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function X(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,K,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}function tt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function et(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,tt,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}function nt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function at(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,nt,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}function it(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function rt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Min - 2000"),g.Nb(2,"br"),g.Rb())}function lt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Max - 2050"),g.Nb(2,"br"),g.Rb())}function ot(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,it,3,0,"span",4),g.yc(6,rt,3,0,"span",4),g.yc(7,lt,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,4,n)),g.Bb(3),g.ic("ngIf",n.required),g.Bb(1),g.ic("ngIf",n.min),g.Bb(1),g.ic("ngIf",n.min)}}function bt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function ct(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"MaxLength - 15"),g.Nb(2,"br"),g.Rb())}function pt(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,bt,3,0,"span",4),g.yc(6,ct,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,3,n)),g.Bb(3),g.ic("ngIf",n.required),g.Bb(1),g.ic("ngIf",n.maxlength)}}function st(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function mt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Min - 0"),g.Nb(2,"br"),g.Rb())}function ut(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Max - 100"),g.Nb(2,"br"),g.Rb())}function ft(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,st,3,0,"span",4),g.yc(6,mt,3,0,"span",4),g.yc(7,ut,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,4,n)),g.Bb(3),g.ic("ngIf",n.required),g.Bb(1),g.ic("ngIf",n.min),g.Bb(1),g.ic("ngIf",n.min)}}function St(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function gt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Min - 0"),g.Nb(2,"br"),g.Rb())}function dt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Max - 100"),g.Nb(2,"br"),g.Rb())}function ht(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,St,3,0,"span",4),g.yc(6,gt,3,0,"span",4),g.yc(7,dt,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,4,n)),g.Bb(3),g.ic("ngIf",n.required),g.Bb(1),g.ic("ngIf",n.min),g.Bb(1),g.ic("ngIf",n.min)}}function yt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function Rt(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,yt,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}function It(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function vt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"MaxLength - 15"),g.Nb(2,"br"),g.Rb())}function Bt(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,It,3,0,"span",4),g.yc(6,vt,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,3,n)),g.Bb(3),g.ic("ngIf",n.required),g.Bb(1),g.ic("ngIf",n.maxlength)}}function Dt(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,1,n))}}function Pt(t,e){if(1&t&&(g.Sb(0,"mat-option",28),g.zc(1),g.Rb()),2&t){var n=e.$implicit;g.ic("value",n.EnumID),g.Bb(1),g.Bc(" ",n.EnumText," ")}}function Ct(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,1,n))}}function zt(t,e){if(1&t&&(g.Sb(0,"mat-option",28),g.zc(1),g.Rb()),2&t){var n=e.$implicit;g.ic("value",n.EnumID),g.Bb(1),g.Bc(" ",n.EnumText," ")}}function Tt(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,1,n))}}function Nt(t,e){if(1&t&&(g.Sb(0,"mat-option",28),g.zc(1),g.Rb()),2&t){var n=e.$implicit;g.ic("value",n.EnumID),g.Bb(1),g.Bc(" ",n.EnumText," ")}}function Lt(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,1,n))}}function xt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function Mt(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"MaxLength - 250"),g.Nb(2,"br"),g.Rb())}function kt(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,xt,3,0,"span",4),g.yc(6,Mt,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,3,n)),g.Bb(3),g.ic("ngIf",n.required),g.Bb(1),g.ic("ngIf",n.maxlength)}}function Et(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function $t(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,Et,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}function At(t,e){1&t&&(g.Sb(0,"span"),g.zc(1,"Is Required"),g.Nb(2,"br"),g.Rb())}function qt(t,e){if(1&t&&(g.Sb(0,"mat-error"),g.Sb(1,"span"),g.zc(2),g.ec(3,"json"),g.Nb(4,"br"),g.Rb(),g.yc(5,At,3,0,"span",4),g.Rb()),2&t){var n=e.$implicit;g.Bb(2),g.Ac(g.fc(3,2,n)),g.Bb(3),g.ic("ngIf",n.required)}}var Ft,Gt=((Ft=function(){function e(n,a){t(this,e),this.samplingplanService=n,this.fb=a,this.samplingplan=null,this.httpClientCommand=S.a.Put}return n(e,[{key:"GetPut",value:function(){return this.httpClientCommand==S.a.Put}},{key:"PutSamplingPlan",value:function(t){this.sub=this.samplingplanService.PutSamplingPlan(t).subscribe()}},{key:"PostSamplingPlan",value:function(t){this.sub=this.samplingplanService.PostSamplingPlan(t).subscribe()}},{key:"ngOnInit",value:function(){this.sampleTypeList=Object(c.b)(),this.samplingPlanTypeList=Object(p.b)(),this.labSheetTypeList=Object(s.b)(),this.analyzeMethodDefaultList=Object(m.b)(),this.sampleMatrixDefaultList=Object(u.b)(),this.laboratoryDefaultList=Object(f.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.samplingplan){var e=this.fb.group({SamplingPlanID:[{value:t===S.a.Post?0:this.samplingplan.SamplingPlanID,disabled:!1},[T.p.required]],IsActive:[{value:this.samplingplan.IsActive,disabled:!1},[T.p.required]],SamplingPlanName:[{value:this.samplingplan.SamplingPlanName,disabled:!1},[T.p.required,T.p.maxLength(200)]],ForGroupName:[{value:this.samplingplan.ForGroupName,disabled:!1},[T.p.required,T.p.maxLength(100)]],SampleType:[{value:this.samplingplan.SampleType,disabled:!1},[T.p.required]],SamplingPlanType:[{value:this.samplingplan.SamplingPlanType,disabled:!1},[T.p.required]],LabSheetType:[{value:this.samplingplan.LabSheetType,disabled:!1},[T.p.required]],ProvinceTVItemID:[{value:this.samplingplan.ProvinceTVItemID,disabled:!1},[T.p.required]],CreatorTVItemID:[{value:this.samplingplan.CreatorTVItemID,disabled:!1},[T.p.required]],Year:[{value:this.samplingplan.Year,disabled:!1},[T.p.required,T.p.min(2e3),T.p.max(2050)]],AccessCode:[{value:this.samplingplan.AccessCode,disabled:!1},[T.p.required,T.p.maxLength(15)]],DailyDuplicatePrecisionCriteria:[{value:this.samplingplan.DailyDuplicatePrecisionCriteria,disabled:!1},[T.p.required,T.p.min(0),T.p.max(100)]],IntertechDuplicatePrecisionCriteria:[{value:this.samplingplan.IntertechDuplicatePrecisionCriteria,disabled:!1},[T.p.required,T.p.min(0),T.p.max(100)]],IncludeLaboratoryQAQC:[{value:this.samplingplan.IncludeLaboratoryQAQC,disabled:!1},[T.p.required]],ApprovalCode:[{value:this.samplingplan.ApprovalCode,disabled:!1},[T.p.required,T.p.maxLength(15)]],SamplingPlanFileTVItemID:[{value:this.samplingplan.SamplingPlanFileTVItemID,disabled:!1}],AnalyzeMethodDefault:[{value:this.samplingplan.AnalyzeMethodDefault,disabled:!1}],SampleMatrixDefault:[{value:this.samplingplan.SampleMatrixDefault,disabled:!1}],LaboratoryDefault:[{value:this.samplingplan.LaboratoryDefault,disabled:!1}],BackupDirectory:[{value:this.samplingplan.BackupDirectory,disabled:!1},[T.p.required,T.p.maxLength(250)]],LastUpdateDate_UTC:[{value:this.samplingplan.LastUpdateDate_UTC,disabled:!1},[T.p.required]],LastUpdateContactTVItemID:[{value:this.samplingplan.LastUpdateContactTVItemID,disabled:!1},[T.p.required]]});this.samplingplanFormEdit=e}}}]),e}()).\u0275fac=function(t){return new(t||Ft)(g.Mb(B),g.Mb(T.d))},Ft.\u0275cmp=g.Gb({type:Ft,selectors:[["app-samplingplan-edit"]],inputs:{samplingplan:"samplingplan",httpClientCommand:"httpClientCommand"},decls:130,vars:32,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","SamplingPlanID"],[4,"ngIf"],["matInput","","type","text","formControlName","IsActive"],["matInput","","type","text","formControlName","SamplingPlanName"],["matInput","","type","text","formControlName","ForGroupName"],["formControlName","SampleType"],[3,"value",4,"ngFor","ngForOf"],["formControlName","SamplingPlanType"],["formControlName","LabSheetType"],["matInput","","type","number","formControlName","ProvinceTVItemID"],["matInput","","type","number","formControlName","CreatorTVItemID"],["matInput","","type","number","formControlName","Year"],["matInput","","type","text","formControlName","AccessCode"],["matInput","","type","number","formControlName","DailyDuplicatePrecisionCriteria"],["matInput","","type","number","formControlName","IntertechDuplicatePrecisionCriteria"],["matInput","","type","text","formControlName","IncludeLaboratoryQAQC"],["matInput","","type","text","formControlName","ApprovalCode"],["matInput","","type","number","formControlName","SamplingPlanFileTVItemID"],["formControlName","AnalyzeMethodDefault"],["formControlName","SampleMatrixDefault"],["formControlName","LaboratoryDefault"],["matInput","","type","text","formControlName","BackupDirectory"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(g.Sb(0,"form",0),g.Zb("ngSubmit",(function(){return e.GetPut()?e.PutSamplingPlan(e.samplingplanFormEdit.value):e.PostSamplingPlan(e.samplingplanFormEdit.value)})),g.Sb(1,"h3"),g.zc(2," SamplingPlan "),g.Sb(3,"button",1),g.Sb(4,"span"),g.zc(5),g.Rb(),g.Rb(),g.yc(6,k,1,0,"mat-progress-bar",2),g.yc(7,E,1,0,"mat-progress-bar",2),g.Rb(),g.Sb(8,"p"),g.Sb(9,"mat-form-field"),g.Sb(10,"mat-label"),g.zc(11,"SamplingPlanID"),g.Rb(),g.Nb(12,"input",3),g.yc(13,A,6,4,"mat-error",4),g.Rb(),g.Sb(14,"mat-form-field"),g.Sb(15,"mat-label"),g.zc(16,"IsActive"),g.Rb(),g.Nb(17,"input",5),g.yc(18,F,6,4,"mat-error",4),g.Rb(),g.Sb(19,"mat-form-field"),g.Sb(20,"mat-label"),g.zc(21,"SamplingPlanName"),g.Rb(),g.Nb(22,"input",6),g.yc(23,w,7,5,"mat-error",4),g.Rb(),g.Sb(24,"mat-form-field"),g.Sb(25,"mat-label"),g.zc(26,"ForGroupName"),g.Rb(),g.Nb(27,"input",7),g.yc(28,U,7,5,"mat-error",4),g.Rb(),g.Rb(),g.Sb(29,"p"),g.Sb(30,"mat-form-field"),g.Sb(31,"mat-label"),g.zc(32,"SampleType"),g.Rb(),g.Sb(33,"mat-select",8),g.yc(34,Q,2,2,"mat-option",9),g.Rb(),g.yc(35,Y,6,4,"mat-error",4),g.Rb(),g.Sb(36,"mat-form-field"),g.Sb(37,"mat-label"),g.zc(38,"SamplingPlanType"),g.Rb(),g.Sb(39,"mat-select",10),g.yc(40,_,2,2,"mat-option",9),g.Rb(),g.yc(41,J,6,4,"mat-error",4),g.Rb(),g.Sb(42,"mat-form-field"),g.Sb(43,"mat-label"),g.zc(44,"LabSheetType"),g.Rb(),g.Sb(45,"mat-select",11),g.yc(46,Z,2,2,"mat-option",9),g.Rb(),g.yc(47,X,6,4,"mat-error",4),g.Rb(),g.Sb(48,"mat-form-field"),g.Sb(49,"mat-label"),g.zc(50,"ProvinceTVItemID"),g.Rb(),g.Nb(51,"input",12),g.yc(52,et,6,4,"mat-error",4),g.Rb(),g.Rb(),g.Sb(53,"p"),g.Sb(54,"mat-form-field"),g.Sb(55,"mat-label"),g.zc(56,"CreatorTVItemID"),g.Rb(),g.Nb(57,"input",13),g.yc(58,at,6,4,"mat-error",4),g.Rb(),g.Sb(59,"mat-form-field"),g.Sb(60,"mat-label"),g.zc(61,"Year"),g.Rb(),g.Nb(62,"input",14),g.yc(63,ot,8,6,"mat-error",4),g.Rb(),g.Sb(64,"mat-form-field"),g.Sb(65,"mat-label"),g.zc(66,"AccessCode"),g.Rb(),g.Nb(67,"input",15),g.yc(68,pt,7,5,"mat-error",4),g.Rb(),g.Sb(69,"mat-form-field"),g.Sb(70,"mat-label"),g.zc(71,"DailyDuplicatePrecisionCriteria"),g.Rb(),g.Nb(72,"input",16),g.yc(73,ft,8,6,"mat-error",4),g.Rb(),g.Rb(),g.Sb(74,"p"),g.Sb(75,"mat-form-field"),g.Sb(76,"mat-label"),g.zc(77,"IntertechDuplicatePrecisionCriteria"),g.Rb(),g.Nb(78,"input",17),g.yc(79,ht,8,6,"mat-error",4),g.Rb(),g.Sb(80,"mat-form-field"),g.Sb(81,"mat-label"),g.zc(82,"IncludeLaboratoryQAQC"),g.Rb(),g.Nb(83,"input",18),g.yc(84,Rt,6,4,"mat-error",4),g.Rb(),g.Sb(85,"mat-form-field"),g.Sb(86,"mat-label"),g.zc(87,"ApprovalCode"),g.Rb(),g.Nb(88,"input",19),g.yc(89,Bt,7,5,"mat-error",4),g.Rb(),g.Sb(90,"mat-form-field"),g.Sb(91,"mat-label"),g.zc(92,"SamplingPlanFileTVItemID"),g.Rb(),g.Nb(93,"input",20),g.yc(94,Dt,5,3,"mat-error",4),g.Rb(),g.Rb(),g.Sb(95,"p"),g.Sb(96,"mat-form-field"),g.Sb(97,"mat-label"),g.zc(98,"AnalyzeMethodDefault"),g.Rb(),g.Sb(99,"mat-select",21),g.yc(100,Pt,2,2,"mat-option",9),g.Rb(),g.yc(101,Ct,5,3,"mat-error",4),g.Rb(),g.Sb(102,"mat-form-field"),g.Sb(103,"mat-label"),g.zc(104,"SampleMatrixDefault"),g.Rb(),g.Sb(105,"mat-select",22),g.yc(106,zt,2,2,"mat-option",9),g.Rb(),g.yc(107,Tt,5,3,"mat-error",4),g.Rb(),g.Sb(108,"mat-form-field"),g.Sb(109,"mat-label"),g.zc(110,"LaboratoryDefault"),g.Rb(),g.Sb(111,"mat-select",23),g.yc(112,Nt,2,2,"mat-option",9),g.Rb(),g.yc(113,Lt,5,3,"mat-error",4),g.Rb(),g.Sb(114,"mat-form-field"),g.Sb(115,"mat-label"),g.zc(116,"BackupDirectory"),g.Rb(),g.Nb(117,"input",24),g.yc(118,kt,7,5,"mat-error",4),g.Rb(),g.Rb(),g.Sb(119,"p"),g.Sb(120,"mat-form-field"),g.Sb(121,"mat-label"),g.zc(122,"LastUpdateDate_UTC"),g.Rb(),g.Nb(123,"input",25),g.yc(124,$t,6,4,"mat-error",4),g.Rb(),g.Sb(125,"mat-form-field"),g.Sb(126,"mat-label"),g.zc(127,"LastUpdateContactTVItemID"),g.Rb(),g.Nb(128,"input",26),g.yc(129,qt,6,4,"mat-error",4),g.Rb(),g.Rb(),g.Rb()),2&t&&(g.ic("formGroup",e.samplingplanFormEdit),g.Bb(5),g.Bc("",e.GetPut()?"Put":"Post"," SamplingPlan"),g.Bb(1),g.ic("ngIf",e.samplingplanService.samplingplanPutModel$.getValue().Working),g.Bb(1),g.ic("ngIf",e.samplingplanService.samplingplanPostModel$.getValue().Working),g.Bb(6),g.ic("ngIf",e.samplingplanFormEdit.controls.SamplingPlanID.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.IsActive.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.SamplingPlanName.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.ForGroupName.errors),g.Bb(6),g.ic("ngForOf",e.sampleTypeList),g.Bb(1),g.ic("ngIf",e.samplingplanFormEdit.controls.SampleType.errors),g.Bb(5),g.ic("ngForOf",e.samplingPlanTypeList),g.Bb(1),g.ic("ngIf",e.samplingplanFormEdit.controls.SamplingPlanType.errors),g.Bb(5),g.ic("ngForOf",e.labSheetTypeList),g.Bb(1),g.ic("ngIf",e.samplingplanFormEdit.controls.LabSheetType.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.ProvinceTVItemID.errors),g.Bb(6),g.ic("ngIf",e.samplingplanFormEdit.controls.CreatorTVItemID.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.Year.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.AccessCode.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.DailyDuplicatePrecisionCriteria.errors),g.Bb(6),g.ic("ngIf",e.samplingplanFormEdit.controls.IntertechDuplicatePrecisionCriteria.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.IncludeLaboratoryQAQC.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.ApprovalCode.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.SamplingPlanFileTVItemID.errors),g.Bb(6),g.ic("ngForOf",e.analyzeMethodDefaultList),g.Bb(1),g.ic("ngIf",e.samplingplanFormEdit.controls.AnalyzeMethodDefault.errors),g.Bb(5),g.ic("ngForOf",e.sampleMatrixDefaultList),g.Bb(1),g.ic("ngIf",e.samplingplanFormEdit.controls.SampleMatrixDefault.errors),g.Bb(5),g.ic("ngForOf",e.laboratoryDefaultList),g.Bb(1),g.ic("ngIf",e.samplingplanFormEdit.controls.LaboratoryDefault.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.BackupDirectory.errors),g.Bb(6),g.ic("ngIf",e.samplingplanFormEdit.controls.LastUpdateDate_UTC.errors),g.Bb(5),g.ic("ngIf",e.samplingplanFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[T.q,T.l,T.f,P.b,r.l,N.c,N.f,L.b,T.n,T.c,T.k,T.e,x.a,r.k,C.a,N.b,M.n],pipes:[r.f],styles:[""],changeDetection:0}),Ft);function jt(t,e){1&t&&g.Nb(0,"mat-progress-bar",4)}function wt(t,e){1&t&&g.Nb(0,"mat-progress-bar",4)}function Ot(t,e){if(1&t&&(g.Sb(0,"p"),g.Nb(1,"app-samplingplan-edit",8),g.Rb()),2&t){var n=g.dc().$implicit,a=g.dc(2);g.Bb(1),g.ic("samplingplan",n)("httpClientCommand",a.GetPutEnum())}}function Vt(t,e){if(1&t&&(g.Sb(0,"p"),g.Nb(1,"app-samplingplan-edit",8),g.Rb()),2&t){var n=g.dc().$implicit,a=g.dc(2);g.Bb(1),g.ic("samplingplan",n)("httpClientCommand",a.GetPostEnum())}}function Ut(t,e){if(1&t){var n=g.Tb();g.Sb(0,"div"),g.Sb(1,"p"),g.Sb(2,"button",6),g.Zb("click",(function(){g.qc(n);var t=e.$implicit;return g.dc(2).DeleteSamplingPlan(t)})),g.Sb(3,"span"),g.zc(4),g.Rb(),g.Sb(5,"mat-icon"),g.zc(6,"delete"),g.Rb(),g.Rb(),g.zc(7,"\xa0\xa0\xa0 "),g.Sb(8,"button",7),g.Zb("click",(function(){g.qc(n);var t=e.$implicit;return g.dc(2).ShowPut(t)})),g.Sb(9,"span"),g.zc(10,"Show Put"),g.Rb(),g.Rb(),g.zc(11,"\xa0\xa0 "),g.Sb(12,"button",7),g.Zb("click",(function(){g.qc(n);var t=e.$implicit;return g.dc(2).ShowPost(t)})),g.Sb(13,"span"),g.zc(14,"Show Post"),g.Rb(),g.Rb(),g.zc(15,"\xa0\xa0 "),g.yc(16,wt,1,0,"mat-progress-bar",0),g.Rb(),g.yc(17,Ot,2,2,"p",2),g.yc(18,Vt,2,2,"p",2),g.Sb(19,"blockquote"),g.Sb(20,"p"),g.Sb(21,"span"),g.zc(22),g.Rb(),g.Sb(23,"span"),g.zc(24),g.Rb(),g.Sb(25,"span"),g.zc(26),g.Rb(),g.Sb(27,"span"),g.zc(28),g.Rb(),g.Rb(),g.Sb(29,"p"),g.Sb(30,"span"),g.zc(31),g.Rb(),g.Sb(32,"span"),g.zc(33),g.Rb(),g.Sb(34,"span"),g.zc(35),g.Rb(),g.Sb(36,"span"),g.zc(37),g.Rb(),g.Rb(),g.Sb(38,"p"),g.Sb(39,"span"),g.zc(40),g.Rb(),g.Sb(41,"span"),g.zc(42),g.Rb(),g.Sb(43,"span"),g.zc(44),g.Rb(),g.Sb(45,"span"),g.zc(46),g.Rb(),g.Rb(),g.Sb(47,"p"),g.Sb(48,"span"),g.zc(49),g.Rb(),g.Sb(50,"span"),g.zc(51),g.Rb(),g.Sb(52,"span"),g.zc(53),g.Rb(),g.Sb(54,"span"),g.zc(55),g.Rb(),g.Rb(),g.Sb(56,"p"),g.Sb(57,"span"),g.zc(58),g.Rb(),g.Sb(59,"span"),g.zc(60),g.Rb(),g.Sb(61,"span"),g.zc(62),g.Rb(),g.Sb(63,"span"),g.zc(64),g.Rb(),g.Rb(),g.Sb(65,"p"),g.Sb(66,"span"),g.zc(67),g.Rb(),g.Sb(68,"span"),g.zc(69),g.Rb(),g.Rb(),g.Rb(),g.Rb()}if(2&t){var a=e.$implicit,i=g.dc(2);g.Bb(4),g.Bc("Delete SamplingPlanID [",a.SamplingPlanID,"]\xa0\xa0\xa0"),g.Bb(4),g.ic("color",i.GetPutButtonColor(a)),g.Bb(4),g.ic("color",i.GetPostButtonColor(a)),g.Bb(4),g.ic("ngIf",i.samplingplanService.samplingplanDeleteModel$.getValue().Working),g.Bb(1),g.ic("ngIf",i.IDToShow===a.SamplingPlanID&&i.showType===i.GetPutEnum()),g.Bb(1),g.ic("ngIf",i.IDToShow===a.SamplingPlanID&&i.showType===i.GetPostEnum()),g.Bb(4),g.Bc("SamplingPlanID: [",a.SamplingPlanID,"]"),g.Bb(2),g.Bc(" --- IsActive: [",a.IsActive,"]"),g.Bb(2),g.Bc(" --- SamplingPlanName: [",a.SamplingPlanName,"]"),g.Bb(2),g.Bc(" --- ForGroupName: [",a.ForGroupName,"]"),g.Bb(3),g.Bc("SampleType: [",i.GetSampleTypeEnumText(a.SampleType),"]"),g.Bb(2),g.Bc(" --- SamplingPlanType: [",i.GetSamplingPlanTypeEnumText(a.SamplingPlanType),"]"),g.Bb(2),g.Bc(" --- LabSheetType: [",i.GetLabSheetTypeEnumText(a.LabSheetType),"]"),g.Bb(2),g.Bc(" --- ProvinceTVItemID: [",a.ProvinceTVItemID,"]"),g.Bb(3),g.Bc("CreatorTVItemID: [",a.CreatorTVItemID,"]"),g.Bb(2),g.Bc(" --- Year: [",a.Year,"]"),g.Bb(2),g.Bc(" --- AccessCode: [",a.AccessCode,"]"),g.Bb(2),g.Bc(" --- DailyDuplicatePrecisionCriteria: [",a.DailyDuplicatePrecisionCriteria,"]"),g.Bb(3),g.Bc("IntertechDuplicatePrecisionCriteria: [",a.IntertechDuplicatePrecisionCriteria,"]"),g.Bb(2),g.Bc(" --- IncludeLaboratoryQAQC: [",a.IncludeLaboratoryQAQC,"]"),g.Bb(2),g.Bc(" --- ApprovalCode: [",a.ApprovalCode,"]"),g.Bb(2),g.Bc(" --- SamplingPlanFileTVItemID: [",a.SamplingPlanFileTVItemID,"]"),g.Bb(3),g.Bc("AnalyzeMethodDefault: [",i.GetAnalyzeMethodEnumText(a.AnalyzeMethodDefault),"]"),g.Bb(2),g.Bc(" --- SampleMatrixDefault: [",i.GetSampleMatrixEnumText(a.SampleMatrixDefault),"]"),g.Bb(2),g.Bc(" --- LaboratoryDefault: [",i.GetLaboratoryEnumText(a.LaboratoryDefault),"]"),g.Bb(2),g.Bc(" --- BackupDirectory: [",a.BackupDirectory,"]"),g.Bb(3),g.Bc("LastUpdateDate_UTC: [",a.LastUpdateDate_UTC,"]"),g.Bb(2),g.Bc(" --- LastUpdateContactTVItemID: [",a.LastUpdateContactTVItemID,"]")}}function Qt(t,e){if(1&t&&(g.Sb(0,"div"),g.yc(1,Ut,70,28,"div",5),g.Rb()),2&t){var n=g.dc();g.Bb(1),g.ic("ngForOf",n.samplingplanService.samplingplanListModel$.getValue())}}var Wt,Yt,_t,Ht=[{path:"",component:(Wt=function(){function e(n,a,i){t(this,e),this.samplingplanService=n,this.router=a,this.httpClientService=i,this.showType=null,i.oldURL=a.url}return n(e,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.SamplingPlanID&&this.showType===S.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.SamplingPlanID&&this.showType===S.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.SamplingPlanID&&this.showType===S.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.SamplingPlanID,this.showType=S.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.SamplingPlanID&&this.showType===S.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.SamplingPlanID,this.showType=S.a.Post)}},{key:"GetPutEnum",value:function(){return S.a.Put}},{key:"GetPostEnum",value:function(){return S.a.Post}},{key:"GetSamplingPlanList",value:function(){this.sub=this.samplingplanService.GetSamplingPlanList().subscribe()}},{key:"DeleteSamplingPlan",value:function(t){this.sub=this.samplingplanService.DeleteSamplingPlan(t).subscribe()}},{key:"GetSampleTypeEnumText",value:function(t){return Object(c.a)(t)}},{key:"GetSamplingPlanTypeEnumText",value:function(t){return Object(p.a)(t)}},{key:"GetLabSheetTypeEnumText",value:function(t){return Object(s.a)(t)}},{key:"GetAnalyzeMethodEnumText",value:function(t){return Object(m.a)(t)}},{key:"GetSampleMatrixEnumText",value:function(t){return Object(u.a)(t)}},{key:"GetLaboratoryEnumText",value:function(t){return Object(f.a)(t)}},{key:"ngOnInit",value:function(){o(this.samplingplanService.samplingplanTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),e}(),Wt.\u0275fac=function(t){return new(t||Wt)(g.Mb(B),g.Mb(l.b),g.Mb(v.a))},Wt.\u0275cmp=g.Gb({type:Wt,selectors:[["app-samplingplan"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"samplingplan","httpClientCommand"]],template:function(t,e){var n,a;1&t&&(g.yc(0,jt,1,0,"mat-progress-bar",0),g.Sb(1,"mat-card"),g.Sb(2,"mat-card-header"),g.Sb(3,"mat-card-title"),g.zc(4," SamplingPlan works! "),g.Sb(5,"button",1),g.Zb("click",(function(){return e.GetSamplingPlanList()})),g.Sb(6,"span"),g.zc(7,"Get SamplingPlan"),g.Rb(),g.Rb(),g.Rb(),g.Sb(8,"mat-card-subtitle"),g.zc(9),g.Rb(),g.Rb(),g.Sb(10,"mat-card-content"),g.yc(11,Qt,2,1,"div",2),g.Rb(),g.Sb(12,"mat-card-actions"),g.Sb(13,"button",3),g.zc(14,"Allo"),g.Rb(),g.Rb(),g.Rb()),2&t&&(g.ic("ngIf",null==(n=e.samplingplanService.samplingplanGetModel$.getValue())?null:n.Working),g.Bb(9),g.Ac(e.samplingplanService.samplingplanTextModel$.getValue().Title),g.Bb(2),g.ic("ngIf",null==(a=e.samplingplanService.samplingplanListModel$.getValue())?null:a.length))},directives:[r.l,D.a,D.d,D.g,P.b,D.f,D.c,D.b,C.a,r.k,z.a,Gt],styles:[""],changeDetection:0}),Wt),canActivate:[i("auXs").a]}],Jt=((Yt=function e(){t(this,e)}).\u0275mod=g.Kb({type:Yt}),Yt.\u0275inj=g.Jb({factory:function(t){return new(t||Yt)},imports:[[l.e.forChild(Ht)],l.e]}),Yt),Zt=i("B+Mi"),Kt=((_t=function e(){t(this,e)}).\u0275mod=g.Kb({type:_t}),_t.\u0275inj=g.Jb({factory:function(t){return new(t||_t)},imports:[[r.c,l.e,Jt,Zt.a,T.g,T.o]]}),_t)},gkM4:function(e,a,i){"use strict";i.d(a,"a",(function(){return b}));var r=i("QRvi"),l=i("fXoL"),o=i("tyNb"),b=function(){var e=function(){function e(n){t(this,e),this.router=n,this.oldURL=n.url}return n(e,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,e,n,a,i){if(a===r.a.Get&&t.next(n),a===r.a.Put&&(t.getValue()[0]=n),a===r.a.Post&&t.getValue().push(n),a===r.a.Delete){var l=t.getValue().indexOf(i);t.getValue().splice(l,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,e,n,a,i){a===r.a.Get&&t.next(n),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(l.Wb(o.b))},e.\u0275prov=l.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()}}])}();