using System.Web;

namespace WebApplication1.Models.Task3
{
    public static class HttpPostedFileUtility
    {
        public static FileModel MapFileToDomainObject(this HttpPostedFileBase file)
        {
            return new FileModel
            {
                file_name = file.FileName,
                file_type = file.ContentType,
                document = file.Read()
            };
        }

        private static byte[] Read(this HttpPostedFileBase file)
        {
            var tempFile = new byte[] { };

            if (file.ContentLength > 0)
            {
                tempFile = new byte[file.ContentLength];

                file.InputStream.Read(tempFile, 0, file.ContentLength);
            }

            return tempFile;
        }
    }
}