using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace TestExe
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte[] commandEncoded = Convert.FromBase64String(args[0]);
            //string command = Convert.FromBase64String(Encoding.UTF8.GetString(commandEncoded));
            //string command = Encoding.UTF8.GetString(commandEncoded);
            Runspace mySpace = RunspaceFactory.CreateRunspace();
            mySpace.Open();
            Pipeline myPipeLine = mySpace.CreatePipeline();
            Console.WriteLine(args[0].Replace("+", " "));
            myPipeLine.Commands.AddScript(args[0].Replace("+"," "));
            Collection<PSObject> outputs = myPipeLine.Invoke();
            mySpace.Close();

            System.Text.StringBuilder sb = new StringBuilder();

            foreach (PSObject pobject in outputs)
            {

                sb.AppendLine(pobject.ToString());

            }
            Console.WriteLine(sb.ToString());
        }
    }
}
