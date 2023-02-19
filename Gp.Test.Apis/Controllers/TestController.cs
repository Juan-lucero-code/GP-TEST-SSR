namespace GP.Test.Apis.Controllers
{
    using Gp.Test.Api.DTO;
    using Gp.Test.Entity;
    using Gp.Test.Interface.Repositories;
    using Gp.Test.Interface.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _service;
        public TestController(ITestService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<PersonasDTO>? GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<PersonasDTO>? GetById([FromRoute] string id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public ActionResult<Personas>? Save([FromBody] PersonasDTO request)
        {
            return Ok(_service.Save(request));
        }

        [HttpPut]
        public ActionResult<bool> Update([FromBody] PersonasDTO request)
        {
            return Ok(_service.Update(request));
        }
    }
}
