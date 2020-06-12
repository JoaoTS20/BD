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
	Select *from (Scouting.Relatorio Join  ( (Scouting.Analise_Caracteristica_Jogador join Scouting.Metricas_Jogo_Jogador on Scouting.Metricas_Jogo_Jogador.Rel_ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID)) on ID=Scouting.Analise_Caracteristica_Jogador.Rel_ID) join Scouting.Jogo on (Jogo.Jogo_Local=Relatorio.Jogo_Local And Jogo.Jogo_Data=Relatorio.Jogo_Data) join Scouting.Observador ON Scouting.Observador.Numero_Identificacao_Federacao= Scouting.Relatorio.Numero_Identificacao_Federacao  WHERE Relatorio.ID=@ID
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









--Stored Procedure INSERIR CLUBE
create procedure Scouting.Insert_Clube(@Clube_Numero_Inscricao varchar(9),@Clube_Pais varchar(40),@Clube_Nome varchar(50))
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

--Stored Procedure Update CLUBES
create procedure Scouting.Update_Clube(@Clube_Numero_Inscricao varchar(9),@Clube_Pais varchar(40),@Clube_Nome varchar(50))
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				Update Scouting.Clube set  Clube_Pais=@Clube_Pais, Clube_Nome=@Clube_Nome where Clube_Numero_Inscricao_FIFA=@Clube_Numero_Inscricao;
				print ('Clube Editado')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Editar Clube', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END














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

-- Stored Procedure Obter Listas	
Create Procedure Scouting.Get_Listas_Observacao_Selecao	
AS	
	Begin	
	SELECT * FROM Scouting.Lista_Observacao_Selecao	
	End	
--Exec Scouting.Get_Listas_Observacao_Selecao


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
					THROW;
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


--UDF Numero jogadores na lista 
CREATE FUNCTION Scouting.Get_NumeroJogadoresLista (@lista varchar(3)) RETURNS int
AS
	begin
	Declare @Total int
	if len(@lista)>0
		Begin
			
			Select @Total=count(*) FROM Scouting.Jogador WHERE Lista_Idade_Maxima=@lista;	
			
		end
	if LEN(@lista)=0
		Begin
			
			Select @Total=count(*) FROM Scouting.Jogador
			
		end
	Return @Total
	end

	--drop function Scouting.Get_NumeroJogadoresLista
	--Select  Scouting.Get_NumeroJogadoresLista('')




--Trigger Não ter mais que um treinador com data de saida Null 
CREATE TRIGGER UmTreinador on Scouting.Treina
AFTER INSERT,UPDATE
AS 
	SET NOCOUNT ON;
	Declare @treinadoratual as int
	Declare @clubid as varchar(9)
	Declare @max_1 as int
	Select @max_1=1;
	Select @clubid= Clube_Num_insc_FIFA from inserted;
	Select @treinadoratual=COUNT(*) from Scouting.Treina where Treinador_Data_Saida is null and Clube_Num_insc_FIFA=@clubid
	if(@treinadoratual>@max_1)
		BEGIN
			RAISERROR ('Só pode ter um treinador a treinar de momento!', 16,1);
				ROLLBACK TRAN; -- Anula a inserção
		END
-- drop trigger UmTreinador


--Stored Procedure Remover Posição de Jogador
CREATE PROCEDURE Scouting.Delete_Posicoes @J_Posicoes varchar(30), @ID varchar(9)
AS
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				delete from Scouting.Jog_Posicoes where J_Posicoes=@J_Posicoes and Jog_Posicoes_ID_FIFPro=@ID
				print ('Posição Removida')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Remover Posição', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END

	--Stored Editar Jogador
CREATE PROCEDURE Scouting.Update_Jogador @ID_FIFPro varchar(9),@Nome Varchar(50), @Altura float, @Peso float, @Pe bit, @Idade int, @Dupla_Na int,@numint int, @Lista int
AS
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				 UPDATE Scouting.Jogador  SET Jogador_Nome=@Nome,Jogador_Altura=@Altura,Jogador_Peso=@Peso,Pe_Favorito=@Pe,Idade=@Idade,Dupla_Nacionalidade=@Dupla_Na,Lista_Idade_Maxima=@Lista  WHERE  ID_FIFPro=@ID_FIFPro;
				 Print 'Jogador Editado'
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Editar Jogador', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END


--Eliminar Relatório
CREATE PROCEDURE Scouting.Delete_Relatorio @ID int
AS
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				 Delete from Scouting.Analise_Caracteristica_Jogador where Rel_ID=@ID
				 Delete from Scouting.Metricas_Jogo_Jogador where Rel_ID=@ID
				 Delete from Scouting.Observacao_Metodo_de_Observacao where Rel_ID_Relatorio=@ID
				 delete from Scouting.Relatorio where ID=@ID
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Eliminar Relatório', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END

--Eliminar Jogador
CREATE PROCEDURE Scouting.Delete_Jogador @ID_FIFPro varchar(9)
AS
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				Declare @idRel as int
				 DELETE FROM Scouting.Jog_Posicoes where Jog_Posicoes_ID_FIFPro=@ID_FIFPro;
				 DELETE FROM Scouting.Jogador_Pertence_Clube WHERE ID_FIFPro=@ID_FIFPro;

				WHILE (1 = 1) 
					BEGIN  

					  -- Get next id
					  SELECT TOP 1 @idRel = ID From Scouting.Relatorio where ID_FIFPro=@ID_FIFPro

					  -- Exit loop if no more Relatorios com aquele id
					  IF @@ROWCOUNT = 0 BREAK;

					  -- call your sproc
					  EXEC Scouting.Delete_Relatorio @idRel;
						End
				DELETE from Scouting.Jogador where ID_FIFPro=@ID_FIFPro;
				Commit Transaction x
				END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Eliminar Jogador', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END

