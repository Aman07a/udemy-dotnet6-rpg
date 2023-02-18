namespace udemy_dotnet6_rpg.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
		private static List<Character> characters = new List<Character> {
			new Character(),
			new Character { Id = 1, Name = "Sam" }
		};

		public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
			characters.Add(newCharacter);
			serviceResponse.Data = characters;
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
		{
			return new ServiceResponse<List<GetCharacterDTO>> { Data = characters };
		}

		public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
		{
			var serviceResponse = new ServiceResponse<GetCharacterDTO>();
			var character = characters.FirstOrDefault(c => c.Id == id);
			serviceResponse.Data = character;
			return serviceResponse;

		}
	}
}
