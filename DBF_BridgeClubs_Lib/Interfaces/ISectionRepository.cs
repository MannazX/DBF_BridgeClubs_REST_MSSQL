using DBF_BridgeClubs_Lib.Models;

namespace DBF_BridgeClubs_Lib.Interfaces
{
	public interface ISectionRepository
	{
		Task<IEnumerable<Section>> GetSectionsByMaintournamentIdAsync(string clubNo, int maintournamentId);
	}
}