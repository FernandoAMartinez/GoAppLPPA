namespace Negocio
{
    public class Usuario
    {
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

        private Perfil _perfil;

        public Perfil Perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }
        #endregion



    }
}
