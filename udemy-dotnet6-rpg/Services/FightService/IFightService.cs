﻿namespace udemy_dotnet6_rpg.Services.FightService
{
	public interface IFightService
	{
		Task<ServiceResponse<AttackResultDTO>> WeaponAttack(WeaponAttackDTO request);
	}
}
