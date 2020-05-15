using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Competicao
    {
        private String _Competicao_ID_FIFA;
        private String _Competicao_Nome;
        private String _Competicao_Numero_Equipas;

        public String Competicao_ID_FIFA
        {
            get { return _Competicao_ID_FIFA; }
            set { _Competicao_ID_FIFA = value; }
        }
        public String Competicao_Nome
        {
            get { return _Competicao_Nome; }
            set { _Competicao_Nome = value; }
        }
        public String Competicao_Numero_Equipas
        {
            get { return _Competicao_Numero_Equipas; }
            set { _Competicao_Numero_Equipas = value; }
        }
    }
   
}
