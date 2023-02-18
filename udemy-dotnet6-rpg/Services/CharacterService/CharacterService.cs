﻿using Microsoft.EntityFrameworkCore;
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
		private readonly DataContext _context;

		public CharacterService(IMapper mapper, DataContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
			Character character = _mapper.Map<Character>(newCharacter);
			_context.Characters.Add(character);
			await _context.SaveChangesAsync();
			serviceResponse.Data = await _context.Characters
				.Select(c => _mapper.Map<GetCharacterDTO>(c))
				.ToListAsync();
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
		{
			ServiceResponse<List<GetCharacterDTO>> response = new ServiceResponse<List<GetCharacterDTO>>();

			try
			{
				Character character = characters.First(c => c.Id == id);
				characters.Remove(character);
				response.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
		{
			var response = new ServiceResponse<List<GetCharacterDTO>>();
			var dbCharacters = await _context.Characters.ToListAsync();
			response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
			return response;
		}

		public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
		{
			var serviceResponse = new ServiceResponse<GetCharacterDTO>();
			var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
			serviceResponse.Data = _mapper.Map<GetCharacterDTO>(dbCharacter);
			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
		{
			ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();

			try
			{
				Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

				character.Name = updatedCharacter.Name;
				character.HitPoints = updatedCharacter.HitPoints;
				character.Strength = updatedCharacter.Strength;
				character.Defense = updatedCharacter.Defense;
				character.Intelligence = updatedCharacter.Intelligence;
				character.Class = updatedCharacter.Class;

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
