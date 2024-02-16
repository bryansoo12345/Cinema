namespace Cinema.Models.Utilities
{
    public static class ImageUtility
    {
        public static void SaveImageFile<T>(T entity) where T : IImageEntity
        {
            if (entity.IFormPhoto != null && entity.IFormPhoto.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    entity.IFormPhoto.CopyTo(memoryStream);
                    entity.PhotoFile = memoryStream.ToArray();
                }
            }
        }
    }   
}
