using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Selecionador
    {
		private String _Selecionador_Numero_Identificacao_Federacao;
		private String _Selecionador_Nome;
		private String _Selecionador_Qualificacao;
		private String _Selecionador_Nacionalidade;
		private String _Selecionador_Idade;


		public String Selecionador_Numero_Identificacao_Federacao
		{
			get { return _Selecionador_Numero_Identificacao_Federacao; }
			set { _Selecionador_Numero_Identificacao_Federacao = value; }
		}
		public String Selecionador_Nome
		{
			get { return _Selecionador_Nome; }
			set { _Selecionador_Nome = value; }
		}
		public String Selecionador_Qualificacao
		{
			get { return _Selecionador_Qualificacao; }
			set { _Selecionador_Qualificacao = value; }
		}
		public String Selecionador_Nacionalidade
		{
			get { return _Selecionador_Nacionalidade; }
			set { _Selecionador_Nacionalidade = value; }
		}
		public String Selecionador_Idade
		{
			get { return _Selecionador_Idade; }
			set { _Selecionador_Idade = value; }
		}
		public override string ToString()
		{
			return Selecionador_Numero_Identificacao_Federacao + "  " + Selecionador_Nome;
		}
	}
}
