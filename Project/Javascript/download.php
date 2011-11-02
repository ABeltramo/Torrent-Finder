<?php  
require_once("gzdecode.php");

$ch = curl_init(); // Initialize Curl  
$url = $_GET['url'];
$Benc = $_GET['benc'];

curl_setopt($ch, CURLOPT_URL, $url); // Set CURL options  
curl_setopt($ch,CURLOPT_RETURNTRANSFER,1); //Return the handle if the curl session is set  
curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1); 
 

$output = curl_exec($ch); // execute the curl  
curl_close($ch); // close the curl 
if($Benc == "true"){
	$output = gzdecode($output);
}

if($output == ""){
		echo "Mi dispiace ma qualcosa è andato storto! Non è possibile scaricare questo file. 
			  <br>Prova a premere il bottone SUCCESSIVO e a scaricarne un altro...
			  <br><br>Output: ".$output."
			  <br>Pagina di download: ".$url;
		exit;	
}

$array = explode("/", $url);
$array = explode(".",  $array[count($array)-1]);
$FileName = $array[0];
$fp = fopen (dirname(__FILE__) . '/Torrent_Download/' .$FileName . '.torrent', 'w+');
fwrite($fp,$output);
fclose($fp);
echo "Il download che hai scelto è partito regolarmente.";

?>  