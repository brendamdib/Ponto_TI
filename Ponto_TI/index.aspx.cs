using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Ponto_TI
{
    public partial class index : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_cpf.Focus();    
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string cpf = rgx.Replace(txt_cpf.Text, replacement);
            int codColab, acao;
            
            if (scripts.Funcoes.IsCpf(cpf))
            {   
                scripts.Funcoes Conecta = new scripts.Funcoes();
                Conecta.Conecta_MySql();
                Conecta.SelectCPF(cpf);
                //Response.Write(Conecta.Valor.ToString());

                if(Conecta.Valor.ToString() == "Erro")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Erro", "alert('Colaborador não encontrado com este CPF, isso pode acontecer, pelos seguintes motivos: CPF Invalido, Colaborador não cadastrado ou Colaborador desligado da empresa');", true);
                }
                else
                {
                    codColab = Int32.Parse(Conecta.Valor);
                    acao = Int32.Parse(rdo_acao.SelectedValue.ToString());

                    Conecta.InserePonto(codColab, acao);

                    btn_submit.Enabled = false;

                    lbl_mensagem.Text = "Lançamento efetuado com sucesso";
                }                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Erro", "alert('CPF Invalido');", true);
            }
        }
    }
}