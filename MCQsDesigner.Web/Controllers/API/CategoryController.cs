﻿using MCQsDesigner.BOL;
using MCQsDesigner.DAL;
using MCQsDesigner.DAL.DAC;
using MCQsDesigner.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MCQsDesigner.Web.Controllers.API
{
    public class CategoryController : ApiController
    {
        private CategoryDAC _category;
        private DegreeProgramDAC _degree;

        public CategoryController()
        {
            _category = new CategoryDAC();
            _degree = new DegreeProgramDAC();
        }




        [HttpGet]
        public IHttpActionResult GetCategory()
        {
            var model = _category.GetAll().Select(x => new {
                x.Id,
                x.Title
            });
            
            return Ok(model);
        }



        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            _category.DeleteCategory(id);
            return Ok();
        }

        // Degree Program
        [HttpGet]
        public IHttpActionResult GetProgram()
        {
          

            var model = _degree.GetAll()
                        .Select(x => new
                        {
                            x.Id,
                            x.ProgramTitle,
                            Category = new
                            {
                                x.Category.Title

                            }
                        });


            return Ok(model);
        }
        [HttpDelete]
        public IHttpActionResult DeleteDegree(int id)
        {
            _degree.DeleteDegree(id);
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            _degree.Dispose();
            _category.Dispose();
            base.Dispose(disposing);
        }




    }
}