# RUN PROJECT

## RUN COMMAND
``` cmd
docker compose up -d 
``` 
## RUN SCRIPT
``` sql
CREATE DATABASE [TestDb]
GO

USE [TestDb];
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [People] (
    [Id] uniqueidentifier NOT NULL,
    [LastName] Nvarchar(50) NULL,
    [FirstName] Nvarchar(50) NULL,
    CONSTRAINT [PK_People] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PersonSalaries] (
    [Id] uniqueidentifier NOT NULL,
    [Tax] decimal(18,2) NOT NULL,
    [Salary] decimal(18,2) NOT NULL,
    [Allowance] decimal(18,2) NOT NULL,
    [BasicSalary] decimal(18,2) NOT NULL,
    [Transportation] decimal(18,2) NOT NULL,
    [Date] datetime2 NOT NULL,
    [OverTimeCalculator] Char(11) NULL,
    [PersonId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PersonSalaries] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PersonSalaries_People_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [People] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_PersonSalaries_Date_PersonId] ON [PersonSalaries] ([Date], [PersonId]);
GO

CREATE INDEX [IX_PersonSalaries_PersonId] ON [PersonSalaries] ([PersonId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230202122451_init', N'7.0.2');
GO

COMMIT;
GO

```


# CREATE PERSON SALARY  SAMPLE

## Custom DataType Sample
``` json
{
  "data": "FirstName/LastName/BasicSalary/Allowance/Transportation/Date\nAli/Ahmadi/1200000/400000/350000/14010801",
  "overTimeCalculator": "calculatora"
}
```


## Xml DataType Sample
``` json
{
  "data": "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><root><FirstName>Ali</FirstName><LastName>Ahmadi</LastName><Allowance>400000</Allowance><BasicSalary>1200000</BasicSalary><Transportation>350000</Transportation><Date>14010801</Date></root>",
  "overTimeCalculator": "calculatora"
}


```

## Json DataType Sample
``` json
{
  "data": "{\"FirstName\": \"Ali\",\"LastName\": \"Ahmadi\",\"Allowance\":400000,\"BasicSalary\": 1200000,\"Transportation\": 350000,\"Date\": 14010801}",
  "overTimeCalculator": "calculatora"
}


```
