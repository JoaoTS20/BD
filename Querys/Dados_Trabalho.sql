--Inserir Dados

--Listas Observação Seleção
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (21,'Sub-21')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (19,'Sub-19')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (15,'Sub-15')


--Jogadores
INSERT INTO Scouting.Jogador VALUES (1,'André Pedro',1.63,70.02,1,17,0,0,21)
INSERT INTO Scouting.Jogador VALUES (2,'Rui Soares',1.82,69.02,1,16,0,0,19)
INSERT INTO Scouting.Jogador VALUES (3,'Famoso Toni',1.24,70.03,1,18,0,0,21)
INSERT INTO Scouting.Jogador VALUES (4,'Daniel Hulk',1.71,62.02,1,12,0,0,15)
INSERT INTO Scouting.Jogador VALUES (5,'Henrique Sousa',1.83,74.02,1,13,0,0,15)

INSERT INTO Scouting.Jogador VALUES (6,'Pinto Sousa',1.63,70.02,1,17,0,0,21)
INSERT INTO Scouting.Jogador VALUES (7,'Carvalho Sousa',1.82,69.02,1,16,0,0,19)
INSERT INTO Scouting.Jogador VALUES (8,'João Moutinho ',1.24,72.03,1,18,0,0,21)
INSERT INTO Scouting.Jogador VALUES (9,'Ricardo Sousa',1.71,68.02,1,12,0,0,15)
INSERT INTO Scouting.Jogador VALUES (10,'Ronaldo Sousa',1.83,69.02,1,19,0,0,21)

--Treinadores
INSERT INTO Scouting.Treinador VALUES(1,'João Soares','UEFA PRO',19,'português')
INSERT INTO Scouting.Treinador VALUES(2,'Pedro Tavares','UEFA PRO',19,'inglês')
INSERT INTO Scouting.Treinador VALUES(3,'Guardiola','UEFA A',40,'espanhol')

--Selecionadores

INSERT INTO Scouting.Selecionador VALUES(1,'José Mourinho','UEFA PRO','português',40)
INSERT INTO Scouting.Selecionador VALUES(2,'Jorge Jesus','UEFA B','português',21)
INSERT INTO Scouting.Selecionador VALUES(3,'Low','UEFA PRO','alemão',30)

--Observadores

INSERT INTO Scouting.Observador VALUES(1,'José Boto','','português',42,'Aveiro')
INSERT INTO Scouting.Observador VALUES(2,'Antero Henriques','UEFA A','português',43,'Lisboa')
INSERT INTO Scouting.Observador VALUES(3,'Manuel Fernanades','UEFA B','português',38,'Porto')
INSERT INTO Scouting.Observador VALUES(4,'Bruno Emanuel','','português',31,'Aveiro')


--Clubes
INSERT INTO Scouting.Clube VALUES (1,'Portugal','FCP')
INSERT INTO Scouting.Clube VALUES (2,'Portugal','Arouca')

--Responsavel
INSERT INTO Scouting.Responsavel VALUES (21,3,'2019-05-01','2020-06-01')
INSERT INTO Scouting.Responsavel VALUES (15,1,'4-01-2016','4-01-2018')
INSERT INTO Scouting.Responsavel VALUES (19,2,'1-07-2014','1-07-2022')

--Treina
INSERT INTO Scouting.Treina VALUES(1,null,'2017-02-01',2)
INSERT INTO Scouting.Treina VALUES(2,'2019-03-21','2017-02-01',1)

--Competições
INSERT INTO Scouting.Competicao VALUES (1,'Iniciados',23)
INSERT INTO Scouting.Competicao VALUES (2,'Juvenis Nacional PT A',18)
INSERT INTO Scouting.Competicao VALUES (3,'Juniores Nacional PT A',18)

--Inscrito Em
INSERT INTO Scouting.Inscrito_Em VALUES (1,1,25,'12-07-2010')
INSERT INTO Scouting.Inscrito_Em VALUES (2,2,23,'10-03-2010')

