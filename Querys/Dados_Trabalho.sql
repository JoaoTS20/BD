--Inserir Dados

--Listas Observação Seleção
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (21,'Sub-21')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (19,'Sub-19')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (15,'Sub-15')
INSERT INTO Scouting.Lista_Observacao_selecao VALUES (17,'Sub-17')
INSERT INTO Scouting.Lista_Observacao_Selecao VALUES (45,'Senioeres')
use Proj;
SELECT * FROM Scouting.Jogador;
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

INSERT INTO Scouting.Jogador VALUES (11,'Martim Coelho',1.63,52.4,1,14,0,0,15)
INSERT INTO Scouting.Jogador VALUES (12,'Roberto Pereira',1.63,60.4,0,15,1,3,15)
INSERT INTO Scouting.Jogador VALUES (13,'André Oliveira',1.78,70.02,0,17,0,13,17)
INSERT INTO Scouting.Jogador VALUES (14,'Sérgio Lima',1.71,63.2,1,16,0,0,17)
INSERT INTO Scouting.Jogador VALUES (15,'João dos Santos',1.81,67.4,1,19,1,15,19)
INSERT INTO Scouting.Jogador VALUES (16,'Filipe Matos',1.70,55.6,0,18,0,3,19)
INSERT INTO Scouting.Jogador VALUES (17,'Francisco Silva',1.75,72.2,1,20,0,0,21)
INSERT INTO Scouting.Jogador VALUES (18,'Joaquim José',1.83,70.2,1,20,0,0,21)



--Treinadores
INSERT INTO Scouting.Treinador VALUES(1,'João Soares','UEFA PRO',19,'português')
INSERT INTO Scouting.Treinador VALUES(2,'Pedro Tavares','UEFA PRO',19,'inglês')
INSERT INTO Scouting.Treinador VALUES(3,'Guardiola','UEFA A',40,'espanhol')
INSERT INTO Scouting.Treinador VALUES(4,'Vitor Manuel','UEFA PRO',35,'brasileiro')
INSERT INTO Scouting.Treinador VALUES(5,'Zidane','UEFA PRO',45,'francês')
INSERT INTO Scouting.Treinador VALUES(6,'Manuel Coutinho','UEFA A',32,'português')
INSERT INTO Scouting.Treinador VALUES(7,'Fernando Silva','UEFA B',40,'português')
INSERT INTO Scouting.Treinador VALUES(8,'Fernando Madureira','UEFA PRO',35,'português')

--Selecionadores

INSERT INTO Scouting.Selecionador VALUES(1,'José Mourinho','UEFA PRO','português',40)
INSERT INTO Scouting.Selecionador VALUES(2,'Jorge Jesus','UEFA B','português',21)
INSERT INTO Scouting.Selecionador VALUES(3,'Low','UEFA PRO','alemão',30)
INSERT INTO Scouting.Selecionador VALUES(4,'Scolari','UEFA PRO','brasileiro',58)
INSERT INTO Scouting.Selecionador VALUES(5,'Fernando Santos','UEFA PRO','português',58)

--Observadores

INSERT INTO Scouting.Observador VALUES(1,'José Boto','','português',42,'Aveiro')
INSERT INTO Scouting.Observador VALUES(2,'Antero Henriques','UEFA A','português',43,'Lisboa')
INSERT INTO Scouting.Observador VALUES(3,'Manuel Fernanades','UEFA B','português',38,'Porto')
INSERT INTO Scouting.Observador VALUES(4,'Bruno Emanuel','','português',31,'Aveiro')
INSERT INTO Scouting.Observador VALUES(5,'Raul Diaz','UEFA B','espanhol',37,'Braga')
INSERT INTO Scouting.Observador VALUES(6,'Bruno Amorim','UEFA PRO','português',41,'Algarve')

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
INSERT INTO Scouting.Responsavel VALUES (15,1,'2018-01-04','2022-01-04')
INSERT INTO Scouting.Responsavel VALUES (19,2,'2018-07-01','2022-07-01')
INSERT INTO Scouting.Responsavel VALUES (17,4,'2018-06-03','2022-06-03')

