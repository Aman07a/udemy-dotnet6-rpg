using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace udemy_dotnet6_rpg.Services.WeaponService
{
	public class WeaponService : IWeaponService
	{
		private readonly DataContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IMapper _mapper;

		public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<GetCharacterDTO>> AddWeapon(AddWeaponDTO newWeapon)
		{
			var response = new ServiceResponse<GetCharacterDTO>();

			try
			{
				var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId);

				if (character == null)
				{
					response.Success = false;
					response.Message = "Character not found.";
					return response;
				}

				Weapon weapon = new Weapon
				{
					Name = newWeapon.Name,
					Damage = newWeapon.Damage,
					Character = character
				};

				_context.Weapons.Add(weapon);
				await _context.SaveChangesAsync();

				response.Data = _mapper.Map<GetCharacterDTO>(character);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}
	}
}
