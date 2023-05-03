CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

-- SECTION -- *Burgers*
CREATE TABLE IF NOT EXISTS burgers(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL,
  buns INT NOT NULL,
  patties INT NOT NULL,
  cheeseSlices INT DEFAULT 0,
  onions BOOLEAN DEFAULT true,
  pickles BOOLEAN DEFAULT false,
  ketchup BOOLEAN DEFAULT true,
  checkedOut BOOLEAN DEFAULT false,
  specialRequest VARCHAR(500) DEFAULT '',

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8mb4 COMMENT '';

-- SECTION -- *Drinks*
CREATE TABLE IF NOT EXISTS drinks(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL,
  flavor VARCHAR(255) NOT NULL,
  size VARCHAR(20) NOT NULL,
  checkedOut BOOLEAN DEFAULT false,

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8mb4 COMMENT '';

-- SECTION -- *Fries*
CREATE TABLE IF NOT EXISTS fries(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  creatorId VARCHAR(255),
  type VARCHAR(255) NOT NULL,
  size VARCHAR(20) NOT NULL,
  checkedOut BOOLEAN DEFAULT false,

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8mb4 COMMENT '';