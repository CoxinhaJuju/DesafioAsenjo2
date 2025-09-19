using DesafioAsenjoPj.BLL;
using DesafioAsenjoPj.Classes;
using DesafioAsenjoPj.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DesafioAsenjoPj
{
    public partial class CRUDPessoa : Form
    {
        Pessoa umaPessoa = new Pessoa();
        public CRUDPessoa()
        {
            InitializeComponent();
        }
        private void CRUDPessoa_Load(object sender, EventArgs e)
        {
            PessoaBLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            
        }

        private void CRUDPessoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            PessoaBLL.desconecta();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtCep.Text = "";
            txtEstado.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            umaPessoa.setNome(txtNome.Text);
            umaPessoa.setTelefone(txtTelefone.Text);
            umaPessoa.setEmail(txtEmail.Text);
            umaPessoa.setCep(txtCep.Text);
            umaPessoa.setEstado(txtEstado.Text);
            umaPessoa.setCidade(txtCidade.Text);
            umaPessoa.setBairro(txtBairro.Text);
            umaPessoa.setRua(txtRua.Text);
            umaPessoa.setNumero(txtNumero.Text);
            umaPessoa.setComplemento(txtComplemento.Text);

            PessoaBLL.validaDados(umaPessoa, 'i');

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
            {
                MessageBox.Show("Pessoa cadastrada com sucesso!");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            umaPessoa.setId(txtId.Text);

            PessoaBLL.validaCodigo(umaPessoa, 'c');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                txtNome.Text = umaPessoa.getNome();
                txtTelefone.Text = umaPessoa.getTelefone();
                txtEmail.Text = umaPessoa.getEmail();
                txtCep.Text = umaPessoa.getCep();
                txtEstado.Text = umaPessoa.getEstado();
                txtCidade.Text = umaPessoa.getCidade();
                txtBairro.Text = umaPessoa.getBairro();
                txtRua.Text = umaPessoa.getRua();
                txtNumero.Text = umaPessoa.getNumero();
                txtComplemento.Text = umaPessoa.getComplemento();
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            umaPessoa.setId(txtId.Text);

            PessoaBLL.validaCodigo(umaPessoa, 'e');

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
            {
                MessageBox.Show("Pessoa excluída com sucesso!");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            umaPessoa.setId(txtId.Text);
            umaPessoa.setNome(txtNome.Text);
            umaPessoa.setTelefone(txtTelefone.Text);
            umaPessoa.setEmail(txtEmail.Text);
            umaPessoa.setCep(txtCep.Text);
            umaPessoa.setEstado(txtEstado.Text);
            umaPessoa.setCidade(txtCidade.Text);
            umaPessoa.setBairro(txtBairro.Text);
            umaPessoa.setRua(txtRua.Text);
            umaPessoa.setNumero(txtNumero.Text);
            umaPessoa.setComplemento(txtComplemento.Text);

            PessoaBLL.validaDados(umaPessoa, 'a');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados alterados com sucesso!");
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            // ViaCEP using WebClient +JavaScriptSerializer(works on.NET Framework 4.0)
                 var cep = txtCep.Text;
            if (string.IsNullOrWhiteSpace(cep)) return;
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    string json = wc.DownloadString("https://viacep.com.br/ws/" + cep + "/json/");

                    var serializer = new JavaScriptSerializer();
                    var obj = serializer.Deserialize<Dictionary<string, object>>(json);

                    if (obj != null && obj.ContainsKey("erro"))
                    {
                        MessageBox.Show("CEP não encontrado.");
                        return;
                    }

                    txtEstado.Text = obj.ContainsKey("uf") ? obj["uf"].ToString() : "";
                    txtCidade.Text = obj.ContainsKey("localidade") ? obj["localidade"].ToString() : "";
                    txtBairro.Text = obj.ContainsKey("bairro") ? obj["bairro"].ToString() : "";
                    txtRua.Text = obj.ContainsKey("logradouro") ? obj["logradouro"].ToString() : "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar CEP: " + ex.Message);
            }
        }
    }
    }

