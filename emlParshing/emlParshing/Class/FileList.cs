using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace emlParshing.Class
{
    public class FileList
    {
        /// <summary>
        /// 특정 디렉토리의 파일 리스트 반환
        /// </summary>
        /// <param name="targetDirectory"></param>
        /// <returns></returns>
        public string[] getFileList(string targetDirectory)
        {
            // Process the list of files found in the directory.
            return Directory.GetFiles(targetDirectory);
        }
    }
}
