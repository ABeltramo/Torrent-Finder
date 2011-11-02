<?php
// create a new cURL resource
$ch = curl_init();
$url = str_replace(" ","+",$_GET["page"]);
// set URL and other appropriate options
curl_setopt($ch, CURLOPT_URL, $url);
curl_setopt($ch, CURLOPT_HEADER, 0);

// grab URL and pass it to the browser
curl_exec($ch);

if(curl_exec($ch) === false)
{
    echo 'Curl error: ' . curl_error($ch);
}
// close cURL resource, and free up system resources
curl_close($ch);
?>