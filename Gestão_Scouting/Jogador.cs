using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Jogador
    {
		private String _ID_FIFPro;
		private String _Jogador_Nome;
		private String _Jogador_Altura;
		private String _Jogador_Peso;
		private String _Pe_Favorito;
		private String _Idade;
		private String _Dupla_Nacionalidade;
		private String _Numero_Internacionalizao;
		private String _Idade_Maxima;

		public String ID_FIFPro
		{
			get { return _ID_FIFPro; }
			set { _ID_FIFPro = value; }
		}


		public String Jogador_Nome
		{
			get { return _Jogador_Nome; }
			set
			{
				_Jogador_Nome = value;
			}
		}

		public String Jogador_Altura
		{
			get { return _Jogador_Altura; }
			set { _Jogador_Altura = value; }
		}

		public String Jogador_Peso
		{
			get { return _Jogador_Peso; }
			set { _Jogador_Peso = value; }
		}

		public String Pe_Favorito
		{
			get { return _Pe_Favorito; }
			set { _Pe_Favorito = value; }
		}

		public String Idade
		{
			get { return _Idade; }
			set { _Idade = value; }
		}

		public String Dupla_Nacionalidade
		{
			get { return _Dupla_Nacionalidade; }
			set { _Dupla_Nacionalidade = value; }
		}
		public String Numero_Internacionalizao
		{
			get { return _Numero_Internacionalizao; }
			set { _Numero_Internacionalizao = value; }

		}

		public String Idade_Maxima
		{
			get { return _Idade_Maxima; }
			set { _Idade_Maxima = value; }
		}


		public override String ToString()
		{
			return _ID_FIFPro + "   " + _Jogador_Nome;
		}

		public Jogador() : base()
		{
		}
	}
}
