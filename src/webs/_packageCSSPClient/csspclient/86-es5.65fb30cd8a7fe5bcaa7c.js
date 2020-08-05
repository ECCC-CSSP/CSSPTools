!function(){function t(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function e(t,e){for(var a=0;a<e.length;a++){var i=e[a];i.enumerable=i.enumerable||!1,i.configurable=!0,"value"in i&&(i.writable=!0),Object.defineProperty(t,i.key,i)}}function a(t,a,i){return a&&e(t.prototype,a),i&&e(t,i),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[86],{QRvi:function(t,e,a){"use strict";a.d(e,"a",(function(){return i}));var i=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(e,i,n){"use strict";n.d(i,"a",(function(){return u}));var r=n("QRvi"),o=n("fXoL"),c=n("tyNb"),u=function(){var e=function(){function e(a){t(this,e),this.router=a,this.oldURL=a.url}return a(e,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,e,a){t.next(null),e.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,e,a){t.next(null),e.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,e,a,i,n){if(i===r.a.Get&&t.next(a),i===r.a.Put&&(t.getValue()[0]=a),i===r.a.Post&&t.getValue().push(a),i===r.a.Delete){var o=t.getValue().indexOf(n);t.getValue().splice(o,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,e,a,i,n){i===r.a.Get&&t.next(a),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(o.Wb(c.b))},e.\u0275prov=o.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()},nTDO:function(e,i,n){"use strict";n.r(i),n.d(i,"TideDataValueModule",(function(){return Vt}));var r=n("ofXK"),o=n("tyNb");function c(t){var e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}function u(){var t=[];return $localize,t.push({EnumID:1,EnumText:"Min15"}),t.push({EnumID:2,EnumText:"Min60"}),t.sort((function(t,e){return t.EnumText.localeCompare(e.EnumText)}))}var b,l=n("qfes"),d=n("vdHS"),s=n("QRvi"),p=n("fXoL"),m=n("2Vo4"),f=n("LRne"),v=n("tk/3"),S=n("lJxs"),h=n("JIr8"),T=n("gkM4"),D=((b=function(){function e(a,i){t(this,e),this.httpClient=a,this.httpClientService=i,this.tidedatavalueTextModel$=new m.a({}),this.tidedatavalueListModel$=new m.a({}),this.tidedatavalueGetModel$=new m.a({}),this.tidedatavaluePutModel$=new m.a({}),this.tidedatavaluePostModel$=new m.a({}),this.tidedatavalueDeleteModel$=new m.a({}),c(this.tidedatavalueTextModel$),this.tidedatavalueTextModel$.next({Title:"Something2 for text"})}return a(e,[{key:"GetTideDataValueList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.tidedatavalueGetModel$),this.httpClient.get("/api/TideDataValue").pipe(Object(S.a)((function(e){t.httpClientService.DoSuccess(t.tidedatavalueListModel$,t.tidedatavalueGetModel$,e,s.a.Get,null)})),Object(h.a)((function(e){return Object(f.a)(e).pipe(Object(S.a)((function(e){t.httpClientService.DoCatchError(t.tidedatavalueListModel$,t.tidedatavalueGetModel$,e)})))})))}},{key:"PutTideDataValue",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.tidedatavaluePutModel$),this.httpClient.put("/api/TideDataValue",t,{headers:new v.d}).pipe(Object(S.a)((function(a){e.httpClientService.DoSuccess(e.tidedatavalueListModel$,e.tidedatavaluePutModel$,a,s.a.Put,t)})),Object(h.a)((function(t){return Object(f.a)(t).pipe(Object(S.a)((function(t){e.httpClientService.DoCatchError(e.tidedatavalueListModel$,e.tidedatavaluePutModel$,t)})))})))}},{key:"PostTideDataValue",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.tidedatavaluePostModel$),this.httpClient.post("/api/TideDataValue",t,{headers:new v.d}).pipe(Object(S.a)((function(a){e.httpClientService.DoSuccess(e.tidedatavalueListModel$,e.tidedatavaluePostModel$,a,s.a.Post,t)})),Object(h.a)((function(t){return Object(f.a)(t).pipe(Object(S.a)((function(t){e.httpClientService.DoCatchError(e.tidedatavalueListModel$,e.tidedatavaluePostModel$,t)})))})))}},{key:"DeleteTideDataValue",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.tidedatavalueDeleteModel$),this.httpClient.delete("/api/TideDataValue/"+t.TideDataValueID).pipe(Object(S.a)((function(a){e.httpClientService.DoSuccess(e.tidedatavalueListModel$,e.tidedatavalueDeleteModel$,a,s.a.Delete,t)})),Object(h.a)((function(t){return Object(f.a)(t).pipe(Object(S.a)((function(t){e.httpClientService.DoCatchError(e.tidedatavalueListModel$,e.tidedatavalueDeleteModel$,t)})))})))}}]),e}()).\u0275fac=function(t){return new(t||b)(p.Wb(v.b),p.Wb(T.a))},b.\u0275prov=p.Ib({token:b,factory:b.\u0275fac,providedIn:"root"}),b),y=n("Wp6s"),R=n("bTqV"),I=n("bv9b"),g=n("NFeN"),B=n("3Pt+"),V=n("kmnG"),C=n("qFsG"),z=n("d3UM"),E=n("FKr1");function k(t,e){1&t&&p.Nb(0,"mat-progress-bar",18)}function N(t,e){1&t&&p.Nb(0,"mat-progress-bar",18)}function $(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function P(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,$,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,2,a)),p.Bb(3),p.ic("ngIf",a.required)}}function M(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function L(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,M,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,2,a)),p.Bb(3),p.ic("ngIf",a.required)}}function w(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function x(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,w,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,2,a)),p.Bb(3),p.ic("ngIf",a.required)}}function _(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function G(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,_,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,2,a)),p.Bb(3),p.ic("ngIf",a.required)}}function q(t,e){if(1&t&&(p.Sb(0,"mat-option",19),p.zc(1),p.Rb()),2&t){var a=e.$implicit;p.ic("value",a.EnumID),p.Bb(1),p.Bc(" ",a.EnumText," ")}}function j(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function O(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,j,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,2,a)),p.Bb(3),p.ic("ngIf",a.required)}}function F(t,e){if(1&t&&(p.Sb(0,"mat-option",19),p.zc(1),p.Rb()),2&t){var a=e.$implicit;p.ic("value",a.EnumID),p.Bb(1),p.Bc(" ",a.EnumText," ")}}function U(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function A(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,U,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,2,a)),p.Bb(3),p.ic("ngIf",a.required)}}function W(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function K(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Min - 0"),p.Nb(2,"br"),p.Rb())}function H(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Max - 10000"),p.Nb(2,"br"),p.Rb())}function J(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,W,3,0,"span",4),p.yc(6,K,3,0,"span",4),p.yc(7,H,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,4,a)),p.Bb(3),p.ic("ngIf",a.required),p.Bb(1),p.ic("ngIf",a.min),p.Bb(1),p.ic("ngIf",a.min)}}function Z(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function X(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Min - 0"),p.Nb(2,"br"),p.Rb())}function Q(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Max - 10"),p.Nb(2,"br"),p.Rb())}function Y(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,Z,3,0,"span",4),p.yc(6,X,3,0,"span",4),p.yc(7,Q,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,4,a)),p.Bb(3),p.ic("ngIf",a.required),p.Bb(1),p.ic("ngIf",a.min),p.Bb(1),p.ic("ngIf",a.min)}}function tt(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function et(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Min - 0"),p.Nb(2,"br"),p.Rb())}function at(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Max - 10"),p.Nb(2,"br"),p.Rb())}function it(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,tt,3,0,"span",4),p.yc(6,et,3,0,"span",4),p.yc(7,at,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,4,a)),p.Bb(3),p.ic("ngIf",a.required),p.Bb(1),p.ic("ngIf",a.min),p.Bb(1),p.ic("ngIf",a.min)}}function nt(t,e){if(1&t&&(p.Sb(0,"mat-option",19),p.zc(1),p.Rb()),2&t){var a=e.$implicit;p.ic("value",a.EnumID),p.Bb(1),p.Bc(" ",a.EnumText," ")}}function rt(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,1,a))}}function ot(t,e){if(1&t&&(p.Sb(0,"mat-option",19),p.zc(1),p.Rb()),2&t){var a=e.$implicit;p.ic("value",a.EnumID),p.Bb(1),p.Bc(" ",a.EnumText," ")}}function ct(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,1,a))}}function ut(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function bt(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,ut,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,2,a)),p.Bb(3),p.ic("ngIf",a.required)}}function lt(t,e){1&t&&(p.Sb(0,"span"),p.zc(1,"Is Required"),p.Nb(2,"br"),p.Rb())}function dt(t,e){if(1&t&&(p.Sb(0,"mat-error"),p.Sb(1,"span"),p.zc(2),p.ec(3,"json"),p.Nb(4,"br"),p.Rb(),p.yc(5,lt,3,0,"span",4),p.Rb()),2&t){var a=e.$implicit;p.Bb(2),p.Ac(p.fc(3,2,a)),p.Bb(3),p.ic("ngIf",a.required)}}var st,pt=((st=function(){function e(a,i){t(this,e),this.tidedatavalueService=a,this.fb=i,this.tidedatavalue=null,this.httpClientCommand=s.a.Put}return a(e,[{key:"GetPut",value:function(){return this.httpClientCommand==s.a.Put}},{key:"PutTideDataValue",value:function(t){this.sub=this.tidedatavalueService.PutTideDataValue(t).subscribe()}},{key:"PostTideDataValue",value:function(t){this.sub=this.tidedatavalueService.PostTideDataValue(t).subscribe()}},{key:"ngOnInit",value:function(){this.tideDataTypeList=u(),this.storageDataTypeList=Object(l.b)(),this.tideStartList=Object(d.b)(),this.tideEndList=Object(d.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.tidedatavalue){var e=this.fb.group({TideDataValueID:[{value:t===s.a.Post?0:this.tidedatavalue.TideDataValueID,disabled:!1},[B.p.required]],TideSiteTVItemID:[{value:this.tidedatavalue.TideSiteTVItemID,disabled:!1},[B.p.required]],DateTime_Local:[{value:this.tidedatavalue.DateTime_Local,disabled:!1},[B.p.required]],Keep:[{value:this.tidedatavalue.Keep,disabled:!1},[B.p.required]],TideDataType:[{value:this.tidedatavalue.TideDataType,disabled:!1},[B.p.required]],StorageDataType:[{value:this.tidedatavalue.StorageDataType,disabled:!1},[B.p.required]],Depth_m:[{value:this.tidedatavalue.Depth_m,disabled:!1},[B.p.required,B.p.min(0),B.p.max(1e4)]],UVelocity_m_s:[{value:this.tidedatavalue.UVelocity_m_s,disabled:!1},[B.p.required,B.p.min(0),B.p.max(10)]],VVelocity_m_s:[{value:this.tidedatavalue.VVelocity_m_s,disabled:!1},[B.p.required,B.p.min(0),B.p.max(10)]],TideStart:[{value:this.tidedatavalue.TideStart,disabled:!1}],TideEnd:[{value:this.tidedatavalue.TideEnd,disabled:!1}],LastUpdateDate_UTC:[{value:this.tidedatavalue.LastUpdateDate_UTC,disabled:!1},[B.p.required]],LastUpdateContactTVItemID:[{value:this.tidedatavalue.LastUpdateContactTVItemID,disabled:!1},[B.p.required]]});this.tidedatavalueFormEdit=e}}}]),e}()).\u0275fac=function(t){return new(t||st)(p.Mb(D),p.Mb(B.d))},st.\u0275cmp=p.Gb({type:st,selectors:[["app-tidedatavalue-edit"]],inputs:{tidedatavalue:"tidedatavalue",httpClientCommand:"httpClientCommand"},decls:81,vars:21,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TideDataValueID"],[4,"ngIf"],["matInput","","type","number","formControlName","TideSiteTVItemID"],["matInput","","type","text","formControlName","DateTime_Local"],["matInput","","type","text","formControlName","Keep"],["formControlName","TideDataType"],[3,"value",4,"ngFor","ngForOf"],["formControlName","StorageDataType"],["matInput","","type","number","formControlName","Depth_m"],["matInput","","type","number","formControlName","UVelocity_m_s"],["matInput","","type","number","formControlName","VVelocity_m_s"],["formControlName","TideStart"],["formControlName","TideEnd"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(p.Sb(0,"form",0),p.Zb("ngSubmit",(function(){return e.GetPut()?e.PutTideDataValue(e.tidedatavalueFormEdit.value):e.PostTideDataValue(e.tidedatavalueFormEdit.value)})),p.Sb(1,"h3"),p.zc(2," TideDataValue "),p.Sb(3,"button",1),p.Sb(4,"span"),p.zc(5),p.Rb(),p.Rb(),p.yc(6,k,1,0,"mat-progress-bar",2),p.yc(7,N,1,0,"mat-progress-bar",2),p.Rb(),p.Sb(8,"p"),p.Sb(9,"mat-form-field"),p.Sb(10,"mat-label"),p.zc(11,"TideDataValueID"),p.Rb(),p.Nb(12,"input",3),p.yc(13,P,6,4,"mat-error",4),p.Rb(),p.Sb(14,"mat-form-field"),p.Sb(15,"mat-label"),p.zc(16,"TideSiteTVItemID"),p.Rb(),p.Nb(17,"input",5),p.yc(18,L,6,4,"mat-error",4),p.Rb(),p.Sb(19,"mat-form-field"),p.Sb(20,"mat-label"),p.zc(21,"DateTime_Local"),p.Rb(),p.Nb(22,"input",6),p.yc(23,x,6,4,"mat-error",4),p.Rb(),p.Sb(24,"mat-form-field"),p.Sb(25,"mat-label"),p.zc(26,"Keep"),p.Rb(),p.Nb(27,"input",7),p.yc(28,G,6,4,"mat-error",4),p.Rb(),p.Rb(),p.Sb(29,"p"),p.Sb(30,"mat-form-field"),p.Sb(31,"mat-label"),p.zc(32,"TideDataType"),p.Rb(),p.Sb(33,"mat-select",8),p.yc(34,q,2,2,"mat-option",9),p.Rb(),p.yc(35,O,6,4,"mat-error",4),p.Rb(),p.Sb(36,"mat-form-field"),p.Sb(37,"mat-label"),p.zc(38,"StorageDataType"),p.Rb(),p.Sb(39,"mat-select",10),p.yc(40,F,2,2,"mat-option",9),p.Rb(),p.yc(41,A,6,4,"mat-error",4),p.Rb(),p.Sb(42,"mat-form-field"),p.Sb(43,"mat-label"),p.zc(44,"Depth_m"),p.Rb(),p.Nb(45,"input",11),p.yc(46,J,8,6,"mat-error",4),p.Rb(),p.Sb(47,"mat-form-field"),p.Sb(48,"mat-label"),p.zc(49,"UVelocity_m_s"),p.Rb(),p.Nb(50,"input",12),p.yc(51,Y,8,6,"mat-error",4),p.Rb(),p.Rb(),p.Sb(52,"p"),p.Sb(53,"mat-form-field"),p.Sb(54,"mat-label"),p.zc(55,"VVelocity_m_s"),p.Rb(),p.Nb(56,"input",13),p.yc(57,it,8,6,"mat-error",4),p.Rb(),p.Sb(58,"mat-form-field"),p.Sb(59,"mat-label"),p.zc(60,"TideStart"),p.Rb(),p.Sb(61,"mat-select",14),p.yc(62,nt,2,2,"mat-option",9),p.Rb(),p.yc(63,rt,5,3,"mat-error",4),p.Rb(),p.Sb(64,"mat-form-field"),p.Sb(65,"mat-label"),p.zc(66,"TideEnd"),p.Rb(),p.Sb(67,"mat-select",15),p.yc(68,ot,2,2,"mat-option",9),p.Rb(),p.yc(69,ct,5,3,"mat-error",4),p.Rb(),p.Sb(70,"mat-form-field"),p.Sb(71,"mat-label"),p.zc(72,"LastUpdateDate_UTC"),p.Rb(),p.Nb(73,"input",16),p.yc(74,bt,6,4,"mat-error",4),p.Rb(),p.Rb(),p.Sb(75,"p"),p.Sb(76,"mat-form-field"),p.Sb(77,"mat-label"),p.zc(78,"LastUpdateContactTVItemID"),p.Rb(),p.Nb(79,"input",17),p.yc(80,dt,6,4,"mat-error",4),p.Rb(),p.Rb(),p.Rb()),2&t&&(p.ic("formGroup",e.tidedatavalueFormEdit),p.Bb(5),p.Bc("",e.GetPut()?"Put":"Post"," TideDataValue"),p.Bb(1),p.ic("ngIf",e.tidedatavalueService.tidedatavaluePutModel$.getValue().Working),p.Bb(1),p.ic("ngIf",e.tidedatavalueService.tidedatavaluePostModel$.getValue().Working),p.Bb(6),p.ic("ngIf",e.tidedatavalueFormEdit.controls.TideDataValueID.errors),p.Bb(5),p.ic("ngIf",e.tidedatavalueFormEdit.controls.TideSiteTVItemID.errors),p.Bb(5),p.ic("ngIf",e.tidedatavalueFormEdit.controls.DateTime_Local.errors),p.Bb(5),p.ic("ngIf",e.tidedatavalueFormEdit.controls.Keep.errors),p.Bb(6),p.ic("ngForOf",e.tideDataTypeList),p.Bb(1),p.ic("ngIf",e.tidedatavalueFormEdit.controls.TideDataType.errors),p.Bb(5),p.ic("ngForOf",e.storageDataTypeList),p.Bb(1),p.ic("ngIf",e.tidedatavalueFormEdit.controls.StorageDataType.errors),p.Bb(5),p.ic("ngIf",e.tidedatavalueFormEdit.controls.Depth_m.errors),p.Bb(5),p.ic("ngIf",e.tidedatavalueFormEdit.controls.UVelocity_m_s.errors),p.Bb(6),p.ic("ngIf",e.tidedatavalueFormEdit.controls.VVelocity_m_s.errors),p.Bb(5),p.ic("ngForOf",e.tideStartList),p.Bb(1),p.ic("ngIf",e.tidedatavalueFormEdit.controls.TideStart.errors),p.Bb(5),p.ic("ngForOf",e.tideEndList),p.Bb(1),p.ic("ngIf",e.tidedatavalueFormEdit.controls.TideEnd.errors),p.Bb(5),p.ic("ngIf",e.tidedatavalueFormEdit.controls.LastUpdateDate_UTC.errors),p.Bb(6),p.ic("ngIf",e.tidedatavalueFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[B.q,B.l,B.f,R.b,r.l,V.c,V.f,C.b,B.n,B.c,B.k,B.e,z.a,r.k,I.a,V.b,E.n],pipes:[r.f],styles:[""],changeDetection:0}),st);function mt(t,e){1&t&&p.Nb(0,"mat-progress-bar",4)}function ft(t,e){1&t&&p.Nb(0,"mat-progress-bar",4)}function vt(t,e){if(1&t&&(p.Sb(0,"p"),p.Nb(1,"app-tidedatavalue-edit",8),p.Rb()),2&t){var a=p.dc().$implicit,i=p.dc(2);p.Bb(1),p.ic("tidedatavalue",a)("httpClientCommand",i.GetPutEnum())}}function St(t,e){if(1&t&&(p.Sb(0,"p"),p.Nb(1,"app-tidedatavalue-edit",8),p.Rb()),2&t){var a=p.dc().$implicit,i=p.dc(2);p.Bb(1),p.ic("tidedatavalue",a)("httpClientCommand",i.GetPostEnum())}}function ht(t,e){if(1&t){var a=p.Tb();p.Sb(0,"div"),p.Sb(1,"p"),p.Sb(2,"button",6),p.Zb("click",(function(){p.qc(a);var t=e.$implicit;return p.dc(2).DeleteTideDataValue(t)})),p.Sb(3,"span"),p.zc(4),p.Rb(),p.Sb(5,"mat-icon"),p.zc(6,"delete"),p.Rb(),p.Rb(),p.zc(7,"\xa0\xa0\xa0 "),p.Sb(8,"button",7),p.Zb("click",(function(){p.qc(a);var t=e.$implicit;return p.dc(2).ShowPut(t)})),p.Sb(9,"span"),p.zc(10,"Show Put"),p.Rb(),p.Rb(),p.zc(11,"\xa0\xa0 "),p.Sb(12,"button",7),p.Zb("click",(function(){p.qc(a);var t=e.$implicit;return p.dc(2).ShowPost(t)})),p.Sb(13,"span"),p.zc(14,"Show Post"),p.Rb(),p.Rb(),p.zc(15,"\xa0\xa0 "),p.yc(16,ft,1,0,"mat-progress-bar",0),p.Rb(),p.yc(17,vt,2,2,"p",2),p.yc(18,St,2,2,"p",2),p.Sb(19,"blockquote"),p.Sb(20,"p"),p.Sb(21,"span"),p.zc(22),p.Rb(),p.Sb(23,"span"),p.zc(24),p.Rb(),p.Sb(25,"span"),p.zc(26),p.Rb(),p.Sb(27,"span"),p.zc(28),p.Rb(),p.Rb(),p.Sb(29,"p"),p.Sb(30,"span"),p.zc(31),p.Rb(),p.Sb(32,"span"),p.zc(33),p.Rb(),p.Sb(34,"span"),p.zc(35),p.Rb(),p.Sb(36,"span"),p.zc(37),p.Rb(),p.Rb(),p.Sb(38,"p"),p.Sb(39,"span"),p.zc(40),p.Rb(),p.Sb(41,"span"),p.zc(42),p.Rb(),p.Sb(43,"span"),p.zc(44),p.Rb(),p.Sb(45,"span"),p.zc(46),p.Rb(),p.Rb(),p.Sb(47,"p"),p.Sb(48,"span"),p.zc(49),p.Rb(),p.Rb(),p.Rb(),p.Rb()}if(2&t){var i=e.$implicit,n=p.dc(2);p.Bb(4),p.Bc("Delete TideDataValueID [",i.TideDataValueID,"]\xa0\xa0\xa0"),p.Bb(4),p.ic("color",n.GetPutButtonColor(i)),p.Bb(4),p.ic("color",n.GetPostButtonColor(i)),p.Bb(4),p.ic("ngIf",n.tidedatavalueService.tidedatavalueDeleteModel$.getValue().Working),p.Bb(1),p.ic("ngIf",n.IDToShow===i.TideDataValueID&&n.showType===n.GetPutEnum()),p.Bb(1),p.ic("ngIf",n.IDToShow===i.TideDataValueID&&n.showType===n.GetPostEnum()),p.Bb(4),p.Bc("TideDataValueID: [",i.TideDataValueID,"]"),p.Bb(2),p.Bc(" --- TideSiteTVItemID: [",i.TideSiteTVItemID,"]"),p.Bb(2),p.Bc(" --- DateTime_Local: [",i.DateTime_Local,"]"),p.Bb(2),p.Bc(" --- Keep: [",i.Keep,"]"),p.Bb(3),p.Bc("TideDataType: [",n.GetTideDataTypeEnumText(i.TideDataType),"]"),p.Bb(2),p.Bc(" --- StorageDataType: [",n.GetStorageDataTypeEnumText(i.StorageDataType),"]"),p.Bb(2),p.Bc(" --- Depth_m: [",i.Depth_m,"]"),p.Bb(2),p.Bc(" --- UVelocity_m_s: [",i.UVelocity_m_s,"]"),p.Bb(3),p.Bc("VVelocity_m_s: [",i.VVelocity_m_s,"]"),p.Bb(2),p.Bc(" --- TideStart: [",n.GetTideTextEnumText(i.TideStart),"]"),p.Bb(2),p.Bc(" --- TideEnd: [",n.GetTideTextEnumText(i.TideEnd),"]"),p.Bb(2),p.Bc(" --- LastUpdateDate_UTC: [",i.LastUpdateDate_UTC,"]"),p.Bb(3),p.Bc("LastUpdateContactTVItemID: [",i.LastUpdateContactTVItemID,"]")}}function Tt(t,e){if(1&t&&(p.Sb(0,"div"),p.yc(1,ht,50,19,"div",5),p.Rb()),2&t){var a=p.dc();p.Bb(1),p.ic("ngForOf",a.tidedatavalueService.tidedatavalueListModel$.getValue())}}var Dt,yt,Rt,It=[{path:"",component:(Dt=function(){function e(a,i,n){t(this,e),this.tidedatavalueService=a,this.router=i,this.httpClientService=n,this.showType=null,n.oldURL=i.url}return a(e,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.TideDataValueID&&this.showType===s.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.TideDataValueID&&this.showType===s.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.TideDataValueID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TideDataValueID,this.showType=s.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.TideDataValueID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TideDataValueID,this.showType=s.a.Post)}},{key:"GetPutEnum",value:function(){return s.a.Put}},{key:"GetPostEnum",value:function(){return s.a.Post}},{key:"GetTideDataValueList",value:function(){this.sub=this.tidedatavalueService.GetTideDataValueList().subscribe()}},{key:"DeleteTideDataValue",value:function(t){this.sub=this.tidedatavalueService.DeleteTideDataValue(t).subscribe()}},{key:"GetTideDataTypeEnumText",value:function(t){return function(t){var e;return u().forEach((function(a){if(a.EnumID==t)return e=a.EnumText,!1})),e}(t)}},{key:"GetStorageDataTypeEnumText",value:function(t){return Object(l.a)(t)}},{key:"GetTideTextEnumText",value:function(t){return Object(d.a)(t)}},{key:"ngOnInit",value:function(){c(this.tidedatavalueService.tidedatavalueTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),e}(),Dt.\u0275fac=function(t){return new(t||Dt)(p.Mb(D),p.Mb(o.b),p.Mb(T.a))},Dt.\u0275cmp=p.Gb({type:Dt,selectors:[["app-tidedatavalue"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tidedatavalue","httpClientCommand"]],template:function(t,e){if(1&t&&(p.yc(0,mt,1,0,"mat-progress-bar",0),p.Sb(1,"mat-card"),p.Sb(2,"mat-card-header"),p.Sb(3,"mat-card-title"),p.zc(4," TideDataValue works! "),p.Sb(5,"button",1),p.Zb("click",(function(){return e.GetTideDataValueList()})),p.Sb(6,"span"),p.zc(7,"Get TideDataValue"),p.Rb(),p.Rb(),p.Rb(),p.Sb(8,"mat-card-subtitle"),p.zc(9),p.Rb(),p.Rb(),p.Sb(10,"mat-card-content"),p.yc(11,Tt,2,1,"div",2),p.Rb(),p.Sb(12,"mat-card-actions"),p.Sb(13,"button",3),p.zc(14,"Allo"),p.Rb(),p.Rb(),p.Rb()),2&t){var a,i,n=null==(a=e.tidedatavalueService.tidedatavalueGetModel$.getValue())?null:a.Working,r=null==(i=e.tidedatavalueService.tidedatavalueListModel$.getValue())?null:i.length;p.ic("ngIf",n),p.Bb(9),p.Ac(e.tidedatavalueService.tidedatavalueTextModel$.getValue().Title),p.Bb(2),p.ic("ngIf",r)}},directives:[r.l,y.a,y.d,y.g,R.b,y.f,y.c,y.b,I.a,r.k,g.a,pt],styles:[""],changeDetection:0}),Dt),canActivate:[n("auXs").a]}],gt=((yt=function e(){t(this,e)}).\u0275mod=p.Kb({type:yt}),yt.\u0275inj=p.Jb({factory:function(t){return new(t||yt)},imports:[[o.e.forChild(It)],o.e]}),yt),Bt=n("B+Mi"),Vt=((Rt=function e(){t(this,e)}).\u0275mod=p.Kb({type:Rt}),Rt.\u0275inj=p.Jb({factory:function(t){return new(t||Rt)},imports:[[r.c,o.e,gt,Bt.a,B.g,B.o]]}),Rt)}}])}();