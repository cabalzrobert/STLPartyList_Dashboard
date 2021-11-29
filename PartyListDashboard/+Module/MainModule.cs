using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comm.Common.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using JLIDashboard.Classes;

namespace JLIDashboard.Module
{
    class MainModule
    {
        private static FileObject config = new FileObject(Application.StartupPath + "\\config.dat");
        static MainModule()
        {
            Pusher.PublicKey = config["Pusher:Key"].Str();
            Pusher.UrlHost = config["Pusher:Host"].Str();
            ImgService.UrlHost = config["ImgService:Host"].Str();
            ApkUploader.UrlHost = config["ApkUploader:Host"].Str();
        }

        public static void test() { }

        /*
         

//AE32020D13A166FC026BBA8BAAA25088 - 1613975717101|A1
//95936E6BF9B9152C3C14C770A9D02EEC - 1613975777755|B1


    //public static string PublicKey = "61D9D52BBBD733B578EE9126372871DC";
    public static string PublicKey = "AE32020D13A166FC026BBA8BAAA25088";
    public static readonly string UrlHost = "210.213.236.202:9999";
         */

    }
}
