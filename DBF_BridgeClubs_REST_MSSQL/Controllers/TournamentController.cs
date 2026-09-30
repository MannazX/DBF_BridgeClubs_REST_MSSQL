using DBF_BridgeClubs_Lib.Interfaces;
using DBF_BridgeClubs_Lib.Models;
using DBF_BridgeClubs_Lib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DBF_BridgeClubs_REST_MSSQL.Controllers
{
	[Route("api/Tournaments")]
	public class TournamentsController : Controller
	{
		private ITournamentRepository tournamentRepo;
		private ISectionRepository sectionRepo;

		public TournamentsController(ITournamentRepository tournamentRepository, ISectionRepository sectionRepository)
		{
			tournamentRepo = tournamentRepository;
			sectionRepo = sectionRepository;
		}

		[HttpGet("{clubNo}/Tournaments/{mainTournamentId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<GroupTournament>>> GetGroupTournaments(string clubNo, int mainTournamentId)
		{
			IEnumerable<GroupTournament> result = await tournamentRepo.GetGroupTournamentsByMaintournamentIdAsync(clubNo, mainTournamentId);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/Sections/{mainTournamentId}/Section")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<Section>>> GetSections(string clubNo, int mainTournamentId)
		{
			IEnumerable<Section> result = await sectionRepo.GetSectionsByMaintournamentIdAsync(clubNo, mainTournamentId);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}
	}
