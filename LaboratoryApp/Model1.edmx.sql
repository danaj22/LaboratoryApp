
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/18/2015 10:24:54
-- Generated from EDMX file: C:\Users\daniel\Documents\Visual Studio 2013\Projects\LaboratoryApp\LaboratoryApp\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [laboratory];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_calibrators_model_of_gauges_calibrators1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[calibrators_model_of_gauges] DROP CONSTRAINT [FK_calibrators_model_of_gauges_calibrators1];
GO
IF OBJECT_ID(N'[dbo].[FK_calibrators_model_of_gauges_model_of_gauges]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[calibrators_model_of_gauges] DROP CONSTRAINT [FK_calibrators_model_of_gauges_model_of_gauges];
GO
IF OBJECT_ID(N'[dbo].[FK_certificates_gauges]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[certificates] DROP CONSTRAINT [FK_certificates_gauges];
GO
IF OBJECT_ID(N'[dbo].[FK_gauges_clients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gauges] DROP CONSTRAINT [FK_gauges_clients];
GO
IF OBJECT_ID(N'[dbo].[FK_gauges_model_of_gauges]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gauges] DROP CONSTRAINT [FK_gauges_model_of_gauges];
GO
IF OBJECT_ID(N'[dbo].[FK_gauges_offices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gauges] DROP CONSTRAINT [FK_gauges_offices];
GO
IF OBJECT_ID(N'[dbo].[FK_gauges_types]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[model_of_gauges] DROP CONSTRAINT [FK_gauges_types];
GO
IF OBJECT_ID(N'[dbo].[FK_gauges_usage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[model_of_gauges] DROP CONSTRAINT [FK_gauges_usage];
GO
IF OBJECT_ID(N'[dbo].[FK_offices_clients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[offices] DROP CONSTRAINT [FK_offices_clients];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[calibrators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[calibrators];
GO
IF OBJECT_ID(N'[dbo].[calibrators_model_of_gauges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[calibrators_model_of_gauges];
GO
IF OBJECT_ID(N'[dbo].[certificates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[certificates];
GO
IF OBJECT_ID(N'[dbo].[clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[clients];
GO
IF OBJECT_ID(N'[dbo].[functions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[functions];
GO
IF OBJECT_ID(N'[dbo].[gauges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gauges];
GO
IF OBJECT_ID(N'[dbo].[model_of_gauges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[model_of_gauges];
GO
IF OBJECT_ID(N'[dbo].[offices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[offices];
GO
IF OBJECT_ID(N'[dbo].[types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[types];
GO
IF OBJECT_ID(N'[dbo].[usages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usages];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'model_of_gauges'
CREATE TABLE [dbo].[model_of_gauges] (
    [model_of_gaugeId] int IDENTITY(1,1) NOT NULL,
    [manufacturer_name] nvarchar(50)  NOT NULL,
    [model] nvarchar(50)  NOT NULL,
    [usage_id] int  NOT NULL,
    [type_id] int  NOT NULL
);
GO

-- Creating table 'clients'
CREATE TABLE [dbo].[clients] (
    [clientId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [adress] nvarchar(150)  NULL,
    [contact_person_name] nvarchar(70)  NULL,
    [mail] nvarchar(70)  NULL,
    [tel] nvarchar(15)  NULL,
    [NIP] nvarchar(15)  NOT NULL,
    [comments] nvarchar(500)  NULL
);
GO

-- Creating table 'gauges'
CREATE TABLE [dbo].[gauges] (
    [gaugeId] int IDENTITY(1,1) NOT NULL,
    [serial_number] nvarchar(100)  NOT NULL,
    [client_id] int  NOT NULL,
    [office_id] int  NULL,
    [model_of_gauge_id] int  NOT NULL
);
GO

-- Creating table 'certificates'
CREATE TABLE [dbo].[certificates] (
    [certifacateId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NULL,
    [date] datetime  NULL,
    [cost] real  NULL,
    [authorized_by] nvarchar(50)  NULL,
    [gauge_id] int  NOT NULL
);
GO

-- Creating table 'types'
CREATE TABLE [dbo].[types] (
    [typeId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'usages'
CREATE TABLE [dbo].[usages] (
    [usageId] int IDENTITY(1,1) NOT NULL,
    [description] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'offices'
CREATE TABLE [dbo].[offices] (
    [officeId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [adress] nvarchar(150)  NULL,
    [contact_person_name] nvarchar(70)  NULL,
    [mail] nvarchar(70)  NULL,
    [tel] nvarchar(15)  NULL,
    [is_default] nvarchar(10)  NULL,
    [client_id] int  NOT NULL
);
GO

-- Creating table 'calibrators'
CREATE TABLE [dbo].[calibrators] (
    [calibratorId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(300)  NOT NULL,
    [model_of_gauge_id] int  NULL
);
GO

-- Creating table 'calibrators_model_of_gauges'
CREATE TABLE [dbo].[calibrators_model_of_gauges] (
    [calibrator_modelId] int IDENTITY(1,1) NOT NULL,
    [calibrator_id] int  NULL,
    [model_of_gaug_id] int  NULL
);
GO

-- Creating table 'functions'
CREATE TABLE [dbo].[functions] (
    [functionId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(150)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [model_of_gaugeId] in table 'model_of_gauges'
ALTER TABLE [dbo].[model_of_gauges]
ADD CONSTRAINT [PK_model_of_gauges]
    PRIMARY KEY CLUSTERED ([model_of_gaugeId] ASC);
GO

-- Creating primary key on [clientId] in table 'clients'
ALTER TABLE [dbo].[clients]
ADD CONSTRAINT [PK_clients]
    PRIMARY KEY CLUSTERED ([clientId] ASC);
GO

-- Creating primary key on [gaugeId] in table 'gauges'
ALTER TABLE [dbo].[gauges]
ADD CONSTRAINT [PK_gauges]
    PRIMARY KEY CLUSTERED ([gaugeId] ASC);
GO

-- Creating primary key on [certifacateId] in table 'certificates'
ALTER TABLE [dbo].[certificates]
ADD CONSTRAINT [PK_certificates]
    PRIMARY KEY CLUSTERED ([certifacateId] ASC);
GO

-- Creating primary key on [typeId] in table 'types'
ALTER TABLE [dbo].[types]
ADD CONSTRAINT [PK_types]
    PRIMARY KEY CLUSTERED ([typeId] ASC);
GO

-- Creating primary key on [usageId] in table 'usages'
ALTER TABLE [dbo].[usages]
ADD CONSTRAINT [PK_usages]
    PRIMARY KEY CLUSTERED ([usageId] ASC);
GO

-- Creating primary key on [officeId] in table 'offices'
ALTER TABLE [dbo].[offices]
ADD CONSTRAINT [PK_offices]
    PRIMARY KEY CLUSTERED ([officeId] ASC);
GO

-- Creating primary key on [calibratorId] in table 'calibrators'
ALTER TABLE [dbo].[calibrators]
ADD CONSTRAINT [PK_calibrators]
    PRIMARY KEY CLUSTERED ([calibratorId] ASC);
GO

-- Creating primary key on [calibrator_modelId] in table 'calibrators_model_of_gauges'
ALTER TABLE [dbo].[calibrators_model_of_gauges]
ADD CONSTRAINT [PK_calibrators_model_of_gauges]
    PRIMARY KEY CLUSTERED ([calibrator_modelId] ASC);
GO

-- Creating primary key on [functionId] in table 'functions'
ALTER TABLE [dbo].[functions]
ADD CONSTRAINT [PK_functions]
    PRIMARY KEY CLUSTERED ([functionId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [client_id] in table 'gauges'
ALTER TABLE [dbo].[gauges]
ADD CONSTRAINT [FK_gauges_clients]
    FOREIGN KEY ([client_id])
    REFERENCES [dbo].[clients]
        ([clientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gauges_clients'
CREATE INDEX [IX_FK_gauges_clients]
ON [dbo].[gauges]
    ([client_id]);
GO

-- Creating foreign key on [model_of_gauge_id] in table 'gauges'
ALTER TABLE [dbo].[gauges]
ADD CONSTRAINT [FK_gauges_model_of_gauges]
    FOREIGN KEY ([model_of_gauge_id])
    REFERENCES [dbo].[model_of_gauges]
        ([model_of_gaugeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gauges_model_of_gauges'
CREATE INDEX [IX_FK_gauges_model_of_gauges]
ON [dbo].[gauges]
    ([model_of_gauge_id]);
GO

-- Creating foreign key on [gauge_id] in table 'certificates'
ALTER TABLE [dbo].[certificates]
ADD CONSTRAINT [FK_certificates_gauges]
    FOREIGN KEY ([gauge_id])
    REFERENCES [dbo].[gauges]
        ([gaugeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_certificates_gauges'
CREATE INDEX [IX_FK_certificates_gauges]
ON [dbo].[certificates]
    ([gauge_id]);
GO

-- Creating foreign key on [type_id] in table 'model_of_gauges'
ALTER TABLE [dbo].[model_of_gauges]
ADD CONSTRAINT [FK_gauges_types]
    FOREIGN KEY ([type_id])
    REFERENCES [dbo].[types]
        ([typeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gauges_types'
CREATE INDEX [IX_FK_gauges_types]
ON [dbo].[model_of_gauges]
    ([type_id]);
GO

-- Creating foreign key on [usage_id] in table 'model_of_gauges'
ALTER TABLE [dbo].[model_of_gauges]
ADD CONSTRAINT [FK_gauges_usage]
    FOREIGN KEY ([usage_id])
    REFERENCES [dbo].[usages]
        ([usageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gauges_usage'
CREATE INDEX [IX_FK_gauges_usage]
ON [dbo].[model_of_gauges]
    ([usage_id]);
GO

-- Creating foreign key on [client_id] in table 'offices'
ALTER TABLE [dbo].[offices]
ADD CONSTRAINT [FK_offices_clients]
    FOREIGN KEY ([client_id])
    REFERENCES [dbo].[clients]
        ([clientId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_offices_clients'
CREATE INDEX [IX_FK_offices_clients]
ON [dbo].[offices]
    ([client_id]);
GO

-- Creating foreign key on [office_id] in table 'gauges'
ALTER TABLE [dbo].[gauges]
ADD CONSTRAINT [FK_gauges_offices]
    FOREIGN KEY ([office_id])
    REFERENCES [dbo].[offices]
        ([officeId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gauges_offices'
CREATE INDEX [IX_FK_gauges_offices]
ON [dbo].[gauges]
    ([office_id]);
GO

-- Creating foreign key on [calibrator_id] in table 'calibrators_model_of_gauges'
ALTER TABLE [dbo].[calibrators_model_of_gauges]
ADD CONSTRAINT [FK_calibrators_model_of_gauges_calibrators1]
    FOREIGN KEY ([calibrator_id])
    REFERENCES [dbo].[calibrators]
        ([calibratorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_calibrators_model_of_gauges_calibrators1'
CREATE INDEX [IX_FK_calibrators_model_of_gauges_calibrators1]
ON [dbo].[calibrators_model_of_gauges]
    ([calibrator_id]);
GO

-- Creating foreign key on [model_of_gaug_id] in table 'calibrators_model_of_gauges'
ALTER TABLE [dbo].[calibrators_model_of_gauges]
ADD CONSTRAINT [FK_calibrators_model_of_gauges_model_of_gauges]
    FOREIGN KEY ([model_of_gaug_id])
    REFERENCES [dbo].[model_of_gauges]
        ([model_of_gaugeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_calibrators_model_of_gauges_model_of_gauges'
CREATE INDEX [IX_FK_calibrators_model_of_gauges_model_of_gauges]
ON [dbo].[calibrators_model_of_gauges]
    ([model_of_gaug_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------