!function(){function n(n,e){if(!(n instanceof e))throw new TypeError("Cannot call a class as a function")}function e(n,e){for(var o=0;o<e.length;o++){var t=e[o];t.enumerable=t.enumerable||!1,t.configurable=!0,"value"in t&&(t.writable=!0),Object.defineProperty(n,t.key,t)}}function o(n,o,t){return o&&e(n.prototype,o),t&&e(n,t),n}(window.webpackJsonp=window.webpackJsonp||[]).push([[93],{"4gTV":function(e,t,a){"use strict";a.r(t),a.d(t,"NoPageFoundModule",(function(){return y}));var i,r,c,u,s=a("ofXK"),d=a("B+Mi"),l=a("tyNb"),b=a("fXoL"),f=a("2Vo4"),g=((i=function(){function e(){n(this,e),this.noPageFoundModel$=new f.a({}),this.Init()}return o(e,[{key:"Init",value:function(){this.UpdateNoPageFound({})}},{key:"UpdateNoPageFound",value:function(n){var e=Object.assign(Object.assign({},this.noPageFoundModel$.getValue()),n);this.noPageFoundModel$=new f.a(e)}}]),e}()).\u0275fac=function(n){return new(n||i)},i.\u0275prov=b.Ib({token:i,factory:i.\u0275fac,providedIn:"root"}),i),p=a("bTqV"),h=[{path:"",component:(r=function(){function e(o,t,a){n(this,e),this.noPageFoundService=o,this.location=t,this.router=a,this.noPageFoundModel={}}return o(e,[{key:"ngOnInit",value:function(){var n,e,o=this;n=this.noPageFoundService,e={SorryPageNotFound:"Sorry Page Not Found",Restart:"Restart",GoBack:"Go Back"},"fr-CA"===$localize.locale&&(e.SorryPageNotFound="Nos excuses. La page est introuvable",e.Restart="Recommencer",e.GoBack="Reculer d'une page"),n.UpdateNoPageFound(e),this.sub=this.noPageFoundService.noPageFoundModel$.subscribe((function(n){return o.noPageFoundModel=n}))}},{key:"restart",value:function(){this.router.navigateByUrl("")}},{key:"goBack",value:function(){this.location.back()}},{key:"ngOnDestroy",value:function(){var n;null===(n=this.sub)||void 0===n||n.unsubscribe()}}]),e}(),r.\u0275fac=function(n){return new(n||r)(b.Mb(g),b.Mb(s.h),b.Mb(l.b))},r.\u0275cmp=b.Gb({type:r,selectors:[["app-no-page-found"]],decls:10,vars:3,consts:[[1,"center"],["mat-raised-button","",3,"click"]],template:function(n,e){1&n&&(b.Sb(0,"div",0),b.Sb(1,"h1"),b.zc(2),b.Rb(),b.Sb(3,"p"),b.Sb(4,"a",1),b.Zb("click",(function(){return e.restart()})),b.zc(5),b.Rb(),b.Sb(6,"span"),b.zc(7,"\xa0\xa0\xa0\xa0\xa0"),b.Rb(),b.Sb(8,"a",1),b.Zb("click",(function(){return e.goBack()})),b.zc(9),b.Rb(),b.Rb(),b.Rb()),2&n&&(b.Bb(2),b.Ac(e.noPageFoundModel.SorryPageNotFound),b.Bb(3),b.Ac(e.noPageFoundModel.Restart),b.Bb(4),b.Ac(e.noPageFoundModel.GoBack))},directives:[p.a],styles:[".center[_ngcontent-%COMP%]{margin:100px;text-align:center;vertical-align:middle}"],changeDetection:0}),r)}],v=((u=function e(){n(this,e)}).\u0275mod=b.Kb({type:u}),u.\u0275inj=b.Jb({factory:function(n){return new(n||u)},imports:[[l.e.forChild(h)],l.e]}),u),y=((c=function e(){n(this,e)}).\u0275mod=b.Kb({type:c}),c.\u0275inj=b.Jb({factory:function(n){return new(n||c)},imports:[[s.c,l.e,v,d.a]]}),c)}}])}();