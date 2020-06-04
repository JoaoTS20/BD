--Inserir Dados

--Listas Observa��o Sele��o
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (21,'Sub-21')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (19,'Sub-19')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (15,'Sub-15')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (17,'Sub-17')
INSERT INTO Scouting.Lista_Observacao_Selecao VALUES (45,'Senioeres')
use Proj;
SELECT * FROM Scouting.Jogador;
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

INSERT INTO Scouting.Jogador VALUES (11,'Martim Coelho',1.63,52.4,1,14,0,0,15)
INSERT INTO Scouting.Jogador VALUES (12,'Roberto Pereira',1.63,60.4,0,15,1,3,15)
INSERT INTO Scouting.Jogador VALUES (13,'Andr� Oliveira',1.78,70.02,0,17,0,13,17)
INSERT INTO Scouting.Jogador VALUES (14,'S�rgio Lima',1.71,63.2,1,16,0,0,17)
INSERT INTO Scouting.Jogador VALUES (15,'Jo�o dos Santos',1.81,67.4,1,19,1,15,19)
INSERT INTO Scouting.Jogador VALUES (16,'Filipe Matos',1.70,55.6,0,18,0,3,19)
INSERT INTO Scouting.Jogador VALUES (17,'Francisco Silva',1.75,72.2,1,20,0,0,21)
INSERT INTO Scouting.Jogador VALUES (18,'Joaquim Jos�',1.83,70.2,1,20,0,0,21)



--Treinadores
INSERT INTO Scouting.Treinador VALUES(1,'Jo�o Soares','UEFA PRO',19,'portugu�s')
INSERT INTO Scouting.Treinador VALUES(2,'Pedro Tavares','UEFA PRO',19,'ingl�s')
INSERT INTO Scouting.Treinador VALUES(3,'Guardiola','UEFA A',40,'espanhol')
INSERT INTO Scouting.Treinador VALUES(4,'Vitor Manuel','UEFA PRO',35,'brasileiro')
INSERT INTO Scouting.Treinador VALUES(5,'Zidane','UEFA PRO',45,'franc�s')
INSERT INTO Scouting.Treinador VALUES(6,'Manuel Coutinho','UEFA A',32,'portugu�s')
INSERT INTO Scouting.Treinador VALUES(7,'Fernando Silva','UEFA B',40,'portugu�s')
INSERT INTO Scouting.Treinador VALUES(8,'Fernando Madureira','UEFA PRO',35,'portugu�s')

--Selecionadores

INSERT INTO Scouting.Selecionador VALUES(1,'Jos� Mourinho','UEFA PRO','portugu�s',40)
INSERT INTO Scouting.Selecionador VALUES(2,'Jorge Jesus','UEFA B','portugu�s',21)
INSERT INTO Scouting.Selecionador VALUES(3,'Low','UEFA PRO','alem�o',30)
INSERT INTO Scouting.Selecionador VALUES(4,'Scolari','UEFA PRO','brasileiro',58)
INSERT INTO Scouting.Selecionador VALUES(5,'Fernando Santos','UEFA PRO','portugu�s',58)

--Observadores

INSERT INTO Scouting.Observador VALUES(1,'Jos� Boto','','portugu�s',42,'Aveiro')
INSERT INTO Scouting.Observador VALUES(2,'Antero Henriques','UEFA A','portugu�s',43,'Lisboa')
INSERT INTO Scouting.Observador VALUES(3,'Manuel Fernanades','UEFA B','portugu�s',38,'Porto')
INSERT INTO Scouting.Observador VALUES(4,'Bruno Emanuel','','portugu�s',31,'Aveiro')
INSERT INTO Scouting.Observador VALUES(5,'Raul Diaz','UEFA B','espanhol',37,'Braga')
INSERT INTO Scouting.Observador VALUES(6,'Bruno Amorim','UEFA PRO','portugu�s',41,'Algarve')

