(window.webpackJsonp=window.webpackJsonp||[]).push([[3],{"9RmB":function(e,t,n){"use strict";n.r(t),n.d(t,"HomeModule",(function(){return s}));var i=n("ofXK"),a=n("tyNb");function l(e){let t={Title:"The title"};"fr-CA"===$localize.locale&&(t.Title="Le Titre"),e.UpdateHomeText(t)}var o=n("fXoL"),r=n("2Vo4");let u=(()=>{class e{constructor(){this.homeTextModel$=new r.a({}),l(this),this.UpdateHomeText({Title:"Something for text"})}UpdateHomeText(e){this.homeTextModel$.next(Object.assign(Object.assign({},this.homeTextModel$.getValue()),e))}}return e.\u0275fac=function(t){return new(t||e)},e.\u0275prov=o.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var c=n("bTqV");const d=[{path:"",component:(()=>{class e{constructor(e){this.homeService=e}ngOnInit(){l(this.homeService)}}return e.\u0275fac=function(t){return new(t||e)(o.Nb(u))},e.\u0275cmp=o.Hb({type:e,selectors:[["app-home"]],decls:173,vars:1,consts:[["mat-button","","routerLink","address","routerLinkActive","active-link"],["mat-button","","routerLink","apperrlog","routerLinkActive","active-link"],["mat-button","","routerLink","apptask","routerLinkActive","active-link"],["mat-button","","routerLink","apptasklanguage","routerLinkActive","active-link"],["mat-button","","routerLink","aspnetuser","routerLinkActive","active-link"],["mat-button","","routerLink","boxmodel","routerLinkActive","active-link"],["mat-button","","routerLink","boxmodellanguage","routerLinkActive","active-link"],["mat-button","","routerLink","boxmodelresult","routerLinkActive","active-link"],["mat-button","","routerLink","classification","routerLinkActive","active-link"],["mat-button","","routerLink","climatedatavalue","routerLinkActive","active-link"],["mat-button","","routerLink","climatesite","routerLinkActive","active-link"],["mat-button","","routerLink","contact","routerLinkActive","active-link"],["mat-button","","routerLink","contactpreference","routerLinkActive","active-link"],["mat-button","","routerLink","contactshortcut","routerLinkActive","active-link"],["mat-button","","routerLink","doctemplate","routerLinkActive","active-link"],["mat-button","","routerLink","droguerun","routerLinkActive","active-link"],["mat-button","","routerLink","droguerunposition","routerLinkActive","active-link"],["mat-button","","routerLink","email","routerLinkActive","active-link"],["mat-button","","routerLink","emaildistributionlist","routerLinkActive","active-link"],["mat-button","","routerLink","emaildistributionlistcontact","routerLinkActive","active-link"],["mat-button","","routerLink","emaildistributionlistcontactlanguage","routerLinkActive","active-link"],["mat-button","","routerLink","emaildistributionlistlanguage","routerLinkActive","active-link"],["mat-button","","routerLink","helpdoc","routerLinkActive","active-link"],["mat-button","","routerLink","hydrometricdatavalue","routerLinkActive","active-link"],["mat-button","","routerLink","hydrometricsite","routerLinkActive","active-link"],["mat-button","","routerLink","infrastructure","routerLinkActive","active-link"],["mat-button","","routerLink","infrastructurelanguage","routerLinkActive","active-link"],["mat-button","","routerLink","labsheet","routerLinkActive","active-link"],["mat-button","","routerLink","labsheetdetail","routerLinkActive","active-link"],["mat-button","","routerLink","labsheettubempndetail","routerLinkActive","active-link"],["mat-button","","routerLink","log","routerLinkActive","active-link"],["mat-button","","routerLink","mapinfo","routerLinkActive","active-link"],["mat-button","","routerLink","mapinfopoint","routerLinkActive","active-link"],["mat-button","","routerLink","mikeboundarycondition","routerLinkActive","active-link"],["mat-button","","routerLink","mikescenario","routerLinkActive","active-link"],["mat-button","","routerLink","mikescenarioresult","routerLinkActive","active-link"],["mat-button","","routerLink","mikesource","routerLinkActive","active-link"],["mat-button","","routerLink","mikesourcestartend","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmanalysisreportparameter","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmlookupmpn","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmrun","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmrunlanguage","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmsample","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmsamplelanguage","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmsite","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmsitestartenddate","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmsubsector","routerLinkActive","active-link"],["mat-button","","routerLink","mwqmsubsectorlanguage","routerLinkActive","active-link"],["mat-button","","routerLink","polsourcegrouping","routerLinkActive","active-link"],["mat-button","","routerLink","polsourcegroupinglanguage","routerLinkActive","active-link"],["mat-button","","routerLink","polsourceobservation","routerLinkActive","active-link"],["mat-button","","routerLink","polsourceobservationissue","routerLinkActive","active-link"],["mat-button","","routerLink","polsourcesite","routerLinkActive","active-link"],["mat-button","","routerLink","polsourcesiteeffect","routerLinkActive","active-link"],["mat-button","","routerLink","polsourcesiteeffectterm","routerLinkActive","active-link"],["mat-button","","routerLink","rainexceedance","routerLinkActive","active-link"],["mat-button","","routerLink","rainexceedanceclimatesite","routerLinkActive","active-link"],["mat-button","","routerLink","ratingcurve","routerLinkActive","active-link"],["mat-button","","routerLink","ratingcurvevalue","routerLinkActive","active-link"],["mat-button","","routerLink","reportsection","routerLinkActive","active-link"],["mat-button","","routerLink","reporttype","routerLinkActive","active-link"],["mat-button","","routerLink","resetpassword","routerLinkActive","active-link"],["mat-button","","routerLink","samplingplan","routerLinkActive","active-link"],["mat-button","","routerLink","samplingplanemail","routerLinkActive","active-link"],["mat-button","","routerLink","samplingplansubsector","routerLinkActive","active-link"],["mat-button","","routerLink","samplingplansubsectorsite","routerLinkActive","active-link"],["mat-button","","routerLink","spill","routerLinkActive","active-link"],["mat-button","","routerLink","spilllanguage","routerLinkActive","active-link"],["mat-button","","routerLink","tel","routerLinkActive","active-link"],["mat-button","","routerLink","tidedatavalue","routerLinkActive","active-link"],["mat-button","","routerLink","tidelocation","routerLinkActive","active-link"],["mat-button","","routerLink","tidesite","routerLinkActive","active-link"],["mat-button","","routerLink","tvfile","routerLinkActive","active-link"],["mat-button","","routerLink","tvfilelanguage","routerLinkActive","active-link"],["mat-button","","routerLink","tvitem","routerLinkActive","active-link"],["mat-button","","routerLink","tvitemlanguage","routerLinkActive","active-link"],["mat-button","","routerLink","tvitemlink","routerLinkActive","active-link"],["mat-button","","routerLink","tvitemstat","routerLinkActive","active-link"],["mat-button","","routerLink","tvitemuserauthorization","routerLinkActive","active-link"],["mat-button","","routerLink","tvtypeuserauthorization","routerLinkActive","active-link"],["mat-button","","routerLink","useofsite","routerLinkActive","active-link"],["mat-button","","routerLink","vpambient","routerLinkActive","active-link"],["mat-button","","routerLink","vpresult","routerLinkActive","active-link"],["mat-button","","routerLink","vpscenario","routerLinkActive","active-link"],["mat-button","","routerLink","vpscenariolanguage","routerLinkActive","active-link"]],template:function(e,t){1&e&&(o.Tb(0,"h2"),o.yc(1),o.Sb(),o.Tb(2,"a",0),o.yc(3,"Address(1)"),o.Sb(),o.Tb(4,"a",1),o.yc(5,"AppErrLog(2)"),o.Sb(),o.Tb(6,"a",2),o.yc(7,"AppTask(3)"),o.Sb(),o.Tb(8,"a",3),o.yc(9,"AppTaskLanguage(4)"),o.Sb(),o.Tb(10,"a",4),o.yc(11,"AspNetUser(5)"),o.Sb(),o.Tb(12,"a",5),o.yc(13,"BoxModel(6)"),o.Sb(),o.Tb(14,"a",6),o.yc(15,"BoxModelLanguage(7)"),o.Sb(),o.Tb(16,"a",7),o.yc(17,"BoxModelResult(8)"),o.Sb(),o.Tb(18,"a",8),o.yc(19,"Classification(9)"),o.Sb(),o.Tb(20,"a",9),o.yc(21,"ClimateDataValue(10)"),o.Sb(),o.Tb(22,"a",10),o.yc(23,"ClimateSite(11)"),o.Sb(),o.Tb(24,"a",11),o.yc(25,"Contact(12)"),o.Sb(),o.Tb(26,"a",12),o.yc(27,"ContactPreference(13)"),o.Sb(),o.Tb(28,"a",13),o.yc(29,"ContactShortcut(14)"),o.Sb(),o.Tb(30,"a",14),o.yc(31,"DocTemplate(15)"),o.Sb(),o.Tb(32,"a",15),o.yc(33,"DrogueRun(16)"),o.Sb(),o.Tb(34,"a",16),o.yc(35,"DrogueRunPosition(17)"),o.Sb(),o.Tb(36,"a",17),o.yc(37,"Email(18)"),o.Sb(),o.Tb(38,"a",18),o.yc(39,"EmailDistributionList(19)"),o.Sb(),o.Tb(40,"a",19),o.yc(41,"EmailDistributionListContact(20)"),o.Sb(),o.Tb(42,"a",20),o.yc(43,"EmailDistributionListContactLanguage(21)"),o.Sb(),o.Tb(44,"a",21),o.yc(45,"EmailDistributionListLanguage(22)"),o.Sb(),o.Tb(46,"a",22),o.yc(47,"HelpDoc(23)"),o.Sb(),o.Tb(48,"a",23),o.yc(49,"HydrometricDataValue(24)"),o.Sb(),o.Tb(50,"a",24),o.yc(51,"HydrometricSite(25)"),o.Sb(),o.Tb(52,"a",25),o.yc(53,"Infrastructure(26)"),o.Sb(),o.Tb(54,"a",26),o.yc(55,"InfrastructureLanguage(27)"),o.Sb(),o.Tb(56,"a",27),o.yc(57,"LabSheet(28)"),o.Sb(),o.Tb(58,"a",28),o.yc(59,"LabSheetDetail(29)"),o.Sb(),o.Tb(60,"a",29),o.yc(61,"LabSheetTubeMPNDetail(30)"),o.Sb(),o.Tb(62,"a",30),o.yc(63,"Log(31)"),o.Sb(),o.Tb(64,"a",31),o.yc(65,"MapInfo(32)"),o.Sb(),o.Tb(66,"a",32),o.yc(67,"MapInfoPoint(33)"),o.Sb(),o.Tb(68,"a",33),o.yc(69,"MikeBoundaryCondition(34)"),o.Sb(),o.Tb(70,"a",34),o.yc(71,"MikeScenario(35)"),o.Sb(),o.Tb(72,"a",35),o.yc(73,"MikeScenarioResult(36)"),o.Sb(),o.Tb(74,"a",36),o.yc(75,"MikeSource(37)"),o.Sb(),o.Tb(76,"a",37),o.yc(77,"MikeSourceStartEnd(38)"),o.Sb(),o.Tb(78,"a",38),o.yc(79,"MWQMAnalysisReportParameter(39)"),o.Sb(),o.Tb(80,"a",39),o.yc(81,"MWQMLookupMPN(40)"),o.Sb(),o.Tb(82,"a",40),o.yc(83,"MWQMRun(41)"),o.Sb(),o.Tb(84,"a",41),o.yc(85,"MWQMRunLanguage(42)"),o.Sb(),o.Tb(86,"a",42),o.yc(87,"MWQMSample(43)"),o.Sb(),o.Tb(88,"a",43),o.yc(89,"MWQMSampleLanguage(44)"),o.Sb(),o.Tb(90,"a",44),o.yc(91,"MWQMSite(45)"),o.Sb(),o.Tb(92,"a",45),o.yc(93,"MWQMSiteStartEndDate(46)"),o.Sb(),o.Tb(94,"a",46),o.yc(95,"MWQMSubsector(47)"),o.Sb(),o.Tb(96,"a",47),o.yc(97,"MWQMSubsectorLanguage(48)"),o.Sb(),o.Tb(98,"a",48),o.yc(99,"PolSourceGrouping(49)"),o.Sb(),o.Tb(100,"a",49),o.yc(101,"PolSourceGroupingLanguage(50)"),o.Sb(),o.Tb(102,"a",50),o.yc(103,"PolSourceObservation(51)"),o.Sb(),o.Tb(104,"a",51),o.yc(105,"PolSourceObservationIssue(52)"),o.Sb(),o.Tb(106,"a",52),o.yc(107,"PolSourceSite(53)"),o.Sb(),o.Tb(108,"a",53),o.yc(109,"PolSourceSiteEffect(54)"),o.Sb(),o.Tb(110,"a",54),o.yc(111,"PolSourceSiteEffectTerm(55)"),o.Sb(),o.Tb(112,"a",55),o.yc(113,"RainExceedance(56)"),o.Sb(),o.Tb(114,"a",56),o.yc(115,"RainExceedanceClimateSite(57)"),o.Sb(),o.Tb(116,"a",57),o.yc(117,"RatingCurve(58)"),o.Sb(),o.Tb(118,"a",58),o.yc(119,"RatingCurveValue(59)"),o.Sb(),o.Tb(120,"a",59),o.yc(121,"ReportSection(60)"),o.Sb(),o.Tb(122,"a",60),o.yc(123,"ReportType(61)"),o.Sb(),o.Tb(124,"a",61),o.yc(125,"ResetPassword(62)"),o.Sb(),o.Tb(126,"a",62),o.yc(127,"SamplingPlan(63)"),o.Sb(),o.Tb(128,"a",63),o.yc(129,"SamplingPlanEmail(64)"),o.Sb(),o.Tb(130,"a",64),o.yc(131,"SamplingPlanSubsector(65)"),o.Sb(),o.Tb(132,"a",65),o.yc(133,"SamplingPlanSubsectorSite(66)"),o.Sb(),o.Tb(134,"a",66),o.yc(135,"Spill(67)"),o.Sb(),o.Tb(136,"a",67),o.yc(137,"SpillLanguage(68)"),o.Sb(),o.Tb(138,"a",68),o.yc(139,"Tel(69)"),o.Sb(),o.Tb(140,"a",69),o.yc(141,"TideDataValue(70)"),o.Sb(),o.Tb(142,"a",70),o.yc(143,"TideLocation(71)"),o.Sb(),o.Tb(144,"a",71),o.yc(145,"TideSite(72)"),o.Sb(),o.Tb(146,"a",72),o.yc(147,"TVFile(73)"),o.Sb(),o.Tb(148,"a",73),o.yc(149,"TVFileLanguage(74)"),o.Sb(),o.Tb(150,"a",74),o.yc(151,"TVItem(75)"),o.Sb(),o.Tb(152,"a",75),o.yc(153,"TVItemLanguage(76)"),o.Sb(),o.Tb(154,"a",76),o.yc(155,"TVItemLink(77)"),o.Sb(),o.Tb(156,"a",77),o.yc(157,"TVItemStat(78)"),o.Sb(),o.Tb(158,"a",78),o.yc(159,"TVItemUserAuthorization(79)"),o.Sb(),o.Tb(160,"a",79),o.yc(161,"TVTypeUserAuthorization(80)"),o.Sb(),o.Tb(162,"a",80),o.yc(163,"UseOfSite(81)"),o.Sb(),o.Tb(164,"a",81),o.yc(165,"VPAmbient(82)"),o.Sb(),o.Tb(166,"a",82),o.yc(167,"VPResult(83)"),o.Sb(),o.Tb(168,"a",83),o.yc(169,"VPScenario(84)"),o.Sb(),o.Tb(170,"a",84),o.yc(171,"VPScenarioLanguage(85)"),o.Sb(),o.Ob(172,"router-outlet")),2&e&&(o.Bb(1),o.Ac("home works! -- ",t.homeService.homeTextModel$.getValue().Title,""))},directives:[c.a,a.d,a.c,a.f],styles:[""],changeDetection:0}),e})(),canActivate:[n("auXs").a],children:[{path:"address",loadChildren:()=>n.e(36).then(n.bind(null,"lIqt")).then(e=>e.AddressModule)},{path:"apperrlog",loadChildren:()=>n.e(37).then(n.bind(null,"t8mL")).then(e=>e.AppErrLogModule)},{path:"apptask",loadChildren:()=>n.e(12).then(n.bind(null,"R5yZ")).then(e=>e.AppTaskModule)},{path:"apptasklanguage",loadChildren:()=>Promise.all([n.e(0),n.e(13)]).then(n.bind(null,"jcPN")).then(e=>e.AppTaskLanguageModule)},{path:"boxmodel",loadChildren:()=>n.e(38).then(n.bind(null,"iGoo")).then(e=>e.BoxModelModule)},{path:"boxmodellanguage",loadChildren:()=>Promise.all([n.e(0),n.e(14)]).then(n.bind(null,"mAw6")).then(e=>e.BoxModelLanguageModule)},{path:"boxmodelresult",loadChildren:()=>n.e(39).then(n.bind(null,"3dNl")).then(e=>e.BoxModelResultModule)},{path:"classification",loadChildren:()=>n.e(40).then(n.bind(null,"vpjk")).then(e=>e.ClassificationModule)},{path:"climatedatavalue",loadChildren:()=>Promise.all([n.e(0),n.e(41)]).then(n.bind(null,"+WJj")).then(e=>e.ClimateDataValueModule)},{path:"climatesite",loadChildren:()=>n.e(42).then(n.bind(null,"2wOd")).then(e=>e.ClimateSiteModule)},{path:"contact",loadChildren:()=>n.e(43).then(n.bind(null,"wtgo")).then(e=>e.ContactModule)},{path:"contactpreference",loadChildren:()=>n.e(28).then(n.bind(null,"9pH/")).then(e=>e.ContactPreferenceModule)},{path:"contactshortcut",loadChildren:()=>n.e(44).then(n.bind(null,"Ho8B")).then(e=>e.ContactShortcutModule)},{path:"doctemplate",loadChildren:()=>n.e(11).then(n.bind(null,"X5H4")).then(e=>e.DocTemplateModule)},{path:"droguerun",loadChildren:()=>n.e(45).then(n.bind(null,"eWI4")).then(e=>e.DrogueRunModule)},{path:"droguerunposition",loadChildren:()=>n.e(46).then(n.bind(null,"Npqq")).then(e=>e.DrogueRunPositionModule)},{path:"email",loadChildren:()=>n.e(47).then(n.bind(null,"+xK4")).then(e=>e.EmailModule)},{path:"emaildistributionlist",loadChildren:()=>n.e(48).then(n.bind(null,"FaSq")).then(e=>e.EmailDistributionListModule)},{path:"emaildistributionlistcontact",loadChildren:()=>n.e(49).then(n.bind(null,"usK0")).then(e=>e.EmailDistributionListContactModule)},{path:"emaildistributionlistcontactlanguage",loadChildren:()=>Promise.all([n.e(0),n.e(15)]).then(n.bind(null,"TOYK")).then(e=>e.EmailDistributionListContactLanguageModule)},{path:"emaildistributionlistlanguage",loadChildren:()=>Promise.all([n.e(0),n.e(16)]).then(n.bind(null,"FuH+")).then(e=>e.EmailDistributionListLanguageModule)},{path:"helpdoc",loadChildren:()=>n.e(17).then(n.bind(null,"yGEX")).then(e=>e.HelpDocModule)},{path:"hydrometricdatavalue",loadChildren:()=>Promise.all([n.e(0),n.e(50)]).then(n.bind(null,"hzbZ")).then(e=>e.HydrometricDataValueModule)},{path:"hydrometricsite",loadChildren:()=>n.e(51).then(n.bind(null,"sJCf")).then(e=>e.HydrometricSiteModule)},{path:"infrastructure",loadChildren:()=>n.e(52).then(n.bind(null,"w0ax")).then(e=>e.InfrastructureModule)},{path:"infrastructurelanguage",loadChildren:()=>Promise.all([n.e(0),n.e(18)]).then(n.bind(null,"yDtO")).then(e=>e.InfrastructureLanguageModule)},{path:"labsheet",loadChildren:()=>Promise.all([n.e(0),n.e(53)]).then(n.bind(null,"uzbP")).then(e=>e.LabSheetModule)},{path:"labsheetdetail",loadChildren:()=>n.e(54).then(n.bind(null,"xJNp")).then(e=>e.LabSheetDetailModule)},{path:"labsheettubempndetail",loadChildren:()=>Promise.all([n.e(0),n.e(55)]).then(n.bind(null,"Go4k")).then(e=>e.LabSheetTubeMPNDetailModule)},{path:"log",loadChildren:()=>n.e(56).then(n.bind(null,"SJzs")).then(e=>e.LogModule)},{path:"mapinfo",loadChildren:()=>n.e(29).then(n.bind(null,"ggi7")).then(e=>e.MapInfoModule)},{path:"mapinfopoint",loadChildren:()=>n.e(57).then(n.bind(null,"TnRq")).then(e=>e.MapInfoPointModule)},{path:"mikeboundarycondition",loadChildren:()=>n.e(30).then(n.bind(null,"O48q")).then(e=>e.MikeBoundaryConditionModule)},{path:"mikescenario",loadChildren:()=>Promise.all([n.e(0),n.e(58)]).then(n.bind(null,"kmbE")).then(e=>e.MikeScenarioModule)},{path:"mikescenarioresult",loadChildren:()=>n.e(59).then(n.bind(null,"KoV8")).then(e=>e.MikeScenarioResultModule)},{path:"mikesource",loadChildren:()=>n.e(60).then(n.bind(null,"Beb1")).then(e=>e.MikeSourceModule)},{path:"mikesourcestartend",loadChildren:()=>n.e(61).then(n.bind(null,"a4Mp")).then(e=>e.MikeSourceStartEndModule)},{path:"mwqmanalysisreportparameter",loadChildren:()=>n.e(62).then(n.bind(null,"ZGES")).then(e=>e.MWQMAnalysisReportParameterModule)},{path:"mwqmlookupmpn",loadChildren:()=>n.e(63).then(n.bind(null,"V7k+")).then(e=>e.MWQMLookupMPNModule)},{path:"mwqmrun",loadChildren:()=>Promise.all([n.e(0),n.e(64)]).then(n.bind(null,"1uu2")).then(e=>e.MWQMRunModule)},{path:"mwqmrunlanguage",loadChildren:()=>Promise.all([n.e(0),n.e(19)]).then(n.bind(null,"gHfH")).then(e=>e.MWQMRunLanguageModule)},{path:"mwqmsample",loadChildren:()=>Promise.all([n.e(0),n.e(65)]).then(n.bind(null,"r0jb")).then(e=>e.MWQMSampleModule)},{path:"mwqmsamplelanguage",loadChildren:()=>Promise.all([n.e(0),n.e(20)]).then(n.bind(null,"vOxx")).then(e=>e.MWQMSampleLanguageModule)},{path:"mwqmsite",loadChildren:()=>n.e(66).then(n.bind(null,"W+NJ")).then(e=>e.MWQMSiteModule)},{path:"mwqmsitestartenddate",loadChildren:()=>n.e(67).then(n.bind(null,"YxUm")).then(e=>e.MWQMSiteStartEndDateModule)},{path:"mwqmsubsector",loadChildren:()=>n.e(68).then(n.bind(null,"QXYi")).then(e=>e.MWQMSubsectorModule)},{path:"mwqmsubsectorlanguage",loadChildren:()=>Promise.all([n.e(0),n.e(21)]).then(n.bind(null,"AfOW")).then(e=>e.MWQMSubsectorLanguageModule)},{path:"polsourcegrouping",loadChildren:()=>n.e(69).then(n.bind(null,"Hqkm")).then(e=>e.PolSourceGroupingModule)},{path:"polsourcegroupinglanguage",loadChildren:()=>Promise.all([n.e(0),n.e(22)]).then(n.bind(null,"b3hc")).then(e=>e.PolSourceGroupingLanguageModule)},{path:"polsourceobservation",loadChildren:()=>n.e(70).then(n.bind(null,"kQdg")).then(e=>e.PolSourceObservationModule)},{path:"polsourceobservationissue",loadChildren:()=>n.e(71).then(n.bind(null,"XBzJ")).then(e=>e.PolSourceObservationIssueModule)},{path:"polsourcesite",loadChildren:()=>n.e(72).then(n.bind(null,"0R/r")).then(e=>e.PolSourceSiteModule)},{path:"polsourcesiteeffect",loadChildren:()=>n.e(73).then(n.bind(null,"CjWm")).then(e=>e.PolSourceSiteEffectModule)},{path:"polsourcesiteeffectterm",loadChildren:()=>n.e(74).then(n.bind(null,"JVZo")).then(e=>e.PolSourceSiteEffectTermModule)},{path:"rainexceedance",loadChildren:()=>n.e(75).then(n.bind(null,"R7CB")).then(e=>e.RainExceedanceModule)},{path:"rainexceedanceclimatesite",loadChildren:()=>n.e(76).then(n.bind(null,"IH5r")).then(e=>e.RainExceedanceClimateSiteModule)},{path:"ratingcurve",loadChildren:()=>n.e(77).then(n.bind(null,"bjkp")).then(e=>e.RatingCurveModule)},{path:"ratingcurvevalue",loadChildren:()=>n.e(78).then(n.bind(null,"NoDl")).then(e=>e.RatingCurveValueModule)},{path:"reportsection",loadChildren:()=>n.e(23).then(n.bind(null,"mcZW")).then(e=>e.ReportSectionModule)},{path:"reporttype",loadChildren:()=>Promise.all([n.e(2),n.e(94)]).then(n.bind(null,"Lav6")).then(e=>e.ReportTypeModule)},{path:"resetpassword",loadChildren:()=>n.e(79).then(n.bind(null,"dfpf")).then(e=>e.ResetPasswordModule)},{path:"samplingplan",loadChildren:()=>Promise.all([n.e(0),n.e(80)]).then(n.bind(null,"d+8X")).then(e=>e.SamplingPlanModule)},{path:"samplingplanemail",loadChildren:()=>n.e(81).then(n.bind(null,"Y3pN")).then(e=>e.SamplingPlanEmailModule)},{path:"samplingplansubsector",loadChildren:()=>n.e(82).then(n.bind(null,"EjMS")).then(e=>e.SamplingPlanSubsectorModule)},{path:"samplingplansubsectorsite",loadChildren:()=>n.e(83).then(n.bind(null,"Zw2d")).then(e=>e.SamplingPlanSubsectorSiteModule)},{path:"spill",loadChildren:()=>n.e(84).then(n.bind(null,"ryrq")).then(e=>e.SpillModule)},{path:"spilllanguage",loadChildren:()=>Promise.all([n.e(0),n.e(24)]).then(n.bind(null,"BA+U")).then(e=>e.SpillLanguageModule)},{path:"tel",loadChildren:()=>n.e(85).then(n.bind(null,"g7fM")).then(e=>e.TelModule)},{path:"tidedatavalue",loadChildren:()=>Promise.all([n.e(0),n.e(86)]).then(n.bind(null,"nTDO")).then(e=>e.TideDataValueModule)},{path:"tidelocation",loadChildren:()=>n.e(87).then(n.bind(null,"Uvpw")).then(e=>e.TideLocationModule)},{path:"tidesite",loadChildren:()=>n.e(88).then(n.bind(null,"rs2v")).then(e=>e.TideSiteModule)},{path:"tvfile",loadChildren:()=>Promise.all([n.e(2),n.e(95)]).then(n.bind(null,"CEwS")).then(e=>e.TVFileModule)},{path:"tvfilelanguage",loadChildren:()=>Promise.all([n.e(0),n.e(25)]).then(n.bind(null,"XzWX")).then(e=>e.TVFileLanguageModule)},{path:"tvitem",loadChildren:()=>n.e(31).then(n.bind(null,"+Qfo")).then(e=>e.TVItemModule)},{path:"tvitemlanguage",loadChildren:()=>Promise.all([n.e(0),n.e(26)]).then(n.bind(null,"wv/s")).then(e=>e.TVItemLanguageModule)},{path:"tvitemlink",loadChildren:()=>n.e(32).then(n.bind(null,"tRap")).then(e=>e.TVItemLinkModule)},{path:"tvitemstat",loadChildren:()=>n.e(33).then(n.bind(null,"B5nr")).then(e=>e.TVItemStatModule)},{path:"tvitemuserauthorization",loadChildren:()=>Promise.all([n.e(0),n.e(89)]).then(n.bind(null,"VfN8")).then(e=>e.TVItemUserAuthorizationModule)},{path:"tvtypeuserauthorization",loadChildren:()=>Promise.all([n.e(0),n.e(34)]).then(n.bind(null,"X9Uk")).then(e=>e.TVTypeUserAuthorizationModule)},{path:"useofsite",loadChildren:()=>n.e(35).then(n.bind(null,"niiC")).then(e=>e.UseOfSiteModule)},{path:"vpambient",loadChildren:()=>n.e(90).then(n.bind(null,"xxNb")).then(e=>e.VPAmbientModule)},{path:"vpresult",loadChildren:()=>n.e(91).then(n.bind(null,"59if")).then(e=>e.VPResultModule)},{path:"vpscenario",loadChildren:()=>Promise.all([n.e(0),n.e(92)]).then(n.bind(null,"wFZd")).then(e=>e.VPScenarioModule)},{path:"vpscenariolanguage",loadChildren:()=>Promise.all([n.e(0),n.e(27)]).then(n.bind(null,"t7MB")).then(e=>e.VPScenarioLanguageModule)}]}];let b=(()=>{class e{}return e.\u0275mod=o.Lb({type:e}),e.\u0275inj=o.Kb({factory:function(t){return new(t||e)},imports:[[a.e.forChild(d)],a.e]}),e})();var h=n("B+Mi");let s=(()=>{class e{}return e.\u0275mod=o.Lb({type:e}),e.\u0275inj=o.Kb({factory:function(t){return new(t||e)},imports:[[i.c,a.e,b,h.a]]}),e})()},auXs:function(e,t,n){"use strict";n.d(t,"a",(function(){return o}));var i=n("fXoL"),a=n("tyNb"),l=n("qfBg");let o=(()=>{class e{constructor(e,t){this.router=e,this.userService=t}canActivate(e,t){if(this.userService.userModel$.getValue().ContactID)return!0;const n=$localize.locale+"/login";return this.router.navigate([n],{queryParams:{returnUrl:t.url}}),!1}}return e.\u0275fac=function(t){return new(t||e)(i.Xb(a.b),i.Xb(l.a))},e.\u0275prov=i.Jb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})()}}]);