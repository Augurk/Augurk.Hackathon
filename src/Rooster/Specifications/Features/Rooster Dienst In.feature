Functionaliteit: Rooster Dienst In
	Diensten kunnen op een dag worden ingeroosterd, waarbij de ATW regels gevalideerd worden.
	
Scenario: Voeg een dienst toe die de ATW regels niet overtreed

	Stel de volgende diensten zijn reeds ingeroosterd
	| Dag     | Start tijd | Eind tijd |
	| Maandag | 08:00      | 12:00     |
	| Dinsdag | 12:00      | 16:00     |
	Als ik een dienst van 16:00 tot 20:00 inrooster op Woensdag 
	Dan zijn de volgende diensten ingeroosterd
	| Dag      | Start tijd | Eind tijd |
	| Maandag  | 08:00      | 12:00     |
	| Dinsdag  | 12:00      | 16:00     |
	| Woensdag | 16:00      | 20:00     |
	En er zijn geen ATW regels overtreden

Scenario: Voeg een dienst toe die de ATW regels overtreed
	
	Stel de medewerker is 16 jaar oud
	En de niet werkbare tijden voor iemand van 16 of 17 jaar zijn van 23:00 tot 06:00
	En de volgende diensten zijn reeds ingeroosterd
	| Dag     | Start tijd | Eind tijd |
	| Maandag | 08:00      | 12:00     |
	| Dinsdag | 12:00      | 16:00     |
	Als ik een dienst van 05:00 tot 11:00 inrooster op Woensdag 
	Dan zijn de volgende diensten ingeroosterd
	| Dag      | Start tijd | Eind tijd |
	| Maandag  | 08:00      | 12:00     |
	| Dinsdag  | 12:00      | 16:00     |
	| Woensdag | 05:00      | 11:00     |
	Maar er zijn ATW regels overtreden