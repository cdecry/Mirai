<?php
require_once("password.php");

$dbhost = 'localhost';
$dbuser = 'mirai';
$dbpass = 'HhjyHylnxbKNUjYv';
$dbname = 'mirai';

$connection = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname) or die("Error connecting to mysql");

mysqli_select_db($connection, $dbname);

$key = mysqli_real_escape_string($connection, $_POST['key']);
$username = mysqli_real_escape_string($connection, $_POST['username']);
$password = mysqli_real_escape_string($connection, $_POST['password']);
$email = mysqli_real_escape_string($connection, $_POST['email']);

$checkKey = mysqli_query($connection, "SELECT * FROM AlphaKeys WHERE code = '$key'");

$rowmatch = mysqli_num_rows($checkKey);

if ($rowmatch == 0)
{
	//5 == alphakey invalid
	die("5");
}
else {

	//check if user exists, if so wait for available user then use same keycode

	$checkuser = mysqli_query($connection, "SELECT * FROM Players WHERE username = '$username'");
	$rowmatch = mysqli_num_rows($checkuser);

	if ($rowmatch == 0)
	{
		//user no exist yey, signup processing

		//encrypting
        $password = mysqli_real_escape_string($connection, password_hash($password, PASSWORD_DEFAULT));

		$insertuserquery = "INSERT INTO Players (username, password, email, alphakey) VALUES ('$username', '$password', '$email', '$key')";
		mysqli_query($connection, $insertuserquery) or die("Failed to insert in database");

		$deletekey = "DELETE FROM AlphaKeys WHERE code = '$key'";
		$deleteresult = mysqli_query($connection, $deletekey) or die("Error processing request: " .mysqli_error());
		//0 == signup w alphakey success
		echo("0");
		
	}
	else
	{	
		//1 == user alredy exists
		die("1");
	}
}

mysqli_close($connection);

?>