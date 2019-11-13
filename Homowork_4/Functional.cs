using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homowork_4
{
    class Functional
    {
        string path1;
        string path2;
        string[] str = new string[1];
        
        public string [] Files(string path)//вывод всех файлов 
        {
            try
            {
                string[] files = Directory.GetFiles(path);
                DateTime time = File.GetCreationTime(path);
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = Path.GetFileName(files[i]);
                }
                return files;
            }
            catch(System.IO.IOException)
            {
                try
                {
                    Process.Start(path);
                }
                catch(System.ComponentModel.Win32Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Can't find file");
                }
            }
            return str;
        }
        public string[] TimeFile(int lenght,string path)
        {
            string[] time = new string[lenght];
            try
            {
                string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                time[i] = File.GetCreationTime(files[i]).ToString();
            }
            return time;
            }
            catch (System.IO.IOException)
            { }
            return str;
        }
        public string[] TimeDirect(int lenght, string path)
        {
            string[] time = new string[lenght];
            try
            {
                string[] files = Directory.GetDirectories(path);
                for (int i = 0; i < files.Length; i++)
                {
                    time[i] = File.GetCreationTime(files[i]).ToString();
                }
                return time;
            }
            catch(System.IO.IOException)
            { }
            return str;

        }

        public string[] TimeAllFiles(int dl,int fl,string path)
        {
            string[] alltime = new string[TimeDirect(dl,path).Length+TimeFile(fl,path).Length];
            for (int i = 0; i < TimeDirect(dl, path).Length; i++)
            {
                alltime[i] = TimeDirect(dl, path)[i];
            }
            for (int i = TimeDirect(dl, path).Length; i < TimeFile(fl, path).Length + TimeDirect(dl, path).Length; i++)
            {
                alltime[i] = TimeFile(fl, path)[i - TimeDirect(dl, path).Length];
            }
            return alltime;
        }
        public string[] Direct(string path)//вывод всех папок
        {
            try
            {
                string[] dir = Directory.GetDirectories(path);
                for (int i = 0; i < dir.Length; i++)
                    dir[i] = Path.GetFileName(dir[i]);
                return dir;
            }
            catch (System.IO.IOException)
            {}
            return str;

        }
        public string [] AllFiles(string path)
        {
            string[] all = new string[Files(path).Length+ Direct(path).Length];
            for (int i = 0 ; i < Direct(path).Length; i++)
            {
                all[i] = Direct(path)[i];
            }
            for (int i = Direct(path).Length; i < Files(path).Length + Direct(path).Length; i++)
            {
                all[i] = Files(path)[i- Direct(path).Length];
            }
            
            return all;
        }
        public string BackL(string path)
        {
            path1 = path;
            try
            {
                return Directory.GetParent(path).ToString();
            }
            catch
            {}
            return Directory.GetCurrentDirectory();
        }
        public string BackR(string path)
        {
            path2 = path;
            return Directory.GetParent(path).ToString();
        }
        public string MyHomeL()
        {
            return path1;
        }
        public string MyHomeR()
        {
            return path2;
        }
        public void Create(string path)
        {
            Directory.CreateDirectory(path);
        }
        public void Delete(string path)
        {
            string e = "Success";
            try
            {
                Directory.Delete(path);
            }
            catch
            {
                e = "Can't do it";
            }
            finally
            {
                System.Windows.Forms.MessageBox.Show(e);
            }
        }
        public string[] Drives()
        {
            string[] Drives = Environment.GetLogicalDrives();
            return Drives;
        }

    }
}
