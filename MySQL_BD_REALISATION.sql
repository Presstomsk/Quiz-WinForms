CREATE TABLE tab_user
(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  login VARCHAR(100) NOT NULL,
  password VARCHAR(100) NOT NULL,
  date_of_birth DATE NOT NULL
);



CREATE TABLE tab_log
(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  login VARCHAR(100) NOT NULL,
  date  DATETIME NOT NULL,
  test_name VARCHAR(50) NOT NULL,
  score INT NOT NULL
);