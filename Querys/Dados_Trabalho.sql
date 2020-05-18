--Inserir Dados

--Listas Observa��o Sele��o
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (21,'Sub-21')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (19,'Sub-19')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (15,'Sub-15')


--Jogadores
INSERT INTO Scouting.Jogador VALUES (1,'Andr� Pedro',1.63,70.02,1,17,0,0,21)
INSERT INTO Scouting.Jogador VALUES (2,'Rui Soares',1.82,69.02,1,16,0,0,19)
INSERT INTO Scouting.Jogador VALUES (3,'Famoso Toni',1.24,70.03,1,18,0,0,21)
INSERT INTO Scouting.Jogador VALUES (4,'Daniel Hulk',1.71,62.02,1,12,0,0,15)
INSERT INTO Scouting.Jogador VALUES (5,'Henrique Sousa',1.83,74.02,1,13,0,0,15)

INSERT INTO Scouting.Jogador VALUES (6,'Pinto Sousa',1.63,70.02,1,17,0,0,21)
INSERT INTO Scouting.Jogador VALUES (7,'Carvalho Sousa',1.82,69.02,1,16,0,0,19)
INSERT INTO Scouting.Jogador VALUES (8,'Jo�o Moutinho ',1.24,72.03,1,18,0,0,21)
INSERT INTO Scouting.Jogador VALUES (9,'Ricardo Sousa',1.71,68.02,1,12,0,0,15)
INSERT INTO Scouting.Jogador VALUES (10,'Ronaldo Sousa',1.83,69.02,1,19,0,0,21)

--Treinadores
INSERT INTO Scouting.Treinador VALUES(1,'Jo�o Soares','UEFA PRO',19,'portugu�s')
INSERT INTO Scouting.Treinador VALUES(2,'Pedro Tavares','UEFA PRO',19,'ingl�s')
INSERT INTO Scouting.Treinador VALUES(3,'Guardiola','UEFA A',40,'espanhol')

--Selecionadores

INSERT INTO Scouting.Selecionador VALUES(1,'Jos� Mourinho','UEFA PRO','portugu�s',40)
INSERT INTO Scouting.Selecionador VALUES(2,'Jorge Jesus','UEFA B','portugu�s',21)
INSERT INTO Scouting.Selecionador VALUES(3,'Low','UEFA PRO','alem�o',30)

--Observadores

INSERT INTO Scouting.Observador VALUES(1,'Jos� Boto','','portugu�s',42,'Aveiro')
INSERT INTO Scouting.Observador VALUES(2,'Antero Henriques','UEFA A','portugu�s',43,'Lisboa')


--Clubes
INSERT INTO Scouting.Clube VALUES (1,'Portugal','FCP')
INSERT INTO Scouting.Clube VALUES (2,'Portugal','Arouca')


INSERT INTO Scouting.Responsavel VALUES (21,3,'2019-05-01','2020-06-01')
INSERT INTO Scouting.Responsavel VALUES (15,1,'4-01-2016','4-01-2018')
INSERT INTO Scouting.Responsavel VALUES (19,2,'1-07-2014','1-07-2022')

--Treina
INSERT INTO Scouting.Treina VALUES(1,null,'2017-02-01',2)
INSERT INTO Scouting.Treina VALUES(2,'2019-03-21','2017-02-01',1)

--Competi��es
INSERT INTO Scouting.Competicao VALUES (1,'Iniciados',23)


--Jogos
INSERT INTO Scouting.Jogo Values('Arouca','2012-05-11','2-0',1,1)

--Relat�rio
INSERT INtO Scouting.Relatorio Values(1,'Relat�rio Jo�o Moutinho','2012-05-13',1,8,'Arouca','2012-05-11')

--Participa_em
INSERT INTO Scouting.Participa_Em Values(1,'2012-05-11','Arouca',21)
INSERT INTO Scouting.Participa_Em Values(2,'2012-05-11','Arouca',18)

--Pertence_Clube

INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (1,8,'1-07-2010','1-07-2013')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (2,3,'1-07-2010','1-07-2013')



SELECT Jogador_Nome,Clube_Nome FROM   Scouting.Jogador JOIN (Scouting.Jogador_Pertence_Clube join Scouting.Clube ON Scouting.Jogador_Pertence_Clube.JPC_Clube_Numero_Inscricao_FIFA=Scouting.Clube.Clube_Numero_Inscricao_FIFA ) ON Scouting.Jogador.ID_FIFPRO = Scouting.Jogador_Pertence_Clube.ID_FIFPRO


--Metodo de Observacao
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',1)

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


SELECT * FROM Scouting.Jogador JOIN (Scouting.Relatorio JOIN Scouting.Dados_Analiticos_Rel ON Scouting.Relatorio.ID=Scouting.Dados_Analiticos_Rel.Rel_ID) ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro
WHERE Scouting.Dados_Analiticos_Rel.Capacidade_Decisao>75;

SELECT * FROM Scouting.Observacao_Metodo_De_Observacao JOIN (Scouting.Relatorio JOIN Scouting.Jogador ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro) ON ID=ID_Relatorio
WHERE Scouting.Observacao_Metodo_De_Observacao.O_Metodo_de_Observacao='Presencial';

SELECT * FROM Scouting.Observacao_Metodo_De_Observacao JOIN (Scouting.Relatorio JOIN Scouting.Jogador ON Scouting.Jogador.ID_FIFPro=Scouting.Relatorio.ID_FIFPro) ON ID=ID_Relatorio
WHERE Scouting.Observacao_Metodo_De_Observacao.O_Metodo_de_Observacao='Presencial';

SELECT DISTINCT Scouting.Jogador.ID_FIFPro,Scouting.Jogador.*,Scouting.Jog_Posicoes.J_Posicoes FROM Scouting.Jog_Posicoes JOIN (Scouting.Relatorio JOIN Scouting.Jogador ON Scouting.Relatorio.ID_FIFPro=Scouting.Jogador.ID_FIFPro) ON Scouting.Jog_Posicoes.Jog_Posicoes_ID_FIFPro=Scouting.Relatorio.ID_FIFPro
WHERE J_Posicoes='MC';