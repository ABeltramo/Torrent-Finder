$(document).ready(function() {	
	$.ajaxSetup({
	   type: "GET",
	   cache: false,
	   dataType: "html",
	   async: true,
	   error: function() {},
 	});
	// NUOVI ELEMENTI NEL DOM
	$(Contenitore).append("<div id='InfoTorrent'></div>").hide();
	$(Contenitore).append("<div id='Buttons'></div>")
	$("#Buttons").html("<input type='button' value='Precedente' id='PrewTor'><input type='button' value='Download' id='Download'><input type='button' value='Successivo' id='SuccTor'><br>");
	$(Contenitore).append("<div id='MoreDesc'></div>");
	$(Contenitore).append("<div id='Risultati'></div>");
	/*LOADING*/
	$("body").append("<div id='Loading'></div>");
	$("body").append("<div id='Obscure'></div>");
	$("#Obscure").hide();
	$("#Loading").html("<img src='css/img/loading.gif'> <b>Caricamento </b><img src='css/img/loading.gif'><br>");
	$("#Loading").append("<br>Aspettare è ancora un'occupazione.<br>È non aspettar niente che è terribile. <br><br>Cesare Pavese, Il mestiere di vivere<br>");
	$("#Loading").append("<br><img src='css/img/loading.gif'> <b>Caricamento </b> <img src='css/img/loading.gif'>").hide();
	//VARIABILI
	var DesTor = new Array();
	var TorrentCode; //Contiene il codice per il download del torrent
	var NTor = 0; //Il numero di torrent che si sta visualizzando
	var NTorTot = 0;//Il numero totale di torrent trovati
	
	//FUNZIONI AL CLICK
	$(RicBut).click(function(){
		RicTorrent($(RicBox).val());
	});
   
	$("#PrewTor").live('click', function() {
		if(NTor > 1)
			FindDesc(DesTor[--NTor]);
	});
			
	$("#SuccTor").live('click', function() {
		if(NTor < NTorTot)
			FindDesc(DesTor[++NTor]);
	});
			
	$("#Download").live('click', function() {
		Loading();
		ApriTorrent();
		Download(DowAbsolutePath + TorrentCode);
	});
	
	
//FUNZIONI PER LA RICERCA ED IL DOWNLOAD DEI FILE TORRENT	
/*
*RICERCA il Torrent
*/	
	function RicTorrent(KeySrc){
		Loading();					
		var path =  RicSite + KeySrc + RicAfter;
		var url = 'proxy.php?page=' + path;
		$.ajax({
			url: url,
			success: function(Page) {
				NTor = 0;
				$(Page).find(TorrentPRic).each(function(){
					DesTor[++NTor] = DesAbsolutePath + $(this).find(HrefTorDes).attr(DesAttr);
				})
				NTorTot = NTor/2;
				NTor = 1;
				FindDesc(DesTor[NTor]);
			}
		});
	}
/*
*RICERCA la descrizione del Torrent
*/	
	function FindDesc(url){
		Loading();
		$.ajax({
			url: 'proxy.php?page=' + url,
			success: function(Page) {
				TorrentCode = $(Page).find(DowButton).attr(DowAttr); //salvo il codice univoco del Torrent
				if(MoreDesc!="")
					$("#MoreDesc").html(MoreDescTit + $(Page).find(MoreDesc).html());
				Completato($(Page).find(ObjDesc).html());
			}
		});
	}
/*
*AVVIA utorrent.exe
*/
	function ApriTorrent(){
		$.ajax({
			url: 'Prog/Torrent.php',
		});
		return true;	
	}
/*
*SCARICA il file torrent dall'url che gli viene passato
*/			
	function Download(url){
		$.ajax({
			url: 'download.php?url=' + url+ "&benc="+Bencoding,
			success: function(Page) {
				Completato(Page);
			}
		});
	}
	
	function Completato(Risultati){
		$("#Obscure").hide();
		$("#Loading").hide();
		$(Contenitore).show();
		$("#InfoTorrent").html("<h3>Stai guardando il download n."+NTor+"/"+NTorTot+" trovati</h3>");					
		$("#Risultati").html("");
		if(Risultati == null)
				$("#Risultati").append("Nessuna descrizione per questo file è stata trovata. Prova a cercarne un altro oppure a selezionare SUCCESSIVO dal bottone in alto.<br> ATTENZIONE: togliere il carattere ' (apostrofo) dalla ricerca! Purtroppo il programmatore non ha ancora controllato questa evenienza...");	
			else 
				$("#Risultati").append("<center><h2>Descrizione</h2></center>"+Risultati);
	}
	
	function Loading(){
		$(Contenitore).hide();
		$("#Obscure").show();
		$("#Loading").show();		
	}
});