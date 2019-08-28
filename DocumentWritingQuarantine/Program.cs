using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentWritingQuarantine
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer;
            writer = new StreamWriter("test.txt");
            QSC qSC = new QSC();
            qSC.cSW("Test");
            
        }
    }
}