--Clubes
INSERT INTO Scouting.Clube VALUES (1,'Portugal','FCP')
INSERT INTO Scouting.Clube VALUES (2,'Portugal','Arouca')
INSERT INTO Scouting.Clube VALUES (3,'Portugal','SCBraga')
INSERT INTO Scouting.Clube VALUES (4,'Portugal','SCFarense')
INSERT INTO Scouting.Clube VALUES (5,'Portugal','ADValecambrense')
INSERT INTO Scouting.Clube VALUES (6,'Portugal','SLBenfica')
INSERT INTO Scouting.Clube VALUES (7,'Portugal','SCPortugal')
INSERT INTO Scouting.Clube VALUES (8,'Portugal','CFCanelas 2010')


--Responsavel
INSERT INTO Scouting.Responsavel VALUES (21,3,'2019-05-01','2020-06-01')
INSERT INTO Scouting.Responsavel VALUES (15,1,'4-01-2016','4-01-2018')
INSERT INTO Scouting.Responsavel VALUES (19,2,'1-07-2014','1-07-2022')
INSERT INTO Scouting.Responsavel VALUES (17,4,'3-06-2014','3-06-2022')

--Treina
INSERT INTO Scouting.Treina VALUES(1,null,'2017-02-01',2)
INSERT INTO Scouting.Treina VALUES(2,'2021-03-21','2017-03-21',1)
INSERT INTO Scouting.Treina VALUES(3,'2020-07-21','2018-07-21',2)
INSERT INTO Scouting.Treina VALUES(4,'2020-03-14','2018-03-14',3)
INSERT INTO Scouting.Treina VALUES(5,'2020-06-14','2018-06-14',4)
INSERT INTO Scouting.Treina VALUES(6,'2020-03-24','2018-03-24',5)
INSERT INTO Scouting.Treina VALUES(7,'2021-03-17','2018-03-17',6)
INSERT INTO Scouting.Treina VALUES(8,'2021-05-18','2018-05-18',8)
SELECT * FROM Scouting.Inscrito_Em;

--Competi��es
INSERT INTO Scouting.Competicao VALUES (1,'Iniciados',23)
INSERT INTO Scouting.Competicao VALUES (2,'Juvenis Nacional PT A',18)
INSERT INTO Scouting.Competicao VALUES (3,'Juniores Nacional PT A',18)
INSERT INTO Scouting.Competicao VALUES (4,'Liga Revela��o PT A',18)

--Inscrito Em
INSERT INTO Scouting.Inscrito_Em VALUES (1,1,25,'12-07-2019')
INSERT INTO Scouting.Inscrito_Em VALUES (2,2,23,'10-03-2019')
INSERT INTO Scouting.Inscrito_Em VALUES (3,3,21,'15-06-2019')
INSERT INTO Scouting.Inscrito_Em VALUES (4,4,26,'15-05-2019')
INSERT INTO Scouting.Inscrito_Em VALUES (5,1,26,'15-06-2019')
INSERT INTO Scouting.Inscrito_Em VALUES (6,2,24,'10-06-2019')
INSERT INTO Scouting.Inscrito_Em VALUES (7,3,22,'21-07-2019')
INSERT INTO Scouting.Inscrito_Em VALUES (8,4,22,'02-08-2019')

--Jogos
INSERT INTO Scouting.Jogo VALUES('Aveiro','2019-05-11','2-0',1,1)
INSERT INTO Scouting.Jogo VALUES('Lisboa','2020-1-13','3-1',2,2)
INSERT INTO Scouting.Jogo VALUES('Porto','2019-11-17','0-1',3,3)
INSERT INTO Scouting.Jogo VALUES('Aveiro','2020-1-10','3-2',2,2)
INSERT INTO Scouting.Jogo VALUES('Braga','2020-4-8','2-2',2,2)
INSERT INTO Scouting.Jogo VALUES('Algarve','2019-11-3','1-2',4,2)
INSERT INTO Scouting.Jogo VALUES('Lisboa','2019-12-2','0-1',3,2)
INSERT INTO Scouting.Jogo VALUES('Aveiro','2020-03-03','2-2',1,1)
INSERT INTO Scouting.Jogo VALUES('Lisboa','2019-10-11','3-2',2,2)
INSERT INTO Scouting.Jogo VALUES('Porto','2019-12-08','3-1',3,3)
INSERT INTO Scouting.Jogo VALUES('Aveiro','2020-1-05','3-3',2,2)
INSERT INTO Scouting.Jogo VALUES('Braga','2020-2-18','2-4',2,2)
INSERT INTO Scouting.Jogo VALUES('Algarve','2019-11-7','2-2',4,2)
INSERT INTO Scouting.Jogo VALUES('Lisboa','2019-10-2','3-1',3,2)
SELECT * FROM Scouting.Jogo;

