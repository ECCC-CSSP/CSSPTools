(window.webpackJsonp=window.webpackJsonp||[]).push([[43],{QRvi:function(t,e,n){"use strict";n.d(e,"a",(function(){return c}));var c=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(t,e,n){"use strict";n.d(e,"a",(function(){return i}));var c=n("QRvi"),o=n("fXoL"),a=n("tyNb");let i=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,n,o,a){if(o===c.a.Get&&t.next(n),o===c.a.Put&&(t.getValue()[0]=n),o===c.a.Post&&t.getValue().push(n),o===c.a.Delete){const e=t.getValue().indexOf(a);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,n,o,a){o===c.a.Get&&t.next(n),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(o.Xb(a.b))},t.\u0275prov=o.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()},wtgo:function(t,e,n){"use strict";n.r(e),n.d(e,"ContactModule",(function(){return Dt}));var c=n("ofXK"),o=n("tyNb");function a(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}function i(){let t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"Director General (fr)"}),t.push({EnumID:2,EnumText:"Director Public Works (fr)"}),t.push({EnumID:3,EnumText:"Superintendent (fr)"}),t.push({EnumID:4,EnumText:"Engineer (fr)"}),t.push({EnumID:5,EnumText:"Foreman (fr)"}),t.push({EnumID:6,EnumText:"Operator (fr)"}),t.push({EnumID:7,EnumText:"Facilities Manager (fr)"}),t.push({EnumID:8,EnumText:"Supervisor (fr)"}),t.push({EnumID:9,EnumText:"Technician (fr)"})):(t.push({EnumID:1,EnumText:"Director General"}),t.push({EnumID:2,EnumText:"Director Public Works"}),t.push({EnumID:3,EnumText:"Superintendent"}),t.push({EnumID:4,EnumText:"Engineer"}),t.push({EnumID:5,EnumText:"Foreman"}),t.push({EnumID:6,EnumText:"Operator"}),t.push({EnumID:7,EnumText:"Facilities Manager"}),t.push({EnumID:8,EnumText:"Supervisor"}),t.push({EnumID:9,EnumText:"Technician"})),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}var r=n("QRvi"),b=n("fXoL"),s=n("2Vo4"),l=n("LRne"),u=n("tk/3"),m=n("lJxs"),p=n("JIr8"),d=n("gkM4");let f=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.contactTextModel$=new s.a({}),this.contactListModel$=new s.a({}),this.contactGetModel$=new s.a({}),this.contactPutModel$=new s.a({}),this.contactPostModel$=new s.a({}),this.contactDeleteModel$=new s.a({}),a(this.contactTextModel$),this.contactTextModel$.next({Title:"Something2 for text"})}GetContactList(){return this.httpClientService.BeforeHttpClient(this.contactGetModel$),this.httpClient.get("/api/Contact").pipe(Object(m.a)(t=>{this.httpClientService.DoSuccess(this.contactListModel$,this.contactGetModel$,t,r.a.Get,null)}),Object(p.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.contactListModel$,this.contactGetModel$,t)}))))}PutContact(t){return this.httpClientService.BeforeHttpClient(this.contactPutModel$),this.httpClient.put("/api/Contact",t,{headers:new u.d}).pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.contactListModel$,this.contactPutModel$,e,r.a.Put,t)}),Object(p.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.contactListModel$,this.contactPutModel$,t)}))))}PostContact(t){return this.httpClientService.BeforeHttpClient(this.contactPostModel$),this.httpClient.post("/api/Contact",t,{headers:new u.d}).pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.contactListModel$,this.contactPostModel$,e,r.a.Post,t)}),Object(p.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.contactListModel$,this.contactPostModel$,t)}))))}DeleteContact(t){return this.httpClientService.BeforeHttpClient(this.contactDeleteModel$),this.httpClient.delete("/api/Contact/"+t.ContactID).pipe(Object(m.a)(e=>{this.httpClientService.DoSuccess(this.contactListModel$,this.contactDeleteModel$,e,r.a.Delete,t)}),Object(p.a)(t=>Object(l.a)(t).pipe(Object(m.a)(t=>{this.httpClientService.DoCatchError(this.contactListModel$,this.contactDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(b.Xb(u.b),b.Xb(d.a))},t.\u0275prov=b.Jb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var T=n("Wp6s"),h=n("bTqV"),S=n("bv9b"),I=n("NFeN"),g=n("3Pt+"),C=n("kmnG"),y=n("qFsG"),x=n("d3UM"),D=n("FKr1");function B(t,e){1&t&&b.Ob(0,"mat-progress-bar",22)}function E(t,e){1&t&&b.Ob(0,"mat-progress-bar",22)}function v(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function j(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,v,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function O(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function P(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 450"),b.Ob(2,"br"),b.Sb())}function L(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,O,3,0,"span",4),b.xc(6,P,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,3,t)),b.Bb(3),b.jc("ngIf",t.required),b.Bb(1),b.jc("ngIf",t.maxlength)}}function $(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function w(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,$,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function N(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function M(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Need valid Email"),b.Ob(2,"br"),b.Sb())}function F(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MinLength - 6"),b.Ob(2,"br"),b.Sb())}function q(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 255"),b.Ob(2,"br"),b.Sb())}function V(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,N,3,0,"span",4),b.xc(6,M,3,0,"span",4),b.xc(7,F,3,0,"span",4),b.xc(8,q,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,5,t)),b.Bb(3),b.jc("ngIf",t.required),b.Bb(1),b.jc("ngIf",t.email),b.Bb(1),b.jc("ngIf",t.minlength),b.Bb(1),b.jc("ngIf",t.maxlength)}}function k(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function G(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 100"),b.Ob(2,"br"),b.Sb())}function A(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,k,3,0,"span",4),b.xc(6,G,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,3,t)),b.Bb(3),b.jc("ngIf",t.required),b.Bb(1),b.jc("ngIf",t.maxlength)}}function U(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function R(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 100"),b.Ob(2,"br"),b.Sb())}function z(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,U,3,0,"span",4),b.xc(6,R,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,3,t)),b.Bb(3),b.jc("ngIf",t.required),b.Bb(1),b.jc("ngIf",t.maxlength)}}function W(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 50"),b.Ob(2,"br"),b.Sb())}function _(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,W,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.maxlength)}}function H(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function X(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 100"),b.Ob(2,"br"),b.Sb())}function J(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,H,3,0,"span",4),b.xc(6,X,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,3,t)),b.Bb(3),b.jc("ngIf",t.required),b.Bb(1),b.jc("ngIf",t.maxlength)}}function K(t,e){if(1&t&&(b.Tb(0,"mat-option",23),b.yc(1),b.Sb()),2&t){const t=e.$implicit;b.jc("value",t.EnumID),b.Bb(1),b.Ac(" ",t.EnumText," ")}}function Q(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,1,t))}}function Y(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function Z(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,Y,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function tt(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function et(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,tt,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function nt(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function ct(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,nt,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function ot(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function at(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,ot,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function it(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 200"),b.Ob(2,"br"),b.Sb())}function rt(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,it,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.maxlength)}}function bt(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"MaxLength - 255"),b.Ob(2,"br"),b.Sb())}function st(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,bt,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.maxlength)}}function lt(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function ut(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,lt,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}function mt(t,e){1&t&&(b.Tb(0,"span"),b.yc(1,"Is Required"),b.Ob(2,"br"),b.Sb())}function pt(t,e){if(1&t&&(b.Tb(0,"mat-error"),b.Tb(1,"span"),b.yc(2),b.fc(3,"json"),b.Ob(4,"br"),b.Sb(),b.xc(5,mt,3,0,"span",4),b.Sb()),2&t){const t=e.$implicit;b.Bb(2),b.zc(b.gc(3,2,t)),b.Bb(3),b.jc("ngIf",t.required)}}let dt=(()=>{class t{constructor(t,e){this.contactService=t,this.fb=e,this.contact=null,this.httpClientCommand=r.a.Put}GetPut(){return this.httpClientCommand==r.a.Put}PutContact(t){this.sub=this.contactService.PutContact(t).subscribe()}PostContact(t){this.sub=this.contactService.PostContact(t).subscribe()}ngOnInit(){this.contactTitleList=i(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.contact){let e=this.fb.group({ContactID:[{value:t===r.a.Post?0:this.contact.ContactID,disabled:!1},[g.p.required]],Id:[{value:this.contact.Id,disabled:!1},[g.p.required,g.p.maxLength(450)]],ContactTVItemID:[{value:this.contact.ContactTVItemID,disabled:!1},[g.p.required]],LoginEmail:[{value:this.contact.LoginEmail,disabled:!1},[g.p.required,g.p.email,g.p.minLength(6),g.p.maxLength(255)]],FirstName:[{value:this.contact.FirstName,disabled:!1},[g.p.required,g.p.maxLength(100)]],LastName:[{value:this.contact.LastName,disabled:!1},[g.p.required,g.p.maxLength(100)]],Initial:[{value:this.contact.Initial,disabled:!1},[g.p.maxLength(50)]],WebName:[{value:this.contact.WebName,disabled:!1},[g.p.required,g.p.maxLength(100)]],ContactTitle:[{value:this.contact.ContactTitle,disabled:!1}],IsAdmin:[{value:this.contact.IsAdmin,disabled:!1},[g.p.required]],EmailValidated:[{value:this.contact.EmailValidated,disabled:!1},[g.p.required]],Disabled:[{value:this.contact.Disabled,disabled:!1},[g.p.required]],IsNew:[{value:this.contact.IsNew,disabled:!1},[g.p.required]],SamplingPlanner_ProvincesTVItemID:[{value:this.contact.SamplingPlanner_ProvincesTVItemID,disabled:!1},[g.p.maxLength(200)]],Token:[{value:this.contact.Token,disabled:!1},[g.p.maxLength(255)]],LastUpdateDate_UTC:[{value:this.contact.LastUpdateDate_UTC,disabled:!1},[g.p.required]],LastUpdateContactTVItemID:[{value:this.contact.LastUpdateContactTVItemID,disabled:!1},[g.p.required]]});this.contactFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(b.Nb(f),b.Nb(g.d))},t.\u0275cmp=b.Hb({type:t,selectors:[["app-contact-edit"]],inputs:{contact:"contact",httpClientCommand:"httpClientCommand"},decls:99,vars:22,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","ContactID"],[4,"ngIf"],["matInput","","type","text","formControlName","Id"],["matInput","","type","number","formControlName","ContactTVItemID"],["matInput","","type","text","formControlName","LoginEmail"],["matInput","","type","text","formControlName","FirstName"],["matInput","","type","text","formControlName","LastName"],["matInput","","type","text","formControlName","Initial"],["matInput","","type","text","formControlName","WebName"],["formControlName","ContactTitle"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","IsAdmin"],["matInput","","type","text","formControlName","EmailValidated"],["matInput","","type","text","formControlName","Disabled"],["matInput","","type","text","formControlName","IsNew"],["matInput","","type","text","formControlName","SamplingPlanner_ProvincesTVItemID"],["matInput","","type","text","formControlName","Token"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(b.Tb(0,"form",0),b.ac("ngSubmit",(function(){return e.GetPut()?e.PutContact(e.contactFormEdit.value):e.PostContact(e.contactFormEdit.value)})),b.Tb(1,"h3"),b.yc(2," Contact "),b.Tb(3,"button",1),b.Tb(4,"span"),b.yc(5),b.Sb(),b.Sb(),b.xc(6,B,1,0,"mat-progress-bar",2),b.xc(7,E,1,0,"mat-progress-bar",2),b.Sb(),b.Tb(8,"p"),b.Tb(9,"mat-form-field"),b.Tb(10,"mat-label"),b.yc(11,"ContactID"),b.Sb(),b.Ob(12,"input",3),b.xc(13,j,6,4,"mat-error",4),b.Sb(),b.Tb(14,"mat-form-field"),b.Tb(15,"mat-label"),b.yc(16,"Id"),b.Sb(),b.Ob(17,"input",5),b.xc(18,L,7,5,"mat-error",4),b.Sb(),b.Tb(19,"mat-form-field"),b.Tb(20,"mat-label"),b.yc(21,"ContactTVItemID"),b.Sb(),b.Ob(22,"input",6),b.xc(23,w,6,4,"mat-error",4),b.Sb(),b.Tb(24,"mat-form-field"),b.Tb(25,"mat-label"),b.yc(26,"LoginEmail"),b.Sb(),b.Ob(27,"input",7),b.xc(28,V,9,7,"mat-error",4),b.Sb(),b.Sb(),b.Tb(29,"p"),b.Tb(30,"mat-form-field"),b.Tb(31,"mat-label"),b.yc(32,"FirstName"),b.Sb(),b.Ob(33,"input",8),b.xc(34,A,7,5,"mat-error",4),b.Sb(),b.Tb(35,"mat-form-field"),b.Tb(36,"mat-label"),b.yc(37,"LastName"),b.Sb(),b.Ob(38,"input",9),b.xc(39,z,7,5,"mat-error",4),b.Sb(),b.Tb(40,"mat-form-field"),b.Tb(41,"mat-label"),b.yc(42,"Initial"),b.Sb(),b.Ob(43,"input",10),b.xc(44,_,6,4,"mat-error",4),b.Sb(),b.Tb(45,"mat-form-field"),b.Tb(46,"mat-label"),b.yc(47,"WebName"),b.Sb(),b.Ob(48,"input",11),b.xc(49,J,7,5,"mat-error",4),b.Sb(),b.Sb(),b.Tb(50,"p"),b.Tb(51,"mat-form-field"),b.Tb(52,"mat-label"),b.yc(53,"ContactTitle"),b.Sb(),b.Tb(54,"mat-select",12),b.xc(55,K,2,2,"mat-option",13),b.Sb(),b.xc(56,Q,5,3,"mat-error",4),b.Sb(),b.Tb(57,"mat-form-field"),b.Tb(58,"mat-label"),b.yc(59,"IsAdmin"),b.Sb(),b.Ob(60,"input",14),b.xc(61,Z,6,4,"mat-error",4),b.Sb(),b.Tb(62,"mat-form-field"),b.Tb(63,"mat-label"),b.yc(64,"EmailValidated"),b.Sb(),b.Ob(65,"input",15),b.xc(66,et,6,4,"mat-error",4),b.Sb(),b.Tb(67,"mat-form-field"),b.Tb(68,"mat-label"),b.yc(69,"Disabled"),b.Sb(),b.Ob(70,"input",16),b.xc(71,ct,6,4,"mat-error",4),b.Sb(),b.Sb(),b.Tb(72,"p"),b.Tb(73,"mat-form-field"),b.Tb(74,"mat-label"),b.yc(75,"IsNew"),b.Sb(),b.Ob(76,"input",17),b.xc(77,at,6,4,"mat-error",4),b.Sb(),b.Tb(78,"mat-form-field"),b.Tb(79,"mat-label"),b.yc(80,"SamplingPlanner_ProvincesTVItemID"),b.Sb(),b.Ob(81,"input",18),b.xc(82,rt,6,4,"mat-error",4),b.Sb(),b.Tb(83,"mat-form-field"),b.Tb(84,"mat-label"),b.yc(85,"Token"),b.Sb(),b.Ob(86,"input",19),b.xc(87,st,6,4,"mat-error",4),b.Sb(),b.Tb(88,"mat-form-field"),b.Tb(89,"mat-label"),b.yc(90,"LastUpdateDate_UTC"),b.Sb(),b.Ob(91,"input",20),b.xc(92,ut,6,4,"mat-error",4),b.Sb(),b.Sb(),b.Tb(93,"p"),b.Tb(94,"mat-form-field"),b.Tb(95,"mat-label"),b.yc(96,"LastUpdateContactTVItemID"),b.Sb(),b.Ob(97,"input",21),b.xc(98,pt,6,4,"mat-error",4),b.Sb(),b.Sb(),b.Sb()),2&t&&(b.jc("formGroup",e.contactFormEdit),b.Bb(5),b.Ac("",e.GetPut()?"Put":"Post"," Contact"),b.Bb(1),b.jc("ngIf",e.contactService.contactPutModel$.getValue().Working),b.Bb(1),b.jc("ngIf",e.contactService.contactPostModel$.getValue().Working),b.Bb(6),b.jc("ngIf",e.contactFormEdit.controls.ContactID.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.Id.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.ContactTVItemID.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.LoginEmail.errors),b.Bb(6),b.jc("ngIf",e.contactFormEdit.controls.FirstName.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.LastName.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.Initial.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.WebName.errors),b.Bb(6),b.jc("ngForOf",e.contactTitleList),b.Bb(1),b.jc("ngIf",e.contactFormEdit.controls.ContactTitle.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.IsAdmin.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.EmailValidated.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.Disabled.errors),b.Bb(6),b.jc("ngIf",e.contactFormEdit.controls.IsNew.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.SamplingPlanner_ProvincesTVItemID.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.Token.errors),b.Bb(5),b.jc("ngIf",e.contactFormEdit.controls.LastUpdateDate_UTC.errors),b.Bb(6),b.jc("ngIf",e.contactFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[g.q,g.l,g.f,h.b,c.l,C.c,C.f,y.b,g.n,g.c,g.k,g.e,x.a,c.k,S.a,C.b,D.n],pipes:[c.f],styles:[""],changeDetection:0}),t})();function ft(t,e){1&t&&b.Ob(0,"mat-progress-bar",4)}function Tt(t,e){1&t&&b.Ob(0,"mat-progress-bar",4)}function ht(t,e){if(1&t&&(b.Tb(0,"p"),b.Ob(1,"app-contact-edit",8),b.Sb()),2&t){const t=b.ec().$implicit,e=b.ec(2);b.Bb(1),b.jc("contact",t)("httpClientCommand",e.GetPutEnum())}}function St(t,e){if(1&t&&(b.Tb(0,"p"),b.Ob(1,"app-contact-edit",8),b.Sb()),2&t){const t=b.ec().$implicit,e=b.ec(2);b.Bb(1),b.jc("contact",t)("httpClientCommand",e.GetPostEnum())}}function It(t,e){if(1&t){const t=b.Ub();b.Tb(0,"div"),b.Tb(1,"p"),b.Tb(2,"button",6),b.ac("click",(function(){b.rc(t);const n=e.$implicit;return b.ec(2).DeleteContact(n)})),b.Tb(3,"span"),b.yc(4),b.Sb(),b.Tb(5,"mat-icon"),b.yc(6,"delete"),b.Sb(),b.Sb(),b.yc(7,"\xa0\xa0\xa0 "),b.Tb(8,"button",7),b.ac("click",(function(){b.rc(t);const n=e.$implicit;return b.ec(2).ShowPut(n)})),b.Tb(9,"span"),b.yc(10,"Show Put"),b.Sb(),b.Sb(),b.yc(11,"\xa0\xa0 "),b.Tb(12,"button",7),b.ac("click",(function(){b.rc(t);const n=e.$implicit;return b.ec(2).ShowPost(n)})),b.Tb(13,"span"),b.yc(14,"Show Post"),b.Sb(),b.Sb(),b.yc(15,"\xa0\xa0 "),b.xc(16,Tt,1,0,"mat-progress-bar",0),b.Sb(),b.xc(17,ht,2,2,"p",2),b.xc(18,St,2,2,"p",2),b.Tb(19,"blockquote"),b.Tb(20,"p"),b.Tb(21,"span"),b.yc(22),b.Sb(),b.Tb(23,"span"),b.yc(24),b.Sb(),b.Tb(25,"span"),b.yc(26),b.Sb(),b.Tb(27,"span"),b.yc(28),b.Sb(),b.Sb(),b.Tb(29,"p"),b.Tb(30,"span"),b.yc(31),b.Sb(),b.Tb(32,"span"),b.yc(33),b.Sb(),b.Tb(34,"span"),b.yc(35),b.Sb(),b.Tb(36,"span"),b.yc(37),b.Sb(),b.Sb(),b.Tb(38,"p"),b.Tb(39,"span"),b.yc(40),b.Sb(),b.Tb(41,"span"),b.yc(42),b.Sb(),b.Tb(43,"span"),b.yc(44),b.Sb(),b.Tb(45,"span"),b.yc(46),b.Sb(),b.Sb(),b.Tb(47,"p"),b.Tb(48,"span"),b.yc(49),b.Sb(),b.Tb(50,"span"),b.yc(51),b.Sb(),b.Tb(52,"span"),b.yc(53),b.Sb(),b.Tb(54,"span"),b.yc(55),b.Sb(),b.Sb(),b.Tb(56,"p"),b.Tb(57,"span"),b.yc(58),b.Sb(),b.Sb(),b.Sb(),b.Sb()}if(2&t){const t=e.$implicit,n=b.ec(2);b.Bb(4),b.Ac("Delete ContactID [",t.ContactID,"]\xa0\xa0\xa0"),b.Bb(4),b.jc("color",n.GetPutButtonColor(t)),b.Bb(4),b.jc("color",n.GetPostButtonColor(t)),b.Bb(4),b.jc("ngIf",n.contactService.contactDeleteModel$.getValue().Working),b.Bb(1),b.jc("ngIf",n.IDToShow===t.ContactID&&n.showType===n.GetPutEnum()),b.Bb(1),b.jc("ngIf",n.IDToShow===t.ContactID&&n.showType===n.GetPostEnum()),b.Bb(4),b.Ac("ContactID: [",t.ContactID,"]"),b.Bb(2),b.Ac(" --- Id: [",t.Id,"]"),b.Bb(2),b.Ac(" --- ContactTVItemID: [",t.ContactTVItemID,"]"),b.Bb(2),b.Ac(" --- LoginEmail: [",t.LoginEmail,"]"),b.Bb(3),b.Ac("FirstName: [",t.FirstName,"]"),b.Bb(2),b.Ac(" --- LastName: [",t.LastName,"]"),b.Bb(2),b.Ac(" --- Initial: [",t.Initial,"]"),b.Bb(2),b.Ac(" --- WebName: [",t.WebName,"]"),b.Bb(3),b.Ac("ContactTitle: [",n.GetContactTitleEnumText(t.ContactTitle),"]"),b.Bb(2),b.Ac(" --- IsAdmin: [",t.IsAdmin,"]"),b.Bb(2),b.Ac(" --- EmailValidated: [",t.EmailValidated,"]"),b.Bb(2),b.Ac(" --- Disabled: [",t.Disabled,"]"),b.Bb(3),b.Ac("IsNew: [",t.IsNew,"]"),b.Bb(2),b.Ac(" --- SamplingPlanner_ProvincesTVItemID: [",t.SamplingPlanner_ProvincesTVItemID,"]"),b.Bb(2),b.Ac(" --- Token: [",t.Token,"]"),b.Bb(2),b.Ac(" --- LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),b.Bb(3),b.Ac("LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function gt(t,e){if(1&t&&(b.Tb(0,"div"),b.xc(1,It,59,23,"div",5),b.Sb()),2&t){const t=b.ec();b.Bb(1),b.jc("ngForOf",t.contactService.contactListModel$.getValue())}}const Ct=[{path:"",component:(()=>{class t{constructor(t,e,n){this.contactService=t,this.router=e,this.httpClientService=n,this.showType=null,n.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.ContactID&&this.showType===r.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.ContactID&&this.showType===r.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.ContactID&&this.showType===r.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactID,this.showType=r.a.Put)}ShowPost(t){this.IDToShow===t.ContactID&&this.showType===r.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactID,this.showType=r.a.Post)}GetPutEnum(){return r.a.Put}GetPostEnum(){return r.a.Post}GetContactList(){this.sub=this.contactService.GetContactList().subscribe()}DeleteContact(t){this.sub=this.contactService.DeleteContact(t).subscribe()}GetContactTitleEnumText(t){return function(t){let e;return i().forEach(n=>{if(n.EnumID==t)return e=n.EnumText,!1}),e}(t)}ngOnInit(){a(this.contactService.contactTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(b.Nb(f),b.Nb(o.b),b.Nb(d.a))},t.\u0275cmp=b.Hb({type:t,selectors:[["app-contact"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"contact","httpClientCommand"]],template:function(t,e){if(1&t&&(b.xc(0,ft,1,0,"mat-progress-bar",0),b.Tb(1,"mat-card"),b.Tb(2,"mat-card-header"),b.Tb(3,"mat-card-title"),b.yc(4," Contact works! "),b.Tb(5,"button",1),b.ac("click",(function(){return e.GetContactList()})),b.Tb(6,"span"),b.yc(7,"Get Contact"),b.Sb(),b.Sb(),b.Sb(),b.Tb(8,"mat-card-subtitle"),b.yc(9),b.Sb(),b.Sb(),b.Tb(10,"mat-card-content"),b.xc(11,gt,2,1,"div",2),b.Sb(),b.Tb(12,"mat-card-actions"),b.Tb(13,"button",3),b.yc(14,"Allo"),b.Sb(),b.Sb(),b.Sb()),2&t){var n;const t=null==(n=e.contactService.contactGetModel$.getValue())?null:n.Working;var c;const o=null==(c=e.contactService.contactListModel$.getValue())?null:c.length;b.jc("ngIf",t),b.Bb(9),b.zc(e.contactService.contactTextModel$.getValue().Title),b.Bb(2),b.jc("ngIf",o)}},directives:[c.l,T.a,T.d,T.g,h.b,T.f,T.c,T.b,S.a,c.k,I.a,dt],styles:[""],changeDetection:0}),t})(),canActivate:[n("auXs").a]}];let yt=(()=>{class t{}return t.\u0275mod=b.Lb({type:t}),t.\u0275inj=b.Kb({factory:function(e){return new(e||t)},imports:[[o.e.forChild(Ct)],o.e]}),t})();var xt=n("B+Mi");let Dt=(()=>{class t{}return t.\u0275mod=b.Lb({type:t}),t.\u0275inj=b.Kb({factory:function(e){return new(e||t)},imports:[[c.c,o.e,yt,xt.a,g.g,g.o]]}),t})()}}]);