using Microsoft.AspNetCore.Components.Forms;

namespace Hotel.Server.Services.FileUpload
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IBrowserFile file);

        bool DeleteFile(string fileName);
    }

}
