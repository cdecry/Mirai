var _gameName;
var _appVersion;
var _lang;
var _userid = "TESTID";
var _key = "";
var _type = "";

var target = "";

function spTest() {
		showDis("disempty");
		$("a#adcenter").attr("href", "/ad/sp_player.html");
		//resize('1');
		
		adcenterFire();	
		target = "fancybox-frame";
}

function snTest() {
		showDis("disempty");
		$("a#adcenter").attr("href", "/ad/ss_player.html");

		//resize('1');
		
		adcenterFire();	
		target = "fancybox-frame";
}

function r1Test() {
	showDis("disempty");
	$("a#r1center").attr("href", "/ad/r1_player.html");

		//resize('1');
		
	adcenterFireR1();	
	target = "fancybox-frame";
	
}

function taTest() {
		showDis("disempty");
		$("a#tacenter").attr("href", "/ad/ta_player.html");

		//resize('1');
		
		adFire("tacenter");
		target = "fancybox-frame";
}

function offerTest() {
		showDis("disempty");
		//resize('1');
		
		adFire("ofct");
		target = "fancybox-frame";
}

function hyprmxTest() {
	showHyprMx("0", "testuserid");	
}

function log(key, msg){

        // in case you use the console.log you will see some additional info about the events from BrandConnect.
        var log = (typeof console !== 'undefined' && typeof console.log !== 'undefined');
        log && console.log(key + "/" + msg);

}


function returnMain() {
	log("returnMain");
	closeFancyBox();	
} 

function playAdOffer(type, gamename, url, rewards, offerid, calltoaction, width, height, actualrewards, appversion, time, lang, userid, key) {
	if(force != "") {
		type = force;
	}
	_type = type;

	log("playAdOffer " + type + "/" + gamename + "/" + url + "/" + key);

	if(type == "google") {
		showGoogle(gamename, appversion, key);
		return;
	}

	if(type == "socialvibe") {
		showSv(gamename, appversion, userid, key);
		return;

	}

	if(type == "supersonic" || type == "radiumone" || type == "v11media" || type == "matomy" || type == "playpage") {

		var targethtml = "/ad/ss_player.html";
		if(type == "radiumone")
			targethtml = "/ad/r1_player.html";

		if(type == "v11media")
			targethtml = "/ad/v1_player.html";

		if(type == "matomy")
			targethtml = "/ad/mm_player.html";

		if(type == "playpage") 
			targethtml = "/ad/ss_campaign.html";

		showDis("divsp");
		worldVisible(false);

		_gameName = gamename;
		_appVersion = appversion;
		_lang = lang;
		_time = time;
		_userid = userid;
		_key = key;

		url = escape(url);
	
	//log(type + "/" + gamename + "/" + rewards + "/" + offerid + "/" + calltoaction + "/" + width + "/" + height + "/" + actualrewards + "/" + time + "/" + lang + "/" + userid + "/" + key);

		var generatedurl = targethtml + "?url=" + url + "&rewards=" + rewards + "&offerid=" + offerid + "&calltoaction=" + calltoaction + "&width=" + width +
			"&height=" + height + "&actualrewards=" + actualrewards + "&userid=" + userid + "&key=" + key;

		//document.getElementById("divsp").innerHTML = "<iframe src='" + generatedurl + "' scrolling='no' width=100% height=100% frameborder=0 id='ssframe'></iframe>";


		$("a#adcenter").attr("href", generatedurl);
		
		adcenterFire();	
		target = "fancybox-frame";
	}

}

function closeFancyBox() {
        $.fancybox.close();
//	showDis("loginPage");
	worldVisible(true);
		
}

function adcenterFire() {
	$("#adcenter").trigger("click");
}

function adcenterFireR1() {
	$("#r1center").trigger("click");
}

function adFire(name) {
	$("#" + name).trigger("click");

	if(isIE()) {
		setSize("loginPage", "0");
	}
}

function adEnd(name) {
	$("#" + name).attr("href", "test.html");
}

function testEnd() {
	adRewarded(_type, _key);
}

