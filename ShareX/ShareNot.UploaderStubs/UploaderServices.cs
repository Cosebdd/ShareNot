namespace ShareX.UploadersLib
{
    public class UploaderServices
    {
        public interface IGenericUploaderService : IUploaderService
        {
            GenericUploader CreateUploader(UploadersConfig config, TaskReferenceHelper taskInfo);
        }
    }

    public abstract class ImageUploaderService : UploaderService<ImageDestination>, IGenericUploaderService
    {
        public abstract GenericUploader CreateUploader(UploadersConfig config, TaskReferenceHelper taskInfo);
    }

    public abstract class TextUploaderService : UploaderService<TextDestination>, IGenericUploaderService
    {
        public abstract GenericUploader CreateUploader(UploadersConfig config, TaskReferenceHelper taskInfo);
    }

    public abstract class FileUploaderService : UploaderService<FileDestination>, IGenericUploaderService
    {
        public abstract GenericUploader CreateUploader(UploadersConfig config, TaskReferenceHelper taskInfo);
    }

    public abstract class URLShortenerService : UploaderService<UrlShortenerType>
    {
        public abstract URLShortener CreateShortener(UploadersConfig config, TaskReferenceHelper taskInfo);
    }

    public abstract class URLSharingService : UploaderService<URLSharingServices>
    {
        public abstract URLSharer CreateSharer(UploadersConfig config, TaskReferenceHelper taskInfo);
    }

    public abstract class URLShortener : Uploader
    {
        public abstract UploadResult ShortenURL(string url);
    }

    public abstract class URLSharer : Uploader
    {
        public abstract UploadResult ShareURL(string url);
    }
}