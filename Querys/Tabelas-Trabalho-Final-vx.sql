use Proj;

CREATE SCHEMA Scouting;
GO

CREATE TABLE Scouting.Jogador (
	ID_FIFPro varchar(9) PRIMARY KEY,
	Jogador_Nome varchar(50) NOT NULL,
	Jogador_Altura float NOT NULL,
	Jogador_Peso float NOT NULL,
	Pe_Favorito bit,
	Idade int NOT NULL CHECK(Idade>0),
	Dupla_Nacionalidade bit,
	Numero_Internacionalizacoes int,
	Lista_Idade_Maxima int ,
	CHECK (Idade <= Lista_Idade_Maxima),
	CHECK (Dupla_Nacionalidade >= 0)
	--FOREIGN KEY Lista_Idade_Maxima REFERENCES Scouting.Lista_Observacao_Selecao(Lista_Idade_Maxima);
);

CREATE TABLE Scouting.Relatorio(
	ID INT IDENTITY(0,1) PRIMARY KEY,
	Relatorio_Titulo varchar(50)  NOT NULL,
	Relatorio_Data date  NOT NULL,
	Numero_Identificacao_Federacao varchar(9),
	ID_FIFPro varchar(9),
	Jogo_Local varchar(100),
	Jogo_Data date,
	--UNIQUE(Numero_Identificacao_Federacao),
	--UNIQUE(ID_FIFPro)
	--FOREIGN KEY Numero_Identificacao_Federacao REFERENCES Scouting.Observador(Numero_Identificacao_Federacao),
	--FOREIGN KEY Jogo_Local REFERENCES Scouting.Jogo(Jogo_Local),
	--FOREIGN KEY ID_FIFPro REFERENCES Scouting.Jogador(ID_FIFPro),
	--FOREIGN KEY data_jogo REFERENCES Scouting.Jogo(Jogo_Data);
);

CREATE TYPE Dados_Value from INT NOT NULL;

CREATE TABLE Scouting.Analise_Caracteristica_Jogador(
	ID_Auto_Carateristicas int IDENTITY(0,1) PRIMARY KEY,
	Rel_ID int,
	Qualidade_Atual Dados_Value CHECK (Qualidade_Atual>0 AND Qualidade_Atual<=100),
	Qualidade_Potencial Dados_Value CHECK (Qualidade_Potencial>0 AND Qualidade_Potencial <=100), 
	Melhor_Atributo varchar(50),
	Etica_Trabalho varchar(50),
	Determinacao Dados_Value CHECK (Determinacao>0 AND Determinacao <=100),
	Capacidade_Decisao Dados_Value CHECK(Capacidade_Decisao>0 AND Capacidade_Decisao <=100),
	Nivel_Tecnica Dados_Value CHECK(Nivel_Tecnica>0 AND Nivel_Tecnica<=100),
	Obs_Num_Iden_Federacao varchar(9),
	--FOREIGN KEY Rel_ID REFERENCES Scouting.Relatorio(ID),
	--FOREIGN KEY Obs_Num_Iden_Federacao REFERENCES Scouting.Observador(Numero_Identificacao_Federacao),
	UNIQUE(Rel_ID),
	--UNIQUE(Obs_Num_Iden_Federacao)
	
);

CREATE TABLE Scouting.Metricas_Jogo_Jogador(
	ID_Auto_Metricas int IDENTITY(0,1) PRIMARY KEY,
	Numero_Golos Dados_Value,
	Rel_ID int,
	Numero_Assistencias Dados_Value,
	Numero_Passes_Efectuados Dados_Value,
	Numero_Passes_Completos Dados_Value,
	Numero_Cortes Dados_Value,
	Minutos_Jogados Dados_Value CHECK(Minutos_Jogados>=0 AND Minutos_Jogados <=120),
	Defesas_Realizadas Dados_Value,
	Distancia_Percorrida float,
	Numero_Toques Dados_Value,
	Numero_Dribles Dados_Value,
	Numero_Remates Dados_Value,
	Obs_Num_Iden_Federacao varchar(9),
	CHECK(Numero_Passes_Completos<Numero_Passes_Efectuados),
	CHECK(Numero_Assistencias<Numero_Passes_Completos),
	CHECK(Numero_Toques>Numero_Passes_Efectuados AND Numero_Toques>Numero_Remates),
	--UNIQUE(Obs_Num_Iden_Federacao),
	UNIQUE(Rel_ID),
	--FOREIGN KEY Rel_ID REFERENCES Scouting.Relatorio(ID),
	--FOREIGN KEY Obs_Num_Iden_Federacao REFERENCES Scouting.Observador(Numero_Identificacao_Federacao);
);

