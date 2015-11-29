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
  `Status` INT NOT NULL DEFAULT 0,
  `Position` VARCHAR(45) NOT NULL DEFAULT "N/A"
);

-- -----------------------------------------------------
-- Table `Employee`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Employee` (
  `Id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `EmpNo` VARCHAR(10) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Password` varchar(40) DEFAULT NULL, -- SHA1 hashes are 40 chars
  `Admin` TINYINT(1) NOT NULL DEFAULT 0
);

-- -----------------------------------------------------
-- Table `registraion`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Registration` (
  `Id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `Comment` VARCHAR(255),
  `Date` DATETIME NOT NULL,
  `CommentHandled` BIT NOT NULL DEFAULT 0,
  `CarId` INT NOT NULL, FOREIGN KEY (CarId) REFERENCES Car(Id),
  `EmployeeId` INT NOT NULL, FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
  `Position` VARCHAR(45) NOT NULL DEFAULT "N/A"
);

-- -----------------------------------------------------
-- DEMO DATA
-- -----------------------------------------------------

INSERT INTO Car (Licenseplate, RouteNo, Hauler, Position) 
	VALUES
		("CF 96 237", "8806", "Ø", "Port 3"),
		("AA 10 559", "8807", "M", "Port 6"),
		("BW 97 791", "8808", "D", "Port 5"),
		("AT 33 059", "8809", "Ø", "At the main gate"),
		("BF 91 770", "8810", "Ø", "By the fence"),
		("AU 72 471", "8814", "D", "By the fence"), 
		("AA 10 840", "8815", "Ø", "Port 34"),
		("BG 93 709", "8815", "Ø", "Port 36"),
		("CG 93 673", "8816", "Ø", "Port 12");

INSERT INTO Employee (EmpNo, Name, Password, Admin) 
	VALUES 
		("123", "Leo Møller", "5f6955d227a320c7f1f6c7da2a6d96a851a8118f", 1);


INSERT INTO Employee (EmpNo, Name) 
	VALUES 
		("78087", "Thomas Due Andersen"),
		("78118", "Rasmus Bessing"),
		("78102", "Morten Kjær Pedersen"),
		("78112", "Mads Petersen"),
		("78120", "Kristian Bilde Højlund"), 
		("78184", "Frederik Thomsen"),
		("78067", "Amaury Montaufier");

INSERT INTO Registration (Date, CarId, Position, EmployeeId, Comment, CommentHandled)
	VALUES
		('2015-11-14 12:12', 3, "Port 5", 3, NULL, 0),
		('2015-11-27 16:21', 3, "Port 5", 3, "Hængsler på bilen er i stykker, hvilket gør det svært at bakke bilen til, når det blæser. Dørene blæser hele tiden i", 0);
	
