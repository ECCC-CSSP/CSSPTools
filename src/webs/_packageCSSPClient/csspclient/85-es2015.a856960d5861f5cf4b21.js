(window.webpackJsonp=window.webpackJsonp||[]).push([[85],{QRvi:function(t,e,i){"use strict";i.d(e,"a",(function(){return n}));var n=function(t){return t[t.Get=1]="Get",t[t.Put=2]="Put",t[t.Post=3]="Post",t[t.Delete=4]="Delete",t}({})},g7fM:function(t,e,i){"use strict";i.r(e),i.d(e,"TelModule",(function(){return X}));var n=i("ofXK"),o=i("tyNb");function r(t){let e={Title:"The title"};"fr-CA"===$localize.locale&&(e.Title="Le Titre"),t.next(e)}function l(){let t=[];return"fr-CA"===$localize.locale?(t.push({EnumID:1,EnumText:"Personnel"}),t.push({EnumID:2,EnumText:"Travail"}),t.push({EnumID:3,EnumText:"Cellulaire"}),t.push({EnumID:4,EnumText:"Personnel-2"}),t.push({EnumID:5,EnumText:"Travail-2"}),t.push({EnumID:6,EnumText:"Cellulaire-2"})):(t.push({EnumID:1,EnumText:"Personal"}),t.push({EnumID:2,EnumText:"Work"}),t.push({EnumID:3,EnumText:"Mobile"}),t.push({EnumID:4,EnumText:"Personal-2"}),t.push({EnumID:5,EnumText:"Work-2"}),t.push({EnumID:6,EnumText:"Mobile-2"})),t.sort((t,e)=>t.EnumText.localeCompare(e.EnumText))}var s=i("QRvi"),c=i("fXoL"),a=i("2Vo4"),b=i("LRne"),u=i("tk/3"),p=i("lJxs"),m=i("JIr8"),h=i("gkM4");let d=(()=>{class t{constructor(t,e){this.httpClient=t,this.httpClientService=e,this.telTextModel$=new a.a({}),this.telListModel$=new a.a({}),this.telGetModel$=new a.a({}),this.telPutModel$=new a.a({}),this.telPostModel$=new a.a({}),this.telDeleteModel$=new a.a({}),r(this.telTextModel$),this.telTextModel$.next({Title:"Something2 for text"})}GetTelList(){return this.httpClientService.BeforeHttpClient(this.telGetModel$),this.httpClient.get("/api/Tel").pipe(Object(p.a)(t=>{this.httpClientService.DoSuccess(this.telListModel$,this.telGetModel$,t,s.a.Get,null)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(p.a)(t=>{this.httpClientService.DoCatchError(this.telListModel$,this.telGetModel$,t)}))))}PutTel(t){return this.httpClientService.BeforeHttpClient(this.telPutModel$),this.httpClient.put("/api/Tel",t,{headers:new u.d}).pipe(Object(p.a)(e=>{this.httpClientService.DoSuccess(this.telListModel$,this.telPutModel$,e,s.a.Put,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(p.a)(t=>{this.httpClientService.DoCatchError(this.telListModel$,this.telPutModel$,t)}))))}PostTel(t){return this.httpClientService.BeforeHttpClient(this.telPostModel$),this.httpClient.post("/api/Tel",t,{headers:new u.d}).pipe(Object(p.a)(e=>{this.httpClientService.DoSuccess(this.telListModel$,this.telPostModel$,e,s.a.Post,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(p.a)(t=>{this.httpClientService.DoCatchError(this.telListModel$,this.telPostModel$,t)}))))}DeleteTel(t){return this.httpClientService.BeforeHttpClient(this.telDeleteModel$),this.httpClient.delete("/api/Tel/"+t.TelID).pipe(Object(p.a)(e=>{this.httpClientService.DoSuccess(this.telListModel$,this.telDeleteModel$,e,s.a.Delete,t)}),Object(m.a)(t=>Object(b.a)(t).pipe(Object(p.a)(t=>{this.httpClientService.DoCatchError(this.telListModel$,this.telDeleteModel$,t)}))))}}return t.\u0275fac=function(e){return new(e||t)(c.Wb(u.b),c.Wb(h.a))},t.\u0275prov=c.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})();var T=i("Wp6s"),f=i("bTqV"),S=i("bv9b"),I=i("NFeN"),D=i("3Pt+"),R=i("kmnG"),g=i("qFsG"),C=i("d3UM"),v=i("FKr1");function y(t,e){1&t&&c.Nb(0,"mat-progress-bar",11)}function B(t,e){1&t&&c.Nb(0,"mat-progress-bar",11)}function P(t,e){1&t&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function E(t,e){if(1&t&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,P,3,0,"span",4),c.Rb()),2&t){const t=e.$implicit;c.Bb(2),c.Ac(c.fc(3,2,t)),c.Bb(3),c.ic("ngIf",t.required)}}function $(t,e){1&t&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function M(t,e){if(1&t&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,$,3,0,"span",4),c.Rb()),2&t){const t=e.$implicit;c.Bb(2),c.Ac(c.fc(3,2,t)),c.Bb(3),c.ic("ngIf",t.required)}}function w(t,e){1&t&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function x(t,e){1&t&&(c.Sb(0,"span"),c.zc(1,"MaxLength - 50"),c.Nb(2,"br"),c.Rb())}function z(t,e){if(1&t&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,w,3,0,"span",4),c.yc(6,x,3,0,"span",4),c.Rb()),2&t){const t=e.$implicit;c.Bb(2),c.Ac(c.fc(3,3,t)),c.Bb(3),c.ic("ngIf",t.required),c.Bb(1),c.ic("ngIf",t.maxlength)}}function L(t,e){if(1&t&&(c.Sb(0,"mat-option",12),c.zc(1),c.Rb()),2&t){const t=e.$implicit;c.ic("value",t.EnumID),c.Bb(1),c.Bc(" ",t.EnumText," ")}}function N(t,e){1&t&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function G(t,e){if(1&t&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,N,3,0,"span",4),c.Rb()),2&t){const t=e.$implicit;c.Bb(2),c.Ac(c.fc(3,2,t)),c.Bb(3),c.ic("ngIf",t.required)}}function k(t,e){1&t&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function V(t,e){if(1&t&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,k,3,0,"span",4),c.Rb()),2&t){const t=e.$implicit;c.Bb(2),c.Ac(c.fc(3,2,t)),c.Bb(3),c.ic("ngIf",t.required)}}function U(t,e){1&t&&(c.Sb(0,"span"),c.zc(1,"Is Required"),c.Nb(2,"br"),c.Rb())}function q(t,e){if(1&t&&(c.Sb(0,"mat-error"),c.Sb(1,"span"),c.zc(2),c.ec(3,"json"),c.Nb(4,"br"),c.Rb(),c.yc(5,U,3,0,"span",4),c.Rb()),2&t){const t=e.$implicit;c.Bb(2),c.Ac(c.fc(3,2,t)),c.Bb(3),c.ic("ngIf",t.required)}}let O=(()=>{class t{constructor(t,e){this.telService=t,this.fb=e,this.tel=null,this.httpClientCommand=s.a.Put}GetPut(){return this.httpClientCommand==s.a.Put}PutTel(t){this.sub=this.telService.PutTel(t).subscribe()}PostTel(t){this.sub=this.telService.PostTel(t).subscribe()}ngOnInit(){this.telTypeList=l(),this.FillFormBuilderGroup(this.httpClientCommand)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}FillFormBuilderGroup(t){if(this.tel){let e=this.fb.group({TelID:[{value:t===s.a.Post?0:this.tel.TelID,disabled:!1},[D.p.required]],TelTVItemID:[{value:this.tel.TelTVItemID,disabled:!1},[D.p.required]],TelNumber:[{value:this.tel.TelNumber,disabled:!1},[D.p.required,D.p.maxLength(50)]],TelType:[{value:this.tel.TelType,disabled:!1},[D.p.required]],LastUpdateDate_UTC:[{value:this.tel.LastUpdateDate_UTC,disabled:!1},[D.p.required]],LastUpdateContactTVItemID:[{value:this.tel.LastUpdateContactTVItemID,disabled:!1},[D.p.required]]});this.telFormEdit=e}}}return t.\u0275fac=function(e){return new(e||t)(c.Mb(d),c.Mb(D.d))},t.\u0275cmp=c.Gb({type:t,selectors:[["app-tel-edit"]],inputs:{tel:"tel",httpClientCommand:"httpClientCommand"},decls:41,vars:11,consts:[[3,"formGroup","ngSubmit"],["mat-raised-button","","type","submit"],["mode","indeterminate",4,"ngIf"],["matInput","","type","number","formControlName","TelID"],[4,"ngIf"],["matInput","","type","number","formControlName","TelTVItemID"],["matInput","","type","text","formControlName","TelNumber"],["formControlName","TelType"],[3,"value",4,"ngFor","ngForOf"],["matInput","","type","text","formControlName","LastUpdateDate_UTC"],["matInput","","type","number","formControlName","LastUpdateContactTVItemID"],["mode","indeterminate"],[3,"value"]],template:function(t,e){1&t&&(c.Sb(0,"form",0),c.Zb("ngSubmit",(function(){return e.GetPut()?e.PutTel(e.telFormEdit.value):e.PostTel(e.telFormEdit.value)})),c.Sb(1,"h3"),c.zc(2," Tel "),c.Sb(3,"button",1),c.Sb(4,"span"),c.zc(5),c.Rb(),c.Rb(),c.yc(6,y,1,0,"mat-progress-bar",2),c.yc(7,B,1,0,"mat-progress-bar",2),c.Rb(),c.Sb(8,"p"),c.Sb(9,"mat-form-field"),c.Sb(10,"mat-label"),c.zc(11,"TelID"),c.Rb(),c.Nb(12,"input",3),c.yc(13,E,6,4,"mat-error",4),c.Rb(),c.Sb(14,"mat-form-field"),c.Sb(15,"mat-label"),c.zc(16,"TelTVItemID"),c.Rb(),c.Nb(17,"input",5),c.yc(18,M,6,4,"mat-error",4),c.Rb(),c.Sb(19,"mat-form-field"),c.Sb(20,"mat-label"),c.zc(21,"TelNumber"),c.Rb(),c.Nb(22,"input",6),c.yc(23,z,7,5,"mat-error",4),c.Rb(),c.Sb(24,"mat-form-field"),c.Sb(25,"mat-label"),c.zc(26,"TelType"),c.Rb(),c.Sb(27,"mat-select",7),c.yc(28,L,2,2,"mat-option",8),c.Rb(),c.yc(29,G,6,4,"mat-error",4),c.Rb(),c.Rb(),c.Sb(30,"p"),c.Sb(31,"mat-form-field"),c.Sb(32,"mat-label"),c.zc(33,"LastUpdateDate_UTC"),c.Rb(),c.Nb(34,"input",9),c.yc(35,V,6,4,"mat-error",4),c.Rb(),c.Sb(36,"mat-form-field"),c.Sb(37,"mat-label"),c.zc(38,"LastUpdateContactTVItemID"),c.Rb(),c.Nb(39,"input",10),c.yc(40,q,6,4,"mat-error",4),c.Rb(),c.Rb(),c.Rb()),2&t&&(c.ic("formGroup",e.telFormEdit),c.Bb(5),c.Bc("",e.GetPut()?"Put":"Post"," Tel"),c.Bb(1),c.ic("ngIf",e.telService.telPutModel$.getValue().Working),c.Bb(1),c.ic("ngIf",e.telService.telPostModel$.getValue().Working),c.Bb(6),c.ic("ngIf",e.telFormEdit.controls.TelID.errors),c.Bb(5),c.ic("ngIf",e.telFormEdit.controls.TelTVItemID.errors),c.Bb(5),c.ic("ngIf",e.telFormEdit.controls.TelNumber.errors),c.Bb(5),c.ic("ngForOf",e.telTypeList),c.Bb(1),c.ic("ngIf",e.telFormEdit.controls.TelType.errors),c.Bb(6),c.ic("ngIf",e.telFormEdit.controls.LastUpdateDate_UTC.errors),c.Bb(5),c.ic("ngIf",e.telFormEdit.controls.LastUpdateContactTVItemID.errors))},directives:[D.q,D.l,D.f,f.b,n.l,R.c,R.f,g.b,D.n,D.c,D.k,D.e,C.a,n.k,S.a,R.b,v.n],pipes:[n.f],styles:[""],changeDetection:0}),t})();function j(t,e){1&t&&c.Nb(0,"mat-progress-bar",4)}function F(t,e){1&t&&c.Nb(0,"mat-progress-bar",4)}function W(t,e){if(1&t&&(c.Sb(0,"p"),c.Nb(1,"app-tel-edit",8),c.Rb()),2&t){const t=c.dc().$implicit,e=c.dc(2);c.Bb(1),c.ic("tel",t)("httpClientCommand",e.GetPutEnum())}}function A(t,e){if(1&t&&(c.Sb(0,"p"),c.Nb(1,"app-tel-edit",8),c.Rb()),2&t){const t=c.dc().$implicit,e=c.dc(2);c.Bb(1),c.ic("tel",t)("httpClientCommand",e.GetPostEnum())}}function _(t,e){if(1&t){const t=c.Tb();c.Sb(0,"div"),c.Sb(1,"p"),c.Sb(2,"button",6),c.Zb("click",(function(){c.qc(t);const i=e.$implicit;return c.dc(2).DeleteTel(i)})),c.Sb(3,"span"),c.zc(4),c.Rb(),c.Sb(5,"mat-icon"),c.zc(6,"delete"),c.Rb(),c.Rb(),c.zc(7,"\xa0\xa0\xa0 "),c.Sb(8,"button",7),c.Zb("click",(function(){c.qc(t);const i=e.$implicit;return c.dc(2).ShowPut(i)})),c.Sb(9,"span"),c.zc(10,"Show Put"),c.Rb(),c.Rb(),c.zc(11,"\xa0\xa0 "),c.Sb(12,"button",7),c.Zb("click",(function(){c.qc(t);const i=e.$implicit;return c.dc(2).ShowPost(i)})),c.Sb(13,"span"),c.zc(14,"Show Post"),c.Rb(),c.Rb(),c.zc(15,"\xa0\xa0 "),c.yc(16,F,1,0,"mat-progress-bar",0),c.Rb(),c.yc(17,W,2,2,"p",2),c.yc(18,A,2,2,"p",2),c.Sb(19,"blockquote"),c.Sb(20,"p"),c.Sb(21,"span"),c.zc(22),c.Rb(),c.Sb(23,"span"),c.zc(24),c.Rb(),c.Sb(25,"span"),c.zc(26),c.Rb(),c.Sb(27,"span"),c.zc(28),c.Rb(),c.Rb(),c.Sb(29,"p"),c.Sb(30,"span"),c.zc(31),c.Rb(),c.Sb(32,"span"),c.zc(33),c.Rb(),c.Rb(),c.Rb(),c.Rb()}if(2&t){const t=e.$implicit,i=c.dc(2);c.Bb(4),c.Bc("Delete TelID [",t.TelID,"]\xa0\xa0\xa0"),c.Bb(4),c.ic("color",i.GetPutButtonColor(t)),c.Bb(4),c.ic("color",i.GetPostButtonColor(t)),c.Bb(4),c.ic("ngIf",i.telService.telDeleteModel$.getValue().Working),c.Bb(1),c.ic("ngIf",i.IDToShow===t.TelID&&i.showType===i.GetPutEnum()),c.Bb(1),c.ic("ngIf",i.IDToShow===t.TelID&&i.showType===i.GetPostEnum()),c.Bb(4),c.Bc("TelID: [",t.TelID,"]"),c.Bb(2),c.Bc(" --- TelTVItemID: [",t.TelTVItemID,"]"),c.Bb(2),c.Bc(" --- TelNumber: [",t.TelNumber,"]"),c.Bb(2),c.Bc(" --- TelType: [",i.GetTelTypeEnumText(t.TelType),"]"),c.Bb(3),c.Bc("LastUpdateDate_UTC: [",t.LastUpdateDate_UTC,"]"),c.Bb(2),c.Bc(" --- LastUpdateContactTVItemID: [",t.LastUpdateContactTVItemID,"]")}}function J(t,e){if(1&t&&(c.Sb(0,"div"),c.yc(1,_,34,12,"div",5),c.Rb()),2&t){const t=c.dc();c.Bb(1),c.ic("ngForOf",t.telService.telListModel$.getValue())}}const H=[{path:"",component:(()=>{class t{constructor(t,e,i){this.telService=t,this.router=e,this.httpClientService=i,this.showType=null,i.oldURL=e.url}GetPutButtonColor(t){return this.IDToShow===t.TelID&&this.showType===s.a.Put?"primary":"basic"}GetPostButtonColor(t){return this.IDToShow===t.TelID&&this.showType===s.a.Post?"primary":"basic"}ShowPut(t){this.IDToShow===t.TelID&&this.showType===s.a.Put?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TelID,this.showType=s.a.Put)}ShowPost(t){this.IDToShow===t.TelID&&this.showType===s.a.Post?(this.IDToShow=0,this.showType=null):(this.IDToShow=t.TelID,this.showType=s.a.Post)}GetPutEnum(){return s.a.Put}GetPostEnum(){return s.a.Post}GetTelList(){this.sub=this.telService.GetTelList().subscribe()}DeleteTel(t){this.sub=this.telService.DeleteTel(t).subscribe()}GetTelTypeEnumText(t){return function(t){let e;return l().forEach(i=>{if(i.EnumID==t)return e=i.EnumText,!1}),e}(t)}ngOnInit(){r(this.telService.telTextModel$)}ngOnDestroy(){var t;null===(t=this.sub)||void 0===t||t.unsubscribe()}}return t.\u0275fac=function(e){return new(e||t)(c.Mb(d),c.Mb(o.b),c.Mb(h.a))},t.\u0275cmp=c.Gb({type:t,selectors:[["app-tel"]],decls:15,vars:3,consts:[["mode","indeterminate",4,"ngIf"],["mat-button","","color","primary",3,"click"],[4,"ngIf"],["mat-button",""],["mode","indeterminate"],[4,"ngFor","ngForOf"],["mat-raised-button","",3,"click"],["mat-raised-button","",3,"color","click"],[3,"tel","httpClientCommand"]],template:function(t,e){if(1&t&&(c.yc(0,j,1,0,"mat-progress-bar",0),c.Sb(1,"mat-card"),c.Sb(2,"mat-card-header"),c.Sb(3,"mat-card-title"),c.zc(4," Tel works! "),c.Sb(5,"button",1),c.Zb("click",(function(){return e.GetTelList()})),c.Sb(6,"span"),c.zc(7,"Get Tel"),c.Rb(),c.Rb(),c.Rb(),c.Sb(8,"mat-card-subtitle"),c.zc(9),c.Rb(),c.Rb(),c.Sb(10,"mat-card-content"),c.yc(11,J,2,1,"div",2),c.Rb(),c.Sb(12,"mat-card-actions"),c.Sb(13,"button",3),c.zc(14,"Allo"),c.Rb(),c.Rb(),c.Rb()),2&t){var i;const t=null==(i=e.telService.telGetModel$.getValue())?null:i.Working;var n;const o=null==(n=e.telService.telListModel$.getValue())?null:n.length;c.ic("ngIf",t),c.Bb(9),c.Ac(e.telService.telTextModel$.getValue().Title),c.Bb(2),c.ic("ngIf",o)}},directives:[n.l,T.a,T.d,T.g,f.b,T.f,T.c,T.b,S.a,n.k,I.a,O],styles:[""],changeDetection:0}),t})(),canActivate:[i("auXs").a]}];let Z=(()=>{class t{}return t.\u0275mod=c.Kb({type:t}),t.\u0275inj=c.Jb({factory:function(e){return new(e||t)},imports:[[o.e.forChild(H)],o.e]}),t})();var K=i("B+Mi");let X=(()=>{class t{}return t.\u0275mod=c.Kb({type:t}),t.\u0275inj=c.Jb({factory:function(e){return new(e||t)},imports:[[n.c,o.e,Z,K.a,D.g,D.o]]}),t})()},gkM4:function(t,e,i){"use strict";i.d(e,"a",(function(){return l}));var n=i("QRvi"),o=i("fXoL"),r=i("tyNb");let l=(()=>{class t{constructor(t){this.router=t,this.oldURL=t.url}BeforeHttpClient(t){t.next({Working:!0,Error:null,Status:null})}DoCatchError(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoCatchErrorSingle(t,e,i){t.next(null),e.next({Working:!1,Error:i,Status:"Error"}),this.DoReload()}DoReload(){this.router.navigateByUrl("",{skipLocationChange:!0}).then(()=>{this.router.navigate(["/"+this.oldURL])})}DoSuccess(t,e,i,o,r){if(o===n.a.Get&&t.next(i),o===n.a.Put&&(t.getValue()[0]=i),o===n.a.Post&&t.getValue().push(i),o===n.a.Delete){const e=t.getValue().indexOf(r);t.getValue().splice(e,1)}t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}DoSuccessSingle(t,e,i,o,r){o===n.a.Get&&t.next(i),t.next(t.getValue()),e.next({Working:!1,Error:null,Status:"ok"}),this.DoReload()}}return t.\u0275fac=function(e){return new(e||t)(o.Wb(r.b))},t.\u0275prov=o.Ib({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);