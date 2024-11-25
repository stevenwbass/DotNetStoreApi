CREATE TABLE IF NOT EXISTS `product_category` (
  `ProductId` int(10) unsigned NOT NULL,
  `CategoryId` int(10) unsigned NOT NULL,
  KEY `product_category_product_FK` (`ProductId`),
  KEY `product_category_category_FK` (`CategoryId`),
  CONSTRAINT `product_category_category_FK` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `product_category_product_FK` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;