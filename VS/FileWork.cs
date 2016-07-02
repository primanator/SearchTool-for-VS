using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace VS
{
    class FileWork
    {
        public int[] values = new int[16];
        public string[] years = new string[16];

        public FileWork()
        {
            for (int i = 0; i < 16; i++)
                values[i] = 0;
            years[0] = "2000";
            years[1] = "2001";
            years[2] = "2002";
            years[3] = "2003";
            years[4] = "2004";
            years[5] = "2005";
            years[6] = "2006";
            years[7] = "2007";
            years[8] = "2008";
            years[9] = "2009";
            years[10] = "2010";
            years[11] = "2011";
            years[12] = "2012";
            years[13] = "2013";
            years[14] = "2014";
            years[15] = "2015";
        }

        public void OutputFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(fs);
            String output = sr.ReadToEnd();
            sr.Dispose();
            GetYear(output);
        }


        public bool CheckExtension(string ext)
        {
            switch (ext)
            {
                case ".cpp":
                    return true;
                case ".c":
                    return true;
                case ".h":
                    return true;
                default:
                    return false;
            }
        }

        public void DirProcessing(DirectoryInfo dir)
        {
            if (CheckFiles(dir))
                FileProcessing(dir);
            if (CheckSubDirs(dir))
            {
                DirectoryInfo[] sub_dirs = dir.GetDirectories("*");
                for (int i = 0; i < sub_dirs.Length; i++)
                    DirProcessing(sub_dirs[i]);
            }
            else
                FileProcessing(dir);
        }

        public bool CheckSubDirs(DirectoryInfo dir)
        {
            DirectoryInfo[] sub_dirs = dir.GetDirectories("*");
            if (sub_dirs.Length >= 1)
                return true;
            return false;
        }

        public bool CheckFiles(DirectoryInfo dir)
        {
            FileInfo[] files = dir.GetFiles("*");
            if (files.Length >= 1)
                return true;
            return false;
        }

        public void FileProcessing(DirectoryInfo dir)
        {
            FileInfo[] main_files = dir.GetFiles("*");
            foreach (FileInfo x in main_files)
            {
                if (CheckExtension(x.Extension))
                    OutputFile(x.FullName);
            }
        }
        public void GetYear(string fcontent)
        {
            string pattern = @"\d\d\d\d-\d\d\d\d";
            Regex regular = new Regex(pattern);
            MatchCollection matches = regular.Matches(fcontent);
            for (int i = 0; i < matches.Count; i++)
            {
                char[] lastYearArr = matches[i].Value.ToCharArray();
                string lastYear = new string(lastYearArr, lastYearArr.Length - 4, 4);
                for (int j = 0; j < 16; j++)
                    if (years[j] == lastYear)
                        values[j]++;
            }
        }
    }
}