--Relat�rio
SELECT * FROM Scouting.Relatorio;
INSERT INtO Scouting.Relatorio Values('Relat�rio Famoso Toni','2011-11-23',2,3,'Lisboa','2020-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Jo�o Moutinho','2012-05-13',1,8,'Arouca','2019-05-11')
INSERT INtO Scouting.Relatorio Values('Relat�rio Ricardo Sousa','2011-11-18',3,9,'Porto','2019-11-17')
INSERT INtO Scouting.Relatorio Values('Relat�rio Carvalho Sousa','2012-1-13',4,7,'Aveiro','2020-1-10')
INSERT INtO Scouting.Relatorio Values('Relat�rio Andr� Pedro','2011-11-18',4,1,'Aveiro','2020-1-10')
INSERT INtO Scouting.Relatorio Values('Relat�rio Rui Soares','2011-11-18',4,2,'Aveiro','2020-1-10')
INSERT INtO Scouting.Relatorio Values('Relat�rio Daniel Hulk','2011-11-23',2,4,'Lisboa','2020-1-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Henrique Sousa','2011-11-23',2,5,'Lisboa','2020-1-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Pinto Sousa','2011-11-23',2,6,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Ronaldo Sousa','2011-11-23',2,10,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Martim Coelho','2011-11-23',2,11,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Roberto Pereira','2011-11-23',2,12,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Andr� Oliveira','2011-11-23',2,13,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio S�rgio Lima','2011-11-23',2,14,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Jo�o Santos','2011-11-23',2,15,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Filipe Matos','2011-11-23',2,16,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Francisco Silva','2011-11-23',2,17,'Lisboa','2011-11-13')
INSERT INtO Scouting.Relatorio Values('Relat�rio Joaquim Jos�','2011-11-23',2,18,'Lisboa','2011-11-13')


--DELETE FROM Scouting.Relatorio WHERE Scouting.Relatorio.ID=3
--SELECT * FROM Scouting.Relatorio;

--Participa_em  POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR
INSERT INTO Scouting.Participa_Em Values(1,'2012-05-11','Arouca',21)
INSERT INTO Scouting.Participa_Em Values(2,'2012-05-11','Arouca',18)
INSERT INTO Scouting.Participa_Em Values(1,'2012-05-11','Arouca',21)
INSERT INTO Scouting.Participa_Em Values(2,'2012-05-11','Arouca',18)
INSERT INTO Scouting.Participa_Em Values(1,'2012-05-11','Arouca',21)
INSERT INTO Scouting.Participa_Em Values(2,'2012-05-11','Arouca',18)
INSERT INTO Scouting.Participa_Em Values(1,'2012-05-11','Arouca',21)
INSERT INTO Scouting.Participa_Em Values(2,'2012-05-11','Arouca',18)

--Pertence_Clube
SELECT * FROM Scouting.Jogador_Pertence_Clube;
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (1,8,'6-03-2017','6-03-2020')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (2,3,'7-05-2017','7-05-2021')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (3,1,'11-07-2017','11-07-2022')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (4,2,'14-07-2017','14-07-2022')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (5,4,'11-02-2018','11-02-2021')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (6,5,'17-02-2018','17-02-2020')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (7,6,'4-06-2018','4-06-2021')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (1,7,'7-06-2018','7-06-2021')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (3,9,'15-06-2018','15-06-2022')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (4,10,'1-07-2018','1-07-2023')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (5,11,'3-08-2018','3-08-2022')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (6,12,'4-03-2019','4-03-2022')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (7,13,'27-03-2019','27-03-2021')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (1,14,'1-06-2019','1-06-2020')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (2,15,'6-06-2019','6-06-2021')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (3,16,'13-06-2019','13-06-2022')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (4,17,'19-07-2019','19-07-2023')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (2,18,'21-07-2019','21-07-2022')

