!function(){function t(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function e(t,e){for(var n=0;n<e.length;n++){var c=e[n];c.enumerable=c.enumerable||!1,c.configurable=!0,"value"in c&&(c.writable=!0),Object.defineProperty(t,c.key,c)}}function n(t,n,c){return n&&e(t.prototype,n),c&&e(t,c),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[42],{QRvi:function(t,e,n){"use strict";n.d(e,"a",(function(){return c}));var c=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},gkM4:function(e,c,a){"use strict";a.d(c,"a",(function(){return b}));var o=a("QRvi"),i=a("fXoL"),r=a("tyNb"),b=function(){var e=function(){function e(n){t(this,e),this.router=n,this.oldURL=n.url}return n(e,[{key:"BeforeHttpClient",value:function(t){t.next({Working:!0,Error:null,Status:null})}},{key:"DoCatchError",value:function(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}},{key:"DoCatchErrorSingle",value:function(t,e,n){t.next(null),e.next({Working:!1,Error:n,Status:"Error"}),this.DoReload()}},{key:"DoReload",value:function(){var t=this;this.router.navigateByUrl("",{skipLocationChange:!0}).then((function(){t.router.navigate(["/"+t.oldURL])}))}},{key:"DoSuccess",value:function(t,e,n,c,a){if(c===o.a.Get&&t.next(n),c===o.a.Put&&(t.getValue()[0]=n),c===o.a.Post&&t.getValue().push(n),c===o.a.Delete){var i=t.getValue().indexOf(a);t.getValue().splice(i,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}},{key:"DoSuccessSingle",value:function(t,e,n,c,a){c===o.a.Get&&t.next(n),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}]),e}();return e.\u0275fac=function(t){return new(t||e)(i.Wb(r.b))},e.\u0275prov=i.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e}()},wtgo:function(e,c,a){"use strict";a.r(c),a.d(c,"ContactModule",(function(){return Lt}));var o=a("ofXK"),i=a("tyNb");function r(t){var e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}function b(){var t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"Director General (fr)"}),t.push({EnumID:2,EnumText:"Director Public Works (fr)"}),t.push({EnumID:3,EnumText:"Superintendent (fr)"}),t.push({EnumID:4,EnumText:"Engineer (fr)"}),t.push({EnumID:5,EnumText:"Foreman (fr)"}),t.push({EnumID:6,EnumText:"Operator (fr)"}),t.push({EnumID:7,EnumText:"Facilities Manager (fr)"}),t.push({EnumID:8,EnumText:"Supervisor (fr)"}),t.push({EnumID:9,EnumText:"Technician (fr)"})):(t.push({EnumID:1,EnumText:"Director General"}),t.push({EnumID:2,EnumText:"Director Public Works"}),t.push({EnumID:3,EnumText:"Superintendent"}),t.push({EnumID:4,EnumText:"Engineer"}),t.push({EnumID:5,EnumText:"Foreman"}),t.push({EnumID:6,EnumText:"Operator"}),t.push({EnumID:7,EnumText:"Facilities Manager"}),t.push({EnumID:8,EnumText:"Supervisor"}),t.push({EnumID:9,EnumText:"Technician"})),t.sort((function(t,e){return t.EnumText.localeCompare(e.EnumText)}))}var s,u=a("QRvi"),l=a("fXoL"),m=a("2Vo4"),p=a("LRne"),f=a("tk/3"),d=a("lJxs"),h=a("JIr8"),S=a("gkM4"),I=((s=function(){function e(n,c){t(this,e),this.httpClient=n,this.httpClientService=c,this.contactTextModel$=new m.a({}),this.contactListModel$=new m.a({}),this.contactGetModel$=new m.a({}),this.contactPutModel$=new m.a({}),this.contactPostModel$=new m.a({}),this.contactDeleteModel$=new m.a({}),r(this.contactTextModel$),this.contactTextModel$.next({Title:"Something2 for text"})}return n(e,[{key:"GetContactList",value:function(){var t=this;return this.httpClientService.BeforeHttpClient(this.contactGetModel$),this.httpClient.get("/api/Contact").pipe(Object(d.a)((function(e){t.httpClientService.DoSuccess(t.contactListModel$,t.contactGetModel$,e,u.a.Get,null)})),Object(h.a)((function(e){return Object(p.a)(e).pipe(Object(d.a)((function(e){t.httpClientService.DoCatchError(t.contactListModel$,t.contactGetModel$,e)})))})))}},{key:"PutContact",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.contactPutModel$),this.httpClient.put("/api/Contact",t,{headers:new f.d}).pipe(Object(d.a)((function(n){e.httpClientService.DoSuccess(e.contactListModel$,e.contactPutModel$,n,u.a.Put,t)})),Object(h.a)((function(t){return Object(p.a)(t).pipe(Object(d.a)((function(t){e.httpClientService.DoCatchError(e.contactListModel$,e.contactPutModel$,t)})))})))}},{key:"PostContact",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.contactPostModel$),this.httpClient.post("/api/Contact",t,{headers:new f.d}).pipe(Object(d.a)((function(n){e.httpClientService.DoSuccess(e.contactListModel$,e.contactPostModel$,n,u.a.Post,t)})),Object(h.a)((function(t){return Object(p.a)(t).pipe(Object(d.a)((function(t){e.httpClientService.DoCatchError(e.contactListModel$,e.contactPostModel$,t)})))})))}},{key:"DeleteContact",value:function(t){var e=this;return this.httpClientService.BeforeHttpClient(this.contactDeleteModel$),this.httpClient.delete("/api/Contact/"+t.ContactID).pipe(Object(d.a)((function(n){e.httpClientService.DoSuccess(e.contactListModel$,e.contactDeleteModel$,n,u.a.Delete,t)})),Object(h.a)((function(t){return Object(p.a)(t).pipe(Object(d.a)((function(t){e.httpClientService.DoCatchError(e.contactListModel$,e.contactDeleteModel$,t)})))})))}}]),e}()).\u0275fac=function(t){return new(t||s)(l.Wb(f.b),l.Wb(S.a))},s.\u0275prov=l.Ib({token:s,factory:s.\u0275fac,providedIn:"root"}),s),R=a("Wp6s"),y=a("bTqV"),v=a("bv9b"),g=a("NFeN"),C=a("3Pt+"),x=a("kmnG"),D=a("qFsG"),N=a("d3UM"),T=a("FKr1");function B(t,e){1&t&&l.Nb(0,"mat-progress-bar",22)}function E(t,e){1&t&&l.Nb(0,"mat-progress-bar",22)}function P(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function L(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,P,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.required)}}function k(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function $(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 450"),l.Nb(2,"br"),l.Rb())}function w(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,k,3,0,"span",4),l.xc(6,$,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,3,n)),l.Bb(3),l.hc("ngIf",n.required),l.Bb(1),l.hc("ngIf",n.maxlength)}}function M(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function F(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,M,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.required)}}function q(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function V(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Need valid Email"),l.Nb(2,"br"),l.Rb())}function G(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"MinLength - 6"),l.Nb(2,"br"),l.Rb())}function j(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 255"),l.Nb(2,"br"),l.Rb())}function A(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,q,3,0,"span",4),l.xc(6,V,3,0,"span",4),l.xc(7,G,3,0,"span",4),l.xc(8,j,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,5,n)),l.Bb(3),l.hc("ngIf",n.required),l.Bb(1),l.hc("ngIf",n.email),l.Bb(1),l.hc("ngIf",n.minlength),l.Bb(1),l.hc("ngIf",n.maxlength)}}function O(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function U(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 100"),l.Nb(2,"br"),l.Rb())}function W(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,O,3,0,"span",4),l.xc(6,U,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,3,n)),l.Bb(3),l.hc("ngIf",n.required),l.Bb(1),l.hc("ngIf",n.maxlength)}}function z(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function _(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 100"),l.Nb(2,"br"),l.Rb())}function J(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,z,3,0,"span",4),l.xc(6,_,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,3,n)),l.Bb(3),l.hc("ngIf",n.required),l.Bb(1),l.hc("ngIf",n.maxlength)}}function H(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 50"),l.Nb(2,"br"),l.Rb())}function Y(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,H,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.maxlength)}}function K(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function X(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 100"),l.Nb(2,"br"),l.Rb())}function Q(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,K,3,0,"span",4),l.xc(6,X,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,3,n)),l.Bb(3),l.hc("ngIf",n.required),l.Bb(1),l.hc("ngIf",n.maxlength)}}function Z(t,e){if(1&t&&(l.Sb(0,"mat-option",23),l.yc(1),l.Rb()),2&t){var n=e.$implicit;l.hc("value",n.EnumID),l.Bb(1),l.Ac(" ",n.EnumText," ")}}function tt(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,1,n))}}function et(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function nt(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,et,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.required)}}function ct(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function at(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,ct,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.required)}}function ot(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function it(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,ot,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.required)}}function rt(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function bt(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,rt,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.required)}}function st(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 200"),l.Nb(2,"br"),l.Rb())}function ut(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,st,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.maxlength)}}function lt(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"MaxLength - 255"),l.Nb(2,"br"),l.Rb())}function mt(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,lt,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.maxlength)}}function pt(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function ft(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,pt,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.required)}}function dt(t,e){1&t&&(l.Sb(0,"span"),l.yc(1,"Is Required"),l.Nb(2,"br"),l.Rb())}function ht(t,e){if(1&t&&(l.Sb(0,"mat-error"),l.Sb(1,"span"),l.yc(2),l.dc(3,"json"),l.Nb(4,"br"),l.Rb(),l.xc(5,dt,3,0,"span",4),l.Rb()),2&t){var n=e.$implicit;l.Bb(2),l.zc(l.ec(3,2,n)),l.Bb(3),l.hc("ngIf",n.required)}}var St,It=((St=function(){function e(n,c){t(this,e),this.contactService=n,this.fb=c,this.contact=null,this.httpClientCommand=u.a.Put}return n(e,[{key:"GetPut",value:function(){return this.httpClientCommand==u.a.Put}},{key:"PutContact",value:function(t){this.sub=this.contactService.PutContact(t).subscribe()}},{key:"PostContact",value:function(t){this.sub=this.contactService.PostContact(t).subscribe()}},{key:"ngOnInit",value:function(){this.contactTitleList=b(),this.FillFormBuilderGroup(this.httpClientCommand)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}},{key:"FillFormBuilderGroup",value:function(t){if(this.contact){var e=this.fb.group({ContactID:[{value:t===u.a.Post?0:this.contact.ContactID,disabled:!1},[C.p.required]],Id:[{value:this.contact.Id,disabled:!1},[C.p.required,C.p.maxLength(450)]],ContactTVItemID:[{value:this.contact.ContactTVItemID,disabled:!1},[C.p.required]],LoginEmail:[{value:this.contact.LoginEmail,disabled:!1},[C.p.required,C.p.email,C.p.minLength(6),C.p.maxLength(255)]],FirstName:[{value:this.contact.FirstName,disabled:!1},[C.p.required,C.p.maxLength(100)]],LastName:[{value:this.contact.LastName,disabled:!1},[C.p.required,C.p.maxLength(100)]],Initial:[{value:this.contact.Initial,disabled:!1},[C.p.maxLength(50)]],WebName:[{value:this.contact.WebName,disabled:!1},[C.p.required,C.p.maxLength(100)]],ContactTitle:[{value:this.contact.ContactTitle,disabled:!1}],IsAdmin:[{value:this.contact.IsAdmin,disabled:!1},[C.p.required]],EmailValidated:[{value:this.contact.EmailValidated,disabled:!1},[C.p.required]],Disabled:[{value:this.contact.Disabled,disabled:!1},[C.p.required]],IsNew:[{value:this.contact.IsNew,disabled:!1},[C.p.required]],SamplingPlanner_ProvincesTVItemID:[{value:this.contact.SamplingPlanner_ProvincesTVItemID,disabled:!1},[C.p.maxLength(200)]],Token:[{value:this.contact.Token,disabled:!1},[C.p.maxLength(255)]],LastUpdateDate_UTC:[{value:this.contact.LastUpdateDate_UTC,disabled:!1},[C.p.required]],LastUpdateContactTVItemID:[{value:this.contact.LastUpdateContactTVItemID,disabled:!1},[C.p.required]]});this.contactFormEdit=e}}}]),e}()).\u0275fac=function(t){return new(t||St)(l.Mb(I),l.Mb(C.d))},St.\u0275cmp=l.Gb({type:St,selectors:[["app-contact-edit"]],inputs:{contact:"contact",httpClientCommand:"httpClientCommand"},decls:99,vars:22,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","ContactID"],[4,"ngIf"],["matInput","","type","text","formControlName","Id"],["matInput","","type","number","formControlName","ContactTVItemID"],["matInput","","type","text","formControlName","LoginEmail"],["matInput","","type","text","formControlName","FirstName"],["matInput","","type","text","formControlName","LastName"],["matInput","","type","text","formControlName","Initial"],["matInput","","type","text","formControlName","WebName"],["formControlName","ContactTitle"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","IsAdmin"],["matInput","","type","text","formControlName","EmailValidated"],["matInput","","type","text","formControlName","Disabled"],["matInput","","type","text","formControlName","IsNew"],["matInput","","type","text","formControlName","SamplingPlanner_ProvincesTVItemID"],["matInput","","type","text","formControlName","Token"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(l.Sb(0,"form",0),l.Yb("ngSubmit",(function(){return e.GetPut()?e.PutContact(e.contactFormEdit.value):e.PostContact(e.contactFormEdit.value)})),l.Sb(1,"h3"),l.yc(2," Contact "),l.Sb(3,"button",1),l.Sb(4,"span"),l.yc(5),l.Rb(),l.Rb(),l.xc(6,B,1,0,"mat-progress-bar",2),l.xc(7,E,1,0,"mat-progress-bar",2),l.Rb(),l.Sb(8,"p"),l.Sb(9,"mat-form-field"),l.Sb(10,"mat-label"),l.yc(11,"ContactID"),l.Rb(),l.Nb(12,"input",3),l.xc(13,L,6,4,"mat-error",4),l.Rb(),l.Sb(14,"mat-form-field"),l.Sb(15,"mat-label"),l.yc(16,"Id"),l.Rb(),l.Nb(17,"input",5),l.xc(18,w,7,5,"mat-error",4),l.Rb(),l.Sb(19,"mat-form-field"),l.Sb(20,"mat-label"),l.yc(21,"ContactTVItemID"),l.Rb(),l.Nb(22,"input",6),l.xc(23,F,6,4,"mat-error",4),l.Rb(),l.Sb(24,"mat-form-field"),l.Sb(25,"mat-label"),l.yc(26,"LoginEmail"),l.Rb(),l.Nb(27,"input",7),l.xc(28,A,9,7,"mat-error",4),l.Rb(),l.Rb(),l.Sb(29,"p"),l.Sb(30,"mat-form-field"),l.Sb(31,"mat-label"),l.yc(32,"FirstName"),l.Rb(),l.Nb(33,"input",8),l.xc(34,W,7,5,"mat-error",4),l.Rb(),l.Sb(35,"mat-form-field"),l.Sb(36,"mat-label"),l.yc(37,"LastName"),l.Rb(),l.Nb(38,"input",9),l.xc(39,J,7,5,"mat-error",4),l.Rb(),l.Sb(40,"mat-form-field"),l.Sb(41,"mat-label"),l.yc(42,"Initial"),l.Rb(),l.Nb(43,"input",10),l.xc(44,Y,6,4,"mat-error",4),l.Rb(),l.Sb(45,"mat-form-field"),l.Sb(46,"mat-label"),l.yc(47,"WebName"),l.Rb(),l.Nb(48,"input",11),l.xc(49,Q,7,5,"mat-error",4),l.Rb(),l.Rb(),l.Sb(50,"p"),l.Sb(51,"mat-form-field"),l.Sb(52,"mat-label"),l.yc(53,"ContactTitle"),l.Rb(),l.Sb(54,"mat-select",12),l.xc(55,Z,2,2,"mat-option",13),l.Rb(),l.xc(56,tt,5,3,"mat-error",4),l.Rb(),l.Sb(57,"mat-form-field"),l.Sb(58,"mat-label"),l.yc(59,"IsAdmin"),l.Rb(),l.Nb(60,"input",14),l.xc(61,nt,6,4,"mat-error",4),l.Rb(),l.Sb(62,"mat-form-field"),l.Sb(63,"mat-label"),l.yc(64,"EmailValidated"),l.Rb(),l.Nb(65,"input",15),l.xc(66,at,6,4,"mat-error",4),l.Rb(),l.Sb(67,"mat-form-field"),l.Sb(68,"mat-label"),l.yc(69,"Disabled"),l.Rb(),l.Nb(70,"input",16),l.xc(71,it,6,4,"mat-error",4),l.Rb(),l.Rb(),l.Sb(72,"p"),l.Sb(73,"mat-form-field"),l.Sb(74,"mat-label"),l.yc(75,"IsNew"),l.Rb(),l.Nb(76,"input",17),l.xc(77,bt,6,4,"mat-error",4),l.Rb(),l.Sb(78,"mat-form-field"),l.Sb(79,"mat-label"),l.yc(80,"SamplingPlanner_ProvincesTVItemID"),l.Rb(),l.Nb(81,"input",18),l.xc(82,ut,6,4,"mat-error",4),l.Rb(),l.Sb(83,"mat-form-field"),l.Sb(84,"mat-label"),l.yc(85,"Token"),l.Rb(),l.Nb(86,"input",19),l.xc(87,mt,6,4,"mat-error",4),l.Rb(),l.Sb(88,"mat-form-field"),l.Sb(89,"mat-label"),l.yc(90,"LastUpdateDate_UTC"),l.Rb(),l.Nb(91,"input",20),l.xc(92,ft,6,4,"mat-error",4),l.Rb(),l.Rb(),l.Sb(93,"p"),l.Sb(94,"mat-form-field"),l.Sb(95,"mat-label"),l.yc(96,"LastUpdateContactTVItemID"),l.Rb(),l.Nb(97,"input",21),l.xc(98,ht,6,4,"mat-error",4),l.Rb(),l.Rb(),l.Rb()),2&t&&(l.hc("formGroup",e.contactFormEdit),l.Bb(5),l.Ac("",e.GetPut()?"Put":"Post"," Contact"),l.Bb(1),l.hc("ngIf",e.contactService.contactPutModel$.getValue().Working),l.Bb(1),l.hc("ngIf",e.contactService.contactPostModel$.getValue().Working),l.Bb(6),l.hc("ngIf",e.contactFormEdit.controls.ContactID.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.Id.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.ContactTVItemID.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.LoginEmail.errors),l.Bb(6),l.hc("ngIf",e.contactFormEdit.controls.FirstName.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.LastName.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.Initial.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.WebName.errors),l.Bb(6),l.hc("ngForOf",e.contactTitleList),l.Bb(1),l.hc("ngIf",e.contactFormEdit.controls.ContactTitle.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.IsAdmin.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.EmailValidated.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.Disabled.errors),l.Bb(6),l.hc("ngIf",e.contactFormEdit.controls.IsNew.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.SamplingPlanner_ProvincesTVItemID.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.Token.errors),l.Bb(5),l.hc("ngIf",e.contactFormEdit.controls.LastUpdateDate_UTC.errors),l.Bb(6),l.hc("ngIf",e.contactFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[C.q,C.l,C.f,y.b,o.l,x.c,x.f,D.b,C.n,C.c,C.k,C.e,N.a,o.k,v.a,x.b,T.n],pipes:[o.f],styles:[""],changeDetection:0}),St);function Rt(t,e){1&t&&l.Nb(0,"mat-progress-bar",4)}function yt(t,e){1&t&&l.Nb(0,"mat-progress-bar",4)}function vt(t,e){if(1&t&&(l.Sb(0,"p"),l.Nb(1,"app-contact-edit",8),l.Rb()),2&t){var n=l.cc().$implicit,c=l.cc(2);l.Bb(1),l.hc("contact",n)("httpClientCommand",c.GetPutEnum())}}function gt(t,e){if(1&t&&(l.Sb(0,"p"),l.Nb(1,"app-contact-edit",8),l.Rb()),2&t){var n=l.cc().$implicit,c=l.cc(2);l.Bb(1),l.hc("contact",n)("httpClientCommand",c.GetPostEnum())}}function Ct(t,e){if(1&t){var n=l.Tb();l.Sb(0,"div"),l.Sb(1,"p"),l.Sb(2,"button",6),l.Yb("click",(function(){l.pc(n);var t=e.$implicit;return l.cc(2).DeleteContact(t)})),l.Sb(3,"span"),l.yc(4),l.Rb(),l.Sb(5,"mat-icon"),l.yc(6,"delete"),l.Rb(),l.Rb(),l.yc(7,"\xa0\xa0\xa0 "),l.Sb(8,"button",7),l.Yb("click",(function(){l.pc(n);var t=e.$implicit;return l.cc(2).ShowPut(t)})),l.Sb(9,"span"),l.yc(10,"Show Put"),l.Rb(),l.Rb(),l.yc(11,"\xa0\xa0 "),l.Sb(12,"button",7),l.Yb("click",(function(){l.pc(n);var t=e.$implicit;return l.cc(2).ShowPost(t)})),l.Sb(13,"span"),l.yc(14,"Show Post"),l.Rb(),l.Rb(),l.yc(15,"\xa0\xa0 "),l.xc(16,yt,1,0,"mat-progress-bar",0),l.Rb(),l.xc(17,vt,2,2,"p",2),l.xc(18,gt,2,2,"p",2),l.Sb(19,"blockquote"),l.Sb(20,"p"),l.Sb(21,"span"),l.yc(22),l.Rb(),l.Sb(23,"span"),l.yc(24),l.Rb(),l.Sb(25,"span"),l.yc(26),l.Rb(),l.Sb(27,"span"),l.yc(28),l.Rb(),l.Rb(),l.Sb(29,"p"),l.Sb(30,"span"),l.yc(31),l.Rb(),l.Sb(32,"span"),l.yc(33),l.Rb(),l.Sb(34,"span"),l.yc(35),l.Rb(),l.Sb(36,"span"),l.yc(37),l.Rb(),l.Rb(),l.Sb(38,"p"),l.Sb(39,"span"),l.yc(40),l.Rb(),l.Sb(41,"span"),l.yc(42),l.Rb(),l.Sb(43,"span"),l.yc(44),l.Rb(),l.Sb(45,"span"),l.yc(46),l.Rb(),l.Rb(),l.Sb(47,"p"),l.Sb(48,"span"),l.yc(49),l.Rb(),l.Sb(50,"span"),l.yc(51),l.Rb(),l.Sb(52,"span"),l.yc(53),l.Rb(),l.Sb(54,"span"),l.yc(55),l.Rb(),l.Rb(),l.Sb(56,"p"),l.Sb(57,"span"),l.yc(58),l.Rb(),l.Rb(),l.Rb(),l.Rb()}if(2&t){var c=e.$implicit,a=l.cc(2);l.Bb(4),l.Ac("Delete ContactID [",c.ContactID,"]\xa0\xa0\xa0"),l.Bb(4),l.hc("color",a.GetPutButtonColor(c)),l.Bb(4),l.hc("color",a.GetPostButtonColor(c)),l.Bb(4),l.hc("ngIf",a.contactService.contactDeleteModel$.getValue().Working),l.Bb(1),l.hc("ngIf",a.IDToShow===c.ContactID&&a.showType===a.GetPutEnum()),l.Bb(1),l.hc("ngIf",a.IDToShow===c.ContactID&&a.showType===a.GetPostEnum()),l.Bb(4),l.Ac("ContactID: [",c.ContactID,"]"),l.Bb(2),l.Ac(" --- Id: [",c.Id,"]"),l.Bb(2),l.Ac(" --- ContactTVItemID: [",c.ContactTVItemID,"]"),l.Bb(2),l.Ac(" --- LoginEmail: [",c.LoginEmail,"]"),l.Bb(3),l.Ac("FirstName: [",c.FirstName,"]"),l.Bb(2),l.Ac(" --- LastName: [",c.LastName,"]"),l.Bb(2),l.Ac(" --- Initial: [",c.Initial,"]"),l.Bb(2),l.Ac(" --- WebName: [",c.WebName,"]"),l.Bb(3),l.Ac("ContactTitle: [",a.GetContactTitleEnumText(c.ContactTitle),"]"),l.Bb(2),l.Ac(" --- IsAdmin: [",c.IsAdmin,"]"),l.Bb(2),l.Ac(" --- EmailValidated: [",c.EmailValidated,"]"),l.Bb(2),l.Ac(" --- Disabled: [",c.Disabled,"]"),l.Bb(3),l.Ac("IsNew: [",c.IsNew,"]"),l.Bb(2),l.Ac(" --- SamplingPlanner_ProvincesTVItemID: [",c.SamplingPlanner_ProvincesTVItemID,"]"),l.Bb(2),l.Ac(" --- Token: [",c.Token,"]"),l.Bb(2),l.Ac(" --- LastUpdateDate_UTC: [",c.LastUpdateDate_UTC,"]"),l.Bb(3),l.Ac("LastUpdateContactTVItemID: [",c.LastUpdateContactTVItemID,"]")}}function xt(t,e){if(1&t&&(l.Sb(0,"div"),l.xc(1,Ct,59,23,"div",5),l.Rb()),2&t){var n=l.cc();l.Bb(1),l.hc("ngForOf",n.contactService.contactListModel$.getValue())}}var Dt,Nt,Tt,Bt=[{path:"",component:(Dt=function(){function e(n,c,a){t(this,e),this.contactService=n,this.router=c,this.httpClientService=a,this.showType=null,a.oldURL=c.url}return n(e,[{key:"GetPutButtonColor",value:function(t){return this.IDToShow===t.ContactID&&this.showType===u.a.Put?"primary":"basic"}},{key:"GetPostButtonColor",value:function(t){return this.IDToShow===t.ContactID&&this.showType===u.a.Post?"primary":"basic"}},{key:"ShowPut",value:function(t){this.IDToShow===t.ContactID&&this.showType===u.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactID,this.showType=u.a.Put)}},{key:"ShowPost",value:function(t){this.IDToShow===t.ContactID&&this.showType===u.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.ContactID,this.showType=u.a.Post)}},{key:"GetPutEnum",value:function(){return u.a.Put}},{key:"GetPostEnum",value:function(){return u.a.Post}},{key:"GetContactList",value:function(){this.sub=this.contactService.GetContactList().subscribe()}},{key:"DeleteContact",value:function(t){this.sub=this.contactService.DeleteContact(t).subscribe()}},{key:"GetContactTitleEnumText",value:function(t){return function(t){var e;return b().forEach((function(n){if(n.EnumID==t)return e=n.EnumText,!1})),e}(t)}},{key:"ngOnInit",value:function(){r(this.contactService.contactTextModel$)}},{key:"ngOnDestroy",value:function(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}]),e}(),Dt.\u0275fac=function(t){return new(t||Dt)(l.Mb(I),l.Mb(i.b),l.Mb(S.a))},Dt.\u0275cmp=l.Gb({type:Dt,selectors:[["app-contact"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"contact","httpClientCommand"]],template:function(t,e){var n,c;1&t&&(l.xc(0,Rt,1,0,"mat-progress-bar",0),l.Sb(1,"mat-card"),l.Sb(2,"mat-card-header"),l.Sb(3,"mat-card-title"),l.yc(4," Contact works! "),l.Sb(5,"button",1),l.Yb("click",(function(){return e.GetContactList()})),l.Sb(6,"span"),l.yc(7,"Get Contact"),l.Rb(),l.Rb(),l.Rb(),l.Sb(8,"mat-card-subtitle"),l.yc(9),l.Rb(),l.Rb(),l.Sb(10,"mat-card-content"),l.xc(11,xt,2,1,"div",2),l.Rb(),l.Sb(12,"mat-card-actions"),l.Sb(13,"button",3),l.yc(14,"Allo"),l.Rb(),l.Rb(),l.Rb()),2&t&&(l.hc("ngIf",null==(n=e.contactService.contactGetModel$.getValue())?null:n.Working),l.Bb(9),l.zc(e.contactService.contactTextModel$.getValue().Title),l.Bb(2),l.hc("ngIf",null==(c=e.contactService.contactListModel$.getValue())?null:c.length))},directives:[o.l,R.a,R.d,R.g,y.b,R.f,R.c,R.b,v.a,o.k,g.a,It],styles:[""],changeDetection:0}),Dt),canActivate:[a("auXs").a]}],Et=((Nt=function e(){t(this,e)}).\u0275mod=l.Kb({type:Nt}),Nt.\u0275inj=l.Jb({factory:function(t){return new(t||Nt)},imports:[[i.e.forChild(Bt)],i.e]}),Nt),Pt=a("B+Mi"),Lt=((Tt=function e(){t(this,e)}).\u0275mod=l.Kb({type:Tt}),Tt.\u0275inj=l.Jb({factory:function(t){return new(t||Tt)},imports:[[o.c,i.e,Et,Pt.a,C.g,C.o]]}),Tt)}}])}();