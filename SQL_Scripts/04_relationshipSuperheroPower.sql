CREATE TABLE SuperheroPower (
SuperheroID int,
PowerID int,
PRIMARY KEY (SuperheroID, PowerID),

FOREIGN KEY (SuperheroID) REFERENCES Superhero(ID),
FOREIGN KEY (PowerID) REFERENCES Power(ID)

);