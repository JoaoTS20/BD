using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Observacao_Metodo_de_Observacao
    {
        private String _O_Metodo_de_Observacao;
        private String _Numero_Identificacao_Federacao;

		public String O_Metodo_de_Observacao
		{
			get { return _O_Metodo_de_Observacao; }
			set { _O_Metodo_de_Observacao = value; }
		}
		public String Numero_Identificacao_Federacao
		{
			get { return _Numero_Identificacao_Federacao; }
			set { _Numero_Identificacao_Federacao = value; }
		}
	}
}