function adRewarded(network, key) {
	//log("adRewarded " + network + " " + key); 
	
	try {
		document.getElementById(target).contentWindow.rewarded(key);
	} catch(error) {
		//console.log("adRewarded ERROR" + network + " " + key); 
		log(document.getElementById(target));
	}
}

function rewardTest(customdata) {
	//console.log("testrequest " + customdata);
	getFlashMovie("loginPage").adStatus("SKIP", customdata);	
}

function playAd(type, gamename, appversion, time, lang, userid, key) {
	
	if(force != "") {
		type = force;
	}

	_type = type;
	_gameName = gamename;
	_appVersion = appversion;
	_lang = lang;
	_time = time;
	_userid = userid;
	_key = key;


	if(type == "supersonic") {
		showSonic(key,userid);
		return;
	}
	target = "ssframe";

	log("playAd : " + type + "/" + gamename + "/" + appversion + "/" + time + "/" + lang + "/" + userid + "/" + key);

	//console.log("playAd : " + type + "/" + gamename + "/" + appversion + "/" + time + "/" + lang + "/" + userid );

	switch(type) {
		case "google":
			showGoogle(gamename, appversion, key);
			//showYume(gamename, appversion);
		break;

		case "yume":
			//showGoogle(gamename, appversion);
			showYume(gamename, appversion);
		break;

		case "sponsorpay":
			showSp(gamename, appversion);
			//showYume(gamename, appversion);
			//showSonic(key,userid);
		break;

		case "socialvibe":
			showSv(gamename, appversion, userid, key);
		break;

		case "sponsorpay_prem":
			
		break;

		case "hyprmx":
			showHyprMx(key, userid);
		break;

		case "selectablemedia":
			showSelectableMedia(key, userid);
		break;

		case "radiumone2":
			showRadiumOne(userid);
		break;
	}
}

function showRadiumOne(userid) {
        var targethtml = "/ad/ra_player.html";
        var generatedurl = targethtml + "?userid=" + userid;

        showDis("disempty");
        $("a#selectablemedia").attr("href", generatedurl);

        adFire("selectablemedia");
}

function showSelectableMedia(key, userid) {


        var targethtml = "/ad/sm_player.html";
        var generatedurl = targethtml + "?userid=" + userid + "&key=" + key;

        $("a#selectablemedia").attr("href", generatedurl);

	log(":: showSelectableMedia " + key + "/" + userid + "/" + generatedurl);

        showDis("disempty");
        adFire("selectablemedia");
}

function showHyprMx(key, userid) {
        var targethtml = "/ad/hmx_player.html";
        var generatedurl = targethtml + "?userid=" + userid + "&key=" + key;

        showDis("disempty");
        $("a#hyprmx").attr("href", generatedurl);
        //$("a#adcenter").attr("href", generatedurl);

        //adcenterFire();
        adFire("hyprmx");
                
	//showDis("disempty");                
	//$("a#bbprem").attr("href", generatedurl);        
	//adFire("bbprem");                
	//target = "fancybox-frame";
}

function showSonic(key, userid) {
	var targethtml = "/ad/ss_player.html";


		//document.getElementById("divsp").innerHTML = "<iframe src='" + generatedurl + "' scrolling='no' width=100% height=100% frameborder=0 id='ssframe'></iframe>";
	var generatedurl = targethtml + "?userid=" + userid + "&key=" + key;


	/*
	$("a#adcenter").attr("href", generatedurl);
	adcenterFire();	
		
	target = "fancybox-frame";
	*/

        document.getElementById("divsp").innerHTML = "<iframe src='"+generatedurl+"' scrolling='no' width=100% height=100% frameborder=0></iframe>";
}

function ssStart() {
	worldVisible(false);
        showDis("divsp");
}

function ssNoOffer() {
	sp_noad();
} 

