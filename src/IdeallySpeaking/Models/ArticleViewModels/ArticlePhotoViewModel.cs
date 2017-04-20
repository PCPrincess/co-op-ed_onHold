using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeallySpeaking.Models.ArticleViewModels
{
    public class ArticlePhotoViewModel
    {
        [Display(Name = "Upload Article Photo")]
        public IFormFile ForArticlePhoto { get; set; }
        // When 'Editing' (uploading) we use IFormFile.
        // To then store the Image in the database, the image must
        // be 'given' to a byte array
    }
}
