using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Participa_Em
    {
        private String _Participa_Clube_Numero_Inscricao_Fifa;
        private String _Participa_Em_Jogo_Data;
        private String _Participa_Em_Jogo_Local;
        private String _Participa_Em_Numero_Jogadores_Convocados;

		public String Participa_Clube_Numero_Inscricao_Fifa
		{
			get { return _Participa_Clube_Numero_Inscricao_Fifa; }
			set { _Participa_Clube_Numero_Inscricao_Fifa = value; }
		}

		public String Participa_Em_Jogo_Data
		{
			get { return _Participa_Em_Jogo_Data; }
			set { _Participa_Em_Jogo_Data = value; }
		}

		public String Participa_Em_Jogo_Local
		{
			get { return _Participa_Em_Jogo_Local; }
			set { _Participa_Em_Jogo_Local = value; }
		}
		public String Participa_Em_Numero_Jogadores_Convocados
		{
			get { return _Participa_Em_Numero_Jogadores_Convocados; }
			set { _Participa_Em_Numero_Jogadores_Convocados = value; }
		}
	}
}
