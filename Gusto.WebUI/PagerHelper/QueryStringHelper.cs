using System;
using Gusto.Core.Entity.Abstract;

namespace Gusto.WebUI.PagerHelper
{
    //Klasik asp.net ortamında queryStringleri direk objeye çeviremediğimiz için bu yapıyı yazmıştım.
    //Algoritma ve reflection bilgimi gösterebilmek adına ekliyorum.
    //Mvc de böyle bir problem yok.
    public static class QueryStringHelper
    {
        public static T QueryByName<T>(string query)
            where T : class, IPostModel, new()
        {
            T model = new T();
            if (string.IsNullOrEmpty(query)) return model;

            var list = query.Split('&');
            foreach (var item in list)
            {
                var prop = item.Split('=');
                if (prop.Length > 1 && prop[1].Length > 0)
                {
                    var type = typeof(T).GetProperty(prop[0]);
                    if (type != null)
                        type.SetValue(model, Convert.ChangeType(prop[1], type.PropertyType));
                }
            }
            return model;
        }
    }
}