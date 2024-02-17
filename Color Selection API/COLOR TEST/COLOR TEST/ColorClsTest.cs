using Color_Selection_API.Controllers;
using Color_Selection_API.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLOR_TEST.COLOR_TEST
{
    public class ColorClsTest
    {
        public readonly DbContextOptions<colorcls> _options;
        public colorcls db;
        public ColorDataController controller;

        public ColorClsTest()
        {
            _options=new DbContextOptionsBuilder<colorcls>().UseInMemoryDatabase(databaseName:"colordatabase").Options;

            db = new colorcls(_options);
            controller = new ColorDataController(db);

        }

        private static Color insertcolor()
        {
            return new Color()
            {
                Id = 4,
                colorName = "White",
                colorCode = 155,
                colorHexaCode = "#ffccnn",
            };
        }

        // --------------------------------------------------- GET DATA ------------------------------------------
        [Fact]
        public void getcolordata()
        {
            //setup
            var clrinsertdata = insertcolor();
            db.colores.Add(clrinsertdata);
            db.SaveChanges();

            //Exicute
            var res = controller.getalldata(clrinsertdata.Id);


          //Assert
          Assert.NotEmpty(res);
            Assert.Equal("White", res.FirstOrDefault().colorName);



        }

        //-------------------------------------------- INSERT DATA ---------------------------------------------
        [Fact]
        public void insertcolordata()
        {
            //Setup
            var clrinsert = insertcolor();

            //Exicute
            var res = controller.Post(clrinsert);
            var result = db.colores.FirstOrDefault(x=>x.Id==clrinsert.Id);
            db.SaveChanges();

            //Assert
            Assert.NotNull(result);

        }

        //------------------------------------------- UPDATE DATA -------------------------------------------------
        [Fact]

        public void colupdate()
        {
            //Setup
            var updateclr = insertcolor();
            db.colores.Add(updateclr); 
            db.SaveChanges();

            //Exicute
            var clrupdate = new Color()
            {
                Id = 4,
                colorName = "Red",
                colorCode = 0405,
                colorHexaCode = "#bnbnbn",
            };

            //Exicute
            var res = controller.Put(clrupdate.Id, clrupdate);
            var result = db.colores.FirstOrDefault();

            //Assert
            Assert.Equal("Red", result.colorName);
            Assert.NotNull(res);



        }

        // -------------------------------------------------- DELETE DATA ---------------------------------------------------
        [Fact]
        public void coldelete()
        {
            //Setup
            var clrdelete = insertcolor();

            //Exicute
            var res = controller.Delete(clrdelete.Id);
            var result = db.colores.FirstOrDefault(x => x.Id == clrdelete.Id);

            //Assert
            Assert.Null(result);


        }
    }
}
