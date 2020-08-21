!function(){function t(t,i){if(!(t instanceof i))throw new TypeError("Cannot call a class as a function")}function i(t,i){for(var e=0;e<i.length;e++){var n=i[e];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}function e(t,e,n){return e&&i(t.prototype,e),n&&i(t,n),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[40],{QRvi:function(t,i,e){"use strict";e.d(i,"a",(function(){return n}));var n=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(i,n,a){"use strict";a.d(n,"a",(function(){return r}));var c=a("QRvi"),o=a("fXoL"),s=a("tyNb"),r=function(){var i=function(){function i(e){t(this,i),this.router=e,this.oldURL=e.url}return e(i,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,i,e){t.next(null),i.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,i,e){t.next(null),i.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,i,e,n,a){if(n===c.a.Get&&t.next(e),n===c.a.Put&&(t.getValue()[0]=e),n===c.a.Post&&t.getValue().push(e),n===c.a.Delete){var o=t.getValue().indexOf(a);t.getValue().splice(o,1)}t.next(t.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,i,e,n,a){n===c.a.Get&&t.next(e),t.next(t.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),i}();return i.\u0275fac=function(t){return new(t||i)(o.Wb(s.b))},i.\u0275prov=o.Ib({token:i,factory:i.\u0275fac,providedIn:"root"}),i}()},vpjk:function(i,n,a){"use strict";a.r(n),a.d(n,"ClassificationModule",(function(){return ct}));var c=a("ofXK"),o=a("tyNb");function s(t){var i={Title:"The title"};"fr-CA"===$localize.locale&&(i.Title="Le Titre"),t.next(i)}function r(){var t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"Agr\xe9\xe9"}),t.push({EnumID:2,EnumText:"Restreint"}),t.push({EnumID:3,EnumText:"Interdit"}),t.push({EnumID:4,EnumText:"Agr\xe9\xe9 sous condition"}),t.push({EnumID:5,EnumText:"Restreint sous condition"})):(t.push({EnumID:1,EnumText:"Approved"}),t.push({EnumID:2,EnumText:"Restricted"}),t.push({EnumID:3,EnumText:"Prohibited"}),t.push({EnumID:4,EnumText:"Conditionally Approved"}),t.push({EnumID:5,EnumText:"Conditionally Restricted"})),t.sort((function(t,i){return t.EnumText.localeCompare(i.EnumText)}))}var l,u=a("QRvi"),f=a("fXoL"),b=a("2Vo4"),p=a("LRne"),m=a("tk/3"),d=a("lJxs"),h=a("JIr8"),C=a("gkM4"),S=((l=function(){function i(e,n){t(this,i),this.httpClient=e,this.httpClientService=n,this.classificationTextModel$=new b.a({}),this.classificationListModel$=new b.a({}),this.classificationGetModel$=new b.a({}),this.classificationPutModel$=new b.a({}),this.classificationPostModel$=new b.a({}),this.classificationDeleteModel$=new b.a({}),s(this.classificationTextModel$),this.classificationTextModel$.next({Title:"Something2 for text"})}return e(i,[{key:"GetClassificationList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.classificationGetModel$),this.httpClient.get("/api/Classification").pipe(Object(d.a)((function(i){t.httpClientService.DoSuccess(t.classificationListModel$,t.classificationGetModel$,i,u.a.Get,null)})),Object(h.a)((function(i){return Object(p.a)(i).pipe(Object(d.a)((function(i){t.httpClientService.DoCatchError(t.classificationListModel$,t.classificationGetModel$,i)})))})))}},{key:"PutClassification",value:function(t){var i=this;return this.httpClientService.BeforeHttpClient(this.classificationPutModel$),this.httpClient.put("/api/Classification",t,{headers:new m.d}).pipe(Object(d.a)((function(e){i.httpClientService.DoSuccess(i.classificationListModel$,i.classificationPutModel$,e,u.a.Put,t)})),Object(h.a)((function(t){return Object(p.a)(t).pipe(Object(d.a)((function(t){i.httpClientService.DoCatchError(i.classificationListModel$,i.classificationPutModel$,t)})))})))}},{key:"PostClassification",value:function(t){var i=this;return this.httpClientService.BeforeHttpClient(this.classificationPostModel$),this.httpClient.post("/api/Classification",t,{headers:new m.d}).pipe(Object(d.a)((function(e){i.httpClientService.DoSuccess(i.classificationListModel$,i.classificationPostModel$,e,u.a.Post,t)})),Object(h.a)((function(t){return Object(p.a)(t).pipe(Object(d.a)((function(t){i.httpClientService.DoCatchError(i.classificationListModel$,i.classificationPostModel$,t)})))})))}},{key:"DeleteClassification",value:function(t){var i=this;return this.httpClientService.BeforeHttpClient(this.classificationDeleteModel$),this.httpClient.delete("/api/Classification/"+t.ClassificationID).pipe(Object(d.a)((function(e){i.httpClientService.DoSuccess(i.classificationListModel$,i.classificationDeleteModel$,e,u.a.Delete,t)})),Object(h.a)((function(t){return Object(p.a)(t).pipe(Object(d.a)((function(t){i.httpClientService.DoCatchError(i.classificationListModel$,i.classificationDeleteModel$,t)})))})))}}]),i}()).\u0275fac=function(t){return new(t||l)(f.Wb(m.b),f.Wb(C.a))},l.\u0275prov=f.Ib({token:l,factory:l.\u0275fac,providedIn:"root"}),l),v=a("Wp6s"),I=a("bTqV"),y=a("bv9b"),D=a("NFeN"),R=a("3Pt+"),g=a("kmnG"),T=a("qFsG"),B=a("d3UM"),k=a("FKr1");function P(t,i){1&t&&f.Nb(0,"mat-progress-bar",11)}function E(t,i){1&t&&f.Nb(0,"mat-progress-bar",11)}function w(t,i){1&t&&(f.Sb(0,"span"),f.zc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function $(t,i){if(1&t&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.zc(2),f.ec(3,"json"),f.Nb(4,"br"),f.Rb(),f.yc(5,w,3,0,"span",4),f.Rb()),2&t){var e=i.$implicit;f.Bb(2),f.Ac(f.fc(3,2,e)),f.Bb(3),f.ic("ngIf",e.required)}}function M(t,i){1&t&&(f.Sb(0,"span"),f.zc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function z(t,i){if(1&t&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.zc(2),f.ec(3,"json"),f.Nb(4,"br"),f.Rb(),f.yc(5,M,3,0,"span",4),f.Rb()),2&t){var e=i.$implicit;f.Bb(2),f.Ac(f.fc(3,2,e)),f.Bb(3),f.ic("ngIf",e.required)}}function x(t,i){if(1&t&&(f.Sb(0,"mat-option",12),f.zc(1),f.Rb()),2&t){var e=i.$implicit;f.ic("value",e.EnumID),f.Bb(1),f.Bc(" ",e.EnumText," ")}}function L(t,i){1&t&&(f.Sb(0,"span"),f.zc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function G(t,i){if(1&t&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.zc(2),f.ec(3,"json"),f.Nb(4,"br"),f.Rb(),f.yc(5,L,3,0,"span",4),f.Rb()),2&t){var e=i.$implicit;f.Bb(2),f.Ac(f.fc(3,2,e)),f.Bb(3),f.ic("ngIf",e.required)}}function N(t,i){1&t&&(f.Sb(0,"span"),f.zc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function O(t,i){1&t&&(f.Sb(0,"span"),f.zc(1,"Min - 0"),f.Nb(2,"br"),f.Rb())}function V(t,i){1&t&&(f.Sb(0,"span"),f.zc(1,"Max - 10000"),f.Nb(2,"br"),f.Rb())}function j(t,i){if(1&t&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.zc(2),f.ec(3,"json"),f.Nb(4,"br"),f.Rb(),f.yc(5,N,3,0,"span",4),f.yc(6,O,3,0,"span",4),f.yc(7,V,3,0,"span",4),f.Rb()),2&t){var e=i.$implicit;f.Bb(2),f.Ac(f.fc(3,4,e)),f.Bb(3),f.ic("ngIf",e.required),f.Bb(1),f.ic("ngIf",e.min),f.Bb(1),f.ic("ngIf",e.min)}}function U(t,i){1&t&&(f.Sb(0,"span"),f.zc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function q(t,i){if(1&t&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.zc(2),f.ec(3,"json"),f.Nb(4,"br"),f.Rb(),f.yc(5,U,3,0,"span",4),f.Rb()),2&t){var e=i.$implicit;f.Bb(2),f.Ac(f.fc(3,2,e)),f.Bb(3),f.ic("ngIf",e.required)}}function F(t,i){1&t&&(f.Sb(0,"span"),f.zc(1,"Is Required"),f.Nb(2,"br"),f.Rb())}function A(t,i){if(1&t&&(f.Sb(0,"mat-error"),f.Sb(1,"span"),f.zc(2),f.ec(3,"json"),f.Nb(4,"br"),f.Rb(),f.yc(5,F,3,0,"span",4),f.Rb()),2&t){var e=i.$implicit;f.Bb(2),f.Ac(f.fc(3,2,e)),f.Bb(3),f.ic("ngIf",e.required)}}var W,_=((W=function(){function i(e,n){t(this,i),this.classificationService=e,this.fb=n,this.classification=null,this.httpClientCommand=u.a.Put}return e(i,[{key:"GetPut",value:function(){return this.httpClientCommand==u.a.Put}},{key:"PutClassification",value:function(t){this.sub=this.classificationService.PutClassification(t).subscribe()}},{key:"PostClassification",value:function(t){this.sub=this.classificationService.PostClassification(t).subscribe()}},{key:"ngOnInit",value:function(){this.classificationTypeList=r(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.classification){var i=this.fb.group({ClassificationID:[{value:t===u.a.Post?0:this.classification.ClassificationID,disabled:!1},[R.p.required]],ClassificationTVItemID:[{value:this.classification.ClassificationTVItemID,disabled:!1},[R.p.required]],ClassificationType:[{value:this.classification.ClassificationType,disabled:!1},[R.p.required]],Ordinal:[{value:this.classification.Ordinal,disabled:!1},[R.p.required,R.p.min(0),R.p.max(1e4)]],LastUpdateDate_UTC:[{value:this.classification.LastUpdateDate_UTC,disabled:!1},[R.p.required]],LastUpdateContactTVItemID:[{value:this.classification.LastUpdateContactTVItemID,disabled:!1},[R.p.required]]});this.classificationFormEdit=i}}}]),i}()).\u0275fac=function(t){return new(t||W)(f.Mb(S),f.Mb(R.d))},W.\u0275cmp=f.Gb({type:W,selectors:[["app-classification-edit"]],inputs:{classification:"classification",httpClientCommand:"httpClientCommand"},decls:41,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","ClassificationID"],[4,"ngIf"],["matInput","","type","number","formControlName","ClassificationTVItemID"],["formControlName","ClassificationType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","number","formControlName","Ordinal"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,i){1&t&&(f.Sb(0,"form",0),f.Zb("ngSubmit",(function(){return i.GetPut()?i.PutClassification(i.classificationFormEdit.value):i.PostClassification(i.classificationFormEdit.value)})),f.Sb(1,"h3"),f.zc(2," Classification "),f.Sb(3,"button",1),f.Sb(4,"span"),f.zc(5),f.Rb(),f.Rb(),f.yc(6,P,1,0,"mat-progress-bar",2),f.yc(7,E,1,0,"mat-progress-bar",2),f.Rb(),f.Sb(8,"p"),f.Sb(9,"mat-form-field"),f.Sb(10,"mat-label"),f.zc(11,"ClassificationID"),f.Rb(),f.Nb(12,"input",3),f.yc(13,$,6,4,"mat-error",4),f.Rb(),f.Sb(14,"mat-form-field"),f.Sb(15,"mat-label"),f.zc(16,"ClassificationTVItemID"),f.Rb(),f.Nb(17,"input",5),f.yc(18,z,6,4,"mat-error",4),f.Rb(),f.Sb(19,"mat-form-field"),f.Sb(20,"mat-label"),f.zc(21,"ClassificationType"),f.Rb(),f.Sb(22,"mat-select",6),f.yc(23,x,2,2,"mat-option",7),f.Rb(),f.yc(24,G,6,4,"mat-error",4),f.Rb(),f.Sb(25,"mat-form-field"),f.Sb(26,"mat-label"),f.zc(27,"Ordinal"),f.Rb(),f.Nb(28,"input",8),f.yc(29,j,8,6,"mat-error",4),f.Rb(),f.Rb(),f.Sb(30,"p"),f.Sb(31,"mat-form-field"),f.Sb(32,"mat-label"),f.zc(33,"LastUpdateDate_UTC"),f.Rb(),f.Nb(34,"input",9),f.yc(35,q,6,4,"mat-error",4),f.Rb(),f.Sb(36,"mat-form-field"),f.Sb(37,"mat-label"),f.zc(38,"LastUpdateContactTVItemID"),f.Rb(),f.Nb(39,"input",10),f.yc(40,A,6,4,"mat-error",4),f.Rb(),f.Rb(),f.Rb()),2&t&&(f.ic("formGroup",i.classificationFormEdit),f.Bb(5),f.Bc("",i.GetPut()?"Put":"Post"," Classification"),f.Bb(1),f.ic("ngIf",i.classificationService.classificationPutModel$.getValue().Working),f.Bb(1),f.ic("ngIf",i.classificationService.classificationPostModel$.getValue().Working),f.Bb(6),f.ic("ngIf",i.classificationFormEdit.controls.ClassificationID.errors),f.Bb(5),f.ic("ngIf",i.classificationFormEdit.controls.ClassificationTVItemID.errors),f.Bb(5),f.ic("ngForOf",i.classificationTypeList),f.Bb(1),f.ic("ngIf",i.classificationFormEdit.controls.ClassificationType.errors),f.Bb(5),f.ic("ngIf",i.classificationFormEdit.controls.Ordinal.errors),f.Bb(6),f.ic("ngIf",i.classificationFormEdit.controls.LastUpdateDate_UTC.errors),f.Bb(5),f.ic("ngIf",i.classificationFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[R.q,R.l,R.f,I.b,c.l,g.c,g.f,T.b,R.n,R.c,R.k,R.e,B.a,c.k,y.a,g.b,k.n],pipes:[c.f],styles:[""],changeDetection:0}),W);function J(t,i){1&t&&f.Nb(0,"mat-progress-bar",4)}function H(t,i){1&t&&f.Nb(0,"mat-progress-bar",4)}function Z(t,i){if(1&t&&(f.Sb(0,"p"),f.Nb(1,"app-classification-edit",8),f.Rb()),2&t){var e=f.dc().$implicit,n=f.dc(2);f.Bb(1),f.ic("classification",e)("httpClientCommand",n.GetPutEnum())}}function K(t,i){if(1&t&&(f.Sb(0,"p"),f.Nb(1,"app-classification-edit",8),f.Rb()),2&t){var e=f.dc().$implicit,n=f.dc(2);f.Bb(1),f.ic("classification",e)("httpClientCommand",n.GetPostEnum())}}function X(t,i){if(1&t){var e=f.Tb();f.Sb(0,"div"),f.Sb(1,"p"),f.Sb(2,"button",6),f.Zb("click",(function(){f.qc(e);var t=i.$implicit;return f.dc(2).DeleteClassification(t)})),f.Sb(3,"span"),f.zc(4),f.Rb(),f.Sb(5,"mat-icon"),f.zc(6,"delete"),f.Rb(),f.Rb(),f.zc(7,"\xa0\xa0\xa0 "),f.Sb(8,"button",7),f.Zb("click",(function(){f.qc(e);var t=i.$implicit;return f.dc(2).ShowPut(t)})),f.Sb(9,"span"),f.zc(10,"Show Put"),f.Rb(),f.Rb(),f.zc(11,"\xa0\xa0 "),f.Sb(12,"button",7),f.Zb("click",(function(){f.qc(e);var t=i.$implicit;return f.dc(2).ShowPost(t)})),f.Sb(13,"span"),f.zc(14,"Show Post"),f.Rb(),f.Rb(),f.zc(15,"\xa0\xa0 "),f.yc(16,H,1,0,"mat-progress-bar",0),f.Rb(),f.yc(17,Z,2,2,"p",2),f.yc(18,K,2,2,"p",2),f.Sb(19,"blockquote"),f.Sb(20,"p"),f.Sb(21,"span"),f.zc(22),f.Rb(),f.Sb(23,"span"),f.zc(24),f.Rb(),f.Sb(25,"span"),f.zc(26),f.Rb(),f.Sb(27,"span"),f.zc(28),f.Rb(),f.Rb(),f.Sb(29,"p"),f.Sb(30,"span"),f.zc(31),f.Rb(),f.Sb(32,"span"),f.zc(33),f.Rb(),f.Rb(),f.Rb(),f.Rb()}if(2&t){var n=i.$implicit,a=f.dc(2);f.Bb(4),f.Bc("Delete ClassificationID [",n.ClassificationID,"]\xa0\xa0\xa0"),f.Bb(4),f.ic("color",a.GetPutButtonColor(n)),f.Bb(4),f.ic("color",a.GetPostButtonColor(n)),f.Bb(4),f.ic("ngIf",a.classificationService.classificationDeleteModel$.getValue().Working),f.Bb(1),f.ic("ngIf",a.IDToShow===n.ClassificationID&&a.showType===a.GetPutEnum()),f.Bb(1),f.ic("ngIf",a.IDToShow===n.ClassificationID&&a.showType===a.GetPostEnum()),f.Bb(4),f.Bc("ClassificationID: [",n.ClassificationID,"]"),f.Bb(2),f.Bc(" --- ClassificationTVItemID: [",n.ClassificationTVItemID,"]"),f.Bb(2),f.Bc(" --- ClassificationType: [",a.GetClassificationTypeEnumText(n.ClassificationType),"]"),f.Bb(2),f.Bc(" --- Ordinal: [",n.Ordinal,"]"),f.Bb(3),f.Bc("LastUpdateDate_UTC: [",n.LastUpdateDate_UTC,"]"),f.Bb(2),f.Bc(" --- LastUpdateContactTVItemID: [",n.LastUpdateContactTVItemID,"]")}}function Q(t,i){if(1&t&&(f.Sb(0,"div"),f.yc(1,X,34,12,"div",5),f.Rb()),2&t){var e=f.dc();f.Bb(1),f.ic("ngForOf",e.classificationService.classificationListModel$.getValue())}}var Y,tt,it,et=[{path:"",component:(Y=function(){function i(e,n,a){t(this,i),this.classificationService=e,this.router=n,this.httpClientService=a,this.showType=null,a.oldURL=n.url}return e(i,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.ClassificationID&&this.showType===u.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.ClassificationID&&this.showType===u.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.ClassificationID&&this.showType===u.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ClassificationID,this.showType=u.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.ClassificationID&&this.showType===u.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ClassificationID,this.showType=u.a.Post)}},{key:"GetPutEnum",value:function(){return u.a.Put}},{key:"GetPostEnum",value:function(){return u.a.Post}},{key:"GetClassificationList",value:function(){this.sub=this.classificationService.GetClassificationList().subscribe()}},{key:"DeleteClassification",value:function(t){this.sub=this.classificationService.DeleteClassification(t).subscribe()}},{key:"GetClassificationTypeEnumText",value:function(t){return function(t){var i;return r().forEach((function(e){if(e.EnumID==t)return i=e.EnumText,!1})),i}(t)}},{key:"ngOnInit",value:function(){s(this.classificationService.classificationTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),i}(),Y.\u0275fac=function(t){return new(t||Y)(f.Mb(S),f.Mb(o.b),f.Mb(C.a))},Y.\u0275cmp=f.Gb({type:Y,selectors:[["app-classification"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"classification","httpClientCommand"]],template:function(t,i){var e,n;1&t&&(f.yc(0,J,1,0,"mat-progress-bar",0),f.Sb(1,"mat-card"),f.Sb(2,"mat-card-header"),f.Sb(3,"mat-card-title"),f.zc(4," Classification works! "),f.Sb(5,"button",1),f.Zb("click",(function(){return i.GetClassificationList()})),f.Sb(6,"span"),f.zc(7,"Get Classification"),f.Rb(),f.Rb(),f.Rb(),f.Sb(8,"mat-card-subtitle"),f.zc(9),f.Rb(),f.Rb(),f.Sb(10,"mat-card-content"),f.yc(11,Q,2,1,"div",2),f.Rb(),f.Sb(12,"mat-card-actions"),f.Sb(13,"button",3),f.zc(14,"Allo"),f.Rb(),f.Rb(),f.Rb()),2&t&&(f.ic("ngIf",null==(e=i.classificationService.classificationGetModel$.getValue())?null:e.Working),f.Bb(9),f.Ac(i.classificationService.classificationTextModel$.getValue().Title),f.Bb(2),f.ic("ngIf",null==(n=i.classificationService.classificationListModel$.getValue())?null:n.length))},directives:[c.l,v.a,v.d,v.g,I.b,v.f,v.c,v.b,y.a,c.k,D.a,_],styles:[""],changeDetection:0}),Y),canActivate:[a("auXs").a]}],nt=((tt=function i(){t(this,i)}).\u0275mod=f.Kb({type:tt}),tt.\u0275inj=f.Jb({factory:function(t){return new(t||tt)},imports:[[o.e.forChild(et)],o.e]}),tt),at=a("B+Mi"),ct=((it=function i(){t(this,i)}).\u0275mod=f.Kb({type:it}),it.\u0275inj=f.Jb({factory:function(t){return new(t||it)},imports:[[c.c,o.e,nt,at.a,R.g,R.o]]}),it)}}])}();