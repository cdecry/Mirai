<?php
$path = 'C:\nginx\html\/';
error_reporting(E_STRICT);
header("HTTP/1.1 200 OK");
if ($_SERVER['REQUEST_URI'] == "/404.php") { die(); }
$totalurl = "http://".str_replace("localhost", "fantage.com", $_SERVER['HTTP_HOST']).$_SERVER['REQUEST_URI'];
$content = file_get_contents($totalurl);
$saveurl2 = explode("?", $_SERVER['REQUEST_URI']);
$dir = findexts($_SERVER['REQUEST_URI']);
$saveurl = $saveurl2[0];
$dir2 = str_replace($dir, '', $saveurl);
$dir3 = rtrim($dir2,"/");
	function findexts ($url){ 
		$filename = $url; 
		$exts = split("/", $filename) ; 
		$n = count($exts)-1; 
		$exts = $exts[$n]; 
		return $exts; 
	} 
	function findexts2 ($url){ 
		$filename1 = strtolower($url) ; 
		$exts1 = split("[/\\.]", $filename1) ; 
		$n = count($exts1)-1; 
		$exts2 = $exts1[$n]; 
		return $exts2; 
	} 

if (!$content)
{
	echo "<center><br><br><br><br><big>404</big></center>";
	header(' ', true, 404);
	die();
}
$shits = array('html', 'htm', 'xml', 'css', 'do');
if(in_array(findexts2($saveurl), $shits)){
$content = str_replace("http://play.fantage.com", "http://play.localhost", $content);
$content = str_replace("http://fantage.com", "http://localhost", $content);
$content = str_replace("http://www.fantage.com", "http://www.localhost", $content);
$content = str_replace("https://", "http://", $content);
$content = str_replace("http://secm.fantage.com", "http://secm.localhost", $content);
$content = str_replace("http://static.fantage.com", "http://static.localhost", $content);
}
if (findexts2($saveurl) == "swf")
{
$header = substr($content, 0, 8);
$content = gzuncompress(substr($content, 8));	
$content = str_replace("http://fantage.com", "http://localhost", $content);
//$content = str_replace("fantage.com", "localhost", $content);// <------
$content = str_replace("play.fantage.com", "play.localhost", $content);
$content = str_replace("*.fantage.com", "*.localhost", $content);
$content = str_replace("www.fantage.com", "www.localhost", $content);
$content = str_replace("blog.fantage.com", "blog.localhost", $content);
$content = str_replace("http://play.fantage.com", "http://play.localhost", $content);
$content = str_replace("http://www.fantage.com", "http://www.localhost", $content);
$content = str_replace("red.fantage.com", "red.localhost", $content);
$content = str_replace("blue.fantage.com", "blue.localhost", $content);
$content = str_replace("panda.fantage.com", "panda.localhost", $content);
$content = str_replace("secure.fantage.com", "secure.localhost", $content);
$content = str_replace("secm.fantage.com", "secm.localhost", $content);

//$content = str_replace("211.43.156.35", "31.7.186.244", $content);
$content = $header.gzcompress($content);
} 
mkdir($path.$dir3, 0777, true);
rmdir($path.$saveurl);
$fp = fopen('C:\nginx\html'.$saveurl, "wb");
$result = fwrite($fp, $content);
fclose($fp);


if (substr($saveurl, -4) == ".swf")
{
	header('Content-type: application/x-shockwave-flash');
}
else if (substr($saveurl, -4) == ".xml")
{
	header('Content-type: text/xml');
}
else if (substr($saveurl, -4) == ".png")
{
	header('Content-type: image/png');
}
else if (substr($saveurl, -4) == ".jpg")
{
	header('Content-type: image/jpeg');
}
else if (substr($saveurl, -4) == ".css")
{
	header('Content-type: text/css');
}
else if (substr($saveurl, -4) == ".html")
{
	header('Content-type: text/html');
}
else if (substr($saveurl, -4) == ".js")
{
	header('Content-type: application/x-javascript');
}
echo $content;
?>