function showSp() {
	/*
	var _sp_videoa=new SPONSORPAY.Video.Iframe({
            appid: '5664',
            uid: _userid,
            height: 520,
            width: 800,
            where:'divsp',
            enable_close: false,
            callback_on_start: on_start,
            callback_no_offers: no_offers,
            callback_on_close:	on_close, 
            callback_on_conversion: on_conversion,
	    text_claim_button:'Earn 20 eCoins',
	    display_format : 'bare_player'
            });

            _sp_videoa.loadAndShow();
	*/

	/*
	worldVisible(false);
	showDis("divsp");

        bbHeightTemp = document.getElementById("mainWrapper").style.height;
        bbWidthTemp = document.getElementById("mainWrapper").style.width;

        document.getElementById("mainWrapper").style.height = "520px";
        document.getElementById("mainWrapper").style.width = "800px";

        document.getElementById("divbb").style.height = "520px";
        document.getElementById("divbb").style.width = "800px";
	*/

	var timerVal = setInterval(function() {
		clearInterval(timerVal);
		document.getElementById("divsp").innerHTML = "<iframe src='/ad/sp_player.html?app="+ _appVersion + "&userid=" + _userid + "&width=" + defaultWidth + "&height=" + defaultHeight + "&key=" + _key + "' scrolling='no' width='100%' height='100%' frameborder=0></iframe>";
	}, 1000);


	/*
	var generatedurl = "/ad/sp_player.html?app="+ _appVersion + "&userid=" + _userid + "&width=" + defaultWidth + "&height=" + defaultHeight + "&key=" + _key 

	$("a#adcenter").attr("href", generatedurl);

	adcenterFire();
        target = "fancybox-frame";
	*/
}

var svFlag = 0;

function redeemSv() {

        //console.log(rewardFlag);

        if(svFlag == 1) {
                document["svBtn"].src = "/images/please_wait.gif";
                svFlag = 2;

                $('#svBtn').delay(1400).queue(function() {
                        svFlag = 3;
                        document["svBtn"].src = "/images/success.png";
                });
        } else if(svFlag == 3) {
                //sp_end("socialvibe");
                closeFancyBox();

		log("::sv end" + svEngagement.signature +"/" + svEngagement.signature_argument_string );
		document.getElementById("inlinewall").style.visibility = "hidden";

		document.getElementById("inlinescreen").innerHTML = "<p/>";
		getFlashMovie("loginPage").adStatus("Ad", "socialvibe", "end", svEngagement.signature, svEngagement.signature_argument_string); 
		worldVisible(true);
        }
}

var svEngagement;
var svActivity = null;
var svClient;
var svStatus = false;

function checkSVExistence(userid) {

	if(svStatus) {
		log("::sv cached " + svActivity);
		getFlashMovie("loginPage").adStatus("SV","exist" );
		return;
	}

	log("::sv check " + userid);
	svFlag = 0;
	var options = {'network_user_id': userid, 'partner_config_hash': 'c27d2e6a952cf0198ece71fb4e38260730e9d435'};
	socialvibe.client(options, function(client) {
		client.requestActivity(function(activity) {
			if (activity) {
				//partnerMethodToPromoteActivity(activity, client);
				svActivity = activity;	
				svStatus = true;
				svClient = client;
				getFlashMovie("loginPage").adStatus("SV","exist" );
				log("::sv check - exist " + svActivity);
			} else {
				//alert('No available activity for this user.');
				log("::sv noad");
				getFlashMovie("loginPage").adStatus("SV","na" );
				svActivity = null;
				svStatus = false;
			}
		});

	});
}

function showSv(gamename, appversion, userid, key) {
	if(svActivity == null) return;
	log("::sv showSv " + gamename + "/" + appversion + "/" + userid + "/" + key + "/" + svActivity + "/" + svClient);
				svActivity.onStart(onStartSv);
				svActivity.onFinish(onFinishSv);
				svActivity.onCredit(onCreditSv);
				svActivity.onClose(closeSv);
	partnerMethodToPromoteActivity(svActivity, svClient);
}

function onStartSv(activity) {
	log("sv:: onStartSv " + activity.id);
}

function onFinishSv(activity) {
	log("sv:: onFinishSv " + activity.id);
}

function onCreditSv(engagement) {
	log("sv:: onCreditSv " + engagement.key);

	svEngagement = engagement;

	svFlag = 1;
	svStatus = false;
	document["svBtn"].src = "/images/earn25ecoin.png";
}

