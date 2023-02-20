namespace udemy_dotnet6_rpg.DTOS.Weapon
{
	public class AttackResultDTO
	{
		public string Attacker { get; set; } = string.Empty;
		public string Opponent { get; set; } = string.Empty;
		public int AttackerHP { get; set; }
		public int OpponentHP { get; set; }
		public int Damage { get; set; }
	}
}
