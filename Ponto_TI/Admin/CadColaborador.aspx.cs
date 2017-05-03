using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Ponto_TI.Admin
{
    public partial class Cadastro_de_Colaborador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (Convert.ToString(context.Session["LoginEstado"]) != "OK")
            {
                Response.Redirect("LoginAdm.aspx");
            }
            rdo_status_ativo.Checked = true;

            
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            scripts.Funcoes scpFuncoes = new scripts.Funcoes();
            scpFuncoes.Conecta_SQL();           
                try
                {
                int status_usu;
                    if (rdo_status_ativo.Checked == true) {
                        status_usu = 1;
                    }
                    else
                    {
                        status_usu = 0;
                    }

                scpFuncoes.InsereColab(txt_nome.Text, txt_cpf.Text, txt_login.Text, txt_senha.Text, Convert.ToInt32(cbo_grupo.SelectedValue), Convert.ToInt32(status_usu), Convert.ToInt32(cbo_regional.SelectedValue));
                    //scpFuncoes.InsereLogin(txt_login.Text, txt_senha.Text, Convert.ToInt32(cbo_grupo.SelectedValue), txt_cpf.Text);
                }
                catch (SqlException ex)
                {
                    Response.Write(ex);
                    throw;
                }                
            }
            //lbl_mensagem.Text = "Cadastro realizado com sucesso";            
        }
    }
