using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
	
	class Dados_Analiticos_Rel
    {
		private String _Rel_ID;
		private String _Qualidade_Atual;
		private String _Qualidade_Potencial;
		private String _Melhor_Atributo;
		private String _Etica_Trabalho;
		private String _Determinacao;
		private String _Capacidade_Decisao;
		private String _Nivel_Tecnica;
		private String _Obs_Num_Iden_Federacao;

		public String Rel_ID
		{
			get { return _Rel_ID; }
			set { _Rel_ID = value; }
		}

		public String Qualidade_Atual
		{
			get { return _Qualidade_Atual; }
			set { _Qualidade_Atual = value; }
		}

		public String Qualidade_Potencial
		{
			get { return _Qualidade_Potencial; }
			set { _Qualidade_Potencial = value; }
		}

		public String Melhor_Atributo
		{
			get { return _Melhor_Atributo; }
			set { _Melhor_Atributo = value; }
		}

		public String Etica_Trabalho
		{
			get { return _Etica_Trabalho; }
			set { _Etica_Trabalho = value; }
		}

		public String Determinacao
		{
			get { return _Determinacao; }
			set { _Determinacao = value; }
		}

		public String Capacidade_Decisao
		{
			get { return _Capacidade_Decisao; }
			set { _Capacidade_Decisao = value; }
		}

		public String Nivel_tecnica
		{
			get { return _Nivel_Tecnica; }
			set { _Nivel_Tecnica = value; }
		}

		public String Obs_Num_Iden_Federacao
		{
			get { return _Obs_Num_Iden_Federacao; }
			set { _Obs_Num_Iden_Federacao = value; }
		}
	}
}
