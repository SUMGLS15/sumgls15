USE glsoverviewdb;
DROP TABLE IF EXISTS `registraion`;
DROP TABLE IF EXISTS `car`;
DROP TABLE IF EXISTS `employee`;

-- -----------------------------------------------------
-- Table `car`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Car` (
  `CarID` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `Licenseplate` INT NOT NULL,
  `RouteNr` VARCHAR(45) NULL,
  `Hauler` VARCHAR(45) NULL,
  `Status` INT NOT NULL
);

-- -----------------------------------------------------
-- Table `employee`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Employee` (
  `EmployeeID` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `EmployeeNumber` VARCHAR(45) NOT NULL,
  `EmployeeName` VARCHAR(45) NOT NULL,
  `Admin` TINYINT(1) NULL DEFAULT 0
);

-- -----------------------------------------------------
-- Table `registraion`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `Registration` (
  `RegistraionID` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `RegistrationDate` DATETIME NULL,
  `RegistrationComment` VARCHAR(255),
  `Registraion_carID` INT NOT NULL, FOREIGN KEY (registraion_carID) REFERENCES Car(carID),
  `Registraion_employeeID` INT NOT NULL, FOREIGN KEY (registraion_employeeID) REFERENCES Employee(employeeID)
);
