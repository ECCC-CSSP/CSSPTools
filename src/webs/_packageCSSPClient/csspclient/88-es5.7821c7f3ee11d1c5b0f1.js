!function(){function t(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function e(t,e){for(var i=0;i<e.length;i++){var n=e[i];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}function i(t,i,n){return i&&e(t.prototype,i),n&&e(t,n),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[88],{QRvi:function(t,e,i){"use strict";i.d(e,"a",(function(){return n}));var n=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(e,n,o){"use strict";o.d(n,"a",(function(){return a}));var r=o("QRvi"),c=o("fXoL"),s=o("tyNb"),a=function(){var e=function(){function e(i){t(this,e),this.router=i,this.oldURL=i.url}return i(e,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,e,i,n,o){if(n===r.a.Get&&t.next(i),n===r.a.Put&&(t.getValue()[0]=i),n===r.a.Post&&t.getValue().push(i),n===r.a.Delete){var c=t.getValue().indexOf(o);t.getValue().splice(c,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,e,i,n,o){n===r.a.Get&&t.next(i),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(c.Wb(s.b))},e.\u0275prov=c.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()},rs2v:function(e,n,o){"use strict";o.r(n),o.d(n,"TideSiteModule",(function(){return ut}));var r=o("ofXK"),c=o("tyNb");function s(t){var e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var a,b=o("QRvi"),u=o("fXoL"),d=o("2Vo4"),l=o("LRne"),p=o("tk/3"),f=o("lJxs"),m=o("JIr8"),S=o("gkM4"),h=((a=function(){function e(i,n){t(this,e),this.httpClient=i,this.httpClientService=n,this.tidesiteTextModel$=new d.a({}),this.tidesiteListModel$=new d.a({}),this.tidesiteGetModel$=new d.a({}),this.tidesitePutModel$=new d.a({}),this.tidesitePostModel$=new d.a({}),this.tidesiteDeleteModel$=new d.a({}),s(this.tidesiteTextModel$),this.tidesiteTextModel$.next({Title:"Something2 for text"})}return i(e,[{key:"GetTideSiteList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.tidesiteGetModel$),this.httpClient.get("/api/TideSite").pipe(Object(f.a)((function(e){t.httpClientService.DoSuccess(t.tidesiteListModel$,t.tidesiteGetModel$,e,b.a.Get,null)})),Object(m.a)((function(e){return Object(l.a)(e).pipe(Object(f.a)((function(e){t.httpClientService.DoCatchError(t.tidesiteListModel$,t.tidesiteGetModel$,e)})))})))}},{key:"PutTideSite",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.tidesitePutModel$),this.httpClient.put("/api/TideSite",t,{headers:new p.d}).pipe(Object(f.a)((function(i){e.httpClientService.DoSuccess(e.tidesiteListModel$,e.tidesitePutModel$,i,b.a.Put,t)})),Object(m.a)((function(t){return Object(l.a)(t).pipe(Object(f.a)((function(t){e.httpClientService.DoCatchError(e.tidesiteListModel$,e.tidesitePutModel$,t)})))})))}},{key:"PostTideSite",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.tidesitePostModel$),this.httpClient.post("/api/TideSite",t,{headers:new p.d}).pipe(Object(f.a)((function(i){e.httpClientService.DoSuccess(e.tidesiteListModel$,e.tidesitePostModel$,i,b.a.Post,t)})),Object(m.a)((function(t){return Object(l.a)(t).pipe(Object(f.a)((function(t){e.httpClientService.DoCatchError(e.tidesiteListModel$,e.tidesitePostModel$,t)})))})))}},{key:"DeleteTideSite",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.tidesiteDeleteModel$),this.httpClient.delete("/api/TideSite/"+t.TideSiteID).pipe(Object(f.a)((function(i){e.httpClientService.DoSuccess(e.tidesiteListModel$,e.tidesiteDeleteModel$,i,b.a.Delete,t)})),Object(m.a)((function(t){return Object(l.a)(t).pipe(Object(f.a)((function(t){e.httpClientService.DoCatchError(e.tidesiteListModel$,e.tidesiteDeleteModel$,t)})))})))}}]),e}()).\u0275fac=function(t){return new(t||a)(u.Wb(p.b),u.Wb(S.a))},a.\u0275prov=u.Ib({token:a,factory:a.\u0275fac,providedIn:"root"}),a),v=o("Wp6s"),I=o("bTqV"),T=o("bv9b"),R=o("NFeN"),g=o("3Pt+"),y=o("kmnG"),D=o("qFsG");function B(t,e){1&t&&u.Nb(0,"mat-progress-bar",12)}function C(t,e){1&t&&u.Nb(0,"mat-progress-bar",12)}function P(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function k(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,P,3,0,"span",4),u.Rb()),2&t){var i=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,i)),u.Bb(3),u.ic("ngIf",i.required)}}function N(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function z(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,N,3,0,"span",4),u.Rb()),2&t){var i=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,i)),u.Bb(3),u.ic("ngIf",i.required)}}function M(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function w(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"MaxLength - 100"),u.Nb(2,"br"),u.Rb())}function $(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,M,3,0,"span",4),u.yc(6,w,3,0,"span",4),u.Rb()),2&t){var i=e.$implicit;u.Bb(2),u.Ac(u.fc(3,3,i)),u.Bb(3),u.ic("ngIf",i.required),u.Bb(1),u.ic("ngIf",i.maxlength)}}function L(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function G(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"MinLength - 2"),u.Nb(2,"br"),u.Rb())}function x(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"MaxLength - 2"),u.Nb(2,"br"),u.Rb())}function E(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,L,3,0,"span",4),u.yc(6,G,3,0,"span",4),u.yc(7,x,3,0,"span",4),u.Rb()),2&t){var i=e.$implicit;u.Bb(2),u.Ac(u.fc(3,4,i)),u.Bb(3),u.ic("ngIf",i.required),u.Bb(1),u.ic("ngIf",i.minlength),u.Bb(1),u.ic("ngIf",i.maxlength)}}function q(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function V(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Min - 0"),u.Nb(2,"br"),u.Rb())}function j(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Max - 10000"),u.Nb(2,"br"),u.Rb())}function U(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,q,3,0,"span",4),u.yc(6,V,3,0,"span",4),u.yc(7,j,3,0,"span",4),u.Rb()),2&t){var i=e.$implicit;u.Bb(2),u.Ac(u.fc(3,4,i)),u.Bb(3),u.ic("ngIf",i.required),u.Bb(1),u.ic("ngIf",i.min),u.Bb(1),u.ic("ngIf",i.min)}}function O(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function F(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Min - 0"),u.Nb(2,"br"),u.Rb())}function W(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Max - 10000"),u.Nb(2,"br"),u.Rb())}function A(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,O,3,0,"span",4),u.yc(6,F,3,0,"span",4),u.yc(7,W,3,0,"span",4),u.Rb()),2&t){var i=e.$implicit;u.Bb(2),u.Ac(u.fc(3,4,i)),u.Bb(3),u.ic("ngIf",i.required),u.Bb(1),u.ic("ngIf",i.min),u.Bb(1),u.ic("ngIf",i.min)}}function Z(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function _(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,Z,3,0,"span",4),u.Rb()),2&t){var i=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,i)),u.Bb(3),u.ic("ngIf",i.required)}}function J(t,e){1&t&&(u.Sb(0,"span"),u.zc(1,"Is Required"),u.Nb(2,"br"),u.Rb())}function H(t,e){if(1&t&&(u.Sb(0,"mat-error"),u.Sb(1,"span"),u.zc(2),u.ec(3,"json"),u.Nb(4,"br"),u.Rb(),u.yc(5,J,3,0,"span",4),u.Rb()),2&t){var i=e.$implicit;u.Bb(2),u.Ac(u.fc(3,2,i)),u.Bb(3),u.ic("ngIf",i.required)}}var X,K=((X=function(){function e(i,n){t(this,e),this.tidesiteService=i,this.fb=n,this.tidesite=null,this.httpClientCommand=b.a.Put}return i(e,[{key:"GetPut",value:function(){return this.httpClientCommand==b.a.Put}},{key:"PutTideSite",value:function(t){this.sub=this.tidesiteService.PutTideSite(t).subscribe()}},{key:"PostTideSite",value:function(t){this.sub=this.tidesiteService.PostTideSite(t).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.tidesite){var e=this.fb.group({TideSiteID:[{value:t===b.a.Post?0:this.tidesite.TideSiteID,disabled:!1},[g.p.required]],TideSiteTVItemID:[{value:this.tidesite.TideSiteTVItemID,disabled:!1},[g.p.required]],TideSiteName:[{value:this.tidesite.TideSiteName,disabled:!1},[g.p.required,g.p.maxLength(100)]],Province:[{value:this.tidesite.Province,disabled:!1},[g.p.required,g.p.minLength(2),g.p.maxLength(2)]],sid:[{value:this.tidesite.sid,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e4)]],Zone:[{value:this.tidesite.Zone,disabled:!1},[g.p.required,g.p.min(0),g.p.max(1e4)]],LastUpdateDate_UTC:[{value:this.tidesite.LastUpdateDate_UTC,disabled:!1},[g.p.required]],LastUpdateContactTVItemID:[{value:this.tidesite.LastUpdateContactTVItemID,disabled:!1},[g.p.required]]});this.tidesiteFormEdit=e}}}]),e}()).\u0275fac=function(t){return new(t||X)(u.Mb(h),u.Mb(g.d))},X.\u0275cmp=u.Gb({type:X,selectors:[["app-tidesite-edit"]],inputs:{tidesite:"tidesite",httpClientCommand:"httpClientCommand"},decls:50,vars:12,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TideSiteID"],[4,"ngIf"],["matInput","","type","number","formControlName","TideSiteTVItemID"],["matInput","","type","text","formControlName","TideSiteName"],["matInput","","type","text","formControlName","Province"],["matInput","","type","number","formControlName","sid"],["matInput","","type","number","formControlName","Zone"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,e){1&t&&(u.Sb(0,"form",0),u.Zb("ngSubmit",(function(){return e.GetPut()?e.PutTideSite(e.tidesiteFormEdit.value):e.PostTideSite(e.tidesiteFormEdit.value)})),u.Sb(1,"h3"),u.zc(2," TideSite "),u.Sb(3,"button",1),u.Sb(4,"span"),u.zc(5),u.Rb(),u.Rb(),u.yc(6,B,1,0,"mat-progress-bar",2),u.yc(7,C,1,0,"mat-progress-bar",2),u.Rb(),u.Sb(8,"p"),u.Sb(9,"mat-form-field"),u.Sb(10,"mat-label"),u.zc(11,"TideSiteID"),u.Rb(),u.Nb(12,"input",3),u.yc(13,k,6,4,"mat-error",4),u.Rb(),u.Sb(14,"mat-form-field"),u.Sb(15,"mat-label"),u.zc(16,"TideSiteTVItemID"),u.Rb(),u.Nb(17,"input",5),u.yc(18,z,6,4,"mat-error",4),u.Rb(),u.Sb(19,"mat-form-field"),u.Sb(20,"mat-label"),u.zc(21,"TideSiteName"),u.Rb(),u.Nb(22,"input",6),u.yc(23,$,7,5,"mat-error",4),u.Rb(),u.Sb(24,"mat-form-field"),u.Sb(25,"mat-label"),u.zc(26,"Province"),u.Rb(),u.Nb(27,"input",7),u.yc(28,E,8,6,"mat-error",4),u.Rb(),u.Rb(),u.Sb(29,"p"),u.Sb(30,"mat-form-field"),u.Sb(31,"mat-label"),u.zc(32,"sid"),u.Rb(),u.Nb(33,"input",8),u.yc(34,U,8,6,"mat-error",4),u.Rb(),u.Sb(35,"mat-form-field"),u.Sb(36,"mat-label"),u.zc(37,"Zone"),u.Rb(),u.Nb(38,"input",9),u.yc(39,A,8,6,"mat-error",4),u.Rb(),u.Sb(40,"mat-form-field"),u.Sb(41,"mat-label"),u.zc(42,"LastUpdateDate_UTC"),u.Rb(),u.Nb(43,"input",10),u.yc(44,_,6,4,"mat-error",4),u.Rb(),u.Sb(45,"mat-form-field"),u.Sb(46,"mat-label"),u.zc(47,"LastUpdateContactTVItemID"),u.Rb(),u.Nb(48,"input",11),u.yc(49,H,6,4,"mat-error",4),u.Rb(),u.Rb(),u.Rb()),2&t&&(u.ic("formGroup",e.tidesiteFormEdit),u.Bb(5),u.Bc("",e.GetPut()?"Put":"Post"," TideSite"),u.Bb(1),u.ic("ngIf",e.tidesiteService.tidesitePutModel$.getValue().Working),u.Bb(1),u.ic("ngIf",e.tidesiteService.tidesitePostModel$.getValue().Working),u.Bb(6),u.ic("ngIf",e.tidesiteFormEdit.controls.TideSiteID.errors),u.Bb(5),u.ic("ngIf",e.tidesiteFormEdit.controls.TideSiteTVItemID.errors),u.Bb(5),u.ic("ngIf",e.tidesiteFormEdit.controls.TideSiteName.errors),u.Bb(5),u.ic("ngIf",e.tidesiteFormEdit.controls.Province.errors),u.Bb(6),u.ic("ngIf",e.tidesiteFormEdit.controls.sid.errors),u.Bb(5),u.ic("ngIf",e.tidesiteFormEdit.controls.Zone.errors),u.Bb(5),u.ic("ngIf",e.tidesiteFormEdit.controls.LastUpdateDate_UTC.errors),u.Bb(5),u.ic("ngIf",e.tidesiteFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[g.q,g.l,g.f,I.b,r.l,y.c,y.f,D.b,g.n,g.c,g.k,g.e,T.a,y.b],pipes:[r.f],styles:[""],changeDetection:0}),X);function Q(t,e){1&t&&u.Nb(0,"mat-progress-bar",4)}function Y(t,e){1&t&&u.Nb(0,"mat-progress-bar",4)}function tt(t,e){if(1&t&&(u.Sb(0,"p"),u.Nb(1,"app-tidesite-edit",8),u.Rb()),2&t){var i=u.dc().$implicit,n=u.dc(2);u.Bb(1),u.ic("tidesite",i)("httpClientCommand",n.GetPutEnum())}}function et(t,e){if(1&t&&(u.Sb(0,"p"),u.Nb(1,"app-tidesite-edit",8),u.Rb()),2&t){var i=u.dc().$implicit,n=u.dc(2);u.Bb(1),u.ic("tidesite",i)("httpClientCommand",n.GetPostEnum())}}function it(t,e){if(1&t){var i=u.Tb();u.Sb(0,"div"),u.Sb(1,"p"),u.Sb(2,"button",6),u.Zb("click",(function(){u.qc(i);var t=e.$implicit;return u.dc(2).DeleteTideSite(t)})),u.Sb(3,"span"),u.zc(4),u.Rb(),u.Sb(5,"mat-icon"),u.zc(6,"delete"),u.Rb(),u.Rb(),u.zc(7,"\xa0\xa0\xa0 "),u.Sb(8,"button",7),u.Zb("click",(function(){u.qc(i);var t=e.$implicit;return u.dc(2).ShowPut(t)})),u.Sb(9,"span"),u.zc(10,"Show Put"),u.Rb(),u.Rb(),u.zc(11,"\xa0\xa0 "),u.Sb(12,"button",7),u.Zb("click",(function(){u.qc(i);var t=e.$implicit;return u.dc(2).ShowPost(t)})),u.Sb(13,"span"),u.zc(14,"Show Post"),u.Rb(),u.Rb(),u.zc(15,"\xa0\xa0 "),u.yc(16,Y,1,0,"mat-progress-bar",0),u.Rb(),u.yc(17,tt,2,2,"p",2),u.yc(18,et,2,2,"p",2),u.Sb(19,"blockquote"),u.Sb(20,"p"),u.Sb(21,"span"),u.zc(22),u.Rb(),u.Sb(23,"span"),u.zc(24),u.Rb(),u.Sb(25,"span"),u.zc(26),u.Rb(),u.Sb(27,"span"),u.zc(28),u.Rb(),u.Rb(),u.Sb(29,"p"),u.Sb(30,"span"),u.zc(31),u.Rb(),u.Sb(32,"span"),u.zc(33),u.Rb(),u.Sb(34,"span"),u.zc(35),u.Rb(),u.Sb(36,"span"),u.zc(37),u.Rb(),u.Rb(),u.Rb(),u.Rb()}if(2&t){var n=e.$implicit,o=u.dc(2);u.Bb(4),u.Bc("Delete TideSiteID [",n.TideSiteID,"]\xa0\xa0\xa0"),u.Bb(4),u.ic("color",o.GetPutButtonColor(n)),u.Bb(4),u.ic("color",o.GetPostButtonColor(n)),u.Bb(4),u.ic("ngIf",o.tidesiteService.tidesiteDeleteModel$.getValue().Working),u.Bb(1),u.ic("ngIf",o.IDToShow===n.TideSiteID&&o.showType===o.GetPutEnum()),u.Bb(1),u.ic("ngIf",o.IDToShow===n.TideSiteID&&o.showType===o.GetPostEnum()),u.Bb(4),u.Bc("TideSiteID: [",n.TideSiteID,"]"),u.Bb(2),u.Bc(" --- TideSiteTVItemID: [",n.TideSiteTVItemID,"]"),u.Bb(2),u.Bc(" --- TideSiteName: [",n.TideSiteName,"]"),u.Bb(2),u.Bc(" --- Province: [",n.Province,"]"),u.Bb(3),u.Bc("sid: [",n.sid,"]"),u.Bb(2),u.Bc(" --- Zone: [",n.Zone,"]"),u.Bb(2),u.Bc(" --- LastUpdateDate_UTC: [",n.LastUpdateDate_UTC,"]"),u.Bb(2),u.Bc(" --- LastUpdateContactTVItemID: [",n.LastUpdateContactTVItemID,"]")}}function nt(t,e){if(1&t&&(u.Sb(0,"div"),u.yc(1,it,38,14,"div",5),u.Rb()),2&t){var i=u.dc();u.Bb(1),u.ic("ngForOf",i.tidesiteService.tidesiteListModel$.getValue())}}var ot,rt,ct,st=[{path:"",component:(ot=function(){function e(i,n,o){t(this,e),this.tidesiteService=i,this.router=n,this.httpClientService=o,this.showType=null,o.oldURL=n.url}return i(e,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.TideSiteID&&this.showType===b.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.TideSiteID&&this.showType===b.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.TideSiteID&&this.showType===b.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TideSiteID,this.showType=b.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.TideSiteID&&this.showType===b.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TideSiteID,this.showType=b.a.Post)}},{key:"GetPutEnum",value:function(){return b.a.Put}},{key:"GetPostEnum",value:function(){return b.a.Post}},{key:"GetTideSiteList",value:function(){this.sub=this.tidesiteService.GetTideSiteList().subscribe()}},{key:"DeleteTideSite",value:function(t){this.sub=this.tidesiteService.DeleteTideSite(t).subscribe()}},{key:"ngOnInit",value:function(){s(this.tidesiteService.tidesiteTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),e}(),ot.\u0275fac=function(t){return new(t||ot)(u.Mb(h),u.Mb(c.b),u.Mb(S.a))},ot.\u0275cmp=u.Gb({type:ot,selectors:[["app-tidesite"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tidesite","httpClientCommand"]],template:function(t,e){if(1&t&&(u.yc(0,Q,1,0,"mat-progress-bar",0),u.Sb(1,"mat-card"),u.Sb(2,"mat-card-header"),u.Sb(3,"mat-card-title"),u.zc(4," TideSite works! "),u.Sb(5,"button",1),u.Zb("click",(function(){return e.GetTideSiteList()})),u.Sb(6,"span"),u.zc(7,"Get TideSite"),u.Rb(),u.Rb(),u.Rb(),u.Sb(8,"mat-card-subtitle"),u.zc(9),u.Rb(),u.Rb(),u.Sb(10,"mat-card-content"),u.yc(11,nt,2,1,"div",2),u.Rb(),u.Sb(12,"mat-card-actions"),u.Sb(13,"button",3),u.zc(14,"Allo"),u.Rb(),u.Rb(),u.Rb()),2&t){var i,n,o=null==(i=e.tidesiteService.tidesiteGetModel$.getValue())?null:i.Working,r=null==(n=e.tidesiteService.tidesiteListModel$.getValue())?null:n.length;u.ic("ngIf",o),u.Bb(9),u.Ac(e.tidesiteService.tidesiteTextModel$.getValue().Title),u.Bb(2),u.ic("ngIf",r)}},directives:[r.l,v.a,v.d,v.g,I.b,v.f,v.c,v.b,T.a,r.k,R.a,K],styles:[""],changeDetection:0}),ot),canActivate:[o("auXs").a]}],at=((rt=function e(){t(this,e)}).\u0275mod=u.Kb({type:rt}),rt.\u0275inj=u.Jb({factory:function(t){return new(t||rt)},imports:[[c.e.forChild(st)],c.e]}),rt),bt=o("B+Mi"),ut=((ct=function e(){t(this,e)}).\u0275mod=u.Kb({type:ct}),ct.\u0275inj=u.Jb({factory:function(t){return new(t||ct)},imports:[[r.c,c.e,at,bt.a,g.g,g.o]]}),ct)}}])}();