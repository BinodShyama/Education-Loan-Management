using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.Media
{
    public class MedaiDto
    {

        public string Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public IFormFile UploadImage { get; set; }
    }
}
