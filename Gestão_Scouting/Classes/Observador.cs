using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
	class Observador
	{
		private String _Numero_Identificacao_Federacao;
		private String _Observador_Nome;
		private String _Observador_Qualificacoes;
		private String _Observador_Nacionalidade;
		private String _Observador_Idade;
		private String _Area_Observacao;

		public String Numero_Identificacao_Federacao
		{
			get { return _Numero_Identificacao_Federacao; }
			set { _Numero_Identificacao_Federacao = value; }
		}
		public String Observador_Nome
		{
			get { return _Observador_Nome; }
			set { _Observador_Nome = value; }
		}

		public String Observador_Nacionalidade
		{
			get { return _Observador_Nacionalidade; }
			set { _Observador_Nacionalidade = value; }
		}

		public String Observador_Idade
		{
			get { return _Observador_Idade; }
			set { _Observador_Idade = value; }
		}

		public String Area_Observacao
		{
			get { return _Area_Observacao; }
			set { _Area_Observacao = value; }
		}
	}
}
