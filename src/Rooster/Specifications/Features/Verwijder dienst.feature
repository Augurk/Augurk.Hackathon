Functionaliteit: Verwijder dienst

Scenario: Eerder ingeroosterde dienst wordt verwijderd

	Stel de volgende diensten zijn reeds ingeroosterd
    | Dag     | Start tijd | Eind tijd |
    | Maandag | 08:00      | 12:00     |
    | Dinsdag | 12:00      | 16:00     |
	Als de dienst van 12:00 tot 16:00 op dinsdag wordt verwijderd
	Dan zijn de volgende diensten ingeroosterd
    | Dag     | Start tijd | Eind tijd |
    | Maandag | 08:00      | 12:00     |