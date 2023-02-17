using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace udemy_dotnet6_rpg.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterController : ControllerBase
	{
		private static Character knight = new Character();

		[HttpGet]
		public ActionResult<Character> Get()
		{
			return Ok(knight);
		}
	}
}
