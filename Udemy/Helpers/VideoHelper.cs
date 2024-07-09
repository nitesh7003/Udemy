namespace Udemy.Helpers
{
    public static class VideoHelper
    {
        public static string GetEmbedUrl(string videoUrl)
        {
            if (videoUrl.Contains("youtube.com/watch"))
            {
                return videoUrl.Replace("watch?v=", "embed/");
            }
            else if (videoUrl.Contains("youtu.be/"))
            {
                return videoUrl.Replace("youtu.be/", "youtube.com/embed/");
            }
            else
            {
                return videoUrl;
            }
        }
    }
}
