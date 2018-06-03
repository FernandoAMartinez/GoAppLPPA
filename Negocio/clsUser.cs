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
            i_logued = LoginStatus(User);
            i_blocked = BlockedStatus(User);
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

        private int i_logued;

        public int Logued
        {
            get { return i_logued; }
            set { i_logued = value; }
        }

        private int i_blocked;

        public int Blocked
        {
            get { return i_blocked; }
            set { i_blocked = value; }
        }

        private int i_tries;

        public int Tries
        {
            get { return i_tries; }
            set { i_tries = value; }
        }

        private string s_Ambiente;                      //Modificado 26.04.2018

        public string Ambient
        {
            get { return s_Ambiente; }
            set { s_Ambiente = value; }
        }                       //Modificado 26.04.2018

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

        public int BlockedStatus(string usu)
        {
            string query = "SELECT Blocked FROM USR01 WHERE Username='" + usu + "'";
            n = dataAccess.GetInstance.ExeScalarInt(query);
            return n;
        }

        public int TriesStatus(string usu)
        {
            string query = "SELECT Tries FROM USR01 WHERE Username='" + usu + "'";
            n = dataAccess.GetInstance.ExeScalarInt(query);
            return n;
        }

        public int LogInLogOut(int Op, string Usu)
        {

            string query;

            if (Op == 1)
            {
                query = "UPDATE USR01 SET LogedIn = 1 WHERE Username='" + Usu + "'";
                n = dataAccess.GetInstance.ExeNonQuery(query);
                i_logued = Op;

            }
            else if (Op == 0)
            {
                query = "UPDATE USR01 SET LogedIn = 0 WHERE Username='" + Usu + "'";
                n = dataAccess.GetInstance.ExeNonQuery(query);
                i_logued = Op;

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
            query = "SELECT Username, Pass, Tries, Blocked, LogedIn FROM USR01 WHERE USERNAME='" + Usu + "'";
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

        public int LoginStatus(string Usu)
        {
            string query = "SELECT LogedIn FROM USR01 WHERE Username='" + Usu + "'";
            n = dataAccess.GetInstance.ExeScalarInt(query);
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
            n = dataAccess.GetInstance.ExeScalarInt("SELECT COUNT(*) FROM USR01 WHERE Username='" + Usu + "'");
            return n;
        }
        #endregion

    }
}
