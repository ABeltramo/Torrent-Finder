PHPTorrent
==========

Applicazione che semplifica il download di file .torrent.
<br>Da un unica pagina tramite chiamate asincrone (ajax) &egrave; possibile vedere i risultati della ricerca, la descrizione del torrent e scaricarlo sul server.
<br>L'applicazione consente anche di avviare automaticamente uTorrent.exe (Nel caso in cui esso sia installato) il quale se configurato correttamente consente di scaricare file .torrent in automatico

Stato
------

Il Progetto &egrave; ancora ad una fase sperimentale (Beta).
<br>Funziona ed &egrave; abbastanza stabile ma bisogna ancora effettuare molti controlli e potenziare la sicurezza (in particolare per quanto riguarda i download).
<br> Il cuore del programma &egrave; il file /Project/js/Torrent.js che contiene le funzioni principali.
<br>Consiglio inoltre di leggere la documentazione allegata in modo da avere un idea degli obiettivi e di ci&ograve; che &egrave; stato realizzato.

Demo
------

Una demo pubblica non &egrave; ancora disponibile ma &egrave; possibile avviare il file index.htm per effettuare una prova del codice.
<br>REQUISITI:
<br>*Il progetto deve essere avviato con apache funzionante*
<br>*Il computer su cui si avvia il progetto deve essere connesso ad internet*
<br>*Per poter avviare uTorrent.exe httpd.exe deve essere aperto dall'utente*

Licenza
-------

Copyright (C) 2011  Alessandro Beltramo <beltramo.ale@gmail.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see http://www.gnu.org/licenses/.