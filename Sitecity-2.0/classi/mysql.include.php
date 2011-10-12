<?php
/*************************************
		 mysql.include.php

               ***
 created by Alessandro Beltramo
      venerdì 5 Agosto 2011
http://www.sitecity.altervista.org/
			   ***
			   
			 V: 1.4
Added: NumCol()
Added: Disconnect()
Added: FetchArray()
Added: Field()
*************************************/
class mysql
{
    private $Server_Name; 
		private $Server_Ute;
		private $Server_Pass;
		private $Db_Name;
		private $Connected;
		private $Last_Query;
		private $Ris;
		
		function __construct(){
			//da modificare con quelli del database
      		$this->Server_Name = "localhost";
      		$this->Server_Ute = "serverale";
			$this->Server_Pass = "lolpollo";
			$this->Db_Name = "serverale";   
			$this->Connected = false; 
			$this->Last_Query = false;   
    }
		
		function __destruct() {
        	if($this->Connected != false)
				$this->Disconnect($this->Connected);
    	}

		public function Report_Error($Str){
			echo "<html>
					<head>
						<title> Error </title>	
					</head>
					<body>
					<h1> Siamo spiacenti ma un'errore interno è avvenuto </h1>
					<h4>
					<br>
					<b>Dettagli:</b>
					<br>
					".$Str;
					
					if(mysql_error() != '')
						echo "<br><br>Errore mysql riportato: <b>".mysql_error()."</b>";
						
					echo "
					</h4>
					<br><br><h1> Prova a ricaricare la pagina oppure a tornare indietro. </h1>
					</body>
				  </html>
				";
			exit();	
		}
		
		final public function Connect(){
			$this->Connected = mysql_connect($this->Server_Name, $this->Server_Ute, $this->Server_Pass);
			if(!$this->Connected)
				$this->Report_Error("Impossibile eseguire la connessione al database");
			if(!mysql_select_db($this->Db_Name, $this->Connected))
				$this->Report_Error("Impossibile selezionare il db durante la connessione");
			return true;	
		}
		
		public function MysqlEscape($Str){
			return (string)mysql_real_escape_string($Str);
		}
		
		final public function Query($Query,$Secure){
			if(!$this->Connected)
				$this->Report_Error("&Egrave; stata eseguita una query prima di essersi connessi al database!");
			if($Secure)
				$Query = $this->MysqlEscape($Query);
			$this->Last_Query = mysql_query($Query);
			if(!$this->Last_Query)
				$this->Report_Error("La seguente query non &egrave; andata a buon fine <br><b>".$Query."</b>");
			return $this->Last_Query;	
		}
		
		public function NumRig(){
			if(!$this->Last_Query)
				$this->Report_Error("Impossibile eseguire NumRig() prima di aver eseguito una query");
			try {
    			$this->Ris =  mysql_num_rows($this->Last_Query);
			} catch (Exception $e) {
    			$this->Report_Error("Impossibile eseguire NumRig(): ".$e->getMessage());
			}
			return (int)$this->Ris;	
		}
		
		public function NumCol(){
			if(!$this->Last_Query)		
			try {
    			$this->Ris =  mysql_num_fields($this->Last_Query);
			} catch (Exception $e) {
    			$this->Report_Error("Impossibile eseguire NumCol(): ".$e->getMessage());
			}
				$this->Report_Error("Non &egrave; stato possibile eseguire la NumCol()");
			return (int)$this->Ris;	
		}
		
		public function FetchArray(){
			if(!$this->Last_Query)
				$this->Report_Error("Impossibile eseguire NumCol() prima di aver eseguito una query");
				$i = 0;
			while ($row = mysql_fetch_array($this->Last_Query, MYSQL_ASSOC)) {
				$this->Ris[$i++] = $row;
			}
			return (array)$this->Ris; //Restituisce una matrice di risultati [0]['campo_db'] 			
		}
		
		public function Field($NameField){
			$this->Ris = $this->FetchArray();
			$NumRig = $this->NumRig();
			$i = 0;
			while($i<=$NumRig && !isset($this->Ris[i][$NameField]))
  			$i++;
		    if($i>=$NumRig && !isset($this->Ris[i][$NameField]))
				return false;
			  return (string)$this->Ris[i][$NameField]; 			
		}
		
		final public function Disconnect(){
			if(!$this->Connected)
				$this->Report_Error("Si &egrave; scelto di chiudere la sessione ma la sessione non era aperta!");
			$this->Ris = mysql_close($this->Connected);
			if(!$this->Ris)
				$this->Report_Error("Impossibile chiudere la connessione a mysql");
			$this->Connected = false;
			return true;	
		}		
}
?>