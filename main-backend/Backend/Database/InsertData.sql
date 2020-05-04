-- PATH:
-- \i 'D:/Users/Niklas/Documents/Workspace/WebDevelopment/Feuerwehr/Backend/Backend/Database/InsertData.sql'

-- ------------------------------------------------------------------- --
-- ------------------------- Tabellen leeren ------------------------- --
-- ------------------------------------------------------------------- --
DELETE FROM Engine;
DELETE FROM Classification;
DELETE FROM Crew;
DELETE FROM Client;
TRUNCATE TABLE Client RESTART IDENTITY CASCADE;
TRUNCATE TABLE Engine RESTART IDENTITY CASCADE;
TRUNCATE TABLE Classification RESTART IDENTITY CASCADE;
TRUNCATE TABLE Crew RESTART IDENTITY CASCADE;

-- ------------------------------------------------------------------- --
-- ------------------------- Tabellen füllen ------------------------- --
-- ------------------------------------------------------------------- --
INSERT INTO Client (ClientName, ClientPrename, ClientSurname, ClientPasswordHash, ClientPasswordSalt, ClientRole) 
VALUES ('nlampe', 'Niklas', 'Lampe', 'D1EF6E3212CF84CC2AFE69D31B61589CD06235F66504D7F4546BCAF0C262B8B526AB6184A66325AB953EDEFB5969FC43C3407E1F54C6F909AD1C86349A0B7282', 'Q5micj8IU40ApNjYb0vlSoNBKrWOrFwC6W2OuGl7wiqFOS36FF864JzIhlx6m4FN', 'God');



INSERT INTO Classification (ClassificationArt, ClassificationType)
VALUES 
('Löschgruppenfahrzeug', 'LF'),
('Tanklöschfahrzeug', 'TLF'),
('Schlauchwagen', 'SW'),
('Drehleiter mit Korb', 'DLK'),
('Mannschaftstransportfahrzeug', 'MTF'),
('Einsatzleitwagen', 'ELW'),
('Feuerwehranhänger Gefahrgut', 'FwA'),
('Feuerwehranhänger Boot', 'FwA'),
('Feuerwehranhänger Notstromaggregat', 'FwA');

INSERT INTO CREW (CrewValue) VALUES
('1/2/3'),
('1/8/9');

INSERT INTO Engine 
(EngineLicensePlate, EngineNumber,  EnginePs,  EngineCapacityCcm,  EngineCylinder, EngineConstructionYear, EngineLength,  EngineWidth,  EngineHight,  EngineRadioCall,  ClassificationId,  CrewId, EngineIsDeprecated)
VALUES 
('CLP-CX 186', 	'24/50',   345,   9500,     8,     1995,      7550,    2500,    3300,    '21-26-10',   2,      1, false),
('CLP-FF 210', 	'16/24',   220,   4801,     4,     2006,      6500,    2400,    3160,    '21-21-10',   2,      1, false),
('CLP-F 2146', 	'10',    218,   4801,     4,     2015,      6650,    2500,    3300,    '21-46-10',   1,      2, false),
('CLP-XT-20', 	'16',    264,    0,      8,     1900,       0,     0,    0,     '21-48-10',   1,      2, false),
('CLP-JD 370', 	'23-12',   264,   13383,     8,     1992,      9680,    2500,    3300,    '21-30-10',   4,      1, false),
('CLP-8508', 	'2000',   155,   5958,     6,     1995,      6950,    2500,    3000,    '21-62-10',   3,      1, false),
('CLP-F 2660', 	'1',    130,   2461,     4,     2009,      5290,    1904,    1990,    '21-11-10',   6,      2, false),
('CLP-F 2117',	NULL,    68,   1896,     4,     2000,      4707,    1840,    1920,    '21-17-10',   5,      2, true);
