using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Observacao_Metodo_de_Observacao
    {
        private String _Rel_Metodo_de_Observacao;
        private String _Rel_ID_Relatorio;

		public String Rel_Metodo_de_Observacao
		{
			get { return _Rel_Metodo_de_Observacao; }
			set { _Rel_Metodo_de_Observacao = value; }
		}
		public String Rel_ID_Relatorio
		{
			get { return _Rel_ID_Relatorio; }
			set { _Rel_ID_Relatorio = value; }
		}
	}
}
