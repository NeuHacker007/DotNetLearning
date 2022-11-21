using SmartEnum;

CreditCard? creditcard = CreditCard.Platinum;
CreditCard? creditcard1 = CreditCard.FromName("Platinum");
CreditCard? creditcard2 = CreditCard.FromValue(3);

Console.WriteLine(creditcard.Equals(creditcard1));
Console.WriteLine(creditcard1?.Equals(creditcard2));
Console.WriteLine(creditcard?.Equals(creditcard1));
Console.WriteLine($"Discount for {creditcard} is {creditcard?.Discount:P}");
Console.ReadKey();