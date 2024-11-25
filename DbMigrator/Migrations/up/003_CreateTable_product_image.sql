CREATE TABLE IF NOT EXISTS product_image (
  `ProductId` int(10) unsigned NOT NULL,
  `ImageId` int(10) unsigned NOT NULL,
  KEY `NewTable_product_FK` (`ProductId`),
  KEY `NewTable_image_FK` (`ImageId`),
  CONSTRAINT `NewTable_image_FK` FOREIGN KEY (`ImageId`) REFERENCES `image` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `NewTable_product_FK` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;