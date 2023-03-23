
using RightWritingEmail.Services;
using System.Text;

Console.WriteLine("Hi there!");


StringHandler handler = new StringHandler(@"..\\..\\..\\Files\\TextFileWithMails.txt");
handler.Handle();
handler.MakeListOfMistakes();
Console.WriteLine(handler);




