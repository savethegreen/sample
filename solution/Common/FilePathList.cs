using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution
{
   static class FilePathList
    {
        public static string DefaultPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"SQLiteDB.db");
    }
}
