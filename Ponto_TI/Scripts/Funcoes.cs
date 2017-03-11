using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Net.NetworkInformation;
//using System.Data.OracleClient;
using Oracle.DataAccess.Client;

namespace Ponto_TI.scripts
{
    public class Funcoes
    {
        //declaração de variáveis
        private OracleConnection connection;
        private string datasource;
        //private string database;
        private string uid;
        private string password;
        private StreamWriter Arqlog;
        public string Valor, StatusLogin;
        public int ContColab, IdUsuario, IdGrupoUsuario, ContLogin;
        public string strIdUsuario, strIdGrupoUsuario;
                
        public string GravaIP()
        {

            string IPAddress = HttpContext.Current.Request.UserHostAddress;
            string Hostname = HttpContext.Current.Request.UserHostName;
            Hostname = System.Environment.MachineName;            
            return IPAddress;

        }

        public void Conecta_Oracle()
        {
            Inicializa();
        }

        private void Inicializa()
        {
            /*Atribuindo valores às variáveis que irão definir a string de conexão e cria 
            arquivo de log*/
            
            datasource = "(DESCRIPTION =  (ADDRESS = (PROTOCOL = tcp)(HOST = sales - server)(PORT = 1521))  (CONNECT_DATA =(SERVICE_NAME = sales.us.acme.com)))";
            //database = "PRODGNC";
            uid = "teste";
            password = "teste";
            string ConnStr;            
            ConnStr = "Data Source=//10.200.1.201:1521/PRODGNC;User ID=" + uid + ";Password = "+ password +"";
            //connection.ConnectionString = ConnStr;
            connection = new OracleConnection(ConnStr);          
            

            CriaLog();
        }

        public void CriaLog()
        {
            //Criando Arquivo de Log
            using (Arqlog = File.AppendText("D:\\log.txt"))
            {
                Arqlog.WriteLine("Conexão com Banco de Dados Oracle ");
                Arqlog.WriteLine("==============================================");
                Arqlog.WriteLine("Data/Hora:" + DateTime.Now.ToString());               
            }
        }

        public void EscreveLog(string Mensagem, TextWriter Escrita)
        {
            Escrita.WriteLine(Mensagem);
        }

        //Abre a Conexão com o Banco de Dados Oracle
        private bool AbreConexao()
        {
            try
            {
                connection.Open();
                using (StreamWriter w = File.AppendText("D:\\log.txt"))
                {
                    EscreveLog(DateTime.Now.ToString() + " - " + "Conexão efetuada com sucesso!", w);
                }
                return true;
            }
            catch (OracleException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.ErrorCode)
                {
                    case 0:
                        using (StreamWriter w = File.AppendText("D:\\log.txt"))
                        {
                            EscreveLog(DateTime.Now.ToString() + " - " + "Falha ao conectar o servidor, contate o administrador!", w);
                        }                        
                        break;

                    case 1045:
                        using (StreamWriter w = File.AppendText("D:\\log.txt"))
                        {
                            EscreveLog(DateTime.Now.ToString() + " - " + "Usuário ou Senha Inválidos", w);
                        }                
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool FechaConexao()
        {
            try
            {
                connection.Close();
                using (StreamWriter w = File.AppendText("D:\\log.txt"))
                {
                    EscreveLog(DateTime.Now.ToString() + " - " + "Conexão finalizada com sucesso!", w);
                }                
                return true;
            }
            catch (OracleException ex)
            {
                using (StreamWriter w = File.AppendText("D:\\log.txt"))
                {
                    EscreveLog(DateTime.Now.ToString() + " - " + "Erro ao encerrar conexão!", w);
                    EscreveLog(DateTime.Now.ToString() + " - " + ex.Message, w);
                }                
                return false;
            }
        }

        //Select CPF
        public void SelectCPF(string cpf)
        {
            //String para pesquisa
            string query = "SELECT DISTINCT colab_id FROM tbl_colab WHERE colab_cpf='" + cpf +"' AND colab_status=0";
            

            //Criando Lista para Armazenar os Dados do Select

            List<string>[] Lista = new List<string>[1];
            Lista[0] = new List<string>();

            if(this.AbreConexao()==true)
            {
                //Cria Comando
                OracleCommand cmd = new OracleCommand(query, connection);

                //Criando o data Reader
                OracleDataReader Oracle_DR = cmd.ExecuteReader();

                DataTable DtColab = new DataTable();
                DtColab.Load(Oracle_DR);
                ContColab = DtColab.Rows.Count;
                Valor = DtColab.Rows[0].Field<Int32>("colab_id").ToString();

                DtColab.Clear();
                
                if (ContColab != 1)
                {                    
                    Valor = "Erro";
                }                   
                    //Fecha Data Reader
                    Oracle_DR.Close();

                    //Fecha Conexão com Banco de Dados
                    this.FechaConexao();
            }
        }

        //Select CPF
        public void SelectLogin(string login, string senha)
        {
            //String para pesquisa
            string query = "SELECT DISTINCT login_id, login_grupo FROM tbl_login WHERE login_username='" + login + "' AND login_senha= '" + senha + "'";
            
            //Criando Lista para Armazenar os Dados do Select

            List<int>[] Lista = new List<int>[2];
            Lista[0] = new List<int>();
            Lista[1] = new List<int>();

            if (this.AbreConexao() == true)
            {
                //Cria Comando
                OracleCommand cmd = new OracleCommand(query, connection);

                //Criando o data Reader
                OracleDataReader Oracle_DR = cmd.ExecuteReader();

                DataTable DtLogin = new DataTable();
                DtLogin.Load(Oracle_DR);
                ContLogin = DtLogin.Rows.Count;

                if (ContLogin != 1)
                {
                    StatusLogin = "Erro";
                }
                else
                {
                    strIdUsuario = Convert.ToString(DtLogin.Rows[0]["login_id"]);
                    strIdGrupoUsuario = Convert.ToString(DtLogin.Rows[0]["login_grupo"]);
                    StatusLogin = "Sucesso";
                    DtLogin.Clear();
                }
                
                //Fecha Data Reader
                Oracle_DR.Close();

                //Fecha Conexão com Banco de Dados
                this.FechaConexao();
            }
        }

        //Insert statement
        public void InserePonto( int id_colab, int cod_acao)
        {
            string query = "INSERT INTO tbl_reg_ponto VALUES(" + id_colab + ", NOW(), " +cod_acao + ")";

            //open connection
            try
            {
                if (this.AbreConexao() == true)
                {
                    //create command and assign the query and connection from the constructor
                    OracleCommand cmd = new OracleCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.FechaConexao();
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("D:\\log.txt"))
                {
                    EscreveLog(DateTime.Now.ToString() + " - " + "Erro ao realizar insert na tabela de ponto", w);
                    EscreveLog(DateTime.Now.ToString() + " - " + ex.Message, w);
                }                
                throw;
            }            
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.AbreConexao() == true)
            {
                //create mysql command
                OracleCommand cmd = new OracleCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.FechaConexao();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.AbreConexao() == true)
            {
                OracleCommand cmd = new OracleCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.FechaConexao();
            }
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }    
}
}