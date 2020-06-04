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
		private String _Res_Data_Inicio;
		private String _Res_Data_Final;

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
		public String Res_Data_Inicio
		{
			get { return _Res_Data_Inicio; }
			set { _Res_Data_Inicio = value; }
		}
		public String Res_Data_Final
		{
			get { return _Res_Data_Final; }
			set { _Res_Data_Final = value; }
		}
	}
}
