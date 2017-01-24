using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
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
            scripts.Funcoes Conecta = new scripts.Funcoes();
            Conecta.Conecta_MySql();
            Conecta.SelectLogin(txt_adm_login.Text, txt_adm_senha.Text);
            //Response.Write(Conecta.Valor.ToString());

            if (Conecta.StatusLogin.ToString() == "Erro")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Erro", "alert('Usuário ou senha inválidos');", true);
            }
            else
            {
                Application["LoginStatus"] = Conecta.StatusLogin.ToString();        
                Response.Redirect("indexAdm.aspx");
            }                     
        }
    }
}