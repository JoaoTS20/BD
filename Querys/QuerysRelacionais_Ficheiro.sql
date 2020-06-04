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


	--EXEC Scouting.GetListaJogadores '15','IDADE'
	--DROP procedure Scouting.GetListaJogadores


--Stored Procedure Obter Posi��es Jogadores
CREATE PROCEDURE Scouting.GetPosicoesByJogador @ID varchar(30)
AS
Begin
SELECT Scouting.Jog_Posicoes.Jog_Posicoes_ID_FIFPro, Scouting.Jog_Posicoes.J_Posicoes FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro WHERE Scouting.Jogador.ID_FIFPro=@ID;
End
--EXEC Scouting.GetPosicoesByJogador 8
--Drop procedure Scouting.GetPosicoesByJogador


-- Stored Procedure Obter Relat�rios Jogador
Create Procedure Scouting.GetRelatorioByJogador @ID varchar(9)
AS
	SELECT Scouting.Relatorio.* FROM Scouting.Relatorio where ID_FIFPro=@ID 

--EXEC Scouting.GetRelatorioByJogador 8
--Drop procedure Scouting.GetRelatorioByJogador


--  Stored Procedure Obter Dados completos Relatorio
Create Procedure Scouting.GetRelatorioData @ID varchar(9)
AS
	Select *from (Scouting.Relatorio Join  ( (Scouting.Analise_Caracteristica_Jogador join Scouting.Metricas_Jogo_Jogador on Scouting.Metricas_Jogo_Jogador.Rel_ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID)) on ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID) join Scouting.Jogo on (Jogo.Jogo_Local=Relatorio.Jogo_Local And Jogo.Jogo_Data=Relatorio.Jogo_Data) WHERE Relatorio.ID=@ID
--EXEC Scouting.GetRelatorioData '12'
--SELECT * From Scouting.Relatorio;



-- Stored Procedure Obter Clubes Ordenados ou não
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
			SELECT * FROM Scouting.Clube;
			END
--EXEC Scouting.Get_Lista_Clubes;
--DROP PROCEDURE Scouting.Get_Lista_Clubes;

-- Stored Procedure Obter Jogadores por Clubes
Create Procedure Scouting.Get_Jogadores_By_Clube @Club_ID varchar(80)
AS
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT * FROM (Scouting.Jogador JOIN Scouting.Jogador_Pertence_Clube ON Jogador.ID_FIFPro=Jogador_Pertence_Clube.ID_FIFPro)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA = @Club_ID;
			END
--EXEC Scouting.Get_Jogadores_By_Clube 2



-- Stored Procedure Obter Treinadores por Clubes
Create Procedure Scouting.Get_Treinadores_By_Clube @Club_ID varchar(9)
AS
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT * FROM (Scouting.Treinador JOIN Scouting.Treina ON Treinador.Treinador_Numero_Inscricao_FIFA=Treina_Num_Insc_FIFA)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Treina.Clube_Num_insc_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA =@Club_ID;
			END
--EXEC Scouting.Get_Treinadores_By_Clube 2
--DROP PROCEDURE Scouting.Get_Treinadores_By_Clube




-- Stored Procedure Obter Competicoes do Clubes
Create Procedure Scouting.Get_Competicoes_By_Clube @Club_ID varchar(9)
AS
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT * FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Competicao.Competicao_ID_FIFA=Inscrito_Em.Ins_Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Inscrito_Em.Ins_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA = @Club_ID;
			END
--EXEC Scouting.Get_Competicoes_By_Clube 2
--DROP PROCEDURE Scouting.Get_Competicoes_By_Clube


-- Stored Procedure Obter Jogos por Clubes
Create Procedure Scouting.Get_Jogos_By_Clube @Club_ID varchar(9)
AS
	DECLARE @SQLStatement varchar(400)
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT @SQLStatement= 'SELECT Scouting.Jogo.* FROM (Scouting.Jogo JOIN Scouting.Participa_Em ON Jogo.Jogo_Data = Participa_Em.Participa_Em_Jogo_Data AND Participa_Em.Participa_Em_Jogo_Local=Jogo.Jogo_Local) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Participa_Em.Participa_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA=' + @Club_ID;
			EXEC(@SQLStatement)
			END
		IF (LEN(@Club_ID)=0)
			BEGIN
			SELECT @SQLStatement= 'SELECT Scouting.Jogo.* FROM (Scouting.Jogo JOIN Scouting.Participa_Em ON Jogo.Jogo_Data = Participa_Em.Participa_Em_Jogo_Data AND Participa_Em.Participa_Em_Jogo_Local=Jogo.Jogo_Local) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Participa_Em.Participa_Clube_Numero_Inscricao_FIFA';
			EXEC(@SQLStatement)
			END
--EXEC Scouting.Get_Jogos_By_Clube 2
--DROP PROCEDURE Scouting.Get_Jogos_By_Clube


--Stored Procedure Adicionar Jogador 
Create Procedure Scouting.Add_Jogador (@ID_FIFPRO varchar(9), @Nome_Jog varchar(50), @Jog_Alt float,@Jog_Peso float,@Pe_Fav bit, @idade int, @Dup_Nac bit,@Num_Inter int,@List_Max int)
AS
	--DECLARE @SQLStat varchar(400)
	IF (LEN(@ID_FIFPRO)=0 OR LEN(@Nome_Jog)=0 OR LEN(@Jog_Alt)=0 OR LEN(@Jog_Peso)=0 OR LEN(@Pe_Fav)=0 OR LEN(@idade)=0 OR LEN(@Dup_Nac)=0 OR LEN(@Num_Inter)=0 OR LEN(@List_Max)=0)
	BEGIN
		--triguer até ou assim aqui acho eu
		RETURN
	END
	ELSE
	Begin
	INSERT INTO Scouting.Jogador Values (@ID_FIFPRO,@Nome_Jog,@Jog_Alt,@Jog_Peso,@Pe_Fav,@idade,@Dup_Nac,@Num_Inter,@List_Max);
	End

--EXEC Scouting.Add_Jogador 13,'Diogo Mota',1.45,55.5,0,15,1,3,15
--SELECT * FROM Scouting.Jogador;
--DROP PROCEDURE Scouting.Add_Jogador;

--------------------------------------------------------------------------------------------
DROP TRIGGER Scouting.AddPlayer

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

-- Obter Dados completos Relatorio
Select *from (Scouting.Relatorio Join  ( (Scouting.Analise_Caracteristica_Jogador join Scouting.Metricas_Jogo_Jogador on Scouting.Metricas_Jogo_Jogador.Rel_ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID)) on ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID) join Scouting.Jogo on (Jogo.Jogo_Local=Relatorio.Jogo_Local And Jogo.Jogo_Data=Relatorio.Jogo_Data) WHERE ID_FIFPro=8

SELECT Scouting.Clube.* FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Competicao.Competicao_ID_FIFA=Inscrito_Em.Ins_Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Inscrito_Em.Ins_Clube_Numero_Inscricao_FIFA
