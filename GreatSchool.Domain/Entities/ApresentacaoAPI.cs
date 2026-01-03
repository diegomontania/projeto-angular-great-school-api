using System;
using System.Collections.Generic;

namespace GreatSchool.Domain.Entities
{
    public class ApresentacaoAPI
    {
        private List<string> _rotas { get; set; }
        public List<string> Rotas
        {
            get { return _rotas; }
        }
        public string MensagemAPI
        {
            get
            {
                return "Seja bem vindo a api";
            }
        }

        //no construtor cria as rotas
        public ApresentacaoAPI()
        {
            //adiciona uma rota
            _rotas = new List<string>();
            _rotas.Add("/alunos");
        }
    }
}
