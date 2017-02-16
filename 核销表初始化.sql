/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2017/2/15 23:01:56                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('City') and o.name = 'FK_CITY_REFERENCE_CITY')
alter table City
   drop constraint FK_CITY_REFERENCE_CITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MatchDetail') and o.name = 'FK_MATCHDET_REFERENCE_RULE')
alter table MatchDetail
   drop constraint FK_MATCHDET_REFERENCE_RULE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PoliceInsurance') and o.name = 'FK_POLICEIN_REFERENCE_INSURANC')
alter table PoliceInsurance
   drop constraint FK_POLICEIN_REFERENCE_INSURANC
go

if exists (select 1
            from  sysobjects
           where  id = object_id('City')
            and   type = 'U')
   drop table City
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GoldTemp')
            and   type = 'U')
   drop table GoldTemp
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Insurance')
            and   type = 'U')
   drop table Insurance
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MYResult')
            and   type = 'U')
   drop table MYResult
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MatchDetail')
            and   type = 'U')
   drop table MatchDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PoliceAccountNature')
            and   type = 'U')
   drop table PoliceAccountNature
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PoliceInsurance')
            and   type = 'U')
   drop table PoliceInsurance
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"Rule"')
            and   type = 'U')
   drop table "Rule"
go

drop schema dbo
go

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
create schema dbo
go

