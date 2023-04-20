using System;
using System.Collections.Generic;
using System.IO;

namespace CueRomovePreGap
{
    internal class ProcessFile
    {
        private const string _TRACK = "TRACK";
        private const string _INDEX = "INDEX";

        private ProcessFileInput _processFileInput;
        private ProcessFileOutput _processFileOutput;
        private List<string> _lineList;

        public ProcessFileOutput Execute(ProcessFileInput processFileInput)
        {
            _processFileInput = processFileInput;
            _processFileOutput = new ProcessFileOutput();

            try
            {
                _lineList = new List<string>();

                ReadFile();

                Process();

                WriteFile();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _processFileOutput;
        }

        private void Process()
        {
            int trackIdFound = 0;
            int indexIdFound = 0;

            int count = _lineList.Count;
            for (int inx = 0; inx < count; inx++)
            {
                if (String.IsNullOrEmpty(_lineList[inx]))
                    continue;

                trackIdFound = GetTrackId(_lineList[inx], inx);

                if (trackIdFound >= 0)
                {
                    _processFileOutput.TrackCount = trackIdFound;
                    continue;
                }

                indexIdFound = GetIndexId(_lineList[inx], inx);

                if (indexIdFound < 0)
                    continue;

                if (indexIdFound == 0)
                {
                    string oldValue = $"{_INDEX} 00";
                    string newValue = $"{_INDEX} 01";
                    _lineList[inx] = _lineList[inx].Replace(oldValue, newValue);
                    _lineList[inx + 1] = null; //remove next
                    _processFileOutput.ChangeCount++;
                    continue;
                }

                if (indexIdFound > 1)
                {
                    if (_processFileInput.RemoveSubIndexes)
                        _lineList[inx] = null;
                    continue;
                }
            }
        }


        private void ReadFile()
        {
            String line;

            using (StreamReader streamReader = new StreamReader(_processFileInput.FullFileName))
            {
                line = streamReader.ReadLine();
                while (line != null)
                {
                    _lineList.Add(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
            }
        }

        private void WriteFile()
        {

            string dir = Path.GetDirectoryName(_processFileInput.FullFileName);
            _processFileOutput.NewFullFileName = Path.Combine(dir, _processFileInput.NewFileName);

            //write new file
            using (StreamWriter streamWriter = new StreamWriter(_processFileOutput.NewFullFileName))
            {
                foreach (string nline in _lineList)
                {
                    if (!String.IsNullOrEmpty(nline))
                        streamWriter.WriteLine(nline);
                }

                streamWriter.Flush();
                streamWriter.Close();
            }
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
