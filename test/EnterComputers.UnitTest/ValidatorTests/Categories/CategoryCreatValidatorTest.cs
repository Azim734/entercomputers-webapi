using EnterComputers.Service.Dtos.Categories;
using EnterComputers.Service.Validators.Dtos.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterComputers.UnitTest.ValidatorTests.Categories
{
    public class CategoryCreatValidatorTest
    {
        [Theory]
        [InlineData("file.png")]
        [InlineData("file.jpg")]
        [InlineData("file.jpeg")]
        [InlineData("file.bmp")]
        [InlineData("file.svg")]

        public void ShouldReturnImageFileExtension(string imagename)
        {
            byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simple dummy of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.");
            IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", imagename);  
            CategoryCreateDto categoryCreateDto = new CategoryCreateDto()
            {
                Name = "electronic products",
                Description = "we sell an electronic product to our clients",
                Image = imageFile
            };
            var validator = new CategoryCreateValidator();
            var result = validator.Validate(categoryCreateDto);
            Assert.True(result.IsValid);
        }


    }
}
