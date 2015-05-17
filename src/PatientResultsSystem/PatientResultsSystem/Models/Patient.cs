using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientResultsSystem.Models
{

    public enum StyleOfHearingAid
    {
        None, CIC, ITC, HalfShell, FullShell, MiniBTE, TraditionalBTE
    };

    public struct HearingAid
	{
        public string Make;
		public string Model;
		public string Serial;
		public DateTime FitDate;
        public StyleOfHearingAid Style;
        public char SideOfHead;

		public HearingAid(string make, string model, string serial, DateTime fitDate, StyleOfHearingAid style, char sideOfHead)
		{
			Make = make;
			Model = model;
			Serial = serial;
			FitDate = fitDate;
            Style = style;
            SideOfHead = sideOfHead;   // L for left, R for right
		}
	}

    public class Patient
    {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char MiddleInitial { get; set; }
        public string ID { get; set; }
        public DateTime TestDate { get; set; }
        public DateTime DoB { get; set; }
        public string Comments { get; set; }
        public HearingAid LeftEar { get; set; }
        public HearingAid RightEar { get; set; }
        public string ProviderName { get; set; }
        public string ClinicianID { get; set; }

		// Parameterized Constructor
        public Patient ( string fName, string lName, char midInit, string ID, DateTime testDate, DateTime DoB, 
			string Comments, HearingAid leftEar, HearingAid rightEar,string providerName, string clinicianID)
        {
	        this.FirstName = fName;
	        this.LastName = lName;
	        this.MiddleInitial = midInit;
	        this.ID = ID;
	        this.TestDate = testDate;
	        this.DoB = DoB;
	        this.Comments = Comments;
	        this.LeftEar = leftEar;
	        this.RightEar = rightEar;
            this.ProviderName = providerName;
            this.ClinicianID = clinicianID;
        }

        // Parameterized Constructor for getting patients from Patients table
        public Patient(string fName, string lName, char midInit, string ID, DateTime testDate, DateTime DoB, string Comments,
            string providerName, string clinicianID)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.MiddleInitial = midInit;
            this.ID = ID;
            this.TestDate = testDate;
            this.DoB = DoB;
            this.Comments = Comments;
            this.ProviderName = providerName;
            this.ClinicianID = clinicianID;
        }
    }
}
