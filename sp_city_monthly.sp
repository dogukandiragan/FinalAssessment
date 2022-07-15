create procedure sp_city_monthly
as
begin


SELECT [City], count(*) as 'Count' FROM [FinalAssessment_DB].[dbo].[Customers] 
group by [City]  order by  Count DESC



end




exec sp_city_monthly 
