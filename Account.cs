﻿namespace BankProgram
{
    internal class Account
    {
        int id;
        int balance;

        public Account(int i, int b)
        {
            this.id = i;
            this.balance = b;

        }
        public int getId()
        {
            return id;
        }
    }
}