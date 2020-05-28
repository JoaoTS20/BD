--Jogador e Respetivas Posições
SELECT * FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro WHERE J_Posicoes='MC';


SELECT * FROM Scouting.Clube;
-- Jogador e Clube a que pertence
SELECT Jogador_Nome,Clube_Nome FROM   Scouting.Jogador JOIN (Scouting.Jogador_Pertence_Clube join Scouting.Clube ON Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Scouting.Clube.Clube_Numero_Inscricao_FIFA ) ON Scouting.Jogador.ID_FIFPRO = Scouting.Jogador_Pertence_Clube.ID_FIFPRO

--Jogadores que pertencem a clube
--Nao sei se se faz por nome do clube ou id, mas é questao de mudar Scouting.Clube.Clube_Numero_Inscricao_FIFA para Clube_Nome
CREATE PROCEDURE Scouting.GetJogadoresByPosicao (@Clube varchar(50),@OrderBy varchar(70))
AS
	DECLARE @SQLquery varchar(500)
	IF(LEN(@Clube)>0 AND(@OrderBy)=0)
	BEGIN
		SELECT @SQLquery='SELECT Jogador_Nome,Clube_Nome FROM   Scouting.Jogador JOIN (Scouting.Jogador_Pertence_Clube join Scouting.Clube ON Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Scouting.Clube.Clube_Numero_Inscricao_FIFA ) ON Scouting.Jogador.ID_FIFPRO = Scouting.Jogador_Pertence_Clube.ID_FIFPRO
		WHERE Scouting.Clube.Clube_Numero_Inscricao_FIFA='''+@Clube+''' ORDER BY Scouting.Jogador.ID_FIFPro';
		EXEC @SQLquery;
	END
	IF(LEN(@Clube)>0 AND(@OrderBy)>0)
	BEGIN
		SELECT @SQLquery='SELECT Jogador_Nome,Clube_Nome FROM   Scouting.Jogador JOIN (Scouting.Jogador_Pertence_Clube join Scouting.Clube ON Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Scouting.Clube.Clube_Numero_Inscricao_FIFA ) ON Scouting.Jogador.ID_FIFPRO = Scouting.Jogador_Pertence_Clube.ID_FIFPRO
		WHERE Scouting.Clube.Clube_Numero_Inscricao_FIFA='''+@Clube+''' ORDER BY '+@OrderBy;
		EXEC @SQLquery;
	END
	IF(LEN(@Clube)=0 AND(@OrderBy)=0)
	BEGIN
		SELECT @SQLquery='SELECT Jogador_Nome,Clube_Nome FROM   Scouting.Jogador JOIN (Scouting.Jogador_Pertence_Clube join Scouting.Clube ON Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Scouting.Clube.Clube_Numero_Inscricao_FIFA ) ON Scouting.Jogador.ID_FIFPRO = Scouting.Jogador_Pertence_Clube.ID_FIFPRO
		ORDER BY Scouting.Jogador.ID_FIFPro';
		EXEC @SQLquery;
	END
	IF(LEN(@Clube)=0 AND(@OrderBy)>0)
	BEGIN
		SELECT @SQLquery='SELECT Jogador_Nome,Clube_Nome FROM   Scouting.Jogador JOIN (Scouting.Jogador_Pertence_Clube join Scouting.Clube ON Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Scouting.Clube.Clube_Numero_Inscricao_FIFA ) ON Scouting.Jogador.ID_FIFPRO = Scouting.Jogador_Pertence_Clube.ID_FIFPRO
		WHERE Scouting.Clube.Clube_Numero_Inscricao_FIFA ORDER BY '+@OrderBy;
		EXEC @SQLquery;
	END

	EXEC Scouting.GetJogadoresByPosicao 'FCP','Scouting.Jogador.ID_FIFPro'
	DROP PROCEDURE Scouting.GetJogadoresByPosicao

--Observador e Jogadores que fez relatórios
SELECT * From Scouting.Jogador join (Scouting.Relatorio join Scouting.Observador on  Scouting.Relatorio.Numero_Identificacao_Federacao=Scouting.Observador.Numero_Identificacao_Federacao) on Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro

