using EnterComputers.Service.Dtos.Categories;
using EnterComputers.Service.Validators.Dtos.Categories;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace EnterComputers.UnitTest.ValidatorTests.Categories
{
    public class CategoryCreatValidatorTest
    {
       [Theory]
        [InlineData(3.1)]
        [InlineData(3.01)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void ShouldReturnWrongImageFileSize(double imageSizeMB)
        {
            byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic product to our clients");
            long imageSizeInBytes = (long) (imageSizeMB * 1024 * 1024);
            IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png ");
            CategoryCreateDto categoryCreateDto = new CategoryCreateDto()
            {
                Name = "electronic products",
                Description = "we sell an electronic product to our clients",
                Image = imageFile
            };
            var validator = new CategoryCreateValidator();
            var result = validator.Validate(categoryCreateDto);
            Assert.False(result.IsValid);
        }




        [Theory]
        [InlineData(2.95)]
        [InlineData(3)]
        [InlineData(1)]
        [InlineData(0.75)]
        [InlineData(0.5)]
        [InlineData(2.5)]
        public void ShouldReturnValidImageFileSize(double imageSizeMB)
        {
            byte[] byteImage = Encoding.UTF8.GetBytes("we sell an electronic product to our clients");
            long imageSizeInBytes = (long)(imageSizeMB * 1024 * 1024);
            IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, imageSizeInBytes, "data", "file.png ");
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



        [Theory]
        [InlineData("file.png")]
        [InlineData("file.jpg")]
        [InlineData("file.jpeg")]
        [InlineData("file.bmp")]
        [InlineData("file.svg")]
        public void ShouldReturnCorrectImageFileExtension(string imagename)
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



        [Theory]
        [InlineData("file.zip")]
        [InlineData("file.mp3")]
        [InlineData("file.html")]
        [InlineData("file.gif")]
        [InlineData("file.txt")]
        [InlineData("file.HEIC")]
        [InlineData("file.mp4")]
        [InlineData("file.avi")]
        [InlineData("file.vaw")]
        [InlineData("file.pgf")]
        [InlineData("file.doc")]
        [InlineData("file.docx")]
        [InlineData("file.xls")]
        [InlineData("file.exe")]
        [InlineData("file.dll")]
        public void ShouldReturnWrongImageFileExtension(string imagename)
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
            Assert.False(result.IsValid);
        }



        [Fact]

        public void ShouldReturnValidValidation()
        {
            byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simple dummy of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.");
            IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "File.jpg");
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


        [Theory]
        [InlineData("AA")]
        [InlineData("A")]
        [InlineData("electronic productswe sell an electronic product to our clientswe sell an electronic product to our clientswe sell an electronic product to our clients")]
        public void ShouldReturnInValidValidation(string name)
        {
            byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simple dummy of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.");
            IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "File.jpg");
            CategoryCreateDto categoryCreateDto = new CategoryCreateDto()
            {
                Name = name,
                Description = "we sell an electronic product to our clients",
                Image = imageFile
            };
            var validator = new CategoryCreateValidator();
            var result = validator.Validate(categoryCreateDto);
            Assert.False(result.IsValid);
        } 
    }
}