--Treina
INSERT INTO Scouting.Treina VALUES(1,null,'2017-02-01',2)
INSERT INTO Scouting.Treina VALUES(2,'2021-03-21','2017-03-21',1)
INSERT INTO Scouting.Treina VALUES(3,'2020-07-21','2018-07-21',2)
INSERT INTO Scouting.Treina VALUES(4,'2020-03-14','2018-03-14',3)
INSERT INTO Scouting.Treina VALUES(5,'2020-06-14','2018-06-14',4)
INSERT INTO Scouting.Treina VALUES(6,'2020-03-24','2018-03-24',5)
INSERT INTO Scouting.Treina VALUES(7,'2021-03-17','2018-03-17',6)
INSERT INTO Scouting.Treina VALUES(8,'2021-05-18','2018-05-18',8)
SELECT * FROM Scouting.Treina;

--Competições
INSERT INTO Scouting.Competicao VALUES (1,'Iniciados',23)
INSERT INTO Scouting.Competicao VALUES (2,'Juvenis Nacional PT A',18)
INSERT INTO Scouting.Competicao VALUES (3,'Juniores Nacional PT A',18)
INSERT INTO Scouting.Competicao VALUES (4,'Liga Revelação PT A',18)

--Inscrito Em
INSERT INTO Scouting.Inscrito_Em VALUES (1,1,25,'2019-07-12')
INSERT INTO Scouting.Inscrito_Em VALUES (2,2,23,'2019-03-10')
INSERT INTO Scouting.Inscrito_Em VALUES (3,3,21,'2019-06-15')
INSERT INTO Scouting.Inscrito_Em VALUES (4,4,26,'2019-05-15')
INSERT INTO Scouting.Inscrito_Em VALUES (5,1,26,'2019-06-15')
INSERT INTO Scouting.Inscrito_Em VALUES (6,2,24,'2019-06-10')
INSERT INTO Scouting.Inscrito_Em VALUES (7,3,22,'2019-07-21')
INSERT INTO Scouting.Inscrito_Em VALUES (8,4,22,'2019-08-02')

--Jogos
INSERT INTO Scouting.Jogo VALUES('Aveiro','2019-05-11','2-0',1,1)
INSERT INTO Scouting.Jogo VALUES('Lisboa','2020-01-13','3-1',2,2)
INSERT INTO Scouting.Jogo VALUES('Porto','2019-11-17','0-1',3,3)
INSERT INTO Scouting.Jogo VALUES('Aveiro','2020-01-10','3-2',2,4)
INSERT INTO Scouting.Jogo VALUES('Braga','2020-04-08','2-2',2,5)
INSERT INTO Scouting.Jogo VALUES('Algarve','2019-11-03','1-2',4,6)
INSERT INTO Scouting.Jogo VALUES('Lisboa','2019-12-02','0-1',3,2)
INSERT INTO Scouting.Jogo VALUES('Aveiro','2020-03-03','2-2',1,4)
INSERT INTO Scouting.Jogo VALUES('Lisboa','2019-10-11','3-2',2,2)
INSERT INTO Scouting.Jogo VALUES('Porto','2019-12-08','3-1',3,3)
INSERT INTO Scouting.Jogo VALUES('Aveiro','2020-01-05','3-3',2,1)
INSERT INTO Scouting.Jogo VALUES('Braga','2020-02-18','2-4',2,5)
INSERT INTO Scouting.Jogo VALUES('Algarve','2019-11-07','2-2',4,6)
INSERT INTO Scouting.Jogo VALUES('Lisboa','2019-10-02','3-1',3,2)
SELECT * FROM Scouting.Jogo;

