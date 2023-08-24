CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE restaurants(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(100) NOT NULL,
  imgUrl VARCHAR(500) NOT NULL,
  description VARCHAR(300) NOT NULL,
  visits INT NOT NULL DEFAULT 0,
  isShutdown BOOLEAN DEFAULT false,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';


INSERT INTO restaurants(name, imgUrl, description, creatorId)
VALUES ('CodFather', 'https://i.pinimg.com/1200x/43/fd/c1/43fdc1ff85c1d25872521d40e11ccd0c.jpg', 'Do you believe in cod? Because I reely trout it exists', '64e5595bb2e0f21b5b0b0254')