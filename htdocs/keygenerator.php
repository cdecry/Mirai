<?php

$dbhost = 'localhost';
$dbuser = 'mirai';
$dbpass = 'HhjyHylnxbKNUjYv';
$dbname = 'mirai';

$connection = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname) or die("Error connecting to mysql");

mysqli_select_db($connection, $dbname);

$key = mysqli_real_escape_string($connection, $_POST['key']);

$checkKey = mysqli_query($connection, "SELECT * FROM AlphaKeys WHERE code = '$key'");

$rowmatch = mysqli_num_rows($checkKey);


if ($rowmatch == 0)
{
		$insertuserquery = "INSERT INTO AlphaKeys (code) VALUES ('$key')";
		mysqli_query($connection, $insertuserquery) or die("Failed to insert in database");
		die("Keys succesfully added.");
}
else
{
		die("Failed to add key: Duplicate found.");
}

mysqli_close($connection);

?>