using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace lab4_1
{
    class Card_info
    {
        static public List<string> ReadFile(string path)
        {
            List<string> CardNum=new List<string>() {""};
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                CardNum.Remove("");
                StreamReader fin = new StreamReader(path);
                while (!fin.EndOfStream) {
                    CardNum.Add(fin.ReadLine());
                }
                fin.Close();
            }
            return CardNum;
        }

        static public void Write(string path,List<string> rez, bool add = true)
        {

            StreamWriter fout = new StreamWriter(path, add);
            foreach (string a in rez)
            fout.WriteLine(a);
            fout.Close();

        }
    }
}