# Ultimate-Tic-Tac-Toe

Igrata se igra na sledniov nacin. Prv pocnuva Player 1 t.e. X i moze da go izbere bilo koe pole. Tabelata vo koja se igraat narednite
potezi e determinirata od prethodniot poteg, odnosno ako Player 1 stavi x vo (1,2) kvadratot Player 2 treba da izigra vo (1,2) tabelata.
Dokolku nekoj od igracite odigra vo kvadratce koe se odrazuva na tabela koja shto prethodno bila osvoena sledniot igrac ima pravo da
odigra vo bilo koja tabela. Prviot igrac shto ke stigne do 3 osvoeni tabeli pobeduva.

Za implementacija na resenieto se cuvaat podatoci za poenite na dvata igraci (playerXPoints i playerOPoints), informacija za momentalno koj igrac e na red (turn), informacija vo koja tabela momentalno e dozvoleno da se igra (currentBox), lista so site tabeli(allPanels), lista so osvoeni tabeli(wonPanels), lista od site kopcinja (buttons) i lista od site veke upotrebeni kopcinja (usedButtons). Pri klik na nekoe kopce se proveruva dali e vo soodvetnata tabela i dokolku e, kopceto preminuva vo disabled sostojba i se proveruva dali ima kompletirana trojka vo soodvetnata tabela. Ako nekoj od igracite soodvetno kompletira nekoja trojka rezultatot se azurira i se proveruva dali nekoj ima osvoeno vkupno 3 poeni. Koga nekoj od igracite osvoi vkupno 3 poeni se pojavuva dijalog za nova igra ili za izlez od aplikacijata.

