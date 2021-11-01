--Criação da tabela Planetas 
CREATE TABLE Planetas(
	IdPlaneta int NOT NULL,
	Nome varchar(50) NOT NULL,
	Rotacao float NOT NULL,
	Orbita float NOT NULL,
	Diametro float NOT NULL,
	Clima varchar(50) NOT NULL,
	Populacao int NOT NULL,

)
GO --Indica o final de uma sessão e o início de outra

ALTER TABLE Planetas ADD CONSTRAINT PK_Planetas PRIMARY KEY (IdPlaneta);
Go

--Criação da tabela Piloto
CREATE TABLE Pilotos(
	IdPiloto int not null,
	Nome varchar(200) not null,
	AnoNascimento varchar(10) not null,
	IdPlaneta int not null,
)
go
alter table Pilotos add constraint PK_Pilotos primary key (IdPiloto);
go
alter table Pilotos add constraint PK_Pilotos_Planetas foreign key(IdPlaneta)
references Planetas (IdPlaneta)
go


--Criação da Tabela PilotoNaves
create table PilotoNaves(
	IdPiloto int not null,
	IdNave int not null,
	FlagAutorizado bit not null,
)
alter table PilotoNaves add constraint PK_PilotoNaves primary key (IdPiloto, IdNave);
go
alter table PilotoNaves add constraint FK_PilotoNaves_Piloto foreign key(IdPiloto)
references Pilotos (IdPiloto)
go
alter table PilotoNaves add constraint FK_PilotosNaves_Naves foreign key(IdNave)
references Naves (IdNave)
go
alter table PilotoNaves add constraint DF_PilotoNaves_FlagAutorizado default (1) for FlagAutorizado

--Criação da Tabela de Histórico de Viagens
create table HistoricoViagens(
	IdNave int not null,
	IdPiloto int not null,
	DtSaida datetime not null,
	DtChegada datetime null
)
go

alter table HistoricoViagens add constraint FK_HistoricoViagens_PilotosNaves foreign key(IdPiloto, IdNave)
references PilotoNaves (IdPiloto, IdNave)
go
alter table HistoricoViagens check constraint FK_HistoricoViagens_PilotosNaves