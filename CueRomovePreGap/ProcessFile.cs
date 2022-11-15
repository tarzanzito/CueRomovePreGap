using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CueRomovePreGap
{
    internal class ProcessFile
    {
        public string Execute(string fullFileName, string newFileName)
        {
            string newFullFileName;

            try
            {
                //read
                List<string> list = new List<string>();
                String line;

                StreamReader streamReader = new StreamReader(fullFileName);
                line = streamReader.ReadLine();
                while (line != null)
                {
                    list.Add(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();

                //process
                int count = list.Count;
                for (int inx = 0; inx < count; inx++)
                {
                    if (String.IsNullOrEmpty(list[inx]))
                        continue;

                    if (list[inx].Contains("INDEX 00"))
                    {
                        list[inx] = list[inx].Replace("INDEX 00", "INDEX 01");
                        list[inx + 1] = null;
                    }
                }

                //write new file
                string dir = Path.GetDirectoryName(fullFileName);
                newFullFileName = Path.Combine(dir, newFileName);

                StreamWriter streamWriter = new StreamWriter(newFullFileName);
                foreach (string nline in list)
                {
                    if (!String.IsNullOrEmpty(nline))
                        streamWriter.WriteLine(nline);
                }

                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newFullFileName;
        }
    }
}