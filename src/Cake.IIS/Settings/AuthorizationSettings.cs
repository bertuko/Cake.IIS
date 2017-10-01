namespace Cake.IIS
{
    public class AuthorizationSettings
    {
        #region Constructors
        public AuthorizationSettings()
        {
            this.AuthorizationType = AuthorizationType.AllUsers;

            this.CanRead = true;
            this.CanWrite = true;
        }
        #endregion





        #region Properties
        public AuthorizationType AuthorizationType { get; set; }



        public string[] Users { get; set; }

        public string[] Roles { get; set; }



        public bool CanRead { get; set; }

        public bool CanWrite { get; set; }
        #endregion
    }
}