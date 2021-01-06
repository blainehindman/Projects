using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DnD_WebApplication.Helper;

namespace DnD_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        Dictionary<string, string> Character_Dictionary = new Dictionary<string, string>();

        public ActionResult Index()
        {
            return View();
        }

        //controler
        [HttpPost]
        public JsonResult Inital_Player_Data(string[] Names, string[] Alignments)
        {
            //This function is not doing anything... Its here to verfy initial data
            //This can be done in Javascript
            //Eentually phase out this function
            return Json(0);
        }

        public double Calculate_Team_Alignment(string[] Alignments)
        {
            double Team_Alignment_Score = 0;
            int Counter = 0;

            foreach (var item in Alignments)
            {
                Counter = Counter + 1;

                //Good
                if (item == "Lawful_Good")
                {
                    Team_Alignment_Score = Team_Alignment_Score + 0.25;
                }
                if (item == "Neutral_Good")
                {
                    Team_Alignment_Score = Team_Alignment_Score + 0.5;
                }
                if (item == "Chaotic_Good")
                {
                    Team_Alignment_Score = Team_Alignment_Score + 1.25;
                }
                //Neutral
                if (item == "Lawful_Neutral")
                {
                    Team_Alignment_Score = Team_Alignment_Score + 0.75;
                }
                if (item == "True_Neutral")
                {
                    Team_Alignment_Score = Team_Alignment_Score + 1;
                }
                if (item == "Chaotic_Neutral")
                {
                    Team_Alignment_Score = Team_Alignment_Score + 1.2;
                }
                //Evil
                if (item == "Lawful_Evil")
                {
                    Team_Alignment_Score = Team_Alignment_Score + 1.25;
                }
                if (item == "Neutral_Evil")
                {
                    Team_Alignment_Score = Team_Alignment_Score + 1.5;
                }
                if (item == "Chaotic_Evil")
                {
                    Team_Alignment_Score = Team_Alignment_Score + 2;
                }
            }

            Team_Alignment_Score = Team_Alignment_Score / Counter;

            return(Team_Alignment_Score);
        }

        [HttpPost]
        public JsonResult Submit_Calculation_Data(string Character, string FibValue, string UserEvent, string SelectedAlignment, string[] Names, string[] Alignments)
        {
            Helper_Functions AddToDictionary;
            AddToDictionary = new Helper_Functions();
            AddToDictionary.UserDictionary(Names, Alignments);
            double Average_Alignment = 0;
            int Action_Scale = Int32.Parse(FibValue);

            if (Character == "Team")
            {
                Average_Alignment = Calculate_Team_Alignment(Alignments);
            }
            if(Character != "Team")
            {
                string[] AlignmentToArray = new string[] { SelectedAlignment};
                Average_Alignment = Calculate_Team_Alignment(AlignmentToArray);
            }

            Calculate_Consequence(Average_Alignment, Action_Scale);
            return Json(0);
        }

        public string Calculate_Consequence(double Average_Alignment, double Action_Scale)
        {
            string Consequence_Message = "";
            double Rho;
            double Unpredictable_External_Value = RandomNumberBetween(0.3,1.3);
            Rho = ((Average_Alignment * Action_Scale) / (Unpredictable_External_Value));
            //
            //After calulions are complete,
            //if Rho is greater then 20.5 then chaotic events begin to take place
            //We need to figure out out to take in the characters desrcibed event and then
            //explain what the event will cause in detail
            //
            return Consequence_Message;
        }

        public double RandomNumberBetween(double minValue, double maxValue)
        {
            Random random = new Random();
            var next = random.NextDouble();
            return next;
        }

        public void PartOfSpeach(string UserEvent)
        {
           
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}