

using BankProgram;

bool isRunning = true;
List<User> users = new();
List<Account> accounts = new();
Dictionary<string, int> UserAccounts = new Dictionary<string, int>();

// Demo objects ------------------------------ //
Account a = new(123, 500);
User u = new("Emelie", "lösenord1");
Account b = new(124, 600);
User v = new("Emil", "lösenord2");
users.Add(u);
accounts.Add(a);
users.Add(v);
accounts.Add(b);
UserAccounts.Add(u.Name(), a.getId());
//---------------------------------------------//

while (isRunning)
{
    Console.WriteLine("Possible actions: (p)rint, (a)dd, (d)elete, (r)emove");
    string answer = Console.ReadLine();
    if (answer.Equals("p"))
    {
        PrintRegister();

    }
}

void PrintRegister()
{
    foreach (KeyValuePair<string, int> pair in UserAccounts)
    {
        Console.WriteLine(pair.Key + " is the owner of account: " + pair.Value);
    }

}