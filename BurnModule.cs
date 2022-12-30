using CSDVDCDBurner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CDBurnerModule
{
    public class CDBurner
    {
        public static DVDCDBurner burner = new DVDCDBurner();

        public static void BurnFiles(String[] filelist, int drive, bool openWhenFinish)
        {
            foreach (String file in filelist)
            {
                FileAttributes attr = File.GetAttributes(@file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    CDBurner.burner.AddDir(file);
                else
                    CDBurner.burner.AddFile(file);
            }
            var today = DateTime.Today;
            var someval = CDBurner.burner.Burn(drive, today.ToShortTimeString(), false, openWhenFinish);

        }

        public static long GetDrives()
            {
                long drives = CDBurner.burner.GetInfoDrives();
                return drives;
            }

        public static long IsDriveReady(int drive)
        {
            long result = burner.IsMediaReady(drive);
            return result;
        }
    }

}
