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


-- Stored Procedure Obter Jogador do Clube Atuais
Create Procedure Scouting.Get_JogadoresAtuais_By_Clube @Club_ID varchar(80)
AS
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT * FROM (Scouting.Jogador JOIN Scouting.Jogador_Pertence_Clube ON Jogador.ID_FIFPro=Jogador_Pertence_Clube.ID_FIFPro)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA = @Club_ID and Pertence_Data_Saida is null;
			END

--drop procedure Scouting.Get_JogadoresAtuais_By_Clube



--Stored Procedure Obter Jogador Passados do Clube
Create Procedure Scouting.Get_JogadoresPassado_By_Clube @Club_ID varchar(80)
AS
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT * FROM (Scouting.Jogador JOIN Scouting.Jogador_Pertence_Clube ON Jogador.ID_FIFPro=Jogador_Pertence_Clube.ID_FIFPro)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA = @Club_ID and Pertence_Data_Saida is not null;
			END

--drop procedure Scouting.Get_JogadoresPassado_By_Clube






-- Stored Procedure Obter Treinadores por Clubes
Create Procedure Scouting.Get_TreinadoresPassado_By_Clube @Club_ID varchar(9)
AS
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT * FROM (Scouting.Treinador JOIN Scouting.Treina ON Treinador.Treinador_Numero_Inscricao_FIFA=Treina_Num_Insc_FIFA)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Treina.Clube_Num_insc_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA =@Club_ID and Treinador_Data_Saida is not null ;
			END
--EXEC Scouting.Get_TreinadoresPassados_By_Clube 2
--DROP PROCEDURE Scouting.Get_TreinadoresPassados_By_Clube






-- Stored Procedure Obter Treinador Atual por Clubes
Create Procedure Scouting.Get_TreinadorAtual_By_Clube @Club_ID varchar(9)
AS
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT * FROM (Scouting.Treinador JOIN Scouting.Treina ON Treinador.Treinador_Numero_Inscricao_FIFA=Treina_Num_Insc_FIFA)JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Treina.Clube_Num_insc_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA =@Club_ID and Treinador_Data_Saida is null;
			END
--EXEC Scouting.Get_Treinadores_By_Clube 2
--DROP PROCEDURE Scouting.Get_TreinadorAtual_By_Clube







-- Stored Procedure Obter Competicoes do Clubes
Create Procedure Scouting.Get_Competicoes_By_Clube @Club_ID varchar(9)
AS
		IF(LEN(@Club_ID)>0 )
			BEGIN
			SELECT * FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Competicao.Competicao_ID_FIFA=Inscrito_Em.Ins_Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Inscrito_Em.Ins_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA = @Club_ID;
			END
--EXEC Scouting.Get_Competicoes_By_Clube 2
--DROP PROCEDURE Scouting.Get_Competicoes_By_Clube







-- Stored Procedure Obter Jogos do Clube todos ou só na comp. //AINDA NÃO TESTADA
Create Procedure Scouting.Get_Jogos_By_Clube @Club_ID varchar(9), @Comp_ID varchar(9)
AS
		IF(LEN(@Club_ID)>0 and LEN(@Comp_ID)>0 )
			BEGIN
			SELECT Scouting.Jogo.* FROM (Scouting.Jogo JOIN Scouting.Participa_Em ON Jogo.Jogo_Data = Participa_Em.Participa_Em_Jogo_Data AND Participa_Em.Participa_Em_Jogo_Local=Jogo.Jogo_Local) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Participa_Em.Participa_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA=@Club_ID and Jogo_Competicao_ID_FIFA=@Comp_ID; 
			END
 		IF (LEN(@Club_ID)>0 and LEN(@Comp_ID)=0)
			BEGIN
			SELECT Scouting.Jogo.* FROM (Scouting.Jogo JOIN Scouting.Participa_Em ON Jogo.Jogo_Data = Participa_Em.Participa_Em_Jogo_Data AND Participa_Em.Participa_Em_Jogo_Local=Jogo.Jogo_Local) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=Participa_Em.Participa_Clube_Numero_Inscricao_FIFA WHERE Clube.Clube_Numero_Inscricao_FIFA=@Club_ID;
			END
--EXEC Scouting.Get_Jogos_By_Clube 2,''
--DROP PROCEDURE Scouting.Get_Jogos_By_Clube









--Stored Procedure INSERIR CLUBES
create procedure Scouting.Insert_Clubes(@Clube_Numero_Inscricao varchar(9),@Clube_Pais varchar(40),@Clube_Nome varchar(50))
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Clube VALUES (@Clube_Numero_Inscricao,@Clube_Pais,@Clube_Nome);
				print ('Clube Inserido')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Inserir Clube', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END
	--EXEC Scouting.Insert_Clubes 2, 'Portugal', 'FCP'
	--Drop procedure Scouting.Insert_Clubes
















