using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace udemy_dotnet6_rpg.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FightController : ControllerBase
	{
		private readonly IFightService _fightService;

		public FightController(IFightService fightService)
		{
			_fightService = fightService;
		}
	}
}
