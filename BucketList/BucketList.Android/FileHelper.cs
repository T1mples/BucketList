using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BucketList.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BucketList.Droid;
using System.IO;
using Xamarin.Forms;
using TodoXamarinForms.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace TodoXamarinForms.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}