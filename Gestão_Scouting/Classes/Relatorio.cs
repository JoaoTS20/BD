using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
	
	class Relatorio
    {
		private String _ID;
		private String _Relatorio_Titulo;
		private String _Relatorio_Data;
		private String _Numero_Identificacao_Federacao;
		private String _ID_FIFPro;
		private String _Jogo_Local;
		private String _Jogo_Data;
		public String ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		public String Relatorio_Titulo
		{
			get { return _Relatorio_Titulo; }
			set { _Relatorio_Titulo = value; }
		}

		public String Relatorio_Data
		{
			get { return _Relatorio_Data; }
			set { _Relatorio_Data = value; }
		}

		public String Numero_Identificacao_Federacao
		{
			get { return _Numero_Identificacao_Federacao; }
			set { _Numero_Identificacao_Federacao = value; }
		}

		public String ID_FIFPro
		{
			get { return _ID_FIFPro; }
			set { _ID_FIFPro = value; }
		}

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

		public override String ToString()
		{
			return _ID + " " + _Relatorio_Titulo+ " "+ _Relatorio_Data.Split(' ')[0];

		}

	}
}
