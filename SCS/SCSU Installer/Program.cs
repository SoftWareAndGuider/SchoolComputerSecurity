using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using IWshRuntimeLibrary;
using Microsoft.Win32;

namespace SCSU_Installer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("설치를 시작합니다. 계속하려면 아무 키나 누르세요");
            Console.ReadKey();
            Console.WriteLine();
            try
            {
                Directory.CreateDirectory("C:\\SCS");
            }
            catch
            {
                Directory.Delete("C:\\SCS");
                Directory.CreateDirectory("C:\\SCS");
            }
            WebClient client = new WebClient();
            string programpath = @"C:\SCS";

            Console.WriteLine("디렉터리 생성 시작");
            Directory.Delete(programpath, true);
            Directory.CreateDirectory(programpath);
            Console.WriteLine("디렉터리 생성 완료");
            Console.WriteLine("파일 다운로드 시작");
            string ftpPath = "ftp://server.noeul.xyz/fileshare/SCS/SCSUUpdater.zip";
            string targetPath = @"C:\SCS\SCSUUpdater.zip";
            string userID = "fileshareftp";
            string password = "noeulfile1412!";
            client.Credentials = new NetworkCredential(userID, password);
            client.DownloadFile(ftpPath, targetPath);

            Console.WriteLine("파일 다운로드 완료");
            Console.WriteLine("압축 해제 시작");
            ZipFile.ExtractToDirectory($@"{programpath}\SCSUUpdater.zip", programpath);
            Console.WriteLine("압축 해제 완료");
            Console.WriteLine("SCSUUUpdater.exe의 바로가기를 복사해주세요");

            System.Diagnostics.Process.Start("explorer.exe", "shell:startup");

            Console.WriteLine("시작 프로그램 등록 완료");
            Console.WriteLine("설치 완료");
            Console.WriteLine("아무 키나 누르세요 . . . . .");
            Console.ReadKey();
        }
    }
}