function closeSv(activity) {
	if(svFlag == 1) {
                closeFancyBox();

                log("::sv end" + svEngagement.signature +"/" + svEngagement.signature_argument_string );
		svActivity = null;
                document.getElementById("inlinewall").style.visibility = "hidden";
                document.getElementById("inlinescreen").innerHTML = "<p/>";
                getFlashMovie("loginPage").adStatus("Ad", "socialvibe", "end", svEngagement.signature, svEngagement.signature_argument_string);
		worldVisible(true);
	} else {
		svStatus = false;
		log("sv:: closeSv " + activity.id);
		svActivity = null;
		$.fancybox.close();
	        document.getElementById("inlinewall").style.visibility = "hidden";
		document.getElementById("inlinescreen").innerHTML = "<p/>";
		worldVisible(true);
	
	        adSkipped();
	        setTimeout(function() {
	                dispatchAdEvent("socialvibe", "skip");
	                getFlashMovie("loginPage").focus();
	        }, 50);
	}
}

function partnerMethodToPromoteActivity(d, client) {
	log("sv:: partnerMethodToPromoteActivity " + d);
	svFlag = 0;
	document.getElementById("inlinewall").style.visibility = "visible";
	document["svBtn"].src = "/images/earn25ecoin_.png";
	client.loadActivityIntoContainer(d, document.getElementById("inlinescreen"));
	log(d.id + "/" + d.image_url + "/" + d.display_text + "/" + d.window_url + "/" + d.window_width + "/" + d.window_height + "/" + d.currency_amount);
	d.currency_amount = 25;
	document.getElementById("inlinescreen").style.width = (d.window_width + 30) + "px";

		showDis("disempty");
                adFire("ofct");
                target = "fancybox-frame";


}

function sp_noad() {
	//adSkipped();
	//showDis("divsp");
	setTimeout(function() {
		dispatchAdEvent("Sponsorpay", "noad");
	}, 1000);
}

function sp_start() {
	showDis("divsp");
	refreshLoginSize();	
}

function campaingEnd() {

	log("playPage");

        adSkipped();
        setTimeout(function() {
		getFlashMovie("loginPage").adStatus("CPN", "", "");
                getFlashMovie("loginPage").focus();
        }, 1000);

        setTimeout(function() {
                document.getElementById("divsp").innerHTML = "<p/>";
        }, 2000);
}

function sp_end(network) {
	if(network == null) network = "sponsorpay";
	if(network == "playpage") {
		campaingEnd();
		return;		
	}

	adSkipped();
	setTimeout(function() {
		dispatchAdEvent(network, "start");
		dispatchAdEvent(network, "end");
		getFlashMovie("loginPage").dispatchWorld("RESUME_AFTER_AD");
		getFlashMovie("loginPage").focus();
	}, 1000);

	setTimeout(function() {
		document.getElementById("divsp").innerHTML = "<p/>";
	}, 2000);
}

function sp_skip() {
	adSkipped();
	setTimeout(function() {
		document.getElementById("divsp").innerHTML = "<p/>";	
		dispatchAdEvent("Sponsorpay", "skip");
		getFlashMovie("loginPage").focus();
	}, 1000);
}

function on_start() {
	dispatchAdEvent("Sponsorpay", "start");
} 

function on_close() {
	//document.getElementById("divsp").innerHTML = "<p/>";
	hideAd();
}

function on_conversion() {
	dispatchAdEvent("Sponsorpay", "Conversion");
	//dispatchAdEvent("Sponsorpay", "end");
}

function showad() {
	showDis("divad");

	var flashvars = {};
	flashvars.spotxPageURL = encodeURIComponent(window.location);
	var params = {allowscriptaccess:"always", bgcolor: "#000000", wmode:windowMode};
	//var params = {allowscriptaccess:"always", wmode:"window"};
	var attributes = {};
	swfobject.embedSWF("AS3_Plug-in.swf","divad", defaultWidth, defaultHeight, "10.0.0", false, flashvars, params, attributes);
}

function refreshDiv(name) {
	var olddiv = document.getElementById(name);
	document.removeChild(olddiv);

	var newDiv = document.createElement("div");
	newDiv.setAttribute('id', name);
	document.getElementById("mainWrapper").appendChild(newDiv);
}

