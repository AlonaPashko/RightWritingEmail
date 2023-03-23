
using RightWritingEmail.Services;
using System.Text;

Console.WriteLine("Hi there!");


//5. sprawdzania lokalnej czesci i domainu osobno


StringHandler handler = new StringHandler(@"..\\..\\..\\Files\\TextFileWithMails.txt");
handler.Handle();
handler.MakeListOfMistakes();
Console.WriteLine(handler);




