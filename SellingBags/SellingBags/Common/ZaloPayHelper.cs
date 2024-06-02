using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SellingBags.Common
{
    public class ZaloPayHelper
    {
        private string app_id = "YourAppId"; // Thay bằng AppId của bạn
        private string key1 = "YourKey1"; // Thay bằng Key1 của bạn
        private string key2 = "YourKey2"; // Thay bằng Key2 của bạn
        private string createOrderUrl = "https://sandbox.zalopay.vn/v2/create";

        public async Task<string> CreatePaymentUrl(string orderId, decimal amount, string returnUrl, string embedData, string items)
        {
            var orderInfo = new
            {
                app_id = app_id,
                app_trans_id = orderId,
                app_user = "user123",
                app_time = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                item = items,
                embed_data = embedData,
                amount = amount,
                description = $"Thanh toan don hang {orderId}",
                bank_code = "zalopayapp",
                callback_url = returnUrl
            };

            string data = $"{app_id}|{orderInfo.app_trans_id}|{orderInfo.app_user}|{orderInfo.amount}|{orderInfo.app_time}|{orderInfo.embed_data}|{orderInfo.item}";
            //orderInfo.mac = HmacSHA256(key1, data);

            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(orderInfo), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(createOrderUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(responseString);
                return responseObject.order_url;
            }
        }

        private string HmacSHA256(string key, string data)
        {
            using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                var hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}