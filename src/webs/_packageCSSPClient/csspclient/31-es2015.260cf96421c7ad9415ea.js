(window.webpackJsonp=window.webpackJsonp||[]).push([[31],{"+Qfo":function(t,e,n){"use strict";n.r(e),n.d(e,"TVItemModule",(function(){return nt}));var u=n("ofXK"),i=n("tyNb");function m(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}var o=n("BJD1"),s=n("QRvi"),r=n("fXoL"),a=n("2Vo4"),c=n("LRne"),p=n("tk/3"),l=n("lJxs"),b=n("JIr8"),E=n("gkM4");let h=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.tvitemTextModel$=new a.a({}),this.tvitemListModel$=new a.a({}),this.tvitemGetModel$=new a.a({}),this.tvitemPutModel$=new a.a({}),this.tvitemPostModel$=new a.a({}),this.tvitemDeleteModel$=new a.a({}),m(this.tvitemTextModel$),this.tvitemTextModel$.next({Title:"Something2 for text"})}GetTVItemList(){return this.httpClientService.BeforeHttpClient(this.tvitemGetModel$),this.httpClient.get("/api/TVItem").pipe(Object(l.a)(t=>{this.httpClientService.DoSuccess(this.tvitemListModel$,this.tvitemGetModel$,t,s.a.Get,null)}),Object(b.a)(t=>Object(c.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.tvitemListModel$,this.tvitemGetModel$,t)}))))}PutTVItem(t){return this.httpClientService.BeforeHttpClient(this.tvitemPutModel$),this.httpClient.put("/api/TVItem",t,{headers:new p.d}).pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.tvitemListModel$,this.tvitemPutModel$,e,s.a.Put,t)}),Object(b.a)(t=>Object(c.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.tvitemListModel$,this.tvitemPutModel$,t)}))))}PostTVItem(t){return this.httpClientService.BeforeHttpClient(this.tvitemPostModel$),this.httpClient.post("/api/TVItem",t,{headers:new p.d}).pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.tvitemListModel$,this.tvitemPostModel$,e,s.a.Post,t)}),Object(b.a)(t=>Object(c.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.tvitemListModel$,this.tvitemPostModel$,t)}))))}DeleteTVItem(t){return this.httpClientService.BeforeHttpClient(this.tvitemDeleteModel$),this.httpClient.delete("/api/TVItem/"+t.TVItemID).pipe(Object(l.a)(e=>{this.httpClientService.DoSuccess(this.tvitemListModel$,this.tvitemDeleteModel$,e,s.a.Delete,t)}),Object(b.a)(t=>Object(c.a)(t).pipe(Object(l.a)(t=>{this.httpClientService.DoCatchError(this.tvitemListModel$,this.tvitemDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(r.Wb(p.b),r.Wb(E.a))},t.\u0275prov=r.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var I=n("Wp6s"),T=n("bTqV"),D=n("bv9b"),f=n("NFeN"),d=n("3Pt+"),S=n("kmnG"),x=n("qFsG"),v=n("d3UM"),M=n("FKr1");function R(t,e){1&t&&r.Nb(0,"mat-progress-bar",13)}function P(t,e){1&t&&r.Nb(0,"mat-progress-bar",13)}function C(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function V(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,C,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.required)}}function g(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function y(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Min - 0"),r.Nb(2,"br"),r.Rb())}function B(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Max - 100"),r.Nb(2,"br"),r.Rb())}function L(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,g,3,0,"span",4),r.yc(6,y,3,0,"span",4),r.yc(7,B,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,4,t)),r.Bb(3),r.ic("ngIf",t.required),r.Bb(1),r.ic("ngIf",t.min),r.Bb(1),r.ic("ngIf",t.min)}}function $(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function N(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"MaxLength - 250"),r.Nb(2,"br"),r.Rb())}function w(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,$,3,0,"span",4),r.yc(6,N,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,3,t)),r.Bb(3),r.ic("ngIf",t.required),r.Bb(1),r.ic("ngIf",t.maxlength)}}function z(t,e){if(1&t&&(r.Sb(0,"mat-option",14),r.zc(1),r.Rb()),2&t){const t=e.$implicit;r.ic("value",t.EnumID),r.Bb(1),r.Bc(" ",t.EnumText," ")}}function k(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function W(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,k,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.required)}}function G(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,1,t))}}function O(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function A(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,O,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.required)}}function q(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function U(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,q,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.required)}}function j(t,e){1&t&&(r.Sb(0,"span"),r.zc(1,"Is Required"),r.Nb(2,"br"),r.Rb())}function F(t,e){if(1&t&&(r.Sb(0,"mat-error"),r.Sb(1,"span"),r.zc(2),r.ec(3,"json"),r.Nb(4,"br"),r.Rb(),r.yc(5,j,3,0,"span",4),r.Rb()),2&t){const t=e.$implicit;r.Bb(2),r.Ac(r.fc(3,2,t)),r.Bb(3),r.ic("ngIf",t.required)}}let Q=(()=>{class t{constructor(t,e){this.tvitemService=t,this.fb=e,this.tvitem=null,this.httpClientCommand=s.a.Put}GetPut(){return this.httpClientCommand==s.a.Put}PutTVItem(t){this.sub=this.tvitemService.PutTVItem(t).subscribe()}PostTVItem(t){this.sub=this.tvitemService.PostTVItem(t).subscribe()}ngOnInit(){this.tVTypeList=Object(o.b)(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.tvitem){let e=this.fb.group({TVItemID:[{value:t===s.a.Post?0:this.tvitem.TVItemID,disabled:!1},[d.p.required]],TVLevel:[{value:this.tvitem.TVLevel,disabled:!1},[d.p.required,d.p.min(0),d.p.max(100)]],TVPath:[{value:this.tvitem.TVPath,disabled:!1},[d.p.required,d.p.maxLength(250)]],TVType:[{value:this.tvitem.TVType,disabled:!1},[d.p.required]],ParentID:[{value:this.tvitem.ParentID,disabled:!1}],IsActive:[{value:this.tvitem.IsActive,disabled:!1},[d.p.required]],LastUpdateDate_UTC:[{value:this.tvitem.LastUpdateDate_UTC,disabled:!1},[d.p.required]],LastUpdateContactTVItemID:[{value:this.tvitem.LastUpdateContactTVItemID,disabled:!1},[d.p.required]]});this.tvitemFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(r.Mb(h),r.Mb(d.d))},t.\u0275cmp=r.Gb({type:t,selectors:[["app-tvitem-edit"]],inputs:{tvitem:"tvitem",httpClientCommand:"httpClientCommand"},decls:51,vars:13,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TVItemID"],[4,"ngIf"],["matInput","","type","number","formControlName","TVLevel"],["matInput","","type","text","formControlName","TVPath"],["formControlName","TVType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","number","formControlName","ParentID"],["matInput","","type","text","formControlName","IsActive"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(r.Sb(0,"form",0),r.Zb("ngSubmit",(function(){return e.GetPut()?e.PutTVItem(e.tvitemFormEdit.value):e.PostTVItem(e.tvitemFormEdit.value)})),r.Sb(1,"h3"),r.zc(2," TVItem "),r.Sb(3,"button",1),r.Sb(4,"span"),r.zc(5),r.Rb(),r.Rb(),r.yc(6,R,1,0,"mat-progress-bar",2),r.yc(7,P,1,0,"mat-progress-bar",2),r.Rb(),r.Sb(8,"p"),r.Sb(9,"mat-form-field"),r.Sb(10,"mat-label"),r.zc(11,"TVItemID"),r.Rb(),r.Nb(12,"input",3),r.yc(13,V,6,4,"mat-error",4),r.Rb(),r.Sb(14,"mat-form-field"),r.Sb(15,"mat-label"),r.zc(16,"TVLevel"),r.Rb(),r.Nb(17,"input",5),r.yc(18,L,8,6,"mat-error",4),r.Rb(),r.Sb(19,"mat-form-field"),r.Sb(20,"mat-label"),r.zc(21,"TVPath"),r.Rb(),r.Nb(22,"input",6),r.yc(23,w,7,5,"mat-error",4),r.Rb(),r.Sb(24,"mat-form-field"),r.Sb(25,"mat-label"),r.zc(26,"TVType"),r.Rb(),r.Sb(27,"mat-select",7),r.yc(28,z,2,2,"mat-option",8),r.Rb(),r.yc(29,W,6,4,"mat-error",4),r.Rb(),r.Rb(),r.Sb(30,"p"),r.Sb(31,"mat-form-field"),r.Sb(32,"mat-label"),r.zc(33,"ParentID"),r.Rb(),r.Nb(34,"input",9),r.yc(35,G,5,3,"mat-error",4),r.Rb(),r.Sb(36,"mat-form-field"),r.Sb(37,"mat-label"),r.zc(38,"IsActive"),r.Rb(),r.Nb(39,"input",10),r.yc(40,A,6,4,"mat-error",4),r.Rb(),r.Sb(41,"mat-form-field"),r.Sb(42,"mat-label"),r.zc(43,"LastUpdateDate_UTC"),r.Rb(),r.Nb(44,"input",11),r.yc(45,U,6,4,"mat-error",4),r.Rb(),r.Sb(46,"mat-form-field"),r.Sb(47,"mat-label"),r.zc(48,"LastUpdateContactTVItemID"),r.Rb(),r.Nb(49,"input",12),r.yc(50,F,6,4,"mat-error",4),r.Rb(),r.Rb(),r.Rb()),2&t&&(r.ic("formGroup",e.tvitemFormEdit),r.Bb(5),r.Bc("",e.GetPut()?"Put":"Post"," TVItem"),r.Bb(1),r.ic("ngIf",e.tvitemService.tvitemPutModel$.getValue().Working),r.Bb(1),r.ic("ngIf",e.tvitemService.tvitemPostModel$.getValue().Working),r.Bb(6),r.ic("ngIf",e.tvitemFormEdit.controls.TVItemID.errors),r.Bb(5),r.ic("ngIf",e.tvitemFormEdit.controls.TVLevel.errors),r.Bb(5),r.ic("ngIf",e.tvitemFormEdit.controls.TVPath.errors),r.Bb(5),r.ic("ngForOf",e.tVTypeList),r.Bb(1),r.ic("ngIf",e.tvitemFormEdit.controls.TVType.errors),r.Bb(6),r.ic("ngIf",e.tvitemFormEdit.controls.ParentID.errors),r.Bb(5),r.ic("ngIf",e.tvitemFormEdit.controls.IsActive.errors),r.Bb(5),r.ic("ngIf",e.tvitemFormEdit.controls.LastUpdateDate_UTC.errors),r.Bb(5),r.ic("ngIf",e.tvitemFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[d.q,d.l,d.f,T.b,u.l,S.c,S.f,x.b,d.n,d.c,d.k,d.e,v.a,u.k,D.a,S.b,M.n],pipes:[u.f],styles:[""],changeDetection:0}),t})();function H(t,e){1&t&&r.Nb(0,"mat-progress-bar",4)}function K(t,e){1&t&&r.Nb(0,"mat-progress-bar",4)}function J(t,e){if(1&t&&(r.Sb(0,"p"),r.Nb(1,"app-tvitem-edit",8),r.Rb()),2&t){const t=r.dc().$implicit,e=r.dc(2);r.Bb(1),r.ic("tvitem",t)("httpClientCommand",e.GetPutEnum())}}function _(t,e){if(1&t&&(r.Sb(0,"p"),r.Nb(1,"app-tvitem-edit",8),r.Rb()),2&t){const t=r.dc().$implicit,e=r.dc(2);r.Bb(1),r.ic("tvitem",t)("httpClientCommand",e.GetPostEnum())}}function Z(t,e){if(1&t){const t=r.Tb();r.Sb(0,"div"),r.Sb(1,"p"),r.Sb(2,"button",6),r.Zb("click",(function(){r.qc(t);const n=e.$implicit;return r.dc(2).DeleteTVItem(n)})),r.Sb(3,"span"),r.zc(4),r.Rb(),r.Sb(5,"mat-icon"),r.zc(6,"delete"),r.Rb(),r.Rb(),r.zc(7,"\xa0\xa0\xa0 "),r.Sb(8,"button",7),r.Zb("click",(function(){r.qc(t);const n=e.$implicit;return r.dc(2).ShowPut(n)})),r.Sb(9,"span"),r.zc(10,"Show Put"),r.Rb(),r.Rb(),r.zc(11,"\xa0\xa0 "),r.Sb(12,"button",7),r.Zb("click",(function(){r.qc(t);const n=e.$implicit;return r.dc(2).ShowPost(n)})),r.Sb(13,"span"),r.zc(14,"Show Post"),r.Rb(),r.Rb(),r.zc(15,"\xa0\xa0 "),r.yc(16,K,1,0,"mat-progress-bar",0),r.Rb(),r.yc(17,J,2,2,"p",2),r.yc(18,_,2,2,"p",2),r.Sb(19,"blockquote"),r.Sb(20,"p"),r.Sb(21,"span"),r.zc(22),r.Rb(),r.Sb(23,"span"),r.zc(24),r.Rb(),r.Sb(25,"span"),r.zc(26),r.Rb(),r.Sb(27,"span"),r.zc(28),r.Rb(),r.Rb(),r.Sb(29,"p"),r.Sb(30,"span"),r.zc(31),r.Rb(),r.Sb(32,"span"),r.zc(33),r.Rb(),r.Sb(34,"span"),r.zc(35),r.Rb(),r.Sb(36,"span"),r.zc(37),r.Rb(),r.Rb(),r.Rb(),r.Rb()}if(2&t){const t=e.$implicit,n=r.dc(2);r.Bb(4),r.Bc("Delete TVItemID [",t.TVItemID,"]\xa0\xa0\xa0"),r.Bb(4),r.ic("color",n.GetPutButtonColor(t)),r.Bb(4),r.ic("color",n.GetPostButtonColor(t)),r.Bb(4),r.ic("ngIf",n.tvitemService.tvitemDeleteModel$.getValue().Working),r.Bb(1),r.ic("ngIf",n.IDToShow===t.TVItemID&&n.showType===n.GetPutEnum()),r.Bb(1),r.ic("ngIf",n.IDToShow===t.TVItemID&&n.showType===n.GetPostEnum()),r.Bb(4),r.Bc("TVItemID: [",t.TVItemID,"]"),r.Bb(2),r.Bc(" --- TVLevel: [",t.TVLevel,"]"),r.Bb(2),r.Bc(" --- TVPath: [",t.TVPath,"]"),r.Bb(2),r.Bc(" --- TVType: [",n.GetTVTypeEnumText(t.TVType),"]"),r.Bb(3),r.Bc("ParentID: [",t.ParentID,"]"),r.Bb(2),r.Bc(" --- IsActive: [",t.IsActive,"]"),r.Bb(2),r.Bc(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),r.Bb(2),r.Bc(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function X(t,e){if(1&t&&(r.Sb(0,"div"),r.yc(1,Z,38,14,"div",5),r.Rb()),2&t){const t=r.dc();r.Bb(1),r.ic("ngForOf",t.tvitemService.tvitemListModel$.getValue())}}const Y=[{path:"",component:(()=>{class t{constructor(t,e,n){this.tvitemService=t,this.router=e,this.httpClientService=n,this.showType=null,n.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.TVItemID&&this.showType===s.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.TVItemID&&this.showType===s.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.TVItemID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TVItemID,this.showType=s.a.Put)}ShowPost(t){this.IDToShow===t.TVItemID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TVItemID,this.showType=s.a.Post)}GetPutEnum(){return s.a.Put}GetPostEnum(){return s.a.Post}GetTVItemList(){this.sub=this.tvitemService.GetTVItemList().subscribe()}DeleteTVItem(t){this.sub=this.tvitemService.DeleteTVItem(t).subscribe()}GetTVTypeEnumText(t){return Object(o.a)(t)}ngOnInit(){m(this.tvitemService.tvitemTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(r.Mb(h),r.Mb(i.b),r.Mb(E.a))},t.\u0275cmp=r.Gb({type:t,selectors:[["app-tvitem"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tvitem","httpClientCommand"]],template:function(t,e){var n,u;1&t&&(r.yc(0,H,1,0,"mat-progress-bar",0),r.Sb(1,"mat-card"),r.Sb(2,"mat-card-header"),r.Sb(3,"mat-card-title"),r.zc(4," TVItem works! "),r.Sb(5,"button",1),r.Zb("click",(function(){return e.GetTVItemList()})),r.Sb(6,"span"),r.zc(7,"Get TVItem"),r.Rb(),r.Rb(),r.Rb(),r.Sb(8,"mat-card-subtitle"),r.zc(9),r.Rb(),r.Rb(),r.Sb(10,"mat-card-content"),r.yc(11,X,2,1,"div",2),r.Rb(),r.Sb(12,"mat-card-actions"),r.Sb(13,"button",3),r.zc(14,"Allo"),r.Rb(),r.Rb(),r.Rb()),2&t&&(r.ic("ngIf",null==(n=e.tvitemService.tvitemGetModel$.getValue())?null:n.Working),r.Bb(9),r.Ac(e.tvitemService.tvitemTextModel$.getValue().Title),r.Bb(2),r.ic("ngIf",null==(u=e.tvitemService.tvitemListModel$.getValue())?null:u.length))},directives:[u.l,I.a,I.d,I.g,T.b,I.f,I.c,I.b,D.a,u.k,f.a,Q],styles:[""],changeDetection:0}),t})(),canActivate:[n("auXs").a]}];let tt=(()=>{class t{}return t.\u0275mod=r.Kb({type:t}),t.\u0275inj=r.Jb({factory:function(e){return new(e||t)},imports:[[i.e.forChild(Y)],i.e]}),t})();var et=n("B+Mi");let nt=(()=>{class t{}return t.\u0275mod=r.Kb({type:t}),t.\u0275inj=r.Jb({factory:function(e){return new(e||t)},imports:[[u.c,i.e,tt,et.a,d.g,d.o]]}),t})()},BJD1:function(t,e,n){"use strict";function u(){let t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"Base"}),t.push({EnumID:2,EnumText:"Adresse"}),t.push({EnumID:3,EnumText:"R\xe9gion"}),t.push({EnumID:4,EnumText:"Climate Site (fr)"}),t.push({EnumID:5,EnumText:"Contact (fr)"}),t.push({EnumID:6,EnumText:"Pays"}),t.push({EnumID:7,EnumText:"Courriel"}),t.push({EnumID:8,EnumText:"Fichier"}),t.push({EnumID:9,EnumText:"Poste hydrom\xe9trique"}),t.push({EnumID:10,EnumText:"Infrastructure"}),t.push({EnumID:11,EnumText:"Mike Boundary Condition Web Tide (fr)"}),t.push({EnumID:12,EnumText:"Mike Boundary Condition Mesh (fr)"}),t.push({EnumID:13,EnumText:"Sc\xe9nario MIKE"}),t.push({EnumID:14,EnumText:"Source MIKE"}),t.push({EnumID:15,EnumText:"Municipalit\xe9"}),t.push({EnumID:16,EnumText:"MWQM Site (fr)"}),t.push({EnumID:17,EnumText:"Site de la source de pollution"}),t.push({EnumID:18,EnumText:"Province "}),t.push({EnumID:19,EnumText:"Secteur"}),t.push({EnumID:20,EnumText:"Sous-secteur"}),t.push({EnumID:21,EnumText:"T\xe9l"}),t.push({EnumID:22,EnumText:"Poste de mar\xe9e"}),t.push({EnumID:23,EnumText:"MWQM Site Sample (fr)"}),t.push({EnumID:24,EnumText:"Usine de traitement de eaux us\xe9es"}),t.push({EnumID:25,EnumText:"Poste de pompage"}),t.push({EnumID:26,EnumText:"D\xe9versement"}),t.push({EnumID:27,EnumText:"Box Model"}),t.push({EnumID:28,EnumText:"Sc\xe9nario Visual Plumes"}),t.push({EnumID:29,EnumText:"\xc9missaire"}),t.push({EnumID:30,EnumText:"Other Infrastructure (fr)"}),t.push({EnumID:31,EnumText:"MWQM Run (fr)"}),t.push({EnumID:33,EnumText:"No Depuration (fr)"}),t.push({EnumID:34,EnumText:"\xc9chec"}),t.push({EnumID:35,EnumText:"R\xe9ussi"}),t.push({EnumID:36,EnumText:"Aucune donn\xe9e"}),t.push({EnumID:37,EnumText:"Less Than 10 Samples (fr)"}),t.push({EnumID:38,EnumText:"Mesh Node (fr)"}),t.push({EnumID:39,EnumText:"Web Tide Node (fr)"}),t.push({EnumID:40,EnumText:"MWQM Plan (fr)"}),t.push({EnumID:41,EnumText:"Voir autre municipalit\xe9"}),t.push({EnumID:42,EnumText:"Line overflow (fr)"}),t.push({EnumID:43,EnumText:"Box Model Inputs (fr)"}),t.push({EnumID:44,EnumText:"Box Model Results (fr)"}),t.push({EnumID:45,EnumText:"Climate Site Info (fr)"}),t.push({EnumID:46,EnumText:"Climate Site Data (fr)"}),t.push({EnumID:47,EnumText:"Hydrometric Site Info (fr)"}),t.push({EnumID:48,EnumText:"Hydrometric Site Data (fr)"}),t.push({EnumID:49,EnumText:"Infrastructure Info (fr)"}),t.push({EnumID:50,EnumText:"Lab Sheet Info (fr)"}),t.push({EnumID:51,EnumText:"Lab Sheet Detail Info (fr)"}),t.push({EnumID:52,EnumText:"Map Info (fr)"}),t.push({EnumID:53,EnumText:"Map Info Point (fr)"}),t.push({EnumID:54,EnumText:"Mike Source Start End Info (fr)"}),t.push({EnumID:55,EnumText:"MWQM Lookup MPN Info (fr)"}),t.push({EnumID:56,EnumText:"MWQM Plan Info (fr)"}),t.push({EnumID:57,EnumText:"MWQM Plan Subsector Info (fr)"}),t.push({EnumID:58,EnumText:"MWQM Plan Subsector Site Info (fr)"}),t.push({EnumID:59,EnumText:"MWQM Site Start End Info (fr)"}),t.push({EnumID:60,EnumText:"MWQM Subsector Info (fr)"}),t.push({EnumID:61,EnumText:"Pollution Source Site Info (fr)"}),t.push({EnumID:62,EnumText:"Pollution Source Site Observation Info (fr)"}),t.push({EnumID:63,EnumText:"Hydrometric Rating Curve Info (fr)"}),t.push({EnumID:64,EnumText:"Hydrometric Rating Curve Data Info (fr)"}),t.push({EnumID:65,EnumText:"Tide Location Info (fr)"}),t.push({EnumID:66,EnumText:"Tide Site Data Info (fr)"}),t.push({EnumID:67,EnumText:"Use Of Site (fr)"}),t.push({EnumID:68,EnumText:"Visual Plumes Scenario Info (fr)"}),t.push({EnumID:69,EnumText:"Visual Plumes Scenario Ambient (fr)"}),t.push({EnumID:70,EnumText:"Visual Plumes Scenario Results (fr)"}),t.push({EnumID:71,EnumText:"Totale fili\xe8re"}),t.push({EnumID:72,EnumText:"Source de pollution MIKE rivi\xe8re"}),t.push({EnumID:73,EnumText:"Source de pollution MIKE inclus"}),t.push({EnumID:74,EnumText:"Source de pollution MIKE non inclus"}),t.push({EnumID:75,EnumText:"Exceedance de pluie"}),t.push({EnumID:76,EnumText:"Liste de distribution des courriels"}),t.push({EnumID:77,EnumText:"Open Data (fr)"}),t.push({EnumID:78,EnumText:"Province Tools"}),t.push({EnumID:79,EnumText:"Classification"}),t.push({EnumID:80,EnumText:"Agr\xe9\xe9"}),t.push({EnumID:81,EnumText:"Restreint"}),t.push({EnumID:82,EnumText:"Interdit"}),t.push({EnumID:83,EnumText:"Agr\xe9\xe9 sous condition"}),t.push({EnumID:84,EnumText:"Restreint sous condition"}),t.push({EnumID:85,EnumText:"Open Data national (fr)"}),t.push({EnumID:86,EnumText:"Pollution source site Mike Scenario (fr)"}),t.push({EnumID:87,EnumText:"Subsector tools (fr)"})):(t.push({EnumID:1,EnumText:"Root"}),t.push({EnumID:2,EnumText:"Address"}),t.push({EnumID:3,EnumText:"Area"}),t.push({EnumID:4,EnumText:"Climate Site"}),t.push({EnumID:5,EnumText:"Contact"}),t.push({EnumID:6,EnumText:"Country"}),t.push({EnumID:7,EnumText:"Email"}),t.push({EnumID:8,EnumText:"File"}),t.push({EnumID:9,EnumText:"Hydrometric Site"}),t.push({EnumID:10,EnumText:"Infrastructure"}),t.push({EnumID:11,EnumText:"Mike Boundary Condition Web Tide"}),t.push({EnumID:12,EnumText:"Mike Boundary Condition Mesh"}),t.push({EnumID:13,EnumText:"Mike Scenario"}),t.push({EnumID:14,EnumText:"Mike Source"}),t.push({EnumID:15,EnumText:"Municipality"}),t.push({EnumID:16,EnumText:"MWQM Site"}),t.push({EnumID:17,EnumText:"Pollution Source Site"}),t.push({EnumID:18,EnumText:"Province"}),t.push({EnumID:19,EnumText:"Sector"}),t.push({EnumID:20,EnumText:"Subsector"}),t.push({EnumID:21,EnumText:"Tel"}),t.push({EnumID:22,EnumText:"Tide Site"}),t.push({EnumID:23,EnumText:"MWQM Site Sample"}),t.push({EnumID:24,EnumText:"Waste Water Treatment Plant"}),t.push({EnumID:25,EnumText:"Lift Station"}),t.push({EnumID:26,EnumText:"Spill"}),t.push({EnumID:27,EnumText:"Box Model"}),t.push({EnumID:28,EnumText:"Visual Plumes Scenario"}),t.push({EnumID:29,EnumText:"Outfall"}),t.push({EnumID:30,EnumText:"Other Infrastructure"}),t.push({EnumID:31,EnumText:"MWQM Run"}),t.push({EnumID:33,EnumText:"No Depuration"}),t.push({EnumID:34,EnumText:"Failed"}),t.push({EnumID:35,EnumText:"Passed"}),t.push({EnumID:36,EnumText:"No Data"}),t.push({EnumID:37,EnumText:"Less Than 10 Samples"}),t.push({EnumID:38,EnumText:"Mesh Node"}),t.push({EnumID:39,EnumText:"Web Tide Node"}),t.push({EnumID:40,EnumText:"MWQM Plan"}),t.push({EnumID:41,EnumText:"See other municipality"}),t.push({EnumID:42,EnumText:"Line overflow"}),t.push({EnumID:43,EnumText:"Box Model Inputs"}),t.push({EnumID:44,EnumText:"Box Model Results"}),t.push({EnumID:45,EnumText:"Climate Site Info"}),t.push({EnumID:46,EnumText:"Climate Site Data"}),t.push({EnumID:47,EnumText:"Hydrometric Site Info"}),t.push({EnumID:48,EnumText:"Hydrometric Site Data"}),t.push({EnumID:49,EnumText:"Infrastructure Info"}),t.push({EnumID:50,EnumText:"Lab Sheet Info"}),t.push({EnumID:51,EnumText:"Lab Sheet Detail Info"}),t.push({EnumID:52,EnumText:"Map Info"}),t.push({EnumID:53,EnumText:"Map Info Point"}),t.push({EnumID:54,EnumText:"Mike Source Start End Info"}),t.push({EnumID:55,EnumText:"MWQM Lookup MPN Info"}),t.push({EnumID:56,EnumText:"MWQM Plan Info"}),t.push({EnumID:57,EnumText:"MWQM Plan Subsector Info"}),t.push({EnumID:58,EnumText:"MWQM Plan Subsector Site Info"}),t.push({EnumID:59,EnumText:"MWQM Site Start End Info"}),t.push({EnumID:60,EnumText:"MWQM Subsector Info"}),t.push({EnumID:61,EnumText:"Pollution Source Site Info"}),t.push({EnumID:62,EnumText:"Pollution Source Site Observation Info"}),t.push({EnumID:63,EnumText:"Hydrometric Rating Curve Info"}),t.push({EnumID:64,EnumText:"Hydrometric Rating Curve Data Info"}),t.push({EnumID:65,EnumText:"Tide Location Info"}),t.push({EnumID:66,EnumText:"Tide Site Data Info"}),t.push({EnumID:67,EnumText:"Use Of Site"}),t.push({EnumID:68,EnumText:"Visual Plumes Scenario Info"}),t.push({EnumID:69,EnumText:"Visual Plumes Scenario Ambient"}),t.push({EnumID:70,EnumText:"Visual Plumes Scenario Results"}),t.push({EnumID:71,EnumText:"Total file"}),t.push({EnumID:72,EnumText:"Mike source is river"}),t.push({EnumID:73,EnumText:"Mike source included"}),t.push({EnumID:74,EnumText:"Mike source not included"}),t.push({EnumID:75,EnumText:"Rain exceedance"}),t.push({EnumID:76,EnumText:"Email distribution list"}),t.push({EnumID:77,EnumText:"Open Data"}),t.push({EnumID:78,EnumText:"Province Tools"}),t.push({EnumID:79,EnumText:"Classification"}),t.push({EnumID:80,EnumText:"Approved"}),t.push({EnumID:81,EnumText:"Restricted"}),t.push({EnumID:82,EnumText:"Prohibited"}),t.push({EnumID:83,EnumText:"Conditionally Approved"}),t.push({EnumID:84,EnumText:"Conditionally Restricted"}),t.push({EnumID:85,EnumText:"Open Data national"}),t.push({EnumID:86,EnumText:"Pollution source site Mike Scenario"}),t.push({EnumID:87,EnumText:"Subsector tools"})),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}function i(t){let e;return u().forEach(n=>{if(n.EnumID==t)return e=n.EnumText,!1}),e}n.d(e,"b",(function(){return u})),n.d(e,"a",(function(){return i}))},QRvi:function(t,e,n){"use strict";n.d(e,"a",(function(){return u}));var u=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,n){"use strict";n.d(e,"a",(function(){return o}));var u=n("QRvi"),i=n("fXoL"),m=n("tyNb");let o=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,n,i,m){if(i===u.a.Get&&t.next(n),i===u.a.Put&&(t.getValue()[0]=n),i===u.a.Post&&t.getValue().push(n),i===u.a.Delete){const e=t.getValue().indexOf(m);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,n,i,m){i===u.a.Get&&t.next(n),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(i.Wb(m.b))},t.\u0275prov=i.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);