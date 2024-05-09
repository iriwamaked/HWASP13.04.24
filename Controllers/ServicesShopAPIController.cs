using HWASP.Data.DAL;
using HWASP.Models.ServicesShop;
using HWASP.Services.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HWASP.Controllers
{
    [Route("api/servicesshop")]
    [ApiController]
    public class ServicesShopAPIController (DataAccessor dataAccessor, IUploadService uploadService): ControllerBase
    {
        private readonly DataAccessor _dataAccessor=dataAccessor;
        private readonly IUploadService _uploadService=uploadService;
        

        [HttpPost("category")]
        public object DoPost(ServicesShopCategoryFormModel model)
        {
            if(String.IsNullOrEmpty(model.Slug) ||
                    String.IsNullOrEmpty(model.Name) || String.IsNullOrEmpty(model.Description))
            {
                Response.StatusCode=StatusCodes.Status422UnprocessableEntity;
                return "Missing required data";
            }
            try
            {
                _dataAccessor.ServicesShopDao.AddCategory(
                    name: model.Name,
                    slug: model.Slug,
                    description: model.Description,
                    imageUrl: _uploadService.SaveFormFile(model.Image, "wwwroot/img/servicesImg"));
                Response.StatusCode = StatusCodes.Status201Created;
                return "Ok";
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                return ex.Message;
            }
            
        }
    }
}
