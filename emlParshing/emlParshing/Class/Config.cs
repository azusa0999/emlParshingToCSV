using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace emlParshing.Class
{
    public class Config
    {
        public Global.ConfigOptionText OptionText;

        /// <summary>
        /// config파일을 옵션텍스트에 저장
        /// </summary>
        public void SetOptionText()
        {
            OptionText.ExportFileName = getConfig("ExportFileName");
            OptionText.TagetDirectory = getConfig("TagetDirectory");
            OptionText.CutLineDelimiters = getConfigValues("CutLineDelimiters");
            OptionText.NotWriteStrings = getConfigValues("NotWriteStrings");
            ValidConfig();
        }
        /// <summary>
        /// config 파일 읽고 해당하는 항목의 값 반환하기
        /// </summary>
        /// <param name="FindItem">항목명</param>
        /// <returns></returns>
        static string getConfig(string FindItem)
        {
            string path = Global.configFileName;
            
            string line = string.Empty;
            string val = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(FindItem))
                    {
                        val = line.Replace(FindItem + "=", string.Empty);
                        return val;
                    }
                }
            }
            return string.Empty;
        }


        /// <summary>
        /// config 파일 읽고 해당하는 항목의 값 반환하기
        /// </summary>
        /// <param name="FindItem">항목명</param>
        /// <returns></returns>
        static string[] getConfigValues(string FindItem)
        {
            string path = "config.txt";

            string line = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(FindItem))
                    {
                        string[] val = line.Replace(FindItem + "=", "").Split(',');
                        return val;
                    }
                }
            }
            return null;
        }

        private void ValidConfig()
        {
            if (string.IsNullOrEmpty(OptionText.TagetDirectory))
                throw new Exception("TagetDirectory 항목이 없거나 TagetDirectory 항목에 내용이 없습니다. 프로그램이 종료됩니다.");
            else if (OptionText.CutLineDelimiters == null)
                throw new Exception("CutLineDelimiters 항목이 없거나 CutLineDelimiters 항목에 내용이 없습니다. 프로그램이 종료됩니다.");
            else if (string.IsNullOrEmpty(OptionText.ExportFileName))
                throw new Exception("ExportFileName 항목이 없거나 ExportFileName 항목에 내용이 없습니다. 프로그램이 종료됩니다.");
            else if (OptionText.NotWriteStrings == null)
                throw new Exception("NotWriteStrings 항목이 없거나 NotWriteStrings 항목에 내용이 없습니다. 프로그램이 종료됩니다.");
        }
    }
}
