using System.Data;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace JLIDashboard.Classes.Common.Extensions
{
    public static class FormCollectionExt
    {
        public static T Find<T>(this FormCollection collection)
        {
            Type type = typeof(T);
            foreach (Form form in collection)
            {
                if (form.GetType() == type)
                {
                    return (T)((object)form);
                }
            }
            return default(T);
        }
        public static T Singleton<T>(this FormCollection collection)
        {
            Form form = collection.Find<T>() as Form;
            if (form == null)
            {
                Type type = typeof(T);
                form = (Activator.CreateInstance(type) as Form);
            }
            return (T)((object)form);
        }
        public static void CloseAll(this FormCollection collection, params Type[] types)
        {
            List<Type> list = new List<Type>(types);
            foreach (Form form in collection)
            {
                if (list.Count != 0 && list.Contains(form.GetType()))
                    continue;
                form.Close();
            }
            list = null;
        }
        public static bool Activated<T>(this FormCollection collection)
        {
            var form = (collection.Find<T>() as Form);
            if (form != null)
            {
                form.Activate();
                return true;
            }
            return false;
        }
    }
}