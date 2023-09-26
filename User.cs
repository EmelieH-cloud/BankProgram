namespace BankProgram
{
    internal class User
    {
        string name;
        string password;

        public User(string n, string p)
        {
            this.name = n;
            this.password = p;
        }

        public string Name()
        {
            return this.name;
        }

        public string UserData()
        {
            return $"Name: {this.name} - Password: {this.password}";
        }
    }
}