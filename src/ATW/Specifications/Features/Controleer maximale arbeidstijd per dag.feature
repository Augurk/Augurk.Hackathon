Functionaliteit: Controleer maximale arbeidstijd per dag
	Op basis van leeftijd mogen medewerkers niet langer dan x uur per dag werken. Deze ATW regel controleert of hieraan wordt voldaan.

Scenario: Maximale arbeidstijd per dag wordt overschreden

	Stel de medewerker is 18 jaar oud
	En de maximaal toegestane arbeidstijd vanaf 18 jaar is 8 uur
	En de medewerker heeft de volgende geroosterde uren
	| Dag     | Start tijd | Eind tijd |
	| Maandag | 08:00      | 21:00     |
	Als de controle "maximale arbeidstijd" wordt uitgevoerd
	Dan wordt de regel "maximale arbeidstijd" overschreden

Scenario: Maximale arbeidstijd per dag wordt niet overschreden

	Stel de medewerker is 18 jaar oud
	En de maximaal toegestane arbeidstijd vanaf 18 jaar is 8 uur
	En de medewerker heeft de volgende geroosterde uren
	| Dag     | Start tijd | Eind tijd |
	| Maandag | 08:00      | 12:00     |
	Als de controle "maximale arbeidstijd" wordt uitgevoerd
	Dan wordt de regel "maximale arbeidstijd" NIET overschreden

Scenario: Meerdere inrichtingen voor verschillende leeftijden

	Stel de medewerker is 16 jaar oud
	En de maximaal toegestane arbeidstijd vanaf 18 jaar is 8 uur
	Maar de maximaal toegestane arbeidstijd vanaf 16 jaar is 6 uur
	En de medewerker heeft de volgende geroosterde uren
	| Dag     | Start tijd | Eind tijd |
	| Maandag | 10:00      | 17:00     |
	Als de controle "maximale arbeidstijd" wordt uitgevoerd
	Dan wordt de regel "maximale arbeidstijd" overschreden