--UDF Numero Relatórios sobre Jogador
CREATE FUNCTION Scouting.Get_NumeroRelatoriosJogadores (@id varchar(9)) RETURNS int
AS
	begin
	Declare @Total int
	if len(@id)>0
		Begin
			
			Select @Total=count(*) FROM Scouting.Relatorio WHERE ID_FIFPro=@id
		end
	Return @Total
	end


--Limitar Posição GR
CREATE TRIGGER PosicaoUniqueGR on Scouting.Jog_Posicoes
AFTER INSERT
AS 
	SET NOCOUNT ON;
	SELECT * FROM inserted;
	Declare @jogid as int
	Select @jogid= Jog_Posicoes_ID_FIFPro from inserted
	Declare @SerGR as int
	Declare @Ser as int
	Select @SerGR= COUNT(*) from Scouting.Jog_Posicoes where Jog_Posicoes_ID_FIFPro=@jogid and J_Posicoes='GR'
	Select @Ser= COUNT(*) from Scouting.Jog_Posicoes where Jog_Posicoes_ID_FIFPro=@jogid and J_Posicoes!='GR'
	if(@SerGR=1 and @Ser>0)
		BEGIN
			RAISERROR ('Guarda-Redes só tem uma posição', 16,1);
				ROLLBACK TRAN; -- Anula a inserção
		END
--drop trigger PosicaoUniqueGR





