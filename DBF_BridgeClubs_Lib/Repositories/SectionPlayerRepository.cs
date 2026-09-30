using DBF_BridgeClubs_Lib.Interfaces;
using DBF_BridgeClubs_Lib.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBF_BridgeClubs_Lib.Repositories
{
	public class SectionPlayerRepository : ISectionPlayerRepository
	{
		private string connectString = Secret.ConnectionString;
		private string selectSql = "SELECT P.ID AS SECTIONPLAYERID, P.FKSECTIONID AS SECTIONID, P.PLAYERNAME AS PLAYERNAME, P.STARTHAC AS STARTHAC, P.PLAYERNO AS PLAYERNO, P.PAIRNO AS PAIRNO, P.SUBSTITUTE AS SUBSTITUTE, P.ISCAPTAIN AS ISCAPTAIN, M.TOTAL_BRONZE AS TOTAL_BRONZE, M.TOTAL_SILVER AS TOTAL_SILVER, M.TOTAL_GOLD AS TOTAL_GOLD, M.TOTAL_MASTER AS TOTAL_MASTER FROM @SECTIONPLAYER P JOIN SECTIONTEAM T ON P.FKSECTIONTEAMID = T.ID JOIN MEM_MEMBER M ON P.FKPLAYERID = M.MEMBER_ID WHERE P.FKSECTIONID = @SECTIONID";

		public async Task<IEnumerable<SectionPlayer>> GetSectionPlayersAsync(string clubNo, int sectionId)
		{
			List<SectionPlayer> sectionPlayers = new List<SectionPlayer>();
			using (SqlConnection connect = new SqlConnection(connectString))
			{
				try
				{
					connect.OpenAsync();
					using (SqlCommand command = new SqlCommand(selectSql, connect))
					{
						command.Parameters.AddWithValue("@SECTIONPLAYER", "club" + clubNo + ".MEM_MEMBER");
						using (SqlDataReader reader = await command.ExecuteReaderAsync())
						{
							while (await reader.ReadAsync())
							{
								int sectionPlayerId = reader.GetInt32("SECTIONPLAYERID");
								int? fksectionId = reader.GetInt32("SECTIONID");
								string? playerName = reader.IsDBNull("PLAYERNAME") ? null : reader.GetString("PLAYERNAME");
								int? startHac = reader.IsDBNull("STARTHAC") ? null : reader.GetInt32("STARTHAC");
								int? playerNo = reader.IsDBNull("PLAYERNO") ? null : reader.GetInt32("PLAYERNO");
								int? pairNo = reader.IsDBNull("PAIRNO") ? null : reader.GetInt32("PAIRNO");
								int substitute = reader.GetInt32("SUBSTITUTE");
								int isCaptain = reader.GetInt32("ISCAPTAIN");
								int? totalBronze = reader.IsDBNull("TOTAL_BRONZE") ? null : reader.GetInt32("TOTAL_BRONZE");
								int? totalSilver = reader.IsDBNull("TOTAL_SILVER") ? null : reader.GetInt32("TOTAL_SILVER");
								int? totalGold = reader.IsDBNull("TOTAL_GOLD") ? null : reader.GetInt32("TOTAL_GOLD");
								int? totalMaster = reader.IsDBNull("TOTAL_MASTER") ? null : reader.GetInt32("TOTAL_MASTER");
								if (sectionId == fksectionId)
								{
									SectionPlayer sectionPlayer = new SectionPlayer(sectionPlayerId, fksectionId, playerName, startHac, playerNo, pairNo, substitute, isCaptain, totalBronze, totalSilver, totalGold, totalMaster);
									sectionPlayers.Add(sectionPlayer);
								}	
							}
						}
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine("Database Error: " + sqlEx.Message);
				}
			}
			return sectionPlayers;
		}
	}
}
