
-- Stored Procedure GetListaJogadores e como Ordenar
CREATE PROCEDURE Scouting.GetListaJogadores (@IdadeList varchar(3), @OrderBy varchar(50))

AS
	
		DECLARE @SQLStatement varchar(300)
		IF(LEN(@IdadeList)=0 AND LEN(@OrderBy)>0 )
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM Scouting.Jogador ORDER BY ' + @OrderBy;
			EXEC(@SQLStatement)
			END
		IF (LEN(@OrderBy)=0 AND LEN(@IdadeList)>0)
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM Scouting.Jogador WHERE Scouting.Jogador.Lista_Idade_Maxima =' + @IdadeList;
			EXEC(@SQLStatement)
			END
		IF(LEN(@OrderBy) =0 AND LEN(@IdadeList)=0)
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM Scouting.Jogador'
			EXEC(@SQLStatement)
			END
		IF(LEN(@OrderBy)>0 AND LEN(@IdadeList)>0)
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM Scouting.Jogador WHERE Scouting.Jogador.Lista_Idade_Maxima =' + @IdadeList +
			' ORDER BY ' + @OrderBy;
			EXEC(@SQLStatement)
			END


	EXEC Scouting.GetListaJogadores '15','IDADE'
	DROP procedure Scouting.GetListaJogadores


--Stored Procedure Obter Posi��es Jogadores
CREATE PROCEDURE Scouting.GetPosicoesByJogador @ID varchar(30)
AS
SELECT Scouting.Jog_Posicoes.Jog_Posicoes_ID_FIFPro, Scouting.Jog_Posicoes.J_Posicoes FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro WHERE Scouting.Jogador.ID_FIFPro=@ID;

EXEC Scouting.GetPosicoesByJogador 8
Drop procedure Scouting.GetPosicoesByJogador


-- Stored Procedure Obter Relat�rios Jogador
Create Procedure Scouting.GetRelatorioByJogador @ID varchar(9)
AS
	SELECT Scouting.Relatorio.* FROM Scouting.Relatorio where ID_FIFPro=@ID 

EXEC Scouting.GetRelatorioByJogador 8
Drop procedure Scouting.GetRelatorioByJogador


--Obter Dados completos Relatorio
Select *from (Scouting.Relatorio Join  ( (Scouting.Analise_Caracteristica_Jogador join Scouting.Metricas_Jogo_Jogador on Scouting.Metricas_Jogo_Jogador.Rel_ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID)) on ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID) join Scouting.Jogo on (Jogo.Jogo_Local=Relatorio.Jogo_Local And Jogo.Jogo_Data=Relatorio.Jogo_Data) WHERE ID_FIFPro=8

--  Stored Procedure Obter Dados completos Relatorio
Create Procedure Scouting.GetRelatorioData @ID varchar(9)
AS
	Select *from (Scouting.Relatorio Join  ( (Scouting.Analise_Caracteristica_Jogador join Scouting.Metricas_Jogo_Jogador on Scouting.Metricas_Jogo_Jogador.Rel_ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID)) on ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID) join Scouting.Jogo on (Jogo.Jogo_Local=Relatorio.Jogo_Local And Jogo.Jogo_Data=Relatorio.Jogo_Data) WHERE Relatorio.ID=@ID
EXEC Scouting.GetRelatorioData '12'
--SELECT * From Scouting.Relatorio;


-- Stored Procedure Obter Listas
Create Procedure Scouting.Get_Listas_Observacao_Selecao
AS
	Begin
	SELECT * FROM Scouting.Lista_Observacao_Selecao
	End
Exec Scouting.Get_Listas_Observacao_Selecao

-- Stored Procedure Obter Clubes Ordenados
Create Procedure Scouting.Get_Lista_Clubes @OrderBy varchar(80)
AS
	DECLARE @SQLStatement varchar(300)
		IF(LEN(@OrderBy)>0 )
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM Scouting.Clube ORDER BY ' + @OrderBy;
			EXEC(@SQLStatement)
			END
		IF (LEN(@OrderBy)=0)
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM Scouting.Clube';
			EXEC(@SQLStatement)
			END
EXEC Scouting.Get_Lista_Clubes 'Scouting.Clube.Clube_Nome';
DROP PROCEDURE Scouting.Get_Lista_Clubes;

-- Stored Procedure Obter Jogadores por Clubes
Create Procedure Scouting.Get_Jogadores_By_Clube @Club_ID varchar(80)
AS
	DECLARE @SQLStatement varchar(300)
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM (Scouting.Jogador JOIN Scouting.Jogador_Pertence_Clube ON Jogador.ID_FIFPro=Jogador_Pertence_Clube.ID_FIFPro)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA =' + @Club_ID;
			EXEC(@SQLStatement)
			END
		IF (LEN(@Club_ID)=0)
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM (Scouting.Jogador JOIN Scouting.Jogador_Pertence_Clube ON Jogador.ID_FIFPro=Jogador_Pertence_Clube.ID_FIFPro)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA';
			EXEC(@SQLStatement)
			END
