USE glsoverviewdb;

DROP TABLE IF EXISTS `Registration`;
DROP TABLE IF EXISTS `Car`;
DROP TABLE IF EXISTS `Employee`;

-- default is for some reason offset=2, increment=10
SET @@auto_increment_offset=1;
SET @@auto_increment_increment=1;

-- -----------------------------------------------------
-- Table `Car`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Car` (
  `Id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `Licenseplate` VARCHAR(20) NOT NULL,
  `RouteNo` VARCHAR(45) NULL,
  `Hauler` VARCHAR(45) NULL,
  `Status` INT NOT NULL,
  `Position` VARCHAR(45) NOT NULL DEFAULT "N/A"
);

-- -----------------------------------------------------
-- Table `Employee`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Employee` (
  `Id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `EmpNo` VARCHAR(10) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Password` varchar(40), -- SHA1 hashes are 40 chars
  `Admin` TINYINT(1) NOT NULL DEFAULT 0
);

-- -----------------------------------------------------
-- Table `registraion`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Registration` (
  `Id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `Comment` VARCHAR(255),
  `Date` DATETIME NOT NULL,
  `CommentHandled` BIT DEFAULT 0,
  `CarId` INT NOT NULL, FOREIGN KEY (CarId) REFERENCES Car(Id),
  `EmployeeId` INT NOT NULL, FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
  `Position` VARCHAR(45) NOT NULL DEFAULT "N/A"
);

-- -----------------------------------------------------
-- DEMO DATA
-- -----------------------------------------------------

INSERT INTO Car (Licenseplate, RouteNo, Hauler, Status, Position) 
	VALUES
		("AA 12 123", "8000", "Ø", 0, "Port 3"),
		("BB 12 123", "9000", "M", 1, "Port 6"),
		("CC 12 123", "8240", "D", 2, "Port 5"),
		("DD 12 123", "8210", "Ø", 0, "At the main gate"),
		("EE 12 123", "8800", "Ø", 1, "By the fence"),
		("FF 12 123", "8801", "D", 1, "By the fence");

INSERT INTO Employee (EmpNo, Name, Password, Admin) 
	VALUES 
		("123", "Leo Møller", "5f6955d227a320c7f1f6c7da2a6d96a851a8118f", 1),
		("234", "Morten KP", NULL, 0),
		("987", "SvendK", NULL, 0),
		("567", "Kim de Vos", NULL, 0),
		("652", "Palle", NULL, 0),
		("852", "Polle", NULL, 0),
		("373", "Ruth", NULL, 0),
		("834", "Piotr", NULL, 0);

INSERT INTO Registration (Comment, Date, CommentHandled, CarId, EmployeeId, Position)
	VALUES
		(NULL, '2015-11-14 12:00', 0, 3, 3, "Port 5")
	
-- Test data for registringer?