function showGoogle(gamename, appversion, key) {
	
	log("showGoogle : " + gamename + "/" + appversion + "/" + key);

	//refreshDiv("divad");

	var flashvars = {gamename:gamename, time:_time, key:key};
	//flashvars.spotxPageURL = encodeURIComponent(window.location);
	var gParams = {allowScriptAccess:"always", bgcolor: "#000000", wmode:windowMode};
	//var params = {allowscriptaccess:"always", wmode:"window"};
	var attributes = {};
	swfobject.embedSWF("/ad/google_adsensevideo.swf?" + appversion,"divgl", defaultWidth, defaultHeight, "10.0.0", false, flashvars, gParams, attributes);
	//swfobject.embedSWF("/ad/google_adsensevideo.swf" ,"divad", defaultWidth, defaultHeight, "10.0.0", "/expressInstall.swf", flashvars, gParams, attributes);

	//showDis("divgl");
	setSize("divgl", "0");
	

	//document.getElementById("divsp").innerHTML = "<iframe src='/ad/sp_player.html?app="+ _appVersion +"&userid="+_userid+"&width=" +defaultWidth + "&height="+defaultHeight+"' scrolling='no' width=100% height=100% frameborder=0></iframe>";
	/*
	document.getElementById("divsp").innerHTML = "<iframe src='/ad/gl_player.html?app="+ _appVersion +"&userid="+_userid+"&width=" +defaultWidth + "&height="+defaultHeight+"' scrolling='no' width=100% height=100% frameborder=0></iframe>";
        showDis("divsp");
	*/

	//document.getElementById("divsp").innerHTML = "<p/>";

}

function hideAd() {
	adSkipped();
	getFlashMovie("loginPage").dispatchWorld("RESUME_AFTER_AD");
	// Stress test
	//showYume(_gameName, _appVersion);
}

function hideAdMsg(message) {
	adSkipped();
	if (message != null)
		getFlashMovie("loginPage").dispatchWorld(message);
}

function adSkipped() {
	//log("adSkipped");
	showDis("loginPage");
	getFlashMovie("loginPage").focus();
	/*	
	setTimeout(function() {
		document.getElementById("divad").innerHTML = "<p/>";
	}, 100);
	*/
}

function showYume(gamename, appversion) {

	showDis("divad");
	var flashvars = {gamename:gamename, appversion:_appVersion};
	var params = {allowScriptAccess:"always", bgcolor: "#000000", wmode:"transparent"};
	var attributes = {};

	swfobject.embedSWF("/ad/yume_player.swf?" + appversion, "divad", defaultWidth, defaultHeight, "10.0.0", "/expressInstall.swf", flashvars, params, attributes);

	document.getElementById("divsp").innerHTML = "<p/>";
}

function blcad() {
	trace("blcad");
	getFlashMovie("loginPage").dispatchWorld("BL_CAD");
}

function showResult(key) {
	getFlashMovie("divad").showResult(key);

	if(key == "OK") {
		hideAd();
	}
}

var setWorldVisible = true;

function isWorldVisible() {
	//return (getFlashMovie("loginPage").getAttribute("wmode").toLowerCase() != "transparent");
	return setWorldVisible;
}

function setIEWorldVisible(str) {
	log("setIEWorldVisible " + str);

        if(str == "true" || str == true) {
		setWorldVisible = true;
		getFlashMovie("loginPage").setAttribute("wmode",windowMode);
		setSize("loginPage", defaultWidth);

                getFlashMovie("loginPage").stageVisible(str);
//		$("#loginPage").css("visibility", "visible");

		refreshStage();
		var myTimer = setInterval( function() { 
			clearInterval(myTimer);
			refreshStage();
		}, 1000);

	} else {
		setWorldVisible = false;
		getFlashMovie("loginPage").setAttribute("wmode","transparent");
//		$("#loginPage").css("visibility", "hidden");
                getFlashMovie("loginPage").stageVisible(str);
		setSize("loginPage", "0");
		refreshStage();
	}
}

