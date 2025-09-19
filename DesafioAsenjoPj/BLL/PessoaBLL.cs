using DesafioAsenjoPj.Classes;
using DesafioAsenjoPj.DAL;
using System;
using System.Text.RegularExpressions;

namespace DesafioAsenjoPj.BLL
{
    internal class PessoaBLL
    {
        private static Regex RxTelefone = new Regex(@"^\(\d{2}\) \d{5}-\d{4}$");  // Para celular
        private static Regex RxTelefoneFixo = new Regex(@"^\(\d{2}\) \d{5}-\d{3}$"); // Para fixo
        private static Regex RxEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private static Regex RxCep = new Regex(@"^\d{5}-\d{3}$");

        public static void conecta()
        {
            PessoaDAL.conecta();
        }

        public static void desconecta()
        {
            PessoaDAL.desconecta();
        }

        public static void validaCodigo(Pessoa p, char op)
        {
            Erro.setErro(false);
            if (p.getId().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }

            if (op == 'c')
                PessoaDAL.consultaUmaPessoa(p);
            else
                PessoaDAL.excluiUmaPessoa(p);
        }

        public static void validaDados(Pessoa p, char op)
        {
            Erro.setErro(false);

            if (p.getNome().Equals(""))
            {
                Erro.setMsg("O nome é obrigatório!");
                return;
            }

            // Validar telefone (celular ou fixo)
            if (p.getTelefone().Equals("") || (!RxTelefone.IsMatch(p.getTelefone()) && !RxTelefoneFixo.IsMatch(p.getTelefone())))
            {
                Erro.setMsg("Telefone inválido! Formato esperado: (xx) xxxxx-xxxx para celular ou (xx) xxxx-xxxx para residencial.");
                return;
            }

            // Validar email
            if (p.getEmail().Equals("") || !RxEmail.IsMatch(p.getEmail()))
            {
                Erro.setMsg("E-mail inválido!");
                return;
            }

            // Validar CEP
            if (p.getCep().Equals("") || !RxCep.IsMatch(p.getCep()))
            {
                Erro.setMsg("CEP inválido! Formato esperado: 00000-000");
                return;
            }

            // Validar endereço
            if (p.getEstado().Equals("") || p.getCidade().Equals("") || p.getBairro().Equals("") || p.getRua().Equals(""))
            {
                Erro.setMsg("Preencha o endereço automaticamente via CEP!");
                return;
            }

            // Validar número
            if (p.getNumero().Equals(""))
            {
                Erro.setMsg("Número é obrigatório!");
                return;
            }

            // Inserir ou atualizar pessoa
            if (op == 'i')
                PessoaDAL.inseriUmaPessoa(p);
            else
                PessoaDAL.atualizaUmaPessoa(p);


        }
    }
}