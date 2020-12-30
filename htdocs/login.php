<?php
require_once("password.php");

//create variable for host, user, pass, dbname

$dbhost = 'localhost';
$dbuser = 'mirai';
$dbpass = 'HhjyHylnxbKNUjYv';
$dbname = 'mirai';

//create variable to hold connection to the mysql

$connection = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname) or die("Error connecting to server");

//once connected, select dbname we want to work with

mysqli_select_db($connection, $dbname);

//variable to store the username from unity
//variable to store the password from unity

$username = mysqli_real_escape_string($connection, $_POST['username']);
$password = mysqli_real_escape_string($connection, $_POST['password']);

//create variable to store the mysql query

$query = "SELECT * FROM Players WHERE LOWER(username)='$username'";

//create var to run query and store result

$result = mysqli_query($connection, $query) or die("Error processing request" .mysqli_error());


while($row = mysqli_fetch_array($result, MYSQLI_ASSOC))
{
        //grab the current row of username and compare it to the username received

        if (password_verify($password, $row['password']))
        {
                //2 = login success
                die("0 " .$row['username']);
        }
        else
        {
                //3 = right user wrong pass
                die("1");
        }

        /* if($row['username'] == $username && password_verify($password, $row['password']))
        {
                //found user and pass
                die("Login Success");
        }*/
}

//3 = username/pw invalid
die("1");

?>