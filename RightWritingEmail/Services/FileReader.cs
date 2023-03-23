﻿using RightWritingEmail.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightWritingEmail.Services
{
    internal class FileReader : IFileReader
    {
        private string filePath;

        public string FilePath
        {
            get => filePath;
            set { if (value != null) filePath = value; }
        }

        public FileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public List<string> ReadExpression()
        {
            if (filePath == null || filePath == "")
            {
                throw new FileNotFoundException();
            }
            if (!File.Exists(filePath)) { File.Create(filePath); }

            List<string> result = new();
            using (StreamReader sr = new(filePath))
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine());
                }
                sr.Close();
            }
            return result;
        }
    }
}