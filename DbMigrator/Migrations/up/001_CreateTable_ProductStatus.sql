CREATE TABLE IF NOT EXISTS store.ProductStatus (
	Id INT UNSIGNED auto_increment NOT NULL,
	Name varchar(100) NOT NULL,
	Description VARCHAR(100) NULL,
	CONSTRAINT ProductStatus_pk PRIMARY KEY (Id),
	CONSTRAINT ProductStatus_unique_name UNIQUE KEY (Name)
)
ENGINE=InnoDB
DEFAULT CHARSET=utf8mb4
COLLATE=utf8mb4_general_ci;
