<?php
execInBackground("AvviaUto.bat");
header("Location: http://serverale.sytes.net:2107/gui/");
?>

<?php 
function execInBackground($cmd) { 
    if (substr(php_uname(), 0, 7) == "Windows"){ 
        pclose(popen("start /B ". $cmd, "r"));  
    } 
    else { 
        exec($cmd . " > /dev/null &");   
    } 
} 
?> 