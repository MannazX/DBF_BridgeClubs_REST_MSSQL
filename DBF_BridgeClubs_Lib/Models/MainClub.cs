namespace DBF_BridgeClubs_Lib.Models
{
	public class MainClub
	{
		#region Properties
		public int MainClubID { get; set; }
		public int? OrgMainClubID { get; set; }
		public int? OrgClubNo { get; set; }
		public string? Location { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? ZipCode { get; set; }
		public string? City { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
		public string? HomePage { get; set; }
		public string? SeasonStart { get; set; }

		#endregion

		#region Constructors
		public MainClub()
		{

		}

		public MainClub(int mainClubId, int? orgMainClubId, int? orgClubNo, string? location, string? name, string? address, string? zipCode, string? city, string? phone, string? email, string? homePage, string? seasonStart)
		{
			MainClubID = mainClubId;
			OrgMainClubID = orgMainClubId;
			OrgClubNo = orgClubNo;
			Location = location;
			Name = name;
			Address = address;
			ZipCode = zipCode;
			City = city;
			Phone = phone;
			Email = email;
			HomePage = homePage;
			SeasonStart = seasonStart;
		}
		#endregion
	}
}
