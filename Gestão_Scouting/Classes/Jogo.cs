using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Jogo
    {
		private String _Jogo_Local;
		private String _Jogo_Data;
		private String _Resultado;
		private String _Jogo_Competicao_ID_FIFA;
		private String _Obs_Num_Iden_Federacao;

		public String Jogo_Local
		{
			get { return _Jogo_Local; }
			set { _Jogo_Local = value; }
		}
		public String Jogo_Data
		{
			get { return _Jogo_Data; }
			set { _Jogo_Data = value; }
		}
		public String Resultado
		{
			get { return _Resultado; }
			set { _Resultado = value; }
		}
		public String Jogo_Competicao_ID_FIFA
		{
			get { return _Jogo_Competicao_ID_FIFA; }
			set { _Jogo_Competicao_ID_FIFA = value; }
		}
		public String Obs_Num_Iden_Federacao
		{
			get { return _Obs_Num_Iden_Federacao; }
			set { _Obs_Num_Iden_Federacao = value; }
		}
	}
}
