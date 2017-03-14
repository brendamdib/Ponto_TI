using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

namespace Ponto_TI.Admin
{
    public partial class Cadastro_de_Colaborador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            scripts.Funcoes scpFuncoes = new scripts.Funcoes();
            scpFuncoes.Conecta_Oracle();            
            scpFuncoes.InsereColab(txt_nome.Text, txt_cpf.Text);
            scpFuncoes.InsereLogin(txt_login.Text, txt_senha.Text, Convert.ToInt32(cbo_grupo.SelectedValue), txt_cpf.Text);
            lbl_mensagem.Text = "Cadastro realizado com sucesso";            
        }
    }
}