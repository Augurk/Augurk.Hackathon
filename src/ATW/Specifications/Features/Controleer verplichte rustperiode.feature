Functionaliteit: Controleer verplichte rustperiode
	Voor 16 en 17 jarige medewerkers geldt dat er een verplichte rustperiode is tussen diensten. Deze ATW regel controleert of hieraan wordt voldaan.

Scenario: Verplichte rustperiode wordt overschreden

	Stel de medewerker is 16 jaar oud
	En de niet werkbare tijden voor iemand van 16 of 17 jaar zijn van 23:00 tot 06:00
	En de medewerker heeft de volgende geroosterde uren
    | Dag     | Start tijd | Eind tijd |
    | Maandag | 20:00      | 23:15     |
	Als de controle "verplichte rustperiode" wordt uitgevoerd
	Dan wordt de regel "verplichte rustperiode" overschreden

Scenario: Verplichte rustperiode wordt niet overschreden

	Stel de medewerker is 18 jaar oud
	En de niet werkbare tijden voor iemand van 16 of 17 jaar zijn van 23:00 tot 06:00
	En de medewerker heeft de volgende geroosterde uren
    | Dag     | Start tijd | Eind tijd |
    | Maandag | 20:00      | 23:15     |
	Als de controle "verplichte rustperiode" wordt uitgevoerd
	Dan wordt de regel "verplichte rustperiode" NIET overschreden