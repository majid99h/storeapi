using Core.Helper;

namespace Repositories.Service
{
    public interface IProcessService
    {
        BaseResponse UploadFile(dynamic File);
    }
}
