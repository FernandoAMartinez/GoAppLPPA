using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Ambiente;
using System.Windows.Forms;
using System.Data;

namespace Negocio
{
    public class Usuario
    {
        int n;
        #region Constructors
        public Usuario() { }

        public Usuario(string User, string Pass)
        {
            _userName = User;
            _password = Pass;
            _isBlocked = false;
            _tries = 0;
        }
        #endregion

        #region Properties

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

       private bool _isBlocked;

        public bool IsBlocked
        {
            get { return _isBlocked; }
            set { _isBlocked = value; }
        }

        private int _tries;

        public int Tries
        {
            get { return _tries; }
            set { _tries = value; }
        }

        #endregion

        #region Methods
        public int LoginValidate(string Usu, string Pass)
        {
            n = dataManipulation.GetInstance.usp_LoginValidation(Usu, Pass);
            return n;
        }

        public int BlockUser(string Usu)
        {
            n = dataManipulation.GetInstance.usp_BlockUser(Usu);
            return n;
        }

        public string BlockedStatus(string usu)
        {
            string n;
            string query = "SELECT ISBLOCKED FROM USR01 WHERE USRNAME='" + usu + "'";
            n = (string)DataAccess.GetInstance.ExeScalarString(query);
            return n;
        }

        public int TriesStatus(string usu)
        {
            string query = "SELECT USTRIES FROM USR01 WHERE USRNAME='" + usu + "'";
            n = DataAccess.GetInstance.ExeScalarInt(query);
            return n;
        }

        public int LogInLogOut(string Op, string Usu)
        {

            string query;

            if (Op == "X")
            {
                query = "UPDATE USR01 SET ISLOGUED = 1 WHERE USRNAME='" + Usu + "'";
                n = DataAccess.GetInstance.ExeNonQuery(query);

            }
            else if (Op == " ")
            {
                query = "UPDATE USR01 SET ISLOGUED = 0 WHERE USRNAME='" + Usu + "'";
                n = DataAccess.GetInstance.ExeNonQuery(query);
            }

            return n;
        }

        //public int BlockUser(string UserName)
        //{
        //    string query = "UPDATE USR01 SET IsBlocked = 1 WHERE Username='" + UserName + "'";
        //    n = DA.ExeNonQuery(query);
        //    return n;
        //}

        //public string GetDNI(string UserName)
        //{
        //    string n;
        //    string query = "SELECT DNI FROM USR01 WHERE Username='" + UserName + "'";
        //    n = DA.ExeNonQueryS(query);
        //    return n;
        //}

        public int NewUser(string Usu, string Pass, int Tries, int Blocked, int Log)
        {
            int n;
            string query = "INSERT INTO USR01 VALUES ('" + Usu + "','" + Seguridad.GetInstance.GetMD5(Pass).ToString() + "',3,0,0)";
            n = DataAccess.GetInstance.ExeNonQuery(query);
            return n;
        }

        public void ReturnRows(string Usu, DataGridView DataTable)
        {
            string query;
            DataView DW = new DataView();
            DataSet DS = new DataSet();
            query = "SELECT USRNAME, USPASS, USTRIES, ISBLOCKED, ISLOGUED FROM USR01 WHERE USRNAME='" + Usu + "'";
            //query = "SELECT TOP " + Rows + " * FROM [" + Table + "]";
            DS = DataAccess.GetInstance.ExecDS(query);
            //            DW.Table = DS.Tables.Add(Table);
            DW.Table = DS.Tables["USR01"];
            DataTable.DataSource = DW.Table;
        }

        public int ResetTries(string User)
        {
            n = dataManipulation.GetInstance.usp_ResetTries(User);
            return n;
        }

        public string LoginStatus(string Usu)
        {
            string n;
            string query = "SELECT ISLOGUED FROM USR01 WHERE USRNAME='" + Usu + "'";
            n = (string)DataAccess.GetInstance.ExeScalarString(query);
            return n;
        }

        //public string GetPSRNBR(string UserName)
        //{
        //    string res;
        //    string query = "SELECT PSRNBR FROM USR01 WHERE Username='" + UserName + "'";
        //    res = DA.ExeScalarString(query);
        //    return res;
        //}

        public int Exists(string Usu)
        {
            n = DataAccess.GetInstance.ExeScalarInt("SELECT COUNT(*) FROM USR01 WHERE USRNAME='" + Usu + "'");
            return n;
        }
        #endregion

    }
}
