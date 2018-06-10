using System.Text;
using System.Security.Cryptography;

namespace NegocioService.Helper
{
    public class Seguridad
    {

        #region Singleton
        private static Seguridad _Instance = null;

        public static Seguridad GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Seguridad();
                }
                return _Instance;
            }
        }
        private Seguridad()
        {
            //nothing
        }



        #endregion

        MD5 c_MD5 = MD5CryptoServiceProvider.Create();
        ASCIIEncoding encoding = new ASCIIEncoding();

        private byte[] b_Stream;

        public byte[] Stream
        {
            get { return b_Stream; }
            set { b_Stream = value; }
        }

        public string GetMD5(string str)
        {
            Stream = null;
            StringBuilder sb = new StringBuilder();
            Stream = c_MD5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < Stream.Length; i++) sb.AppendFormat("{0:x2}", Stream[i]);
            return sb.ToString();
        }
    }
}