--Relatório
SELECT * FROM Scouting.Relatorio;
INSERT INtO Scouting.Relatorio Values('Relatório Famoso Toni','2019-01-13',2,3,'Lisboa','2020-01-13')
INSERT INtO Scouting.Relatorio Values('Relatório João Moutinho','2019-05-14',1,8,'Aveiro','2019-05-11')
INSERT INtO Scouting.Relatorio Values('Relatório Ricardo Sousa','2019-11-18',3,9,'Porto','2019-11-17')
INSERT INtO Scouting.Relatorio Values('Relatório Carvalho Sousa','2020-01-11',4,7,'Aveiro','2020-01-10')
INSERT INtO Scouting.Relatorio Values('Relatório André Pedro','2020-03-11',4,1,'Aveiro','2020-03-03')
INSERT INtO Scouting.Relatorio Values('Relatório Rui Soares','2020-01-12',4,2,'Aveiro','2020-01-10')
INSERT INtO Scouting.Relatorio Values('Relatório Daniel Hulk','2019-12-17',3,4,'Porto','2019-12-08')
INSERT INtO Scouting.Relatorio Values('Relatório Henrique Sousa','2020-01-18',2,5,'Lisboa','2020-01-13')
INSERT INtO Scouting.Relatorio Values('Relatório Pinto Sousa','2019-10-13',2,6,'Lisboa','2019-10-11')
INSERT INtO Scouting.Relatorio Values('Relatório Ronaldo Sousa','2019-12-04',2,10,'Lisboa','2019-12-02')
INSERT INtO Scouting.Relatorio Values('Relatório Martim Coelho','2019-11-06',6,11,'Algarve','2019-11-03')
INSERT INtO Scouting.Relatorio Values('Relatório Roberto Pereira','2019-12-04',2,12,'Lisboa','2019-12-02')
INSERT INtO Scouting.Relatorio Values('Relatório André Oliveira','2020-02-22',5,13,'Braga','2020-02-18')
INSERT INtO Scouting.Relatorio Values('Relatório Sérgio Lima','2019-11-10',6,14,'Algarve','2019-11-07')
INSERT INtO Scouting.Relatorio Values('Relatório João Santos','2020-01-14',2,15,'Lisboa','2020-01-13')
INSERT INtO Scouting.Relatorio Values('Relatório Filipe Matos','2020-01-09',5,16,'Braga','2020-01-05')
INSERT INtO Scouting.Relatorio Values('Relatório Francisco Silva','2019-12-04',2,17,'Lisboa','2019-12-02')
INSERT INtO Scouting.Relatorio Values('Relatório Joaquim José','2019-11-19',3,18,'Porto','2019-11-17')


--DELETE FROM Scouting.Relatorio WHERE Scouting.Relatorio.ID=3
SELECT * FROM Scouting.Relatorio;
DELETE FROM Scouting.Relatorio;
--Participa_em
INSERT INTO Scouting.Participa_Em Values(1,'2020-01-10','Aveiro',21)
INSERT INTO Scouting.Participa_Em Values(2,'2019-11-17','Porto',18)
INSERT INTO Scouting.Participa_Em Values(3,'2019-05-11','Aveiro',21)
INSERT INTO Scouting.Participa_Em Values(4,'2020-02-18','Braga',18)
INSERT INTO Scouting.Participa_Em Values(5,'2019-11-07','Algarve',21)
INSERT INTO Scouting.Participa_Em Values(6,'2020-02-08','Braga',18)
INSERT INTO Scouting.Participa_Em Values(7,'2020-01-13','Lisboa',21)
INSERT INTO Scouting.Participa_Em Values(8,'2019-11-17','Porto',18)