--Jogadores e lista de seleção
SELECT *FROM Scouting.Lista_Observacao_Selecao join Scouting.Jogador on (Scouting.Lista_Observacao_Selecao.Lista_Idade_Maxima=Scouting.Jogador.Lista_Idade_Maxima)

--Equipas e Jogo
SELECT *FROM Scouting.Participa_Em join Scouting.Clube on Scouting.Participa_Em.Participa_Clube_Numero_Inscricao_FIFA = Scouting.Clube.Clube_Numero_Inscricao_FIFA

--Clubes que treinou treina
SELECT Scouting.Treinador.Treinador_Nome, Scouting.Clube.Clube_Nome, Treinador_Data_Inicio, Treinador_Data_Saida FROM Scouting.Treinador join Scouting.Treina on Scouting.Treina.Treina_Num_Insc_FIFA= Scouting.Treinador.Treinador_Numero_Inscricao_FIFA join Scouting.Clube on Scouting.Treina.Clube_Num_insc_FIFA =Scouting.Clube.Clube_Numero_Inscricao_FIFA

--Jogador com certa qualidade
SELECT * FROM (Scouting.Jogador JOIN Scouting.Relatorio ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro)
				JOIN Scouting.Analise_Caracteristica_Jogador ON Scouting.Analise_Caracteristica_Jogador.Rel_ID=Scouting.Relatorio.ID
				WHERE Scouting.Analise_Caracteristica_Jogador.Qualidade_Atual>70 AND Scouting.Analise_Caracteristica_Jogador.Capacidade_Decisao>80;

--Jogador e Respetivas Posições
CREATE PROCEDURE Scouting.GetJogadorByPosicao (@Posicao varchar(30), @OrderBy varchar(70))
AS

	DECLARE @Sql_Statement varchar(500)
	IF(LEN(@Posicao)=0 AND LEN(@OrderBy)=0)
		BEGIN
			SELECT @Sql_Statement='SELECT * FROM Scouting.Jogador';
			EXEC(@Sql_Statement)

		END
	IF(LEN(@Posicao)>0 AND LEN(@OrderBy)=0)
		BEGIN
			SELECT @Sql_Statement='SELECT * FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro WHERE Scouting.Jog_Posicoes.J_Posicoes='''+@Posicao+'''';
			EXEC(@Sql_Statement)		
		END
	IF(LEN(@Posicao)=0 AND LEN(@OrderBy)>0)
		BEGIN
			SELECT @Sql_Statement='SELECT * FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro ORDER BY '+@OrderBy;
			EXEC(@Sql_Statement)		
		END
	IF(LEN(@Posicao)>0 AND LEN(@OrderBy)>0)
		BEGIN
			SELECT @Sql_Statement='SELECT * FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro WHERE Scouting.Jog_Posicoes.J_Posicoes= '''+@Posicao+''' ORDER BY '+@OrderBy;
			EXEC(@Sql_Statement)		
		END

EXEC Scouting.GetJogadorByPosicao 'MC','Scouting.Jogador.Jogador_Nome'
DROP procedure Scouting.GetJogadorByPosicao


--GetListaJogadores e como Ordenar
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


--Obter Posições Jogadores
CREATE PROCEDURE Scouting.GetPosicoesByJogador @ID varchar(30)
AS
SELECT Scouting.Jog_Posicoes.Jog_Posicoes_ID_FIFPro, Scouting.Jog_Posicoes.J_Posicoes FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro WHERE Scouting.Jogador.ID_FIFPro=@ID;

EXEC Scouting.GetPosicoesByJogador 8
Drop procedure Scouting.GetPosicoesByJogador


--Obter Relatório Jogador
Create Procedure Scouting.GetRelatorioByJogador @ID varchar(9)
AS
	SELECT Scouting.Relatorio.* FROM Scouting.Relatorio where ID_FIFPro=@ID 

EXEC Scouting.GetRelatorioByJogador 8
Drop procedure Scouting.GetRelatorioByJogador