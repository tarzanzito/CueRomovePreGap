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
        public ProcessFileOutput Execute(ProcessFileInput input)
        {
            var output = new ProcessFileOutput();

            try
            {
                //read
                List<string> list = new List<string>();
                String line;

                StreamReader streamReader = new StreamReader(input.FullFileName);
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
                        output.ChangeCount++;
                    }
                }

                //write new file
                string dir = Path.GetDirectoryName(input.FullFileName);
                output.NewFullFileName = Path.Combine(dir, input.NewFileName);

                StreamWriter streamWriter = new StreamWriter(output.NewFullFileName);
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

            return output;
        }
    }
}