EXEC Scouting.Get_Jogadores_By_Clube 2

-- Stored Procedure Obter Treinadores por Clubes
Create Procedure Scouting.Get_Treinadores_By_Clube @Club_ID varchar(9)
AS
	DECLARE @SQLStatement varchar(300)
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM (Scouting.Treinador JOIN Scouting.Treina ON Treinador.Treinador_Numero_Inscricao_FIFA=Treina_Num_Insc_FIFA)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Treina.Clube_Num_insc_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA =' + @Club_ID;
			EXEC(@SQLStatement)
			END
		IF (LEN(@Club_ID)=0)
			BEGIN
			SELECT @SQLStatement= 'SELECT * FROM (Scouting.Treinador JOIN Scouting.Treina ON Treinador.Treinador_Numero_Inscricao_FIFA=Treina_Num_Insc_FIFA)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Treina.Clube_Num_insc_FIFA';
			EXEC(@SQLStatement)
			END
EXEC Scouting.Get_Treinadores_By_Clube 2
DROP PROCEDURE Scouting.Get_Treinadores_By_Clube

-- Stored Procedure Obter Competicoes por Clubes
SELECT Scouting.Clube.* FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Competicao.Competicao_ID_FIFA=Inscrito_Em.Ins_Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Inscrito_Em.Ins_Clube_Numero_Inscricao_FIFA
SELECT * FROM Scouting.Inscrito_Em
Create Procedure Scouting.Get_Competicoes_By_Clube @Club_ID varchar(9)
AS
	DECLARE @SQLStatement varchar(400)
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT @SQLStatement= 'SELECT Scouting.Clube.* FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Competicao.Competicao_ID_FIFA=Inscrito_Em.Ins_Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Inscrito_Em.Ins_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA =' + @Club_ID;
			EXEC(@SQLStatement)
			END
		IF (LEN(@Club_ID)=0)
			BEGIN
			SELECT @SQLStatement= 'SELECT Scouting.Clube.* FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Competicao.Competicao_ID_FIFA=Inscrito_Em.Ins_Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Inscrito_Em.Ins_Clube_Numero_Inscricao_FIFA';
			EXEC(@SQLStatement)
			END
EXEC Scouting.Get_Competicoes_By_Clube 1
DROP PROCEDURE Scouting.Get_Competicoes_By_Clube

-- Stored Procedure Obter Jogos por Clubes
--------------------------------------------------------------------------------------------


SELECT * FROM Scouting.Clube;
-- Jogador e Clube a que pertence
SELECT Jogador_Nome,Clube_Nome FROM   Scouting.Jogador JOIN (Scouting.Jogador_Pertence_Clube join Scouting.Clube ON Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Scouting.Clube.Clube_Numero_Inscricao_FIFA ) ON Scouting.Jogador.ID_FIFPRO = Scouting.Jogador_Pertence_Clube.ID_FIFPRO

--Observador e Jogadores que fez relatorios
SELECT * From Scouting.Jogador join (Scouting.Relatorio join Scouting.Observador on  Scouting.Relatorio.Numero_Identificacao_Federacao=Scouting.Observador.Numero_Identificacao_Federacao) on Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro

--Jogadores e lista de sele��o
SELECT *FROM Scouting.Lista_Observacao_Selecao join Scouting.Jogador on (Scouting.Lista_Observacao_Selecao.Lista_Idade_Maxima=Scouting.Jogador.Lista_Idade_Maxima)

--Equipas e Jogo
SELECT *FROM Scouting.Participa_Em join Scouting.Clube on Scouting.Participa_Em.Participa_Clube_Numero_Inscricao_FIFA = Scouting.Clube.Clube_Numero_Inscricao_FIFA

--Clubes que treinou treina
SELECT Scouting.Treinador.Treinador_Nome, Scouting.Clube.Clube_Nome, Treinador_Data_Inicio, Treinador_Data_Saida FROM Scouting.Treinador join Scouting.Treina on Scouting.Treina.Treina_Num_Insc_FIFA= Scouting.Treinador.Treinador_Numero_Inscricao_FIFA join Scouting.Clube on Scouting.Treina.Clube_Num_insc_FIFA =Scouting.Clube.Clube_Numero_Inscricao_FIFA

--Jogador com certa qualidade
SELECT * FROM (Scouting.Jogador JOIN Scouting.Relatorio ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro)
				JOIN Scouting.Analise_Caracteristica_Jogador ON Scouting.Analise_Caracteristica_Jogador.Rel_ID=Scouting.Relatorio.ID
				WHERE Scouting.Analise_Caracteristica_Jogador.Qualidade_Atual>70 AND Scouting.Analise_Caracteristica_Jogador.Capacidade_Decisao>80;
--Jogador e Respetivas Posi��es
SELECT * FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro WHERE J_Posicoes='MC';