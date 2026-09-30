using DBF_BridgeClubs_Lib.Models;

namespace DBF_BridgeClubs_Lib.Interfaces
{
	public interface ISectionPlayerRepository
	{
		Task<IEnumerable<SectionPlayer>> GetSectionPlayersAsync(string clubNo, int sectionId);
	}
}