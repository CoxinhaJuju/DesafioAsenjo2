using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAsenjoPj.Classes
{
    internal class Pessoa
    {
        private int id;
        private string nome;
        private string telefone;
        private string email;
        private string cep;
        private string estado;
        private string cidade;
        private string bairro;
        private string rua;
        private string numero;
        private string complemento;

        public void setId(string _id) { id = string.IsNullOrWhiteSpace(_id) ? 0 : int.Parse(_id); }
        public void setNome(string _nome) { nome = _nome; }
        public void setTelefone(string _telefone) { telefone = _telefone; }
        public void setEmail(string _email) { email = _email; }
        public void setCep(string _cep) { cep = _cep; }
        public void setEstado(string _estado) { estado = _estado; }
        public void setCidade(string _cidade) { cidade = _cidade; }
        public void setBairro(string _bairro) { bairro = _bairro; }
        public void setRua(string _rua) { rua = _rua; }
        public void setNumero(string _numero) { numero = _numero; }
        public void setComplemento(string _complemento) { complemento = _complemento; }

        public int getId() { return id; }
        public string getNome() { return nome; }
        public string getTelefone() { return telefone; }
        public string getEmail() { return email; }
        public string getCep() { return cep; }
        public string getEstado() { return estado; }
        public string getCidade() { return cidade; }
        public string getBairro() { return bairro; }
        public string getRua() { return rua; }
        public string getNumero() { return numero; }
        public string getComplemento() { return complemento; }
    }
}
