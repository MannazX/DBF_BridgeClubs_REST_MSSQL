using DBF_BridgeClubs_Lib.Interfaces;
using DBF_BridgeClubs_Lib.Models;
using DBF_BridgeClubs_Lib.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DBF_BridgeClubs_REST_MSSQL.Controllers
{
	public class ClubController : Controller
	{
		private IMainClubRepository mainClubRepo;
		private IMemberClubRepository memberClubRepo;
		private IMemberRepository memberRepo;
		private ISubClubRepository subClubRepo;
		private ITournamentRepository tournamentRepo;
		public ClubController(IMainClubRepository mainClubRepository, IMemberClubRepository memberClubRepository, IMemberRepository memRepository, ISubClubRepository subClubRepository, ITournamentRepository tournamentRepository)
		{
			mainClubRepo = mainClubRepository;
			memberClubRepo = memberClubRepository;
			memberRepo = memRepository;
			subClubRepo = subClubRepository;
			tournamentRepo = tournamentRepository;
		}

		[HttpGet("{clubNo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<MainClub>> GetClub(string clubNo)
		{
			MainClub result = await mainClubRepo.GetMainClubAsync(clubNo);
			if (result == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/SubClubs")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<SubClub>>> GetSubClub(string clubNo)
		{
			IEnumerable<SubClub> result = await subClubRepo.GetSubClubsAsync(clubNo);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{clubNo}/Members")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<Member>>> GetMembers(string clubNo)
		{
			IEnumerable<Member> result = await memberRepo.GetMembersAsync(clubNo);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{fdbNo}/Members/{memberNo}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Member>> GetMembersByNo(string clubNo, int memberNo)
		{
			Member result = await memberRepo.GetMemberByMemberNoAsync(clubNo, memberNo);
			if (result == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{fdbNo}/MemberClubs")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<MemberClub>> GetMemberClubs(string clubNo)
		{
			IEnumerable<MemberClub> result = await memberClubRepo.GetMemberClubsAsync(clubNo);
			if (result.Count() == 0)
			{
				return NoContent();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet("{fdbNo}/{clubId}/Tournaments")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<MainTournament>>> GetTournaments(string clubNo, int clubId)
		{
			IEnumerable<MainTournament> result = await tournamentRepo.GetMainTournamentByClubIdAsync(clubNo, clubId);
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
}
