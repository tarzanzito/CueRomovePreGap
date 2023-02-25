using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace CueRomovePreGap
{
    internal class ProcessFile
    {
        private const string _TRACK = "TRACK";
        private const string _INDEX = "INDEX";

        public ProcessFileOutput Execute(ProcessFileInput input)
        {
            var output = new ProcessFileOutput();

            try
            {
                //read file
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
                int trackIdFound = 0;
                int indexIdFound = 0;

                int count = list.Count;
                for (int inx = 0; inx < count; inx++)
                {
                    if (String.IsNullOrEmpty(list[inx]))
                        continue;

                    trackIdFound = GetTrackId(list[inx], inx);

                    if (trackIdFound >= 0)
                    {
                        output.TrackCount = trackIdFound;
                        continue;
                    }

                    indexIdFound = GetIndexId(list[inx], inx);

                    if (indexIdFound < 0)
                        continue;

                    if (indexIdFound == 0)
                    {
                        string oldValue = $"{_INDEX} 00";
                        string newValue = $"{_INDEX} 01";
                        list[inx] = list[inx].Replace(oldValue, newValue);
                        list[inx + 1] = null; //remove next
                        output.ChangeCount++;
                        continue;
                    }

                    if (indexIdFound > 1)
                    {
                        if (input.RemoveSubIndexes)
                            list[inx] = null;
                        continue;
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

        private int GetTrackId(string text, int inx)
        {
            //TRACK 01 AUDIO

            string temp = text.Trim();
            string[] words = temp.Split(' ');

            if (words.Length < 3)
                return -1;

            if (words[0] != _TRACK)
                return -1;

            int id;
            if (!int.TryParse(words[1], out id))
                throw new Exception($"Error in line {inx}: Track Format Invalid. [{text}]");

            return id;
        }

        private int GetIndexId(string text, int inx)
        {
            //INDEX 00 46:38:70

            string temp = text.Trim();
            string[] words = temp.Split(' ');

            if (words.Length < 3)
                return -1;


            if (words[0] != _INDEX)
                return -1;

            int id;
            if (!int.TryParse(words[1], out id))
                throw new Exception($"Error in line {inx}: Index Format Invalid. [{text}]");

            return id;
        }
    }
}