--Metodo de Observacao
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',1)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',2)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',3)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',4)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',5)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',6)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',7)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',8)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',9)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',10)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',11)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',12)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',13)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',14)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',15)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',16)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',17)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Dist�ncia',18)

--Dados_Analiticos_Abs POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (0,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,6,1,32,0,2,25,5,2,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,12,6,1,32,0,2,25,5,2,1)
Select  *from Scouting.Metricas_Jogo_Jogador;

--Analise_Jogador POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR POR ALTERAR
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (1,70,65,'','Boa',76,83,78,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (2,78,78,'Passe','Boa',68,90,80,2);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (3,81,73,'Drible','Boa',78,83,77,3);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (0,77,80,'Vis�o de Jogo','M�dia',73,91,71,4);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (1,70,65,'','Boa',76,83,78,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (2,78,78,'Passe','Boa',68,90,80,2);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (3,81,73,'Drible','Boa',78,83,77,3);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (0,77,80,'Vis�o de Jogo','M�dia',73,91,71,4);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (1,70,65,'','Boa',76,83,78,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (2,78,78,'Passe','Boa',68,90,80,2);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (3,81,73,'Drible','Boa',78,83,77,3);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (0,77,80,'Vis�o de Jogo','M�dia',73,91,71,4);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (1,70,65,'','Boa',76,83,78,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (2,78,78,'Passe','Boa',68,90,80,2);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (3,81,73,'Drible','Boa',78,83,77,3);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (0,77,80,'Vis�o de Jogo','M�dia',73,91,71,4);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (1,70,65,'','Boa',76,83,78,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (2,78,78,'Passe','Boa',68,90,80,2);

--Jog_Posicoes
INSERT INTO Scouting.Jog_Posicoes VALUES ('MC',8);
INSERT INTO Scouting.Jog_Posicoes VALUES ('MDF',8);
INSERT INTO Scouting.Jog_Posicoes VALUES ('PL',4);
INSERT INTO Scouting.Jog_posicoes VALUES ('DLD',9);
INSERT INTO Scouting.Jog_Posicoes VALUES ('MCO',1);
INSERT INTO Scouting.Jog_Posicoes VALUES ('EE',2);
INSERT INTO Scouting.Jog_Posicoes VALUES ('ED',3);
INSERT INTO Scouting.Jog_posicoes VALUES ('DC',4);
INSERT INTO Scouting.Jog_Posicoes VALUES ('DC',5);
INSERT INTO Scouting.Jog_Posicoes VALUES ('GR',6);
INSERT INTO Scouting.Jog_Posicoes VALUES ('PL',7);
INSERT INTO Scouting.Jog_posicoes VALUES ('PL',10);
INSERT INTO Scouting.Jog_Posicoes VALUES ('ED',11);
INSERT INTO Scouting.Jog_Posicoes VALUES ('DLD',12);
INSERT INTO Scouting.Jog_Posicoes VALUES ('DLE',13);
INSERT INTO Scouting.Jog_posicoes VALUES ('DLE',14);
INSERT INTO Scouting.Jog_Posicoes VALUES ('GR',15);
INSERT INTO Scouting.Jog_Posicoes VALUES ('MDF',16);
INSERT INTO Scouting.Jog_Posicoes VALUES ('MCO',17);
INSERT INTO Scouting.Jog_posicoes VALUES ('DLE',18);





--Comments
--DELETE FROM Scouting.Analise_Caracteristica_Jogador WHERE Scouting.Analise_Caracteristica_Jogador.Rel_ID=3

--M�tricas do Jogo


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