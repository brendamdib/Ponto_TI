using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace Ponto_TI.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        public string Status;

        protected void Page_Load(object sender, EventArgs e)
        {       
            txt_adm_login.Focus();
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {   
            scripts.Funcoes scpFuncoes = new scripts.Funcoes();
            scpFuncoes.Conecta_SQL();
            scpFuncoes.SelectLogin(txt_adm_login.Text, txt_adm_senha.Text);
            //Response.Write(Conecta.Valor.ToString());

            if (scpFuncoes.StatusLogin.ToString() == "Erro")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Erro", "alert('Usuário ou senha inválidos');", true);
            }
            else
            {
                Response.Write(scpFuncoes.strIdGrupoUsuario.ToString());
                Session["LoginEstado"] = "OK";
                Response.Redirect("indexAdm.aspx");
            }                     
        }
    }
}