function _classCallCheck(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function _defineProperties(t,e){for(var a=0;a<e.length;a++){var i=e[a];i.enumerable=i.enumerable||!1,i.configurable=!0,"value"in i&&(i.writable=!0),Object.defineProperty(t,i.key,i)}}function _createClass(t,e,a){return e&&_defineProperties(t.prototype,e),a&&_defineProperties(t,a),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[85],{QRvi:function(t,e,a){"use strict";a.d(e,"a",(function(){return i}));var i=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,a){"use strict";a.d(e,"a",(function(){return o}));var i=a("QRvi"),n=a("fXoL"),r=a("tyNb"),o=function(){var t=function(){function t(e){_classCallCheck(this,t),this.router=e,this.oldURL=e.url}return _createClass(t,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,e,a){t.next(null),e.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,e,a){t.next(null),e.next({Working:!1,Error:a,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,e,a,n,r){if(n===i.a.Get&&t.next(a),n===i.a.Put&&(t.getValue()[0]=a),n===i.a.Post&&t.getValue().push(a),n===i.a.Delete){var o=t.getValue().indexOf(r);t.getValue().splice(o,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,e,a,n,r){n===i.a.Get&&t.next(a),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),t}();return t.\u0275fac=function(e){return new(e||t)(n.Xb(r.b))},t.\u0275prov=n.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t}()},nTDO:function(t,e,a){"use strict";a.r(e),a.d(e,"TideDataValueModule",(function(){return Ct}));var i=a("ofXK"),n=a("tyNb");function r(t){var e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}function o(){var t=[];return $localize,t.push({EnumID:1,EnumText:"Min15"}),t.push({EnumID:2,EnumText:"Min60"}),t.sort((function(t,e){return t.EnumText.localeCompare(e.EnumText)}))}var c,u=a("qfes"),l=a("vdHS"),b=a("QRvi"),d=a("fXoL"),s=a("2Vo4"),p=a("LRne"),m=a("tk/3"),T=a("lJxs"),f=a("JIr8"),v=a("gkM4"),S=((c=function(){function t(e,a){_classCallCheck(this,t),this.httpClient=e,this.httpClientService=a,this.tidedatavalueTextModel$=new s.a({}),this.tidedatavalueListModel$=new s.a({}),this.tidedatavalueGetModel$=new s.a({}),this.tidedatavaluePutModel$=new s.a({}),this.tidedatavaluePostModel$=new s.a({}),this.tidedatavalueDeleteModel$=new s.a({}),r(this.tidedatavalueTextModel$),this.tidedatavalueTextModel$.next({Title:"Something2 for text"})}return _createClass(t,[{key:"GetTideDataValueList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.tidedatavalueGetModel$),this.httpClient.get("/api/TideDataValue").pipe(Object(T.a)((function(e){t.httpClientService.DoSuccess(t.tidedatavalueListModel$,t.tidedatavalueGetModel$,e,b.a.Get,null)})),Object(f.a)((function(e){return Object(p.a)(e).pipe(Object(T.a)((function(e){t.httpClientService.DoCatchError(t.tidedatavalueListModel$,t.tidedatavalueGetModel$,e)})))})))}},{key:"PutTideDataValue",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.tidedatavaluePutModel$),this.httpClient.put("/api/TideDataValue",t,{headers:new m.d}).pipe(Object(T.a)((function(a){e.httpClientService.DoSuccess(e.tidedatavalueListModel$,e.tidedatavaluePutModel$,a,b.a.Put,t)})),Object(f.a)((function(t){return Object(p.a)(t).pipe(Object(T.a)((function(t){e.httpClientService.DoCatchError(e.tidedatavalueListModel$,e.tidedatavaluePutModel$,t)})))})))}},{key:"PostTideDataValue",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.tidedatavaluePostModel$),this.httpClient.post("/api/TideDataValue",t,{headers:new m.d}).pipe(Object(T.a)((function(a){e.httpClientService.DoSuccess(e.tidedatavalueListModel$,e.tidedatavaluePostModel$,a,b.a.Post,t)})),Object(f.a)((function(t){return Object(p.a)(t).pipe(Object(T.a)((function(t){e.httpClientService.DoCatchError(e.tidedatavalueListModel$,e.tidedatavaluePostModel$,t)})))})))}},{key:"DeleteTideDataValue",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.tidedatavalueDeleteModel$),this.httpClient.delete("/api/TideDataValue/"+t.TideDataValueID).pipe(Object(T.a)((function(a){e.httpClientService.DoSuccess(e.tidedatavalueListModel$,e.tidedatavalueDeleteModel$,a,b.a.Delete,t)})),Object(f.a)((function(t){return Object(p.a)(t).pipe(Object(T.a)((function(t){e.httpClientService.DoCatchError(e.tidedatavalueListModel$,e.tidedatavalueDeleteModel$,t)})))})))}}]),t}()).\u0275fac=function(t){return new(t||c)(d.Xb(m.b),d.Xb(v.a))},c.\u0275prov=d.Jb({token:c,factory:c.\u0275fac,providedIn:"root"}),c),h=a("Wp6s"),y=a("bTqV"),D=a("bv9b"),I=a("NFeN"),g=a("3Pt+"),C=a("kmnG"),V=a("qFsG"),x=a("d3UM"),B=a("FKr1");function j(t,e){1&t&&d.Ob(0,"mat-progress-bar",18)}function O(t,e){1&t&&d.Ob(0,"mat-progress-bar",18)}function E(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function k(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,E,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,2,a)),d.Bb(3),d.jc("ngIf",a.required)}}function _(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function P(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,_,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,2,a)),d.Bb(3),d.jc("ngIf",a.required)}}function $(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function L(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,$,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,2,a)),d.Bb(3),d.jc("ngIf",a.required)}}function w(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function M(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,w,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,2,a)),d.Bb(3),d.jc("ngIf",a.required)}}function G(t,e){if(1&t&&(d.Tb(0,"mat-option",19),d.yc(1),d.Sb()),2&t){var a=e.$implicit;d.jc("value",a.EnumID),d.Bb(1),d.Ac(" ",a.EnumText," ")}}function q(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function U(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,q,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,2,a)),d.Bb(3),d.jc("ngIf",a.required)}}function F(t,e){if(1&t&&(d.Tb(0,"mat-option",19),d.yc(1),d.Sb()),2&t){var a=e.$implicit;d.jc("value",a.EnumID),d.Bb(1),d.Ac(" ",a.EnumText," ")}}function R(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function A(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,R,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,2,a)),d.Bb(3),d.jc("ngIf",a.required)}}function N(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function z(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Min - 0"),d.Ob(2,"br"),d.Sb())}function K(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Max - 10000"),d.Ob(2,"br"),d.Sb())}function W(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,N,3,0,"span",4),d.xc(6,z,3,0,"span",4),d.xc(7,K,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,4,a)),d.Bb(3),d.jc("ngIf",a.required),d.Bb(1),d.jc("ngIf",a.min),d.Bb(1),d.jc("ngIf",a.min)}}function H(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function X(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Min - 0"),d.Ob(2,"br"),d.Sb())}function J(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Max - 10"),d.Ob(2,"br"),d.Sb())}function Q(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,H,3,0,"span",4),d.xc(6,X,3,0,"span",4),d.xc(7,J,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,4,a)),d.Bb(3),d.jc("ngIf",a.required),d.Bb(1),d.jc("ngIf",a.min),d.Bb(1),d.jc("ngIf",a.min)}}function Y(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function Z(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Min - 0"),d.Ob(2,"br"),d.Sb())}function tt(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Max - 10"),d.Ob(2,"br"),d.Sb())}function et(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,Y,3,0,"span",4),d.xc(6,Z,3,0,"span",4),d.xc(7,tt,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,4,a)),d.Bb(3),d.jc("ngIf",a.required),d.Bb(1),d.jc("ngIf",a.min),d.Bb(1),d.jc("ngIf",a.min)}}function at(t,e){if(1&t&&(d.Tb(0,"mat-option",19),d.yc(1),d.Sb()),2&t){var a=e.$implicit;d.jc("value",a.EnumID),d.Bb(1),d.Ac(" ",a.EnumText," ")}}function it(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,1,a))}}function nt(t,e){if(1&t&&(d.Tb(0,"mat-option",19),d.yc(1),d.Sb()),2&t){var a=e.$implicit;d.jc("value",a.EnumID),d.Bb(1),d.Ac(" ",a.EnumText," ")}}function rt(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,1,a))}}function ot(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function ct(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,ot,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,2,a)),d.Bb(3),d.jc("ngIf",a.required)}}function ut(t,e){1&t&&(d.Tb(0,"span"),d.yc(1,"Is Required"),d.Ob(2,"br"),d.Sb())}function lt(t,e){if(1&t&&(d.Tb(0,"mat-error"),d.Tb(1,"span"),d.yc(2),d.fc(3,"json"),d.Ob(4,"br"),d.Sb(),d.xc(5,ut,3,0,"span",4),d.Sb()),2&t){var a=e.$implicit;d.Bb(2),d.zc(d.gc(3,2,a)),d.Bb(3),d.jc("ngIf",a.required)}}var bt,dt=((bt=function(){function t(e,a){_classCallCheck(this,t),this.tidedatavalueService=e,this.fb=a,this.tidedatavalue=null,this.httpClientCommand=b.a.Put}return _createClass(t,[{key:"GetPut",value:function(){return this.httpClientCommand==b.a.Put}},{key:"PutTideDataValue",value:function(t){this.sub=this.tidedatavalueService.PutTideDataValue(t).subscribe()}},{key:"PostTideDataValue",value:function(t){this.sub=this.tidedatavalueService.PostTideDataValue(t).subscribe()}},{key:"ngOnInit",value:function(){this.tideDataTypeList=o(),this.storageDataTypeList=Object(u.b)(),this.tideStartList=Object(l.b)(),this.tideEndList=Object(l.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.tidedatavalue){var e=this.fb.group({TideDataValueID:[{value:t===b.a.Post?0:this.tidedatavalue.TideDataValueID,disabled:!1},[g.p.required]],TideSiteTVItemID:[{value:this.tidedatavalue.TideSiteTVItemID,disabled:!1},[g.p.required]],DateTime_Local:[{value:this.tidedatavalue.DateTime_Local,disabled:!1},[g.p.required]],Keep:[{value:this.tidedatavalue.Keep,disabled:!1},[g.p.required]],TideDataType:[{value:this.tidedatavalue.TideDataType,disabled:!1},[g.p.required]],StorageDataType:[{value:this.tidedatavalue.StorageDataType,disabled:!1},[g.p.required]],Depth_m:[{value:this.tidedatavalue.Depth_m,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e4)]],UVelocity_m_s:[{value:this.tidedatavalue.UVelocity_m_s,disabled:!1},[g.p.required,g.p.min(0),g.p.max(10)]],VVelocity_m_s:[{value:this.tidedatavalue.VVelocity_m_s,disabled:!1},[g.p.required,g.p.min(0),g.p.max(10)]],TideStart:[{value:this.tidedatavalue.TideStart,disabled:!1}],TideEnd:[{value:this.tidedatavalue.TideEnd,disabled:!1}],LastUpdateDate_UTC:[{value:this.tidedatavalue.LastUpdateDate_UTC,disabled:!1},[g.p.required]],LastUpdateContactTVItemID:[{value:this.tidedatavalue.LastUpdateContactTVItemID,disabled:!1},[g.p.required]]});this.tidedatavalueFormEdit=e}}}]),t}()).\u0275fac=function(t){return new(t||bt)(d.Nb(S),d.Nb(g.d))},bt.\u0275cmp=d.Hb({type:bt,selectors:[["app-tidedatavalue-edit"]],inputs:{tidedatavalue:"tidedatavalue",httpClientCommand:"httpClientCommand"},decls:81,vars:21,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TideDataValueID"],[4,"ngIf"],["matInput","","type","number","formControlName","TideSiteTVItemID"],["matInput","","type","text","formControlName","DateTime_Local"],["matInput","","type","text","formControlName","Keep"],["formControlName","TideDataType"],[3,"value",4,"ngFor","ngForOf"],["formControlName","StorageDataType"],["matInput","","type","number","formControlName","Depth_m"],["matInput","","type","number","formControlName","UVelocity_m_s"],["matInput","","type","number","formControlName","VVelocity_m_s"],["formControlName","TideStart"],["formControlName","TideEnd"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(d.Tb(0,"form",0),d.ac("ngSubmit",(function(){return e.GetPut()?e.PutTideDataValue(e.tidedatavalueFormEdit.value):e.PostTideDataValue(e.tidedatavalueFormEdit.value)})),d.Tb(1,"h3"),d.yc(2," TideDataValue "),d.Tb(3,"button",1),d.Tb(4,"span"),d.yc(5),d.Sb(),d.Sb(),d.xc(6,j,1,0,"mat-progress-bar",2),d.xc(7,O,1,0,"mat-progress-bar",2),d.Sb(),d.Tb(8,"p"),d.Tb(9,"mat-form-field"),d.Tb(10,"mat-label"),d.yc(11,"TideDataValueID"),d.Sb(),d.Ob(12,"input",3),d.xc(13,k,6,4,"mat-error",4),d.Sb(),d.Tb(14,"mat-form-field"),d.Tb(15,"mat-label"),d.yc(16,"TideSiteTVItemID"),d.Sb(),d.Ob(17,"input",5),d.xc(18,P,6,4,"mat-error",4),d.Sb(),d.Tb(19,"mat-form-field"),d.Tb(20,"mat-label"),d.yc(21,"DateTime_Local"),d.Sb(),d.Ob(22,"input",6),d.xc(23,L,6,4,"mat-error",4),d.Sb(),d.Tb(24,"mat-form-field"),d.Tb(25,"mat-label"),d.yc(26,"Keep"),d.Sb(),d.Ob(27,"input",7),d.xc(28,M,6,4,"mat-error",4),d.Sb(),d.Sb(),d.Tb(29,"p"),d.Tb(30,"mat-form-field"),d.Tb(31,"mat-label"),d.yc(32,"TideDataType"),d.Sb(),d.Tb(33,"mat-select",8),d.xc(34,G,2,2,"mat-option",9),d.Sb(),d.xc(35,U,6,4,"mat-error",4),d.Sb(),d.Tb(36,"mat-form-field"),d.Tb(37,"mat-label"),d.yc(38,"StorageDataType"),d.Sb(),d.Tb(39,"mat-select",10),d.xc(40,F,2,2,"mat-option",9),d.Sb(),d.xc(41,A,6,4,"mat-error",4),d.Sb(),d.Tb(42,"mat-form-field"),d.Tb(43,"mat-label"),d.yc(44,"Depth_m"),d.Sb(),d.Ob(45,"input",11),d.xc(46,W,8,6,"mat-error",4),d.Sb(),d.Tb(47,"mat-form-field"),d.Tb(48,"mat-label"),d.yc(49,"UVelocity_m_s"),d.Sb(),d.Ob(50,"input",12),d.xc(51,Q,8,6,"mat-error",4),d.Sb(),d.Sb(),d.Tb(52,"p"),d.Tb(53,"mat-form-field"),d.Tb(54,"mat-label"),d.yc(55,"VVelocity_m_s"),d.Sb(),d.Ob(56,"input",13),d.xc(57,et,8,6,"mat-error",4),d.Sb(),d.Tb(58,"mat-form-field"),d.Tb(59,"mat-label"),d.yc(60,"TideStart"),d.Sb(),d.Tb(61,"mat-select",14),d.xc(62,at,2,2,"mat-option",9),d.Sb(),d.xc(63,it,5,3,"mat-error",4),d.Sb(),d.Tb(64,"mat-form-field"),d.Tb(65,"mat-label"),d.yc(66,"TideEnd"),d.Sb(),d.Tb(67,"mat-select",15),d.xc(68,nt,2,2,"mat-option",9),d.Sb(),d.xc(69,rt,5,3,"mat-error",4),d.Sb(),d.Tb(70,"mat-form-field"),d.Tb(71,"mat-label"),d.yc(72,"LastUpdateDate_UTC"),d.Sb(),d.Ob(73,"input",16),d.xc(74,ct,6,4,"mat-error",4),d.Sb(),d.Sb(),d.Tb(75,"p"),d.Tb(76,"mat-form-field"),d.Tb(77,"mat-label"),d.yc(78,"LastUpdateContactTVItemID"),d.Sb(),d.Ob(79,"input",17),d.xc(80,lt,6,4,"mat-error",4),d.Sb(),d.Sb(),d.Sb()),2&t&&(d.jc("formGroup",e.tidedatavalueFormEdit),d.Bb(5),d.Ac("",e.GetPut()?"Put":"Post"," TideDataValue"),d.Bb(1),d.jc("ngIf",e.tidedatavalueService.tidedatavaluePutModel$.getValue().Working),d.Bb(1),d.jc("ngIf",e.tidedatavalueService.tidedatavaluePostModel$.getValue().Working),d.Bb(6),d.jc("ngIf",e.tidedatavalueFormEdit.controls.TideDataValueID.errors),d.Bb(5),d.jc("ngIf",e.tidedatavalueFormEdit.controls.TideSiteTVItemID.errors),d.Bb(5),d.jc("ngIf",e.tidedatavalueFormEdit.controls.DateTime_Local.errors),d.Bb(5),d.jc("ngIf",e.tidedatavalueFormEdit.controls.Keep.errors),d.Bb(6),d.jc("ngForOf",e.tideDataTypeList),d.Bb(1),d.jc("ngIf",e.tidedatavalueFormEdit.controls.TideDataType.errors),d.Bb(5),d.jc("ngForOf",e.storageDataTypeList),d.Bb(1),d.jc("ngIf",e.tidedatavalueFormEdit.controls.StorageDataType.errors),d.Bb(5),d.jc("ngIf",e.tidedatavalueFormEdit.controls.Depth_m.errors),d.Bb(5),d.jc("ngIf",e.tidedatavalueFormEdit.controls.UVelocity_m_s.errors),d.Bb(6),d.jc("ngIf",e.tidedatavalueFormEdit.controls.VVelocity_m_s.errors),d.Bb(5),d.jc("ngForOf",e.tideStartList),d.Bb(1),d.jc("ngIf",e.tidedatavalueFormEdit.controls.TideStart.errors),d.Bb(5),d.jc("ngForOf",e.tideEndList),d.Bb(1),d.jc("ngIf",e.tidedatavalueFormEdit.controls.TideEnd.errors),d.Bb(5),d.jc("ngIf",e.tidedatavalueFormEdit.controls.LastUpdateDate_UTC.errors),d.Bb(6),d.jc("ngIf",e.tidedatavalueFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[g.q,g.l,g.f,y.b,i.l,C.c,C.f,V.b,g.n,g.c,g.k,g.e,x.a,i.k,D.a,C.b,B.n],pipes:[i.f],styles:[""],changeDetection:0}),bt);function st(t,e){1&t&&d.Ob(0,"mat-progress-bar",4)}function pt(t,e){1&t&&d.Ob(0,"mat-progress-bar",4)}function mt(t,e){if(1&t&&(d.Tb(0,"p"),d.Ob(1,"app-tidedatavalue-edit",8),d.Sb()),2&t){var a=d.ec().$implicit,i=d.ec(2);d.Bb(1),d.jc("tidedatavalue",a)("httpClientCommand",i.GetPutEnum())}}function Tt(t,e){if(1&t&&(d.Tb(0,"p"),d.Ob(1,"app-tidedatavalue-edit",8),d.Sb()),2&t){var a=d.ec().$implicit,i=d.ec(2);d.Bb(1),d.jc("tidedatavalue",a)("httpClientCommand",i.GetPostEnum())}}function ft(t,e){if(1&t){var a=d.Ub();d.Tb(0,"div"),d.Tb(1,"p"),d.Tb(2,"button",6),d.ac("click",(function(){d.rc(a);var t=e.$implicit;return d.ec(2).DeleteTideDataValue(t)})),d.Tb(3,"span"),d.yc(4),d.Sb(),d.Tb(5,"mat-icon"),d.yc(6,"delete"),d.Sb(),d.Sb(),d.yc(7,"\xa0\xa0\xa0 "),d.Tb(8,"button",7),d.ac("click",(function(){d.rc(a);var t=e.$implicit;return d.ec(2).ShowPut(t)})),d.Tb(9,"span"),d.yc(10,"Show Put"),d.Sb(),d.Sb(),d.yc(11,"\xa0\xa0 "),d.Tb(12,"button",7),d.ac("click",(function(){d.rc(a);var t=e.$implicit;return d.ec(2).ShowPost(t)})),d.Tb(13,"span"),d.yc(14,"Show Post"),d.Sb(),d.Sb(),d.yc(15,"\xa0\xa0 "),d.xc(16,pt,1,0,"mat-progress-bar",0),d.Sb(),d.xc(17,mt,2,2,"p",2),d.xc(18,Tt,2,2,"p",2),d.Tb(19,"blockquote"),d.Tb(20,"p"),d.Tb(21,"span"),d.yc(22),d.Sb(),d.Tb(23,"span"),d.yc(24),d.Sb(),d.Tb(25,"span"),d.yc(26),d.Sb(),d.Tb(27,"span"),d.yc(28),d.Sb(),d.Sb(),d.Tb(29,"p"),d.Tb(30,"span"),d.yc(31),d.Sb(),d.Tb(32,"span"),d.yc(33),d.Sb(),d.Tb(34,"span"),d.yc(35),d.Sb(),d.Tb(36,"span"),d.yc(37),d.Sb(),d.Sb(),d.Tb(38,"p"),d.Tb(39,"span"),d.yc(40),d.Sb(),d.Tb(41,"span"),d.yc(42),d.Sb(),d.Tb(43,"span"),d.yc(44),d.Sb(),d.Tb(45,"span"),d.yc(46),d.Sb(),d.Sb(),d.Tb(47,"p"),d.Tb(48,"span"),d.yc(49),d.Sb(),d.Sb(),d.Sb(),d.Sb()}if(2&t){var i=e.$implicit,n=d.ec(2);d.Bb(4),d.Ac("Delete TideDataValueID [",i.TideDataValueID,"]\xa0\xa0\xa0"),d.Bb(4),d.jc("color",n.GetPutButtonColor(i)),d.Bb(4),d.jc("color",n.GetPostButtonColor(i)),d.Bb(4),d.jc("ngIf",n.tidedatavalueService.tidedatavalueDeleteModel$.getValue().Working),d.Bb(1),d.jc("ngIf",n.IDToShow===i.TideDataValueID&&n.showType===n.GetPutEnum()),d.Bb(1),d.jc("ngIf",n.IDToShow===i.TideDataValueID&&n.showType===n.GetPostEnum()),d.Bb(4),d.Ac("TideDataValueID: [",i.TideDataValueID,"]"),d.Bb(2),d.Ac(" --- TideSiteTVItemID: [",i.TideSiteTVItemID,"]"),d.Bb(2),d.Ac(" --- DateTime_Local: [",i.DateTime_Local,"]"),d.Bb(2),d.Ac(" --- Keep: [",i.Keep,"]"),d.Bb(3),d.Ac("TideDataType: [",n.GetTideDataTypeEnumText(i.TideDataType),"]"),d.Bb(2),d.Ac(" --- StorageDataType: [",n.GetStorageDataTypeEnumText(i.StorageDataType),"]"),d.Bb(2),d.Ac(" --- Depth_m: [",i.Depth_m,"]"),d.Bb(2),d.Ac(" --- UVelocity_m_s: [",i.UVelocity_m_s,"]"),d.Bb(3),d.Ac("VVelocity_m_s: [",i.VVelocity_m_s,"]"),d.Bb(2),d.Ac(" --- TideStart: [",n.GetTideTextEnumText(i.TideStart),"]"),d.Bb(2),d.Ac(" --- TideEnd: [",n.GetTideTextEnumText(i.TideEnd),"]"),d.Bb(2),d.Ac(" --- LastUpdateDate_UTC: [",i.LastUpdateDate_UTC,"]"),d.Bb(3),d.Ac("LastUpdateContactTVItemID: [",i.LastUpdateContactTVItemID,"]")}}function vt(t,e){if(1&t&&(d.Tb(0,"div"),d.xc(1,ft,50,19,"div",5),d.Sb()),2&t){var a=d.ec();d.Bb(1),d.jc("ngForOf",a.tidedatavalueService.tidedatavalueListModel$.getValue())}}var St,ht,yt,Dt=[{path:"",component:(St=function(){function t(e,a,i){_classCallCheck(this,t),this.tidedatavalueService=e,this.router=a,this.httpClientService=i,this.showType=null,i.oldURL=a.url}return _createClass(t,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.TideDataValueID&&this.showType===b.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.TideDataValueID&&this.showType===b.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.TideDataValueID&&this.showType===b.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TideDataValueID,this.showType=b.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.TideDataValueID&&this.showType===b.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TideDataValueID,this.showType=b.a.Post)}},{key:"GetPutEnum",value:function(){return b.a.Put}},{key:"GetPostEnum",value:function(){return b.a.Post}},{key:"GetTideDataValueList",value:function(){this.sub=this.tidedatavalueService.GetTideDataValueList().subscribe()}},{key:"DeleteTideDataValue",value:function(t){this.sub=this.tidedatavalueService.DeleteTideDataValue(t).subscribe()}},{key:"GetTideDataTypeEnumText",value:function(t){return function(t){var e;return o().forEach((function(a){if(a.EnumID==t)return e=a.EnumText,!1})),e}(t)}},{key:"GetStorageDataTypeEnumText",value:function(t){return Object(u.a)(t)}},{key:"GetTideTextEnumText",value:function(t){return Object(l.a)(t)}},{key:"ngOnInit",value:function(){r(this.tidedatavalueService.tidedatavalueTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),t}(),St.\u0275fac=function(t){return new(t||St)(d.Nb(S),d.Nb(n.b),d.Nb(v.a))},St.\u0275cmp=d.Hb({type:St,selectors:[["app-tidedatavalue"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tidedatavalue","httpClientCommand"]],template:function(t,e){if(1&t&&(d.xc(0,st,1,0,"mat-progress-bar",0),d.Tb(1,"mat-card"),d.Tb(2,"mat-card-header"),d.Tb(3,"mat-card-title"),d.yc(4," TideDataValue works! "),d.Tb(5,"button",1),d.ac("click",(function(){return e.GetTideDataValueList()})),d.Tb(6,"span"),d.yc(7,"Get TideDataValue"),d.Sb(),d.Sb(),d.Sb(),d.Tb(8,"mat-card-subtitle"),d.yc(9),d.Sb(),d.Sb(),d.Tb(10,"mat-card-content"),d.xc(11,vt,2,1,"div",2),d.Sb(),d.Tb(12,"mat-card-actions"),d.Tb(13,"button",3),d.yc(14,"Allo"),d.Sb(),d.Sb(),d.Sb()),2&t){var a,i,n=null==(a=e.tidedatavalueService.tidedatavalueGetModel$.getValue())?null:a.Working,r=null==(i=e.tidedatavalueService.tidedatavalueListModel$.getValue())?null:i.length;d.jc("ngIf",n),d.Bb(9),d.zc(e.tidedatavalueService.tidedatavalueTextModel$.getValue().Title),d.Bb(2),d.jc("ngIf",r)}},directives:[i.l,h.a,h.d,h.g,y.b,h.f,h.c,h.b,D.a,i.k,I.a,dt],styles:[""],changeDetection:0}),St),canActivate:[a("auXs").a]}],It=((ht=function t(){_classCallCheck(this,t)}).\u0275mod=d.Lb({type:ht}),ht.\u0275inj=d.Kb({factory:function(t){return new(t||ht)},imports:[[n.e.forChild(Dt)],n.e]}),ht),gt=a("B+Mi"),Ct=((yt=function t(){_classCallCheck(this,t)}).\u0275mod=d.Lb({type:yt}),yt.\u0275inj=d.Kb({factory:function(t){return new(t||yt)},imports:[[i.c,n.e,It,gt.a,g.g,g.o]]}),yt)}}]);