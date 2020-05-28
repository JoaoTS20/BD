using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Jog_Posicoes
    {
        private String _J_Posicoes;
        private String _Jog_Posicoes_ID_FIFPro;

		public String J_Posicoes
		{
			get { return _J_Posicoes; }
			set { _J_Posicoes = value; }
		}
		public String J_Posicoes_ID_FIFPro
		{
			get { return _Jog_Posicoes_ID_FIFPro; }
			set { _Jog_Posicoes_ID_FIFPro = value; }
		}
		public override String ToString()
		{
			return _J_Posicoes;

		}
	}
}
