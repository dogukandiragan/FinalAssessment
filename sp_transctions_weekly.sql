create procedure sp_transctions_weekly
as
begin


select TOP (5) Customers.Name,  Customers.Surname, Customers.CallNumber, Count(Transactions.Id) as 'TotalTransaction',  sum(Transactions.price) as 'TotalPrice'
from Transactions inner join Customers on Transactions.UserId = Customers.Id
group by  Customers.Name,  Customers.Surname, Customers.CallNumber 
order by 'TotalTransaction' DESC




end




exec sp_transctions_weekly 
