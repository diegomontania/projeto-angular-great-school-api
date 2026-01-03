using GreatSchool.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GreatSchool.API.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //retorna apresentacao
        public ApresentacaoAPI Index()
        {
            return new ApresentacaoAPI();
        }
    }
}