CREATE TABLE Scouting.Observador(
	Numero_Identificacao_Federacao varchar(9) PRIMARY KEY,
	Observador_Nome varchar(50) NOT NULL,
	Observador_Qualificações varchar(100) NOT NULL,
	Observador_Nacionalidade varchar(40) NOT NULL,
	Observador_Idade int NOT NULL CHECK(Observador_Idade>=18),
	Area_Observacao varchar(50) NOT NULL
);

CREATE TABLE Scouting.Lista_Observacao_Selecao(
	Lista_Idade_Maxima int PRIMARY KEY,
	Lista_Nome varchar(30) NOT NULL
);

CREATE TABLE Scouting.Responsavel(
	Idade_Maxima int,
	Selec_Numero_Iden_Federacao varchar(9),
	Res_Data_Inicio date,
	Res_Data_Final date,
	CHECK(Res_Data_Final>Res_Data_Inicio)
);

CREATE TABLE Scouting.Jog_Posicoes(
	J_Posicoes varchar(30),
	Jog_Posicoes_ID_FIFPro varchar(9),
	--FOREIGN KEY Jog_Posicoes_ID_FIFPro REFERENCES Scouting.Jogador(ID_FIFPro);
	PRIMARY KEY (J_Posicoes,Jog_Posicoes_ID_FIFPro)
);

CREATE TABLE Scouting.Clube(
	Clube_Numero_Inscricao_FIFA varchar(9) PRIMARY KEY,
	Clube_Pais varchar(40) NOT NULL,
	Clube_Nome varchar(50) NOT NULL,
	
	--FOREIGN KEY (Clube_Treinador_Numero_Inscricao_FIFA) REFERENCES Scouting.Treinador(Treinador_Numero_Inscricao_FIFA);
);

CREATE TABLE Scouting.Treina(
	Treina_Num_Insc_FIFA varchar(9),
	Treinador_Data_Saida date,
	Treinador_Data_Inicio date,
	Clube_Num_insc_FIFA varchar(9),
	PRIMARY KEY(Treina_Num_Insc_FIFA,Clube_Num_insc_FIFA),
	CHECK(Treinador_Data_Saida>Treinador_Data_Inicio)
);

CREATE TABLE Scouting.Jogador_Pertence_Clube(
	JPC_Clube_Numero_Inscricao_FIFA varchar(9),
	ID_FIFPro varchar(9),
	Pertence_Data_Inicio date,
	Pertence_Data_Saida date,
	CHECK(Pertence_Data_Saida>Pertence_Data_Inicio),
	--FOREIGN KEY JPC_Clube_Numero_Inscricao_FIFA REFERENCES Scouting.Clube(Clube_Numero_Inscricao_FIFA),
	--FOREIGN KEY ID_FIFPro REFERENCES Scouting.Jogador(ID_FIFPro)
	PRIMARY KEY(JPC_Clube_Numero_Inscricao_FIFA,ID_FIFPro)
);