/*==============================================================*/
/* Table: City                                                  */
/*==============================================================*/
create table City (
   Id                   nvarchar(36)         not null,
   Cit_Id               nvarchar(36)         null,
   Name                 nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   State                nvarchar(200)        null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        null,
   Vertion              int                  null,
   constraint PK_CITY primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('City')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'City', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', @CurrentUser, 'table', 'City', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('City')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'City', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'City', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('City')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'City', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'City', 'column', 'UpdateTime'
go

/*==============================================================*/
/* Table: GoldTemp                                              */
/*==============================================================*/
create table GoldTemp (
   Id                   nvarchar(36)         not null,
   Name                 nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   State                nvarchar(200)        null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        null,
   Vertion              int                  null,
   constraint PK_GOLDTEMP primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('GoldTemp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'GoldTemp', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', @CurrentUser, 'table', 'GoldTemp', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('GoldTemp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'GoldTemp', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'GoldTemp', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('GoldTemp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'GoldTemp', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'GoldTemp', 'column', 'UpdateTime'
go

/*==============================================================*/
/* Table: Insurance                                             */
/*==============================================================*/
create table Insurance (
   Id                   nvarchar(36)         not null,
   Name                 nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   State                nvarchar(200)        null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        null,
   Vertion              int                  null,
   constraint PK_INSURANCE primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Insurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Insurance', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', @CurrentUser, 'table', 'Insurance', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Insurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Insurance', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'Insurance', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Insurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Insurance', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'Insurance', 'column', 'UpdateTime'
go

/*==============================================================*/
/* Table: MYResult                                              */
/*==============================================================*/
create table MYResult (
   Id                   nvarchar(36)         not null,
   Result               nvarchar(200)        null,
   GoldTempId           nvarchar(36)         null,
   GoldTempPath         nvarchar(200)        null,
   StandardTemp         nvarchar(200)        null,
   InsuranceId          nvarchar(36)         null,
   Style                nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   State                nvarchar(200)        null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        null,
   Vertion              int                  null,
   constraint PK_MYRESULT primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MYResult')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MYResult', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', @CurrentUser, 'table', 'MYResult', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MYResult')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MYResult', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'MYResult', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MYResult')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MYResult', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'MYResult', 'column', 'UpdateTime'
go

/*==============================================================*/
/* Table: MatchDetail                                           */
/*==============================================================*/
create table MatchDetail (
   Id                   nvarchar(36)         not null,
   Name                 nvarchar(200)        null,
   RuleId               nvarchar(36)         null,
   ChangeMonth          int                  null,
   BaseExcel            int                  null,
   MatchExcel           int                  null,
   BaseMatch            nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   State                nvarchar(200)        null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        null,
   Vertion              int                  null,
   constraint PK_MATCHDETAIL primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MatchDetail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BaseMatch')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MatchDetail', 'column', 'BaseMatch'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '匹配项设定,对比项设定
   ',
   'user', @CurrentUser, 'table', 'MatchDetail', 'column', 'BaseMatch'
go

/*==============================================================*/
/* Table: PoliceAccountNature                                   */
/*==============================================================*/
create table PoliceAccountNature (
   Id                   nvarchar(36)         not null,
   Name                 nvarchar(200)        null,
   Style                nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   State                nvarchar(200)        null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        null,
   Vertion              int                  null,
   constraint PK_POLICEACCOUNTNATURE primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('PoliceAccountNature') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'PoliceAccountNature' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '本地城镇
   本地农村
   外地城镇
   外地农村', 
   'user', @CurrentUser, 'table', 'PoliceAccountNature'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceAccountNature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Style')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceAccountNature', 'column', 'Style'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', @CurrentUser, 'table', 'PoliceAccountNature', 'column', 'Style'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceAccountNature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceAccountNature', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', @CurrentUser, 'table', 'PoliceAccountNature', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceAccountNature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceAccountNature', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'PoliceAccountNature', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceAccountNature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceAccountNature', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'PoliceAccountNature', 'column', 'UpdateTime'
go

/*==============================================================*/
/* Table: PoliceInsurance                                       */
/*==============================================================*/
create table PoliceInsurance (
   Id                   nvarchar(36)         not null,
   Name                 nvarchar(200)        null,
   InsuranceId          nvarchar(36)         null,
   CityId               nvarchar(36)         null,
   PoliceAccountNatureId nvarchar(36)         null,
   InsuranceKindId      nvarchar(36)         null,
   StartTime            datetime             null,
   EndTime              datetime             null,
   MaxPayMonth          int                  null,
   InsuranceAdd         int                  null,
   PaymentFrequency     int                  null,
   InsuranceReduce      int                  null,
   CompanyPercent       decimal(18, 2)       null,
   EmployeePercent      decimal(18, 2)       null,
   CompanyLowestNumber  decimal(18, 2)       null,
   CompanyNumber        decimal(18, 2)       null,
   EmployeeNumber       decimal(18, 2)       null,
   EmployeeLowestNumber decimal(18, 2)       null,
   CompanyHighestNumber decimal(18, 2)       null,
   EmployeeHighestNumber decimal(18, 2)       null,
   LowWage              decimal(18, 2)       null,
   SocialWage           decimal(18, 2)       null,
   CompanySub           int                  null,
   CompanyDigit         int                  null,
   EmployeeSub          int                  null,
   EmployeeDigit        int                  null,
   IsDefault            nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   State                nvarchar(200)        null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        null,
   Vertion              int                  null,
   constraint PK_POLICEINSURANCE primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceInsurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CityId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'CityId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'CityId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceInsurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PoliceAccountNatureId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'PoliceAccountNatureId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'PoliceAccountNatureId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceInsurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InsuranceKindId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'InsuranceKindId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'DropDown',
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'InsuranceKindId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceInsurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CompanySub')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'CompanySub'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1：四舍五入，2：不进位，3：进位',
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'CompanySub'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceInsurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EmployeeSub')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'EmployeeSub'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1：四舍五入，2：不进位，3：进位',
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'EmployeeSub'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceInsurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceInsurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PoliceInsurance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'PoliceInsurance', 'column', 'UpdateTime'
go

/*==============================================================*/
/* Table: "Rule"                                                */
/*==============================================================*/
create table "Rule" (
   Id                   nvarchar(36)         not null,
   Name                 nvarchar(200)        null,
   Remark               nvarchar(4000)       null,
   State                nvarchar(200)        null,
   CreateTime           datetime             null,
   CreatePerson         nvarchar(200)        null,
   UpdateTime           datetime             null,
   UpdatePerson         nvarchar(200)        null,
   Vertion              int                  null,
   constraint PK_RULE primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('"Rule"') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Rule' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '规则设定页面', 
   'user', @CurrentUser, 'table', 'Rule'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Rule"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Rule', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ResearchDropDown',
   'user', @CurrentUser, 'table', 'Rule', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Rule"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Rule', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'Rule', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Rule"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Rule', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Research',
   'user', @CurrentUser, 'table', 'Rule', 'column', 'UpdateTime'
go

alter table City
   add constraint FK_CITY_REFERENCE_CITY foreign key (Cit_Id)
      references City (Id)
go

alter table MatchDetail
   add constraint FK_MATCHDET_REFERENCE_RULE foreign key (RuleId)
      references "Rule" (Id)
go

alter table PoliceInsurance
   add constraint FK_POLICEIN_REFERENCE_INSURANC foreign key (InsuranceId)
      references Insurance (Id)
go

