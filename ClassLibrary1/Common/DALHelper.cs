//using HuceDocs.Services.ViewModels.User;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net;
//using System.Net.Http;
//using System.Reflection;
//using System.Text;


//namespace HuceDocs.Services.Common
//{
//    public static class DALHelper
//    {
//        public static void CopyProperty(object fromObj, object toObj)
//        {
//            var fromType = fromObj.GetType();
//            var toType = toObj.GetType();
//            foreach (PropertyInfo prop in fromType.GetProperties())
//            {
//                if (prop.PropertyType.Namespace == "System")
//                    toType.GetProperty(prop.Name)?.SetValue(toObj, prop.GetValue(fromObj, null), null);
//            }
//        }
//        public static GoogleApiTokenInfo GetGoogleApiTokenInfo(string idToken)
//        {
//            string GoogleApiTokenInfoUrl = "https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=" + idToken;
//            var httpClient = new HttpClient();
//            var requestUri = new Uri(string.Format(GoogleApiTokenInfoUrl, idToken));

//            HttpResponseMessage httpResponseMessage;
//            try
//            {
//                httpResponseMessage = httpClient.GetAsync(requestUri).Result;
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }

//            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
//            {
//                return null;
//            }

//            var response = httpResponseMessage.Content.ReadAsStringAsync().Result;
//            var googleApiTokenInfo = JsonConvert.DeserializeObject<GoogleApiTokenInfo>(response);

//            return googleApiTokenInfo;
//        }
//    }
//}