CREATE TABLE Scouting.Participa_Em(
	Participa_Clube_Numero_Inscricao_FIFA varchar(9),
	Participa_Em_Jogo_Data date,
	Participa_Em_Jogo_Local varchar(100),
	Participa_Em_Numero_Jogadores_Convocados int NOT NULL CHECK(Participa_Em_Numero_Jogadores_Convocados <= 23 AND Participa_Em_Numero_Jogadores_Convocados >= 11),
	--FOREIGN KEY Participa_Clube_Numero_Inscricao_FIFA REFERENCES Scouting.Clube(Clube_Numero_Inscricao_FIFA);
	--FOREIGN KEY Participa_Em_Jogo_Data REFERENCES Scouting.Jogo(Jogo_Data),
	--FOREIGN KEY Participa_Em_Jogo_Local REFERENCES Scouting.Jogo(Jogo_Local)
	PRIMARY KEY(Participa_Clube_Numero_Inscricao_FIFA,Participa_Em_Jogo_Data,Participa_Em_Jogo_Local)
);

CREATE TABLE Scouting.Observacao_Metodo_de_Observacao(
	Rel_Metodo_de_Observacao varchar(15),
	Rel_ID_Relatorio INT,
	--FOREIGN KEY Numero_Identificacao_Federacao REFERENCES Scouting.Relatorio(ID)
	PRIMARY KEY(Rel_Metodo_de_Observacao,Rel_ID_Relatorio)
);
DROP table Scouting.Observacao_Metodo_de_Observacao

CREATE TABLE Scouting.Selecionador(
	Selecionador_Numero_Identificacao_Federacao varchar(9) PRIMARY KEY,
	Selecionador_Nome varchar(50) NOT NULL,
	Selecionador_Qualificacao varchar(100) NOT NULL,
	Selecionador_Nacionalidade varchar(40) NOT NULL,
	Selecionador_Idade int NOT NULL CHECK(Selecionador_Idade >=18),
);


CREATE TABLE Scouting.Jogo(
	Jogo_Local varchar(100) Not null,
	Jogo_Data date Not Null,
	Resultado varchar(5) NOT NULL,
	Jogo_Competicao_ID_FIFA varchar(9),
	Obs_Num_Iden_Federacao varchar(9),
	--UNIQUE(Jogo_Local),
	--UNIQUE(Jogo_Data),
	PRIMARY KEY(Jogo_Local,Jogo_Data)
);
drop table Scouting.Jogo

CREATE TABLE Scouting.Treinador(
	Treinador_Numero_Inscricao_FIFA varchar(9) PRIMARY KEY,
	Treinador_Nome varchar(50) NOT NULL,
	Treinador_Qualificacao varchar(50) NOT NULL,
	Treinador_Idade int NOT NULL CHECK(Treinador_Idade >=18),
	Treinador_Nacionalidade varchar(40) NOT NULL
);

