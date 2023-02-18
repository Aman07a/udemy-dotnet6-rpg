using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace udemy_dotnet6_rpg.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterController : ControllerBase
	{
		private readonly ICharacterService _characterService;

		public CharacterController(ICharacterService characterService)
		{
			_characterService = characterService;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<Character>> Get()
		{
			return Ok(await _characterService.GetAllCharacters());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Character>> GetSingle(int id)
		{
			return Ok(await _characterService.GetCharacterById(id));
		}

		[HttpPost]
		public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
		{
			return Ok(await _characterService.AddCharacter(newCharacter));
		}
	}
}
