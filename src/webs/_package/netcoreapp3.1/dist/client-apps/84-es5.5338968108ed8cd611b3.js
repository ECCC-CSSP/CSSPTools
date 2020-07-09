function _classCallCheck(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function _defineProperties(t,e){for(var i=0;i<e.length;i++){var l=e[i];l.enumerable=l.enumerable||!1,l.configurable=!0,"value"in l&&(l.writable=!0),Object.defineProperty(t,l.key,l)}}function _createClass(t,e,i){return e&&_defineProperties(t.prototype,e),i&&_defineProperties(t,i),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[84],{QRvi:function(t,e,i){"use strict";i.d(e,"a",(function(){return l}));var l=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,i){"use strict";i.d(e,"a",(function(){return o}));var l=i("QRvi"),n=i("fXoL"),r=i("tyNb"),o=function(){var t=function(){function t(e){_classCallCheck(this,t),this.router=e,this.oldURL=e.url}return _createClass(t,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,e,i,n,r){if(n===l.a.Get&&t.next(i),n===l.a.Put&&(t.getValue()[0]=i),n===l.a.Post&&t.getValue().push(i),n===l.a.Delete){var o=t.getValue().indexOf(r);t.getValue().splice(o,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,e,i,n,r){n===l.a.Get&&t.next(i),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),t}();return t.\u0275fac=function(e){return new(e||t)(n.Xb(r.b))},t.\u0275prov=n.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t}()},ryrq:function(t,e,i){"use strict";i.r(e),i.d(e,"SpillModule",(function(){return et}));var l=i("ofXK"),n=i("tyNb");function r(t){var e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var o,a=i("QRvi"),c=i("fXoL"),s=i("2Vo4"),b=i("LRne"),u=i("tk/3"),p=i("lJxs"),f=i("JIr8"),m=i("gkM4"),d=((o=function(){function t(e,i){_classCallCheck(this,t),this.httpClient=e,this.httpClientService=i,this.spillTextModel$=new s.a({}),this.spillListModel$=new s.a({}),this.spillGetModel$=new s.a({}),this.spillPutModel$=new s.a({}),this.spillPostModel$=new s.a({}),this.spillDeleteModel$=new s.a({}),r(this.spillTextModel$),this.spillTextModel$.next({Title:"Something2 for text"})}return _createClass(t,[{key:"GetSpillList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.spillGetModel$),this.httpClient.get("/api/Spill").pipe(Object(p.a)((function(e){t.httpClientService.DoSuccess(t.spillListModel$,t.spillGetModel$,e,a.a.Get,null)})),Object(f.a)((function(e){return Object(b.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.spillListModel$,t.spillGetModel$,e)})))})))}},{key:"PutSpill",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.spillPutModel$),this.httpClient.put("/api/Spill",t,{headers:new u.d}).pipe(Object(p.a)((function(i){e.httpClientService.DoSuccess(e.spillListModel$,e.spillPutModel$,i,a.a.Put,t)})),Object(f.a)((function(t){return Object(b.a)(t).pipe(Object(p.a)((function(t){e.httpClientService.DoCatchError(e.spillListModel$,e.spillPutModel$,t)})))})))}},{key:"PostSpill",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.spillPostModel$),this.httpClient.post("/api/Spill",t,{headers:new u.d}).pipe(Object(p.a)((function(i){e.httpClientService.DoSuccess(e.spillListModel$,e.spillPostModel$,i,a.a.Post,t)})),Object(f.a)((function(t){return Object(b.a)(t).pipe(Object(p.a)((function(t){e.httpClientService.DoCatchError(e.spillListModel$,e.spillPostModel$,t)})))})))}},{key:"DeleteSpill",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.spillDeleteModel$),this.httpClient.delete("/api/Spill/"+t.SpillID).pipe(Object(p.a)((function(i){e.httpClientService.DoSuccess(e.spillListModel$,e.spillDeleteModel$,i,a.a.Delete,t)})),Object(f.a)((function(t){return Object(b.a)(t).pipe(Object(p.a)((function(t){e.httpClientService.DoCatchError(e.spillListModel$,e.spillDeleteModel$,t)})))})))}}]),t}()).\u0275fac=function(t){return new(t||o)(c.Xb(u.b),c.Xb(m.a))},o.\u0275prov=c.Jb({token:o,factory:o.\u0275fac,providedIn:"root"}),o),S=i("Wp6s"),h=i("bTqV"),T=i("bv9b"),v=i("NFeN"),y=i("3Pt+"),I=i("kmnG"),D=i("qFsG");function g(t,e){1&t&&c.Ob(0,"mat-progress-bar",12)}function C(t,e){1&t&&c.Ob(0,"mat-progress-bar",12)}function k(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function P(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,k,3,0,"span",4),c.Sb()),2&t){var i=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,i)),c.Bb(3),c.jc("ngIf",i.required)}}function B(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function w(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,B,3,0,"span",4),c.Sb()),2&t){var i=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,i)),c.Bb(3),c.jc("ngIf",i.required)}}function j(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.Sb()),2&t){var i=e.$implicit;c.Bb(2),c.zc(c.gc(3,1,i))}}function O(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function L(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,O,3,0,"span",4),c.Sb()),2&t){var i=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,i)),c.Bb(3),c.jc("ngIf",i.required)}}function $(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.Sb()),2&t){var i=e.$implicit;c.Bb(2),c.zc(c.gc(3,1,i))}}function x(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function _(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Min - 0"),c.Ob(2,"br"),c.Sb())}function M(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Max - 1000000"),c.Ob(2,"br"),c.Sb())}function E(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,x,3,0,"span",4),c.xc(6,_,3,0,"span",4),c.xc(7,M,3,0,"span",4),c.Sb()),2&t){var i=e.$implicit;c.Bb(2),c.zc(c.gc(3,4,i)),c.Bb(3),c.jc("ngIf",i.required),c.Bb(1),c.jc("ngIf",i.min),c.Bb(1),c.jc("ngIf",i.min)}}function V(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function G(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,V,3,0,"span",4),c.Sb()),2&t){var i=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,i)),c.Bb(3),c.jc("ngIf",i.required)}}function F(t,e){1&t&&(c.Tb(0,"span"),c.yc(1,"Is Required"),c.Ob(2,"br"),c.Sb())}function U(t,e){if(1&t&&(c.Tb(0,"mat-error"),c.Tb(1,"span"),c.yc(2),c.fc(3,"json"),c.Ob(4,"br"),c.Sb(),c.xc(5,F,3,0,"span",4),c.Sb()),2&t){var i=e.$implicit;c.Bb(2),c.zc(c.gc(3,2,i)),c.Bb(3),c.jc("ngIf",i.required)}}var q,A=((q=function(){function t(e,i){_classCallCheck(this,t),this.spillService=e,this.fb=i,this.spill=null,this.httpClientCommand=a.a.Put}return _createClass(t,[{key:"GetPut",value:function(){return this.httpClientCommand==a.a.Put}},{key:"PutSpill",value:function(t){this.sub=this.spillService.PutSpill(t).subscribe()}},{key:"PostSpill",value:function(t){this.sub=this.spillService.PostSpill(t).subscribe()}},{key:"ngOnInit",value:function(){this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.spill){var e=this.fb.group({SpillID:[{value:t===a.a.Post?0:this.spill.SpillID,disabled:!1},[y.p.required]],MunicipalityTVItemID:[{value:this.spill.MunicipalityTVItemID,disabled:!1},[y.p.required]],InfrastructureTVItemID:[{value:this.spill.InfrastructureTVItemID,disabled:!1}],StartDateTime_Local:[{value:this.spill.StartDateTime_Local,disabled:!1},[y.p.required]],EndDateTime_Local:[{value:this.spill.EndDateTime_Local,disabled:!1}],AverageFlow_m3_day:[{value:this.spill.AverageFlow_m3_day,disabled:!1},[y.p.required,y.p.min(0),y.p.max(1e6)]],LastUpdateDate_UTC:[{value:this.spill.LastUpdateDate_UTC,disabled:!1},[y.p.required]],LastUpdateContactTVItemID:[{value:this.spill.LastUpdateContactTVItemID,disabled:!1},[y.p.required]]});this.spillFormEdit=e}}}]),t}()).\u0275fac=function(t){return new(t||q)(c.Nb(d),c.Nb(y.d))},q.\u0275cmp=c.Hb({type:q,selectors:[["app-spill-edit"]],inputs:{spill:"spill",httpClientCommand:"httpClientCommand"},decls:50,vars:12,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","SpillID"],[4,"ngIf"],["matInput","","type","number","formControlName","MunicipalityTVItemID"],["matInput","","type","number","formControlName","InfrastructureTVItemID"],["matInput","","type","text","formControlName","StartDateTime_Local"],["matInput","","type","text","formControlName","EndDateTime_Local"],["matInput","","type","number","formControlName","AverageFlow_m3_day"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,e){1&t&&(c.Tb(0,"form",0),c.ac("ngSubmit",(function(){return e.GetPut()?e.PutSpill(e.spillFormEdit.value):e.PostSpill(e.spillFormEdit.value)})),c.Tb(1,"h3"),c.yc(2," Spill "),c.Tb(3,"button",1),c.Tb(4,"span"),c.yc(5),c.Sb(),c.Sb(),c.xc(6,g,1,0,"mat-progress-bar",2),c.xc(7,C,1,0,"mat-progress-bar",2),c.Sb(),c.Tb(8,"p"),c.Tb(9,"mat-form-field"),c.Tb(10,"mat-label"),c.yc(11,"SpillID"),c.Sb(),c.Ob(12,"input",3),c.xc(13,P,6,4,"mat-error",4),c.Sb(),c.Tb(14,"mat-form-field"),c.Tb(15,"mat-label"),c.yc(16,"MunicipalityTVItemID"),c.Sb(),c.Ob(17,"input",5),c.xc(18,w,6,4,"mat-error",4),c.Sb(),c.Tb(19,"mat-form-field"),c.Tb(20,"mat-label"),c.yc(21,"InfrastructureTVItemID"),c.Sb(),c.Ob(22,"input",6),c.xc(23,j,5,3,"mat-error",4),c.Sb(),c.Tb(24,"mat-form-field"),c.Tb(25,"mat-label"),c.yc(26,"StartDateTime_Local"),c.Sb(),c.Ob(27,"input",7),c.xc(28,L,6,4,"mat-error",4),c.Sb(),c.Sb(),c.Tb(29,"p"),c.Tb(30,"mat-form-field"),c.Tb(31,"mat-label"),c.yc(32,"EndDateTime_Local"),c.Sb(),c.Ob(33,"input",8),c.xc(34,$,5,3,"mat-error",4),c.Sb(),c.Tb(35,"mat-form-field"),c.Tb(36,"mat-label"),c.yc(37,"AverageFlow_m3_day"),c.Sb(),c.Ob(38,"input",9),c.xc(39,E,8,6,"mat-error",4),c.Sb(),c.Tb(40,"mat-form-field"),c.Tb(41,"mat-label"),c.yc(42,"LastUpdateDate_UTC"),c.Sb(),c.Ob(43,"input",10),c.xc(44,G,6,4,"mat-error",4),c.Sb(),c.Tb(45,"mat-form-field"),c.Tb(46,"mat-label"),c.yc(47,"LastUpdateContactTVItemID"),c.Sb(),c.Ob(48,"input",11),c.xc(49,U,6,4,"mat-error",4),c.Sb(),c.Sb(),c.Sb()),2&t&&(c.jc("formGroup",e.spillFormEdit),c.Bb(5),c.Ac("",e.GetPut()?"Put":"Post"," Spill"),c.Bb(1),c.jc("ngIf",e.spillService.spillPutModel$.getValue().Working),c.Bb(1),c.jc("ngIf",e.spillService.spillPostModel$.getValue().Working),c.Bb(6),c.jc("ngIf",e.spillFormEdit.controls.SpillID.errors),c.Bb(5),c.jc("ngIf",e.spillFormEdit.controls.MunicipalityTVItemID.errors),c.Bb(5),c.jc("ngIf",e.spillFormEdit.controls.InfrastructureTVItemID.errors),c.Bb(5),c.jc("ngIf",e.spillFormEdit.controls.StartDateTime_Local.errors),c.Bb(6),c.jc("ngIf",e.spillFormEdit.controls.EndDateTime_Local.errors),c.Bb(5),c.jc("ngIf",e.spillFormEdit.controls.AverageFlow_m3_day.errors),c.Bb(5),c.jc("ngIf",e.spillFormEdit.controls.LastUpdateDate_UTC.errors),c.Bb(5),c.jc("ngIf",e.spillFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[y.q,y.l,y.f,h.b,l.l,I.c,I.f,D.b,y.n,y.c,y.k,y.e,T.a,I.b],pipes:[l.f],styles:[""],changeDetection:0}),q);function R(t,e){1&t&&c.Ob(0,"mat-progress-bar",4)}function N(t,e){1&t&&c.Ob(0,"mat-progress-bar",4)}function z(t,e){if(1&t&&(c.Tb(0,"p"),c.Ob(1,"app-spill-edit",8),c.Sb()),2&t){var i=c.ec().$implicit,l=c.ec(2);c.Bb(1),c.jc("spill",i)("httpClientCommand",l.GetPutEnum())}}function W(t,e){if(1&t&&(c.Tb(0,"p"),c.Ob(1,"app-spill-edit",8),c.Sb()),2&t){var i=c.ec().$implicit,l=c.ec(2);c.Bb(1),c.jc("spill",i)("httpClientCommand",l.GetPostEnum())}}function H(t,e){if(1&t){var i=c.Ub();c.Tb(0,"div"),c.Tb(1,"p"),c.Tb(2,"button",6),c.ac("click",(function(){c.rc(i);var t=e.$implicit;return c.ec(2).DeleteSpill(t)})),c.Tb(3,"span"),c.yc(4),c.Sb(),c.Tb(5,"mat-icon"),c.yc(6,"delete"),c.Sb(),c.Sb(),c.yc(7,"\xa0\xa0\xa0 "),c.Tb(8,"button",7),c.ac("click",(function(){c.rc(i);var t=e.$implicit;return c.ec(2).ShowPut(t)})),c.Tb(9,"span"),c.yc(10,"Show Put"),c.Sb(),c.Sb(),c.yc(11,"\xa0\xa0 "),c.Tb(12,"button",7),c.ac("click",(function(){c.rc(i);var t=e.$implicit;return c.ec(2).ShowPost(t)})),c.Tb(13,"span"),c.yc(14,"Show Post"),c.Sb(),c.Sb(),c.yc(15,"\xa0\xa0 "),c.xc(16,N,1,0,"mat-progress-bar",0),c.Sb(),c.xc(17,z,2,2,"p",2),c.xc(18,W,2,2,"p",2),c.Tb(19,"blockquote"),c.Tb(20,"p"),c.Tb(21,"span"),c.yc(22),c.Sb(),c.Tb(23,"span"),c.yc(24),c.Sb(),c.Tb(25,"span"),c.yc(26),c.Sb(),c.Tb(27,"span"),c.yc(28),c.Sb(),c.Sb(),c.Tb(29,"p"),c.Tb(30,"span"),c.yc(31),c.Sb(),c.Tb(32,"span"),c.yc(33),c.Sb(),c.Tb(34,"span"),c.yc(35),c.Sb(),c.Tb(36,"span"),c.yc(37),c.Sb(),c.Sb(),c.Sb(),c.Sb()}if(2&t){var l=e.$implicit,n=c.ec(2);c.Bb(4),c.Ac("Delete SpillID [",l.SpillID,"]\xa0\xa0\xa0"),c.Bb(4),c.jc("color",n.GetPutButtonColor(l)),c.Bb(4),c.jc("color",n.GetPostButtonColor(l)),c.Bb(4),c.jc("ngIf",n.spillService.spillDeleteModel$.getValue().Working),c.Bb(1),c.jc("ngIf",n.IDToShow===l.SpillID&&n.showType===n.GetPutEnum()),c.Bb(1),c.jc("ngIf",n.IDToShow===l.SpillID&&n.showType===n.GetPostEnum()),c.Bb(4),c.Ac("SpillID: [",l.SpillID,"]"),c.Bb(2),c.Ac(" --- MunicipalityTVItemID: [",l.MunicipalityTVItemID,"]"),c.Bb(2),c.Ac(" --- InfrastructureTVItemID: [",l.InfrastructureTVItemID,"]"),c.Bb(2),c.Ac(" --- StartDateTime_Local: [",l.StartDateTime_Local,"]"),c.Bb(3),c.Ac("EndDateTime_Local: [",l.EndDateTime_Local,"]"),c.Bb(2),c.Ac(" --- AverageFlow_m3_day: [",l.AverageFlow_m3_day,"]"),c.Bb(2),c.Ac(" --- LastUpdateDate_UTC: [",l.LastUpdateDate_UTC,"]"),c.Bb(2),c.Ac(" --- LastUpdateContactTVItemID: [",l.LastUpdateContactTVItemID,"]")}}function X(t,e){if(1&t&&(c.Tb(0,"div"),c.xc(1,H,38,14,"div",5),c.Sb()),2&t){var i=c.ec();c.Bb(1),c.jc("ngForOf",i.spillService.spillListModel$.getValue())}}var J,K,Q,Y=[{path:"",component:(J=function(){function t(e,i,l){_classCallCheck(this,t),this.spillService=e,this.router=i,this.httpClientService=l,this.showType=null,l.oldURL=i.url}return _createClass(t,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.SpillID&&this.showType===a.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.SpillID&&this.showType===a.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.SpillID&&this.showType===a.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.SpillID,this.showType=a.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.SpillID&&this.showType===a.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.SpillID,this.showType=a.a.Post)}},{key:"GetPutEnum",value:function(){return a.a.Put}},{key:"GetPostEnum",value:function(){return a.a.Post}},{key:"GetSpillList",value:function(){this.sub=this.spillService.GetSpillList().subscribe()}},{key:"DeleteSpill",value:function(t){this.sub=this.spillService.DeleteSpill(t).subscribe()}},{key:"ngOnInit",value:function(){r(this.spillService.spillTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),t}(),J.\u0275fac=function(t){return new(t||J)(c.Nb(d),c.Nb(n.b),c.Nb(m.a))},J.\u0275cmp=c.Hb({type:J,selectors:[["app-spill"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"spill","httpClientCommand"]],template:function(t,e){if(1&t&&(c.xc(0,R,1,0,"mat-progress-bar",0),c.Tb(1,"mat-card"),c.Tb(2,"mat-card-header"),c.Tb(3,"mat-card-title"),c.yc(4," Spill works! "),c.Tb(5,"button",1),c.ac("click",(function(){return e.GetSpillList()})),c.Tb(6,"span"),c.yc(7,"Get Spill"),c.Sb(),c.Sb(),c.Sb(),c.Tb(8,"mat-card-subtitle"),c.yc(9),c.Sb(),c.Sb(),c.Tb(10,"mat-card-content"),c.xc(11,X,2,1,"div",2),c.Sb(),c.Tb(12,"mat-card-actions"),c.Tb(13,"button",3),c.yc(14,"Allo"),c.Sb(),c.Sb(),c.Sb()),2&t){var i,l,n=null==(i=e.spillService.spillGetModel$.getValue())?null:i.Working,r=null==(l=e.spillService.spillListModel$.getValue())?null:l.length;c.jc("ngIf",n),c.Bb(9),c.zc(e.spillService.spillTextModel$.getValue().Title),c.Bb(2),c.jc("ngIf",r)}},directives:[l.l,S.a,S.d,S.g,h.b,S.f,S.c,S.b,T.a,l.k,v.a,A],styles:[""],changeDetection:0}),J),canActivate:[i("auXs").a]}],Z=((K=function t(){_classCallCheck(this,t)}).\u0275mod=c.Lb({type:K}),K.\u0275inj=c.Kb({factory:function(t){return new(t||K)},imports:[[n.e.forChild(Y)],n.e]}),K),tt=i("B+Mi"),et=((Q=function t(){_classCallCheck(this,t)}).\u0275mod=c.Lb({type:Q}),Q.\u0275inj=c.Kb({factory:function(t){return new(t||Q)},imports:[[l.c,n.e,Z,tt.a,y.g,y.o]]}),Q)}}]);