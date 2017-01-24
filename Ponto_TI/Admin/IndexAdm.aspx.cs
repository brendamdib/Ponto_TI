using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ponto_TI.Admin
{
    public partial class IndexAdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificaLogin();
        }

        public void VerificaLogin()
        {
            if ((Application["LoginStatus"] == null)) //|| (Application["LoginStatus"].ToString() == "Erro"))
            {
                Response.Redirect("LoginAdm.aspx");
            }
        }
    }
}