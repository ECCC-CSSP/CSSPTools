(window.webpackJsonp=window.webpackJsonp||[]).push([[8],{XB0k:function(e,o,n){"use strict";n.r(o),n.d(o,"NoPageFoundModule",(function(){return l}));var t=n("ofXK"),a=n("tyNb"),r=n("B+Mi"),c=n("fXoL"),s=n("2Vo4");let i=(()=>{class e{constructor(){this.noPageFoundModel$=new s.a({}),this.Init()}Init(){this.UpdateNoPageFound({})}UpdateNoPageFound(e){let o=Object.assign(Object.assign({},this.noPageFoundModel$.getValue()),e);this.noPageFoundModel$=new s.a(o)}}return e.\u0275fac=function(o){return new(o||e)},e.\u0275prov=c.Ib({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var u=n("bTqV");const d=[{path:"",component:(()=>{class e{constructor(e,o,n){this.noPageFoundService=e,this.location=o,this.router=n,this.noPageFoundModel={}}ngOnInit(){!function(e){let o={SorryPageNotFound:"Sorry Page Not Found",Restart:"Restart",GoBack:"Go Back"};"fr-CA"===$localize.locale&&(o.SorryPageNotFound="Nos excuses. La page est introuvable",o.Restart="Recommencer",o.GoBack="Reculer d'une page"),e.UpdateNoPageFound(o)}(this.noPageFoundService),this.sub=this.noPageFoundService.noPageFoundModel$.subscribe(e=>this.noPageFoundModel=e)}restart(){this.router.navigateByUrl("")}goBack(){this.location.back()}ngOnDestroy(){var e;null===(e=this.sub)||void 0===e||e.unsubscribe()}}return e.\u0275fac=function(o){return new(o||e)(c.Mb(i),c.Mb(t.n),c.Mb(a.b))},e.\u0275cmp=c.Gb({type:e,selectors:[["app-no-page-found"]],decls:10,vars:3,consts:[[1,"center"],["mat-raised-button","",3,"click"]],template:function(e,o){1&e&&(c.Sb(0,"div",0),c.Sb(1,"h1"),c.Bc(2),c.Rb(),c.Sb(3,"p"),c.Sb(4,"a",1),c.Zb("click",(function(){return o.restart()})),c.Bc(5),c.Rb(),c.Sb(6,"span"),c.Bc(7,"\xa0\xa0\xa0\xa0\xa0"),c.Rb(),c.Sb(8,"a",1),c.Zb("click",(function(){return o.goBack()})),c.Bc(9),c.Rb(),c.Rb(),c.Rb()),2&e&&(c.Bb(2),c.Cc(o.noPageFoundModel.SorryPageNotFound),c.Bb(3),c.Cc(o.noPageFoundModel.Restart),c.Bb(4),c.Cc(o.noPageFoundModel.GoBack))},directives:[u.a],styles:[".center[_ngcontent-%COMP%]{margin:100px;text-align:center;vertical-align:middle}"],changeDetection:0}),e})()}];let b=(()=>{class e{}return e.\u0275mod=c.Kb({type:e}),e.\u0275inj=c.Jb({factory:function(o){return new(o||e)},imports:[[a.f.forChild(d)],a.f]}),e})(),l=(()=>{class e{}return e.\u0275mod=c.Kb({type:e}),e.\u0275inj=c.Jb({factory:function(o){return new(o||e)},imports:[[t.c,a.f,b,r.a]]}),e})()}}]);