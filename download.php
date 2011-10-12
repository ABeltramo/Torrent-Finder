<?php  
require_once("gzdecode.php");

$ch = curl_init(); // Initialize Curl  
$url = $_GET['url'];

curl_setopt($ch, CURLOPT_URL, $url); // Set CURL options  
curl_setopt($ch,CURLOPT_RETURNTRANSFER,1); //Return the handle if the curl session is set  
//curl_setopt($ch, CURLOPT_POST, 2);
//curl_setopt($ch, CURLOPT_POSTFIELDS, 'site=8&cerca='.$_GET['code']);

$output = curl_exec($ch); // execute the curl  
curl_close($ch); // close the curl 
if(gzdecode($output) == ""){
	echo "Mi dispiace ma qualcosa è andato storto! Non è possibile scaricare questo file. Prova a premere il bottone SUCCESSIVO e a scaricarne un altro...";	
}
else{ 
	$FileName = strrchr($_GET['url'], '/');
	$fp = fopen (dirname(__FILE__) . '/Torrent_Download/' .$FileName . '.torrent', 'w+');
	fwrite($fp,gzdecode($output));
	fclose($fp);
	echo "Il download che hai scelto è partito regolarmente.";
}
?>  