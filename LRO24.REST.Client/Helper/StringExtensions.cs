namespace LRO24.REST.Client.Helper {
    internal static class StringExtensions {
        public static string NormalizeUrl(this string url) {
            url = (url ?? "").Trim();
            url = url.ToLower();

            if(url.EndsWith("/")) {
                url = url.Substring(0, url.Length - 1);
            }

            return url;
        }

        public static string Base64UrlEncode(this string base64) {
            return base64.Replace("+", "~")
                .Replace("/", "-")
                .Replace("=", "_");
        }

        public static string Base64UrlDecode(this string base64) {
            return base64.Replace("~", "+")
                .Replace("-", "/")
                .Replace("_", "=");
        }
    }
}