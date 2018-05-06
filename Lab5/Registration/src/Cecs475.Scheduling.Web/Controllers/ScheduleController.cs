using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Cecs475.Scheduling.Web.Controllers
{
    public class SemesterTermDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static SemesterTermDto From(Model.SemesterTerm s)
        {
            return new SemesterTermDto()
            {
                Id = s.Id,
                Name = s.Name
            };
        }
    }


    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        private Model.CatalogContext mContext = new Model.CatalogContext();

        [HttpGet]
        [Route("{year}/{term}")]
        public IEnumerable<CourseSectionDto> Get(string year, string term)
        {
            string termName = term + " " + year;
            var termObject = mContext.SemesterTerms.Where(m => m.Name == termName).FirstOrDefault();
            if (termObject == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"SemesterTerm named \"{termName}\" not found"));
            }
            return termObject.CourseSections.Select(CourseSectionDto.From);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IEnumerable<CourseSectionDto> Get(int id)
        {
            var termObject = mContext.SemesterTerms.Where(m => m.Id == id).FirstOrDefault();
            if (termObject == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"SemesterTerm ID \"{id}\" not found"));
            }
            var termName = termObject.Name.Split(' ');
            return Get(termName[1], termName[0]);
        }

        [HttpGet]
        [Route("terms")]
        public IEnumerable<SemesterTermDto> Get()
        {
            return mContext.SemesterTerms.Select(SemesterTermDto.From);
        }
    }
}