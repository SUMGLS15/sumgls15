USE glsoverviewdb;
DROP TABLE IF EXISTS `registraion`;
DROP TABLE IF EXISTS `car`;
DROP TABLE IF EXISTS `employee`;

-- -----------------------------------------------------
-- Table `car`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `car` (
  `carID` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `licenseplate` INT NOT NULL,
  `routeNr` VARCHAR(45) NULL,
  `hauler` VARCHAR(45) NULL,
  `status` INT NOT NULL
);

-- -----------------------------------------------------
-- Table `employee`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `employee` (
  `employeeID` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `employeeNumber` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `admin` TINYINT(1) NULL DEFAULT 0
);

-- -----------------------------------------------------
-- Table `registraion`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `registraion` (
  `registraionID` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `registrationDate` DATETIME NULL,
  `comment` VARCHAR(255),
  `registraion_carID` INT NOT NULL, FOREIGN KEY (registraion_carID) REFERENCES Car(carID),
  `registraion_employeeID` INT NOT NULL, FOREIGN KEY (registraion_employeeID) REFERENCES Employee(employeeID)
);
