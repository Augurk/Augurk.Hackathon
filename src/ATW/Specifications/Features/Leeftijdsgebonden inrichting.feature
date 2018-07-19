Functionaliteit: Leeftijdsgebonden inrichting
Omdat de ATW veelal afwijkt per leeftijd is het noodzakelijk om eenvoudig de juiste inrichting voor een bepaalde leeftijd te kunnen bepalen,
Deze feature omschrijft hoe dit werkt.

Scenario: Inrichting wordt gevonden

	Stel het volgende is ingericht onder de naam "maximale arbeidstijd"
	| Leeftijd | Waarde |
	| 16       | 1      |
	| 17       | 2      |
	| 18       | 3      |
	Als de inrichting van "maximale arbeidstijd" wordt opgevraagd voor een medewerker van 18 jaar
	Dan wordt de waarde 3 gevonden

Scenario: Inrichting wordt niet gevonden

	Stel het volgende is ingericht onder de naam "maximale arbeidstijd"
	| Leeftijd | Waarde |
	| 16       | 1      |
	| 17       | 2      |
	| 18       | 3      |
	Als de inrichting van "maximale arbeidstijd" wordt opgevraagd voor een medewerker van 15 jaar
	Dan wordt geen waarde gevonden