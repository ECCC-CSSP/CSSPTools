function _classCallCheck(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function _defineProperties(e,t){for(var i=0;i<t.length;i++){var a=t[i];a.enumerable=a.enumerable||!1,a.configurable=!0,"value"in a&&(a.writable=!0),Object.defineProperty(e,a.key,a)}}function _createClass(e,t,i){return t&&_defineProperties(e.prototype,t),i&&_defineProperties(e,i),e}(window.webpackJsonp=window.webpackJsonp||[]).push([[47],{"+xK4":function(e,t,i){"use strict";i.r(t),i.d(t,"EmailModule",(function(){return ae}));var a=i("ofXK"),n=i("tyNb");function r(e){var t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.next(t)}function o(){var e=[];return"fr-CA"===$localize.locale?(e.push({EnumID:1,EnumText:"Personnel"}),e.push({EnumID:2,EnumText:"Travail"}),e.push({EnumID:3,EnumText:"Personnel-2"}),e.push({EnumID:4,EnumText:"Travail-2"})):(e.push({EnumID:1,EnumText:"Personal"}),e.push({EnumID:2,EnumText:"Work"}),e.push({EnumID:3,EnumText:"Personal-2"}),e.push({EnumID:4,EnumText:"Work-2"})),e.sort((function(e,t){return e.EnumText.localeCompare(t.EnumText)}))}var l,c=i("QRvi"),s=i("fXoL"),u=i("2Vo4"),m=i("LRne"),b=i("tk/3"),p=i("lJxs"),f=i("JIr8"),d=i("gkM4"),h=((l=function(){function e(t,i){_classCallCheck(this,e),this.httpClient=t,this.httpClientService=i,this.emailTextModel$=new u.a({}),this.emailListModel$=new u.a({}),this.emailGetModel$=new u.a({}),this.emailPutModel$=new u.a({}),this.emailPostModel$=new u.a({}),this.emailDeleteModel$=new u.a({}),r(this.emailTextModel$),this.emailTextModel$.next({Title:"Something2 for text"})}return _createClass(e,[{key:"GetEmailList",value:function(){var e=this;return this.httpClientService.BeforeHttpClient(this.emailGetModel$),this.httpClient.get("/api/Email").pipe(Object(p.a)((function(t){e.httpClientService.DoSuccess(e.emailListModel$,e.emailGetModel$,t,c.a.Get,null)})),Object(f.a)((function(t){return Object(m.a)(t).pipe(Object(p.a)((function(t){e.httpClientService.DoCatchError(e.emailListModel$,e.emailGetModel$,t)})))})))}},{key:"PutEmail",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.emailPutModel$),this.httpClient.put("/api/Email",e,{headers:new b.d}).pipe(Object(p.a)((function(i){t.httpClientService.DoSuccess(t.emailListModel$,t.emailPutModel$,i,c.a.Put,e)})),Object(f.a)((function(e){return Object(m.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.emailListModel$,t.emailPutModel$,e)})))})))}},{key:"PostEmail",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.emailPostModel$),this.httpClient.post("/api/Email",e,{headers:new b.d}).pipe(Object(p.a)((function(i){t.httpClientService.DoSuccess(t.emailListModel$,t.emailPostModel$,i,c.a.Post,e)})),Object(f.a)((function(e){return Object(m.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.emailListModel$,t.emailPostModel$,e)})))})))}},{key:"DeleteEmail",value:function(e){var t=this;return this.httpClientService.BeforeHttpClient(this.emailDeleteModel$),this.httpClient.delete("/api/Email/"+e.EmailID).pipe(Object(p.a)((function(i){t.httpClientService.DoSuccess(t.emailListModel$,t.emailDeleteModel$,i,c.a.Delete,e)})),Object(f.a)((function(e){return Object(m.a)(e).pipe(Object(p.a)((function(e){t.httpClientService.DoCatchError(t.emailListModel$,t.emailDeleteModel$,e)})))})))}}]),e}()).\u0275fac=function(e){return new(e||l)(s.Xb(b.b),s.Xb(d.a))},l.\u0275prov=s.Jb({token:l,factory:l.\u0275fac,providedIn:"root"}),l),T=i("Wp6s"),v=i("bTqV"),S=i("bv9b"),E=i("NFeN"),y=i("3Pt+"),I=i("kmnG"),C=i("qFsG"),D=i("d3UM"),g=i("FKr1");function P(e,t){1&e&&s.Ob(0,"mat-progress-bar",11)}function k(e,t){1&e&&s.Ob(0,"mat-progress-bar",11)}function x(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function B(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,x,3,0,"span",4),s.Sb()),2&e){var i=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,i)),s.Bb(3),s.jc("ngIf",i.required)}}function j(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function w(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,j,3,0,"span",4),s.Sb()),2&e){var i=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,i)),s.Bb(3),s.jc("ngIf",i.required)}}function O(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function $(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Need valid Email"),s.Ob(2,"br"),s.Sb())}function L(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"MaxLength - 255"),s.Ob(2,"br"),s.Sb())}function M(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,O,3,0,"span",4),s.xc(6,$,3,0,"span",4),s.xc(7,L,3,0,"span",4),s.Sb()),2&e){var i=t.$implicit;s.Bb(2),s.zc(s.gc(3,4,i)),s.Bb(3),s.jc("ngIf",i.required),s.Bb(1),s.jc("ngIf",i.email),s.Bb(1),s.jc("ngIf",i.maxlength)}}function G(e,t){if(1&e&&(s.Tb(0,"mat-option",12),s.yc(1),s.Sb()),2&e){var i=t.$implicit;s.jc("value",i.EnumID),s.Bb(1),s.Ac(" ",i.EnumText," ")}}function V(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function U(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,V,3,0,"span",4),s.Sb()),2&e){var i=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,i)),s.Bb(3),s.jc("ngIf",i.required)}}function F(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function q(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,F,3,0,"span",4),s.Sb()),2&e){var i=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,i)),s.Bb(3),s.jc("ngIf",i.required)}}function _(e,t){1&e&&(s.Tb(0,"span"),s.yc(1,"Is Required"),s.Ob(2,"br"),s.Sb())}function A(e,t){if(1&e&&(s.Tb(0,"mat-error"),s.Tb(1,"span"),s.yc(2),s.fc(3,"json"),s.Ob(4,"br"),s.Sb(),s.xc(5,_,3,0,"span",4),s.Sb()),2&e){var i=t.$implicit;s.Bb(2),s.zc(s.gc(3,2,i)),s.Bb(3),s.jc("ngIf",i.required)}}var N,R=((N=function(){function e(t,i){_classCallCheck(this,e),this.emailService=t,this.fb=i,this.email=null,this.httpClientCommand=c.a.Put}return _createClass(e,[{key:"GetPut",value:function(){return this.httpClientCommand==c.a.Put}},{key:"PutEmail",value:function(e){this.sub=this.emailService.PutEmail(e).subscribe()}},{key:"PostEmail",value:function(e){this.sub=this.emailService.PostEmail(e).subscribe()}},{key:"ngOnInit",value:function(){this.emailTypeList=o(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(e){if(this.email){var t=this.fb.group({EmailID:[{value:e===c.a.Post?0:this.email.EmailID,disabled:!1},[y.p.required]],EmailTVItemID:[{value:this.email.EmailTVItemID,disabled:!1},[y.p.required]],EmailAddress:[{value:this.email.EmailAddress,disabled:!1},[y.p.required,y.p.email,y.p.maxLength(255)]],EmailType:[{value:this.email.EmailType,disabled:!1},[y.p.required]],LastUpdateDate_UTC:[{value:this.email.LastUpdateDate_UTC,disabled:!1},[y.p.required]],LastUpdateContactTVItemID:[{value:this.email.LastUpdateContactTVItemID,disabled:!1},[y.p.required]]});this.emailFormEdit=t}}}]),e}()).\u0275fac=function(e){return new(e||N)(s.Nb(h),s.Nb(y.d))},N.\u0275cmp=s.Hb({type:N,selectors:[["app-email-edit"]],inputs:{email:"email",httpClientCommand:"httpClientCommand"},decls:41,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","EmailID"],[4,"ngIf"],["matInput","","type","number","formControlName","EmailTVItemID"],["matInput","","type","text","formControlName","EmailAddress"],["formControlName","EmailType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(e,t){1&e&&(s.Tb(0,"form",0),s.ac("ngSubmit",(function(){return t.GetPut()?t.PutEmail(t.emailFormEdit.value):t.PostEmail(t.emailFormEdit.value)})),s.Tb(1,"h3"),s.yc(2," Email "),s.Tb(3,"button",1),s.Tb(4,"span"),s.yc(5),s.Sb(),s.Sb(),s.xc(6,P,1,0,"mat-progress-bar",2),s.xc(7,k,1,0,"mat-progress-bar",2),s.Sb(),s.Tb(8,"p"),s.Tb(9,"mat-form-field"),s.Tb(10,"mat-label"),s.yc(11,"EmailID"),s.Sb(),s.Ob(12,"input",3),s.xc(13,B,6,4,"mat-error",4),s.Sb(),s.Tb(14,"mat-form-field"),s.Tb(15,"mat-label"),s.yc(16,"EmailTVItemID"),s.Sb(),s.Ob(17,"input",5),s.xc(18,w,6,4,"mat-error",4),s.Sb(),s.Tb(19,"mat-form-field"),s.Tb(20,"mat-label"),s.yc(21,"EmailAddress"),s.Sb(),s.Ob(22,"input",6),s.xc(23,M,8,6,"mat-error",4),s.Sb(),s.Tb(24,"mat-form-field"),s.Tb(25,"mat-label"),s.yc(26,"EmailType"),s.Sb(),s.Tb(27,"mat-select",7),s.xc(28,G,2,2,"mat-option",8),s.Sb(),s.xc(29,U,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Tb(30,"p"),s.Tb(31,"mat-form-field"),s.Tb(32,"mat-label"),s.yc(33,"LastUpdateDate_UTC"),s.Sb(),s.Ob(34,"input",9),s.xc(35,q,6,4,"mat-error",4),s.Sb(),s.Tb(36,"mat-form-field"),s.Tb(37,"mat-label"),s.yc(38,"LastUpdateContactTVItemID"),s.Sb(),s.Ob(39,"input",10),s.xc(40,A,6,4,"mat-error",4),s.Sb(),s.Sb(),s.Sb()),2&e&&(s.jc("formGroup",t.emailFormEdit),s.Bb(5),s.Ac("",t.GetPut()?"Put":"Post"," Email"),s.Bb(1),s.jc("ngIf",t.emailService.emailPutModel$.getValue().Working),s.Bb(1),s.jc("ngIf",t.emailService.emailPostModel$.getValue().Working),s.Bb(6),s.jc("ngIf",t.emailFormEdit.controls.EmailID.errors),s.Bb(5),s.jc("ngIf",t.emailFormEdit.controls.EmailTVItemID.errors),s.Bb(5),s.jc("ngIf",t.emailFormEdit.controls.EmailAddress.errors),s.Bb(5),s.jc("ngForOf",t.emailTypeList),s.Bb(1),s.jc("ngIf",t.emailFormEdit.controls.EmailType.errors),s.Bb(6),s.jc("ngIf",t.emailFormEdit.controls.LastUpdateDate_UTC.errors),s.Bb(5),s.jc("ngIf",t.emailFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[y.q,y.l,y.f,v.b,a.l,I.c,I.f,C.b,y.n,y.c,y.k,y.e,D.a,a.k,S.a,I.b,g.n],pipes:[a.f],styles:[""],changeDetection:0}),N);function W(e,t){1&e&&s.Ob(0,"mat-progress-bar",4)}function z(e,t){1&e&&s.Ob(0,"mat-progress-bar",4)}function H(e,t){if(1&e&&(s.Tb(0,"p"),s.Ob(1,"app-email-edit",8),s.Sb()),2&e){var i=s.ec().$implicit,a=s.ec(2);s.Bb(1),s.jc("email",i)("httpClientCommand",a.GetPutEnum())}}function X(e,t){if(1&e&&(s.Tb(0,"p"),s.Ob(1,"app-email-edit",8),s.Sb()),2&e){var i=s.ec().$implicit,a=s.ec(2);s.Bb(1),s.jc("email",i)("httpClientCommand",a.GetPostEnum())}}function J(e,t){if(1&e){var i=s.Ub();s.Tb(0,"div"),s.Tb(1,"p"),s.Tb(2,"button",6),s.ac("click",(function(){s.rc(i);var e=t.$implicit;return s.ec(2).DeleteEmail(e)})),s.Tb(3,"span"),s.yc(4),s.Sb(),s.Tb(5,"mat-icon"),s.yc(6,"delete"),s.Sb(),s.Sb(),s.yc(7,"\xa0\xa0\xa0 "),s.Tb(8,"button",7),s.ac("click",(function(){s.rc(i);var e=t.$implicit;return s.ec(2).ShowPut(e)})),s.Tb(9,"span"),s.yc(10,"Show Put"),s.Sb(),s.Sb(),s.yc(11,"\xa0\xa0 "),s.Tb(12,"button",7),s.ac("click",(function(){s.rc(i);var e=t.$implicit;return s.ec(2).ShowPost(e)})),s.Tb(13,"span"),s.yc(14,"Show Post"),s.Sb(),s.Sb(),s.yc(15,"\xa0\xa0 "),s.xc(16,z,1,0,"mat-progress-bar",0),s.Sb(),s.xc(17,H,2,2,"p",2),s.xc(18,X,2,2,"p",2),s.Tb(19,"blockquote"),s.Tb(20,"p"),s.Tb(21,"span"),s.yc(22),s.Sb(),s.Tb(23,"span"),s.yc(24),s.Sb(),s.Tb(25,"span"),s.yc(26),s.Sb(),s.Tb(27,"span"),s.yc(28),s.Sb(),s.Sb(),s.Tb(29,"p"),s.Tb(30,"span"),s.yc(31),s.Sb(),s.Tb(32,"span"),s.yc(33),s.Sb(),s.Sb(),s.Sb(),s.Sb()}if(2&e){var a=t.$implicit,n=s.ec(2);s.Bb(4),s.Ac("Delete EmailID [",a.EmailID,"]\xa0\xa0\xa0"),s.Bb(4),s.jc("color",n.GetPutButtonColor(a)),s.Bb(4),s.jc("color",n.GetPostButtonColor(a)),s.Bb(4),s.jc("ngIf",n.emailService.emailDeleteModel$.getValue().Working),s.Bb(1),s.jc("ngIf",n.IDToShow===a.EmailID&&n.showType===n.GetPutEnum()),s.Bb(1),s.jc("ngIf",n.IDToShow===a.EmailID&&n.showType===n.GetPostEnum()),s.Bb(4),s.Ac("EmailID: [",a.EmailID,"]"),s.Bb(2),s.Ac(" --- EmailTVItemID: [",a.EmailTVItemID,"]"),s.Bb(2),s.Ac(" --- EmailAddress: [",a.EmailAddress,"]"),s.Bb(2),s.Ac(" --- EmailType: [",n.GetEmailTypeEnumText(a.EmailType),"]"),s.Bb(3),s.Ac("LastUpdateDate_UTC: [",a.LastUpdateDate_UTC,"]"),s.Bb(2),s.Ac(" --- LastUpdateContactTVItemID: [",a.LastUpdateContactTVItemID,"]")}}function K(e,t){if(1&e&&(s.Tb(0,"div"),s.xc(1,J,34,12,"div",5),s.Sb()),2&e){var i=s.ec();s.Bb(1),s.jc("ngForOf",i.emailService.emailListModel$.getValue())}}var Q,Y,Z,ee=[{path:"",component:(Q=function(){function e(t,i,a){_classCallCheck(this,e),this.emailService=t,this.router=i,this.httpClientService=a,this.showType=null,a.oldURL=i.url}return _createClass(e,[{key:"GetPutButtonColor",value:function(e){return this.IDToShow===e.EmailID&&this.showType===c.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(e){return this.IDToShow===e.EmailID&&this.showType===c.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(e){this.IDToShow===e.EmailID&&this.showType===c.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.EmailID,this.showType=c.a.Put)}},{key:"ShowPost",value:function(e){this.IDToShow===e.EmailID&&this.showType===c.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=e.EmailID,this.showType=c.a.Post)}},{key:"GetPutEnum",value:function(){return c.a.Put}},{key:"GetPostEnum",value:function(){return c.a.Post}},{key:"GetEmailList",value:function(){this.sub=this.emailService.GetEmailList().subscribe()}},{key:"DeleteEmail",value:function(e){this.sub=this.emailService.DeleteEmail(e).subscribe()}},{key:"GetEmailTypeEnumText",value:function(e){return function(e){var t;return o().forEach((function(i){if(i.EnumID==e)return t=i.EnumText,!1})),t}(e)}},{key:"ngOnInit",value:function(){r(this.emailService.emailTextModel$)}},{key:"ngOnDestroy",value:function(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}]),e}(),Q.\u0275fac=function(e){return new(e||Q)(s.Nb(h),s.Nb(n.b),s.Nb(d.a))},Q.\u0275cmp=s.Hb({type:Q,selectors:[["app-email"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"email","httpClientCommand"]],template:function(e,t){if(1&e&&(s.xc(0,W,1,0,"mat-progress-bar",0),s.Tb(1,"mat-card"),s.Tb(2,"mat-card-header"),s.Tb(3,"mat-card-title"),s.yc(4," Email works! "),s.Tb(5,"button",1),s.ac("click",(function(){return t.GetEmailList()})),s.Tb(6,"span"),s.yc(7,"Get Email"),s.Sb(),s.Sb(),s.Sb(),s.Tb(8,"mat-card-subtitle"),s.yc(9),s.Sb(),s.Sb(),s.Tb(10,"mat-card-content"),s.xc(11,K,2,1,"div",2),s.Sb(),s.Tb(12,"mat-card-actions"),s.Tb(13,"button",3),s.yc(14,"Allo"),s.Sb(),s.Sb(),s.Sb()),2&e){var i,a,n=null==(i=t.emailService.emailGetModel$.getValue())?null:i.Working,r=null==(a=t.emailService.emailListModel$.getValue())?null:a.length;s.jc("ngIf",n),s.Bb(9),s.zc(t.emailService.emailTextModel$.getValue().Title),s.Bb(2),s.jc("ngIf",r)}},directives:[a.l,T.a,T.d,T.g,v.b,T.f,T.c,T.b,S.a,a.k,E.a,R],styles:[""],changeDetection:0}),Q),canActivate:[i("auXs").a]}],te=((Y=function e(){_classCallCheck(this,e)}).\u0275mod=s.Lb({type:Y}),Y.\u0275inj=s.Kb({factory:function(e){return new(e||Y)},imports:[[n.e.forChild(ee)],n.e]}),Y),ie=i("B+Mi"),ae=((Z=function e(){_classCallCheck(this,e)}).\u0275mod=s.Lb({type:Z}),Z.\u0275inj=s.Kb({factory:function(e){return new(e||Z)},imports:[[a.c,n.e,te,ie.a,y.g,y.o]]}),Z)},QRvi:function(e,t,i){"use strict";i.d(t,"a",(function(){return a}));var a=function(e){return e[e.Get=1]="Get",e[e.Put=2]="Put",e[e.Post=3]="Post",e[e.Delete=4]="Delete",e}({})},gkM4:function(e,t,i){"use strict";i.d(t,"a",(function(){return o}));var a=i("QRvi"),n=i("fXoL"),r=i("tyNb"),o=function(){var e=function(){function e(t){_classCallCheck(this,e),this.router=t,this.oldURL=t.url}return _createClass(e,[{key:"BeforeHttpClient",value:function(e){e.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(e,t,i){e.next(null),t.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var e=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){e.router.navigate(["/"+e.oldURL])}))}},{key:"DoSuccess",value:function(e,t,i,n,r){if(n===a.a.Get&&e.next(i),n===a.a.Put&&(e.getValue()[0]=i),n===a.a.Post&&e.getValue().push(i),n===a.a.Delete){var o=e.getValue().indexOf(r);e.getValue().splice(o,1)}e.next(e.getValue()),t.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(n.Xb(r.b))},e.\u0275prov=n.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()}}]);