--Todo: Karthick Code Review
go
create procedure sp_getstockbyproductid
@ProductID bigint
as
begin
select * from Stock where ProductID = @ProductID
end
go