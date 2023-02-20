namespace udemy_dotnet6_rpg.Services.WeaponService
{
	public interface IWeaponService
	{
		Task<ServiceResponse<GetCharacterDTO>> AddWeapon(AddWeaponDTO newWeapon);
	}
}
