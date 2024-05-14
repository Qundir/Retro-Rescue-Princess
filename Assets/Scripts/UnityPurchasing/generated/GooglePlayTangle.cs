// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("Pf5DuIPMZs+W1tE741F7QICdC8vHYxbsJC5dRj35JUKaoebgAy9YmuOgQo+fHYv5R3XZhNpyaX3yeMcMERT9WVwlyvirGBfAje4uEsG+urWEhdKmPhhC5MbbrbXIYIWZ1sEB6e1f3P/t0NvU91uVWyrQ3Nzc2N3enr7NbgLsPP0qoETE3ACVUcCQz0wo98sNpU3ceh/UDHE9Gjqna3g9kXN28QP2eiX8GN2F6lFEXyqJeqJwESBJAnOoMV/1I/WACiHNdtpRLf1f3NLd7V/c199f3NzdSdOR1BZsjC0r8W8LSWVKqFjSONqd5WEjIF/UyjB3P9HOevRkVl6LEhcze+/IUxfmuWMRVzOmdSuDomI3ZmDbp0Q83D3N7QAOkVnLbN/e3N3c");
        private static int[] order = new int[] { 5,13,10,11,7,5,7,8,12,9,13,11,12,13,14 };
        private static int key = 221;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
