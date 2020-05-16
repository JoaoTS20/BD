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

INSERT INTO Scouting.Selecionador VALUES(1,'José Mourinho','UEFA PRO','português',40,'2019-05-01','2020-06-01',21)
INSERT INTO Scouting.Selecionador VALUES(2,'Jorge Jesus','UEFA B','português',21,'2018-05-01','2019-06-01',15)
INSERT INTO Scouting.Selecionador VALUES(3,'Low','UEFA PRO','alemão',30,'2017-05-01','2019-06-01',19)

--Observadores

INSERT INTO Scouting.Observador VALUES(1,'José Boto','','português',42,'Aveiro')
INSERT INTO Scouting.Observador VALUES(2,'Antero Henriques','UEFA A','português',43,'Lisboa')


--Clubes
INSERT INTO Scouting.Clube VALUES (1,'Portugal','FCP',2,null,'2017-02-01')
INSERT INTO Scouting.Clube VALUES (2,'Portugal','Arouca',1,'2019-03-21','2017-02-01')



--Competições
INSERT INTO Scouting.Competicao VALUES (1,'Iniciados',23)


--Jogos
INSERT INTO Scouting.Jogo Values('Arouca','2012-05-11','2-0',1,1)

--Relatório
INSERT INtO Scouting.Relatorio Values(1,'Relatório João Moutinho','2012-05-13',1,8,'Arouca','2012-05-11')

--Participa_em
INSERT INTO Scouting.Participa_Em Values(1,'2012-05-11','Arouca',21)
INSERT INTO Scouting.Participa_Em Values(2,'2012-05-11','Arouca',18)

--Pertence_Clube

INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (1,8,'1-07-2010','1-07-2013')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (2,3,'1-07-2010','1-07-2013')

SELECT Jogador_Nome,Clube_Nome FROM   Scouting.Jogador JOIN (Scouting.Jogador_Pertence_Clube join Scouting.Clube ON Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Scouting.Clube.Clube_Numero_Inscricao_FIFA ) ON Scouting.Jogador.ID_FIFPRO = Scouting.Jogador_Pertence_Clube.ID_FIFPRO


--Metodo de Observacao
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES (1,1)

--Dados_Analiticos_Abs
INSERT INTO Scouting.Dados_Analiticos_ABS VALUES (0,1,2,12,6,1,32,0,2,25,5,2,1)

--Dados_Analiticos_Rel
INSERT INTO Scouting.Dados_Analiticos_Rel VALUES (1,72,91,'Passe','Boa',81,90,72,1)

--Query a relacionar isto

SELECT * FROM Scouting.Jogador JOIN (Scouting.Observador JOIN (Scouting.Relatorio JOIN (Scouting.Dados_Analiticos_Rel JOIN Scouting.Dados_Analiticos_ABS ON Scouting.Dados_Analiticos_Rel.Rel_ID= Scouting.Dados_Analiticos_ABS.REL_ID )ON Scouting.Dados_Analiticos_Rel.Obs_Num_Iden_Federacao=ID) on Scouting.Observador.Numero_Identificacao_Federacao=Scouting.Relatorio.ID ) ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro


--Jog_Posicoes
INSERT INTO Scouting.Jog_Posicoes VALUES ('MC',8);
INSERT INTO Scouting.Jog_Posicoes VALUES ('MDF',8);

SELECT * FROM Scouting.Jogador JOIN Scouting.Jog_Posicoes ON ID_FIFPro=Jog_Posicoes_ID_FIFPro


