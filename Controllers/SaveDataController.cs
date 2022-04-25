using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Assingment1_FootballLeague.Controllers
{
    public class SaveDataController : Controller
    {
        public ActionResult SaveData()
        {
            ViewBag.result = "";
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(string MatchId, string TeamName1,string TeamName2,string status,string WinningTeam, string Points )

        {
            String constring = "Data Source=DESKTOP-I74GCFC; Initial Catalog=FootballLeague; Integrated Security=true";
            SqlConnection sqlcon = new SqlConnection(constring);
            String Team = "TeamDataInsert"; ;
            sqlcon.Open();
            SqlCommand com = new SqlCommand(Team, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MatchId", Convert.ToInt16(MatchId));
            com.Parameters.AddWithValue("@TeamName1", TeamName1);
            com.Parameters.AddWithValue("@TeamName2", TeamName2);
            com.Parameters.AddWithValue("@status", status);
            com.Parameters.AddWithValue("@WinningTeam", WinningTeam);
            com.Parameters.AddWithValue("@Points", Points);

            com.ExecuteNonQuery();
            sqlcon.Close();
            ViewBag.result = "Record Has Been Saved Successfully";
            return View();
        }
    }
}
