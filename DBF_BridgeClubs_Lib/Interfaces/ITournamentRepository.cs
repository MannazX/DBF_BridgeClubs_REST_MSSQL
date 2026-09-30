using DBF_BridgeClubs_Lib.Models;

namespace DBF_BridgeClubs_Lib.Interfaces
{
	public interface ITournamentRepository
	{
		Task<IEnumerable<MainTournament>> GetMainTournamentsByClubIdAsync(string clubNo, int clubId);
		Task<IEnumerable<GroupTournament>> GetGroupTournamentsByMaintournamentIdAsync(string clubNo, int mainTournamentId);
	}
}