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
		private String _Clube_Treinador_Inscricao_FIFA;
		private String _Treinador_Data_Saida;
		private String _Treinador_Data_Inicio;

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

		public String Clube_Treinador_Inscricao_FIFA
		{
			get { return _Clube_Treinador_Inscricao_FIFA; }
			set { _Clube_Treinador_Inscricao_FIFA = value; }
		}

		public String Treinador_Data_Saida
		{
			get { return _Treinador_Data_Saida; }
			set { _Treinador_Data_Saida = value; }
		}
		public String Treinador_Data_Inicio
		{
			get { return _Treinador_Data_Inicio; }
			set { _Treinador_Data_Inicio = value; }
		}
	}
}
