USE Roman;
GO

INSERT INTO TipoUsuario(TipoUsuario)
VALUES				   ('Professor'),
					   ('Administrador');

INSERT INTO Tema(Nome)
VALUES			('FrontEnd'),
				('Banco de dados'),
				('BackEnd'),
				('Gest�o');

INSERT INTO Projeto (Nome, Descricao, IdTema)
VALUES					('WishList', 'Aplica��o para simular uma lista de desejos feito com Banco de dados e FrontEnd', 1),
						('E-Players', 'Aplica��o quase inteiramente em html, Css e C#.', 3),
						('SpMedicalGroup', 'Aplica��o que simula uma clinica, feito com banco de dados, BackEnd e FrontEnd', 2),
						('Relogio', 'Aplica��o feita totalmente em ReactJS', 3);

INSERT INTO Equipe(Nome)
VALUES				('Multimidia'),
					('Desenvolvimento de Sistemas'),
					('Redes');


INSERT INTO Usuario(Nome, Email, Senha, idTipoUsuario, idEquipe)
VALUES				('Yuri', 'Yuri@email.com', 'yuri123', 1, 1),
					('Giovanni', 'giovanni@email.com', 'giovanniel123', 1, 1),
					('Caic', 'caic@email.com', 'caic123', 2, 2),
					('Marcos', 'marcos@email.com', 'marcos123', 2, 2);

