        function popupArt() {
                var ww = 840;
                var hh = 620;
                var mywindow = window.open("/fun/contest_results_fanart.html", "mywindow","toolbar=no,menubar=no,location=no,status=no,scrollbars=no, width="+ww+",height="+hh);
                if(window.focus) {mywindow.focus();}
                mywindow.moveTo(screen.width/2 - ww/2,  screen.height/2 - hh/2);
        }

        function popupComic() {
                var ww = 840;
                var hh = 550;
                mywindow = window.open("/fun/contest_results_comic.html", "mywindow","toolbar=no,menubar=no,location=no,status=no,scrollbars=no, width="+ww+",height="+hh);
                if(window.focus) {mywindow.focus();}
                mywindow.moveTo(screen.width/2 - ww/2,  screen.height/2 - hh/2);
        }

        function popupSubmission() {
                var ww = 860;
                var hh = 630;
                mywindow = window.open("/submission_mini.html", "mywindow","toolbar=no,menubar=no,location=no,status=no,scrollbars=no, width="+ww+",height="+hh);
                if(window.focus) {mywindow.focus();}
                mywindow.moveTo(screen.width/2 - ww/2,  screen.height/2 - hh/2);
        }

        function popupPrint(url) {
                mywindow = window.open("/fun/popup_print.php?url="+url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=no, width=300, height=300");
                if(window.focus) {mywindow.focus();}
                mywindow.moveTo(screen.width/2 - 150,screen.height/2 - 150);
        }

        function popupNoPrint(url) {
                mywindow = window.open("/fun/popup_noprint.php?url="+url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=no, width=300, height=300");
                if(window.focus) {mywindow.focus();}
                mywindow.moveTo(screen.width/2 - 150,screen.height/2 - 150);
        }

	function popupScrollWindow(url) {
		var ww = 850;
		var hh = 600;
                mywindow = window.open(url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=yes, width="+ww+", height="+hh);
                if(window.focus) {mywindow.focus();}
	}

	function popupNoScrollWindow(url) {
		var ww = 850;
		var hh = 600;
                mywindow = window.open(url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=no, width="+ww+", height="+hh);
                if(window.focus) {mywindow.focus();}
                mywindow.moveTo(screen.width/2 - ww/2,screen.height/2 - hh/2);
	}

        function popupImage() {
                var j1 = document.getElementById("hiddenTarget");
                var url = j1.href;

                mywindow = window.open("/fun/popup_print.php?url="+url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=no, width=500, height=200");
                if(window.focus) {mywindow.focus();}
                mywindow.moveTo(screen.width/2 - 250,screen.height/2 - 250);
        }

        function callArt() {
                $('#hiddenArtBtn').trigger('click');
        }

        function callComic() {
                $('#hiddenComicBtn').trigger('click');
        }

        function callSubmission() {
                $('#hiddenSubmissionBtn').trigger('click');
        }
        function openPopup(url, width, height) {
                var ww = width;
                var hh = height;
                mywindow = window.open(url, "mywindow","toolbar=no,menubar=no,location=no,status=yes,scrollbars=yes,resizable=yes, width="+ww+",height="+hh);
                if(window.focus) {mywindow.focus();}
                mywindow.moveTo(screen.width/2 - ww/2,  screen.height/2 - hh/2);
        }

        function callPopup(url) {

		var ww=850;
		var hh=600;

                mywindow = window.open("/fun/popup_print.php?url="+url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=no, width=600, height=400");
                if(window.focus) {mywindow.focus();}
                mywindow.moveTo(screen.width/2 - 250,screen.height/2 - 250);

		if((url == "http://play.fantage.com/fun/stationery.html")||(url == "http://play.fantage.com/fun/card.html") || (url == "http://play.fantage.com/fun/wallpaper.html") || (url == "http://play.fantage.com/fun/banner.html") || (url == "http://play.fantage.com/fun/coloringsheet.html") || (url == "http://play.fantage.com/preview.html")) 
		{
			mywindow.resizeTo(ww,hh);
			mywindow.moveTo(screen.width/2 - ww/2, screen.height/2 - hh/2);
		}
        }

	function callMini(url) {
		var ww=840;
		var hh=screen.height;

               	mywindow = window.open(url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=yes, width="+ww+", height="+hh);
           	if(window.focus) {mywindow.focus();}
		
               	mywindow.moveTo(screen.width/2 - ww/2,  screen.height/2 - hh/2);
	}

         function callPopupWindow(url){
		var ww=850;
		var hh=600;
		
		if(url == "http://blog.fantage.com" || url == "http://blog.fantage.com/") {
			ww = 1100;
			hh = screen.height;
			
                	mywindow = window.open(url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=yes, width="+ww+", height="+hh);
           	     	if(window.focus) {mywindow.focus();}
		
                	mywindow.moveTo(screen.width/2 - ww/2,  screen.height/2 - hh/2);

			
		} else if(url == "http://play.fantage.com/contest/preview_small.html") { 
			ww = 880;
			hh = screen.height;
                	mywindow = window.open(url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=yes, width="+ww+", height="+hh);
           	     	if(window.focus) {mywindow.focus();}

                	mywindow.moveTo(screen.width/2 - ww/2,  screen.height/2 - hh/2);
		
		} else if(url == "http://play.fantage.com/fun/contest_results_comic.html") {
			popupComic();
		} else if(url == "http://play.fantage.com/fun/contest_results_fanart.html") {
			popupArt();
		} else { 

                	mywindow = window.open(url, "mywindow", "toolbar=no, menubar=no, location=no, status=no, scrollbars=no, width=800, height=400");
           	     	if(window.focus) {mywindow.focus();}
        	        mywindow.moveTo(screen.width/2 - 250,screen.height/2 - 250);

			if((url == "http://play.fantage.com/fun/stationery.html")||(url == "http://play.fantage.com/fun/card.html") || (url == "http://play.fantage.com/fun/wallpaper.html") || (url == "http://play.fantage.com/fun/banner.html") || (url == "http://play.fantage.com/fun/coloringsheet.html") || (url == "http://play.fantage.com/preview.html")) 
			{
				mywindow.resizeTo(ww,hh);
				mywindow.moveTo(screen.width/2 - ww/2, screen.height/2 - hh/2);
			}

		}
        }