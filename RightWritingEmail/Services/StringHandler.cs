using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightWritingEmail.Services
{
    internal class StringHandler
    {
        public List<string> EnterList { get; set; }
        public List<string> RightWritingList { get; set; }
        public List<string> WrongWritingList { get; set; }

        private const int standartLocalPartLength = 255;
        private const int standartDomainPartLength = 64;

        private readonly string[] reservedDomains =
            { ".example", ".invalid", "example.com", "example.net", "example.org"};

        private readonly char[] notAllowedSymbols = {'!', '#', '$', '%', '&', '*', '+',
            '/', '=', '?', '^', '`', '{', '|', '}', '~', ' ', '"'};

        public StringHandler()
        {
            EnterList = new List<string>();
            RightWritingList = new List<string>();
            WrongWritingList = new List<string>();
        }
        public StringHandler(string filePath)
        {
            FileReader reader = new FileReader(filePath);
            EnterList = reader.ReadExpression();
            RightWritingList = new List<string>();
            WrongWritingList = new List<string>();
        }
        public override string ToString()
        {
            return "\nRight writing mails:\n\n" + Print.PrintStringList(RightWritingList) +
                "\nWrong writing mails:\n\n" + Print.PrintStringList(WrongWritingList);
        }
        private bool IsAtSign(string str)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '@') { count++; }
            }
            if (count == 1) return true;
            else return false;
        }
        private bool IsNormalLength(string localPart, string domainPart)
        {
            if (localPart.Length <= standartLocalPartLength &&
                domainPart.Length <= standartDomainPartLength)
            {
                return true;
            }
            return false;
        }
        private bool IsReservedDomain(string str)
        {
            for (int i = 0; i < reservedDomains.Length; i++)
            {
                if (reservedDomains[i] == str) { return false; }
            }
            return true;
        }
        private bool IsAllowedSymbols(string str)
        {
            for (int i = 0; i < notAllowedSymbols.Length; i++)
            {
                if (str.Contains(notAllowedSymbols[i]))
                    return false;
            }
            return true;
        }
        private bool IsItQuote(string str)
        {
            if (str[0] == '"' && str[0] == str[str.Length - 1])
            { return true; }
            return false;
        }
        private bool IsRightUsingDot(string str)
        {
            if (str[0] == '.' || str[str.Length - 1] == '.') { return false; }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.' && str[i + 1] == '.') { return false; }
            }

            return true;
        }
        private bool IsRightUsingHyphen(string str)
        {
            if (str[0] == '-' || str[str.Length - 1] == '-') { return false; }
            return true;
        }
        private bool IsRightUsingUnderscore(string str)
        {
            if (str.Contains("_")) { return false; }
            return true;
        }
        
        private bool CheckDomain(string str)
        {
            if (IsReservedDomain(str) && IsRightUsingHyphen(str) &&
                IsRightUsingUnderscore(str)) { return true; }
            return false;
        }
        private bool CheckLocalPart(string str)
        {
            if (IsItQuote(str) || IsAllowedSymbols(str) && IsRightUsingDot(str)) 
            { return true; }
            return false;
        }

        public List<string> Handle()
        {
            for (int i = 0; i < EnterList.Count; i++)
            {
                if (IsAtSign(EnterList[i]))
                {
                    string localPart = EnterList[i].Remove(EnterList[i].IndexOf('@'),
                        (EnterList[i].Length - EnterList[i].IndexOf('@')));
                    string domainPart = EnterList[i].Remove(0, EnterList[i].IndexOf('@') + 1);

                    if (IsNormalLength(localPart, domainPart))
                    {
                        if (CheckDomain(domainPart) && CheckLocalPart(localPart))
                        {
                            RightWritingList.Add(EnterList[i]);
                        }
                    }
                }
            }
            return RightWritingList;
        }
        public List<string> MakeListOfMistakes()
        {
            foreach (var item in EnterList)
            {
                if (!RightWritingList.Contains(item))
                {
                    WrongWritingList.Add(item);
                }
            }
            return WrongWritingList;
        }
    }
}
