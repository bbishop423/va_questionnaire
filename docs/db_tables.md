### Tables
  1. Users
    * Username varchar32 PK
    * Password varchar32
    * FirstName varchar32
    * LastName varchar32
    * UserType varchar32
  2. Patients
    * idNumber varchar32 PK
	* FirstName varchar32
    * LastName varchar32
	* MiddleInitial char
	* ProviderName varchar32
	* TestDate date
	* DOB date
	* Comments text
	* ClinicianID varchar32 FK to Users.Username
  3. EarInfo
    * idNumber int PK (Auto Incrementing)
	* Make varchar32
	* Model varchar32
	* Serial varchar32
	* FitDate date
	* Style varchar15
	* SideOfHead char
	* PatientID varchar32 FK to Patients.idNumber

### Test Data in Tables
#### Users

  1. ----------------------------
    * admin
    * password (encrypted)
	* John
	* Doe
	* administrator
  2. ----------------------------
	* clinician
	* password (encrypted)
	* Jane
	* Doe
	* clinician

#### Patients
  1. ----------------------------
    * P1234567
	* Joe
	* Shmoe
	* A
	* Random Health Care
	* 2015-01-31
	* 1970-01-31
	* Joe sure is awesome.
	* clinician
  2. ----------------------------
	* P1111111
	* James
	* Davis
	* B
	* My Health Provider
	* 2014-02-28
	* 1980-04-15
	* I hate James!
	* clinician
  3. ----------------------------
	* P2222222
	* Rick
	* James
	* F
	* Yo Couch Healthcare
	* 2013-12-30
	* 1950-08-27
	* I'm Rick James!
	* clinician
	
#### EarInfo
  1. ----------------------------
    * 1
	* Ford
	* F350
	* ABC123
	* 2014-09-30
	* CIC
	* L
	* P1111111
  2. ----------------------------
	* 2
	* Chevrolet
	* Silverado
	* XYZ789
	* 2015-02-18
	* HalfShell
	* R
	* P2222222
  3. ----------------------------
	* 3
	* Cadillac
	* CTS-V
	* JKL345
	* 2014-09-19
	* TraditionalBTE
	* L
	* P2222222

### Notes
* In the Users table I made the Username column the primary key.
* The reason idNumber in Patients is varchar32 is because I'm assuming the ID number is like our ETSU E numbers.
* ClinicianID in Patients is a foreign key that references back to the clinician Username in Users so each clinician can track the patients that they are seeing.
* EarInfo table is a table that will reference a Patient with PatientID being the foreign key referencing back to idNumber in Patients.
* In EarInfo SideOfHead is a char that will hold either 'L' or 'R' depending on which ear is being referenced, this is to take care of the fact that a patient might have only 1 hearing aid so that eliminates a bunch of null fields if we had both ears in 1 table.  So tables are only created for ears that are being examined by the clinician.
* Style is varchar15 because I counted the letters in the list on D2L for hearing aid styles and that was the maximum amount of letters out of the list of types.
* Whenever inserting new hearing aids into the EarInfo table always pass in null as the first column parameter for the primary key because I have it set up to auto generate the primary key.
* These are just general notes I came up with from obvious things that might not be clear from the documentation I have written up.  If you guys have any other questions just let me know.