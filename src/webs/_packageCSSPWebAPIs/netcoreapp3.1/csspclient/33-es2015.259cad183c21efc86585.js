(window.webpackJsonp=window.webpackJsonp||[]).push([[33],{B5nr:function(t,e,n){"use strict";n.r(e),n.d(e,"TVItemStatModule",(function(){return Y}));var u=n("ofXK"),i=n("tyNb");function s(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var m=n("BJD1"),o=n("QRvi"),r=n("fXoL"),a=n("2Vo4"),c=n("LRne"),p=n("tk/3"),l=n("lJxs"),E=n("JIr8"),T=n("gkM4");let h=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.tvitemstatTextModel$=new a.a({}),this.tvitemstatListModel$=new a.a({}),this.tvitemstatGetModel$=new a.a({}),this.tvitemstatPutModel$=new a.a({}),this.tvitemstatPostModel$=new a.a({}),this.tvitemstatDeleteModel$=new a.a({}),s(this.tvitemstatTextModel$),this.tvitemstatTextModel$.next({Title:"Something2 for text"})}GetTVItemStatList(){return this.httpClientService.BeforeHttpClient(this.tvitemstatGetModel$),this.httpClient.get("/api/TVItemStat").pipe(Object(l.a)(t=>{this.httpClientService.DoSuccess(this.tvitemstatListModel$,this.tvitemstatGetModel$,t,o.a.Get,null)}),Object(E.a)(t=>Object(c.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.tvitemstatListModel$,this.tvitemstatGetModel$,t)}))))}PutTVItemStat(t){return this.httpClientService.BeforeHttpClient(this.tvitemstatPutModel$),this.httpClient.put("/api/TVItemStat",t,{headers:new p.d}).pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.tvitemstatListModel$,this.tvitemstatPutModel$,e,o.a.Put,t)}),Object(E.a)(t=>Object(c.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.tvitemstatListModel$,this.tvitemstatPutModel$,t)}))))}PostTVItemStat(t){return this.httpClientService.BeforeHttpClient(this.tvitemstatPostModel$),this.httpClient.post("/api/TVItemStat",t,{headers:new p.d}).pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.tvitemstatListModel$,this.tvitemstatPostModel$,e,o.a.Post,t)}),Object(E.a)(t=>Object(c.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.tvitemstatListModel$,this.tvitemstatPostModel$,t)}))))}DeleteTVItemStat(t){return this.httpClientService.BeforeHttpClient(this.tvitemstatDeleteModel$),this.httpClient.delete("/api/TVItemStat/"+t.TVItemStatID).pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.tvitemstatListModel$,this.tvitemstatDeleteModel$,e,o.a.Delete,t)}),Object(E.a)(t=>Object(c.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.tvitemstatListModel$,this.tvitemstatDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(r.Xb(p.b),r.Xb(T.a))},t.\u0275prov=r.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var I=n("Wp6s"),b=n("bTqV"),D=n("bv9b"),f=n("NFeN"),d=n("3Pt+"),S=n("kmnG"),x=n("qFsG"),v=n("d3UM"),M=n("FKr1");function C(t,e){1&t&&r.Ob(0,"mat-progress-bar",11)}function y(t,e){1&t&&r.Ob(0,"mat-progress-bar",11)}function P(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function g(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,P,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function V(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function B(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,V,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function O(t,e){if(1&t&&(r.Tb(0,"mat-option",12),r.yc(1),r.Sb()),2&t){const t=e.$implicit;r.jc("value",t.EnumID),r.Bb(1),r.Ac(" ",t.EnumText," ")}}function j(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function L(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,j,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function $(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function w(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Min - 0"),r.Ob(2,"br"),r.Sb())}function k(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Max - 10000000"),r.Ob(2,"br"),r.Sb())}function G(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,$,3,0,"span",4),r.xc(6,w,3,0,"span",4),r.xc(7,k,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,4,t)),r.Bb(3),r.jc("ngIf",t.required),r.Bb(1),r.jc("ngIf",t.min),r.Bb(1),r.jc("ngIf",t.min)}}function R(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function W(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,R,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function U(t,e){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function F(t,e){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,U,3,0,"span",4),r.Sb()),2&t){const t=e.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}let N=(()=>{class t{constructor(t,e){this.tvitemstatService=t,this.fb=e,this.tvitemstat=null,this.httpClientCommand=o.a.Put}GetPut(){return this.httpClientCommand==o.a.Put}PutTVItemStat(t){this.sub=this.tvitemstatService.PutTVItemStat(t).subscribe()}PostTVItemStat(t){this.sub=this.tvitemstatService.PostTVItemStat(t).subscribe()}ngOnInit(){this.tVTypeList=Object(m.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.tvitemstat){let e=this.fb.group({TVItemStatID:[{value:t===o.a.Post?0:this.tvitemstat.TVItemStatID,disabled:!1},[d.p.required]],TVItemID:[{value:this.tvitemstat.TVItemID,disabled:!1},[d.p.required]],TVType:[{value:this.tvitemstat.TVType,disabled:!1},[d.p.required]],ChildCount:[{value:this.tvitemstat.ChildCount,disabled:!1},[d.p.required,d.p.min(0),d.p.max(1e7)]],LastUpdateDate_UTC:[{value:this.tvitemstat.LastUpdateDate_UTC,disabled:!1},[d.p.required]],LastUpdateContactTVItemID:[{value:this.tvitemstat.LastUpdateContactTVItemID,disabled:!1},[d.p.required]]});this.tvitemstatFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(r.Nb(h),r.Nb(d.d))},t.\u0275cmp=r.Hb({type:t,selectors:[["app-tvitemstat-edit"]],inputs:{tvitemstat:"tvitemstat",httpClientCommand:"httpClientCommand"},decls:41,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TVItemStatID"],[4,"ngIf"],["matInput","","type","number","formControlName","TVItemID"],["formControlName","TVType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","number","formControlName","ChildCount"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(r.Tb(0,"form",0),r.ac("ngSubmit",(function(){return e.GetPut()?e.PutTVItemStat(e.tvitemstatFormEdit.value):e.PostTVItemStat(e.tvitemstatFormEdit.value)})),r.Tb(1,"h3"),r.yc(2," TVItemStat "),r.Tb(3,"button",1),r.Tb(4,"span"),r.yc(5),r.Sb(),r.Sb(),r.xc(6,C,1,0,"mat-progress-bar",2),r.xc(7,y,1,0,"mat-progress-bar",2),r.Sb(),r.Tb(8,"p"),r.Tb(9,"mat-form-field"),r.Tb(10,"mat-label"),r.yc(11,"TVItemStatID"),r.Sb(),r.Ob(12,"input",3),r.xc(13,g,6,4,"mat-error",4),r.Sb(),r.Tb(14,"mat-form-field"),r.Tb(15,"mat-label"),r.yc(16,"TVItemID"),r.Sb(),r.Ob(17,"input",5),r.xc(18,B,6,4,"mat-error",4),r.Sb(),r.Tb(19,"mat-form-field"),r.Tb(20,"mat-label"),r.yc(21,"TVType"),r.Sb(),r.Tb(22,"mat-select",6),r.xc(23,O,2,2,"mat-option",7),r.Sb(),r.xc(24,L,6,4,"mat-error",4),r.Sb(),r.Tb(25,"mat-form-field"),r.Tb(26,"mat-label"),r.yc(27,"ChildCount"),r.Sb(),r.Ob(28,"input",8),r.xc(29,G,8,6,"mat-error",4),r.Sb(),r.Sb(),r.Tb(30,"p"),r.Tb(31,"mat-form-field"),r.Tb(32,"mat-label"),r.yc(33,"LastUpdateDate_UTC"),r.Sb(),r.Ob(34,"input",9),r.xc(35,W,6,4,"mat-error",4),r.Sb(),r.Tb(36,"mat-form-field"),r.Tb(37,"mat-label"),r.yc(38,"LastUpdateContactTVItemID"),r.Sb(),r.Ob(39,"input",10),r.xc(40,F,6,4,"mat-error",4),r.Sb(),r.Sb(),r.Sb()),2&t&&(r.jc("formGroup",e.tvitemstatFormEdit),r.Bb(5),r.Ac("",e.GetPut()?"Put":"Post"," TVItemStat"),r.Bb(1),r.jc("ngIf",e.tvitemstatService.tvitemstatPutModel$.getValue().Working),r.Bb(1),r.jc("ngIf",e.tvitemstatService.tvitemstatPostModel$.getValue().Working),r.Bb(6),r.jc("ngIf",e.tvitemstatFormEdit.controls.TVItemStatID.errors),r.Bb(5),r.jc("ngIf",e.tvitemstatFormEdit.controls.TVItemID.errors),r.Bb(5),r.jc("ngForOf",e.tVTypeList),r.Bb(1),r.jc("ngIf",e.tvitemstatFormEdit.controls.TVType.errors),r.Bb(5),r.jc("ngIf",e.tvitemstatFormEdit.controls.ChildCount.errors),r.Bb(6),r.jc("ngIf",e.tvitemstatFormEdit.controls.LastUpdateDate_UTC.errors),r.Bb(5),r.jc("ngIf",e.tvitemstatFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[d.q,d.l,d.f,b.b,u.l,S.c,S.f,x.b,d.n,d.c,d.k,d.e,v.a,u.k,D.a,S.b,M.n],pipes:[u.f],styles:[""],changeDetection:0}),t})();function q(t,e){1&t&&r.Ob(0,"mat-progress-bar",4)}function A(t,e){1&t&&r.Ob(0,"mat-progress-bar",4)}function Q(t,e){if(1&t&&(r.Tb(0,"p"),r.Ob(1,"app-tvitemstat-edit",8),r.Sb()),2&t){const t=r.ec().$implicit,e=r.ec(2);r.Bb(1),r.jc("tvitemstat",t)("httpClientCommand",e.GetPutEnum())}}function H(t,e){if(1&t&&(r.Tb(0,"p"),r.Ob(1,"app-tvitemstat-edit",8),r.Sb()),2&t){const t=r.ec().$implicit,e=r.ec(2);r.Bb(1),r.jc("tvitemstat",t)("httpClientCommand",e.GetPostEnum())}}function z(t,e){if(1&t){const t=r.Ub();r.Tb(0,"div"),r.Tb(1,"p"),r.Tb(2,"button",6),r.ac("click",(function(){r.rc(t);const n=e.$implicit;return r.ec(2).DeleteTVItemStat(n)})),r.Tb(3,"span"),r.yc(4),r.Sb(),r.Tb(5,"mat-icon"),r.yc(6,"delete"),r.Sb(),r.Sb(),r.yc(7,"\xa0\xa0\xa0 "),r.Tb(8,"button",7),r.ac("click",(function(){r.rc(t);const n=e.$implicit;return r.ec(2).ShowPut(n)})),r.Tb(9,"span"),r.yc(10,"Show Put"),r.Sb(),r.Sb(),r.yc(11,"\xa0\xa0 "),r.Tb(12,"button",7),r.ac("click",(function(){r.rc(t);const n=e.$implicit;return r.ec(2).ShowPost(n)})),r.Tb(13,"span"),r.yc(14,"Show Post"),r.Sb(),r.Sb(),r.yc(15,"\xa0\xa0 "),r.xc(16,A,1,0,"mat-progress-bar",0),r.Sb(),r.xc(17,Q,2,2,"p",2),r.xc(18,H,2,2,"p",2),r.Tb(19,"blockquote"),r.Tb(20,"p"),r.Tb(21,"span"),r.yc(22),r.Sb(),r.Tb(23,"span"),r.yc(24),r.Sb(),r.Tb(25,"span"),r.yc(26),r.Sb(),r.Tb(27,"span"),r.yc(28),r.Sb(),r.Sb(),r.Tb(29,"p"),r.Tb(30,"span"),r.yc(31),r.Sb(),r.Tb(32,"span"),r.yc(33),r.Sb(),r.Sb(),r.Sb(),r.Sb()}if(2&t){const t=e.$implicit,n=r.ec(2);r.Bb(4),r.Ac("Delete TVItemStatID [",t.TVItemStatID,"]\xa0\xa0\xa0"),r.Bb(4),r.jc("color",n.GetPutButtonColor(t)),r.Bb(4),r.jc("color",n.GetPostButtonColor(t)),r.Bb(4),r.jc("ngIf",n.tvitemstatService.tvitemstatDeleteModel$.getValue().Working),r.Bb(1),r.jc("ngIf",n.IDToShow===t.TVItemStatID&&n.showType===n.GetPutEnum()),r.Bb(1),r.jc("ngIf",n.IDToShow===t.TVItemStatID&&n.showType===n.GetPostEnum()),r.Bb(4),r.Ac("TVItemStatID: [",t.TVItemStatID,"]"),r.Bb(2),r.Ac(" --- TVItemID: [",t.TVItemID,"]"),r.Bb(2),r.Ac(" --- TVType: [",n.GetTVTypeEnumText(t.TVType),"]"),r.Bb(2),r.Ac(" --- ChildCount: [",t.ChildCount,"]"),r.Bb(3),r.Ac("LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),r.Bb(2),r.Ac(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function K(t,e){if(1&t&&(r.Tb(0,"div"),r.xc(1,z,34,12,"div",5),r.Sb()),2&t){const t=r.ec();r.Bb(1),r.jc("ngForOf",t.tvitemstatService.tvitemstatListModel$.getValue())}}const J=[{path:"",component:(()=>{class t{constructor(t,e,n){this.tvitemstatService=t,this.router=e,this.httpClientService=n,this.showType=null,n.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.TVItemStatID&&this.showType===o.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.TVItemStatID&&this.showType===o.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.TVItemStatID&&this.showType===o.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TVItemStatID,this.showType=o.a.Put)}ShowPost(t){this.IDToShow===t.TVItemStatID&&this.showType===o.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TVItemStatID,this.showType=o.a.Post)}GetPutEnum(){return o.a.Put}GetPostEnum(){return o.a.Post}GetTVItemStatList(){this.sub=this.tvitemstatService.GetTVItemStatList().subscribe()}DeleteTVItemStat(t){this.sub=this.tvitemstatService.DeleteTVItemStat(t).subscribe()}GetTVTypeEnumText(t){return Object(m.a)(t)}ngOnInit(){s(this.tvitemstatService.tvitemstatTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(r.Nb(h),r.Nb(i.b),r.Nb(T.a))},t.\u0275cmp=r.Hb({type:t,selectors:[["app-tvitemstat"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tvitemstat","httpClientCommand"]],template:function(t,e){if(1&t&&(r.xc(0,q,1,0,"mat-progress-bar",0),r.Tb(1,"mat-card"),r.Tb(2,"mat-card-header"),r.Tb(3,"mat-card-title"),r.yc(4," TVItemStat works! "),r.Tb(5,"button",1),r.ac("click",(function(){return e.GetTVItemStatList()})),r.Tb(6,"span"),r.yc(7,"Get TVItemStat"),r.Sb(),r.Sb(),r.Sb(),r.Tb(8,"mat-card-subtitle"),r.yc(9),r.Sb(),r.Sb(),r.Tb(10,"mat-card-content"),r.xc(11,K,2,1,"div",2),r.Sb(),r.Tb(12,"mat-card-actions"),r.Tb(13,"button",3),r.yc(14,"Allo"),r.Sb(),r.Sb(),r.Sb()),2&t){var n;const t=null==(n=e.tvitemstatService.tvitemstatGetModel$.getValue())?null:n.Working;var u;const i=null==(u=e.tvitemstatService.tvitemstatListModel$.getValue())?null:u.length;r.jc("ngIf",t),r.Bb(9),r.zc(e.tvitemstatService.tvitemstatTextModel$.getValue().Title),r.Bb(2),r.jc("ngIf",i)}},directives:[u.l,I.a,I.d,I.g,b.b,I.f,I.c,I.b,D.a,u.k,f.a,N],styles:[""],changeDetection:0}),t})(),canActivate:[n("auXs").a]}];let X=(()=>{class t{}return t.\u0275mod=r.Lb({type:t}),t.\u0275inj=r.Kb({factory:function(e){return new(e||t)},imports:[[i.e.forChild(J)],i.e]}),t})();var _=n("B+Mi");let Y=(()=>{class t{}return t.\u0275mod=r.Lb({type:t}),t.\u0275inj=r.Kb({factory:function(e){return new(e||t)},imports:[[u.c,i.e,X,_.a,d.g,d.o]]}),t})()},BJD1:function(t,e,n){"use strict";function u(){let t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"Base"}),t.push({EnumID:2,EnumText:"Adresse"}),t.push({EnumID:3,EnumText:"R\xe9gion"}),t.push({EnumID:4,EnumText:"Climate Site (fr)"}),t.push({EnumID:5,EnumText:"Contact (fr)"}),t.push({EnumID:6,EnumText:"Pays"}),t.push({EnumID:7,EnumText:"Courriel"}),t.push({EnumID:8,EnumText:"Fichier"}),t.push({EnumID:9,EnumText:"Poste hydrom\xe9trique"}),t.push({EnumID:10,EnumText:"Infrastructure"}),t.push({EnumID:11,EnumText:"Mike Boundary Condition Web Tide (fr)"}),t.push({EnumID:12,EnumText:"Mike Boundary Condition Mesh (fr)"}),t.push({EnumID:13,EnumText:"Sc\xe9nario MIKE"}),t.push({EnumID:14,EnumText:"Source MIKE"}),t.push({EnumID:15,EnumText:"Municipalit\xe9"}),t.push({EnumID:16,EnumText:"MWQM Site (fr)"}),t.push({EnumID:17,EnumText:"Site de la source de pollution"}),t.push({EnumID:18,EnumText:"Province "}),t.push({EnumID:19,EnumText:"Secteur"}),t.push({EnumID:20,EnumText:"Sous-secteur"}),t.push({EnumID:21,EnumText:"T\xe9l"}),t.push({EnumID:22,EnumText:"Poste de mar\xe9e"}),t.push({EnumID:23,EnumText:"MWQM Site Sample (fr)"}),t.push({EnumID:24,EnumText:"Usine de traitement de eaux us\xe9es"}),t.push({EnumID:25,EnumText:"Poste de pompage"}),t.push({EnumID:26,EnumText:"D\xe9versement"}),t.push({EnumID:27,EnumText:"Box Model"}),t.push({EnumID:28,EnumText:"Sc\xe9nario Visual Plumes"}),t.push({EnumID:29,EnumText:"\xc9missaire"}),t.push({EnumID:30,EnumText:"Other Infrastructure (fr)"}),t.push({EnumID:31,EnumText:"MWQM Run (fr)"}),t.push({EnumID:33,EnumText:"No Depuration (fr)"}),t.push({EnumID:34,EnumText:"\xc9chec"}),t.push({EnumID:35,EnumText:"R\xe9ussi"}),t.push({EnumID:36,EnumText:"Aucune donn\xe9e"}),t.push({EnumID:37,EnumText:"Less Than 10 Samples (fr)"}),t.push({EnumID:38,EnumText:"Mesh Node (fr)"}),t.push({EnumID:39,EnumText:"Web Tide Node (fr)"}),t.push({EnumID:40,EnumText:"MWQM Plan (fr)"}),t.push({EnumID:41,EnumText:"Voir autre municipalit\xe9"}),t.push({EnumID:42,EnumText:"Line overflow (fr)"}),t.push({EnumID:43,EnumText:"Box Model Inputs (fr)"}),t.push({EnumID:44,EnumText:"Box Model Results (fr)"}),t.push({EnumID:45,EnumText:"Climate Site Info (fr)"}),t.push({EnumID:46,EnumText:"Climate Site Data (fr)"}),t.push({EnumID:47,EnumText:"Hydrometric Site Info (fr)"}),t.push({EnumID:48,EnumText:"Hydrometric Site Data (fr)"}),t.push({EnumID:49,EnumText:"Infrastructure Info (fr)"}),t.push({EnumID:50,EnumText:"Lab Sheet Info (fr)"}),t.push({EnumID:51,EnumText:"Lab Sheet Detail Info (fr)"}),t.push({EnumID:52,EnumText:"Map Info (fr)"}),t.push({EnumID:53,EnumText:"Map Info Point (fr)"}),t.push({EnumID:54,EnumText:"Mike Source Start End Info (fr)"}),t.push({EnumID:55,EnumText:"MWQM Lookup MPN Info (fr)"}),t.push({EnumID:56,EnumText:"MWQM Plan Info (fr)"}),t.push({EnumID:57,EnumText:"MWQM Plan Subsector Info (fr)"}),t.push({EnumID:58,EnumText:"MWQM Plan Subsector Site Info (fr)"}),t.push({EnumID:59,EnumText:"MWQM Site Start End Info (fr)"}),t.push({EnumID:60,EnumText:"MWQM Subsector Info (fr)"}),t.push({EnumID:61,EnumText:"Pollution Source Site Info (fr)"}),t.push({EnumID:62,EnumText:"Pollution Source Site Observation Info (fr)"}),t.push({EnumID:63,EnumText:"Hydrometric Rating Curve Info (fr)"}),t.push({EnumID:64,EnumText:"Hydrometric Rating Curve Data Info (fr)"}),t.push({EnumID:65,EnumText:"Tide Location Info (fr)"}),t.push({EnumID:66,EnumText:"Tide Site Data Info (fr)"}),t.push({EnumID:67,EnumText:"Use Of Site (fr)"}),t.push({EnumID:68,EnumText:"Visual Plumes Scenario Info (fr)"}),t.push({EnumID:69,EnumText:"Visual Plumes Scenario Ambient (fr)"}),t.push({EnumID:70,EnumText:"Visual Plumes Scenario Results (fr)"}),t.push({EnumID:71,EnumText:"Totale fili\xe8re"}),t.push({EnumID:72,EnumText:"Source de pollution MIKE rivi\xe8re"}),t.push({EnumID:73,EnumText:"Source de pollution MIKE inclus"}),t.push({EnumID:74,EnumText:"Source de pollution MIKE non inclus"}),t.push({EnumID:75,EnumText:"Exceedance de pluie"}),t.push({EnumID:76,EnumText:"Liste de distribution des courriels"}),t.push({EnumID:77,EnumText:"Open Data (fr)"}),t.push({EnumID:78,EnumText:"Province Tools"}),t.push({EnumID:79,EnumText:"Classification"}),t.push({EnumID:80,EnumText:"Agr\xe9\xe9"}),t.push({EnumID:81,EnumText:"Restreint"}),t.push({EnumID:82,EnumText:"Interdit"}),t.push({EnumID:83,EnumText:"Agr\xe9\xe9 sous condition"}),t.push({EnumID:84,EnumText:"Restreint sous condition"}),t.push({EnumID:85,EnumText:"Open Data national (fr)"}),t.push({EnumID:86,EnumText:"Pollution source site Mike Scenario (fr)"}),t.push({EnumID:87,EnumText:"Subsector tools (fr)"})):(t.push({EnumID:1,EnumText:"Root"}),t.push({EnumID:2,EnumText:"Address"}),t.push({EnumID:3,EnumText:"Area"}),t.push({EnumID:4,EnumText:"Climate Site"}),t.push({EnumID:5,EnumText:"Contact"}),t.push({EnumID:6,EnumText:"Country"}),t.push({EnumID:7,EnumText:"Email"}),t.push({EnumID:8,EnumText:"File"}),t.push({EnumID:9,EnumText:"Hydrometric Site"}),t.push({EnumID:10,EnumText:"Infrastructure"}),t.push({EnumID:11,EnumText:"Mike Boundary Condition Web Tide"}),t.push({EnumID:12,EnumText:"Mike Boundary Condition Mesh"}),t.push({EnumID:13,EnumText:"Mike Scenario"}),t.push({EnumID:14,EnumText:"Mike Source"}),t.push({EnumID:15,EnumText:"Municipality"}),t.push({EnumID:16,EnumText:"MWQM Site"}),t.push({EnumID:17,EnumText:"Pollution Source Site"}),t.push({EnumID:18,EnumText:"Province"}),t.push({EnumID:19,EnumText:"Sector"}),t.push({EnumID:20,EnumText:"Subsector"}),t.push({EnumID:21,EnumText:"Tel"}),t.push({EnumID:22,EnumText:"Tide Site"}),t.push({EnumID:23,EnumText:"MWQM Site Sample"}),t.push({EnumID:24,EnumText:"Waste Water Treatment Plant"}),t.push({EnumID:25,EnumText:"Lift Station"}),t.push({EnumID:26,EnumText:"Spill"}),t.push({EnumID:27,EnumText:"Box Model"}),t.push({EnumID:28,EnumText:"Visual Plumes Scenario"}),t.push({EnumID:29,EnumText:"Outfall"}),t.push({EnumID:30,EnumText:"Other Infrastructure"}),t.push({EnumID:31,EnumText:"MWQM Run"}),t.push({EnumID:33,EnumText:"No Depuration"}),t.push({EnumID:34,EnumText:"Failed"}),t.push({EnumID:35,EnumText:"Passed"}),t.push({EnumID:36,EnumText:"No Data"}),t.push({EnumID:37,EnumText:"Less Than 10 Samples"}),t.push({EnumID:38,EnumText:"Mesh Node"}),t.push({EnumID:39,EnumText:"Web Tide Node"}),t.push({EnumID:40,EnumText:"MWQM Plan"}),t.push({EnumID:41,EnumText:"See other municipality"}),t.push({EnumID:42,EnumText:"Line overflow"}),t.push({EnumID:43,EnumText:"Box Model Inputs"}),t.push({EnumID:44,EnumText:"Box Model Results"}),t.push({EnumID:45,EnumText:"Climate Site Info"}),t.push({EnumID:46,EnumText:"Climate Site Data"}),t.push({EnumID:47,EnumText:"Hydrometric Site Info"}),t.push({EnumID:48,EnumText:"Hydrometric Site Data"}),t.push({EnumID:49,EnumText:"Infrastructure Info"}),t.push({EnumID:50,EnumText:"Lab Sheet Info"}),t.push({EnumID:51,EnumText:"Lab Sheet Detail Info"}),t.push({EnumID:52,EnumText:"Map Info"}),t.push({EnumID:53,EnumText:"Map Info Point"}),t.push({EnumID:54,EnumText:"Mike Source Start End Info"}),t.push({EnumID:55,EnumText:"MWQM Lookup MPN Info"}),t.push({EnumID:56,EnumText:"MWQM Plan Info"}),t.push({EnumID:57,EnumText:"MWQM Plan Subsector Info"}),t.push({EnumID:58,EnumText:"MWQM Plan Subsector Site Info"}),t.push({EnumID:59,EnumText:"MWQM Site Start End Info"}),t.push({EnumID:60,EnumText:"MWQM Subsector Info"}),t.push({EnumID:61,EnumText:"Pollution Source Site Info"}),t.push({EnumID:62,EnumText:"Pollution Source Site Observation Info"}),t.push({EnumID:63,EnumText:"Hydrometric Rating Curve Info"}),t.push({EnumID:64,EnumText:"Hydrometric Rating Curve Data Info"}),t.push({EnumID:65,EnumText:"Tide Location Info"}),t.push({EnumID:66,EnumText:"Tide Site Data Info"}),t.push({EnumID:67,EnumText:"Use Of Site"}),t.push({EnumID:68,EnumText:"Visual Plumes Scenario Info"}),t.push({EnumID:69,EnumText:"Visual Plumes Scenario Ambient"}),t.push({EnumID:70,EnumText:"Visual Plumes Scenario Results"}),t.push({EnumID:71,EnumText:"Total file"}),t.push({EnumID:72,EnumText:"Mike source is river"}),t.push({EnumID:73,EnumText:"Mike source included"}),t.push({EnumID:74,EnumText:"Mike source not included"}),t.push({EnumID:75,EnumText:"Rain exceedance"}),t.push({EnumID:76,EnumText:"Email distribution list"}),t.push({EnumID:77,EnumText:"Open Data"}),t.push({EnumID:78,EnumText:"Province Tools"}),t.push({EnumID:79,EnumText:"Classification"}),t.push({EnumID:80,EnumText:"Approved"}),t.push({EnumID:81,EnumText:"Restricted"}),t.push({EnumID:82,EnumText:"Prohibited"}),t.push({EnumID:83,EnumText:"Conditionally Approved"}),t.push({EnumID:84,EnumText:"Conditionally Restricted"}),t.push({EnumID:85,EnumText:"Open Data national"}),t.push({EnumID:86,EnumText:"Pollution source site Mike Scenario"}),t.push({EnumID:87,EnumText:"Subsector tools"})),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}function i(t){let e;return u().forEach(n=>{if(n.EnumID==t)return e=n.EnumText,!1}),e}n.d(e,"b",(function(){return u})),n.d(e,"a",(function(){return i}))},QRvi:function(t,e,n){"use strict";n.d(e,"a",(function(){return u}));var u=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,n){"use strict";n.d(e,"a",(function(){return m}));var u=n("QRvi"),i=n("fXoL"),s=n("tyNb");let m=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,n,i,s){if(i===u.a.Get&&t.next(n),i===u.a.Put&&(t.getValue()[0]=n),i===u.a.Post&&t.getValue().push(n),i===u.a.Delete){const e=t.getValue().indexOf(s);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,n,i,s){i===u.a.Get&&t.next(n),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(i.Xb(s.b))},t.\u0275prov=i.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);