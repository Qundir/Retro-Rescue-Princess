// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("AiJR8p5woGG2PNhYQJwJzVwMU9CNiGHFwLlWZDeEi1wRcrKOXSImKY281Z7vNK3Dab9pHJa9UepGzbFh7+ptn2rmuWCEQRl2zdjDthXmPux6Jf+Ny6866bcfPv6r+vxHO9igQFv/inC4ssHaoWW53gY9enyfs8QGsbdt85fV+dY0xE6kRgF5/b+8w0h/PN4TA4EXZdvpRRhG7vXhbuRbkLRrV5E50UDmg0iQ7aGGpjv35KENVqzro01S5mj4ysIXjouv53NUz4sYGU46ooTeeFpHMSlU/BkFSl2ddXHDQGNxTEdIa8cJx7ZMQEBAREFCw0BOQXHDQEtDw0BAQdVPDUiK8BChYt8kH1D6UwpKTad/zefcHAGXV6FRcZySDcVX8ENCQEFA");
        private static int[] order = new int[] { 4,11,9,12,9,13,12,10,8,12,10,12,12,13,14 };
        private static int key = 65;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
