using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NipSearchApp.Models;
using System.Text.Json;

namespace NipSearchApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public SearchController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetOne(string id)
        {
            var task = _dataContext.Subject.Include(x=>x.accountNumbers)
                                           .Include(x=>x.authorizedClerks)
                                           .Include(x=>x.partners)
                                           .Include(x=>x.representatives)
                                           .Where(x => x.nip == id).FirstOrDefault();

            if (task == null)
            {
                var currentDate = DateTime.Now.GetDateTimeFormats();
                var requestUrl = $"https://wl-test.mf.gov.pl/api/search/nip/{id}?date={currentDate[0]}";

                HttpClient client = new HttpClient();
                var response = await client.GetAsync(requestUrl);
                var json = response.Content.ReadAsStringAsync().Result;
                Root? entities = JsonSerializer.Deserialize<Root>(json);

                var result = entities.result;
                var subject = result.subject;

                _dataContext.Subject.Add(subject);

                try
                {
                    await _dataContext.SaveChangesAsync();
                }
                catch (System.Exception)
                {

                    throw;
                }

                return Ok(subject);
            }
            return Ok(task);           
        }
    }
}