using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getCardNum()
    {
        return cardNum;
    }

    public void setCardNum(String cardNum)
    {
        this.cardNum = cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public void setPin(int pin)
    {
        this.pin = pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public void setFirstName(String firstName)
    {
        this.firstName = firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public void setLastName(String lastName)
    {
        this.lastName = lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setBalance(double balance)
    {
        this.balance = balance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your money. Your new balance is " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());

            if (currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You're good to go. Thank you!");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();

        cardHolder person1 = new cardHolder("123456789", 1234, "John", "Doe", 1000.0);
        cardHolders.Add(person1);

        cardHolder person2 = new cardHolder("987654321", 4321, "Jane", "Smith", 500.0);
        cardHolders.Add(person2);

        cardHolder person3 = new cardHolder("567890123", 7890, "Alice", "Johnson", 2000.0);
        cardHolders.Add(person3);

        cardHolder person4 = new cardHolder("1111222233334444", 9999, "Robert", "Williams", 1500.0);
        cardHolders.Add(person4);

        cardHolder person5 = new cardHolder("5555666677778888", 8888, "Emily", "Anderson", 3000.0);
        cardHolders.Add(person5);

        cardHolder person6 = new cardHolder("9999000011112222", 7777, "Michael", "Brown", 2500.0);
        cardHolders.Add(person6);

        // Prompt user
        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please Try Again"); }
            }
            catch
            {
                Console.WriteLine("something happened :(");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please Try Again"); }
            }
            catch
            {
                Console.WriteLine("something happened :(");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + ":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("something happened :(");
            }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you!");
    }

}