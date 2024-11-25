CREATE TABLE IF NOT EXISTS store.product (
	Id INT UNSIGNED auto_increment NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Price DECIMAL(10,2) NOT NULL,
	ProductStatusId INTEGER UNSIGNED NULL,
	CreatedBy varchar(100) NOT NULL,
	CreatedOn TIMESTAMP DEFAULT now() NOT NULL,
	UpdatedBy varchar(100) NOT NULL,
	UpdatedOn TIMESTAMP DEFAULT now() NOT NULL,
	primary key (Id),
	CONSTRAINT Product_unique_name UNIQUE KEY (Name),
	CONSTRAINT Product_productstatus_FK FOREIGN KEY (ProductStatusId) REFERENCES store.productstatus(Id) ON DELETE SET NULL
)
ENGINE=InnoDB
DEFAULT CHARSET=utf8mb4
COLLATE=utf8mb4_general_ci;
