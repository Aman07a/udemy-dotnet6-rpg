using udemy_dotnet6_rpg.DTOS.Character;

namespace udemy_dotnet6_rpg.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
		private static List<Character> characters = new List<Character> {
			new Character(),
			new Character { Id = 1, Name = "Sam" }
		};

		private readonly IMapper _mapper;

		public CharacterService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
			Character character = _mapper.Map<Character>(newCharacter);
			character.Id = characters.Max(c => c.Id) + 1;
			characters.Add(character);
			serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
		{
			return new ServiceResponse<List<GetCharacterDTO>>
			{
				Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList()
			};
		}

		public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
		{
			var serviceResponse = new ServiceResponse<GetCharacterDTO>();
			var character = characters.FirstOrDefault(c => c.Id == id);
			serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
			return serviceResponse;

		}
	}
}
