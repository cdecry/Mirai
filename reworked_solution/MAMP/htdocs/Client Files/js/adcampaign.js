var _sp_video;
var _sp_conversion = false;
function checkSPCampaign(userid, pub) {
	_sp_video=new SPONSORPAY.Video.Iframe({
		appid: '8091',
		uid:  userid, 
		height: 750,
		width: 750,
		pub0:pub,
		where:'spWallScreen',
		enable_close: false,
		display_format:  'bare_player', // default, will show only the video.
		text_claim_button:'Earn 30 eCoins',
		callback_on_start: spCampaignStart, 
		callback_no_offers: spCampaignNoOffers, 
		callback_on_close: spCampaignClose, 
		callback_on_conversion: spCampaignConversion 
	});
	_sp_video.backgroundLoad();
}

function spCampaignStart() {
	_sp_conversion = false;
	log("spCampaignStart");
	getFlashMovie("loginPage").adStatus("ADP", "SP_PREM", "READY");
}

function spCampaignNoOffers() {
	log("spCampaignNoOffers");
	// Not exist : Never check again
	/*
	document.getElementById("spWall").style.width = "0px";
	document.getElementById("spWall").style.height = "0px";
	document.getElementById("spWall").style.visibility = "hidden";
	document.getElementById("spUi").style.visibility = "hidden";
	document.getElementById("spWallScreen").style.height = "0px";
	*/
	var element = document.getElementById("spWall");
	element.parentNode.removeChild(element);
	getFlashMovie("loginPage").adStatus("ADP", "SP_PREM", "NO_OFFER");
}

function spCampaignClose() {
	log("spCampaignClose");
	document.getElementById("spWall").style.width = "0px";
	document.getElementById("spWall").style.height = "0px";
	document.getElementById("spWall").style.visibility = "hidden";
	document.getElementById("spUi").style.visibility = "hidden";
	$.fancybox.close();
	worldVisible(true);

	if(_sp_conversion) {
        	getFlashMovie("loginPage").adStatus("ADP", "SP_PREM", "CONVERSION");
	} else {
        	getFlashMovie("loginPage").adStatus("ADP", "SP_PREM", "RESUME");
	}
}

function spCampaignConversion() {
	_sp_conversion = true;
	log("spCampaignConversion");
}

function spCampaignPlay() {
	document.getElementById("spWall").style.width = "";
	document.getElementById("spWall").style.height = "";
	document.getElementById("spUi").style.visibility = "hidden";
	document.getElementById("spWall").style.visibility = "visible";
	worldVisible(false);
	adFire("spprem");
	_sp_video.showVideo();
	setTimeout(spCampaignShowBtn, 7000);
}

function spCampaignShowBtn() {
	document.getElementById("spUi").style.visibility = "visible";
}

function spCampaignSkip() {
        var r=confirm("By closing this ad it will skip and you will not earn any eCoins.\nAre you sure you want to do this?");

        if(r==true) {
		_sp_video.closeContainer();
	        $.fancybox.close();
       		worldVisible(true);
        } else {
        }
}


function checkBBCampaign(userid, pub) {
	document.getElementById("divbb").innerHTML = "<p/>";
	var bbUrl = "/ad/bb_player.html?userid=" + userid;
	document.getElementById("divbb").innerHTML = "<iframe src='" + bbUrl + "' scrolling='no' width=100% height=100% frameborder=0 id='bbframe'></iframe>";
}

function bbCampaignNoOffer() {
	getFlashMovie("loginPage").adStatus("ADP", "BB_PREM", "NO_OFFER");
} 

function bbCampaignReady() {
	getFlashMovie("loginPage").adStatus("ADP", "BB_PREM", "READY");
} 

var bbHeightTemp;
var bbWidthTemp;

function bbCampaignStart() {
	/*
	document.getElementById("divbb").style.visibility = "visible";
	log("bbCampaignStart");
        showDis("divbb");
	document.getElementById('bbframe').contentWindow.startAd();
	bbHeightTemp = document.getElementById("mainWrapper").style.height;
	bbWidthTemp = document.getElementById("mainWrapper").style.width;

	document.getElementById("mainWrapper").style.height = "560px";
	document.getElementById("mainWrapper").style.width = "900px";

	document.getElementById("divbb").style.height = "560px";
	document.getElementById("divbb").style.width = "900px";
	*/

	document.getElementById("divbb").style.visibility = "visible";
	log("bbCampaignStart");
	document.getElementById('bbframe').contentWindow.startAd();
	bbHeightTemp = document.getElementById("mainWrapper").style.height;

	document.getElementById("divbb").style.width = document.getElementById("mainWrapper").style.width;  
        showDis("divbb");
        worldVisible(false);


	//document.getElementById("divbb").style.width = document.getElementById("mainWrapper").style.width;  
	//testBB();
}

function bbCampaignComplete() {
	log("bbCampaignComplete");
	document.getElementById("mainWrapper").style.height = bbHeightTemp; 
	document.getElementById("mainWrapper").style.width = bbWidthTemp; 
	document.getElementById("divbb").style.position = "absolute";
	document.getElementById("divbb").style.visibility = "hidden";
//        worldVisible(true);
//        showDis("loginPage");
	getFlashMovie("loginPage").focus();
	getFlashMovie("loginPage").adStatus("ADP", "BB_PREM", "COMPLETE");

        worldVisible(true);
        showDis("loginPage");
}

/*
function testBB() {
	worldVisible(false);
	document.getElementById("divbb").style.position = "relative";
	document.getElementById("divbb").style.visibility = "visible";
	adFire('bbprem');
	document.getElementById('bbframe').contentWindow.startAd();
}
*/