--Stored Procedure Inserir Observadores 
create procedure Scouting.Insert_Observador(@Numero_Identificacao_Federacao varchar(9),@Observador_Nome varchar(50),@Observador_Qualificacoes varchar(100), @Obsevador_Nacionalidade varchar(40),@Observador_Idade int, @Area_Obsevacao varchar(50))
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Observador VALUES (@Numero_Identificacao_Federacao,@Observador_Nome,@Observador_Qualificacoes, @Obsevador_Nacionalidade, @Observador_Idade, @Area_Obsevacao);
				print ('Observador Inserido')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Inserir Observador', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END
	--EXEC Scouting.Insert_Observador '1', 'Hugo', 'Nenhuma','tuga',19,'ALA'
	--Drop procedure Scouting.Inserir_Observador

--ST Inserir Relatório com os dados todos
















--Stored Procedure INSERIR Competicao
create procedure Scouting.Insert_Competicao(@Competicao_ID_FIFA varchar(9),@Competicao_Nome varchar(50),@Competicao_Numero_Equipas int)
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Competicao VALUES (@Competicao_ID_FIFA,@Competicao_Nome,@Competicao_Numero_Equipas);
				print ('Competição Inserida')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Inserir Competicão', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END
	--EXEC Scouting.Insert_Competicao 12,'liga max 2', 2
	--drop stored Scouting.Insert_Competicao










--Trigger Não ter mais de numero de equipas inscritas
CREATE TRIGGER LimiteNumeroEquipasCompeticao on Scouting.Inscrito_Em
AFTER INSERT,UPDATE
AS 
	SET NOCOUNT ON;
	Declare @MaxClubs as int
	Declare @ClubesAtuais as int
	Declare @idCompeticao as varchar(9)
	Select @idCompeticao= Ins_Competicao_ID_FIFA from inserted;
	Select @MaxClubs =  Scouting.Competicao.Competicao_Numero_Equipas from Scouting.Competicao where Scouting.Competicao.Competicao_ID_FIFA=@idCompeticao;
	Select @ClubesAtuais =count(*) FROM Scouting.Inscrito_Em WHERE Ins_Competicao_ID_FIFA = @idCompeticao;
	if(@ClubesAtuais>@MaxClubs)
		BEGIN
			RAISERROR ('Número de equipas na Competiçao Ultrapassado', 16,1);
				ROLLBACK TRAN; -- Anula a inserção
		END


--drop trigger LimiteNumeroEquipasCompeticao 















--Stored Procedure INSERIR EQUIPAS INSCRITAS COMPETICAO
create procedure Scouting.Insert_Equipas_Inscritas_Competicao(@Ins_Clube_Numero_Inscricao_FIFA varchar(9),@Ins_Competicao_ID_FIFA varchar(9),@Numero_Jogadores_Inscritos int, @data date)
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Inscrito_Em VALUES (@Ins_Clube_Numero_Inscricao_FIFA, @Ins_Competicao_ID_FIFA , @Numero_Jogadores_Inscritos , @data);
				print ('Equipa Inscrita na Competicão')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro na Inscricão', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END
drop procedure Scouting.Insert_Equipas_Inscritas_Competicao
--EXEC Scouting.Insert_Equipas_Inscritas_Competicao 1,12,20,'2012-02-01'

















--Stored Procedure INSERIR AS POSIÇÕES DO JOGADOR
create procedure Scouting.Insert_Posicoes(@J_Posicoes varchar(30),@ID varchar(9))
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Jog_Posicoes VALUES (@J_Posicoes , @ID);
				print ('Posição Inserida')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro na Inserção', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END
--drop procedure Scouting.Insert_Posicoes
--EXEC Scouting.Insert_Posicoes'MC',1













--ST INSERT JOGADORES
create procedure Scouting.Insert_Jogador(@ID_FIFPro varchar(9),@Nome Varchar(50), @Altura float, @Peso float, @Pe bit, @Idade int, @Dupla_Na int,@numint int, @Lista int)
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Jogador VALUES (@ID_FIFPro,@Nome, @Altura, @Peso, @Pe, @Idade, @Dupla_Na,@numint, @Lista);
				print ('Jogador Inserido!')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro na Inserção', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END










--UDF Numero jogadores na equipa atualmente
CREATE FUNCTION Scouting.Get_NumeroJogadoresEquipa (@Clube_Numero_Inscricao_FIFA varchar(9)) RETURNS int
AS
	Begin
		Declare @Total int
			Select @Total=count(*) FROM Scouting.Jogador_Pertence_Clube WHERE JPC_Clube_Numero_Inscricao_FIFA = @Clube_Numero_Inscricao_FIFA and Pertence_Data_Saida is NULL;	
		Return @Total
	End

--Select  Scouting.Get_NumeroJogadoresEquipa (2)
--drop function Scouting.Get_NumeroJogadoresEquipa







--Inserir Jogador num Clube

CREATE PROCEDURE Scouting.Insert_Jogador_Clube(@Club_ID varchar(9),@ID_Jogador varchar(9), @Data_Inicio date, @Data_Fim date)
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (@Club_ID, @ID_Jogador, @Data_Inicio, @Data_Fim);
				print ('Jogador Pertence ao Clube!')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro na Inserção', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END












































--------------------------------------------------------------------------------------------


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








