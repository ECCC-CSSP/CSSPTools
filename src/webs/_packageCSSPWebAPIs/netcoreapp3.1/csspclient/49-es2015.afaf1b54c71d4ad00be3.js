(window.webpackJsonp=window.webpackJsonp||[]).push([[49],{QRvi:function(t,i,e){"use strict";e.d(i,"a",(function(){return n}));var n=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,i,e){"use strict";e.d(i,"a",(function(){return s}));var n=e("QRvi"),o=e("fXoL"),a=e("tyNb");let s=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,i,e){t.next(null),i.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,i,e){t.next(null),i.next({Working:!1,Error:e,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,i,e,o,a){if(o===n.a.Get&&t.next(e),o===n.a.Put&&(t.getValue()[0]=e),o===n.a.Post&&t.getValue().push(e),o===n.a.Delete){const i=t.getValue().indexOf(a);t.getValue().splice(i,1)}t.next(t.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,i,e,o,a){o===n.a.Get&&t.next(e),t.next(t.getValue()),i.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(i){return new(i||t)(o.Xb(a.b))},t.\u0275prov=o.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()},usK0:function(t,i,e){"use strict";e.r(i),e.d(i,"EmailDistributionListContactModule",(function(){return rt}));var n=e("ofXK"),o=e("tyNb");function a(t){let i={Title:"The title"};"fr-CA"===$localize.locale&&(i.Title="Le Titre"),t.next(i)}var s=e("QRvi"),r=e("fXoL"),c=e("2Vo4"),b=e("LRne"),l=e("tk/3"),u=e("lJxs"),m=e("JIr8"),d=e("gkM4");let p=(()=>{class t{constructor(t,i){this.httpClient=t,this.httpClientService=i,this.emaildistributionlistcontactTextModel$=new c.a({}),this.emaildistributionlistcontactListModel$=new c.a({}),this.emaildistributionlistcontactGetModel$=new c.a({}),this.emaildistributionlistcontactPutModel$=new c.a({}),this.emaildistributionlistcontactPostModel$=new c.a({}),this.emaildistributionlistcontactDeleteModel$=new c.a({}),a(this.emaildistributionlistcontactTextModel$),this.emaildistributionlistcontactTextModel$.next({Title:"Something2 for text"})}GetEmailDistributionListContactList(){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistcontactGetModel$),this.httpClient.get("/api/EmailDistributionListContact").pipe(Object(u.a)(t=>{this.httpClientService.DoSuccess(this.emaildistributionlistcontactListModel$,this.emaildistributionlistcontactGetModel$,t,s.a.Get,null)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistcontactListModel$,this.emaildistributionlistcontactGetModel$,t)}))))}PutEmailDistributionListContact(t){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistcontactPutModel$),this.httpClient.put("/api/EmailDistributionListContact",t,{headers:new l.d}).pipe(Object(u.a)(i=>{this.httpClientService.DoSuccess(this.emaildistributionlistcontactListModel$,this.emaildistributionlistcontactPutModel$,i,s.a.Put,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistcontactListModel$,this.emaildistributionlistcontactPutModel$,t)}))))}PostEmailDistributionListContact(t){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistcontactPostModel$),this.httpClient.post("/api/EmailDistributionListContact",t,{headers:new l.d}).pipe(Object(u.a)(i=>{this.httpClientService.DoSuccess(this.emaildistributionlistcontactListModel$,this.emaildistributionlistcontactPostModel$,i,s.a.Post,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistcontactListModel$,this.emaildistributionlistcontactPostModel$,t)}))))}DeleteEmailDistributionListContact(t){return this.httpClientService.BeforeHttpClient(this.emaildistributionlistcontactDeleteModel$),this.httpClient.delete("/api/EmailDistributionListContact/"+t.EmailDistributionListContactID).pipe(Object(u.a)(i=>{this.httpClientService.DoSuccess(this.emaildistributionlistcontactListModel$,this.emaildistributionlistcontactDeleteModel$,i,s.a.Delete,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(u.a)(t=>{this.httpClientService.DoCatchError(this.emaildistributionlistcontactListModel$,this.emaildistributionlistcontactDeleteModel$,t)}))))}}return t.\u0275fac=function(i){return new(i||t)(r.Xb(l.b),r.Xb(d.a))},t.\u0275prov=r.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var f=e("Wp6s"),h=e("bTqV"),S=e("bv9b"),T=e("NFeN"),C=e("3Pt+"),D=e("kmnG"),g=e("qFsG");function y(t,i){1&t&&r.Ob(0,"mat-progress-bar",16)}function I(t,i){1&t&&r.Ob(0,"mat-progress-bar",16)}function E(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function L(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,E,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function B(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function v(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,B,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function P(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function x(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,P,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function j(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function O(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"MaxLength - 100"),r.Ob(2,"br"),r.Sb())}function w(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,j,3,0,"span",4),r.xc(6,O,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,3,t)),r.Bb(3),r.jc("ngIf",t.required),r.Bb(1),r.jc("ngIf",t.maxlength)}}function M(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function $(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Need valid Email"),r.Ob(2,"br"),r.Sb())}function q(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"MaxLength - 200"),r.Ob(2,"br"),r.Sb())}function R(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,M,3,0,"span",4),r.xc(6,$,3,0,"span",4),r.xc(7,q,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,4,t)),r.Bb(3),r.jc("ngIf",t.required),r.Bb(1),r.jc("ngIf",t.email),r.Bb(1),r.jc("ngIf",t.maxlength)}}function G(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function k(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,G,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function W(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function N(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,W,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function U(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function F(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,U,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function A(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function V(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,A,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function z(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function H(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,z,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function X(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function _(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,X,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}function J(t,i){1&t&&(r.Tb(0,"span"),r.yc(1,"Is Required"),r.Ob(2,"br"),r.Sb())}function K(t,i){if(1&t&&(r.Tb(0,"mat-error"),r.Tb(1,"span"),r.yc(2),r.fc(3,"json"),r.Ob(4,"br"),r.Sb(),r.xc(5,J,3,0,"span",4),r.Sb()),2&t){const t=i.$implicit;r.Bb(2),r.zc(r.gc(3,2,t)),r.Bb(3),r.jc("ngIf",t.required)}}let Q=(()=>{class t{constructor(t,i){this.emaildistributionlistcontactService=t,this.fb=i,this.emaildistributionlistcontact=null,this.httpClientCommand=s.a.Put}GetPut(){return this.httpClientCommand==s.a.Put}PutEmailDistributionListContact(t){this.sub=this.emaildistributionlistcontactService.PutEmailDistributionListContact(t).subscribe()}PostEmailDistributionListContact(t){this.sub=this.emaildistributionlistcontactService.PostEmailDistributionListContact(t).subscribe()}ngOnInit(){this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.emaildistributionlistcontact){let i=this.fb.group({EmailDistributionListContactID:[{value:t===s.a.Post?0:this.emaildistributionlistcontact.EmailDistributionListContactID,disabled:!1},[C.p.required]],EmailDistributionListID:[{value:this.emaildistributionlistcontact.EmailDistributionListID,disabled:!1},[C.p.required]],IsCC:[{value:this.emaildistributionlistcontact.IsCC,disabled:!1},[C.p.required]],Name:[{value:this.emaildistributionlistcontact.Name,disabled:!1},[C.p.required,C.p.maxLength(100)]],Email:[{value:this.emaildistributionlistcontact.Email,disabled:!1},[C.p.required,C.p.email,C.p.maxLength(200)]],CMPRainfallSeasonal:[{value:this.emaildistributionlistcontact.CMPRainfallSeasonal,disabled:!1},[C.p.required]],CMPWastewater:[{value:this.emaildistributionlistcontact.CMPWastewater,disabled:!1},[C.p.required]],EmergencyWeather:[{value:this.emaildistributionlistcontact.EmergencyWeather,disabled:!1},[C.p.required]],EmergencyWastewater:[{value:this.emaildistributionlistcontact.EmergencyWastewater,disabled:!1},[C.p.required]],ReopeningAllTypes:[{value:this.emaildistributionlistcontact.ReopeningAllTypes,disabled:!1},[C.p.required]],LastUpdateDate_UTC:[{value:this.emaildistributionlistcontact.LastUpdateDate_UTC,disabled:!1},[C.p.required]],LastUpdateContactTVItemID:[{value:this.emaildistributionlistcontact.LastUpdateContactTVItemID,disabled:!1},[C.p.required]]});this.emaildistributionlistcontactFormEdit=i}}}return t.\u0275fac=function(i){return new(i||t)(r.Nb(p),r.Nb(C.d))},t.\u0275cmp=r.Hb({type:t,selectors:[["app-emaildistributionlistcontact-edit"]],inputs:{emaildistributionlistcontact:"emaildistributionlistcontact",httpClientCommand:"httpClientCommand"},decls:71,vars:16,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","EmailDistributionListContactID"],[4,"ngIf"],["matInput","","type","number","formControlName","EmailDistributionListID"],["matInput","","type","text","formControlName","IsCC"],["matInput","","type","text","formControlName","Name"],["matInput","","type","text","formControlName","Email"],["matInput","","type","text","formControlName","CMPRainfallSeasonal"],["matInput","","type","text","formControlName","CMPWastewater"],["matInput","","type","text","formControlName","EmergencyWeather"],["matInput","","type","text","formControlName","EmergencyWastewater"],["matInput","","type","text","formControlName","ReopeningAllTypes"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"]],template:function(t,i){1&t&&(r.Tb(0,"form",0),r.ac("ngSubmit",(function(){return i.GetPut()?i.PutEmailDistributionListContact(i.emaildistributionlistcontactFormEdit.value):i.PostEmailDistributionListContact(i.emaildistributionlistcontactFormEdit.value)})),r.Tb(1,"h3"),r.yc(2," EmailDistributionListContact "),r.Tb(3,"button",1),r.Tb(4,"span"),r.yc(5),r.Sb(),r.Sb(),r.xc(6,y,1,0,"mat-progress-bar",2),r.xc(7,I,1,0,"mat-progress-bar",2),r.Sb(),r.Tb(8,"p"),r.Tb(9,"mat-form-field"),r.Tb(10,"mat-label"),r.yc(11,"EmailDistributionListContactID"),r.Sb(),r.Ob(12,"input",3),r.xc(13,L,6,4,"mat-error",4),r.Sb(),r.Tb(14,"mat-form-field"),r.Tb(15,"mat-label"),r.yc(16,"EmailDistributionListID"),r.Sb(),r.Ob(17,"input",5),r.xc(18,v,6,4,"mat-error",4),r.Sb(),r.Tb(19,"mat-form-field"),r.Tb(20,"mat-label"),r.yc(21,"IsCC"),r.Sb(),r.Ob(22,"input",6),r.xc(23,x,6,4,"mat-error",4),r.Sb(),r.Tb(24,"mat-form-field"),r.Tb(25,"mat-label"),r.yc(26,"Name"),r.Sb(),r.Ob(27,"input",7),r.xc(28,w,7,5,"mat-error",4),r.Sb(),r.Sb(),r.Tb(29,"p"),r.Tb(30,"mat-form-field"),r.Tb(31,"mat-label"),r.yc(32,"Email"),r.Sb(),r.Ob(33,"input",8),r.xc(34,R,8,6,"mat-error",4),r.Sb(),r.Tb(35,"mat-form-field"),r.Tb(36,"mat-label"),r.yc(37,"CMPRainfallSeasonal"),r.Sb(),r.Ob(38,"input",9),r.xc(39,k,6,4,"mat-error",4),r.Sb(),r.Tb(40,"mat-form-field"),r.Tb(41,"mat-label"),r.yc(42,"CMPWastewater"),r.Sb(),r.Ob(43,"input",10),r.xc(44,N,6,4,"mat-error",4),r.Sb(),r.Tb(45,"mat-form-field"),r.Tb(46,"mat-label"),r.yc(47,"EmergencyWeather"),r.Sb(),r.Ob(48,"input",11),r.xc(49,F,6,4,"mat-error",4),r.Sb(),r.Sb(),r.Tb(50,"p"),r.Tb(51,"mat-form-field"),r.Tb(52,"mat-label"),r.yc(53,"EmergencyWastewater"),r.Sb(),r.Ob(54,"input",12),r.xc(55,V,6,4,"mat-error",4),r.Sb(),r.Tb(56,"mat-form-field"),r.Tb(57,"mat-label"),r.yc(58,"ReopeningAllTypes"),r.Sb(),r.Ob(59,"input",13),r.xc(60,H,6,4,"mat-error",4),r.Sb(),r.Tb(61,"mat-form-field"),r.Tb(62,"mat-label"),r.yc(63,"LastUpdateDate_UTC"),r.Sb(),r.Ob(64,"input",14),r.xc(65,_,6,4,"mat-error",4),r.Sb(),r.Tb(66,"mat-form-field"),r.Tb(67,"mat-label"),r.yc(68,"LastUpdateContactTVItemID"),r.Sb(),r.Ob(69,"input",15),r.xc(70,K,6,4,"mat-error",4),r.Sb(),r.Sb(),r.Sb()),2&t&&(r.jc("formGroup",i.emaildistributionlistcontactFormEdit),r.Bb(5),r.Ac("",i.GetPut()?"Put":"Post"," EmailDistributionListContact"),r.Bb(1),r.jc("ngIf",i.emaildistributionlistcontactService.emaildistributionlistcontactPutModel$.getValue().Working),r.Bb(1),r.jc("ngIf",i.emaildistributionlistcontactService.emaildistributionlistcontactPostModel$.getValue().Working),r.Bb(6),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.EmailDistributionListContactID.errors),r.Bb(5),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.EmailDistributionListID.errors),r.Bb(5),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.IsCC.errors),r.Bb(5),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.Name.errors),r.Bb(6),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.Email.errors),r.Bb(5),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.CMPRainfallSeasonal.errors),r.Bb(5),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.CMPWastewater.errors),r.Bb(5),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.EmergencyWeather.errors),r.Bb(6),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.EmergencyWastewater.errors),r.Bb(5),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.ReopeningAllTypes.errors),r.Bb(5),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.LastUpdateDate_UTC.errors),r.Bb(5),r.jc("ngIf",i.emaildistributionlistcontactFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[C.q,C.l,C.f,h.b,n.l,D.c,D.f,g.b,C.n,C.c,C.k,C.e,S.a,D.b],pipes:[n.f],styles:[""],changeDetection:0}),t})();function Y(t,i){1&t&&r.Ob(0,"mat-progress-bar",4)}function Z(t,i){1&t&&r.Ob(0,"mat-progress-bar",4)}function tt(t,i){if(1&t&&(r.Tb(0,"p"),r.Ob(1,"app-emaildistributionlistcontact-edit",8),r.Sb()),2&t){const t=r.ec().$implicit,i=r.ec(2);r.Bb(1),r.jc("emaildistributionlistcontact",t)("httpClientCommand",i.GetPutEnum())}}function it(t,i){if(1&t&&(r.Tb(0,"p"),r.Ob(1,"app-emaildistributionlistcontact-edit",8),r.Sb()),2&t){const t=r.ec().$implicit,i=r.ec(2);r.Bb(1),r.jc("emaildistributionlistcontact",t)("httpClientCommand",i.GetPostEnum())}}function et(t,i){if(1&t){const t=r.Ub();r.Tb(0,"div"),r.Tb(1,"p"),r.Tb(2,"button",6),r.ac("click",(function(){r.rc(t);const e=i.$implicit;return r.ec(2).DeleteEmailDistributionListContact(e)})),r.Tb(3,"span"),r.yc(4),r.Sb(),r.Tb(5,"mat-icon"),r.yc(6,"delete"),r.Sb(),r.Sb(),r.yc(7,"\xa0\xa0\xa0 "),r.Tb(8,"button",7),r.ac("click",(function(){r.rc(t);const e=i.$implicit;return r.ec(2).ShowPut(e)})),r.Tb(9,"span"),r.yc(10,"Show Put"),r.Sb(),r.Sb(),r.yc(11,"\xa0\xa0 "),r.Tb(12,"button",7),r.ac("click",(function(){r.rc(t);const e=i.$implicit;return r.ec(2).ShowPost(e)})),r.Tb(13,"span"),r.yc(14,"Show Post"),r.Sb(),r.Sb(),r.yc(15,"\xa0\xa0 "),r.xc(16,Z,1,0,"mat-progress-bar",0),r.Sb(),r.xc(17,tt,2,2,"p",2),r.xc(18,it,2,2,"p",2),r.Tb(19,"blockquote"),r.Tb(20,"p"),r.Tb(21,"span"),r.yc(22),r.Sb(),r.Tb(23,"span"),r.yc(24),r.Sb(),r.Tb(25,"span"),r.yc(26),r.Sb(),r.Tb(27,"span"),r.yc(28),r.Sb(),r.Sb(),r.Tb(29,"p"),r.Tb(30,"span"),r.yc(31),r.Sb(),r.Tb(32,"span"),r.yc(33),r.Sb(),r.Tb(34,"span"),r.yc(35),r.Sb(),r.Tb(36,"span"),r.yc(37),r.Sb(),r.Sb(),r.Tb(38,"p"),r.Tb(39,"span"),r.yc(40),r.Sb(),r.Tb(41,"span"),r.yc(42),r.Sb(),r.Tb(43,"span"),r.yc(44),r.Sb(),r.Tb(45,"span"),r.yc(46),r.Sb(),r.Sb(),r.Sb(),r.Sb()}if(2&t){const t=i.$implicit,e=r.ec(2);r.Bb(4),r.Ac("Delete EmailDistributionListContactID [",t.EmailDistributionListContactID,"]\xa0\xa0\xa0"),r.Bb(4),r.jc("color",e.GetPutButtonColor(t)),r.Bb(4),r.jc("color",e.GetPostButtonColor(t)),r.Bb(4),r.jc("ngIf",e.emaildistributionlistcontactService.emaildistributionlistcontactDeleteModel$.getValue().Working),r.Bb(1),r.jc("ngIf",e.IDToShow===t.EmailDistributionListContactID&&e.showType===e.GetPutEnum()),r.Bb(1),r.jc("ngIf",e.IDToShow===t.EmailDistributionListContactID&&e.showType===e.GetPostEnum()),r.Bb(4),r.Ac("EmailDistributionListContactID: [",t.EmailDistributionListContactID,"]"),r.Bb(2),r.Ac(" --- EmailDistributionListID: [",t.EmailDistributionListID,"]"),r.Bb(2),r.Ac(" --- IsCC: [",t.IsCC,"]"),r.Bb(2),r.Ac(" --- Name: [",t.Name,"]"),r.Bb(3),r.Ac("Email: [",t.Email,"]"),r.Bb(2),r.Ac(" --- CMPRainfallSeasonal: [",t.CMPRainfallSeasonal,"]"),r.Bb(2),r.Ac(" --- CMPWastewater: [",t.CMPWastewater,"]"),r.Bb(2),r.Ac(" --- EmergencyWeather: [",t.EmergencyWeather,"]"),r.Bb(3),r.Ac("EmergencyWastewater: [",t.EmergencyWastewater,"]"),r.Bb(2),r.Ac(" --- ReopeningAllTypes: [",t.ReopeningAllTypes,"]"),r.Bb(2),r.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),r.Bb(2),r.Ac(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function nt(t,i){if(1&t&&(r.Tb(0,"div"),r.xc(1,et,47,18,"div",5),r.Sb()),2&t){const t=r.ec();r.Bb(1),r.jc("ngForOf",t.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue())}}const ot=[{path:"",component:(()=>{class t{constructor(t,i,e){this.emaildistributionlistcontactService=t,this.router=i,this.httpClientService=e,this.showType=null,e.oldURL=i.url}GetPutButtonColor(t){return this.IDToShow===t.EmailDistributionListContactID&&this.showType===s.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.EmailDistributionListContactID&&this.showType===s.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.EmailDistributionListContactID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.EmailDistributionListContactID,this.showType=s.a.Put)}ShowPost(t){this.IDToShow===t.EmailDistributionListContactID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.EmailDistributionListContactID,this.showType=s.a.Post)}GetPutEnum(){return s.a.Put}GetPostEnum(){return s.a.Post}GetEmailDistributionListContactList(){this.sub=this.emaildistributionlistcontactService.GetEmailDistributionListContactList().subscribe()}DeleteEmailDistributionListContact(t){this.sub=this.emaildistributionlistcontactService.DeleteEmailDistributionListContact(t).subscribe()}ngOnInit(){a(this.emaildistributionlistcontactService.emaildistributionlistcontactTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(i){return new(i||t)(r.Nb(p),r.Nb(o.b),r.Nb(d.a))},t.\u0275cmp=r.Hb({type:t,selectors:[["app-emaildistributionlistcontact"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"emaildistributionlistcontact","httpClientCommand"]],template:function(t,i){if(1&t&&(r.xc(0,Y,1,0,"mat-progress-bar",0),r.Tb(1,"mat-card"),r.Tb(2,"mat-card-header"),r.Tb(3,"mat-card-title"),r.yc(4," EmailDistributionListContact works! "),r.Tb(5,"button",1),r.ac("click",(function(){return i.GetEmailDistributionListContactList()})),r.Tb(6,"span"),r.yc(7,"Get EmailDistributionListContact"),r.Sb(),r.Sb(),r.Sb(),r.Tb(8,"mat-card-subtitle"),r.yc(9),r.Sb(),r.Sb(),r.Tb(10,"mat-card-content"),r.xc(11,nt,2,1,"div",2),r.Sb(),r.Tb(12,"mat-card-actions"),r.Tb(13,"button",3),r.yc(14,"Allo"),r.Sb(),r.Sb(),r.Sb()),2&t){var e;const t=null==(e=i.emaildistributionlistcontactService.emaildistributionlistcontactGetModel$.getValue())?null:e.Working;var n;const o=null==(n=i.emaildistributionlistcontactService.emaildistributionlistcontactListModel$.getValue())?null:n.length;r.jc("ngIf",t),r.Bb(9),r.zc(i.emaildistributionlistcontactService.emaildistributionlistcontactTextModel$.getValue().Title),r.Bb(2),r.jc("ngIf",o)}},directives:[n.l,f.a,f.d,f.g,h.b,f.f,f.c,f.b,S.a,n.k,T.a,Q],styles:[""],changeDetection:0}),t})(),canActivate:[e("auXs").a]}];let at=(()=>{class t{}return t.\u0275mod=r.Lb({type:t}),t.\u0275inj=r.Kb({factory:function(i){return new(i||t)},imports:[[o.e.forChild(ot)],o.e]}),t})();var st=e("B+Mi");let rt=(()=>{class t{}return t.\u0275mod=r.Lb({type:t}),t.\u0275inj=r.Kb({factory:function(i){return new(i||t)},imports:[[n.c,o.e,at,st.a,C.g,C.o]]}),t})()}}]);