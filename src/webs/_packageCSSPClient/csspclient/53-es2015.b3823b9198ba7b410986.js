(window.webpackJsonp=window.webpackJsonp||[]).push([[53],{QRvi:function(e,t,b){"use strict";b.d(t,"a",(function(){return n}));var n=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,b){"use strict";b.d(t,"a",(function(){return r}));var n=b("QRvi"),a=b("fXoL"),i=b("tyNb");let r=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,t,b){e.next(null),t.next({Working:!1,Error:b,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(e,t,b){e.next(null),t.next({Working:!1,Error:b,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,t,b,a,i){if(a===n.a.Get&&e.next(b),a===n.a.Put&&(e.getValue()[0]=b),a===n.a.Post&&e.getValue().push(b),a===n.a.Delete){const t=e.getValue().indexOf(i);e.getValue().splice(t,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(e,t,b,a,i){a===n.a.Get&&e.next(b),e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(t){return new(t||e)(a.Wb(i.b))},e.\u0275prov=a.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()},uzbP:function(e,t,b){"use strict";b.r(t),b.d(t,"LabSheetModule",(function(){return ke}));var n=b("ofXK"),a=b("tyNb");function i(e){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var r=b("V1px"),c=b("KyBE"),o=b("OG+2");function s(){let e=[];return"fr-CA"===$localize.locale?(e.push({EnumID:1,EnumText:"Created (fr)"}),e.push({EnumID:2,EnumText:"Transferred (fr)"}),e.push({EnumID:3,EnumText:"Accept\xe9"}),e.push({EnumID:4,EnumText:"Rejected (fr)"})):(e.push({EnumID:1,EnumText:"Created"}),e.push({EnumID:2,EnumText:"Transferred"}),e.push({EnumID:3,EnumText:"Accepted"}),e.push({EnumID:4,EnumText:"Rejected"})),e.sort((e,t)=>e.EnumText.localeCompare(t.EnumText))}var l=b("QRvi"),m=b("fXoL"),p=b("2Vo4"),u=b("LRne"),h=b("tk/3"),S=b("lJxs"),d=b("JIr8"),f=b("gkM4");let R=(()=>{class e{constructor(e,t){this.httpClient=e,this.httpClientService=t,this.labsheetTextModel$=new p.a({}),this.labsheetListModel$=new p.a({}),this.labsheetGetModel$=new p.a({}),this.labsheetPutModel$=new p.a({}),this.labsheetPostModel$=new p.a({}),this.labsheetDeleteModel$=new p.a({}),i(this.labsheetTextModel$),this.labsheetTextModel$.next({Title:"Something2 for text"})}GetLabSheetList(){return this.httpClientService.BeforeHttpClient(this.labsheetGetModel$),this.httpClient.get("/api/LabSheet").pipe(Object(S.a)(e=>{this.httpClientService.DoSuccess(this.labsheetListModel$,this.labsheetGetModel$,e,l.a.Get,null)}),Object(d.a)(e=>Object(u.a)(e).pipe(Object(S.a)(e=>{this.httpClientService.DoCatchError(this.labsheetListModel$,this.labsheetGetModel$,e)}))))}PutLabSheet(e){return this.httpClientService.BeforeHttpClient(this.labsheetPutModel$),this.httpClient.put("/api/LabSheet",e,{headers:new h.d}).pipe(Object(S.a)(t=>{this.httpClientService.DoSuccess(this.labsheetListModel$,this.labsheetPutModel$,t,l.a.Put,e)}),Object(d.a)(e=>Object(u.a)(e).pipe(Object(S.a)(e=>{this.httpClientService.DoCatchError(this.labsheetListModel$,this.labsheetPutModel$,e)}))))}PostLabSheet(e){return this.httpClientService.BeforeHttpClient(this.labsheetPostModel$),this.httpClient.post("/api/LabSheet",e,{headers:new h.d}).pipe(Object(S.a)(t=>{this.httpClientService.DoSuccess(this.labsheetListModel$,this.labsheetPostModel$,t,l.a.Post,e)}),Object(d.a)(e=>Object(u.a)(e).pipe(Object(S.a)(e=>{this.httpClientService.DoCatchError(this.labsheetListModel$,this.labsheetPostModel$,e)}))))}DeleteLabSheet(e){return this.httpClientService.BeforeHttpClient(this.labsheetDeleteModel$),this.httpClient.delete("/api/LabSheet/"+e.LabSheetID).pipe(Object(S.a)(t=>{this.httpClientService.DoSuccess(this.labsheetListModel$,this.labsheetDeleteModel$,t,l.a.Delete,e)}),Object(d.a)(e=>Object(u.a)(e).pipe(Object(S.a)(e=>{this.httpClientService.DoCatchError(this.labsheetListModel$,this.labsheetDeleteModel$,e)}))))}}return e.\u0275fac=function(t){return new(t||e)(m.Wb(h.b),m.Wb(f.a))},e.\u0275prov=m.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var I=b("Wp6s"),B=b("bTqV"),g=b("bv9b"),y=b("NFeN"),D=b("3Pt+"),L=b("kmnG"),T=b("qFsG"),N=b("d3UM"),z=b("FKr1");function C(e,t){1&e&&m.Nb(0,"mat-progress-bar",27)}function v(e,t){1&e&&m.Nb(0,"mat-progress-bar",27)}function M(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function P(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,M,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function E(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function $(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Min - 1"),m.Nb(2,"br"),m.Rb())}function j(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,E,3,0,"span",4),m.yc(6,$,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.required),m.Bb(1),m.ic("ngIf",e.min)}}function x(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function F(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,x,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function q(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function O(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"MinLength - 1"),m.Nb(2,"br"),m.Rb())}function w(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"MaxLength - 250"),m.Nb(2,"br"),m.Rb())}function G(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,q,3,0,"span",4),m.yc(6,O,3,0,"span",4),m.yc(7,w,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,4,e)),m.Bb(3),m.ic("ngIf",e.required),m.Bb(1),m.ic("ngIf",e.minlength),m.Bb(1),m.ic("ngIf",e.maxlength)}}function V(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function A(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Min - 1980"),m.Nb(2,"br"),m.Rb())}function k(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,V,3,0,"span",4),m.yc(6,A,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,3,e)),m.Bb(3),m.ic("ngIf",e.required),m.Bb(1),m.ic("ngIf",e.min)}}function U(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function W(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Min - 1"),m.Nb(2,"br"),m.Rb())}function _(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Max - 12"),m.Nb(2,"br"),m.Rb())}function Q(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,U,3,0,"span",4),m.yc(6,W,3,0,"span",4),m.yc(7,_,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,4,e)),m.Bb(3),m.ic("ngIf",e.required),m.Bb(1),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function Y(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function J(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Min - 1"),m.Nb(2,"br"),m.Rb())}function H(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Max - 31"),m.Nb(2,"br"),m.Rb())}function K(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,Y,3,0,"span",4),m.yc(6,J,3,0,"span",4),m.yc(7,H,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,4,e)),m.Bb(3),m.ic("ngIf",e.required),m.Bb(1),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function Z(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function X(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Min - 1"),m.Nb(2,"br"),m.Rb())}function ee(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Max - 100"),m.Nb(2,"br"),m.Rb())}function te(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,Z,3,0,"span",4),m.yc(6,X,3,0,"span",4),m.yc(7,ee,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,4,e)),m.Bb(3),m.ic("ngIf",e.required),m.Bb(1),m.ic("ngIf",e.min),m.Bb(1),m.ic("ngIf",e.min)}}function be(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function ne(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,be,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function ae(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,1,e))}}function ie(e,t){if(1&e&&(m.Sb(0,"mat-option",28),m.zc(1),m.Rb()),2&e){const e=t.$implicit;m.ic("value",e.EnumID),m.Bb(1),m.Bc(" ",e.EnumText," ")}}function re(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function ce(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,re,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function oe(e,t){if(1&e&&(m.Sb(0,"mat-option",28),m.zc(1),m.Rb()),2&e){const e=t.$implicit;m.ic("value",e.EnumID),m.Bb(1),m.Bc(" ",e.EnumText," ")}}function se(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function le(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,se,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function me(e,t){if(1&e&&(m.Sb(0,"mat-option",28),m.zc(1),m.Rb()),2&e){const e=t.$implicit;m.ic("value",e.EnumID),m.Bb(1),m.Bc(" ",e.EnumText," ")}}function pe(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function ue(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,pe,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function he(e,t){if(1&e&&(m.Sb(0,"mat-option",28),m.zc(1),m.Rb()),2&e){const e=t.$implicit;m.ic("value",e.EnumID),m.Bb(1),m.Bc(" ",e.EnumText," ")}}function Se(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function de(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,Se,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function fe(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function Re(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"MinLength - 1"),m.Nb(2,"br"),m.Rb())}function Ie(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"MaxLength - 250"),m.Nb(2,"br"),m.Rb())}function Be(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,fe,3,0,"span",4),m.yc(6,Re,3,0,"span",4),m.yc(7,Ie,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,4,e)),m.Bb(3),m.ic("ngIf",e.required),m.Bb(1),m.ic("ngIf",e.minlength),m.Bb(1),m.ic("ngIf",e.maxlength)}}function ge(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function ye(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,ge,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function De(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function Le(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,De,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function Te(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,1,e))}}function Ne(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,1,e))}}function ze(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"MaxLength - 250"),m.Nb(2,"br"),m.Rb())}function Ce(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,ze,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.maxlength)}}function ve(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function Me(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,ve,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}function Pe(e,t){1&e&&(m.Sb(0,"span"),m.zc(1,"Is Required"),m.Nb(2,"br"),m.Rb())}function Ee(e,t){if(1&e&&(m.Sb(0,"mat-error"),m.Sb(1,"span"),m.zc(2),m.ec(3,"json"),m.Nb(4,"br"),m.Rb(),m.yc(5,Pe,3,0,"span",4),m.Rb()),2&e){const e=t.$implicit;m.Bb(2),m.Ac(m.fc(3,2,e)),m.Bb(3),m.ic("ngIf",e.required)}}let $e=(()=>{class e{constructor(e,t){this.labsheetService=e,this.fb=t,this.labsheet=null,this.httpClientCommand=l.a.Put}GetPut(){return this.httpClientCommand==l.a.Put}PutLabSheet(e){this.sub=this.labsheetService.PutLabSheet(e).subscribe()}PostLabSheet(e){this.sub=this.labsheetService.PostLabSheet(e).subscribe()}ngOnInit(){this.samplingPlanTypeList=Object(r.b)(),this.sampleTypeList=Object(c.b)(),this.labSheetTypeList=Object(o.b)(),this.labSheetStatusList=s(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.labsheet){let t=this.fb.group({LabSheetID:[{value:e===l.a.Post?0:this.labsheet.LabSheetID,disabled:!1},[D.p.required]],OtherServerLabSheetID:[{value:this.labsheet.OtherServerLabSheetID,disabled:!1},[D.p.required,D.p.min(1)]],SamplingPlanID:[{value:this.labsheet.SamplingPlanID,disabled:!1},[D.p.required]],SamplingPlanName:[{value:this.labsheet.SamplingPlanName,disabled:!1},[D.p.required,D.p.minLength(1),D.p.maxLength(250)]],Year:[{value:this.labsheet.Year,disabled:!1},[D.p.required,D.p.min(1980)]],Month:[{value:this.labsheet.Month,disabled:!1},[D.p.required,D.p.min(1),D.p.max(12)]],Day:[{value:this.labsheet.Day,disabled:!1},[D.p.required,D.p.min(1),D.p.max(31)]],RunNumber:[{value:this.labsheet.RunNumber,disabled:!1},[D.p.required,D.p.min(1),D.p.max(100)]],SubsectorTVItemID:[{value:this.labsheet.SubsectorTVItemID,disabled:!1},[D.p.required]],MWQMRunTVItemID:[{value:this.labsheet.MWQMRunTVItemID,disabled:!1}],SamplingPlanType:[{value:this.labsheet.SamplingPlanType,disabled:!1},[D.p.required]],SampleType:[{value:this.labsheet.SampleType,disabled:!1},[D.p.required]],LabSheetType:[{value:this.labsheet.LabSheetType,disabled:!1},[D.p.required]],LabSheetStatus:[{value:this.labsheet.LabSheetStatus,disabled:!1},[D.p.required]],FileName:[{value:this.labsheet.FileName,disabled:!1},[D.p.required,D.p.minLength(1),D.p.maxLength(250)]],FileLastModifiedDate_Local:[{value:this.labsheet.FileLastModifiedDate_Local,disabled:!1},[D.p.required]],FileContent:[{value:this.labsheet.FileContent,disabled:!1},[D.p.required]],AcceptedOrRejectedByContactTVItemID:[{value:this.labsheet.AcceptedOrRejectedByContactTVItemID,disabled:!1}],AcceptedOrRejectedDateTime:[{value:this.labsheet.AcceptedOrRejectedDateTime,disabled:!1}],RejectReason:[{value:this.labsheet.RejectReason,disabled:!1},[D.p.maxLength(250)]],LastUpdateDate_UTC:[{value:this.labsheet.LastUpdateDate_UTC,disabled:!1},[D.p.required]],LastUpdateContactTVItemID:[{value:this.labsheet.LastUpdateContactTVItemID,disabled:!1},[D.p.required]]});this.labsheetFormEdit=t}}}return e.\u0275fac=function(t){return new(t||e)(m.Mb(R),m.Mb(D.d))},e.\u0275cmp=m.Gb({type:e,selectors:[["app-labsheet-edit"]],inputs:{labsheet:"labsheet",httpClientCommand:"httpClientCommand"},decls:128,vars:30,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","LabSheetID"],[4,"ngIf"],["matInput","","type","number","formControlName","OtherServerLabSheetID"],["matInput","","type","number","formControlName","SamplingPlanID"],["matInput","","type","text","formControlName","SamplingPlanName"],["matInput","","type","number","formControlName","Year"],["matInput","","type","number","formControlName","Month"],["matInput","","type","number","formControlName","Day"],["matInput","","type","number","formControlName","RunNumber"],["matInput","","type","number","formControlName","SubsectorTVItemID"],["matInput","","type","number","formControlName","MWQMRunTVItemID"],["formControlName","SamplingPlanType"],[3,"value",4,"ngFor","ngForOf"],["formControlName","SampleType"],["formControlName","LabSheetType"],["formControlName","LabSheetStatus"],["matInput","","type","text","formControlName","FileName"],["matInput","","type","text","formControlName","FileLastModifiedDate_Local"],["matInput","","type","text","formControlName","FileContent"],["matInput","","type","number","formControlName","AcceptedOrRejectedByContactTVItemID"],["matInput","","type","text","formControlName","AcceptedOrRejectedDateTime"],["matInput","","type","text","formControlName","RejectReason"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(m.Sb(0,"form",0),m.Zb("ngSubmit",(function(){return t.GetPut()?t.PutLabSheet(t.labsheetFormEdit.value):t.PostLabSheet(t.labsheetFormEdit.value)})),m.Sb(1,"h3"),m.zc(2," LabSheet "),m.Sb(3,"button",1),m.Sb(4,"span"),m.zc(5),m.Rb(),m.Rb(),m.yc(6,C,1,0,"mat-progress-bar",2),m.yc(7,v,1,0,"mat-progress-bar",2),m.Rb(),m.Sb(8,"p"),m.Sb(9,"mat-form-field"),m.Sb(10,"mat-label"),m.zc(11,"LabSheetID"),m.Rb(),m.Nb(12,"input",3),m.yc(13,P,6,4,"mat-error",4),m.Rb(),m.Sb(14,"mat-form-field"),m.Sb(15,"mat-label"),m.zc(16,"OtherServerLabSheetID"),m.Rb(),m.Nb(17,"input",5),m.yc(18,j,7,5,"mat-error",4),m.Rb(),m.Sb(19,"mat-form-field"),m.Sb(20,"mat-label"),m.zc(21,"SamplingPlanID"),m.Rb(),m.Nb(22,"input",6),m.yc(23,F,6,4,"mat-error",4),m.Rb(),m.Sb(24,"mat-form-field"),m.Sb(25,"mat-label"),m.zc(26,"SamplingPlanName"),m.Rb(),m.Nb(27,"input",7),m.yc(28,G,8,6,"mat-error",4),m.Rb(),m.Rb(),m.Sb(29,"p"),m.Sb(30,"mat-form-field"),m.Sb(31,"mat-label"),m.zc(32,"Year"),m.Rb(),m.Nb(33,"input",8),m.yc(34,k,7,5,"mat-error",4),m.Rb(),m.Sb(35,"mat-form-field"),m.Sb(36,"mat-label"),m.zc(37,"Month"),m.Rb(),m.Nb(38,"input",9),m.yc(39,Q,8,6,"mat-error",4),m.Rb(),m.Sb(40,"mat-form-field"),m.Sb(41,"mat-label"),m.zc(42,"Day"),m.Rb(),m.Nb(43,"input",10),m.yc(44,K,8,6,"mat-error",4),m.Rb(),m.Sb(45,"mat-form-field"),m.Sb(46,"mat-label"),m.zc(47,"RunNumber"),m.Rb(),m.Nb(48,"input",11),m.yc(49,te,8,6,"mat-error",4),m.Rb(),m.Rb(),m.Sb(50,"p"),m.Sb(51,"mat-form-field"),m.Sb(52,"mat-label"),m.zc(53,"SubsectorTVItemID"),m.Rb(),m.Nb(54,"input",12),m.yc(55,ne,6,4,"mat-error",4),m.Rb(),m.Sb(56,"mat-form-field"),m.Sb(57,"mat-label"),m.zc(58,"MWQMRunTVItemID"),m.Rb(),m.Nb(59,"input",13),m.yc(60,ae,5,3,"mat-error",4),m.Rb(),m.Sb(61,"mat-form-field"),m.Sb(62,"mat-label"),m.zc(63,"SamplingPlanType"),m.Rb(),m.Sb(64,"mat-select",14),m.yc(65,ie,2,2,"mat-option",15),m.Rb(),m.yc(66,ce,6,4,"mat-error",4),m.Rb(),m.Sb(67,"mat-form-field"),m.Sb(68,"mat-label"),m.zc(69,"SampleType"),m.Rb(),m.Sb(70,"mat-select",16),m.yc(71,oe,2,2,"mat-option",15),m.Rb(),m.yc(72,le,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Sb(73,"p"),m.Sb(74,"mat-form-field"),m.Sb(75,"mat-label"),m.zc(76,"LabSheetType"),m.Rb(),m.Sb(77,"mat-select",17),m.yc(78,me,2,2,"mat-option",15),m.Rb(),m.yc(79,ue,6,4,"mat-error",4),m.Rb(),m.Sb(80,"mat-form-field"),m.Sb(81,"mat-label"),m.zc(82,"LabSheetStatus"),m.Rb(),m.Sb(83,"mat-select",18),m.yc(84,he,2,2,"mat-option",15),m.Rb(),m.yc(85,de,6,4,"mat-error",4),m.Rb(),m.Sb(86,"mat-form-field"),m.Sb(87,"mat-label"),m.zc(88,"FileName"),m.Rb(),m.Nb(89,"input",19),m.yc(90,Be,8,6,"mat-error",4),m.Rb(),m.Sb(91,"mat-form-field"),m.Sb(92,"mat-label"),m.zc(93,"FileLastModifiedDate_Local"),m.Rb(),m.Nb(94,"input",20),m.yc(95,ye,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Sb(96,"p"),m.Sb(97,"mat-form-field"),m.Sb(98,"mat-label"),m.zc(99,"FileContent"),m.Rb(),m.Nb(100,"input",21),m.yc(101,Le,6,4,"mat-error",4),m.Rb(),m.Sb(102,"mat-form-field"),m.Sb(103,"mat-label"),m.zc(104,"AcceptedOrRejectedByContactTVItemID"),m.Rb(),m.Nb(105,"input",22),m.yc(106,Te,5,3,"mat-error",4),m.Rb(),m.Sb(107,"mat-form-field"),m.Sb(108,"mat-label"),m.zc(109,"AcceptedOrRejectedDateTime"),m.Rb(),m.Nb(110,"input",23),m.yc(111,Ne,5,3,"mat-error",4),m.Rb(),m.Sb(112,"mat-form-field"),m.Sb(113,"mat-label"),m.zc(114,"RejectReason"),m.Rb(),m.Nb(115,"input",24),m.yc(116,Ce,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Sb(117,"p"),m.Sb(118,"mat-form-field"),m.Sb(119,"mat-label"),m.zc(120,"LastUpdateDate_UTC"),m.Rb(),m.Nb(121,"input",25),m.yc(122,Me,6,4,"mat-error",4),m.Rb(),m.Sb(123,"mat-form-field"),m.Sb(124,"mat-label"),m.zc(125,"LastUpdateContactTVItemID"),m.Rb(),m.Nb(126,"input",26),m.yc(127,Ee,6,4,"mat-error",4),m.Rb(),m.Rb(),m.Rb()),2&e&&(m.ic("formGroup",t.labsheetFormEdit),m.Bb(5),m.Bc("",t.GetPut()?"Put":"Post"," LabSheet"),m.Bb(1),m.ic("ngIf",t.labsheetService.labsheetPutModel$.getValue().Working),m.Bb(1),m.ic("ngIf",t.labsheetService.labsheetPostModel$.getValue().Working),m.Bb(6),m.ic("ngIf",t.labsheetFormEdit.controls.LabSheetID.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.OtherServerLabSheetID.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.SamplingPlanID.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.SamplingPlanName.errors),m.Bb(6),m.ic("ngIf",t.labsheetFormEdit.controls.Year.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.Month.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.Day.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.RunNumber.errors),m.Bb(6),m.ic("ngIf",t.labsheetFormEdit.controls.SubsectorTVItemID.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.MWQMRunTVItemID.errors),m.Bb(5),m.ic("ngForOf",t.samplingPlanTypeList),m.Bb(1),m.ic("ngIf",t.labsheetFormEdit.controls.SamplingPlanType.errors),m.Bb(5),m.ic("ngForOf",t.sampleTypeList),m.Bb(1),m.ic("ngIf",t.labsheetFormEdit.controls.SampleType.errors),m.Bb(6),m.ic("ngForOf",t.labSheetTypeList),m.Bb(1),m.ic("ngIf",t.labsheetFormEdit.controls.LabSheetType.errors),m.Bb(5),m.ic("ngForOf",t.labSheetStatusList),m.Bb(1),m.ic("ngIf",t.labsheetFormEdit.controls.LabSheetStatus.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.FileName.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.FileLastModifiedDate_Local.errors),m.Bb(6),m.ic("ngIf",t.labsheetFormEdit.controls.FileContent.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.AcceptedOrRejectedByContactTVItemID.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.AcceptedOrRejectedDateTime.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.RejectReason.errors),m.Bb(6),m.ic("ngIf",t.labsheetFormEdit.controls.LastUpdateDate_UTC.errors),m.Bb(5),m.ic("ngIf",t.labsheetFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[D.q,D.l,D.f,B.b,n.l,L.c,L.f,T.b,D.n,D.c,D.k,D.e,N.a,n.k,g.a,L.b,z.n],pipes:[n.f],styles:[""],changeDetection:0}),e})();function je(e,t){1&e&&m.Nb(0,"mat-progress-bar",4)}function xe(e,t){1&e&&m.Nb(0,"mat-progress-bar",4)}function Fe(e,t){if(1&e&&(m.Sb(0,"p"),m.Nb(1,"app-labsheet-edit",8),m.Rb()),2&e){const e=m.dc().$implicit,t=m.dc(2);m.Bb(1),m.ic("labsheet",e)("httpClientCommand",t.GetPutEnum())}}function qe(e,t){if(1&e&&(m.Sb(0,"p"),m.Nb(1,"app-labsheet-edit",8),m.Rb()),2&e){const e=m.dc().$implicit,t=m.dc(2);m.Bb(1),m.ic("labsheet",e)("httpClientCommand",t.GetPostEnum())}}function Oe(e,t){if(1&e){const e=m.Tb();m.Sb(0,"div"),m.Sb(1,"p"),m.Sb(2,"button",6),m.Zb("click",(function(){m.qc(e);const b=t.$implicit;return m.dc(2).DeleteLabSheet(b)})),m.Sb(3,"span"),m.zc(4),m.Rb(),m.Sb(5,"mat-icon"),m.zc(6,"delete"),m.Rb(),m.Rb(),m.zc(7,"\xa0\xa0\xa0 "),m.Sb(8,"button",7),m.Zb("click",(function(){m.qc(e);const b=t.$implicit;return m.dc(2).ShowPut(b)})),m.Sb(9,"span"),m.zc(10,"Show Put"),m.Rb(),m.Rb(),m.zc(11,"\xa0\xa0 "),m.Sb(12,"button",7),m.Zb("click",(function(){m.qc(e);const b=t.$implicit;return m.dc(2).ShowPost(b)})),m.Sb(13,"span"),m.zc(14,"Show Post"),m.Rb(),m.Rb(),m.zc(15,"\xa0\xa0 "),m.yc(16,xe,1,0,"mat-progress-bar",0),m.Rb(),m.yc(17,Fe,2,2,"p",2),m.yc(18,qe,2,2,"p",2),m.Sb(19,"blockquote"),m.Sb(20,"p"),m.Sb(21,"span"),m.zc(22),m.Rb(),m.Sb(23,"span"),m.zc(24),m.Rb(),m.Sb(25,"span"),m.zc(26),m.Rb(),m.Sb(27,"span"),m.zc(28),m.Rb(),m.Rb(),m.Sb(29,"p"),m.Sb(30,"span"),m.zc(31),m.Rb(),m.Sb(32,"span"),m.zc(33),m.Rb(),m.Sb(34,"span"),m.zc(35),m.Rb(),m.Sb(36,"span"),m.zc(37),m.Rb(),m.Rb(),m.Sb(38,"p"),m.Sb(39,"span"),m.zc(40),m.Rb(),m.Sb(41,"span"),m.zc(42),m.Rb(),m.Sb(43,"span"),m.zc(44),m.Rb(),m.Sb(45,"span"),m.zc(46),m.Rb(),m.Rb(),m.Sb(47,"p"),m.Sb(48,"span"),m.zc(49),m.Rb(),m.Sb(50,"span"),m.zc(51),m.Rb(),m.Sb(52,"span"),m.zc(53),m.Rb(),m.Sb(54,"span"),m.zc(55),m.Rb(),m.Rb(),m.Sb(56,"p"),m.Sb(57,"span"),m.zc(58),m.Rb(),m.Sb(59,"span"),m.zc(60),m.Rb(),m.Sb(61,"span"),m.zc(62),m.Rb(),m.Sb(63,"span"),m.zc(64),m.Rb(),m.Rb(),m.Sb(65,"p"),m.Sb(66,"span"),m.zc(67),m.Rb(),m.Sb(68,"span"),m.zc(69),m.Rb(),m.Rb(),m.Rb(),m.Rb()}if(2&e){const e=t.$implicit,b=m.dc(2);m.Bb(4),m.Bc("Delete LabSheetID [",e.LabSheetID,"]\xa0\xa0\xa0"),m.Bb(4),m.ic("color",b.GetPutButtonColor(e)),m.Bb(4),m.ic("color",b.GetPostButtonColor(e)),m.Bb(4),m.ic("ngIf",b.labsheetService.labsheetDeleteModel$.getValue().Working),m.Bb(1),m.ic("ngIf",b.IDToShow===e.LabSheetID&&b.showType===b.GetPutEnum()),m.Bb(1),m.ic("ngIf",b.IDToShow===e.LabSheetID&&b.showType===b.GetPostEnum()),m.Bb(4),m.Bc("LabSheetID: [",e.LabSheetID,"]"),m.Bb(2),m.Bc(" --- OtherServerLabSheetID: [",e.OtherServerLabSheetID,"]"),m.Bb(2),m.Bc(" --- SamplingPlanID: [",e.SamplingPlanID,"]"),m.Bb(2),m.Bc(" --- SamplingPlanName: [",e.SamplingPlanName,"]"),m.Bb(3),m.Bc("Year: [",e.Year,"]"),m.Bb(2),m.Bc(" --- Month: [",e.Month,"]"),m.Bb(2),m.Bc(" --- Day: [",e.Day,"]"),m.Bb(2),m.Bc(" --- RunNumber: [",e.RunNumber,"]"),m.Bb(3),m.Bc("SubsectorTVItemID: [",e.SubsectorTVItemID,"]"),m.Bb(2),m.Bc(" --- MWQMRunTVItemID: [",e.MWQMRunTVItemID,"]"),m.Bb(2),m.Bc(" --- SamplingPlanType: [",b.GetSamplingPlanTypeEnumText(e.SamplingPlanType),"]"),m.Bb(2),m.Bc(" --- SampleType: [",b.GetSampleTypeEnumText(e.SampleType),"]"),m.Bb(3),m.Bc("LabSheetType: [",b.GetLabSheetTypeEnumText(e.LabSheetType),"]"),m.Bb(2),m.Bc(" --- LabSheetStatus: [",b.GetLabSheetStatusEnumText(e.LabSheetStatus),"]"),m.Bb(2),m.Bc(" --- FileName: [",e.FileName,"]"),m.Bb(2),m.Bc(" --- FileLastModifiedDate_Local: [",e.FileLastModifiedDate_Local,"]"),m.Bb(3),m.Bc("FileContent: [",e.FileContent,"]"),m.Bb(2),m.Bc(" --- AcceptedOrRejectedByContactTVItemID: [",e.AcceptedOrRejectedByContactTVItemID,"]"),m.Bb(2),m.Bc(" --- AcceptedOrRejectedDateTime: [",e.AcceptedOrRejectedDateTime,"]"),m.Bb(2),m.Bc(" --- RejectReason: [",e.RejectReason,"]"),m.Bb(3),m.Bc("LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),m.Bb(2),m.Bc(" --- LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function we(e,t){if(1&e&&(m.Sb(0,"div"),m.yc(1,Oe,70,28,"div",5),m.Rb()),2&e){const e=m.dc();m.Bb(1),m.ic("ngForOf",e.labsheetService.labsheetListModel$.getValue())}}const Ge=[{path:"",component:(()=>{class e{constructor(e,t,b){this.labsheetService=e,this.router=t,this.httpClientService=b,this.showType=null,b.oldURL=t.url}GetPutButtonColor(e){return this.IDToShow===e.LabSheetID&&this.showType===l.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.LabSheetID&&this.showType===l.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.LabSheetID&&this.showType===l.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.LabSheetID,this.showType=l.a.Put)}ShowPost(e){this.IDToShow===e.LabSheetID&&this.showType===l.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.LabSheetID,this.showType=l.a.Post)}GetPutEnum(){return l.a.Put}GetPostEnum(){return l.a.Post}GetLabSheetList(){this.sub=this.labsheetService.GetLabSheetList().subscribe()}DeleteLabSheet(e){this.sub=this.labsheetService.DeleteLabSheet(e).subscribe()}GetSamplingPlanTypeEnumText(e){return Object(r.a)(e)}GetSampleTypeEnumText(e){return Object(c.a)(e)}GetLabSheetTypeEnumText(e){return Object(o.a)(e)}GetLabSheetStatusEnumText(e){return function(e){let t;return s().forEach(b=>{if(b.EnumID==e)return t=b.EnumText,!1}),t}(e)}ngOnInit(){i(this.labsheetService.labsheetTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(t){return new(t||e)(m.Mb(R),m.Mb(a.b),m.Mb(f.a))},e.\u0275cmp=m.Gb({type:e,selectors:[["app-labsheet"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"labsheet","httpClientCommand"]],template:function(e,t){var b,n;1&e&&(m.yc(0,je,1,0,"mat-progress-bar",0),m.Sb(1,"mat-card"),m.Sb(2,"mat-card-header"),m.Sb(3,"mat-card-title"),m.zc(4," LabSheet works! "),m.Sb(5,"button",1),m.Zb("click",(function(){return t.GetLabSheetList()})),m.Sb(6,"span"),m.zc(7,"Get LabSheet"),m.Rb(),m.Rb(),m.Rb(),m.Sb(8,"mat-card-subtitle"),m.zc(9),m.Rb(),m.Rb(),m.Sb(10,"mat-card-content"),m.yc(11,we,2,1,"div",2),m.Rb(),m.Sb(12,"mat-card-actions"),m.Sb(13,"button",3),m.zc(14,"Allo"),m.Rb(),m.Rb(),m.Rb()),2&e&&(m.ic("ngIf",null==(b=t.labsheetService.labsheetGetModel$.getValue())?null:b.Working),m.Bb(9),m.Ac(t.labsheetService.labsheetTextModel$.getValue().Title),m.Bb(2),m.ic("ngIf",null==(n=t.labsheetService.labsheetListModel$.getValue())?null:n.length))},directives:[n.l,I.a,I.d,I.g,B.b,I.f,I.c,I.b,g.a,n.k,y.a,$e],styles:[""],changeDetection:0}),e})(),canActivate:[b("auXs").a]}];let Ve=(()=>{class e{}return e.\u0275mod=m.Kb({type:e}),e.\u0275inj=m.Jb({factory:function(t){return new(t||e)},imports:[[a.e.forChild(Ge)],a.e]}),e})();var Ae=b("B+Mi");let ke=(()=>{class e{}return e.\u0275mod=m.Kb({type:e}),e.\u0275inj=m.Jb({factory:function(t){return new(t||e)},imports:[[n.c,a.e,Ve,Ae.a,D.g,D.o]]}),e})()}}]);