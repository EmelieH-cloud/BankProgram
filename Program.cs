

using BankProgram;
bool isRunning = true;
List<User> users = new();
List<Account> accounts = new();
Dictionary<string, int> UserAccounts = new Dictionary<string, int>();

// Demo objects ------------------------------ //
Account account1 = new(123, 500);
User u = new("Emelie", "lösenord1");
Account account2 = new(124, 600);
User v = new("Emil", "lösenord2");
users.Add(u);
accounts.Add(account1);
users.Add(v);
accounts.Add(account2);
UserAccounts.Add(u.Name(), account1.getBalance());
UserAccounts.Add(v.Name(), account2.getBalance());
//---------------------------------------------//

while (isRunning)
{
    Console.WriteLine("WELCOME TO THE BANK");
    Console.WriteLine("Are you a existing (c)ustomer or a (b)ank associate?");
    string answer = Console.ReadLine();
    if (answer.Equals("c"))
    {
        Console.WriteLine("Enter your username (at least 3 letters and no numbers):");
        string username = Console.ReadLine();
        bool length = validateLength(username);
        int numbers = NoNumbers(username);
        while (!length || numbers != 0)
        {
            Console.WriteLine(
           "ERROR, username contains " + numbers + " number(s) and is " + username.Length + " characters long.");
            username = Console.ReadLine();
            numbers = NoNumbers(username);
            length = validateLength(username);
        }

        LookforCustomer(username);
    }

}

void LookforCustomer(string u)
{
    int hits = 0;
    int index = 0;
    for (int i = 0; i < users.Count; i++)
    {
        string name = users[i].Name();
        if (name.Equals(u))
        {
            hits++;
            index = i;
        }
    }

    if (hits == 1)
    {
        Console.WriteLine(hits + " hits " + "in the database.");
        Console.WriteLine("Enter the password for username: " + u);
        string p = Console.ReadLine();
        passwordCheck(p, index);
    }

    else if (hits == 0)
    {
        Console.WriteLine("No hits on that username.");
    }

}

void passwordCheck(string pass, int userIndex)
{
    User user = users[userIndex];
    if (user.GetPassWord().Equals(pass))
    {
        Console.Clear();
        Console.WriteLine("Access allowed!");
        Console.WriteLine("Type (v) to view your bank account or (e) to deposit/withdraw money");
        string action = Console.ReadLine();
        if (action.Equals("v"))
        {
            int cash = findUserAccount(user);
            if (cash == 0)
            {
                Console.WriteLine("No account found.");
            }
            else if (cash > 0)
            {
                Console.WriteLine("Current balance: " + cash + " sek");
            }
        }

    }

    else if (!user.GetPassWord().Equals(pass))
    {
        Console.Clear();
        Console.WriteLine("Access denied.");
    }
}

int findUserAccount(User u)
{
    string name = u.Name();
    bool hasAccount;
    int balance;
    foreach (KeyValuePair<string, int> pair in UserAccounts)
    {
        if (UserAccounts.ContainsKey(name))
        {
            hasAccount = UserAccounts.TryGetValue(name, out balance);

            if (hasAccount)
            {
                return balance;
            }

            else if (!hasAccount)
            {
                return 0;
            }
        }

    }
    return 0;

}

int NoNumbers(string s)
{
    int numberError = 0;
    char[] charArray = s.ToCharArray();
    for (int i = 0; i < charArray.Length; i++)
    {
        if (Char.IsDigit(charArray[i]))
        {
            numberError++;
        }
    }
    return numberError;
}


bool validateLength(string input)
{
    bool b = false;
    if (input.Length < 3)
    {
        b = false;
    }
    else if (input.Length >= 3)
    {
        b = true;
    }
    return b;
}

void PrintRegister()
{
    foreach (KeyValuePair<string, int> pair in UserAccounts)
    {
        Console.WriteLine(pair.Key + " is the owner of account: " + pair.Value);
    }
}