--Jogos
INSERT INTO Scouting.Jogo VALUES('Arouca','2012-05-11','2-0',1,1)
INSERT INTO Scouting.Jogo VALUES('Lisboa','2011-11-13','3-1',2,2)
INSERT INTO Scouting.Jogo VALUES('Porto','2011-11-17','0-1',3,3)
INSERT INTO Scouting.Jogo VALUES('Aveiro','2011-11-18','3-2',3,2)
SELECT * FROM Scouting.Jogo;
--Relatório
INSERT INtO Scouting.Relatorio Values('Relatório João Moutinho','2012-05-13',1,8,'Arouca','2012-05-11')
INSERT INtO Scouting.Relatorio Values('Relatório Famoso Toni','2011-11-23',2,3,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relatório Ricardo Sousa','2011-11-18',3,9,'Porto','2011-11-17')
INSERT INtO Scouting.Relatorio Values('Relatório Carvalho Sousa','2011-11-18',4,7,'Aveiro','2011-11-18')
--DELETE FROM Scouting.Relatorio WHERE Scouting.Relatorio.ID=3
--SELECT * FROM Scouting.Relatorio;

--Participa_em
INSERT INTO Scouting.Participa_Em Values(1,'2012-05-11','Arouca',21)
INSERT INTO Scouting.Participa_Em Values(2,'2012-05-11','Arouca',18)

--Pertence_Clube

INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (1,8,'1-07-2010','1-07-2013')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (2,3,'1-07-2010','1-07-2013')

--Metodo de Observacao
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',1)

--Dados_Analiticos_Abs
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
Select  *from Scouting.Metricas_Jogo_Jogador


--Jog_Posicoes
INSERT INTO Scouting.Jog_Posicoes VALUES ('MC',8);
INSERT INTO Scouting.Jog_Posicoes VALUES ('MDF',8);
INSERT INTO Scouting.Jog_Posicoes VALUES ('PL',4);
INSERT INTO Scouting.Jog_posicoes VALUES ('DLE',9);

--Analise_Jogador
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (1,70,65,'','Boa',76,83,78,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (2,78,78,'Passe','Boa',68,90,80,2);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (3,81,73,'Drible','Boa',78,83,77,3);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (0,77,80,'Visão de Jogo','Média',73,91,71,4);








--Comments
--DELETE FROM Scouting.Analise_Caracteristica_Jogador WHERE Scouting.Analise_Caracteristica_Jogador.Rel_ID=3

--Métricas do Jogo


--SELECT Jogador_Nome,Clube_Nome FROM   Scouting.Jogador JOIN (Scouting.Jogador_Pertence_Clube join Scouting.Clube ON Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Scouting.Clube.Clube_Numero_Inscricao_FIFA ) ON Scouting.Jogador.ID_FIFPRO = Scouting.Jogador_Pertence_Clube.ID_FIFPRO



--Query a relacionar isto

--SELECT * FROM Scouting.Jogador JOIN (Scouting.Observador JOIN (Scouting.Relatorio JOIN (Scouting.Dados_Analiticos_Rel JOIN Scouting.Dados_Analiticos_ABS ON Scouting.Dados_Analiticos_Rel.Rel_ID= Scouting.Dados_Analiticos_ABS.REL_ID )ON Scouting.Dados_Analiticos_Rel.Obs_Num_Iden_Federacao=ID) on Scouting.Observador.Numero_Identificacao_Federacao=Scouting.Relatorio.ID ) ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro





--SELECT * FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro


--SELECT * FROM Scouting.Jogador JOIN (Scouting.Relatorio JOIN Scouting.Dados_Analiticos_Rel ON Scouting.Relatorio.ID=Scouting.Dados_Analiticos_Rel.Rel_ID) ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro
--WHERE Scouting.Dados_Analiticos_Rel.Capacidade_Decisao>75;

--SELECT * FROM Scouting.Observacao_Metodo_De_Observacao JOIN (Scouting.Relatorio JOIN Scouting.Jogador ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro) ON ID=ID_Relatorio
--WHERE Scouting.Observacao_Metodo_De_Observacao.O_Metodo_de_Observacao='Presencial';

--SELECT * FROM Scouting.Observacao_Metodo_De_Observacao JOIN (Scouting.Relatorio JOIN Scouting.Jogador ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro) ON ID=ID_Relatorio
--WHERE Scouting.Observacao_Metodo_De_Observacao.O_Metodo_de_Observacao='Presencial';

--SELECT DISTINCT Scouting.Jogador.ID_FIFPro,Scouting.Jogador.*,Scouting.Jog_Posicoes.J_Posicoes FROM Scouting.Jog_Posicoes JOIN (Scouting.Relatorio JOIN Scouting.Jogador ON Scouting.Relatorio.ID_FIFPro=Scouting.Jogador.ID_FIFPro) ON Scouting.Jog_Posicoes.Jog_Posicoes_ID_FIFPro=Scouting.Relatorio.ID_FIFPro
--WHERE J_Posicoes='MC';