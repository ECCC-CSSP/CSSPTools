(window.webpackJsonp=window.webpackJsonp||[]).push([[49],{QRvi:function(t,e,a){"use strict";a.d(e,"a",(function(){return r}));var r=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,a){"use strict";a.d(e,"a",(function(){return c}));var r=a("QRvi"),i=a("fXoL"),o=a("tyNb");let c=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,a){t.next(null),e.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,a){t.next(null),e.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,a,i,o){if(i===r.a.Get&&t.next(a),i===r.a.Put&&(t.getValue()[0]=a),i===r.a.Post&&t.getValue().push(a),i===r.a.Delete){const e=t.getValue().indexOf(o);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,a,i,o){i===r.a.Get&&t.next(a),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(i.Xb(o.b))},t.\u0275prov=i.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()},hzbZ:function(t,e,a){"use strict";a.r(e),a.d(e,"HydrometricDataValueModule",(function(){return lt}));var r=a("ofXK"),i=a("tyNb");function o(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var c=a("qfes"),n=a("QRvi"),s=a("fXoL"),b=a("2Vo4"),l=a("LRne"),u=a("tk/3"),d=a("lJxs"),m=a("JIr8"),h=a("gkM4");let p=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.hydrometricdatavalueTextModel$=new b.a({}),this.hydrometricdatavalueListModel$=new b.a({}),this.hydrometricdatavalueGetModel$=new b.a({}),this.hydrometricdatavaluePutModel$=new b.a({}),this.hydrometricdatavaluePostModel$=new b.a({}),this.hydrometricdatavalueDeleteModel$=new b.a({}),o(this.hydrometricdatavalueTextModel$),this.hydrometricdatavalueTextModel$.next({Title:"Something2 for text"})}GetHydrometricDataValueList(){return this.httpClientService.BeforeHttpClient(this.hydrometricdatavalueGetModel$),this.httpClient.get("/api/HydrometricDataValue").pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.hydrometricdatavalueListModel$,this.hydrometricdatavalueGetModel$,t,n.a.Get,null)}),Object(m.a)(t=>Object(l.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.hydrometricdatavalueListModel$,this.hydrometricdatavalueGetModel$,t)}))))}PutHydrometricDataValue(t){return this.httpClientService.BeforeHttpClient(this.hydrometricdatavaluePutModel$),this.httpClient.put("/api/HydrometricDataValue",t,{headers:new u.d}).pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.hydrometricdatavalueListModel$,this.hydrometricdatavaluePutModel$,e,n.a.Put,t)}),Object(m.a)(t=>Object(l.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.hydrometricdatavalueListModel$,this.hydrometricdatavaluePutModel$,t)}))))}PostHydrometricDataValue(t){return this.httpClientService.BeforeHttpClient(this.hydrometricdatavaluePostModel$),this.httpClient.post("/api/HydrometricDataValue",t,{headers:new u.d}).pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.hydrometricdatavalueListModel$,this.hydrometricdatavaluePostModel$,e,n.a.Post,t)}),Object(m.a)(t=>Object(l.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.hydrometricdatavalueListModel$,this.hydrometricdatavaluePostModel$,t)}))))}DeleteHydrometricDataValue(t){return this.httpClientService.BeforeHttpClient(this.hydrometricdatavalueDeleteModel$),this.httpClient.delete("/api/HydrometricDataValue/"+t.HydrometricDataValueID).pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.hydrometricdatavalueListModel$,this.hydrometricdatavalueDeleteModel$,e,n.a.Delete,t)}),Object(m.a)(t=>Object(l.a)(t).pipe(Object(d.a)(t=>{this.httpClientService.DoCatchError(this.hydrometricdatavalueListModel$,this.hydrometricdatavalueDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(s.Xb(u.b),s.Xb(h.a))},t.\u0275prov=s.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var y=a("Wp6s"),f=a("bTqV"),S=a("bv9b"),T=a("NFeN"),v=a("3Pt+"),D=a("kmnG"),g=a("qFsG"),I=a("d3UM"),B=a("FKr1");function C(t,e){1&t&&s.Ob(0,"mat-progress-bar",17)}function j(t,e){1&t&&s.Ob(0,"mat-progress-bar",17)}function V(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function H(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,V,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function x(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function O(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,x,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function P(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function $(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,P,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function L(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function _(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,L,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function w(t,e){if(1&t&&(s.Tb(0,"mat-option",18),s.yc(1),s.Sb()),2&t){const t=e.$implicit;s.jc("value",t.EnumID),s.Bb(1),s.Ac(" ",t.EnumText," ")}}function M(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function E(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,M,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function G(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function k(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,G,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function q(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function F(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Max - 100000"),s.Ob(2,"br"),s.Sb())}function R(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,q,3,0,"span",4),s.xc(6,F,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,3,t)),s.Bb(3),s.jc("ngIf",t.min),s.Bb(1),s.jc("ngIf",t.min)}}function U(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function N(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Max - 100000"),s.Ob(2,"br"),s.Sb())}function A(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,U,3,0,"span",4),s.xc(6,N,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,3,t)),s.Bb(3),s.jc("ngIf",t.min),s.Bb(1),s.jc("ngIf",t.min)}}function z(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Min - 0"),s.Ob(2,"br"),s.Sb())}function K(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Max - 10000"),s.Ob(2,"br"),s.Sb())}function W(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,z,3,0,"span",4),s.xc(6,K,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,3,t)),s.Bb(3),s.jc("ngIf",t.min),s.Bb(1),s.jc("ngIf",t.min)}}function X(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,1,t))}}function J(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function Q(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,J,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function Z(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function Y(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,Z,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}let tt=(()=>{class t{constructor(t,e){this.hydrometricdatavalueService=t,this.fb=e,this.hydrometricdatavalue=null,this.httpClientCommand=n.a.Put}GetPut(){return this.httpClientCommand==n.a.Put}PutHydrometricDataValue(t){this.sub=this.hydrometricdatavalueService.PutHydrometricDataValue(t).subscribe()}PostHydrometricDataValue(t){this.sub=this.hydrometricdatavalueService.PostHydrometricDataValue(t).subscribe()}ngOnInit(){this.storageDataTypeList=Object(c.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.hydrometricdatavalue){let e=this.fb.group({HydrometricDataValueID:[{value:t===n.a.Post?0:this.hydrometricdatavalue.HydrometricDataValueID,disabled:!1},[v.p.required]],HydrometricSiteID:[{value:this.hydrometricdatavalue.HydrometricSiteID,disabled:!1},[v.p.required]],DateTime_Local:[{value:this.hydrometricdatavalue.DateTime_Local,disabled:!1},[v.p.required]],Keep:[{value:this.hydrometricdatavalue.Keep,disabled:!1},[v.p.required]],StorageDataType:[{value:this.hydrometricdatavalue.StorageDataType,disabled:!1},[v.p.required]],HasBeenRead:[{value:this.hydrometricdatavalue.HasBeenRead,disabled:!1},[v.p.required]],Discharge_m3_s:[{value:this.hydrometricdatavalue.Discharge_m3_s,disabled:!1},[v.p.min(0),v.p.max(1e5)]],DischargeEntered_m3_s:[{value:this.hydrometricdatavalue.DischargeEntered_m3_s,disabled:!1},[v.p.min(0),v.p.max(1e5)]],Level_m:[{value:this.hydrometricdatavalue.Level_m,disabled:!1},[v.p.min(0),v.p.max(1e4)]],HourlyValues:[{value:this.hydrometricdatavalue.HourlyValues,disabled:!1}],LastUpdateDate_UTC:[{value:this.hydrometricdatavalue.LastUpdateDate_UTC,disabled:!1},[v.p.required]],LastUpdateContactTVItemID:[{value:this.hydrometricdatavalue.LastUpdateContactTVItemID,disabled:!1},[v.p.required]]});this.hydrometricdatavalueFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(s.Nb(p),s.Nb(v.d))},t.\u0275cmp=s.Hb({type:t,selectors:[["app-hydrometricdatavalue-edit"]],inputs:{hydrometricdatavalue:"hydrometricdatavalue",httpClientCommand:"httpClientCommand"},decls:72,vars:17,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","HydrometricDataValueID"],[4,"ngIf"],["matInput","","type","number","formControlName","HydrometricSiteID"],["matInput","","type","text","formControlName","DateTime_Local"],["matInput","","type","text","formControlName","Keep"],["formControlName","StorageDataType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","HasBeenRead"],["matInput","","type","number","formControlName","Discharge_m3_s"],["matInput","","type","number","formControlName","DischargeEntered_m3_s"],["matInput","","type","number","formControlName","Level_m"],["matInput","","type","text","formControlName","HourlyValues"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(s.Tb(0,"form",0),s.ac("ngSubmit",(function(){return e.GetPut()?e.PutHydrometricDataValue(e.hydrometricdatavalueFormEdit.value):e.PostHydrometricDataValue(e.hydrometricdatavalueFormEdit.value)})),s.Tb(1,"h3"),s.yc(2," HydrometricDataValue "),s.Tb(3,"button",1),s.Tb(4,"span"),s.yc(5),s.Sb(),s.Sb(),s.xc(6,C,1,0,"mat-progress-bar",2),s.xc(7,j,1,0,"mat-progress-bar",2),s.Sb(),s.Tb(8,"p"),s.Tb(9,"mat-form-field"),s.Tb(10,"mat-label"),s.yc(11,"HydrometricDataValueID"),s.Sb(),s.Ob(12,"input",3),s.xc(13,H,6,4,"mat-error",4),s.Sb(),s.Tb(14,"mat-form-field"),s.Tb(15,"mat-label"),s.yc(16,"HydrometricSiteID"),s.Sb(),s.Ob(17,"input",5),s.xc(18,O,6,4,"mat-error",4),s.Sb(),s.Tb(19,"mat-form-field"),s.Tb(20,"mat-label"),s.yc(21,"DateTime_Local"),s.Sb(),s.Ob(22,"input",6),s.xc(23,$,6,4,"mat-error",4),s.Sb(),s.Tb(24,"mat-form-field"),s.Tb(25,"mat-label"),s.yc(26,"Keep"),s.Sb(),s.Ob(27,"input",7),s.xc(28,_,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Tb(29,"p"),s.Tb(30,"mat-form-field"),s.Tb(31,"mat-label"),s.yc(32,"StorageDataType"),s.Sb(),s.Tb(33,"mat-select",8),s.xc(34,w,2,2,"mat-option",9),s.Sb(),s.xc(35,E,6,4,"mat-error",4),s.Sb(),s.Tb(36,"mat-form-field"),s.Tb(37,"mat-label"),s.yc(38,"HasBeenRead"),s.Sb(),s.Ob(39,"input",10),s.xc(40,k,6,4,"mat-error",4),s.Sb(),s.Tb(41,"mat-form-field"),s.Tb(42,"mat-label"),s.yc(43,"Discharge_m3_s"),s.Sb(),s.Ob(44,"input",11),s.xc(45,R,7,5,"mat-error",4),s.Sb(),s.Tb(46,"mat-form-field"),s.Tb(47,"mat-label"),s.yc(48,"DischargeEntered_m3_s"),s.Sb(),s.Ob(49,"input",12),s.xc(50,A,7,5,"mat-error",4),s.Sb(),s.Sb(),s.Tb(51,"p"),s.Tb(52,"mat-form-field"),s.Tb(53,"mat-label"),s.yc(54,"Level_m"),s.Sb(),s.Ob(55,"input",13),s.xc(56,W,7,5,"mat-error",4),s.Sb(),s.Tb(57,"mat-form-field"),s.Tb(58,"mat-label"),s.yc(59,"HourlyValues"),s.Sb(),s.Ob(60,"input",14),s.xc(61,X,5,3,"mat-error",4),s.Sb(),s.Tb(62,"mat-form-field"),s.Tb(63,"mat-label"),s.yc(64,"LastUpdateDate_UTC"),s.Sb(),s.Ob(65,"input",15),s.xc(66,Q,6,4,"mat-error",4),s.Sb(),s.Tb(67,"mat-form-field"),s.Tb(68,"mat-label"),s.yc(69,"LastUpdateContactTVItemID"),s.Sb(),s.Ob(70,"input",16),s.xc(71,Y,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Sb()),2&t&&(s.jc("formGroup",e.hydrometricdatavalueFormEdit),s.Bb(5),s.Ac("",e.GetPut()?"Put":"Post"," HydrometricDataValue"),s.Bb(1),s.jc("ngIf",e.hydrometricdatavalueService.hydrometricdatavaluePutModel$.getValue().Working),s.Bb(1),s.jc("ngIf",e.hydrometricdatavalueService.hydrometricdatavaluePostModel$.getValue().Working),s.Bb(6),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.HydrometricDataValueID.errors),s.Bb(5),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.HydrometricSiteID.errors),s.Bb(5),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.DateTime_Local.errors),s.Bb(5),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.Keep.errors),s.Bb(6),s.jc("ngForOf",e.storageDataTypeList),s.Bb(1),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.StorageDataType.errors),s.Bb(5),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.HasBeenRead.errors),s.Bb(5),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.Discharge_m3_s.errors),s.Bb(5),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.DischargeEntered_m3_s.errors),s.Bb(6),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.Level_m.errors),s.Bb(5),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.HourlyValues.errors),s.Bb(5),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.LastUpdateDate_UTC.errors),s.Bb(5),s.jc("ngIf",e.hydrometricdatavalueFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[v.q,v.l,v.f,f.b,r.l,D.c,D.f,g.b,v.n,v.c,v.k,v.e,I.a,r.k,S.a,D.b,B.n],pipes:[r.f],styles:[""],changeDetection:0}),t})();function et(t,e){1&t&&s.Ob(0,"mat-progress-bar",4)}function at(t,e){1&t&&s.Ob(0,"mat-progress-bar",4)}function rt(t,e){if(1&t&&(s.Tb(0,"p"),s.Ob(1,"app-hydrometricdatavalue-edit",8),s.Sb()),2&t){const t=s.ec().$implicit,e=s.ec(2);s.Bb(1),s.jc("hydrometricdatavalue",t)("httpClientCommand",e.GetPutEnum())}}function it(t,e){if(1&t&&(s.Tb(0,"p"),s.Ob(1,"app-hydrometricdatavalue-edit",8),s.Sb()),2&t){const t=s.ec().$implicit,e=s.ec(2);s.Bb(1),s.jc("hydrometricdatavalue",t)("httpClientCommand",e.GetPostEnum())}}function ot(t,e){if(1&t){const t=s.Ub();s.Tb(0,"div"),s.Tb(1,"p"),s.Tb(2,"button",6),s.ac("click",(function(){s.rc(t);const a=e.$implicit;return s.ec(2).DeleteHydrometricDataValue(a)})),s.Tb(3,"span"),s.yc(4),s.Sb(),s.Tb(5,"mat-icon"),s.yc(6,"delete"),s.Sb(),s.Sb(),s.yc(7,"\xa0\xa0\xa0 "),s.Tb(8,"button",7),s.ac("click",(function(){s.rc(t);const a=e.$implicit;return s.ec(2).ShowPut(a)})),s.Tb(9,"span"),s.yc(10,"Show Put"),s.Sb(),s.Sb(),s.yc(11,"\xa0\xa0 "),s.Tb(12,"button",7),s.ac("click",(function(){s.rc(t);const a=e.$implicit;return s.ec(2).ShowPost(a)})),s.Tb(13,"span"),s.yc(14,"Show Post"),s.Sb(),s.Sb(),s.yc(15,"\xa0\xa0 "),s.xc(16,at,1,0,"mat-progress-bar",0),s.Sb(),s.xc(17,rt,2,2,"p",2),s.xc(18,it,2,2,"p",2),s.Tb(19,"blockquote"),s.Tb(20,"p"),s.Tb(21,"span"),s.yc(22),s.Sb(),s.Tb(23,"span"),s.yc(24),s.Sb(),s.Tb(25,"span"),s.yc(26),s.Sb(),s.Tb(27,"span"),s.yc(28),s.Sb(),s.Sb(),s.Tb(29,"p"),s.Tb(30,"span"),s.yc(31),s.Sb(),s.Tb(32,"span"),s.yc(33),s.Sb(),s.Tb(34,"span"),s.yc(35),s.Sb(),s.Tb(36,"span"),s.yc(37),s.Sb(),s.Sb(),s.Tb(38,"p"),s.Tb(39,"span"),s.yc(40),s.Sb(),s.Tb(41,"span"),s.yc(42),s.Sb(),s.Tb(43,"span"),s.yc(44),s.Sb(),s.Tb(45,"span"),s.yc(46),s.Sb(),s.Sb(),s.Sb(),s.Sb()}if(2&t){const t=e.$implicit,a=s.ec(2);s.Bb(4),s.Ac("Delete HydrometricDataValueID [",t.HydrometricDataValueID,"]\xa0\xa0\xa0"),s.Bb(4),s.jc("color",a.GetPutButtonColor(t)),s.Bb(4),s.jc("color",a.GetPostButtonColor(t)),s.Bb(4),s.jc("ngIf",a.hydrometricdatavalueService.hydrometricdatavalueDeleteModel$.getValue().Working),s.Bb(1),s.jc("ngIf",a.IDToShow===t.HydrometricDataValueID&&a.showType===a.GetPutEnum()),s.Bb(1),s.jc("ngIf",a.IDToShow===t.HydrometricDataValueID&&a.showType===a.GetPostEnum()),s.Bb(4),s.Ac("HydrometricDataValueID: [",t.HydrometricDataValueID,"]"),s.Bb(2),s.Ac(" --- HydrometricSiteID: [",t.HydrometricSiteID,"]"),s.Bb(2),s.Ac(" --- DateTime_Local: [",t.DateTime_Local,"]"),s.Bb(2),s.Ac(" --- Keep: [",t.Keep,"]"),s.Bb(3),s.Ac("StorageDataType: [",a.GetStorageDataTypeEnumText(t.StorageDataType),"]"),s.Bb(2),s.Ac(" --- HasBeenRead: [",t.HasBeenRead,"]"),s.Bb(2),s.Ac(" --- Discharge_m3_s: [",t.Discharge_m3_s,"]"),s.Bb(2),s.Ac(" --- DischargeEntered_m3_s: [",t.DischargeEntered_m3_s,"]"),s.Bb(3),s.Ac("Level_m: [",t.Level_m,"]"),s.Bb(2),s.Ac(" --- HourlyValues: [",t.HourlyValues,"]"),s.Bb(2),s.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),s.Bb(2),s.Ac(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function ct(t,e){if(1&t&&(s.Tb(0,"div"),s.xc(1,ot,47,18,"div",5),s.Sb()),2&t){const t=s.ec();s.Bb(1),s.jc("ngForOf",t.hydrometricdatavalueService.hydrometricdatavalueListModel$.getValue())}}const nt=[{path:"",component:(()=>{class t{constructor(t,e,a){this.hydrometricdatavalueService=t,this.router=e,this.httpClientService=a,this.showType=null,a.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.HydrometricDataValueID&&this.showType===n.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.HydrometricDataValueID&&this.showType===n.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.HydrometricDataValueID&&this.showType===n.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.HydrometricDataValueID,this.showType=n.a.Put)}ShowPost(t){this.IDToShow===t.HydrometricDataValueID&&this.showType===n.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.HydrometricDataValueID,this.showType=n.a.Post)}GetPutEnum(){return n.a.Put}GetPostEnum(){return n.a.Post}GetHydrometricDataValueList(){this.sub=this.hydrometricdatavalueService.GetHydrometricDataValueList().subscribe()}DeleteHydrometricDataValue(t){this.sub=this.hydrometricdatavalueService.DeleteHydrometricDataValue(t).subscribe()}GetStorageDataTypeEnumText(t){return Object(c.a)(t)}ngOnInit(){o(this.hydrometricdatavalueService.hydrometricdatavalueTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(s.Nb(p),s.Nb(i.b),s.Nb(h.a))},t.\u0275cmp=s.Hb({type:t,selectors:[["app-hydrometricdatavalue"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"hydrometricdatavalue","httpClientCommand"]],template:function(t,e){if(1&t&&(s.xc(0,et,1,0,"mat-progress-bar",0),s.Tb(1,"mat-card"),s.Tb(2,"mat-card-header"),s.Tb(3,"mat-card-title"),s.yc(4," HydrometricDataValue works! "),s.Tb(5,"button",1),s.ac("click",(function(){return e.GetHydrometricDataValueList()})),s.Tb(6,"span"),s.yc(7,"Get HydrometricDataValue"),s.Sb(),s.Sb(),s.Sb(),s.Tb(8,"mat-card-subtitle"),s.yc(9),s.Sb(),s.Sb(),s.Tb(10,"mat-card-content"),s.xc(11,ct,2,1,"div",2),s.Sb(),s.Tb(12,"mat-card-actions"),s.Tb(13,"button",3),s.yc(14,"Allo"),s.Sb(),s.Sb(),s.Sb()),2&t){var a;const t=null==(a=e.hydrometricdatavalueService.hydrometricdatavalueGetModel$.getValue())?null:a.Working;var r;const i=null==(r=e.hydrometricdatavalueService.hydrometricdatavalueListModel$.getValue())?null:r.length;s.jc("ngIf",t),s.Bb(9),s.zc(e.hydrometricdatavalueService.hydrometricdatavalueTextModel$.getValue().Title),s.Bb(2),s.jc("ngIf",i)}},directives:[r.l,y.a,y.d,y.g,f.b,y.f,y.c,y.b,S.a,r.k,T.a,tt],styles:[""],changeDetection:0}),t})(),canActivate:[a("auXs").a]}];let st=(()=>{class t{}return t.\u0275mod=s.Lb({type:t}),t.\u0275inj=s.Kb({factory:function(e){return new(e||t)},imports:[[i.e.forChild(nt)],i.e]}),t})();var bt=a("B+Mi");let lt=(()=>{class t{}return t.\u0275mod=s.Lb({type:t}),t.\u0275inj=s.Kb({factory:function(e){return new(e||t)},imports:[[r.c,i.e,st,bt.a,v.g,v.o]]}),t})()}}]);