namespace udemy_dotnet6_rpg.DTOS.Weapon
{
	public class AddWeaponDTO
	{
		public string Name { get; set; } = string.Empty;
		public int Damage { get; set; }
		public int CharacterId { get; set; }
	}
}
