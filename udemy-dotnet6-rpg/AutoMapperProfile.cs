namespace udemy_dotnet6_rpg
{
	public class AutoMapperProfile: Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Character, GetCharacterDTO>();
			CreateMap<AddCharacterDTO, Character>();
			CreateMap<Weapon, GetWeaponDTO>();
			CreateMap<Skill, GetSkillDTO>();
			CreateMap<Character, HighscoreDTO>();
		}
	}
}
