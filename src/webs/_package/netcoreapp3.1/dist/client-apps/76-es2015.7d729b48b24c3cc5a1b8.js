(window.webpackJsonp=window.webpackJsonp||[]).push([[76],{IH5r:function(e,t,i){"use strict";i.r(t),i.d(t,"RainExceedanceClimateSiteModule",(function(){return H}));var a=i("ofXK"),c=i("tyNb");function n(e){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}var r=i("QRvi"),s=i("fXoL"),o=i("2Vo4"),l=i("LRne"),b=i("tk/3"),d=i("lJxs"),m=i("JIr8"),u=i("gkM4");let p=(()=>{class e{constructor(e,t){this.httpClient=e,this.httpClientService=t,this.rainexceedanceclimatesiteTextModel$=new o.a({}),this.rainexceedanceclimatesiteListModel$=new o.a({}),this.rainexceedanceclimatesiteGetModel$=new o.a({}),this.rainexceedanceclimatesitePutModel$=new o.a({}),this.rainexceedanceclimatesitePostModel$=new o.a({}),this.rainexceedanceclimatesiteDeleteModel$=new o.a({}),n(this.rainexceedanceclimatesiteTextModel$),this.rainexceedanceclimatesiteTextModel$.next({Title:"Something2 for text"})}GetRainExceedanceClimateSiteList(){return this.httpClientService.BeforeHttpClient(this.rainexceedanceclimatesiteGetModel$),this.httpClient.get("/api/RainExceedanceClimateSite").pipe(Object(d.a)(e=>{this.httpClientService.DoSuccess(this.rainexceedanceclimatesiteListModel$,this.rainexceedanceclimatesiteGetModel$,e,r.a.Get,null)}),Object(m.a)(e=>Object(l.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.rainexceedanceclimatesiteListModel$,this.rainexceedanceclimatesiteGetModel$,e)}))))}PutRainExceedanceClimateSite(e){return this.httpClientService.BeforeHttpClient(this.rainexceedanceclimatesitePutModel$),this.httpClient.put("/api/RainExceedanceClimateSite",e,{headers:new b.d}).pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.rainexceedanceclimatesiteListModel$,this.rainexceedanceclimatesitePutModel$,t,r.a.Put,e)}),Object(m.a)(e=>Object(l.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.rainexceedanceclimatesiteListModel$,this.rainexceedanceclimatesitePutModel$,e)}))))}PostRainExceedanceClimateSite(e){return this.httpClientService.BeforeHttpClient(this.rainexceedanceclimatesitePostModel$),this.httpClient.post("/api/RainExceedanceClimateSite",e,{headers:new b.d}).pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.rainexceedanceclimatesiteListModel$,this.rainexceedanceclimatesitePostModel$,t,r.a.Post,e)}),Object(m.a)(e=>Object(l.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.rainexceedanceclimatesiteListModel$,this.rainexceedanceclimatesitePostModel$,e)}))))}DeleteRainExceedanceClimateSite(e){return this.httpClientService.BeforeHttpClient(this.rainexceedanceclimatesiteDeleteModel$),this.httpClient.delete("/api/RainExceedanceClimateSite/"+e.RainExceedanceClimateSiteID).pipe(Object(d.a)(t=>{this.httpClientService.DoSuccess(this.rainexceedanceclimatesiteListModel$,this.rainexceedanceclimatesiteDeleteModel$,t,r.a.Delete,e)}),Object(m.a)(e=>Object(l.a)(e).pipe(Object(d.a)(e=>{this.httpClientService.DoCatchError(this.rainexceedanceclimatesiteListModel$,this.rainexceedanceclimatesiteDeleteModel$,e)}))))}}return e.\u0275fac=function(t){return new(t||e)(s.Xb(b.b),s.Xb(u.a))},e.\u0275prov=s.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var h=i("Wp6s"),S=i("bTqV"),x=i("bv9b"),f=i("NFeN"),C=i("3Pt+"),T=i("kmnG"),I=i("qFsG");function D(e,t){1&e&&s.Ob(0,"mat-progress-bar",9)}function g(e,t){1&e&&s.Ob(0,"mat-progress-bar",9)}function E(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function y(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,E,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function v(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function R(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,v,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function P(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function w(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,P,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function $(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function B(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,$,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}function j(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function O(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,j,3,0,"span",4),s.Sb()),2&e){const e=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,e)),s.Bb(3),s.jc("ngIf",e.required)}}let M=(()=>{class e{constructor(e,t){this.rainexceedanceclimatesiteService=e,this.fb=t,this.rainexceedanceclimatesite=null,this.httpClientCommand=r.a.Put}GetPut(){return this.httpClientCommand==r.a.Put}PutRainExceedanceClimateSite(e){this.sub=this.rainexceedanceclimatesiteService.PutRainExceedanceClimateSite(e).subscribe()}PostRainExceedanceClimateSite(e){this.sub=this.rainexceedanceclimatesiteService.PostRainExceedanceClimateSite(e).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}FillFormBuilderGroup(e){if(this.rainexceedanceclimatesite){let t=this.fb.group({RainExceedanceClimateSiteID:[{value:e===r.a.Post?0:this.rainexceedanceclimatesite.RainExceedanceClimateSiteID,disabled:!1},[C.p.required]],RainExceedanceTVItemID:[{value:this.rainexceedanceclimatesite.RainExceedanceTVItemID,disabled:!1},[C.p.required]],ClimateSiteTVItemID:[{value:this.rainexceedanceclimatesite.ClimateSiteTVItemID,disabled:!1},[C.p.required]],LastUpdateDate_UTC:[{value:this.rainexceedanceclimatesite.LastUpdateDate_UTC,disabled:!1},[C.p.required]],LastUpdateContactTVItemID:[{value:this.rainexceedanceclimatesite.LastUpdateContactTVItemID,disabled:!1},[C.p.required]]});this.rainexceedanceclimatesiteFormEdit=t}}}return e.\u0275fac=function(t){return new(t||e)(s.Nb(p),s.Nb(C.d))},e.\u0275cmp=s.Hb({type:e,selectors:[["app-rainexceedanceclimatesite-edit"]],inputs:{rainexceedanceclimatesite:"rainexceedanceclimatesite",httpClientCommand:"httpClientCommand"},decls:35,vars:9,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","RainExceedanceClimateSiteID"],[4,"ngIf"],["matInput","","type","number","formControlName","RainExceedanceTVItemID"],["matInput","","type","number","formControlName","ClimateSiteTVItemID"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(e,t){1&e&&(s.Tb(0,"form",0),s.ac("ngSubmit",(function(){return t.GetPut()?t.PutRainExceedanceClimateSite(t.rainexceedanceclimatesiteFormEdit.value):t.PostRainExceedanceClimateSite(t.rainexceedanceclimatesiteFormEdit.value)})),s.Tb(1,"h3"),s.yc(2," RainExceedanceClimateSite "),s.Tb(3,"button",1),s.Tb(4,"span"),s.yc(5),s.Sb(),s.Sb(),s.xc(6,D,1,0,"mat-progress-bar",2),s.xc(7,g,1,0,"mat-progress-bar",2),s.Sb(),s.Tb(8,"p"),s.Tb(9,"mat-form-field"),s.Tb(10,"mat-label"),s.yc(11,"RainExceedanceClimateSiteID"),s.Sb(),s.Ob(12,"input",3),s.xc(13,y,6,4,"mat-error",4),s.Sb(),s.Tb(14,"mat-form-field"),s.Tb(15,"mat-label"),s.yc(16,"RainExceedanceTVItemID"),s.Sb(),s.Ob(17,"input",5),s.xc(18,R,6,4,"mat-error",4),s.Sb(),s.Tb(19,"mat-form-field"),s.Tb(20,"mat-label"),s.yc(21,"ClimateSiteTVItemID"),s.Sb(),s.Ob(22,"input",6),s.xc(23,w,6,4,"mat-error",4),s.Sb(),s.Tb(24,"mat-form-field"),s.Tb(25,"mat-label"),s.yc(26,"LastUpdateDate_UTC"),s.Sb(),s.Ob(27,"input",7),s.xc(28,B,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Tb(29,"p"),s.Tb(30,"mat-form-field"),s.Tb(31,"mat-label"),s.yc(32,"LastUpdateContactTVItemID"),s.Sb(),s.Ob(33,"input",8),s.xc(34,O,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Sb()),2&e&&(s.jc("formGroup",t.rainexceedanceclimatesiteFormEdit),s.Bb(5),s.Ac("",t.GetPut()?"Put":"Post"," RainExceedanceClimateSite"),s.Bb(1),s.jc("ngIf",t.rainexceedanceclimatesiteService.rainexceedanceclimatesitePutModel$.getValue().Working),s.Bb(1),s.jc("ngIf",t.rainexceedanceclimatesiteService.rainexceedanceclimatesitePostModel$.getValue().Working),s.Bb(6),s.jc("ngIf",t.rainexceedanceclimatesiteFormEdit.controls.RainExceedanceClimateSiteID.errors),s.Bb(5),s.jc("ngIf",t.rainexceedanceclimatesiteFormEdit.controls.RainExceedanceTVItemID.errors),s.Bb(5),s.jc("ngIf",t.rainexceedanceclimatesiteFormEdit.controls.ClimateSiteTVItemID.errors),s.Bb(5),s.jc("ngIf",t.rainexceedanceclimatesiteFormEdit.controls.LastUpdateDate_UTC.errors),s.Bb(6),s.jc("ngIf",t.rainexceedanceclimatesiteFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[C.q,C.l,C.f,S.b,a.l,T.c,T.f,I.b,C.n,C.c,C.k,C.e,x.a,T.b],pipes:[a.f],styles:[""],changeDetection:0}),e})();function L(e,t){1&e&&s.Ob(0,"mat-progress-bar",4)}function V(e,t){1&e&&s.Ob(0,"mat-progress-bar",4)}function G(e,t){if(1&e&&(s.Tb(0,"p"),s.Ob(1,"app-rainexceedanceclimatesite-edit",8),s.Sb()),2&e){const e=s.ec().$implicit,t=s.ec(2);s.Bb(1),s.jc("rainexceedanceclimatesite",e)("httpClientCommand",t.GetPutEnum())}}function k(e,t){if(1&e&&(s.Tb(0,"p"),s.Ob(1,"app-rainexceedanceclimatesite-edit",8),s.Sb()),2&e){const e=s.ec().$implicit,t=s.ec(2);s.Bb(1),s.jc("rainexceedanceclimatesite",e)("httpClientCommand",t.GetPostEnum())}}function U(e,t){if(1&e){const e=s.Ub();s.Tb(0,"div"),s.Tb(1,"p"),s.Tb(2,"button",6),s.ac("click",(function(){s.rc(e);const i=t.$implicit;return s.ec(2).DeleteRainExceedanceClimateSite(i)})),s.Tb(3,"span"),s.yc(4),s.Sb(),s.Tb(5,"mat-icon"),s.yc(6,"delete"),s.Sb(),s.Sb(),s.yc(7,"\xa0\xa0\xa0 "),s.Tb(8,"button",7),s.ac("click",(function(){s.rc(e);const i=t.$implicit;return s.ec(2).ShowPut(i)})),s.Tb(9,"span"),s.yc(10,"Show Put"),s.Sb(),s.Sb(),s.yc(11,"\xa0\xa0 "),s.Tb(12,"button",7),s.ac("click",(function(){s.rc(e);const i=t.$implicit;return s.ec(2).ShowPost(i)})),s.Tb(13,"span"),s.yc(14,"Show Post"),s.Sb(),s.Sb(),s.yc(15,"\xa0\xa0 "),s.xc(16,V,1,0,"mat-progress-bar",0),s.Sb(),s.xc(17,G,2,2,"p",2),s.xc(18,k,2,2,"p",2),s.Tb(19,"blockquote"),s.Tb(20,"p"),s.Tb(21,"span"),s.yc(22),s.Sb(),s.Tb(23,"span"),s.yc(24),s.Sb(),s.Tb(25,"span"),s.yc(26),s.Sb(),s.Tb(27,"span"),s.yc(28),s.Sb(),s.Sb(),s.Tb(29,"p"),s.Tb(30,"span"),s.yc(31),s.Sb(),s.Sb(),s.Sb(),s.Sb()}if(2&e){const e=t.$implicit,i=s.ec(2);s.Bb(4),s.Ac("Delete RainExceedanceClimateSiteID [",e.RainExceedanceClimateSiteID,"]\xa0\xa0\xa0"),s.Bb(4),s.jc("color",i.GetPutButtonColor(e)),s.Bb(4),s.jc("color",i.GetPostButtonColor(e)),s.Bb(4),s.jc("ngIf",i.rainexceedanceclimatesiteService.rainexceedanceclimatesiteDeleteModel$.getValue().Working),s.Bb(1),s.jc("ngIf",i.IDToShow===e.RainExceedanceClimateSiteID&&i.showType===i.GetPutEnum()),s.Bb(1),s.jc("ngIf",i.IDToShow===e.RainExceedanceClimateSiteID&&i.showType===i.GetPostEnum()),s.Bb(4),s.Ac("RainExceedanceClimateSiteID: [",e.RainExceedanceClimateSiteID,"]"),s.Bb(2),s.Ac(" --- RainExceedanceTVItemID: [",e.RainExceedanceTVItemID,"]"),s.Bb(2),s.Ac(" --- ClimateSiteTVItemID: [",e.ClimateSiteTVItemID,"]"),s.Bb(2),s.Ac(" --- LastUpdateDate_UTC: [",e.LastUpdateDate_UTC,"]"),s.Bb(3),s.Ac("LastUpdateContactTVItemID: [",e.LastUpdateContactTVItemID,"]")}}function q(e,t){if(1&e&&(s.Tb(0,"div"),s.xc(1,U,32,11,"div",5),s.Sb()),2&e){const e=s.ec();s.Bb(1),s.jc("ngForOf",e.rainexceedanceclimatesiteService.rainexceedanceclimatesiteListModel$.getValue())}}const F=[{path:"",component:(()=>{class e{constructor(e,t,i){this.rainexceedanceclimatesiteService=e,this.router=t,this.httpClientService=i,this.showType=null,i.oldURL=t.url}GetPutButtonColor(e){return this.IDToShow===e.RainExceedanceClimateSiteID&&this.showType===r.a.Put?"primary":"basic"}GetPostButtonColor(e){return this.IDToShow===e.RainExceedanceClimateSiteID&&this.showType===r.a.Post?"primary":"basic"}ShowPut(e){this.IDToShow===e.RainExceedanceClimateSiteID&&this.showType===r.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RainExceedanceClimateSiteID,this.showType=r.a.Put)}ShowPost(e){this.IDToShow===e.RainExceedanceClimateSiteID&&this.showType===r.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.RainExceedanceClimateSiteID,this.showType=r.a.Post)}GetPutEnum(){return r.a.Put}GetPostEnum(){return r.a.Post}GetRainExceedanceClimateSiteList(){this.sub=this.rainexceedanceclimatesiteService.GetRainExceedanceClimateSiteList().subscribe()}DeleteRainExceedanceClimateSite(e){this.sub=this.rainexceedanceclimatesiteService.DeleteRainExceedanceClimateSite(e).subscribe()}ngOnInit(){n(this.rainexceedanceclimatesiteService.rainexceedanceclimatesiteTextModel$)}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(t){return new(t||e)(s.Nb(p),s.Nb(c.b),s.Nb(u.a))},e.\u0275cmp=s.Hb({type:e,selectors:[["app-rainexceedanceclimatesite"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"rainexceedanceclimatesite","httpClientCommand"]],template:function(e,t){if(1&e&&(s.xc(0,L,1,0,"mat-progress-bar",0),s.Tb(1,"mat-card"),s.Tb(2,"mat-card-header"),s.Tb(3,"mat-card-title"),s.yc(4," RainExceedanceClimateSite works! "),s.Tb(5,"button",1),s.ac("click",(function(){return t.GetRainExceedanceClimateSiteList()})),s.Tb(6,"span"),s.yc(7,"Get RainExceedanceClimateSite"),s.Sb(),s.Sb(),s.Sb(),s.Tb(8,"mat-card-subtitle"),s.yc(9),s.Sb(),s.Sb(),s.Tb(10,"mat-card-content"),s.xc(11,q,2,1,"div",2),s.Sb(),s.Tb(12,"mat-card-actions"),s.Tb(13,"button",3),s.yc(14,"Allo"),s.Sb(),s.Sb(),s.Sb()),2&e){var i;const e=null==(i=t.rainexceedanceclimatesiteService.rainexceedanceclimatesiteGetModel$.getValue())?null:i.Working;var a;const c=null==(a=t.rainexceedanceclimatesiteService.rainexceedanceclimatesiteListModel$.getValue())?null:a.length;s.jc("ngIf",e),s.Bb(9),s.zc(t.rainexceedanceclimatesiteService.rainexceedanceclimatesiteTextModel$.getValue().Title),s.Bb(2),s.jc("ngIf",c)}},directives:[a.l,h.a,h.d,h.g,S.b,h.f,h.c,h.b,x.a,a.k,f.a,M],styles:[""],changeDetection:0}),e})(),canActivate:[i("auXs").a]}];let N=(()=>{class e{}return e.\u0275mod=s.Lb({type:e}),e.\u0275inj=s.Kb({factory:function(t){return new(t||e)},imports:[[c.e.forChild(F)],c.e]}),e})();var A=i("B+Mi");let H=(()=>{class e{}return e.\u0275mod=s.Lb({type:e}),e.\u0275inj=s.Kb({factory:function(t){return new(t||e)},imports:[[a.c,c.e,N,A.a,C.g,C.o]]}),e})()},QRvi:function(e,t,i){"use strict";i.d(t,"a",(function(){return a}));var a=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,i){"use strict";i.d(t,"a",(function(){return r}));var a=i("QRvi"),c=i("fXoL"),n=i("tyNb");let r=(()=>{class e{constructor(e){this.router=e,this.oldURL=e.url}BeforeHttpClient(e){e.next({Working:!0,Error:null,Status:null})}DoCatchError(e,t,i){e.next(null),t.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(e,t,i,c,n){if(c===a.a.Get&&e.next(i),c===a.a.Put&&(e.getValue()[0]=i),c===a.a.Post&&e.getValue().push(i),c===a.a.Delete){const t=e.getValue().indexOf(n);e.getValue().splice(t,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return e.\u0275fac=function(t){return new(t||e)(c.Xb(n.b))},e.\u0275prov=c.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()}}]);