function worldVisible(str) {

	log("worldVisible " + str);
	log("getFlashMovie " + getFlashMovie("loginPage")); 
	log("jquery loginPage " + $("#loginPage") );

	//if(isIE() || isSafari()) {
	if(isIE()) {
		setIEWorldVisible(str);
		return;
	}
		
       	if(str == "true" || str == true) {
		setWorldVisible = true;
		log("worldVisible 1");
                getFlashMovie("loginPage").setAttribute("wmode",windowMode);
		log("worldVisible 2");
		if(!isIE()) {
			$("#loginPage").attr("wmode", windowMode);
			log("worldVisible 3");
			$("#loginPage").css("visibility", "visible");
		}
		log("worldVisible 4");
		getFlashMovie("loginPage").focus();
		log("worldVisible 5");
		//document.getElementById("loginPage").style.width = defaultWidth;
		//document.getElementById("loginPage").style.height= defaultHeight;
		setSize("loginPage", defaultWidth);
		/*
		try {
                	getFlashMovie("loginPage").wmode = "window";
		}catch(error) {
		}
		*/
		refreshStage();

		// Slow pc handling
		getFlashMovie("loginPage").stageVisible(str);
		var myTimer = setInterval( function() { 
			clearInterval(myTimer);
			refreshStage();
		}, 1000);
        } else if(str == "false" || str == false) {
		getFlashMovie("loginPage").stageVisible(str);
		setWorldVisible = false;
                getFlashMovie("loginPage").setAttribute("wmode","transparent");
		if(!isIE()) {
			$("#loginPage").attr("wmode", "transparent");
			$("#loginPage").css("visibility", "hidden");
		}
		setSize("loginPage", "0px");
		//document.getElementById("loginPage").style.width = 0;
		//document.getElementById("loginPage").style.height= 0;
		/*
		try {
                	//getFlashMovie("loginPage").wmode = "transparent";
			document.getElementById("loginPage").wmode = "transparent";
		}catch(error) {
		}
		*/
        }

	refreshLoginSize();


}

function detectSafari()
{
var browser=navigator.appName;
var navindex=navigator.userAgent.indexOf('Safari');

if (navindex != -1 || browser=='Safari') return true;

return false; 

} 

function callExternalGameSkip() {
	document.getElementById("adscreen").style.border = "0px";
	lockresize = true;

	log("callExternalGameskip "); 

	document.getElementById("divpanel").style.visibility = "visible";
	//setSize("divpanel", "800");
	//showDis("divpanel");
        worldVisible(false);

	showAppssavvy();
	getFlashMovie("resultbar").startSkip();
}

function callExternalGamePanel(isDoubleStar, finalScore, starEarned, gameName, soundEnabled, bonusStar, appversion) {
	/*
	var gameUrl = "/ad/panels/gameresult.html?isDoubleStar=" + isDoubleStar + "&finalScore=" + finalScore + "&starEarned=" + starEarned + "&gameName=" + gameName + "&soundEnabled=" + soundEnabled + "&bonusStar=" + bonusStar + "&appversion=" + appversion;
	document.getElementById("divsp").innerHTML = "<iframe src='"+gameUrl+"' scrolling='no' width=100% height=100% frameborder=0></iframe>";

	showDis("divsp");
        worldVisible(false);
	*/

	document.getElementById("adscreen").style.border = "0px";
	lockresize = true;

	log("callExternalGamePanel : " + isDoubleStar + "/" + finalScore + "/" + starEarned + "/" + gameName + "/" + soundEnabled + "/" + bonusStar + "/" + appversion);
	
	document.getElementById("divpanel").style.visibility = "visible";
	//setSize("divpanel", "800");
	//showDis("divpanel");
        worldVisible(false);

	showAppssavvy();
	getFlashMovie("resultbar").startDisplay(isDoubleStar, finalScore, starEarned, gameName, soundEnabled, bonusStar);

}

function resumeAfterGamePanel() {

        adSkipped();
        setTimeout(function() {
                getFlashMovie("loginPage").adStatus("RSM_GMPNL", "", "");
                getFlashMovie("loginPage").focus();
        }, 10);

        setTimeout(function() {
                document.getElementById("divsp").innerHTML = "<p/>";
        }, 20);
}

