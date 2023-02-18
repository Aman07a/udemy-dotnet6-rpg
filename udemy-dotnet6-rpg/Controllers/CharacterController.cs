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
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Get()
		{
			return Ok(await _characterService.GetAllCharacters());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetSingle(int id)
		{
			return Ok(await _characterService.GetCharacterById(id));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> AddCharacter(AddCharacterDTO newCharacter)
		{
			return Ok(await _characterService.AddCharacter(newCharacter));
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
		{
			var response = await _characterService.UpdateCharacter(updatedCharacter);

			if (response.Data == null)
			{
				return NotFound(response);
			}

			return Ok(response);
		}
	}
}
