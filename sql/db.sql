CREATE TABLE IF NOT EXISTS `User` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FullName` longtext,
  `CPF` longtext,
  `EMAIL` longtext,
  `TELEFONE` longtext,
  `SEXO` char(1),
  `NACIONALIDADE` longtext,
  `ESTADO` longtext,
  `CIDADE` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB;