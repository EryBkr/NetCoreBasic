

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingCore.ExtensionMethods
{
    public static class SessionExtensionMethod
    {
        public static void SetObject(ISession session,string key,object val)
        {
            string objectString = JsonConvert.SerializeObject(val);
            session.SetString(key,objectString);
        }

        public static T GetObject<T>(ISession session, string key) where T:class
        {
            string objectString = session.GetString(key);

            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }

            T value = JsonConvert.DeserializeObject<T>(objectString);
            return value;

        }
    }
}
