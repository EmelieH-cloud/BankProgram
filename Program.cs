

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
UserAccounts.Add(u.Name(), account1.getId());
UserAccounts.Add(v.Name(), account2.getId());
//---------------------------------------------//

while (isRunning)
{
    Console.WriteLine("WELCOME TO THE BANK");
    Console.WriteLine("Are you a (c)ustomer or a (b)ank associate?");
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

    }

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