function resumeAfterSkipAd() {
	lockresize = false;

	log("asv:: resumeAfterSkipAd", getFlashMovie("resultbar").alternative());

	document.getElementById("adscreen").innerHTML = "<p/>";
	//document.getElementById("divpanel").style.visibility = "hidden";
	//setSize("divpanel", "0");
	//showDis("loginPage");
	getFlashMovie("loginPage").adStatus("RSM_SKPNL", "", "");
	getFlashMovie("loginPage").focus();
        worldVisible(true);

	try {
		AS.removeAd({act:'game/complete'});
	} catch(e) {}

}

function returnToWorld() {
	lockresize = false;

	try {
		AS.removeAd({act:'game/complete'});
	} catch(e) {}

	document.getElementById("adscreen").innerHTML = "<p/>";
	//document.getElementById("divpanel").style.visibility = "hidden";
	setSize("divpanel", "0");
	showDis("loginPage");
	getFlashMovie("loginPage").adStatus("RSM_GMPNL", "", "");
	getFlashMovie("loginPage").focus();
        worldVisible(true);
}

function refreshResultPanel() {
	return;
	var flashvars = {};
        var params2 = {
                      align: "middle",
                      play: "true",
                      loop: "true",
                      scale: "",
                      wmode: "transparent",
                      devicefont: "false",
                      id: "mainscreen",
                      bgcolor: "#FFFFFF",
                      name: "mainscreen",
                      menu: "false",
                      allowFullScreen: "false",
                      allowScriptAccess: "always"
        };
        var attributes = {};
	swfobject.embedSWF("/ad/panels/gameresult.swf?v1.0" , "resultbar", 800, 190, "10.0.0", "/expressInstall.swf", flashvars, params2, attributes);
}

function showAppssavvy() {

	refreshResultPanel();


	log("asv:: showAppssavvy");
	log( document.getElementById("adscreen"));
	try {
       		AS.ready(function() {
                //AS.openAd({siteId:10004, targetDiv:'adscreen', act:'testact', width:600, height:300, pos:2, frame:0, close:0, delAd:1, onAdResponse:decideAndShow, onAdDisplay:onUpdateState});
                AS.openAd({siteId:'9357770e-ba8c-3d56-a956-808906163e7e', targetDiv:'adscreen', act:'game/complete', width:600, height:300, pos:2, frame:0, close:0, delAd:1, onAdResponse:decideAndShow, onAdDisplay:onUpdateState});
        	});
                log("ASV: display");
        } catch(e) {
		requestAlternative();
        }
}

function requestAlternative() {
	log("asv:: requestAlternative");
	getFlashMovie("resultbar").alternative();
}

function asvAlternative(url) {
        var isIE = navigator.appName.indexOf("Microsoft") != -1;
        if(isIE) {
                document.getElementById("adscreen").innerHTML = "<p style='top:0px;position:relative;padding-top:30px;'><img src='/" + url + "'></p>";
        } else {
               document.getElementById("adscreen").innerHTML = "<p style='top:-12px;position:relative;padding-top:30px;'><img src='/" + url + "'></p>";
        }
}

function isIE() {
        return navigator.appName.indexOf("Microsoft") != -1;
}

function isSafari() {
	var is_safari = navigator.userAgent.indexOf("Safari") > -1;
	var is_chrome = isChrome();

	if ((is_chrome)&&(is_safari)) {is_safari=false;}
	return is_safari;
}

function isChrome() {
	return navigator.userAgent.indexOf('Chrome') > -1;
}

function isOpera() {
}

function onUpdateState(state) {
	log("asv:: onUpdateState : " + state + "/" + state.state);
}

function decideAndShow(obj) {
	log("asv:: onAdResponse " + obj.response);
	if(!obj.response) {
	        document.getElementById("adscreen").style.border = "0px";
		requestAlternative();
	} else {
		document.getElementById("adscreen").style.border = "solid 3px #13A2E2";
		log("asv:: onCredit");
		getFlashMovie("loginPage").adStatus("RSM_REWARD", "", "");
		getFlashMovie("resultbar").onCredit();
	}
}

function refreshLoginSize() {
	if(isFullScreen == "true") {
		goFull();
	} else {
		resize(defaultWidth);
	}
}