CREATE TABLE Scouting.Inscrito_Em(
	Ins_Clube_Numero_Inscricao_FIFA varchar(9),
	Ins_Competicao_ID_FIFA varchar(9),
	Numeros_Jogadores_Inscritos int NOT NULL,
	CHECK(Numeros_Jogadores_Inscritos >= 18),
	Data_Inscricao date NOT NULL,
	--FOREIGN KEY Ins_Competicao_ID_FIFA REFERENCES Scouting.Competicao(Competicao_ID_FIFA),
	--FOREIGN KEY Ins_Clube_Numero_Inscricao_FIFA REFERENCES Scouting.Clube(Clube_Numero_Inscricao_FIFA;
	PRIMARY KEY(Ins_Clube_Numero_Inscricao_FIFA,Ins_Competicao_ID_FIFA)
);

CREATE TABLE Scouting.Competicao(
	Competicao_ID_FIFA varchar(9) PRIMARY KEY,
	Competicao_Nome varchar(50) NOT NULL,
	Competicao_Numero_Equipas int NOT NULL,
	CHECK(Competicao_Numero_Equipas >=2)
);

--ALTERS PARA FK
ALTER TABLE Scouting.Jogador 
ADD FOREIGN KEY (Lista_Idade_Maxima) REFERENCES Scouting.Lista_Observacao_Selecao(Lista_Idade_Maxima);


ALTER TABLE Scouting.Relatorio
	ADD FOREIGN KEY (Numero_Identificacao_Federacao) REFERENCES Scouting.Observador(Numero_Identificacao_Federacao),
		FOREIGN KEY (Jogo_Local,Jogo_Data) REFERENCES Scouting.Jogo(Jogo_Local,Jogo_Data),
		FOREIGN KEY (ID_FIFPro) REFERENCES Scouting.Jogador(ID_FIFPro);
		--FOREIGN KEY (Jogo_Data) REFERENCES Scouting.Jogo(Jogo_Data);
--;


ALTER TABLE Scouting.Analise_Caracteristica_Jogador
	ADD FOREIGN KEY (Rel_ID) REFERENCES Scouting.Relatorio(ID),
		FOREIGN KEY (Obs_Num_Iden_Federacao) REFERENCES Scouting.Observador(Numero_Identificacao_Federacao)
;


ALTER TABLE Scouting.Metricas_Jogo_Jogador
	ADD FOREIGN KEY (Rel_ID) REFERENCES Scouting.Relatorio(ID),
		FOREIGN KEY (Obs_Num_Iden_Federacao) REFERENCES Scouting.Observador(Numero_Identificacao_Federacao)
;

ALTER TABLE Scouting.Jog_Posicoes
	ADD FOREIGN KEY (Jog_Posicoes_ID_FIFPro) REFERENCES Scouting.Jogador(ID_FIFPro)
;

ALTER TABLE Scouting.Jogador_Pertence_Clube
	ADD FOREIGN KEY (JPC_Clube_Numero_Inscricao_FIFA) REFERENCES Scouting.Clube(Clube_Numero_Inscricao_FIFA),
		FOREIGN KEY (ID_FIFPro) REFERENCES Scouting.Jogador(ID_FIFPro);

ALTER TABLE Scouting.Participa_Em
	ADD FOREIGN KEY (Participa_Clube_Numero_Inscricao_FIFA) REFERENCES Scouting.Clube(Clube_Numero_Inscricao_FIFA),
		FOREIGN KEY (Participa_Em_Jogo_Local,Participa_Em_Jogo_Data) REFERENCES Scouting.Jogo(Jogo_Local,Jogo_Data);
		--FOREIGN KEY (Participa_Em_Jogo_Local) REFERENCES Scouting.Jogo(Jogo_Local);

ALTER TABLE Scouting.Observacao_Metodo_de_Observacao
	ADD FOREIGN KEY (Rel_ID_Relatorio) REFERENCES Scouting.Relatorio(ID);


ALTER TABLE Scouting.Jogo
	ADD FOREIGN KEY (Jogo_Competicao_ID_FIFA) REFERENCES Scouting.Competicao(Competicao_ID_FIFA),
		FOREIGN KEY (Obs_Num_Iden_Federacao) REFERENCES Scouting.Observador(Numero_Identificacao_Federacao)
;


ALTER TABLE Scouting.Inscrito_Em
	ADD FOREIGN KEY (Ins_Competicao_ID_FIFA) REFERENCES Scouting.Competicao(Competicao_ID_FIFA),
		FOREIGN KEY (Ins_Clube_Numero_Inscricao_FIFA) REFERENCES Scouting.Clube(Clube_Numero_Inscricao_FIFA);

ALTER TABLE Scouting.Clube
	ADD FOREIGN KEY (Clube_Numero_Inscricao_FIFA) REFERENCES Scouting.Treinador(Treinador_Numero_Inscricao_FIFA);

ALTER TABLE Scouting.Responsavel
	ADD FOREIGN KEY (Selec_Numero_Iden_Federacao) REFERENCES Scouting.Selecionador(Selecionador_Numero_Identificacao_Federacao),
	FOREIGN KEY(Idade_Maxima) REFERENCES Scouting.Lista_Observacao_Selecao(Lista_Idade_Maxima);

ALTER TABLE Scouting.Treina
	ADD FOREIGN KEY (Treina_Num_Insc_FIFA) REFERENCES Scouting.Treinador(Treinador_Numero_Inscricao_FIFA),
	FOREIGN KEY (Clube_Num_Insc_FIFA) REFERENCES Scouting.Clube(Clube_Numero_Inscricao_FIFA);