/*****
* MODIFICARE QUESTE VARIABILI GLOBALI 
*****/
//id o classe del contenitore dei risultati nella pagina dove viene richiamato
var Contenitore = ".Contenitore";
//id o classe della text box dal quale leggere le ricerche
var RicBox = "#Ric";
//id o classe del bottone dove si preme per avviare la ricerca
var RicBut = ".Search";
/*****
* NON MODIFICARE OLTRE SE NON SI SA COSA SI FA! 
*****/

/*
*RICERCA DEL TORRENT
*/
//Pagina del sito dal quale fare la ricerca
var RicSite = "http://it.limetorrents.com/search/all/";
//Compilare questo spazio solo se il sito necessita di una parte successiva alla stringa di ricerca
var RicAfter = "/";
	/* IN QUESTO CASO LA RICERCA ERA DEL TIPO: http://www.kat.ph/search/RICERCA/  */
//id o classe di ogni torrent contenuto nella pagina di ricerca 
var TorrentPRic = ".tdleft";
/*
*DESCRIZIONE DEL TORRENT
*/
//id o classe dell'oggetto che contiene il link alla descrizione del torrent
var HrefTorDes = ".tt-name a:nth-child(2)";
//Riempire questa variabile solo se il link alla descrizione è RELATIVO
var DesAbsolutePath = "http://it.limetorrents.com/";
//Attributo dove ricercare il link alla descrizione
var DesAttr = "href";
//Id o classe dove è contenuta la descrizione del torrent
var ObjDesc = "pre";
//Id o classe che contiene una descrizione aggiuntiva (Tipo le dimensioni del file)
var MoreDesc = "";
//Titolo della descrizione
var MoreDescTit = ""
/*
*DOWNLOAD DEL TORRENT
*/
//Id o classe dell'oggetto che contiene il link per scaricare
var DowButton = ".torrentinfo .downloadarea .dltorrent p a";
//Attributo dove il link è salvato
var DowAttr = "href"
//Riempire questa variabile solo se il link al download è RELATIVO
var DowAbsolutePath = "http://it.limetorrents.com/";
//True se sul risultato bisogna eseguire il bencoding (Errori nell'apertura del file torrent)
var Bencoding = false;