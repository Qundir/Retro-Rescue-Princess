// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("YGE2Qtr8pgAiP0lRLIRhfTIl5Q3ZGqdcZyiCK3IyNd8HtZ+kZHnvL8nPFYvvrYGuTLw23D55AYXHxLsw9fAZvbjBLhxP/PMkaQrK9iVaXlH1xK3ml0zVuxHHEWTuxSmSPrXJGbs4NjkJuzgzO7s4ODmtN3Uw8ohoAl2H9bPXQpHPZ0aG04KEP0Og2DiXkhXnEp7BGPw5YQ61oLvObZ5GlMwTL+lBqTie+zDoldn+3kOPnNl1Cbs4Gwk0PzATv3G/zjQ4ODg8OTou1JPbNSqeEICyum/289efCyy38wdEpmt7+W8do5E9YD6WjZkWnCPoI4fyCMDKuaLZHcGmfkUCBOfLvH56WimK5gjYGc5EoCA45HG1JHQrqNkpCeTqdb0viDs6ODk4");
        private static int[] order = new int[] { 7,5,3,11,9,5,11,12,8,12,11,11,13,13,14 };
        private static int key = 57;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
