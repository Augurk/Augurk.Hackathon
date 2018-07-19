# Augurk Hackathon
Deze repository bevat een voorbeeld project ten behoeve van de Augurk Hackathon op 28 juli 2018 in De Lik, Utrecht.

## Context
Augurk is een living documentation systeem dat gebruikt kan worden in combinatie met Specification By Example. Augurk biedt momenteel een verzamelplek voor alle documentatie geschreven in Gherkin feature files zodat de business de documentatie kan inzien, zonder in allerlei versie beheer systemen te hoeven kijken. Daarnaast biedt Augurk een aantal features om het lezen van feature files prettiger te maken, zoals het inklappen van scenario's en tabellen en ondersteund het Markdown voor het opmaken van tekst.

Doormiddel van deze hackathon willen we Augurk nog meer waarde laten toevoegen, door niet alleen de documentatie makkelijk beschikbaar te maken, maar ook de onderlinge verbanden tussen features inzichtelijk te maken. Hiervoor is reeds een statische analyse tool ontwikkelt om aan de hand van code de onderlinge verbanden te vinden. De volgende stap is om dat ook visueel te maken, zodat gebruikers van Augurk bijvoorbeeld kunnen inzien welke andere features van het systeem gebruik maken van een bepaalde feature, of andersom welke andere features een bepaalde feature gebruikt.

## Voorbeeld project
Het voorbeeld project bestaat uit twee losse Visual Studio solutions, die een onderlinge afhankelijkheid van elkaar hebben. Deze solutions beschreven respectievelijk een implementatie van de Arbeidstijdenwet (ATW) en een Rooster module die gebruik maakt ATW om te controleren of geroosterde diensten wel passen binnen die wet.

Voor het ATW gedeelte zijn de volgende features geschreven en geïmplementeerd:
- Controleer ATW
- Controleer maximale arbeidstijd per dag
- Controleer verplichte rustperiode
- Leeftijdsgebonden inrichting

Daarbij maakt de **Controleer ATW** feature gebruik van de twee onderliggende ATW regels **Controleer maximale arbeidstijd per dag** en **Controleer verplichte rustperiode**. Die twee regels maken weer gebruik van de **Leeftijdsgebonden inrichting** feature.

De rooster functionaliteit bestaat uit slechts twee features, die beiden gebruik maken van de **Controleer ATW** feature:
- Rooster Dienst In
- Verwijder dienst

## Voor eerste gebruik
Om enige data te krijgen om te visualiseren, volg de volgende stappen:

1. Clone de **Augurk** repository: git clone https://github.com/augurk/Augurk
2. Open **Augurk.sln** in Visual Studio en zorg er voor dat de solution **bouwt**
3. Start Augurk zonder debuggen zodat de webserver draait

4. Clone de **Augurk.Hackathon** repository: git clone https://github.com/augurk/Augurk.Hackathon
5. Open **ATW.sln** in een nieuwe instantie van Visual Studio (sluit niet Augurk, want dan stopt de webserver)
6. Zorg er voor dat de solution **bouwt**
7. Gebruik **publish.cmd** <url-naar-augurk> om de feature files te publiceren naar Augurk.
8. Gebruik **analyze.cmd** <url-naar-augurk> om de analyze uit te voeren en de resultaten te uploaden naar Augurk.
9. Vraag de data op via <url-naar-augurk>/api/v2/dependencies

De data zou vergelijkbaar moeten zijn met de volgende output:

```json
[
    {
        "featureName": "Rooster Dienst In",
        "productName": "Rooster",
        "version": "0.0.0",
        "tags": [],
        "dependsOn": [
            {
                "featureName": "Controleer ATW",
                "productName": "ATW",
                "version": "0.0.0",
                "tags": [],
                "dependsOn": [
                    {
                        "featureName": "Controleer maximale arbeidstijd per dag",
                        "productName": "ATW",
                        "version": "0.0.0",
                        "tags": [],
                        "dependsOn": [
                            {
                                "featureName": "Leeftijdsgebonden inrichting",
                                "productName": "ATW",
                                "version": "0.0.0",
                                "tags": [],
                                "dependsOn": []
                            }
                        ]
                    },
                    {
                        "featureName": "Controleer verplichte rustperiode",
                        "productName": "ATW",
                        "version": "0.0.0",
                        "tags": [],
                        "dependsOn": [
                            {
                                "featureName": "Leeftijdsgebonden inrichting",
                                "productName": "ATW",
                                "version": "0.0.0",
                                "tags": [],
                                "dependsOn": []
                            }
                        ]
                    },
                    {
                        "featureName": "Leeftijdsgebonden inrichting",
                        "productName": "ATW",
                        "version": "0.0.0",
                        "tags": [],
                        "dependsOn": []
                    }
                ]
            }
        ]
    },
    {
        "featureName": "Verwijder dienst",
        "productName": "Rooster",
        "version": "0.0.0",
        "tags": [],
        "dependsOn": [
            {
                "featureName": "Controleer ATW",
                "productName": "ATW",
                "version": "0.0.0",
                "tags": [],
                "dependsOn": [
                    {
                        "featureName": "Controleer maximale arbeidstijd per dag",
                        "productName": "ATW",
                        "version": "0.0.0",
                        "tags": [],
                        "dependsOn": [
                            {
                                "featureName": "Leeftijdsgebonden inrichting",
                                "productName": "ATW",
                                "version": "0.0.0",
                                "tags": [],
                                "dependsOn": []
                            }
                        ]
                    },
                    {
                        "featureName": "Controleer verplichte rustperiode",
                        "productName": "ATW",
                        "version": "0.0.0",
                        "tags": [],
                        "dependsOn": [
                            {
                                "featureName": "Leeftijdsgebonden inrichting",
                                "productName": "ATW",
                                "version": "0.0.0",
                                "tags": [],
                                "dependsOn": []
                            }
                        ]
                    },
                    {
                        "featureName": "Leeftijdsgebonden inrichting",
                        "productName": "ATW",
                        "version": "0.0.0",
                        "tags": [],
                        "dependsOn": []
                    }
                ]
            }
        ]
    }
]
```