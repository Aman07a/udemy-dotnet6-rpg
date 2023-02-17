using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace udemy_dotnet6_rpg.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterController : ControllerBase
	{
		private static List<Character> characters = new List<Character>
		{
			new Character(),
			new Character { Name = "Sam" }
		};

		[HttpGet("GetAll")]
		public ActionResult<Character> Get()
		{
			return Ok(characters);
		}

		[HttpGet]
		public ActionResult<Character> GetSingle()
		{
			return Ok(characters[0]);
		}
	}
}
