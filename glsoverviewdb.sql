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
  `PortNo` INT NOT NULL DEFAULT -1
);

-- -----------------------------------------------------
-- Table `Employee`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Employee` (
  `Id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `EmpNo` VARCHAR(10) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Password` varchar(20),
  `Admin` TINYINT(1) NULL DEFAULT 0
);

-- -----------------------------------------------------
-- Table `registraion`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Registration` (
  `Id` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `Date` DATETIME NULL,
  `Comment` VARCHAR(255),
  `CarId` INT NOT NULL, FOREIGN KEY (CarId) REFERENCES Car(Id),
  `EmployeeId` INT NOT NULL, FOREIGN KEY (EmployeeId) REFERENCES Employee(Id)
);

-- -----------------------------------------------------
-- DEMO DATA
-- -----------------------------------------------------

INSERT INTO Car (Licenseplate, RouteNo, Hauler, Status) 
	VALUES ("AA12123", "8000", "Ø", 0);
INSERT INTO Car (Licenseplate, RouteNo, Hauler, Status) 
	VALUES ("BB12123", "9000", "M", 1);
INSERT INTO Car (Licenseplate, RouteNo, Hauler, Status) 
	VALUES ("CC12123", "8240", "D", 2);
INSERT INTO Car (Licenseplate, RouteNo, Hauler, Status) 
	VALUES ("DD12123", "8210", "Ø", 0);
INSERT INTO Car (Licenseplate, RouteNo, Hauler, Status) 
	VALUES ("EE12123", "8800", "Ø", 1);

INSERT INTO Employee (EmpNo, Name, Password, Admin) 
	VALUES ("123", "Leo Møller", "321", 1);
INSERT INTO Employee (EmpNo, Name, Password, Admin) 
	VALUES ("234", "Morten KP", NULL, 0);
INSERT INTO Employee (EmpNo, Name, Password, Admin) 
	VALUES ("987", "SvendDK", NULL, 0);
INSERT INTO Employee (EmpNo, Name, Password, Admin)  
	VALUES ("567", "Kim de Vos", NULL, 0);
