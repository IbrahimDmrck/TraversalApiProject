using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var vales = context.Visitors.ToList();
                return Ok(vales);
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                return values != null ? Ok(values) : NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                    return NotFound();
                context.Remove(values);
                context.SaveChanges();
                return Ok();
            }
        }


        [HttpPut]
        public IActionResult VisitorDelete(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Find<Visitor>(visitor.VisitorID);
                if (values == null)
                    return NotFound();
                values.City = visitor.City;
                values.Name = visitor.City;
                values.Mail = visitor.Mail;
                values.Surname = visitor.Surname;
                values.Name = visitor.Name;
                values.Country = visitor.Country;
                context.Update(values);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
