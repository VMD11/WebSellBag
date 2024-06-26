﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Common
{
    public class GenarateRandomID
    {
        private static Random random = new Random();
        public static string Execute()
        {
            int byteLength = 5; // Số lượng byte cần sinh ra (tương đương với 10 ký tự hex)
            byte[] randomBytes = new byte[byteLength];

            // Sinh byte ngẫu nhiên
            random.NextBytes(randomBytes);

            // Chuyển đổi sang chuỗi hex
            string randomHex = BitConverter.ToString(randomBytes).Replace("-", "");

            return randomHex;
        }

    }
}