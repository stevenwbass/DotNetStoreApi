CREATE PROCEDURE store.sp_GetProducts(in productName varchar(100))
begin
	select
		p.*,
		pi.ImageId
	FROM Product p
	left join product_image pi on p.Id = pi.ProductId
	where (productName is null or p.Name like '%' + productName + '%');
end