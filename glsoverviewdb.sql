USE glsoverviewdb;
DROP TABLE IF EXISTS `Registration`;
DROP TABLE IF EXISTS `car`;
DROP TABLE IF EXISTS `employee`;

-- -----------------------------------------------------
-- Table `car`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Car` (
  `CarID` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `Licenseplate` VARCHAR(20) NOT NULL,
  `RouteNr` VARCHAR(45) NULL,
  `Hauler` VARCHAR(45) NULL,
  `Status` INT NOT NULL
);

-- -----------------------------------------------------
-- Table `employee`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Employee` (
  `EmployeeID` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `EmployeeNumber` VARCHAR(10) NOT NULL,
  `EmployeeName` VARCHAR(45) NOT NULL,
  `Password` varchar(20),
  `Admin` TINYINT(1) NULL DEFAULT 0
);

-- -----------------------------------------------------
-- Table `registraion`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Registration` (
  `RegistraionID` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `RegistrationDate` DATETIME NULL,
  `RegistrationComment` VARCHAR(255),
  `Registration_carID` INT NOT NULL, FOREIGN KEY (Registration_carID) REFERENCES Car(carID),
  `Registration_employeeID` INT NOT NULL, FOREIGN KEY (Registration_employeeID) REFERENCES Employee(employeeID)
);

-- -----------------------------------------------------
-- DEMO DATA
-- -----------------------------------------------------

INSERT INTO Car (Licenseplate, RouteNr, Hauler, Status) VALUES ("AA-12-123", "8000", "Ø", 0);
INSERT INTO Car (Licenseplate, RouteNr, Hauler, Status) VALUES ("BB-12-123", "9000", "M", 1);
INSERT INTO Car (Licenseplate, RouteNr, Hauler, Status) VALUES ("CC-12-123", "8240", "D", 2);
INSERT INTO Car (Licenseplate, RouteNr, Hauler, Status) VALUES ("DD-12-123", "8210", "Ø", 0);
INSERT INTO Car (Licenseplate, RouteNr, Hauler, Status) VALUES ("EE-12-123", "8800", "Ø", 1);

INSERT INTO Employee (EmployeeNumber, EmployeeName, Password, Admin) VALUES ("123", "Leo Møller", "321", 1);
INSERT INTO Employee (EmployeeNumber, EmployeeName, Password, Admin) VALUES ("234", "Morten KP", NULL, 0);
INSERT INTO Employee (EmployeeNumber, EmployeeName, Password, Admin) VALUES ("987", "SvendDK", NULL, 0);
INSERT INTO Employee (EmployeeNumber, EmployeeName, Password, Admin) VALUES ("567", "Kim de Vos", NULL, 0);
