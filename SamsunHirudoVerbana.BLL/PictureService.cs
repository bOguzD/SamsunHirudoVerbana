using System;
using System.IO;
using AutoMapper;
using SamsunHirudoVerbana.BLL.DTOs;
using SamsunHirudoVerbana.BLL.EntityService;
using SamsunHirudoVerbana.BLL.Service;
using SamsunHirudoVerbana.Core.CoreRepository;
using SamsunHirudoVerbana.Core.UnitOfWorks;
using SamsunHirudoVerbana.Data;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.BLL
{
    public class PictureService : Service<Picture>, IPictureService
    {
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostingEnvironment;
        public PictureService(IUnitOfWork unitOfWork, IRepository<Picture> repository, IMapper mapper, IWebHostEnvironment hostingEnvironment) 
            : base(unitOfWork, repository)
        {
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task UploadPicture(PictureDTO model)
        {
            try
            {
                if (model == null)
                {
                    const string message = "Fotoğraf veya resim yüklenemesi tamamlanamadı. Dosyayı düzgün yüklediğinizden emin olun.";
                    //notyf.Error(message)
                    throw new Exception(message);
                }
                if (string.IsNullOrWhiteSpace(model.PictureName) || string.IsNullOrWhiteSpace(model.AltText))
                {
                    const string message = "Lütfen fotoğraf adını veya fotoğraf ile ilgili kelime tanımını boş bırakmayınız.";
                    //notyf.Warning(message);
                    throw new Exception(message);
                }

                string filePath = hostingEnvironment.WebRootPath + "/ProductImages/";
                bool filePathExist = Directory.Exists(filePath);
                if (!filePathExist)
                    Directory.CreateDirectory(filePath);

                //Save image to wwwroot
                string wwwrootPath = hostingEnvironment.WebRootPath;
                string extention = Path.GetExtension(model.File.FileName);
                model.PictureName = model.PictureName + extention;
                string path = Path.Combine(wwwrootPath, "ProductImages", model.PictureName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.File.CopyTo(fileStream);
                }

                model.PicturePath = path;

                Picture picEntity = mapper.Map<Picture>(model);
                await Insert(picEntity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Beklenmeyen hata oluştu", ex.InnerException);
            }
        }
    }
}
