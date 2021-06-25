<?php
require_once("password.php");

//create variables for host, user, pass, dbname

$dbhost = 'localhost';
$dbuser = 'mirai';
$dbpass = 'HhjyHylnxbKNUjYv';
$dbname = 'mirai';

//create variable to hold connection to mysql using mysql_connect(dbhost, user, pass)

$connection = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname) or die("Error connecting to server");

//once connected, select dbname u want to work wif using mysql_select_db(dbname)

mysqli_select_db($connection, $dbname);

//variable to store the username sent from unity
//variable to store the pw sent from unity
//variable to store the email sent from unity

$username = mysqli_real_escape_string($connection, $_POST['username']);
$password = mysqli_real_escape_string($connection, $_POST['password']);
$email = mysqli_real_escape_string($connection, $_POST['email']);
$pin = mysqli_real_escape_string($connection, $_POST['pin']);
$ipaddress = mysqli_real_escape_string($connection, $_POST['ipaddress']);

//create a variable to store the query we'd like to run in the database

//SELECT all FROM TableName WHERE ColumnName = ".$variable.";   place this in a string

//check if username already exists

$checkuser = mysqli_query($connection, "SELECT * FROM Players WHERE username = '$username'");

//check to see if a row returns with the username received from unity

$rowmatch = mysqli_num_rows($checkuser);

if ($rowmatch == 0)
{
        //username available
        //encrypt their password
        //insert them into database
        
        //encrypting
        $password = mysqli_real_escape_string($connection, password_hash($password, PASSWORD_DEFAULT));

        //INSERT into database the username, pw, email

        $insertuserquery = "INSERT INTO Players (username, password, email, pin, ipaddress) VALUES ('$username', '$password', '$email', '$pin', '$ipaddress')";

        //run query to insert into database
        
        mysqli_query($connection, $insertuserquery) or die("Failed to insert in database");

        //0 = signup complete
        die("0");
}

else
{
        //1 = username already exists
        die("1");
}

mysqli_close($connection);

?>