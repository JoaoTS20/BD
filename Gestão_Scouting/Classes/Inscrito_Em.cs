using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Inscrito_Em
    {
        private String _Ins_Clube_Numero_Inscricao_FIFA;
        private String _Ins_Competicao_ID_FIFA;
        private String _Numeros_Jogadores_Inscritos;
        private String _Data_Inscricao;

        public String Ins_Clube_Numero_Inscricao_FIFA
        {
            get { return _Ins_Clube_Numero_Inscricao_FIFA; }
            set { _Ins_Clube_Numero_Inscricao_FIFA = value; }
        }
        public String Ins_Competicao_ID_FIFA
        {
            get { return _Ins_Competicao_ID_FIFA; }
            set { _Ins_Competicao_ID_FIFA = value; }
        }
        public String Numeros_Jogadores_Inscritos
        {
            get { return _Numeros_Jogadores_Inscritos; }
            set { _Numeros_Jogadores_Inscritos = value; }
        }
        public String Data_Inscricao
        {
            get { return _Data_Inscricao; }
            set { _Data_Inscricao = value; }
        }
    }
}
