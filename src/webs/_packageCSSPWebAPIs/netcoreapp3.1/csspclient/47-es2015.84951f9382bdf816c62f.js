(window.webpackJsonp=window.webpackJsonp||[]).push([[47],{"+xK4":function(t,e,i){"use strict";i.r(e),i.d(e,"EmailModule",(function(){return Y}));var a=i("ofXK"),n=i("tyNb");function o(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}function r(){let t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"Personnel"}),t.push({EnumID:2,EnumText:"Travail"}),t.push({EnumID:3,EnumText:"Personnel-2"}),t.push({EnumID:4,EnumText:"Travail-2"})):(t.push({EnumID:1,EnumText:"Personal"}),t.push({EnumID:2,EnumText:"Work"}),t.push({EnumID:3,EnumText:"Personal-2"}),t.push({EnumID:4,EnumText:"Work-2"})),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}var l=i("QRvi"),s=i("fXoL"),c=i("2Vo4"),m=i("LRne"),b=i("tk/3"),u=i("lJxs"),p=i("JIr8"),h=i("gkM4");let d=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.emailTextModel$=new c.a({}),this.emailListModel$=new c.a({}),this.emailGetModel$=new c.a({}),this.emailPutModel$=new c.a({}),this.emailPostModel$=new c.a({}),this.emailDeleteModel$=new c.a({}),o(this.emailTextModel$),this.emailTextModel$.next({Title:"Something2 for text"})}GetEmailList(){return this.httpClientService.BeforeHttpClient(this.emailGetModel$),this.httpClient.get("/api/Email").pipe(Object(u.a)(t=>{this.httpClientService.DoSuccess(this.emailListModel$,this.emailGetModel$,t,l.a.Get,null)}),Object(p.a)(t=>Object(m.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.emailListModel$,this.emailGetModel$,t)}))))}PutEmail(t){return this.httpClientService.BeforeHttpClient(this.emailPutModel$),this.httpClient.put("/api/Email",t,{headers:new b.d}).pipe(Object(u.a)(e=>{this.httpClientService.DoSuccess(this.emailListModel$,this.emailPutModel$,e,l.a.Put,t)}),Object(p.a)(t=>Object(m.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.emailListModel$,this.emailPutModel$,t)}))))}PostEmail(t){return this.httpClientService.BeforeHttpClient(this.emailPostModel$),this.httpClient.post("/api/Email",t,{headers:new b.d}).pipe(Object(u.a)(e=>{this.httpClientService.DoSuccess(this.emailListModel$,this.emailPostModel$,e,l.a.Post,t)}),Object(p.a)(t=>Object(m.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.emailListModel$,this.emailPostModel$,t)}))))}DeleteEmail(t){return this.httpClientService.BeforeHttpClient(this.emailDeleteModel$),this.httpClient.delete("/api/Email/"+t.EmailID).pipe(Object(u.a)(e=>{this.httpClientService.DoSuccess(this.emailListModel$,this.emailDeleteModel$,e,l.a.Delete,t)}),Object(p.a)(t=>Object(m.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.emailListModel$,this.emailDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(s.Xb(b.b),s.Xb(h.a))},t.\u0275prov=s.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var T=i("Wp6s"),f=i("bTqV"),S=i("bv9b"),E=i("NFeN"),I=i("3Pt+"),D=i("kmnG"),g=i("qFsG"),y=i("d3UM"),C=i("FKr1");function v(t,e){1&t&&s.Ob(0,"mat-progress-bar",11)}function x(t,e){1&t&&s.Ob(0,"mat-progress-bar",11)}function P(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function B(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,P,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function j(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function $(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,j,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function O(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function w(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Need valid Email"),s.Ob(2,"br"),s.Sb())}function L(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"MaxLength - 255"),s.Ob(2,"br"),s.Sb())}function M(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,O,3,0,"span",4),s.xc(6,w,3,0,"span",4),s.xc(7,L,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,4,t)),s.Bb(3),s.jc("ngIf",t.required),s.Bb(1),s.jc("ngIf",t.email),s.Bb(1),s.jc("ngIf",t.maxlength)}}function G(t,e){if(1&t&&(s.Tb(0,"mat-option",12),s.yc(1),s.Sb()),2&t){const t=e.$implicit;s.jc("value",t.EnumID),s.Bb(1),s.Ac(" ",t.EnumText," ")}}function k(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function V(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,k,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function U(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function F(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,U,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}function q(t,e){1&t&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function A(t,e){if(1&t&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,q,3,0,"span",4),s.Sb()),2&t){const t=e.$implicit;s.Bb(2),s.zc(s.gc(3,2,t)),s.Bb(3),s.jc("ngIf",t.required)}}let R=(()=>{class t{constructor(t,e){this.emailService=t,this.fb=e,this.email=null,this.httpClientCommand=l.a.Put}GetPut(){return this.httpClientCommand==l.a.Put}PutEmail(t){this.sub=this.emailService.PutEmail(t).subscribe()}PostEmail(t){this.sub=this.emailService.PostEmail(t).subscribe()}ngOnInit(){this.emailTypeList=r(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.email){let e=this.fb.group({EmailID:[{value:t===l.a.Post?0:this.email.EmailID,disabled:!1},[I.p.required]],EmailTVItemID:[{value:this.email.EmailTVItemID,disabled:!1},[I.p.required]],EmailAddress:[{value:this.email.EmailAddress,disabled:!1},[I.p.required,I.p.email,I.p.maxLength(255)]],EmailType:[{value:this.email.EmailType,disabled:!1},[I.p.required]],LastUpdateDate_UTC:[{value:this.email.LastUpdateDate_UTC,disabled:!1},[I.p.required]],LastUpdateContactTVItemID:[{value:this.email.LastUpdateContactTVItemID,disabled:!1},[I.p.required]]});this.emailFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(s.Nb(d),s.Nb(I.d))},t.\u0275cmp=s.Hb({type:t,selectors:[["app-email-edit"]],inputs:{email:"email",httpClientCommand:"httpClientCommand"},decls:41,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","EmailID"],[4,"ngIf"],["matInput","","type","number","formControlName","EmailTVItemID"],["matInput","","type","text","formControlName","EmailAddress"],["formControlName","EmailType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(s.Tb(0,"form",0),s.ac("ngSubmit",(function(){return e.GetPut()?e.PutEmail(e.emailFormEdit.value):e.PostEmail(e.emailFormEdit.value)})),s.Tb(1,"h3"),s.yc(2," Email "),s.Tb(3,"button",1),s.Tb(4,"span"),s.yc(5),s.Sb(),s.Sb(),s.xc(6,v,1,0,"mat-progress-bar",2),s.xc(7,x,1,0,"mat-progress-bar",2),s.Sb(),s.Tb(8,"p"),s.Tb(9,"mat-form-field"),s.Tb(10,"mat-label"),s.yc(11,"EmailID"),s.Sb(),s.Ob(12,"input",3),s.xc(13,B,6,4,"mat-error",4),s.Sb(),s.Tb(14,"mat-form-field"),s.Tb(15,"mat-label"),s.yc(16,"EmailTVItemID"),s.Sb(),s.Ob(17,"input",5),s.xc(18,$,6,4,"mat-error",4),s.Sb(),s.Tb(19,"mat-form-field"),s.Tb(20,"mat-label"),s.yc(21,"EmailAddress"),s.Sb(),s.Ob(22,"input",6),s.xc(23,M,8,6,"mat-error",4),s.Sb(),s.Tb(24,"mat-form-field"),s.Tb(25,"mat-label"),s.yc(26,"EmailType"),s.Sb(),s.Tb(27,"mat-select",7),s.xc(28,G,2,2,"mat-option",8),s.Sb(),s.xc(29,V,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Tb(30,"p"),s.Tb(31,"mat-form-field"),s.Tb(32,"mat-label"),s.yc(33,"LastUpdateDate_UTC"),s.Sb(),s.Ob(34,"input",9),s.xc(35,F,6,4,"mat-error",4),s.Sb(),s.Tb(36,"mat-form-field"),s.Tb(37,"mat-label"),s.yc(38,"LastUpdateContactTVItemID"),s.Sb(),s.Ob(39,"input",10),s.xc(40,A,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Sb()),2&t&&(s.jc("formGroup",e.emailFormEdit),s.Bb(5),s.Ac("",e.GetPut()?"Put":"Post"," Email"),s.Bb(1),s.jc("ngIf",e.emailService.emailPutModel$.getValue().Working),s.Bb(1),s.jc("ngIf",e.emailService.emailPostModel$.getValue().Working),s.Bb(6),s.jc("ngIf",e.emailFormEdit.controls.EmailID.errors),s.Bb(5),s.jc("ngIf",e.emailFormEdit.controls.EmailTVItemID.errors),s.Bb(5),s.jc("ngIf",e.emailFormEdit.controls.EmailAddress.errors),s.Bb(5),s.jc("ngForOf",e.emailTypeList),s.Bb(1),s.jc("ngIf",e.emailFormEdit.controls.EmailType.errors),s.Bb(6),s.jc("ngIf",e.emailFormEdit.controls.LastUpdateDate_UTC.errors),s.Bb(5),s.jc("ngIf",e.emailFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[I.q,I.l,I.f,f.b,a.l,D.c,D.f,g.b,I.n,I.c,I.k,I.e,y.a,a.k,S.a,D.b,C.n],pipes:[a.f],styles:[""],changeDetection:0}),t})();function N(t,e){1&t&&s.Ob(0,"mat-progress-bar",4)}function W(t,e){1&t&&s.Ob(0,"mat-progress-bar",4)}function z(t,e){if(1&t&&(s.Tb(0,"p"),s.Ob(1,"app-email-edit",8),s.Sb()),2&t){const t=s.ec().$implicit,e=s.ec(2);s.Bb(1),s.jc("email",t)("httpClientCommand",e.GetPutEnum())}}function H(t,e){if(1&t&&(s.Tb(0,"p"),s.Ob(1,"app-email-edit",8),s.Sb()),2&t){const t=s.ec().$implicit,e=s.ec(2);s.Bb(1),s.jc("email",t)("httpClientCommand",e.GetPostEnum())}}function X(t,e){if(1&t){const t=s.Ub();s.Tb(0,"div"),s.Tb(1,"p"),s.Tb(2,"button",6),s.ac("click",(function(){s.rc(t);const i=e.$implicit;return s.ec(2).DeleteEmail(i)})),s.Tb(3,"span"),s.yc(4),s.Sb(),s.Tb(5,"mat-icon"),s.yc(6,"delete"),s.Sb(),s.Sb(),s.yc(7,"\xa0\xa0\xa0 "),s.Tb(8,"button",7),s.ac("click",(function(){s.rc(t);const i=e.$implicit;return s.ec(2).ShowPut(i)})),s.Tb(9,"span"),s.yc(10,"Show Put"),s.Sb(),s.Sb(),s.yc(11,"\xa0\xa0 "),s.Tb(12,"button",7),s.ac("click",(function(){s.rc(t);const i=e.$implicit;return s.ec(2).ShowPost(i)})),s.Tb(13,"span"),s.yc(14,"Show Post"),s.Sb(),s.Sb(),s.yc(15,"\xa0\xa0 "),s.xc(16,W,1,0,"mat-progress-bar",0),s.Sb(),s.xc(17,z,2,2,"p",2),s.xc(18,H,2,2,"p",2),s.Tb(19,"blockquote"),s.Tb(20,"p"),s.Tb(21,"span"),s.yc(22),s.Sb(),s.Tb(23,"span"),s.yc(24),s.Sb(),s.Tb(25,"span"),s.yc(26),s.Sb(),s.Tb(27,"span"),s.yc(28),s.Sb(),s.Sb(),s.Tb(29,"p"),s.Tb(30,"span"),s.yc(31),s.Sb(),s.Tb(32,"span"),s.yc(33),s.Sb(),s.Sb(),s.Sb(),s.Sb()}if(2&t){const t=e.$implicit,i=s.ec(2);s.Bb(4),s.Ac("Delete EmailID [",t.EmailID,"]\xa0\xa0\xa0"),s.Bb(4),s.jc("color",i.GetPutButtonColor(t)),s.Bb(4),s.jc("color",i.GetPostButtonColor(t)),s.Bb(4),s.jc("ngIf",i.emailService.emailDeleteModel$.getValue().Working),s.Bb(1),s.jc("ngIf",i.IDToShow===t.EmailID&&i.showType===i.GetPutEnum()),s.Bb(1),s.jc("ngIf",i.IDToShow===t.EmailID&&i.showType===i.GetPostEnum()),s.Bb(4),s.Ac("EmailID: [",t.EmailID,"]"),s.Bb(2),s.Ac(" --- EmailTVItemID: [",t.EmailTVItemID,"]"),s.Bb(2),s.Ac(" --- EmailAddress: [",t.EmailAddress,"]"),s.Bb(2),s.Ac(" --- EmailType: [",i.GetEmailTypeEnumText(t.EmailType),"]"),s.Bb(3),s.Ac("LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),s.Bb(2),s.Ac(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function _(t,e){if(1&t&&(s.Tb(0,"div"),s.xc(1,X,34,12,"div",5),s.Sb()),2&t){const t=s.ec();s.Bb(1),s.jc("ngForOf",t.emailService.emailListModel$.getValue())}}const J=[{path:"",component:(()=>{class t{constructor(t,e,i){this.emailService=t,this.router=e,this.httpClientService=i,this.showType=null,i.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.EmailID&&this.showType===l.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.EmailID&&this.showType===l.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.EmailID&&this.showType===l.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.EmailID,this.showType=l.a.Put)}ShowPost(t){this.IDToShow===t.EmailID&&this.showType===l.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.EmailID,this.showType=l.a.Post)}GetPutEnum(){return l.a.Put}GetPostEnum(){return l.a.Post}GetEmailList(){this.sub=this.emailService.GetEmailList().subscribe()}DeleteEmail(t){this.sub=this.emailService.DeleteEmail(t).subscribe()}GetEmailTypeEnumText(t){return function(t){let e;return r().forEach(i=>{if(i.EnumID==t)return e=i.EnumText,!1}),e}(t)}ngOnInit(){o(this.emailService.emailTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(s.Nb(d),s.Nb(n.b),s.Nb(h.a))},t.\u0275cmp=s.Hb({type:t,selectors:[["app-email"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"email","httpClientCommand"]],template:function(t,e){if(1&t&&(s.xc(0,N,1,0,"mat-progress-bar",0),s.Tb(1,"mat-card"),s.Tb(2,"mat-card-header"),s.Tb(3,"mat-card-title"),s.yc(4," Email works! "),s.Tb(5,"button",1),s.ac("click",(function(){return e.GetEmailList()})),s.Tb(6,"span"),s.yc(7,"Get Email"),s.Sb(),s.Sb(),s.Sb(),s.Tb(8,"mat-card-subtitle"),s.yc(9),s.Sb(),s.Sb(),s.Tb(10,"mat-card-content"),s.xc(11,_,2,1,"div",2),s.Sb(),s.Tb(12,"mat-card-actions"),s.Tb(13,"button",3),s.yc(14,"Allo"),s.Sb(),s.Sb(),s.Sb()),2&t){var i;const t=null==(i=e.emailService.emailGetModel$.getValue())?null:i.Working;var a;const n=null==(a=e.emailService.emailListModel$.getValue())?null:a.length;s.jc("ngIf",t),s.Bb(9),s.zc(e.emailService.emailTextModel$.getValue().Title),s.Bb(2),s.jc("ngIf",n)}},directives:[a.l,T.a,T.d,T.g,f.b,T.f,T.c,T.b,S.a,a.k,E.a,R],styles:[""],changeDetection:0}),t})(),canActivate:[i("auXs").a]}];let K=(()=>{class t{}return t.\u0275mod=s.Lb({type:t}),t.\u0275inj=s.Kb({factory:function(e){return new(e||t)},imports:[[n.e.forChild(J)],n.e]}),t})();var Q=i("B+Mi");let Y=(()=>{class t{}return t.\u0275mod=s.Lb({type:t}),t.\u0275inj=s.Kb({factory:function(e){return new(e||t)},imports:[[a.c,n.e,K,Q.a,I.g,I.o]]}),t})()},QRvi:function(t,e,i){"use strict";i.d(e,"a",(function(){return a}));var a=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,i){"use strict";i.d(e,"a",(function(){return r}));var a=i("QRvi"),n=i("fXoL"),o=i("tyNb");let r=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,i,n,o){if(n===a.a.Get&&t.next(i),n===a.a.Put&&(t.getValue()[0]=i),n===a.a.Post&&t.getValue().push(i),n===a.a.Delete){const e=t.getValue().indexOf(o);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,i,n,o){n===a.a.Get&&t.next(i),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(n.Xb(o.b))},t.\u0275prov=n.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);