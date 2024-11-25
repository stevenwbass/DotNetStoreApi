CREATE TABLE if not exists `product_variant` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NULL,
  `Price` decimal(10,2) NULL,
  `ProductStatusId` int(10) unsigned DEFAULT NULL,
  `parent_product_id` int(10) unsigned not null,
  `CreatedBy` varchar(100) NOT NULL,
  `CreatedOn` timestamp NOT NULL DEFAULT current_timestamp(),
  `UpdatedBy` varchar(100) NOT NULL,
  `UpdatedOn` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`),
  KEY `Product_productstatus_FK` (`ProductStatusId`),
  CONSTRAINT `Product_variant_productstatus_FK` FOREIGN KEY (`ProductStatusId`) REFERENCES `productstatus` (`Id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;