--Pertence_Clube
SELECT * FROM Scouting.Participa_Em;
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (1,8,'2017-03-06','2020-03-06')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (2,3,'2017-05-07','2021-05-07')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (3,1,'2017-07-11','2022-07-11')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (4,2,'2017-07-14','2022-07-14')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (5,4,'2018-02-11','2021-02-11')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (6,5,'2018-02-17','2020-02-17')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (7,6,'2018-06-04','2021-06-04')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (1,7,'2018-06-07','2021-06-07')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (3,9,'2018-06-15','2022-06-15')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (4,10,'2018-07-01','2023-07-01')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (5,11,'2018-08-03','2022-08-03')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (6,12,'2019-03-04','2022-03-04')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (7,13,'2019-03-27','2021-03-27')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (1,14,'2019-06-01','2020-06-01')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (2,15,'2019-06-06','2021-06-06')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (3,16,'2019-06-13','2022-06-13')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (4,17,'2019-07-19','2023-07-19')
INSERT INTO Scouting.Jogador_Pertence_Clube VALUES (2,18,'2019-07-21','2022-07-21')

--Metodo de Observacao
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',1)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',2)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',3)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',4)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',5)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',6)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',7)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',8)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',9)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',10)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',11)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',12)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',13)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',14)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Presencial',15)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',16)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',17)
INSERT INTO Scouting.Observacao_Metodo_de_Observacao VALUES ('Distância',18)

--Dados_Analiticos_Abs
--INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,0,1,12,9,3,32,0,2,25,5,2,1)
--INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,1,1,43,29,4,80,0,7.2,125,5,4,4)
--INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (0,2,0,66,38,7,70,0,6.4,92,1,2,6)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (1,3,0,45,33,3,45,0,2.5,65,1,3,6)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (0,4,0,71,60,8,80,0,6.8,98,2,1,2)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (0,5,1,25,18,2,25,0,1.5,43,7,2,3)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (1,6,0,61,44,5,78,0,6.8,80,6,1,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (1,7,0,33,24,4,40,0,3.5,62,3,5,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (1,8,0,36,30,4,37,0,2.4,39,2,2,3)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (0,9,0,10,7,2,90,4,0.9,25,0,0,5)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (0,10,0,65,51,9,81,0,9.3,87,1,3,6)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (0,11,0,78,62,11,90,0,8.3,91,3,3,6)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (1,12,0,65,48,9,70,0,6.3,91,6,2,5)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (1,13,0,45,34,9,65,0,5.2,49,7,6,3)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (1,14,1,34,23,6,50,0,4.8,39,4,5,1)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (0,15,0,7,6,1,90,9,1,16,0,0,2)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,16,0,65,51,10,75,0,6.1,73,5,4,4)
INSERT INTO Scouting.Metricas_Jogo_Jogador VALUES (2,17,0,78,60,12,90,7,8.9,81,2,3,6)
DELETE FROM Scouting.Metricas_Jogo_Jogador;
Select  *from Scouting.Metricas_Jogo_Jogador WHERE Rel_ID=15;
SELECT * FROM Scouting.Analise_Caracteristica_Jogador;
--Analise_Jogador
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (1,70,71,'Remate','Boa',76,83,78,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (2,78,78,'Passe','Boa',68,90,80,4);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (3,81,73,'Drible','Muito Boa',78,83,77,6);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (4,76,85,'Visão de Jogo','Média',73,91,71,6);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (5,70,65,'Drible','Média',76,83,78,2);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (6,83,78,'Passe','Boa',68,90,80,3);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (7,76,77,'Drible','Muito Boa',88,83,77,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (8,77,80,'Visão de Jogo','Muito Boa',85,91,71,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (9,75,69,'Antecipação','Boa',78,83,78,3);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (10,78,80,'Passe','Boa',68,75,80,5);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (11,87,73,'Corte','Boa',78,79,77,6);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (12,79,67,'Liderança','Média',68,91,71,4);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (13,79,65,'Agressividade na bola','Muito Boa',78,83,78,5);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (14,78,73,'Visão de Jogo','Boa',70,90,80,3);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (15,83,78,'Reflexos','Boa',78,83,77,1);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (16,90,80,'Visão de Jogo','Média',68,91,71,2);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (17,70,65,'Drible','Muito Boa',81,83,78,4);
INSERT INTO Scouting.Analise_Caracteristica_Jogador VALUES (0,78,80,'Passe','Boa',68,90,80,6);

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

use Proj;

CREATE DATABASE Proj;
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