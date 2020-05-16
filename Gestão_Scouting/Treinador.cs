using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestão_Scouting
{
    class Treinador
    {
        private String _Treinador_Numero_Inscricao_FIFA;
        private String _Treinador_Nome;
        private String _Treinador_Qualificacao;
        private String _Treindaor_Idade;
        private String _Treindaor_Nacionalidade;

        public String Treinador_Numero_Inscricao_FIFA
        {
            get { return _Treinador_Numero_Inscricao_FIFA; }
            set { _Treinador_Numero_Inscricao_FIFA = value; }
        }
        public String Treinador_Nome
        {
            get { return _Treinador_Nome; }
            set { _Treinador_Nome = value; }
        }
        public String Treinador_Qualificacao
        {
            get { return _Treinador_Qualificacao; }
            set { _Treinador_Qualificacao = value; }
        }
        public String Treindaor_Idade
        {
            get { return _Treindaor_Idade; }
            set { _Treindaor_Idade = value; }
        }
        public String Treindaor_Nacionalidade
        {
            get { return _Treindaor_Nacionalidade; }
            set { _Treindaor_Nacionalidade = value; }
        }
    }
}
