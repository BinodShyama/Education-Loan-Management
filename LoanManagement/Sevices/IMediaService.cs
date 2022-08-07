using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.Media;
using LoanManagement.ViewModel.ResponseModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Sevices
{
    public interface IMediaService
    {
        Task<ResponseModel<MedaiDto>> UpdateAsync(MedaiDto mvm);
        Task<ResponseModel<MedaiDto>> CreateAsync(MedaiDto mvm);
        Task<bool> Delete(string mediaId);
        Task<ResponseModel<MedaiDto>> Get(string mediaId);
    }
    public class MediaService : IMediaService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        public async Task<bool> Delete(string mediaId)
        {
            var image = await _db.Media.FindAsync(mediaId);
            string title = image.Title;
            if (image != null)
            {

                var result = DeleteFile(image);

                _db.Media.Remove(image);
                _db.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<ResponseModel<MedaiDto>> Get(string mediaId)
        {
            var mediaData = await _db.Media.Where(x => x.Id == mediaId).FirstOrDefaultAsync();
            if (mediaData != null)
            {
               var data= _mapper.Map<MedaiDto>(mediaData);
                return new ResponseModel<MedaiDto> { Status = true, Messages = new List<string> { "Successfully retrived" }, Data = data };
            }
            else
                return new ResponseModel<MedaiDto> { Status = false, Messages =new List<string> { "Retrived Failed" }, Data = null };
        }

        public async Task<ResponseModel<MedaiDto>> UpdateAsync(MedaiDto mvm)
        {
            var UpdateModel = await _db.Media.Where(o => o.Id == mvm.Id).AsNoTracking().FirstOrDefaultAsync();
            if (UpdateModel != null)
            {
                if (mvm.UploadImage != null)
                {

                    mvm.Url = await CreateFile(mvm);

                }

                mvm.CreatedDate = UpdateModel.CreatedDate;
                mvm.CreatedBy = UpdateModel.CreatedBy;
                UpdateModel = _mapper.Map<Media>(mvm);
                UpdateModel.UpdatedBy = _accountService.GetLoggedinUserId();
                UpdateModel.UpdateDate = DateTime.Now;
                _db.Media.Update(UpdateModel);
                await _db.SaveChangesAsync();
                return new ResponseModel<MedaiDto>() { Status = true, Messages = new List<string> { "Updated Successfully." }, Data = mvm };
            }
            return new ResponseModel<MedaiDto>() { Status = false, Messages = new List<string> { "Fail to Update." }, Data = mvm };


        }
        private bool DeleteFile(Media mvm)
        {
            string filename = mvm.Url;
            string folderpath = _hostingEnvironment.ContentRootPath;
            string filepath = $"{folderpath}\\wwwroot\\{mvm.Path}\\{filename}";
            try
            {
                if (File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private async Task<string> CreateFile(MedaiDto mvm)
        {
            var extension = System.IO.Path.GetExtension(mvm.UploadImage.FileName);
            string filename = System.Guid.NewGuid() + "." + extension;
            string folderpath = _hostingEnvironment.ContentRootPath;
            string filepath = $"{folderpath}\\wwwroot\\{mvm.Path}\\{filename}";
            try
            {
                using (var stream = System.IO.File.Create(filepath))
                {
                    await mvm.UploadImage.CopyToAsync(stream);
                }
                return filename;
            }
            catch (Exception ex)
            {
                //Log.LogError("MediaService - CreateOrUpdate - " + ex);
                return null;
            }

        }


        public async Task<ResponseModel<MedaiDto>> CreateAsync(MedaiDto mvm)
        {
            try
            {
                if (mvm.UploadImage != null)
                {
                    mvm.Url = await CreateFile(mvm);
                }
                mvm.CreatedDate = DateTime.Now;
                mvm.CreatedBy = _accountService.GetLoggedinUserId();
                _db.Media.Add(_mapper.Map<Media>(mvm));
                await _db.SaveChangesAsync();
                return new ResponseModel<MedaiDto>() { Status = true, Messages = new List<string> { "Saved Successfully" }, Data = mvm };
            }
            catch (Exception ex)
            {
                return new ResponseModel<MedaiDto>() { Status = false, Messages = new List<string> { "Fail to save." }, Data = mvm };
            }
        }
    }
}