--Inserir Relatorio e Consequentes 
Create PROCEDURE Scouting.Insert_Relatorio(@Titulo varchar(50), @Data date, @ID_Federacao_Obs varchar(9), @ID varchar(9),@Local varchar(100), @Jogo_Data date, 
@Qualidade_Atual int,@Qualidade_Potencial int, @M_Atributo varchar(50), @Etica varchar(50), @Determinacao int, @Decisao int, @Tecnica int,@Numero_Golo int,
@assistencias int,@passes_efec int,@passes_comp int,@numero_cortes int, @minutos_jogados int, @Defesa_Realizada int, @distancia int, @toques int, @dribles int,@remates int, @metodo_observacao varchar(15))
as 
	BEGIN
		Declare @ID_Rel int
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Relatorio VALUES (@Titulo, @Data, @ID_Federacao_Obs, @ID,@Local, @Jogo_Data);--Inserir Relatorio
				Select @ID_Rel=IDENT_CURRENT ('Scouting.Relatorio')
				Insert INTO Scouting.Observacao_Metodo_de_Observacao values (@metodo_observacao,@ID_Rel)
				Insert INTO Scouting.Analise_Caracteristica_Jogador VALUES (@ID_Rel,@Qualidade_Atual,@Qualidade_Potencial, @M_Atributo, @Etica, @Determinacao, @Decisao, @Tecnica, @ID_Federacao_Obs);
				Insert INTO Scouting.Metricas_Jogo_Jogador values (@Numero_Golo,@ID_Rel,@assistencias,@passes_efec,@passes_comp,@numero_cortes, @minutos_jogados, @Defesa_Realizada, @distancia, @toques, @dribles, @remates, @ID_Federacao_Obs);
				PRINT 'Relatório Criado'
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					THROW;
					raiserror ('Erro na Inserção De Relatório', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END




--Stored Procedure Obter Jogos Clube Participou e Observador Analisou 
Create Procedure Scouting.Get_Jogos_By_Clube_Observador @club_id varchar(9), @obs_id varchar(9)
AS
			BEGIN
			SELECT * FROM Scouting.Participa_Em join Scouting.Jogo on Jogo_Local=Participa_Em_Jogo_Local and Jogo_Data=Participa_Em_Jogo_Data where Participa_Clube_Numero_Inscricao_FIFA=@club_id and Obs_Num_Iden_Federacao=@obs_id;
			END

-- drop Procedure Scouting.Get_Jogos_By_Clube_Observador


--Stored Procedure Obter Observador
Create Procedure Scouting.Get_Observador
AS
			BEGIN
			SELECT * FROM Scouting.Observador
			END
-- drop Provedure Scouting.Get_Observador






--Stored Procedure BIG Obter Observador
CREATE PROCEDURE Scouting.Get_Lista_Observadores @sort_by varchar(30), @filter_by varchar(60), @filter_value varchar(50)
 AS
	DECLARE @SQLStatement varchar(200)
	IF(LEN(@sort_by)=0 AND LEN(@filter_by)=0)
	BEGIN
		SELECT * FROM Scouting.Observador;
	END
	IF(LEN(@sort_by)>0 AND LEN(@filter_by)=0)
	BEGIN
	PRINT 'talvez'
		SELECT @SQLStatement= 'SELECT * FROM Scouting.Observador ORDER BY ' + @sort_by;
		EXEC(@SQLStatement)
	END
	--se filter_value len=0 a partir daqui erro
	IF(LEN(@filter_value)=0)
	BEGIN
		PRINT 'filtro nao tem valor associado'
		return
	END
	IF(LEN(@sort_by)=0 AND LEN(@filter_by)>0)
	BEGIN
		PRINT 'nao'
		SELECT @SQLStatement= 'SELECT * FROM Scouting.Observador WHERE ' + @filter_by+'='''+@filter_value+'''';
		EXEC(@SQLStatement)
	END
	IF(LEN(@sort_by)>0 AND LEN(@filter_by)>0)
	BEGIN
		PRINT 'sim'
		SELECT @SQLStatement= 'SELECT * FROM Scouting.Observador WHERE ' + @filter_by+'='''+@filter_value+''' ORDER BY '+@sort_by;
		EXEC(@SQLStatement)
	END






--Obter Clube Atual Jogador
Create Procedure Scouting.Get_ClubeAtual_Jogador @id varchar(9)
as
	begin
	select * from Scouting.Jogador_Pertence_Clube join Scouting.Clube on Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Clube_Numero_Inscricao_FIFA WHERE Pertence_Data_Saida is null and ID_FIFPro=@id;
	end


-- Obter jogos em que jogador participou
CREATE PROCEDURE Scouting.Get_Jogos_Jogador @id_fifpro varchar(9)
as
	BEGIN
		SELECT Jogo.* FROM (((Jogador JOIN Jogador_Pertence_Clube ON Jogador.ID_FIFPro=Jogador_Pertence_Clube.ID_FIFPro) JOIN Scouting.Clube ON Clube.Clube_Numero_Inscricao_FIFA=JPC_Clube_Numero_Inscricao_FIFA)
						JOIN Participa_Em ON JPC_Clube_Numero_Inscricao_FIFA = Participa_Clube_Numero_Inscricao_FIFA) JOIN Jogo ON Jogo.Jogo_Data=Participa_Em.Participa_Em_Jogo_Data AND Jogo.Jogo_Local=Participa_Em_Jogo_Local WHERE Jogador.ID_FIFPro=@id_fifpro
	END
--EXEC Scouting.Get_Jogos_Jogador 13
--DROP PROCEDURE Scouting.Get_Jogos_Jogador



--Obter Jogadores do Passado Jogador
CREATE Procedure Scouting.Get_ClubesPassado @id varchar(9)
AS
		IF(LEN(@id)>0 )
			BEGIN
			select * from Scouting.Jogador_Pertence_Clube join Scouting.Clube on JPC_Clube_Numero_Inscricao_FIFA=Clube_Numero_Inscricao_FIFA where Pertence_Data_Saida is not null and ID_FIFPro=@id;
			END

--select * from Scouting.Jogador_Pertence_Clube join Scouting.Clube on JPC_Clube_Numero_Inscricao_FIFA=Clube_Numero_Inscricao_FIFA where ID_FIFPro=20



--Obter Metodos de Observacao Do Relatório
CREATE Procedure Scouting.Get_Metodo_Observacao @idRel int
AS
		IF(LEN(@idRel)>0 )
			BEGIN
			select * from Scouting.Observacao_Metodo_de_Observacao WHERE Rel_ID_Relatorio=@idRel 
			end

--Exec Scouting.Get_Metodo_Observacao 74

--Editar Relatorio e Consequentes 
Create PROCEDURE Scouting.Update_Relatorio(@idRel int,@Titulo varchar(50), @Data date, @ID_Federacao_Obs varchar(9), @ID varchar(9), 
@Qualidade_Atual int,@Qualidade_Potencial int, @M_Atributo varchar(50), @Etica varchar(50), @Determinacao int, @Decisao int, @Tecnica int,@Numero_Golo int,
@assistencias int,@passes_efec int,@passes_comp int,@numero_cortes int, @minutos_jogados int, @Defesa_Realizada int, @distancia int, @toques int, @dribles int,@remates int)
as 
	BEGIN
		Declare @ID_Rel int
		Begin Transaction  x
			BEGIN TRY
				Update Scouting.Relatorio set Relatorio_Titulo=@Titulo, Relatorio_Data=@Data, Numero_Identificacao_Federacao=@ID_Federacao_Obs, ID_FIFPro=@ID where ID=@idRel;
				Update Scouting.Analise_Caracteristica_Jogador set Qualidade_Atual=@Qualidade_Atual,Qualidade_Potencial=@Qualidade_Potencial, Melhor_Atributo=@M_Atributo, Etica_Trabalho=@Etica, Determinacao=@Determinacao,@Decisao=@Decisao,Nivel_Tecnica=@Tecnica where Rel_ID=@ID_Rel
				Update Scouting.Metricas_Jogo_Jogador set @Numero_Golo=@Numero_Golo,Numero_Assistencias=@assistencias, Numero_Passes_Efectuados=@passes_efec, Numero_Passes_Completos= @passes_comp, @numero_cortes=@numero_cortes, @minutos_jogados= @minutos_jogados, Defesas_Realizadas= @Defesa_Realizada,Distancia_Percorrida= @distancia, Numero_Toques= @toques, Numero_Dribles= @dribles, Numero_Remates=@remates where Rel_ID=@idRel;
				PRINT 'Relatório Editado'
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					THROW;
					raiserror ('Erro Editar De Relatório', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END


--Stored Procedure Delete Relatorio
Create PROCEDURE [Scouting].[Delete_Relatorio] @ID int
AS
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				 Delete from Scouting.Analise_Caracteristica_Jogador where Rel_ID=@ID
				 Delete from Scouting.Metricas_Jogo_Jogador where Rel_ID=@ID
				 Delete from Scouting.Observacao_Metodo_de_Observacao where Rel_ID_Relatorio=@ID
				 delete from Scouting.Relatorio where ID=@ID
				 print ('Relatorio Removido')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Eliminar Relatório', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END




--Stored Procedure Delete POSICOES
create PROCEDURE [Scouting].[Delete_Posicoes] @J_Posicoes varchar(30), @ID varchar(9)
AS
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				delete from Scouting.Jog_Posicoes where J_Posicoes=@J_Posicoes and Jog_Posicoes_ID_FIFPro=@ID
				print ('Posição Removida')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Remover Posição', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END









--Stored Procedure INSERIR AS METODOS DO JOGADOR
create procedure Scouting.Insert_Metodo_Observacao(@Metodo varchar(15),@ID INT)
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES (@Metodo , @ID);
				print ('Método Inserida')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					THROW;
					raiserror ('Erro na Inserção', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END





-- Stored Procedure Delete Observador
CREATE PROCEDURE Scouting.Delete_Observador @id_Fed varchar(9)
AS
Begin Transaction  x
			BEGIN TRY
				UPDATE Scouting.Analise_Caracteristica_Jogador
				SET Obs_Num_Iden_Federacao=null
				WHERE Obs_Num_Iden_Federacao=@id_Fed;
				UPDATE Scouting.Metricas_Jogo_Jogador
				SET Obs_Num_Iden_Federacao=null
				WHERE Obs_Num_Iden_Federacao=@id_Fed;
				UPDATE Scouting.Jogo
				SET Obs_Num_Iden_Federacao=null
				WHERE Obs_Num_Iden_Federacao=@id_Fed;
				UPDATE Scouting.Relatorio
				SET Relatorio.Numero_Identificacao_Federacao=null
				WHERE Numero_Identificacao_Federacao=@id_Fed;
				DELETE FROM Scouting.Observador WHERE Numero_Identificacao_Federacao=@id_Fed
				PRINT 'Observador eliminado com sucesso'
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					THROW;
					raiserror ('Erro ao Eliminar Observador', 16, 1);
					ROLLBACK TRANSACTION x
				END
			END CATCH












--Stored Procedure Remover AS METODOS DO JOGADOR
create procedure Scouting.Delete_Metodo_Observacao(@Metodo varchar(15),@ID INT)
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				delete from Scouting.Observacao_Metodo_de_Observacao where Rel_Metodo_de_Observacao=@Metodo and Rel_ID_Relatorio= @ID;
				print ('Método Removido')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					THROW;
					raiserror ('Erro no Delete', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END


--nÃO TESTADA 
CREATE TRIGGER check_local on Scouting.Relatorio
AFTER INSERT
AS
	declare @loc as varchar(100);
	declare @Obs as varchar(9);
	declare @Area_obs as varchar(50);
	declare @num as int;
	SELECT @loc = Jogo_Local FROM inserted;
	SELECT @Obs = Numero_Identificacao_Federacao FROM inserted;

	SELECT @num=COUNT(*) FROM Observador.Area_Observacao WHERE Observador.Numero_Identificacao_Federacao=@Obs and Observador.Area_Observacao LIKE '%'+@loc+'%';
	if(@num=0)
	BEGIN
		RAISERROR ('Observador so pode observar na sua área!', 16,1);
		ROLLBACK TRAN;
	END

--DROP TRIGGER check_local







--Stored Procedure Update Observador
CREATE PROCEDURE Scouting.Update_Observador @id_fed varchar(9), @nome varchar(50), @qualificacoes varchar(100), @nacionalidade varchar(40),@idade int,@area varchar(50)
AS
	Begin Transaction  x
			BEGIN TRY
				UPDATE Scouting.Observador 
				SET Observador_Nome=@nome,Observador_Idade=@idade,Observador_Nacionalidade=@nacionalidade,Observador_Qualificações=@qualificacoes,Area_Observacao=@area
				WHERE Numero_Identificacao_Federacao=@id_fed;
				PRINT 'Observador editado com sucesso'
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					THROW;
					raiserror ('Erro ao Editar Observador', 16, 1);
					ROLLBACK TRANSACTION x
				END
			END CATCH





--Stored Procedure Obter Relatorios Observador
CREATE PROCEDURE Scouting.Get_Relatorios_Observador @id varchar(9), @Order_By varchar(50)
AS
	DECLARE @SQLStatement varchar(300);
		IF(LEN(@Order_By)>0 )
			BEGIN
				SELECT @SQLStatement= 'SELECT Relatorio.* FROM Scouting.Observador JOIN Scouting.Relatorio ON Relatorio.Numero_Identificacao_Federacao=Observador.Numero_Identificacao_Federacao
				WHERE Observador.Numero_Identificacao_Federacao = '''+@id+'''ORDER BY ' + @Order_By;
				EXEC(@SQLStatement)
			END
		IF(LEN(@Order_By)=0)
			BEGIN
				SELECT Relatorio.* FROM Scouting.Relatorio JOIN Scouting.Observador ON Relatorio.Numero_Identificacao_Federacao=Observador.Numero_Identificacao_Federacao
				WHERE Observador.Numero_Identificacao_Federacao=@id;
			END





--Stored Procedure Update Competicao
CREATE PROCEDURE Scouting.Update_Competicao @id_fifa varchar(9), @nome varchar(50), @num_equipas int
AS
	Begin Transaction  x
			BEGIN TRY
				UPDATE Scouting.Competicao 
				SET Competicao_Nome=@nome,Competicao_Numero_Equipas=@num_equipas
				WHERE Competicao_ID_FIFA=@id_fifa;
				PRINT 'Competicao editada Com Sucesso'
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					THROW;
					raiserror ('Erro ao Editar Competicao', 16, 1);
					ROLLBACK TRANSACTION x
				END
			END CATCH




--Stored Processo Remover Clube de Competicao
CREATE PROCEDURE Scouting.Delete_Competicao_Clube @clube_id varchar(9), @compet_id varchar(9)
AS
	BEGIN
	Begin Transaction  x
			BEGIN TRY
				UPDATE Scouting.Participa_Em SET Participa_Clube_Numero_Inscricao_FIFA=null 
				WHERE Participa_Clube_Numero_Inscricao_FIFA=@clube_id AND
				(SELECT Jogo.Jogo_Competicao_ID_FIFA FROM Scouting.Jogo JOIN Scouting.Participa_Em ON Participa_Em_Jogo_Data=Jogo_Data AND Participa_Em_Jogo_Local=Jogo_Local)=@compet_id;
				
				DELETE FROM Scouting.Inscrito_Em WHERE Inscrito_Em.Ins_Clube_Numero_Inscricao_FIFA=@clube_id AND Ins_Competicao_ID_FIFA = @compet_id;
				PRINT 'Inscricao Eliminada'
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					THROW;
					raiserror ('Erro ao Remover Inscricao', 16, 1);
					ROLLBACK TRANSACTION x
				END
			END CATCH
	END





--Stored Procedure Adicionar Clube à Competição
CREATE PROCEDURE Scouting.Insert_Competicao_Clube @clube_id varchar(9), @compet_id varchar(9),@num_jog int,@data_insc date
AS
	BEGIN
	Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Inscrito_Em VALUES (@clube_id, @compet_id, @num_jog, @data_insc);
				PRINT 'Inscricao Realizada'
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					THROW;
					raiserror ('Erro na Inscricao', 16, 1);
					ROLLBACK TRANSACTION x
				END
			END CATCH
	END








--UDF Obter Numero de Observadores

CREATE FUNCTION Scouting.Get_NumeroObservadores () RETURNS int
AS	
	BEGIN
		DECLARE @res int;
		Select @res=count(*) FROM Scouting.Observador;
		return @res;
	END






--UDF Obter Numero de Relatorios do Observador
CREATE FUNCTION Scouting.Get_NumRelatoriosObservador (@id_obs varchar(9)) RETURNS int
AS	
		begin
			DECLARE @res int;
			Select @res=count(*) FROM Scouting.Observador JOIN Scouting.Relatorio 
			ON Observador.Numero_Identificacao_Federacao= Relatorio.Numero_Identificacao_Federacao
			WHERE Observador.Numero_Identificacao_Federacao=@id_obs;
		return @res;
	END











--UDF Obter Numero de Jogos Observados pelo Observador 
Create FUNCTION Scouting.Get_NumJogosObservador (@id_obs varchar(9)) RETURNS int
AS	
	BEGIN
		DECLARE @res int;
		
			Select @res=count(*) FROM Scouting.Observador JOIN Scouting.Jogo 
			ON Observador.Numero_Identificacao_Federacao= Jogo.Obs_Num_Iden_Federacao
			WHERE Numero_Identificacao_Federacao=@id_obs;
		return @res;
	END






--Obter Jogos Analisados Jogador
Create Procedure [Scouting].[Get_Jogos_Observador]  @obs_id varchar(9)
AS
			BEGIN
			SELECT * FROM Scouting.Participa_Em join Scouting.Jogo on Jogo_Local=Participa_Em_Jogo_Local and Jogo_Data=Participa_Em_Jogo_Data where Obs_Num_Iden_Federacao=@obs_id;
			END


--Stored Procedure Get Competições
CREATE PROCEDURE Scouting.Get_Lista_Competicoes @orderby varchar(50)
AS
	BEGIN
		DECLARE @SQLstat varchar(200)
		if (LEN(@orderby)=0)
		BEGIN
		SELECT * FROM Scouting.Competicao;
		END
		IF(LEN(@orderby)>0)
		BEGIN
			SELECT @SQLstat = 'SELECT * FROM Scouting.Competicao ORDER BY '+@orderby;
			EXEC(@SQLstat);
		END
	END









--Stored Procedure Obter Jogos Competicao
CREATE PROCEDURE Scouting.Get_Jogos_By_Competicao @comp_id varchar(9)
AS
		IF(LEN(@comp_id)=0)
		BEGIN
			SELECT * FROM Scouting.Jogo;
		END
		IF(LEN(@comp_id)>0)
		BEGIN
			SELECT * FROM Scouting.Jogo WHERE @comp_id=Jogo.Jogo_Competicao_ID_FIFA;
		END










--UDF Obter Numero de Competicoes
CREATE FUNCTION Scouting.Get_Numero_Competicoes() RETURNS int
AS
	BEGIN
		DECLARE @res int;
		SELECT @res = COUNT (*) FROM Scouting.Competicao
		return @res;

	END








--UDF Obter Numero Jogos Competicao
create FUNCTION Scouting.Get_Numero_Jogos_Por_Competicao(@id_comp varchar(9)) RETURNS int
AS
	BEGIN
		DECLARE @res int;
		IF(LEN(@id_comp)=0)
		BEGIN
			SELECT @res = COUNT (*) FROM Scouting.Jogo;
		END
		IF(LEN(@id_comp)>0)
		BEGIN
		SELECT @res = COUNT (*) FROM Scouting.Jogo
		WHERE Jogo.Jogo_Competicao_ID_FIFA=@id_comp;
		END
		return @res;

	END










--Stored Procedures Obter Numero de Jogos da competicao
CREATE PROCEDURE Scouting.Get_Clubes_By_Competicao @id_comp varchar(9),@orderby varchar(40)
AS
	DECLARE @SQLstat varchar(500);
	IF(LEN(@id_comp)=0)
	BEGIN
		return;
	END
	IF(LEN(@orderby)=0)
	BEGIN
		SELECT Clube.* FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Ins_Competicao_ID_FIFA=Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube_Numero_Inscricao_FIFA=Ins_Clube_Numero_Inscricao_FIFA
		WHERE Competicao_ID_FIFA=@id_comp;
	END
	IF(LEN(@orderby)>0)
	BEGIN
		SELECT @SQLstat = 'SELECT Clube.* FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Ins_Competicao_ID_FIFA=Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube_Numero_Inscricao_FIFA=Ins_Clube_Numero_Inscricao_FIFA
		WHERE Competicao_ID_FIFA='+@id_comp+' ORDER BY '+@orderby;
		EXEC(@SQLstat);
	END









--Stored Procedures Obter Clubes da competicao
CREATE PROCEDURE Scouting.Get_Clubes_By_Competicao @id_comp varchar(9),@orderby varchar(40)
AS
	DECLARE @SQLstat varchar(500);
	IF(LEN(@id_comp)=0)
	BEGIN
		return;
	END
	IF(LEN(@orderby)=0)
	BEGIN
		SELECT Clube.* FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Ins_Competicao_ID_FIFA=Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube_Numero_Inscricao_FIFA=Ins_Clube_Numero_Inscricao_FIFA
		WHERE Competicao_ID_FIFA=@id_comp;
	END
	IF(LEN(@orderby)>0)
	BEGIN
		SELECT @SQLstat = 'SELECT Clube.* FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Ins_Competicao_ID_FIFA=Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube_Numero_Inscricao_FIFA=Ins_Clube_Numero_Inscricao_FIFA
		WHERE Competicao_ID_FIFA='+@id_comp+' ORDER BY '+@orderby;
		EXEC(@SQLstat);
	END







--udf Obter Numero de clubes Competicao
CREATE FUNCTION Scouting.Get_Numero_Clubes_Por_Competicao(@id_comp varchar(9)) RETURNS int
AS
	BEGIN

		DECLARE @res int;
		IF(LEN(@id_comp)=0)
		BEGIN
			SELECT @res = COUNT (*) FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Competicao_ID_FIFA=Inscrito_Em.Ins_Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube_Numero_Inscricao_FIFA=Ins_Clube_Numero_Inscricao_FIFA;
		END
		IF(LEN(@id_comp)>0)
		BEGIN
			SELECT @res = COUNT (*) FROM (Scouting.Competicao JOIN Scouting.Inscrito_Em ON Competicao_ID_FIFA=Inscrito_Em.Ins_Competicao_ID_FIFA) JOIN Scouting.Clube ON Clube_Numero_Inscricao_FIFA=Ins_Clube_Numero_Inscricao_FIFA
			WHERE Competicao.Competicao_ID_FIFA=@id_comp;
		END
		return @res;

	END








-- Stored Procedure Delete Competicao
CREATE PROCEDURE Scouting.Delete_Competicao @id_comp varchar(9)
AS
	Begin Transaction  x
	IF(LEN(@id_comp)=0)
	BEGIN
		return;
	END
	BEGIN TRY
		DELETE Scouting.Inscrito_Em WHERE Ins_Competicao_ID_FIFA=@id_comp;
		UPDATE Scouting.Jogo
		SET Jogo_Competicao_ID_FIFA=NULL
		WHERE Jogo_Competicao_ID_FIFA=@id_comp;
		DELETE Scouting.Competicao WHERE Competicao_ID_FIFA=@id_comp;
		PRINT 'Lista Observacao Eliminada'
		Commit Transaction x
	END TRY
	BEGIN CATCH 
		IF @@TRANCOUNT>0
		BEGIN
			THROW;
			raiserror ('Erro ao Eliminar', 16, 1);
			ROLLBACK TRANSACTION x
		END
	END CATCH



















--Stored Procedure Insert Lista Obs
CREATE PROCEDURE Scouting.Insert_Lista_Observ @idade_max int,@lista_nome varchar(30)
AS
	Begin Transaction  x
		BEGIN TRY
			INSERT INTO Scouting.Lista_Observacao_Selecao VALUES (@idade_max, @lista_nome);
			PRINT 'Lista Observacao Introduzida'
			Commit Transaction x
		END TRY
		BEGIN CATCH 
			IF @@TRANCOUNT>0
			BEGIN
				THROW;
				raiserror ('Erro na Insercao', 16, 1);
				ROLLBACK TRANSACTION x
			END
		END CATCH

----Stored Procedure Update Lista Obs
CREATE PROCEDURE Scouting.Update_Lista_Observ @idade_max int,@lista_nome varchar(30)
AS
	Begin Transaction  x
		IF(LEN(@idade_max)=0)
		BEGIN
			return;
		END
		BEGIN TRY
			UPDATE Scouting.Lista_Observacao_Selecao
			SET Lista_Nome=@lista_nome
			WHERE Lista_Idade_Maxima=@idade_max;
			PRINT 'Lista Observacao Alterada'
			Commit Transaction x
		END TRY
		BEGIN CATCH 
			IF @@TRANCOUNT>0
			BEGIN
				THROW;
				raiserror ('Erro na Alteração', 16, 1);
				ROLLBACK TRANSACTION x
			END
		END CATCH


--Stored Procedure Inserir Jogo Competição
Create PROCEDURE [Scouting].[Insert_Jogo] @id_club varchar(9), @convocados int,@local varchar(100),@data date, @resultado varchar(5),@comp_id varchar(9),@obs_id varchar(9)
AS
	BEGIN TRANSACTION x;
	IF(LEN(@local)=0 OR LEN(@data)=0)
	BEGIN
		return;
	END
	BEGIN TRY
		INSERT INTO Scouting.Jogo VALUES (@local,@data,@resultado,@comp_id,@obs_id)
		Insert Into Scouting.Participa_Em VALUES (@id_club,@data,@local,@convocados)
		PRINT 'Jogo Adicionada'
		Commit Transaction x
	END TRY
	BEGIN CATCH 
		IF @@TRANCOUNT>0
		BEGIN
			THROW;
			raiserror ('Erro ao Inserir', 16, 1);
			ROLLBACK TRANSACTION x
		END
	END CATCH




--Stored Procedure Edit Jogo 
CREATE PROCEDURE Scouting.Edit_Jogo @local varchar(100),@data date, @resultado varchar(5),@comp_id varchar(9)
AS
	BEGIN TRANSACTION x;
	IF(LEN(@local)=0 OR LEN(@data)=0)
	BEGIN
		return;
	END
	BEGIN TRY
		UPDATE Scouting.Jogo
		SET Jogo_Competicao_ID_FIFA=@comp_id,Resultado=@resultado
		WHERE Jogo_Local=@local AND Jogo_Data=@data;
		PRINT 'Jogo Editado'
		Commit Transaction x
	END TRY
	BEGIN CATCH 
		IF @@TRANCOUNT>0
		BEGIN
			THROW;
			raiserror ('Erro ao Editar', 16, 1);
			ROLLBACK TRANSACTION x
		END
	END CATCH



--Stored Procedure Insert Jogador to Clube
CREATE PROCEDURE Scouting.Insert_Jogador_To_Clube @club_insc varchar(9),@id_fifpro varchar(9),@data_ini date
AS
	BEGIN TRANSACTION x;
	BEGIN TRY
		INSERT INTO Scouting.Jogador_Pertence_Clube VALUES(@club_insc,@id_fifpro,@data_ini,null)
		PRINT 'Jogador Inserido'
		Commit Transaction x
	END TRY
	BEGIN CATCH 
		IF @@TRANCOUNT>0
		BEGIN
			THROW;
			raiserror ('Erro ao Inserir', 16, 1);
			ROLLBACK TRANSACTION x
		END
	END CATCH


--Stored Procedure Delete Clube from Jogador
CREATE PROCEDURE Scouting.Delete_Jogador_From_Clube @club_insc varchar(9),@id_fifpro varchar(9),@data_fin date
AS
		BEGIN TRANSACTION x;
	BEGIN TRY
		UPDATE Scouting.Jogador_Pertence_Clube
		SET Pertence_Data_Saida=@data_fin
		WHERE JPC_Clube_Numero_Inscricao_FIFA=@club_insc AND ID_FIFPro=@id_fifpro;
		PRINT 'Jogador Removido do Clube'
		Commit Transaction x
	END TRY
	BEGIN CATCH 
		IF @@TRANCOUNT>0
		BEGIN
			THROW;
			raiserror ('Erro ao Remover', 16, 1);
			ROLLBACK TRANSACTION x
		END
	END CATCH



	--Trigger Não ter mais que um Jogador com data de saida Null 
CREATE TRIGGER UmClubeAtual on Scouting.Jogador_Pertence_Clube
AFTER INSERT,UPDATE
AS 
	SET NOCOUNT ON;
	Declare @jogadorid as VARCHAR(9)
	Declare @Actual as int
	Declare @max_1 as int
	Select @max_1=1;
	Select @jogadorid= ID_FIFPro from inserted;
	Select @Actual=COUNT(*) from Scouting.Jogador_Pertence_Clube where Pertence_Data_Saida is null and ID_FIFPro=@jogadorid
	if(@Actual>@max_1)
		BEGIN
			RAISERROR ('Jogador só pode Jogar num clube de cada vez', 16,1);
				ROLLBACK TRAN; -- Anula a inserção
		END

--Get Selecionador por lista
CREATE PROCEDURE Scouting.Get_ID_Selecionador @idade_max int
AS
	BEGIN
	IF(LEN(@idade_max)=0)
	BEGIN
		RETURN;
	END
	declare @res varchar(9);
	SELECT Selecionador.* FROM (Scouting.Selecionador JOIN Scouting.Responsavel 
	ON Responsavel.Selec_Numero_Iden_Federacao=Selecionador_Numero_Identificacao_Federacao) JOIN Scouting.Lista_Observacao_Selecao
	ON Lista_Idade_Maxima=Idade_Maxima
	WHERE Idade_Maxima=@idade_max AND Res_Data_Final IS NULL;
	END




--Stored Procedure Get Treinadores
CREATE PROCEDURE Scouting.Get_Treinadores
AS
	
	BEGIN
		SELECT * FROM Scouting.Treinador
	END
	


--udf Obter Numero de clubes 
Create FUNCTION [Scouting].[Get_Numero_Clubes]() RETURNS int
AS
	BEGIN

		DECLARE @res int;

		BEGIN
			SELECT @res = COUNT (*) FROM Scouting.Clube;
		END
		return @res;

	END

--Stored Procedure Treinador Muda de clube
CREATE PROCEDURE Scouting.Change_Treinador_Clube @id_treinador varchar(9),@data date, @id_Clube varchar(9)
AS
	Begin Transaction  x
			BEGIN TRY
				UPDATE Scouting.Treina SET Treinador_Data_Saida=@data
				WHERE @id_treinador=Treina_Num_Insc_FIFA AND Treinador_Data_Saida IS NULL;
				IF(LEN(@id_Clube)>0)
				BEGIN
					INSERT INTO Scouting.Treina VALUES (@id_treinador,NULL,@data,@id_Clube)
				END
	

				print ('Treinador Treina Novo Clube!')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro na Alteracao', 16, 1);
					RollBack Transaction x
				END
			END CATCH



--Stored Procedure Get Clube Atual Treinador
CREATE PROCEDURE Scouting.Get_Clube_Atual_Treinador @id_treinador varchar(9)
AS
	SELECT * FROM (Scouting.Treinador JOIN Scouting.Treina ON Treinador_Numero_Inscricao_FIFA=Treina_Num_Insc_FIFA)
	JOIN Scouting.Clube ON Clube_Num_insc_FIFA=Clube_Numero_Inscricao_FIFA WHERE Treinador.Treinador_Numero_Inscricao_FIFA=@id_treinador AND Treinador_Data_Saida IS NULL;








--Stored Procedure Get Clube Antigos Treinador
CREATE PROCEDURE Scouting.Get_Clubes_Antigos_Treinador @id_treinador varchar(9)
AS
	SELECT * FROM (Scouting.Treinador JOIN Scouting.Treina ON Treinador_Numero_Inscricao_FIFA=Treina_Num_Insc_FIFA)
	JOIN Scouting.Clube ON Clube_Num_insc_FIFA=Clube_Numero_Inscricao_FIFA WHERE Treinador.Treinador_Numero_Inscricao_FIFA=@id_treinador AND Treinador_Data_Saida is not null

--Trigger metricas coerentes
CREATE TRIGGER MetricasCoerentes on Scouting.Metricas_Jogo_Jogador
AFTER INSERT,UPDATE
AS 
	SET NOCOUNT ON;
	Declare @numeroAs as int
	Declare @numeroG as int
	Declare @numero_Passes_efectuados as int
	Declare @numero_Passes_completos as int
	Declare @numero_Cortes as int
	Declare @minutos_jogados as int
	Declare @defesas_realizadas as int
	Declare @numero_toques as int
	Declare @numero_dribles as int
	Declare @Numero_remates as int
	--
	Select @numeroAs = Numero_Assistencias from inserted 
	Select @numeroG = Numero_Golos from inserted 
	Select @numero_Passes_efectuados = Numero_Passes_Efectuados from inserted 
	Select @numero_Passes_completos = Numero_Passes_Completos from inserted 
	Select @numero_Cortes = Numero_Cortes from inserted 
	Select @minutos_jogados = Minutos_Jogados from inserted 
	Select @defesas_realizadas = Defesas_Realizadas from inserted 
	Select @numero_toques = Numero_Toques from inserted 
	Select @numero_dribles = Numero_Dribles from inserted 
	Select @Numero_remates = Numero_Remates from inserted 

	if(@numero_Passes_completos>@numero_Passes_efectuados)
		BEGIN
			RAISERROR ('Número de Passes Completos > Número de Passes Efectuados', 16,1);
				ROLLBACK TRAN; -- Anula a inserção
		END
	if(@numeroAs>@numero_Passes_completos)
		BEGIN
			RAISERROR ('Número de Assistências > Número de Passes Completos', 16,1);
				ROLLBACK TRAN; -- Anula a inserção
		END
	if(@minutos_jogados<=0 AND @minutos_jogados >=120)
		BEGIN
			RAISERROR ('Número de Minutos de 0 a 120', 16,1);
				ROLLBACK TRAN; -- Anula a inserção
		END
	if(@numeroG>@Numero_remates)
		BEGIN
			RAISERROR ('Número de Golos> Número de Remates', 16,1);
				ROLLBACK TRAN; -- Anula a inserção
		END
	if(@numero_toques<@Numero_Passes_Efectuados )
		BEGIN
			RAISERROR ('Número de Toques < Número de Passes Efectuados', 16,1);
				ROLLBACK TRAN; -- Anula a inserção
		END

--Stored Procedures Ainda não implementados
create procedure Scouting.Insert_Selecionador @Numero_Identificacao varchar(9),@Nome varchar(50),@Qualificacoes varchar(100), @Nacionalidade varchar(40),@Idade int
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Selecionador VALUES (@Numero_Identificacao,@Nome,@Qualificacoes, @Nacionalidade, @Idade);
				print ('Selecionador Inserido')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Inserir Selecionador', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END

create procedure Scouting.Insert_Treinador @Numero_Identificacao varchar(9),@Nome varchar(50),@Qualificacoes varchar(100), @Nacionalidade varchar(40),@Idade int
as 
	BEGIN
		Begin Transaction  x
			BEGIN TRY
				INSERT INTO Scouting.Treinador VALUES (@Numero_Identificacao,@Nome,@Qualificacoes, @Idade, @Nacionalidade);
				print ('Treinador Inserido')
				Commit Transaction x
			END TRY

			BEGIN CATCH 
				IF @@TRANCOUNT>0
				BEGIN
					raiserror ('Erro Inserir Treinador', 16, 1);
					RollBack Transaction x
				END
			END CATCH
	END





CREATE UNIQUE NONCLUSTERED INDEX IxJogo ON Scouting.Jogo (Jogo_Local,Jogo_Data);
CREATE UNIQUE NONCLUSTERED INDEX IxJogador ON Scouting.Jogador (ID_FIFPro);










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








