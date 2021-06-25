window.onload=triggerCall;
function triggerCall(){
        callparent();
}
function callparent() {

        var size;
        if(arguments.length > 0) {
                size = arguments[0];
        } else {
                size = getDocHeight();
        }
	
	if(checkMiniClip()) {
                window.parent.resizeiframe(size);
        }
}

function getDocHeight() {
    var D = document;
    return document.body.clientHeight
    /*
    return Math.max(
        Math.max(D.body.scrollHeight, D.documentElement.scrollHeight),
        Math.max(D.body.offsetHeight, D.documentElement.offsetHeight),
        Math.max(D.body.clientHeight, D.documentElement.clientHeight)
    );
    */
}

function checkMiniClip() {

	try {
		if(window.parent != null) {
			if( window.parent.isMiniClip() ) {
				return true;	
			}
		}
	} catch(e) { }

	return false;
}

function openMembership() {

	if(!checkMiniClip()) {
		document.location.href = "https://secure.fantage.com/membershipv3/pmSelectPayment.do";
	} else {
		//window.top.location.href = "https://secure.fantage.com/membership?miniclip";
		window.parent.openEcommerce();
	}
}

function callParentResizeIframe(width) {
	if(checkMiniClip()) {
		window.parent.callResizeIFrame(width);
	}
}

function openManageAccount() {

        var param = "";
        if(arguments.length > 0) {
                param = arguments[0];
        }
	
	if(!checkMiniClip()) {
		document.location.href = "https://secure.fantage.com/membershipv3/manageAccount.do";
	} else {
		//window.top.location.href = "https://secure.fantage.com/membership?miniclip";
		window.parent.openManageAccount(param);
	}
}
