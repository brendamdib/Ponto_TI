using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;

namespace Ponto_TI.scripts
{
    public class Funcoes
    {
        //declaração de variáveis
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private StreamWriter Arqlog;
        public string Valor, StatusLogin;
        public int ContColab, IdUsuario, IdGrupoUsuario, ContLogin;
        
        public void Conecta_MySql()
        {
            Inicializa();
        }

        private void Inicializa()
        {
            /*Atribuindo valores às variáveis que irão definir a string de conexão e cria 
            arquivo de log*/
        
            server = "localhost";
            database = "gnc_ponto_ti";
            uid = "root";
            password = "monteiro1982";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

            CriaLog();
        }

        public void CriaLog()
        {
            //Criando Arquivo de Log
            using (Arqlog = File.AppendText("D:\\log.txt"))
            {
                Arqlog.WriteLine("Conexão com Banco de Dados MySQL ");
                Arqlog.WriteLine("==============================================");
                Arqlog.WriteLine("Data/Hora:" + DateTime.Now.ToString());
            }
        }

        public void EscreveLog(string Mensagem, TextWriter Escrita)
        {
            Escrita.WriteLine(Mensagem);
        }


        //Abre a Conexão com o Banco de Dados MySQL
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
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
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
            catch (MySqlException ex)
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
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Criando o data Reader
                MySqlDataReader MySQL_DR = cmd.ExecuteReader();

                DataTable DtColab = new DataTable();
                DtColab.Load(MySQL_DR);
                ContColab = DtColab.Rows.Count;
                Valor = DtColab.Rows[0].Field<Int32>("colab_id").ToString();

                DtColab.Clear();
                
                if (ContColab != 1)
                {                    
                    Valor = "Erro";
                }
                    

                    //Fecha Data Reader
                    MySQL_DR.Close();

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
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Criando o data Reader
                MySqlDataReader MySQL_DR = cmd.ExecuteReader();

                DataTable DtLogin = new DataTable();
                DtLogin.Load(MySQL_DR);
                ContLogin = DtLogin.Rows.Count;

                if (ContLogin != 1)
                {
                    StatusLogin = "Erro";
                }
                else
                {
                    IdUsuario = DtLogin.Rows[0].Field<Int32>("login_id");
                    IdGrupoUsuario = DtLogin.Rows[0].Field<Int32>("login_grupo");
                    StatusLogin = "Sucesso";
                    DtLogin.Clear();
                }


                //Fecha Data Reader
                MySQL_DR.Close();

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
                    MySqlCommand cmd = new MySqlCommand(query, connection);

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
                MySqlCommand cmd = new MySqlCommand();
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
                MySqlCommand cmd = new MySqlCommand(query, connection);
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