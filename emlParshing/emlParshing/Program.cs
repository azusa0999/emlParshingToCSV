using System;
using System.Text;
using System.IO;
using emlParshing.Class;

namespace emlParshing
{
    class Program
    {
        static Config config;
        static void Main(string[] args)
        {
            config = new Config();
            config.SetOptionText();

            try
            {
                FileList list = new FileList();
                using (Stream stream = new FileStream(config.OptionText.ExportFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using(StreamWriter csv = new System.IO.StreamWriter(stream, System.Text.Encoding.UTF8))
                    { 
                        string[] fileList = list.getFileList(config.OptionText.TagetDirectory);
                        foreach (string path in fileList)
                        {
                            Eml eml = new Eml();
                            string str = eml.ReadString(path);
                            str = DelimiterCutLine(str, config.OptionText.CutLineDelimiters);

                            str = StringDelete(str, config.OptionText.NotWriteStrings);
                            if(str.Length > 0)
                                csv.WriteLine(str);
                        }
                    }
                }
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
        }

        /// <summary>
        /// 구분자가 나올 때까지만 문자열을 옆으로 모아 반환한다.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="delimiter">구분자</param>
        /// <returns></returns>
        static string DelimiterCutLine(string text, string[] delimiters)
        {
            string ret = string.Empty;
            string line = string.Empty;
            StringReader strReader = new StringReader(text);
            while ((line = strReader.ReadLine()) != null)
            {
                bool isEqual = false;
                if (line.Trim().Length > 0)
                {
                    foreach (string delimiter in delimiters)
                    {
                        if (line.Contains(delimiter))
                        {
                            isEqual = true;
                            break;
                        }
                    }

                    if (isEqual == true)
                        break;

                    ret = ret + line.Trim();
                }
            }

            ret = ret.TrimStart();
            ret = ret.TrimEnd();
            return ret;
        }

        /// <summary>
        /// 원하는 문자열을 삭제하고 반환한다.
        /// </summary>
        /// <param name="TagetText">수정할 문자열</param>
        /// <param name="deleteTexts">삭제할 대상문자열</param>
        /// <returns></returns>
        static string StringDelete(string TagetText, string[] deleteTexts)
        {
            string ret = TagetText;
            foreach (string deleteText in deleteTexts)
                ret = ret.Replace(deleteText, string.Empty).TrimStart().TrimEnd();

            return ret;
        }
    }
}
