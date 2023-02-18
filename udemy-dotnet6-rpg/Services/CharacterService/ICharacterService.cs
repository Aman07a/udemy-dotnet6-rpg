namespace udemy_dotnet6_rpg.Services.CharacterService
{
	public interface ICharacterService
	{
		List<Character> GetAllCharacters();
		Character GetCharacterById(int id);
		List<Character> AddCharacter(Character newCharacter);
	}
}
