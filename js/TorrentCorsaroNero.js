$(document).ready(function() {	
	$.ajaxSetup({
	   type: "GET",
	   cache: false,
	   dataType: "html",
	   async: false,
	   error: function() {},
 	});
	// NUOVI ELEMENTI NEL DOM
	$(".Contenitore").append("<div id='InfoTorrent'></div>");
	$(".Contenitore").append("<div id='Buttons'></div>");
	$("#Buttons").html("<input type='button' value='Precedente' id='PrewTor'><input type='button' value='Download' id='Download'><input type='button' value='Successivo' id='SuccTor'><br>").hide();
	$(".Contenitore").append("<div id='Risultati'></div>");
	//VARIABILI
	var DesTor = new Array();
	var TorrentCode; //Contiene il codice per il download del torrent
	var TorrentLocation; //variabile contente l'url del file torrent
	var NTor = 0; //Il numero di torrent che si sta visualizzando
	var NTorTot = 0;//Il numero totale di torrent trovati
	//FUNZIONI AL CLICK
	$(".Search").click(function(){
		DesTor = RicTorrent($("#Ric").val());
		Completato(FindDesc(DesTor[NTor]));
	});
   
	$("#PrewTor").live('click', function() {
		if(NTor > 1)
			Completato(FindDesc(DesTor[--NTor]));
	});
			
	$("#SuccTor").live('click', function() {
		if(NTor < NTorTot)
			Completato(FindDesc(DesTor[++NTor]));
	});
			
	$("#Download").live('click', function() {
		var Result = Post(DesTor[NTor],'site=8&cerca='+TorrentCode);
		var Ini = SearchLast(Result,'src="');
		var i=Ini;
		TorrentLocation = "";
		while(Result[i] != '"'){
			TorrentLocation += Result[i++];		
		}
		ApriTorrent();
		Download(TorrentLocation);
	});
	//FUNZIONI PER LA RICERCA ED IL DOWNLOAD DEI FILE TORRENT
	function Completato(Risultati){
		$("#InfoTorrent").html("<h3>Stai guardando il download n."+NTor+"/"+NTorTot+" trovati</h3>");					
		$("#Buttons").show();
		$("#Risultati").show();
		$("#Risultati").html("");
		if(Risultati == null)
				$("#Risultati").append("Nessuna descrizione per questo file è stata trovata. Prova a cercarne un altro oppure a selezionare SUCCESSIVO dal bottone in alto.<br> ATTENZIONE: togliere il carattere ' (apostrofo) dalla ricerca! Purtroppo il programmatore non ha ancora controllato questa evenienza...");	
			else 
				$("#Risultati").append(Risultati);
	}
	
	function ApriTorrent(){
		$.ajax({
			url: 'Prog/Torrent.php',
		});
		return true;	
	}
	
	function SearchLast(str,value){
		var PosIni = 0;
		while(str.search(value) != -1){
			PosIni += str.search(value) + value.length;
			str = str.substring(str.search(value) + value.length);
		}
		return PosIni;
	}
	
	function RicTorrent(KeySrc){
		var Risu = new Array();						
		var path = "http://ilcorsaronero.info/argh.php?search=" + KeySrc;
		var url = 'proxy.php?page=' + path;
		$.ajax({
			url: url,
			success: function(Page) {
				NTor = 0;
				$(Page).find(".tab").each(function(){
					Risu[++NTor] = $(this).attr("href");
				})
				NTorTot = NTor/2;
				NTor = 1;
			}
		});
		return Risu;
	}
	
	function FindDesc(url){
		var Ris;
		$.ajax({
			url: 'proxy.php?page=' + url,
			success: function(Page) {
				Ris = Page;
				TorrentCode = $(Ris).find("input[name='cerca']").attr("value"); //salvo il codice univoco del Torrent
			}
		});	
		return $(Ris).find("i").html();
	}
			
	function Post(Url,Value){
		var Ris;
		$.ajax({
			data: "url=" + Url + "&post=" + escape(Value),
			url: 'post.php',
			success: function(Page) {
				Ris = Page;
			}
		});
		return Ris;	
	}
			
	function Download(url){
		$.ajax({
			url: 'download.php?url=' + url,
			success: function(Page) {
				Completato(Page);
			}
		});
	}
});