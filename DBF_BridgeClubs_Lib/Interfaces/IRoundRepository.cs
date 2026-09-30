using DBF_BridgeClubs_Lib.Models;

namespace DBF_BridgeClubs_Lib.Interfaces
{
	public interface IRoundRepository
	{
		Task<List<Round>> GetRoundsAsync(string clubNo, int sectionId);
	}
}