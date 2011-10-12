<?php  
require_once("gzdecode.php");

$ch = curl_init(); // Initialize Curl  
$url = $_GET['url'];

curl_setopt($ch, CURLOPT_URL, $url); // Set CURL options  
curl_setopt($ch,CURLOPT_RETURNTRANSFER,1); //Return the handle if the curl session is set  
curl_setopt($ch, CURLOPT_POST, 2);
curl_setopt($ch, CURLOPT_POSTFIELDS, urldecode($_GET['post']));
$output = curl_exec($ch); // execute the curl  
curl_close($ch); // close the curl  
echo $output;
?>  