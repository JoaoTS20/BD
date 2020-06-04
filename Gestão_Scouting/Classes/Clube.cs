using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Clube
    {
		private String _Clube_Numero_Inscricao_FIFA;
		private String _Clube_Pais;
		private String _Clube_Nome;

		public String Clube_Numero_Inscricao_FIFA
		{
			get { return _Clube_Numero_Inscricao_FIFA; }
			set { _Clube_Numero_Inscricao_FIFA = value; }
		}
		public String Clube_Pais
		{
			get { return _Clube_Pais; }
			set { _Clube_Pais = value; }
		}

		public String Clube_Nome
		{
			get { return _Clube_Nome; }
			set { _Clube_Nome = value; }
		}
		public override String ToString()
		{
			return Clube_Numero_Inscricao_FIFA + "   " + Clube_Nome;
		}


	}
}
