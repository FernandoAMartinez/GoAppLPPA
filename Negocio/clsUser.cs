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
    public class clsUser
    {
        int n;
        #region Constructors
        private clsUser() { }

        public clsUser(string User, string Pass)
        {
            s_Usu = User;
            s_Pass = Seguridad.GetInstance.GetMD5(Pass);
            s_logued = LoginStatus(User);
            s_blocked = BlockedStatus(User);
            i_tries = TriesStatus(User);
        }
        #endregion

        #region Properties
        /** ** ** ** ** ** ** ** ** ** ** ** ** Properties ** ** ** ** ** ** ** ** ** ** ** ** **/
        private string s_Usu;

        public string Usu
        {
            get { return s_Usu; }
            set { s_Usu = value; }
        }

        private string s_Pass;

        public string Pass
        {
            get { return s_Pass; }
            set { s_Pass = value; }
        }

        private string s_logued;

        public string Logued
        {
            get { return s_logued; }
            set { s_logued = value; }
        }

        private string s_blocked;

        public string Blocked
        {
            get { return s_blocked; }
            set { s_blocked = value; }
        }

        private int i_tries;

        public int Tries
        {
            get { return i_tries; }
            set { i_tries = value; }
        }

        /** ** ** ** ** ** ** ** ** ** ** ** ** Properties ** ** ** ** ** ** ** ** ** ** ** ** **/
        #endregion

        #region Methods
        /** ** ** ** ** ** ** ** ** ** ** ** ** Methods ** ** ** ** ** ** ** ** ** ** ** ** **/
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
            n = (string)dataAccess.GetInstance.ExeScalarString(query);
            return n;
        }

        public int TriesStatus(string usu)
        {
            string query = "SELECT USTRIES FROM USR01 WHERE USRNAME='" + usu + "'";
            n = dataAccess.GetInstance.ExeScalarInt(query);
            return n;
        }

        public int LogInLogOut(string Op, string Usu)
        {

            string query;

            if (Op == "X")
            {
                query = "UPDATE USR01 SET ISLOGUED = 1 WHERE USRNAME='" + Usu + "'";
                n = dataAccess.GetInstance.ExeNonQuery(query);
                s_logued = Op;

            }
            else if (Op == " ")
            {
                query = "UPDATE USR01 SET ISLOGUED = 0 WHERE USRNAME='" + Usu + "'";
                n = dataAccess.GetInstance.ExeNonQuery(query);
                s_logued = Op;

            }

            return n;
        }

        //public int BlockUser(string Usu)
        //{
        //    string query = "UPDATE USR01 SET Blocked = 1 WHERE Username='" + Usu + "'";
        //    n = DA.ExeNonQuery(query);
        //    return n;
        //}

        //public string GetDNI(string Usu)
        //{
        //    string n;
        //    string query = "SELECT DNI FROM USR01 WHERE Username='" + Usu + "'";
        //    n = DA.ExeNonQueryS(query);
        //    return n;
        //}

        public int NewUser(string Usu, string Pass, int Tries, int Blocked, int Log)
        {
            int n;
            string query = "INSERT INTO USR01 VALUES ('" + Usu + "','" + Seguridad.GetInstance.GetMD5(Pass).ToString() + "',3,0,0)";
            n = dataAccess.GetInstance.ExeNonQuery(query);
            return n;
        }

        public void ReturnRows(string Usu, DataGridView DataTable)
        {
            string query;
            DataView DW = new DataView();
            DataSet DS = new DataSet();
            query = "SELECT USRNAME, USPASS, USTRIES, ISBLOCKED, ISLOGUED FROM USR01 WHERE USRNAME='" + Usu + "'";
            //query = "SELECT TOP " + Rows + " * FROM [" + Table + "]";
            DS = dataAccess.GetInstance.ExecDS(query);
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
            n = (string)dataAccess.GetInstance.ExeScalarString(query);
            return n;
        }

        //public string GetPSRNBR(string Usu)
        //{
        //    string res;
        //    string query = "SELECT PSRNBR FROM USR01 WHERE Username='" + Usu + "'";
        //    res = DA.ExeScalarString(query);
        //    return res;
        //}

        public int Exists(string Usu)
        {
            n = dataAccess.GetInstance.ExeScalarInt("SELECT COUNT(*) FROM USR01 WHERE USRNAME='" + Usu + "'");
            return n;
        }
        #endregion

    }
}
