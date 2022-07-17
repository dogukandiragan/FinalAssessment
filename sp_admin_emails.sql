create procedure sp_admin_emails
as
begin

select Email from  [FinalAssessment_DB].[dbo].[AspNetUsers] where Id = ( SELECT UserId
  FROM [FinalAssessment_DB].[dbo].[AspNetRoles] inner join [FinalAssessment_DB].[dbo].[AspNetUserRoles]
  on [AspNetRoles].Id = [AspNetUserRoles].RoleId where [AspNetRoles].NormalizedName='ADMIN')


end




exec sp_admin_emails 
